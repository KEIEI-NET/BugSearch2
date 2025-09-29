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
// 修 正 日  2011/09/15  修正内容 : #24923 ファイルレイアウト変更による項目追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
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
    /// 売上履歴明細データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: PMKOBETSU-3877の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/09/25</br>
    /// </remarks>
    public class APSalesHistDtlDB : RemoteDB
    {
        /// <summary>
        /// 売上履歴明細データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APSalesHistDtlDB()
        {
        }

        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="salesHistDtlArrList">売上履歴明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上履歴明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchSalesHistDtl(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList salesHistDtlArrList, out string retMessage)
        {
            return SearchSalesHistDtlProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  salesHistDtlArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="salesHistDtlArrList">売上履歴明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上履歴明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchSalesHistDtlProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList salesHistDtlArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            salesHistDtlArrList = new ArrayList();
            APSalesHistDtlWork salesHistDtlWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF FROM SALESHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 売上履歴明細データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    salesHistDtlWork = new APSalesHistDtlWork();

                    salesHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    salesHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    salesHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    salesHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    salesHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    salesHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    salesHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    salesHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    salesHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    salesHistDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    salesHistDtlWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    salesHistDtlWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    salesHistDtlWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
                    salesHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    salesHistDtlWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    salesHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    salesHistDtlWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    salesHistDtlWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                    salesHistDtlWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
                    salesHistDtlWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
                    salesHistDtlWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF")); salesHistDtlWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    salesHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    salesHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    salesHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    salesHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                    salesHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    salesHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    salesHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    salesHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    salesHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                    salesHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    salesHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    salesHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    salesHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                    salesHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    salesHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    salesHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    salesHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                    salesHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    salesHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    salesHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    salesHistDtlWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    salesHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    salesHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    salesHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    salesHistDtlWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
                    salesHistDtlWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
                    salesHistDtlWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
                    salesHistDtlWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
                    salesHistDtlWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
                    salesHistDtlWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
                    salesHistDtlWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
                    salesHistDtlWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
                    salesHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    salesHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    salesHistDtlWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
                    salesHistDtlWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                    salesHistDtlWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
                    salesHistDtlWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
                    salesHistDtlWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
                    salesHistDtlWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
                    salesHistDtlWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                    salesHistDtlWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
                    salesHistDtlWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
                    salesHistDtlWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                    salesHistDtlWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    salesHistDtlWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
                    salesHistDtlWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
                    salesHistDtlWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
                    salesHistDtlWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
                    salesHistDtlWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
                    salesHistDtlWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
                    salesHistDtlWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
                    salesHistDtlWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
                    salesHistDtlWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
                    salesHistDtlWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    salesHistDtlWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
                    salesHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                    salesHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                    salesHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
                    salesHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
                    salesHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
                    salesHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
                    salesHistDtlWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    salesHistDtlWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
                    salesHistDtlWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    salesHistDtlWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                    salesHistDtlWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
                    salesHistDtlWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    salesHistDtlWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                    salesHistDtlWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    salesHistDtlWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    salesHistDtlWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
                    salesHistDtlWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                    salesHistDtlWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
                    salesHistDtlWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    salesHistDtlWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                    salesHistDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    salesHistDtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    salesHistDtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    salesHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    salesHistDtlWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
                    salesHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    salesHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    salesHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    salesHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    salesHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    salesHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    salesHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                    salesHistDtlWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                    salesHistDtlWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                    salesHistDtlWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
                    salesHistDtlWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
                    salesHistDtlWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
                    salesHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
                    salesHistDtlWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
                    salesHistDtlWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
                    salesHistDtlWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
                    salesHistDtlWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
                    salesHistDtlWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
                    salesHistDtlWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
                    salesHistDtlWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
                    salesHistDtlWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
                    salesHistDtlWork.PrtGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
                    salesHistDtlWork.PrtMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTMAKERCODERF"));
                    salesHistDtlWork.PrtMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTMAKERNAMERF"));
                    // ↓ 2009.05.26 liuyang add
                    salesHistDtlWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
                    salesHistDtlWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));
                    salesHistDtlWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));
                    salesHistDtlWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATERF"));
                    salesHistDtlWork.RecycleDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEDIVRF"));
                    salesHistDtlWork.RecycleDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEDIVNMRF"));
                    salesHistDtlWork.WayToAcptOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOACPTODRRF"));
                    // ↑ 2009.05.26 liuyang add

                    salesHistDtlArrList.Add(salesHistDtlWork);
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
        /// 売上履歴明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesHistDtlList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateSalesHistDtl(string enterPriseCode, ArrayList salesHistDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateSalesHistDtlProc(enterPriseCode, salesHistDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesHistDtlList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateSalesHistDtlProc(string enterPriseCode, ArrayList salesHistDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteSalesHistDtl(enterPriseCode, salesHistDtlList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertSalesHistDtl(enterPriseCode, salesHistDtlList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesHistDtlList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteSalesHistDtl(string enterPriseCode, ArrayList salesHistDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteSalesHistDtlProc(enterPriseCode, salesHistDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesHistDtlList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteSalesHistDtlProc(string enterPriseCode, ArrayList salesHistDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APSalesHistDtlWork salesHistDtlWork in salesHistDtlList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                // modified by zhubj for 仕様変更 start on 20090429
                //sqlText = "DELETE FROM SALESHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";
                sqlText = "DELETE FROM SALESHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";
                // modified by zhubj for 仕様変更 end on 20090429
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                // modified by zhubj for 仕様変更 start on 20090429
                //SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                // modified by zhubj for 仕様変更 end on 20090429
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaAcptAnOdrStatus.Value = salesHistDtlWork.AcptAnOdrStatus;
                // modified by zhubj for 仕様変更 start on 20090429
                //findParaSalesSlipDtlNum.Value = salesHistDtlWork.SalesSlipDtlNum;
                findParaSalesSlipNum.Value = salesHistDtlWork.SalesSlipNum;
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
        /// 売上履歴明細データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesHistDtlList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertSalesHistDtl(string enterPriseCode, ArrayList salesHistDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertSalesHistDtlProc(enterPriseCode, salesHistDtlList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴明細データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesHistDtlList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        private int InsertSalesHistDtlProc(string enterPriseCode, ArrayList salesHistDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                foreach (APSalesHistDtlWork salesHistDtlWork in salesHistDtlList)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

					//sqlText = "INSERT INTO SALESHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR)"; // DEL 2011/09/15
                    // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                    //sqlText = "INSERT INTO SALESHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF, AUTOANSWERDIVSCMRF, ACCEPTORORDERKINDRF, INQUIRYNUMBERRF, INQROWNUMBERRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR, @AUTOANSWERDIVSCM, @ACCEPTORORDERKIND, @INQUIRYNUMBER, @INQROWNUMBER)"; // ADD 2011/09/15
                    sqlText = "INSERT INTO SALESHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF, AUTOANSWERDIVSCMRF, ACCEPTORORDERKINDRF, INQUIRYNUMBERRF, INQROWNUMBERRF, RENTSYNCSUPPLIERRF, RENTSYNCSTOCKDATERF, RENTSYNCSUPSLIPNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR, @AUTOANSWERDIVSCM, @ACCEPTORORDERKIND, @INQUIRYNUMBER, @INQROWNUMBER, @RENTSYNCSUPPLIER, @RENTSYNCSTOCKDATE, @RENTSYNCSUPSLIPNO)";
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<

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
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSalesRowNo = sqlCommand.Parameters.Add("@SALESROWNO", SqlDbType.Int);
                    SqlParameter paraSalesRowDerivNo = sqlCommand.Parameters.Add("@SALESROWDERIVNO", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                    SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                    SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                    SqlParameter paraAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSRC", SqlDbType.Int);
                    SqlParameter paraSalesSlipDtlNumSrc = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSRC", SqlDbType.BigInt);
                    SqlParameter paraSupplierFormalSync = sqlCommand.Parameters.Add("@SUPPLIERFORMALSYNC", SqlDbType.Int);
                    SqlParameter paraStockSlipDtlNumSync = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSYNC", SqlDbType.BigInt);
                    SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@SALESSLIPCDDTL", SqlDbType.Int);
                    SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                    SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
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
                    SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                    SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                    SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                    SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                    SqlParameter paraListPriceRate = sqlCommand.Parameters.Add("@LISTPRICERATE", SqlDbType.Float);
                    SqlParameter paraRateSectPriceUnPrc = sqlCommand.Parameters.Add("@RATESECTPRICEUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivLPrice = sqlCommand.Parameters.Add("@RATEDIVLPRICE", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdLPrice = sqlCommand.Parameters.Add("@UNPRCCALCCDLPRICE", SqlDbType.Int);
                    SqlParameter paraPriceCdLPrice = sqlCommand.Parameters.Add("@PRICECDLPRICE", SqlDbType.Int);
                    SqlParameter paraStdUnPrcLPrice = sqlCommand.Parameters.Add("@STDUNPRCLPRICE", SqlDbType.Float);
                    SqlParameter paraFracProcUnitLPrice = sqlCommand.Parameters.Add("@FRACPROCUNITLPRICE", SqlDbType.Float);
                    SqlParameter paraFracProcLPrice = sqlCommand.Parameters.Add("@FRACPROCLPRICE", SqlDbType.Int);
                    SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                    SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                    SqlParameter paraListPriceChngCd = sqlCommand.Parameters.Add("@LISTPRICECHNGCD", SqlDbType.Int);
                    SqlParameter paraSalesRate = sqlCommand.Parameters.Add("@SALESRATE", SqlDbType.Float);
                    SqlParameter paraRateSectSalUnPrc = sqlCommand.Parameters.Add("@RATESECTSALUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivSalUnPrc = sqlCommand.Parameters.Add("@RATEDIVSALUNPRC", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdSalUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSALUNPRC", SqlDbType.Int);
                    SqlParameter paraPriceCdSalUnPrc = sqlCommand.Parameters.Add("@PRICECDSALUNPRC", SqlDbType.Int);
                    SqlParameter paraStdUnPrcSalUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSALUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcUnitSalUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSALUNPRC", SqlDbType.Float);
                    SqlParameter paraFracProcSalUnPrc = sqlCommand.Parameters.Add("@FRACPROCSALUNPRC", SqlDbType.Int);
                    SqlParameter paraSalesUnPrcTaxIncFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXINCFL", SqlDbType.Float);
                    SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
                    SqlParameter paraSalesUnPrcChngCd = sqlCommand.Parameters.Add("@SALESUNPRCCHNGCD", SqlDbType.Int);
                    SqlParameter paraCostRate = sqlCommand.Parameters.Add("@COSTRATE", SqlDbType.Float);
                    SqlParameter paraRateSectCstUnPrc = sqlCommand.Parameters.Add("@RATESECTCSTUNPRC", SqlDbType.NChar);
                    SqlParameter paraRateDivUnCst = sqlCommand.Parameters.Add("@RATEDIVUNCST", SqlDbType.NChar);
                    SqlParameter paraUnPrcCalcCdUnCst = sqlCommand.Parameters.Add("@UNPRCCALCCDUNCST", SqlDbType.Int);
                    SqlParameter paraPriceCdUnCst = sqlCommand.Parameters.Add("@PRICECDUNCST", SqlDbType.Int);
                    SqlParameter paraStdUnPrcUnCst = sqlCommand.Parameters.Add("@STDUNPRCUNCST", SqlDbType.Float);
                    SqlParameter paraFracProcUnitUnCst = sqlCommand.Parameters.Add("@FRACPROCUNITUNCST", SqlDbType.Float);
                    SqlParameter paraFracProcUnCst = sqlCommand.Parameters.Add("@FRACPROCUNCST", SqlDbType.Int);
                    SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                    SqlParameter paraSalesUnitCostChngDiv = sqlCommand.Parameters.Add("@SALESUNITCOSTCHNGDIV", SqlDbType.Int);
                    SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                    SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                    SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                    SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                    SqlParameter paraPrtBLGoodsCode = sqlCommand.Parameters.Add("@PRTBLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraPrtBLGoodsName = sqlCommand.Parameters.Add("@PRTBLGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                    SqlParameter paraSalesCdNm = sqlCommand.Parameters.Add("@SALESCDNM", SqlDbType.NVarChar);
                    SqlParameter paraWorkManHour = sqlCommand.Parameters.Add("@WORKMANHOUR", SqlDbType.Float);
                    SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraSalesMoneyTaxInc = sqlCommand.Parameters.Add("@SALESMONEYTAXINC", SqlDbType.BigInt);
                    SqlParameter paraSalesMoneyTaxExc = sqlCommand.Parameters.Add("@SALESMONEYTAXEXC", SqlDbType.BigInt);
                    SqlParameter paraCost = sqlCommand.Parameters.Add("@COST", SqlDbType.BigInt);
                    SqlParameter paraGrsProfitChkDiv = sqlCommand.Parameters.Add("@GRSPROFITCHKDIV", SqlDbType.Int);
                    SqlParameter paraSalesGoodsCd = sqlCommand.Parameters.Add("@SALESGOODSCD", SqlDbType.Int);
                    SqlParameter paraSalesPriceConsTax = sqlCommand.Parameters.Add("@SALESPRICECONSTAX", SqlDbType.BigInt);
                    SqlParameter paraTaxationDivCd = sqlCommand.Parameters.Add("@TAXATIONDIVCD", SqlDbType.Int);
                    SqlParameter paraPartySlipNumDtl = sqlCommand.Parameters.Add("@PARTYSLIPNUMDTL", SqlDbType.NVarChar);
                    SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@DTLNOTE", SqlDbType.NVarChar);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                    SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                    SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                    SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                    SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                    SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                    SqlParameter paraBfSalesUnitPrice = sqlCommand.Parameters.Add("@BFSALESUNITPRICE", SqlDbType.Float);
                    SqlParameter paraBfUnitCost = sqlCommand.Parameters.Add("@BFUNITCOST", SqlDbType.Float);
                    SqlParameter paraCmpltSalesRowNo = sqlCommand.Parameters.Add("@CMPLTSALESROWNO", SqlDbType.Int);
                    SqlParameter paraCmpltGoodsMakerCd = sqlCommand.Parameters.Add("@CMPLTGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraCmpltMakerName = sqlCommand.Parameters.Add("@CMPLTMAKERNAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltMakerKanaName = sqlCommand.Parameters.Add("@CMPLTMAKERKANANAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltGoodsName = sqlCommand.Parameters.Add("@CMPLTGOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraCmpltShipmentCnt = sqlCommand.Parameters.Add("@CMPLTSHIPMENTCNT", SqlDbType.Float);
                    SqlParameter paraCmpltSalesUnPrcFl = sqlCommand.Parameters.Add("@CMPLTSALESUNPRCFL", SqlDbType.Float);
                    SqlParameter paraCmpltSalesMoney = sqlCommand.Parameters.Add("@CMPLTSALESMONEY", SqlDbType.BigInt);
                    SqlParameter paraCmpltSalesUnitCost = sqlCommand.Parameters.Add("@CMPLTSALESUNITCOST", SqlDbType.Float);
                    SqlParameter paraCmpltCost = sqlCommand.Parameters.Add("@CMPLTCOST", SqlDbType.BigInt);
                    SqlParameter paraCmpltPartySalSlNum = sqlCommand.Parameters.Add("@CMPLTPARTYSALSLNUM", SqlDbType.NVarChar);
                    SqlParameter paraCmpltNote = sqlCommand.Parameters.Add("@CMPLTNOTE", SqlDbType.NVarChar);
                    SqlParameter paraPrtGoodsNo = sqlCommand.Parameters.Add("@PRTGOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraPrtMakerCode = sqlCommand.Parameters.Add("@PRTMAKERCODE", SqlDbType.Int);
                    SqlParameter paraPrtMakerName = sqlCommand.Parameters.Add("@PRTMAKERNAME", SqlDbType.NVarChar);
                    // ↓ 2009.05.26 liuyang add
                    SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                    SqlParameter paraCampaignName = sqlCommand.Parameters.Add("@CAMPAIGNNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsDivCd = sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
                    SqlParameter paraAnswerDelivDate = sqlCommand.Parameters.Add("@ANSWERDELIVDATE", SqlDbType.NVarChar);
                    SqlParameter paraRecycleDiv = sqlCommand.Parameters.Add("@RECYCLEDIV", SqlDbType.Int);
                    SqlParameter paraRecycleDivNm = sqlCommand.Parameters.Add("@RECYCLEDIVNM", SqlDbType.NVarChar);
                    SqlParameter paraWayToAcptOdr = sqlCommand.Parameters.Add("@WAYTOACPTODR", SqlDbType.Int);
                    // ↑ 2009.05.26 liuyang add
					// ADD 2011/09/15 ---------->>>>>
					SqlParameter paraAutoAnswerDivSCM = sqlCommand.Parameters.Add("@AUTOANSWERDIVSCM", SqlDbType.Int);
					SqlParameter paraAcceptOrOrderKind = sqlCommand.Parameters.Add("@ACCEPTORORDERKIND", SqlDbType.Int);
					SqlParameter paraInquiryNumber = sqlCommand.Parameters.Add("@INQUIRYNUMBER", SqlDbType.Int);
					SqlParameter paraInqRowNumber = sqlCommand.Parameters.Add("@INQROWNUMBER", SqlDbType.Int);
					// ADD 2011/09/15 ----------<<<<<
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                    SqlParameter paraRentSyncSupplier = sqlCommand.Parameters.Add("@RENTSYNCSUPPLIER", SqlDbType.Int); // 貸出同時仕入先
                    SqlParameter paraRentSyncStockDate = sqlCommand.Parameters.Add("@RENTSYNCSTOCKDATE", SqlDbType.Int); // 貸出同時仕入日
                    SqlParameter paraRentSyncSupSlipNo = sqlCommand.Parameters.Add("@RENTSYNCSUPSLIPNO", SqlDbType.NVarChar); // 貸出同時仕入伝票番号
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistDtlWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistDtlWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesHistDtlWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.LogicalDeleteCode);
                    paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.AcceptAnOrderNo);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SalesSlipNum);
                    paraSalesRowNo.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesRowNo);
                    paraSalesRowDerivNo.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesRowDerivNo);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SectionCode);
                    paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SubSectionCode);
                    paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesHistDtlWork.SalesDate);
                    paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.CommonSeqNo);
                    paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.SalesSlipDtlNum);
                    paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.AcptAnOdrStatusSrc);
                    paraSalesSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.SalesSlipDtlNumSrc);
                    paraSupplierFormalSync.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SupplierFormalSync);
                    paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.StockSlipDtlNumSync);
                    paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesSlipCdDtl);
                    paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.GoodsKindCode);
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.GoodsMakerCd);
                    paraMakerName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.MakerName);
                    paraMakerKanaName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.MakerKanaName);
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.GoodsNo);
                    paraGoodsName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.GoodsName);
                    paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.GoodsNameKana);
                    paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.GoodsLGroup);
                    paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.GoodsLGroupName);
                    paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.GoodsMGroup);
                    paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.GoodsMGroupName);
                    paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.BLGroupCode);
                    paraBLGroupName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.BLGroupName);
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.BLGoodsCode);
                    paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.BLGoodsFullName);
                    paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.EnterpriseGanreCode);
                    paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.EnterpriseGanreName);
                    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.WarehouseCode);
                    paraWarehouseName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.WarehouseName);
                    paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.WarehouseShelfNo);
                    paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesOrderDivCd);
                    paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.OpenPriceDiv);
                    paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.GoodsRateRank);
                    paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.CustRateGrpCode);
                    paraListPriceRate.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.ListPriceRate);
                    paraRateSectPriceUnPrc.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateSectPriceUnPrc);
                    paraRateDivLPrice.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateDivLPrice);
                    paraUnPrcCalcCdLPrice.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.UnPrcCalcCdLPrice);
                    paraPriceCdLPrice.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.PriceCdLPrice);
                    paraStdUnPrcLPrice.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.StdUnPrcLPrice);
                    paraFracProcUnitLPrice.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.FracProcUnitLPrice);
                    paraFracProcLPrice.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.FracProcLPrice);
                    paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.ListPriceTaxIncFl);
                    paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.ListPriceTaxExcFl);
                    paraListPriceChngCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.ListPriceChngCd);
                    paraSalesRate.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.SalesRate);
                    paraRateSectSalUnPrc.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateSectSalUnPrc);
                    paraRateDivSalUnPrc.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateDivSalUnPrc);
                    paraUnPrcCalcCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.UnPrcCalcCdSalUnPrc);
                    paraPriceCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.PriceCdSalUnPrc);
                    paraStdUnPrcSalUnPrc.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.StdUnPrcSalUnPrc);
                    paraFracProcUnitSalUnPrc.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.FracProcUnitSalUnPrc);
                    paraFracProcSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.FracProcSalUnPrc);
                    paraSalesUnPrcTaxIncFl.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.SalesUnPrcTaxIncFl);
                    paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.SalesUnPrcTaxExcFl);
                    paraSalesUnPrcChngCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesUnPrcChngCd);
                    paraCostRate.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.CostRate);
                    paraRateSectCstUnPrc.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateSectCstUnPrc);
                    paraRateDivUnCst.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateDivUnCst);
                    paraUnPrcCalcCdUnCst.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.UnPrcCalcCdUnCst);
                    paraPriceCdUnCst.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.PriceCdUnCst);
                    paraStdUnPrcUnCst.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.StdUnPrcUnCst);
                    paraFracProcUnitUnCst.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.FracProcUnitUnCst);
                    paraFracProcUnCst.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.FracProcUnCst);
                    paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.SalesUnitCost);
                    paraSalesUnitCostChngDiv.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesUnitCostChngDiv);
                    paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.RateBLGoodsCode);
                    paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateBLGoodsName);
                    paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.RateGoodsRateGrpCd);
                    paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateGoodsRateGrpNm);
                    paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.RateBLGroupCode);
                    paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RateBLGroupName);
                    paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.PrtBLGoodsCode);
                    paraPrtBLGoodsName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.PrtBLGoodsName);
                    paraSalesCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesCode);
                    paraSalesCdNm.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SalesCdNm);
                    paraWorkManHour.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.WorkManHour);
                    paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.ShipmentCnt);
                    paraSalesMoneyTaxInc.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.SalesMoneyTaxInc);
                    paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.SalesMoneyTaxExc);
                    paraCost.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.Cost);
                    paraGrsProfitChkDiv.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.GrsProfitChkDiv);
                    paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SalesGoodsCd);
                    paraSalesPriceConsTax.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.SalesPriceConsTax);
                    paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.TaxationDivCd);
                    paraPartySlipNumDtl.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.PartySlipNumDtl);
                    paraDtlNote.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.DtlNote);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.SupplierCd);
                    paraSupplierSnm.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SupplierSnm);
                    paraOrderNumber.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.OrderNumber);
                    paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.WayToOrder);
                    paraSlipMemo1.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SlipMemo1);
                    paraSlipMemo2.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SlipMemo2);
                    paraSlipMemo3.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.SlipMemo3);
                    paraInsideMemo1.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.InsideMemo1);
                    paraInsideMemo2.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.InsideMemo2);
                    paraInsideMemo3.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.InsideMemo3);
                    paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.BfListPrice);
                    paraBfSalesUnitPrice.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.BfSalesUnitPrice);
                    paraBfUnitCost.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.BfUnitCost);
                    paraCmpltSalesRowNo.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.CmpltSalesRowNo);
                    paraCmpltGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.CmpltGoodsMakerCd);
                    paraCmpltMakerName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.CmpltMakerName);
                    paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.CmpltMakerKanaName);
                    paraCmpltGoodsName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.CmpltGoodsName);
                    paraCmpltShipmentCnt.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.CmpltShipmentCnt);
                    paraCmpltSalesUnPrcFl.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.CmpltSalesUnPrcFl);
                    paraCmpltSalesMoney.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.CmpltSalesMoney);
                    paraCmpltSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(salesHistDtlWork.CmpltSalesUnitCost);
                    paraCmpltCost.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.CmpltCost);
                    paraCmpltPartySalSlNum.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.CmpltPartySalSlNum);
                    paraCmpltNote.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.CmpltNote);
                    paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.PrtGoodsNo);
                    paraPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.PrtMakerCode);
                    paraPrtMakerName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.PrtMakerName);
                    // ↓ 2009.05.26 liuyang add
                    paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.CampaignCode);
                    paraCampaignName.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.CampaignName);
                    paraGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.GoodsDivCd);
                    paraAnswerDelivDate.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.AnswerDelivDate);
                    paraRecycleDiv.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.RecycleDiv);
                    paraRecycleDivNm.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RecycleDivNm);
                    paraWayToAcptOdr.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.WayToAcptOdr);
                    // ↑ 2009.05.26 liuyang add
					// ADD 2011/09/15 ---------->>>>>
					paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.AutoAnswerDivSCM);
					paraAcceptOrOrderKind.Value = SqlDataMediator.SqlSetInt16(salesHistDtlWork.AcceptOrOrderKind);
					paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(salesHistDtlWork.InquiryNumber);
					paraInqRowNumber.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.InqRowNumber);
					// ADD 2011/09/15 ----------<<<<<
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                    paraRentSyncSupplier.Value = SqlDataMediator.SqlSetInt32(salesHistDtlWork.RentSyncSupplier); // 貸出同時仕入先
                    paraRentSyncStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesHistDtlWork.RentSyncStockDate); // 貸出同時仕入日
                    paraRentSyncSupSlipNo.Value = SqlDataMediator.SqlSetString(salesHistDtlWork.RentSyncSupSlipNo); // 貸出同時仕入伝票番号
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<

                    sqlCommand.CommandText = sqlText;
                    //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                    sqlCommand.CommandTimeout = 600;
                    //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex, "SalesHistDtlDB.InsertSalesHistDtl(salesHistDtlList, ref SqlConnection, ref SqlTransaction)", ex.Number);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → SupplierWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public APSalesHistDtlWork CopyToSalesHistDtlWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APSalesHistDtlWork salesHistDtlWork = new APSalesHistDtlWork();

			this.CopyToSalesHistDtlWorkFromReaderSCM(ref myReader, ref salesHistDtlWork, tableNm);

			return salesHistDtlWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → salesHistDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="salesHistDtlWork">salesHistDtlWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
		private void CopyToSalesHistDtlWorkFromReaderSCM(ref SqlDataReader myReader, ref APSalesHistDtlWork salesHistDtlWork, string tableNm)
		{
			if (myReader != null && salesHistDtlWork != null)
			{
				# region クラスへ格納
				salesHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				salesHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				salesHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				salesHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				salesHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				salesHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				salesHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				salesHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				salesHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				salesHistDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				salesHistDtlWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				salesHistDtlWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESROWNORF"));
				salesHistDtlWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESROWDERIVNORF"));
				salesHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				salesHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				salesHistDtlWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SALESDATERF"));
				salesHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COMMONSEQNORF"));
				salesHistDtlWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPDTLNUMRF"));
				salesHistDtlWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSSRCRF"));
				salesHistDtlWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPDTLNUMSRCRF"));
				salesHistDtlWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALSYNCRF"));
				salesHistDtlWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPDTLNUMSYNCRF"));
				salesHistDtlWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPCDDTLRF"));
				salesHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSKINDCODERF"));
				salesHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMAKERCDRF"));
				salesHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERNAMERF"));
				salesHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERKANANAMERF"));
				salesHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNORF"));
				salesHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMERF"));
				salesHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMEKANARF"));
				salesHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPRF"));
				salesHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPNAMERF"));
				salesHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPRF"));
				salesHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPNAMERF"));
				salesHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGROUPCODERF"));
				salesHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGROUPNAMERF"));
				salesHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGOODSCODERF"));
				salesHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGOODSFULLNAMERF"));
				salesHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRECODERF"));
				salesHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRENAMERF"));
				salesHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSECODERF"));
				salesHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSENAMERF"));
				salesHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSESHELFNORF"));
				salesHistDtlWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESORDERDIVCDRF"));
				salesHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OPENPRICEDIVRF"));
				salesHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSRATERANKRF"));
				salesHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTRATEGRPCODERF"));
				salesHistDtlWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICERATERF"));
				salesHistDtlWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTPRICEUNPRCRF"));
				salesHistDtlWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVLPRICERF"));
				salesHistDtlWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDLPRICERF"));
				salesHistDtlWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDLPRICERF"));
				salesHistDtlWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCLPRICERF"));
				salesHistDtlWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITLPRICERF"));
				salesHistDtlWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCLPRICERF"));
				salesHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXINCFLRF"));
				salesHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXEXCFLRF"));
				salesHistDtlWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LISTPRICECHNGCDRF"));
				salesHistDtlWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESRATERF"));
				salesHistDtlWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTSALUNPRCRF"));
				salesHistDtlWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVSALUNPRCRF"));
				salesHistDtlWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDSALUNPRCRF"));
				salesHistDtlWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDSALUNPRCRF"));
				salesHistDtlWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCSALUNPRCRF"));
				salesHistDtlWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITSALUNPRCRF"));
				salesHistDtlWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCSALUNPRCRF"));
				salesHistDtlWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESUNPRCTAXINCFLRF"));
				salesHistDtlWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESUNPRCTAXEXCFLRF"));
				salesHistDtlWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESUNPRCCHNGCDRF"));
				salesHistDtlWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "COSTRATERF"));
				salesHistDtlWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTCSTUNPRCRF"));
				salesHistDtlWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVUNCSTRF"));
				salesHistDtlWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDUNCSTRF"));
				salesHistDtlWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDUNCSTRF"));
				salesHistDtlWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCUNCSTRF"));
				salesHistDtlWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITUNCSTRF"));
				salesHistDtlWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNCSTRF"));
				salesHistDtlWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESUNITCOSTRF"));
				salesHistDtlWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESUNITCOSTCHNGDIVRF"));
				salesHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSCODERF"));
				salesHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSNAMERF"));
				salesHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPCDRF"));
				salesHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPNMRF"));
				salesHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPCODERF"));
				salesHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPNAMERF"));
				salesHistDtlWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRTBLGOODSCODERF"));
				salesHistDtlWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PRTBLGOODSNAMERF"));
				salesHistDtlWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESCODERF"));
				salesHistDtlWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESCDNMRF"));
				salesHistDtlWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "WORKMANHOURRF"));
				salesHistDtlWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SHIPMENTCNTRF"));
				salesHistDtlWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESMONEYTAXINCRF"));
				salesHistDtlWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESMONEYTAXEXCRF"));
				salesHistDtlWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COSTRF"));
				salesHistDtlWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GRSPROFITCHKDIVRF"));
				salesHistDtlWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESGOODSCDRF"));
				salesHistDtlWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRICECONSTAXRF"));
				salesHistDtlWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TAXATIONDIVCDRF"));
				salesHistDtlWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSLIPNUMDTLRF"));
				salesHistDtlWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DTLNOTERF"));
				salesHistDtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				salesHistDtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				salesHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ORDERNUMBERRF"));
				salesHistDtlWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "WAYTOORDERRF"));
				salesHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO1RF"));
				salesHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO2RF"));
				salesHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO3RF"));
				salesHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO1RF"));
				salesHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO2RF"));
				salesHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO3RF"));
				salesHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFLISTPRICERF"));
				salesHistDtlWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFSALESUNITPRICERF"));
				salesHistDtlWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFUNITCOSTRF"));
				salesHistDtlWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESROWNORF"));
				salesHistDtlWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CMPLTGOODSMAKERCDRF"));
				salesHistDtlWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTMAKERNAMERF"));
				salesHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTMAKERKANANAMERF"));
				salesHistDtlWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTGOODSNAMERF"));
				salesHistDtlWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CMPLTSHIPMENTCNTRF"));
				salesHistDtlWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESUNPRCFLRF"));
				salesHistDtlWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESMONEYRF"));
				salesHistDtlWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESUNITCOSTRF"));
				salesHistDtlWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "CMPLTCOSTRF"));
				salesHistDtlWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTPARTYSALSLNUMRF"));
				salesHistDtlWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTNOTERF"));
				salesHistDtlWork.PrtGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PRTGOODSNORF"));
				salesHistDtlWork.PrtMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRTMAKERCODERF"));
				salesHistDtlWork.PrtMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PRTMAKERNAMERF"));
				salesHistDtlWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CAMPAIGNCODERF"));
				salesHistDtlWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CAMPAIGNNAMERF"));
				salesHistDtlWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSDIVCDRF"));
				salesHistDtlWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ANSWERDELIVDATERF"));
				salesHistDtlWork.RecycleDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RECYCLEDIVRF"));
				salesHistDtlWork.RecycleDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RECYCLEDIVNMRF"));
				salesHistDtlWork.WayToAcptOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "WAYTOACPTODRRF"));
				// ADD 2011/09/15 ---------- >>>>>
				salesHistDtlWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOANSWERDIVSCMRF"));
				salesHistDtlWork.AcceptOrOrderKind = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal(tableNm + "ACCEPTORORDERKINDRF"));
				salesHistDtlWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "INQUIRYNUMBERRF"));
				salesHistDtlWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "INQROWNUMBERRF"));
				// ADD 2011/09/15 ---------- <<<<<
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                salesHistDtlWork.RentSyncSupplier = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RENTSYNCSUPPLIERRF")); // 貸出同時仕入先
                salesHistDtlWork.RentSyncStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "RENTSYNCSTOCKDATERF")); // 貸出同時仕入日
                salesHistDtlWork.RentSyncSupSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RENTSYNCSUPSLIPNORF")); // 貸出同時仕入伝票番号
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

    }
}

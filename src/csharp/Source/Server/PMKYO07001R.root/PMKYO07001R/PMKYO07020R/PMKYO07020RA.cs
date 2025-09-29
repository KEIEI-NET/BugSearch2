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
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/09/10  修正内容 : Mantis.16023　電子元帳で赤伝発行した場合、明細が抜け落ちる不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬
// 修 正 日  2011/04/25  修正内容 : 売上明細データ抽出時に企業コードを追加
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
    /// 売上明細データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// <br>Update Note: PMKOBETSU-3877の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/09/25</br>
    /// </remarks>
    public class APSalesDetailDB : RemoteDB
    {
        /// <summary>
        /// 売上明細データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APSalesDetailDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="salesDetailArrList">売上明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchSalesDetail(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList salesDetailArrList, out string retMessage)
        {
            return SearchSalesDetailProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  salesDetailArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="salesDetailArrList">売上明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 売上明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchSalesDetailProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList salesDetailArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            salesDetailArrList = new ArrayList();
            APSalesDetailWork salesDetailWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // 2010/09/10 >>>
                //sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, DELIGDSCMPLTDUEDATERF, GOODSKINDCODERF, GOODSSEARCHDIVCDRF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, ACCEPTANORDERCNTRF, ACPTANODRADJUSTCNTRF, ACPTANODRREMAINCNTRF, REMAINCNTUPDDATERF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF FROM SALESDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, DELIGDSCMPLTDUEDATERF, GOODSKINDCODERF, GOODSSEARCHDIVCDRF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, ACCEPTANORDERCNTRF, ACPTANODRADJUSTCNTRF, ACPTANODRREMAINCNTRF, REMAINCNTUPDDATERF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF";
                sqlStr += " FROM SALESDETAILRF";
                sqlStr += " WHERE SALESSLIPNUMRF in (";
                sqlStr += " SELECT DISTINCT SALESSLIPNUMRF FROM SALESDETAILRF";
                sqlStr += "  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
                sqlStr += "  AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                sqlStr += "  AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF )";
                sqlStr += "  AND ENTERPRISECODERF=@FINDENTERPRISECODE ";  // ADD 2011/04/25
                // 2010/09/10 <<<

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 売上明細データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    salesDetailWork = new APSalesDetailWork();

                    salesDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    salesDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    salesDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    salesDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    salesDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    salesDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    salesDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    salesDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    salesDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    salesDetailWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    salesDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    salesDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    salesDetailWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
                    salesDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    salesDetailWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    salesDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    salesDetailWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    salesDetailWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                    salesDetailWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
                    salesDetailWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
                    salesDetailWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
                    salesDetailWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    salesDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
                    salesDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    salesDetailWork.GoodsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSEARCHDIVCDRF"));
                    salesDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    salesDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    salesDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                    salesDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    salesDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    salesDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    salesDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    salesDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                    salesDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    salesDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    salesDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    salesDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                    salesDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    salesDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    salesDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    salesDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                    salesDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    salesDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    salesDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    salesDetailWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    salesDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    salesDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    salesDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    salesDetailWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
                    salesDetailWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
                    salesDetailWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
                    salesDetailWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
                    salesDetailWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
                    salesDetailWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
                    salesDetailWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
                    salesDetailWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
                    salesDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    salesDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    salesDetailWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
                    salesDetailWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                    salesDetailWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
                    salesDetailWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
                    salesDetailWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
                    salesDetailWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
                    salesDetailWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                    salesDetailWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
                    salesDetailWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
                    salesDetailWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                    salesDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    salesDetailWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
                    salesDetailWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
                    salesDetailWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
                    salesDetailWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
                    salesDetailWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
                    salesDetailWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
                    salesDetailWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
                    salesDetailWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
                    salesDetailWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
                    salesDetailWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    salesDetailWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
                    salesDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                    salesDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                    salesDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
                    salesDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
                    salesDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
                    salesDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
                    salesDetailWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    salesDetailWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
                    salesDetailWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                    salesDetailWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                    salesDetailWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
                    salesDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    salesDetailWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    salesDetailWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
                    salesDetailWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    salesDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
                    salesDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                    salesDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    salesDetailWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                    salesDetailWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
                    salesDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                    salesDetailWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
                    salesDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                    salesDetailWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                    salesDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                    salesDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    salesDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    salesDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    salesDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
                    salesDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    salesDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    salesDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    salesDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    salesDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    salesDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    salesDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                    salesDetailWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                    salesDetailWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                    salesDetailWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
                    salesDetailWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
                    salesDetailWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
                    salesDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
                    salesDetailWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
                    salesDetailWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
                    salesDetailWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
                    salesDetailWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
                    salesDetailWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
                    salesDetailWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
                    salesDetailWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
                    salesDetailWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
                    salesDetailWork.PrtGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
                    salesDetailWork.PrtMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTMAKERCODERF"));
                    salesDetailWork.PrtMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTMAKERNAMERF"));
                    // ↓ 2009.05.26 liuyang add
                    salesDetailWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
                    salesDetailWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));
                    salesDetailWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSDIVCDRF"));
                    salesDetailWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERDELIVDATERF"));
                    salesDetailWork.RecycleDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECYCLEDIVRF"));
                    salesDetailWork.RecycleDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECYCLEDIVNMRF"));
                    salesDetailWork.WayToAcptOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOACPTODRRF"));
                    // ↑ 2009.05.26 liuyang add

                    salesDetailArrList.Add(salesDetailWork);
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
        /// 売上明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateSalesDetail(string enterPriseCode, ArrayList salesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateSalesDetailProc(enterPriseCode, salesDetailList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateSalesDetailProc(string enterPriseCode, ArrayList salesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteSalesDetail(enterPriseCode, salesDetailList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertSalesDetail(enterPriseCode, salesDetailList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteSalesDetail(string enterPriseCode, ArrayList salesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteSalesDetailProc(enterPriseCode, salesDetailList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteSalesDetailProc(string enterPriseCode, ArrayList salesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APSalesDetailWork salesDetail in salesDetailList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // modified by zhubj for 仕様変更 start on 20090429
                // sqlText = "DELETE FROM SALESDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";
                sqlText = "DELETE FROM SALESDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";
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
                findParaAcptAnOdrStatus.Value = salesDetail.AcptAnOdrStatus;
                // modified by zhubj for 仕様変更 start on 20090429
                //findParaSalesSlipDtlNum.Value = salesDetail.SalesSlipDtlNum;
                findParaSalesSlipNum.Value = salesDetail.SalesSlipNum;
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
        /// 売上明細データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertSalesDetail(string enterPriseCode, ArrayList salesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertSalesDetailProc(enterPriseCode, salesDetailList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上明細データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        private int InsertSalesDetailProc(string enterPriseCode, ArrayList salesDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APSalesDetailWork salesDetailWork in salesDetailList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				//sqlText = "INSERT INTO SALESDETAILRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, DELIGDSCMPLTDUEDATERF, GOODSKINDCODERF, GOODSSEARCHDIVCDRF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, ACCEPTANORDERCNTRF, ACPTANODRADJUSTCNTRF, ACPTANODRREMAINCNTRF, REMAINCNTUPDDATERF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @DELIGDSCMPLTDUEDATE, @GOODSKINDCODE, @GOODSSEARCHDIVCD, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @ACCEPTANORDERCNT, @ACPTANODRADJUSTCNT, @ACPTANODRREMAINCNT, @REMAINCNTUPDDATE, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR)"; // DEL 2011/09/15
                // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                //sqlText = "INSERT INTO SALESDETAILRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, DELIGDSCMPLTDUEDATERF, GOODSKINDCODERF, GOODSSEARCHDIVCDRF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, ACCEPTANORDERCNTRF, ACPTANODRADJUSTCNTRF, ACPTANODRREMAINCNTRF, REMAINCNTUPDDATERF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF, AUTOANSWERDIVSCMRF, ACCEPTORORDERKINDRF, INQUIRYNUMBERRF, INQROWNUMBERRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @DELIGDSCMPLTDUEDATE, @GOODSKINDCODE, @GOODSSEARCHDIVCD, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @ACCEPTANORDERCNT, @ACPTANODRADJUSTCNT, @ACPTANODRREMAINCNT, @REMAINCNTUPDDATE, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR, @AUTOANSWERDIVSCM, @ACCEPTORORDERKIND, @INQUIRYNUMBER, @INQROWNUMBER)";// ADD 2011/09/15
                sqlText = "INSERT INTO SALESDETAILRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, DELIGDSCMPLTDUEDATERF, GOODSKINDCODERF, GOODSSEARCHDIVCDRF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, ACCEPTANORDERCNTRF, ACPTANODRADJUSTCNTRF, ACPTANODRREMAINCNTRF, REMAINCNTUPDDATERF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF, AUTOANSWERDIVSCMRF, ACCEPTORORDERKINDRF, INQUIRYNUMBERRF, INQROWNUMBERRF, RENTSYNCSUPPLIERRF, RENTSYNCSTOCKDATERF, RENTSYNCSUPSLIPNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @DELIGDSCMPLTDUEDATE, @GOODSKINDCODE, @GOODSSEARCHDIVCD, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @ACCEPTANORDERCNT, @ACPTANODRADJUSTCNT, @ACPTANODRREMAINCNT, @REMAINCNTUPDDATE, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR, @AUTOANSWERDIVSCM, @ACCEPTORORDERKIND, @INQUIRYNUMBER, @INQROWNUMBER, @RENTSYNCSUPPLIER, @RENTSYNCSTOCKDATE, @RENTSYNCSUPSLIPNO)";
                // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
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
                SqlParameter paraDeliGdsCmpltDueDate = sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                SqlParameter paraGoodsSearchDivCd = sqlCommand.Parameters.Add("@GOODSSEARCHDIVCD", SqlDbType.Int);
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
                SqlParameter paraAcceptAnOrderCnt = sqlCommand.Parameters.Add("@ACCEPTANORDERCNT", SqlDbType.Float);
                SqlParameter paraAcptAnOdrAdjustCnt = sqlCommand.Parameters.Add("@ACPTANODRADJUSTCNT", SqlDbType.Float);
                SqlParameter paraAcptAnOdrRemainCnt = sqlCommand.Parameters.Add("@ACPTANODRREMAINCNT", SqlDbType.Float);
                SqlParameter paraRemainCntUpdDate = sqlCommand.Parameters.Add("@REMAINCNTUPDDATE", SqlDbType.Int);
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
                SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                SqlParameter paraCampaignName = sqlCommand.Parameters.Add("@CAMPAIGNNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsDivCd = sqlCommand.Parameters.Add("@GOODSDIVCD", SqlDbType.Int);
                SqlParameter paraAnswerDelivDate = sqlCommand.Parameters.Add("@ANSWERDELIVDATE", SqlDbType.NVarChar);
                SqlParameter paraRecycleDiv = sqlCommand.Parameters.Add("@RECYCLEDIV", SqlDbType.Int);
                SqlParameter paraRecycleDivNm = sqlCommand.Parameters.Add("@RECYCLEDIVNM", SqlDbType.NVarChar);
                SqlParameter paraWayToAcptOdr = sqlCommand.Parameters.Add("@WAYTOACPTODR", SqlDbType.Int);
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesDetailWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesDetailWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesDetailWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesDetailWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesDetailWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AcceptAnOrderNo);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesDetailWork.SalesSlipNum);
                paraSalesRowNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesRowNo);
                paraSalesRowDerivNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesRowDerivNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SubSectionCode);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.SalesDate);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.CommonSeqNo);
                paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesSlipDtlNum);
                paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AcptAnOdrStatusSrc);
                paraSalesSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesSlipDtlNumSrc);
                paraSupplierFormalSync.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SupplierFormalSync);
                paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.StockSlipDtlNumSync);
                paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesSlipCdDtl);
                paraDeliGdsCmpltDueDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.DeliGdsCmpltDueDate);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsKindCode);
                paraGoodsSearchDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsSearchDivCd);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(salesDetailWork.MakerName);
                paraMakerKanaName.Value = SqlDataMediator.SqlSetString(salesDetailWork.MakerKanaName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsNameKana);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsLGroup);
                paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsLGroupName);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsMGroup);
                paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsMGroupName);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.BLGroupCode);
                paraBLGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.BLGroupName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(salesDetailWork.BLGoodsFullName);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.EnterpriseGanreCode);
                paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(salesDetailWork.EnterpriseGanreName);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(salesDetailWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(salesDetailWork.WarehouseName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.WarehouseShelfNo);
                paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesOrderDivCd);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.OpenPriceDiv);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(salesDetailWork.GoodsRateRank);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CustRateGrpCode);
                paraListPriceRate.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ListPriceRate);
                paraRateSectPriceUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateSectPriceUnPrc);
                paraRateDivLPrice.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateDivLPrice);
                paraUnPrcCalcCdLPrice.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.UnPrcCalcCdLPrice);
                paraPriceCdLPrice.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PriceCdLPrice);
                paraStdUnPrcLPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.StdUnPrcLPrice);
                paraFracProcUnitLPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.FracProcUnitLPrice);
                paraFracProcLPrice.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.FracProcLPrice);
                paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ListPriceTaxIncFl);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ListPriceTaxExcFl);
                paraListPriceChngCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.ListPriceChngCd);
                paraSalesRate.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesRate);
                paraRateSectSalUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateSectSalUnPrc);
                paraRateDivSalUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateDivSalUnPrc);
                paraUnPrcCalcCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.UnPrcCalcCdSalUnPrc);
                paraPriceCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PriceCdSalUnPrc);
                paraStdUnPrcSalUnPrc.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.StdUnPrcSalUnPrc);
                paraFracProcUnitSalUnPrc.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.FracProcUnitSalUnPrc);
                paraFracProcSalUnPrc.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.FracProcSalUnPrc);
                paraSalesUnPrcTaxIncFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesUnPrcTaxIncFl);
                paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesUnPrcTaxExcFl);
                paraSalesUnPrcChngCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesUnPrcChngCd);
                paraCostRate.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CostRate);
                paraRateSectCstUnPrc.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateSectCstUnPrc);
                paraRateDivUnCst.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateDivUnCst);
                paraUnPrcCalcCdUnCst.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.UnPrcCalcCdUnCst);
                paraPriceCdUnCst.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PriceCdUnCst);
                paraStdUnPrcUnCst.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.StdUnPrcUnCst);
                paraFracProcUnitUnCst.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.FracProcUnitUnCst);
                paraFracProcUnCst.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.FracProcUnCst);
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.SalesUnitCost);
                paraSalesUnitCostChngDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesUnitCostChngDiv);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RateBLGoodsCode);
                paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateBLGoodsName);
                paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RateGoodsRateGrpCd);
                paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateGoodsRateGrpNm);
                paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RateBLGroupCode);
                paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(salesDetailWork.RateBLGroupName);
                paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PrtBLGoodsCode);
                paraPrtBLGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.PrtBLGoodsName);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesCode);
                paraSalesCdNm.Value = SqlDataMediator.SqlSetString(salesDetailWork.SalesCdNm);
                paraWorkManHour.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.WorkManHour);
                paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.ShipmentCnt);
                paraAcceptAnOrderCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.AcceptAnOrderCnt);
                paraAcptAnOdrAdjustCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.AcptAnOdrAdjustCnt);
                paraAcptAnOdrRemainCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.AcptAnOdrRemainCnt);
                paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.RemainCntUpdDate);
                paraSalesMoneyTaxInc.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesMoneyTaxInc);
                paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesMoneyTaxExc);
                paraCost.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.Cost);
                paraGrsProfitChkDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GrsProfitChkDiv);
                paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SalesGoodsCd);
                paraSalesPriceConsTax.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.SalesPriceConsTax);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.TaxationDivCd);
                paraPartySlipNumDtl.Value = SqlDataMediator.SqlSetString(salesDetailWork.PartySlipNumDtl);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(salesDetailWork.DtlNote);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(salesDetailWork.SupplierSnm);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(salesDetailWork.OrderNumber);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.WayToOrder);
                paraSlipMemo1.Value = SqlDataMediator.SqlSetString(salesDetailWork.SlipMemo1);
                paraSlipMemo2.Value = SqlDataMediator.SqlSetString(salesDetailWork.SlipMemo2);
                paraSlipMemo3.Value = SqlDataMediator.SqlSetString(salesDetailWork.SlipMemo3);
                paraInsideMemo1.Value = SqlDataMediator.SqlSetString(salesDetailWork.InsideMemo1);
                paraInsideMemo2.Value = SqlDataMediator.SqlSetString(salesDetailWork.InsideMemo2);
                paraInsideMemo3.Value = SqlDataMediator.SqlSetString(salesDetailWork.InsideMemo3);
                paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.BfListPrice);
                paraBfSalesUnitPrice.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.BfSalesUnitPrice);
                paraBfUnitCost.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.BfUnitCost);
                paraCmpltSalesRowNo.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CmpltSalesRowNo);
                paraCmpltGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CmpltGoodsMakerCd);
                paraCmpltMakerName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltMakerName);
                paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltMakerKanaName);
                paraCmpltGoodsName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltGoodsName);
                paraCmpltShipmentCnt.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CmpltShipmentCnt);
                paraCmpltSalesUnPrcFl.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CmpltSalesUnPrcFl);
                paraCmpltSalesMoney.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.CmpltSalesMoney);
                paraCmpltSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(salesDetailWork.CmpltSalesUnitCost);
                paraCmpltCost.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.CmpltCost);
                paraCmpltPartySalSlNum.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltPartySalSlNum);
                paraCmpltNote.Value = SqlDataMediator.SqlSetString(salesDetailWork.CmpltNote);
                paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.PrtGoodsNo);
                paraPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.PrtMakerCode);
                paraPrtMakerName.Value = SqlDataMediator.SqlSetString(salesDetailWork.PrtMakerName);
                // ↓ 2009.05.26 liuyang add
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.CampaignCode);
                paraCampaignName.Value = SqlDataMediator.SqlSetString(salesDetailWork.CampaignName);
                paraGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.GoodsDivCd);
                paraAnswerDelivDate.Value = SqlDataMediator.SqlSetString(salesDetailWork.AnswerDelivDate);
                paraRecycleDiv.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RecycleDiv);
                paraRecycleDivNm.Value = SqlDataMediator.SqlSetString(salesDetailWork.RecycleDivNm);
                paraWayToAcptOdr.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.WayToAcptOdr);
                // ↑ 2009.05.26 liuyang add
				// ADD 2011/09/15 ---------->>>>>
				paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.AutoAnswerDivSCM);
				paraAcceptOrOrderKind.Value = SqlDataMediator.SqlSetInt16(salesDetailWork.AcceptOrOrderKind);
				paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(salesDetailWork.InquiryNumber);
				paraInqRowNumber.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.InqRowNumber);
				// ADD 2011/09/15 ----------<<<<<
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                paraRentSyncSupplier.Value = SqlDataMediator.SqlSetInt32(salesDetailWork.RentSyncSupplier); // 貸出同時仕入先
                paraRentSyncStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(salesDetailWork.RentSyncStockDate); // 貸出同時仕入日
                paraRentSyncSupSlipNo.Value = SqlDataMediator.SqlSetString(salesDetailWork.RentSyncSupSlipNo); // 貸出同時仕入伝票番号
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
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
		/// クラス格納処理 Reader → SupplierWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public APSalesDetailWork CopyToSalesDetailWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APSalesDetailWork salesDetailWork = new APSalesDetailWork();

			this.CopyToSalesDetailWorkFromReaderSCM(ref myReader, ref salesDetailWork, tableNm);

			return salesDetailWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → salesDetailWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="salesDetailWork">salesDetailWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
		private void CopyToSalesDetailWorkFromReaderSCM(ref SqlDataReader myReader, ref APSalesDetailWork salesDetailWork, string tableNm)
		{
			if (myReader != null && salesDetailWork != null)
			{
				# region クラスへ格納
				salesDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				salesDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				salesDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				salesDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				salesDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				salesDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				salesDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				salesDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				salesDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				salesDetailWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				salesDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				salesDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESROWNORF"));
				salesDetailWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESROWDERIVNORF"));
				salesDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				salesDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				salesDetailWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SALESDATERF"));
				salesDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COMMONSEQNORF"));
				salesDetailWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPDTLNUMRF"));
				salesDetailWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSSRCRF"));
				salesDetailWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPDTLNUMSRCRF"));
				salesDetailWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALSYNCRF"));
				salesDetailWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPDTLNUMSYNCRF"));
				salesDetailWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPCDDTLRF"));
				salesDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "DELIGDSCMPLTDUEDATERF"));
				salesDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSKINDCODERF"));
				salesDetailWork.GoodsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSSEARCHDIVCDRF"));
				salesDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMAKERCDRF"));
				salesDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERNAMERF"));
				salesDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERKANANAMERF"));
				salesDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNORF"));
				salesDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMERF"));
				salesDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMEKANARF"));
				salesDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPRF"));
				salesDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPNAMERF"));
				salesDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPRF"));
				salesDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPNAMERF"));
				salesDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGROUPCODERF"));
				salesDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGROUPNAMERF"));
				salesDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGOODSCODERF"));
				salesDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGOODSFULLNAMERF"));
				salesDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRECODERF"));
				salesDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRENAMERF"));
				salesDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSECODERF"));
				salesDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSENAMERF"));
				salesDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSESHELFNORF"));
				salesDetailWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESORDERDIVCDRF"));
				salesDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OPENPRICEDIVRF"));
				salesDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSRATERANKRF"));
				salesDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTRATEGRPCODERF"));
				salesDetailWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICERATERF"));
				salesDetailWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTPRICEUNPRCRF"));
				salesDetailWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVLPRICERF"));
				salesDetailWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDLPRICERF"));
				salesDetailWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDLPRICERF"));
				salesDetailWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCLPRICERF"));
				salesDetailWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITLPRICERF"));
				salesDetailWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCLPRICERF"));
				salesDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXINCFLRF"));
				salesDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXEXCFLRF"));
				salesDetailWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LISTPRICECHNGCDRF"));
				salesDetailWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESRATERF"));
				salesDetailWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTSALUNPRCRF"));
				salesDetailWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVSALUNPRCRF"));
				salesDetailWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDSALUNPRCRF"));
				salesDetailWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDSALUNPRCRF"));
				salesDetailWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCSALUNPRCRF"));
				salesDetailWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITSALUNPRCRF"));
				salesDetailWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCSALUNPRCRF"));
				salesDetailWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESUNPRCTAXINCFLRF"));
				salesDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESUNPRCTAXEXCFLRF"));
				salesDetailWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESUNPRCCHNGCDRF"));
				salesDetailWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "COSTRATERF"));
				salesDetailWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTCSTUNPRCRF"));
				salesDetailWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVUNCSTRF"));
				salesDetailWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDUNCSTRF"));
				salesDetailWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDUNCSTRF"));
				salesDetailWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCUNCSTRF"));
				salesDetailWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITUNCSTRF"));
				salesDetailWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNCSTRF"));
				salesDetailWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SALESUNITCOSTRF"));
				salesDetailWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESUNITCOSTCHNGDIVRF"));
				salesDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSCODERF"));
				salesDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSNAMERF"));
				salesDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPCDRF"));
				salesDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPNMRF"));
				salesDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPCODERF"));
				salesDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPNAMERF"));
				salesDetailWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRTBLGOODSCODERF"));
				salesDetailWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PRTBLGOODSNAMERF"));
				salesDetailWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESCODERF"));
				salesDetailWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESCDNMRF"));
				salesDetailWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "WORKMANHOURRF"));
				salesDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SHIPMENTCNTRF"));
				salesDetailWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERCNTRF"));
				salesDetailWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRADJUSTCNTRF"));
				salesDetailWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRREMAINCNTRF"));
				salesDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "REMAINCNTUPDDATERF"));
				salesDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESMONEYTAXINCRF"));
				salesDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESMONEYTAXEXCRF"));
				salesDetailWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COSTRF"));
				salesDetailWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GRSPROFITCHKDIVRF"));
				salesDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESGOODSCDRF"));
				salesDetailWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRICECONSTAXRF"));
				salesDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TAXATIONDIVCDRF"));
				salesDetailWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSLIPNUMDTLRF"));
				salesDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DTLNOTERF"));
				salesDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				salesDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				salesDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ORDERNUMBERRF"));
				salesDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "WAYTOORDERRF"));
				salesDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO1RF"));
				salesDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO2RF"));
				salesDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO3RF"));
				salesDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO1RF"));
				salesDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO2RF"));
				salesDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO3RF"));
				salesDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFLISTPRICERF"));
				salesDetailWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFSALESUNITPRICERF"));
				salesDetailWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFUNITCOSTRF"));
				salesDetailWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESROWNORF"));
				salesDetailWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CMPLTGOODSMAKERCDRF"));
				salesDetailWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTMAKERNAMERF"));
				salesDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTMAKERKANANAMERF"));
				salesDetailWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTGOODSNAMERF"));
				salesDetailWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CMPLTSHIPMENTCNTRF"));
				salesDetailWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESUNPRCFLRF"));
				salesDetailWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESMONEYRF"));
				salesDetailWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CMPLTSALESUNITCOSTRF"));
				salesDetailWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "CMPLTCOSTRF"));
				salesDetailWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTPARTYSALSLNUMRF"));
				salesDetailWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTNOTERF"));
				salesDetailWork.PrtGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PRTGOODSNORF"));
				salesDetailWork.PrtMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRTMAKERCODERF"));
				salesDetailWork.PrtMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PRTMAKERNAMERF"));
				salesDetailWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CAMPAIGNCODERF"));
				salesDetailWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CAMPAIGNNAMERF"));
				salesDetailWork.GoodsDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSDIVCDRF"));
				salesDetailWork.AnswerDelivDate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ANSWERDELIVDATERF"));
				salesDetailWork.RecycleDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RECYCLEDIVRF"));
				salesDetailWork.RecycleDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RECYCLEDIVNMRF"));
				salesDetailWork.WayToAcptOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "WAYTOACPTODRRF"));
				// ADD 2011/09/15 ---------- >>>>>
				salesDetailWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOANSWERDIVSCMRF"));
				salesDetailWork.AcceptOrOrderKind = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal(tableNm + "ACCEPTORORDERKINDRF"));
				salesDetailWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "INQUIRYNUMBERRF"));
				salesDetailWork.InqRowNumber = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "INQROWNUMBERRF"));
				// ADD 2011/09/15 ---------- <<<<<
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                salesDetailWork.RentSyncSupplier = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RENTSYNCSUPPLIERRF")); // 貸出同時仕入先
                salesDetailWork.RentSyncStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "RENTSYNCSTOCKDATERF")); // 貸出同時仕入日
                salesDetailWork.RentSyncSupSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RENTSYNCSUPSLIPNORF")); // 貸出同時仕入伝票番号
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<
                # endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}


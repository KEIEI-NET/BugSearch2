//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
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
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上明細履歴データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上明細履歴データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: PMKOBETSU-3877の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/09/25</br>
    /// </remarks>
    [Serializable]
    public class DCSalesHistDtlDB : RemoteDB
    {
        /// <summary>
        /// 売上明細履歴データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCSalesHistDtlDB()
            : base("PMKYO07441D", "Broadleaf.Application.Remoting.ParamData.DCSalesHistDtlWork", "SALESHISTDTLRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上明細履歴データ取得
        /// </summary>
        /// <param name="salesHistDtlList">売上明細履歴データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList salesHistDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  salesHistDtlList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上明細履歴データ取得
        /// </summary>
        /// <param name="salesHistDtlList">売上明細履歴データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList salesHistDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            salesHistDtlList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF FROM SALESHISTDTLRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

            //Prameterオブジェクトの作成
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
            findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;

            // SQL文
			sqlCommand.CommandText = sqlText;

            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                salesHistDtlList.Add(this.CopyToSalesHistDtlWorkFromReader(ref myReader));
            }

            if (salesHistDtlList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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

        /// <summary>
        /// クラス格納処理 Reader → SupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCSalesHistDtlWork CopyToSalesHistDtlWorkFromReader(ref SqlDataReader myReader)
        {
            DCSalesHistDtlWork salesHistDtlWork = new DCSalesHistDtlWork();

			this.CopyToSalesHistDtlWorkFromReader(ref myReader, ref salesHistDtlWork);

            return salesHistDtlWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → salesHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="salesHistDtlWork">salesHistDtlWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
		private void CopyToSalesHistDtlWorkFromReader(ref SqlDataReader myReader, ref DCSalesHistDtlWork salesHistDtlWork)
        {
            if (myReader != null && salesHistDtlWork != null)
            {
				# region クラスへ格納
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
				salesHistDtlWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
				salesHistDtlWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
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
				# endregion
            }
        }
		*/
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → SupplierWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public DCSalesHistDtlWork CopyToSalesHistDtlWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCSalesHistDtlWork salesHistDtlWork = new DCSalesHistDtlWork();

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
		private void CopyToSalesHistDtlWorkFromReaderSCM(ref SqlDataReader myReader, ref DCSalesHistDtlWork salesHistDtlWork, string tableNm)
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

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴明細データ削除
        /// </summary>
        /// <param name="dcSalesHistDtlWorkList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcSalesHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcSalesHistDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴明細データ削除
        /// </summary>
        /// <param name="dcSalesHistDtlWorkList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcSalesHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCSalesHistDtlWork dcSalesHistDtlWork in dcSalesHistDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                /* --- DEL 2009/04/27 ---------->>>>>
                sqlCommand.CommandText = "DELETE FROM SALESHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";
                --- DEL 2009/04/27 ----------<<<<< */
                sqlCommand.CommandText = "DELETE FROM SALESHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM"; //ADD 2009/04/27 売上明細通番->売上伝票番号(NCHAR(18))

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                //SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt); // DEL 2009/04/27
                SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar); //ADD 2009/04/27

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcSalesHistDtlWork.EnterpriseCode;
                findParaAcptAnOdrStatus.Value = dcSalesHistDtlWork.AcptAnOdrStatus;
                //findParaSalesSlipDtlNum.Value = dcSalesHistDtlWork.SalesSlipDtlNum; // DEL 2009/04/27
                findParaSalesSlipNum.Value = dcSalesHistDtlWork.SalesSlipNum; //ADD 2009/04/27

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 売上履歴明細データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴明細データ登録
        /// </summary>
        /// <param name="dcSalesHistDtlWorkList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcSalesHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcSalesHistDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴明細データ登録
        /// </summary>
        /// <param name="dcSalesHistDtlWorkList">売上履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
        private void InsertProc(ArrayList dcSalesHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCSalesHistDtlWork dcSalesHistDtlWork in dcSalesHistDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
				//sqlCommand.CommandText = "INSERT INTO SALESHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR)";// DEL 2011/09.14
                // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                //sqlCommand.CommandText = "INSERT INTO SALESHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF, AUTOANSWERDIVSCMRF, ACCEPTORORDERKINDRF, INQUIRYNUMBERRF, INQROWNUMBERRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR, @AUTOANSWERDIVSCM, @ACCEPTORORDERKIND, @INQUIRYNUMBER, @INQROWNUMBER)";// ADD 2011/09.14
				sqlCommand.CommandText = "INSERT INTO SALESHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SALESROWNORF, SALESROWDERIVNORF, SECTIONCODERF, SUBSECTIONCODERF, SALESDATERF, COMMONSEQNORF, SALESSLIPDTLNUMRF, ACPTANODRSTATUSSRCRF, SALESSLIPDTLNUMSRCRF, SUPPLIERFORMALSYNCRF, STOCKSLIPDTLNUMSYNCRF, SALESSLIPCDDTLRF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, SALESORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, LISTPRICERATERF, RATESECTPRICEUNPRCRF, RATEDIVLPRICERF, UNPRCCALCCDLPRICERF, PRICECDLPRICERF, STDUNPRCLPRICERF, FRACPROCUNITLPRICERF, FRACPROCLPRICERF, LISTPRICETAXINCFLRF, LISTPRICETAXEXCFLRF, LISTPRICECHNGCDRF, SALESRATERF, RATESECTSALUNPRCRF, RATEDIVSALUNPRCRF, UNPRCCALCCDSALUNPRCRF, PRICECDSALUNPRCRF, STDUNPRCSALUNPRCRF, FRACPROCUNITSALUNPRCRF, FRACPROCSALUNPRCRF, SALESUNPRCTAXINCFLRF, SALESUNPRCTAXEXCFLRF, SALESUNPRCCHNGCDRF, COSTRATERF, RATESECTCSTUNPRCRF, RATEDIVUNCSTRF, UNPRCCALCCDUNCSTRF, PRICECDUNCSTRF, STDUNPRCUNCSTRF, FRACPROCUNITUNCSTRF, FRACPROCUNCSTRF, SALESUNITCOSTRF, SALESUNITCOSTCHNGDIVRF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, PRTBLGOODSCODERF, PRTBLGOODSNAMERF, SALESCODERF, SALESCDNMRF, WORKMANHOURRF, SHIPMENTCNTRF, SALESMONEYTAXINCRF, SALESMONEYTAXEXCRF, COSTRF, GRSPROFITCHKDIVRF, SALESGOODSCDRF, SALESPRICECONSTAXRF, TAXATIONDIVCDRF, PARTYSLIPNUMDTLRF, DTLNOTERF, SUPPLIERCDRF, SUPPLIERSNMRF, ORDERNUMBERRF, WAYTOORDERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, BFLISTPRICERF, BFSALESUNITPRICERF, BFUNITCOSTRF, CMPLTSALESROWNORF, CMPLTGOODSMAKERCDRF, CMPLTMAKERNAMERF, CMPLTMAKERKANANAMERF, CMPLTGOODSNAMERF, CMPLTSHIPMENTCNTRF, CMPLTSALESUNPRCFLRF, CMPLTSALESMONEYRF, CMPLTSALESUNITCOSTRF, CMPLTCOSTRF, CMPLTPARTYSALSLNUMRF, CMPLTNOTERF, PRTGOODSNORF, PRTMAKERCODERF, PRTMAKERNAMERF, CAMPAIGNCODERF, CAMPAIGNNAMERF, GOODSDIVCDRF, ANSWERDELIVDATERF, RECYCLEDIVRF, RECYCLEDIVNMRF, WAYTOACPTODRRF, AUTOANSWERDIVSCMRF, ACCEPTORORDERKINDRF, INQUIRYNUMBERRF, INQROWNUMBERRF, RENTSYNCSUPPLIERRF, RENTSYNCSTOCKDATERF, RENTSYNCSUPSLIPNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @ACPTANODRSTATUS, @SALESSLIPNUM, @SALESROWNO, @SALESROWDERIVNO, @SECTIONCODE, @SUBSECTIONCODE, @SALESDATE, @COMMONSEQNO, @SALESSLIPDTLNUM, @ACPTANODRSTATUSSRC, @SALESSLIPDTLNUMSRC, @SUPPLIERFORMALSYNC, @STOCKSLIPDTLNUMSYNC, @SALESSLIPCDDTL, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @SALESORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @LISTPRICERATE, @RATESECTPRICEUNPRC, @RATEDIVLPRICE, @UNPRCCALCCDLPRICE, @PRICECDLPRICE, @STDUNPRCLPRICE, @FRACPROCUNITLPRICE, @FRACPROCLPRICE, @LISTPRICETAXINCFL, @LISTPRICETAXEXCFL, @LISTPRICECHNGCD, @SALESRATE, @RATESECTSALUNPRC, @RATEDIVSALUNPRC, @UNPRCCALCCDSALUNPRC, @PRICECDSALUNPRC, @STDUNPRCSALUNPRC, @FRACPROCUNITSALUNPRC, @FRACPROCSALUNPRC, @SALESUNPRCTAXINCFL, @SALESUNPRCTAXEXCFL, @SALESUNPRCCHNGCD, @COSTRATE, @RATESECTCSTUNPRC, @RATEDIVUNCST, @UNPRCCALCCDUNCST, @PRICECDUNCST, @STDUNPRCUNCST, @FRACPROCUNITUNCST, @FRACPROCUNCST, @SALESUNITCOST, @SALESUNITCOSTCHNGDIV, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @PRTBLGOODSCODE, @PRTBLGOODSNAME, @SALESCODE, @SALESCDNM, @WORKMANHOUR, @SHIPMENTCNT, @SALESMONEYTAXINC, @SALESMONEYTAXEXC, @COST, @GRSPROFITCHKDIV, @SALESGOODSCD, @SALESPRICECONSTAX, @TAXATIONDIVCD, @PARTYSLIPNUMDTL, @DTLNOTE, @SUPPLIERCD, @SUPPLIERSNM, @ORDERNUMBER, @WAYTOORDER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @BFLISTPRICE, @BFSALESUNITPRICE, @BFUNITCOST, @CMPLTSALESROWNO, @CMPLTGOODSMAKERCD, @CMPLTMAKERNAME, @CMPLTMAKERKANANAME, @CMPLTGOODSNAME, @CMPLTSHIPMENTCNT, @CMPLTSALESUNPRCFL, @CMPLTSALESMONEY, @CMPLTSALESUNITCOST, @CMPLTCOST, @CMPLTPARTYSALSLNUM, @CMPLTNOTE, @PRTGOODSNO, @PRTMAKERCODE, @PRTMAKERNAME, @CAMPAIGNCODE, @CAMPAIGNNAME, @GOODSDIVCD, @ANSWERDELIVDATE, @RECYCLEDIV, @RECYCLEDIVNM, @WAYTOACPTODR, @AUTOANSWERDIVSCM, @ACCEPTORORDERKIND, @INQUIRYNUMBER, @INQROWNUMBER, @RENTSYNCSUPPLIER, @RENTSYNCSTOCKDATE, @RENTSYNCSUPSLIPNO)";
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSalesHistDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSalesHistDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcSalesHistDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.AcceptAnOrderNo);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SalesSlipNum);
                paraSalesRowNo.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesRowNo);
                paraSalesRowDerivNo.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesRowDerivNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SubSectionCode);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistDtlWork.SalesDate);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.CommonSeqNo);
                paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.SalesSlipDtlNum);
                paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.AcptAnOdrStatusSrc);
                paraSalesSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.SalesSlipDtlNumSrc);
                paraSupplierFormalSync.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SupplierFormalSync);
                paraStockSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.StockSlipDtlNumSync);
                paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesSlipCdDtl);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.GoodsKindCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.MakerName);
                paraMakerKanaName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.MakerKanaName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.GoodsNameKana);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.GoodsLGroup);
                paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.GoodsLGroupName);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.GoodsMGroup);
                paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.GoodsMGroupName);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.BLGroupCode);
                paraBLGroupName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.BLGroupName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.BLGoodsFullName);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.EnterpriseGanreCode);
                paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.EnterpriseGanreName);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.WarehouseName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.WarehouseShelfNo);
                paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesOrderDivCd);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.OpenPriceDiv);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.GoodsRateRank);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.CustRateGrpCode);
                paraListPriceRate.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.ListPriceRate);
                paraRateSectPriceUnPrc.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateSectPriceUnPrc);
                paraRateDivLPrice.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateDivLPrice);
                paraUnPrcCalcCdLPrice.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.UnPrcCalcCdLPrice);
                paraPriceCdLPrice.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.PriceCdLPrice);
                paraStdUnPrcLPrice.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.StdUnPrcLPrice);
                paraFracProcUnitLPrice.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.FracProcUnitLPrice);
                paraFracProcLPrice.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.FracProcLPrice);
                paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.ListPriceTaxIncFl);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.ListPriceTaxExcFl);
                paraListPriceChngCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.ListPriceChngCd);
                paraSalesRate.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.SalesRate);
                paraRateSectSalUnPrc.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateSectSalUnPrc);
                paraRateDivSalUnPrc.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateDivSalUnPrc);
                paraUnPrcCalcCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.UnPrcCalcCdSalUnPrc);
                paraPriceCdSalUnPrc.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.PriceCdSalUnPrc);
                paraStdUnPrcSalUnPrc.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.StdUnPrcSalUnPrc);
                paraFracProcUnitSalUnPrc.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.FracProcUnitSalUnPrc);
                paraFracProcSalUnPrc.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.FracProcSalUnPrc);
                paraSalesUnPrcTaxIncFl.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.SalesUnPrcTaxIncFl);
                paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.SalesUnPrcTaxExcFl);
                paraSalesUnPrcChngCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesUnPrcChngCd);
                paraCostRate.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.CostRate);
                paraRateSectCstUnPrc.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateSectCstUnPrc);
                paraRateDivUnCst.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateDivUnCst);
                paraUnPrcCalcCdUnCst.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.UnPrcCalcCdUnCst);
                paraPriceCdUnCst.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.PriceCdUnCst);
                paraStdUnPrcUnCst.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.StdUnPrcUnCst);
                paraFracProcUnitUnCst.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.FracProcUnitUnCst);
                paraFracProcUnCst.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.FracProcUnCst);
                paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.SalesUnitCost);
                paraSalesUnitCostChngDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesUnitCostChngDiv);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.RateBLGoodsCode);
                paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateBLGoodsName);
                paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.RateGoodsRateGrpCd);
                paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateGoodsRateGrpNm);
                paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.RateBLGroupCode);
                paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RateBLGroupName);
                paraPrtBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.PrtBLGoodsCode);
                paraPrtBLGoodsName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.PrtBLGoodsName);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesCode);
                paraSalesCdNm.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SalesCdNm);
                paraWorkManHour.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.WorkManHour);
                paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.ShipmentCnt);
                paraSalesMoneyTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.SalesMoneyTaxInc);
                paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.SalesMoneyTaxExc);
                paraCost.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.Cost);
                paraGrsProfitChkDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.GrsProfitChkDiv);
                paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SalesGoodsCd);
                paraSalesPriceConsTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.SalesPriceConsTax);
                paraTaxationDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.TaxationDivCd);
                paraPartySlipNumDtl.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.PartySlipNumDtl);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.DtlNote);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SupplierSnm);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.OrderNumber);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.WayToOrder);
                paraSlipMemo1.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SlipMemo1);
                paraSlipMemo2.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SlipMemo2);
                paraSlipMemo3.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.SlipMemo3);
                paraInsideMemo1.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.InsideMemo1);
                paraInsideMemo2.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.InsideMemo2);
                paraInsideMemo3.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.InsideMemo3);
                paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.BfListPrice);
                paraBfSalesUnitPrice.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.BfSalesUnitPrice);
                paraBfUnitCost.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.BfUnitCost);
                paraCmpltSalesRowNo.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.CmpltSalesRowNo);
                paraCmpltGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.CmpltGoodsMakerCd);
                paraCmpltMakerName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.CmpltMakerName);
                paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.CmpltMakerKanaName);
                paraCmpltGoodsName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.CmpltGoodsName);
                paraCmpltShipmentCnt.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.CmpltShipmentCnt);
                paraCmpltSalesUnPrcFl.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.CmpltSalesUnPrcFl);
                paraCmpltSalesMoney.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.CmpltSalesMoney);
                paraCmpltSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(dcSalesHistDtlWork.CmpltSalesUnitCost);
                paraCmpltCost.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.CmpltCost);
                paraCmpltPartySalSlNum.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.CmpltPartySalSlNum);
                paraCmpltNote.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.CmpltNote);
                paraPrtGoodsNo.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.PrtGoodsNo);
                paraPrtMakerCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.PrtMakerCode);
                paraPrtMakerName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.PrtMakerName);
                // ↓ 2009.05.26 liuyang add
                paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.CampaignCode);
                paraCampaignName.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.CampaignName);
                paraGoodsDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.GoodsDivCd);
                paraAnswerDelivDate.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.AnswerDelivDate);
                paraRecycleDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.RecycleDiv);
                paraRecycleDivNm.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RecycleDivNm);
                paraWayToAcptOdr.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.WayToAcptOdr);
                // ↑ 2009.05.26 liuyang add
				// ADD 2011/09/15 ---------->>>>>
				paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.AutoAnswerDivSCM);
				paraAcceptOrOrderKind.Value = SqlDataMediator.SqlSetInt16(dcSalesHistDtlWork.AcceptOrOrderKind);
				paraInquiryNumber.Value = SqlDataMediator.SqlSetInt64(dcSalesHistDtlWork.InquiryNumber);
				paraInqRowNumber.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.InqRowNumber);
				// ADD 2011/09/15 ----------<<<<<
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
                paraRentSyncSupplier.Value = SqlDataMediator.SqlSetInt32(dcSalesHistDtlWork.RentSyncSupplier); // 貸出同時仕入先
                paraRentSyncStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistDtlWork.RentSyncStockDate); // 貸出同時仕入日
                paraRentSyncSupSlipNo.Value = SqlDataMediator.SqlSetString(dcSalesHistDtlWork.RentSyncSupSlipNo); // 貸出同時仕入伝票番号
                // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 売上履歴明細データを登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		# region [Clear]
		// Rクラスのpublic MethodでSQL文字が駄目
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
        {
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode, enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
        }
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
        {
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            //sqlCommand.CommandText = "DELETE FROM SALESHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM SALESHISTDTLRF WHERE   EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT SALESHISTDTLRF.ACPTANODRSTATUSRF FROM SALESHISTORYRF  WHERE SALESHISTORYRF.ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
            sb.Append(" AND SALESHISTORYRF.ENTERPRISECODERF = SALESHISTDTLRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND SALESHISTORYRF.ACPTANODRSTATUSRF = SALESHISTDTLRF.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESHISTORYRF.SALESSLIPNUMRF = SALESHISTDTLRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" AND SALESHISTORYRF.RESULTSADDUPSECCDRF =@FINDSECTIONCODERF) ").Append(Environment.NewLine);
            sqlCommand.CommandText = sb.ToString();
            
            //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // 売上データを削除する
            sqlCommand.ExecuteNonQuery();

        }
		#endregion
		// ADD 2011.08.26 張莉莉 ----------<<<<<
    }
}

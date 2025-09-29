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
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
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
    /// 仕入履歴明細データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入履歴明細の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockSlHistDtlDB : RemoteDB
    {
        /// <summary>
        /// 仕入履歴明細データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockSlHistDtlDB()
            : base("PMKYO07501D", "Broadleaf.Application.Remoting.ParamData.DCStockSlHistDtlWork", "STOCKSLHISTDTLRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入履歴明細データ取得
        /// </summary>
        /// <param name="stockSlHistDtlList">仕入履歴明細データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList stockSlHistDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockSlHistDtlList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴明細データ取得
        /// </summary>
        /// <param name="stockSlHistDtlList">仕入履歴明細データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockSlHistDtlList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockSlHistDtlList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, ORDERNUMBERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF FROM STOCKSLHISTDTLRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                stockSlHistDtlList.Add(this.CopyToStockSlHistDtlWorkFromReader(ref myReader));
            }

            if (stockSlHistDtlList.Count > 0)
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
        /// クラス格納処理 Reader → stockSlHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockSlHistDtlWork CopyToStockSlHistDtlWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockSlHistDtlWork stockSlHistDtlWork = new DCStockSlHistDtlWork();

			this.CopyToStockSlHistDtlWorkFromReader(ref myReader, ref stockSlHistDtlWork);

            return stockSlHistDtlWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → stockSlHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockSlHistDtlWork">stockSlHistDtlWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToStockSlHistDtlWorkFromReader(ref SqlDataReader myReader, ref DCStockSlHistDtlWork stockSlHistDtlWork)
        {
            if (myReader != null && stockSlHistDtlWork != null)
            {
				# region クラスへ格納
				stockSlHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				stockSlHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				stockSlHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				stockSlHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				stockSlHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				stockSlHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				stockSlHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				stockSlHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				stockSlHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
				stockSlHistDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
				stockSlHistDtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
				stockSlHistDtlWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
				stockSlHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				stockSlHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
				stockSlHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
				stockSlHistDtlWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
				stockSlHistDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
				stockSlHistDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
				stockSlHistDtlWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
				stockSlHistDtlWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
				stockSlHistDtlWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
				stockSlHistDtlWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
				stockSlHistDtlWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
				stockSlHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
				stockSlHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
				stockSlHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
				stockSlHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
				stockSlHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
				stockSlHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
				stockSlHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
				stockSlHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
				stockSlHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
				stockSlHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
				stockSlHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
				stockSlHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
				stockSlHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
				stockSlHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
				stockSlHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
				stockSlHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
				stockSlHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
				stockSlHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
				stockSlHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
				stockSlHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
				stockSlHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
				stockSlHistDtlWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
				stockSlHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
				stockSlHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
				stockSlHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
				stockSlHistDtlWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
				stockSlHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
				stockSlHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
				stockSlHistDtlWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
				stockSlHistDtlWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
				stockSlHistDtlWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
				stockSlHistDtlWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
				stockSlHistDtlWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
				stockSlHistDtlWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
				stockSlHistDtlWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
				stockSlHistDtlWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
				stockSlHistDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
				stockSlHistDtlWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
				stockSlHistDtlWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
				stockSlHistDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
				stockSlHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
				stockSlHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
				stockSlHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
				stockSlHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
				stockSlHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
				stockSlHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
				stockSlHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
				stockSlHistDtlWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
				stockSlHistDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
				stockSlHistDtlWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
				stockSlHistDtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
				stockSlHistDtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
				stockSlHistDtlWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
				stockSlHistDtlWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
				stockSlHistDtlWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
				stockSlHistDtlWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
				stockSlHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
				stockSlHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
				stockSlHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
				stockSlHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
				stockSlHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
				stockSlHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
				stockSlHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
				# endregion
            }
        }
 */
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → stockSlHistDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public DCStockSlHistDtlWork CopyToStockSlHistDtlWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCStockSlHistDtlWork stockSlHistDtlWork = new DCStockSlHistDtlWork();

			this.CopyToStockSlHistDtlWorkFromReaderSCM(ref myReader, ref stockSlHistDtlWork, tableNm);

			return stockSlHistDtlWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockSlHistDtlWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockSlHistDtlWork">stockSlHistDtlWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToStockSlHistDtlWorkFromReaderSCM(ref SqlDataReader myReader, ref DCStockSlHistDtlWork stockSlHistDtlWork, string tableNm)
		{
			if (myReader != null && stockSlHistDtlWork != null)
			{
				# region クラスへ格納
				stockSlHistDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				stockSlHistDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				stockSlHistDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				stockSlHistDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				stockSlHistDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				stockSlHistDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				stockSlHistDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				stockSlHistDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				stockSlHistDtlWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				stockSlHistDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				stockSlHistDtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				stockSlHistDtlWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKROWNORF"));
				stockSlHistDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				stockSlHistDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				stockSlHistDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COMMONSEQNORF"));
				stockSlHistDtlWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPDTLNUMRF"));
				stockSlHistDtlWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALSRCRF"));
				stockSlHistDtlWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPDTLNUMSRCRF"));
				stockSlHistDtlWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSSYNCRF"));
				stockSlHistDtlWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPDTLNUMSYNCRF"));
				stockSlHistDtlWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPCDDTLRF"));
				stockSlHistDtlWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTCODERF"));
				stockSlHistDtlWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTNAMERF"));
				stockSlHistDtlWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSKINDCODERF"));
				stockSlHistDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMAKERCDRF"));
				stockSlHistDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERNAMERF"));
				stockSlHistDtlWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERKANANAMERF"));
				stockSlHistDtlWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTMAKERKANANAMERF"));
				stockSlHistDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNORF"));
				stockSlHistDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMERF"));
				stockSlHistDtlWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMEKANARF"));
				stockSlHistDtlWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPRF"));
				stockSlHistDtlWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPNAMERF"));
				stockSlHistDtlWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPRF"));
				stockSlHistDtlWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPNAMERF"));
				stockSlHistDtlWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGROUPCODERF"));
				stockSlHistDtlWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGROUPNAMERF"));
				stockSlHistDtlWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGOODSCODERF"));
				stockSlHistDtlWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGOODSFULLNAMERF"));
				stockSlHistDtlWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRECODERF"));
				stockSlHistDtlWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRENAMERF"));
				stockSlHistDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSECODERF"));
				stockSlHistDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSENAMERF"));
				stockSlHistDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSESHELFNORF"));
				stockSlHistDtlWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKORDERDIVCDRF"));
				stockSlHistDtlWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OPENPRICEDIVRF"));
				stockSlHistDtlWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSRATERANKRF"));
				stockSlHistDtlWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTRATEGRPCODERF"));
				stockSlHistDtlWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPRATEGRPCODERF"));
				stockSlHistDtlWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXEXCFLRF"));
				stockSlHistDtlWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXINCFLRF"));
				stockSlHistDtlWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKRATERF"));
				stockSlHistDtlWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTSTCKUNPRCRF"));
				stockSlHistDtlWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVSTCKUNPRCRF"));
				stockSlHistDtlWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDSTCKUNPRCRF"));
				stockSlHistDtlWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDSTCKUNPRCRF"));
				stockSlHistDtlWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCSTCKUNPRCRF"));
				stockSlHistDtlWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITSTCUNPRCRF"));
				stockSlHistDtlWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCSTCKUNPRCRF"));
				stockSlHistDtlWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKUNITPRICEFLRF"));
				stockSlHistDtlWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKUNITTAXPRICEFLRF"));
				stockSlHistDtlWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKUNITCHNGDIVRF"));
				stockSlHistDtlWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFSTOCKUNITPRICEFLRF"));
				stockSlHistDtlWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFLISTPRICERF"));
				stockSlHistDtlWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSCODERF"));
				stockSlHistDtlWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSNAMERF"));
				stockSlHistDtlWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPCDRF"));
				stockSlHistDtlWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPNMRF"));
				stockSlHistDtlWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPCODERF"));
				stockSlHistDtlWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPNAMERF"));
				stockSlHistDtlWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKCOUNTRF"));
				stockSlHistDtlWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICETAXEXCRF"));
				stockSlHistDtlWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICETAXINCRF"));
				stockSlHistDtlWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSCDRF"));
				stockSlHistDtlWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICECONSTAXRF"));
				stockSlHistDtlWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TAXATIONCODERF"));
				stockSlHistDtlWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKDTISLIPNOTE1RF"));
				stockSlHistDtlWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESCUSTOMERCODERF"));
				stockSlHistDtlWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESCUSTOMERSNMRF"));
				stockSlHistDtlWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ORDERNUMBERRF"));
				stockSlHistDtlWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO1RF"));
				stockSlHistDtlWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO2RF"));
				stockSlHistDtlWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO3RF"));
				stockSlHistDtlWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO1RF"));
				stockSlHistDtlWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO2RF"));
				stockSlHistDtlWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO3RF"));
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入履歴明細データ削除
        /// </summary>
        /// <param name="dcStockSlHistDtlWorkList">仕入履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockSlHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockSlHistDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴明細データ削除
        /// </summary>
        /// <param name="dcStockSlHistDtlWorkList">仕入履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockSlHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockSlHistDtlWork dcStockSlHistDtlWork in dcStockSlHistDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                /* --- DEL 2009/04/27 ---------->>>>>
                sqlCommand.CommandText = "DELETE FROM STOCKSLHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM";
                --- DEL 2009/04/27 ----------<<<<< */
                sqlCommand.CommandText = "DELETE FROM STOCKSLHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO"; //ADD 2009/04/27 仕入明細通番->仕入伝票番号(Int32)

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                //SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt); // DEL 2009/04/27
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int); //ADD 2009/04/27


                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcStockSlHistDtlWork.EnterpriseCode;
                findParaSupplierFormal.Value = dcStockSlHistDtlWork.SupplierFormal;
                //findParaStockSlipDtlNum.Value = dcStockSlHistDtlWork.StockSlipDtlNum; // DEL 2009/04/27
                findParaSupplierSlipNo.Value = dcStockSlHistDtlWork.SupplierSlipNo; //ADD 2009/04/27

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 仕入履歴明細データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入履歴明細データ登録
        /// </summary>
        /// <param name="dcStockSlHistDtlWorkList">仕入履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockSlHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockSlHistDtlWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴明細データ登録
        /// </summary>
        /// <param name="dcStockSlHistDtlWorkList">仕入履歴明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockSlHistDtlWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockSlHistDtlWork dcStockSlHistDtlWork in dcStockSlHistDtlWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO STOCKSLHISTDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, ORDERNUMBERRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @STOCKROWNO, @SECTIONCODE, @SUBSECTIONCODE, @COMMONSEQNO, @STOCKSLIPDTLNUM, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPTANODRSTATUSSYNC, @SALESSLIPDTLNUMSYNC, @STOCKSLIPCDDTL, @STOCKAGENTCODE, @STOCKAGENTNAME, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @CMPLTMAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @STOCKORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @SUPPRATEGRPCODE, @LISTPRICETAXEXCFL, @LISTPRICETAXINCFL, @STOCKRATE, @RATESECTSTCKUNPRC, @RATEDIVSTCKUNPRC, @UNPRCCALCCDSTCKUNPRC, @PRICECDSTCKUNPRC, @STDUNPRCSTCKUNPRC, @FRACPROCUNITSTCUNPRC, @FRACPROCSTCKUNPRC, @STOCKUNITPRICEFL, @STOCKUNITTAXPRICEFL, @STOCKUNITCHNGDIV, @BFSTOCKUNITPRICEFL, @BFLISTPRICE, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @STOCKCOUNT, @STOCKPRICETAXEXC, @STOCKPRICETAXINC, @STOCKGOODSCD, @STOCKPRICECONSTAX, @TAXATIONCODE, @STOCKDTISLIPNOTE1, @SALESCUSTOMERCODE, @SALESCUSTOMERSNM, @ORDERNUMBER, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3)";
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
                SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                SqlParameter paraStockPriceTaxInc = sqlCommand.Parameters.Add("@STOCKPRICETAXINC", SqlDbType.BigInt);
                SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                SqlParameter paraTaxationCode = sqlCommand.Parameters.Add("@TAXATIONCODE", SqlDbType.Int);
                SqlParameter paraStockDtiSlipNote1 = sqlCommand.Parameters.Add("@STOCKDTISLIPNOTE1", SqlDbType.NVarChar);
                SqlParameter paraSalesCustomerCode = sqlCommand.Parameters.Add("@SALESCUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSalesCustomerSnm = sqlCommand.Parameters.Add("@SALESCUSTOMERSNM", SqlDbType.NVarChar);
                SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockSlHistDtlWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockSlHistDtlWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockSlHistDtlWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.AcceptAnOrderNo);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.SupplierSlipNo);
                paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.StockRowNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.SubSectionCode);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.CommonSeqNo);
                paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.StockSlipDtlNum);
                paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.SupplierFormalSrc);
                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.StockSlipDtlNumSrc);
                paraAcptAnOdrStatusSync.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.AcptAnOdrStatusSync);
                paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.SalesSlipDtlNumSync);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.StockSlipCdDtl);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.StockAgentName);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.GoodsKindCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.MakerName);
                paraMakerKanaName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.MakerKanaName);
                paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.CmpltMakerKanaName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.GoodsNameKana);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.GoodsLGroup);
                paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.GoodsLGroupName);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.GoodsMGroup);
                paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.GoodsMGroupName);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.BLGroupCode);
                paraBLGroupName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.BLGroupName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.BLGoodsFullName);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.EnterpriseGanreCode);
                paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.EnterpriseGanreName);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.WarehouseName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.WarehouseShelfNo);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.StockOrderDivCd);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.OpenPriceDiv);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.GoodsRateRank);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.CustRateGrpCode);
                paraSuppRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.SuppRateGrpCode);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.ListPriceTaxExcFl);
                paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.ListPriceTaxIncFl);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.StockRate);
                paraRateSectStckUnPrc.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.RateSectStckUnPrc);
                paraRateDivStckUnPrc.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.RateDivStckUnPrc);
                paraUnPrcCalcCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.UnPrcCalcCdStckUnPrc);
                paraPriceCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.PriceCdStckUnPrc);
                paraStdUnPrcStckUnPrc.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.StdUnPrcStckUnPrc);
                paraFracProcUnitStcUnPrc.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.FracProcUnitStcUnPrc);
                paraFracProcStckUnPrc.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.FracProcStckUnPrc);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.StockUnitPriceFl);
                paraStockUnitTaxPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.StockUnitTaxPriceFl);
                paraStockUnitChngDiv.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.StockUnitChngDiv);
                paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.BfStockUnitPriceFl);
                paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.BfListPrice);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.RateBLGoodsCode);
                paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.RateBLGoodsName);
                paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.RateGoodsRateGrpCd);
                paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.RateGoodsRateGrpNm);
                paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.RateBLGroupCode);
                paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.RateBLGroupName);
                paraStockCount.Value = SqlDataMediator.SqlSetDouble(dcStockSlHistDtlWork.StockCount);
                paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.StockPriceTaxExc);
                paraStockPriceTaxInc.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.StockPriceTaxInc);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.StockGoodsCd);
                paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(dcStockSlHistDtlWork.StockPriceConsTax);
                paraTaxationCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.TaxationCode);
                paraStockDtiSlipNote1.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.StockDtiSlipNote1);
                paraSalesCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcStockSlHistDtlWork.SalesCustomerCode);
                paraSalesCustomerSnm.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.SalesCustomerSnm);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.OrderNumber);
                paraSlipMemo1.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.SlipMemo1);
                paraSlipMemo2.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.SlipMemo2);
                paraSlipMemo3.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.SlipMemo3);
                paraInsideMemo1.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.InsideMemo1);
                paraInsideMemo2.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.InsideMemo2);
                paraInsideMemo3.Value = SqlDataMediator.SqlSetString(dcStockSlHistDtlWork.InsideMemo3);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 仕入履歴明細データを登録する
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
            //sqlCommand.CommandText = "DELETE FROM STOCKSLHISTDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM STOCKSLHISTDTLRF WHERE  EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT STOCKSLHISTDTLRF.SUPPLIERFORMALRF FROM STOCKSLIPHISTRF  WHERE STOCKSLIPHISTRF.ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPHISTRF.ENTERPRISECODERF = STOCKSLHISTDTLRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPHISTRF.SUPPLIERFORMALRF = STOCKSLHISTDTLRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPHISTRF.SUPPLIERSLIPNORF = STOCKSLHISTDTLRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPHISTRF.STOCKADDUPSECTIONCDRF = @FINDSECTIONCODERF) ").Append(Environment.NewLine);
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

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   DC抽出・更新DB仲介クラス
//                  :   PMKYO07480R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   劉洋
// Date             :   2009.3.30
//----------------------------------------------------------------------
// Update Note      :
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
// 修 正 日  2011/09/08  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : Redmine #24562 仕入明細データの送信について
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
    /// 仕入明細データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入明細の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockDetailDB : RemoteDB
    {
        /// <summary>
        /// 仕入明細データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockDetailDB()
            : base("PMKYO07481D", "Broadleaf.Application.Remoting.ParamData.DCStockDetailWork", "STOCKDETAILRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入明細データ取得
        /// </summary>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList stockDetailList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockDetailList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データ取得
        /// </summary>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockDetailList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockDetailList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, ORDERCNTRF, ORDERADJUSTCNTRF, ORDERREMAINCNTRF, REMAINCNTUPDDATERF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, SUPPLIERCDRF, SUPPLIERSNMRF, ADDRESSEECODERF, ADDRESSEENAMERF, DIRECTSENDINGCDRF, ORDERNUMBERRF, WAYTOORDERRF, DELIGDSCMPLTDUEDATERF, EXPECTDELIVERYDATERF, ORDERDATACREATEDIVRF, ORDERDATACREATEDATERF, ORDERFORMISSUEDDIVRF FROM STOCKDETAILRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                stockDetailList.Add(this.CopyToStockDetailWorkFromReader(ref myReader));
            }

            if (stockDetailList.Count > 0)
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
        /// クラス格納処理 Reader → stockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockDetailWork CopyToStockDetailWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockDetailWork stockDetailWork = new DCStockDetailWork();

			this.CopyToStockDetailWorkFromReader(ref myReader, ref stockDetailWork);

            return stockDetailWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → stockDetailWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockDetailWork">stockDetailWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToStockDetailWorkFromReader(ref SqlDataReader myReader, ref DCStockDetailWork stockDetailWork)
        {
            if (myReader != null && stockDetailWork != null)
            {
				# region クラスへ格納
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
				# endregion
            }
        }
		*/
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → stockDetailWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public DCStockDetailWork CopyToStockDetailWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCStockDetailWork stockDetailWork = new DCStockDetailWork();

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
		private void CopyToStockDetailWorkFromReaderSCM(ref SqlDataReader myReader, ref DCStockDetailWork stockDetailWork, string tableNm)
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

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入明細データ削除
        /// </summary>
        /// <param name="dcStockDetailWorkList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockDetailWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockDetailWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データ削除
        /// </summary>
        /// <param name="dcStockDetailWorkList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockDetailWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockDetailWork dcStockDetailWork in dcStockDetailWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                /* --- DEL 2009/04/27 ---------->>>>>
                sqlCommand.CommandText = "DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM";
                 --- DEL 2009/04/27 ----------<<<<< */
                sqlCommand.CommandText = "DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO"; //ADD 2009/04/27 仕入明細通番->仕入伝票番号(Int32)
				
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                //SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt); // DEL 2009/04/27
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int); // ADD 2009/04/27

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcStockDetailWork.EnterpriseCode;
                findParaSupplierFormal.Value = dcStockDetailWork.SupplierFormal;
                //findParaStockSlipDtlNum.Value = dcStockDetailWork.StockSlipDtlNum; // DEL 2009/04/27
				findParaSupplierSlipNo.Value = dcStockDetailWork.SupplierSlipNo; // ADD 2009/04/27

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 仕入明細データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入明細データ登録
        /// </summary>
        /// <param name="dcStockDetailWorkList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockDetailWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockDetailWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データ登録
        /// </summary>
        /// <param name="dcStockDetailWorkList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockDetailWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockDetailWork dcStockDetailWork in dcStockDetailWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO STOCKDETAILRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, ORDERCNTRF, ORDERADJUSTCNTRF, ORDERREMAINCNTRF, REMAINCNTUPDDATERF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, SUPPLIERCDRF, SUPPLIERSNMRF, ADDRESSEECODERF, ADDRESSEENAMERF, DIRECTSENDINGCDRF, ORDERNUMBERRF, WAYTOORDERRF, DELIGDSCMPLTDUEDATERF, EXPECTDELIVERYDATERF, ORDERDATACREATEDIVRF, ORDERDATACREATEDATERF, ORDERFORMISSUEDDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @STOCKROWNO, @SECTIONCODE, @SUBSECTIONCODE, @COMMONSEQNO, @STOCKSLIPDTLNUM, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPTANODRSTATUSSYNC, @SALESSLIPDTLNUMSYNC, @STOCKSLIPCDDTL, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @CMPLTMAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @STOCKORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @SUPPRATEGRPCODE, @LISTPRICETAXEXCFL, @LISTPRICETAXINCFL, @STOCKRATE, @RATESECTSTCKUNPRC, @RATEDIVSTCKUNPRC, @UNPRCCALCCDSTCKUNPRC, @PRICECDSTCKUNPRC, @STDUNPRCSTCKUNPRC, @FRACPROCUNITSTCUNPRC, @FRACPROCSTCKUNPRC, @STOCKUNITPRICEFL, @STOCKUNITTAXPRICEFL, @STOCKUNITCHNGDIV, @BFSTOCKUNITPRICEFL, @BFLISTPRICE, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @STOCKCOUNT, @ORDERCNT, @ORDERADJUSTCNT, @ORDERREMAINCNT, @REMAINCNTUPDDATE, @STOCKPRICETAXEXC, @STOCKPRICETAXINC, @STOCKGOODSCD, @STOCKPRICECONSTAX, @TAXATIONCODE, @STOCKDTISLIPNOTE1, @SALESCUSTOMERCODE, @SALESCUSTOMERSNM, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @SUPPLIERCD, @SUPPLIERSNM, @ADDRESSEECODE, @ADDRESSEENAME, @DIRECTSENDINGCD, @ORDERNUMBER, @WAYTOORDER, @DELIGDSCMPLTDUEDATE, @EXPECTDELIVERYDATE, @ORDERDATACREATEDIV, @ORDERDATACREATEDATE, @ORDERFORMISSUEDDIV)";
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
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockDetailWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockDetailWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockDetailWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.AcceptAnOrderNo);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SupplierSlipNo);
                paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.StockRowNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SubSectionCode);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.CommonSeqNo);
                paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.StockSlipDtlNum);
                paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SupplierFormalSrc);
                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.StockSlipDtlNumSrc);
                paraAcptAnOdrStatusSync.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.AcptAnOdrStatusSync);
                paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.SalesSlipDtlNumSync);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.StockSlipCdDtl);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.StockAgentName);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.GoodsKindCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.MakerName);
                paraMakerKanaName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.MakerKanaName);
                paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.CmpltMakerKanaName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.GoodsNameKana);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.GoodsLGroup);
                paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.GoodsLGroupName);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.GoodsMGroup);
                paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.GoodsMGroupName);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.BLGroupCode);
                paraBLGroupName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.BLGroupName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.BLGoodsFullName);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.EnterpriseGanreCode);
                paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.EnterpriseGanreName);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.WarehouseName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.WarehouseShelfNo);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.StockOrderDivCd);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.OpenPriceDiv);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.GoodsRateRank);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.CustRateGrpCode);
                paraSuppRateGrpCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SuppRateGrpCode);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.ListPriceTaxExcFl);
                paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.ListPriceTaxIncFl);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.StockRate);
                paraRateSectStckUnPrc.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.RateSectStckUnPrc);
                paraRateDivStckUnPrc.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.RateDivStckUnPrc);
                paraUnPrcCalcCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.UnPrcCalcCdStckUnPrc);
                paraPriceCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.PriceCdStckUnPrc);
                paraStdUnPrcStckUnPrc.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.StdUnPrcStckUnPrc);
                paraFracProcUnitStcUnPrc.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.FracProcUnitStcUnPrc);
                paraFracProcStckUnPrc.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.FracProcStckUnPrc);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.StockUnitPriceFl);
                paraStockUnitTaxPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.StockUnitTaxPriceFl);
                paraStockUnitChngDiv.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.StockUnitChngDiv);
                paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.BfStockUnitPriceFl);
                paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.BfListPrice);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.RateBLGoodsCode);
                paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.RateBLGoodsName);
                paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.RateGoodsRateGrpCd);
                paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.RateGoodsRateGrpNm);
                paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.RateBLGroupCode);
                paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.RateBLGroupName);
                paraStockCount.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.StockCount);
                paraOrderCnt.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.OrderCnt);
                paraOrderAdjustCnt.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.OrderAdjustCnt);
                paraOrderRemainCnt.Value = SqlDataMediator.SqlSetDouble(dcStockDetailWork.OrderRemainCnt);
                paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockDetailWork.RemainCntUpdDate);
                paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.StockPriceTaxExc);
                paraStockPriceTaxInc.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.StockPriceTaxInc);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.StockGoodsCd);
                paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(dcStockDetailWork.StockPriceConsTax);
                paraTaxationCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.TaxationCode);
                paraStockDtiSlipNote1.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.StockDtiSlipNote1);
                paraSalesCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SalesCustomerCode);
                paraSalesCustomerSnm.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.SalesCustomerSnm);
                paraSlipMemo1.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.SlipMemo1);
                paraSlipMemo2.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.SlipMemo2);
                paraSlipMemo3.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.SlipMemo3);
                paraInsideMemo1.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.InsideMemo1);
                paraInsideMemo2.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.InsideMemo2);
                paraInsideMemo3.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.InsideMemo3);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.SupplierSnm);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.AddresseeCode);
                paraAddresseeName.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.AddresseeName);
                paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.DirectSendingCd);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(dcStockDetailWork.OrderNumber);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.WayToOrder);
                paraDeliGdsCmpltDueDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockDetailWork.DeliGdsCmpltDueDate);
                paraExpectDeliveryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockDetailWork.ExpectDeliveryDate);
                paraOrderDataCreateDiv.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.OrderDataCreateDiv);
                paraOrderDataCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcStockDetailWork.OrderDataCreateDate);
                paraOrderFormIssuedDiv.Value = SqlDataMediator.SqlSetInt32(dcStockDetailWork.OrderFormIssuedDiv);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 仕入明細データを登録する
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
            //sqlCommand.CommandText = "DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";//DEL by Liangsd     2011/09/06
            //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM STOCKDETAILRF WHERE  EXISTS ").Append(Environment.NewLine);
            sb.Append("(SELECT STOCKDETAILRF.SUPPLIERFORMALRF FROM STOCKSLIPRF  WHERE STOCKSLIPRF.ENTERPRISECODERF=@FINDENTERPRISECODE ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.ENTERPRISECODERF = STOCKDETAILRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.SUPPLIERFORMALRF = STOCKDETAILRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.SUPPLIERSLIPNORF = STOCKDETAILRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            sb.Append(" AND STOCKSLIPRF.STOCKADDUPSECTIONCDRF = @FINDSECTIONCODERF) ").Append(Environment.NewLine);
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

		#region [--- DEL 2011/09/15 張莉莉　SCM対応‐拠点管理（10704767-00）---]
		//// ADD 2011/09/08 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>

		//// Rクラスのpublic MethodでSQL文字が駄目
		///// <summary>
		///// 仕入明細データ取得
		///// </summary>
		///// <param name="stockDetailList">仕入明細データ</param>
		///// <param name="receiveDataWork">受信データ</param>
		///// <param name="sqlConnection">データベース接続情報</param>
		///// <param name="sqlTransaction">トランザクション情報</param>
		///// <returns></returns>
		//public int Search(out ArrayList stockDetailList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//    return SearchProc(out  stockDetailList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		//}

		///// <summary>
		///// 仕入明細データ取得
		///// </summary>
		///// <param name="stockDetailList">仕入明細データ</param>
		///// <param name="receiveDataWork">受信データ</param>
		///// <param name="sqlConnection">データベース接続情報</param>
		///// <param name="sqlTransaction">トランザクション情報</param>
		///// <returns></returns>
		//private int SearchProc(out ArrayList stockDetailList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

		//    SqlDataReader myReader = null;
		//    SqlCommand sqlCommand = null;

		//    stockDetailList = new ArrayList();

		//    string sqlText = string.Empty;
		//    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

		//    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, ORDERCNTRF, ORDERADJUSTCNTRF, ORDERREMAINCNTRF, REMAINCNTUPDDATERF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, SUPPLIERCDRF, SUPPLIERSNMRF, ADDRESSEECODERF, ADDRESSEENAMERF, DIRECTSENDINGCDRF, ORDERNUMBERRF, WAYTOORDERRF, DELIGDSCMPLTDUEDATERF, EXPECTDELIVERYDATERF, ORDERDATACREATEDIVRF, ORDERDATACREATEDATERF, ORDERFORMISSUEDDIVRF  FROM STOCKDETAILRF WHERE SUPPLIERFORMALRF=2 AND SUPPLIERSLIPNORF=0 AND SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME";
			
		//    //Prameterオブジェクトの作成
		//    SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
		//    SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
		//    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
		//    //Parameterオブジェクトへ値設定
		//    findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
		//    findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
		//    findParaSectionCode.Value = receiveDataWork.PmSectionCode;

		//    // SQL文
		//    sqlCommand.CommandText = sqlText;

		//    myReader = sqlCommand.ExecuteReader();

		//    while (myReader.Read())
		//    {
		//        stockDetailList.Add(this.CopyToStockDetailWorkFromReader(ref myReader));
		//    }

		//    if (stockDetailList.Count > 0)
		//    {
		//        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//    }
		//    else
		//    {
		//        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//    }

		//    if (myReader != null)
		//    {
		//        if (!myReader.IsClosed)
		//        {
		//            myReader.Close();
		//        }

		//        myReader.Dispose();
		//    }

		//    if (sqlCommand != null)
		//    {
		//        sqlCommand.Cancel();
		//        sqlCommand.Dispose();
		//    }

		//    return status;
		//}

		///// <summary>
		///// クラス格納処理 Reader → stockDetailWork
		///// </summary>
		///// <param name="myReader">SqlDataReader</param>
		///// <returns>オブジェクト</returns>
		///// <remarks>
		///// </remarks>
		//private DCStockDetailWork CopyToStockDetailWorkFromReader(ref SqlDataReader myReader)
		//{
		//    DCStockDetailWork stockDetailWork = new DCStockDetailWork();

		//    this.CopyToStockDetailWorkFromReader(ref myReader, ref stockDetailWork);

		//    return stockDetailWork;
		//}

		///// <summary>
		///// クラス格納処理 Reader → stockDetailWork
		///// </summary>
		///// <param name="myReader">SqlDataReader</param>
		///// <param name="stockDetailWork">stockDetailWork オブジェクト</param>
		///// <returns>void</returns>
		///// <remarks>
		///// </remarks>
		//private void CopyToStockDetailWorkFromReader(ref SqlDataReader myReader, ref DCStockDetailWork stockDetailWork)
		//{
		//    if (myReader != null && stockDetailWork != null)
		//    {
		//        # region クラスへ格納
		//        stockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
		//        stockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
		//        stockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
		//        stockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//        stockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//        stockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//        stockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//        stockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
		//        stockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
		//        stockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
		//        stockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
		//        stockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
		//        stockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
		//        stockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
		//        stockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
		//        stockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
		//        stockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
		//        stockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
		//        stockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
		//        stockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
		//        stockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
		//        stockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
		//        stockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
		//        stockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
		//        stockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
		//        stockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
		//        stockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
		//        stockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
		//        stockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
		//        stockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
		//        stockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
		//        stockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
		//        stockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
		//        stockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
		//        stockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
		//        stockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
		//        stockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
		//        stockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
		//        stockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
		//        stockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
		//        stockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
		//        stockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
		//        stockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
		//        stockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
		//        stockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
		//        stockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
		//        stockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
		//        stockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
		//        stockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
		//        stockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
		//        stockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
		//        stockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
		//        stockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
		//        stockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
		//        stockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
		//        stockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
		//        stockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
		//        stockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
		//        stockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
		//        stockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
		//        stockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
		//        stockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
		//        stockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
		//        stockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
		//        stockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
		//        stockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
		//        stockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
		//        stockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
		//        stockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
		//        stockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
		//        stockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
		//        stockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
		//        stockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
		//        stockDetailWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
		//        stockDetailWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
		//        stockDetailWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
		//        stockDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
		//        stockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
		//        stockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
		//        stockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
		//        stockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
		//        stockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
		//        stockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
		//        stockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
		//        stockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
		//        stockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
		//        stockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
		//        stockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
		//        stockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
		//        stockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
		//        stockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
		//        stockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
		//        stockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
		//        stockDetailWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
		//        stockDetailWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
		//        stockDetailWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
		//        stockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
		//        stockDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
		//        stockDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
		//        stockDetailWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
		//        stockDetailWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERDATACREATEDIVRF"));
		//        stockDetailWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
		//        stockDetailWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));
		//        # endregion
		//    }
		//}

		//// ADD 2011/09/08 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
		#endregion [--- DEL 2011/09/15 張莉莉　SCM対応‐拠点管理（10704767-00）---]
    }
}

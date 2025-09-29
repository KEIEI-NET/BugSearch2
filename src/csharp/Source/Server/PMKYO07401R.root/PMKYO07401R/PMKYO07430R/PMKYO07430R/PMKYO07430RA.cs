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
// 修 正 日  2011/08/18  修正内容 : Redmine#23746
//                                  違う企業コード間の送受信についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/08  修正内容 : #24609仕入データの赤伝を削除した際のデータ送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 修 正 日  2011/10/08  修正内容 : #25780 データ送信処理　売上履歴データ送信時のタイムアウト設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 作 成 日  2011/11/01  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 脇田 靖之
// 修 正 日  2014/03/26  修正内容 : 仕掛一覧№2292対応
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
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上履歴データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上履歴データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: PMKOBETSU-3877の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/09/25</br>
    /// </remarks>
    [Serializable]
    public class DCSalesHistoryDB : RemoteDB
    {
        /// <summary>
        /// 売上履歴データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCSalesHistoryDB()
            : base("PMKYO07431D", "Broadleaf.Application.Remoting.ParamData.DCSalesHistoryWork", "SALESHISTORYRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴データ取得
        /// </summary>
        /// <param name="salesHistoryList">売上履歴データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList salesHistoryList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  salesHistoryList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴データ取得
        /// </summary>
        /// <param name="salesHistoryList">売上履歴データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList salesHistoryList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            salesHistoryList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSALESSLNUMRF, SALESSLIPCDRF, SALESGOODSCDRF, ACCRECDIVCDRF, SALESINPSECCDRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, SALESSLIPUPDATECDRF, SEARCHSLIPDATERF, SHIPMENTDAYRF, SALESDATERF, ADDUPADATERF, DELAYPAYMENTDIVRF, INPUTAGENCDRF, INPUTAGENNMRF, SALESINPUTCODERF, SALESINPUTNAMERF, FRONTEMPLOYEECDRF, FRONTEMPLOYEENMRF, SALESEMPLOYEECDRF, SALESEMPLOYEENMRF, TOTALAMOUNTDISPWAYCDRF, TTLAMNTDISPRATEAPYRF, SALESTOTALTAXINCRF, SALESTOTALTAXEXCRF, SALESPRTTOTALTAXINCRF, SALESPRTTOTALTAXEXCRF, SALESWORKTOTALTAXINCRF, SALESWORKTOTALTAXEXCRF, SALESSUBTOTALTAXINCRF, SALESSUBTOTALTAXEXCRF, SALESPRTSUBTTLINCRF, SALESPRTSUBTTLEXCRF, SALESWORKSUBTTLINCRF, SALESWORKSUBTTLEXCRF, SALESNETPRICERF, SALESSUBTOTALTAXRF, ITDEDSALESOUTTAXRF, ITDEDSALESINTAXRF, SALSUBTTLSUBTOTAXFRERF, SALESOUTTAXRF, SALAMNTCONSTAXINCLURF, SALESDISTTLTAXEXCRF, ITDEDSALESDISOUTTAXRF, ITDEDSALESDISINTAXRF, ITDEDPARTSDISOUTTAXRF, ITDEDPARTSDISINTAXRF, ITDEDWORKDISOUTTAXRF, ITDEDWORKDISINTAXRF, ITDEDSALESDISTAXFRERF, SALESDISOUTTAXRF, SALESDISTTLTAXINCLURF, PARTSDISCOUNTRATERF, RAVORDISCOUNTRATERF, TOTALCOSTRF, CONSTAXLAYMETHODRF, CONSTAXRATERF, FRACTIONPROCCDRF, ACCRECCONSTAXRF, AUTODEPOSITCDRF, AUTODEPOSITSLIPNORF, DEPOSITALLOWANCETTLRF, DEPOSITALWCBLNCERF, CLAIMCODERF, CLAIMSNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, HONORIFICTITLERF, OUTPUTNAMECODERF, OUTPUTNAMERF, CUSTSLIPNORF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, PARTYSALESLIPNUMRF, SLIPNOTERF, SLIPNOTE2RF, SLIPNOTE3RF, RETGOODSREASONDIVRF, RETGOODSREASONRF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, SALESSLIPPRINTDATERF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, DELIVEREDGOODSDIVRF, DELIVEREDGOODSDIVNMRF, SALESAREACODERF, SALESAREANAMERF, SLIPPRTSETPAPERIDRF, COMPLETECDRF, SALESPRICEFRACPROCCDRF, STOCKGOODSTTLTAXEXCRF, PUREGOODSTTLTAXEXCRF, LISTPRICEPRINTDIVRF, ERANAMEDISPCD1RF FROM SALESHISTORYRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                salesHistoryList.Add(this.CopyToSalesHistoryWorkFromReader(ref myReader));
            }

            if (salesHistoryList.Count > 0)
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
        private DCSalesHistoryWork CopyToSalesHistoryWorkFromReader(ref SqlDataReader myReader)
        {
            DCSalesHistoryWork salesHistoryWork = new DCSalesHistoryWork();

			this.CopyToSalesHistoryWorkFromReader(ref myReader, ref salesHistoryWork);

            return salesHistoryWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → salesHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="salesHistoryWork">salesHistoryWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
		private void CopyToSalesHistoryWorkFromReader(ref SqlDataReader myReader, ref DCSalesHistoryWork salesHistoryWork)
        {
            if (myReader != null && salesHistoryWork != null)
            {
				# region クラスへ格納
				salesHistoryWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				salesHistoryWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				salesHistoryWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				salesHistoryWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				salesHistoryWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				salesHistoryWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				salesHistoryWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				salesHistoryWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				salesHistoryWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				salesHistoryWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
				salesHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				salesHistoryWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
				salesHistoryWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
				salesHistoryWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
				salesHistoryWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
				salesHistoryWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
				salesHistoryWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
				salesHistoryWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
				salesHistoryWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
				salesHistoryWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
				salesHistoryWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
				salesHistoryWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));
				salesHistoryWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
				salesHistoryWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
				salesHistoryWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
				salesHistoryWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
				salesHistoryWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
				salesHistoryWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
				salesHistoryWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
				salesHistoryWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
				salesHistoryWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
				salesHistoryWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
				salesHistoryWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
				salesHistoryWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
				salesHistoryWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
				salesHistoryWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
				salesHistoryWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
				salesHistoryWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
				salesHistoryWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
				salesHistoryWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
				salesHistoryWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
				salesHistoryWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
				salesHistoryWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
				salesHistoryWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
				salesHistoryWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
				salesHistoryWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
				salesHistoryWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
				salesHistoryWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
				salesHistoryWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
				salesHistoryWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
				salesHistoryWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
				salesHistoryWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
				salesHistoryWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
				salesHistoryWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
				salesHistoryWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
				salesHistoryWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
				salesHistoryWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
				salesHistoryWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
				salesHistoryWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
				salesHistoryWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
				salesHistoryWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
				salesHistoryWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
				salesHistoryWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
				salesHistoryWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
				salesHistoryWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
				salesHistoryWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
				salesHistoryWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
				salesHistoryWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
				salesHistoryWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
				salesHistoryWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
				salesHistoryWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
				salesHistoryWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
				salesHistoryWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
				salesHistoryWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
				salesHistoryWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
				salesHistoryWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
				salesHistoryWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
				salesHistoryWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
				salesHistoryWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
				salesHistoryWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				salesHistoryWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				salesHistoryWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
				salesHistoryWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
				salesHistoryWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
				salesHistoryWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
				salesHistoryWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
				salesHistoryWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
				salesHistoryWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
				salesHistoryWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
				salesHistoryWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
				salesHistoryWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
				salesHistoryWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
				salesHistoryWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
				salesHistoryWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
				salesHistoryWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
				salesHistoryWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
				salesHistoryWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
				salesHistoryWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
				salesHistoryWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
				salesHistoryWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
				salesHistoryWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
				salesHistoryWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
				salesHistoryWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
				salesHistoryWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
				salesHistoryWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
				salesHistoryWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
				salesHistoryWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
				salesHistoryWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
				salesHistoryWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
				salesHistoryWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
				salesHistoryWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
				salesHistoryWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
				salesHistoryWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
				salesHistoryWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
				salesHistoryWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
				salesHistoryWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
				salesHistoryWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
				salesHistoryWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
				salesHistoryWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
				salesHistoryWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
				salesHistoryWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
				salesHistoryWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
				salesHistoryWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
				salesHistoryWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
				# endregion
            }
        }
		*/
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// 売上履歴データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out resultList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 売上履歴データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
		private int SearchSCMProc(out ArrayList resultList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			//売上履歴データ
			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT E.CREATEDATETIMERF as E_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.UPDATEDATETIMERF as E_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.ENTERPRISECODERF as E_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.FILEHEADERGUIDRF as E_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.UPDEMPLOYEECODERF as E_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.UPDASSEMBLYID1RF as E_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,E.UPDASSEMBLYID2RF as E_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,E.LOGICALDELETECODERF as E_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.ACPTANODRSTATUSRF as E_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSLIPNUMRF as E_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SECTIONCODERF as E_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SUBSECTIONCODERF as E_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.DEBITNOTEDIVRF as E_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,E.DEBITNLNKSALESSLNUMRF as E_DEBITNLNKSALESSLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSLIPCDRF as E_SALESSLIPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESGOODSCDRF as E_SALESGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ACCRECDIVCDRF as E_ACCRECDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESINPSECCDRF as E_SALESINPSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.DEMANDADDUPSECCDRF as E_DEMANDADDUPSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.RESULTSADDUPSECCDRF as E_RESULTSADDUPSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.UPDATESECCDRF as E_UPDATESECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSLIPUPDATECDRF as E_SALESSLIPUPDATECDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SEARCHSLIPDATERF as E_SEARCHSLIPDATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SHIPMENTDAYRF as E_SHIPMENTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESDATERF as E_SALESDATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDUPADATERF as E_ADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.DELAYPAYMENTDIVRF as E_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,E.INPUTAGENCDRF as E_INPUTAGENCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.INPUTAGENNMRF as E_INPUTAGENNMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESINPUTCODERF as E_SALESINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESINPUTNAMERF as E_SALESINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.FRONTEMPLOYEECDRF as E_FRONTEMPLOYEECDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.FRONTEMPLOYEENMRF as E_FRONTEMPLOYEENMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESEMPLOYEECDRF as E_SALESEMPLOYEECDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESEMPLOYEENMRF as E_SALESEMPLOYEENMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.TOTALAMOUNTDISPWAYCDRF as E_TOTALAMOUNTDISPWAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.TTLAMNTDISPRATEAPYRF as E_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESTOTALTAXINCRF as E_SALESTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESTOTALTAXEXCRF as E_SALESTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESPRTTOTALTAXINCRF as E_SALESPRTTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESPRTTOTALTAXEXCRF as E_SALESPRTTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESWORKTOTALTAXINCRF as E_SALESWORKTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESWORKTOTALTAXEXCRF as E_SALESWORKTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSUBTOTALTAXINCRF as E_SALESSUBTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSUBTOTALTAXEXCRF as E_SALESSUBTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESPRTSUBTTLINCRF as E_SALESPRTSUBTTLINCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESPRTSUBTTLEXCRF as E_SALESPRTSUBTTLEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESWORKSUBTTLINCRF as E_SALESWORKSUBTTLINCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESWORKSUBTTLEXCRF as E_SALESWORKSUBTTLEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESNETPRICERF as E_SALESNETPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSUBTOTALTAXRF as E_SALESSUBTOTALTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDSALESOUTTAXRF as E_ITDEDSALESOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDSALESINTAXRF as E_ITDEDSALESINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALSUBTTLSUBTOTAXFRERF as E_SALSUBTTLSUBTOTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESOUTTAXRF as E_SALESOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALAMNTCONSTAXINCLURF as E_SALAMNTCONSTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESDISTTLTAXEXCRF as E_SALESDISTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDSALESDISOUTTAXRF as E_ITDEDSALESDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDSALESDISINTAXRF as E_ITDEDSALESDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDPARTSDISOUTTAXRF as E_ITDEDPARTSDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDPARTSDISINTAXRF as E_ITDEDPARTSDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDWORKDISOUTTAXRF as E_ITDEDWORKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDWORKDISINTAXRF as E_ITDEDWORKDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ITDEDSALESDISTAXFRERF as E_ITDEDSALESDISTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESDISOUTTAXRF as E_SALESDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESDISTTLTAXINCLURF as E_SALESDISTTLTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,E.PARTSDISCOUNTRATERF as E_PARTSDISCOUNTRATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.RAVORDISCOUNTRATERF as E_RAVORDISCOUNTRATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.TOTALCOSTRF as E_TOTALCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,E.CONSTAXLAYMETHODRF as E_CONSTAXLAYMETHODRF ").Append(Environment.NewLine);
			sb.Append(" ,E.CONSTAXRATERF as E_CONSTAXRATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.FRACTIONPROCCDRF as E_FRACTIONPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ACCRECCONSTAXRF as E_ACCRECCONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,E.AUTODEPOSITCDRF as E_AUTODEPOSITCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.AUTODEPOSITSLIPNORF as E_AUTODEPOSITSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,E.DEPOSITALLOWANCETTLRF as E_DEPOSITALLOWANCETTLRF ").Append(Environment.NewLine);
			sb.Append(" ,E.DEPOSITALWCBLNCERF as E_DEPOSITALWCBLNCERF ").Append(Environment.NewLine);
			sb.Append(" ,E.CLAIMCODERF as E_CLAIMCODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.CLAIMSNMRF as E_CLAIMSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.CUSTOMERCODERF as E_CUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.CUSTOMERNAMERF as E_CUSTOMERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.CUSTOMERNAME2RF as E_CUSTOMERNAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,E.CUSTOMERSNMRF as E_CUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.HONORIFICTITLERF as E_HONORIFICTITLERF ").Append(Environment.NewLine);
			sb.Append(" ,E.OUTPUTNAMECODERF as E_OUTPUTNAMECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.OUTPUTNAMERF as E_OUTPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.CUSTSLIPNORF as E_CUSTSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPADDRESSDIVRF as E_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEECODERF as E_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEENAMERF as E_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEENAME2RF as E_ADDRESSEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEEPOSTNORF as E_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEEADDR1RF as E_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEEADDR3RF as E_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEEADDR4RF as E_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEETELNORF as E_ADDRESSEETELNORF ").Append(Environment.NewLine);
			sb.Append(" ,E.ADDRESSEEFAXNORF as E_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
			sb.Append(" ,E.PARTYSALESLIPNUMRF as E_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPNOTERF as E_SLIPNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPNOTE2RF as E_SLIPNOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPNOTE3RF as E_SLIPNOTE3RF ").Append(Environment.NewLine);
			sb.Append(" ,E.RETGOODSREASONDIVRF as E_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,E.RETGOODSREASONRF as E_RETGOODSREASONRF ").Append(Environment.NewLine);
			sb.Append(" ,E.DETAILROWCOUNTRF as E_DETAILROWCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,E.EDISENDDATERF as E_EDISENDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.EDITAKEINDATERF as E_EDITAKEINDATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.UOEREMARK1RF as E_UOEREMARK1RF ").Append(Environment.NewLine);
			sb.Append(" ,E.UOEREMARK2RF as E_UOEREMARK2RF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPPRINTDIVCDRF as E_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPPRINTFINISHCDRF as E_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESSLIPPRINTDATERF as E_SALESSLIPPRINTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,E.BUSINESSTYPECODERF as E_BUSINESSTYPECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.BUSINESSTYPENAMERF as E_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.DELIVEREDGOODSDIVRF as E_DELIVEREDGOODSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,E.DELIVEREDGOODSDIVNMRF as E_DELIVEREDGOODSDIVNMRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESAREACODERF as E_SALESAREACODERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESAREANAMERF as E_SALESAREANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,E.SLIPPRTSETPAPERIDRF as E_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.COMPLETECDRF as E_COMPLETECDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.SALESPRICEFRACPROCCDRF as E_SALESPRICEFRACPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,E.STOCKGOODSTTLTAXEXCRF as E_STOCKGOODSTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.PUREGOODSTTLTAXEXCRF as E_PUREGOODSTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,E.LISTPRICEPRINTDIVRF as E_LISTPRICEPRINTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,E.ERANAMEDISPCD1RF  as E_ERANAMEDISPCD1RF  ").Append(Environment.NewLine);
			//売上明細履歴データ
			sb.Append(" ,F.CREATEDATETIMERF as F_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.UPDATEDATETIMERF as F_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.ENTERPRISECODERF as F_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.FILEHEADERGUIDRF as F_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.UPDEMPLOYEECODERF as F_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.UPDASSEMBLYID1RF as F_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,F.UPDASSEMBLYID2RF as F_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,F.LOGICALDELETECODERF as F_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.ACCEPTANORDERNORF as F_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.ACPTANODRSTATUSRF as F_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESSLIPNUMRF as F_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESROWNORF as F_SALESROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESROWDERIVNORF as F_SALESROWDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.SECTIONCODERF as F_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.SUBSECTIONCODERF as F_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESDATERF as F_SALESDATERF ").Append(Environment.NewLine);
			sb.Append(" ,F.COMMONSEQNORF as F_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESSLIPDTLNUMRF as F_SALESSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.ACPTANODRSTATUSSRCRF as F_ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESSLIPDTLNUMSRCRF as F_SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SUPPLIERFORMALSYNCRF as F_SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.STOCKSLIPDTLNUMSYNCRF as F_STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESSLIPCDDTLRF as F_SALESSLIPCDDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSKINDCODERF as F_GOODSKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSMAKERCDRF as F_GOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.MAKERNAMERF as F_MAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.MAKERKANANAMERF as F_MAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSNORF as F_GOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSNAMERF as F_GOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSNAMEKANARF as F_GOODSNAMEKANARF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSLGROUPRF as F_GOODSLGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSLGROUPNAMERF as F_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSMGROUPRF as F_GOODSMGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSMGROUPNAMERF as F_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.BLGROUPCODERF as F_BLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.BLGROUPNAMERF as F_BLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.BLGOODSCODERF as F_BLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.BLGOODSFULLNAMERF as F_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.ENTERPRISEGANRECODERF as F_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.ENTERPRISEGANRENAMERF as F_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.WAREHOUSECODERF as F_WAREHOUSECODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.WAREHOUSENAMERF as F_WAREHOUSENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.WAREHOUSESHELFNORF as F_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESORDERDIVCDRF as F_SALESORDERDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.OPENPRICEDIVRF as F_OPENPRICEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSRATERANKRF as F_GOODSRATERANKRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CUSTRATEGRPCODERF as F_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.LISTPRICERATERF as F_LISTPRICERATERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATESECTPRICEUNPRCRF as F_RATESECTPRICEUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEDIVLPRICERF as F_RATEDIVLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.UNPRCCALCCDLPRICERF as F_UNPRCCALCCDLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRICECDLPRICERF as F_PRICECDLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.STDUNPRCLPRICERF as F_STDUNPRCLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.FRACPROCUNITLPRICERF as F_FRACPROCUNITLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.FRACPROCLPRICERF as F_FRACPROCLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.LISTPRICETAXINCFLRF as F_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.LISTPRICETAXEXCFLRF as F_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.LISTPRICECHNGCDRF as F_LISTPRICECHNGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESRATERF as F_SALESRATERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATESECTSALUNPRCRF as F_RATESECTSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEDIVSALUNPRCRF as F_RATEDIVSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.UNPRCCALCCDSALUNPRCRF as F_UNPRCCALCCDSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRICECDSALUNPRCRF as F_PRICECDSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.STDUNPRCSALUNPRCRF as F_STDUNPRCSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.FRACPROCUNITSALUNPRCRF as F_FRACPROCUNITSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.FRACPROCSALUNPRCRF as F_FRACPROCSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESUNPRCTAXINCFLRF as F_SALESUNPRCTAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESUNPRCTAXEXCFLRF as F_SALESUNPRCTAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESUNPRCCHNGCDRF as F_SALESUNPRCCHNGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.COSTRATERF as F_COSTRATERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATESECTCSTUNPRCRF as F_RATESECTCSTUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEDIVUNCSTRF as F_RATEDIVUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.UNPRCCALCCDUNCSTRF as F_UNPRCCALCCDUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRICECDUNCSTRF as F_PRICECDUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.STDUNPRCUNCSTRF as F_STDUNPRCUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.FRACPROCUNITUNCSTRF as F_FRACPROCUNITUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.FRACPROCUNCSTRF as F_FRACPROCUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESUNITCOSTRF as F_SALESUNITCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESUNITCOSTCHNGDIVRF as F_SALESUNITCOSTCHNGDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEBLGOODSCODERF as F_RATEBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEBLGOODSNAMERF as F_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEGOODSRATEGRPCDRF as F_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEGOODSRATEGRPNMRF as F_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEBLGROUPCODERF as F_RATEBLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RATEBLGROUPNAMERF as F_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRTBLGOODSCODERF as F_PRTBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRTBLGOODSNAMERF as F_PRTBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESCODERF as F_SALESCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESCDNMRF as F_SALESCDNMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.WORKMANHOURRF as F_WORKMANHOURRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SHIPMENTCNTRF as F_SHIPMENTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESMONEYTAXINCRF as F_SALESMONEYTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESMONEYTAXEXCRF as F_SALESMONEYTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,F.COSTRF as F_COSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.GRSPROFITCHKDIVRF as F_GRSPROFITCHKDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESGOODSCDRF as F_SALESGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SALESPRICECONSTAXRF as F_SALESPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,F.TAXATIONDIVCDRF as F_TAXATIONDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.PARTYSLIPNUMDTLRF as F_PARTYSLIPNUMDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.DTLNOTERF as F_DTLNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,F.SUPPLIERCDRF as F_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SUPPLIERSNMRF as F_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.ORDERNUMBERRF as F_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,F.WAYTOORDERRF as F_WAYTOORDERRF ").Append(Environment.NewLine);
			sb.Append(" ,F.SLIPMEMO1RF as F_SLIPMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,F.SLIPMEMO2RF as F_SLIPMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,F.SLIPMEMO3RF as F_SLIPMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,F.INSIDEMEMO1RF as F_INSIDEMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,F.INSIDEMEMO2RF as F_INSIDEMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,F.INSIDEMEMO3RF as F_INSIDEMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,F.BFLISTPRICERF as F_BFLISTPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.BFSALESUNITPRICERF as F_BFSALESUNITPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,F.BFUNITCOSTRF as F_BFUNITCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTSALESROWNORF as F_CMPLTSALESROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTGOODSMAKERCDRF as F_CMPLTGOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTMAKERNAMERF as F_CMPLTMAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTMAKERKANANAMERF as F_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTGOODSNAMERF as F_CMPLTGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTSHIPMENTCNTRF as F_CMPLTSHIPMENTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTSALESUNPRCFLRF as F_CMPLTSALESUNPRCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTSALESMONEYRF as F_CMPLTSALESMONEYRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTSALESUNITCOSTRF as F_CMPLTSALESUNITCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTCOSTRF as F_CMPLTCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTPARTYSALSLNUMRF as F_CMPLTPARTYSALSLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.CMPLTNOTERF as F_CMPLTNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRTGOODSNORF as F_PRTGOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRTMAKERCODERF as F_PRTMAKERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.PRTMAKERNAMERF as F_PRTMAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.CAMPAIGNCODERF as F_CAMPAIGNCODERF ").Append(Environment.NewLine);
			sb.Append(" ,F.CAMPAIGNNAMERF as F_CAMPAIGNNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,F.GOODSDIVCDRF as F_GOODSDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.ANSWERDELIVDATERF as F_ANSWERDELIVDATERF ").Append(Environment.NewLine);
			sb.Append(" ,F.RECYCLEDIVRF as F_RECYCLEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,F.RECYCLEDIVNMRF as F_RECYCLEDIVNMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.WAYTOACPTODRRF as F_WAYTOACPTODRRF ").Append(Environment.NewLine);
			// ADD 2011/09/15 ---------- >>>>>
			sb.Append(" ,F.AUTOANSWERDIVSCMRF as F_AUTOANSWERDIVSCMRF ").Append(Environment.NewLine);
			sb.Append(" ,F.ACCEPTORORDERKINDRF as F_ACCEPTORORDERKINDRF ").Append(Environment.NewLine);
			sb.Append(" ,F.INQUIRYNUMBERRF as F_INQUIRYNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,F.INQROWNUMBERRF as F_INQROWNUMBERRF ").Append(Environment.NewLine);
			// ADD 2011/09/15 ---------- <<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
            sb.Append(" ,F.RENTSYNCSUPPLIERRF as F_RENTSYNCSUPPLIERRF ").Append(Environment.NewLine);
            sb.Append(" ,F.RENTSYNCSTOCKDATERF as F_RENTSYNCSTOCKDATERF ").Append(Environment.NewLine);
            sb.Append(" ,F.RENTSYNCSUPSLIPNORF as F_RENTSYNCSUPSLIPNORF ").Append(Environment.NewLine);
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 -----<<<<<

			sb.Append(" FROM SALESHISTORYRF E WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            //売上明細履歴データ
            // ----- UPD 2012/02/27 西 毅 ---------->>>>>
            //sb.Append(" INNER JOIN SALESHISTDTLRF F WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            sb.Append(" INNER JOIN (SELECT * FROM SALESHISTDTLRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            //	売上履歴データ.企業コード　＝　パラメータ.企業コード
            sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                //	売上履歴明細データ.売上日付　≧　パラメータ.開始日付
                sb.Append(" AND (( SALESDATERF>=@FINDUPDATESTARTDATETIME_F ").Append(Environment.NewLine);
                //	売上履歴明細データ.売上日付　≦　パラメータ.終了日付
                sb.Append("    AND SALESDATERF<=@FINDUPDATEENDDATETIME_F )").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append("   OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                //sb.Append("   AND  UPDATEDATETIMERF<@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append("   OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append("   AND  UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append("   AND  SALESDATERF<=@FINDUPDATEENDDATETIME_F )) ").Append(Environment.NewLine);
            }
            else
            {
                //	売上履歴明細データ.更新日時　>　パラメータ.開始日付
                sb.Append(" AND ( UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_F ").Append(Environment.NewLine);
                //	売上履歴明細データ.更新日時　≦　パラメータ.終了日付
                sb.Append(" AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_F )").Append(Environment.NewLine);
            }
            sb.Append(" ) AS F ").Append(Environment.NewLine);
            // ----- UPD 2012/02/27 西 毅 ----------<<<<<
            //	売上履歴データ.企業コード　＝　売上履歴明細データ.企業コード
			sb.Append(" ON E.ENTERPRISECODERF = F.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	売上履歴データ.受注ステータス　＝　売上履歴明細データ.受注ステータス
			sb.Append(" AND E.ACPTANODRSTATUSRF = F.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//	売上履歴データ.売上伝票番号　＝　売上履歴明細データ.売上伝票番号
			sb.Append(" AND E.SALESSLIPNUMRF = F.SALESSLIPNUMRF ").Append(Environment.NewLine);
			// DEL 2011.09.08 ------- >>>>>
			////	売上履歴明細データ.更新日時　>　パラメータ.開始日付
			//sb.Append(" AND F.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_F ").Append(Environment.NewLine);
			////	売上履歴明細データ.更新日時　≦　パラメータ.終了日付
			//sb.Append(" AND F.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_F ").Append(Environment.NewLine);
			// DEL 2011.09.08 ------- <<<<<

			//	売上履歴データ.実績計上拠点コード　＝　パラメータ.拠点コード
			sb.Append(" WHERE E.RESULTSADDUPSECCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine);
            //-----Add 2011/11/01 陳建明 for #26228 start----->>>>>
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
		    {
                //	売上履歴データ.売上日付　≧　パラメータ.開始日付
                //sb.Append(" AND ((E.SALESDATERF>=@FINDUPDATESTARTDATETIME_E ").Append(Environment.NewLine); // DEL 2011/11/30
                sb.Append(" AND (((E.SALESDATERF>=@FINDUPDATESTARTDATETIME_E ").Append(Environment.NewLine); // ADD 2011/11/30
                //	売上履歴データ.売上日付　≦　パラメータ.終了日付
                sb.Append(" AND E.SALESDATERF<=@FINDUPDATEENDDATETIME_E) ").Append(Environment.NewLine);
                // ADD 2011.09.08 ------- >>>>>			
                //	売上履歴明細データ.売上日付　≧　パラメータ.開始日付
                sb.Append(" OR ( F.SALESDATERF>=@FINDUPDATESTARTDATETIME_F ").Append(Environment.NewLine);
                //	売上履歴明細データ.売上日付　≦　パラメータ.終了日付
                sb.Append(" AND F.SALESDATERF<=@FINDUPDATEENDDATETIME_F ))").Append(Environment.NewLine);
                // ADD 2011.09.08 ------- <<<<<


                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append(" OR (( E.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR (( E.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append(" AND  E.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  E.SALESDATERF<=@FINDUPDATEENDDATETIME_E ) ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append("     OR ( F.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                //sb.Append("     AND  F.UPDATEDATETIMERF<@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append("     OR ( F.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append("     AND  F.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append("     AND  F.SALESDATERF<=@FINDUPDATEENDDATETIME_F ))) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<
		    }
		    else
		    {
            //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<<    
                //	売上履歴データ.更新日時　>　パラメータ.開始日付
                sb.Append(" AND ((E.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_E ").Append(Environment.NewLine);
                //	売上履歴データ.更新日時　≦　パラメータ.終了日付
                sb.Append(" AND E.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_E) ").Append(Environment.NewLine);
                // ADD 2011.09.08 ------- >>>>>			
                //	売上履歴明細データ.更新日時　>　パラメータ.開始日付
                sb.Append(" OR ( F.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_F ").Append(Environment.NewLine);
                //	売上履歴明細データ.更新日時　≦　パラメータ.終了日付
                sb.Append(" AND F.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_F ))").Append(Environment.NewLine);
                // ADD 2011.09.08 ------- <<<<<
		    }//Add 2011/11/01 陳建明 for #26228
		    
			//	売上履歴データ.企業コード　＝　パラメータ.企業コード
			sb.Append(" AND E.ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);// ADD 2011/08/18 張莉莉　Redmine#23746

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" E_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,E_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,E_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,F_ACPTANODRSTATUSRF  ").Append(Environment.NewLine);
			sb.Append(" ,F_SALESSLIPDTLNUMRF ").Append(Environment.NewLine);

			sqlText = sb.ToString();

			//Prameterオブジェクトの作成
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_E = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_E", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_E = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_E", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime_F = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_F", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_F = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_F", SqlDbType.BigInt);
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);// ADD 2011/08/18 張莉莉　Redmine#23746
			
			//Parameterオブジェクトへ値設定
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_E.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_E.Value = receiveDataWork.EndDateTime;
			findParaUpdateStartDateTime_F.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_F.Value = receiveDataWork.EndDateTime;
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 張莉莉　Redmine#23746

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //データ送信抽出条件区分が「伝票区分」の場合
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = receiveDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                findParaEndTime.Value = receiveDataWork.EndDateTimeTicks;
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

			// SQL文
			sqlCommand.CommandText = sqlText;
            //  ADD dingjx  2011/10/08  ---------------->>>>>>
            // Timeout
            sqlCommand.CommandTimeout = 600;
            //  ADD dingjx  2011/10/08  ----------------<<<<<<
			myReader = sqlCommand.ExecuteReader();

			ArrayList salesHistoryList = new ArrayList();
			ArrayList salesHisDtlList = new ArrayList();
			DCSalesHistDtlDB dCSalesHistDtlDB = new DCSalesHistDtlDB();
			DCSalesHistoryWork tmpWorkE = new DCSalesHistoryWork();
			DCSalesHistDtlWork tmpWorkF = new DCSalesHistDtlWork();

			Dictionary<string, string> salesHisDic = new Dictionary<string, string>();
			Dictionary<string, string> salesHisDtlDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				// 売上履歴データ
				tmpWorkE = this.CopyToSalesHistoryWorkFromReaderSCM(ref myReader, "E_");
				string workE_key = tmpWorkE.EnterpriseCode + tmpWorkE.AcptAnOdrStatus.ToString() + tmpWorkE.SalesSlipNum;
				if (!string.Empty.Equals(tmpWorkE.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkE.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkE.SalesSlipNum)
					&& !salesHisDic.ContainsKey(workE_key))
				{
					salesHisDic.Add(workE_key, workE_key);
					salesHistoryList.Add(tmpWorkE);
				}
				// 売上履歴明細データ
				tmpWorkF = dCSalesHistDtlDB.CopyToSalesHistDtlWorkFromReaderSCM(ref myReader, "F_");
				string workF_key = tmpWorkF.EnterpriseCode + tmpWorkF.AcptAnOdrStatus.ToString() + tmpWorkF.SalesSlipDtlNum.ToString();
				if (!string.Empty.Equals(tmpWorkF.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkF.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkF.SalesSlipDtlNum.ToString())
					&& !salesHisDtlDic.ContainsKey(workF_key))
				{
					salesHisDtlDic.Add(workF_key, workF_key);
					salesHisDtlList.Add(tmpWorkF);
				}
			}

			// 売上履歴要否フラグ
			if (receiveDataWork.DoSalesHistoryFlg)
			{
				resultList.Add(salesHistoryList);
			}
			// 売上履歴明細否フラグ
			if (receiveDataWork.DoSalesHistDtlFlg)
			{
				resultList.Add(salesHisDtlList);
			}

			if (salesHistoryList.Count > 0)
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
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		private DCSalesHistoryWork CopyToSalesHistoryWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCSalesHistoryWork salesHistoryWork = new DCSalesHistoryWork();

			this.CopyToSalesHistoryWorkFromReaderSCM(ref myReader, ref salesHistoryWork, tableNm);

			return salesHistoryWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → salesHistoryWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="salesHistoryWork">salesHistoryWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToSalesHistoryWorkFromReaderSCM(ref SqlDataReader myReader, ref DCSalesHistoryWork salesHistoryWork, string tableNm)
		{
			if (myReader != null && salesHistoryWork != null)
			{
				# region クラスへ格納
				salesHistoryWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				salesHistoryWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				salesHistoryWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				salesHistoryWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				salesHistoryWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				salesHistoryWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				salesHistoryWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				salesHistoryWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				salesHistoryWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				salesHistoryWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				salesHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				salesHistoryWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				salesHistoryWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				salesHistoryWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEBITNLNKSALESSLNUMRF"));
				salesHistoryWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPCDRF"));
				salesHistoryWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESGOODSCDRF"));
				salesHistoryWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCRECDIVCDRF"));
				salesHistoryWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESINPSECCDRF"));
				salesHistoryWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEMANDADDUPSECCDRF"));
				salesHistoryWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RESULTSADDUPSECCDRF"));
				salesHistoryWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDATESECCDRF"));
				salesHistoryWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPUPDATECDRF"));
				salesHistoryWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SEARCHSLIPDATERF"));
				salesHistoryWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SHIPMENTDAYRF"));
				salesHistoryWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SALESDATERF"));
				salesHistoryWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ADDUPADATERF"));
				salesHistoryWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELAYPAYMENTDIVRF"));
				salesHistoryWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INPUTAGENCDRF"));
				salesHistoryWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INPUTAGENNMRF"));
				salesHistoryWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESINPUTCODERF"));
				salesHistoryWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESINPUTNAMERF"));
				salesHistoryWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FRONTEMPLOYEECDRF"));
				salesHistoryWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FRONTEMPLOYEENMRF"));
				salesHistoryWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESEMPLOYEECDRF"));
				salesHistoryWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESEMPLOYEENMRF"));
				salesHistoryWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TOTALAMOUNTDISPWAYCDRF"));
				salesHistoryWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TTLAMNTDISPRATEAPYRF"));
				salesHistoryWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESTOTALTAXINCRF"));
				salesHistoryWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESTOTALTAXEXCRF"));
				salesHistoryWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTTOTALTAXINCRF"));
				salesHistoryWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTTOTALTAXEXCRF"));
				salesHistoryWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKTOTALTAXINCRF"));
				salesHistoryWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKTOTALTAXEXCRF"));
				salesHistoryWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSUBTOTALTAXINCRF"));
				salesHistoryWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSUBTOTALTAXEXCRF"));
				salesHistoryWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTSUBTTLINCRF"));
				salesHistoryWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTSUBTTLEXCRF"));
				salesHistoryWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKSUBTTLINCRF"));
				salesHistoryWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKSUBTTLEXCRF"));
				salesHistoryWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESNETPRICERF"));
				salesHistoryWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSUBTOTALTAXRF"));
				salesHistoryWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESOUTTAXRF"));
				salesHistoryWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESINTAXRF"));
				salesHistoryWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALSUBTTLSUBTOTAXFRERF"));
				salesHistoryWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESOUTTAXRF"));
				salesHistoryWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALAMNTCONSTAXINCLURF"));
				salesHistoryWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESDISTTLTAXEXCRF"));
				salesHistoryWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESDISOUTTAXRF"));
				salesHistoryWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESDISINTAXRF"));
				salesHistoryWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDPARTSDISOUTTAXRF"));
				salesHistoryWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDPARTSDISINTAXRF"));
				salesHistoryWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDWORKDISOUTTAXRF"));
				salesHistoryWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDWORKDISINTAXRF"));
				salesHistoryWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESDISTAXFRERF"));
				salesHistoryWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESDISOUTTAXRF"));
				salesHistoryWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESDISTTLTAXINCLURF"));
				salesHistoryWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "PARTSDISCOUNTRATERF"));
				salesHistoryWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "RAVORDISCOUNTRATERF"));
				salesHistoryWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TOTALCOSTRF"));
				salesHistoryWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CONSTAXLAYMETHODRF"));
				salesHistoryWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CONSTAXRATERF"));
				salesHistoryWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACTIONPROCCDRF"));
				salesHistoryWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ACCRECCONSTAXRF"));
				salesHistoryWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTODEPOSITCDRF"));
				salesHistoryWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTODEPOSITSLIPNORF"));
				salesHistoryWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITALLOWANCETTLRF"));
				salesHistoryWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITALWCBLNCERF"));
				salesHistoryWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CLAIMCODERF"));
				salesHistoryWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CLAIMSNMRF"));
				salesHistoryWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERCODERF"));
				salesHistoryWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERNAMERF"));
				salesHistoryWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERNAME2RF"));
				salesHistoryWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERSNMRF"));
				salesHistoryWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "HONORIFICTITLERF"));
				salesHistoryWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OUTPUTNAMECODERF"));
				salesHistoryWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "OUTPUTNAMERF"));
				salesHistoryWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTSLIPNORF"));
				salesHistoryWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPADDRESSDIVRF"));
				salesHistoryWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEECODERF"));
				salesHistoryWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAMERF"));
				salesHistoryWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAME2RF"));
				salesHistoryWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEPOSTNORF"));
				salesHistoryWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR1RF"));
				salesHistoryWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR3RF"));
				salesHistoryWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR4RF"));
				salesHistoryWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEETELNORF"));
				salesHistoryWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEFAXNORF"));
				salesHistoryWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSALESLIPNUMRF"));
				salesHistoryWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPNOTERF"));
				salesHistoryWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPNOTE2RF"));
				salesHistoryWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPNOTE3RF"));
				salesHistoryWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONDIVRF"));
				salesHistoryWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONRF"));
				salesHistoryWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DETAILROWCOUNTRF"));
				salesHistoryWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDISENDDATERF"));
				salesHistoryWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDITAKEINDATERF"));
				salesHistoryWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK1RF"));
				salesHistoryWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK2RF"));
				salesHistoryWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTDIVCDRF"));
				salesHistoryWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTFINISHCDRF"));
				salesHistoryWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPPRINTDATERF"));
				salesHistoryWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPECODERF"));
				salesHistoryWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPENAMERF"));
				salesHistoryWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELIVEREDGOODSDIVRF"));
				salesHistoryWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DELIVEREDGOODSDIVNMRF"));
				salesHistoryWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESAREACODERF"));
				salesHistoryWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESAREANAMERF"));
				salesHistoryWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPPRTSETPAPERIDRF"));
				salesHistoryWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "COMPLETECDRF"));
				salesHistoryWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESPRICEFRACPROCCDRF"));
				salesHistoryWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSTTLTAXEXCRF"));
				salesHistoryWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PUREGOODSTTLTAXEXCRF"));
				salesHistoryWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LISTPRICEPRINTDIVRF"));
				salesHistoryWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ERANAMEDISPCD1RF"));
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴データ削除
        /// </summary>
        /// <param name="dcSalesHistoryWorkList">売上履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcSalesHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcSalesHistoryWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴データ削除
        /// </summary>
        /// <param name="dcSalesHistoryWorkList">売上履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcSalesHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCSalesHistoryWork dcSalesHistoryWork in dcSalesHistoryWorkList)
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM SALESHISTORYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcSalesHistoryWork.EnterpriseCode;
                findParaAcptAnOdrStatus.Value = dcSalesHistoryWork.AcptAnOdrStatus;
				findParaSalesSlipNum.Value = dcSalesHistoryWork.SalesSlipNum;


                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 売上履歴データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上履歴データ登録
        /// </summary>
        /// <param name="dcSalesHistoryWorkList">売上履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcSalesHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcSalesHistoryWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上履歴データ登録
        /// </summary>
        /// <param name="dcSalesHistoryWorkList">売上履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcSalesHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCSalesHistoryWork dcSalesHistoryWork in dcSalesHistoryWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO SALESHISTORYRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSALESSLNUMRF, SALESSLIPCDRF, SALESGOODSCDRF, ACCRECDIVCDRF, SALESINPSECCDRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, SALESSLIPUPDATECDRF, SEARCHSLIPDATERF, SHIPMENTDAYRF, SALESDATERF, ADDUPADATERF, DELAYPAYMENTDIVRF, INPUTAGENCDRF, INPUTAGENNMRF, SALESINPUTCODERF, SALESINPUTNAMERF, FRONTEMPLOYEECDRF, FRONTEMPLOYEENMRF, SALESEMPLOYEECDRF, SALESEMPLOYEENMRF, TOTALAMOUNTDISPWAYCDRF, TTLAMNTDISPRATEAPYRF, SALESTOTALTAXINCRF, SALESTOTALTAXEXCRF, SALESPRTTOTALTAXINCRF, SALESPRTTOTALTAXEXCRF, SALESWORKTOTALTAXINCRF, SALESWORKTOTALTAXEXCRF, SALESSUBTOTALTAXINCRF, SALESSUBTOTALTAXEXCRF, SALESPRTSUBTTLINCRF, SALESPRTSUBTTLEXCRF, SALESWORKSUBTTLINCRF, SALESWORKSUBTTLEXCRF, SALESNETPRICERF, SALESSUBTOTALTAXRF, ITDEDSALESOUTTAXRF, ITDEDSALESINTAXRF, SALSUBTTLSUBTOTAXFRERF, SALESOUTTAXRF, SALAMNTCONSTAXINCLURF, SALESDISTTLTAXEXCRF, ITDEDSALESDISOUTTAXRF, ITDEDSALESDISINTAXRF, ITDEDPARTSDISOUTTAXRF, ITDEDPARTSDISINTAXRF, ITDEDWORKDISOUTTAXRF, ITDEDWORKDISINTAXRF, ITDEDSALESDISTAXFRERF, SALESDISOUTTAXRF, SALESDISTTLTAXINCLURF, PARTSDISCOUNTRATERF, RAVORDISCOUNTRATERF, TOTALCOSTRF, CONSTAXLAYMETHODRF, CONSTAXRATERF, FRACTIONPROCCDRF, ACCRECCONSTAXRF, AUTODEPOSITCDRF, AUTODEPOSITSLIPNORF, DEPOSITALLOWANCETTLRF, DEPOSITALWCBLNCERF, CLAIMCODERF, CLAIMSNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, HONORIFICTITLERF, OUTPUTNAMECODERF, OUTPUTNAMERF, CUSTSLIPNORF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, PARTYSALESLIPNUMRF, SLIPNOTERF, SLIPNOTE2RF, SLIPNOTE3RF, RETGOODSREASONDIVRF, RETGOODSREASONRF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, SALESSLIPPRINTDATERF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, DELIVEREDGOODSDIVRF, DELIVEREDGOODSDIVNMRF, SALESAREACODERF, SALESAREANAMERF, SLIPPRTSETPAPERIDRF, COMPLETECDRF, SALESPRICEFRACPROCCDRF, STOCKGOODSTTLTAXEXCRF, PUREGOODSTTLTAXEXCRF, LISTPRICEPRINTDIVRF, ERANAMEDISPCD1RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @SALESSLIPNUM, @SECTIONCODE, @SUBSECTIONCODE, @DEBITNOTEDIV, @DEBITNLNKSALESSLNUM, @SALESSLIPCD, @SALESGOODSCD, @ACCRECDIVCD, @SALESINPSECCD, @DEMANDADDUPSECCD, @RESULTSADDUPSECCD, @UPDATESECCD, @SALESSLIPUPDATECD, @SEARCHSLIPDATE, @SHIPMENTDAY, @SALESDATE, @ADDUPADATE, @DELAYPAYMENTDIV, @INPUTAGENCD, @INPUTAGENNM, @SALESINPUTCODE, @SALESINPUTNAME, @FRONTEMPLOYEECD, @FRONTEMPLOYEENM, @SALESEMPLOYEECD, @SALESEMPLOYEENM, @TOTALAMOUNTDISPWAYCD, @TTLAMNTDISPRATEAPY, @SALESTOTALTAXINC, @SALESTOTALTAXEXC, @SALESPRTTOTALTAXINC, @SALESPRTTOTALTAXEXC, @SALESWORKTOTALTAXINC, @SALESWORKTOTALTAXEXC, @SALESSUBTOTALTAXINC, @SALESSUBTOTALTAXEXC, @SALESPRTSUBTTLINC, @SALESPRTSUBTTLEXC, @SALESWORKSUBTTLINC, @SALESWORKSUBTTLEXC, @SALESNETPRICE, @SALESSUBTOTALTAX, @ITDEDSALESOUTTAX, @ITDEDSALESINTAX, @SALSUBTTLSUBTOTAXFRE, @SALESOUTTAX, @SALAMNTCONSTAXINCLU, @SALESDISTTLTAXEXC, @ITDEDSALESDISOUTTAX, @ITDEDSALESDISINTAX, @ITDEDPARTSDISOUTTAX, @ITDEDPARTSDISINTAX, @ITDEDWORKDISOUTTAX, @ITDEDWORKDISINTAX, @ITDEDSALESDISTAXFRE, @SALESDISOUTTAX, @SALESDISTTLTAXINCLU, @PARTSDISCOUNTRATE, @RAVORDISCOUNTRATE, @TOTALCOST, @CONSTAXLAYMETHOD, @CONSTAXRATE, @FRACTIONPROCCD, @ACCRECCONSTAX, @AUTODEPOSITCD, @AUTODEPOSITSLIPNO, @DEPOSITALLOWANCETTL, @DEPOSITALWCBLNCE, @CLAIMCODE, @CLAIMSNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @HONORIFICTITLE, @OUTPUTNAMECODE, @OUTPUTNAME, @CUSTSLIPNO, @SLIPADDRESSDIV, @ADDRESSEECODE, @ADDRESSEENAME, @ADDRESSEENAME2, @ADDRESSEEPOSTNO, @ADDRESSEEADDR1, @ADDRESSEEADDR3, @ADDRESSEEADDR4, @ADDRESSEETELNO, @ADDRESSEEFAXNO, @PARTYSALESLIPNUM, @SLIPNOTE, @SLIPNOTE2, @SLIPNOTE3, @RETGOODSREASONDIV, @RETGOODSREASON, @DETAILROWCOUNT, @EDISENDDATE, @EDITAKEINDATE, @UOEREMARK1, @UOEREMARK2, @SLIPPRINTDIVCD, @SLIPPRINTFINISHCD, @SALESSLIPPRINTDATE, @BUSINESSTYPECODE, @BUSINESSTYPENAME, @DELIVEREDGOODSDIV, @DELIVEREDGOODSDIVNM, @SALESAREACODE, @SALESAREANAME, @SLIPPRTSETPAPERID, @COMPLETECD, @SALESPRICEFRACPROCCD, @STOCKGOODSTTLTAXEXC, @PUREGOODSTTLTAXEXC, @LISTPRICEPRINTDIV, @ERANAMEDISPCD1)";
                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                SqlParameter paraDebitNLnkSalesSlNum = sqlCommand.Parameters.Add("@DEBITNLNKSALESSLNUM", SqlDbType.NChar);
                SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                SqlParameter paraSalesGoodsCd = sqlCommand.Parameters.Add("@SALESGOODSCD", SqlDbType.Int);
                SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                SqlParameter paraSalesInpSecCd = sqlCommand.Parameters.Add("@SALESINPSECCD", SqlDbType.NChar);
                SqlParameter paraDemandAddUpSecCd = sqlCommand.Parameters.Add("@DEMANDADDUPSECCD", SqlDbType.NChar);
                SqlParameter paraResultsAddUpSecCd = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                SqlParameter paraUpdateSecCd = sqlCommand.Parameters.Add("@UPDATESECCD", SqlDbType.NChar);
                SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                SqlParameter paraSearchSlipDate = sqlCommand.Parameters.Add("@SEARCHSLIPDATE", SqlDbType.Int);
                SqlParameter paraShipmentDay = sqlCommand.Parameters.Add("@SHIPMENTDAY", SqlDbType.Int);
                SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);
                SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
                SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
                SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);
                SqlParameter paraSalesInputName = sqlCommand.Parameters.Add("@SALESINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                SqlParameter paraFrontEmployeeNm = sqlCommand.Parameters.Add("@FRONTEMPLOYEENM", SqlDbType.NVarChar);
                SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@SALESEMPLOYEECD", SqlDbType.NChar);
                SqlParameter paraSalesEmployeeNm = sqlCommand.Parameters.Add("@SALESEMPLOYEENM", SqlDbType.NVarChar);
                SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);
                SqlParameter paraSalesTotalTaxInc = sqlCommand.Parameters.Add("@SALESTOTALTAXINC", SqlDbType.BigInt);
                SqlParameter paraSalesTotalTaxExc = sqlCommand.Parameters.Add("@SALESTOTALTAXEXC", SqlDbType.BigInt);
                SqlParameter paraSalesPrtTotalTaxInc = sqlCommand.Parameters.Add("@SALESPRTTOTALTAXINC", SqlDbType.BigInt);
                SqlParameter paraSalesPrtTotalTaxExc = sqlCommand.Parameters.Add("@SALESPRTTOTALTAXEXC", SqlDbType.BigInt);
                SqlParameter paraSalesWorkTotalTaxInc = sqlCommand.Parameters.Add("@SALESWORKTOTALTAXINC", SqlDbType.BigInt);
                SqlParameter paraSalesWorkTotalTaxExc = sqlCommand.Parameters.Add("@SALESWORKTOTALTAXEXC", SqlDbType.BigInt);
                SqlParameter paraSalesSubtotalTaxInc = sqlCommand.Parameters.Add("@SALESSUBTOTALTAXINC", SqlDbType.BigInt);
                SqlParameter paraSalesSubtotalTaxExc = sqlCommand.Parameters.Add("@SALESSUBTOTALTAXEXC", SqlDbType.BigInt);
                SqlParameter paraSalesPrtSubttlInc = sqlCommand.Parameters.Add("@SALESPRTSUBTTLINC", SqlDbType.BigInt);
                SqlParameter paraSalesPrtSubttlExc = sqlCommand.Parameters.Add("@SALESPRTSUBTTLEXC", SqlDbType.BigInt);
                SqlParameter paraSalesWorkSubttlInc = sqlCommand.Parameters.Add("@SALESWORKSUBTTLINC", SqlDbType.BigInt);
                SqlParameter paraSalesWorkSubttlExc = sqlCommand.Parameters.Add("@SALESWORKSUBTTLEXC", SqlDbType.BigInt);
                SqlParameter paraSalesNetPrice = sqlCommand.Parameters.Add("@SALESNETPRICE", SqlDbType.BigInt);
                SqlParameter paraSalesSubtotalTax = sqlCommand.Parameters.Add("@SALESSUBTOTALTAX", SqlDbType.BigInt);
                SqlParameter paraItdedSalesOutTax = sqlCommand.Parameters.Add("@ITDEDSALESOUTTAX", SqlDbType.BigInt);
                SqlParameter paraItdedSalesInTax = sqlCommand.Parameters.Add("@ITDEDSALESINTAX", SqlDbType.BigInt);
                SqlParameter paraSalSubttlSubToTaxFre = sqlCommand.Parameters.Add("@SALSUBTTLSUBTOTAXFRE", SqlDbType.BigInt);
                SqlParameter paraSalesOutTax = sqlCommand.Parameters.Add("@SALESOUTTAX", SqlDbType.BigInt);
                SqlParameter paraSalAmntConsTaxInclu = sqlCommand.Parameters.Add("@SALAMNTCONSTAXINCLU", SqlDbType.BigInt);
                SqlParameter paraSalesDisTtlTaxExc = sqlCommand.Parameters.Add("@SALESDISTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraItdedSalesDisOutTax = sqlCommand.Parameters.Add("@ITDEDSALESDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraItdedSalesDisInTax = sqlCommand.Parameters.Add("@ITDEDSALESDISINTAX", SqlDbType.BigInt);
                SqlParameter paraItdedPartsDisOutTax = sqlCommand.Parameters.Add("@ITDEDPARTSDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraItdedPartsDisInTax = sqlCommand.Parameters.Add("@ITDEDPARTSDISINTAX", SqlDbType.BigInt);
                SqlParameter paraItdedWorkDisOutTax = sqlCommand.Parameters.Add("@ITDEDWORKDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraItdedWorkDisInTax = sqlCommand.Parameters.Add("@ITDEDWORKDISINTAX", SqlDbType.BigInt);
                SqlParameter paraItdedSalesDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSALESDISTAXFRE", SqlDbType.BigInt);
                SqlParameter paraSalesDisOutTax = sqlCommand.Parameters.Add("@SALESDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraSalesDisTtlTaxInclu = sqlCommand.Parameters.Add("@SALESDISTTLTAXINCLU", SqlDbType.BigInt);
                SqlParameter paraPartsDiscountRate = sqlCommand.Parameters.Add("@PARTSDISCOUNTRATE", SqlDbType.Float);
                SqlParameter paraRavorDiscountRate = sqlCommand.Parameters.Add("@RAVORDISCOUNTRATE", SqlDbType.Float);
                SqlParameter paraTotalCost = sqlCommand.Parameters.Add("@TOTALCOST", SqlDbType.BigInt);
                SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                SqlParameter paraConsTaxRate = sqlCommand.Parameters.Add("@CONSTAXRATE", SqlDbType.Float);
                SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                SqlParameter paraAccRecConsTax = sqlCommand.Parameters.Add("@ACCRECCONSTAX", SqlDbType.BigInt);
                SqlParameter paraAutoDepositCd = sqlCommand.Parameters.Add("@AUTODEPOSITCD", SqlDbType.Int);
                SqlParameter paraAutoDepositSlipNo = sqlCommand.Parameters.Add("@AUTODEPOSITSLIPNO", SqlDbType.Int);
                SqlParameter paraDepositAllowanceTtl = sqlCommand.Parameters.Add("@DEPOSITALLOWANCETTL", SqlDbType.BigInt);
                SqlParameter paraDepositAlwcBlnce = sqlCommand.Parameters.Add("@DEPOSITALWCBLNCE", SqlDbType.BigInt);
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                SqlParameter paraClaimSnm = sqlCommand.Parameters.Add("@CLAIMSNM", SqlDbType.NVarChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraCustomerName = sqlCommand.Parameters.Add("@CUSTOMERNAME", SqlDbType.NVarChar);
                SqlParameter paraCustomerName2 = sqlCommand.Parameters.Add("@CUSTOMERNAME2", SqlDbType.NVarChar);
                SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.Int);
                SqlParameter paraSlipAddressDiv = sqlCommand.Parameters.Add("@SLIPADDRESSDIV", SqlDbType.Int);
                SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@ADDRESSEECODE", SqlDbType.Int);
                SqlParameter paraAddresseeName = sqlCommand.Parameters.Add("@ADDRESSEENAME", SqlDbType.NVarChar);
                SqlParameter paraAddresseeName2 = sqlCommand.Parameters.Add("@ADDRESSEENAME2", SqlDbType.NVarChar);
                SqlParameter paraAddresseePostNo = sqlCommand.Parameters.Add("@ADDRESSEEPOSTNO", SqlDbType.NVarChar);
                SqlParameter paraAddresseeAddr1 = sqlCommand.Parameters.Add("@ADDRESSEEADDR1", SqlDbType.NVarChar);
                SqlParameter paraAddresseeAddr3 = sqlCommand.Parameters.Add("@ADDRESSEEADDR3", SqlDbType.NVarChar);
                SqlParameter paraAddresseeAddr4 = sqlCommand.Parameters.Add("@ADDRESSEEADDR4", SqlDbType.NVarChar);
                SqlParameter paraAddresseeTelNo = sqlCommand.Parameters.Add("@ADDRESSEETELNO", SqlDbType.NVarChar);
                SqlParameter paraAddresseeFaxNo = sqlCommand.Parameters.Add("@ADDRESSEEFAXNO", SqlDbType.NVarChar);
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);
                SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@SLIPNOTE2", SqlDbType.NVarChar);
                SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@SLIPNOTE3", SqlDbType.NVarChar);
                SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);
                SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);
                SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);
                SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                SqlParameter paraSalesSlipPrintDate = sqlCommand.Parameters.Add("@SALESSLIPPRINTDATE", SqlDbType.Int);
                SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);
                SqlParameter paraDeliveredGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
                SqlParameter paraDeliveredGoodsDivNm = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIVNM", SqlDbType.NVarChar);
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                SqlParameter paraCompleteCd = sqlCommand.Parameters.Add("@COMPLETECD", SqlDbType.Int);
                SqlParameter paraSalesPriceFracProcCd = sqlCommand.Parameters.Add("@SALESPRICEFRACPROCCD", SqlDbType.Int);
                SqlParameter paraStockGoodsTtlTaxExc = sqlCommand.Parameters.Add("@STOCKGOODSTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraPureGoodsTtlTaxExc = sqlCommand.Parameters.Add("@PUREGOODSTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraListPricePrintDiv = sqlCommand.Parameters.Add("@LISTPRICEPRINTDIV", SqlDbType.Int);
                SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSalesHistoryWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSalesHistoryWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcSalesHistoryWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesSlipNum);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SubSectionCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.DebitNoteDiv);
                paraDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.DebitNLnkSalesSlNum);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SalesSlipCd);
                paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SalesGoodsCd);
                paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.AccRecDivCd);
                paraSalesInpSecCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesInpSecCd);
                paraDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.DemandAddUpSecCd);
                paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.ResultsAddUpSecCd);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.UpdateSecCd);
                paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SalesSlipUpdateCd);
                paraSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.SearchSlipDate);
                paraShipmentDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.ShipmentDay);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.SalesDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.AddUpADate);
                paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.DelayPaymentDiv);
                paraInputAgenCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.InputAgenCd);
                paraInputAgenNm.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.InputAgenNm);
                paraSalesInputCode.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesInputCode);
                paraSalesInputName.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesInputName);
                paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.FrontEmployeeCd);
                paraFrontEmployeeNm.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.FrontEmployeeNm);
                paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesEmployeeCd);
                paraSalesEmployeeNm.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesEmployeeNm);
                paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.TotalAmountDispWayCd);
                paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.TtlAmntDispRateApy);
                paraSalesTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesTotalTaxInc);
                paraSalesTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesTotalTaxExc);
                paraSalesPrtTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesPrtTotalTaxInc);
                paraSalesPrtTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesPrtTotalTaxExc);
                paraSalesWorkTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesWorkTotalTaxInc);
                paraSalesWorkTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesWorkTotalTaxExc);
                paraSalesSubtotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesSubtotalTaxInc);
                paraSalesSubtotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesSubtotalTaxExc);
                paraSalesPrtSubttlInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesPrtSubttlInc);
                paraSalesPrtSubttlExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesPrtSubttlExc);
                paraSalesWorkSubttlInc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesWorkSubttlInc);
                paraSalesWorkSubttlExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesWorkSubttlExc);
                paraSalesNetPrice.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesNetPrice);
                paraSalesSubtotalTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesSubtotalTax);
                paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedSalesOutTax);
                paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedSalesInTax);
                paraSalSubttlSubToTaxFre.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalSubttlSubToTaxFre);
                paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesOutTax);
                paraSalAmntConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalAmntConsTaxInclu);
                paraSalesDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesDisTtlTaxExc);
                paraItdedSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedSalesDisOutTax);
                paraItdedSalesDisInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedSalesDisInTax);
                paraItdedPartsDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedPartsDisOutTax);
                paraItdedPartsDisInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedPartsDisInTax);
                paraItdedWorkDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedWorkDisOutTax);
                paraItdedWorkDisInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedWorkDisInTax);
                paraItdedSalesDisTaxFre.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.ItdedSalesDisTaxFre);
                paraSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesDisOutTax);
                paraSalesDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.SalesDisTtlTaxInclu);
                paraPartsDiscountRate.Value = SqlDataMediator.SqlSetDouble(dcSalesHistoryWork.PartsDiscountRate);
                paraRavorDiscountRate.Value = SqlDataMediator.SqlSetDouble(dcSalesHistoryWork.RavorDiscountRate);
                paraTotalCost.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.TotalCost);
                paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.ConsTaxLayMethod);
                paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(dcSalesHistoryWork.ConsTaxRate);
                paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.FractionProcCd);
                paraAccRecConsTax.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.AccRecConsTax);
                paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.AutoDepositCd);
                paraAutoDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.AutoDepositSlipNo);
                paraDepositAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.DepositAllowanceTtl);
                paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.DepositAlwcBlnce);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.ClaimCode);
                paraClaimSnm.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.ClaimSnm);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.CustomerCode);
                paraCustomerName.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.CustomerName);
                paraCustomerName2.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.CustomerName2);
                paraCustomerSnm.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.CustomerSnm);
                paraHonorificTitle.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.HonorificTitle);
                paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.OutputNameCode);
                paraOutputName.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.OutputName);
                paraCustSlipNo.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.CustSlipNo);
                paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SlipAddressDiv);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.AddresseeCode);
                paraAddresseeName.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeName);
                paraAddresseeName2.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeName2);
                paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseePostNo);
                paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeAddr1);
                paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeAddr3);
                paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeAddr4);
                paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeTelNo);
                paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.AddresseeFaxNo);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.PartySaleSlipNum);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SlipNote);
                paraSlipNote2.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SlipNote2);
                paraSlipNote3.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SlipNote3);
                paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.RetGoodsReasonDiv);
                paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.RetGoodsReason);
                paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.DetailRowCount);
                paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.EdiSendDate);
                paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.EdiTakeInDate);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.UoeRemark1);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.UoeRemark2);
                paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SlipPrintDivCd);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SlipPrintFinishCd);
                paraSalesSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesHistoryWork.SalesSlipPrintDate);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.BusinessTypeCode);
                paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.BusinessTypeName);
                paraDeliveredGoodsDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.DeliveredGoodsDiv);
                paraDeliveredGoodsDivNm.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.DeliveredGoodsDivNm);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SalesAreaCode);
                paraSalesAreaName.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SalesAreaName);
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dcSalesHistoryWork.SlipPrtSetPaperId);
                paraCompleteCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.CompleteCd);
                paraSalesPriceFracProcCd.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.SalesPriceFracProcCd);
                paraStockGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.StockGoodsTtlTaxExc);
                paraPureGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesHistoryWork.PureGoodsTtlTaxExc);
                paraListPricePrintDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.ListPricePrintDiv);
                paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(dcSalesHistoryWork.EraNameDispCd1);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 売上履歴データを登録する
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
            //sqlCommand.CommandText = "DELETE FROM SALESHISTORYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";                                 //DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM SALESHISTORYRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND RESULTSADDUPSECCDRF = @FINDSECTIONCODERF";//ADD by Liangsd    2011/09/06
            
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

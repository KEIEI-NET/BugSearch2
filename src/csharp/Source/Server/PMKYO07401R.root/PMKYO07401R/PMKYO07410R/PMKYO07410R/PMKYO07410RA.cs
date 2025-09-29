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
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/29  修正内容 : Redmine #23896 No.16 日付の範囲チェックを削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : #24923 ファイルレイアウト変更による項目追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田
// 修 正 日  2011/09/28  修正内容 : タイムアウト暫定対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 修 正 日  2011/10/08  修正内容 : #25780 データ送信処理　売上履歴データ送信時のタイムアウト設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 作 成 日  2011/11/01  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 作 成 日  2011/11/11  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/02/14  修正内容 : READUNCOMMITTEDの追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/02/27  修正内容 : 速度向上化に伴うクエリの修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/21  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
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
    /// 売上データリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Update Note: PMKOBETSU-3877の対応</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/09/25</br>
    /// </remarks>
    [Serializable]
    public class DCSalesSlipDB : RemoteDB
    {
        /// <summary>
        /// 売上データDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCSalesSlipDB()
            : base("PMKYO07411D", "Broadleaf.Application.Remoting.ParamData.DCSalesSlipWork", "SALESSLIPRF")
        {

        }

        # region [Read]
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上データ取得
        /// </summary>
        /// <param name="salesSlipList">売上データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int Search(out ArrayList salesSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  salesSlipList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上データ取得
        /// </summary>
        /// <param name="salesSlipList">売上データ</param>
        /// <param name="receiveDataWork">受信データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList salesSlipList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            salesSlipList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSALESSLNUMRF, SALESSLIPCDRF, SALESGOODSCDRF, ACCRECDIVCDRF, SALESINPSECCDRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, SALESSLIPUPDATECDRF, SEARCHSLIPDATERF, SHIPMENTDAYRF, SALESDATERF, ADDUPADATERF, DELAYPAYMENTDIVRF, ESTIMATEFORMNORF, ESTIMATEDIVIDERF, INPUTAGENCDRF, INPUTAGENNMRF, SALESINPUTCODERF, SALESINPUTNAMERF, FRONTEMPLOYEECDRF, FRONTEMPLOYEENMRF, SALESEMPLOYEECDRF, SALESEMPLOYEENMRF, TOTALAMOUNTDISPWAYCDRF, TTLAMNTDISPRATEAPYRF, SALESTOTALTAXINCRF, SALESTOTALTAXEXCRF, SALESPRTTOTALTAXINCRF, SALESPRTTOTALTAXEXCRF, SALESWORKTOTALTAXINCRF, SALESWORKTOTALTAXEXCRF, SALESSUBTOTALTAXINCRF, SALESSUBTOTALTAXEXCRF, SALESPRTSUBTTLINCRF, SALESPRTSUBTTLEXCRF, SALESWORKSUBTTLINCRF, SALESWORKSUBTTLEXCRF, SALESNETPRICERF, SALESSUBTOTALTAXRF, ITDEDSALESOUTTAXRF, ITDEDSALESINTAXRF, SALSUBTTLSUBTOTAXFRERF, SALESOUTTAXRF, SALAMNTCONSTAXINCLURF, SALESDISTTLTAXEXCRF, ITDEDSALESDISOUTTAXRF, ITDEDSALESDISINTAXRF, ITDEDPARTSDISOUTTAXRF, ITDEDPARTSDISINTAXRF, ITDEDWORKDISOUTTAXRF, ITDEDWORKDISINTAXRF, ITDEDSALESDISTAXFRERF, SALESDISOUTTAXRF, SALESDISTTLTAXINCLURF, PARTSDISCOUNTRATERF, RAVORDISCOUNTRATERF, TOTALCOSTRF, CONSTAXLAYMETHODRF, CONSTAXRATERF, FRACTIONPROCCDRF, ACCRECCONSTAXRF, AUTODEPOSITCDRF, AUTODEPOSITSLIPNORF, DEPOSITALLOWANCETTLRF, DEPOSITALWCBLNCERF, CLAIMCODERF, CLAIMSNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, HONORIFICTITLERF, OUTPUTNAMECODERF, OUTPUTNAMERF, CUSTSLIPNORF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, PARTYSALESLIPNUMRF, SLIPNOTERF, SLIPNOTE2RF, SLIPNOTE3RF, RETGOODSREASONDIVRF, RETGOODSREASONRF, REGIPROCDATERF, CASHREGISTERNORF, POSRECEIPTNORF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, SALESSLIPPRINTDATERF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, ORDERNUMBERRF, DELIVEREDGOODSDIVRF, DELIVEREDGOODSDIVNMRF, SALESAREACODERF, SALESAREANAMERF, RECONCILEFLAGRF, SLIPPRTSETPAPERIDRF, COMPLETECDRF, SALESPRICEFRACPROCCDRF, STOCKGOODSTTLTAXEXCRF, PUREGOODSTTLTAXEXCRF, LISTPRICEPRINTDIVRF, ERANAMEDISPCD1RF, ESTIMATAXDIVCDRF, ESTIMATEFORMPRTCDRF, ESTIMATESUBJECTRF, FOOTNOTES1RF, FOOTNOTES2RF, ESTIMATETITLE1RF, ESTIMATETITLE2RF, ESTIMATETITLE3RF, ESTIMATETITLE4RF, ESTIMATETITLE5RF, ESTIMATENOTE1RF, ESTIMATENOTE2RF, ESTIMATENOTE3RF, ESTIMATENOTE4RF, ESTIMATENOTE5RF, ESTIMATEVALIDITYDATERF, PARTSNOPRTCDRF, OPTIONPRINGDIVCDRF, RATEUSECODERF FROM SALESSLIPRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";

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
                salesSlipList.Add(this.CopyToSalesSlipWorkFromReader(ref myReader));
            }

            if (salesSlipList.Count > 0)
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
		private DCSalesSlipWork CopyToSalesSlipWorkFromReader(ref SqlDataReader myReader)
		{
			DCSalesSlipWork salesSlipWork = new DCSalesSlipWork();

			this.CopyToSalesSlipWorkFromReader(ref myReader, ref salesSlipWork);

			return salesSlipWork;
		}

        /// <summary>
        /// クラス格納処理 Reader → salesSlipWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="salesSlipWork">salesSlipWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
		private void CopyToSalesSlipWorkFromReader(ref SqlDataReader myReader, ref DCSalesSlipWork salesSlipWork)
        {
            if (myReader != null && salesSlipWork != null)
            {
				# region クラスへ格納
				salesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
				salesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
				salesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
				salesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
				salesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
				salesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
				salesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
				salesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
				salesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
				salesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
				salesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
				salesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
				salesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
				salesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
				salesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
				salesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
				salesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
				salesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
				salesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
				salesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
				salesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
				salesSlipWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));
				salesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
				salesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
				salesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
				salesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
				salesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
				salesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));
				salesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
				salesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
				salesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
				salesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
				salesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
				salesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
				salesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
				salesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
				salesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
				salesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
				salesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
				salesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
				salesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
				salesSlipWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
				salesSlipWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
				salesSlipWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
				salesSlipWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
				salesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
				salesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
				salesSlipWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
				salesSlipWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
				salesSlipWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
				salesSlipWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
				salesSlipWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
				salesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
				salesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
				salesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
				salesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
				salesSlipWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
				salesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
				salesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
				salesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
				salesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
				salesSlipWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
				salesSlipWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
				salesSlipWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
				salesSlipWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
				salesSlipWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
				salesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
				salesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
				salesSlipWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
				salesSlipWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
				salesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
				salesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
				salesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
				salesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
				salesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
				salesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
				salesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
				salesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
				salesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
				salesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
				salesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
				salesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				salesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				salesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
				salesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
				salesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
				salesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
				salesSlipWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
				salesSlipWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
				salesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
				salesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
				salesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
				salesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
				salesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
				salesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
				salesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
				salesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
				salesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
				salesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
				salesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
				salesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
				salesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
				salesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
				salesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
				salesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
				salesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));
				salesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
				salesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));
				salesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
				salesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
				salesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
				salesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
				salesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
				salesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
				salesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
				salesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
				salesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
				salesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
				salesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
				salesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
				salesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
				salesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
				salesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
				salesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));
				salesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
				salesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
				salesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
				salesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
				salesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
				salesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
				salesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
				salesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
				salesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
				salesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
				salesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
				salesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
				salesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
				salesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
				salesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
				salesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
				salesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
				salesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
				salesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
				salesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
				salesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
				salesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
				salesSlipWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));
				salesSlipWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
				salesSlipWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));
				salesSlipWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));
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
		private DCSalesSlipWork CopyToSalesSlipWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			DCSalesSlipWork salesSlipWork = new DCSalesSlipWork();

			this.CopyToSalesSlipWorkFromReaderSCM(ref myReader, ref salesSlipWork, tableNm);

			return salesSlipWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → salesSlipWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="salesSlipWork">salesSlipWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToSalesSlipWorkFromReaderSCM(ref SqlDataReader myReader, ref DCSalesSlipWork salesSlipWork, string tableNm)
		{
			if (myReader != null && salesSlipWork != null)
			{
				# region クラスへ格納
				salesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				salesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				salesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				salesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				salesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				salesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				salesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				salesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				salesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSRF"));
				salesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPNUMRF"));
				salesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				salesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				salesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				salesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEBITNLNKSALESSLNUMRF"));
				salesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPCDRF"));
				salesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESGOODSCDRF"));
				salesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCRECDIVCDRF"));
				salesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESINPSECCDRF"));
				salesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DEMANDADDUPSECCDRF"));
				salesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RESULTSADDUPSECCDRF"));
				salesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDATESECCDRF"));
				salesSlipWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPUPDATECDRF"));
				salesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SEARCHSLIPDATERF"));
				salesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SHIPMENTDAYRF"));
				salesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SALESDATERF"));
				salesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ADDUPADATERF"));
				salesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELAYPAYMENTDIVRF"));
				salesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATEFORMNORF"));
				salesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ESTIMATEDIVIDERF"));
				salesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INPUTAGENCDRF"));
				salesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INPUTAGENNMRF"));
				salesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESINPUTCODERF"));
				salesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESINPUTNAMERF"));
				salesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FRONTEMPLOYEECDRF"));
				salesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FRONTEMPLOYEENMRF"));
				salesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESEMPLOYEECDRF"));
				salesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESEMPLOYEENMRF"));
				salesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TOTALAMOUNTDISPWAYCDRF"));
				salesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TTLAMNTDISPRATEAPYRF"));
				salesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESTOTALTAXINCRF"));
				salesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESTOTALTAXEXCRF"));
				salesSlipWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTTOTALTAXINCRF"));
				salesSlipWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTTOTALTAXEXCRF"));
				salesSlipWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKTOTALTAXINCRF"));
				salesSlipWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKTOTALTAXEXCRF"));
				salesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSUBTOTALTAXINCRF"));
				salesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSUBTOTALTAXEXCRF"));
				salesSlipWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTSUBTTLINCRF"));
				salesSlipWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESPRTSUBTTLEXCRF"));
				salesSlipWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKSUBTTLINCRF"));
				salesSlipWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESWORKSUBTTLEXCRF"));
				salesSlipWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESNETPRICERF"));
				salesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSUBTOTALTAXRF"));
				salesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESOUTTAXRF"));
				salesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESINTAXRF"));
				salesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALSUBTTLSUBTOTAXFRERF"));
				salesSlipWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESOUTTAXRF"));
				salesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALAMNTCONSTAXINCLURF"));
				salesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESDISTTLTAXEXCRF"));
				salesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESDISOUTTAXRF"));
				salesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESDISINTAXRF"));
				salesSlipWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDPARTSDISOUTTAXRF"));
				salesSlipWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDPARTSDISINTAXRF"));
				salesSlipWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDWORKDISOUTTAXRF"));
				salesSlipWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDWORKDISINTAXRF"));
				salesSlipWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSALESDISTAXFRERF"));
				salesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESDISOUTTAXRF"));
				salesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESDISTTLTAXINCLURF"));
				salesSlipWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "PARTSDISCOUNTRATERF"));
				salesSlipWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "RAVORDISCOUNTRATERF"));
				salesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TOTALCOSTRF"));
				salesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CONSTAXLAYMETHODRF"));
				salesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "CONSTAXRATERF"));
				salesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACTIONPROCCDRF"));
				salesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ACCRECCONSTAXRF"));
				salesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTODEPOSITCDRF"));
				salesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTODEPOSITSLIPNORF"));
				salesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITALLOWANCETTLRF"));
				salesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "DEPOSITALWCBLNCERF"));
				salesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CLAIMCODERF"));
				salesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CLAIMSNMRF"));
				salesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERCODERF"));
				salesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERNAMERF"));
				salesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERNAME2RF"));
				salesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CUSTOMERSNMRF"));
				salesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "HONORIFICTITLERF"));
				salesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OUTPUTNAMECODERF"));
				salesSlipWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "OUTPUTNAMERF"));
				salesSlipWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTSLIPNORF"));
				salesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPADDRESSDIVRF"));
				salesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEECODERF"));
				salesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAMERF"));
				salesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAME2RF"));
				salesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEPOSTNORF"));
				salesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR1RF"));
				salesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR3RF"));
				salesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR4RF"));
				salesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEETELNORF"));
				salesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEFAXNORF"));
				salesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSALESLIPNUMRF"));
				salesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPNOTERF"));
				salesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPNOTE2RF"));
				salesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPNOTE3RF"));
				salesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONDIVRF"));
				salesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONRF"));
				salesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "REGIPROCDATERF"));
				salesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CASHREGISTERNORF"));
				salesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "POSRECEIPTNORF"));
				salesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DETAILROWCOUNTRF"));
				salesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDISENDDATERF"));
				salesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDITAKEINDATERF"));
				salesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK1RF"));
				salesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK2RF"));
				salesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTDIVCDRF"));
				salesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTFINISHCDRF"));
				salesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPPRINTDATERF"));
				salesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPECODERF"));
				salesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPENAMERF"));
				salesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ORDERNUMBERRF"));
				salesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELIVEREDGOODSDIVRF"));
				salesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "DELIVEREDGOODSDIVNMRF"));
				salesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESAREACODERF"));
				salesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESAREANAMERF"));
				salesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RECONCILEFLAGRF"));
				salesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPPRTSETPAPERIDRF"));
				salesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "COMPLETECDRF"));
				salesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESPRICEFRACPROCCDRF"));
				salesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSTTLTAXEXCRF"));
				salesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "PUREGOODSTTLTAXEXCRF"));
				salesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LISTPRICEPRINTDIVRF"));
				salesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ERANAMEDISPCD1RF"));
				salesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ESTIMATAXDIVCDRF"));
				salesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ESTIMATEFORMPRTCDRF"));
				salesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATESUBJECTRF"));
				salesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FOOTNOTES1RF"));
				salesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "FOOTNOTES2RF"));
				salesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATETITLE1RF"));
				salesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATETITLE2RF"));
				salesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATETITLE3RF"));
				salesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATETITLE4RF"));
				salesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATETITLE5RF"));
				salesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATENOTE1RF"));
				salesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATENOTE2RF"));
				salesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATENOTE3RF"));
				salesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATENOTE4RF"));
				salesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ESTIMATENOTE5RF"));
				salesSlipWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ESTIMATEVALIDITYDATERF"));
				salesSlipWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PARTSNOPRTCDRF"));
				salesSlipWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OPTIONPRINGDIVCDRF"));
				salesSlipWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEUSECODERF"));
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上データ削除
        /// </summary>
        /// <param name="dcSalesSlipWorkList">売上データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Delete(ArrayList dcSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcSalesSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上データ削除
        /// </summary>
        /// <param name="dcSalesSlipWorkList">売上データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCSalesSlipWork dcSalesSlipWork in dcSalesSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "DELETE FROM SALESSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPNUMRF=@FINDSALESSLIPNUM";
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = dcSalesSlipWork.EnterpriseCode;
                findParaAcptAnOdrStatus.Value = dcSalesSlipWork.AcptAnOdrStatus;
                findParaSalesSlipNum.Value = dcSalesSlipWork.SalesSlipNum;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 売上データを削除する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 売上データ登録
        /// </summary>
        /// <param name="dcSalesSlipWorkList">売上データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        public void Insert(ArrayList dcSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcSalesSlipWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 売上データ登録
        /// </summary>
        /// <param name="dcSalesSlipWorkList">売上データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcSalesSlipWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCSalesSlipWork dcSalesSlipWork in dcSalesSlipWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                // Deleteコマンドの生成
                sqlCommand.CommandText = "INSERT INTO SALESSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPNUMRF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSALESSLNUMRF, SALESSLIPCDRF, SALESGOODSCDRF, ACCRECDIVCDRF, SALESINPSECCDRF, DEMANDADDUPSECCDRF, RESULTSADDUPSECCDRF, UPDATESECCDRF, SALESSLIPUPDATECDRF, SEARCHSLIPDATERF, SHIPMENTDAYRF, SALESDATERF, ADDUPADATERF, DELAYPAYMENTDIVRF, ESTIMATEFORMNORF, ESTIMATEDIVIDERF, INPUTAGENCDRF, INPUTAGENNMRF, SALESINPUTCODERF, SALESINPUTNAMERF, FRONTEMPLOYEECDRF, FRONTEMPLOYEENMRF, SALESEMPLOYEECDRF, SALESEMPLOYEENMRF, TOTALAMOUNTDISPWAYCDRF, TTLAMNTDISPRATEAPYRF, SALESTOTALTAXINCRF, SALESTOTALTAXEXCRF, SALESPRTTOTALTAXINCRF, SALESPRTTOTALTAXEXCRF, SALESWORKTOTALTAXINCRF, SALESWORKTOTALTAXEXCRF, SALESSUBTOTALTAXINCRF, SALESSUBTOTALTAXEXCRF, SALESPRTSUBTTLINCRF, SALESPRTSUBTTLEXCRF, SALESWORKSUBTTLINCRF, SALESWORKSUBTTLEXCRF, SALESNETPRICERF, SALESSUBTOTALTAXRF, ITDEDSALESOUTTAXRF, ITDEDSALESINTAXRF, SALSUBTTLSUBTOTAXFRERF, SALESOUTTAXRF, SALAMNTCONSTAXINCLURF, SALESDISTTLTAXEXCRF, ITDEDSALESDISOUTTAXRF, ITDEDSALESDISINTAXRF, ITDEDPARTSDISOUTTAXRF, ITDEDPARTSDISINTAXRF, ITDEDWORKDISOUTTAXRF, ITDEDWORKDISINTAXRF, ITDEDSALESDISTAXFRERF, SALESDISOUTTAXRF, SALESDISTTLTAXINCLURF, PARTSDISCOUNTRATERF, RAVORDISCOUNTRATERF, TOTALCOSTRF, CONSTAXLAYMETHODRF, CONSTAXRATERF, FRACTIONPROCCDRF, ACCRECCONSTAXRF, AUTODEPOSITCDRF, AUTODEPOSITSLIPNORF, DEPOSITALLOWANCETTLRF, DEPOSITALWCBLNCERF, CLAIMCODERF, CLAIMSNMRF, CUSTOMERCODERF, CUSTOMERNAMERF, CUSTOMERNAME2RF, CUSTOMERSNMRF, HONORIFICTITLERF, OUTPUTNAMECODERF, OUTPUTNAMERF, CUSTSLIPNORF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, PARTYSALESLIPNUMRF, SLIPNOTERF, SLIPNOTE2RF, SLIPNOTE3RF, RETGOODSREASONDIVRF, RETGOODSREASONRF, REGIPROCDATERF, CASHREGISTERNORF, POSRECEIPTNORF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, SALESSLIPPRINTDATERF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, ORDERNUMBERRF, DELIVEREDGOODSDIVRF, DELIVEREDGOODSDIVNMRF, SALESAREACODERF, SALESAREANAMERF, RECONCILEFLAGRF, SLIPPRTSETPAPERIDRF, COMPLETECDRF, SALESPRICEFRACPROCCDRF, STOCKGOODSTTLTAXEXCRF, PUREGOODSTTLTAXEXCRF, LISTPRICEPRINTDIVRF, ERANAMEDISPCD1RF, ESTIMATAXDIVCDRF, ESTIMATEFORMPRTCDRF, ESTIMATESUBJECTRF, FOOTNOTES1RF, FOOTNOTES2RF, ESTIMATETITLE1RF, ESTIMATETITLE2RF, ESTIMATETITLE3RF, ESTIMATETITLE4RF, ESTIMATETITLE5RF, ESTIMATENOTE1RF, ESTIMATENOTE2RF, ESTIMATENOTE3RF, ESTIMATENOTE4RF, ESTIMATENOTE5RF, ESTIMATEVALIDITYDATERF, PARTSNOPRTCDRF, OPTIONPRINGDIVCDRF, RATEUSECODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @SALESSLIPNUM, @SECTIONCODE, @SUBSECTIONCODE, @DEBITNOTEDIV, @DEBITNLNKSALESSLNUM, @SALESSLIPCD, @SALESGOODSCD, @ACCRECDIVCD, @SALESINPSECCD, @DEMANDADDUPSECCD, @RESULTSADDUPSECCD, @UPDATESECCD, @SALESSLIPUPDATECD, @SEARCHSLIPDATE, @SHIPMENTDAY, @SALESDATE, @ADDUPADATE, @DELAYPAYMENTDIV, @ESTIMATEFORMNO, @ESTIMATEDIVIDE, @INPUTAGENCD, @INPUTAGENNM, @SALESINPUTCODE, @SALESINPUTNAME, @FRONTEMPLOYEECD, @FRONTEMPLOYEENM, @SALESEMPLOYEECD, @SALESEMPLOYEENM, @TOTALAMOUNTDISPWAYCD, @TTLAMNTDISPRATEAPY, @SALESTOTALTAXINC, @SALESTOTALTAXEXC, @SALESPRTTOTALTAXINC, @SALESPRTTOTALTAXEXC, @SALESWORKTOTALTAXINC, @SALESWORKTOTALTAXEXC, @SALESSUBTOTALTAXINC, @SALESSUBTOTALTAXEXC, @SALESPRTSUBTTLINC, @SALESPRTSUBTTLEXC, @SALESWORKSUBTTLINC, @SALESWORKSUBTTLEXC, @SALESNETPRICE, @SALESSUBTOTALTAX, @ITDEDSALESOUTTAX, @ITDEDSALESINTAX, @SALSUBTTLSUBTOTAXFRE, @SALESOUTTAX, @SALAMNTCONSTAXINCLU, @SALESDISTTLTAXEXC, @ITDEDSALESDISOUTTAX, @ITDEDSALESDISINTAX, @ITDEDPARTSDISOUTTAX, @ITDEDPARTSDISINTAX, @ITDEDWORKDISOUTTAX, @ITDEDWORKDISINTAX, @ITDEDSALESDISTAXFRE, @SALESDISOUTTAX, @SALESDISTTLTAXINCLU, @PARTSDISCOUNTRATE, @RAVORDISCOUNTRATE, @TOTALCOST, @CONSTAXLAYMETHOD, @CONSTAXRATE, @FRACTIONPROCCD, @ACCRECCONSTAX, @AUTODEPOSITCD, @AUTODEPOSITSLIPNO, @DEPOSITALLOWANCETTL, @DEPOSITALWCBLNCE, @CLAIMCODE, @CLAIMSNM, @CUSTOMERCODE, @CUSTOMERNAME, @CUSTOMERNAME2, @CUSTOMERSNM, @HONORIFICTITLE, @OUTPUTNAMECODE, @OUTPUTNAME, @CUSTSLIPNO, @SLIPADDRESSDIV, @ADDRESSEECODE, @ADDRESSEENAME, @ADDRESSEENAME2, @ADDRESSEEPOSTNO, @ADDRESSEEADDR1, @ADDRESSEEADDR3, @ADDRESSEEADDR4, @ADDRESSEETELNO, @ADDRESSEEFAXNO, @PARTYSALESLIPNUM, @SLIPNOTE, @SLIPNOTE2, @SLIPNOTE3, @RETGOODSREASONDIV, @RETGOODSREASON, @REGIPROCDATE, @CASHREGISTERNO, @POSRECEIPTNO, @DETAILROWCOUNT, @EDISENDDATE, @EDITAKEINDATE, @UOEREMARK1, @UOEREMARK2, @SLIPPRINTDIVCD, @SLIPPRINTFINISHCD, @SALESSLIPPRINTDATE, @BUSINESSTYPECODE, @BUSINESSTYPENAME, @ORDERNUMBER, @DELIVEREDGOODSDIV, @DELIVEREDGOODSDIVNM, @SALESAREACODE, @SALESAREANAME, @RECONCILEFLAG, @SLIPPRTSETPAPERID, @COMPLETECD, @SALESPRICEFRACPROCCD, @STOCKGOODSTTLTAXEXC, @PUREGOODSTTLTAXEXC, @LISTPRICEPRINTDIV, @ERANAMEDISPCD1, @ESTIMATAXDIVCD, @ESTIMATEFORMPRTCD, @ESTIMATESUBJECT, @FOOTNOTES1, @FOOTNOTES2, @ESTIMATETITLE1, @ESTIMATETITLE2, @ESTIMATETITLE3, @ESTIMATETITLE4, @ESTIMATETITLE5, @ESTIMATENOTE1, @ESTIMATENOTE2, @ESTIMATENOTE3, @ESTIMATENOTE4, @ESTIMATENOTE5, @ESTIMATEVALIDITYDATE, @PARTSNOPRTCD, @OPTIONPRINGDIVCD, @RATEUSECODE)";
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
                SqlParameter paraEstimateFormNo = sqlCommand.Parameters.Add("@ESTIMATEFORMNO", SqlDbType.NChar);
                SqlParameter paraEstimateDivide = sqlCommand.Parameters.Add("@ESTIMATEDIVIDE", SqlDbType.Int);
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
                SqlParameter paraRegiProcDate = sqlCommand.Parameters.Add("@REGIPROCDATE", SqlDbType.Int);
                SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                SqlParameter paraPosReceiptNo = sqlCommand.Parameters.Add("@POSRECEIPTNO", SqlDbType.Int);
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
                SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                SqlParameter paraDeliveredGoodsDiv = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIV", SqlDbType.Int);
                SqlParameter paraDeliveredGoodsDivNm = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIVNM", SqlDbType.NVarChar);
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                SqlParameter paraReconcileFlag = sqlCommand.Parameters.Add("@RECONCILEFLAG", SqlDbType.Int);
                SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                SqlParameter paraCompleteCd = sqlCommand.Parameters.Add("@COMPLETECD", SqlDbType.Int);
                SqlParameter paraSalesPriceFracProcCd = sqlCommand.Parameters.Add("@SALESPRICEFRACPROCCD", SqlDbType.Int);
                SqlParameter paraStockGoodsTtlTaxExc = sqlCommand.Parameters.Add("@STOCKGOODSTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraPureGoodsTtlTaxExc = sqlCommand.Parameters.Add("@PUREGOODSTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraListPricePrintDiv = sqlCommand.Parameters.Add("@LISTPRICEPRINTDIV", SqlDbType.Int);
                SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);
                SqlParameter paraEstimaTaxDivCd = sqlCommand.Parameters.Add("@ESTIMATAXDIVCD", SqlDbType.Int);
                SqlParameter paraEstimateFormPrtCd = sqlCommand.Parameters.Add("@ESTIMATEFORMPRTCD", SqlDbType.Int);
                SqlParameter paraEstimateSubject = sqlCommand.Parameters.Add("@ESTIMATESUBJECT", SqlDbType.NVarChar);
                SqlParameter paraFootnotes1 = sqlCommand.Parameters.Add("@FOOTNOTES1", SqlDbType.NVarChar);
                SqlParameter paraFootnotes2 = sqlCommand.Parameters.Add("@FOOTNOTES2", SqlDbType.NVarChar);
                SqlParameter paraEstimateTitle1 = sqlCommand.Parameters.Add("@ESTIMATETITLE1", SqlDbType.NVarChar);
                SqlParameter paraEstimateTitle2 = sqlCommand.Parameters.Add("@ESTIMATETITLE2", SqlDbType.NVarChar);
                SqlParameter paraEstimateTitle3 = sqlCommand.Parameters.Add("@ESTIMATETITLE3", SqlDbType.NVarChar);
                SqlParameter paraEstimateTitle4 = sqlCommand.Parameters.Add("@ESTIMATETITLE4", SqlDbType.NVarChar);
                SqlParameter paraEstimateTitle5 = sqlCommand.Parameters.Add("@ESTIMATETITLE5", SqlDbType.NVarChar);
                SqlParameter paraEstimateNote1 = sqlCommand.Parameters.Add("@ESTIMATENOTE1", SqlDbType.NVarChar);
                SqlParameter paraEstimateNote2 = sqlCommand.Parameters.Add("@ESTIMATENOTE2", SqlDbType.NVarChar);
                SqlParameter paraEstimateNote3 = sqlCommand.Parameters.Add("@ESTIMATENOTE3", SqlDbType.NVarChar);
                SqlParameter paraEstimateNote4 = sqlCommand.Parameters.Add("@ESTIMATENOTE4", SqlDbType.NVarChar);
                SqlParameter paraEstimateNote5 = sqlCommand.Parameters.Add("@ESTIMATENOTE5", SqlDbType.NVarChar);
                SqlParameter paraEstimateValidityDate = sqlCommand.Parameters.Add("@ESTIMATEVALIDITYDATE", SqlDbType.Int);
                SqlParameter paraPartsNoPrtCd = sqlCommand.Parameters.Add("@PARTSNOPRTCD", SqlDbType.Int);
                SqlParameter paraOptionPringDivCd = sqlCommand.Parameters.Add("@OPTIONPRINGDIVCD", SqlDbType.Int);
                SqlParameter paraRateUseCode = sqlCommand.Parameters.Add("@RATEUSECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSalesSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcSalesSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcSalesSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesSlipNum);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SubSectionCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.DebitNoteDiv);
                paraDebitNLnkSalesSlNum.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.DebitNLnkSalesSlNum);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SalesSlipCd);
                paraSalesGoodsCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SalesGoodsCd);
                paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.AccRecDivCd);
                paraSalesInpSecCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesInpSecCd);
                paraDemandAddUpSecCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.DemandAddUpSecCd);
                paraResultsAddUpSecCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.ResultsAddUpSecCd);
                paraUpdateSecCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.UpdateSecCd);
                paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SalesSlipUpdateCd);
                paraSearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.SearchSlipDate);
                paraShipmentDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.ShipmentDay);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.SalesDate);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.AddUpADate);
                paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.DelayPaymentDiv);
                paraEstimateFormNo.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateFormNo);
                paraEstimateDivide.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.EstimateDivide);
                paraInputAgenCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.InputAgenCd);
                paraInputAgenNm.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.InputAgenNm);
                paraSalesInputCode.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesInputCode);
                paraSalesInputName.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesInputName);
                paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.FrontEmployeeCd);
                paraFrontEmployeeNm.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.FrontEmployeeNm);
                paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesEmployeeCd);
                paraSalesEmployeeNm.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesEmployeeNm);
                paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.TotalAmountDispWayCd);
                paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.TtlAmntDispRateApy);
                paraSalesTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesTotalTaxInc);
                paraSalesTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesTotalTaxExc);
                paraSalesPrtTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesPrtTotalTaxInc);
                paraSalesPrtTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesPrtTotalTaxExc);
                paraSalesWorkTotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesWorkTotalTaxInc);
                paraSalesWorkTotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesWorkTotalTaxExc);
                paraSalesSubtotalTaxInc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesSubtotalTaxInc);
                paraSalesSubtotalTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesSubtotalTaxExc);
                paraSalesPrtSubttlInc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesPrtSubttlInc);
                paraSalesPrtSubttlExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesPrtSubttlExc);
                paraSalesWorkSubttlInc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesWorkSubttlInc);
                paraSalesWorkSubttlExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesWorkSubttlExc);
                paraSalesNetPrice.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesNetPrice);
                paraSalesSubtotalTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesSubtotalTax);
                paraItdedSalesOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedSalesOutTax);
                paraItdedSalesInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedSalesInTax);
                paraSalSubttlSubToTaxFre.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalSubttlSubToTaxFre);
                paraSalesOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesOutTax);
                paraSalAmntConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalAmntConsTaxInclu);
                paraSalesDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesDisTtlTaxExc);
                paraItdedSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedSalesDisOutTax);
                paraItdedSalesDisInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedSalesDisInTax);
                paraItdedPartsDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedPartsDisOutTax);
                paraItdedPartsDisInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedPartsDisInTax);
                paraItdedWorkDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedWorkDisOutTax);
                paraItdedWorkDisInTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedWorkDisInTax);
                paraItdedSalesDisTaxFre.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.ItdedSalesDisTaxFre);
                paraSalesDisOutTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesDisOutTax);
                paraSalesDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.SalesDisTtlTaxInclu);
                paraPartsDiscountRate.Value = SqlDataMediator.SqlSetDouble(dcSalesSlipWork.PartsDiscountRate);
                paraRavorDiscountRate.Value = SqlDataMediator.SqlSetDouble(dcSalesSlipWork.RavorDiscountRate);
                paraTotalCost.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.TotalCost);
                paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.ConsTaxLayMethod);
                paraConsTaxRate.Value = SqlDataMediator.SqlSetDouble(dcSalesSlipWork.ConsTaxRate);
                paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.FractionProcCd);
                paraAccRecConsTax.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.AccRecConsTax);
                paraAutoDepositCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.AutoDepositCd);
                paraAutoDepositSlipNo.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.AutoDepositSlipNo);
                paraDepositAllowanceTtl.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.DepositAllowanceTtl);
                paraDepositAlwcBlnce.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.DepositAlwcBlnce);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.ClaimCode);
                paraClaimSnm.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.ClaimSnm);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.CustomerCode);
                paraCustomerName.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.CustomerName);
                paraCustomerName2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.CustomerName2);
                paraCustomerSnm.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.CustomerSnm);
                paraHonorificTitle.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.HonorificTitle);
                paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.OutputNameCode);
                paraOutputName.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.OutputName);
                paraCustSlipNo.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.CustSlipNo);
                paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SlipAddressDiv);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.AddresseeCode);
                paraAddresseeName.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeName);
                paraAddresseeName2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeName2);
                paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseePostNo);
                paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeAddr1);
                paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeAddr3);
                paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeAddr4);
                paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeTelNo);
                paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.AddresseeFaxNo);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.PartySaleSlipNum);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SlipNote);
                paraSlipNote2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SlipNote2);
                paraSlipNote3.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SlipNote3);
                paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.RetGoodsReasonDiv);
                paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.RetGoodsReason);
                paraRegiProcDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.RegiProcDate);
                paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.CashRegisterNo);
                paraPosReceiptNo.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.PosReceiptNo);
                paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.DetailRowCount);
                paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.EdiSendDate);
                paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.EdiTakeInDate);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.UoeRemark1);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.UoeRemark2);
                paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SlipPrintDivCd);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SlipPrintFinishCd);
                paraSalesSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.SalesSlipPrintDate);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.BusinessTypeCode);
                paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.BusinessTypeName);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.OrderNumber);
                paraDeliveredGoodsDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.DeliveredGoodsDiv);
                paraDeliveredGoodsDivNm.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.DeliveredGoodsDivNm);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SalesAreaCode);
                paraSalesAreaName.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SalesAreaName);
                paraReconcileFlag.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.ReconcileFlag);
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.SlipPrtSetPaperId);
                paraCompleteCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.CompleteCd);
                paraSalesPriceFracProcCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.SalesPriceFracProcCd);
                paraStockGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.StockGoodsTtlTaxExc);
                paraPureGoodsTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(dcSalesSlipWork.PureGoodsTtlTaxExc);
                paraListPricePrintDiv.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.ListPricePrintDiv);
                paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.EraNameDispCd1);
                paraEstimaTaxDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.EstimaTaxDivCd);
                paraEstimateFormPrtCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.EstimateFormPrtCd);
                paraEstimateSubject.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateSubject);
                paraFootnotes1.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.Footnotes1);
                paraFootnotes2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.Footnotes2);
                paraEstimateTitle1.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateTitle1);
                paraEstimateTitle2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateTitle2);
                paraEstimateTitle3.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateTitle3);
                paraEstimateTitle4.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateTitle4);
                paraEstimateTitle5.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateTitle5);
                paraEstimateNote1.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateNote1);
                paraEstimateNote2.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateNote2);
                paraEstimateNote3.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateNote3);
                paraEstimateNote4.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateNote4);
                paraEstimateNote5.Value = SqlDataMediator.SqlSetString(dcSalesSlipWork.EstimateNote5);
                paraEstimateValidityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcSalesSlipWork.EstimateValidityDate);
                paraPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.PartsNoPrtCd);
                paraOptionPringDivCd.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.OptionPringDivCd);
                paraRateUseCode.Value = SqlDataMediator.SqlSetInt32(dcSalesSlipWork.RateUseCode);


                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // 売上データを登録する
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        #region [Search SCM]
		/// <summary>
		/// 売上データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="acpOdrList">acpOdrList</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, out ArrayList acpOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out resultList, out acpOdrList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 売上データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="acpOdrList">acpOdrList</param>
		/// <param name="receiveDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        /// <br>Update Note: PMKOBETSU-3877の対応</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/09/25</br>
		private int SearchSCMProc(out ArrayList resultList, out ArrayList acpOdrList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();
			acpOdrList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //sqlCommand.CommandTimeout = 0;  //ADD 2011/09/28 M.Kubota //  DEL dingjx  2011/10/08  #25780

			//売上データ
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT A.CREATEDATETIMERF as A_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.UPDATEDATETIMERF as A_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.ENTERPRISECODERF as A_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.FILEHEADERGUIDRF as A_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.UPDEMPLOYEECODERF as A_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.UPDASSEMBLYID1RF as A_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.UPDASSEMBLYID2RF as A_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.LOGICALDELETECODERF as A_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.ACPTANODRSTATUSRF as A_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSLIPNUMRF as A_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SECTIONCODERF as A_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SUBSECTIONCODERF as A_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.DEBITNOTEDIVRF as A_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,A.DEBITNLNKSALESSLNUMRF as A_DEBITNLNKSALESSLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSLIPCDRF as A_SALESSLIPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESGOODSCDRF as A_SALESGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ACCRECDIVCDRF as A_ACCRECDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESINPSECCDRF as A_SALESINPSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.DEMANDADDUPSECCDRF as A_DEMANDADDUPSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.RESULTSADDUPSECCDRF as A_RESULTSADDUPSECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.UPDATESECCDRF as A_UPDATESECCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSLIPUPDATECDRF as A_SALESSLIPUPDATECDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SEARCHSLIPDATERF as A_SEARCHSLIPDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SHIPMENTDAYRF as A_SHIPMENTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESDATERF as A_SALESDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDUPADATERF as A_ADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.DELAYPAYMENTDIVRF as A_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATEFORMNORF as A_ESTIMATEFORMNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATEDIVIDERF as A_ESTIMATEDIVIDERF ").Append(Environment.NewLine);
			sb.Append(" ,A.INPUTAGENCDRF as A_INPUTAGENCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.INPUTAGENNMRF as A_INPUTAGENNMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESINPUTCODERF as A_SALESINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESINPUTNAMERF as A_SALESINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.FRONTEMPLOYEECDRF as A_FRONTEMPLOYEECDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.FRONTEMPLOYEENMRF as A_FRONTEMPLOYEENMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESEMPLOYEECDRF as A_SALESEMPLOYEECDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESEMPLOYEENMRF as A_SALESEMPLOYEENMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.TOTALAMOUNTDISPWAYCDRF as A_TOTALAMOUNTDISPWAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.TTLAMNTDISPRATEAPYRF as A_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESTOTALTAXINCRF as A_SALESTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESTOTALTAXEXCRF as A_SALESTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESPRTTOTALTAXINCRF as A_SALESPRTTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESPRTTOTALTAXEXCRF as A_SALESPRTTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESWORKTOTALTAXINCRF as A_SALESWORKTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESWORKTOTALTAXEXCRF as A_SALESWORKTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSUBTOTALTAXINCRF as A_SALESSUBTOTALTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSUBTOTALTAXEXCRF as A_SALESSUBTOTALTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESPRTSUBTTLINCRF as A_SALESPRTSUBTTLINCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESPRTSUBTTLEXCRF as A_SALESPRTSUBTTLEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESWORKSUBTTLINCRF as A_SALESWORKSUBTTLINCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESWORKSUBTTLEXCRF as A_SALESWORKSUBTTLEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESNETPRICERF as A_SALESNETPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSUBTOTALTAXRF as A_SALESSUBTOTALTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDSALESOUTTAXRF as A_ITDEDSALESOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDSALESINTAXRF as A_ITDEDSALESINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALSUBTTLSUBTOTAXFRERF as A_SALSUBTTLSUBTOTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESOUTTAXRF as A_SALESOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALAMNTCONSTAXINCLURF as A_SALAMNTCONSTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESDISTTLTAXEXCRF as A_SALESDISTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDSALESDISOUTTAXRF as A_ITDEDSALESDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDSALESDISINTAXRF as A_ITDEDSALESDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDPARTSDISOUTTAXRF as A_ITDEDPARTSDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDPARTSDISINTAXRF as A_ITDEDPARTSDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDWORKDISOUTTAXRF as A_ITDEDWORKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDWORKDISINTAXRF as A_ITDEDWORKDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ITDEDSALESDISTAXFRERF as A_ITDEDSALESDISTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESDISOUTTAXRF as A_SALESDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESDISTTLTAXINCLURF as A_SALESDISTTLTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,A.PARTSDISCOUNTRATERF as A_PARTSDISCOUNTRATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.RAVORDISCOUNTRATERF as A_RAVORDISCOUNTRATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.TOTALCOSTRF as A_TOTALCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,A.CONSTAXLAYMETHODRF as A_CONSTAXLAYMETHODRF ").Append(Environment.NewLine);
			sb.Append(" ,A.CONSTAXRATERF as A_CONSTAXRATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.FRACTIONPROCCDRF as A_FRACTIONPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ACCRECCONSTAXRF as A_ACCRECCONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,A.AUTODEPOSITCDRF as A_AUTODEPOSITCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.AUTODEPOSITSLIPNORF as A_AUTODEPOSITSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.DEPOSITALLOWANCETTLRF as A_DEPOSITALLOWANCETTLRF ").Append(Environment.NewLine);
			sb.Append(" ,A.DEPOSITALWCBLNCERF as A_DEPOSITALWCBLNCERF ").Append(Environment.NewLine);
			sb.Append(" ,A.CLAIMCODERF as A_CLAIMCODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.CLAIMSNMRF as A_CLAIMSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.CUSTOMERCODERF as A_CUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.CUSTOMERNAMERF as A_CUSTOMERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.CUSTOMERNAME2RF as A_CUSTOMERNAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.CUSTOMERSNMRF as A_CUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.HONORIFICTITLERF as A_HONORIFICTITLERF ").Append(Environment.NewLine);
			sb.Append(" ,A.OUTPUTNAMECODERF as A_OUTPUTNAMECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.OUTPUTNAMERF as A_OUTPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.CUSTSLIPNORF as A_CUSTSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPADDRESSDIVRF as A_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEECODERF as A_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEENAMERF as A_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEENAME2RF as A_ADDRESSEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEEPOSTNORF as A_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEEADDR1RF as A_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEEADDR3RF as A_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEEADDR4RF as A_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEETELNORF as A_ADDRESSEETELNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.ADDRESSEEFAXNORF as A_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.PARTYSALESLIPNUMRF as A_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPNOTERF as A_SLIPNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPNOTE2RF as A_SLIPNOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPNOTE3RF as A_SLIPNOTE3RF ").Append(Environment.NewLine);
			sb.Append(" ,A.RETGOODSREASONDIVRF as A_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,A.RETGOODSREASONRF as A_RETGOODSREASONRF ").Append(Environment.NewLine);
			sb.Append(" ,A.REGIPROCDATERF as A_REGIPROCDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.CASHREGISTERNORF as A_CASHREGISTERNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.POSRECEIPTNORF as A_POSRECEIPTNORF ").Append(Environment.NewLine);
			sb.Append(" ,A.DETAILROWCOUNTRF as A_DETAILROWCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,A.EDISENDDATERF as A_EDISENDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.EDITAKEINDATERF as A_EDITAKEINDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.UOEREMARK1RF as A_UOEREMARK1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.UOEREMARK2RF as A_UOEREMARK2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPPRINTDIVCDRF as A_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPPRINTFINISHCDRF as A_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESSLIPPRINTDATERF as A_SALESSLIPPRINTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.BUSINESSTYPECODERF as A_BUSINESSTYPECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.BUSINESSTYPENAMERF as A_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.ORDERNUMBERRF as A_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,A.DELIVEREDGOODSDIVRF as A_DELIVEREDGOODSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,A.DELIVEREDGOODSDIVNMRF as A_DELIVEREDGOODSDIVNMRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESAREACODERF as A_SALESAREACODERF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESAREANAMERF as A_SALESAREANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,A.RECONCILEFLAGRF as A_RECONCILEFLAGRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SLIPPRTSETPAPERIDRF as A_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.COMPLETECDRF as A_COMPLETECDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.SALESPRICEFRACPROCCDRF as A_SALESPRICEFRACPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.STOCKGOODSTTLTAXEXCRF as A_STOCKGOODSTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.PUREGOODSTTLTAXEXCRF as A_PUREGOODSTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,A.LISTPRICEPRINTDIVRF as A_LISTPRICEPRINTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ERANAMEDISPCD1RF as A_ERANAMEDISPCD1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATAXDIVCDRF as A_ESTIMATAXDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATEFORMPRTCDRF as A_ESTIMATEFORMPRTCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATESUBJECTRF as A_ESTIMATESUBJECTRF ").Append(Environment.NewLine);
			sb.Append(" ,A.FOOTNOTES1RF as A_FOOTNOTES1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.FOOTNOTES2RF as A_FOOTNOTES2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATETITLE1RF as A_ESTIMATETITLE1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATETITLE2RF as A_ESTIMATETITLE2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATETITLE3RF as A_ESTIMATETITLE3RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATETITLE4RF as A_ESTIMATETITLE4RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATETITLE5RF as A_ESTIMATETITLE5RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATENOTE1RF as A_ESTIMATENOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATENOTE2RF as A_ESTIMATENOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATENOTE3RF as A_ESTIMATENOTE3RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATENOTE4RF as A_ESTIMATENOTE4RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATENOTE5RF as A_ESTIMATENOTE5RF ").Append(Environment.NewLine);
			sb.Append(" ,A.ESTIMATEVALIDITYDATERF as A_ESTIMATEVALIDITYDATERF ").Append(Environment.NewLine);
			sb.Append(" ,A.PARTSNOPRTCDRF as A_PARTSNOPRTCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.OPTIONPRINGDIVCDRF as A_OPTIONPRINGDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,A.RATEUSECODERF  as A_RATEUSECODERF  ").Append(Environment.NewLine);
			//売上明細データ
			sb.Append(" ,B.CREATEDATETIMERF as B_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.UPDATEDATETIMERF as B_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.ENTERPRISECODERF as B_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.FILEHEADERGUIDRF as B_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.UPDEMPLOYEECODERF as B_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.UPDASSEMBLYID1RF as B_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,B.UPDASSEMBLYID2RF as B_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,B.LOGICALDELETECODERF as B_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACCEPTANORDERNORF as B_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACPTANODRSTATUSRF as B_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESSLIPNUMRF as B_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESROWNORF as B_SALESROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESROWDERIVNORF as B_SALESROWDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.SECTIONCODERF as B_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.SUBSECTIONCODERF as B_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESDATERF as B_SALESDATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.COMMONSEQNORF as B_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESSLIPDTLNUMRF as B_SALESSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACPTANODRSTATUSSRCRF as B_ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESSLIPDTLNUMSRCRF as B_SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SUPPLIERFORMALSYNCRF as B_SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.STOCKSLIPDTLNUMSYNCRF as B_STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESSLIPCDDTLRF as B_SALESSLIPCDDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.DELIGDSCMPLTDUEDATERF as B_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSKINDCODERF as B_GOODSKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSSEARCHDIVCDRF as B_GOODSSEARCHDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSMAKERCDRF as B_GOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.MAKERNAMERF as B_MAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.MAKERKANANAMERF as B_MAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSNORF as B_GOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSNAMERF as B_GOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSNAMEKANARF as B_GOODSNAMEKANARF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSLGROUPRF as B_GOODSLGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSLGROUPNAMERF as B_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSMGROUPRF as B_GOODSMGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSMGROUPNAMERF as B_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.BLGROUPCODERF as B_BLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.BLGROUPNAMERF as B_BLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.BLGOODSCODERF as B_BLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.BLGOODSFULLNAMERF as B_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.ENTERPRISEGANRECODERF as B_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.ENTERPRISEGANRENAMERF as B_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.WAREHOUSECODERF as B_WAREHOUSECODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.WAREHOUSENAMERF as B_WAREHOUSENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.WAREHOUSESHELFNORF as B_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESORDERDIVCDRF as B_SALESORDERDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.OPENPRICEDIVRF as B_OPENPRICEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSRATERANKRF as B_GOODSRATERANKRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CUSTRATEGRPCODERF as B_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.LISTPRICERATERF as B_LISTPRICERATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATESECTPRICEUNPRCRF as B_RATESECTPRICEUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEDIVLPRICERF as B_RATEDIVLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.UNPRCCALCCDLPRICERF as B_UNPRCCALCCDLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRICECDLPRICERF as B_PRICECDLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.STDUNPRCLPRICERF as B_STDUNPRCLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.FRACPROCUNITLPRICERF as B_FRACPROCUNITLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.FRACPROCLPRICERF as B_FRACPROCLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.LISTPRICETAXINCFLRF as B_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.LISTPRICETAXEXCFLRF as B_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.LISTPRICECHNGCDRF as B_LISTPRICECHNGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESRATERF as B_SALESRATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATESECTSALUNPRCRF as B_RATESECTSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEDIVSALUNPRCRF as B_RATEDIVSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.UNPRCCALCCDSALUNPRCRF as B_UNPRCCALCCDSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRICECDSALUNPRCRF as B_PRICECDSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.STDUNPRCSALUNPRCRF as B_STDUNPRCSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.FRACPROCUNITSALUNPRCRF as B_FRACPROCUNITSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.FRACPROCSALUNPRCRF as B_FRACPROCSALUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESUNPRCTAXINCFLRF as B_SALESUNPRCTAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESUNPRCTAXEXCFLRF as B_SALESUNPRCTAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESUNPRCCHNGCDRF as B_SALESUNPRCCHNGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.COSTRATERF as B_COSTRATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATESECTCSTUNPRCRF as B_RATESECTCSTUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEDIVUNCSTRF as B_RATEDIVUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.UNPRCCALCCDUNCSTRF as B_UNPRCCALCCDUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRICECDUNCSTRF as B_PRICECDUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.STDUNPRCUNCSTRF as B_STDUNPRCUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.FRACPROCUNITUNCSTRF as B_FRACPROCUNITUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.FRACPROCUNCSTRF as B_FRACPROCUNCSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESUNITCOSTRF as B_SALESUNITCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESUNITCOSTCHNGDIVRF as B_SALESUNITCOSTCHNGDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEBLGOODSCODERF as B_RATEBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEBLGOODSNAMERF as B_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEGOODSRATEGRPCDRF as B_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEGOODSRATEGRPNMRF as B_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEBLGROUPCODERF as B_RATEBLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RATEBLGROUPNAMERF as B_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRTBLGOODSCODERF as B_PRTBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRTBLGOODSNAMERF as B_PRTBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESCODERF as B_SALESCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESCDNMRF as B_SALESCDNMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.WORKMANHOURRF as B_WORKMANHOURRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SHIPMENTCNTRF as B_SHIPMENTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACCEPTANORDERCNTRF as B_ACCEPTANORDERCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACPTANODRADJUSTCNTRF as B_ACPTANODRADJUSTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACPTANODRREMAINCNTRF as B_ACPTANODRREMAINCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.REMAINCNTUPDDATERF as B_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESMONEYTAXINCRF as B_SALESMONEYTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESMONEYTAXEXCRF as B_SALESMONEYTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,B.COSTRF as B_COSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.GRSPROFITCHKDIVRF as B_GRSPROFITCHKDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESGOODSCDRF as B_SALESGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SALESPRICECONSTAXRF as B_SALESPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,B.TAXATIONDIVCDRF as B_TAXATIONDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.PARTYSLIPNUMDTLRF as B_PARTYSLIPNUMDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.DTLNOTERF as B_DTLNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,B.SUPPLIERCDRF as B_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SUPPLIERSNMRF as B_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ORDERNUMBERRF as B_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,B.WAYTOORDERRF as B_WAYTOORDERRF ").Append(Environment.NewLine);
			sb.Append(" ,B.SLIPMEMO1RF as B_SLIPMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,B.SLIPMEMO2RF as B_SLIPMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,B.SLIPMEMO3RF as B_SLIPMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,B.INSIDEMEMO1RF as B_INSIDEMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,B.INSIDEMEMO2RF as B_INSIDEMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,B.INSIDEMEMO3RF as B_INSIDEMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,B.BFLISTPRICERF as B_BFLISTPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.BFSALESUNITPRICERF as B_BFSALESUNITPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,B.BFUNITCOSTRF as B_BFUNITCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTSALESROWNORF as B_CMPLTSALESROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTGOODSMAKERCDRF as B_CMPLTGOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTMAKERNAMERF as B_CMPLTMAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTMAKERKANANAMERF as B_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTGOODSNAMERF as B_CMPLTGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTSHIPMENTCNTRF as B_CMPLTSHIPMENTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTSALESUNPRCFLRF as B_CMPLTSALESUNPRCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTSALESMONEYRF as B_CMPLTSALESMONEYRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTSALESUNITCOSTRF as B_CMPLTSALESUNITCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTCOSTRF as B_CMPLTCOSTRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTPARTYSALSLNUMRF as B_CMPLTPARTYSALSLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.CMPLTNOTERF as B_CMPLTNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRTGOODSNORF as B_PRTGOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRTMAKERCODERF as B_PRTMAKERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.PRTMAKERNAMERF as B_PRTMAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.CAMPAIGNCODERF as B_CAMPAIGNCODERF ").Append(Environment.NewLine);
			sb.Append(" ,B.CAMPAIGNNAMERF as B_CAMPAIGNNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,B.GOODSDIVCDRF as B_GOODSDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ANSWERDELIVDATERF as B_ANSWERDELIVDATERF ").Append(Environment.NewLine);
			sb.Append(" ,B.RECYCLEDIVRF as B_RECYCLEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,B.RECYCLEDIVNMRF as B_RECYCLEDIVNMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.WAYTOACPTODRRF as B_WAYTOACPTODRRF ").Append(Environment.NewLine);
			// ADD 2011/09/15 ---------- >>>>>
			sb.Append(" ,B.AUTOANSWERDIVSCMRF as B_AUTOANSWERDIVSCMRF ").Append(Environment.NewLine);
			sb.Append(" ,B.ACCEPTORORDERKINDRF as B_ACCEPTORORDERKINDRF ").Append(Environment.NewLine);
			sb.Append(" ,B.INQUIRYNUMBERRF as B_INQUIRYNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,B.INQROWNUMBERRF as B_INQROWNUMBERRF ").Append(Environment.NewLine);
			// ADD 2011/09/15 ---------- <<<<<
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
            sb.Append(" ,B.RENTSYNCSUPPLIERRF as B_RENTSYNCSUPPLIERRF ").Append(Environment.NewLine); // 貸出同時仕入先
            sb.Append(" ,B.RENTSYNCSTOCKDATERF as B_RENTSYNCSTOCKDATERF ").Append(Environment.NewLine); // 貸出同時仕入日
            sb.Append(" ,B.RENTSYNCSUPSLIPNORF as B_RENTSYNCSUPSLIPNORF ").Append(Environment.NewLine); // 貸出同時仕入伝票番号
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877 ----->>>>>
			//受注マスタ
			sb.Append(" ,C.CREATEDATETIMERF as C_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C.UPDATEDATETIMERF as C_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C.ENTERPRISECODERF as C_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C.FILEHEADERGUIDRF as C_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,C.UPDEMPLOYEECODERF as C_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C.UPDASSEMBLYID1RF as C_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,C.UPDASSEMBLYID2RF as C_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,C.LOGICALDELETECODERF as C_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C.SECTIONCODERF as C_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C.ACCEPTANORDERNORF as C_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,C.ACPTANODRSTATUSRF as C_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C.SALESSLIPNUMRF as C_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C.DATAINPUTSYSTEMRF as C_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C.COMMONSEQNORF as C_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C.SLIPDTLNUMRF as C_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C.SLIPDTLNUMDERIVNORF as C_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,C.SRCLINKDATACODERF as C_SRCLINKDATACODERF ").Append(Environment.NewLine);
			sb.Append(" ,C.SRCSLIPDTLNUMRF as C_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);
			//受注マスタ（車両）
			sb.Append(" ,D.CREATEDATETIMERF as D_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.UPDATEDATETIMERF as D_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.ENTERPRISECODERF as D_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.FILEHEADERGUIDRF as D_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,D.UPDEMPLOYEECODERF as D_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.UPDASSEMBLYID1RF as D_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,D.UPDASSEMBLYID2RF as D_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,D.LOGICALDELETECODERF as D_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.ACCEPTANORDERNORF as D_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,D.ACPTANODRSTATUSRF as D_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,D.DATAINPUTSYSTEMRF as D_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,D.CARMNGNORF as D_CARMNGNORF ").Append(Environment.NewLine);
			sb.Append(" ,D.CARMNGCODERF as D_CARMNGCODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.NUMBERPLATE1CODERF as D_NUMBERPLATE1CODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.NUMBERPLATE1NAMERF as D_NUMBERPLATE1NAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.NUMBERPLATE2RF as D_NUMBERPLATE2RF ").Append(Environment.NewLine);
			sb.Append(" ,D.NUMBERPLATE3RF as D_NUMBERPLATE3RF ").Append(Environment.NewLine);
			sb.Append(" ,D.NUMBERPLATE4RF as D_NUMBERPLATE4RF ").Append(Environment.NewLine);
			sb.Append(" ,D.FIRSTENTRYDATERF as D_FIRSTENTRYDATERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MAKERCODERF as D_MAKERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MAKERFULLNAMERF as D_MAKERFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MAKERHALFNAMERF as D_MAKERHALFNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MODELCODERF as D_MODELCODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MODELSUBCODERF as D_MODELSUBCODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MODELFULLNAMERF as D_MODELFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MODELHALFNAMERF as D_MODELHALFNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.EXHAUSTGASSIGNRF as D_EXHAUSTGASSIGNRF ").Append(Environment.NewLine);
			sb.Append(" ,D.SERIESMODELRF as D_SERIESMODELRF ").Append(Environment.NewLine);
			sb.Append(" ,D.CATEGORYSIGNMODELRF as D_CATEGORYSIGNMODELRF ").Append(Environment.NewLine);
			sb.Append(" ,D.FULLMODELRF as D_FULLMODELRF ").Append(Environment.NewLine);
			sb.Append(" ,D.MODELDESIGNATIONNORF as D_MODELDESIGNATIONNORF ").Append(Environment.NewLine);
			sb.Append(" ,D.CATEGORYNORF as D_CATEGORYNORF ").Append(Environment.NewLine);
			sb.Append(" ,D.FRAMEMODELRF as D_FRAMEMODELRF ").Append(Environment.NewLine);
			sb.Append(" ,D.FRAMENORF as D_FRAMENORF ").Append(Environment.NewLine);
			sb.Append(" ,D.SEARCHFRAMENORF as D_SEARCHFRAMENORF ").Append(Environment.NewLine);
			sb.Append(" ,D.ENGINEMODELNMRF as D_ENGINEMODELNMRF ").Append(Environment.NewLine);
			sb.Append(" ,D.RELEVANCEMODELRF as D_RELEVANCEMODELRF ").Append(Environment.NewLine);
			sb.Append(" ,D.SUBCARNMCDRF as D_SUBCARNMCDRF ").Append(Environment.NewLine);
			sb.Append(" ,D.MODELGRADESNAMERF as D_MODELGRADESNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.COLORCODERF as D_COLORCODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.COLORNAME1RF as D_COLORNAME1RF ").Append(Environment.NewLine);
			sb.Append(" ,D.TRIMCODERF as D_TRIMCODERF ").Append(Environment.NewLine);
			sb.Append(" ,D.TRIMNAMERF as D_TRIMNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,D.MILEAGERF as D_MILEAGERF ").Append(Environment.NewLine);
			sb.Append(" ,D.FULLMODELFIXEDNOARYRF as D_FULLMODELFIXEDNOARYRF ").Append(Environment.NewLine);
			sb.Append(" ,D.CATEGORYOBJARYRF as D_CATEGORYOBJARYRF ").Append(Environment.NewLine);
			sb.Append(" ,D.CARNOTERF as D_CARNOTERF ").Append(Environment.NewLine);
			sb.Append(" ,D.FREESRCHMDLFXDNOARYRF as D_FREESRCHMDLFXDNOARYRF ").Append(Environment.NewLine);
            // --- ADD 2013/03/21 ---------->>>>>
            sb.Append(" ,D.DOMESTICFOREIGNCODERF as D_DOMESTICFOREIGNCODERF ").Append(Environment.NewLine);
            // --- ADD 2013/03/21 ----------<<<<<


            // ----- UPD 2012/02/27 西 毅 ---------->>>>>
            //sb.Append(" FROM  SALESSLIPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			////売上明細データ
			//sb.Append(" INNER JOIN SALESDETAILRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			////	売上データ.企業コード　＝　売上明細データ.企業コード
			//sb.Append(" ON A.ENTERPRISECODERF = B.ENTERPRISECODERF ").Append(Environment.NewLine);
			////	売上データ.受注ステータス　＝　売上明細データ.受注ステータス
			//sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			////	売上データ.売上伝票番号　＝　売上明細データ.売上伝票番号
			//sb.Append(" AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF ").Append(Environment.NewLine);
			//// DEL 2011.08.29 ------->>>>>
			//////	売上明細データ.更新日時　>　パラメータ.開始日付
			////sb.Append(" AND B.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_B ").Append(Environment.NewLine);
			//////	売上明細データ.更新日時　≦　パラメータ.終了日付
			////sb.Append(" AND B.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_B ").Append(Environment.NewLine);
			//// DEL 2011.08.29 -------<<<<<
            //
			////受注マスタ
			//sb.Append(" INNER JOIN ACCEPTODRRF C WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			////	売上明細データ.企業コード　＝　受注マスタ.企業コード
			//sb.Append(" ON B.ENTERPRISECODERF = C.ENTERPRISECODERF ").Append(Environment.NewLine);
			////	売上明細データ.受注ステータス　＝　受注マスタ.受注ステータス
			//sb.Append(" AND ((B.ACPTANODRSTATUSRF = 10 AND C.ACPTANODRSTATUSRF =1)  ").Append(Environment.NewLine);
			//sb.Append(" OR (B.ACPTANODRSTATUSRF = 20 AND C.ACPTANODRSTATUSRF =3)  ").Append(Environment.NewLine);
			//sb.Append(" OR (B.ACPTANODRSTATUSRF = 30 AND C.ACPTANODRSTATUSRF =7)  ").Append(Environment.NewLine);
			//sb.Append(" OR (B.ACPTANODRSTATUSRF = 40 AND C.ACPTANODRSTATUSRF =5)) ").Append(Environment.NewLine);
			////	売上明細データ.売上伝票番号　＝　受注マスタ.伝票番号
			//sb.Append(" AND B.SALESSLIPNUMRF = C.SALESSLIPNUMRF ").Append(Environment.NewLine);
			//// DEL 2011.08.29 ------->>>>>
			//////	受注マスタ.更新日時　>　パラメータ.開始日付
			////sb.Append(" AND C.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_C ").Append(Environment.NewLine);
			//////	受注マスタ.更新日時　≦　パラメータ.終了日付
			////sb.Append(" AND C.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_C ").Append(Environment.NewLine);
			//// DEL 2011.08.29 -------<<<<<
            //
			////受注マスタ（車両）
			//sb.Append(" LEFT JOIN ACCEPTODRCARRF D WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			////	受注マスタ.企業コード　＝　受注マスタ（車両）.企業コード（＋）
			//sb.Append(" ON C.ENTERPRISECODERF = D.ENTERPRISECODERF ").Append(Environment.NewLine);
			////	受注マスタ.受注ステータス　＝　受注マスタ（車両）.受注ステータス（＋）
			//sb.Append(" AND C.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			////	受注マスタ.受注番号　＝　受注マスタ（車両）.受注番号（＋）
			//sb.Append(" AND C.ACCEPTANORDERNORF = D.ACCEPTANORDERNORF ").Append(Environment.NewLine);
			//// DEL 2011.08.29 ------->>>>>
			//////	受注マスタ（車両）.更新日時　>　パラメータ.開始日付
			////sb.Append(" AND D.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_D ").Append(Environment.NewLine);
			//////	受注マスタ（車両）.更新日時　≦　パラメータ.終了日付
			////sb.Append(" AND D.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_D ").Append(Environment.NewLine);
			//// DEL 2011.08.29 -------<<<<<
            sb.Append(" FROM  (SELECT A.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" ,A.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" ,A.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" FROM  SALESSLIPRF AS A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            // ----- UPD 2012/02/27 西 毅 ----------<<<<<

			//	売上データ.実績計上拠点コード　＝　パラメータ.拠点コード
			sb.Append(" WHERE A.RESULTSADDUPSECCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine);
            //-----Add 2011/11/01 陳建明 for #26228 start----->>>>>
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
		    {
                // ----- DEL 2011/11/11 xupz---------->>>>>
                ////	売上データ.売上日付　≧　パラメータ.開始日付
                //sb.Append(" AND A.SALESDATERF>=@FINDUPDATESTARTDATETIME_A ").Append(Environment.NewLine);
                ////	売上データ.売上日付　≦　パラメータ.終了日付
                //sb.Append(" AND A.SALESDATERF<=@FINDUPDATEENDDATETIME_A ").Append(Environment.NewLine);
                // ----- DEL 2011/11/11 xupz----------<<<<<

                // ----- ADD 2011/11/11 xupz---------->>>>>
                //売上データ(伝票日付対応)　開始
                //sb.Append(" AND ").Append(Environment.NewLine); // DEL 2011/11/30
                sb.Append(" AND (( ").Append(Environment.NewLine);   // ADD 2011/11/30
                sb.Append(" (CASE A.ACPTANODRSTATUSRF WHEN 40 THEN A.SHIPMENTDAYRF ").Append(Environment.NewLine);
                sb.Append(" ELSE A.SALESDATERF END ").Append(Environment.NewLine);
                sb.Append(" >=@FINDUPDATESTARTDATETIME_A ").Append(Environment.NewLine);
                //売上データ(伝票日付対応)　終了
                sb.Append(" AND ").Append(Environment.NewLine);
                sb.Append(" CASE A.ACPTANODRSTATUSRF WHEN 40 THEN A.SHIPMENTDAYRF ").Append(Environment.NewLine);
                sb.Append(" ELSE A.SALESDATERF END ").Append(Environment.NewLine);
                //sb.Append(" <=@FINDUPDATESTARTDATETIME_A)").Append(Environment.NewLine); // DEL 2011/11/30
                sb.Append(" <=@FINDUPDATEENDDATETIME_A)").Append(Environment.NewLine);  // ADD 2011/11/30
                // ----- ADD 2011/11/11 xupz----------<<<<<

                // ----- ADD 2011/11/30 tanh---------->>>>>
                sb.Append(" ) ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append(" OR ((A.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                sb.Append(" OR ((A.UPDATEDATETIMERF>@FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append("     AND (A.UPDATEDATETIMERF <= @FINDENDTIMERF) ").Append(Environment.NewLine);
                sb.Append("     AND (((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);
                sb.Append("         AND (A.SHIPMENTDAYRF<=@FINDUPDATEENDDATETIME_A)) ").Append(Environment.NewLine);
                sb.Append("         OR ((A.ACPTANODRSTATUSRF <> 40) ").Append(Environment.NewLine);
                sb.Append("            AND (A.SALESDATERF<=@FINDUPDATEENDDATETIME_A))))) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<



		    }
		    else
		    {
            //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<<    
                //	売上データ.更新日時　>　パラメータ.開始日付
                sb.Append(" AND A.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_A ").Append(Environment.NewLine);
                //	売上データ.更新日時　≦　パラメータ.終了日付
                sb.Append(" AND A.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_A ").Append(Environment.NewLine);
                //	売上データ.企業コード　＝　パラメータ.企業コード
		    }//Add 2011/11/01 陳建明 for #26228
			sb.Append(" AND A.ENTERPRISECODERF=@FINDENTERPRISECODERF ").Append(Environment.NewLine);// ADD 2011/08/18 張莉莉　Redmine#23746
			// DEL 2011.08.29 --------->>>>>
			//sb.Append(" ORDER BY ").Append(Environment.NewLine);
			//sb.Append(" A_ENTERPRISECODERF ").Append(Environment.NewLine);
			//sb.Append(" ,A_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//sb.Append(" ,A_SALESSLIPNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,B_ACPTANODRSTATUSRF  ").Append(Environment.NewLine);
			//sb.Append(" ,B_SALESSLIPDTLNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C_SECTIONCODERF ").Append(Environment.NewLine);
			//sb.Append(" ,C_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//sb.Append(" ,C_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C_COMMONSEQNORF ").Append(Environment.NewLine);
			//sb.Append(" ,C_SLIPDTLNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			//sb.Append(" ,D_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			//sb.Append(" ,D_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//sb.Append(" ,D_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ---------<<<<<
			// ADD 2011.08.29 --------->>>>>
			sb.Append(" UNION ").Append(Environment.NewLine);

            // ----- UPD 2012/02/27 西 毅 ---------->>>>>
            ////売上データ
            //sb.Append(" SELECT A.CREATEDATETIMERF as A_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UPDATEDATETIMERF as A_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ENTERPRISECODERF as A_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.FILEHEADERGUIDRF as A_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UPDEMPLOYEECODERF as A_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UPDASSEMBLYID1RF as A_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UPDASSEMBLYID2RF as A_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.LOGICALDELETECODERF as A_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ACPTANODRSTATUSRF as A_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSLIPNUMRF as A_SALESSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SECTIONCODERF as A_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SUBSECTIONCODERF as A_SUBSECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DEBITNOTEDIVRF as A_DEBITNOTEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DEBITNLNKSALESSLNUMRF as A_DEBITNLNKSALESSLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSLIPCDRF as A_SALESSLIPCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESGOODSCDRF as A_SALESGOODSCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ACCRECDIVCDRF as A_ACCRECDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESINPSECCDRF as A_SALESINPSECCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DEMANDADDUPSECCDRF as A_DEMANDADDUPSECCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.RESULTSADDUPSECCDRF as A_RESULTSADDUPSECCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UPDATESECCDRF as A_UPDATESECCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSLIPUPDATECDRF as A_SALESSLIPUPDATECDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SEARCHSLIPDATERF as A_SEARCHSLIPDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SHIPMENTDAYRF as A_SHIPMENTDAYRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESDATERF as A_SALESDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDUPADATERF as A_ADDUPADATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DELAYPAYMENTDIVRF as A_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATEFORMNORF as A_ESTIMATEFORMNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATEDIVIDERF as A_ESTIMATEDIVIDERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.INPUTAGENCDRF as A_INPUTAGENCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.INPUTAGENNMRF as A_INPUTAGENNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESINPUTCODERF as A_SALESINPUTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESINPUTNAMERF as A_SALESINPUTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.FRONTEMPLOYEECDRF as A_FRONTEMPLOYEECDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.FRONTEMPLOYEENMRF as A_FRONTEMPLOYEENMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESEMPLOYEECDRF as A_SALESEMPLOYEECDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESEMPLOYEENMRF as A_SALESEMPLOYEENMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.TOTALAMOUNTDISPWAYCDRF as A_TOTALAMOUNTDISPWAYCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.TTLAMNTDISPRATEAPYRF as A_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESTOTALTAXINCRF as A_SALESTOTALTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESTOTALTAXEXCRF as A_SALESTOTALTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESPRTTOTALTAXINCRF as A_SALESPRTTOTALTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESPRTTOTALTAXEXCRF as A_SALESPRTTOTALTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESWORKTOTALTAXINCRF as A_SALESWORKTOTALTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESWORKTOTALTAXEXCRF as A_SALESWORKTOTALTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSUBTOTALTAXINCRF as A_SALESSUBTOTALTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSUBTOTALTAXEXCRF as A_SALESSUBTOTALTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESPRTSUBTTLINCRF as A_SALESPRTSUBTTLINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESPRTSUBTTLEXCRF as A_SALESPRTSUBTTLEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESWORKSUBTTLINCRF as A_SALESWORKSUBTTLINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESWORKSUBTTLEXCRF as A_SALESWORKSUBTTLEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESNETPRICERF as A_SALESNETPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSUBTOTALTAXRF as A_SALESSUBTOTALTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDSALESOUTTAXRF as A_ITDEDSALESOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDSALESINTAXRF as A_ITDEDSALESINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALSUBTTLSUBTOTAXFRERF as A_SALSUBTTLSUBTOTAXFRERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESOUTTAXRF as A_SALESOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALAMNTCONSTAXINCLURF as A_SALAMNTCONSTAXINCLURF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESDISTTLTAXEXCRF as A_SALESDISTTLTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDSALESDISOUTTAXRF as A_ITDEDSALESDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDSALESDISINTAXRF as A_ITDEDSALESDISINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDPARTSDISOUTTAXRF as A_ITDEDPARTSDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDPARTSDISINTAXRF as A_ITDEDPARTSDISINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDWORKDISOUTTAXRF as A_ITDEDWORKDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDWORKDISINTAXRF as A_ITDEDWORKDISINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ITDEDSALESDISTAXFRERF as A_ITDEDSALESDISTAXFRERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESDISOUTTAXRF as A_SALESDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESDISTTLTAXINCLURF as A_SALESDISTTLTAXINCLURF ").Append(Environment.NewLine);
            //sb.Append(" ,A.PARTSDISCOUNTRATERF as A_PARTSDISCOUNTRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.RAVORDISCOUNTRATERF as A_RAVORDISCOUNTRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.TOTALCOSTRF as A_TOTALCOSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CONSTAXLAYMETHODRF as A_CONSTAXLAYMETHODRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CONSTAXRATERF as A_CONSTAXRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.FRACTIONPROCCDRF as A_FRACTIONPROCCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ACCRECCONSTAXRF as A_ACCRECCONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.AUTODEPOSITCDRF as A_AUTODEPOSITCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.AUTODEPOSITSLIPNORF as A_AUTODEPOSITSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DEPOSITALLOWANCETTLRF as A_DEPOSITALLOWANCETTLRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DEPOSITALWCBLNCERF as A_DEPOSITALWCBLNCERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CLAIMCODERF as A_CLAIMCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CLAIMSNMRF as A_CLAIMSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CUSTOMERCODERF as A_CUSTOMERCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CUSTOMERNAMERF as A_CUSTOMERNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CUSTOMERNAME2RF as A_CUSTOMERNAME2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CUSTOMERSNMRF as A_CUSTOMERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.HONORIFICTITLERF as A_HONORIFICTITLERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.OUTPUTNAMECODERF as A_OUTPUTNAMECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.OUTPUTNAMERF as A_OUTPUTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CUSTSLIPNORF as A_CUSTSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPADDRESSDIVRF as A_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEECODERF as A_ADDRESSEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEENAMERF as A_ADDRESSEENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEENAME2RF as A_ADDRESSEENAME2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEEPOSTNORF as A_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEEADDR1RF as A_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEEADDR3RF as A_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEEADDR4RF as A_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEETELNORF as A_ADDRESSEETELNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ADDRESSEEFAXNORF as A_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.PARTYSALESLIPNUMRF as A_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPNOTERF as A_SLIPNOTERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPNOTE2RF as A_SLIPNOTE2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPNOTE3RF as A_SLIPNOTE3RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.RETGOODSREASONDIVRF as A_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.RETGOODSREASONRF as A_RETGOODSREASONRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.REGIPROCDATERF as A_REGIPROCDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.CASHREGISTERNORF as A_CASHREGISTERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.POSRECEIPTNORF as A_POSRECEIPTNORF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DETAILROWCOUNTRF as A_DETAILROWCOUNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.EDISENDDATERF as A_EDISENDDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.EDITAKEINDATERF as A_EDITAKEINDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UOEREMARK1RF as A_UOEREMARK1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.UOEREMARK2RF as A_UOEREMARK2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPPRINTDIVCDRF as A_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPPRINTFINISHCDRF as A_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESSLIPPRINTDATERF as A_SALESSLIPPRINTDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.BUSINESSTYPECODERF as A_BUSINESSTYPECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.BUSINESSTYPENAMERF as A_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ORDERNUMBERRF as A_ORDERNUMBERRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DELIVEREDGOODSDIVRF as A_DELIVEREDGOODSDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.DELIVEREDGOODSDIVNMRF as A_DELIVEREDGOODSDIVNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESAREACODERF as A_SALESAREACODERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESAREANAMERF as A_SALESAREANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.RECONCILEFLAGRF as A_RECONCILEFLAGRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SLIPPRTSETPAPERIDRF as A_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.COMPLETECDRF as A_COMPLETECDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.SALESPRICEFRACPROCCDRF as A_SALESPRICEFRACPROCCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.STOCKGOODSTTLTAXEXCRF as A_STOCKGOODSTTLTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.PUREGOODSTTLTAXEXCRF as A_PUREGOODSTTLTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.LISTPRICEPRINTDIVRF as A_LISTPRICEPRINTDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ERANAMEDISPCD1RF as A_ERANAMEDISPCD1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATAXDIVCDRF as A_ESTIMATAXDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATEFORMPRTCDRF as A_ESTIMATEFORMPRTCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATESUBJECTRF as A_ESTIMATESUBJECTRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.FOOTNOTES1RF as A_FOOTNOTES1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.FOOTNOTES2RF as A_FOOTNOTES2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATETITLE1RF as A_ESTIMATETITLE1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATETITLE2RF as A_ESTIMATETITLE2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATETITLE3RF as A_ESTIMATETITLE3RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATETITLE4RF as A_ESTIMATETITLE4RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATETITLE5RF as A_ESTIMATETITLE5RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATENOTE1RF as A_ESTIMATENOTE1RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATENOTE2RF as A_ESTIMATENOTE2RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATENOTE3RF as A_ESTIMATENOTE3RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATENOTE4RF as A_ESTIMATENOTE4RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATENOTE5RF as A_ESTIMATENOTE5RF ").Append(Environment.NewLine);
            //sb.Append(" ,A.ESTIMATEVALIDITYDATERF as A_ESTIMATEVALIDITYDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,A.PARTSNOPRTCDRF as A_PARTSNOPRTCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.OPTIONPRINGDIVCDRF as A_OPTIONPRINGDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,A.RATEUSECODERF  as A_RATEUSECODERF  ").Append(Environment.NewLine);
            ////売上明細データ
            //sb.Append(" ,B.CREATEDATETIMERF as B_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UPDATEDATETIMERF as B_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ENTERPRISECODERF as B_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FILEHEADERGUIDRF as B_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UPDEMPLOYEECODERF as B_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UPDASSEMBLYID1RF as B_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UPDASSEMBLYID2RF as B_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.LOGICALDELETECODERF as B_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACCEPTANORDERNORF as B_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACPTANODRSTATUSRF as B_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESSLIPNUMRF as B_SALESSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESROWNORF as B_SALESROWNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESROWDERIVNORF as B_SALESROWDERIVNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SECTIONCODERF as B_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SUBSECTIONCODERF as B_SUBSECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESDATERF as B_SALESDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.COMMONSEQNORF as B_COMMONSEQNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESSLIPDTLNUMRF as B_SALESSLIPDTLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACPTANODRSTATUSSRCRF as B_ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESSLIPDTLNUMSRCRF as B_SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SUPPLIERFORMALSYNCRF as B_SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.STOCKSLIPDTLNUMSYNCRF as B_STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESSLIPCDDTLRF as B_SALESSLIPCDDTLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.DELIGDSCMPLTDUEDATERF as B_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSKINDCODERF as B_GOODSKINDCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSSEARCHDIVCDRF as B_GOODSSEARCHDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSMAKERCDRF as B_GOODSMAKERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.MAKERNAMERF as B_MAKERNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.MAKERKANANAMERF as B_MAKERKANANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSNORF as B_GOODSNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSNAMERF as B_GOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSNAMEKANARF as B_GOODSNAMEKANARF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSLGROUPRF as B_GOODSLGROUPRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSLGROUPNAMERF as B_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSMGROUPRF as B_GOODSMGROUPRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSMGROUPNAMERF as B_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BLGROUPCODERF as B_BLGROUPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BLGROUPNAMERF as B_BLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BLGOODSCODERF as B_BLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BLGOODSFULLNAMERF as B_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ENTERPRISEGANRECODERF as B_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ENTERPRISEGANRENAMERF as B_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.WAREHOUSECODERF as B_WAREHOUSECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.WAREHOUSENAMERF as B_WAREHOUSENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.WAREHOUSESHELFNORF as B_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESORDERDIVCDRF as B_SALESORDERDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.OPENPRICEDIVRF as B_OPENPRICEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSRATERANKRF as B_GOODSRATERANKRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CUSTRATEGRPCODERF as B_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.LISTPRICERATERF as B_LISTPRICERATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATESECTPRICEUNPRCRF as B_RATESECTPRICEUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEDIVLPRICERF as B_RATEDIVLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UNPRCCALCCDLPRICERF as B_UNPRCCALCCDLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRICECDLPRICERF as B_PRICECDLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.STDUNPRCLPRICERF as B_STDUNPRCLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FRACPROCUNITLPRICERF as B_FRACPROCUNITLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FRACPROCLPRICERF as B_FRACPROCLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.LISTPRICETAXINCFLRF as B_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.LISTPRICETAXEXCFLRF as B_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.LISTPRICECHNGCDRF as B_LISTPRICECHNGCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESRATERF as B_SALESRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATESECTSALUNPRCRF as B_RATESECTSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEDIVSALUNPRCRF as B_RATEDIVSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UNPRCCALCCDSALUNPRCRF as B_UNPRCCALCCDSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRICECDSALUNPRCRF as B_PRICECDSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.STDUNPRCSALUNPRCRF as B_STDUNPRCSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FRACPROCUNITSALUNPRCRF as B_FRACPROCUNITSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FRACPROCSALUNPRCRF as B_FRACPROCSALUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESUNPRCTAXINCFLRF as B_SALESUNPRCTAXINCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESUNPRCTAXEXCFLRF as B_SALESUNPRCTAXEXCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESUNPRCCHNGCDRF as B_SALESUNPRCCHNGCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.COSTRATERF as B_COSTRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATESECTCSTUNPRCRF as B_RATESECTCSTUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEDIVUNCSTRF as B_RATEDIVUNCSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.UNPRCCALCCDUNCSTRF as B_UNPRCCALCCDUNCSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRICECDUNCSTRF as B_PRICECDUNCSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.STDUNPRCUNCSTRF as B_STDUNPRCUNCSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FRACPROCUNITUNCSTRF as B_FRACPROCUNITUNCSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.FRACPROCUNCSTRF as B_FRACPROCUNCSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESUNITCOSTRF as B_SALESUNITCOSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESUNITCOSTCHNGDIVRF as B_SALESUNITCOSTCHNGDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEBLGOODSCODERF as B_RATEBLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEBLGOODSNAMERF as B_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEGOODSRATEGRPCDRF as B_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEGOODSRATEGRPNMRF as B_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEBLGROUPCODERF as B_RATEBLGROUPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RATEBLGROUPNAMERF as B_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRTBLGOODSCODERF as B_PRTBLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRTBLGOODSNAMERF as B_PRTBLGOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESCODERF as B_SALESCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESCDNMRF as B_SALESCDNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.WORKMANHOURRF as B_WORKMANHOURRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SHIPMENTCNTRF as B_SHIPMENTCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACCEPTANORDERCNTRF as B_ACCEPTANORDERCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACPTANODRADJUSTCNTRF as B_ACPTANODRADJUSTCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACPTANODRREMAINCNTRF as B_ACPTANODRREMAINCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.REMAINCNTUPDDATERF as B_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESMONEYTAXINCRF as B_SALESMONEYTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESMONEYTAXEXCRF as B_SALESMONEYTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.COSTRF as B_COSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GRSPROFITCHKDIVRF as B_GRSPROFITCHKDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESGOODSCDRF as B_SALESGOODSCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SALESPRICECONSTAXRF as B_SALESPRICECONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.TAXATIONDIVCDRF as B_TAXATIONDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PARTYSLIPNUMDTLRF as B_PARTYSLIPNUMDTLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.DTLNOTERF as B_DTLNOTERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SUPPLIERCDRF as B_SUPPLIERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SUPPLIERSNMRF as B_SUPPLIERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ORDERNUMBERRF as B_ORDERNUMBERRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.WAYTOORDERRF as B_WAYTOORDERRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SLIPMEMO1RF as B_SLIPMEMO1RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SLIPMEMO2RF as B_SLIPMEMO2RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.SLIPMEMO3RF as B_SLIPMEMO3RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.INSIDEMEMO1RF as B_INSIDEMEMO1RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.INSIDEMEMO2RF as B_INSIDEMEMO2RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.INSIDEMEMO3RF as B_INSIDEMEMO3RF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BFLISTPRICERF as B_BFLISTPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BFSALESUNITPRICERF as B_BFSALESUNITPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.BFUNITCOSTRF as B_BFUNITCOSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTSALESROWNORF as B_CMPLTSALESROWNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTGOODSMAKERCDRF as B_CMPLTGOODSMAKERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTMAKERNAMERF as B_CMPLTMAKERNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTMAKERKANANAMERF as B_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTGOODSNAMERF as B_CMPLTGOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTSHIPMENTCNTRF as B_CMPLTSHIPMENTCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTSALESUNPRCFLRF as B_CMPLTSALESUNPRCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTSALESMONEYRF as B_CMPLTSALESMONEYRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTSALESUNITCOSTRF as B_CMPLTSALESUNITCOSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTCOSTRF as B_CMPLTCOSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTPARTYSALSLNUMRF as B_CMPLTPARTYSALSLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CMPLTNOTERF as B_CMPLTNOTERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRTGOODSNORF as B_PRTGOODSNORF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRTMAKERCODERF as B_PRTMAKERCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.PRTMAKERNAMERF as B_PRTMAKERNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CAMPAIGNCODERF as B_CAMPAIGNCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.CAMPAIGNNAMERF as B_CAMPAIGNNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.GOODSDIVCDRF as B_GOODSDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ANSWERDELIVDATERF as B_ANSWERDELIVDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RECYCLEDIVRF as B_RECYCLEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.RECYCLEDIVNMRF as B_RECYCLEDIVNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.WAYTOACPTODRRF as B_WAYTOACPTODRRF ").Append(Environment.NewLine);
            //// ADD 2011/09/15 ---------- >>>>>
            //sb.Append(" ,B.AUTOANSWERDIVSCMRF as B_AUTOANSWERDIVSCMRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.ACCEPTORORDERKINDRF as B_ACCEPTORORDERKINDRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.INQUIRYNUMBERRF as B_INQUIRYNUMBERRF ").Append(Environment.NewLine);
            //sb.Append(" ,B.INQROWNUMBERRF as B_INQROWNUMBERRF ").Append(Environment.NewLine);
            //// ADD 2011/09/15 ---------- <<<<<
            ////受注マスタ
            //sb.Append(" ,C.CREATEDATETIMERF as C_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.UPDATEDATETIMERF as C_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.ENTERPRISECODERF as C_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.FILEHEADERGUIDRF as C_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,C.UPDEMPLOYEECODERF as C_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.UPDASSEMBLYID1RF as C_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,C.UPDASSEMBLYID2RF as C_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,C.LOGICALDELETECODERF as C_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.SECTIONCODERF as C_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.ACCEPTANORDERNORF as C_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C.ACPTANODRSTATUSRF as C_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //sb.Append(" ,C.SALESSLIPNUMRF as C_SALESSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C.DATAINPUTSYSTEMRF as C_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C.COMMONSEQNORF as C_COMMONSEQNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C.SLIPDTLNUMRF as C_SLIPDTLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C.SLIPDTLNUMDERIVNORF as C_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C.SRCLINKDATACODERF as C_SRCLINKDATACODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C.SRCSLIPDTLNUMRF as C_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);
            ////受注マスタ（車両）
            //sb.Append(" ,D.CREATEDATETIMERF as D_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.UPDATEDATETIMERF as D_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.ENTERPRISECODERF as D_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FILEHEADERGUIDRF as D_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.UPDEMPLOYEECODERF as D_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.UPDASSEMBLYID1RF as D_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,D.UPDASSEMBLYID2RF as D_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,D.LOGICALDELETECODERF as D_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.ACCEPTANORDERNORF as D_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,D.ACPTANODRSTATUSRF as D_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.DATAINPUTSYSTEMRF as D_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.CARMNGNORF as D_CARMNGNORF ").Append(Environment.NewLine);
            //sb.Append(" ,D.CARMNGCODERF as D_CARMNGCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.NUMBERPLATE1CODERF as D_NUMBERPLATE1CODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.NUMBERPLATE1NAMERF as D_NUMBERPLATE1NAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.NUMBERPLATE2RF as D_NUMBERPLATE2RF ").Append(Environment.NewLine);
            //sb.Append(" ,D.NUMBERPLATE3RF as D_NUMBERPLATE3RF ").Append(Environment.NewLine);
            //sb.Append(" ,D.NUMBERPLATE4RF as D_NUMBERPLATE4RF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FIRSTENTRYDATERF as D_FIRSTENTRYDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MAKERCODERF as D_MAKERCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MAKERFULLNAMERF as D_MAKERFULLNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MAKERHALFNAMERF as D_MAKERHALFNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MODELCODERF as D_MODELCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MODELSUBCODERF as D_MODELSUBCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MODELFULLNAMERF as D_MODELFULLNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MODELHALFNAMERF as D_MODELHALFNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.EXHAUSTGASSIGNRF as D_EXHAUSTGASSIGNRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.SERIESMODELRF as D_SERIESMODELRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.CATEGORYSIGNMODELRF as D_CATEGORYSIGNMODELRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FULLMODELRF as D_FULLMODELRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MODELDESIGNATIONNORF as D_MODELDESIGNATIONNORF ").Append(Environment.NewLine);
            //sb.Append(" ,D.CATEGORYNORF as D_CATEGORYNORF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FRAMEMODELRF as D_FRAMEMODELRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FRAMENORF as D_FRAMENORF ").Append(Environment.NewLine);
            //sb.Append(" ,D.SEARCHFRAMENORF as D_SEARCHFRAMENORF ").Append(Environment.NewLine);
            //sb.Append(" ,D.ENGINEMODELNMRF as D_ENGINEMODELNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.RELEVANCEMODELRF as D_RELEVANCEMODELRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.SUBCARNMCDRF as D_SUBCARNMCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MODELGRADESNAMERF as D_MODELGRADESNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.COLORCODERF as D_COLORCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.COLORNAME1RF as D_COLORNAME1RF ").Append(Environment.NewLine);
            //sb.Append(" ,D.TRIMCODERF as D_TRIMCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.TRIMNAMERF as D_TRIMNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.MILEAGERF as D_MILEAGERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FULLMODELFIXEDNOARYRF as D_FULLMODELFIXEDNOARYRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.CATEGORYOBJARYRF as D_CATEGORYOBJARYRF ").Append(Environment.NewLine);
            //sb.Append(" ,D.CARNOTERF as D_CARNOTERF ").Append(Environment.NewLine);
            //sb.Append(" ,D.FREESRCHMDLFXDNOARYRF as D_FREESRCHMDLFXDNOARYRF ").Append(Environment.NewLine);
            //sb.Append(" FROM  SALESSLIPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            ////売上明細データ
            //sb.Append(" INNER JOIN SALESDETAILRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            ////	売上データ.企業コード　＝　売上明細データ.企業コード
            //sb.Append(" ON A.ENTERPRISECODERF = B.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	売上データ.受注ステータス　＝　売上明細データ.受注ステータス
            //sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            ////	売上データ.売上伝票番号　＝　売上明細データ.売上伝票番号
            //sb.Append(" AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF ").Append(Environment.NewLine);
            //
            ////受注マスタ
            //sb.Append(" INNER JOIN ACCEPTODRRF C WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            ////	売上明細データ.企業コード　＝　受注マスタ.企業コード
            //sb.Append(" ON B.ENTERPRISECODERF = C.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	売上明細データ.受注ステータス　＝　受注マスタ.受注ステータス
            //sb.Append(" AND ((B.ACPTANODRSTATUSRF = 10 AND C.ACPTANODRSTATUSRF =1)  ").Append(Environment.NewLine);
            //sb.Append(" OR (B.ACPTANODRSTATUSRF = 20 AND C.ACPTANODRSTATUSRF =3)  ").Append(Environment.NewLine);
            //sb.Append(" OR (B.ACPTANODRSTATUSRF = 30 AND C.ACPTANODRSTATUSRF =7)  ").Append(Environment.NewLine);
            //sb.Append(" OR (B.ACPTANODRSTATUSRF = 40 AND C.ACPTANODRSTATUSRF =5)) ").Append(Environment.NewLine);
            ////	売上明細データ.売上伝票番号　＝　受注マスタ.伝票番号
            //sb.Append(" AND B.SALESSLIPNUMRF = C.SALESSLIPNUMRF ").Append(Environment.NewLine);
            //
            ////受注マスタ（車両）
            //sb.Append(" LEFT JOIN ACCEPTODRCARRF D WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            ////	受注マスタ.企業コード　＝　受注マスタ（車両）.企業コード（＋）
            //sb.Append(" ON C.ENTERPRISECODERF = D.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	受注マスタ.受注ステータス　＝　受注マスタ（車両）.受注ステータス（＋）
            //sb.Append(" AND C.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            ////	受注マスタ.受注番号　＝　受注マスタ（車両）.受注番号（＋）
            //sb.Append(" AND C.ACCEPTANORDERNORF = D.ACCEPTANORDERNORF ").Append(Environment.NewLine);
            sb.Append(" SELECT A.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" ,A.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" ,A.SALESSLIPNUMRF ").Append(Environment.NewLine);
            sb.Append(" FROM  SALESSLIPRF AS A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            // ----- UPD 2012/02/27 西 毅 ----------<<<<<

            //仮売上データ
			sb.Append(" INNER JOIN (  ").Append(Environment.NewLine);
			sb.Append("    SELECT DISTINCT SALESRF.ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append("    ,SALESRF.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append("    ,SALESRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
            // ----- UPD 2012/02/14 西 毅 ---------->>>>>
            //sb.Append("    FROM SALESSLIPRF SALESRF ").Append(Environment.NewLine);
            //sb.Append("    INNER JOIN SALESDETAILRF SALEDTLRF ").Append(Environment.NewLine);
            sb.Append("    FROM SALESSLIPRF SALESRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            sb.Append("    INNER JOIN SALESDETAILRF SALEDTLRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            // ----- UPD 2012/02/14 西 毅 ----------<<<<<
            //	売上データ.企業コード　＝　売上明細データ.企業コード
			sb.Append("    ON SALESRF.ENTERPRISECODERF = SALEDTLRF.ENTERPRISECODERF  ").Append(Environment.NewLine);
			//	売上データ.受注ステータス　＝　売上明細データ.受注ステータス
			sb.Append("    AND SALESRF.ACPTANODRSTATUSRF = SALEDTLRF.ACPTANODRSTATUSRF  ").Append(Environment.NewLine);
			//	売上データ.売上伝票番号　＝　売上明細データ.売上伝票番号			
			sb.Append("    AND SALESRF.SALESSLIPNUMRF = SALEDTLRF.SALESSLIPNUMRF ").Append(Environment.NewLine);
			//	売上データ.実績計上拠点コード　＝　パラメータ.拠点コード
			sb.Append("    WHERE SALESRF.RESULTSADDUPSECCDRF=@FINDSECTIONCODE_SALESRF ").Append(Environment.NewLine);

			//	売上データ.企業コード　＝　パラメータ.企業コード
			sb.Append("    AND SALESRF.ENTERPRISECODERF=@FINDENTERPRISECODERF_SALESRF ").Append(Environment.NewLine);// ADD 2011/08/18 張莉莉　Redmine#23746
            //-----Add 2011/11/01 陳建明 for #26228 start----->>>>> 
            if (receiveDataWork.Kind==0&&receiveDataWork.SndLogExtraCondDiv==1)
            {
                // ----- DEL 2011/11/11 xupz---------->>>>>
                ////	売上明細データ.売上日付　≧　パラメータ.開始日付
                //sb.Append("    AND SALEDTLRF.SALESDATERF>=@FINDUPDATESTARTDATETIME_SALESRF ").Append(Environment.NewLine);
                ////	売上明細データ.売上日付　≦　パラメータ.終了日付
                //sb.Append("    AND SALEDTLRF.SALESDATERF<=@FINDUPDATEENDDATETIME_ASALESRF ").Append(Environment.NewLine);
                // ----- DEL 2011/11/11 xupz----------<<<<<
                // ----- ADD 2011/11/11 xupz---------->>>>>
                //	売上明細データ.売上日付(受注ステータスが40、売上明細データ.売上日付が抽出条件としないで、売上データ.入荷日付です)
                //sb.Append("    AND(((SALEDTLRF.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine); // DEL 2011/11/30
                sb.Append("    AND (((((SALEDTLRF.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);   // ADD 2011/11/30
                sb.Append("    AND (SALESRF.SHIPMENTDAYRF>=@FINDUPDATESTARTDATETIME_SALESRF) ").Append(Environment.NewLine);
                sb.Append("    AND (SALESRF.SHIPMENTDAYRF<=@FINDUPDATEENDDATETIME_ASALESRF)) ").Append(Environment.NewLine);
                sb.Append("    OR ((SALEDTLRF.ACPTANODRSTATUSRF<>40) ").Append(Environment.NewLine);
                sb.Append("    AND (SALEDTLRF.SALESDATERF>=@FINDUPDATESTARTDATETIME_SALESRF) ").Append(Environment.NewLine);
                sb.Append("    AND (SALEDTLRF.SALESDATERF<=@FINDUPDATEENDDATETIME_ASALESRF)))").Append(Environment.NewLine);
                // ----- ADD 2011/11/11 xupz----------<<<<<

                // ----- ADD 2011/11/30 tanh---------->>>>>
                sb.Append(" ) ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sb.Append(" OR ((SALEDTLRF.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                sb.Append(" OR ((SALEDTLRF.UPDATEDATETIMERF>@FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
                sb.Append("     AND (SALEDTLRF.UPDATEDATETIMERF <= @FINDENDTIMERF) ").Append(Environment.NewLine);
                sb.Append("     AND (((SALEDTLRF.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);
                sb.Append("         AND (SALESRF.SHIPMENTDAYRF<=@FINDUPDATEENDDATETIME_ASALESRF)) ").Append(Environment.NewLine);
                sb.Append("         OR ((SALEDTLRF.ACPTANODRSTATUSRF <> 40) ").Append(Environment.NewLine);
                sb.Append("            AND (SALEDTLRF.SALESDATERF<=@FINDUPDATEENDDATETIME_ASALESRF))))) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<
            }
		    else
            {
            //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<    
                //    売上明細データ.更新日時　>　パラメータ.開始日付
                sb.Append("    AND SALEDTLRF.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_SALESRF ").Append(Environment.NewLine);
                //    売上明細データ.更新日時　≦　パラメータ.終了日付
                sb.Append("    AND SALEDTLRF.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_ASALESRF ").Append(Environment.NewLine);
            }//Add 2011/11/01 陳建明 for #26228 
		    sb.Append(" )AS AA").Append(Environment.NewLine);

			//	売上データ.企業コード　＝　仮売上データ.企業コード
			sb.Append(" ON A.ENTERPRISECODERF = AA.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	売上データ.受注ステータス　＝　仮売上明細データ.受注ステータス
			sb.Append(" AND A.ACPTANODRSTATUSRF =  AA.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//	売上データ.売上伝票番号　＝　仮売上明細データ.売上伝票番号
			sb.Append(" AND A.SALESSLIPNUMRF = AA.SALESSLIPNUMRF ").Append(Environment.NewLine);

            // ----- ADD 2012/02/27 西 毅 ---------->>>>>
            sb.Append(" )AS MAIN ").Append(Environment.NewLine);
            sb.Append(" INNER JOIN SALESSLIPRF A WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            sb.Append(" ON MAIN.ENTERPRISECODERF = A.ENTERPRISECODERF ").Append(Environment.NewLine);
            sb.Append(" AND MAIN.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            sb.Append(" AND MAIN.SALESSLIPNUMRF = A.SALESSLIPNUMRF ").Append(Environment.NewLine);

            sb.Append(" INNER JOIN SALESDETAILRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            //	売上データ.企業コード　＝　売上明細データ.企業コード
            sb.Append(" ON A.ENTERPRISECODERF = B.ENTERPRISECODERF ").Append(Environment.NewLine);
            //	売上データ.受注ステータス　＝　売上明細データ.受注ステータス
            sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //	売上データ.売上伝票番号　＝　売上明細データ.売上伝票番号
            sb.Append(" AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF ").Append(Environment.NewLine);

            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            // 貸出データ受信区分＝なしの場合、下記条件を追加する。
            if (receiveDataWork.ShipmentRecvDiv == 0)
            {
                // 売上データ.受注ステータス　≠　40:貸出
                sb.Append(" AND A.ACPTANODRSTATUSRF <> 40 ").Append(Environment.NewLine);
            }
            // 受注データ受信区分＝なしの場合、下記条件を追加する。
            if (receiveDataWork.AcptAnOdrRecvDiv == 0)
            {
                // 売上データ.受注ステータス　≠　20:受注
                sb.Append(" AND A.ACPTANODRSTATUSRF <> 20 ").Append(Environment.NewLine);
            }
            // 見積データ受信区分＝なしの場合、下記条件を追加する。
            if (receiveDataWork.EstimateRecvDiv == 0)
            {
                // 売上データ.受注ステータス　≠　10:見積
                sb.Append(" AND A.ACPTANODRSTATUSRF <> 10 ").Append(Environment.NewLine);
            }
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

            //受注マスタ
            sb.Append(" INNER JOIN ACCEPTODRRF C WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            //	売上明細データ.企業コード　＝　受注マスタ.企業コード
            sb.Append(" ON B.ENTERPRISECODERF = C.ENTERPRISECODERF ").Append(Environment.NewLine);
            //	売上明細データ.受注ステータス　＝　受注マスタ.受注ステータス
            sb.Append(" AND ((B.ACPTANODRSTATUSRF = 10 AND C.ACPTANODRSTATUSRF =1)  ").Append(Environment.NewLine);
            sb.Append(" OR (B.ACPTANODRSTATUSRF = 20 AND C.ACPTANODRSTATUSRF =3)  ").Append(Environment.NewLine);
            sb.Append(" OR (B.ACPTANODRSTATUSRF = 30 AND C.ACPTANODRSTATUSRF =7)  ").Append(Environment.NewLine);
            sb.Append(" OR (B.ACPTANODRSTATUSRF = 40 AND C.ACPTANODRSTATUSRF =5)) ").Append(Environment.NewLine);
            //	売上明細データ.売上伝票番号　＝　受注マスタ.伝票番号
            sb.Append(" AND B.SALESSLIPNUMRF = C.SALESSLIPNUMRF ").Append(Environment.NewLine);
            
            //受注マスタ（車両）
            sb.Append(" LEFT JOIN ACCEPTODRCARRF D WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            //	受注マスタ.企業コード　＝　受注マスタ（車両）.企業コード（＋）
            sb.Append(" ON C.ENTERPRISECODERF = D.ENTERPRISECODERF ").Append(Environment.NewLine);
            //	受注マスタ.受注ステータス　＝　受注マスタ（車両）.受注ステータス（＋）
            sb.Append(" AND C.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //	受注マスタ.受注番号　＝　受注マスタ（車両）.受注番号（＋）
            sb.Append(" AND C.ACCEPTANORDERNORF = D.ACCEPTANORDERNORF ").Append(Environment.NewLine);
            // ----- ADD 2012/02/27 西 毅 ----------<<<<<

            sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" A_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,A_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,A_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,B_ACPTANODRSTATUSRF  ").Append(Environment.NewLine);
			sb.Append(" ,B_SALESSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,D_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,D_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,D_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);

			sqlText = sb.ToString();
			// ADD 2011.08.29 ---------<<<<<


			//Prameterオブジェクトの作成
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_A = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_A", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_A = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_A", SqlDbType.BigInt);
			// ADD 2011.08.29 --------->>>>>
			SqlParameter findParaSectionCode_sale = sqlCommand.Parameters.Add("@FINDSECTIONCODE_SALESRF", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_sale = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_SALESRF", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_sale = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_ASALESRF", SqlDbType.BigInt);
			// ADD 2011.08.29 ---------<<<<<
			// DEL 2011.08.29 ------->>>>>
			//SqlParameter findParaUpdateStartDateTime_B = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_B", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_B = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_B", SqlDbType.BigInt);
			//SqlParameter findParaUpdateStartDateTime_C = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_C", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_C = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_C", SqlDbType.BigInt);
			//SqlParameter findParaUpdateStartDateTime_D = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_D", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_D = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_D", SqlDbType.BigInt);
			// DEL 2011.08.29 -------<<<<<
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);// ADD 2011/08/18 張莉莉　Redmine#23746
			SqlParameter findParaEnterpriseCode_sale = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF_SALESRF", SqlDbType.NChar);// ADD 2011/08/18 張莉莉　Redmine#23746
			

			//Parameterオブジェクトへ値設定
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_A.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_A.Value = receiveDataWork.EndDateTime;
			// ADD 2011.08.29 --------->>>>>
			findParaSectionCode_sale.Value = receiveDataWork.PmSectionCode;
			findParaUpdateStartDateTime_sale.Value = receiveDataWork.StartDateTime;
			findParaUpdateEndDateTime_sale.Value = receiveDataWork.EndDateTime;
			// ADD 2011.08.29 ---------<<<<<
			// DEL 2011.08.29 ------->>>>>
			//findParaUpdateStartDateTime_B.Value = receiveDataWork.StartDateTime;
			//findParaUpdateEndDateTime_B.Value = receiveDataWork.EndDateTime;
			//findParaUpdateStartDateTime_C.Value = receiveDataWork.StartDateTime;
			//findParaUpdateEndDateTime_C.Value = receiveDataWork.EndDateTime;
			//findParaUpdateStartDateTime_D.Value = receiveDataWork.StartDateTime;
			//findParaUpdateEndDateTime_D.Value = receiveDataWork.EndDateTime;
			// DEL 2011.08.29 -------<<<<<
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 張莉莉　Redmine#23746
			findParaEnterpriseCode_sale.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 張莉莉　Redmine#23746

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
            // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //sqlCommand.CommandTimeout = 600;
            sqlCommand.CommandTimeout = 3600;
            // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
            //  ADD dingjx  2011/10/08  ----------------<<<<<<
			myReader = sqlCommand.ExecuteReader();

			ArrayList salesSlipList = new ArrayList();
			ArrayList salesDetailList = new ArrayList();
			ArrayList acceptodrList = new ArrayList();
			ArrayList acceptodrCarList = new ArrayList();
			DCSalesDetailDB dCSalesDetailDB = new DCSalesDetailDB();
			DCAcceptOdrDB dCAcceptOdrDB = new DCAcceptOdrDB();
			DCAcceptOdrCarDB dCAcceptOdrCarDB = new DCAcceptOdrCarDB();
			DCSalesSlipWork tmpWorkA = new DCSalesSlipWork();
			DCSalesDetailWork tmpWorkB = new DCSalesDetailWork();
			DCAcceptOdrWork tmpWorkC = new DCAcceptOdrWork();
			DCAcceptOdrCarWork tmpWorkD = new DCAcceptOdrCarWork();

			Dictionary<string, string> salesDic = new Dictionary<string, string>();
			Dictionary<string, string> salesDtlDic = new Dictionary<string, string>();
			Dictionary<string, string> accOdrDic = new Dictionary<string, string>();
			Dictionary<string, string> accOdrCarDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				// 売上
				tmpWorkA = this.CopyToSalesSlipWorkFromReaderSCM(ref myReader, "A_");
				string workA_key = tmpWorkA.EnterpriseCode + tmpWorkA.AcptAnOdrStatus.ToString() + tmpWorkA.SalesSlipNum;
				if (!string.Empty.Equals(tmpWorkA.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkA.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkA.SalesSlipNum)
					&& !salesDic.ContainsKey(workA_key))
				{
					salesDic.Add(workA_key, workA_key);
					salesSlipList.Add(tmpWorkA);
				}

				// 売上明細
				tmpWorkB = dCSalesDetailDB.CopyToSalesDetailWorkFromReaderSCM(ref myReader, "B_");
				string workB_key = tmpWorkB.EnterpriseCode + tmpWorkB.AcptAnOdrStatus.ToString() + tmpWorkB.SalesSlipDtlNum.ToString();
				if (!string.Empty.Equals(tmpWorkB.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkB.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkB.SalesSlipDtlNum.ToString())
					&& !salesDtlDic.ContainsKey(workB_key))
				{
					salesDtlDic.Add(workB_key, workB_key);
					salesDetailList.Add(tmpWorkB);
				}

				// 受注マスタ
				tmpWorkC = dCAcceptOdrDB.CopyToAcceptOdrWorkFromReaderSCM(ref myReader, "C_");
				string workC_key = tmpWorkC.EnterpriseCode + tmpWorkC.SectionCode.Trim() + tmpWorkC.AcptAnOdrStatus.ToString()
								   + tmpWorkC.DataInputSystem.ToString() + tmpWorkC.CommonSeqNo.ToString() + tmpWorkC.SlipDtlNum.ToString()
								   + tmpWorkC.SlipDtlNumDerivNo.ToString();
				if (!string.Empty.Equals(tmpWorkC.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkC.SectionCode.Trim())
					&& !string.Empty.Equals(tmpWorkC.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkC.DataInputSystem.ToString())
					&& !string.Empty.Equals(tmpWorkC.CommonSeqNo.ToString())
					&& !string.Empty.Equals(tmpWorkC.SlipDtlNum.ToString())
					&& !string.Empty.Equals(tmpWorkC.SlipDtlNumDerivNo.ToString())
					&& !accOdrDic.ContainsKey(workC_key))
				{
					accOdrDic.Add(workC_key, workC_key);
					acceptodrList.Add(tmpWorkC);
				}
				// 受注マスタ（車両）
				tmpWorkD = dCAcceptOdrCarDB.CopyToAcceptOdrCarWorkFromReaderSCM(ref myReader, "D_");
				string workD_key = tmpWorkD.EnterpriseCode + tmpWorkD.AcceptAnOrderNo.ToString()
								   + tmpWorkD.AcptAnOdrStatus.ToString() + tmpWorkD.DataInputSystem.ToString();
				if (!string.Empty.Equals(tmpWorkD.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkD.AcceptAnOrderNo.ToString())
					&& !string.Empty.Equals(tmpWorkD.AcptAnOdrStatus.ToString())
					&& !string.Empty.Equals(tmpWorkD.DataInputSystem.ToString())
					&& !accOdrCarDic.ContainsKey(workD_key))
				{
					accOdrCarDic.Add(workD_key, workD_key);
					acceptodrCarList.Add(tmpWorkD);
				}
			}
			// 売上要否フラグ
			if (receiveDataWork.DoSalesSlipFlg)
			{
				resultList.Add(salesSlipList);
			}
			// 売上明細要否フラグ
			if (receiveDataWork.DoSalesSlipFlg)
			{
				resultList.Add(salesDetailList);
			}
			// 受注マスタ要否フラグ
			if (receiveDataWork.DoAcceptOdrFlg)
			{
				acpOdrList = acceptodrList;
			}
			// 受注マスタ（車両）要否フラグ
			if (receiveDataWork.DoAcceptOdrCarFlg)
			{
				resultList.Add(acceptodrCarList);
			}

			if (salesSlipList.Count > 0)
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
		#endregion
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

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
            //sqlCommand.CommandText = "DELETE FROM SALESSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";                                                                                                     //DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM SALESSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND RESULTSADDUPSECCDRF = @FINDSECTIONCODERF";//ADD by Liangsd    2011/09/06
            
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

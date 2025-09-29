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
// 修 正 日  2011/09/08  修正内容 : #24609仕入データの赤伝を削除した際のデータ送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 修 正 日  2011/10/08  修正内容 : #25780 データ送信処理　売上履歴データ送信時のタイムアウト設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/17  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine#8293 拠点管理／伝票日付日付抽出改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/06  修正内容 : Redmine#8293 画面の終了日付＋システム時刻仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 脇田 靖之
// 修 正 日  2014/02/20  修正内容 : 仕掛一覧№2292対応
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
    /// 仕入履歴データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APStockSlipHistDB : RemoteDB
    {
        /// <summary>
        /// 仕入履歴データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APStockSlipHistDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入履歴データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockSlipHistArrList">仕入履歴データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入履歴データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchStockSlipHist(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockSlipHistArrList, out string retMessage)
        {
            return SearchStockSlipHistProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockSlipHistArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockSlipHistArrList">仕入履歴データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入履歴データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchStockSlipHistProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockSlipHistArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockSlipHistArrList = new ArrayList();
            APStockSlipHistWork stockSlipHistWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSUPPSLIPNORF, SUPPLIERSLIPCDRF, STOCKGOODSCDRF, ACCPAYDIVCDRF, STOCKSECTIONCDRF, STOCKADDUPSECTIONCDRF, STOCKSLIPUPDATECDRF, INPUTDAYRF, ARRIVALGOODSDAYRF, STOCKDATERF, STOCKADDUPADATERF, DELAYPAYMENTDIVRF, PAYEECODERF, PAYEESNMRF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, SALESAREACODERF, SALESAREANAMERF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, SUPPTTLAMNTDSPWAYCDRF, TTLAMNTDISPRATEAPYRF, STOCKTOTALPRICERF, STOCKSUBTTLPRICERF, STOCKTTLPRICTAXINCRF, STOCKTTLPRICTAXEXCRF, STOCKNETPRICERF, STOCKPRICECONSTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, STOCKOUTTAXRF, STCKPRCCONSTAXINCLURF, STCKDISTTLTAXEXCRF, ITDEDSTOCKDISOUTTAXRF, ITDEDSTOCKDISINTAXRF, ITDEDSTOCKDISTAXFRERF, STOCKDISOUTTAXRF, STCKDISTTLTAXINCLURF, TAXADJUSTRF, BALANCEADJUSTRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, ACCPAYCONSTAXRF, STOCKFRACTIONPROCCDRF, AUTOPAYMENTRF, AUTOPAYSLIPNUMRF, RETGOODSREASONDIVRF, RETGOODSREASONRF, PARTYSALESLIPNUMRF, SUPPLIERSLIPNOTE1RF, SUPPLIERSLIPNOTE2RF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, STOCKSLIPPRINTDATERF, SLIPPRTSETPAPERIDRF FROM STOCKSLIPHISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 仕入履歴データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockSlipHistWork = new APStockSlipHistWork();

                    stockSlipHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockSlipHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockSlipHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockSlipHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockSlipHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockSlipHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockSlipHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockSlipHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockSlipHistWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    stockSlipHistWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    stockSlipHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockSlipHistWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    stockSlipHistWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    stockSlipHistWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
                    stockSlipHistWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                    stockSlipHistWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                    stockSlipHistWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
                    stockSlipHistWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    stockSlipHistWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
                    stockSlipHistWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
                    stockSlipHistWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockSlipHistWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    stockSlipHistWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    stockSlipHistWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    stockSlipHistWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                    stockSlipHistWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    stockSlipHistWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    stockSlipHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockSlipHistWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    stockSlipHistWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    stockSlipHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockSlipHistWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    stockSlipHistWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                    stockSlipHistWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    stockSlipHistWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                    stockSlipHistWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockSlipHistWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockSlipHistWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    stockSlipHistWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    stockSlipHistWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                    stockSlipHistWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                    stockSlipHistWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    stockSlipHistWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                    stockSlipHistWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                    stockSlipHistWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                    stockSlipHistWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
                    stockSlipHistWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    stockSlipHistWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                    stockSlipHistWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                    stockSlipHistWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                    stockSlipHistWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
                    stockSlipHistWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                    stockSlipHistWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
                    stockSlipHistWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
                    stockSlipHistWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
                    stockSlipHistWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
                    stockSlipHistWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
                    stockSlipHistWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                    stockSlipHistWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
                    stockSlipHistWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
                    stockSlipHistWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    stockSlipHistWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
                    stockSlipHistWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
                    stockSlipHistWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
                    stockSlipHistWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    stockSlipHistWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
                    stockSlipHistWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                    stockSlipHistWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    stockSlipHistWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    stockSlipHistWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                    stockSlipHistWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                    stockSlipHistWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    stockSlipHistWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    stockSlipHistWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    stockSlipHistWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    stockSlipHistWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    stockSlipHistWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                    stockSlipHistWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    stockSlipHistWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
                    stockSlipHistWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));



                    stockSlipHistArrList.Add(stockSlipHistWork);
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
        /// 仕入履歴データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipHistList">仕入履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockSlipHist(string enterPriseCode, ArrayList stockSlipHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockSlipHistProc(enterPriseCode, stockSlipHistList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipHistList">仕入履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockSlipHistProc(string enterPriseCode, ArrayList stockSlipHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockSlipHist(enterPriseCode, stockSlipHistList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockSlipHist(enterPriseCode, stockSlipHistList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入履歴データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipHistList">仕入履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockSlipHist(string enterPriseCode, ArrayList stockSlipHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockSlipHistProc(enterPriseCode, stockSlipHistList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipHistList">仕入履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockSlipHistProc(string enterPriseCode, ArrayList stockSlipHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockSlipHistWork stockSlipHistWork in stockSlipHistList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKSLIPHISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaSupplierFormal.Value = stockSlipHistWork.SupplierFormal;
                findParaSupplierSlipNo.Value = stockSlipHistWork.SupplierSlipNo;

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
        /// 仕入履歴データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipHistList">仕入履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockSlipHist(string enterPriseCode, ArrayList stockSlipHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockSlipHistProc(enterPriseCode, stockSlipHistList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入履歴データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipHistList">仕入履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockSlipHistProc(string enterPriseCode, ArrayList stockSlipHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockSlipHistWork stockSlipHistWork in stockSlipHistList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKSLIPHISTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSUPPSLIPNORF, SUPPLIERSLIPCDRF, STOCKGOODSCDRF, ACCPAYDIVCDRF, STOCKSECTIONCDRF, STOCKADDUPSECTIONCDRF, STOCKSLIPUPDATECDRF, INPUTDAYRF, ARRIVALGOODSDAYRF, STOCKDATERF, STOCKADDUPADATERF, DELAYPAYMENTDIVRF, PAYEECODERF, PAYEESNMRF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, SALESAREACODERF, SALESAREANAMERF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, SUPPTTLAMNTDSPWAYCDRF, TTLAMNTDISPRATEAPYRF, STOCKTOTALPRICERF, STOCKSUBTTLPRICERF, STOCKTTLPRICTAXINCRF, STOCKTTLPRICTAXEXCRF, STOCKNETPRICERF, STOCKPRICECONSTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, STOCKOUTTAXRF, STCKPRCCONSTAXINCLURF, STCKDISTTLTAXEXCRF, ITDEDSTOCKDISOUTTAXRF, ITDEDSTOCKDISINTAXRF, ITDEDSTOCKDISTAXFRERF, STOCKDISOUTTAXRF, STCKDISTTLTAXINCLURF, TAXADJUSTRF, BALANCEADJUSTRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, ACCPAYCONSTAXRF, STOCKFRACTIONPROCCDRF, AUTOPAYMENTRF, AUTOPAYSLIPNUMRF, RETGOODSREASONDIVRF, RETGOODSREASONRF, PARTYSALESLIPNUMRF, SUPPLIERSLIPNOTE1RF, SUPPLIERSLIPNOTE2RF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, STOCKSLIPPRINTDATERF, SLIPPRTSETPAPERIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @SECTIONCODE, @SUBSECTIONCODE, @DEBITNOTEDIV, @DEBITNLNKSUPPSLIPNO, @SUPPLIERSLIPCD, @STOCKGOODSCD, @ACCPAYDIVCD, @STOCKSECTIONCD, @STOCKADDUPSECTIONCD, @STOCKSLIPUPDATECD, @INPUTDAY, @ARRIVALGOODSDAY, @STOCKDATE, @STOCKADDUPADATE, @DELAYPAYMENTDIV, @PAYEECODE, @PAYEESNM, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @BUSINESSTYPECODE, @BUSINESSTYPENAME, @SALESAREACODE, @SALESAREANAME, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @SUPPTTLAMNTDSPWAYCD, @TTLAMNTDISPRATEAPY, @STOCKTOTALPRICE, @STOCKSUBTTLPRICE, @STOCKTTLPRICTAXINC, @STOCKTTLPRICTAXEXC, @STOCKNETPRICE, @STOCKPRICECONSTAX, @TTLITDEDSTCOUTTAX, @TTLITDEDSTCINTAX, @TTLITDEDSTCTAXFREE, @STOCKOUTTAX, @STCKPRCCONSTAXINCLU, @STCKDISTTLTAXEXC, @ITDEDSTOCKDISOUTTAX, @ITDEDSTOCKDISINTAX, @ITDEDSTOCKDISTAXFRE, @STOCKDISOUTTAX, @STCKDISTTLTAXINCLU, @TAXADJUST, @BALANCEADJUST, @SUPPCTAXLAYCD, @SUPPLIERCONSTAXRATE, @ACCPAYCONSTAX, @STOCKFRACTIONPROCCD, @AUTOPAYMENT, @AUTOPAYSLIPNUM, @RETGOODSREASONDIV, @RETGOODSREASON, @PARTYSALESLIPNUM, @SUPPLIERSLIPNOTE1, @SUPPLIERSLIPNOTE2, @DETAILROWCOUNT, @EDISENDDATE, @EDITAKEINDATE, @UOEREMARK1, @UOEREMARK2, @SLIPPRINTDIVCD, @SLIPPRINTFINISHCD, @STOCKSLIPPRINTDATE, @SLIPPRTSETPAPERID)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                SqlParameter paraDebitNLnkSuppSlipNo = sqlCommand.Parameters.Add("@DEBITNLNKSUPPSLIPNO", SqlDbType.Int);
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@SUPPLIERSLIPCD", SqlDbType.Int);
                SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                SqlParameter paraAccPayDivCd = sqlCommand.Parameters.Add("@ACCPAYDIVCD", SqlDbType.Int);
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockAddUpSectionCd = sqlCommand.Parameters.Add("@STOCKADDUPSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockSlipUpdateCd = sqlCommand.Parameters.Add("@STOCKSLIPUPDATECD", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraArrivalGoodsDay = sqlCommand.Parameters.Add("@ARRIVALGOODSDAY", SqlDbType.Int);
                SqlParameter paraStockDate = sqlCommand.Parameters.Add("@STOCKDATE", SqlDbType.Int);
                SqlParameter paraStockAddUpADate = sqlCommand.Parameters.Add("@STOCKADDUPADATE", SqlDbType.Int);
                SqlParameter paraDelayPaymentDiv = sqlCommand.Parameters.Add("@DELAYPAYMENTDIV", SqlDbType.Int);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                SqlParameter paraPayeeSnm = sqlCommand.Parameters.Add("@PAYEESNM", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                SqlParameter paraBusinessTypeName = sqlCommand.Parameters.Add("@BUSINESSTYPENAME", SqlDbType.NVarChar);
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                SqlParameter paraSalesAreaName = sqlCommand.Parameters.Add("@SALESAREANAME", SqlDbType.NVarChar);
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);
                SqlParameter paraTtlAmntDispRateApy = sqlCommand.Parameters.Add("@TTLAMNTDISPRATEAPY", SqlDbType.Int);
                SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                SqlParameter paraStockTtlPricTaxInc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXINC", SqlDbType.BigInt);
                SqlParameter paraStockTtlPricTaxExc = sqlCommand.Parameters.Add("@STOCKTTLPRICTAXEXC", SqlDbType.BigInt);
                SqlParameter paraStockNetPrice = sqlCommand.Parameters.Add("@STOCKNETPRICE", SqlDbType.BigInt);
                SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                SqlParameter paraTtlItdedStcOutTax = sqlCommand.Parameters.Add("@TTLITDEDSTCOUTTAX", SqlDbType.BigInt);
                SqlParameter paraTtlItdedStcInTax = sqlCommand.Parameters.Add("@TTLITDEDSTCINTAX", SqlDbType.BigInt);
                SqlParameter paraTtlItdedStcTaxFree = sqlCommand.Parameters.Add("@TTLITDEDSTCTAXFREE", SqlDbType.BigInt);
                SqlParameter paraStockOutTax = sqlCommand.Parameters.Add("@STOCKOUTTAX", SqlDbType.BigInt);
                SqlParameter paraStckPrcConsTaxInclu = sqlCommand.Parameters.Add("@STCKPRCCONSTAXINCLU", SqlDbType.BigInt);
                SqlParameter paraStckDisTtlTaxExc = sqlCommand.Parameters.Add("@STCKDISTTLTAXEXC", SqlDbType.BigInt);
                SqlParameter paraItdedStockDisOutTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraItdedStockDisInTax = sqlCommand.Parameters.Add("@ITDEDSTOCKDISINTAX", SqlDbType.BigInt);
                SqlParameter paraItdedStockDisTaxFre = sqlCommand.Parameters.Add("@ITDEDSTOCKDISTAXFRE", SqlDbType.BigInt);
                SqlParameter paraStockDisOutTax = sqlCommand.Parameters.Add("@STOCKDISOUTTAX", SqlDbType.BigInt);
                SqlParameter paraStckDisTtlTaxInclu = sqlCommand.Parameters.Add("@STCKDISTTLTAXINCLU", SqlDbType.BigInt);
                SqlParameter paraTaxAdjust = sqlCommand.Parameters.Add("@TAXADJUST", SqlDbType.BigInt);
                SqlParameter paraBalanceAdjust = sqlCommand.Parameters.Add("@BALANCEADJUST", SqlDbType.BigInt);
                SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                SqlParameter paraSupplierConsTaxRate = sqlCommand.Parameters.Add("@SUPPLIERCONSTAXRATE", SqlDbType.Float);
                SqlParameter paraAccPayConsTax = sqlCommand.Parameters.Add("@ACCPAYCONSTAX", SqlDbType.BigInt);
                SqlParameter paraStockFractionProcCd = sqlCommand.Parameters.Add("@STOCKFRACTIONPROCCD", SqlDbType.Int);
                SqlParameter paraAutoPayment = sqlCommand.Parameters.Add("@AUTOPAYMENT", SqlDbType.Int);
                SqlParameter paraAutoPaySlipNum = sqlCommand.Parameters.Add("@AUTOPAYSLIPNUM", SqlDbType.Int);
                SqlParameter paraRetGoodsReasonDiv = sqlCommand.Parameters.Add("@RETGOODSREASONDIV", SqlDbType.Int);
                SqlParameter paraRetGoodsReason = sqlCommand.Parameters.Add("@RETGOODSREASON", SqlDbType.NVarChar);
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@PARTYSALESLIPNUM", SqlDbType.NVarChar);
                SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE1", SqlDbType.NVarChar);
                SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@SUPPLIERSLIPNOTE2", SqlDbType.NVarChar);
                SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                SqlParameter paraEdiSendDate = sqlCommand.Parameters.Add("@EDISENDDATE", SqlDbType.Int);
                SqlParameter paraEdiTakeInDate = sqlCommand.Parameters.Add("@EDITAKEINDATE", SqlDbType.Int);
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                SqlParameter paraSlipPrintDivCd = sqlCommand.Parameters.Add("@SLIPPRINTDIVCD", SqlDbType.Int);
                SqlParameter paraSlipPrintFinishCd = sqlCommand.Parameters.Add("@SLIPPRINTFINISHCD", SqlDbType.Int);
                SqlParameter paraStockSlipPrintDate = sqlCommand.Parameters.Add("@STOCKSLIPPRINTDATE", SqlDbType.Int);
                SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipHistWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipHistWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockSlipHistWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.LogicalDeleteCode);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SupplierSlipNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SubSectionCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.DebitNoteDiv);
                paraDebitNLnkSuppSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.DebitNLnkSuppSlipNo);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SupplierSlipCd);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.StockGoodsCd);
                paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.AccPayDivCd);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.StockSectionCd);
                paraStockAddUpSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.StockAddUpSectionCd);
                paraStockSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.StockSlipUpdateCd);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.InputDay);
                paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.ArrivalGoodsDay);
                paraStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.StockDate);
                paraStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.StockAddUpADate);
                paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.DelayPaymentDiv);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.PayeeCode);
                paraPayeeSnm.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.PayeeSnm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SupplierCd);
                paraSupplierNm1.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SupplierNm1);
                paraSupplierNm2.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SupplierNm2);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SupplierSnm);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.BusinessTypeCode);
                paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.BusinessTypeName);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SalesAreaCode);
                paraSalesAreaName.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SalesAreaName);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.StockAgentName);
                paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SuppTtlAmntDspWayCd);
                paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.TtlAmntDispRateApy);
                paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockTotalPrice);
                paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockSubttlPrice);
                paraStockTtlPricTaxInc.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockTtlPricTaxInc);
                paraStockTtlPricTaxExc.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockTtlPricTaxExc);
                paraStockNetPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockNetPrice);
                paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockPriceConsTax);
                paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.TtlItdedStcOutTax);
                paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.TtlItdedStcInTax);
                paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.TtlItdedStcTaxFree);
                paraStockOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockOutTax);
                paraStckPrcConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StckPrcConsTaxInclu);
                paraStckDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StckDisTtlTaxExc);
                paraItdedStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.ItdedStockDisOutTax);
                paraItdedStockDisInTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.ItdedStockDisInTax);
                paraItdedStockDisTaxFre.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.ItdedStockDisTaxFre);
                paraStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StockDisOutTax);
                paraStckDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.StckDisTtlTaxInclu);
                paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.TaxAdjust);
                paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.BalanceAdjust);
                paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SuppCTaxLayCd);
                paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(stockSlipHistWork.SupplierConsTaxRate);
                paraAccPayConsTax.Value = SqlDataMediator.SqlSetInt64(stockSlipHistWork.AccPayConsTax);
                paraStockFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.StockFractionProcCd);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.AutoPayment);
                paraAutoPaySlipNum.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.AutoPaySlipNum);
                paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.RetGoodsReasonDiv);
                paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.RetGoodsReason);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.PartySaleSlipNum);
                paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SupplierSlipNote1);
                paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SupplierSlipNote2);
                paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.DetailRowCount);
                paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.EdiSendDate);
                paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.EdiTakeInDate);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.UoeRemark1);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.UoeRemark2);
                paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SlipPrintDivCd);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockSlipHistWork.SlipPrintFinishCd);
                paraStockSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipHistWork.StockSlipPrintDate);
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(stockSlipHistWork.SlipPrtSetPaperId);

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
		/// 仕入履歴データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="sendDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		public int SearchSCM(out ArrayList resultList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}

		/// <summary>
		/// 仕入履歴データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="sendDataWork">送信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		private int SearchSCMProc(out ArrayList resultList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();

			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT K.CREATEDATETIMERF as K_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,K.UPDATEDATETIMERF as K_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,K.ENTERPRISECODERF as K_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.FILEHEADERGUIDRF as K_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.UPDEMPLOYEECODERF as K_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.UPDASSEMBLYID1RF as K_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,K.UPDASSEMBLYID2RF as K_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,K.LOGICALDELETECODERF as K_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERFORMALRF as K_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERSLIPNORF as K_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,K.SECTIONCODERF as K_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUBSECTIONCODERF as K_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.DEBITNOTEDIVRF as K_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,K.DEBITNLNKSUPPSLIPNORF as K_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERSLIPCDRF as K_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKGOODSCDRF as K_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.ACCPAYDIVCDRF as K_ACCPAYDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKSECTIONCDRF as K_STOCKSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKADDUPSECTIONCDRF as K_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKSLIPUPDATECDRF as K_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.INPUTDAYRF as K_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,K.ARRIVALGOODSDAYRF as K_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKDATERF as K_STOCKDATERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKADDUPADATERF as K_STOCKADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,K.DELAYPAYMENTDIVRF as K_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,K.PAYEECODERF as K_PAYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.PAYEESNMRF as K_PAYEESNMRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERCDRF as K_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERNM1RF as K_SUPPLIERNM1RF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERNM2RF as K_SUPPLIERNM2RF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERSNMRF as K_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,K.BUSINESSTYPECODERF as K_BUSINESSTYPECODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.BUSINESSTYPENAMERF as K_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,K.SALESAREACODERF as K_SALESAREACODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.SALESAREANAMERF as K_SALESAREANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKINPUTCODERF as K_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKINPUTNAMERF as K_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKAGENTCODERF as K_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKAGENTNAMERF as K_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPTTLAMNTDSPWAYCDRF as K_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.TTLAMNTDISPRATEAPYRF as K_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKTOTALPRICERF as K_STOCKTOTALPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKSUBTTLPRICERF as K_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKTTLPRICTAXINCRF as K_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKTTLPRICTAXEXCRF as K_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKNETPRICERF as K_STOCKNETPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKPRICECONSTAXRF as K_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.TTLITDEDSTCOUTTAXRF as K_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.TTLITDEDSTCINTAXRF as K_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.TTLITDEDSTCTAXFREERF as K_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKOUTTAXRF as K_STOCKOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STCKPRCCONSTAXINCLURF as K_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,K.STCKDISTTLTAXEXCRF as K_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,K.ITDEDSTOCKDISOUTTAXRF as K_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.ITDEDSTOCKDISINTAXRF as K_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.ITDEDSTOCKDISTAXFRERF as K_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKDISOUTTAXRF as K_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STCKDISTTLTAXINCLURF as K_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,K.TAXADJUSTRF as K_TAXADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,K.BALANCEADJUSTRF as K_BALANCEADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPCTAXLAYCDRF as K_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERCONSTAXRATERF as K_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
			sb.Append(" ,K.ACCPAYCONSTAXRF as K_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKFRACTIONPROCCDRF as K_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.AUTOPAYMENTRF as K_AUTOPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,K.AUTOPAYSLIPNUMRF as K_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,K.RETGOODSREASONDIVRF as K_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,K.RETGOODSREASONRF as K_RETGOODSREASONRF ").Append(Environment.NewLine);
			sb.Append(" ,K.PARTYSALESLIPNUMRF as K_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERSLIPNOTE1RF as K_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,K.SUPPLIERSLIPNOTE2RF as K_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,K.DETAILROWCOUNTRF as K_DETAILROWCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,K.EDISENDDATERF as K_EDISENDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,K.EDITAKEINDATERF as K_EDITAKEINDATERF ").Append(Environment.NewLine);
			sb.Append(" ,K.UOEREMARK1RF as K_UOEREMARK1RF ").Append(Environment.NewLine);
			sb.Append(" ,K.UOEREMARK2RF as K_UOEREMARK2RF ").Append(Environment.NewLine);
			sb.Append(" ,K.SLIPPRINTDIVCDRF as K_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.SLIPPRINTFINISHCDRF as K_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
			sb.Append(" ,K.STOCKSLIPPRINTDATERF as K_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,K.SLIPPRTSETPAPERIDRF as K_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
			//仕入履歴明細データ
			sb.Append(" ,L.CREATEDATETIMERF as L_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.UPDATEDATETIMERF as L_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.ENTERPRISECODERF as L_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.FILEHEADERGUIDRF as L_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,L.UPDEMPLOYEECODERF as L_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.UPDASSEMBLYID1RF as L_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,L.UPDASSEMBLYID2RF as L_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,L.LOGICALDELETECODERF as L_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.ACCEPTANORDERNORF as L_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,L.SUPPLIERFORMALRF as L_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,L.SUPPLIERSLIPNORF as L_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKROWNORF as L_STOCKROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,L.SECTIONCODERF as L_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.SUBSECTIONCODERF as L_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.COMMONSEQNORF as L_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKSLIPDTLNUMRF as L_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,L.SUPPLIERFORMALSRCRF as L_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKSLIPDTLNUMSRCRF as L_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.ACPTANODRSTATUSSYNCRF as L_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.SALESSLIPDTLNUMSYNCRF as L_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKSLIPCDDTLRF as L_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKAGENTCODERF as L_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKAGENTNAMERF as L_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSKINDCODERF as L_GOODSKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSMAKERCDRF as L_GOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,L.MAKERNAMERF as L_MAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.MAKERKANANAMERF as L_MAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.CMPLTMAKERKANANAMERF as L_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSNORF as L_GOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSNAMERF as L_GOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSNAMEKANARF as L_GOODSNAMEKANARF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSLGROUPRF as L_GOODSLGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSLGROUPNAMERF as L_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSMGROUPRF as L_GOODSMGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSMGROUPNAMERF as L_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.BLGROUPCODERF as L_BLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.BLGROUPNAMERF as L_BLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.BLGOODSCODERF as L_BLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.BLGOODSFULLNAMERF as L_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.ENTERPRISEGANRECODERF as L_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.ENTERPRISEGANRENAMERF as L_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.WAREHOUSECODERF as L_WAREHOUSECODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.WAREHOUSENAMERF as L_WAREHOUSENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.WAREHOUSESHELFNORF as L_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKORDERDIVCDRF as L_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,L.OPENPRICEDIVRF as L_OPENPRICEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,L.GOODSRATERANKRF as L_GOODSRATERANKRF ").Append(Environment.NewLine);
			sb.Append(" ,L.CUSTRATEGRPCODERF as L_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.SUPPRATEGRPCODERF as L_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.LISTPRICETAXEXCFLRF as L_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,L.LISTPRICETAXINCFLRF as L_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKRATERF as L_STOCKRATERF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATESECTSTCKUNPRCRF as L_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEDIVSTCKUNPRCRF as L_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.UNPRCCALCCDSTCKUNPRCRF as L_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.PRICECDSTCKUNPRCRF as L_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STDUNPRCSTCKUNPRCRF as L_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.FRACPROCUNITSTCUNPRCRF as L_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.FRACPROCSTCKUNPRCRF as L_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKUNITPRICEFLRF as L_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKUNITTAXPRICEFLRF as L_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKUNITCHNGDIVRF as L_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,L.BFSTOCKUNITPRICEFLRF as L_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,L.BFLISTPRICERF as L_BFLISTPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEBLGOODSCODERF as L_RATEBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEBLGOODSNAMERF as L_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEGOODSRATEGRPCDRF as L_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEGOODSRATEGRPNMRF as L_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEBLGROUPCODERF as L_RATEBLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.RATEBLGROUPNAMERF as L_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKCOUNTRF as L_STOCKCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKPRICETAXEXCRF as L_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKPRICETAXINCRF as L_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKGOODSCDRF as L_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKPRICECONSTAXRF as L_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,L.TAXATIONCODERF as L_TAXATIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.STOCKDTISLIPNOTE1RF as L_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,L.SALESCUSTOMERCODERF as L_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,L.SALESCUSTOMERSNMRF as L_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,L.ORDERNUMBERRF as L_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,L.SLIPMEMO1RF as L_SLIPMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,L.SLIPMEMO2RF as L_SLIPMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,L.SLIPMEMO3RF as L_SLIPMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,L.INSIDEMEMO1RF as L_INSIDEMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,L.INSIDEMEMO2RF as L_INSIDEMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,L.INSIDEMEMO3RF as L_INSIDEMEMO3RF ").Append(Environment.NewLine);

			sb.Append(" FROM STOCKSLIPHISTRF K WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//仕入履歴明細データ
			sb.Append(" INNER JOIN STOCKSLHISTDTLRF L WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);

			//	仕入履歴データ.企業コード　＝　仕入履歴明細データ.企業コード
			sb.Append(" ON K.ENTERPRISECODERF = L.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	仕入履歴データ.仕入形式　＝　仕入履歴明細データ.仕入形式
			sb.Append(" AND K.SUPPLIERFORMALRF = L.SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//	仕入履歴データ.仕入伝票番号　＝　仕入履歴明細データ.仕入伝票番号
			sb.Append(" AND K.SUPPLIERSLIPNORF = L.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			// DEL 2011.09.08 ------- >>>>>
			////	仕入履歴明細データ.更新日時　>　パラメータ.開始日付
			//sb.Append(" AND L.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_L ").Append(Environment.NewLine);
			////	仕入履歴明細データ.更新日時　≦　パラメータ.終了日付
			//sb.Append(" AND L.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_L ").Append(Environment.NewLine);
			// DEL 2011.09.08 ------- <<<<<
         
            // ----- DEL 2011/11/17 xupz---------->>>>>
            ////	仕入履歴データ.仕入計上拠点コード　＝　パラメータ.拠点コード  
            //sb.Append(" WHERE K.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine); 
            // ----- DEL 2011/11/17 xupz----------<<<<<
            // ----- ADD 2011/11/17 xupz---------->>>>>
            //  仕入履歴データ.仕入拠点コード　＝　パラメータ.拠点コード
            sb.Append(" WHERE K.STOCKSECTIONCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine);
            // ----- ADD 2011/11/17 xupz----------<<<<<
           
            // ----- DEL 2011/11/01 xupz---------->>>>>　　
            ////	仕入履歴データ.更新日時　>　パラメータ.開始日付
            //sb.Append(" AND ((K.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_K ").Append(Environment.NewLine);
            ////	仕入履歴データ.更新日時　≦　パラメータ.終了日付
            //sb.Append(" AND K.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_K) ").Append(Environment.NewLine);
            //// ADD 2011.09.08 ------- >>>>>
            ////	仕入履歴明細データ.更新日時　>　パラメータ.開始日付
            //sb.Append(" OR (L.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_L ").Append(Environment.NewLine);
            ////	仕入履歴明細データ.更新日時　≦　パラメータ.終了日付
            //sb.Append(" AND L.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_L ))").Append(Environment.NewLine);
            //// ADD 2011.09.08 ------- <<<<<
            // ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>  
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0) 
            {
			//	仕入履歴データ.更新日時　>　パラメータ.開始日付
			sb.Append(" AND ((K.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_K ").Append(Environment.NewLine);
			//	仕入履歴データ.更新日時　≦　パラメータ.終了日付
			sb.Append(" AND K.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_K) ").Append(Environment.NewLine);
			// ADD 2011.09.08 ------- >>>>>
			//	仕入履歴明細データ.更新日時　>　パラメータ.開始日付
			sb.Append(" OR (L.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_L ").Append(Environment.NewLine);
			//	仕入履歴明細データ.更新日時　≦　パラメータ.終了日付
			sb.Append(" AND L.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_L ))").Append(Environment.NewLine);
			// ADD 2011.09.08 ------- <<<<<
            }
            //データ送信抽出条件区分が「伝票日付」の場合
            else if (sendDataWork.SndMesExtraCondDiv == 1) 
            {
                //	仕入履歴データ.仕入日　>=　パラメータ.開始日付
                //sb.Append(" AND (K.STOCKDATERF>=@FINDUPDATESTARTDATETIME_K ").Append(Environment.NewLine); // DEL 2011/11/30
                sb.Append(" AND ((K.STOCKDATERF>=@FINDUPDATESTARTDATETIME_K ").Append(Environment.NewLine);  // ADD 2011/11/30
                //	仕入履歴データ.仕入日　≦　パラメータ.終了日付
                sb.Append(" AND K.STOCKDATERF<=@FINDUPDATEENDDATETIME_K) ").Append(Environment.NewLine);

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sb.Append(" OR ( K.UPDATEDATETIMERF>=@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                sb.Append(" OR ( K.UPDATEDATETIMERF>@FINDSYNCEXECDATERF ").Append(Environment.NewLine);
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sb.Append(" AND  K.UPDATEDATETIMERF<=@FINDENDTIMERF ").Append(Environment.NewLine);
                sb.Append(" AND  K.STOCKDATERF<=@FINDUPDATEENDDATETIME_K )) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<<
            }
            // ----- ADD 2011/11/01 xupz----------<<<<<

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" K_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,K_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,K_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,L_SUPPLIERFORMALRF  ").Append(Environment.NewLine);
			sb.Append(" ,L_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);

			sqlText = sb.ToString();

			//Prameterオブジェクトの作成
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_K = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_K", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_K = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_K", SqlDbType.BigInt);
			SqlParameter findParaUpdateStartDateTime_L = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_L", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_L = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_L", SqlDbType.BigInt);

			//Parameterオブジェクトへ値設定
			findParaSectionCode.Value = sendDataWork.PmSectionCode;
			findParaUpdateStartDateTime_K.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_K.Value = sendDataWork.EndDateTime;
			findParaUpdateStartDateTime_L.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_L.Value = sendDataWork.EndDateTime;

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //データ送信抽出条件区分が「伝票区分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = sendDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                // DEL 2011/12/06 ----------- >>>>>>>>>>>>>>>
                //string endTimeStr = sendDataWork.EndDateTime.ToString();
                //if (endTimeStr.Length == 8)
                //{
                //    DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                //                                int.Parse(endTimeStr.Substring(4, 2)),
                //                                int.Parse(endTimeStr.Substring(6, 2)),
                //                                23, 59, 59);
                //    findParaEndTime.Value = endTime.Ticks;
                //}
                //else
                //{
                //    findParaEndTime.Value = DateTime.MinValue.Ticks;
                //}
                // DEL 2011/12/06 ----------- <<<<<<<<<<<<<<<
                findParaEndTime.Value = sendDataWork.EndDateTimeTicks; // ADD 2011/12/06
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

			// SQL文
			sqlCommand.CommandText = sqlText;
            //  ADD dingjx  2011/10/08  ---------------->>>>>>
            // Timeout
            sqlCommand.CommandTimeout = 600;
            //  ADD dingjx  2011/10/08  ----------------<<<<<<
			myReader = sqlCommand.ExecuteReader();

			ArrayList stockSlipHistList = new ArrayList();
			ArrayList stockDtlHistList = new ArrayList();
			APStockSlHistDtlDB aPSalesHistDtlDB = new APStockSlHistDtlDB();
			APStockSlipHistWork tmpWorkK = new APStockSlipHistWork();
			APStockSlHistDtlWork tmpWorkL = new APStockSlHistDtlWork();

			Dictionary<string, string> stockSlipHisDic = new Dictionary<string, string>();
			Dictionary<string, string> stockHisDtlDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				//	仕入履歴データ
				tmpWorkK = this.CopyToStockSlipHistWorkFromReaderSCM(ref myReader, "K_");
				string workK_key = tmpWorkK.EnterpriseCode + tmpWorkK.SupplierFormal.ToString() + tmpWorkK.SupplierSlipNo.ToString();
				if (!string.Empty.Equals(tmpWorkK.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkK.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkK.SupplierSlipNo.ToString())
					&& !stockSlipHisDic.ContainsKey(workK_key))
				{
					stockSlipHisDic.Add(workK_key, workK_key);
					stockSlipHistList.Add(tmpWorkK);
				}

				//	仕入履歴明細データ
				tmpWorkL = aPSalesHistDtlDB.CopyToStockSlHistDtlWorkFromReaderSCM(ref myReader, "L_");
				string workL_key = tmpWorkL.EnterpriseCode + tmpWorkL.SupplierFormal.ToString() + tmpWorkL.StockSlipDtlNum.ToString();
				if (!string.Empty.Equals(tmpWorkL.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkL.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkL.StockSlipDtlNum.ToString())
					&& !stockHisDtlDic.ContainsKey(workL_key))
				{
					stockHisDtlDic.Add(workL_key, workL_key);
					stockDtlHistList.Add(tmpWorkL);
				}
			}

			// 仕入履歴要否フラグ
			if (sendDataWork.DoStockSlipHistFlg)
			{
				resultList.Add(stockSlipHistList);
			}
			// 仕入履歴明細否フラグ
			if (sendDataWork.DoStockSlHistDtlFlg)
			{
				resultList.Add(stockDtlHistList);
			}

			if (stockSlipHistList.Count > 0)
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
		/// クラス格納処理 Reader → stockSlipHistWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		private APStockSlipHistWork CopyToStockSlipHistWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APStockSlipHistWork stockSlipHistWork = new APStockSlipHistWork();

			this.CopyToStockSlipHistWorkFromReaderSCM(ref myReader, ref stockSlipHistWork, tableNm);

			return stockSlipHistWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockSlipHistWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockSlipHistWork">stockSlipHistWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToStockSlipHistWorkFromReaderSCM(ref SqlDataReader myReader, ref APStockSlipHistWork stockSlipHistWork, string tableNm)
		{
			if (myReader != null && stockSlipHistWork != null)
			{
				# region クラスへ格納
				stockSlipHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				stockSlipHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				stockSlipHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				stockSlipHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				stockSlipHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				stockSlipHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				stockSlipHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				stockSlipHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				stockSlipHistWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				stockSlipHistWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				stockSlipHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				stockSlipHistWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				stockSlipHistWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				stockSlipHistWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNLNKSUPPSLIPNORF"));
				stockSlipHistWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPCDRF"));
				stockSlipHistWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSCDRF"));
				stockSlipHistWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCPAYDIVCDRF"));
				stockSlipHistWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKSECTIONCDRF"));
				stockSlipHistWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKADDUPSECTIONCDRF"));
				stockSlipHistWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPUPDATECDRF"));
				stockSlipHistWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "INPUTDAYRF"));
				stockSlipHistWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ARRIVALGOODSDAYRF"));
				stockSlipHistWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKDATERF"));
				stockSlipHistWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKADDUPADATERF"));
				stockSlipHistWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELAYPAYMENTDIVRF"));
				stockSlipHistWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYEECODERF"));
				stockSlipHistWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEESNMRF"));
				stockSlipHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				stockSlipHistWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM1RF"));
				stockSlipHistWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM2RF"));
				stockSlipHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				stockSlipHistWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPECODERF"));
				stockSlipHistWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPENAMERF"));
				stockSlipHistWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESAREACODERF"));
				stockSlipHistWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESAREANAMERF"));
				stockSlipHistWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTCODERF"));
				stockSlipHistWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTNAMERF"));
				stockSlipHistWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTCODERF"));
				stockSlipHistWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTNAMERF"));
				stockSlipHistWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPTTLAMNTDSPWAYCDRF"));
				stockSlipHistWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TTLAMNTDISPRATEAPYRF"));
				stockSlipHistWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTOTALPRICERF"));
				stockSlipHistWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSUBTTLPRICERF"));
				stockSlipHistWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTTLPRICTAXINCRF"));
				stockSlipHistWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTTLPRICTAXEXCRF"));
				stockSlipHistWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKNETPRICERF"));
				stockSlipHistWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICECONSTAXRF"));
				stockSlipHistWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCOUTTAXRF"));
				stockSlipHistWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCINTAXRF"));
				stockSlipHistWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCTAXFREERF"));
				stockSlipHistWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKOUTTAXRF"));
				stockSlipHistWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKPRCCONSTAXINCLURF"));
				stockSlipHistWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKDISTTLTAXEXCRF"));
				stockSlipHistWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISOUTTAXRF"));
				stockSlipHistWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISINTAXRF"));
				stockSlipHistWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISTAXFRERF"));
				stockSlipHistWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKDISOUTTAXRF"));
				stockSlipHistWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKDISTTLTAXINCLURF"));
				stockSlipHistWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TAXADJUSTRF"));
				stockSlipHistWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "BALANCEADJUSTRF"));
				stockSlipHistWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPCTAXLAYCDRF"));
				stockSlipHistWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCONSTAXRATERF"));
				stockSlipHistWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ACCPAYCONSTAXRF"));
				stockSlipHistWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKFRACTIONPROCCDRF"));
				stockSlipHistWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYMENTRF"));
				stockSlipHistWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYSLIPNUMRF"));
				stockSlipHistWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONDIVRF"));
				stockSlipHistWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONRF"));
				stockSlipHistWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSALESLIPNUMRF"));
				stockSlipHistWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNOTE1RF"));
				stockSlipHistWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNOTE2RF"));
				stockSlipHistWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DETAILROWCOUNTRF"));
				stockSlipHistWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDISENDDATERF"));
				stockSlipHistWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDITAKEINDATERF"));
				stockSlipHistWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK1RF"));
				stockSlipHistWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK2RF"));
				stockSlipHistWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTDIVCDRF"));
				stockSlipHistWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTFINISHCDRF"));
				stockSlipHistWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPPRINTDATERF"));
				stockSlipHistWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPPRTSETPAPERIDRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}

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
// 修 正 日  2011/08/29  修正内容 : Redmine #23896 No.16 日付の範囲チェックを削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/08  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 丁建雄
// 修 正 日  2011/10/08  修正内容 : #25780 データ送信処理　売上履歴データ送信時のタイムアウト設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳建明
// 作 成 日  2011/11/11  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 作 成 日  2011/11/14  修正内容 : 仕様連絡 #26228: 拠点管理改良／伝票日付による抽出対応
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
    /// 仕入データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APStockSlipDB : RemoteDB
    {
        /// <summary>
        /// 仕入データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APStockSlipDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockSlipArrList">仕入データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchStockSlip(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockSlipArrList, out string retMessage)
        {
            return SearchStockSlipProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockSlipArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockSlipArrList">仕入データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchStockSlipProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockSlipArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockSlipArrList = new ArrayList();
            APStockSlipWork stockSlipWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSUPPSLIPNORF, SUPPLIERSLIPCDRF, STOCKGOODSCDRF, ACCPAYDIVCDRF, STOCKSECTIONCDRF, STOCKADDUPSECTIONCDRF, STOCKSLIPUPDATECDRF, INPUTDAYRF, ARRIVALGOODSDAYRF, STOCKDATERF, STOCKADDUPADATERF, DELAYPAYMENTDIVRF, PAYEECODERF, PAYEESNMRF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, SALESAREACODERF, SALESAREANAMERF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, SUPPTTLAMNTDSPWAYCDRF, TTLAMNTDISPRATEAPYRF, STOCKTOTALPRICERF, STOCKSUBTTLPRICERF, STOCKTTLPRICTAXINCRF, STOCKTTLPRICTAXEXCRF, STOCKNETPRICERF, STOCKPRICECONSTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, STOCKOUTTAXRF, STCKPRCCONSTAXINCLURF, STCKDISTTLTAXEXCRF, ITDEDSTOCKDISOUTTAXRF, ITDEDSTOCKDISINTAXRF, ITDEDSTOCKDISTAXFRERF, STOCKDISOUTTAXRF, STCKDISTTLTAXINCLURF, TAXADJUSTRF, BALANCEADJUSTRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, ACCPAYCONSTAXRF, STOCKFRACTIONPROCCDRF, AUTOPAYMENTRF, AUTOPAYSLIPNUMRF, RETGOODSREASONDIVRF, RETGOODSREASONRF, PARTYSALESLIPNUMRF, SUPPLIERSLIPNOTE1RF, SUPPLIERSLIPNOTE2RF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, STOCKSLIPPRINTDATERF, SLIPPRTSETPAPERIDRF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, DIRECTSENDINGCDRF FROM STOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 仕入データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockSlipWork = new APStockSlipWork();

                    stockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    stockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    stockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    stockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                    stockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
                    stockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                    stockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                    stockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
                    stockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                    stockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
                    stockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
                    stockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    stockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                    stockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    stockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                    stockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                    stockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    stockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    stockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                    stockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                    stockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                    stockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                    stockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                    stockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                    stockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    stockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    stockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                    stockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                    stockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    stockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                    stockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                    stockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                    stockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
                    stockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    stockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                    stockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                    stockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                    stockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
                    stockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                    stockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
                    stockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
                    stockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
                    stockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
                    stockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
                    stockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                    stockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
                    stockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
                    stockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    stockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
                    stockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
                    stockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
                    stockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                    stockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
                    stockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                    stockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                    stockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    stockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                    stockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                    stockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                    stockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                    stockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                    stockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    stockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    stockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                    stockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                    stockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
                    stockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                    stockSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
                    stockSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                    stockSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                    stockSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                    stockSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                    stockSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                    stockSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                    stockSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                    stockSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                    stockSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                    stockSlipWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));


                    stockSlipArrList.Add(stockSlipWork);
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
        /// 仕入データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipList">仕入データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockSlip(string enterPriseCode, ArrayList stockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockSlipProc(enterPriseCode, stockSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipList">仕入データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockSlipProc(string enterPriseCode, ArrayList stockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockSlip(enterPriseCode, stockSlipList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockSlip(enterPriseCode, stockSlipList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipList">仕入データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockSlip(string enterPriseCode, ArrayList stockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockSlipProc(enterPriseCode, stockSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipList">仕入データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockSlipProc(string enterPriseCode, ArrayList stockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockSlipWork stockSlipWork in stockSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKSLIPRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaSupplierFormal.Value = stockSlipWork.SupplierFormal;
                findParaSupplierSlipNo.Value = stockSlipWork.SupplierSlipNo;

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
        /// 仕入データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipList">仕入データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockSlip(string enterPriseCode, ArrayList stockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockSlipProc(enterPriseCode, stockSlipList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockSlipList">仕入データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockSlipProc(string enterPriseCode, ArrayList stockSlipList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockSlipWork stockSlipWork in stockSlipList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKSLIPRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, SECTIONCODERF, SUBSECTIONCODERF, DEBITNOTEDIVRF, DEBITNLNKSUPPSLIPNORF, SUPPLIERSLIPCDRF, STOCKGOODSCDRF, ACCPAYDIVCDRF, STOCKSECTIONCDRF, STOCKADDUPSECTIONCDRF, STOCKSLIPUPDATECDRF, INPUTDAYRF, ARRIVALGOODSDAYRF, STOCKDATERF, STOCKADDUPADATERF, DELAYPAYMENTDIVRF, PAYEECODERF, PAYEESNMRF, SUPPLIERCDRF, SUPPLIERNM1RF, SUPPLIERNM2RF, SUPPLIERSNMRF, BUSINESSTYPECODERF, BUSINESSTYPENAMERF, SALESAREACODERF, SALESAREANAMERF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, SUPPTTLAMNTDSPWAYCDRF, TTLAMNTDISPRATEAPYRF, STOCKTOTALPRICERF, STOCKSUBTTLPRICERF, STOCKTTLPRICTAXINCRF, STOCKTTLPRICTAXEXCRF, STOCKNETPRICERF, STOCKPRICECONSTAXRF, TTLITDEDSTCOUTTAXRF, TTLITDEDSTCINTAXRF, TTLITDEDSTCTAXFREERF, STOCKOUTTAXRF, STCKPRCCONSTAXINCLURF, STCKDISTTLTAXEXCRF, ITDEDSTOCKDISOUTTAXRF, ITDEDSTOCKDISINTAXRF, ITDEDSTOCKDISTAXFRERF, STOCKDISOUTTAXRF, STCKDISTTLTAXINCLURF, TAXADJUSTRF, BALANCEADJUSTRF, SUPPCTAXLAYCDRF, SUPPLIERCONSTAXRATERF, ACCPAYCONSTAXRF, STOCKFRACTIONPROCCDRF, AUTOPAYMENTRF, AUTOPAYSLIPNUMRF, RETGOODSREASONDIVRF, RETGOODSREASONRF, PARTYSALESLIPNUMRF, SUPPLIERSLIPNOTE1RF, SUPPLIERSLIPNOTE2RF, DETAILROWCOUNTRF, EDISENDDATERF, EDITAKEINDATERF, UOEREMARK1RF, UOEREMARK2RF, SLIPPRINTDIVCDRF, SLIPPRINTFINISHCDRF, STOCKSLIPPRINTDATERF, SLIPPRTSETPAPERIDRF, SLIPADDRESSDIVRF, ADDRESSEECODERF, ADDRESSEENAMERF, ADDRESSEENAME2RF, ADDRESSEEPOSTNORF, ADDRESSEEADDR1RF, ADDRESSEEADDR3RF, ADDRESSEEADDR4RF, ADDRESSEETELNORF, ADDRESSEEFAXNORF, DIRECTSENDINGCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @SECTIONCODE, @SUBSECTIONCODE, @DEBITNOTEDIV, @DEBITNLNKSUPPSLIPNO, @SUPPLIERSLIPCD, @STOCKGOODSCD, @ACCPAYDIVCD, @STOCKSECTIONCD, @STOCKADDUPSECTIONCD, @STOCKSLIPUPDATECD, @INPUTDAY, @ARRIVALGOODSDAY, @STOCKDATE, @STOCKADDUPADATE, @DELAYPAYMENTDIV, @PAYEECODE, @PAYEESNM, @SUPPLIERCD, @SUPPLIERNM1, @SUPPLIERNM2, @SUPPLIERSNM, @BUSINESSTYPECODE, @BUSINESSTYPENAME, @SALESAREACODE, @SALESAREANAME, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @SUPPTTLAMNTDSPWAYCD, @TTLAMNTDISPRATEAPY, @STOCKTOTALPRICE, @STOCKSUBTTLPRICE, @STOCKTTLPRICTAXINC, @STOCKTTLPRICTAXEXC, @STOCKNETPRICE, @STOCKPRICECONSTAX, @TTLITDEDSTCOUTTAX, @TTLITDEDSTCINTAX, @TTLITDEDSTCTAXFREE, @STOCKOUTTAX, @STCKPRCCONSTAXINCLU, @STCKDISTTLTAXEXC, @ITDEDSTOCKDISOUTTAX, @ITDEDSTOCKDISINTAX, @ITDEDSTOCKDISTAXFRE, @STOCKDISOUTTAX, @STCKDISTTLTAXINCLU, @TAXADJUST, @BALANCEADJUST, @SUPPCTAXLAYCD, @SUPPLIERCONSTAXRATE, @ACCPAYCONSTAX, @STOCKFRACTIONPROCCD, @AUTOPAYMENT, @AUTOPAYSLIPNUM, @RETGOODSREASONDIV, @RETGOODSREASON, @PARTYSALESLIPNUM, @SUPPLIERSLIPNOTE1, @SUPPLIERSLIPNOTE2, @DETAILROWCOUNT, @EDISENDDATE, @EDITAKEINDATE, @UOEREMARK1, @UOEREMARK2, @SLIPPRINTDIVCD, @SLIPPRINTFINISHCD, @STOCKSLIPPRINTDATE, @SLIPPRTSETPAPERID, @SLIPADDRESSDIV, @ADDRESSEECODE, @ADDRESSEENAME, @ADDRESSEENAME2, @ADDRESSEEPOSTNO, @ADDRESSEEADDR1, @ADDRESSEEADDR3, @ADDRESSEEADDR4, @ADDRESSEETELNO, @ADDRESSEEFAXNO, @DIRECTSENDINGCD)";

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
                SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockSlipWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockSlipWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.LogicalDeleteCode);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SubSectionCode);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DebitNoteDiv);
                paraDebitNLnkSuppSlipNo.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DebitNLnkSuppSlipNo);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierSlipCd);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.StockGoodsCd);
                paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AccPayDivCd);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockSectionCd);
                paraStockAddUpSectionCd.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAddUpSectionCd);
                paraStockSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.StockSlipUpdateCd);
                paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.InputDay);
                paraArrivalGoodsDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.ArrivalGoodsDay);
                paraStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.StockDate);
                paraStockAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.StockAddUpADate);
                paraDelayPaymentDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DelayPaymentDiv);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.PayeeCode);
                paraPayeeSnm.Value = SqlDataMediator.SqlSetString(stockSlipWork.PayeeSnm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SupplierCd);
                paraSupplierNm1.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierNm1);
                paraSupplierNm2.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierNm2);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierSnm);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.BusinessTypeCode);
                paraBusinessTypeName.Value = SqlDataMediator.SqlSetString(stockSlipWork.BusinessTypeName);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SalesAreaCode);
                paraSalesAreaName.Value = SqlDataMediator.SqlSetString(stockSlipWork.SalesAreaName);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockSlipWork.StockAgentName);
                paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SuppTtlAmntDspWayCd);
                paraTtlAmntDispRateApy.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.TtlAmntDispRateApy);
                paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockTotalPrice);
                paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockSubttlPrice);
                paraStockTtlPricTaxInc.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockTtlPricTaxInc);
                paraStockTtlPricTaxExc.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockTtlPricTaxExc);
                paraStockNetPrice.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockNetPrice);
                paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockPriceConsTax);
                paraTtlItdedStcOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TtlItdedStcOutTax);
                paraTtlItdedStcInTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TtlItdedStcInTax);
                paraTtlItdedStcTaxFree.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TtlItdedStcTaxFree);
                paraStockOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockOutTax);
                paraStckPrcConsTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StckPrcConsTaxInclu);
                paraStckDisTtlTaxExc.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StckDisTtlTaxExc);
                paraItdedStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.ItdedStockDisOutTax);
                paraItdedStockDisInTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.ItdedStockDisInTax);
                paraItdedStockDisTaxFre.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.ItdedStockDisTaxFre);
                paraStockDisOutTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StockDisOutTax);
                paraStckDisTtlTaxInclu.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.StckDisTtlTaxInclu);
                paraTaxAdjust.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.TaxAdjust);
                paraBalanceAdjust.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.BalanceAdjust);
                paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SuppCTaxLayCd);
                paraSupplierConsTaxRate.Value = SqlDataMediator.SqlSetDouble(stockSlipWork.SupplierConsTaxRate);
                paraAccPayConsTax.Value = SqlDataMediator.SqlSetInt64(stockSlipWork.AccPayConsTax);
                paraStockFractionProcCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.StockFractionProcCd);
                paraAutoPayment.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AutoPayment);
                paraAutoPaySlipNum.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AutoPaySlipNum);
                paraRetGoodsReasonDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.RetGoodsReasonDiv);
                paraRetGoodsReason.Value = SqlDataMediator.SqlSetString(stockSlipWork.RetGoodsReason);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(stockSlipWork.PartySaleSlipNum);
                paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierSlipNote1);
                paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(stockSlipWork.SupplierSlipNote2);
                paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DetailRowCount);
                paraEdiSendDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.EdiSendDate);
                paraEdiTakeInDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.EdiTakeInDate);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(stockSlipWork.UoeRemark1);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(stockSlipWork.UoeRemark2);
                paraSlipPrintDivCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SlipPrintDivCd);
                paraSlipPrintFinishCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SlipPrintFinishCd);
                paraStockSlipPrintDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockSlipWork.StockSlipPrintDate);
                paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(stockSlipWork.SlipPrtSetPaperId);
                paraSlipAddressDiv.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.SlipAddressDiv);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.AddresseeCode);
                paraAddresseeName.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeName);
                paraAddresseeName2.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeName2);
                paraAddresseePostNo.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseePostNo);
                paraAddresseeAddr1.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeAddr1);
                paraAddresseeAddr3.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeAddr3);
                paraAddresseeAddr4.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeAddr4);
                paraAddresseeTelNo.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeTelNo);
                paraAddresseeFaxNo.Value = SqlDataMediator.SqlSetString(stockSlipWork.AddresseeFaxNo);
                paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(stockSlipWork.DirectSendingCd);

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
		/// 仕入データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="acpOdrList">acpOdrList</param>
		/// <param name="sendDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		// DEL 2011/09/15 ---------->>>>>
		//public int SearchSCM(out ArrayList resultList, out ArrayList outSstockDtlList, out ArrayList acpOdrList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		//{
		//    return SearchSCMProc(out  resultList, out outSstockDtlList, out acpOdrList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		//}
		// DEL 2011/09/15 ----------<<<<<
		// ADD 2011/09/15 ---------->>>>>
		public int SearchSCM(out ArrayList resultList, out ArrayList acpOdrList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return SearchSCMProc(out  resultList, out acpOdrList, sendDataWork, ref  sqlConnection, ref  sqlTransaction);
		}
		// ADD 2011/09/15 ----------<<<<<

		/// <summary>
		/// 仕入データ取得
		/// </summary>
		/// <param name="resultList">結果データ</param>
		/// <param name="acpOdrList">acpOdrList</param>
		/// <param name="sendDataWork">受信データ</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <returns></returns>
		//private int SearchSCMProc(out ArrayList resultList,out ArrayList outSstockDtlList, out ArrayList acpOdrList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) // DEL 2011/09/15
		private int SearchSCMProc(out ArrayList resultList, out ArrayList acpOdrList, APSendDataWork sendDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) // ADD 2011/09/15
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			resultList = new ArrayList();
			acpOdrList = new ArrayList();
			//outSstockDtlList = new ArrayList();// DEL 2011/09/15
			string sqlText = string.Empty;
			sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT I.CREATEDATETIMERF as I_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDATEDATETIMERF as I_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ENTERPRISECODERF as I_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.FILEHEADERGUIDRF as I_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDEMPLOYEECODERF as I_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDASSEMBLYID1RF as I_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDASSEMBLYID2RF as I_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.LOGICALDELETECODERF as I_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERFORMALRF as I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNORF as I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.SECTIONCODERF as I_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUBSECTIONCODERF as I_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.DEBITNOTEDIVRF as I_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.DEBITNLNKSUPPSLIPNORF as I_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPCDRF as I_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKGOODSCDRF as I_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ACCPAYDIVCDRF as I_ACCPAYDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSECTIONCDRF as I_STOCKSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKADDUPSECTIONCDRF as I_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSLIPUPDATECDRF as I_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.INPUTDAYRF as I_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ARRIVALGOODSDAYRF as I_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKDATERF as I_STOCKDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKADDUPADATERF as I_STOCKADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.DELAYPAYMENTDIVRF as I_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.PAYEECODERF as I_PAYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.PAYEESNMRF as I_PAYEESNMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERCDRF as I_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERNM1RF as I_SUPPLIERNM1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERNM2RF as I_SUPPLIERNM2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSNMRF as I_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.BUSINESSTYPECODERF as I_BUSINESSTYPECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.BUSINESSTYPENAMERF as I_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SALESAREACODERF as I_SALESAREACODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SALESAREANAMERF as I_SALESAREANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKINPUTCODERF as I_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKINPUTNAMERF as I_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKAGENTCODERF as I_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKAGENTNAMERF as I_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPTTLAMNTDSPWAYCDRF as I_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLAMNTDISPRATEAPYRF as I_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTOTALPRICERF as I_STOCKTOTALPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSUBTTLPRICERF as I_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTTLPRICTAXINCRF as I_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTTLPRICTAXEXCRF as I_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKNETPRICERF as I_STOCKNETPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKPRICECONSTAXRF as I_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCOUTTAXRF as I_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCINTAXRF as I_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCTAXFREERF as I_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKOUTTAXRF as I_STOCKOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKPRCCONSTAXINCLURF as I_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKDISTTLTAXEXCRF as I_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISOUTTAXRF as I_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISINTAXRF as I_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISTAXFRERF as I_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKDISOUTTAXRF as I_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKDISTTLTAXINCLURF as I_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,I.TAXADJUSTRF as I_TAXADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.BALANCEADJUSTRF as I_BALANCEADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPCTAXLAYCDRF as I_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERCONSTAXRATERF as I_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ACCPAYCONSTAXRF as I_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKFRACTIONPROCCDRF as I_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.AUTOPAYMENTRF as I_AUTOPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.AUTOPAYSLIPNUMRF as I_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.RETGOODSREASONDIVRF as I_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.RETGOODSREASONRF as I_RETGOODSREASONRF ").Append(Environment.NewLine);
			sb.Append(" ,I.PARTYSALESLIPNUMRF as I_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNOTE1RF as I_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNOTE2RF as I_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.DETAILROWCOUNTRF as I_DETAILROWCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.EDISENDDATERF as I_EDISENDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.EDITAKEINDATERF as I_EDITAKEINDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UOEREMARK1RF as I_UOEREMARK1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.UOEREMARK2RF as I_UOEREMARK2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRINTDIVCDRF as I_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRINTFINISHCDRF as I_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSLIPPRINTDATERF as I_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRTSETPAPERIDRF as I_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPADDRESSDIVRF as I_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEECODERF as I_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEENAMERF as I_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEENAME2RF as I_ADDRESSEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEPOSTNORF as I_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR1RF as I_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR3RF as I_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR4RF as I_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEETELNORF as I_ADDRESSEETELNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEFAXNORF as I_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.DIRECTSENDINGCDRF as I_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
			//仕入明細データ
			sb.Append(" ,J.CREATEDATETIMERF as J_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDATEDATETIMERF as J_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISECODERF as J_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.FILEHEADERGUIDRF as J_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDEMPLOYEECODERF as J_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDASSEMBLYID1RF as J_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDASSEMBLYID2RF as J_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.LOGICALDELETECODERF as J_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ACCEPTANORDERNORF as J_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERFORMALRF as J_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERSLIPNORF as J_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKROWNORF as J_STOCKROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.SECTIONCODERF as J_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUBSECTIONCODERF as J_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.COMMONSEQNORF as J_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPDTLNUMRF as J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERFORMALSRCRF as J_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPDTLNUMSRCRF as J_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ACPTANODRSTATUSSYNCRF as J_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESSLIPDTLNUMSYNCRF as J_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPCDDTLRF as J_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKINPUTCODERF as J_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKINPUTNAMERF as J_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKAGENTCODERF as J_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKAGENTNAMERF as J_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSKINDCODERF as J_GOODSKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMAKERCDRF as J_GOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.MAKERNAMERF as J_MAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.MAKERKANANAMERF as J_MAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.CMPLTMAKERKANANAMERF as J_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNORF as J_GOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNAMERF as J_GOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNAMEKANARF as J_GOODSNAMEKANARF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSLGROUPRF as J_GOODSLGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSLGROUPNAMERF as J_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMGROUPRF as J_GOODSMGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMGROUPNAMERF as J_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGROUPCODERF as J_BLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGROUPNAMERF as J_BLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGOODSCODERF as J_BLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGOODSFULLNAMERF as J_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISEGANRECODERF as J_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISEGANRENAMERF as J_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSECODERF as J_WAREHOUSECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSENAMERF as J_WAREHOUSENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSESHELFNORF as J_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKORDERDIVCDRF as J_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.OPENPRICEDIVRF as J_OPENPRICEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSRATERANKRF as J_GOODSRATERANKRF ").Append(Environment.NewLine);
			sb.Append(" ,J.CUSTRATEGRPCODERF as J_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPRATEGRPCODERF as J_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.LISTPRICETAXEXCFLRF as J_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.LISTPRICETAXINCFLRF as J_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKRATERF as J_STOCKRATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATESECTSTCKUNPRCRF as J_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEDIVSTCKUNPRCRF as J_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.UNPRCCALCCDSTCKUNPRCRF as J_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.PRICECDSTCKUNPRCRF as J_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STDUNPRCSTCKUNPRCRF as J_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.FRACPROCUNITSTCUNPRCRF as J_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.FRACPROCSTCKUNPRCRF as J_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITPRICEFLRF as J_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITTAXPRICEFLRF as J_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITCHNGDIVRF as J_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.BFSTOCKUNITPRICEFLRF as J_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.BFLISTPRICERF as J_BFLISTPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGOODSCODERF as J_RATEBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGOODSNAMERF as J_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEGOODSRATEGRPCDRF as J_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEGOODSRATEGRPNMRF as J_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGROUPCODERF as J_RATEBLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGROUPNAMERF as J_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKCOUNTRF as J_STOCKCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERCNTRF as J_ORDERCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERADJUSTCNTRF as J_ORDERADJUSTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERREMAINCNTRF as J_ORDERREMAINCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.REMAINCNTUPDDATERF as J_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICETAXEXCRF as J_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICETAXINCRF as J_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKGOODSCDRF as J_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICECONSTAXRF as J_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,J.TAXATIONCODERF as J_TAXATIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKDTISLIPNOTE1RF as J_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESCUSTOMERCODERF as J_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESCUSTOMERSNMRF as J_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO1RF as J_SLIPMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO2RF as J_SLIPMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO3RF as J_SLIPMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO1RF as J_INSIDEMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO2RF as J_INSIDEMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO3RF as J_INSIDEMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERCDRF as J_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERSNMRF as J_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ADDRESSEECODERF as J_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ADDRESSEENAMERF as J_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.DIRECTSENDINGCDRF as J_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERNUMBERRF as J_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAYTOORDERRF as J_WAYTOORDERRF ").Append(Environment.NewLine);
			sb.Append(" ,J.DELIGDSCMPLTDUEDATERF as J_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.EXPECTDELIVERYDATERF as J_EXPECTDELIVERYDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERDATACREATEDIVRF as J_ORDERDATACREATEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERDATACREATEDATERF as J_ORDERDATACREATEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERFORMISSUEDDIVRF  as J_ORDERFORMISSUEDDIVRF  ").Append(Environment.NewLine);
			//受注マスタ
			sb.Append(" ,C2.CREATEDATETIMERF as C2_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDATEDATETIMERF as C2_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ENTERPRISECODERF as C2_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.FILEHEADERGUIDRF as C2_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDEMPLOYEECODERF as C2_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDASSEMBLYID1RF as C2_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDASSEMBLYID2RF as C2_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,C2.LOGICALDELETECODERF as C2_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SECTIONCODERF as C2_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ACCEPTANORDERNORF as C2_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ACPTANODRSTATUSRF as C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SALESSLIPNUMRF as C2_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.DATAINPUTSYSTEMRF as C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.COMMONSEQNORF as C2_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SLIPDTLNUMRF as C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SLIPDTLNUMDERIVNORF as C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SRCLINKDATACODERF as C2_SRCLINKDATACODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SRCSLIPDTLNUMRF as C2_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);

			sb.Append(" FROM STOCKSLIPRF I WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//仕入明細データ
			sb.Append(" INNER JOIN STOCKDETAILRF J WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//	仕入データ.企業コード　＝　仕入明細データ.企業コード
			sb.Append(" ON I.ENTERPRISECODERF = J.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	仕入データ.仕入形式　＝　仕入明細データ.仕入形式
			sb.Append(" AND I.SUPPLIERFORMALRF = J.SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//	仕入データ.仕入伝票番号　＝　仕入明細データ.仕入伝票番号
			sb.Append(" AND I.SUPPLIERSLIPNORF = J.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ------->>>>>
			////	仕入明細データ.更新日時　>　パラメータ.開始日付
			//sb.Append(" AND J.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_J ").Append(Environment.NewLine);
			////	仕入明細データ.更新日時　≦　パラメータ.終了日付
			//sb.Append(" AND J.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_J ").Append(Environment.NewLine);
			// DEL 2011.08.29 -------<<<<<

			//受注マスタ
			sb.Append(" LEFT JOIN ACCEPTODRRF C2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			//	仕入明細データ.企業コード　＝　受注マスタ.企業コード
			sb.Append(" ON I.ENTERPRISECODERF = C2.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	仕入明細データ.仕入形式　＝　受注マスタ.受注ステータス
			sb.Append(" AND ((I.SUPPLIERFORMALRF = 0 AND C2.ACPTANODRSTATUSRF =6)  ").Append(Environment.NewLine);
			sb.Append(" OR (I.SUPPLIERFORMALRF = 1 AND C2.ACPTANODRSTATUSRF =4)  ").Append(Environment.NewLine);
			sb.Append(" OR (I.SUPPLIERFORMALRF = 2 AND C2.ACPTANODRSTATUSRF =2))  ").Append(Environment.NewLine);
			//	仕入明細データ.仕入伝票番号　＝　受注マスタ.伝票番号
			sb.Append(" AND I.SUPPLIERSLIPNORF = C2.SALESSLIPNUMRF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ------->>>>>
			////	受注マスタ.更新日時　>　パラメータ.開始日付
			//sb.Append(" AND C2.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_C2 ").Append(Environment.NewLine);
			////	受注マスタ.更新日時　≦　パラメータ.終了日付
			//sb.Append(" AND C2.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_C2 ").Append(Environment.NewLine);
			// DEL 2011.08.29 -------<<<<<

			//	仕入データ.仕入計上拠点コード　＝　パラメータ.拠点コード
            //sb.Append(" WHERE I.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine); // DEL 2011/11/14 xupz
            sb.Append(" WHERE I.STOCKSECTIONCDRF=@FINDSECTIONCODE ").Append(Environment.NewLine); // ADD 2011/11/14 xupz

            // ----- DEL 2011/11/01 xupz----------<<<<<
            ////	仕入データ.更新日時　>　パラメータ.開始日付
            //sb.Append(" AND I.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_I ").Append(Environment.NewLine);
            ////	仕入データ.更新日時　≦　パラメータ.終了日付
            //sb.Append(" AND I.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
            // ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>
            //データ送信抽出条件区分が「差分」の場合
            if (sendDataWork.SndMesExtraCondDiv == 0) 
            {
			//	仕入データ.更新日時　>　パラメータ.開始日付
			sb.Append(" AND I.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_I ").Append(Environment.NewLine);
			//	仕入データ.更新日時　≦　パラメータ.終了日付
			sb.Append(" AND I.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
            }
            //データ送信抽出条件区分が「伝票日付」の場合
            else if (sendDataWork.SndMesExtraCondDiv == 1) 
            {
                //-----Add 2011/11/11 陳建明 for #26228 start----->>>>>
                //1:入荷=>入荷日付
                //sb.Append(" AND ((I.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine);// DEL 2011/11/30
                sb.Append(" AND (((I.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine); // ADD 2011/11/30
                //	仕入データ.入荷日付　≧　パラメータ.開始日付
                sb.Append(" AND I.ARRIVALGOODSDAYRF>=@FINDUPDATESTARTDATETIME_I").Append(Environment.NewLine);
                //	仕入データ.入荷日付　≦　パラメータ.終了日付
                sb.Append(" AND I.ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
                sb.Append(" ) OR ").Append(Environment.NewLine);
                //0:仕入,2:発注=>仕入日付
                sb.Append(" (I.SUPPLIERFORMALRF<>1 ").Append(Environment.NewLine);
                //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<<    
                //	仕入データ.仕入日　≧　パラメータ.開始日付
                sb.Append(" AND I.STOCKDATERF>=@FINDUPDATESTARTDATETIME_I ").Append(Environment.NewLine);
                //	仕入データ.仕入日　≦　パラメータ.終了日付
                sb.Append(" AND I.STOCKDATERF<=@FINDUPDATEENDDATETIME_I ").Append(Environment.NewLine);
                sb.Append(" ))");//Add 2011/11/11 陳建明 for #26228

                // ----- ADD 2011/11/30 tanh---------->>>>>
                // --- UPD 2014/02/20 Y.Wakita ---------->>>>>
                //sb.Append("    OR ((I.UPDATEDATETIMERF >= @FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                sb.Append("    OR ((I.UPDATEDATETIMERF > @FINDSYNCEXECDATERF) ").Append(Environment.NewLine);
                // --- UPD 2014/02/20 Y.Wakita ----------<<<<<
                sb.Append("       AND (I.UPDATEDATETIMERF <= @FINDENDTIMERF) ").Append(Environment.NewLine);
                sb.Append("       AND (((I.SUPPLIERFORMALRF=1) ").Append(Environment.NewLine);
                sb.Append("           AND (I.ARRIVALGOODSDAYRF<=@FINDUPDATEENDDATETIME_I)) ").Append(Environment.NewLine);
                sb.Append("            OR ((I.SUPPLIERFORMALRF<>1) ").Append(Environment.NewLine);
                sb.Append("           AND (I.STOCKDATERF<=@FINDUPDATEENDDATETIME_I))))) ").Append(Environment.NewLine);
                // ----- ADD 2011/11/30 tanh----------<<<<<
            }
            // ----- ADD 2011/11/01 xupz----------<<<<<

			// DEL 2011.08.29 ------>>>>>
			//sb.Append(" ORDER BY ").Append(Environment.NewLine);
			//sb.Append(" I_ENTERPRISECODERF ").Append(Environment.NewLine);
			//sb.Append(" ,I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//sb.Append(" ,I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			//sb.Append(" ,J_SUPPLIERFORMALRF  ").Append(Environment.NewLine);
			//sb.Append(" ,J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_SECTIONCODERF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_COMMONSEQNORF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			//sb.Append(" ,C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			// DEL 2011.08.29 ------<<<<<
			// ADD 2011.08.29 ------>>>>>

            // ----- DEL K2011/11/01 xupz---------->>>>>
            //sb.Append(" UNION ").Append(Environment.NewLine);
            ////仕入データ
            //sb.Append(" SELECT I.CREATEDATETIMERF as I_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDATEDATETIMERF as I_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ENTERPRISECODERF as I_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.FILEHEADERGUIDRF as I_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDEMPLOYEECODERF as I_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDASSEMBLYID1RF as I_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UPDASSEMBLYID2RF as I_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.LOGICALDELETECODERF as I_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERFORMALRF as I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPNORF as I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SECTIONCODERF as I_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUBSECTIONCODERF as I_SUBSECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DEBITNOTEDIVRF as I_DEBITNOTEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DEBITNLNKSUPPSLIPNORF as I_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPCDRF as I_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKGOODSCDRF as I_STOCKGOODSCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ACCPAYDIVCDRF as I_ACCPAYDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSECTIONCDRF as I_STOCKSECTIONCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKADDUPSECTIONCDRF as I_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSLIPUPDATECDRF as I_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.INPUTDAYRF as I_INPUTDAYRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ARRIVALGOODSDAYRF as I_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKDATERF as I_STOCKDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKADDUPADATERF as I_STOCKADDUPADATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DELAYPAYMENTDIVRF as I_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.PAYEECODERF as I_PAYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.PAYEESNMRF as I_PAYEESNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERCDRF as I_SUPPLIERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERNM1RF as I_SUPPLIERNM1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERNM2RF as I_SUPPLIERNM2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSNMRF as I_SUPPLIERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.BUSINESSTYPECODERF as I_BUSINESSTYPECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.BUSINESSTYPENAMERF as I_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SALESAREACODERF as I_SALESAREACODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SALESAREANAMERF as I_SALESAREANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKINPUTCODERF as I_STOCKINPUTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKINPUTNAMERF as I_STOCKINPUTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKAGENTCODERF as I_STOCKAGENTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKAGENTNAMERF as I_STOCKAGENTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPTTLAMNTDSPWAYCDRF as I_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLAMNTDISPRATEAPYRF as I_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKTOTALPRICERF as I_STOCKTOTALPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSUBTTLPRICERF as I_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKTTLPRICTAXINCRF as I_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKTTLPRICTAXEXCRF as I_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKNETPRICERF as I_STOCKNETPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKPRICECONSTAXRF as I_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLITDEDSTCOUTTAXRF as I_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLITDEDSTCINTAXRF as I_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TTLITDEDSTCTAXFREERF as I_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKOUTTAXRF as I_STOCKOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STCKPRCCONSTAXINCLURF as I_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STCKDISTTLTAXEXCRF as I_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ITDEDSTOCKDISOUTTAXRF as I_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ITDEDSTOCKDISINTAXRF as I_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ITDEDSTOCKDISTAXFRERF as I_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKDISOUTTAXRF as I_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STCKDISTTLTAXINCLURF as I_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
            //sb.Append(" ,I.TAXADJUSTRF as I_TAXADJUSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.BALANCEADJUSTRF as I_BALANCEADJUSTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPCTAXLAYCDRF as I_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERCONSTAXRATERF as I_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ACCPAYCONSTAXRF as I_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKFRACTIONPROCCDRF as I_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.AUTOPAYMENTRF as I_AUTOPAYMENTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.AUTOPAYSLIPNUMRF as I_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.RETGOODSREASONDIVRF as I_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.RETGOODSREASONRF as I_RETGOODSREASONRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.PARTYSALESLIPNUMRF as I_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPNOTE1RF as I_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SUPPLIERSLIPNOTE2RF as I_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DETAILROWCOUNTRF as I_DETAILROWCOUNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.EDISENDDATERF as I_EDISENDDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.EDITAKEINDATERF as I_EDITAKEINDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UOEREMARK1RF as I_UOEREMARK1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.UOEREMARK2RF as I_UOEREMARK2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPPRINTDIVCDRF as I_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPPRINTFINISHCDRF as I_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.STOCKSLIPPRINTDATERF as I_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPPRTSETPAPERIDRF as I_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.SLIPADDRESSDIVRF as I_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEECODERF as I_ADDRESSEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEENAMERF as I_ADDRESSEENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEENAME2RF as I_ADDRESSEENAME2RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEPOSTNORF as I_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEADDR1RF as I_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEADDR3RF as I_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEADDR4RF as I_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEETELNORF as I_ADDRESSEETELNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.ADDRESSEEFAXNORF as I_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
            //sb.Append(" ,I.DIRECTSENDINGCDRF as I_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
            ////仕入明細データ
            //sb.Append(" ,J.CREATEDATETIMERF as J_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDATEDATETIMERF as J_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ENTERPRISECODERF as J_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.FILEHEADERGUIDRF as J_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDEMPLOYEECODERF as J_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDASSEMBLYID1RF as J_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UPDASSEMBLYID2RF as J_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.LOGICALDELETECODERF as J_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ACCEPTANORDERNORF as J_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERFORMALRF as J_SUPPLIERFORMALRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERSLIPNORF as J_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKROWNORF as J_STOCKROWNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SECTIONCODERF as J_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUBSECTIONCODERF as J_SUBSECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.COMMONSEQNORF as J_COMMONSEQNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKSLIPDTLNUMRF as J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERFORMALSRCRF as J_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKSLIPDTLNUMSRCRF as J_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ACPTANODRSTATUSSYNCRF as J_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SALESSLIPDTLNUMSYNCRF as J_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKSLIPCDDTLRF as J_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKINPUTCODERF as J_STOCKINPUTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKINPUTNAMERF as J_STOCKINPUTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKAGENTCODERF as J_STOCKAGENTCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKAGENTNAMERF as J_STOCKAGENTNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSKINDCODERF as J_GOODSKINDCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSMAKERCDRF as J_GOODSMAKERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.MAKERNAMERF as J_MAKERNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.MAKERKANANAMERF as J_MAKERKANANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.CMPLTMAKERKANANAMERF as J_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSNORF as J_GOODSNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSNAMERF as J_GOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSNAMEKANARF as J_GOODSNAMEKANARF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSLGROUPRF as J_GOODSLGROUPRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSLGROUPNAMERF as J_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSMGROUPRF as J_GOODSMGROUPRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSMGROUPNAMERF as J_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGROUPCODERF as J_BLGROUPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGROUPNAMERF as J_BLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGOODSCODERF as J_BLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BLGOODSFULLNAMERF as J_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ENTERPRISEGANRECODERF as J_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ENTERPRISEGANRENAMERF as J_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAREHOUSECODERF as J_WAREHOUSECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAREHOUSENAMERF as J_WAREHOUSENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAREHOUSESHELFNORF as J_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKORDERDIVCDRF as J_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.OPENPRICEDIVRF as J_OPENPRICEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.GOODSRATERANKRF as J_GOODSRATERANKRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.CUSTRATEGRPCODERF as J_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPRATEGRPCODERF as J_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.LISTPRICETAXEXCFLRF as J_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.LISTPRICETAXINCFLRF as J_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKRATERF as J_STOCKRATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATESECTSTCKUNPRCRF as J_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEDIVSTCKUNPRCRF as J_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.UNPRCCALCCDSTCKUNPRCRF as J_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.PRICECDSTCKUNPRCRF as J_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STDUNPRCSTCKUNPRCRF as J_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.FRACPROCUNITSTCUNPRCRF as J_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.FRACPROCSTCKUNPRCRF as J_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKUNITPRICEFLRF as J_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKUNITTAXPRICEFLRF as J_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKUNITCHNGDIVRF as J_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BFSTOCKUNITPRICEFLRF as J_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.BFLISTPRICERF as J_BFLISTPRICERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGOODSCODERF as J_RATEBLGOODSCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGOODSNAMERF as J_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEGOODSRATEGRPCDRF as J_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEGOODSRATEGRPNMRF as J_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGROUPCODERF as J_RATEBLGROUPCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.RATEBLGROUPNAMERF as J_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKCOUNTRF as J_STOCKCOUNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERCNTRF as J_ORDERCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERADJUSTCNTRF as J_ORDERADJUSTCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERREMAINCNTRF as J_ORDERREMAINCNTRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.REMAINCNTUPDDATERF as J_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKPRICETAXEXCRF as J_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKPRICETAXINCRF as J_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKGOODSCDRF as J_STOCKGOODSCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKPRICECONSTAXRF as J_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.TAXATIONCODERF as J_TAXATIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.STOCKDTISLIPNOTE1RF as J_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SALESCUSTOMERCODERF as J_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SALESCUSTOMERSNMRF as J_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SLIPMEMO1RF as J_SLIPMEMO1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SLIPMEMO2RF as J_SLIPMEMO2RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SLIPMEMO3RF as J_SLIPMEMO3RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.INSIDEMEMO1RF as J_INSIDEMEMO1RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.INSIDEMEMO2RF as J_INSIDEMEMO2RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.INSIDEMEMO3RF as J_INSIDEMEMO3RF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERCDRF as J_SUPPLIERCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.SUPPLIERSNMRF as J_SUPPLIERSNMRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ADDRESSEECODERF as J_ADDRESSEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ADDRESSEENAMERF as J_ADDRESSEENAMERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.DIRECTSENDINGCDRF as J_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERNUMBERRF as J_ORDERNUMBERRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.WAYTOORDERRF as J_WAYTOORDERRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.DELIGDSCMPLTDUEDATERF as J_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.EXPECTDELIVERYDATERF as J_EXPECTDELIVERYDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERDATACREATEDIVRF as J_ORDERDATACREATEDIVRF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERDATACREATEDATERF as J_ORDERDATACREATEDATERF ").Append(Environment.NewLine);
            //sb.Append(" ,J.ORDERFORMISSUEDDIVRF  as J_ORDERFORMISSUEDDIVRF  ").Append(Environment.NewLine);
            ////受注マスタ
            //sb.Append(" ,C2.CREATEDATETIMERF as C2_CREATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDATEDATETIMERF as C2_UPDATEDATETIMERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.ENTERPRISECODERF as C2_ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.FILEHEADERGUIDRF as C2_FILEHEADERGUIDRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDEMPLOYEECODERF as C2_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDASSEMBLYID1RF as C2_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.UPDASSEMBLYID2RF as C2_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.LOGICALDELETECODERF as C2_LOGICALDELETECODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SECTIONCODERF as C2_SECTIONCODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.ACCEPTANORDERNORF as C2_ACCEPTANORDERNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.ACPTANODRSTATUSRF as C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SALESSLIPNUMRF as C2_SALESSLIPNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.DATAINPUTSYSTEMRF as C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.COMMONSEQNORF as C2_COMMONSEQNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SLIPDTLNUMRF as C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SLIPDTLNUMDERIVNORF as C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SRCLINKDATACODERF as C2_SRCLINKDATACODERF ").Append(Environment.NewLine);
            //sb.Append(" ,C2.SRCSLIPDTLNUMRF as C2_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);

            //sb.Append(" FROM STOCKSLIPRF I WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            ////仕入明細データ
            //sb.Append(" INNER JOIN STOCKDETAILRF J WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
            ////	仕入データ.企業コード　＝　仕入明細データ.企業コード
            //sb.Append(" ON I.ENTERPRISECODERF = J.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	仕入データ.仕入形式　＝　仕入明細データ.仕入形式
            //sb.Append(" AND I.SUPPLIERFORMALRF = J.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            ////	仕入データ.仕入伝票番号　＝　仕入明細データ.仕入伝票番号
            //sb.Append(" AND I.SUPPLIERSLIPNORF = J.SUPPLIERSLIPNORF ").Append(Environment.NewLine);

            ////受注マスタ
            //sb.Append(" LEFT JOIN ACCEPTODRRF C2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            ////	仕入明細データ.企業コード　＝　受注マスタ.企業コード
            //sb.Append(" ON I.ENTERPRISECODERF = C2.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	仕入明細データ.仕入形式　＝　受注マスタ.受注ステータス
            //sb.Append(" AND ((I.SUPPLIERFORMALRF = 0 AND C2.ACPTANODRSTATUSRF =6)  ").Append(Environment.NewLine);
            //sb.Append(" OR (I.SUPPLIERFORMALRF = 1 AND C2.ACPTANODRSTATUSRF =4)  ").Append(Environment.NewLine);
            //sb.Append(" OR (I.SUPPLIERFORMALRF = 2 AND C2.ACPTANODRSTATUSRF =2))  ").Append(Environment.NewLine);
            ////	仕入明細データ.仕入伝票番号　＝　受注マスタ.伝票番号
            //sb.Append(" AND I.SUPPLIERSLIPNORF = C2.SALESSLIPNUMRF ").Append(Environment.NewLine);

            ////仮仕入データ
            //sb.Append(" INNER JOIN (  ").Append(Environment.NewLine);
            //sb.Append("    SELECT DISTINCT SSLIPRF.ENTERPRISECODERF ").Append(Environment.NewLine);
            //sb.Append("    ,SSLIPRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            //sb.Append("    ,SSLIPRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //sb.Append("    FROM STOCKSLIPRF SSLIPRF ").Append(Environment.NewLine);
            //sb.Append("    INNER JOIN STOCKDETAILRF SSLIPDTLRF ").Append(Environment.NewLine);
            ////	仕入データ.企業コード　＝　仕入明細データ.企業コード
            //sb.Append("    ON SSLIPRF.ENTERPRISECODERF = SSLIPDTLRF.ENTERPRISECODERF  ").Append(Environment.NewLine);
            ////	仕入データ.仕入形式　＝　仕入明細データ.仕入形式
            //sb.Append("    AND SSLIPRF.SUPPLIERFORMALRF = SSLIPDTLRF.SUPPLIERFORMALRF  ").Append(Environment.NewLine);
            ////	仕入データ.仕入伝票番号　＝　仕入明細データ.仕入伝票番号			
            //sb.Append("    AND SSLIPRF.SUPPLIERSLIPNORF = SSLIPDTLRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            ////	仕入データ.仕入計上拠点コード　＝　パラメータ.拠点コード
            //sb.Append("    WHERE SSLIPRF.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE_SSLIPRF ").Append(Environment.NewLine);

            ////	仕入明細データ.更新日時　>　パラメータ.開始日付
            //sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_SSLIPRF ").Append(Environment.NewLine);
            ////	仕入明細データ.更新日時　≦　パラメータ.終了日付
            //sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_SSLIPRF ").Append(Environment.NewLine);

            //sb.Append(" )AS II").Append(Environment.NewLine);

            ////	仕入データ.企業コード　＝　仮仕入データ.企業コード　
            //sb.Append(" ON I.ENTERPRISECODERF = II.ENTERPRISECODERF ").Append(Environment.NewLine);
            ////	仕入データ.仕入形式　＝　仮仕入データ.仕入形式
            //sb.Append(" AND I.SUPPLIERFORMALRF = II.SUPPLIERFORMALRF ").Append(Environment.NewLine);
            ////	仕入データ.仕入伝票番号　＝　仮仕入データ.仕入伝票番号	
            //sb.Append(" AND I.SUPPLIERSLIPNORF = II.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
            //// ----- DEL 2011/11/01 xupz----------<<<<<

            // ----- ADD 2011/11/01 xupz---------->>>>>
            //データ送信抽出条件区分が「差分」の場合
            if(sendDataWork.SndMesExtraCondDiv == 0)
            {
			sb.Append(" UNION ").Append(Environment.NewLine);
			//仕入データ
			sb.Append(" SELECT I.CREATEDATETIMERF as I_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDATEDATETIMERF as I_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ENTERPRISECODERF as I_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.FILEHEADERGUIDRF as I_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDEMPLOYEECODERF as I_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDASSEMBLYID1RF as I_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.UPDASSEMBLYID2RF as I_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.LOGICALDELETECODERF as I_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERFORMALRF as I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNORF as I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.SECTIONCODERF as I_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUBSECTIONCODERF as I_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.DEBITNOTEDIVRF as I_DEBITNOTEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.DEBITNLNKSUPPSLIPNORF as I_DEBITNLNKSUPPSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPCDRF as I_SUPPLIERSLIPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKGOODSCDRF as I_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ACCPAYDIVCDRF as I_ACCPAYDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSECTIONCDRF as I_STOCKSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKADDUPSECTIONCDRF as I_STOCKADDUPSECTIONCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSLIPUPDATECDRF as I_STOCKSLIPUPDATECDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.INPUTDAYRF as I_INPUTDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ARRIVALGOODSDAYRF as I_ARRIVALGOODSDAYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKDATERF as I_STOCKDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKADDUPADATERF as I_STOCKADDUPADATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.DELAYPAYMENTDIVRF as I_DELAYPAYMENTDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.PAYEECODERF as I_PAYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.PAYEESNMRF as I_PAYEESNMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERCDRF as I_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERNM1RF as I_SUPPLIERNM1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERNM2RF as I_SUPPLIERNM2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSNMRF as I_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.BUSINESSTYPECODERF as I_BUSINESSTYPECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.BUSINESSTYPENAMERF as I_BUSINESSTYPENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SALESAREACODERF as I_SALESAREACODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SALESAREANAMERF as I_SALESAREANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKINPUTCODERF as I_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKINPUTNAMERF as I_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKAGENTCODERF as I_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKAGENTNAMERF as I_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPTTLAMNTDSPWAYCDRF as I_SUPPTTLAMNTDSPWAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLAMNTDISPRATEAPYRF as I_TTLAMNTDISPRATEAPYRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTOTALPRICERF as I_STOCKTOTALPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSUBTTLPRICERF as I_STOCKSUBTTLPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTTLPRICTAXINCRF as I_STOCKTTLPRICTAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKTTLPRICTAXEXCRF as I_STOCKTTLPRICTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKNETPRICERF as I_STOCKNETPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKPRICECONSTAXRF as I_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCOUTTAXRF as I_TTLITDEDSTCOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCINTAXRF as I_TTLITDEDSTCINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.TTLITDEDSTCTAXFREERF as I_TTLITDEDSTCTAXFREERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKOUTTAXRF as I_STOCKOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKPRCCONSTAXINCLURF as I_STCKPRCCONSTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKDISTTLTAXEXCRF as I_STCKDISTTLTAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISOUTTAXRF as I_ITDEDSTOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISINTAXRF as I_ITDEDSTOCKDISINTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ITDEDSTOCKDISTAXFRERF as I_ITDEDSTOCKDISTAXFRERF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKDISOUTTAXRF as I_STOCKDISOUTTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STCKDISTTLTAXINCLURF as I_STCKDISTTLTAXINCLURF ").Append(Environment.NewLine);
			sb.Append(" ,I.TAXADJUSTRF as I_TAXADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.BALANCEADJUSTRF as I_BALANCEADJUSTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPCTAXLAYCDRF as I_SUPPCTAXLAYCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERCONSTAXRATERF as I_SUPPLIERCONSTAXRATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ACCPAYCONSTAXRF as I_ACCPAYCONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKFRACTIONPROCCDRF as I_STOCKFRACTIONPROCCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.AUTOPAYMENTRF as I_AUTOPAYMENTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.AUTOPAYSLIPNUMRF as I_AUTOPAYSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.RETGOODSREASONDIVRF as I_RETGOODSREASONDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.RETGOODSREASONRF as I_RETGOODSREASONRF ").Append(Environment.NewLine);
			sb.Append(" ,I.PARTYSALESLIPNUMRF as I_PARTYSALESLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNOTE1RF as I_SUPPLIERSLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SUPPLIERSLIPNOTE2RF as I_SUPPLIERSLIPNOTE2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.DETAILROWCOUNTRF as I_DETAILROWCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,I.EDISENDDATERF as I_EDISENDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.EDITAKEINDATERF as I_EDITAKEINDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.UOEREMARK1RF as I_UOEREMARK1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.UOEREMARK2RF as I_UOEREMARK2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRINTDIVCDRF as I_SLIPPRINTDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRINTFINISHCDRF as I_SLIPPRINTFINISHCDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.STOCKSLIPPRINTDATERF as I_STOCKSLIPPRINTDATERF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPPRTSETPAPERIDRF as I_SLIPPRTSETPAPERIDRF ").Append(Environment.NewLine);
			sb.Append(" ,I.SLIPADDRESSDIVRF as I_SLIPADDRESSDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEECODERF as I_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEENAMERF as I_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEENAME2RF as I_ADDRESSEENAME2RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEPOSTNORF as I_ADDRESSEEPOSTNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR1RF as I_ADDRESSEEADDR1RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR3RF as I_ADDRESSEEADDR3RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEADDR4RF as I_ADDRESSEEADDR4RF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEETELNORF as I_ADDRESSEETELNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.ADDRESSEEFAXNORF as I_ADDRESSEEFAXNORF ").Append(Environment.NewLine);
			sb.Append(" ,I.DIRECTSENDINGCDRF as I_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
			//仕入明細データ
			sb.Append(" ,J.CREATEDATETIMERF as J_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDATEDATETIMERF as J_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISECODERF as J_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.FILEHEADERGUIDRF as J_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDEMPLOYEECODERF as J_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDASSEMBLYID1RF as J_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.UPDASSEMBLYID2RF as J_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.LOGICALDELETECODERF as J_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ACCEPTANORDERNORF as J_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERFORMALRF as J_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERSLIPNORF as J_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKROWNORF as J_STOCKROWNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.SECTIONCODERF as J_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUBSECTIONCODERF as J_SUBSECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.COMMONSEQNORF as J_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPDTLNUMRF as J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERFORMALSRCRF as J_SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPDTLNUMSRCRF as J_STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ACPTANODRSTATUSSYNCRF as J_ACPTANODRSTATUSSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESSLIPDTLNUMSYNCRF as J_SALESSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKSLIPCDDTLRF as J_STOCKSLIPCDDTLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKINPUTCODERF as J_STOCKINPUTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKINPUTNAMERF as J_STOCKINPUTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKAGENTCODERF as J_STOCKAGENTCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKAGENTNAMERF as J_STOCKAGENTNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSKINDCODERF as J_GOODSKINDCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMAKERCDRF as J_GOODSMAKERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.MAKERNAMERF as J_MAKERNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.MAKERKANANAMERF as J_MAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.CMPLTMAKERKANANAMERF as J_CMPLTMAKERKANANAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNORF as J_GOODSNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNAMERF as J_GOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSNAMEKANARF as J_GOODSNAMEKANARF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSLGROUPRF as J_GOODSLGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSLGROUPNAMERF as J_GOODSLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMGROUPRF as J_GOODSMGROUPRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSMGROUPNAMERF as J_GOODSMGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGROUPCODERF as J_BLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGROUPNAMERF as J_BLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGOODSCODERF as J_BLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.BLGOODSFULLNAMERF as J_BLGOODSFULLNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISEGANRECODERF as J_ENTERPRISEGANRECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ENTERPRISEGANRENAMERF as J_ENTERPRISEGANRENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSECODERF as J_WAREHOUSECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSENAMERF as J_WAREHOUSENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAREHOUSESHELFNORF as J_WAREHOUSESHELFNORF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKORDERDIVCDRF as J_STOCKORDERDIVCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.OPENPRICEDIVRF as J_OPENPRICEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.GOODSRATERANKRF as J_GOODSRATERANKRF ").Append(Environment.NewLine);
			sb.Append(" ,J.CUSTRATEGRPCODERF as J_CUSTRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPRATEGRPCODERF as J_SUPPRATEGRPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.LISTPRICETAXEXCFLRF as J_LISTPRICETAXEXCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.LISTPRICETAXINCFLRF as J_LISTPRICETAXINCFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKRATERF as J_STOCKRATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATESECTSTCKUNPRCRF as J_RATESECTSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEDIVSTCKUNPRCRF as J_RATEDIVSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.UNPRCCALCCDSTCKUNPRCRF as J_UNPRCCALCCDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.PRICECDSTCKUNPRCRF as J_PRICECDSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STDUNPRCSTCKUNPRCRF as J_STDUNPRCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.FRACPROCUNITSTCUNPRCRF as J_FRACPROCUNITSTCUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.FRACPROCSTCKUNPRCRF as J_FRACPROCSTCKUNPRCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITPRICEFLRF as J_STOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITTAXPRICEFLRF as J_STOCKUNITTAXPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKUNITCHNGDIVRF as J_STOCKUNITCHNGDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.BFSTOCKUNITPRICEFLRF as J_BFSTOCKUNITPRICEFLRF ").Append(Environment.NewLine);
			sb.Append(" ,J.BFLISTPRICERF as J_BFLISTPRICERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGOODSCODERF as J_RATEBLGOODSCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGOODSNAMERF as J_RATEBLGOODSNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEGOODSRATEGRPCDRF as J_RATEGOODSRATEGRPCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEGOODSRATEGRPNMRF as J_RATEGOODSRATEGRPNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGROUPCODERF as J_RATEBLGROUPCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.RATEBLGROUPNAMERF as J_RATEBLGROUPNAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKCOUNTRF as J_STOCKCOUNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERCNTRF as J_ORDERCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERADJUSTCNTRF as J_ORDERADJUSTCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERREMAINCNTRF as J_ORDERREMAINCNTRF ").Append(Environment.NewLine);
			sb.Append(" ,J.REMAINCNTUPDDATERF as J_REMAINCNTUPDDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICETAXEXCRF as J_STOCKPRICETAXEXCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICETAXINCRF as J_STOCKPRICETAXINCRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKGOODSCDRF as J_STOCKGOODSCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKPRICECONSTAXRF as J_STOCKPRICECONSTAXRF ").Append(Environment.NewLine);
			sb.Append(" ,J.TAXATIONCODERF as J_TAXATIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.STOCKDTISLIPNOTE1RF as J_STOCKDTISLIPNOTE1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESCUSTOMERCODERF as J_SALESCUSTOMERCODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.SALESCUSTOMERSNMRF as J_SALESCUSTOMERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO1RF as J_SLIPMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO2RF as J_SLIPMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SLIPMEMO3RF as J_SLIPMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO1RF as J_INSIDEMEMO1RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO2RF as J_INSIDEMEMO2RF ").Append(Environment.NewLine);
			sb.Append(" ,J.INSIDEMEMO3RF as J_INSIDEMEMO3RF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERCDRF as J_SUPPLIERCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.SUPPLIERSNMRF as J_SUPPLIERSNMRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ADDRESSEECODERF as J_ADDRESSEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ADDRESSEENAMERF as J_ADDRESSEENAMERF ").Append(Environment.NewLine);
			sb.Append(" ,J.DIRECTSENDINGCDRF as J_DIRECTSENDINGCDRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERNUMBERRF as J_ORDERNUMBERRF ").Append(Environment.NewLine);
			sb.Append(" ,J.WAYTOORDERRF as J_WAYTOORDERRF ").Append(Environment.NewLine);
			sb.Append(" ,J.DELIGDSCMPLTDUEDATERF as J_DELIGDSCMPLTDUEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.EXPECTDELIVERYDATERF as J_EXPECTDELIVERYDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERDATACREATEDIVRF as J_ORDERDATACREATEDIVRF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERDATACREATEDATERF as J_ORDERDATACREATEDATERF ").Append(Environment.NewLine);
			sb.Append(" ,J.ORDERFORMISSUEDDIVRF  as J_ORDERFORMISSUEDDIVRF  ").Append(Environment.NewLine);
			//受注マスタ
			sb.Append(" ,C2.CREATEDATETIMERF as C2_CREATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDATEDATETIMERF as C2_UPDATEDATETIMERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ENTERPRISECODERF as C2_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.FILEHEADERGUIDRF as C2_FILEHEADERGUIDRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDEMPLOYEECODERF as C2_UPDEMPLOYEECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDASSEMBLYID1RF as C2_UPDASSEMBLYID1RF ").Append(Environment.NewLine);
			sb.Append(" ,C2.UPDASSEMBLYID2RF as C2_UPDASSEMBLYID2RF ").Append(Environment.NewLine);
			sb.Append(" ,C2.LOGICALDELETECODERF as C2_LOGICALDELETECODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SECTIONCODERF as C2_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ACCEPTANORDERNORF as C2_ACCEPTANORDERNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.ACPTANODRSTATUSRF as C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SALESSLIPNUMRF as C2_SALESSLIPNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.DATAINPUTSYSTEMRF as C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.COMMONSEQNORF as C2_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SLIPDTLNUMRF as C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SLIPDTLNUMDERIVNORF as C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SRCLINKDATACODERF as C2_SRCLINKDATACODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2.SRCSLIPDTLNUMRF as C2_SRCSLIPDTLNUMRF ").Append(Environment.NewLine);

			sb.Append(" FROM STOCKSLIPRF I WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//仕入明細データ
			sb.Append(" INNER JOIN STOCKDETAILRF J WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
			//	仕入データ.企業コード　＝　仕入明細データ.企業コード
			sb.Append(" ON I.ENTERPRISECODERF = J.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	仕入データ.仕入形式　＝　仕入明細データ.仕入形式
			sb.Append(" AND I.SUPPLIERFORMALRF = J.SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//	仕入データ.仕入伝票番号　＝　仕入明細データ.仕入伝票番号
			sb.Append(" AND I.SUPPLIERSLIPNORF = J.SUPPLIERSLIPNORF ").Append(Environment.NewLine);

			//受注マスタ
			sb.Append(" LEFT JOIN ACCEPTODRRF C2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
			//	仕入明細データ.企業コード　＝　受注マスタ.企業コード
			sb.Append(" ON I.ENTERPRISECODERF = C2.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	仕入明細データ.仕入形式　＝　受注マスタ.受注ステータス
			sb.Append(" AND ((I.SUPPLIERFORMALRF = 0 AND C2.ACPTANODRSTATUSRF =6)  ").Append(Environment.NewLine);
			sb.Append(" OR (I.SUPPLIERFORMALRF = 1 AND C2.ACPTANODRSTATUSRF =4)  ").Append(Environment.NewLine);
			sb.Append(" OR (I.SUPPLIERFORMALRF = 2 AND C2.ACPTANODRSTATUSRF =2))  ").Append(Environment.NewLine);
			//	仕入明細データ.仕入伝票番号　＝　受注マスタ.伝票番号
			sb.Append(" AND I.SUPPLIERSLIPNORF = C2.SALESSLIPNUMRF ").Append(Environment.NewLine);

			//仮仕入データ
			sb.Append(" INNER JOIN (  ").Append(Environment.NewLine);
			sb.Append("    SELECT DISTINCT SSLIPRF.ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append("    ,SSLIPRF.SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append("    ,SSLIPRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append("    FROM STOCKSLIPRF SSLIPRF ").Append(Environment.NewLine);
			sb.Append("    INNER JOIN STOCKDETAILRF SSLIPDTLRF ").Append(Environment.NewLine);
			//	仕入データ.企業コード　＝　仕入明細データ.企業コード
			sb.Append("    ON SSLIPRF.ENTERPRISECODERF = SSLIPDTLRF.ENTERPRISECODERF  ").Append(Environment.NewLine);
			//	仕入データ.仕入形式　＝　仕入明細データ.仕入形式
			sb.Append("    AND SSLIPRF.SUPPLIERFORMALRF = SSLIPDTLRF.SUPPLIERFORMALRF  ").Append(Environment.NewLine);
			//	仕入データ.仕入伝票番号　＝　仕入明細データ.仕入伝票番号			
			sb.Append("    AND SSLIPRF.SUPPLIERSLIPNORF = SSLIPDTLRF.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			//	仕入データ.仕入計上拠点コード　＝　パラメータ.拠点コード
            //sb.Append("    WHERE SSLIPRF.STOCKADDUPSECTIONCDRF=@FINDSECTIONCODE_SSLIPRF ").Append(Environment.NewLine); // DEL 2011/11/14 xupz
            sb.Append("    WHERE SSLIPRF.STOCKSECTIONCDRF=@FINDSECTIONCODE_SSLIPRF ").Append(Environment.NewLine); // ADD 2011/11/14 xupz
			//	仕入明細データ.更新日時　>　パラメータ.開始日付
			sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME_SSLIPRF ").Append(Environment.NewLine);
			//	仕入明細データ.更新日時　≦　パラメータ.終了日付
			sb.Append("    AND SSLIPDTLRF.UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME_SSLIPRF ").Append(Environment.NewLine);
			sb.Append(" )AS II").Append(Environment.NewLine);

			//	仕入データ.企業コード　＝　仮仕入データ.企業コード　
			sb.Append(" ON I.ENTERPRISECODERF = II.ENTERPRISECODERF ").Append(Environment.NewLine);
			//	仕入データ.仕入形式　＝　仮仕入データ.仕入形式
			sb.Append(" AND I.SUPPLIERFORMALRF = II.SUPPLIERFORMALRF ").Append(Environment.NewLine);
			//	仕入データ.仕入伝票番号　＝　仮仕入データ.仕入伝票番号	
			sb.Append(" AND I.SUPPLIERSLIPNORF = II.SUPPLIERSLIPNORF ").Append(Environment.NewLine);

            }
            // ----- ADD 2011/11/01 xupz----------<<<<<

			sb.Append(" ORDER BY ").Append(Environment.NewLine);
			sb.Append(" I_ENTERPRISECODERF ").Append(Environment.NewLine);
			sb.Append(" ,I_SUPPLIERFORMALRF ").Append(Environment.NewLine);
			sb.Append(" ,I_SUPPLIERSLIPNORF ").Append(Environment.NewLine);
			sb.Append(" ,J_SUPPLIERFORMALRF  ").Append(Environment.NewLine);
			sb.Append(" ,J_STOCKSLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_SECTIONCODERF ").Append(Environment.NewLine);
			sb.Append(" ,C2_ACPTANODRSTATUSRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_DATAINPUTSYSTEMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_COMMONSEQNORF ").Append(Environment.NewLine);
			sb.Append(" ,C2_SLIPDTLNUMRF ").Append(Environment.NewLine);
			sb.Append(" ,C2_SLIPDTLNUMDERIVNORF ").Append(Environment.NewLine);

			sqlText = sb.ToString();
			// ADD 2011.08.29 ------<<<<<

			//Prameterオブジェクトの作成
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_I = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_I", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_I = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_I", SqlDbType.BigInt);
			// ADD 2011.08.29 ------>>>>>
			SqlParameter findParaSectionCode_sslip = sqlCommand.Parameters.Add("@FINDSECTIONCODE_SSLIPRF", SqlDbType.NChar);
			SqlParameter findParaUpdateStartDateTime_sslip = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_SSLIPRF", SqlDbType.BigInt);
			SqlParameter findParaUpdateEndDateTime_sslip = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_SSLIPRF", SqlDbType.BigInt);
			// ADD 2011.08.29 ------<<<<<

			// DEL 2011.08.29 ------->>>>>
			//SqlParameter findParaUpdateStartDateTime_C2 = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_C2", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_C2 = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_C2", SqlDbType.BigInt);
			//SqlParameter findParaUpdateStartDateTime_J = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME_J", SqlDbType.BigInt);
			//SqlParameter findParaUpdateEndDateTime_J = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME_J", SqlDbType.BigInt);
			// DEL 2011.08.29 -------<<<<<

			//Parameterオブジェクトへ値設定
			findParaSectionCode.Value = sendDataWork.PmSectionCode;
			findParaUpdateStartDateTime_I.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_I.Value = sendDataWork.EndDateTime;
			// ADD 2011.08.29 ------>>>>>
			findParaSectionCode_sslip.Value = sendDataWork.PmSectionCode;
			findParaUpdateStartDateTime_sslip.Value = sendDataWork.StartDateTime;
			findParaUpdateEndDateTime_sslip.Value = sendDataWork.EndDateTime;
			// ADD 2011.08.29 ------<<<<<

			// DEL 2011.08.29 ------->>>>>
			//findParaUpdateStartDateTime_C2.Value = sendDataWork.StartDateTime;
			//findParaUpdateEndDateTime_C2.Value = sendDataWork.EndDateTime;
			//findParaUpdateStartDateTime_J.Value = sendDataWork.StartDateTime;
			//findParaUpdateEndDateTime_J.Value = sendDataWork.EndDateTime;
			// DEL 2011.08.29 -------<<<<<

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

			ArrayList stockSlipList = new ArrayList();
			ArrayList stockDtlList = new ArrayList();
			ArrayList acceptodrList = new ArrayList();
			APStockDetailDB aPSalesHistDtlDB = new APStockDetailDB();
			APAcceptOdrDB aPAcceptOdrDB = new APAcceptOdrDB();
			APStockSlipWork tmpWorkI = new APStockSlipWork();
			APStockDetailWork tmpWorkJ = new APStockDetailWork();
			APAcceptOdrWork tmpWorkC = new APAcceptOdrWork();

			Dictionary<string, string> stockSlipDic = new Dictionary<string, string>();
			Dictionary<string, string> stockDtlDic = new Dictionary<string, string>();
			Dictionary<string, string> accOdrDic = new Dictionary<string, string>();

			while (myReader.Read())
			{
				//	仕入データ
				tmpWorkI = this.CopyToStockSlipWorkFromReaderSCM(ref myReader, "I_");
				string workI_key = tmpWorkI.EnterpriseCode + tmpWorkI.SupplierFormal.ToString() + tmpWorkI.SupplierSlipNo.ToString();
				if (!string.Empty.Equals(tmpWorkI.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkI.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkI.SupplierSlipNo.ToString())
					&& !stockSlipDic.ContainsKey(workI_key))
				{
					stockSlipDic.Add(workI_key, workI_key);
					stockSlipList.Add(tmpWorkI);
				}
				//	仕入明細データ
				tmpWorkJ = aPSalesHistDtlDB.CopyToStockDetailWorkFromReaderSCM(ref myReader, "J_");
				string workJ_key = tmpWorkJ.EnterpriseCode + tmpWorkJ.SupplierFormal.ToString() + tmpWorkJ.StockSlipDtlNum.ToString();
				if (!string.Empty.Equals(tmpWorkJ.EnterpriseCode)
					&& !string.Empty.Equals(tmpWorkJ.SupplierFormal.ToString())
					&& !string.Empty.Equals(tmpWorkJ.StockSlipDtlNum.ToString())
					&& !stockDtlDic.ContainsKey(workJ_key))
				{
					stockDtlDic.Add(workJ_key, workJ_key);
					stockDtlList.Add(tmpWorkJ);
				}
				// 受注マスタ
				tmpWorkC = aPAcceptOdrDB.CopyToAcceptOdrWorkFromReaderSCM(ref myReader, "C2_");
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
			}

			// 仕入要否フラグ
			if (sendDataWork.DoSalesSlipFlg)
			{
				resultList.Add(stockSlipList);
			}
			// 仕入明細否フラグ
			if (sendDataWork.DoStockDetailFlg)
			{
				//resultList.Add(stockDtlList); // DEL 2011.09.08
				//outSstockDtlList = stockDtlList; // ADD 2011.09.08 // DEL 2011/09/15
				resultList.Add(stockDtlList); // ADD 2011/09/15
			}
			// 受注マスタ要否フラグ
			if (sendDataWork.DoAcceptOdrFlg)
			{
				acpOdrList = acceptodrList;
			}

			if (stockSlipList.Count > 0)
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
		/// クラス格納処理 Reader → stockSlipWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		private APStockSlipWork CopyToStockSlipWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APStockSlipWork stockSlipWork = new APStockSlipWork();

			this.CopyToStockSlipWorkFromReaderSCM(ref myReader, ref stockSlipWork, tableNm);

			return stockSlipWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockSlipWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockSlipWork">stockSlipWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToStockSlipWorkFromReaderSCM(ref SqlDataReader myReader, ref APStockSlipWork stockSlipWork, string tableNm)
		{
			if (myReader != null && stockSlipWork != null)
			{
				# region クラスへ格納
				stockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				stockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				stockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				stockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				stockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				stockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				stockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				stockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				stockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				stockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				stockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				stockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				stockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNOTEDIVRF"));
				stockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DEBITNLNKSUPPSLIPNORF"));
				stockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPCDRF"));
				stockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSCDRF"));
				stockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCPAYDIVCDRF"));
				stockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKSECTIONCDRF"));
				stockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKADDUPSECTIONCDRF"));
				stockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPUPDATECDRF"));
				stockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "INPUTDAYRF"));
				stockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ARRIVALGOODSDAYRF"));
				stockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKDATERF"));
				stockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKADDUPADATERF"));
				stockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DELAYPAYMENTDIVRF"));
				stockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PAYEECODERF"));
				stockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PAYEESNMRF"));
				stockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				stockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM1RF"));
				stockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERNM2RF"));
				stockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				stockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPECODERF"));
				stockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BUSINESSTYPENAMERF"));
				stockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESAREACODERF"));
				stockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESAREANAMERF"));
				stockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTCODERF"));
				stockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTNAMERF"));
				stockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTCODERF"));
				stockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTNAMERF"));
				stockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPTTLAMNTDSPWAYCDRF"));
				stockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TTLAMNTDISPRATEAPYRF"));
				stockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTOTALPRICERF"));
				stockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSUBTTLPRICERF"));
				stockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTTLPRICTAXINCRF"));
				stockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKTTLPRICTAXEXCRF"));
				stockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKNETPRICERF"));
				stockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICECONSTAXRF"));
				stockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCOUTTAXRF"));
				stockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCINTAXRF"));
				stockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TTLITDEDSTCTAXFREERF"));
				stockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKOUTTAXRF"));
				stockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKPRCCONSTAXINCLURF"));
				stockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKDISTTLTAXEXCRF"));
				stockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISOUTTAXRF"));
				stockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISINTAXRF"));
				stockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ITDEDSTOCKDISTAXFRERF"));
				stockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKDISOUTTAXRF"));
				stockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STCKDISTTLTAXINCLURF"));
				stockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "TAXADJUSTRF"));
				stockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "BALANCEADJUSTRF"));
				stockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPCTAXLAYCDRF"));
				stockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCONSTAXRATERF"));
				stockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "ACCPAYCONSTAXRF"));
				stockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKFRACTIONPROCCDRF"));
				stockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYMENTRF"));
				stockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "AUTOPAYSLIPNUMRF"));
				stockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONDIVRF"));
				stockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RETGOODSREASONRF"));
				stockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "PARTYSALESLIPNUMRF"));
				stockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNOTE1RF"));
				stockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNOTE2RF"));
				stockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DETAILROWCOUNTRF"));
				stockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDISENDDATERF"));
				stockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EDITAKEINDATERF"));
				stockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK1RF"));
				stockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UOEREMARK2RF"));
				stockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTDIVCDRF"));
				stockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPPRINTFINISHCDRF"));
				stockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPPRINTDATERF"));
				stockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPPRTSETPAPERIDRF"));
				stockSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SLIPADDRESSDIVRF"));
				stockSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEECODERF"));
				stockSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAMERF"));
				stockSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAME2RF"));
				stockSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEPOSTNORF"));
				stockSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR1RF"));
				stockSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR3RF"));
				stockSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEADDR4RF"));
				stockSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEETELNORF"));
				stockSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEEFAXNORF"));
				stockSlipWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DIRECTSENDINGCDRF"));
				# endregion
			}
		}
		
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
    }
}

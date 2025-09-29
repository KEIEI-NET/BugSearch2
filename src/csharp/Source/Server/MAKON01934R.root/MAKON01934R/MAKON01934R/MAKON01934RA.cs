using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入伝票検索リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入伝票の検索を行うクラスです</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.02.16</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 仕入データファイルレイアウト変更</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.03.26</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 仕入データファイルレイアウト変更</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.19</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 仕入データファイルレイアウト変更・日付関連(Int32→DateTime)</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.14</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: DC.NS用に修正</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.20</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 得意先・仕入先切り分け</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.04.23</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更</br>
    /// <br>Programmer : 20081 疋田　勇人</br>
    /// <br>Date       : 2008.06.24</br>
    /// <br>-------------------------------------------</br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Programmer : 22008 長内　数馬</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SearchStockSlipDB : RemoteDB, ISearchStockSlipDB
    {
        #region[const SQL構文補助]
        // Del 2007.03.26 Saitoh
        //仕入データ項目ID
        //private const string STOCKSLIP_HEADID = " A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF,"
        //                    + " A.UPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.SUPPLIERFORMALRF,"
        //                    + " A.SUPPLIERSLIPNORF, A.PARTYSALESLIPNUMRF, A.STOCKSECTIONCDRF, A.STOCKADDUPSECTIONCDRF, A.STOCKAGENTCODERF,"
        //                    + " A.STOCKAGENTNAMERF, A.CUSTOMERCODERF, A.CUSTOMERNAMERF, A.CUSTOMERNAME2RF, A.PAYEECODERF, A.PAYEENAME1RF,"
        //                    + " A.PAYEENAME2RF, A.PAYMENTDATERF, A.INPUTDAYRF, A.ARRIVALGOODSDAYRF, A.STOCKDATERF, A.STOCKADDUPADATERF,"
        //                    + " A.SUPPLIERSLIPCDRF, A.ACCPAYDIVCDRF, A.DEBITNOTEDIVRF, A.DEBITNLNKSUPPSLIPNORF, A.STOCKTOTALPRICERF,"
        //                    + " A.STOCKSUBTTLPRICERF, A.STOCKTTLDISCOUNTRF, A.TTLITDEDSTOCKOUTTAXRF, A.TTLITDEDSTOCKINTAXRF, A.TTLITDEDSTOCKTAXFREERF,"
        //                    + " A.TTLSTOCKOUTERTAXRF, A.TTLSTOCKINNERTAXRF, A.SUPPCTAXLAYCDRF, A.SUPPLIERCONSTAXRATERF, A.STOCKFRACTIONPROCCDRF,"
        //                    + " A.SUPPLIERSLIPNOTE1RF, A.SUPPLIERSLIPNOTE2RF, A.CARRIEREPCODERF, A.CARRIEREPNAMERF, A.WAREHOUSECODERF,"
        //                    + " A.WAREHOUSENAMERF, A.STOCKGOODSCDRF, A.TAXADJUSTRF, A.BALANCEADJUSTRF, A.TRUSTADDUPSPCDRF, A.RETGOODSREASONDIVRF,"
        //                    + " A.RETGOODSREASONRF ";
        // Del 2007.03.26 Saitoh

        // Add 2007.03.26 Saitoh
        //仕入データ項目ID
        //private const string STOCKSLIP_HEADID = "A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF,"
        //                    + " A.UPDASSEMBLYID1RF, A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.SUPPLIERFORMALRF, A.SUPPLIERSLIPNORF,"
        //                    + " A.PARTYSALESLIPNUMRF, A.STOCKSECTIONCDRF, A.STOCKADDUPSECTIONCDRF, A.STOCKAGENTCODERF, A.STOCKAGENTNAMERF, A.CUSTOMERCODERF,"
        //                    + " A.CUSTOMERNAMERF, A.CUSTOMERNAME2RF, A.PAYEECODERF, A.PAYEENAME1RF, A.PAYEENAME2RF, A.PAYMENTDATERF, A.INPUTDAYRF,"
        //                    + " A.ARRIVALGOODSDAYRF, A.STOCKDATERF, A.STOCKADDUPADATERF, A.SUPPLIERSLIPCDRF, A.ACCPAYDIVCDRF, A.DEBITNOTEDIVRF,"
        //                    + " A.DEBITNLNKSUPPSLIPNORF, A.STOCKTOTALPRICERF, A.STOCKSUBTTLPRICERF, A.STOCKTTLPRICTAXINCRF, A.STOCKTTLPRICTAXEXCRF,"
        //                    + " A.TTLITDEDSTOCKTAXFREERF, A.STOCKPRICECONSTAXRF, A.SUPPCTAXLAYCDRF, A.SUPPLIERCONSTAXRATERF, A.STOCKFRACTIONPROCCDRF,"
        //                    + " A.SUPPTTLAMNTDSPWAYCDRF, A.SUPPLIERSLIPNOTE1RF, A.SUPPLIERSLIPNOTE2RF, A.CARRIEREPCODERF, A.CARRIEREPNAMERF, A.WAREHOUSECODERF,"
        //                    + " A.WAREHOUSENAMERF, A.STOCKGOODSCDRF, A.TAXADJUSTRF, A.BALANCEADJUSTRF, A.TRUSTADDUPSPCDRF, A.RETGOODSREASONDIVRF, A.RETGOODSREASONRF, "
        //                    + " A.ACCEPTANORDERNORF, A.SALESROWNORF ";
        //// Add 2007.03.26 Saitoh

        // 2008.06.24 upd start ------------------------------------->>
        //private string STOCKSLIP_HEADID = "  SLIP.CREATEDATETIMERF" + Environment.NewLine +
        //                                  " ,SLIP.UPDATEDATETIMERF" + Environment.NewLine +
        //                                  " ,SLIP.ENTERPRISECODERF" + Environment.NewLine +
        //                                  " ,SLIP.FILEHEADERGUIDRF" + Environment.NewLine +
        //                                  " ,SLIP.UPDEMPLOYEECODERF" + Environment.NewLine +
        //                                  " ,SLIP.UPDASSEMBLYID1RF" + Environment.NewLine +
        //                                  " ,SLIP.UPDASSEMBLYID2RF" + Environment.NewLine +
        //                                  " ,SLIP.LOGICALDELETECODERF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine +
        //                                  " ,SLIP.SECTIONCODERF" + Environment.NewLine +
        //                                  " ,SLIP.SUBSECTIONCODERF" + Environment.NewLine +
        //                                  " ,SLIP.MINSECTIONCODERF" + Environment.NewLine +
        //                                  " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine +
        //                                  " ,SLIP.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine +
        //                                  " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine +
        //                                  " ,SLIP.TRUSTADDUPSPCDRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKADDUPSECTIONCDRF" + Environment.NewLine +
        //                                  " ,SLIP.INPUTDAYRF" + Environment.NewLine +
        //                                  " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKDATERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine +
        //                                  " ,SLIP.DELAYPAYMENTDIVRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKINPUTCODERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine +
        //                                  " ,SLIP.TTLAMNTDISPRATEAPYRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine +
        //                                  " ,SLIP.TTLITDEDSTCOUTTAXRF" + Environment.NewLine +
        //                                  " ,SLIP.TTLITDEDSTCINTAXRF" + Environment.NewLine +
        //                                  " ,SLIP.TTLITDEDSTCTAXFREERF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine +
        //                                  " ,SLIP.STCKPRCCONSTAXINCLURF" + Environment.NewLine +
        //                                  " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine +
        //                                  " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine +
        //                                  " ,SLIP.TAXADJUSTRF" + Environment.NewLine +
        //                                  " ,SLIP.BALANCEADJUSTRF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERCONSTAXRATERF" + Environment.NewLine +
        //                                  " ,SLIP.ACCPAYCONSTAXRF" + Environment.NewLine +
        //                                  " ,SLIP.PAYEECODERF" + Environment.NewLine +
        //                                  " ,SLIP.PAYEESNMRF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERCDRF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERNM1RF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERNM2RF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine +
        //                                  " ,SLIP.OUTPUTNAMECODERF" + Environment.NewLine +
        //                                  " ,SLIP.RETGOODSREASONDIVRF" + Environment.NewLine +
        //                                  " ,SLIP.RETGOODSREASONRF" + Environment.NewLine +
        //                                  " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine +
        //                                  " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine +
        //                                  " ,SLIP.DETAILROWCOUNTRF" + Environment.NewLine +
        //                                  " ,SLIP.EDISENDDATERF" + Environment.NewLine +
        //                                  " ,SLIP.EDITAKEINDATERF" + Environment.NewLine +
        //                                  " ,SLIP.UOEREMARK1RF" + Environment.NewLine +
        //                                  " ,SLIP.UOEREMARK2RF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKSLIPPRINTDATERF" + Environment.NewLine +
        //                                  " ,SLIP.ORDERFORMPRINTDATERF" + Environment.NewLine +
        //                                  " ,SLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine +
        //                                  " ,SLIP.BUSINESSTYPECODERF" + Environment.NewLine +
        //                                  " ,SLIP.BUSINESSTYPENAMERF" + Environment.NewLine +
        //                                  " ,SLIP.RECONCILEFLAGRF" + Environment.NewLine +
        //                                  " ,SLIP.STOCKFRACTIONPROCCDRF" + Environment.NewLine +
        //                                  " ,SLIP.SLIPADDRESSDIVRF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEECODERF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEENAMERF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEENAME2RF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEEPOSTNORF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEEADDR1RF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEEADDR2RF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEEADDR3RF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEEADDR4RF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEETELNORF" + Environment.NewLine +
        //                                  " ,SLIP.ADDRESSEEFAXNORF" + Environment.NewLine +
        //                                  " ,SLIP.DIRECTSENDINGCDRF" + Environment.NewLine;
        private string STOCKSLIP_HEADID = "  SLIP.CREATEDATETIMERF" + Environment.NewLine +
                                            " ,SLIP.UPDATEDATETIMERF" + Environment.NewLine +
                                            " ,SLIP.ENTERPRISECODERF" + Environment.NewLine +
                                            " ,SLIP.FILEHEADERGUIDRF" + Environment.NewLine +
                                            " ,SLIP.UPDEMPLOYEECODERF" + Environment.NewLine +
                                            " ,SLIP.UPDASSEMBLYID1RF" + Environment.NewLine +
                                            " ,SLIP.UPDASSEMBLYID2RF" + Environment.NewLine +
                                            " ,SLIP.LOGICALDELETECODERF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine +
                                            " ,SLIP.SECTIONCODERF" + Environment.NewLine +
                                            " ,SLIP.SUBSECTIONCODERF" + Environment.NewLine +
                                            " ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine +
                                            " ,SLIP.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine +
                                            " ,SLIP.STOCKGOODSCDRF" + Environment.NewLine +
                                            " ,SLIP.ACCPAYDIVCDRF" + Environment.NewLine +
                                            " ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine +
                                            " ,SLIP.STOCKADDUPSECTIONCDRF" + Environment.NewLine +
                                            " ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine +
                                            " ,SLIP.INPUTDAYRF" + Environment.NewLine +
                                            " ,SLIP.ARRIVALGOODSDAYRF" + Environment.NewLine +
                                            " ,SLIP.STOCKDATERF" + Environment.NewLine +
                                            " ,SLIP.STOCKADDUPADATERF" + Environment.NewLine +
                                            " ,SLIP.DELAYPAYMENTDIVRF" + Environment.NewLine +
                                            " ,SLIP.PAYEECODERF" + Environment.NewLine +
                                            " ,SLIP.PAYEESNMRF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERCDRF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERNM1RF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERNM2RF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERSNMRF" + Environment.NewLine +
                                            " ,SLIP.BUSINESSTYPECODERF" + Environment.NewLine +
                                            " ,SLIP.BUSINESSTYPENAMERF" + Environment.NewLine +
                                            " ,SLIP.SALESAREACODERF" + Environment.NewLine +
                                            " ,SLIP.SALESAREANAMERF" + Environment.NewLine +
                                            " ,SLIP.STOCKINPUTCODERF" + Environment.NewLine +
                                            " ,SLIP.STOCKINPUTNAMERF" + Environment.NewLine +
                                            " ,SLIP.STOCKAGENTCODERF" + Environment.NewLine +
                                            " ,SLIP.STOCKAGENTNAMERF" + Environment.NewLine +
                                            " ,SLIP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine +
                                            " ,SLIP.TTLAMNTDISPRATEAPYRF" + Environment.NewLine +
                                            " ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine +
                                            " ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine +
                                            " ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine +
                                            " ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine +
                                            " ,SLIP.STOCKNETPRICERF" + Environment.NewLine +
                                            " ,SLIP.STOCKPRICECONSTAXRF" + Environment.NewLine +
                                            " ,SLIP.TTLITDEDSTCOUTTAXRF" + Environment.NewLine +
                                            " ,SLIP.TTLITDEDSTCINTAXRF" + Environment.NewLine +
                                            " ,SLIP.TTLITDEDSTCTAXFREERF" + Environment.NewLine +
                                            " ,SLIP.STOCKOUTTAXRF" + Environment.NewLine +
                                            " ,SLIP.STCKPRCCONSTAXINCLURF" + Environment.NewLine +
                                            " ,SLIP.STCKDISTTLTAXEXCRF" + Environment.NewLine +
                                            " ,SLIP.ITDEDSTOCKDISOUTTAXRF" + Environment.NewLine +
                                            " ,SLIP.ITDEDSTOCKDISINTAXRF" + Environment.NewLine +
                                            " ,SLIP.ITDEDSTOCKDISTAXFRERF" + Environment.NewLine +
                                            " ,SLIP.STOCKDISOUTTAXRF" + Environment.NewLine +
                                            " ,SLIP.STCKDISTTLTAXINCLURF" + Environment.NewLine +
                                            " ,SLIP.TAXADJUSTRF" + Environment.NewLine +
                                            " ,SLIP.BALANCEADJUSTRF" + Environment.NewLine +
                                            " ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERCONSTAXRATERF" + Environment.NewLine +
                                            " ,SLIP.ACCPAYCONSTAXRF" + Environment.NewLine +
                                            " ,SLIP.STOCKFRACTIONPROCCDRF" + Environment.NewLine +
                                            " ,SLIP.AUTOPAYMENTRF" + Environment.NewLine +
                                            " ,SLIP.AUTOPAYSLIPNUMRF" + Environment.NewLine +
                                            " ,SLIP.RETGOODSREASONDIVRF" + Environment.NewLine +
                                            " ,SLIP.RETGOODSREASONRF" + Environment.NewLine +
                                            " ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine +
                                            " ,SLIP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine +
                                            " ,SLIP.DETAILROWCOUNTRF" + Environment.NewLine +
                                            " ,SLIP.EDISENDDATERF" + Environment.NewLine +
                                            " ,SLIP.EDITAKEINDATERF" + Environment.NewLine +
                                            " ,SLIP.UOEREMARK1RF" + Environment.NewLine +
                                            " ,SLIP.UOEREMARK2RF" + Environment.NewLine +
                                            " ,SLIP.SLIPPRINTDIVCDRF" + Environment.NewLine +
                                            " ,SLIP.SLIPPRINTFINISHCDRF" + Environment.NewLine +
                                            " ,SLIP.STOCKSLIPPRINTDATERF" + Environment.NewLine +
                                            " ,SLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine +
                                            " ,SLIP.SLIPADDRESSDIVRF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEECODERF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEENAMERF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEENAME2RF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEEPOSTNORF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEEADDR1RF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEEADDR3RF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEEADDR4RF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEETELNORF" + Environment.NewLine +
                                            " ,SLIP.ADDRESSEEFAXNORF" + Environment.NewLine +
                                            " ,SLIP.DIRECTSENDINGCDRF" + Environment.NewLine +
                                            // --- ADD 2009/04/07 -------->>>
                                            " ,SLIP.SUBSECTIONCODERF" + Environment.NewLine +
                                            " ,SUBS.SUBSECTIONNAMERF" + Environment.NewLine;
                                            // --- ADD 2009/04/07 --------<<<


        // 2008.06.24 upd end ---------------------------------------<<
        

        //JOIN句
        //private const string STOCKSLIP_JOIN = " (STOCKSLIPRF A LEFT JOIN STOCKDETAILRF B ON (A.ENTERPRISECODERF=B.ENTERPRISECODERF AND A.SUPPLIERFORMALRF=B.SUPPLIERFORMALRF"
        //                    + " AND A.SUPPLIERSLIPNORF=B.SUPPLIERSLIPNORF)) LEFT JOIN STOCKEXPLADATARF C ON (A.ENTERPRISECODERF=C.ENTERPRISECODERF"
        //                    + " AND A.SUPPLIERFORMALRF=C.SUPPLIERFORMALRF AND A.SUPPLIERSLIPNORF=C.SUPPLIERSLIPNORF) ";

        private string STOCKSLIP_JOIN = "  STOCKSLIPRF AS SLIP LEFT JOIN STOCKDETAILRF DTIL" + Environment.NewLine +
                                        "    ON  SLIP.ENTERPRISECODERF = DTIL.ENTERPRISECODERF" + Environment.NewLine +
                                        "    AND SLIP.SUPPLIERFORMALRF = DTIL.SUPPLIERFORMALRF" + Environment.NewLine +
                                        "    AND SLIP.SUPPLIERSLIPNORF = DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
        // -- UPD 2010/05/10 ------------------------------------------------------------------------>>>
        //private string SUBSECITON_JOIN = "  LEFT JOIN SUBSECTIONRF AS SUBS" + Environment.NewLine +
        //                                "    ON  DTIL.ENTERPRISECODERF = SUBS.ENTERPRISECODERF" + Environment.NewLine +
        //                                "    AND DTIL.SUBSECTIONCODERF = SUBS.SUBSECTIONCODERF" + Environment.NewLine;
        private string SUBSECITON_JOIN = "  LEFT JOIN SUBSECTIONRF AS SUBS" + Environment.NewLine +
                                        "    ON  SLIP.ENTERPRISECODERF = SUBS.ENTERPRISECODERF" + Environment.NewLine +
                                        "    AND SLIP.SUBSECTIONCODERF = SUBS.SUBSECTIONCODERF" + Environment.NewLine;
        // -- UPD 2010/05/10 ------------------------------------------------------------------------<<<
        #endregion

        /// <summary>
        /// 仕入伝票検索リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        /// </remarks>
        public SearchStockSlipDB()
            : base("MAKON01936D", "Broadleaf.Application.Remoting.ParamData.SearchParaStockSlip", "STOCKSLIPRF")
        {
        }

        #region[指定paraの仕入データLIST]
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての仕入データLISTを戻します
        /// </summary>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="retObj">検索結果仕入データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす全ての仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(ref object paraObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●検索パラメータList・検索結果リターンList
            CustomSerializeArrayList paraList = paraObj as CustomSerializeArrayList;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            retObj = null;

            //●検索パラメータチェック
            if (paraObj == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。検索対象パラメータListが未指定です");
                return status;
            }

            // --- ADD 2011/03/22----------------------------------->>>>>
            SearchParaStockSlip ParaStockSlip = new SearchParaStockSlip();
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            SqlConnection sqlConnection = null;

            for (int i = 0; i < paraList.Count; i++)
            {
                if (paraList[i] is SearchParaStockSlip)
                {
                    ParaStockSlip = paraList[i] as SearchParaStockSlip;
                }
            }
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ParaStockSlip.EnterpriseCode, "仕入伝票照会", "抽出開始");

                // --- ADD 2011/03/22-----------------------------------<<<<<
                //●検索処理実行
                status = SearchProc(paraList, out retList);

                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ParaStockSlip.EnterpriseCode, "仕入伝票照会", "抽出終了");

            }
            catch
            {
                //なし。
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            // --- ADD 2011/03/22-----------------------------------<<<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retObj = (object)retList;
            }
            retObj = (object)retList;

            return status;
        }

        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての仕入データLISTを戻します
        /// </summary>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="retList">検索結果仕入データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす全ての仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.19</br>
        private int SearchProc(CustomSerializeArrayList paraList, out CustomSerializeArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;

            //●検索パラメータ格納用
            SearchParaStockSlip searchParaStockSlip = null;

            //●検索結果格納用List
            retList = new CustomSerializeArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //●検索パラメータの取り出し
                if (paraList != null)
                {
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        if (paraList[i] is SearchParaStockSlip)
                        {
                            searchParaStockSlip = paraList[i] as SearchParaStockSlip;
                        }
                    }
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //--- DEL 2007.09.20 M.Kubota --->>>
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "STOCKSLIPRF", "STOCKDETAILRF", "STOCKEXPLADATARF" });
                //●暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);
                //--- DEL 2007.09.20 M.Kubota ---<<<

                if (searchParaStockSlip != null)
                {
                    SqlCommand sqlCommand;

                    //●SQL構文生成
                    string sqlText = "SELECT DISTINCT" + Environment.NewLine;
                    sqlText += STOCKSLIP_HEADID;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += STOCKSLIP_JOIN;
                    sqlText += SUBSECITON_JOIN;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaStockSlip);

#if DEBUG
                    Console.Clear();
                    Console.WriteLine("--- 変数 ---");

                    foreach (SqlParameter param in sqlCommand.Parameters)
                    {
                        string sqlDbType = param.SqlDbType.ToString();
                        if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                        {
                            sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                        }

                        string value = param.Value.ToString();
                        if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                        {
                            value = string.Format("'{0}'", param.Value);
                        }

                        Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                        Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                        Console.WriteLine("");
                    }

                    Console.WriteLine("--- SQL ---");
                    Console.WriteLine(sqlCommand.CommandText);
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        SearchRetStockSlip wkSearchRetStockSlip = new SearchRetStockSlip();

                        //●検索結果クラスに格納
                        wkSearchRetStockSlip = SearchRetStockSlipPut(ref myReader);

                        retList.Add(wkSearchRetStockSlip);
                    }

                    if (retList.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchStockSlipDB.SearchProc Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                /*--- DEL 2007.09.20 M.Kubota --->>>
                if (myReader != null && myReader.IsClosed == false) myReader.Close();
                //暗号化キークローズ
                if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // コネクションクローズ
                if (sqlConnection != null) sqlConnection.Close();
                  --- DEL 2007.09.20 M.Kubota ---<<<*/

                //--- ADD 2007.09.20 M.Kubota --->>>
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                //--- ADD 2007.09.20 M.Kubota ---<<<
            }

            return status;
        }
        #endregion

        #region[指定paraの指定件数分仕入データLIST]
        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="paraObj">仕入検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retObj">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        public int SearchSpecificationPara(ref object paraObj, out object retObj, out int retTotalCnt, out bool nextData, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●検索パラメータList・検索結果リターンList
            CustomSerializeArrayList paraList = paraObj as CustomSerializeArrayList;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            retObj = null;
            retTotalCnt = 0;
            nextData = false;

            //●検索パラメータチェック
            if (paraObj == null)
            {
                base.WriteErrorLog(null, "プログラムエラー。検索対象パラメータListが未指定です");
                return status;
            }

            //●検索処理実行
            status = SearchSpecificationParaProc(paraList, out retList, out retTotalCnt, out nextData, readCnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retObj = (object)retList;
            }

            return status;
        }

        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="paraList">仕入検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retList">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        public int SearchSpecificationParaProc(CustomSerializeArrayList paraList, out CustomSerializeArrayList retList, out int retTotalCnt, out bool nextData, int readCnt)
        {
            return this.SearchSpecificationPara(paraList, out retList, out retTotalCnt, out nextData, readCnt);
        }

        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="paraList">仕入検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retList">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす指定件数分の仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        private int SearchSpecificationPara(CustomSerializeArrayList paraList, out CustomSerializeArrayList retList, out int retTotalCnt, out bool nextData, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;

            SearchParaStockSlip searchParaStockSlip = null;
            retList = null;

            //●総件数を0で初期化
            retTotalCnt = 0;

            //●件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = readCnt;
            //if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            nextData = false;

            //●検索結果格納用List
            retList = new CustomSerializeArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                if (paraList != null)
                {
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        if (paraList[i] is SearchParaStockSlip)
                        {
                            searchParaStockSlip = paraList[i] as SearchParaStockSlip;
                        }
                    }
                }

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "STOCKSLIPRF", "STOCKDETAILRF", "STOCKEXPLADATARF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                if (searchParaStockSlip != null)
                {
                    //件数指定リードで一件目リードの場合データ総件数を取得
                    if (readCnt > 0)
                    {
                        SqlCommand sqlCommandCount = new SqlCommand("SELECT COUNT(DISTINCT SLIP.SUPPLIERSLIPNORF) FROM "
                                            + STOCKSLIP_JOIN, sqlConnection);

                        sqlCommandCount.CommandText += MakeWhereString(ref sqlCommandCount, searchParaStockSlip);

#if DEBUG
                        Console.Clear();
                        Console.WriteLine(sqlCommandCount.CommandText);
#endif

                        retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    }

                    SqlCommand sqlCommand;

                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        //SQL構文生成
                        sqlCommand = new SqlCommand("SELECT " + STOCKSLIP_HEADID + "FROM "
                                    + STOCKSLIP_JOIN, sqlConnection);
                        //WHERE文生成
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaStockSlip);

#if DEBUG
                        Console.Clear();
                        Console.WriteLine(sqlCommand.CommandText);
#endif

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            SearchRetStockSlip wkSearchRetStockSlip = new SearchRetStockSlip();

                            //●検索結果クラスに格納
                            wkSearchRetStockSlip = SearchRetStockSlipPut(ref myReader);
                            retList.Add(wkSearchRetStockSlip);


                        }
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    //複数件指定の場合
                    else
                    {
                        //SQL構文生成
                        sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString()
                                    + STOCKSLIP_HEADID
                                    + "FROM "
                                    + STOCKSLIP_JOIN, sqlConnection);
                        //WHERE文生成
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchParaStockSlip);

#if DEBUG
                        Console.Clear();
                        Console.WriteLine("--- 変数 ---");

                        foreach (SqlParameter param in sqlCommand.Parameters)
                        {
                            string sqlDbType = param.SqlDbType.ToString();
                            if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                            {
                                sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                            }

                            string value = param.Value.ToString();
                            if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                            {
                                value = string.Format("'{0}'", param.Value);
                            }

                            Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                            Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                            Console.WriteLine("");
                        }

                        Console.WriteLine("--- SQL ---");
                        Console.WriteLine(sqlCommand.CommandText);
#endif

                        myReader = sqlCommand.ExecuteReader();

                        int retCnt = 0;

                        while (myReader.Read())
                        {
                            //戻り値カウンタカウント
                            retCnt += 1;
                            if (readCnt > 0)
                            {
                                //戻り値の件数が取得指示件数を超えた場合終了
                                if (readCnt < retCnt)
                                {
                                    nextData = true;
                                    break;
                                }
                            }

                            SearchRetStockSlip wkSearchRetStockSlip = new SearchRetStockSlip();

                            //●検索結果クラスに格納
                            wkSearchRetStockSlip = SearchRetStockSlipPut(ref myReader);
                            retList.Add(wkSearchRetStockSlip);
                        }

                        if (retList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchStockSlipDB.SearchSpecificationParaProc Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //if (myReader != null && myReader.IsClosed == false) myReader.Close();
                //暗号化キークローズ
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // コネクションクローズ
                //if (sqlConnection != null) sqlConnection.Close();
                
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region[指定paraの仕入データLIST件数]
        /// <summary>
        /// 指定されたパラメータの条件を満たす仕入データLIST件数を戻します
        /// </summary>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす仕入データLIST件数を戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        public int SearchCntPara(ref object paraObj, out int retTotalCnt)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                //●検索パラメータList
                CustomSerializeArrayList paraList = paraObj as CustomSerializeArrayList;

                retTotalCnt = 0;

                //●検索パラメータチェック
                if (paraObj == null)
                {
                    base.WriteErrorLog(null, "プログラムエラー。検索対象パラメータListが未指定です");
                    return status;
                }

                //●検索処理実行
                status = SearchCntParaProc(paraList, out retTotalCnt);

                return status;
            }
            catch (Exception ex)
            {
                retTotalCnt = 0;
                base.WriteErrorLog(ex, "SearchStockSlipDB_SearchCntPara", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 指定されたパラメータの条件を満たす仕入データLIST件数を戻します
        /// </summary>
        /// <param name="paraList">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす仕入データLIST件数を戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        private int SearchCntParaProc(CustomSerializeArrayList paraList, out int retTotalCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;

            SearchParaStockSlip searchParaStockSlip = null;
            retTotalCnt = 0;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                if (paraList != null)
                {
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        if (paraList[i] is SearchParaStockSlip)
                        {
                            searchParaStockSlip = paraList[i] as SearchParaStockSlip;
                        }
                    }
                }

                if (searchParaStockSlip != null)
                {
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    SqlCommand sqlCommandCount;
                    //SQL構文生成
                    sqlCommandCount = new SqlCommand("SELECT COUNT(DISTINCT SLIP.ENTERPRISECODERF, SLIP.SUPPLIERFORMALRF, SLIP.SUPPLIERSLIPNORF) "
                                    + "FROM "
                                    + STOCKSLIP_JOIN, sqlConnection);
                    //WHERE文生成
                    sqlCommandCount.CommandText += MakeWhereString(ref sqlCommandCount, searchParaStockSlip);

#if DEBUG
                    Console.Clear();
                    Console.WriteLine(sqlCommandCount.CommandText);
#endif

                    //データリード
                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    if (retTotalCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            sqlConnection.Close();

            return status;
        }
        #endregion

        #region[企業コード単位の仕入データLIST]
        /// <summary>
        /// 指定された企業コードの仕入データLISTを全て戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retObj">検索結果仕入データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        public int SearchEnterprise(string enterpriseCode, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●検索結果パラメータList
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retObj = null;

            //●検索パラメータチェック
            if (enterpriseCode == "")
            {
                base.WriteErrorLog(null, "プログラムエラー。検索対象企業コードが未指定です");
                return status;
            }

            //●検索処理実行
            status = SearchEnterpriseProc(enterpriseCode, out retList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retObj = (object)retList;
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入データLISTを全て戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retList">検索結果仕入データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        private int SearchEnterpriseProc(string enterpriseCode, out CustomSerializeArrayList retList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;

            retList = null;

            //●検索結果格納用List
            retList = new CustomSerializeArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "STOCKSLIPRF", "STOCKDETAILRF", "STOCKEXPLADATARF" });
                //●暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                if (enterpriseCode != "")
                {
                    SqlCommand sqlCommand;

                    //●SQL構文生成
                    //sqlCommand = new SqlCommand("SELECT * FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE ORDER BY SUPPLIERSLIPNORF DESC", sqlConnection);  //DEL 2007/09/1 M.Kubota
                    sqlCommand = new SqlCommand("SELECT * FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ORDER BY SUPPLIERSLIPNORF DESC", sqlConnection);  //ADD 2007/09/11 M.Kubota

                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
#if DEBUG
                    Console.Clear();
                    Console.WriteLine(sqlCommand.CommandText);
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

                        //●検索結果クラスに格納
                        searchRetStockSlip = SearchRetStockSlipPut(ref myReader);
                        retList.Add(searchRetStockSlip);

                        
                    }

                    if (retList.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                //if (myReader != null && myReader.IsClosed == false) myReader.Close();
                //暗号化キークローズ
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // コネクションクローズ
                //if (sqlConnection != null) sqlConnection.Close();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region[企業コード単位の指定件数分仕入データLIST]
        /// <summary>
        /// 指定された企業コードの指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retObj">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの指定件数分の仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        public int SearchSpecificationEnterprise(string enterpriseCode, out object retObj, out int retTotalCnt, out bool nextData, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //●検索結果パラメータList
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            retObj = null;
            retTotalCnt = 0;
            nextData = false;

            //●検索パラメータチェック
            if (enterpriseCode == "")
            {
                base.WriteErrorLog(null, "プログラムエラー。検索対象企業コードが未指定です");
                return status;
            }

            //●検索処理実行
            status = SearchSpecificationEnterpriseProc(enterpriseCode, out retList, out retTotalCnt, out nextData, readCnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retObj = (object)retList;
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードの指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retList">検索結果仕入データ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの指定件数分の仕入データLISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        private int SearchSpecificationEnterpriseProc(string enterpriseCode, out CustomSerializeArrayList retList, out int retTotalCnt, out bool nextData, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;

            retList = null;

            //●総件数を0で初期化
            retTotalCnt = 0;

            //●件数指定リードの場合には指定件数＋1件リードする
            int _readCnt = readCnt;
            //if (_readCnt > 0) _readCnt += 1;
            //●次レコード無しで初期化
            nextData = false;

            retList = new CustomSerializeArrayList();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "STOCKSLIPRF", "STOCKDETAILRF", "STOCKEXPLADATARF" });
                //暗号化キーOPEN（SQLExceptionの可能性有り）
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                if (enterpriseCode != null || enterpriseCode != "")
                {
                    //件数指定リードで一件目リードの場合データ総件数を取得
                    if (readCnt > 0)
                    {
                        //SqlCommand sqlCommandCount = new SqlCommand("SELECT COUNT (ENTERPRISECODERF) FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE", sqlConnection);  //DEL 2007/09/11 M.Kubota
                        SqlCommand sqlCommandCount = new SqlCommand("SELECT COUNT (ENTERPRISECODERF) FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE", sqlConnection);  //ADD 2007/09/11 M.Kubota

                        SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                        SqlParameter findLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);  //ADD 2007/09/11 M.Kubota
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);  //ADD 2007/09/11 M.Kubota
#if DEBUG
                        Console.Clear();
                        Console.WriteLine(sqlCommandCount.CommandText);
#endif

                        retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    }

                    SqlCommand sqlCommand;

                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        //●SQL構文生成
                        //sqlCommand = new SqlCommand("SELECT * FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE ORDER BY SUPPLIERSLIPNORF DESC", sqlConnection);  //DEL 2007/09/11 M.Kubota
                        sqlCommand = new SqlCommand("SELECT * FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ORDER BY SUPPLIERSLIPNORF DESC", sqlConnection);  //ADD 2007/09/11 M.Kubota

                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);  //ADD 2007/09/11 M.Kubota
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);  //ADD 2007/09/11 M.Kubota
#if DEBUG
                        Console.Clear();
                        Console.WriteLine(sqlCommand.CommandText);
#endif

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

                            //●検索結果クラスに格納
                            searchRetStockSlip = SearchRetStockSlipPut(ref myReader);
                            retList.Add(searchRetStockSlip);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                    }
                    //指定件数が複数件の場合
                    else
                    {
                        //sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE", sqlConnection);  //DEL 2007/09/11 M.Kubota
                        sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE", sqlConnection);  //ADD 2007/09/11 M.Kubota

                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
#if DEBUG
                        Console.Clear();
                        Console.WriteLine(sqlCommand.CommandText);
#endif

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

                            //●検索結果クラスに格納
                            searchRetStockSlip = SearchRetStockSlipPut(ref myReader);
                            retList.Add(searchRetStockSlip);
                        }

                        if (retList.Count > 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                //if (myReader != null && myReader.IsClosed == false) myReader.Close();
                //暗号化キークローズ
                //if (sqlEncriptInfo != null && sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // コネクションクローズ
                //if (sqlConnection != null) sqlConnection.Close();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                    myReader.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }

            return status;
        }
        #endregion

        #region[企業コード単位のLIST件数]
        /// <summary>
        /// 指定された企業コードの仕入データLIST件数を戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retCnt">該当データ件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLIST件数を戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        public int SearchCntEnterprise(string enterpriseCode, out int retCnt)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                retCnt = 0;

                //●検索パラメータチェック
                if (enterpriseCode == "")
                {
                    base.WriteErrorLog(null, "プログラムエラー。検索対象企業コードが未指定です");
                    return status;
                }

                //●検索処理実行
                status = SearchCntEnterpriseProc(enterpriseCode, out retCnt);

                return status;
            }
            catch (Exception ex)
            {
                retCnt = 0;
                base.WriteErrorLog(ex, "SearchStockSlipDB_Search", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 指定された企業コードの仕入データLIST件数を戻します
        /// </summary>
        /// <param name="enterpriseCode">検索パラメータ</param>
        /// <param name="retCnt">該当データ件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLIST件数を戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.16</br>
        private int SearchCntEnterpriseProc(string enterpriseCode, out int retCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            //SearchRetStockSlip searchRetStockSlip = null;

            retCnt = 0;

            ArrayList workArray = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                if (enterpriseCode != null || enterpriseCode != "")
                {
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    SqlCommand sqlCommandCount;
                    //sqlCommandCount = new SqlCommand("SELECT COUNT(ENTERPRISECODERF) FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE", sqlConnection);  //DEL 2007/09/11 M.Kubota
                    sqlCommandCount = new SqlCommand("SELECT COUNT(ENTERPRISECODERF) FROM STOCKSLIPRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE", sqlConnection);  //ADD 2007/09/11 M.Kubota

                    SqlParameter findEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                    SqlParameter findLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);  //ADD 2007/09/11 M.Kubota
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);  //ADD 2007/09/11 M.Kubota
#if DEBUG
                    Console.Clear();
                    Console.WriteLine(sqlCommandCount.CommandText);
#endif

                    //データリード
                    retCnt = (int)sqlCommandCount.ExecuteScalar();
                    if (retCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            sqlConnection.Close();

            return status;
        }
        #endregion

        #region[Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchParaStockSlip">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchParaStockSlip searchParaStockSlip)
        {
            string retstring = "WHERE" + Environment.NewLine;

            //--------------------------STOCKSLIPRF SLIP--------------------------
            //企業コード
            retstring += "  SLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.EnterpriseCode);

            //論理削除
            retstring += "  AND SLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            // -- DEL 2010/05/10 -------------------------------------->>>
            //retstring += "  AND DTIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            // -- DEL 2010/05/10 --------------------------------------<<<
            SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);

            //仕入形式
            //全て検索の場合：99 (但し、UIからは 0:仕入 1:入荷 しか設定されてこない)
            if (searchParaStockSlip.SupplierFormal != 99)
            {
                retstring += "  AND SLIP.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.SupplierFormal);
            }

            //相手先伝票番号（あいまい検索）
            if (string.IsNullOrEmpty(searchParaStockSlip.PartySaleSlipNum) == false)
            {
                retstring += " AND SLIP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM" + Environment.NewLine;
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (searchParaStockSlip.PartySaleSlipNumSrchTyp == 1) searchParaStockSlip.PartySaleSlipNum = searchParaStockSlip.PartySaleSlipNum + "%";
                //後方一致検索の場合
                if (searchParaStockSlip.PartySaleSlipNumSrchTyp == 2) searchParaStockSlip.PartySaleSlipNum = "%" + searchParaStockSlip.PartySaleSlipNum;
                //曖昧検索の場合
                if (searchParaStockSlip.PartySaleSlipNumSrchTyp == 3) searchParaStockSlip.PartySaleSlipNum = "%" + searchParaStockSlip.PartySaleSlipNum + "%";

                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.PartySaleSlipNum);
            }

            //仕入伝票番号(開始)
            if (searchParaStockSlip.SupplierSlipNoSt > 0)
            {
                retstring += "  AND SLIP.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNOST" + Environment.NewLine;
                SqlParameter paraSupplierSlipNoSt = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOST", SqlDbType.Int);
                paraSupplierSlipNoSt.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.SupplierSlipNoSt);

                
            }
            //仕入伝票番号(終了)
            if (searchParaStockSlip.SupplierSlipNoEd > 0)
            {
                retstring += "  AND SLIP.SUPPLIERSLIPNORF<=@FINDSUPPLIERSLIPNOED" + Environment.NewLine;
                SqlParameter paraSupplierSlipNoEd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOED", SqlDbType.Int);
                paraSupplierSlipNoEd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.SupplierSlipNoEd);

                
            }

            //仕入伝票区分
            //全て検索の場合：99
            if (searchParaStockSlip.SupplierSlipCd != 99)
            {
                retstring += "  AND SLIP.SUPPLIERSLIPCDRF = @FINDSUPPLIERSLIPCD" + Environment.NewLine;
                SqlParameter paraSupplierSlipCd = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPCD", SqlDbType.Int);
                paraSupplierSlipCd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.SupplierSlipCd);
            }

            //赤伝区分
            //全て検索の場合：99
            if (searchParaStockSlip.DebitNoteDiv != 99)
            {
                retstring += "  AND SLIP.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV" + Environment.NewLine;
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.DebitNoteDiv);
            }

            //仕入商品区分
            //全て検索の場合：99
            if (searchParaStockSlip.StockGoodsCd != 99)
            {
                retstring += "  AND SLIP.STOCKGOODSCDRF = @FINDSTOCKGOODSCD" + Environment.NewLine;
                SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@FINDSTOCKGOODSCD", SqlDbType.Int);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.StockGoodsCd);
            }

            //買掛区分
            //全て検索の場合：99
            if (searchParaStockSlip.AccPayDivCd != 99)
            {
                retstring += "  AND SLIP.ACCPAYDIVCDRF = @FINDACCPAYDIVCD" + Environment.NewLine;
                SqlParameter paraAccPayDivCd = sqlCommand.Parameters.Add("@FINDACCPAYDIVCD", SqlDbType.Int);
                paraAccPayDivCd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.AccPayDivCd);
            }

            //仕入担当者コード
            if (searchParaStockSlip.StockAgentCode != "")
            {
                retstring += "  AND SLIP.STOCKAGENTCODERF = @FINDSTOCKAGENTCD" + Environment.NewLine;
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCD", SqlDbType.NChar);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.StockAgentCode);
            }

            //仕入拠点コード
            if (searchParaStockSlip.StockSectionCd != "")
            {
                retstring += "  AND SLIP.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.StockSectionCd);
            }

            //事業者コード
            //if (searchParaStockSlip.CarrierEpCode > 0)
            //{
            //    retstring += "AND A.CARRIEREPCODERF=@FINDCARRIEREPCODE ";
            //    SqlParameter paraCarrierEpCode = sqlCommand.Parameters.Add("@FINDCARRIEREPCODE", SqlDbType.Int);
            //    paraCarrierEpCode.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.CarrierEpCode);
            //}

            //仕入先コード
            if (searchParaStockSlip.SupplierCd > 0)
            {
                retstring += "  AND SLIP.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.SupplierCd);
            }

            // 2008.06.24 add start -------------------------------------->>
            //支払先コード
            if (searchParaStockSlip.PayeeCode > 0)
            {
                retstring += "  AND SLIP.PAYEECODERF = @FINDPAYEECODE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.PayeeCode);
            }
            // 2008.06.24 add end ----------------------------------------<<

            //仕入日・入荷日(開始 or 終了) ※仕入形式が 99:指定無し の場合は考慮していない。
            switch (searchParaStockSlip.SupplierFormal)
            {
                case 0:
                    {
                        // 仕入日(開始)
                        if (searchParaStockSlip.StockDateSt > 0)
                        {
                            retstring += "  AND SLIP.STOCKDATERF >= @FINDSTOCKDATEST" + Environment.NewLine;
                            SqlParameter paraStockDateSt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                            paraStockDateSt.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.StockDateSt);
                        }

                        // 仕入日(終了)
                        if (searchParaStockSlip.StockDateEd > 0)
                        {
                            retstring += "  AND SLIP.STOCKDATERF <= @FINDSTOCKDATEED" + Environment.NewLine;
                            SqlParameter paraStockDateEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                            paraStockDateEd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.StockDateEd);
                        }

                        break;
                    }
                case 1:
                    {
                        // 入荷日(開始)
                        if (searchParaStockSlip.ArrivalGoodsDaySt > 0)
                        {
                            retstring += "  AND SLIP.ARRIVALGOODSDAYRF >= @FINDSTOCKDATEST" + Environment.NewLine;
                            SqlParameter paraArrivalGoodsDaySt = sqlCommand.Parameters.Add("@FINDSTOCKDATEST", SqlDbType.Int);
                            paraArrivalGoodsDaySt.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.ArrivalGoodsDaySt);
                        }

                        // 入荷日(終了)
                        if (searchParaStockSlip.ArrivalGoodsDayEd > 0)
                        {
                            retstring += "  AND SLIP.ARRIVALGOODSDAYRF <= @FINDSTOCKDATEED" + Environment.NewLine;
                            SqlParameter ArrivalGoodsDayEd = sqlCommand.Parameters.Add("@FINDSTOCKDATEED", SqlDbType.Int);
                            ArrivalGoodsDayEd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.ArrivalGoodsDayEd);
                        }

                        break;
                    }
            }

            // 入力日(開始)
            if (searchParaStockSlip.InputDaySt > 0)
            {
                retstring += "  AND SLIP.INPUTDAYRF >= @FINDINPUTDAYST" + Environment.NewLine;
                SqlParameter paraInputDaySt = sqlCommand.Parameters.Add("@FINDINPUTDAYST", SqlDbType.Int);
                paraInputDaySt.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.InputDaySt);
            }

            // 入力日(終了)
            if (searchParaStockSlip.InputDayEd > 0)
            {
                retstring += "  AND SLIP.INPUTDAYRF <= @FINDINPUTDAYED" + Environment.NewLine;
                SqlParameter paraInputDayEd = sqlCommand.Parameters.Add("@FINDINPUTDAYED", SqlDbType.Int);
                paraInputDayEd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.InputDayEd);
            }

            // 仕入計上日付(開始)
            if (searchParaStockSlip.StockAddUpADateSt > 0)
            {
                retstring += "  AND SLIP.STOCKADDUPADATERF >= @FINDSTOCKADDUPADATEST" + Environment.NewLine;
                SqlParameter paraStockAddUpADateSt = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATEST", SqlDbType.Int);
                paraStockAddUpADateSt.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.StockAddUpADateSt);
            }

            // 仕入計上日付(終了)
            if (searchParaStockSlip.StockAddUpADateEd > 0)
            {
                retstring += "  AND SLIP.STOCKADDUPADATERF <= @FINDSTOCKADDUPADATEED" + Environment.NewLine;
                SqlParameter paraStockAddUpADateEd = sqlCommand.Parameters.Add("@FINDSTOCKADDUPADATEED", SqlDbType.Int);
                paraStockAddUpADateEd.Value = SqlDataMediator.SqlSetInt32(searchParaStockSlip.StockAddUpADateEd);
            }

            //倉庫コード
            //if (searchParaStockSlip.WarehouseCode != "")
            //{
            //    retstring += "AND A.WAREHOUSECODERF=@FINDWAREHOUSECODE ";
            //    SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
            //    paraWarehouseCode.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.WarehouseCode);
            //}

            //--------------------------STOCKDETAILRF DTIL--------------------------
            // 商品メーカーコード
            if (searchParaStockSlip.GoodsMakerCd > 0)
            {
                retstring += "  AND DTIL.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt(searchParaStockSlip.GoodsMakerCd);
            }
            
            // 商品コード
            if (searchParaStockSlip.GoodsNo != "")
            {
                retstring += "  AND DTIL.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                SqlParameter paraGoodsCode = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsCode.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.GoodsNo);
            }

            // 商品名称
            if (searchParaStockSlip.GoodsName != "")
            {
                if (searchParaStockSlip.GoodsNmVagueSrch)
                {
                    // 前方一致の曖昧検索を行う
                    retstring += "  AND DTIL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                }
                else
                {
                    // 完全一致の検索を行う
                    retstring += "  AND DTIL.GOODSNAMERF = @FINDGOODSNAME" + Environment.NewLine;
                }

                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.GoodsName + (searchParaStockSlip.GoodsNmVagueSrch ? "%" : ""));
            }


            //--------------------------STOCKEXPLADATARF C--------------------------
            /*
            //商品電話番号1(開始～終了)
            if (searchParaStockSlip.StockTelNo1Start != "" && searchParaStockSlip.StockTelNo1End != "")
            {
                retstring += "AND (C.STOCKTELNO1RF >= @STOCKTELNO1START AND C.STOCKTELNO1RF <= @STOCKTELNO1END) ";
                SqlParameter paraStockTelNo1Start = sqlCommand.Parameters.Add("@STOCKTELNO1START", SqlDbType.NChar);
                SqlParameter paraStockTelNo1End = sqlCommand.Parameters.Add("@STOCKTELNO1END", SqlDbType.NChar);
                paraStockTelNo1Start.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.StockTelNo1Start);
                paraStockTelNo1End.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.StockTelNo1End);
            }

            //製造番号1(開始～終了)
            if (searchParaStockSlip.ProductNumber1Start != "" && searchParaStockSlip.ProductNumber1End != "")
            {
                retstring += "AND (C.PRODUCTNUMBER1RF >= @PRODUCTNUMBER1START AND C.PRODUCTNUMBER1RF <= @PRODUCTNUMBER1END) ";
                SqlParameter paraProductNumber1Start = sqlCommand.Parameters.Add("@PRODUCTNUMBER1START", SqlDbType.NChar);
                SqlParameter paraProductNumber1End = sqlCommand.Parameters.Add("@PRODUCTNUMBER1END", SqlDbType.NChar);
                paraProductNumber1Start.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.ProductNumber1Start);
                paraProductNumber1End.Value = SqlDataMediator.SqlSetString(searchParaStockSlip.ProductNumber1End);
            }
            */

            // --- ADD 2009/04/07 -------->>>
            // 部門コード
            if (searchParaStockSlip.SubSectionCode != 0)
            {
                retstring += " AND SLIP.SUBSECTIONCODERF = @SUBSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt(searchParaStockSlip.SubSectionCode);
            }
            // --- ADD 2009/04/07 --------<<<

            //並び替え文字列
            retstring += "ORDER BY SLIP.SUPPLIERSLIPNORF DESC";

            return retstring;
        }
        #endregion

        #region[検索結果クラス格納]
        /// <summary>
        /// 仕入検索結果クラス出力処理
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <returns>出力クラス</returns>
        /// <br>Note       : 仕入検索結果クラス出力処理</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.02.19</br>
        private SearchRetStockSlip SearchRetStockSlipPut(ref SqlDataReader myReader)
        {
            SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

            #region 仕入ワーククラスへ代入　※レイアウト変更時対応必須
            searchRetStockSlip.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            searchRetStockSlip.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            searchRetStockSlip.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            searchRetStockSlip.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            searchRetStockSlip.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            searchRetStockSlip.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            searchRetStockSlip.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            searchRetStockSlip.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            searchRetStockSlip.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            searchRetStockSlip.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            searchRetStockSlip.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            searchRetStockSlip.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            searchRetStockSlip.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            searchRetStockSlip.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
            searchRetStockSlip.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            searchRetStockSlip.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            searchRetStockSlip.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            searchRetStockSlip.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            searchRetStockSlip.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            searchRetStockSlip.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
            searchRetStockSlip.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            searchRetStockSlip.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            searchRetStockSlip.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            searchRetStockSlip.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            searchRetStockSlip.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            searchRetStockSlip.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            searchRetStockSlip.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            searchRetStockSlip.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            searchRetStockSlip.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
            searchRetStockSlip.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
            searchRetStockSlip.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            searchRetStockSlip.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            searchRetStockSlip.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            searchRetStockSlip.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            searchRetStockSlip.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            searchRetStockSlip.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            searchRetStockSlip.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
            searchRetStockSlip.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            searchRetStockSlip.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            searchRetStockSlip.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            searchRetStockSlip.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            searchRetStockSlip.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            searchRetStockSlip.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            searchRetStockSlip.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
            searchRetStockSlip.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
            searchRetStockSlip.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
            searchRetStockSlip.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            searchRetStockSlip.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
            searchRetStockSlip.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
            searchRetStockSlip.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
            searchRetStockSlip.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
            searchRetStockSlip.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            searchRetStockSlip.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
            searchRetStockSlip.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
            searchRetStockSlip.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
            searchRetStockSlip.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
            searchRetStockSlip.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
            searchRetStockSlip.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            searchRetStockSlip.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
            searchRetStockSlip.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
            searchRetStockSlip.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            searchRetStockSlip.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            searchRetStockSlip.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
            searchRetStockSlip.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
            searchRetStockSlip.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
            searchRetStockSlip.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
            searchRetStockSlip.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            searchRetStockSlip.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            searchRetStockSlip.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            searchRetStockSlip.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            searchRetStockSlip.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            searchRetStockSlip.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
            searchRetStockSlip.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
            searchRetStockSlip.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            searchRetStockSlip.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            searchRetStockSlip.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            searchRetStockSlip.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
            searchRetStockSlip.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            searchRetStockSlip.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
            searchRetStockSlip.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            searchRetStockSlip.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            searchRetStockSlip.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            searchRetStockSlip.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            searchRetStockSlip.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            searchRetStockSlip.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            searchRetStockSlip.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            searchRetStockSlip.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            searchRetStockSlip.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            searchRetStockSlip.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            searchRetStockSlip.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            searchRetStockSlip.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
            searchRetStockSlip.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            searchRetStockSlip.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            #endregion

            return searchRetStockSlip;
        }
        #endregion
    }
}

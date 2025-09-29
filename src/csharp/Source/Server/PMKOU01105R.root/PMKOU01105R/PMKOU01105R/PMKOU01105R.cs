using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入チェック処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入チェック処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.2</br>
    /// <br></br>
    /// <br>Update Note: 2010/09/14　30517 夏野 駿希</br>
    /// <br>             Mantis.16051 表示順がPM7と異なる為修正する。</br>
    /// <br>             転嫁方式の取得先を仕入履歴データへ変更。</br>
    /// <br></br>
    /// <br>Update Note: 2010/09/17　30517 夏野 駿希</br>
    /// <br>             Mantis.16075 表示順がPM7と異なる為修正する。</br>
    /// <br>Update Note: 2010/10/21　李占川</br>
    /// <br>             MANTIS：0016368、0016384 金額、消費税表示内容の変更</br>
    /// <br>Update Note: 2012/08/30　凌小青</br>
    /// <br>             Redmine#31879の対応　UOE仕入データの区分を取得</br>
    /// <br>　　　　　　 仕入履歴データのＵＯＥリマーク１とＵＯＥリマーク２を取得</br>
    /// <br>Update Note: 2012/09/12　凌小青</br>
    /// <br>             Redmine#31879の#13の対応　仕入伝票入力で仕入伝票番号を呼出、数量を修正登録します。</br>
    /// <br> 　　　　　　仕入チェック処理でUOE仕入場合の背景色が白色です。</br>
    /// <br>Update Note: 2012/10/09　朱 猛</br>
    /// <br>             Redmine#31879　仕入チェック処理で赤伝伝票場合の背景色を赤に変更する為、赤伝区分を取得。</br>
    /// <br>Update Note: 2015/09/07　李魏</br>
    /// <br>             Redmine#47300　仕入チェック処理で拠点コードの取得元を変更する。</br>
    /// <br>Update Note: K2015/09/24　李魏</br>
    /// <br>             Redmine#47300　チェック区分が「未チェック/チェック済み」場合、伝票区分が「削除」場合を追加する。</br>
    /// <br>Update Note: 2021/05/31 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4142 仕入チェック処理速度対応</br>
    /// </remarks>
    [Serializable]
    public class SupplierCheckOrderWorkDB : RemoteWithAppLockDB, ISupplierCheckOrderWorkDB
    {
        /// <summary>
        /// 仕入チェック処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        /// </remarks>
        public SupplierCheckOrderWorkDB()
            :
        base("PMKOU01107D", "Broadleaf.Application.Remoting.ParamData.SupplierCheckResultWorkDB", "StockSlHistDtlRF") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードの仕入チェック処理LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="orderListResultWork">検索結果</param>
        /// <param name="orderListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの発注一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        public int Search(out object supplierCheckResultWork, object supplierCheckOrdeCndtnrWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            supplierCheckResultWork = null;

            SupplierCheckOrderCndtnWork _supplierCheckOrdeCndtnrWork = supplierCheckOrdeCndtnrWork as SupplierCheckOrderCndtnWork;

            try
            {
                status = SearchProc(out supplierCheckResultWork, _supplierCheckOrdeCndtnrWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "supplierCheckOrdeCndtnrWork.Search Exception=" + ex.Message);
                supplierCheckResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの仕入チェック処理LISTを全て戻します
        /// </summary>
        /// <param name="orderListResultWork">検索結果</param>
        /// <param name="_orderListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入チェック処理LISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object supplierCheckResultWork, SupplierCheckOrderCndtnWork _supplierCheckOrdeCndtnrWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            supplierCheckResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _supplierCheckOrdeCndtnrWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierCheckResultWork.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            supplierCheckResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2021/05/31 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4142 仕入チェック処理速度対応</br>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SupplierCheckOrderCndtnWork _supplierCheckOrdeCndtnrWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList list = new ArrayList();
            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += MakeSelectString(ref sqlCommand, _supplierCheckOrdeCndtnrWork, logicalMode);

                sqlCommand.CommandText = selectTxt;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //sqlCommand.CommandTimeout = 600;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                sqlCommand.CommandTimeout = 3600;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SupplierCheckResultWork wkSupplierCheckResultWork = new SupplierCheckResultWork();
                    
                    //格納項目
                    wkSupplierCheckResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSupplierCheckResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkSupplierCheckResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSupplierCheckResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkSupplierCheckResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkSupplierCheckResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkSupplierCheckResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkSupplierCheckResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkSupplierCheckResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkSupplierCheckResultWork.StockCheckDivCAddUp = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCHECKDIVCADDUPRF"));
                    wkSupplierCheckResultWork.StockCheckDivDaily = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCHECKDIVDAILYRF"));
                    wkSupplierCheckResultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                    wkSupplierCheckResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkSupplierCheckResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    wkSupplierCheckResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    wkSupplierCheckResultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                    wkSupplierCheckResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    wkSupplierCheckResultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    wkSupplierCheckResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSupplierCheckResultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    wkSupplierCheckResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkSupplierCheckResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkSupplierCheckResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkSupplierCheckResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkSupplierCheckResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkSupplierCheckResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkSupplierCheckResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkSupplierCheckResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkSupplierCheckResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSupplierCheckResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSupplierCheckResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                    wkSupplierCheckResultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                    wkSupplierCheckResultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                    wkSupplierCheckResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkSupplierCheckResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkSupplierCheckResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSupplierCheckResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkSupplierCheckResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkSupplierCheckResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    wkSupplierCheckResultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                    wkSupplierCheckResultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                    wkSupplierCheckResultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    wkSupplierCheckResultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                    wkSupplierCheckResultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                    wkSupplierCheckResultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                    wkSupplierCheckResultWork.StockTtlPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICECONSTAXRF"));

                    // --- ADD 2010/10/21 ---------->>>>>
                    wkSupplierCheckResultWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    wkSupplierCheckResultWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                    // --- ADD 2010/10/21 ----------<<<<<

                    wkSupplierCheckResultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                    wkSupplierCheckResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                    #endregion


                    al.Add(wkSupplierCheckResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierCheckResultWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        private string MakeSelectString(ref SqlCommand sqlCommand, SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string rstring = "";
            if (_supplierCheckOrderCndtnWork.CheckDiv == 2) 
            {
                #region SELECT文　2:チェック済み
                rstring = "SELECT " + Environment.NewLine;
                rstring += "	     A.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,B.CREATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,B.UPDATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,B.ENTERPRISECODERF" + Environment.NewLine;
             
                rstring += "        ,B.FILEHEADERGUIDRF" + Environment.NewLine;
                rstring += "        ,B.UPDEMPLOYEECODERF" + Environment.NewLine;
                rstring += "        ,B.UPDASSEMBLYID1RF" + Environment.NewLine;
                rstring += "        ,B.UPDASSEMBLYID2RF" + Environment.NewLine;
                rstring += "        ,B.LOGICALDELETECODERF" + Environment.NewLine;
                //rstring += "        ,B.SECTIONCODERF" + Environment.NewLine;//DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "	    ,B.STOCKSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,B.STOCKCHECKDIVCADDUPRF" + Environment.NewLine;
                rstring += "        ,B.STOCKCHECKDIVDAILYRF" + Environment.NewLine;
                rstring += "        ,B.WAYTOORDERRF" + Environment.NewLine;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                rstring += "        ,B.STOCKDATERF" + Environment.NewLine;
                rstring += "        ,B.INPUTDAYRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,B.PARTYSALESLIPNUMRF" + Environment.NewLine;
                rstring += "        ,B.STOCKPRICETAXINCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKPRICETAXEXCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKPRICECONSTAXRF" + Environment.NewLine;
                rstring += "        ,B.GOODSNORF" + Environment.NewLine;
                rstring += "        ,B.STOCKCOUNTRF" + Environment.NewLine;
                rstring += "        ,B.BLGOODSCODERF" + Environment.NewLine;
                rstring += "        ,B.GOODSNAMERF" + Environment.NewLine;
                rstring += "        ,B.STOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,B.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,B.SALESMONEYTAXEXCRF" + Environment.NewLine;
                rstring += "        ,B.SALESDATERF" + Environment.NewLine;
                rstring += "        ,B.SALESSLIPNUMRF" + Environment.NewLine;
                rstring += "        ,B.CUSTOMERCODERF" + Environment.NewLine;
                rstring += "        ,B.CUSTOMERSNMRF" + Environment.NewLine;
                rstring += "        ,B.SALESEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,B.FRONTEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,B.SALESINPUTNAMERF" + Environment.NewLine;
                rstring += "        ,B.UOEREMARK1RF" + Environment.NewLine;
                rstring += "        ,B.UOEREMARK2RF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERCDRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERSNMRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "        ,B.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "        ,B.STOCKGOODSCDRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERSLIPCDRF" + Environment.NewLine;
                rstring += "        ,B.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,B.SUPPCTAXLAYCDRF" + Environment.NewLine;
                rstring += "        ,B.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKTTLPRICECONSTAXRF" + Environment.NewLine;
                // --- ADD 2010/10/21 ---------->>>>>
                rstring += "        ,B.STOCKTOTALPRICERF" + Environment.NewLine;
                rstring += "        ,B.STOCKSUBTTLPRICERF" + Environment.NewLine;
                // --- ADD 2010/10/21 ----------<<<<<
                rstring += "        ,B.DEBITNOTEDIVRF" + Environment.NewLine;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                rstring += "FROM(SELECT " + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "		SUPPLIERSLIPNORF" + Environment.NewLine;
                //rstring += "		FROM STOCKSLHISTDTLRF AS STOCK1" + Environment.NewLine;
                //rstring += "		LEFT JOIN STOCKCHECKDTLRF AS STCH1" + Environment.NewLine;
                rstring += "		STOCK1.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "		FROM STOCKSLIPHISTRF AS STOCK_H WITH(READUNCOMMITTED)" + Environment.NewLine; //ヘッダから読み込む
                rstring += "		LEFT JOIN STOCKSLHISTDTLRF AS STOCK1 WITH(READUNCOMMITTED)" + Environment.NewLine;
                rstring += "		ON" + Environment.NewLine;
                rstring += "		STOCK_H.ENTERPRISECODERF = STOCK1.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "		AND STOCK_H.SUPPLIERFORMALRF = STOCK1.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "		AND STOCK_H.SUPPLIERSLIPNORF = STOCK1.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "		LEFT JOIN STOCKCHECKDTLRF AS STCH1 WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "		ON" + Environment.NewLine;
                rstring += "			STCH1.ENTERPRISECODERF = STOCK1.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "		AND STCH1.SUPPLIERFORMALRF=STOCK1.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "		AND STCH1.STOCKSLIPDTLNUMRF=STOCK1.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "		WHERE" + Environment.NewLine;
                if (_supplierCheckOrderCndtnWork.ProcDiv == 0)
                { // 日次
                    rstring += "	STCH1.STOCKCHECKDIVDAILYRF = 1" + Environment.NewLine;
                }
                else if (_supplierCheckOrderCndtnWork.ProcDiv == 1)
                { // 締次
                    rstring += "	STCH1.STOCKCHECKDIVCADDUPRF = 1" + Environment.NewLine;
                }
                //rstring += "		AND STOCK1.LOGICALDELETECODERF =0" + Environment.NewLine;//DEL BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理------->>>>>>>
                // 伝票区分が「削除」場合
                if (_supplierCheckOrderCndtnWork.SlipDiv == 4)
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "		AND STOCK1.LOGICALDELETECODERF =1" + Environment.NewLine;
                    rstring += "		AND STOCK_H.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                else
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "		AND STOCK1.LOGICALDELETECODERF =0" + Environment.NewLine;
                    rstring += "		AND STOCK_H.LOGICALDELETECODERF =0" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理-------<<<<<<<
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "		AND STOCK1.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                //rstring += "		GROUP BY SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "		AND STOCK_H.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                rstring += "		AND STOCK_H.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                rstring += MakeWhereString3(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);
                rstring += "		GROUP BY STOCK1.SUPPLIERSLIPNORF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "	) AS A" + Environment.NewLine;
                rstring += "LEFT JOIN " + Environment.NewLine;
                rstring += "(SELECT " + Environment.NewLine;
                rstring += "         SLHI.CREATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,STCH.UPDATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "        ,SLHI.FILEHEADERGUIDRF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDEMPLOYEECODERF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDASSEMBLYID1RF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDASSEMBLYID2RF" + Environment.NewLine;
                rstring += "        ,SLHI.LOGICALDELETECODERF" + Environment.NewLine;
                //rstring += "	    ,SLHI.SECTIONCODERF" + Environment.NewLine; //DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "	    ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,STCH.STOCKCHECKDIVCADDUPRF" + Environment.NewLine;
                rstring += "        ,STCH.STOCKCHECKDIVDAILYRF" + Environment.NewLine;
                rstring += "        ,DETAIL.WAYTOORDERRF" + Environment.NewLine;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                rstring += "        ,SLIP.STOCKDATERF" + Environment.NewLine;
                rstring += "        ,SLIP.INPUTDAYRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICETAXINCRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICETAXEXCRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICECONSTAXRF" + Environment.NewLine;
                rstring += "        ,SLHI.GOODSNORF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKCOUNTRF" + Environment.NewLine;
                rstring += "        ,SLHI.BLGOODSCODERF" + Environment.NewLine;
                rstring += "        ,SLHI.GOODSNAMERF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,SLHI.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,SAHI.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,SAHI.SALESMONEYTAXEXCRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESDATERF" + Environment.NewLine;
                rstring += "        ,SALE.SALESSLIPNUMRF" + Environment.NewLine;
                rstring += "        ,SALE.CUSTOMERCODERF" + Environment.NewLine;
                rstring += "        ,SALE.CUSTOMERSNMRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,SALE.FRONTEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESINPUTNAMERF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                rstring += "        ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                //rstring += "        ,SALE.UOEREMARK1RF" + Environment.NewLine;
                //rstring += "        ,SALE.UOEREMARK2RF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                rstring += "        ,SLHI.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                // 2010/09/14 >>>
                //rstring += "        ,SUPP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                // 2010/09/14 <<<
                rstring += "        ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKPRICECONSTAXRF AS STOCKTTLPRICECONSTAXRF" + Environment.NewLine;
                // --- ADD 2010/10/21 ---------->>>>>
                rstring += "        ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                // --- ADD 2010/10/21 ----------<<<<<
                rstring += "        ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += " FROM STOCKSLHISTDTLRF AS SLHI" + Environment.NewLine;
                ////------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
                //rstring += "LEFT JOIN STOCKDETAILRF AS DETAIL" + Environment.NewLine;
                rstring += " FROM STOCKSLIPHISTRF AS SLIP WITH(READUNCOMMITTED)" + Environment.NewLine;
                rstring += " LEFT JOIN STOCKSLHISTDTLRF AS SLHI  WITH(READUNCOMMITTED)" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SLIP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERSLIPNORF=SLHI.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += " LEFT JOIN STOCKDETAILRF AS DETAIL  WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    DETAIL.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                //------DEL BY 凌小青 on 2012/09/12 for Redmine#31879------->>>>>>>
                //rstring += "	AND DETAIL.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                //rstring += "	AND DETAIL.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                //------DEL BY 凌小青 on 2012/09/12 for Redmine#31879-------<<<<<<<
                //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
                //------ADD BY 凌小青 on 2012/09/12 for Redmine#31879------->>>>>>>
                rstring += "	AND DETAIL.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALSRCRF" + Environment.NewLine;
                rstring += "	AND DETAIL.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                //------ADD BY 凌小青 on 2012/09/12 for Redmine#31879-------<<<<<<<
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN STOCKSLIPHISTRF AS SLIP" + Environment.NewLine;
                //rstring += "ON" + Environment.NewLine;
                //rstring += "	    SLIP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                //rstring += "	AND SLIP.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                //rstring += "	AND SLIP.SUPPLIERSLIPNORF=SLHI.SUPPLIERSLIPNORF" + Environment.NewLine;
                //rstring += "LEFT JOIN STOCKCHECKDTLRF AS STCH" + Environment.NewLine;
                rstring += "LEFT JOIN STOCKCHECKDTLRF AS STCH   WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    STCH.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND STCH.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	AND STCH.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN SALESHISTDTLRF AS SAHI" + Environment.NewLine;
                rstring += "LEFT JOIN SALESHISTDTLRF AS SAHI   WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SAHI.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SAHI.ACPTANODRSTATUSRF=SLHI.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                rstring += "	AND SAHI.SALESSLIPDTLNUMRF=SLHI.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN SALESHISTORYRF AS SALE" + Environment.NewLine;
                rstring += "LEFT JOIN SALESHISTORYRF AS SALE   WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SALE.ENTERPRISECODERF=SAHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SALE.ACPTANODRSTATUSRF=SAHI.ACPTANODRSTATUSRF" + Environment.NewLine;
                rstring += "	AND SALE.SALESSLIPNUMRF=SAHI.SALESSLIPNUMRF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN SUPPLIERRF AS SUPP" + Environment.NewLine;
                rstring += "LEFT JOIN SUPPLIERRF AS SUPP  WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SUPP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SUPP.SUPPLIERCDRF=SLIP.SUPPLIERCDRF" + Environment.NewLine;
                //WHERE文の作成
                //rstring += "WHERE SLHI.LOGICALDELETECODERF = 0" + Environment.NewLine;//DEL BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理------->>>>>>>
                // 伝票区分が「削除」場合
                if (_supplierCheckOrderCndtnWork.SlipDiv == 4)
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "WHERE SLHI.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    rstring += "WHERE SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                else
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "WHERE SLHI.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    rstring += "WHERE SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理-------<<<<<<<
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "	AND SLHI.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                rstring += "	AND SLIP.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                rstring += MakeWhereString4(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += " ) AS B" + Environment.NewLine;
                rstring += " ON B.SUPPLIERSLIPNORF = A.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += MakeWhereString2(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);
                // 2010/09/14 仕入先－仕入日－仕入伝票番号 >>>
                //rstring += "  ORDER BY A.SUPPLIERSLIPNORF" + Environment.NewLine;
                // 2010/09/17 >>>
                //rstring += "  ORDER BY B.SUPPLIERCDRF, B.STOCKDATERF, A.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "  ORDER BY B.SUPPLIERCDRF, B.STOCKDATERF, B.PARTYSALESLIPNUMRF" + Environment.NewLine;
                // 2010/09/17 <<<
                // 2010/09/14 <<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERP", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.EnterpriseCode);
                #endregion
            }
            else if (_supplierCheckOrderCndtnWork.CheckDiv == 1)
            {
                #region Select文 1:未チェック
                rstring += "SELECT " + Environment.NewLine;
                rstring += "         A.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,B.CREATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,B.UPDATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,B.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "        ,B.FILEHEADERGUIDRF" + Environment.NewLine;
                rstring += "        ,B.UPDEMPLOYEECODERF" + Environment.NewLine;
                rstring += "        ,B.UPDASSEMBLYID1RF" + Environment.NewLine;
                rstring += "        ,B.UPDASSEMBLYID2RF" + Environment.NewLine;
                rstring += "        ,B.LOGICALDELETECODERF" + Environment.NewLine;
                //rstring += "        ,B.SECTIONCODERF" + Environment.NewLine;//DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "	    ,B.STOCKSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,B.STOCKCHECKDIVCADDUPRF" + Environment.NewLine;
                rstring += "        ,B.STOCKCHECKDIVDAILYRF" + Environment.NewLine;
                rstring += "        ,B.STOCKDATERF" + Environment.NewLine;
                rstring += "        ,B.INPUTDAYRF" + Environment.NewLine;
                rstring += "        ,B.WAYTOORDERRF" + Environment.NewLine;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                rstring += "        ,B.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,B.PARTYSALESLIPNUMRF" + Environment.NewLine;
                rstring += "        ,B.STOCKPRICETAXINCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKPRICETAXEXCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKPRICECONSTAXRF" + Environment.NewLine;
                rstring += "        ,B.GOODSNORF" + Environment.NewLine;
                rstring += "        ,B.STOCKCOUNTRF" + Environment.NewLine;
                rstring += "        ,B.BLGOODSCODERF" + Environment.NewLine;
                rstring += "        ,B.GOODSNAMERF" + Environment.NewLine;
                rstring += "        ,B.STOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,B.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,B.SALESMONEYTAXEXCRF" + Environment.NewLine;
                rstring += "        ,B.SALESDATERF" + Environment.NewLine;
                rstring += "        ,B.SALESSLIPNUMRF" + Environment.NewLine;
                rstring += "        ,B.CUSTOMERCODERF" + Environment.NewLine;
                rstring += "        ,B.CUSTOMERSNMRF" + Environment.NewLine;
                rstring += "        ,B.SALESEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,B.FRONTEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,B.SALESINPUTNAMERF" + Environment.NewLine;
                rstring += "        ,B.UOEREMARK1RF" + Environment.NewLine;
                rstring += "        ,B.UOEREMARK2RF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERCDRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERSNMRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERFORMALRF" + Environment.NewLine;

                rstring += "        ,B.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "        ,B.STOCKGOODSCDRF" + Environment.NewLine;
                rstring += "        ,B.SUPPLIERSLIPCDRF" + Environment.NewLine;
                rstring += "        ,B.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,B.SUPPCTAXLAYCDRF" + Environment.NewLine;
                rstring += "        ,B.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                rstring += "        ,B.STOCKTTLPRICECONSTAXRF" + Environment.NewLine;
                // --- ADD 2010/10/21 ---------->>>>>
                rstring += "        ,B.STOCKTOTALPRICERF" + Environment.NewLine;
                rstring += "        ,B.STOCKSUBTTLPRICERF" + Environment.NewLine;
                // --- ADD 2010/10/21 ----------<<<<<
                rstring += "        ,B.DEBITNOTEDIVRF" + Environment.NewLine;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                rstring += "FROM(SELECT" + Environment.NewLine;
                rstring += " C.SUPPLIERSLIPNORF AS SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "FROM" + Environment.NewLine;
                rstring += " (SELECT " + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "		SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "		STOCK1.SUPPLIERSLIPNORF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "		,SUM(STCH1.STOCKCHECKDIVCADDUPRF) AS STOCKCHECKDIVCADDUPRF1" + Environment.NewLine;
                rstring += "		,SUM(STCH1.STOCKCHECKDIVDAILYRF) AS STOCKCHECKDIVDAILYRF1" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "		FROM STOCKSLHISTDTLRF AS STOCK1" + Environment.NewLine;
                //rstring += "		LEFT JOIN STOCKCHECKDTLRF AS STCH1" + Environment.NewLine;
                rstring += "		FROM STOCKSLIPHISTRF AS STOCK_H WITH(READUNCOMMITTED)" + Environment.NewLine; //ヘッダから読み込む
                rstring += "		LEFT JOIN STOCKSLHISTDTLRF AS STOCK1 WITH(READUNCOMMITTED)" + Environment.NewLine;
                rstring += "		ON" + Environment.NewLine;
                rstring += "		STOCK_H.ENTERPRISECODERF = STOCK1.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "		AND STOCK_H.SUPPLIERFORMALRF = STOCK1.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "		AND STOCK_H.SUPPLIERSLIPNORF = STOCK1.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "		LEFT JOIN STOCKCHECKDTLRF AS STCH1 WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "		ON" + Environment.NewLine;
                rstring += "			STCH1.ENTERPRISECODERF = STOCK1.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "		AND STCH1.SUPPLIERFORMALRF = STOCK1.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "		AND STCH1.STOCKSLIPDTLNUMRF = STOCK1.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                //rstring += "		WHERE STOCK1.LOGICALDELETECODERF = 0" + Environment.NewLine;//DEL BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理------->>>>>>>
                // 伝票区分が「削除」場合
                if (_supplierCheckOrderCndtnWork.SlipDiv == 4)
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "		WHERE STOCK1.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    rstring += "		WHERE STOCK_H.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                else
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "		WHERE STOCK1.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    rstring += "		WHERE STOCK_H.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理-------<<<<<<<
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "		AND STOCK1.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                //rstring += "		GROUP BY SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "		AND STOCK_H.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                rstring += "		AND STOCK_H.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                rstring += MakeWhereString3(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);
                rstring += "		GROUP BY STOCK1.SUPPLIERSLIPNORF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += ")AS C" + Environment.NewLine;
                rstring += " WHERE" + Environment.NewLine;
                if (_supplierCheckOrderCndtnWork.ProcDiv == 0)
                {
                    rstring += "	STOCKCHECKDIVDAILYRF1 =0 OR STOCKCHECKDIVDAILYRF1 IS NULL" + Environment.NewLine;
                }
                else if (_supplierCheckOrderCndtnWork.ProcDiv == 1)
                {
                    rstring += "	STOCKCHECKDIVCADDUPRF1 =0 OR STOCKCHECKDIVCADDUPRF1 IS NULL" + Environment.NewLine;
                }
                rstring += "" + Environment.NewLine;
                rstring += "	) AS A" + Environment.NewLine;
                rstring += "LEFT JOIN " + Environment.NewLine;
                rstring += " (SELECT " + Environment.NewLine;
                rstring += "         SLHI.CREATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,STCH.UPDATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "        ,SLHI.FILEHEADERGUIDRF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDEMPLOYEECODERF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDASSEMBLYID1RF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDASSEMBLYID2RF" + Environment.NewLine;
                rstring += "        ,SLHI.LOGICALDELETECODERF" + Environment.NewLine;
                //rstring += "	    ,SLHI.SECTIONCODERF" + Environment.NewLine; //DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "	    ,SLIP.STOCKSECTIONCDRF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,STCH.STOCKCHECKDIVCADDUPRF" + Environment.NewLine;
                rstring += "        ,STCH.STOCKCHECKDIVDAILYRF" + Environment.NewLine;
                rstring += "        ,DETAIL.WAYTOORDERRF" + Environment.NewLine;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                rstring += "        ,SLIP.STOCKSLIPUPDATECDRF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,SLIP.STOCKDATERF" + Environment.NewLine;
                rstring += "        ,SLIP.INPUTDAYRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICETAXINCRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICETAXEXCRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICECONSTAXRF" + Environment.NewLine;
                rstring += "        ,SLHI.GOODSNORF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKCOUNTRF" + Environment.NewLine;
                rstring += "        ,SLHI.BLGOODSCODERF" + Environment.NewLine;
                rstring += "        ,SLHI.GOODSNAMERF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,SLHI.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,SAHI.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,SAHI.SALESMONEYTAXEXCRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESDATERF" + Environment.NewLine;
                rstring += "        ,SALE.SALESSLIPNUMRF" + Environment.NewLine;
                rstring += "        ,SALE.CUSTOMERCODERF" + Environment.NewLine;
                rstring += "        ,SALE.CUSTOMERSNMRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,SALE.FRONTEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESINPUTNAMERF" + Environment.NewLine;
                //-----DEL BY 凌小青 on 2012/08/30 for Redmine#31879--------->>>>>>>
                //rstring += "        ,SALE.UOEREMARK1RF" + Environment.NewLine;
                //rstring += "        ,SALE.UOEREMARK2RF" + Environment.NewLine;
                //-----DEL BY 凌小青 on 2012/08/30 for Redmine#31879---------<<<<<<<
                //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879--------->>>>>>>
                rstring += "        ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                rstring += "        ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879---------<<<<<<<
                rstring += "        ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                rstring += "        ,SLHI.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                // 2010/09/14 >>>
                //rstring += "        ,SUPP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                // 2010/09/14 <<<
                rstring += "        ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKPRICECONSTAXRF AS STOCKTTLPRICECONSTAXRF" + Environment.NewLine;
                // --- ADD 2010/10/21 ---------->>>>>
                rstring += "        ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                // --- ADD 2010/10/21 ----------<<<<<
                rstring += "        ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += " FROM STOCKSLHISTDTLRF AS SLHI" + Environment.NewLine;
                ////------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
                //rstring += "LEFT JOIN STOCKDETAILRF AS DETAIL" + Environment.NewLine;
                rstring += " FROM STOCKSLIPHISTRF AS SLIP WITH(READUNCOMMITTED)" + Environment.NewLine;
                rstring += "LEFT JOIN STOCKSLHISTDTLRF AS SLHI  WITH(READUNCOMMITTED)" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SLIP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERSLIPNORF=SLHI.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += " LEFT JOIN STOCKDETAILRF AS DETAIL  WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    DETAIL.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                //------DEL BY 凌小青 on 2012/09/12 for Redmine#31879------->>>>>>>
                //rstring += "	AND DETAIL.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                //rstring += "	AND DETAIL.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                //------DEL BY 凌小青 on 2012/09/12 for Redmine#31879-------<<<<<<<
                //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
                //------ADD BY 凌小青 on 2012/09/12 for Redmine#31879------->>>>>>>
                rstring += "	AND DETAIL.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALSRCRF" + Environment.NewLine;
                rstring += "	AND DETAIL.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                //------ADD BY 凌小青 on 2012/09/12 for Redmine#31879-------<<<<<<<
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN STOCKSLIPHISTRF AS SLIP" + Environment.NewLine;
                //rstring += "ON" + Environment.NewLine;
                //rstring += "	    SLIP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                //rstring += "	AND SLIP.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                //rstring += "	AND SLIP.SUPPLIERSLIPNORF=SLHI.SUPPLIERSLIPNORF" + Environment.NewLine;
                //rstring += "LEFT JOIN STOCKCHECKDTLRF AS STCH" + Environment.NewLine;
                rstring += "LEFT JOIN STOCKCHECKDTLRF AS STCH   WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    STCH.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND STCH.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	AND STCH.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN SALESHISTDTLRF AS SAHI" + Environment.NewLine;
                rstring += "LEFT JOIN SALESHISTDTLRF AS SAHI  WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SAHI.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SAHI.ACPTANODRSTATUSRF=SLHI.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                rstring += "	AND SAHI.SALESSLIPDTLNUMRF=SLHI.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN SALESHISTORYRF AS SALE" + Environment.NewLine;
                rstring += "LEFT JOIN SALESHISTORYRF AS SALE  WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SALE.ENTERPRISECODERF=SAHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SALE.ACPTANODRSTATUSRF=SAHI.ACPTANODRSTATUSRF" + Environment.NewLine;
                rstring += "	AND SALE.SALESSLIPNUMRF=SAHI.SALESSLIPNUMRF" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "LEFT JOIN SUPPLIERRF AS SUPP" + Environment.NewLine;
                rstring += "LEFT JOIN SUPPLIERRF AS SUPP  WITH(READUNCOMMITTED)" + Environment.NewLine;
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SUPP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SUPP.SUPPLIERCDRF=SLIP.SUPPLIERCDRF" + Environment.NewLine;
                //rstring += "		WHERE SLHI.LOGICALDELETECODERF = 0" + Environment.NewLine;//DEL BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理------->>>>>>>
                // 伝票区分が「削除」場合
                if (_supplierCheckOrderCndtnWork.SlipDiv == 4)
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "		WHERE SLHI.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    rstring += "		WHERE SLIP.LOGICALDELETECODERF = 1" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                else
                {
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                    //rstring += "		WHERE SLHI.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    rstring += "		WHERE SLIP.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                }
                ////------ADD BY 李魏 K2015/09/24 for Redmine#47300 MKアシスト／仕入チェック処理-------<<<<<<<
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
                //rstring += "	AND SLHI.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                rstring += "	AND SLIP.ENTERPRISECODERF = @ENTERP" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                rstring += MakeWhereString4(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);
                // ------ UPD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
                rstring += " ) AS B" + Environment.NewLine;
                rstring += " ON B.SUPPLIERSLIPNORF = A.SUPPLIERSLIPNORF" + Environment.NewLine;
                //WHERE文の作成
                rstring += MakeWhereString2(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);
                // 2010/09/14 仕入先－仕入日－仕入伝票番号 >>>
                //rstring += " ORDER BY A.SUPPLIERSLIPNORF" + Environment.NewLine;
                // 2010/09/17 >>>
                //rstring += " ORDER BY B.SUPPLIERCDRF, B.STOCKDATERF, A.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += " ORDER BY B.SUPPLIERCDRF, B.STOCKDATERF, B.PARTYSALESLIPNUMRF" + Environment.NewLine;
                // 2010/09/17 <<<
                // 2010/09/14 <<<

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERP", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.EnterpriseCode);

                #endregion
            }
            else
            {
                #region Select文 全て


                rstring += "SELECT " + Environment.NewLine;
                rstring += "	     SLHI.CREATEDATETIMERF" + Environment.NewLine;
                //rstring += "      ,SLHI.UPDATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,STCH.UPDATEDATETIMERF" + Environment.NewLine;
                rstring += "        ,SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "        ,SLHI.FILEHEADERGUIDRF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDEMPLOYEECODERF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDASSEMBLYID1RF" + Environment.NewLine;
                rstring += "        ,SLHI.UPDASSEMBLYID2RF" + Environment.NewLine;
                rstring += "        ,SLHI.LOGICALDELETECODERF" + Environment.NewLine;
                //rstring += "	    ,SLHI.SECTIONCODERF" + Environment.NewLine; //DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "	    ,SLIP.STOCKSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine;//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                rstring += "        ,STCH.STOCKCHECKDIVCADDUPRF" + Environment.NewLine;
                rstring += "        ,STCH.STOCKCHECKDIVDAILYRF" + Environment.NewLine;
                rstring += "        ,DETAIL.WAYTOORDERRF" + Environment.NewLine;//ADD BY 凌小青 on 2012/08/30 for Redmine#31879
                rstring += "        ,SLIP.STOCKDATERF" + Environment.NewLine;
                rstring += "        ,SLIP.INPUTDAYRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "        ,SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICETAXINCRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICETAXEXCRF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKPRICECONSTAXRF" + Environment.NewLine;
                rstring += "        ,SLHI.GOODSNORF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKCOUNTRF" + Environment.NewLine;
                rstring += "        ,SLHI.BLGOODSCODERF" + Environment.NewLine;
                rstring += "        ,SLHI.GOODSNAMERF" + Environment.NewLine;
                rstring += "        ,SLHI.STOCKUNITPRICEFLRF" + Environment.NewLine;
                rstring += "        ,SLHI.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,SAHI.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                rstring += "        ,SAHI.SALESMONEYTAXEXCRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESDATERF" + Environment.NewLine;
                rstring += "        ,SALE.SALESSLIPNUMRF" + Environment.NewLine;
                rstring += "        ,SALE.CUSTOMERCODERF" + Environment.NewLine;
                rstring += "        ,SALE.CUSTOMERSNMRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,SALE.FRONTEMPLOYEENMRF" + Environment.NewLine;
                rstring += "        ,SALE.SALESINPUTNAMERF" + Environment.NewLine;
                //-----DEL BY 凌小青 on 2012/08/30 for Redmine#31879--------->>>>>>>
                //rstring += "        ,SALE.UOEREMARK1RF" + Environment.NewLine;
                //rstring += "        ,SALE.UOEREMARK2RF" + Environment.NewLine;
                //-----DEL BY 凌小青 on 2012/08/30 for Redmine#31879---------<<<<<<<
                //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879--------->>>>>>>
                rstring += "        ,SLIP.UOEREMARK1RF" + Environment.NewLine;
                rstring += "        ,SLIP.UOEREMARK2RF" + Environment.NewLine;
                //-----ADD BY 凌小青 on 2012/08/30 for Redmine#31879---------<<<<<<<
                rstring += "        ,SLIP.SUPPLIERCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSNMRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	    ,SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKGOODSCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPLIERSLIPCDRF" + Environment.NewLine;
                rstring += "        ,SLHI.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
                // 2010/09/14 >>>
                //rstring += "        ,SUPP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                rstring += "        ,SLIP.SUPPCTAXLAYCDRF" + Environment.NewLine;
                // 2010/09/14 <<<
                rstring += "        ,SLIP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKPRICECONSTAXRF AS STOCKTTLPRICECONSTAXRF" + Environment.NewLine;
                // --- ADD 2010/10/21 ---------->>>>>
                rstring += "        ,SLIP.STOCKTOTALPRICERF" + Environment.NewLine;
                rstring += "        ,SLIP.STOCKSUBTTLPRICERF" + Environment.NewLine;
                // --- ADD 2010/10/21 ----------<<<<<
                rstring += "        ,SLIP.DEBITNOTEDIVRF" + Environment.NewLine;//ADD BY 朱 猛 on 2012/10/09 for Redmine#31879
                rstring += " FROM STOCKSLHISTDTLRF AS SLHI" + Environment.NewLine;
                //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
                rstring += "LEFT JOIN STOCKDETAILRF AS DETAIL" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    DETAIL.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                //------DEL BY 凌小青 on 2012/09/12 for Redmine#31879------->>>>>>>
                //rstring += "	AND DETAIL.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                //rstring += "	AND DETAIL.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                //------DEL BY 凌小青 on 2012/09/12 for Redmine#31879-------<<<<<<<
                //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
                //------ADD BY 凌小青 on 2012/09/12 for Redmine#31879------->>>>>>>
                rstring += "	AND DETAIL.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALSRCRF" + Environment.NewLine;
                rstring += "	AND DETAIL.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
                //------ADD BY 凌小青 on 2012/09/12 for Redmine#31879-------<<<<<<<
                rstring += "LEFT JOIN STOCKSLIPHISTRF AS SLIP" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SLIP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	AND SLIP.SUPPLIERSLIPNORF=SLHI.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += "LEFT JOIN STOCKCHECKDTLRF AS STCH" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    STCH.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND STCH.SUPPLIERFORMALRF=SLHI.SUPPLIERFORMALRF" + Environment.NewLine;
                rstring += "	AND STCH.STOCKSLIPDTLNUMRF=SLHI.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                rstring += "LEFT JOIN SALESHISTDTLRF AS SAHI" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SAHI.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SAHI.ACPTANODRSTATUSRF=SLHI.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
                rstring += "	AND SAHI.SALESSLIPDTLNUMRF=SLHI.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
                rstring += "LEFT JOIN SALESHISTORYRF AS SALE" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SALE.ENTERPRISECODERF=SAHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SALE.ACPTANODRSTATUSRF=SAHI.ACPTANODRSTATUSRF" + Environment.NewLine;
                rstring += "	AND SALE.SALESSLIPNUMRF=SAHI.SALESSLIPNUMRF" + Environment.NewLine;
                rstring += "LEFT JOIN SUPPLIERRF AS SUPP" + Environment.NewLine;
                rstring += "ON" + Environment.NewLine;
                rstring += "	    SUPP.ENTERPRISECODERF=SLHI.ENTERPRISECODERF" + Environment.NewLine;
                rstring += "	AND SUPP.SUPPLIERCDRF=SLIP.SUPPLIERCDRF" + Environment.NewLine;

                //WHERE文の作成
                rstring += MakeWhereString(ref sqlCommand, _supplierCheckOrderCndtnWork, logicalMode);

                // 2010/09/14 仕入先－仕入日－仕入伝票番号 >>>
                //rstring += " ORDER BY SLHI.SUPPLIERSLIPNORF" + Environment.NewLine;
                // 2010/09/17 >>>
                //rstring += " ORDER BY SLIP.SUPPLIERCDRF, SLIP.STOCKDATERF, SLIP.SUPPLIERSLIPNORF" + Environment.NewLine;
                rstring += " ORDER BY SLIP.SUPPLIERCDRF, SLIP.STOCKDATERF, SLIP.PARTYSALESLIPNUMRF" + Environment.NewLine;
                // 2010/09/17 <<<
                // 2010/09/14 <<<
                #endregion
            }
            return rstring;
        }

        #endregion

        #region Write
        /// <summary>
        /// 仕入チェック処理情報を追加・更新します（論理削除除く）
        /// </summary>
        /// <param name="al">追加・更新</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入チェック処理情報を追加・更新します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        public int Write(ref object al)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = al as ArrayList;
                if (paraList == null) return status;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //write実行
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                al = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RateProtyMngDB.Write(ref object supplierCheckResultWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        private ArrayList CastToArrayListFromPara(object al)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// 仕入チェック処理情報を追加・更新します（論理削除除く）
        /// </summary>
        /// <param name="al">追加・更新</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入チェック処理情報を追加・更新します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.2</br>
        private int WriteProc(ref ArrayList stockCheckList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (stockCheckList != null)
                {
                    for (int i = 0; i < stockCheckList.Count; i++)
                    {
                        string sqlText = string.Empty;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        StockCheckDtlWork stockCheckDtlWork = stockCheckList[i] as StockCheckDtlWork;

                        # region [SELECT文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  STCH.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  STOCKCHECKDTLRF AS STCH" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  STCH.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND STCH.SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND STCH.STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockCheckDtlWork.EnterpriseCode);
                        findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockCheckDtlWork.SupplierFormal);
                        findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockCheckDtlWork.StockSlipDtlNum);

                        myReader = sqlCommand.ExecuteReader();


                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != stockCheckDtlWork.UpdateDateTime)
                            {
                                if (stockCheckDtlWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // 既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            #region [UPDATE文]
                            sqlText += "UPDATE STOCKCHECKDTLRF SET " + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SUPPLIERFORMALRF=@SUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += " , STOCKSLIPDTLNUMRF=@STOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlText += " , STOCKCHECKDIVCADDUPRF=@STOCKCHECKDIVCADDUP" + Environment.NewLine;
                            sqlText += " , STOCKCHECKDIVDAILYRF=@STOCKCHECKDIVDAILY" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "        AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "        AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            #endregion
                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockCheckDtlWork.EnterpriseCode);
                            findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockCheckDtlWork.SupplierFormal);
                            findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockCheckDtlWork.StockSlipDtlNum);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockCheckDtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (stockCheckDtlWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT文
                            sqlText += "INSERT INTO STOCKCHECKDTLRF" + Environment.NewLine;
                            sqlText += " 	(CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "        ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "        ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "        ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "        ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "        ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "        ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "        ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "        ,SUPPLIERFORMALRF" + Environment.NewLine;
                            sqlText += "        ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "        ,STOCKCHECKDIVCADDUPRF" + Environment.NewLine;
                            sqlText += "        ,STOCKCHECKDIVDAILYRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " 	(@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "        ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "        ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "        ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "        ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "        ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "        ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "        ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "        ,@SUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += 
                                "        ,@STOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "        ,@STOCKCHECKDIVCADDUP" + Environment.NewLine;
                            sqlText += "        ,@STOCKCHECKDIVDAILY" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            #endregion
                            sqlCommand.CommandText = sqlText;

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)stockCheckDtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                        SqlParameter paraStockCheckDivCAddUp = sqlCommand.Parameters.Add("@STOCKCHECKDIVCADDUP", SqlDbType.Int);
                        SqlParameter paraStockCheckDivDaily = sqlCommand.Parameters.Add("@STOCKCHECKDIVDAILY", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockCheckDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockCheckDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockCheckDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockCheckDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockCheckDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockCheckDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockCheckDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockCheckDtlWork.LogicalDeleteCode);
                        paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockCheckDtlWork.SupplierFormal);
                        paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockCheckDtlWork.StockSlipDtlNum);
                        paraStockCheckDivCAddUp.Value = SqlDataMediator.SqlSetInt32(stockCheckDtlWork.StockCheckDivCAddUp);
                        paraStockCheckDivDaily.Value = SqlDataMediator.SqlSetInt32(stockCheckDtlWork.StockCheckDivDaily);

                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(stockCheckDtlWork);

                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            stockCheckList = al;

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;
            // 企業コード
            retstring += " SLHI.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.EnterpriseCode);

            // 拠点コード
            if (_supplierCheckOrderCndtnWork.SectionCode != "")
            {
                //retstring += " AND SLHI.SECTIONCODERF=@SECTIONCODE"; //DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理　
                retstring += " AND SLIP.STOCKSECTIONCDRF=@SECTIONCODE";//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.SectionCode);
            }
            // 仕入先コード
            if (_supplierCheckOrderCndtnWork.SupplierCd != 0)
            {
                retstring += " AND SLIP.SUPPLIERCDRF=@SUPPLIERCD";
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.SupplierCd);
            }

            // 伝票区分/全て
            if (_supplierCheckOrderCndtnWork.SlipDiv == 0)
            {
                retstring += " AND SLHI.LOGICALDELETECODERF = 0";
            }
            //仕入
            else if (_supplierCheckOrderCndtnWork.SlipDiv == 1)
            {
                retstring += " AND (SLHI.LOGICALDELETECODERF = 0 AND SLIP.SUPPLIERSLIPCDRF=10)";
            }
            //返品
            else if (_supplierCheckOrderCndtnWork.SlipDiv == 2)
            {
                retstring += " AND (SLHI.LOGICALDELETECODERF = 0 AND SLIP.SUPPLIERSLIPCDRF=20)";
            }
            //訂正
            else if (_supplierCheckOrderCndtnWork.SlipDiv == 3)
            {
                retstring += " AND (SLHI.LOGICALDELETECODERF = 0 AND SLIP.STOCKSLIPUPDATECDRF=1)";
            }
            //削除
            else
            {
                retstring += " AND (SLHI.LOGICALDELETECODERF = 1)";
            }
            // 仕入日
            if (_supplierCheckOrderCndtnWork.St_StockDate != 0)
            {
                retstring += " AND SLIP.STOCKDATERF>=@STSTOCKDATE" + Environment.NewLine;
                SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                paraStStockDate.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_StockDate);
            }
            if (_supplierCheckOrderCndtnWork.Ed_StockDate != 0)
            {
                retstring += " AND SLIP.STOCKDATERF<=@EDSTOCKDATE" + Environment.NewLine;
                SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                paraEdStockDate.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_StockDate);
            }

            // 入力日
            if (_supplierCheckOrderCndtnWork.St_InputDay != 0)
            {
                retstring += " AND SLIP.INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_InputDay);
            }
            if (_supplierCheckOrderCndtnWork.Ed_InputDay != 0)
            {
                retstring += " AND SLIP.INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_InputDay);
            }

            // 仕入SEQ番号
            if (_supplierCheckOrderCndtnWork.St_SupplierSlipNo != 0)
            {
                retstring += " AND SLHI.SUPPLIERSLIPNORF>=@STSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraStSupplierSlipNo = sqlCommand.Parameters.Add("@STSUPPLIERSLIPNO", SqlDbType.Int);
                paraStSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_SupplierSlipNo);
            }
            if (_supplierCheckOrderCndtnWork.Ed_SupplierSlipNo != 0)
            {
                retstring += " AND SLHI.SUPPLIERSLIPNORF<=@EDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraEdSupplierSlipNo = sqlCommand.Parameters.Add("@EDSUPPLIERSLIPNO", SqlDbType.Int);
                paraEdSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_SupplierSlipNo);
            }

            // 伝票番号
            if (_supplierCheckOrderCndtnWork.St_PartySaleSlipNum != "")
            {
                retstring += " AND SLIP.PARTYSALESLIPNUMRF>=@STPARTYSALESLIPNUM" + Environment.NewLine;
                SqlParameter paraStPartySaleSlipNum = sqlCommand.Parameters.Add("@STPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraStPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.St_PartySaleSlipNum);
            }
            if (_supplierCheckOrderCndtnWork.Ed_PartySaleSlipNum != "")
            {
                retstring += " AND SLIP.PARTYSALESLIPNUMRF<=@EDPARTYSALESLIPNUM" + Environment.NewLine;
                SqlParameter paraEdPartySaleSlipNum = sqlCommand.Parameters.Add("@EDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraEdPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.Ed_PartySaleSlipNum);
            }
            #endregion
            return retstring;
        }

                /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString2(ref SqlCommand sqlCommand, SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;
            // 企業コード
            retstring += " B.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.EnterpriseCode);

            // 拠点コード
            if (_supplierCheckOrderCndtnWork.SectionCode != "")
            {
                //retstring += " AND B.SECTIONCODERF=@SECTIONCODE"; //DEL BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理　
                retstring += " AND B.STOCKSECTIONCDRF=@SECTIONCODE";//ADD BY 李魏 K2015/09/07 for Redmine#47300 MKアシスト／仕入チェック処理
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.SectionCode);
            }
            // 仕入先コード
            if (_supplierCheckOrderCndtnWork.SupplierCd != 0)
            {
                retstring += " AND B.SUPPLIERCDRF=@SUPPLIERCD";
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.SupplierCd);
            }

            // 伝票区分/全て
            if (_supplierCheckOrderCndtnWork.SlipDiv == 0)
            {
                retstring += " AND B.LOGICALDELETECODERF = 0";
            }
            //仕入
            else if (_supplierCheckOrderCndtnWork.SlipDiv == 1)
            {
                retstring += " AND (B.LOGICALDELETECODERF = 0 AND B.SUPPLIERSLIPCDRF=10)";
            }
            //返品
            else if (_supplierCheckOrderCndtnWork.SlipDiv == 2)
            {
                retstring += " AND (B.LOGICALDELETECODERF = 0 AND B.SUPPLIERSLIPCDRF=20)";
            }
            //訂正
            else if (_supplierCheckOrderCndtnWork.SlipDiv == 3)
            {
                retstring += " AND (B.LOGICALDELETECODERF = 0 AND B.STOCKSLIPUPDATECDRF=1)";
            }
            //削除
            else
            {
                retstring += " AND (B.LOGICALDELETECODERF = 1)";
            }

            //if (_supplierCheckOrderCndtnWork.CheckDiv == 1 && _supplierCheckOrderCndtnWork.ProcDiv ==0)
            //{
            //    retstring += " AND (STCH.STOCKCHECKDIVDAILYRF = 0 OR STCH.STOCKCHECKDIVDAILYRF IS NULL)";
            //}
            //else if (_supplierCheckOrderCndtnWork.CheckDiv == 2 && _supplierCheckOrderCndtnWork.ProcDiv == 0)
            //{
            //    retstring += " AND STCH.STOCKCHECKDIVDAILYRF = 1";
            //}
            //else if (_supplierCheckOrderCndtnWork.CheckDiv ==1 && _supplierCheckOrderCndtnWork.ProcDiv ==1)
            //{
            //    retstring += " AND (STCH.STOCKCHECKDIVCADDUPRF = 0 OR STCH.STOCKCHECKDIVCADDUPRF IS NULL)";
            //}
            //else if (_supplierCheckOrderCndtnWork.CheckDiv == 2 && _supplierCheckOrderCndtnWork.ProcDiv == 1)
            //{
            //    retstring += " AND STCH.STOCKCHECKDIVCADDUPRF = 1";
            //}

            // 仕入日
            if (_supplierCheckOrderCndtnWork.St_StockDate != 0)
            {
                retstring += " AND B.STOCKDATERF>=@STSTOCKDATE" + Environment.NewLine;
                SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                paraStStockDate.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_StockDate);
            }
            if (_supplierCheckOrderCndtnWork.Ed_StockDate != 0)
            {
                retstring += " AND B.STOCKDATERF<=@EDSTOCKDATE" + Environment.NewLine;
                SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                paraEdStockDate.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_StockDate);
            }

            // 入力日
            if (_supplierCheckOrderCndtnWork.St_InputDay != 0)
            {
                retstring += " AND B.INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_InputDay);
            }
            if (_supplierCheckOrderCndtnWork.Ed_InputDay != 0)
            {
                retstring += " AND B.INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_InputDay);
            }

            // 仕入SEQ番号
            if (_supplierCheckOrderCndtnWork.St_SupplierSlipNo != 0)
            {
                retstring += " AND A.SUPPLIERSLIPNORF>=@STSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraStSupplierSlipNo = sqlCommand.Parameters.Add("@STSUPPLIERSLIPNO", SqlDbType.Int);
                paraStSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_SupplierSlipNo);
            }
            if (_supplierCheckOrderCndtnWork.Ed_SupplierSlipNo != 0)
            {
                retstring += " AND A.SUPPLIERSLIPNORF<=@EDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraEdSupplierSlipNo = sqlCommand.Parameters.Add("@EDSUPPLIERSLIPNO", SqlDbType.Int);
                paraEdSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_SupplierSlipNo);
            }

            // 伝票番号
            if (_supplierCheckOrderCndtnWork.St_PartySaleSlipNum != "")
            {
                retstring += " AND B.PARTYSALESLIPNUMRF>=@STPARTYSALESLIPNUM" + Environment.NewLine;
                SqlParameter paraStPartySaleSlipNum = sqlCommand.Parameters.Add("@STPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraStPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.St_PartySaleSlipNum);
            }
            if (_supplierCheckOrderCndtnWork.Ed_PartySaleSlipNum != "")
            {
                retstring += " AND B.PARTYSALESLIPNUMRF<=@EDPARTYSALESLIPNUM" + Environment.NewLine;
                SqlParameter paraEdPartySaleSlipNum = sqlCommand.Parameters.Add("@EDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraEdPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.Ed_PartySaleSlipNum);
            }
            #endregion
            return retstring;
        }

        // ------ ADD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142-------->>>>>
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : 検索条件文字列生成＋条件値設定</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/05/31</br>
        private string MakeWhereString3(ref SqlCommand sqlCommand, SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = string.Empty;

            // 拠点コード
            if (_supplierCheckOrderCndtnWork.SectionCode != "")
            {
                retstring += " AND STOCK_H.STOCKSECTIONCDRF=@SECTIONCODECHILDA";
                SqlParameter paraSectionCodeChildA = sqlCommand.Parameters.Add("@SECTIONCODECHILDA", SqlDbType.NChar);
                paraSectionCodeChildA.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.SectionCode);
            }
            // 仕入先コード
            if (_supplierCheckOrderCndtnWork.SupplierCd != 0)
            {
                retstring += " AND STOCK_H.SUPPLIERCDRF=@SUPPLIERCDCHILDA";
                SqlParameter paraSupplierCdChildA = sqlCommand.Parameters.Add("@SUPPLIERCDCHILDA", SqlDbType.Int);
                paraSupplierCdChildA.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.SupplierCd);
            }

            // 仕入日
            if (_supplierCheckOrderCndtnWork.St_StockDate != 0)
            {
                retstring += " AND STOCK_H.STOCKDATERF>=@STSTOCKDATECHILDA" + Environment.NewLine;
                SqlParameter paraStStockDateChildA = sqlCommand.Parameters.Add("@STSTOCKDATECHILDA", SqlDbType.Int);
                paraStStockDateChildA.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_StockDate);
            }
            if (_supplierCheckOrderCndtnWork.Ed_StockDate != 0)
            {
                retstring += " AND STOCK_H.STOCKDATERF<=@EDSTOCKDATECHILDA" + Environment.NewLine;
                SqlParameter paraEdStockDateChildA = sqlCommand.Parameters.Add("@EDSTOCKDATECHILDA", SqlDbType.Int);
                paraEdStockDateChildA.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_StockDate);
            }

            // 入力日
            if (_supplierCheckOrderCndtnWork.St_InputDay != 0)
            {
                retstring += " AND STOCK_H.INPUTDAYRF>=@STINPUTDAYCHILDA" + Environment.NewLine;
                SqlParameter paraStInputDayChildA = sqlCommand.Parameters.Add("@STINPUTDAYCHILDA", SqlDbType.Int);
                paraStInputDayChildA.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_InputDay);
            }
            if (_supplierCheckOrderCndtnWork.Ed_InputDay != 0)
            {
                retstring += " AND STOCK_H.INPUTDAYRF<=@EDINPUTDAYCHILDA" + Environment.NewLine;
                SqlParameter paraEdInputDayChildA = sqlCommand.Parameters.Add("@EDINPUTDAYCHILDA", SqlDbType.Int);
                paraEdInputDayChildA.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_InputDay);
            }
            #endregion
            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_orderListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : 検索条件文字列生成＋条件値設定</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/05/31</br>
        private string MakeWhereString4(ref SqlCommand sqlCommand, SupplierCheckOrderCndtnWork _supplierCheckOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = string.Empty;

            // 拠点コード
            if (_supplierCheckOrderCndtnWork.SectionCode != "")
            {
                retstring += " AND SLIP.STOCKSECTIONCDRF=@SECTIONCODECHILDB";
                SqlParameter paraSectionCodeChildB = sqlCommand.Parameters.Add("@SECTIONCODECHILDB", SqlDbType.NChar);
                paraSectionCodeChildB.Value = SqlDataMediator.SqlSetString(_supplierCheckOrderCndtnWork.SectionCode);
            }
            // 仕入先コード
            if (_supplierCheckOrderCndtnWork.SupplierCd != 0)
            {
                retstring += " AND SLIP.SUPPLIERCDRF=@SUPPLIERCDCHILDB";
                SqlParameter paraSupplierCdChildB = sqlCommand.Parameters.Add("@SUPPLIERCDCHILDB", SqlDbType.Int);
                paraSupplierCdChildB.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.SupplierCd);
            }

            // 仕入日
            if (_supplierCheckOrderCndtnWork.St_StockDate != 0)
            {
                retstring += " AND SLIP.STOCKDATERF>=@STSTOCKDATECHILDB" + Environment.NewLine;
                SqlParameter paraStStockDateChildB = sqlCommand.Parameters.Add("@STSTOCKDATECHILDB", SqlDbType.Int);
                paraStStockDateChildB.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_StockDate);
            }
            if (_supplierCheckOrderCndtnWork.Ed_StockDate != 0)
            {
                retstring += " AND SLIP.STOCKDATERF<=@EDSTOCKDATECHILDB" + Environment.NewLine;
                SqlParameter paraEdStockDateChildB = sqlCommand.Parameters.Add("@EDSTOCKDATECHILDB", SqlDbType.Int);
                paraEdStockDateChildB.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_StockDate);
            }

            // 入力日
            if (_supplierCheckOrderCndtnWork.St_InputDay != 0)
            {
                retstring += " AND SLIP.INPUTDAYRF>=@STINPUTDAYCHILDB" + Environment.NewLine;
                SqlParameter paraStInputDayChildB = sqlCommand.Parameters.Add("@STINPUTDAYCHILDB", SqlDbType.Int);
                paraStInputDayChildB.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.St_InputDay);
            }
            if (_supplierCheckOrderCndtnWork.Ed_InputDay != 0)
            {
                retstring += " AND SLIP.INPUTDAYRF<=@EDINPUTDAYCHILDB" + Environment.NewLine;
                SqlParameter paraEdInputDayChildB = sqlCommand.Parameters.Add("@EDINPUTDAYCHILDB", SqlDbType.Int);
                paraEdInputDayChildB.Value = SqlDataMediator.SqlSetInt32(_supplierCheckOrderCndtnWork.Ed_InputDay);
            }
            #endregion
            return retstring;
        }
        // ------ ADD 2021/05/31 陳艶丹 FOR PMKOBETSU-4142--------<<<<<
    }
}


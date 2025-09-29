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
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上データ検索リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データの検索を行うクラスです</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.03.23</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2007.10.05</br>
    /// <br>             流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2007.12.10</br>
    /// <br>             EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2007.12.13</br>
    /// <br>             論理削除区分のチェックを追加</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2008.01.10</br>
    /// <br>             抽出パラメータの追加・変更</br>
    /// <br>             相手先伝票番号を抽出条件に追加</br>
    /// <br>             売上伝票番号を単独指定から範囲指定に変更</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2008.01.11</br>
    /// <br>             結果パラメータに拠点名・部門名・課名を追加</br>
    /// <br></br>
    /// <br>Update Note: 980081 山田 明友</br>
    /// <br>Date       : 2008.02.28</br>
    /// <br>             出荷日付・見積区分を抽出処理条件に追加</br>
    /// <br></br>
    /// <br>Update Note: 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.23</br>
    /// <br>             ＰＭ.ＮＳ用に変更</br>
    /// <br></br>
    /// <br>Update Note: 23015 森本 大輝</br>
    /// <br>Date       : 2008.09.16</br>
    /// <br>             エラー対応</br>
    /// <br></br>
    /// <br>Update Note: 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.06</br>
    /// <br>             抽出拠点コード修正</br>
    /// <br></br>
    /// <br>Update Note: 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br>             車輌取得不具合修正</br>
    /// <br></br>
    /// <br>Update Note: 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br>             返却値のソート順修正</br>
    /// <br></br>
    /// <br>Update Note: 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.01.08</br>
    /// <br>             受注・貸出計上済み伝票は対象外に修正</br>
    /// <br></br>
    /// <br>Update Note: 23012 畠中 啓次朗</br>
    /// <br>Date       : 2009.02.02</br>
    /// <br>             検索見積伝票の対象外区分追加</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 数馬</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>             拠点名の取得不具合の修正</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br>Update Note: 朱宝軍</br>
    /// <br>Date       : 2011/07/18</br>
    /// <br>             回答区分追加対応</br>
    /// <br>Update Note: 鄧潘ハン Redmine 26538対応</br>
    /// <br>Date       : 2011/11/11</br>
    /// <br>Update Note: 2014/04/17 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : 純正定価印字対応の障害対応</br>
    /// <br>Update Note: 管理番号 : 11900025-00 作成担当 : 3H 仰亮亮</br>
    /// <br>           : 修正内容 : READUNCOMMITTED対応</br>
    /// <br>Date       : 2023/11/07</br>
    /// </remarks>
    [Serializable]
    public class SearchSalesSlipDB : RemoteDB, ISearchSalesSlipDB
    {        
        private SalesSlipSearchWork _salesSlipSearchWorks = null; //ADD 2011/11/11

        /// <summary>
        /// 売上データ検索リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        /// </remarks>
        public SearchSalesSlipDB()
            : base("MAHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalesSlipSearchWork", "SALESSLIPRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上データLISTを戻します
        /// </summary>
        /// <param name="salesSlipSearchResult">検索結果</param>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす全ての売上データLISTを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.10.05</br>
        /// <br>             流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        /// <br>             EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             論理削除区分のチェックを追加</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2008.01.10</br>
        /// <br>             抽出パラメータの追加・変更</br>
        /// <br>             相手先伝票番号を抽出条件に追加</br>
        /// <br>             売上伝票番号を単独指定から範囲指定に変更</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        /// <br>Update Note: 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date       : 2011/11/11</br>
        public int Search(out object salesSlipSearchResult, object salesSlipSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            _salesSlipSearchWorks = new SalesSlipSearchWork();//ADD 2011/11/11
          
            salesSlipSearchResult = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //検索実行
            ArrayList salesSlipSearchResultWorkList = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalesSlipSearchWork)salesSlipSearchWork).EnterpriseCode, "売上伝票照会", "抽出開始");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                
                status = Search(out salesSlipSearchResultWorkList, (SalesSlipSearchWork)salesSlipSearchWork, ref sqlConnection, logicalMode);

                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((SalesSlipSearchWork)salesSlipSearchWork).EnterpriseCode, "売上伝票照会", "抽出終了");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchSalesSlipDB.Search");
                return status;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //outパラメータを設定
            salesSlipSearchResult = salesSlipSearchResultWorkList;

            return status;
        }
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上データLISTを戻します
        /// </summary>
        /// <param name="salesSlipSearchResultWorkList">検索結果</param>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date       : 2011/11/11</br>
        /// <br>Update Note: 管理番号 : 11900025-00 作成担当 : 3H 仰亮亮</br>
        /// <br>           : 修正内容 : READUNCOMMITTED対応</br>
        /// <br>Date       : 2023/11/07</br>
        private int Search(out ArrayList salesSlipSearchResultWorkList, SalesSlipSearchWork salesSlipSearchWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            salesSlipSearchResultWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            _salesSlipSearchWorks.AutoAnswerDivSCM = salesSlipSearchWork.AutoAnswerDivSCM;//ADD 2011/11/11
            _salesSlipSearchWorks.AcceptOrOrderKind = salesSlipSearchWork.AcceptOrOrderKind;//ADD 2011/11/11
            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                //暗号化キーOPEN
                // 2008.06.23 del start ----------------------------------->>
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESSLIPRF", "SALESDETAILRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);
                // 2008.06.23 del end -------------------------------------<<

                //クエリ文字列生成
                string queryString = string.Empty;
                queryString += "SELECT DISTINCT" + Environment.NewLine;
                queryString += "     SS.ENTERPRISECODERF" + Environment.NewLine;
                queryString += "    ,SS.LOGICALDELETECODERF" + Environment.NewLine;
                queryString += "    ,SS.ACPTANODRSTATUSRF" + Environment.NewLine;
                queryString += "    ,SS.SALESSLIPNUMRF" + Environment.NewLine;
                queryString += "    ,SS.SECTIONCODERF" + Environment.NewLine;
                queryString += "    ,SS.RESULTSADDUPSECCDRF" + Environment.NewLine;// ADD 2008.11.06
                queryString += "    ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                queryString += "    ,SS.SUBSECTIONCODERF" + Environment.NewLine;
                queryString += "    ,SUB.SUBSECTIONNAMERF" + Environment.NewLine;
                queryString += "    ,SS.DEBITNOTEDIVRF" + Environment.NewLine;
                queryString += "    ,SS.DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                queryString += "    ,SS.SALESSLIPCDRF" + Environment.NewLine;
                queryString += "    ,SS.SALESGOODSCDRF" + Environment.NewLine;
                queryString += "    ,SS.ACCRECDIVCDRF" + Environment.NewLine;
                queryString += "    ,SS.SALESINPSECCDRF" + Environment.NewLine;
                queryString += "    ,SS.DEMANDADDUPSECCDRF" + Environment.NewLine;
                queryString += "    ,SS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                queryString += "    ,SS.UPDATESECCDRF" + Environment.NewLine;
                queryString += "    ,SS.SEARCHSLIPDATERF" + Environment.NewLine;
                queryString += "    ,SS.SHIPMENTDAYRF" + Environment.NewLine;
                queryString += "    ,SS.SALESDATERF" + Environment.NewLine;
                queryString += "    ,SS.ADDUPADATERF" + Environment.NewLine;
                queryString += "    ,SS.DELAYPAYMENTDIVRF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATEFORMNORF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATEDIVIDERF" + Environment.NewLine;
                queryString += "    ,SS.INPUTAGENCDRF" + Environment.NewLine;
                queryString += "    ,SS.INPUTAGENNMRF" + Environment.NewLine;
                queryString += "    ,SS.SALESINPUTCODERF" + Environment.NewLine;
                queryString += "    ,SS.SALESINPUTNAMERF" + Environment.NewLine;
                queryString += "    ,SS.FRONTEMPLOYEECDRF" + Environment.NewLine;
                queryString += "    ,SS.FRONTEMPLOYEENMRF" + Environment.NewLine;
                queryString += "    ,SS.SALESEMPLOYEECDRF" + Environment.NewLine;
                queryString += "    ,SS.SALESEMPLOYEENMRF" + Environment.NewLine;
                queryString += "    ,SS.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                queryString += "    ,SS.TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                queryString += "    ,SS.SALESTOTALTAXINCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESTOTALTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESPRTTOTALTAXINCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESPRTTOTALTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESWORKTOTALTAXINCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESWORKTOTALTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESPRTSUBTTLINCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESPRTSUBTTLEXCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESWORKSUBTTLINCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESWORKSUBTTLEXCRF" + Environment.NewLine;
                queryString += "    ,SS.SALESNETPRICERF" + Environment.NewLine;
                queryString += "    ,SS.SALESSUBTOTALTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDSALESINTAXRF" + Environment.NewLine;
                queryString += "    ,SS.SALSUBTTLSUBTOTAXFRERF" + Environment.NewLine;
                queryString += "    ,SS.SALESOUTTAXRF" + Environment.NewLine;
                queryString += "    ,SS.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                queryString += "    ,SS.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDSALESDISOUTTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDSALESDISINTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDPARTSDISOUTTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDPARTSDISINTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDWORKDISOUTTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDWORKDISINTAXRF" + Environment.NewLine;
                queryString += "    ,SS.ITDEDSALESDISTAXFRERF" + Environment.NewLine;
                queryString += "    ,SS.SALESDISOUTTAXRF" + Environment.NewLine;
                queryString += "    ,SS.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                queryString += "    ,SS.PARTSDISCOUNTRATERF" + Environment.NewLine;
                queryString += "    ,SS.RAVORDISCOUNTRATERF" + Environment.NewLine;
                queryString += "    ,SS.TOTALCOSTRF" + Environment.NewLine;
                queryString += "    ,SS.CONSTAXLAYMETHODRF" + Environment.NewLine;
                queryString += "    ,SS.CONSTAXRATERF" + Environment.NewLine;
                queryString += "    ,SS.FRACTIONPROCCDRF" + Environment.NewLine;
                queryString += "    ,SS.ACCRECCONSTAXRF" + Environment.NewLine;
                queryString += "    ,SS.AUTODEPOSITCDRF" + Environment.NewLine;
                queryString += "    ,SS.AUTODEPOSITSLIPNORF" + Environment.NewLine;
                queryString += "    ,SS.DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                queryString += "    ,SS.DEPOSITALWCBLNCERF" + Environment.NewLine;
                queryString += "    ,SS.CLAIMCODERF" + Environment.NewLine;
                queryString += "    ,SS.CLAIMSNMRF" + Environment.NewLine;
                queryString += "    ,SS.CUSTOMERCODERF" + Environment.NewLine;
                queryString += "    ,SS.CUSTOMERNAMERF" + Environment.NewLine;
                queryString += "    ,SS.CUSTOMERNAME2RF" + Environment.NewLine;
                queryString += "    ,SS.CUSTOMERSNMRF" + Environment.NewLine;
                queryString += "    ,SS.HONORIFICTITLERF" + Environment.NewLine;
                queryString += "    ,SS.OUTPUTNAMERF" + Environment.NewLine;
                queryString += "    ,SS.CUSTSLIPNORF" + Environment.NewLine;
                queryString += "    ,SS.SLIPADDRESSDIVRF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEECODERF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEENAMERF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEENAME2RF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEEPOSTNORF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEEADDR1RF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEEADDR3RF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEEADDR4RF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEETELNORF" + Environment.NewLine;
                queryString += "    ,SS.ADDRESSEEFAXNORF" + Environment.NewLine;
                queryString += "    ,SS.PARTYSALESLIPNUMRF" + Environment.NewLine;
                queryString += "    ,SS.SLIPNOTERF" + Environment.NewLine;
                queryString += "    ,SS.SLIPNOTE2RF" + Environment.NewLine;
                queryString += "    ,SS.SLIPNOTE3RF" + Environment.NewLine;
                queryString += "    ,SS.RETGOODSREASONDIVRF" + Environment.NewLine;
                queryString += "    ,SS.RETGOODSREASONRF" + Environment.NewLine;
                queryString += "    ,SS.REGIPROCDATERF" + Environment.NewLine;
                queryString += "    ,SS.CASHREGISTERNORF" + Environment.NewLine;
                queryString += "    ,SS.POSRECEIPTNORF" + Environment.NewLine;
                queryString += "    ,SS.DETAILROWCOUNTRF" + Environment.NewLine;
                queryString += "    ,SS.EDISENDDATERF" + Environment.NewLine;
                queryString += "    ,SS.EDITAKEINDATERF" + Environment.NewLine;
                queryString += "    ,SS.UOEREMARK1RF" + Environment.NewLine;
                queryString += "    ,SS.UOEREMARK2RF" + Environment.NewLine;
                queryString += "    ,SS.SLIPPRINTDIVCDRF" + Environment.NewLine;
                queryString += "    ,SS.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                queryString += "    ,SS.SALESSLIPPRINTDATERF" + Environment.NewLine;
                queryString += "    ,SS.BUSINESSTYPECODERF" + Environment.NewLine;
                queryString += "    ,SS.BUSINESSTYPENAMERF" + Environment.NewLine;
                queryString += "    ,SS.ORDERNUMBERRF" + Environment.NewLine;
                queryString += "    ,SS.DELIVEREDGOODSDIVRF" + Environment.NewLine;
                queryString += "    ,SS.DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                queryString += "    ,SS.SALESAREACODERF" + Environment.NewLine;
                queryString += "    ,SS.SALESAREANAMERF" + Environment.NewLine;
                queryString += "    ,SS.RECONCILEFLAGRF" + Environment.NewLine;
                queryString += "    ,SS.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                queryString += "    ,SS.COMPLETECDRF" + Environment.NewLine;
                queryString += "    ,SS.SALESPRICEFRACPROCCDRF" + Environment.NewLine;
                queryString += "    ,SS.STOCKGOODSTTLTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.PUREGOODSTTLTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SS.LISTPRICEPRINTDIVRF" + Environment.NewLine;
                queryString += "    ,SS.ERANAMEDISPCD1RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATAXDIVCDRF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATEFORMPRTCDRF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATESUBJECTRF" + Environment.NewLine;
                queryString += "    ,SS.FOOTNOTES1RF" + Environment.NewLine;
                queryString += "    ,SS.FOOTNOTES2RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATETITLE1RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATETITLE2RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATETITLE3RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATETITLE4RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATETITLE5RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATENOTE1RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATENOTE2RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATENOTE3RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATENOTE4RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATENOTE5RF" + Environment.NewLine;
                queryString += "    ,SS.ESTIMATEVALIDITYDATERF" + Environment.NewLine;
                queryString += "    ,SS.PARTSNOPRTCDRF" + Environment.NewLine;
                queryString += "    ,SS.OPTIONPRINGDIVCDRF" + Environment.NewLine;
                queryString += "    ,SS.RATEUSECODERF" + Environment.NewLine;
                queryString += "    ,AOC.ACCEPTANORDERNORF" + Environment.NewLine;
                queryString += "    ,AOC.CARMNGCODERF" + Environment.NewLine;
                queryString += "    ,AOC.MODELDESIGNATIONNORF" + Environment.NewLine;
                queryString += "    ,AOC.CATEGORYNORF" + Environment.NewLine;
                queryString += "    ,AOC.MAKERFULLNAMERF" + Environment.NewLine;
                queryString += "    ,AOC.FULLMODELRF" + Environment.NewLine;
                queryString += "    ,AOC.MODELFULLNAMERF" + Environment.NewLine;
                queryString += "    ,(CASE WHEN SS.SALESDATERF IS NULL THEN SS.SHIPMENTDAYRF ELSE SS.SALESDATERF END) AS ORDERDAY" + Environment.NewLine;
                //queryString += " FROM SALESSLIPRF AS SS" + Environment.NewLine;//  DEL 3H 仰亮亮 2023/11/07
                queryString += " FROM SALESSLIPRF AS SS WITH (READUNCOMMITTED)" + Environment.NewLine;//  ADD 3H 仰亮亮 2023/11/07

                sqlCommand = new SqlCommand(queryString, sqlConnection);

                //パラメータよりFROM句、WHERE句生成
                string fromClause;
                string whereClause;
                SetFromWhereClause(ref sqlCommand, salesSlipSearchWork, out fromClause, out whereClause, logicalMode);
                if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                //ORDER BY
                sqlCommand.CommandText += SetOrderByClause(salesSlipSearchWork);

                //実行
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        salesSlipSearchResultWorkList.Add(ReaderToSalesSlipSearchResultWork(ref myReader));
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                // 2008.06.23 del start ----------------------------------->>
                //暗号化キークローズ
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
                // 2008.06.23 del end -------------------------------------<<
            }

            if (sqlConnection == null) return status;
            return status;
        }
        #endregion

        #region 未使用の為、削除
        /*
        #region [TopSearch]
        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の売上データLISTを戻します
        /// </summary>
        /// <param name="salesSlipSearchResult">検索結果</param>
        /// <param name="salesSlipSearchWork">売上検索パラメータ（NextRead時は前回最終レコードキー）</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="readCnt">検索指定件数</param>        
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす指定件数分の売上データLISTを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.10.05</br>
        /// <br>             流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        /// <br>             EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             論理削除区分のチェックを追加</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2008.01.10</br>
        /// <br>             抽出パラメータの追加・変更</br>
        /// <br>             相手先伝票番号を抽出条件に追加</br>
        /// <br>             売上伝票番号を単独指定から範囲指定に変更</br>
        public int TopSearch(out object salesSlipSearchResult, object salesSlipSearchWork, out int retTotalCnt, out bool nextData, int readCnt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            salesSlipSearchResult = null;
            retTotalCnt = 0;
            nextData = false;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //検索実行
            ArrayList salesSlipSearchResultWorkList = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //件数を取得
                // ↓ 2007.12.13 c
                //status = SearchCount((SalesSlipSearchWork)salesSlipSearchWork, out retTotalCnt, 0, ConstantManagement.LogicalMode.GetData0);
                status = SearchCount((SalesSlipSearchWork)salesSlipSearchWork, out retTotalCnt, 0, logicalMode);
                // ↑ 2007.12.13 c
                if (retTotalCnt == 0) return status;
                //データを取得
                // ↓ 2007.12.13 c
                //status = TopSearch(out salesSlipSearchResultWorkList, (SalesSlipSearchWork)salesSlipSearchWork, readCnt, ref sqlConnection);
                status = TopSearch(out salesSlipSearchResultWorkList, (SalesSlipSearchWork)salesSlipSearchWork, readCnt, ref sqlConnection, logicalMode);
                // ↑ 2007.12.13 c
                
                //全件数が取得件数よりも多ければ次データあり
                if (retTotalCnt > salesSlipSearchResultWorkList.Count) nextData = true;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchSalesSlipDB.TopSearch");
                return status;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //outパラメータを設定
            salesSlipSearchResult = salesSlipSearchResultWorkList;

            return status;
        }
        /// <summary>
        /// 指定されたパラメータの条件を満たす指定件数分の売上データLISTを戻します
        /// </summary>
        /// <param name="salesSlipSearchResultWorkList">検索結果</param>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="readCnt">総件数</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        // ↓ 2007.12.13 c
        //private int TopSearch(out ArrayList salesSlipSearchResultWorkList, SalesSlipSearchWork salesSlipSearchWork, int readCnt, ref SqlConnection sqlConnection)
        private int TopSearch(out ArrayList salesSlipSearchResultWorkList, SalesSlipSearchWork salesSlipSearchWork, int readCnt, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        // ↑ 2007.12.13 c
        {
            salesSlipSearchResultWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                //暗号化キーOPEN
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESSLIPRF", "SALESDETAILRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                //クエリ文字列生成
                string queryString;
                if (readCnt > 0)
                {
                    // 2008.06.23 upd start ------------------------------------------>>
                    //queryString = "SELECT DISTINCT TOP " + readCnt.ToString() + " " + _selectClause + "FROM SALESSLIPRF SS";
                    queryString = string.Empty;
                    queryString += "SELECT DISTINCT TOP" + Environment.NewLine;
                    queryString += readCnt.ToString() + Environment.NewLine;
                    queryString += "     SS.ENTERPRISECODERF" + Environment.NewLine;
                    queryString += "    ,SS.LOGICALDELETECODERF" + Environment.NewLine;
                    queryString += "    ,SS.ACPTANODRSTATUSRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSLIPNUMRF" + Environment.NewLine;
                    queryString += "    ,SS.SECTIONCODERF" + Environment.NewLine;
                    queryString += "    ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                    queryString += "    ,SS.SUBSECTIONCODERF" + Environment.NewLine;
                    queryString += "    ,SUB.SUBSECTIONNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.DEBITNOTEDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSLIPCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESGOODSCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ACCRECDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESINPSECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.DEMANDADDUPSECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.UPDATESECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SEARCHSLIPDATERF" + Environment.NewLine;
                    queryString += "    ,SS.SHIPMENTDAYRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDATERF" + Environment.NewLine;
                    queryString += "    ,SS.ADDUPADATERF" + Environment.NewLine;
                    queryString += "    ,SS.DELAYPAYMENTDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEFORMNORF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEDIVIDERF" + Environment.NewLine;
                    queryString += "    ,SS.INPUTAGENCDRF" + Environment.NewLine;
                    queryString += "    ,SS.INPUTAGENNMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESINPUTCODERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESINPUTNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.FRONTEMPLOYEECDRF" + Environment.NewLine;
                    queryString += "    ,SS.FRONTEMPLOYEENMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESEMPLOYEECDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESEMPLOYEENMRF" + Environment.NewLine;
                    queryString += "    ,SS.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    queryString += "    ,SS.TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTSUBTTLINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTSUBTTLEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKSUBTTLINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKSUBTTLEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESNETPRICERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSUBTOTALTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.SALSUBTTLSUBTOTAXFRERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESDISINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDPARTSDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDPARTSDISINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDWORKDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDWORKDISINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESDISTAXFRERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                    queryString += "    ,SS.PARTSDISCOUNTRATERF" + Environment.NewLine;
                    queryString += "    ,SS.RAVORDISCOUNTRATERF" + Environment.NewLine;
                    queryString += "    ,SS.TOTALCOSTRF" + Environment.NewLine;
                    queryString += "    ,SS.CONSTAXLAYMETHODRF" + Environment.NewLine;
                    queryString += "    ,SS.CONSTAXRATERF" + Environment.NewLine;
                    queryString += "    ,SS.FRACTIONPROCCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ACCRECCONSTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.AUTODEPOSITCDRF" + Environment.NewLine;
                    queryString += "    ,SS.AUTODEPOSITSLIPNORF" + Environment.NewLine;
                    queryString += "    ,SS.DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                    queryString += "    ,SS.DEPOSITALWCBLNCERF" + Environment.NewLine;
                    queryString += "    ,SS.CLAIMCODERF" + Environment.NewLine;
                    queryString += "    ,SS.CLAIMSNMRF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERCODERF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERNAME2RF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERSNMRF" + Environment.NewLine;
                    queryString += "    ,SS.HONORIFICTITLERF" + Environment.NewLine;
                    queryString += "    ,SS.OUTPUTNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTSLIPNORF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPADDRESSDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEECODERF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEENAMERF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEENAME2RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEPOSTNORF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEADDR1RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEADDR3RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEADDR4RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEETELNORF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEFAXNORF" + Environment.NewLine;
                    queryString += "    ,SS.PARTYSALESLIPNUMRF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPNOTERF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPNOTE2RF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPNOTE3RF" + Environment.NewLine;
                    queryString += "    ,SS.RETGOODSREASONDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.RETGOODSREASONRF" + Environment.NewLine;
                    queryString += "    ,SS.REGIPROCDATERF" + Environment.NewLine;
                    queryString += "    ,SS.CASHREGISTERNORF" + Environment.NewLine;
                    queryString += "    ,SS.POSRECEIPTNORF" + Environment.NewLine;
                    queryString += "    ,SS.DETAILROWCOUNTRF" + Environment.NewLine;
                    queryString += "    ,SS.EDISENDDATERF" + Environment.NewLine;
                    queryString += "    ,SS.EDITAKEINDATERF" + Environment.NewLine;
                    queryString += "    ,SS.UOEREMARK1RF" + Environment.NewLine;
                    queryString += "    ,SS.UOEREMARK2RF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPPRINTDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSLIPPRINTDATERF" + Environment.NewLine;
                    queryString += "    ,SS.BUSINESSTYPECODERF" + Environment.NewLine;
                    queryString += "    ,SS.BUSINESSTYPENAMERF" + Environment.NewLine;
                    queryString += "    ,SS.ORDERNUMBERRF" + Environment.NewLine;
                    queryString += "    ,SS.DELIVEREDGOODSDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESAREACODERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESAREANAMERF" + Environment.NewLine;
                    queryString += "    ,SS.RECONCILEFLAGRF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    queryString += "    ,SS.COMPLETECDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRICEFRACPROCCDRF" + Environment.NewLine;
                    queryString += "    ,SS.STOCKGOODSTTLTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.PUREGOODSTTLTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.LISTPRICEPRINTDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.ERANAMEDISPCD1RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATAXDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEFORMPRTCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATESUBJECTRF" + Environment.NewLine;
                    queryString += "    ,SS.FOOTNOTES1RF" + Environment.NewLine;
                    queryString += "    ,SS.FOOTNOTES2RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE1RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE2RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE3RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE4RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE5RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE1RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE2RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE3RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE4RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE5RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEVALIDITYDATERF" + Environment.NewLine;
                    queryString += "    ,SS.PARTSNOPRTCDRF" + Environment.NewLine;
                    queryString += "    ,SS.OPTIONPRINGDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.RATEUSECODERF" + Environment.NewLine;
                    queryString += "    ,AOC.CARMNGCODERF" + Environment.NewLine;
                    queryString += "    ,AOC.MODELDESIGNATIONNORF" + Environment.NewLine;
                    queryString += "    ,AOC.CATEGORYNORF" + Environment.NewLine;
                    queryString += "    ,AOC.MAKERFULLNAMERF" + Environment.NewLine;
                    queryString += "    ,AOC.FULLMODELRF" + Environment.NewLine;
                    queryString += "    ,AOC.MODELFULLNAMERF" + Environment.NewLine;
                    queryString += " FROM SALESSLIPRF AS SS" + Environment.NewLine;
                    // 2008.06.23 upd end --------------------------------------------<<
                }
                else
                {
                    // 2008.06.23 upd start ------------------------------------------>>
                    //queryString = "SELECT DISTINCT " + _selectClause + "FROM SALESSLIPRF SS";
                    queryString = string.Empty;
                    queryString += "SELECT DISTINCT" + Environment.NewLine;
                    queryString += "     SS.ENTERPRISECODERF" + Environment.NewLine;
                    queryString += "    ,SS.LOGICALDELETECODERF" + Environment.NewLine;
                    queryString += "    ,SS.ACPTANODRSTATUSRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSLIPNUMRF" + Environment.NewLine;
                    queryString += "    ,SS.SECTIONCODERF" + Environment.NewLine;
                    queryString += "    ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                    queryString += "    ,SS.SUBSECTIONCODERF" + Environment.NewLine;
                    queryString += "    ,SUB.SUBSECTIONNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.DEBITNOTEDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.DEBITNLNKSALESSLNUMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSLIPCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESGOODSCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ACCRECDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESINPSECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.DEMANDADDUPSECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.RESULTSADDUPSECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.UPDATESECCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SEARCHSLIPDATERF" + Environment.NewLine;
                    queryString += "    ,SS.SHIPMENTDAYRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDATERF" + Environment.NewLine;
                    queryString += "    ,SS.ADDUPADATERF" + Environment.NewLine;
                    queryString += "    ,SS.DELAYPAYMENTDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEFORMNORF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEDIVIDERF" + Environment.NewLine;
                    queryString += "    ,SS.INPUTAGENCDRF" + Environment.NewLine;
                    queryString += "    ,SS.INPUTAGENNMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESINPUTCODERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESINPUTNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.FRONTEMPLOYEECDRF" + Environment.NewLine;
                    queryString += "    ,SS.FRONTEMPLOYEENMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESEMPLOYEECDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESEMPLOYEENMRF" + Environment.NewLine;
                    queryString += "    ,SS.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                    queryString += "    ,SS.TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSUBTOTALTAXINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSUBTOTALTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTSUBTTLINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRTSUBTTLEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKSUBTTLINCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESWORKSUBTTLEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESNETPRICERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSUBTOTALTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.SALSUBTTLSUBTOTAXFRERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESDISINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDPARTSDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDPARTSDISINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDWORKDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDWORKDISINTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.ITDEDSALESDISTAXFRERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDISOUTTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                    queryString += "    ,SS.PARTSDISCOUNTRATERF" + Environment.NewLine;
                    queryString += "    ,SS.RAVORDISCOUNTRATERF" + Environment.NewLine;
                    queryString += "    ,SS.TOTALCOSTRF" + Environment.NewLine;
                    queryString += "    ,SS.CONSTAXLAYMETHODRF" + Environment.NewLine;
                    queryString += "    ,SS.CONSTAXRATERF" + Environment.NewLine;
                    queryString += "    ,SS.FRACTIONPROCCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ACCRECCONSTAXRF" + Environment.NewLine;
                    queryString += "    ,SS.AUTODEPOSITCDRF" + Environment.NewLine;
                    queryString += "    ,SS.AUTODEPOSITSLIPNORF" + Environment.NewLine;
                    queryString += "    ,SS.DEPOSITALLOWANCETTLRF" + Environment.NewLine;
                    queryString += "    ,SS.DEPOSITALWCBLNCERF" + Environment.NewLine;
                    queryString += "    ,SS.CLAIMCODERF" + Environment.NewLine;
                    queryString += "    ,SS.CLAIMSNMRF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERCODERF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERNAME2RF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTOMERSNMRF" + Environment.NewLine;
                    queryString += "    ,SS.HONORIFICTITLERF" + Environment.NewLine;
                    queryString += "    ,SS.OUTPUTNAMERF" + Environment.NewLine;
                    queryString += "    ,SS.CUSTSLIPNORF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPADDRESSDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEECODERF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEENAMERF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEENAME2RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEPOSTNORF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEADDR1RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEADDR3RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEADDR4RF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEETELNORF" + Environment.NewLine;
                    queryString += "    ,SS.ADDRESSEEFAXNORF" + Environment.NewLine;
                    queryString += "    ,SS.PARTYSALESLIPNUMRF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPNOTERF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPNOTE2RF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPNOTE3RF" + Environment.NewLine;
                    queryString += "    ,SS.RETGOODSREASONDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.RETGOODSREASONRF" + Environment.NewLine;
                    queryString += "    ,SS.REGIPROCDATERF" + Environment.NewLine;
                    queryString += "    ,SS.CASHREGISTERNORF" + Environment.NewLine;
                    queryString += "    ,SS.POSRECEIPTNORF" + Environment.NewLine;
                    queryString += "    ,SS.DETAILROWCOUNTRF" + Environment.NewLine;
                    queryString += "    ,SS.EDISENDDATERF" + Environment.NewLine;
                    queryString += "    ,SS.EDITAKEINDATERF" + Environment.NewLine;
                    queryString += "    ,SS.UOEREMARK1RF" + Environment.NewLine;
                    queryString += "    ,SS.UOEREMARK2RF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPPRINTDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPPRINTFINISHCDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESSLIPPRINTDATERF" + Environment.NewLine;
                    queryString += "    ,SS.BUSINESSTYPECODERF" + Environment.NewLine;
                    queryString += "    ,SS.BUSINESSTYPENAMERF" + Environment.NewLine;
                    queryString += "    ,SS.ORDERNUMBERRF" + Environment.NewLine;
                    queryString += "    ,SS.DELIVEREDGOODSDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESAREACODERF" + Environment.NewLine;
                    queryString += "    ,SS.SALESAREANAMERF" + Environment.NewLine;
                    queryString += "    ,SS.RECONCILEFLAGRF" + Environment.NewLine;
                    queryString += "    ,SS.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    queryString += "    ,SS.COMPLETECDRF" + Environment.NewLine;
                    queryString += "    ,SS.SALESPRICEFRACPROCCDRF" + Environment.NewLine;
                    queryString += "    ,SS.STOCKGOODSTTLTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.PUREGOODSTTLTAXEXCRF" + Environment.NewLine;
                    queryString += "    ,SS.LISTPRICEPRINTDIVRF" + Environment.NewLine;
                    queryString += "    ,SS.ERANAMEDISPCD1RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATAXDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEFORMPRTCDRF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATESUBJECTRF" + Environment.NewLine;
                    queryString += "    ,SS.FOOTNOTES1RF" + Environment.NewLine;
                    queryString += "    ,SS.FOOTNOTES2RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE1RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE2RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE3RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE4RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATETITLE5RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE1RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE2RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE3RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE4RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATENOTE5RF" + Environment.NewLine;
                    queryString += "    ,SS.ESTIMATEVALIDITYDATERF" + Environment.NewLine;
                    queryString += "    ,SS.PARTSNOPRTCDRF" + Environment.NewLine;
                    queryString += "    ,SS.OPTIONPRINGDIVCDRF" + Environment.NewLine;
                    queryString += "    ,SS.RATEUSECODERF" + Environment.NewLine;
                    queryString += "    ,AOC.CARMNGCODERF" + Environment.NewLine;
                    queryString += "    ,AOC.MODELDESIGNATIONNORF" + Environment.NewLine;
                    queryString += "    ,AOC.CATEGORYNORF" + Environment.NewLine;
                    queryString += "    ,AOC.MAKERFULLNAMERF" + Environment.NewLine;
                    queryString += "    ,AOC.FULLMODELRF" + Environment.NewLine;
                    queryString += "    ,AOC.MODELFULLNAMERF" + Environment.NewLine;
                    queryString += " FROM SALESSLIPRF AS SS" + Environment.NewLine;
                    // 2008.06.23 upd end --------------------------------------------<<
                }
                sqlCommand = new SqlCommand(queryString, sqlConnection);

                //パラメータよりFROM句、WHERE句生成
                string fromClause;
                string whereClause;
                // ↓ 2007.12.13 c
                //SetFromWhereClause(ref sqlCommand, salesSlipSearchWork, out fromClause, out whereClause);
                SetFromWhereClause(ref sqlCommand, salesSlipSearchWork, out fromClause, out whereClause, logicalMode);
                // ↑ 2007.12.13 c
                if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                //ORDER BY
                sqlCommand.CommandText += SetOrderByClause();

                //実行
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        salesSlipSearchResultWorkList.Add(ReaderToSalesSlipSearchResultWork(ref myReader));
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //暗号化キークローズ
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
            }

            if (sqlConnection == null) return status;
            return status;
        }
        #endregion

        #region [SearchCount]
        /// <summary>
        /// 指定されたパラメータの条件を満たす売上データ件数を戻します
        /// </summary>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす売上データ件数を戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.03.23</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.10.05</br>
        /// <br>             流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.10</br>
        /// <br>             EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             論理削除区分のチェックを追加</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2008.01.10</br>
        /// <br>             抽出パラメータの追加・変更</br>
        /// <br>             相手先伝票番号を抽出条件に追加</br>
        /// <br>             売上伝票番号を単独指定から範囲指定に変更</br>
        public int SearchCount(object salesSlipSearchWork, out int retTotalCnt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            retTotalCnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //検索実行
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ↓ 2007.12.13 c
                //status = SearchCount((SalesSlipSearchWork)salesSlipSearchWork, out retTotalCnt, ref sqlConnection);
                status = SearchCount((SalesSlipSearchWork)salesSlipSearchWork, out retTotalCnt, ref sqlConnection, logicalMode);
                // ↑ 2007.12.13 c
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchSalesSlipDB.SearchCount");
                return status;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// 指定されたパラメータの条件を満たす売上データ件数を戻します
        /// </summary>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="retTotalCnt">検索対象総件数</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        // ↓ 2007.12.13 c
        //private int SearchCount(SalesSlipSearchWork salesSlipSearchWork, out int retTotalCnt, ref SqlConnection sqlConnection)
        private int SearchCount(SalesSlipSearchWork salesSlipSearchWork, out int retTotalCnt, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        // ↑ 2007.12.13 c
        {
            retTotalCnt = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                //暗号化キーOPEN
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESSLIPRF", "SALESDETAILRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                //クエリ文字列生成
                // ↓ 2007.10.05 980081 c
                //string queryString = "SELECT COUNT(DISTINCT SS.ACCEPTANORDERNORF) FROM SALESSLIPRF SS";
                string queryString = "SELECT COUNT(DISTINCT SS.SALESSLIPNUMRF) FROM SALESSLIPRF SS";
                // ↑ 2007.10.05 980081 c

                sqlCommand = new SqlCommand(queryString, sqlConnection);

                //パラメータよりFROM句、WHERE句生成
                string fromClause;
                string whereClause;
                // ↓ 2007.12.13 c
                //SetFromWhereClause(ref sqlCommand, salesSlipSearchWork, out fromClause, out whereClause);
                SetFromWhereClause(ref sqlCommand, salesSlipSearchWork, out fromClause, out whereClause, logicalMode);
                // ↑ 2007.12.13 c
                if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                //実行
                retTotalCnt = (int)sqlCommand.ExecuteScalar();
                if (retTotalCnt > 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //暗号化キークローズ
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
            }

            if (sqlConnection == null) return status;
            return status;
        }
        #endregion
        */
        #endregion

        #region クエリ文字列生成
        /// <summary>
        /// パラメータより、動的にFROM句、WHERE句を生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommand オブジェクト</param>
        /// <param name="salesSlipSearchWork">検索パラメータ</param>
        /// <param name="fromClause">FROM句クエリ文字列</param>
        /// <param name="whereClause">WHERE句クエリ文字列</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <br>Update Note: 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date       : 2011/11/11</br>
        /// <br>Update Note: 管理番号 : 11900025-00 作成担当 : 3H 仰亮亮</br>
        /// <br>           : 修正内容 : READUNCOMMITTED対応</br>
        /// <br>Date       : 2023/11/07</br>
        private void SetFromWhereClause(ref SqlCommand sqlCommand, SalesSlipSearchWork salesSlipSearchWork, out string fromClause, out string whereClause, ConstantManagement.LogicalMode logicalMode)
        {
            fromClause = String.Empty;
            whereClause = String.Empty;
            //---DEL 2011/11/11 --------------------------->>>>>
            //// -- UPD 2010/05/10 ------------------------------------------------------------->>>
            ////fromClause += " LEFT JOIN SECINFOSETRF AS SEC ON (SS.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SS.SECTIONCODERF=SEC.SECTIONCODERF)"
            //fromClause += " LEFT JOIN SECINFOSETRF AS SEC ON (SS.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SS.RESULTSADDUPSECCDRF=SEC.SECTIONCODERF)"
            //    // -- UPD 2010/05/10 -------------------------------------------------------------<<<
            //    // 修正 2009.01.06 >>>
            //    //+ " LEFT JOIN SUBSECTIONRF AS SUB ON (SS.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SS.SECTIONCODERF=SUB.SECTIONCODERF AND SS.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)"
            //            + " LEFT JOIN SUBSECTIONRF AS SUB ON (SS.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SS.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)"
            //    // 修正 2009.01.06 <<<
            //            + " INNER JOIN SALESDETAILRF SD ON (SS.ENTERPRISECODERF=SD.ENTERPRISECODERF AND SS.ACPTANODRSTATUSRF=SD.ACPTANODRSTATUSRF AND SS.SALESSLIPNUMRF=SD.SALESSLIPNUMRF)";

            ////            + " LEFT JOIN ACCEPTODRCARRF AS AOC ON (SD.ENTERPRISECODERF=AOC.ENTERPRISECODERF AND SD.ACCEPTANORDERNORF=AOC.ACCEPTANORDERNORF AND SD.ACPTANODRSTATUSRF=AOC.ACPTANODRSTATUSRF)"; // 2008.06.23 add // DEL 2008.11.17
            //---DEL 2011/11/11 ---------------------------<<<<<

            //---ADD 2011/11/11 --------------------------->>>>>
            // --- DEL START 3H 仰亮亮 2023/11/07 -------------------->>>>>
            //fromClause += " LEFT JOIN SECINFOSETRF AS SEC ON (SS.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SS.RESULTSADDUPSECCDRF=SEC.SECTIONCODERF)";
            //fromClause += " LEFT JOIN SUBSECTIONRF AS SUB ON (SS.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SS.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)";
            //fromClause += " INNER JOIN SALESDETAILRF SD ON (SS.ENTERPRISECODERF=SD.ENTERPRISECODERF AND SS.ACPTANODRSTATUSRF=SD.ACPTANODRSTATUSRF AND SS.SALESSLIPNUMRF=SD.SALESSLIPNUMRF)";
            // --- DEL END 3H 仰亮亮 2023/11/07 ----------------------<<<<<
            // --- ADD START 3H 仰亮亮 2023/11/07 -------------------->>>>>
            fromClause += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON (SS.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SS.RESULTSADDUPSECCDRF=SEC.SECTIONCODERF)";
            fromClause += " LEFT JOIN SUBSECTIONRF AS SUB WITH (READUNCOMMITTED) ON (SS.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SS.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)";
            fromClause += " INNER JOIN SALESDETAILRF SD WITH (READUNCOMMITTED) ON (SS.ENTERPRISECODERF=SD.ENTERPRISECODERF AND SS.ACPTANODRSTATUSRF=SD.ACPTANODRSTATUSRF AND SS.SALESSLIPNUMRF=SD.SALESSLIPNUMRF)";
            // --- ADD END 3H 仰亮亮 2023/11/07 ----------------------<<<<<

            if (salesSlipSearchWork.AutoAnswerDivSCM == 0)
            {
                fromClause += (" AND SD.AUTOANSWERDIVSCMRF=0");
            }
            if (salesSlipSearchWork.AutoAnswerDivSCM == 1)
            {
                if (salesSlipSearchWork.AcceptOrOrderKind == -1)
                {
                    fromClause += (" AND SD.AUTOANSWERDIVSCMRF=0");
                }
                else if (salesSlipSearchWork.AcceptOrOrderKind == 0)
                {
                    fromClause += (" AND (SD.AUTOANSWERDIVSCMRF= 0 OR (SD.AUTOANSWERDIVSCMRF<> 0 AND SD.ACCEPTORORDERKINDRF=0))");
                }
                else if (salesSlipSearchWork.AcceptOrOrderKind == 1)
                {
                    fromClause += (" AND (SD.AUTOANSWERDIVSCMRF= 0 OR (SD.AUTOANSWERDIVSCMRF<> 0 AND SD.ACCEPTORORDERKINDRF=1))");
                }
                else if (salesSlipSearchWork.AcceptOrOrderKind == 2)
                {
                    fromClause += (" AND (SD.AUTOANSWERDIVSCMRF=0 OR SD.AUTOANSWERDIVSCMRF=1 OR SD.AUTOANSWERDIVSCMRF=2)");
                }
            }
            if (salesSlipSearchWork.AutoAnswerDivSCM == 2)
            {
                if (salesSlipSearchWork.AcceptOrOrderKind == -1)
                {
                    fromClause += (" AND SD.AcceptOrOrderKind = -1");
                }
                else if (salesSlipSearchWork.AcceptOrOrderKind == 0)
                {
                    fromClause += (" AND ((SD.ACCEPTORORDERKINDRF=0 ) AND  SD.AUTOANSWERDIVSCMRF <>0)");
                }
                else if (salesSlipSearchWork.AcceptOrOrderKind == 1)
                {
                    fromClause += (" AND ((SD.ACCEPTORORDERKINDRF=1 ) AND  SD.AUTOANSWERDIVSCMRF <>0)");
                }
                else if (salesSlipSearchWork.AcceptOrOrderKind == 2)
                {
                    fromClause += (" AND ((SD.ACCEPTORORDERKINDRF=0 OR SD.ACCEPTORORDERKINDRF=1) AND  SD.AUTOANSWERDIVSCMRF <>0)");
                }
            }
            //---ADD 2011/11/11 -------------------------------------<<<<<
           
            // ADD 2008.11.17 >>>
            //fromClause += " LEFT JOIN ACCEPTODRCARRF AOC ON (" + Environment.NewLine;//  DEL 3H 仰亮亮 2023/11/07
            fromClause += " LEFT JOIN ACCEPTODRCARRF AOC WITH (READUNCOMMITTED) ON (" + Environment.NewLine;//  ADD 3H 仰亮亮 2023/11/07
            fromClause +=" SD.ENTERPRISECODERF=AOC.ENTERPRISECODERF  " + Environment.NewLine;
            fromClause +=" AND SD.ACCEPTANORDERNORF=AOC.ACCEPTANORDERNORF" + Environment.NewLine;
            fromClause +=" AND (" + Environment.NewLine;
            fromClause +="      (SD.ACPTANODRSTATUSRF = 10 AND AOC.ACPTANODRSTATUSRF = 1) " + Environment.NewLine;   //　見積
            fromClause +="      OR (SD.ACPTANODRSTATUSRF = 20 AND AOC.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // 受注
            fromClause +="      OR (SD.ACPTANODRSTATUSRF = 30 AND AOC.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // 売上
            fromClause +="      OR (SD.ACPTANODRSTATUSRF = 40 AND AOC.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // 出荷　
            fromClause +="    )" + Environment.NewLine;            
            fromClause +=")" + Environment.NewLine;
            // ADD 2008.11.17 <<<
            // ADD 2009.01.08 >>>
            fromClause += " LEFT JOIN " + Environment.NewLine;
            fromClause += " (" + Environment.NewLine;
            fromClause += "   SELECT" + Environment.NewLine;
            fromClause += "   ENTERPRISECODERF" + Environment.NewLine;
            fromClause += "   ,ACPTANODRSTATUSRF" + Environment.NewLine;
            fromClause += "   ,SALESSLIPNUMRF" + Environment.NewLine;
            //---ADD 2011/11/11 -------------------->>>>>
            if (salesSlipSearchWork.AutoAnswerDivSCM == 0)
            {
                fromClause += "   ,SUM(ACPTANODRREMAINCNTRF) AS ACPTANODRREMAINCNTRF,SUM(AUTOANSWERDIVSCMRF)  AS SUMAUTOANSWERDIVSCMRF" + Environment.NewLine;
            }
            else
            {
                fromClause += "   ,SUM(ACPTANODRREMAINCNTRF) AS ACPTANODRREMAINCNTRF" + Environment.NewLine;
            }
            //---ADD 2011/11/11 --------------------<<<<<
            //fromClause += "   ,SUM(ACPTANODRREMAINCNTRF) AS ACPTANODRREMAINCNTRF" + Environment.NewLine;// DEL 2011/11/11
            fromClause += "   FROM" + Environment.NewLine;
            fromClause += "   SALESDETAILRF" + Environment.NewLine;
            fromClause += "   GROUP BY" + Environment.NewLine;
            fromClause += "   ENTERPRISECODERF" + Environment.NewLine;
            fromClause += "   ,ACPTANODRSTATUSRF" + Environment.NewLine;
            fromClause += "   ,SALESSLIPNUMRF     " + Environment.NewLine;
            fromClause += " ) AS SD2" + Environment.NewLine;
            fromClause += " ON (SS.ENTERPRISECODERF=SD2.ENTERPRISECODERF AND SS.ACPTANODRSTATUSRF=SD2.ACPTANODRSTATUSRF AND SS.SALESSLIPNUMRF=SD2.SALESSLIPNUMRF) " + Environment.NewLine;
            // ADD 2009.01.08 <<<


            #region パラメータより
            //企業コード
            if (IsValidParameter(salesSlipSearchWork.EnterpriseCode))
            {
                ConnectWhereClause(ref whereClause, "SS.ENTERPRISECODERF=@FINDENTERPRISECODE");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.EnterpriseCode);
            }
            if (salesSlipSearchWork.AutoAnswerDivSCM == 0)
            {
                whereClause += "  AND SD2.SUMAUTOANSWERDIVSCMRF =0" + Environment.NewLine;
            }
            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                ConnectWhereClause(ref whereClause, "SS.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                ConnectWhereClause(ref whereClause, "SS.LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
            }
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            // ADD 2009.01.08 >>>
            //受注残数判断     
            if (salesSlipSearchWork.AcptAnOdrStatus == 20 || salesSlipSearchWork.AcptAnOdrStatus == 40)
            {
                ConnectWhereClause(ref whereClause, "SD2.ACPTANODRREMAINCNTRF !=0");
            }
            // ADD 2009.01.08 <<<

            //受注ステータス
            if (IsValidParameter(salesSlipSearchWork.AcptAnOdrStatus, false))
            {
                ConnectWhereClause(ref whereClause, "SS.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS");
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.AcptAnOdrStatus);
            }
            //売上伝票区分
            if (IsValidParameter(salesSlipSearchWork.SalesSlipCd, true))
            {
                ConnectWhereClause(ref whereClause, "SS.SALESSLIPCDRF=@FINDSALESSLIPCD");
                SqlParameter findParaSalesSlipCd = sqlCommand.Parameters.Add("@FINDSALESSLIPCD", SqlDbType.Int);
                findParaSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.SalesSlipCd);
            }
            //受付従業員コード
            if (IsValidParameter(salesSlipSearchWork.FrontEmployeeCd))
            {
                ConnectWhereClause(ref whereClause, "SS.FRONTEMPLOYEECDRF=@FINDFRONTEMPLOYEECD");
                SqlParameter findParaFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDFRONTEMPLOYEECD", SqlDbType.NChar);
                findParaFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.FrontEmployeeCd);
            }
            //販売従業員コード
            if (IsValidParameter(salesSlipSearchWork.SalesEmployeeCd))
            {
                ConnectWhereClause(ref whereClause, "SS.SALESEMPLOYEECDRF=@FINDSALESEMPLOYEECD");
                SqlParameter findParaSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                findParaSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.SalesEmployeeCd);
            }
            //売掛区分
            if (IsValidParameter(salesSlipSearchWork.AccRecDivCd, true))
            {
                ConnectWhereClause(ref whereClause, "SS.ACCRECDIVCDRF=@FINDACCRECDIVCD");
                SqlParameter findParaAccRecDivCd = sqlCommand.Parameters.Add("@FINDACCRECDIVCD", SqlDbType.Int);
                findParaAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.AccRecDivCd);
            }
            //請求先コード
            if (IsValidParameter(salesSlipSearchWork.ClaimCode, false))
            {
                ConnectWhereClause(ref whereClause, "SS.CLAIMCODERF=@FINDCLAIMCODE");
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.ClaimCode);
            }
            //得意先コード
            if (IsValidParameter(salesSlipSearchWork.CustomerCode, false))
            {
                ConnectWhereClause(ref whereClause, "SS.CUSTOMERCODERF=@FINDCUSTOMERCODE");
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.CustomerCode);
            }
            //売上伝票番号(開始)
            if (IsValidParameter(salesSlipSearchWork.SalesSlipNumSt))
            {
                ConnectWhereClause(ref whereClause, "SS.SALESSLIPNUMRF>=@FINDSALESSLIPNUMST");
                SqlParameter findParaSalesSlipNumSt = sqlCommand.Parameters.Add("@FINDSALESSLIPNUMST", SqlDbType.NChar);
                findParaSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.SalesSlipNumSt);
            }
            //売上伝票番号(終了)
            if (IsValidParameter(salesSlipSearchWork.SalesSlipNumEd))
            {
                ConnectWhereClause(ref whereClause, "SS.SALESSLIPNUMRF<=@FINDSALESSLIPNUMED");
                SqlParameter findParaSalesSlipNumEd = sqlCommand.Parameters.Add("@FINDSALESSLIPNUMED", SqlDbType.NChar);
                findParaSalesSlipNumEd.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.SalesSlipNumEd);
            }
            //相手先伝票番号
            if (IsValidParameter(salesSlipSearchWork.PartySaleSlipNum))
            {
                ConnectWhereClause(ref whereClause, "SS.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM");
                SqlParameter findParaPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NChar);
                findParaPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.PartySaleSlipNum);
            }
            //売上日(開始)
            if (IsValidParameter(salesSlipSearchWork.SalesDateSt, false))
            {
                //貸出の場合は出荷日を参照、以外は売上日付
                ConnectWhereClause(ref whereClause, "((SS.ACPTANODRSTATUSRF <> 40 AND SS.SALESDATERF>=@FINDSALESHDATEST) OR (SS.ACPTANODRSTATUSRF = 40 AND SS.SHIPMENTDAYRF>=@FINDSALESHDATEST))");
                SqlParameter findParaSalesDateSt = sqlCommand.Parameters.Add("@FINDSALESHDATEST", SqlDbType.Int);
                findParaSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.SalesDateSt);
            }
            //売上日(終了)
            if (IsValidParameter(salesSlipSearchWork.SalesDateEd, false))
            {
                //貸出の場合は出荷日を参照、以外は売上日付
                ConnectWhereClause(ref whereClause, "((SS.ACPTANODRSTATUSRF <> 40 AND SS.SALESDATERF<=@FINDSALESHDATEED) OR (SS.ACPTANODRSTATUSRF = 40 AND SS.SHIPMENTDAYRF<=@FINDSALESHDATEED))");
                SqlParameter findParaSalesDateEd = sqlCommand.Parameters.Add("@FINDSALESHDATEED", SqlDbType.Int);
                findParaSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.SalesDateEd);
            }

            /*
            //出荷日(開始)
            if (IsValidParameter(salesSlipSearchWork.ShipmentDaySt, false))
            {
                ConnectWhereClause(ref whereClause, "SS.SHIPMENTDAYRF>=@FINDSHIPMENTDAYST");
                SqlParameter findParaShipmentDaySt = sqlCommand.Parameters.Add("@FINDSHIPMENTDAYST", SqlDbType.Int);
                findParaShipmentDaySt.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.ShipmentDaySt);
            }
            //出荷日(終了)
            if (IsValidParameter(salesSlipSearchWork.ShipmentDayEd, false))
            {
                ConnectWhereClause(ref whereClause, "SS.SHIPMENTDAYRF<=@FINDSHIPMENTDAYED");
                SqlParameter findParaShipmentDayEd = sqlCommand.Parameters.Add("@FINDSHIPMENTDAYED", SqlDbType.Int);
                findParaShipmentDayEd.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.ShipmentDayEd);
            }
            */ 

            //見積区分
            if (IsValidParameter(salesSlipSearchWork.EstimateDivide, false))
            {
                ConnectWhereClause(ref whereClause, "SS.ESTIMATEDIVIDERF=@FINDESTIMATEDIVIDE");
                SqlParameter findParaEstimateDivide = sqlCommand.Parameters.Add("@FINDESTIMATEDIVIDE", SqlDbType.Int);
                findParaEstimateDivide.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.EstimateDivide);
            }
            // ADD 2009.02.02 >>>
            else if (salesSlipSearchWork.EstimateDivide == -1) // -1:検索見積以外
            {
                ConnectWhereClause(ref whereClause, "SS.ESTIMATEDIVIDERF!=3");
            }
            // ADD 2009.02.02 <<<
            //伝票検索日付(開始)
            if (IsValidParameter(salesSlipSearchWork.SearchSlipDateSt,false))
            {
                ConnectWhereClause(ref whereClause, "SS.SEARCHSLIPDATERF>=@FINDSEARCHSLIPDATEST");
                SqlParameter findParaSearchSlipDateSt = sqlCommand.Parameters.Add("@FINDSEARCHSLIPDATEST", SqlDbType.Int);
                findParaSearchSlipDateSt.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.SearchSlipDateSt);
            }
            //伝票検索日付(終了)
            if (IsValidParameter(salesSlipSearchWork.SearchSlipDateEd,false))
            {
                ConnectWhereClause(ref whereClause, "SS.SEARCHSLIPDATERF<=@FINDSEARCHSLIPDATEED");
                SqlParameter findParaSearchSlipDateEd = sqlCommand.Parameters.Add("@FINDSEARCHSLIPDATEED", SqlDbType.Int);
                findParaSearchSlipDateEd.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.SearchSlipDateEd);
            }
            //売上入力者コード
            if (IsValidParameter(salesSlipSearchWork.SalesInputCode))
            {
                ConnectWhereClause(ref whereClause, "SS.SALESINPUTCODERF=@FINDSALESINPUTCODE");
                SqlParameter findParaSalesInputCode = sqlCommand.Parameters.Add("@FINDSALESINPUTCODE", SqlDbType.NChar);
                findParaSalesInputCode.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.SalesInputCode);
            }
            //拠点コード
            if (IsValidParameter(salesSlipSearchWork.SectionCode))
            {
                //ConnectWhereClause(ref whereClause, "SS.SECTIONCODERF=@FINDSECTIONCODE");// DEL 2008.11.06
                ConnectWhereClause(ref whereClause, "SS.RESULTSADDUPSECCDRF=@FINDSECTIONCODE");// ADD 2008.11.06
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.SectionCode);
            }
            //商品メーカーコード
            if (IsValidParameter(salesSlipSearchWork.GoodsMakerCd, false))
            {
                ConnectWhereClause(ref whereClause, "SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.GoodsMakerCd);
            }
            //商品番号
            if (IsValidParameter(salesSlipSearchWork.GoodsNo))
            {
                ConnectWhereClause(ref whereClause, "SD.GOODSNORF=@FINDGOODSNO");
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.GoodsNo);
            }

            // 部門コード
            if (IsValidParameter(salesSlipSearchWork.SubSectionCode, false))
            {
                ConnectWhereClause(ref whereClause, "SS.SUBSECTIONCODERF=@FINDSUBSECTIONCODE");
                SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(salesSlipSearchWork.SubSectionCode);
            }

            //型式
            if (string.IsNullOrEmpty(salesSlipSearchWork.FullModel) == false)
            {
                ConnectWhereClause(ref whereClause, "AOC.FULLMODELRF LIKE @FINDFULLMODEL");
                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (salesSlipSearchWork.FullModelSrchTyp == 1) salesSlipSearchWork.FullModel = salesSlipSearchWork.FullModel + "%";
                //後方一致検索の場合
                if (salesSlipSearchWork.FullModelSrchTyp == 2) salesSlipSearchWork.FullModel = "%" + salesSlipSearchWork.FullModel;
                //曖昧検索の場合
                if (salesSlipSearchWork.FullModelSrchTyp == 3) salesSlipSearchWork.FullModel = "%" + salesSlipSearchWork.FullModel + "%";

                paraFullModel.Value = SqlDataMediator.SqlSetString(salesSlipSearchWork.FullModel);
            }

            #endregion
        }
        /// <summary>
        /// WHERE句を接続する
        /// </summary>
        private void ConnectWhereClause(ref string whereClause, string addition)
        {
            if (String.IsNullOrEmpty(whereClause))
                whereClause += " WHERE " + addition;
            else
                whereClause += " AND " + addition;
        }
        /// <summary>
        /// ORDER BY 句を生成する
        /// </summary>
        /// <returns>ORDER BY 句</returns>
        private string SetOrderByClause(SalesSlipSearchWork salesSlipSearchWork)
        {
            if (salesSlipSearchWork.AcptAnOdrStatus == 40)
            {
                return " ORDER BY SS.ENTERPRISECODERF DESC , SS.SHIPMENTDAYRF DESC , SS.SALESSLIPNUMRF DESC"; // ADD 2009/04/08
            }
            else if (salesSlipSearchWork.AcptAnOdrStatus == -1)
            {
                return " ORDER BY SS.ENTERPRISECODERF DESC , ORDERDAY DESC , SS.SALESSLIPNUMRF DESC"; // ADD 2009/04/08
            }
            else
            {
                //return " ORDER BY SS.ENTERPRISECODERF, SS.SALESSLIPNUMRF"; // DEL 2008.12.08
                return " ORDER BY SS.ENTERPRISECODERF DESC , SS.SALESDATERF DESC , SS.SALESSLIPNUMRF DESC"; // ADD 2008.12.08
            }

        }

        /// <summary>
        /// stringが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(string value)
        {
            return !String.IsNullOrEmpty(value);
        }
        /// <summary>
        /// intが有効なパラメータかどうかを判断する
        /// </summary>
        /// <param name="value">パラメータ</param>
        /// <param name="includeZero">0を含むかどうか(true:0有効 false:0無効)</param>
        private bool IsValidParameter(int value, bool includeZero)
        {
            if (includeZero)
                return value >= 0;
            else
                return value > 0;
        }
        /// <summary>
        /// DateTimeが有効なパラメータかどうかを判断する
        /// </summary>
        private bool IsValidParameter(DateTime value)
        {
            return value > DateTime.MinValue;
        }
        #endregion

        #region データセット
        /// <summary>
        /// SqlDataReader を SalesSlipSearchResultWork に変換
        /// </summary>
        /// <param name="myReader">抽出結果 SqlDataReader</param>
        /// <returns>データセット済み SalesSlipSearchResultWork オブジェクト</returns>
        private SalesSlipSearchResultWork ReaderToSalesSlipSearchResultWork(ref SqlDataReader myReader)
        {
            SalesSlipSearchResultWork salesSlipSearchResultWork = new SalesSlipSearchResultWork();

            #region SalesSlipSearchResultWorkに代入
            salesSlipSearchResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salesSlipSearchResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            salesSlipSearchResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            salesSlipSearchResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            //salesSlipSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // DEL 2008.11.06
            salesSlipSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ADD 2008.11.06

            salesSlipSearchResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            salesSlipSearchResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            salesSlipSearchResultWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            salesSlipSearchResultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            salesSlipSearchResultWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
            salesSlipSearchResultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            salesSlipSearchResultWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            salesSlipSearchResultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            salesSlipSearchResultWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
            salesSlipSearchResultWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            salesSlipSearchResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            salesSlipSearchResultWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
            salesSlipSearchResultWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            salesSlipSearchResultWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            salesSlipSearchResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            salesSlipSearchResultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            salesSlipSearchResultWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
            salesSlipSearchResultWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));
            salesSlipSearchResultWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));
            salesSlipSearchResultWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
            salesSlipSearchResultWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
            salesSlipSearchResultWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            salesSlipSearchResultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            salesSlipSearchResultWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            salesSlipSearchResultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            salesSlipSearchResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            salesSlipSearchResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            salesSlipSearchResultWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            salesSlipSearchResultWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            salesSlipSearchResultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            salesSlipSearchResultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            salesSlipSearchResultWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
            salesSlipSearchResultWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
            salesSlipSearchResultWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
            salesSlipSearchResultWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
            salesSlipSearchResultWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
            salesSlipSearchResultWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
            salesSlipSearchResultWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
            salesSlipSearchResultWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
            salesSlipSearchResultWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
            salesSlipSearchResultWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
            salesSlipSearchResultWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
            salesSlipSearchResultWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            salesSlipSearchResultWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
            salesSlipSearchResultWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
            salesSlipSearchResultWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
            salesSlipSearchResultWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
            salesSlipSearchResultWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
            salesSlipSearchResultWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
            salesSlipSearchResultWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
            salesSlipSearchResultWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
            salesSlipSearchResultWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
            salesSlipSearchResultWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
            salesSlipSearchResultWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
            salesSlipSearchResultWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
            salesSlipSearchResultWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
            salesSlipSearchResultWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
            salesSlipSearchResultWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
            salesSlipSearchResultWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
            salesSlipSearchResultWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
            salesSlipSearchResultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
            salesSlipSearchResultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            salesSlipSearchResultWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
            salesSlipSearchResultWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            salesSlipSearchResultWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
            salesSlipSearchResultWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
            salesSlipSearchResultWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
            salesSlipSearchResultWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
            salesSlipSearchResultWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
            salesSlipSearchResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            salesSlipSearchResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            salesSlipSearchResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            salesSlipSearchResultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            salesSlipSearchResultWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            salesSlipSearchResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            salesSlipSearchResultWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            salesSlipSearchResultWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
            salesSlipSearchResultWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            salesSlipSearchResultWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            salesSlipSearchResultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            salesSlipSearchResultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            salesSlipSearchResultWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            salesSlipSearchResultWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            salesSlipSearchResultWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            salesSlipSearchResultWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            salesSlipSearchResultWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            salesSlipSearchResultWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            salesSlipSearchResultWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            salesSlipSearchResultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            salesSlipSearchResultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            salesSlipSearchResultWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            salesSlipSearchResultWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            salesSlipSearchResultWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            salesSlipSearchResultWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            salesSlipSearchResultWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));
            salesSlipSearchResultWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            salesSlipSearchResultWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));
            salesSlipSearchResultWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
            salesSlipSearchResultWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
            salesSlipSearchResultWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
            salesSlipSearchResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            salesSlipSearchResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            salesSlipSearchResultWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
            salesSlipSearchResultWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
            salesSlipSearchResultWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
            salesSlipSearchResultWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            salesSlipSearchResultWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            salesSlipSearchResultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            salesSlipSearchResultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
            salesSlipSearchResultWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
            salesSlipSearchResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            salesSlipSearchResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            salesSlipSearchResultWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));
            salesSlipSearchResultWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            salesSlipSearchResultWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
            salesSlipSearchResultWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
            salesSlipSearchResultWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
            salesSlipSearchResultWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
            salesSlipSearchResultWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
            salesSlipSearchResultWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
            salesSlipSearchResultWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
            salesSlipSearchResultWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
            salesSlipSearchResultWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
            salesSlipSearchResultWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
            salesSlipSearchResultWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
            salesSlipSearchResultWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
            salesSlipSearchResultWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
            salesSlipSearchResultWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
            salesSlipSearchResultWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
            salesSlipSearchResultWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
            salesSlipSearchResultWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
            salesSlipSearchResultWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
            salesSlipSearchResultWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
            salesSlipSearchResultWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
            salesSlipSearchResultWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
            salesSlipSearchResultWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));
            salesSlipSearchResultWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
            salesSlipSearchResultWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));
            salesSlipSearchResultWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));
            salesSlipSearchResultWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
            salesSlipSearchResultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
            salesSlipSearchResultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
            salesSlipSearchResultWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));
            salesSlipSearchResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
            salesSlipSearchResultWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));

            #endregion

            return salesSlipSearchResultWork;
        }
        #endregion

        #region 売上明細データ引当
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上明細データLISTを戻します
        /// </summary>
        /// <param name="salesSlipDetailSearchResult">検索結果</param>
        /// <param name="salesSlipDetailSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたパラメータの条件を満たす全ての売上明細データLISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.17</br>
        /// <br></br>
        /// <br>Update Note: 980081 山田 明友</br>
        /// <br>Date       : 2007.12.13</br>
        /// <br>             論理削除区分のチェックを追加</br>
        public int SearchDetail(out object salesSlipDetailSearchResult, object salesSlipDetailSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            salesSlipDetailSearchResult = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //検索実行
            ArrayList salesSlipDetailSearchResultWorkList = new ArrayList();
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = GetSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchDetail(out salesSlipDetailSearchResultWorkList, (SalesSlipDetailSearchWork)salesSlipDetailSearchWork, ref sqlConnection, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchSalesSlipDB.SearchDetail");
                return status;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            //outパラメータを設定
            salesSlipDetailSearchResult = salesSlipDetailSearchResultWorkList;

            return status;
        }
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての売上明細データLISTを戻します
        /// </summary>
        /// <param name="salesSlipDetailSearchResultWorkList">検索結果</param>
        /// <param name="salesSlipDetailSearchWork">検索パラメータ</param>
        /// <param name="sqlConnection">SQL接続情報</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date       : 2011/11/11</br>
        /// <br>Update Note: 管理番号 : 11900025-00 作成担当 : 3H 仰亮亮</br>
        /// <br>           : 修正内容 : READUNCOMMITTED対応</br>
        /// <br>Date       : 2023/11/07</br>
        private int SearchDetail(out ArrayList salesSlipDetailSearchResultWorkList, SalesSlipDetailSearchWork salesSlipDetailSearchWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            salesSlipDetailSearchResultWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //SqlEncryptInfo sqlEncriptInfo = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                //暗号化キーOPEN
                //sqlEncriptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "SALESDETAILRF" });
                //sqlEncriptInfo.OpenSymKey(ref sqlConnection);

                //クエリ文字列生成
                string queryString = string.Empty;
                queryString += "SELECT DISTINCT" + Environment.NewLine;
                queryString += "     SD.ENTERPRISECODERF" + Environment.NewLine;
                queryString += "    ,SD.LOGICALDELETECODERF" + Environment.NewLine;
                queryString += "    ,SD.ACCEPTANORDERNORF" + Environment.NewLine;
                queryString += "    ,SD.ACPTANODRSTATUSRF" + Environment.NewLine;
                queryString += "    ,SD.SALESSLIPNUMRF" + Environment.NewLine;
                queryString += "    ,SD.SALESROWNORF" + Environment.NewLine;
                queryString += "    ,SD.SALESROWDERIVNORF" + Environment.NewLine;
                queryString += "    ,SD.SECTIONCODERF" + Environment.NewLine;
                queryString += "    ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                queryString += "    ,SD.SUBSECTIONCODERF" + Environment.NewLine;
                queryString += "    ,SUB.SUBSECTIONNAMERF" + Environment.NewLine;
                queryString += "    ,SD.SALESDATERF" + Environment.NewLine;
                queryString += "    ,SD.COMMONSEQNORF" + Environment.NewLine;
                queryString += "    ,SD.SALESSLIPDTLNUMRF" + Environment.NewLine;
                queryString += "    ,SD.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                queryString += "    ,SD.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                queryString += "    ,SD.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                queryString += "    ,SD.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                queryString += "    ,SD.SALESSLIPCDDTLRF" + Environment.NewLine;
                queryString += "    ,SD.DELIGDSCMPLTDUEDATERF" + Environment.NewLine;
                queryString += "    ,SD.GOODSKINDCODERF" + Environment.NewLine;
                queryString += "    ,SD.GOODSSEARCHDIVCDRF" + Environment.NewLine;
                queryString += "    ,SD.GOODSMAKERCDRF" + Environment.NewLine;
                queryString += "    ,SD.MAKERNAMERF" + Environment.NewLine;
                queryString += "    ,SD.GOODSNORF" + Environment.NewLine;
                queryString += "    ,SD.GOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SD.GOODSLGROUPRF" + Environment.NewLine;
                queryString += "    ,SD.GOODSLGROUPNAMERF" + Environment.NewLine;
                queryString += "    ,SD.GOODSMGROUPRF" + Environment.NewLine;
                queryString += "    ,SD.GOODSMGROUPNAMERF" + Environment.NewLine;
                queryString += "    ,SD.BLGROUPCODERF" + Environment.NewLine;
                queryString += "    ,SD.BLGROUPNAMERF" + Environment.NewLine;
                queryString += "    ,SD.BLGOODSCODERF" + Environment.NewLine;
                queryString += "    ,SD.BLGOODSFULLNAMERF" + Environment.NewLine;
                queryString += "    ,SD.ENTERPRISEGANRECODERF" + Environment.NewLine;
                queryString += "    ,SD.ENTERPRISEGANRENAMERF" + Environment.NewLine;
                queryString += "    ,SD.WAREHOUSECODERF" + Environment.NewLine;
                queryString += "    ,SD.WAREHOUSENAMERF" + Environment.NewLine;
                queryString += "    ,SD.WAREHOUSESHELFNORF" + Environment.NewLine;
                queryString += "    ,SD.SALESORDERDIVCDRF" + Environment.NewLine;
                queryString += "    ,SD.OPENPRICEDIVRF" + Environment.NewLine;
                queryString += "    ,SD.GOODSRATERANKRF" + Environment.NewLine;
                queryString += "    ,SD.CUSTRATEGRPCODERF" + Environment.NewLine;
                queryString += "    ,SD.LISTPRICERATERF" + Environment.NewLine;
                queryString += "    ,SD.RATESECTPRICEUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.RATEDIVLPRICERF" + Environment.NewLine;
                queryString += "    ,SD.UNPRCCALCCDLPRICERF" + Environment.NewLine;
                queryString += "    ,SD.PRICECDLPRICERF" + Environment.NewLine;
                queryString += "    ,SD.STDUNPRCLPRICERF" + Environment.NewLine;
                queryString += "    ,SD.FRACPROCUNITLPRICERF" + Environment.NewLine;
                queryString += "    ,SD.FRACPROCLPRICERF" + Environment.NewLine;
                queryString += "    ,SD.LISTPRICETAXINCFLRF" + Environment.NewLine;
                queryString += "    ,SD.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                queryString += "    ,SD.LISTPRICECHNGCDRF" + Environment.NewLine;
                queryString += "    ,SD.SALESRATERF" + Environment.NewLine;
                queryString += "    ,SD.RATESECTSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.RATEDIVSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.UNPRCCALCCDSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.PRICECDSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.FRACPROCUNITSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.FRACPROCSALUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                queryString += "    ,SD.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                queryString += "    ,SD.SALESUNPRCCHNGCDRF" + Environment.NewLine;
                queryString += "    ,SD.COSTRATERF" + Environment.NewLine;
                queryString += "    ,SD.RATESECTCSTUNPRCRF" + Environment.NewLine;
                queryString += "    ,SD.RATEDIVUNCSTRF" + Environment.NewLine;
                queryString += "    ,SD.UNPRCCALCCDUNCSTRF" + Environment.NewLine;
                queryString += "    ,SD.PRICECDUNCSTRF" + Environment.NewLine;
                queryString += "    ,SD.STDUNPRCUNCSTRF" + Environment.NewLine;
                queryString += "    ,SD.FRACPROCUNITUNCSTRF" + Environment.NewLine;
                queryString += "    ,SD.FRACPROCUNCSTRF" + Environment.NewLine;
                queryString += "    ,SD.SALESUNITCOSTRF" + Environment.NewLine;
                queryString += "    ,SD.SALESUNITCOSTCHNGDIVRF" + Environment.NewLine;
                queryString += "    ,SD.RATEBLGOODSCODERF" + Environment.NewLine;
                queryString += "    ,SD.RATEBLGOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SD.PRTBLGOODSCODERF" + Environment.NewLine;
                queryString += "    ,SD.PRTBLGOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SD.SALESCODERF" + Environment.NewLine;
                queryString += "    ,SD.SALESCDNMRF" + Environment.NewLine;
                queryString += "    ,SD.WORKMANHOURRF" + Environment.NewLine;
                queryString += "    ,SD.SHIPMENTCNTRF" + Environment.NewLine;
                queryString += "    ,SD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                queryString += "    ,SD.ACPTANODRADJUSTCNTRF" + Environment.NewLine;
                queryString += "    ,SD.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                queryString += "    ,SD.REMAINCNTUPDDATERF" + Environment.NewLine;
                queryString += "    ,SD.SALESMONEYTAXINCRF" + Environment.NewLine;
                queryString += "    ,SD.SALESMONEYTAXEXCRF" + Environment.NewLine;
                queryString += "    ,SD.COSTRF" + Environment.NewLine;
                queryString += "    ,SD.GRSPROFITCHKDIVRF" + Environment.NewLine;
                queryString += "    ,SD.SALESGOODSCDRF" + Environment.NewLine;
                queryString += "    ,SD.SALESPRICECONSTAXRF" + Environment.NewLine;
                queryString += "    ,SD.TAXATIONDIVCDRF" + Environment.NewLine;
                queryString += "    ,SD.PARTYSLIPNUMDTLRF" + Environment.NewLine;
                queryString += "    ,SD.DTLNOTERF" + Environment.NewLine;
                queryString += "    ,SD.SUPPLIERCDRF" + Environment.NewLine;
                queryString += "    ,SD.SUPPLIERSNMRF" + Environment.NewLine;
                queryString += "    ,SD.ORDERNUMBERRF" + Environment.NewLine;
                queryString += "    ,SD.WAYTOORDERRF" + Environment.NewLine;
                queryString += "    ,SD.SLIPMEMO1RF" + Environment.NewLine;
                queryString += "    ,SD.SLIPMEMO2RF" + Environment.NewLine;
                queryString += "    ,SD.SLIPMEMO3RF" + Environment.NewLine;
                queryString += "    ,SD.INSIDEMEMO1RF" + Environment.NewLine;
                queryString += "    ,SD.INSIDEMEMO2RF" + Environment.NewLine;
                queryString += "    ,SD.INSIDEMEMO3RF" + Environment.NewLine;
                queryString += "    ,SD.BFLISTPRICERF" + Environment.NewLine;
                queryString += "    ,SD.BFSALESUNITPRICERF" + Environment.NewLine;
                queryString += "    ,SD.BFUNITCOSTRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTSALESROWNORF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTGOODSMAKERCDRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTMAKERNAMERF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTGOODSNAMERF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTSHIPMENTCNTRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTSALESUNPRCFLRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTSALESMONEYRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTSALESUNITCOSTRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTCOSTRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTPARTYSALSLNUMRF" + Environment.NewLine;
                queryString += "    ,SD.CMPLTNOTERF" + Environment.NewLine;
                queryString += "    ,SD.AUTOANSWERDIVSCMRF" + Environment.NewLine;// add 2011/07/18 朱宝軍 
                queryString += "    ,SD.ACCEPTORORDERKINDRF" + Environment.NewLine;// ADD 2011/11/11
                //queryString += " FROM SALESDETAILRF AS SD" + Environment.NewLine;//  DEL 3H 仰亮亮 2023/11/07
                queryString += " FROM SALESDETAILRF AS SD WITH (READUNCOMMITTED)" + Environment.NewLine;//  ADD 3H 仰亮亮 2023/11/07
                sqlCommand = new SqlCommand(queryString, sqlConnection);

                //パラメータよりFROM句、WHERE句生成
                string fromClause;
                string whereClause;
                SetFromWhereClauseDetail(ref sqlCommand, salesSlipDetailSearchWork, out fromClause, out whereClause, logicalMode);
                if (!String.IsNullOrEmpty(fromClause)) sqlCommand.CommandText += fromClause;
                if (!String.IsNullOrEmpty(whereClause)) sqlCommand.CommandText += whereClause;

                //ORDER BY
                //sqlCommand.CommandText += " ORDER BY ENTERPRISECODERF, SALESSLIPNUMRF, SALESROWNORF "; // DEL 2008.12.08
                sqlCommand.CommandText += " ORDER BY ENTERPRISECODERF DESC , SALESDATERF DESC , SALESSLIPNUMRF DESC , SALESROWNORF DESC "; // ADD 2008.12.08

                //実行
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        salesSlipDetailSearchResultWorkList.Add(ReaderToSalesSlipDetailSearchResultWork(ref myReader));
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                //暗号化キークローズ
                //if (sqlEncriptInfo != null)
                //    if (sqlEncriptInfo.IsOpen) sqlEncriptInfo.CloseSymKey(ref sqlConnection);
            }

            if (sqlConnection == null) return status;
            return status;
        }

        /// <summary>
        /// パラメータより、動的にFROM句、WHERE句を生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommand オブジェクト</param>
        /// <param name="salesSlipDetailSearchWork">検索パラメータ</param>
        /// <param name="fromClause">FROM句クエリ文字列</param>
        /// <param name="whereClause">WHERE句クエリ文字列</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:保留データのみ 3:完全削除データのみ 4:全件 5:正規データ+削除データ 6:正規データ+削除データ+保留データ)</param>
        /// <br>Update Note: 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date       : 2011/11/11</br>
        /// <br>Update Note: 管理番号 : 11900025-00 作成担当 : 3H 仰亮亮</br>
        /// <br>           : 修正内容 : READUNCOMMITTED対応</br>
        /// <br>Date       : 2023/11/07</br>
        private void SetFromWhereClauseDetail(ref SqlCommand sqlCommand, SalesSlipDetailSearchWork salesSlipDetailSearchWork, out string fromClause, out string whereClause, ConstantManagement.LogicalMode logicalMode)
        {
            fromClause = String.Empty;
            whereClause = String.Empty;
            // --- DEL START 3H 仰亮亮 2023/11/07 -------------------->>>>>
            //fromClause += " LEFT JOIN SECINFOSETRF AS SEC ON (SD.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SD.SECTIONCODERF=SEC.SECTIONCODERF)"
            //+ " LEFT JOIN SUBSECTIONRF AS SUB ON (SD.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SD.SECTIONCODERF=SUB.SECTIONCODERF AND SD.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)";
            // --- DEL END 3H 仰亮亮 2023/11/07 ----------------------<<<<<
            // --- ADD START 3H 仰亮亮 2023/11/07 -------------------->>>>>
            fromClause += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ON (SD.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND SD.SECTIONCODERF=SEC.SECTIONCODERF)"
                        + " LEFT JOIN SUBSECTIONRF AS SUB WITH (READUNCOMMITTED) ON (SD.ENTERPRISECODERF=SUB.ENTERPRISECODERF AND SD.SECTIONCODERF=SUB.SECTIONCODERF AND SD.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF)";
            // --- ADD END 3H 仰亮亮 2023/11/07 ----------------------<<<<<
            #region パラメータより
            //企業コード
            if (IsValidParameter(salesSlipDetailSearchWork.EnterpriseCode))
            {
                ConnectWhereClause(ref whereClause, "SD.ENTERPRISECODERF=@FINDENTERPRISECODE");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesSlipDetailSearchWork.EnterpriseCode);
            }
            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                ConnectWhereClause(ref whereClause, "SD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                ConnectWhereClause(ref whereClause, "SD.LOGICALDELETECODERF<@FINDLOGICALDELETECODE");
            }
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            //受注ステータス
            if (IsValidParameter(salesSlipDetailSearchWork.AcptAnOdrStatus, false))
            {
                ConnectWhereClause(ref whereClause, "SD.ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS");
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesSlipDetailSearchWork.AcptAnOdrStatus);
            }
            //売上伝票番号
            if (IsValidParameter(salesSlipDetailSearchWork.SalesSlipNum))
            {
                ConnectWhereClause(ref whereClause, "SD.SALESSLIPNUMRF=@FINDSALESSLIPNUM");
                SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipDetailSearchWork.SalesSlipNum);
            }
            // --- DEL 2014/04/17 Y.Wakita ---------->>>>>
            ////一式データ(一式明細番号=0)
            //ConnectWhereClause(ref whereClause, "SD.CMPLTSALESROWNORF=0");
            // --- DEL 2014/04/17 Y.Wakita ----------<<<<<
            //---ADD 2011/11/11 ------------------------------------->>>>>
            if (_salesSlipSearchWorks.AutoAnswerDivSCM == 0)
            {
                whereClause += (" AND SD.AUTOANSWERDIVSCMRF=0");
            }
            if (_salesSlipSearchWorks.AutoAnswerDivSCM == 1)
            {
                if (_salesSlipSearchWorks.AcceptOrOrderKind == -1)
                {
                    whereClause += (" AND SD.AUTOANSWERDIVSCMRF=0");
                }
                else if (_salesSlipSearchWorks.AcceptOrOrderKind == 0)
                {
                    whereClause += (" AND (SD.AUTOANSWERDIVSCMRF= 0 OR (SD.AUTOANSWERDIVSCMRF<> 0 AND SD.ACCEPTORORDERKINDRF=0))");
                }
                else if (_salesSlipSearchWorks.AcceptOrOrderKind == 1)
                {
                    whereClause += (" AND (SD.AUTOANSWERDIVSCMRF= 0 OR (SD.AUTOANSWERDIVSCMRF<> 0 AND SD.ACCEPTORORDERKINDRF=1))");
                }
                else if (_salesSlipSearchWorks.AcceptOrOrderKind == 2)
                {
                    whereClause += (" AND (SD.AUTOANSWERDIVSCMRF=0 OR SD.AUTOANSWERDIVSCMRF=1 OR SD.AUTOANSWERDIVSCMRF=2)");
                }
            }
            if (_salesSlipSearchWorks.AutoAnswerDivSCM == 2)
            {
                if (_salesSlipSearchWorks.AcceptOrOrderKind == -1)
                {
                    whereClause += (" AND SD.AcceptOrOrderKind = -1");
                }
                else if (_salesSlipSearchWorks.AcceptOrOrderKind == 0)
                {
                    whereClause += (" AND ((SD.ACCEPTORORDERKINDRF=0 ) AND  SD.AUTOANSWERDIVSCMRF <>0)");
                }
                else if (_salesSlipSearchWorks.AcceptOrOrderKind == 1)
                {
                    whereClause += (" AND ((SD.ACCEPTORORDERKINDRF=1 ) AND  SD.AUTOANSWERDIVSCMRF <>0)");
                }
                else if (_salesSlipSearchWorks.AcceptOrOrderKind == 2)
                {
                    whereClause += (" AND ((SD.ACCEPTORORDERKINDRF=0 OR SD.ACCEPTORORDERKINDRF=1) AND  SD.AUTOANSWERDIVSCMRF <>0)");
                }
            }
            //---ADD 2011/11/11 -------------------------------------<<<<<

            #endregion
        }

        /// <summary>
        /// SqlDataReader を SalesSlipDetailSearchResultWork に変換
        /// </summary>
        /// <param name="myReader">抽出結果 SqlDataReader</param>
        /// <returns>データセット済み SalesSlipDetailSearchResultWork オブジェクト</returns>
        /// <br>Update Note: 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date       : 2011/11/11</br>
        private SalesSlipDetailSearchResultWork ReaderToSalesSlipDetailSearchResultWork(ref SqlDataReader myReader)
        {
            SalesSlipDetailSearchResultWork salesSlipDetailSearchResultWork = new SalesSlipDetailSearchResultWork();

            #region SalesSlipDetailSearchResultWorkに代入
            salesSlipDetailSearchResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            salesSlipDetailSearchResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            salesSlipDetailSearchResultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            salesSlipDetailSearchResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            salesSlipDetailSearchResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            salesSlipDetailSearchResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
            salesSlipDetailSearchResultWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
            salesSlipDetailSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            salesSlipDetailSearchResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            salesSlipDetailSearchResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            salesSlipDetailSearchResultWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            salesSlipDetailSearchResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            salesSlipDetailSearchResultWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            salesSlipDetailSearchResultWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            salesSlipDetailSearchResultWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
            salesSlipDetailSearchResultWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
            salesSlipDetailSearchResultWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
            salesSlipDetailSearchResultWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
            salesSlipDetailSearchResultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
            salesSlipDetailSearchResultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
            salesSlipDetailSearchResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            salesSlipDetailSearchResultWork.GoodsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSEARCHDIVCDRF"));
            salesSlipDetailSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            salesSlipDetailSearchResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            salesSlipDetailSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            salesSlipDetailSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            salesSlipDetailSearchResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            salesSlipDetailSearchResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            salesSlipDetailSearchResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            salesSlipDetailSearchResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            salesSlipDetailSearchResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            salesSlipDetailSearchResultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            salesSlipDetailSearchResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            salesSlipDetailSearchResultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            salesSlipDetailSearchResultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            salesSlipDetailSearchResultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            salesSlipDetailSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            salesSlipDetailSearchResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            salesSlipDetailSearchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            salesSlipDetailSearchResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
            salesSlipDetailSearchResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            salesSlipDetailSearchResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            salesSlipDetailSearchResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            salesSlipDetailSearchResultWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
            salesSlipDetailSearchResultWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
            salesSlipDetailSearchResultWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
            salesSlipDetailSearchResultWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
            salesSlipDetailSearchResultWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
            salesSlipDetailSearchResultWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
            salesSlipDetailSearchResultWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
            salesSlipDetailSearchResultWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
            salesSlipDetailSearchResultWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            salesSlipDetailSearchResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            salesSlipDetailSearchResultWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
            salesSlipDetailSearchResultWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
            salesSlipDetailSearchResultWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
            salesSlipDetailSearchResultWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
            salesSlipDetailSearchResultWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
            salesSlipDetailSearchResultWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
            salesSlipDetailSearchResultWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
            salesSlipDetailSearchResultWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
            salesSlipDetailSearchResultWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
            salesSlipDetailSearchResultWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
            salesSlipDetailSearchResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            salesSlipDetailSearchResultWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
            salesSlipDetailSearchResultWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
            salesSlipDetailSearchResultWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
            salesSlipDetailSearchResultWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
            salesSlipDetailSearchResultWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
            salesSlipDetailSearchResultWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
            salesSlipDetailSearchResultWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
            salesSlipDetailSearchResultWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
            salesSlipDetailSearchResultWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
            salesSlipDetailSearchResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            salesSlipDetailSearchResultWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
            salesSlipDetailSearchResultWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
            salesSlipDetailSearchResultWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
            salesSlipDetailSearchResultWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
            salesSlipDetailSearchResultWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
            salesSlipDetailSearchResultWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            salesSlipDetailSearchResultWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
            salesSlipDetailSearchResultWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
            salesSlipDetailSearchResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            salesSlipDetailSearchResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
            salesSlipDetailSearchResultWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
            salesSlipDetailSearchResultWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
            salesSlipDetailSearchResultWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
            salesSlipDetailSearchResultWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
            salesSlipDetailSearchResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            salesSlipDetailSearchResultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
            salesSlipDetailSearchResultWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
            salesSlipDetailSearchResultWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            salesSlipDetailSearchResultWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
            salesSlipDetailSearchResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            salesSlipDetailSearchResultWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
            salesSlipDetailSearchResultWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            salesSlipDetailSearchResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            salesSlipDetailSearchResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            salesSlipDetailSearchResultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            salesSlipDetailSearchResultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
            salesSlipDetailSearchResultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            salesSlipDetailSearchResultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            salesSlipDetailSearchResultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            salesSlipDetailSearchResultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            salesSlipDetailSearchResultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            salesSlipDetailSearchResultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            salesSlipDetailSearchResultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
            salesSlipDetailSearchResultWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
            salesSlipDetailSearchResultWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
            salesSlipDetailSearchResultWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
            salesSlipDetailSearchResultWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
            salesSlipDetailSearchResultWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
            salesSlipDetailSearchResultWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
            salesSlipDetailSearchResultWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
            salesSlipDetailSearchResultWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
            salesSlipDetailSearchResultWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
            salesSlipDetailSearchResultWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
            salesSlipDetailSearchResultWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
            salesSlipDetailSearchResultWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
            salesSlipDetailSearchResultWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
            salesSlipDetailSearchResultWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));// add 2011/07/18 朱宝軍            
            salesSlipDetailSearchResultWork.AcceptOrOrderKind = SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal("ACCEPTORORDERKINDRF"));// ADD 2011/11/11 
            #endregion

            return salesSlipDetailSearchResultWork;
        }
        #endregion

        #region SQLコネクション取得
        /// <summary>
        /// SQLコネクション取得
        /// </summary>
        /// <returns>SQLコネクション</returns>
        private SqlConnection GetSqlConnection()
        {
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            return new SqlConnection(connectionText);
        }
        #endregion

        #region ユーティリティ
        /// <summary>
        /// ArrayListが空かどうかを判断する
        /// </summary>
        /// <param name="al">検査する対象のArrayList</param>
        /// <returns>true:空 false:空でない</returns>
        private bool IsEmpty(ArrayList al)
        {
            if (al == null || al.Count <= 0) return true;
            return false;
        }
        private bool IsNotEmpty(ArrayList al)
        {
            return !IsEmpty(al);
        }

        /// <summary>
        /// ステータスのエラーチェック
        /// </summary>
        /// <param name="status">ステータス</param>
        private bool HasError(int status)
        {
            return (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL);
        }
        private bool HasNoError(int status)
        {
            return (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL);
        }
        #endregion
    }
}

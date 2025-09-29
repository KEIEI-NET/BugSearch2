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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上確認表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上確認表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20098　村瀬　勝也</br>
    /// <br>Date       : 2007.03.19</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2007.10.18</br>
    /// <br>           : DC対応</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2007.11.07</br>
    /// <br>           : 納入場所住所等を戻り値に追加</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2008.03.21</br>
    /// <br>           : 金額項目の最新レイアウト対応</br>
    /// <br>           : (残高調整データ・消費税調整データ対応)</br>
    /// <br></br>
    /// <br>Update Note: 980081  山田 明友</br>
    /// <br>Date       : 2008.03.25</br>
    /// <br>           : 諸口得意先のみ正式名(手入力した名称)を取得</br>
    /// <br></br>
    /// <br>Update Note: ＰＭ.ＮＳ用に変更 UIではSearchSlip、SearchDetailを使用</br>
    /// <br>Date       : 2008.07.01</br>
    /// <br>           : 20081 疋田 勇人</br>
    /// <br></br>
    /// <br>Update Note: 伝票タイプ印刷の場合に同一レコードが重複表示されるエラー対応</br>
    /// <br>Date       : 2008.09.17</br>
    /// <br>           : 23015 森本 大輝</br>
    /// <br></br>
    /// <br>Update Note: 拠点ガイド名称⇒拠点ガイド略称に変更</br>
    /// <br>Date       : 2008.10.08</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 抽出結果クラスへの項目追加対応</br>
    /// <br>Date       : 2008.10.28</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 抽出不具合修正</br>
    /// <br>Date       : 2008.11.04 2008.11.25</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: 抽出不具合修正</br>
    /// <br>Date       : 2009/5/18</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: MANTIS対応[11184]</br>
    /// <br>Date       : 2009/7/23</br>
    /// <br>           : 23012 畠中 啓次朗</br>
    /// <br></br>
    /// <br>Update Note: MANTIS対応[14013]</br>
    /// <br>Date       : 2009/08/10</br>
    /// <br>           : 22008 長内 数馬</br>
    /// <br></br>
    /// <br>Update Note: ゼロ指定条件をOR条件に変更</br>
    /// <br>           : 粗利ゼロ以下、粗利率以下、以上で指定値を含むように修正</br>
    /// <br>           : 注釈行を抽出しないように修正</br>
    /// <br>Date       : 2009/10/22</br>
    /// <br>           : 22008 長内 数馬</br>
    /// <br></br>
    /// <br>Update Note: 速度チューニング</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>           : 22008 長内 数馬</br>
    /// <br></br>
    /// <br>Update Note: 粗利率の指定条件の不具合修正</br>
    /// <br>Date       : 2010/06/08</br>
    /// <br>           : 30517 夏野 駿希</br>
    /// <br></br>
    /// <br>Update Note: Mantis.15691　車種名の印字を車種全角名称から車種半角名称へ変更する。</br>
    /// <br>Date       : 2010/06/29</br>
    /// <br>           : 30517 夏野 駿希</br>
    /// <br></br>
    /// <br>Update Note: Mantis【15806】品名に品名カナをセットするように修正</br>
    /// <br>Date       : 30531 2010/07/14</br>
    /// <br>           : 30531 大矢 睦美</br>
    /// <br>Update Note: 明細に「自動回答」の追加対応</br>
    /// <br>Date       : 2011/07/18</br>
    /// <br>           : 施健</br>
    /// <br>Update Note: 障害報告 #8076売上確認表/訂正伝票と削除伝票の区別についての対応</br>
    /// <br>Date       : 2011/11/29</br>
    /// <br>           : 陳建明</br>
    /// <br>Update Note: 管理番号 : 10904597-00 作成担当 : 宮本 利明</br>
    /// <br>           : 修正内容 : 純正定価印字対応の障害対応</br>
    /// <br>Date       : 2014/04/17</br>
    /// <br></br>
    /// <br>Update Note: 「売上伝票入力」の登録でタイムアウトが出続けましたの対応 for redmine #42684 </br>
    /// <br>Date       : 2014/05/29</br>
    /// <br>           : zhangwei</br>
    /// <br></br>
	/// <br>Update Note: 11570208-00 軽減税率対応 </br>
	/// <br>Date       : 2020/02/27</br>
    /// <br>           : 3H 尹安</br>
    /// <br></br>
    /// <br>Update Note: 11800255-00　インボイス対応（税率別合計金額不具合修正） </br>
    /// <br>Date       : 2022/09/05</br>
    /// <br>           : 陳艶丹 </br>
    /// </remarks>
    [Serializable]
    public class SalesConfDB : RemoteDB, ISalesConfDB
    {
        /// <summary>
        /// 売上確認表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        public SalesConfDB()
            :
            base("MAHNB02356D", "Broadleaf.Application.Remoting.ParamData.SalesConfWork", "SALESCONFRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の売上確認表情報LISTを戻します
        /// </summary>
        /// <param name="salesConfWork">検索結果</param>
        /// <param name="parasalesConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表情報LISTを戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int Search(out object salesConfWork, object parasalesConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesConfWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesConfProc(out salesConfWork, parasalesConfWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesConfDB.Search");
                salesConfWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の売上確認表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsalesConfWork">検索結果</param>
        /// <param name="parasalesConfWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchSalesConfProc(out object objsalesConfWork, object parasalesConfWork, ref SqlConnection sqlConnection)
        {
            SalesConfShWork salesconfshWork = null;

            ArrayList salesconfshWorkList = parasalesConfWork as ArrayList;
            ArrayList salesconfWorkList = new ArrayList();

            if (salesconfshWorkList == null)
            {
                salesconfshWork = parasalesConfWork as SalesConfShWork;
            }
            else
            {
                if (salesconfshWorkList.Count > 0)
                    salesconfshWork = salesconfshWorkList[0] as SalesConfShWork;
            }

            int status = SearchSalesConfProc(out salesconfWorkList, salesconfshWork, ref sqlConnection);
            objsalesConfWork = salesconfWorkList;
            return status;

        }

        /// <summary>
        /// 指定された条件の売上確認表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesconfWorkList">検索結果</param>
        /// <param name="salesconfShWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        public int SearchSalesConfProc(out ArrayList salesconfWorkList, SalesConfShWork salesconfShWork, ref SqlConnection sqlConnection)
        {
            return SearchSalesConfProcProc(out salesconfWorkList, salesconfShWork, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の売上確認表情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesconfWorkList">検索結果</param>
        /// <param name="salesconfShWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        private int SearchSalesConfProcProc(out ArrayList salesconfWorkList, SalesConfShWork salesconfShWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string OrderbyStr = "";
            //bool isDetails; // 2008.07.01 del

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, salesconfShWork)
                                       + MakeWhereString(ref sqlCommand, salesconfShWork)
                                       + MakeGroupByString(ref sqlCommand, salesconfShWork)
                                       + OrderbyStr;
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();


                //isDetails = salesconfShWork.IsDetails; // 2008.07.01 del

                while (myReader.Read())
                {

                    //al.Add(CopyToSalesConfWorkFromReader(ref myReader, isDetails)); // 2008.07.01 del
                    al.Add(CopyToSalesConfWorkFromReader(ref myReader));              // 2008.07.01 add 

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
            }

            salesconfWorkList = al;

            return status;
        }
        #endregion

        #region [SQL生成処理]
        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesconfShWork">検索条件格納クラス</param>
        /// <returns>売上確認表のSQL文字列</returns>
        /// <br>Note       : 売上確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, SalesConfShWork salesconfShWork)
        {
            // 2008.07.01 upd start ---------------------------------------------->>
            //string sqlstring = "";
            //if (salesconfShWork.IsDetails == false)
            //{
            //    //製番単位SELECTの作成
            //    sqlstring = "SELECT "
            //         + "B.RESULTSADDUPSECCDRF SECTIONCODERF, "	//拠点コード
            //         + "D.SECTIONGUIDENMRF SECTIONGUIDENMRF, "	//拠点ガイド名称
            //         + "B.SALESDATERF SALESDATERF, "	//売上日付
            //         + "A.SHIPMENTDAYRF SHIPMENTDAYRF, "	//出荷日付
            //         + "A.CUSTOMERCODERF CUSTOMERCODERF, "	//得意先コード
            //         + "A.CUSTOMERNAMERF CUSTOMERNAMERF, "	//得意先名称
            //         + "A.CUSTOMERNAME2RF CUSTOMERNAME2RF, "	//得意先名称2
            //         + "B.SALESFORMCODERF SALESFORMCODERF, "	//販売形態コード
            //         + "B.SALESFORMNAMERF SALESFORMNAMERF, "	//販売形態名称
            //         + "B.GOODSCODERF GOODSCODERF, "	//商品コード
            //         + "B.GOODSNAMERF GOODSNAMERF, "	//商品名称
            //         + "A.SALESSLIPNUMRF SALESSLIPNUMRF, "	//受注番号→売上伝票番号に変更　2007/05/31
            //         + "B.SALESROWNORF SALESROWNORF, "	//売上行番号
            //         + "A.DEBITNOTEDIVRF DEBITNOTEDIVRF, "	//赤伝区分
            //         + "A.ACCRECDIVCDRF ACCRECDIVCDRF, "	//売掛区分
            //         + "B.CARRIERCODERF CARRIERCODERF, "	//キャリアコード
            //         + "B.CARRIERNAMERF CARRIERNAMERF, "	//キャリア名称
            //         + "B.LARGEGOODSGANRECODERF LARGEGOODSGANRECODERF, "	//商品大分類コード
            //         + "B.LARGEGOODSGANRENAMERF LARGEGOODSGANRENAMERF, "	//商品大分類名称
            //         + "B.MEDIUMGOODSGANRECODERF MEDIUMGOODSGANRECODERF, "	//商品中分類コード
            //         + "B.MEDIUMGOODSGANRENAMERF MEDIUMGOODSGANRENAMERF, "	//商品中分類名称
            //         + "B.CELLPHONEMODELCODERF CELLPHONEMODELCODERF, "	//機種コード
            //         + "B.CELLPHONEMODELNAMERF CELLPHONEMODELNAMERF, "	//機種名称
            //         + "A.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, "	//販売従業員コード
            //         + "A.SALESEMPLOYEENMRF SALESEMPLOYEENMRF, "	//販売従業員名称
            //         + "C.PRODUCTNUMBER1RF PRODUCTNUMBER1RF, "	//製造番号1
            //         + "C.PRODUCTNUMBER2RF PRODUCTNUMBER2RF, "	//製造番号2
            //         + "C.STOCKTELNO1RF STOCKTELNO1RF, "	//商品電話番号1
            //         + "C.STOCKTELNO2RF STOCKTELNO2RF, "	//商品電話番号2
            //         + "C.SALESSLIPEXPNUMRF SALESSLIPEXPNUMRF, "	//売上詳細番号
            //         //+ "B.SALESCOUNTRF SALESCOUNTRF, "	//売上数
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END) SALESCOUNTRF, "	//売上数
            //         + "B.SALESUNITPRICETAXEXCRF SALESUNITPRICETAXEXCRF, "	//売上単価（税抜き）
            //         + "B.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, "	//売上金額（税抜き）
            //         + "B.COSTRF COSTRF, "	//原価
            //         + "SUM(ISNULL(F.INCRECVTAXEXCRF,0)) INCENTIVERECVRF, "	//受取インセンティブ
            //         + "SUM(ISNULL(E.INCDTBTTAXEXCRF,0)) INCENTIVEDTBTRF, "	//支払インセンティブ
            //         + "A.SALESSLIPCDRF SALESSLIPCDRF "	//売上伝票区分
            //         + "FROM "
            //         + "(SALESSLIPRF A "	//売上
            //         + "INNER JOIN SALESDETAILRF B "	//売上明細
            //         + "ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.ACCEPTANORDERNORF = A.ACCEPTANORDERNORF) "
            //         + "INNER JOIN SECINFOSETRF D "	//拠点マスタ
            //         + "ON (D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.RESULTSADDUPSECCDRF)) "
            //         + "LEFT JOIN SALESEXPLADATARF C "	//売上詳細
            //         + "ON (C.ENTERPRISECODERF = B.ENTERPRISECODERF AND C.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND C.SALESROWNORF = B.SALESROWNORF) "
            //         + "LEFT JOIN INCDTBTRF E "	//支払インセンティブ
            //         + "ON (E.ENTERPRISECODERF = B.ENTERPRISECODERF AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND E.SALESROWNORF = B.SALESROWNORF) "
            //         + "LEFT JOIN INCRECVRF F "	//受取インセンティブ
            //         + "ON (F.ENTERPRISECODERF = B.ENTERPRISECODERF AND F.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND F.SALESROWNORF = B.SALESROWNORF) ";
            //     }
            //else {
            //    //明細単位SELECTの作成
            //    sqlstring = "SELECT "
            //         + "B.RESULTSADDUPSECCDRF SECTIONCODERF, "	//拠点コード
            //         + "D.SECTIONGUIDENMRF SECTIONGUIDENMRF, "	//拠点ガイド名称
            //         + "B.SALESDATERF SALESDATERF, "	//売上日付
            //         + "A.SHIPMENTDAYRF SHIPMENTDAYRF, "	//出荷日付
            //         + "A.CUSTOMERCODERF CUSTOMERCODERF, "	//得意先コード
            //         + "A.CUSTOMERNAMERF CUSTOMERNAMERF, "	//得意先名称
            //         + "A.CUSTOMERNAME2RF CUSTOMERNAME2RF, "	//得意先名称2
            //         + "B.SALESFORMCODERF SALESFORMCODERF, "	//販売形態コード
            //         + "B.SALESFORMNAMERF SALESFORMNAMERF, "	//販売形態名称
            //         + "B.GOODSCODERF GOODSCODERF, "	//商品コード
            //         + "B.GOODSNAMERF GOODSNAMERF, "	//商品名称
            //         + "A.SALESSLIPNUMRF SALESSLIPNUMRF, "	//受注番号→売上受注番号に変更 2007/05/31
            //         + "B.SALESROWNORF SALESROWNORF, "	//売上行番号
            //         + "A.DEBITNOTEDIVRF DEBITNOTEDIVRF, "	//赤伝区分
            //         + "A.ACCRECDIVCDRF ACCRECDIVCDRF, "	//売掛区分
            //         + "B.CARRIERCODERF CARRIERCODERF, "	//キャリアコード
            //         + "B.CARRIERNAMERF CARRIERNAMERF, "	//キャリア名称
            //         + "B.LARGEGOODSGANRECODERF LARGEGOODSGANRECODERF, "	//商品大分類コード
            //         + "B.LARGEGOODSGANRENAMERF LARGEGOODSGANRENAMERF, "	//商品大分類名称
            //         + "B.MEDIUMGOODSGANRECODERF MEDIUMGOODSGANRECODERF, "	//商品中分類コード
            //         + "B.MEDIUMGOODSGANRENAMERF MEDIUMGOODSGANRENAMERF, "	//商品中分類名称
            //         + "B.CELLPHONEMODELCODERF CELLPHONEMODELCODERF, "	//機種コード
            //         + "B.CELLPHONEMODELNAMERF CELLPHONEMODELNAMERF, "	//機種名称
            //         + "A.SALESEMPLOYEECDRF SALESEMPLOYEECDRF, "	//販売従業員コード
            //         + "A.SALESEMPLOYEENMRF SALESEMPLOYEENMRF, "	//販売従業員名称
            //        //+ "B.SALESCOUNTRF SALESCOUNTRF, "	//売上数
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END) SALESCOUNTRF, "	//売上数
            //         + "B.SALESUNITPRICETAXEXCRF SALESUNITPRICETAXEXCRF, "	//売上単価（税抜き）
            //         + "B.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, "	//売上金額（税抜き）
            //         + "B.COSTRF COSTRF, "	//原価
            //         + "SUM(ISNULL(F.INCRECVTAXEXCRF,0)) INCENTIVERECVRF, "	//受取インセンティブ
            //         + "SUM(ISNULL(E.INCDTBTTAXEXCRF,0)) INCENTIVEDTBTRF, "	//支払インセンティブ
            //         + "A.SALESSLIPCDRF SALESSLIPCDRF "	//売上伝票区分
            //         + "FROM "
            //         + "SALESSLIPRF A "	//売上
            //         + "INNER JOIN SALESDETAILRF B "	//売上明細
            //         + "ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.ACCEPTANORDERNORF = A.ACCEPTANORDERNORF) "
            //         + "INNER JOIN SECINFOSETRF D "	//拠点マスタ
            //         + "ON (D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.RESULTSADDUPSECCDRF) "
            //         +"LEFT JOIN INCDTBTRF E "	//支払インセンティブ
            //         + "ON (E.ENTERPRISECODERF = B.ENTERPRISECODERF AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND E.SALESROWNORF = B.SALESROWNORF) "
            //         +"LEFT JOIN INCRECVRF F "	//受取インセンティブ
            //         + "ON (F.ENTERPRISECODERF = B.ENTERPRISECODERF AND F.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF AND F.SALESROWNORF = B.SALESROWNORF) ";
            //}
            string sqlstring = string.Empty;
            // 2008.07.01 upd end ------------------------------------------------<<

            return sqlstring;
        }
        #endregion

        #region [WHERE句生成処理]
        /// <summary>
        /// WHERE句生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesconfShWork">検索条件格納クラス</param>
        /// <returns>売上確認表のSQL文字列</returns>
        /// <br>Note       : 売上確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesConfShWork salesconfShWork)
        {
            //string wherestring = " ";
            //基本WHERE句の作成
            string wherestring = "WHERE ";

            //固定条件
            //企業コード
            wherestring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesconfShWork.EnterpriseCode);

            //論理削除区分
            wherestring += "AND A.LOGICALDELETECODERF=0 ";
            wherestring += "AND B.LOGICALDELETECODERF=0 ";

            //実績計上拠点コード
            //if (salesconfShWork.IsSelectAllSection == false && salesconfShWork.IsOutputAllSecRec == false) // 2008.07.01 del
            if (salesconfShWork.IsSelectAllSection == false) // 2008.07.01 add
            {
                string sectionString = "";
                foreach (string sectionCode in salesconfShWork.ResultsAddUpSecList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    wherestring += "AND B.RESULTSADDUPSECCDRF IN (" + sectionString + ") ";
                }
            }


            //売上伝票種別(10:売上,20:売切,31:委託計上)
            wherestring += "AND A.SALESSLIPKINDRF IN (10,20,31) ";

            //受注ステータス(30：売上のみ)
            wherestring += "AND A.ACPTANODRSTATUSRF=30 ";

            //サービス伝票区分(0：OFFのみ)
            wherestring += "AND A.SERVICESLIPCDRF=0 ";

            //これよりパラメータの値により動的変化の項目
            //売上日付(開始)
            if (salesconfShWork.SalesDateSt != 0)
            {
                wherestring += "AND B.SALESDATERF>=@SALESDATEST ";
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesDateSt);
            }

            //売上日付(終了)
            if (salesconfShWork.SalesDateEd != 0)
            {
                wherestring += "AND B.SALESDATERF<=@SALESDATEED ";
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesDateEd);
            }


            //出荷日付(開始)
            if (salesconfShWork.ShipmentDaySt != 0)
            {
                wherestring += "AND A.SHIPMENTDAYRF>=@SHIPMENTDAYST ";
                SqlParameter paraShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                paraShipmentDaySt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.ShipmentDaySt);
            }

            //出荷日付(終了)
            if (salesconfShWork.ShipmentDayEd != 0)
            {
                wherestring += "AND A.SHIPMENTDAYRF<=@SHIPMENTDAYED ";
                SqlParameter paraShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                paraShipmentDayEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.ShipmentDayEd);
            }

            // ↓ 2007.10.18 980081 d
            ////キャリアコード
            //if (salesconfShWork.IsSelectAllCarrier == false)
            //{
            //    string carrierString = "";
            //    foreach (int carrierCode in salesconfShWork.CarrierCodeList)
            //    {
            //        if (carrierCode != 0)
            //        {
            //            if (carrierString != "") carrierString += ",";
            //            carrierString += carrierCode.ToString();
            //        }
            //    }
            //    if (carrierString != "")
            //    {
            //        wherestring += "AND B.CARRIERCODERF IN (" + carrierString + ") ";
            //    }
            //}
            // ↑ 2007.10.18 980081 d

            //得意先コード(開始)
            if (salesconfShWork.CustomerCodeSt != 0)
            {
                wherestring += "AND A.CUSTOMERCODERF>=@CUSTOMERCODEST ";
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.CustomerCodeSt);
            }

            //得意先コード(終了)
            if (salesconfShWork.CustomerCodeEd != 0)
            {
                wherestring += "AND A.CUSTOMERCODERF<=@CUSTOMERCODEED ";
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.CustomerCodeEd);
            }

            //赤伝区分
            if (salesconfShWork.DebitNoteDiv != -1)
            {
                wherestring += "AND A.DEBITNOTEDIVRF=@DEBITNOTEDIV ";
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.DebitNoteDiv);
            }

            //売上伝票区分
            if (salesconfShWork.SalesSlipCd != -1)
            {
                wherestring += "AND A.SALESSLIPCDRF=@SALESSLIPCD ";
                SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesSlipCd);
            }

            // ↓ 2007.10.18 980081 d
            #region 旧レイアウト(コメントアウト)
            ////売上形式
            //string salesFormalString = "";
            //foreach (int salesFormalCode in salesconfShWork.SalesFormal)
            //{
            //    if (salesFormalCode != 0)
            //    {
            //        if (salesFormalString != "") salesFormalString += ",";
            //        salesFormalString += salesFormalCode.ToString();
            //    }
            //}
            //if (salesFormalString != "")
            //{
            //    wherestring += "AND A.SALESFORMALRF IN (" + salesFormalString + ") ";
            //}
            //
            ////販売形態コード
            //string salesFormCodeString = "";
            //if (salesconfShWork.SalesFormCode != null)
            //{
            //    foreach (int salesFormCode in salesconfShWork.SalesFormCode)
            //    {
            //        if (salesFormCode != 0)
            //        {
            //            if (salesFormCodeString != "") salesFormCodeString += ",";
            //            salesFormCodeString += salesFormCode.ToString();
            //        }
            //    }
            //    if (salesFormCodeString != "")
            //    {
            //        wherestring += "AND B.SALESFORMCODERF IN (" + salesFormCodeString + ") ";
            //    }
            //
            //}
            // ↑ 2007.10.18 980081 d

            ////販売形態コード(開始)
            //if (salesconfShWork.SalesFormCodeSt != 0)
            //{
            //    wherestring += "AND B.SALESFORMCODERF>=@SALESFORMCODEST ";
            //    SqlParameter paraSalesFormCodeSt = sqlCommand.Parameters.Add("@SALESFORMCODEST", SqlDbType.Int);
            //    paraSalesFormCodeSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesFormCodeSt);
            //}

            ////販売形態コード(終了)
            //if (salesconfShWork.SalesFormCodeEd != 0)
            //{
            //    wherestring += "AND B.SALESFORMCODERF<=@SALESFORMCODEED ";
            //    SqlParameter paraSalesFormCodeEd = sqlCommand.Parameters.Add("@SALESFORMCODEED", SqlDbType.Int);
            //    paraSalesFormCodeEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesFormCodeEd);
            //}

            // ↓ 2007.10.18 980081 d
            ////商品大分類コード(開始)
            //if (salesconfShWork.LargeGoodsGanreCdSt != "")
            //{
            //    wherestring += "AND B.LARGEGOODSGANRECODERF>=@LARGEGOODSGANRECDST ";
            //    SqlParameter paraLargeGoodsGanreCdSt = sqlCommand.Parameters.Add("@LARGEGOODSGANRECDST", SqlDbType.NChar);
            //    paraLargeGoodsGanreCdSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.LargeGoodsGanreCdSt);
            //}
            //
            ////商品大分類コード(終了)
            //if (salesconfShWork.LargeGoodsGanreCdEd != "")
            //{
            //    wherestring += "AND B.LARGEGOODSGANRECODERF<=@LARGEGOODSGANRECDED ";
            //    SqlParameter paraLargeGoodsGanreCdEd = sqlCommand.Parameters.Add("@LARGEGOODSGANRECDED", SqlDbType.NChar);
            //    paraLargeGoodsGanreCdEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.LargeGoodsGanreCdEd);
            //}
            //
            ////商品中分類コード(開始)
            //if (salesconfShWork.MediumGoodsGanreCdSt != "")
            //{
            //    wherestring += "AND B.MEDIUMGOODSGANRECODERF>=@MEDIUMGOODSGANRECDST ";
            //    SqlParameter paraMediumGoodsGanreCdSt = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECDST", SqlDbType.NChar);
            //    paraMediumGoodsGanreCdSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.MediumGoodsGanreCdSt);
            //}
            //
            ////商品中分類コード(終了)
            //if (salesconfShWork.MediumGoodsGanreCdEd != "")
            //{
            //    wherestring += "AND B.MEDIUMGOODSGANRECODERF<=@MEDIUMGOODSGANRECDED ";
            //    SqlParameter paraMediumGoodsGanreCdEd = sqlCommand.Parameters.Add("@MEDIUMGOODSGANRECDED", SqlDbType.NChar);
            //    paraMediumGoodsGanreCdEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.MediumGoodsGanreCdEd);
            //}
            //
            ////商品コード(開始)
            //if (salesconfShWork.GoodsCodeSt != "")
            //{
            //    wherestring += "AND B.GOODSCODERF>=@GOODSCODEST ";
            //    SqlParameter paraGoodsCodeSt = sqlCommand.Parameters.Add("@GOODSCODEST", SqlDbType.NVarChar);
            //    paraGoodsCodeSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.GoodsCodeSt);
            //}
            //
            ////商品コード(終了)
            //if (salesconfShWork.GoodsCodeEd != "")
            //{
            //    wherestring += "AND B.GOODSCODERF<=@GOODSCODEED ";
            //    SqlParameter paraGoodsCodeEd = sqlCommand.Parameters.Add("@GOODSCODEED", SqlDbType.NVarChar);
            //    paraGoodsCodeEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.GoodsCodeEd);
            //}
            #endregion
            // ↑ 2007.10.18 980081 d

            //受注番号(開始)→売上伝票番号に変更
            if (salesconfShWork.SalesSlipNumSt != "")
            {
                wherestring += "AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST ";
                SqlParameter paraAcceptAnOrderNoSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraAcceptAnOrderNoSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesSlipNumSt);
            }

            //受注番号(終了)→売上伝票番号に変更
            if (salesconfShWork.SalesSlipNumEd != "")
            {
                wherestring += "AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED ";
                SqlParameter paraAcceptAnOrderNoEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraAcceptAnOrderNoEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesSlipNumEd);
            }

            // ↓ 2007.10.18 980081 d
            ////機種コード(開始)
            //if (salesconfShWork.CellphoneModelCodeSt != "")
            //{
            //    wherestring += "AND B.CELLPHONEMODELCODERF>=@CELLPHONEMODELCODEST ";
            //    SqlParameter paraCellphoneModelCodeSt = sqlCommand.Parameters.Add("@CELLPHONEMODELCODEST", SqlDbType.NVarChar);
            //    paraCellphoneModelCodeSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.CellphoneModelCodeSt);
            //}
            //
            ////機種コード(終了)
            //if (salesconfShWork.CellphoneModelCodeEd != "")
            //{
            //    wherestring += "AND B.CELLPHONEMODELCODERF<=@CELLPHONEMODELCODEED ";
            //    SqlParameter paraCellphoneModelCodeEd = sqlCommand.Parameters.Add("@CELLPHONEMODELCODEED", SqlDbType.NVarChar);
            //    paraCellphoneModelCodeEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.CellphoneModelCodeEd);
            //}
            // ↑ 2007.10.18 980081 d

            //販売従業員コード(開始)
            if (salesconfShWork.SalesEmployeeCdSt != "")
            {
                wherestring += "AND A.SALESEMPLOYEECDRF>=@SALESEMPLOYEECDST ";
                SqlParameter paraSalesEmployeeCdSt = sqlCommand.Parameters.Add("@SALESEMPLOYEECDST", SqlDbType.NVarChar);
                paraSalesEmployeeCdSt.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesEmployeeCdSt);
            }

            //販売従業員コード(終了)
            if (salesconfShWork.SalesEmployeeCdEd != "")
            {
                wherestring += "AND A.SALESEMPLOYEECDRF<=@SALESEMPLOYEECDED ";
                SqlParameter paraSalesEmployeeCdEd = sqlCommand.Parameters.Add("@SALESEMPLOYEECDED", SqlDbType.NVarChar);
                paraSalesEmployeeCdEd.Value = SqlDataMediator.SqlSetString(salesconfShWork.SalesEmployeeCdEd);
            }

            //仕入先コード(開始)
            if (salesconfShWork.SupplierCdSt != 0)
            {
                wherestring += "AND B.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SupplierCdSt);
            }

            //仕入先コード(終了)
            if (salesconfShWork.SupplierCdEd != 0)
            {
                wherestring += "AND B.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SupplierCdEd);
            }
            //売上在庫取寄せ区分
            if (salesconfShWork.SalesOrderDivCd != -1)
            {
                wherestring += "AND B.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.SalesOrderDivCd);
            }
            //注文方法区分
            if (salesconfShWork.WayToOrder != -1)
            {
                wherestring += "AND B.WAYTOORDERRF=@WAYTOORDER ";
                SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesconfShWork.WayToOrder);
            }
            //売上伝票区分 2:返品・値引
            if (salesconfShWork.SalesSlipCd == 2)
            {
                wherestring += "AND (A.SALESSLIPCDRF=1 OR (A.SALESSLIPCDRF=0 AND B.SALESSLIPCDDTLRF = 2 ))";
            }


            return wherestring;
        }
        #endregion


        #region [GROUP BY句生成処理]
        /// <summary>
        /// GROUP BY句生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesconfShWork">検索条件格納クラス</param>
        /// <returns>売上確認表のSQL文字列</returns>
        /// <br>Note       : 売上確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        private string MakeGroupByString(ref SqlCommand sqlCommand, SalesConfShWork salesconfShWork)
        {
            // 2008.07.01 upd start ----------------------------------------->>
            //string sqlstring = "";
            //if (salesconfShWork.IsDetails == false)
            //{
            //    //製番単位GROUP BY句の作成
            //    sqlstring = " GROUP BY "
            //         + "B.RESULTSADDUPSECCDRF, "	//拠点コード
            //         + "D.SECTIONGUIDENMRF, "	//拠点ガイド名称
            //         + "B.SALESDATERF, "	//売上日付
            //         + "A.SHIPMENTDAYRF, "	//出荷日付
            //         + "A.CUSTOMERCODERF, "	//得意先コード
            //         + "A.CUSTOMERNAMERF, "	//得意先名称
            //         + "A.CUSTOMERNAME2RF, "	//得意先名称2
            //         + "B.SALESFORMCODERF, "	//販売形態コード
            //         + "B.SALESFORMNAMERF, "	//販売形態名称
            //         + "B.GOODSCODERF, "	//商品コード
            //         + "B.GOODSNAMERF, "	//商品名称
            //         + "A.SALESSLIPNUMRF, "	//受注番号 →　売上伝票番号に変更
            //         + "B.SALESROWNORF, "	//売上行番号
            //         + "A.DEBITNOTEDIVRF, "	//赤伝区分
            //         + "A.ACCRECDIVCDRF, "	//売掛区分
            //         + "B.CARRIERCODERF, "	//キャリアコード
            //         + "B.CARRIERNAMERF, "	//キャリア名称
            //         + "B.LARGEGOODSGANRECODERF, "	//商品大分類コード
            //         + "B.LARGEGOODSGANRENAMERF, "	//商品大分類名称
            //         + "B.MEDIUMGOODSGANRECODERF, "	//商品中分類コード
            //         + "B.MEDIUMGOODSGANRENAMERF, "	//商品中分類名称
            //         + "B.CELLPHONEMODELCODERF, "	//機種コード
            //         + "B.CELLPHONEMODELNAMERF, "	//機種名称
            //         + "A.SALESEMPLOYEECDRF, "	//販売従業員コード
            //         + "A.SALESEMPLOYEENMRF, "	//販売従業員名称
            //         + "C.PRODUCTNUMBER1RF, "	//製造番号1
            //         + "C.PRODUCTNUMBER2RF, "	//製造番号2
            //         + "C.STOCKTELNO1RF, "	//商品電話番号1
            //         + "C.STOCKTELNO2RF, "	//商品電話番号2
            //         + "C.SALESSLIPEXPNUMRF, "	//売上詳細番号
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END), "	//売上数
            //         + "B.SALESUNITPRICETAXEXCRF, "	//売上単価（税抜き）
            //         + "B.SALESMONEYTAXEXCRF, "	//売上金額（税抜き）
            //         + "B.COSTRF, "	//原価
            //         + "A.SALESSLIPCDRF ";	//売上伝票区分
            //}
            //else
            //{
            //    //明細単位GROUP BY句の作成
            //    sqlstring = " GROUP BY "
            //         + "B.RESULTSADDUPSECCDRF, "	//拠点コード
            //         + "D.SECTIONGUIDENMRF, "	//拠点ガイド名称
            //         + "B.SALESDATERF, "	//売上日付
            //         + "A.SHIPMENTDAYRF, "	//出荷日付
            //         + "A.CUSTOMERCODERF, "	//得意先コード
            //         + "A.CUSTOMERNAMERF, "	//得意先名称
            //         + "A.CUSTOMERNAME2RF, "	//得意先名称2
            //         + "B.SALESFORMCODERF, "	//販売形態コード
            //         + "B.SALESFORMNAMERF, "	//販売形態名称
            //         + "B.GOODSCODERF, "	//商品コード
            //         + "B.GOODSNAMERF, "	//商品名称
            //         + "A.SALESSLIPNUMRF, "	//受注番号 →　売上伝票番号に変更
            //         + "B.SALESROWNORF, "	//売上行番号
            //         + "A.DEBITNOTEDIVRF, "	//赤伝区分
            //         + "A.ACCRECDIVCDRF, "	//売掛区分
            //         + "B.CARRIERCODERF, "	//キャリアコード
            //         + "B.CARRIERNAMERF, "	//キャリア名称
            //         + "B.LARGEGOODSGANRECODERF, "	//商品大分類コード
            //         + "B.LARGEGOODSGANRENAMERF, "	//商品大分類名称
            //         + "B.MEDIUMGOODSGANRECODERF, "	//商品中分類コード
            //         + "B.MEDIUMGOODSGANRENAMERF, "	//商品中分類名称
            //         + "B.CELLPHONEMODELCODERF, "	//機種コード
            //         + "B.CELLPHONEMODELNAMERF, "	//機種名称
            //         + "A.SALESEMPLOYEECDRF, "	//販売従業員コード
            //         + "A.SALESEMPLOYEENMRF, "	//販売従業員名称
            //         + "(CASE WHEN B.GOODSKINDCODERF IN (38,39) THEN 0 ELSE B.SALESCOUNTRF END), "	//売上数
            //         + "B.SALESUNITPRICETAXEXCRF, "	//売上単価（税抜き）
            //         + "B.SALESMONEYTAXEXCRF, "	//売上金額（税抜き）
            //         + "B.COSTRF, "	//原価
            //         + "A.SALESSLIPCDRF ";	//売上伝票区分
            //}
            string sqlstring = string.Empty;
            // 2008.07.01 upd end -------------------------------------------<<

            return sqlstring;
        }
        #endregion


        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SalesConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        //private SalesConfWork CopyToSalesConfWorkFromReader(ref SqlDataReader myReader, bool isDetails) // 2008.07.01 del
        private SalesConfWork CopyToSalesConfWorkFromReader(ref SqlDataReader myReader)                   // 2008.07.01 add
        {
            SalesConfWork wkSalesConfWork = new SalesConfWork();

            #region クラスへ格納
            wkSalesConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));  //2008.10.08 DEL
            wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));   //2008.10.08 ADD
            wkSalesConfWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkSalesConfWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            wkSalesConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // ↓ 2007.10.18 980081 d
            //wkSalesConfWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            //wkSalesConfWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            //wkSalesConfWork.SalesFormCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESFORMCODERF"));
            //wkSalesConfWork.SalesFormName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESFORMNAMERF"));
            //wkSalesConfWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
            // ↑ 2007.10.18 980081 d
            wkSalesConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkSalesConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            //wkSalesConfWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF")); // 2008.07.01 del
            //wkSalesConfWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF")); // 2008.07.01 del
            wkSalesConfWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            // ↓ 2007.10.18 980081 d
            //wkSalesConfWork.CarrierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARRIERCODERF"));
            //wkSalesConfWork.CarrierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARRIERNAMERF"));
            //wkSalesConfWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
            //wkSalesConfWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
            //wkSalesConfWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
            //wkSalesConfWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
            //wkSalesConfWork.CellphoneModelCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELCODERF"));
            //wkSalesConfWork.CellphoneModelName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CELLPHONEMODELNAMERF"));
            // ↑ 2007.10.18 980081 d
            wkSalesConfWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            wkSalesConfWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));

            // ↓ 2007.10.18 980081 d
            //if (isDetails == false)
            //{
            //    wkSalesConfWork.ProductNumber1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTNUMBER1RF"));
            //    wkSalesConfWork.ProductNumber2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTNUMBER2RF"));
            //    wkSalesConfWork.StockTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKTELNO1RF"));
            //    wkSalesConfWork.StockTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKTELNO2RF"));
            //    wkSalesConfWork.SalesSlipExpNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPEXPNUMRF"));
            //}
            // ↑ 2007.10.18 980081 d

            // ↓ 2007.10.18 980081 d
            //wkSalesConfWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
            //wkSalesConfWork.SalesUnitPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESUNITPRICETAXEXCRF"));
            // ↑ 2007.10.18 980081 d
            wkSalesConfWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
            wkSalesConfWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
            wkSalesConfWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            // ↓ 2007.10.18 980081 d
            //wkSalesConfWork.IncentiveRecv = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCENTIVERECVRF"));
            //wkSalesConfWork.IncentiveDtbt = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INCENTIVEDTBTRF"));
            // ↑ 2007.10.18 980081 d
            #endregion

            return wkSalesConfWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.03.19</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
        
        // ↓ 2007.10.18 980081 a
        #region 売上確認表(合計)・売上確認表(明細)対応
        /// <summary>
        /// 指定された条件の売上確認表(合計)LISTを戻します
        /// </summary>
        /// <param name="salesConfWork">検索結果</param>
        /// <param name="paraSalesConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表(合計)LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchSlip(out object salesConfWork, object paraSalesConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesConfWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesSlipConfProc(out salesConfWork, paraSalesConfWork, ref sqlConnection, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesConfDB.SearchSlip");
                salesConfWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の売上確認表(明細)LISTを戻します
        /// </summary>
        /// <param name="salesConfWork">検索結果</param>
        /// <param name="paraSalesConfWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表(明細)LISTを戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchDetail(out object salesConfWork, object paraSalesConfWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesConfWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSalesSlipConfProc(out salesConfWork, paraSalesConfWork, ref sqlConnection, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesConfDB.SearchDetail");
                salesConfWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の売上確認表LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objSalesConfWork">検索結果</param>
        /// <param name="paraSalesConfWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="printMode">0:合計タイプ 1:明細・詳細タイプ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchSalesSlipConfProc(out object objSalesConfWork, object paraSalesConfWork, ref SqlConnection sqlConnection, int printMode)
        {
            SalesConfShWork salesConfShWork = null;

            ArrayList salesConfShWorkList = paraSalesConfWork as ArrayList;
            ArrayList salesConfWorkList = new ArrayList();

            if (salesConfShWorkList == null)
            {
                salesConfShWork = paraSalesConfWork as SalesConfShWork;
            }
            else
            {
                if (salesConfShWorkList.Count > 0)
                    salesConfShWork = salesConfShWorkList[0] as SalesConfShWork;
            }

            int status = SearchSalesSlipConfProc(out salesConfWorkList, salesConfShWork, ref sqlConnection, printMode);
            objSalesConfWork = salesConfWorkList;
            return status;

        }

        /// <summary>
        /// 指定された条件の売上確認表(合計)LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="salesConfWorkList">検索結果</param>
        /// <param name="salesConfShWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="printMode">0:合計タイプ 1:明細・詳細タイプ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の売上確認表(合計)LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        public int SearchSalesSlipConfProc(out ArrayList salesConfWorkList, SalesConfShWork salesConfShWork, ref SqlConnection sqlConnection, int printMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectStringSlip(ref sqlCommand, salesConfShWork, printMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToSalesSlipConfWorkFromReader(ref myReader, salesConfShWork, printMode));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
            }

            salesConfWorkList = al;

            return status;
        }

        /// <summary>
        /// SQL生成
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesConfShWork">検索条件格納クラス</param>
        /// <param name="printMode">0:合計タイプ 1:明細・詳細タイプ</param>
        /// <returns>売上確認表のSQL文字列</returns>
        /// <br>Note       : 売上確認表のSQLを作成して戻します</br>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Note       : 「売上伝票入力」の登録でタイムアウトが出続けました for redmine #42684 </br>
        /// <br>Programmer : zhangwei</br>
        /// <br>Date       : 2014/05/29</br>
        /// <br>Note       : 軽減税率対応 </br>
        /// <br>Programmer : 3H 尹安</br>
        /// <br>Date       : 2020/02/27</br>
        private string MakeSelectStringSlip(ref SqlCommand sqlCommand, SalesConfShWork salesConfShWork, int printMode)
        {
            #region Select文
            string sqlString = "";

            // 2008.07.01 upd start ------------------------------------------------->>
            #region 2008.07.01 DEL
            //if (printMode == 0)
            //{
            //    sqlString = "SELECT A.SECTIONCODERF, "
            //                     + "C.SECTIONGUIDENMRF, "
            //                     + "A.SUBSECTIONCODERF, "
            //                     + "D.SUBSECTIONNAMERF, "
            //                     + "A.MINSECTIONCODERF, "
            //                     + "E.MINSECTIONNAMERF, "
            //                     + "A.CUSTOMERCODERF, "
            //                     // ↓ 2008.03.25 980081 c
            //                     //+ "A.CUSTOMERSNMRF, "
            //                     + "CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF, "
            //                     // ↑ 2008.03.25 980081 c
            //                     + "A.SALESAREACODERF, "
            //                     + "A.SALESAREANAMERF, "
            //                     + "A.CLAIMCODERF, "
            //                     + "A.CLAIMSNMRF, "
            //                     + "A.ADDRESSEECODERF, "
            //                     + "A.ADDRESSEENAMERF, "
            //                     + "A.ADDRESSEENAME2RF, "
            //                     //+ "A.ADDRESSEEPOSTNORF, "
            //                     + "A.ADDRESSEEADDR1RF, "
            //                     + "A.ADDRESSEEADDR2RF, "
            //                     + "A.ADDRESSEEADDR3RF, "
            //                     + "A.ADDRESSEEADDR4RF, "
            //                     + "A.SALESINPUTCODERF, "
            //                     + "A.SALESINPUTNAMERF, "
            //                     + "A.FRONTEMPLOYEECDRF, "
            //                     + "A.FRONTEMPLOYEENMRF, "
            //                     + "A.SALESEMPLOYEECDRF, "
            //                     + "A.SALESEMPLOYEENMRF, "
            //                     + "A.ACPTANODRSTATUSRF, "
            //                     + "A.SALESSLIPNUMRF, "
            //                     + "A.DEBITNOTEDIVRF, "
            //                     + "A.SALESSLIPCDRF, "
            //                     + "A.SALESGOODSCDRF, "
            //                     + "A.ACCRECDIVCDRF, "
            //                     + "A.SEARCHSLIPDATERF, "
            //                     + "A.SHIPMENTDAYRF, "
            //                     + "A.SALESDATERF, "
            //                     + "A.ADDUPADATERF, "
            //                     + "A.DELAYPAYMENTDIVRF, "
            //                     + "A.PARTYSALESLIPNUMRF, "
            //                     + "A.SALESTOTALTAXEXCRF, "
            //                     + "A.SALESTOTALTAXINCRF, "
            //                     + "A.SALESDISTTLTAXEXCRF, "
            //                     + "A.SALESDISTTLTAXINCLURF, "
            //                     + "A.TOTALCOSTRF, "
            //                     // ↓ 2008.03.21 980081 a
            //                     + "A.SALESSUBTOTALTAXINCRF, "
            //                     + "A.SALESSUBTOTALTAXEXCRF, "
            //                     + "A.SALSENETPRICERF, "
            //                     + "A.SALESSUBTOTALTAXRF, "
            //                     + "A.ITDEDSALESOUTTAXRF, "
            //                     + "A.ITDEDSALESINTAXRF, "
            //                     + "A.SALSUBTTLSUBTOTAXFRERF, "
            //                     + "A.SALSEOUTTAXRF, "
            //                     + "A.SALAMNTCONSTAXINCLURF, "
            //                     + "A.ITDEDSALESDISOUTTAXRF, "
            //                     + "A.ITDEDSALESDISINTAXRF, "
            //                     + "A.ITDEDSALSEDISTAXFRERF, "
            //                     + "A.SALESDISOUTTAXRF, "
            //                     + "A.TOTALCOSTRF, "
            //                     // ↑ 2008.03.21 980081 a
            //                     + "A.SLIPNOTERF "
            //                     + "FROM SALESHISTORYRF A "
            //                     + "LEFT JOIN SECINFOSETRF C ON(C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.SECTIONCODERF = A.SECTIONCODERF) "
            //                     + "LEFT JOIN SUBSECTIONRF D ON(D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.SECTIONCODERF AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF) "
            //                     + "LEFT JOIN MINSECTIONRF E ON(E.ENTERPRISECODERF = A.ENTERPRISECODERF AND E.SECTIONCODERF = A.SECTIONCODERF AND E.SUBSECTIONCODERF = A.SUBSECTIONCODERF AND E.MINSECTIONCODERF = A.MINSECTIONCODERF) ";
            //}
            //else if (printMode == 1)
            //{
            //    sqlString = "SELECT A.SECTIONCODERF, "
            //                     + "C.SECTIONGUIDENMRF, "
            //                     + "A.SUBSECTIONCODERF, "
            //                     + "D.SUBSECTIONNAMERF, "
            //                     + "A.MINSECTIONCODERF, "
            //                     + "E.MINSECTIONNAMERF, "
            //                     + "A.CUSTOMERCODERF, "
            //                     // ↓ 2008.03.25 980081 c
            //                     //+ "A.CUSTOMERSNMRF, "
            //                     + "CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF, "
            //                     // ↑ 2008.03.25 980081 c
            //                     + "A.SALESAREACODERF, "
            //                     + "A.SALESAREANAMERF, "
            //                     + "A.CLAIMCODERF, "
            //                     + "A.CLAIMSNMRF, "
            //                     + "A.ADDRESSEECODERF, "
            //                     + "A.ADDRESSEENAMERF, "
            //                     + "A.ADDRESSEENAME2RF, "
            //                     //+ "A.ADDRESSEEPOSTNORF, "
            //                     + "A.ADDRESSEEADDR1RF, "
            //                     + "A.ADDRESSEEADDR2RF, "
            //                     + "A.ADDRESSEEADDR3RF, "
            //                     + "A.ADDRESSEEADDR4RF, "
            //                     + "A.SALESINPUTCODERF, "
            //                     + "A.SALESINPUTNAMERF, "
            //                     + "A.FRONTEMPLOYEECDRF, "
            //                     + "A.FRONTEMPLOYEENMRF, "
            //                     + "A.SALESEMPLOYEECDRF, "
            //                     + "A.SALESEMPLOYEENMRF, "
            //                     + "A.ACPTANODRSTATUSRF, "
            //                     + "A.SALESSLIPNUMRF, "
            //                     + "A.DEBITNOTEDIVRF, "
            //                     + "A.SALESSLIPCDRF, "
            //                     + "A.SALESGOODSCDRF, "
            //                     + "A.ACCRECDIVCDRF, "
            //                     + "A.SEARCHSLIPDATERF, "
            //                     + "A.SHIPMENTDAYRF, "
            //                     + "A.SALESDATERF, "
            //                     + "A.ADDUPADATERF, "
            //                     + "A.DELAYPAYMENTDIVRF, "
            //                     + "A.PARTYSALESLIPNUMRF, "
            //                     + "A.SALESTOTALTAXEXCRF, "
            //                     + "A.SALESTOTALTAXINCRF, "
            //                     + "A.SALESDISTTLTAXEXCRF, "
            //                     + "A.SALESDISTTLTAXINCLURF, "
            //                     + "A.TOTALCOSTRF, "
            //                     + "A.SLIPNOTERF, "
            //                     // ↓ 2008.03.21 980081 a
            //                     + "A.SALESSUBTOTALTAXINCRF, "
            //                     + "A.SALESSUBTOTALTAXEXCRF, "
            //                     + "A.SALSENETPRICERF, "
            //                     + "A.SALESSUBTOTALTAXRF, "
            //                     + "A.ITDEDSALESOUTTAXRF, "
            //                     + "A.ITDEDSALESINTAXRF, "
            //                     + "A.SALSUBTTLSUBTOTAXFRERF, "
            //                     + "A.SALSEOUTTAXRF, "
            //                     + "A.SALAMNTCONSTAXINCLURF, "
            //                     + "A.ITDEDSALESDISOUTTAXRF, "
            //                     + "A.ITDEDSALESDISINTAXRF, "
            //                     + "A.ITDEDSALSEDISTAXFRERF, "
            //                     + "A.SALESDISOUTTAXRF, "
            //                     + "A.TOTALCOSTRF, "
            //                     + "B.SALSEPRICECONSTAXRF, "
            //                     // ↑ 2008.03.21 980081 a
            //                     + "B.SALESROWNORF, "
            //                     + "B.SALESSLIPCDDTLRF, "
            //                     + "B.GOODSMAKERCDRF, "
            //                     + "B.MAKERNAMERF, "
            //                     + "B.GOODSNORF, "
            //                     + "B.GOODSNAMERF, "
            //                     + "B.UNITCODERF, "
            //                     + "B.UNITNAMERF, "
            //                     + "B.SHIPMENTCNTRF, "
            //                     + "B.STDUNPRCSALUNPRCRF, "
            //                     + "B.SALESUNPRCTAXINCFLRF, "
            //                     + "B.SALESUNPRCTAXEXCFLRF, "
            //                     + "B.SALESMONEYTAXINCRF, "
            //                     + "B.SALESMONEYTAXEXCRF, "
            //                     + "B.SALESUNITCOSTRF, "
            //                     + "B.COSTRF, "
            //                     + "B.WAREHOUSECODERF, "
            //                     + "B.WAREHOUSENAMERF, "
            //                     + "B.SUPPLIERCDRF, "
            //                     + "B.SUPPLIERSNMRF, "
            //                     + "B.PARTYSLIPNUMDTLRF, "
            //                     + "B.DTLNOTERF "
            //                     + "FROM SALESHISTORYRF A "
            //                     + "INNER JOIN SALESHISTDTLRF B ON (B.ENTERPRISECODERF = A.ENTERPRISECODERF AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF) "
            //                     + "LEFT JOIN SECINFOSETRF C ON(C.ENTERPRISECODERF = A.ENTERPRISECODERF AND C.SECTIONCODERF = A.SECTIONCODERF) "
            //                     + "LEFT JOIN SUBSECTIONRF D ON(D.ENTERPRISECODERF = A.ENTERPRISECODERF AND D.SECTIONCODERF = A.SECTIONCODERF AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF) "
            //                     + "LEFT JOIN MINSECTIONRF E ON(E.ENTERPRISECODERF = A.ENTERPRISECODERF AND E.SECTIONCODERF = A.SECTIONCODERF AND E.SUBSECTIONCODERF = A.SUBSECTIONCODERF AND E.MINSECTIONCODERF = A.MINSECTIONCODERF) ";
            //}
            #endregion

            if (printMode == 0)
            {
                //sqlString += "SELECT " + Environment.NewLine;        //2008.09.17 DEL
                sqlString += "SELECT DISTINCT" + Environment.NewLine;  //2008.09.17 ADD
                // 修正 2009/05/18 >>>
                //sqlString += "     A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "     A.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine; 
                // 修正 2009/05/18 <<<
                //sqlString += "    ,C.SECTIONGUIDENMRF" + Environment.NewLine;  // 2008.10.08 DEL
                sqlString += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;   // 2008.10.08 ADD

                sqlString += "    ,A.LOGICALDELETECODERF" + Environment.NewLine; // --- ADD  陳建明  2010/11/29

                sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONDIVRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONRF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += "    ,A.CONSTAXRATERF" + Environment.NewLine; // 消費税税率   // ADD 3H 尹安 2020/02/27
                // 修正 2009/04/21 >>>
                //sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,E.SALESDISTTLTAXEXCGOODS AS SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXEXCRF - E.SALESDISTTLTAXEXCGYO AS SALESDISTTLTAXEXCRF" + Environment.NewLine;
                // 修正 2009/04/21 <<<
                sqlString += "    ,A.CUSTSLIPNORF" + Environment.NewLine;
                sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                // ADD 2008.10.28 >>>
                sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;

                
                // 修正 2009/05/18 >>>
                //// --- ADD 2009/04/09 ------->>>
                sqlString += "    ,DTL.COSTRF AS TOTALCOSTRF" + Environment.NewLine;
                //sqlString += "    ,DTL.SALESMONEYTAXEXCRF AS SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,DTL.SALESMONEYTAXINCRF AS SALESTOTALTAXINCRF" + Environment.NewLine;
                //// --- ADD 2009/04/09 -------<<<
                //sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                // 修正 2009/05/18 <<<

                // 伝票タイプの場合
                // 消費税金額は、伝票の値
                // その他金額は、明細の値を出力 ←←PM7仕様
                sqlString += "    ,DTL.SALESMONEYTAXEXCRF AS SALESTOTALTAXEXCRF" + Environment.NewLine;
                // 修正 2009/07/23 >>>
                //sqlString += "    ,DTL.SALESMONEYTAXEXCRF + A.SALESTOTALTAXINCRF -A.SALESTOTALTAXEXCRF AS SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += ",CASE WHEN A.CONSTAXLAYMETHODRF =0 THEN DTL.SALESMONEYTAXEXCRF + A.SALESTOTALTAXINCRF -A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += " ELSE DTL.SALESMONEYTAXINCRF END AS SALESTOTALTAXINCRF" + Environment.NewLine;
                // 修正 2009/07/23 <<<
                // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                sqlString += "    ,F.SALESMONEYTAXFREECRF AS SALESMONEYTAXFREECRF" + Environment.NewLine;
                sqlString += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                sqlString += "       SELECT   " + Environment.NewLine;
                sqlString += "          1   " + Environment.NewLine;
                sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                sqlString += "       AND A.CONSTAXLAYMETHODRF != 9 " + Environment.NewLine;
                sqlString += "       AND SALESDTL.SALESSLIPCDDTLRF != 3 " + Environment.NewLine;
                
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "    AND (A.CONSTAXLAYMETHODRF = 0 OR ( A.CONSTAXLAYMETHODRF <> 0 AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD))";
                }
                sqlString += "       AND SALESDTL.TAXATIONDIVCDRF != 1)  " + Environment.NewLine;
                sqlString += "  THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
                sqlString += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                sqlString += "       SELECT   " + Environment.NewLine;
                sqlString += "          1   " + Environment.NewLine;
                sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "    AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                }
                sqlString += "       AND (A.CONSTAXLAYMETHODRF = 9 OR SALESDTL.TAXATIONDIVCDRF = 1))  " + Environment.NewLine;
                sqlString += "  THEN 1 ELSE 0 END TAXFREEEXISTFLAG  " + Environment.NewLine;
                // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                // ADD 2008.10.28 <<<
                // ADD 2009.01.14 >>>
                //sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                //sqlString += "    ,SUM(CASE WHEN B.SALESSLIPCDDTLRF = 2 THEN B.COSTRF ELSE 0 END) AS DISCOSTRF" + Environment.NewLine;
                // 修正 2009/04/21 >>>
                //sqlString += "    ,E.DISOUTTAXGOODS AS SALESDISOUTTAXRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISOUTTAXRF - E.DISOUTTAXGYO AS SALESDISOUTTAXRF" + Environment.NewLine;
                // 修正 2009/04/21 <<<
                sqlString += "    ,E.DISCOSTGOODS AS DISCOSTRF" + Environment.NewLine;
                // ADD 2009.01.14 <<<
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ---------->>>>> 
                //sqlString += " FROM SALESHISTORYRF A" + Environment.NewLine;
                //sqlString += " INNER JOIN SALESHISTDTLRF B ON" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>> 
                sqlString += " FROM SALESHISTORYRF A WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += " INNER JOIN SALESHISTDTLRF B WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                sqlString += " (B.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                //sqlString += " )LEFT JOIN SECINFOSETRF C ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " )LEFT JOIN SECINFOSETRF C WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (C.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/05/18 >>>
                //sqlString += "    AND C.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "    AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                // 修正 2009/05/18 <<<
                sqlString += " ) LEFT" + Environment.NewLine;
                //sqlString += " JOIN SUBSECTIONRF D ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " JOIN SUBSECTIONRF D WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (D.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND D.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;  // DEL 2010/05/10
                sqlString += "    AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                // ADD 
                sqlString += " LEFT JOIN" + Environment.NewLine;
                sqlString += " (" + Environment.NewLine;
                sqlString += "   SELECT" + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF," + Environment.NewLine;
                sqlString += "    --売上/返品へ加算" + Environment.NewLine;
                sqlString += "    SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 THEN SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) SALESDISTTLTAXEXCGOODS," + Environment.NewLine;
                sqlString += "    SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 THEN SALESDTL.SALESMONEYTAXINCRF ELSE 0 END) SALESDISTTLTAXINCGOODS," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 THEN SALESDTL.COSTRF ELSE 0 END) DISCOSTGOODS," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF != 0 AND SALESDTL.TAXATIONDIVCDRF = 0 " + Environment.NewLine;
                sqlString += "	     THEN SALESDTL.SALESMONEYTAXINCRF - SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) DISOUTTAXGOODS," + Environment.NewLine;
                sqlString += "	  -- 行値引" + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF = 0 THEN SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) SALESDISTTLTAXEXCGYO," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF = 0 THEN SALESDTL.COSTRF ELSE 0 END) DISCOSTGYO," + Environment.NewLine;
                sqlString += "	  SUM(CASE WHEN SALESDTL.SHIPMENTCNTRF = 0 AND SALESDTL.TAXATIONDIVCDRF = 0 " + Environment.NewLine;
                sqlString += "	     THEN SALESDTL.SALESMONEYTAXINCRF - SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) DISOUTTAXGYO" + Environment.NewLine;
                sqlString += "   FROM " + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ---------->>>>> 
                //sqlString += "     SALESHISTDTLRF AS SALESDTL" + Environment.NewLine;
                //sqlString += "   LEFT JOIN SALESHISTORYRF AS SALES" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>>
                sqlString += "     SALESHISTDTLRF AS SALESDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += "   LEFT JOIN SALESHISTORYRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                sqlString += "   ON " + Environment.NewLine;
                sqlString += "     (SALES.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "     AND SALES.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "     AND SALES.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF)" + Environment.NewLine;
                sqlString += "   WHERE" + Environment.NewLine;
                // -- UPD 2010/05/10 ----------------------------------------->>>
                //sqlString += "    SALESSLIPCDDTLRF = 2 -- 値引  " + Environment.NewLine;
                sqlString += "        SALES.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                sqlString += "    AND SALESDTL.SALESSLIPCDDTLRF = 2 -- 値引  " + Environment.NewLine;
                // -- UPD 2010/05/10 -----------------------------------------<<<
                sqlString += "   GROUP BY " + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += " ) AS E ON " + Environment.NewLine;
                sqlString += " (      " + Environment.NewLine;
                sqlString += "    E.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND E.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND E.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    AND E.SALESSLIPCDRF = A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "  )" + Environment.NewLine;
                // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
                sqlString += " LEFT JOIN" + Environment.NewLine;
                sqlString += " (" + Environment.NewLine;
                sqlString += "   SELECT" + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF," + Environment.NewLine;
                sqlString += "    SUM(SALESDTL.SALESMONEYTAXEXCRF) SALESMONEYTAXFREECRF" + Environment.NewLine;
                sqlString += "   FROM " + Environment.NewLine;
                sqlString += "     SALESHISTDTLRF AS SALESDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += "   LEFT JOIN SALESHISTORYRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += "   ON " + Environment.NewLine;
                sqlString += "     (SALES.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "     AND SALES.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "     AND SALES.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF)" + Environment.NewLine;
                sqlString += "   WHERE" + Environment.NewLine;
                sqlString += "        SALES.ENTERPRISECODERF = @ENTERPRISECODE  " + Environment.NewLine;
                sqlString += "    AND (SALESDTL.SALESSLIPCDDTLRF != 2  OR (SALESDTL.SALESSLIPCDDTLRF=2 AND SALESDTL.SHIPMENTCNTRF=0 ))" + Environment.NewLine;
                sqlString += "    AND (SALES.CONSTAXLAYMETHODRF = 9 OR SALESDTL.TAXATIONDIVCDRF = 1)  " + Environment.NewLine;
                sqlString += "    AND (SALES.SALESSLIPCDRF = 0 OR SALES.SALESSLIPCDRF = 1)  " + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "    AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                }
                sqlString += "   GROUP BY " + Environment.NewLine;
                sqlString += "    SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "    SALESDTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                sqlString += "    SALESDTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "    SALES.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += " ) AS F ON " + Environment.NewLine;
                sqlString += " (      " + Environment.NewLine;
                sqlString += "    F.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND F.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND F.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    AND F.SALESSLIPCDRF = A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "  )" + Environment.NewLine;
                // ----- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<

                // DEL 2009/05/18 >>>
                // --- ADD 2009/04/09 ------->>> Mantis対応11184 売上明細より売上金額と原価の合算値を取得
                sqlString += "	LEFT JOIN " + Environment.NewLine;
                sqlString += "	 (SELECT" + Environment.NewLine;
                sqlString += "	  SADTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "	  SADTL.SALESSLIPNUMRF," + Environment.NewLine;
                sqlString += "	  SADTL.ACPTANODRSTATUSRF," + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "   SALESORDERDIVCDRF," + Environment.NewLine;
                }

                sqlString += "	  SUM (SADTL.SALESMONEYTAXEXCRF) AS SALESMONEYTAXEXCRF," + Environment.NewLine;
                sqlString += "	  SUM (SADTL.COSTRF) AS COSTRF," + Environment.NewLine;
                sqlString += "    SUM (SADTL.SALESMONEYTAXINCRF) AS SALESMONEYTAXINCRF" + Environment.NewLine;
                //sqlString += "	  SADTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -- 2009/08/10 ------------------------------------------------->>>
                //sqlString += "	FROM SALESDETAILRF SADTL" + Environment.NewLine;
                //sqlString += "	FROM SALESHISTDTLRF SADTL" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += "	FROM SALESHISTDTLRF SADTL WITH (READUNCOMMITTED)" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                // -- 2009/08/10 -------------------------------------------------<<<
                sqlString += "	GROUP BY SADTL.ENTERPRISECODERF," + Environment.NewLine;
                sqlString += "	         SADTL.SALESSLIPNUMRF," + Environment.NewLine;
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += "   SALESORDERDIVCDRF," + Environment.NewLine;
                }
                sqlString += "	         SADTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                //sqlString += "	         SADTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                sqlString += "	) AS DTL" + Environment.NewLine;
                sqlString += "	ON  DTL.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "	AND DTL.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "	AND DTL.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                // --- ADD 2009/04/09 -------<<<
                // DEL 2009/05/18 <<<
            }
            else
            {
                //sqlString += "SELECT A.SECTIONCODERF" + Environment.NewLine;  //2008.09.17 DEL
                sqlString += "SELECT DISTINCT" + Environment.NewLine;           //2008.09.17 ADD
                // 修正 2009/05/18 >>>
                //sqlString += "     A.SECTIONCODERF" + Environment.NewLine;      //2008.09.17 ADD
                sqlString += "     A.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                // 修正 2009/05/18 <<<
                sqlString += "    ,A.LOGICALDELETECODERF" + Environment.NewLine;  // --- ADD  陳建明  2010/11/29
                //sqlString += "    ,C.SECTIONGUIDENMRF" + Environment.NewLine; //2008.10.08 DEL
                sqlString += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;  //2008.10.08 ADD
                sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END CUSTOMERSNMRF" + Environment.NewLine;
                sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONDIVRF" + Environment.NewLine;
                sqlString += "    ,A.RETGOODSREASONRF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                sqlString += "    ,A.CONSTAXRATERF" + Environment.NewLine; // 消費税税率   // ADD 3H 尹安 2020/02/27
                sqlString += "    ,A.CUSTSLIPNORF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,B.GOODSNORF" + Environment.NewLine;
                sqlString += "    ,B.GOODSNAMERF" + Environment.NewLine;
                sqlString += "    ,B.BLGOODSCODERF" + Environment.NewLine;
                sqlString += "    ,B.BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlString += "    ,B.SALESORDERDIVCDRF" + Environment.NewLine;
                sqlString += "    ,B.LISTPRICETAXINCFLRF" + Environment.NewLine;
                sqlString += "    ,B.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESRATERF" + Environment.NewLine;
                sqlString += "    ,B.SHIPMENTCNTRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNITCOSTRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXINCFLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                sqlString += "    ,B.COSTRF" + Environment.NewLine;
                sqlString += "    ,B.SALESMONEYTAXINCRF" + Environment.NewLine;
                sqlString += "    ,B.SALESMONEYTAXEXCRF" + Environment.NewLine;
                sqlString += "    ,B.SUPPLIERCDRF" + Environment.NewLine;
                sqlString += "    ,B.SUPPLIERSNMRF" + Environment.NewLine;
                sqlString += "    ,F.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlString += "    ,G.PARTYSALESLIPNUMRF AS PARTYSALESLIPNUMSTOCK" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSECODERF" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSENAMERF" + Environment.NewLine;
                sqlString += "    ,B.WAREHOUSESHELFNORF" + Environment.NewLine;
                sqlString += "    ,B.SALESCODERF" + Environment.NewLine;
                sqlString += "    ,B.SALESCDNMRF" + Environment.NewLine;
                sqlString += "    ,E.MODELFULLNAMERF" + Environment.NewLine;
                sqlString += "    ,E.FULLMODELRF" + Environment.NewLine;
                sqlString += "    ,E.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlString += "    ,E.CATEGORYNORF" + Environment.NewLine;
                sqlString += "    ,E.CARMNGCODERF" + Environment.NewLine;
                sqlString += "    ,E.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlString += "    ,B.SALESSLIPCDDTLRF" + Environment.NewLine;
                sqlString += "    ,B.SALESROWNORF" + Environment.NewLine;
                sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                // ADD 2008.10.28 >>>
                sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                sqlString += "    ,B.TAXATIONDIVCDRF" + Environment.NewLine;
                // ADD 2008.10.28 <<<
                // ADD 2009.01.14 >>>
                sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                // ADD 2009.01.14 <<<
                // 2010/06/29 Add >>>
                sqlString += "    ,E.MODELHALFNAMERF" + Environment.NewLine;
                // 2010/06/29 Add <<<
                // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
                sqlString += "    ,B.GOODSNAMEKANARF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/07/14 ----------<<<<<
                // ----- ADD 2022/09/29 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- >>>>>
               

                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    sqlString += " ,CASE WHEN  EXISTS (" + Environment.NewLine;
                    sqlString += "       SELECT   " + Environment.NewLine;
                    sqlString += "          1   " + Environment.NewLine;
                    sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                    sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                    sqlString += "       AND A.CONSTAXLAYMETHODRF != 9 " + Environment.NewLine;
                    sqlString += "       AND SALESDTL.SALESSLIPCDDTLRF != 3 " + Environment.NewLine;
                    sqlString += "    AND (A.CONSTAXLAYMETHODRF = 0 AND SALESDTL.SALESORDERDIVCDRF<>@SALESORDERDIVCD)";
                    sqlString += "       AND SALESDTL.TAXATIONDIVCDRF != 1)  " + Environment.NewLine;
                    sqlString += "  AND NOT EXISTS (" + Environment.NewLine;
                    sqlString += "       SELECT   " + Environment.NewLine;
                    sqlString += "          1   " + Environment.NewLine;
                    sqlString += "       FROM  SALESHISTDTLRF SALESDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlString += "       WHERE SALESDTL.ENTERPRISECODERF=A.ENTERPRISECODERF " + Environment.NewLine;
                    sqlString += "       AND A.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF  " + Environment.NewLine;
                    sqlString += "       AND A.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF  " + Environment.NewLine;
                    sqlString += "       AND A.CONSTAXLAYMETHODRF != 9 " + Environment.NewLine;
                    sqlString += "       AND SALESDTL.SALESSLIPCDDTLRF != 3 " + Environment.NewLine;
                    sqlString += "    AND (A.CONSTAXLAYMETHODRF = 0 AND SALESDTL.SALESORDERDIVCDRF=@SALESORDERDIVCD)";
                    sqlString += "       AND SALESDTL.TAXATIONDIVCDRF != 1)  " + Environment.NewLine;
                    sqlString += "  THEN 1 ELSE 0 END TAXRATEEXISTFLAG  " + Environment.NewLine;
                }
                // ----- ADD 2022/09/29 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）----- <<<<<
                // --- ADD  施健  2010/07/18 ---------->>>>>
                sqlString += "    ,B.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                // --- ADD  施健  2010/07/18 ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>>
                //sqlString += " FROM SALESHISTORYRF A" + Environment.NewLine;
                //sqlString += " INNER JOIN SALESHISTDTLRF B ON" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                // --- ADD zhangwei 2014/05/29 for redmine #42684  ---------->>>>>
                sqlString += " FROM SALESHISTORYRF A WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlString += " INNER JOIN SALESHISTDTLRF B WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                // --- DEL zhangwei 2014/05/29 for redmine #42684  ----------<<<<<
                sqlString += " (B.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND B.ACPTANODRSTATUSRF = A.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlString += "    AND B.SALESSLIPNUMRF = A.SALESSLIPNUMRF" + Environment.NewLine;
                //sqlString += " ) LEFT JOIN SECINFOSETRF C ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " ) LEFT JOIN SECINFOSETRF C WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (C.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                // 修正 2009/05/18 >>>
                //sqlString += "    AND C.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;
                sqlString += "    AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;
                // 修正 2009/05/18 <<<
                //sqlString += " ) LEFT JOIN SUBSECTIONRF D ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " ) LEFT JOIN SUBSECTIONRF D WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += " (D.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND D.SECTIONCODERF = A.SECTIONCODERF" + Environment.NewLine;  // DEL 2010/05/10
                sqlString += "    AND D.SUBSECTIONCODERF = A.SUBSECTIONCODERF" + Environment.NewLine;
                // DEL 2008.11.25 >>>+
                //sqlString += " ) LEFT JOIN ACCEPTODRCARRF E ON" + Environment.NewLine;
                //sqlString += " (E.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                //sqlString += "    AND E.ACCEPTANORDERNORF = B.ACCEPTANORDERNORF" + Environment.NewLine;
                //sqlString += "    AND E.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF" + Environment.NewLine;
                // DEL 2008.11.25 <<<
                // ADD 2008.11.25 >>>
                //sqlString += ") LEFT JOIN ACCEPTODRCARRF E ON (" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += ") LEFT JOIN ACCEPTODRCARRF E WITH (READUNCOMMITTED) ON (" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += "B.ENTERPRISECODERF=E.ENTERPRISECODERF  " + Environment.NewLine;
                sqlString += "AND B.ACCEPTANORDERNORF=E.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlString += "AND (" + Environment.NewLine;
                sqlString += "      (B.ACPTANODRSTATUSRF = 10 AND E.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //　見積
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 20 AND E.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // 受注
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 30 AND E.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // 売上
                sqlString += "      OR (B.ACPTANODRSTATUSRF = 40 AND E.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // 出荷　
                sqlString += "    )" + Environment.NewLine;
                // ADD 2008.11.25 <<<

                // -- 2009/08/10 -------------------------------------------------->>>
                //sqlString += " ) LEFT JOIN STOCKDETAILRF F ON" + Environment.NewLine;
                //sqlString += " ) LEFT JOIN STOCKSLHISTDTLRF F ON" + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " ) LEFT JOIN STOCKSLHISTDTLRF F WITH (READUNCOMMITTED) ON" + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                // -- 2009/08/10 --------------------------------------------------<<<
                sqlString += " (F.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += "    AND F.SUPPLIERFORMALRF = B.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                sqlString += "    AND F.STOCKSLIPDTLNUMRF = B.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;
                //sqlString += " LEFT JOIN STOCKSLIPHISTRF G ON " + Environment.NewLine;//DEL zhangwei 2014/05/29 for redmine #42684
                sqlString += " LEFT JOIN STOCKSLIPHISTRF G WITH (READUNCOMMITTED) ON " + Environment.NewLine;//ADD zhangwei 2014/05/29 for redmine #42684
                sqlString += "( G.ENTERPRISECODERF = F.ENTERPRISECODERF" + Environment.NewLine;
                sqlString += " AND G.SUPPLIERFORMALRF = F.SUPPLIERFORMALRF" + Environment.NewLine;
                sqlString += " AND G.SUPPLIERSLIPNORF = F.SUPPLIERSLIPNORF" + Environment.NewLine;
                sqlString += " )" + Environment.NewLine;

            }
            // 2008.07.01 upd end ---------------------------------------------------<<

            #endregion

            #region Where文
            sqlString += "WHERE ";

            //企業コード
            sqlString += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesConfShWork.EnterpriseCode);

            //論理削除区分
            if (salesConfShWork.LogicalDeleteCode == 1 && salesConfShWork.SalesSlipUpdateCd == 1)
            {
                sqlString += "AND( A.LOGICALDELETECODERF=@LOGICALDELETECODE OR A.SALESSLIPUPDATECDRF>=@SALESSLIPUPDATECD ) ";

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.LogicalDeleteCode);

                SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesSlipUpdateCd);

            }
            else
            {
                //論理削除区分
                sqlString += "AND A.LOGICALDELETECODERF=@LOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.LogicalDeleteCode);

                //売上伝票更新区分
                if (salesConfShWork.SalesSlipUpdateCd != -1)
                {
                    sqlString += "AND A.SALESSLIPUPDATECDRF>=@SALESSLIPUPDATECD ";
                    SqlParameter paraSalesSlipUpdateCd = sqlCommand.Parameters.Add("@SALESSLIPUPDATECD", SqlDbType.Int);
                    paraSalesSlipUpdateCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesSlipUpdateCd);
                }
            }


            //実績計上拠点コード
            //if (salesConfShWork.IsSelectAllSection == false && salesConfShWork.IsOutputAllSecRec == false) // 2008.07.01 del
            if (salesConfShWork.IsSelectAllSection == false) // 2008.07.01 del
            {
                string sectionString = "";
                foreach (string sectionCode in salesConfShWork.ResultsAddUpSecList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    
                    //sqlString += "AND A.SECTIONCODERF IN (" + sectionString + ") "; // DEL 2008.11.04
                    sqlString += "AND A.RESULTSADDUPSECCDRF IN (" + sectionString + ") "; // ADD 2008.11.04
                }
            }

            //受注ステータス(30:売上のみ)
            sqlString += "AND A.ACPTANODRSTATUSRF=30 ";

            //売上日付(開始)
            if (salesConfShWork.SalesDateSt != 0)
            {
                // -- UPD 2010/05/10 ----------------------------------------->>>
                //sqlString += "AND A.SALESDATERF>=@SALESDATEST ";
                //SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                //paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateSt);

                sqlString += "AND A.SALESDATERF>=" + SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -----------------------------------------<<<
            }

            //売上日付(終了)
            if (salesConfShWork.SalesDateEd != 0)
            {
                // -- UPD 2010/05/10 ----------------------------------------->>>
                //sqlString += "AND A.SALESDATERF<=@SALESDATEED ";
                //SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                //paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateEd);

                sqlString += "AND A.SALESDATERF<=" + SqlDataMediator.SqlSetInt32(salesConfShWork.SalesDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -----------------------------------------<<<
            }

            //出荷日付(開始)
            if (salesConfShWork.ShipmentDaySt != 0)
            {
                sqlString += "AND A.SHIPMENTDAYRF>=@SHIPMENTDAYST ";
                SqlParameter paraShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                paraShipmentDaySt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.ShipmentDaySt);
            }

            //出荷日付(終了)
            if (salesConfShWork.ShipmentDayEd != 0)
            {
                sqlString += "AND A.SHIPMENTDAYRF<=@SHIPMENTDAYED ";
                SqlParameter paraShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                paraShipmentDayEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.ShipmentDayEd);
            }

            //入力日付(開始)
            if (salesConfShWork.SearchSlipDateSt != 0)
            {
                sqlString += "AND A.SEARCHSLIPDATERF>=@SEARCHSLIPDATEST ";
                SqlParameter paraSearchSlipDateSt = sqlCommand.Parameters.Add("@SEARCHSLIPDATEST", SqlDbType.Int);
                paraSearchSlipDateSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SearchSlipDateSt);
            }

            //入力日付(終了)
            if (salesConfShWork.SearchSlipDateEd != 0)
            {
                sqlString += "AND A.SEARCHSLIPDATERF<=@SEARCHSLIPDATEED ";
                SqlParameter paraSearchSlipDateEd = sqlCommand.Parameters.Add("@SEARCHSLIPDATEED", SqlDbType.Int);
                paraSearchSlipDateEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SearchSlipDateEd);
            }

            //赤伝区分
            if (salesConfShWork.DebitNoteDiv != -1)
            {
                sqlString += "AND A.DEBITNOTEDIVRF=@DEBITNOTEDIV ";
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.DebitNoteDiv);
            }

            //売上伝票区分 
            if (salesConfShWork.SalesSlipCd != -1 && salesConfShWork.SalesSlipCd != 2)
            {
                sqlString += "AND A.SALESSLIPCDRF=@SALESSLIPCD ";
                SqlParameter paraSalesSlipCd = sqlCommand.Parameters.Add("@SALESSLIPCD", SqlDbType.Int);
                paraSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesSlipCd);
            }

            //得意先コード(開始)
            if (salesConfShWork.CustomerCodeSt != 0)
            {
                sqlString += "AND A.CUSTOMERCODERF>=@CUSTOMERCODEST ";
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.CustomerCodeSt);
            }

            //得意先コード(終了)
            if (salesConfShWork.CustomerCodeEd != 0)
            {
                sqlString += "AND A.CUSTOMERCODERF<=@CUSTOMERCODEED ";
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.CustomerCodeEd);
            }
            
            //売上伝票番号(開始)
            if (salesConfShWork.SalesSlipNumSt != "")
            {
                sqlString += "AND A.SALESSLIPNUMRF>=@SALESSLIPNUMST ";
                SqlParameter paraSalesSlipNumSt = sqlCommand.Parameters.Add("@SALESSLIPNUMST", SqlDbType.NChar);
                paraSalesSlipNumSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesSlipNumSt);
            }

            //売上伝票番号(終了)
            if (salesConfShWork.SalesSlipNumEd != "")
            {
                sqlString += "AND A.SALESSLIPNUMRF<=@SALESSLIPNUMED ";
                SqlParameter paraSalesSlipNumStEd = sqlCommand.Parameters.Add("@SALESSLIPNUMED", SqlDbType.NChar);
                paraSalesSlipNumStEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesSlipNumEd);
            }

            //販売従業員コード(開始)
            if (salesConfShWork.SalesEmployeeCdSt != "")
            {
                sqlString += "AND A.SALESEMPLOYEECDRF>=@SALESEMPLOYEECDST ";
                SqlParameter paraSalesEmployeeCdSt = sqlCommand.Parameters.Add("@SALESEMPLOYEECDST", SqlDbType.NVarChar);
                paraSalesEmployeeCdSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesEmployeeCdSt);
            }

            //販売従業員コード(終了)
            if (salesConfShWork.SalesEmployeeCdEd != "")
            {
                sqlString += "AND ( A.SALESEMPLOYEECDRF<=@SALESEMPLOYEECDED OR A.SALESEMPLOYEECDRF IS NULL ) ";
                SqlParameter paraSalesEmployeeCdEd = sqlCommand.Parameters.Add("@SALESEMPLOYEECDED", SqlDbType.NVarChar);
                paraSalesEmployeeCdEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesEmployeeCdEd);
            }

            //受付従業員コード(開始)
            if (salesConfShWork.FrontEmployeeCdSt != "")
            {
                sqlString += "AND A.FRONTEMPLOYEECDRF>=@FRONTEMPLOYEECDST ";
                SqlParameter paraFrontEmployeeCdSt = sqlCommand.Parameters.Add("@FRONTEMPLOYEECDST", SqlDbType.NVarChar);
                paraFrontEmployeeCdSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.FrontEmployeeCdSt);
            }

            //受付従業員コード(終了)
            if (salesConfShWork.FrontEmployeeCdEd != "")
            {
                sqlString += "AND ( A.FRONTEMPLOYEECDRF<=@FRONTEMPLOYEECDED OR A.FRONTEMPLOYEECDRF IS NULL )";
                SqlParameter paraFrontEmployeeCdEd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECDED", SqlDbType.NVarChar);
                paraFrontEmployeeCdEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.FrontEmployeeCdEd);
            }

            //入力担当者コード(開始)
            if (salesConfShWork.SalesInputCodeSt != "")
            {
                sqlString += "AND A.SALESINPUTCODERF>=@SALESINPUTCODEST ";
                SqlParameter paraSalesInputCodeSt = sqlCommand.Parameters.Add("@SALESINPUTCODEST", SqlDbType.NVarChar);
                paraSalesInputCodeSt.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesInputCodeSt);
            }

            //入力担当者コード(終了)
            if (salesConfShWork.SalesInputCodeEd != "")
            {
                sqlString += "AND ( A.SALESINPUTCODERF<=@SALESINPUTCODEED OR A.SALESINPUTCODERF IS NULL )";
                SqlParameter paraSalesInputCodeEd = sqlCommand.Parameters.Add("@SALESINPUTCODEED", SqlDbType.NVarChar);
                paraSalesInputCodeEd.Value = SqlDataMediator.SqlSetString(salesConfShWork.SalesInputCodeEd);
            }

            // 2008.07.01 add start ------------------------------>>
            //販売エリアコード(開始)
            if (salesConfShWork.SalesAreaCodeSt != 0)
            {
                sqlString += "AND A.SALESAREACODERF>=@SALESAREACODEST ";
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@SALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesAreaCodeSt);
            }
            //販売エリアコード(開始)
            if (salesConfShWork.SalesAreaCodeEd != 0)
            {
                sqlString += "AND A.SALESAREACODERF<=@SALESAREACODEED ";
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@SALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesAreaCodeEd);
            }
            //業種コード(開始)
            if (salesConfShWork.BusinessTypeCodeSt != 0)
            {
                sqlString += "AND A.BUSINESSTYPECODERF>=@BUSINESSTYPECODEST ";
                SqlParameter paraBusinessTypeCodeSt = sqlCommand.Parameters.Add("@BUSINESSTYPECODEST", SqlDbType.Int);
                paraBusinessTypeCodeSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.BusinessTypeCodeSt);
            }
            //業種コード(終了)
            if (salesConfShWork.BusinessTypeCodeEd != 0)
            {
                sqlString += "AND A.BUSINESSTYPECODERF<=@BUSINESSTYPECODEED ";
                SqlParameter paraBusinessTypeCodeEd = sqlCommand.Parameters.Add("@BUSINESSTYPECODEED", SqlDbType.Int);
                paraBusinessTypeCodeEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.BusinessTypeCodeEd);
            }

            //if (printMode != 0) // 明細タイプの時
            //{

            //仕入先コード(開始)
            if (salesConfShWork.SupplierCdSt != 0)
            {
                sqlString += "AND B.SUPPLIERCDRF>=@SUPPLIERCDST ";
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SupplierCdSt);
            }

            //仕入先コード(終了)
            if (salesConfShWork.SupplierCdEd != 0)
            {
                sqlString += "AND B.SUPPLIERCDRF<=@SUPPLIERCDED ";
                SqlParameter paraSupplierCdEd = sqlCommand.Parameters.Add("@SUPPLIERCDED", SqlDbType.Int);
                paraSupplierCdEd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SupplierCdEd);
            }
            //売上在庫取寄せ区分
            if (salesConfShWork.SalesOrderDivCd != -1)
            {
                if (printMode == 0)
                {
                    sqlString += "AND B.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                    sqlString += "AND DTL.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                    SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                    paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesOrderDivCd);
                }
                else
                {
                    sqlString += "AND B.SALESORDERDIVCDRF=@SALESORDERDIVCD ";
                    SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@SALESORDERDIVCD", SqlDbType.Int);
                    paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.SalesOrderDivCd);
                }
            }
            //注文方法区分
            if (salesConfShWork.WayToOrder != -1)
            {
                sqlString += "AND B.WAYTOORDERRF=@WAYTOORDER ";
                SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(salesConfShWork.WayToOrder);
            }
            //売上伝票区分 2:返品・値引
            if (salesConfShWork.SalesSlipCd == 2)
            {
                sqlString += "AND (A.SALESSLIPCDRF=1 OR (A.SALESSLIPCDRF=0 AND B.SALESSLIPCDDTLRF = 2 )) ";
            }

            // ADD 2009/10/22 -------------------------------->>>
            //注釈行は対象外とする
            sqlString += "AND B.SALESSLIPCDDTLRF != 3 ";
            // ADD 2009/10/22 --------------------------------<<<

            //}

            // -- UPD 2009/10/22 ------------------------------------------>>>
            #region 削除
            ////売価ゼロ
            //if (salesConfShWork.ZeroSalesPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.SALESMONEYTAXEXCRF=0 ";
            //    else
            //        sqlString += "AND B.SALESMONEYTAXEXCRF=0 ";
            //}
            ////原価ゼロ
            //if (salesConfShWork.ZeroCostPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.COSTRF=0 ";
            //    else
            //        sqlString += "AND B.COSTRF=0 ";
            //}
            ////粗利ゼロ
            //if (salesConfShWork.ZeroGrsProfitPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.SALESMONEYTAXEXCRF - DTL.COSTRF=0 ";
            //    else
            //        sqlString += "AND B.SALESMONEYTAXEXCRF - B.COSTRF=0 ";
            //}
            ////粗利ゼロ以下
            //if (salesConfShWork.ZeroUdrGrsProfitPrint != 0)
            //{
            //    if (printMode == 0)
            //        sqlString += "AND DTL.SALESMONEYTAXEXCRF - DTL.COSTRF<0 ";
            //    else
            //        sqlString += "AND B.SALESMONEYTAXEXCRF - B.COSTRF<0 ";
            //}
            ////粗利率
            //string grsProfitRatePrintVal = string.Empty;
            //grsProfitRatePrintVal = salesConfShWork.GrsProfitRatePrintVal.ToString();

            //if (salesConfShWork.GrsProfitRatePrint != 0)
            //{
            //    if (salesConfShWork.GrsProfitRatePrintDiv != 0) // 以上
            //    {
            //        if (printMode == 0)
            //            sqlString += "AND (CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) >" + grsProfitRatePrintVal + Environment.NewLine;
            //        else
            //            //sqlString += "AND (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF>" + grsProfitRatePrintVal + Environment.NewLine;
            //            sqlString += "AND (CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) >" + grsProfitRatePrintVal + Environment.NewLine;
            //    }
            //    else
            //    {
            //        if (printMode == 0)
            //            sqlString += "AND (CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) <" + grsProfitRatePrintVal + Environment.NewLine;
            //        else
            //            //sqlString += "AND (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF<" + grsProfitRatePrintVal + Environment.NewLine;
            //            sqlString += "AND (CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) <" + grsProfitRatePrintVal + Environment.NewLine;
            //    }
            //}
            // 2008.07.01 add end --------------------------------<<
            #endregion

            //ゼロ指定はＯＲ条件に変更
            string zeroString = string.Empty;

            //売価ゼロ
            if (salesConfShWork.ZeroSalesPrint != 0)
            {
                if (printMode == 0)
                    zeroString += "DTL.SALESMONEYTAXEXCRF=0";
                else
                    zeroString += "B.SALESMONEYTAXEXCRF=0";
            }
            //原価ゼロ
            if (salesConfShWork.ZeroCostPrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (printMode == 0)
                    zeroString += "DTL.COSTRF=0";
                else
                    zeroString += "B.COSTRF=0";
            }
            //粗利ゼロ
            if (salesConfShWork.ZeroGrsProfitPrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (printMode == 0)
                    zeroString += "DTL.SALESMONEYTAXEXCRF - DTL.COSTRF=0";
                else
                    zeroString += "B.SALESMONEYTAXEXCRF - B.COSTRF=0";
            }
            //粗利ゼロ以下
            if (salesConfShWork.ZeroUdrGrsProfitPrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (printMode == 0)
                    zeroString += "DTL.SALESMONEYTAXEXCRF - DTL.COSTRF<=0";
                else
                    zeroString += "B.SALESMONEYTAXEXCRF - B.COSTRF<=0";
            }

            //粗利率
            string grsProfitRatePrintVal = string.Empty;
            grsProfitRatePrintVal = salesConfShWork.GrsProfitRatePrintVal.ToString();

            if (salesConfShWork.GrsProfitRatePrint != 0)
            {
                if (zeroString != string.Empty)
                {
                    zeroString += " OR ";
                }

                if (salesConfShWork.GrsProfitRatePrintDiv != 0) // 以上
                {
                    if (printMode == 0)
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) >=" + grsProfitRatePrintVal +')' + Environment.NewLine;
                        zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,DTL.SALESMONEYTAXEXCRF) - convert(decimal,DTL.COSTRF)) * 100 / convert(decimal,DTL.SALESMONEYTAXEXCRF) ELSE 0 END) >=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                    else
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) >=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,B.SALESMONEYTAXEXCRF) - convert(decimal,B.COSTRF)) * 100 / convert(decimal,B.SALESMONEYTAXEXCRF) ELSE 0 END) >=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                }
                else
                {
                    if(printMode ==0)
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (DTL.SALESMONEYTAXEXCRF - DTL.COSTRF) * 100 / DTL.SALESMONEYTAXEXCRF ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        zeroString += "((CASE WHEN DTL.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,DTL.SALESMONEYTAXEXCRF) - convert(decimal,DTL.COSTRF)) * 100 / convert(decimal,DTL.SALESMONEYTAXEXCRF) ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                    else
                        // 2010/06/08 >>>
                        //zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (B.SALESMONEYTAXEXCRF - B.COSTRF) * 100 / B.SALESMONEYTAXEXCRF ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        zeroString += "((CASE WHEN B.SALESMONEYTAXEXCRF != 0 THEN (convert(decimal,B.SALESMONEYTAXEXCRF) - convert(decimal,B.COSTRF)) * 100 / convert(decimal,B.SALESMONEYTAXEXCRF) ELSE 0 END) <=" + grsProfitRatePrintVal + ')' + Environment.NewLine;
                        // 2010/06/08 <<<
                }
            }

            if (zeroString != string.Empty)
            {
                sqlString += "AND (" + zeroString + ") ";
            }
            // -- UPD 2009/10/22 ------------------------------------------<<<

            // 2008.07.01 add end --------------------------------<<

            if (printMode == 1)
            {
                // --- DEL 2014/04/17 T.Miyamoto ------------------------------>>>>>
                ////一式データ(一式明細番号=0)
                //sqlString += "AND B.CMPLTSALESROWNORF=0 ";
                // --- DEL 2014/04/17 T.Miyamoto ------------------------------<<<<<
            }
            #endregion

            // ADD 2009.01.14 >>>
            if (printMode == 0)
            {
                #region GROUP BY
                //sqlString += " GROUP BY" + Environment.NewLine;
                //sqlString += "     A.SECTIONCODERF" + Environment.NewLine;
                //sqlString += "    ,C.SECTIONGUIDESNMRF" + Environment.NewLine;
                //sqlString += "    ,A.SUBSECTIONCODERF" + Environment.NewLine;
                //sqlString += "    ,D.SUBSECTIONNAMERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESSLIPNUMRF" + Environment.NewLine;
                //sqlString += "    ,A.CLAIMCODERF" + Environment.NewLine;
                //sqlString += "    ,A.CLAIMSNMRF" + Environment.NewLine;
                //sqlString += "    ,A.CUSTOMERCODERF" + Environment.NewLine;
                //sqlString += "    ,A.CUSTOMERSNMRF" + Environment.NewLine;
                //sqlString += "    ,CASE WHEN OUTPUTNAMECODERF=3 THEN A.CUSTOMERNAMERF ELSE A.CUSTOMERSNMRF END" + Environment.NewLine;
                //sqlString += "    ,A.SHIPMENTDAYRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDATERF" + Environment.NewLine;
                //sqlString += "    ,A.ADDUPADATERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESSLIPCDRF" + Environment.NewLine;
                //sqlString += "    ,A.ACCRECDIVCDRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESINPUTCODERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESINPUTNAMERF" + Environment.NewLine;
                //sqlString += "    ,A.FRONTEMPLOYEECDRF" + Environment.NewLine;
                //sqlString += "    ,A.FRONTEMPLOYEENMRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESEMPLOYEECDRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESEMPLOYEENMRF" + Environment.NewLine;
                //sqlString += "    ,A.PARTYSALESLIPNUMRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXINCRF" + Environment.NewLine;
                //sqlString += "    ,A.SALESTOTALTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.TOTALCOSTRF" + Environment.NewLine;
                //sqlString += "    ,A.RETGOODSREASONDIVRF" + Environment.NewLine;
                //sqlString += "    ,A.RETGOODSREASONRF" + Environment.NewLine;
                //sqlString += "    ,A.SLIPNOTERF" + Environment.NewLine;
                //sqlString += "    ,A.SLIPNOTE2RF" + Environment.NewLine;
                //sqlString += "    ,A.SLIPNOTE3RF" + Environment.NewLine;
                //sqlString += "    ,A.BUSINESSTYPECODERF" + Environment.NewLine;
                //sqlString += "    ,A.BUSINESSTYPENAMERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESAREACODERF" + Environment.NewLine;
                //sqlString += "    ,A.SALESAREANAMERF" + Environment.NewLine;
                //sqlString += "    ,A.UOEREMARK1RF" + Environment.NewLine;
                //sqlString += "    ,A.UOEREMARK2RF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                //sqlString += "    ,A.CUSTSLIPNORF" + Environment.NewLine;
                //sqlString += "    ,A.SEARCHSLIPDATERF" + Environment.NewLine;
                //sqlString += "    ,A.CONSTAXLAYMETHODRF" + Environment.NewLine;
                //sqlString += "    ,A.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                //sqlString += "    ,A.SALAMNTCONSTAXINCLURF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDISTTLTAXINCLURF" + Environment.NewLine;
                //sqlString += "    ,A.SALESDISOUTTAXRF" + Environment.NewLine;
                #endregion
            }
            // ADD 2009.01.14 <<<

            #region Order By文
            sqlString += "ORDER BY A.SALESSLIPNUMRF ";
            if (printMode == 1)
            {
                sqlString += ", B.SALESROWNORF ";
            }

            #endregion

            return sqlString;
        }

        /// <summary>
        /// クラス格納処理 Reader → SalesConfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="salesConfShWork">検索パラメータ</param>
        /// <param name="printMode">0:合計タイプ 1:明細・詳細タイプ</param>
        /// <returns>SalesConfWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  山田 明友</br>
        /// <br>Date       : 2007.10.18</br>
        /// </remarks>
        private SalesConfWork CopyToSalesSlipConfWorkFromReader(ref SqlDataReader myReader, SalesConfShWork salesConfShWork, int printMode)
        {
            #region クラスへ格納
            SalesConfWork wkSalesConfWork = new SalesConfWork();

            //売上データ
            wkSalesConfWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); //2008.10.08 DEL
            wkSalesConfWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));  //2008.10.08 ADD
            wkSalesConfWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkSalesConfWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            wkSalesConfWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            wkSalesConfWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkSalesConfWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkSalesConfWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkSalesConfWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkSalesConfWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            wkSalesConfWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkSalesConfWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            wkSalesConfWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
            wkSalesConfWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
            wkSalesConfWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            wkSalesConfWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            wkSalesConfWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            wkSalesConfWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            wkSalesConfWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            wkSalesConfWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            wkSalesConfWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            wkSalesConfWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
            wkSalesConfWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
            wkSalesConfWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
            wkSalesConfWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
            wkSalesConfWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
            wkSalesConfWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
            wkSalesConfWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
            wkSalesConfWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
            wkSalesConfWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkSalesConfWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            wkSalesConfWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkSalesConfWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            wkSalesConfWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            wkSalesConfWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            wkSalesConfWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));  // 消費税税率　// ADD 3H 尹安 2020/02/27
            wkSalesConfWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
            wkSalesConfWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
            wkSalesConfWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));

            // ADD 2008.10.28 >>>
            wkSalesConfWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            wkSalesConfWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            wkSalesConfWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
            wkSalesConfWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
            // ADD 2008.10.28 <<<
            // ADD 2009.01.14 >>>
            wkSalesConfWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
            wkSalesConfWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));// --- ADD  陳建明  2010/11/29
            if (printMode == 0)
            {
                wkSalesConfWork.DisCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOSTRF"));
                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--->>>>>
                wkSalesConfWork.TaxFreeExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXFREEEXISTFLAG")) > 0;
                wkSalesConfWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;
                wkSalesConfWork.SalesMoneyTaxFreeCdrf = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXFREECRF"));
                // --- ADD 2022/09/05 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---<<<<<
            }
            // --- ADD 2022/09/29 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）--->>>>>
            else {
                if (salesConfShWork.SalesOrderDivCd != -1)
                {
                    wkSalesConfWork.TaxRateExistFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATEEXISTFLAG")) > 0;
                }
                else 
                {
                    wkSalesConfWork.TaxRateExistFlag = false;
                }
            }
            // --- ADD 2022/09/29 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）---<<<<<
            // ADD 2009.01.14 <<<

            // 修正 2009/04/21 >>>            
            if (printMode == 0)
            {
                // 値引消費税の補正処理
                // 値引消費税が0以外 かつ 値引金額(税抜)=0 の場合、値引消費税を売上/返品消費税へ移動
                if (wkSalesConfWork.SalesDisOutTax != 0 && wkSalesConfWork.SalesDisTtlTaxExc == 0)
                {
                    //wkSalesConfWork.SalesTotalTaxInc -= wkSalesConfWork.SalesDisOutTax;
                    wkSalesConfWork.SalesDisOutTax = 0;
                }

            }
            // 修正 2009/04/21 <<<

            //取引区分名
            if (wkSalesConfWork.SalesSlipCd == 0)
            {
                if (wkSalesConfWork.AccRecDivCd == 0)
                {
                    wkSalesConfWork.TransactionName = "現金売上";
                }
                else if (wkSalesConfWork.AccRecDivCd == 1)
                {
                    wkSalesConfWork.TransactionName = "掛売上";
                }
            }
            else if (wkSalesConfWork.SalesSlipCd == 1)
            {
                if (wkSalesConfWork.AccRecDivCd == 0)
                {
                    wkSalesConfWork.TransactionName = "現金返品";
                }
                else if (wkSalesConfWork.AccRecDivCd == 1)
                {
                    wkSalesConfWork.TransactionName = "掛返品";
                }
            }

            //粗利率(合計)
            if (wkSalesConfWork.SalesTotalTaxExc == 0)
            {
                wkSalesConfWork.GrossMarginRate = 0;
            }
            else
            {
                wkSalesConfWork.GrossMarginRate = (wkSalesConfWork.SalesTotalTaxExc - wkSalesConfWork.TotalCost) * 100 / (double)wkSalesConfWork.SalesTotalTaxExc;
            }

            //粗利チェックマーク(合計)
            if (wkSalesConfWork.GrossMarginRate < salesConfShWork.GrsProfitCheckLower)
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin1Mark;
            }
            else if (wkSalesConfWork.GrossMarginRate < salesConfShWork.GrsProfitCheckBest)
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin2Mark;
            }
            else if (wkSalesConfWork.GrossMarginRate < salesConfShWork.GrsProfitCheckUpper)
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin3Mark;
            }
            else
            {
                wkSalesConfWork.GrossMarginMarkSlip = salesConfShWork.GrossMargin4Mark;
            }
 
            //明細データ
            if (printMode == 1)
            {
                wkSalesConfWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkSalesConfWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkSalesConfWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkSalesConfWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkSalesConfWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                wkSalesConfWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                wkSalesConfWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkSalesConfWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                wkSalesConfWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                wkSalesConfWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                wkSalesConfWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                wkSalesConfWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                wkSalesConfWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                wkSalesConfWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                wkSalesConfWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                wkSalesConfWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkSalesConfWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkSalesConfWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                wkSalesConfWork.PartySaleSlipNumStock = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMSTOCK"));
                wkSalesConfWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkSalesConfWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkSalesConfWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkSalesConfWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                wkSalesConfWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                wkSalesConfWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                wkSalesConfWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                wkSalesConfWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                wkSalesConfWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                wkSalesConfWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                wkSalesConfWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));
                wkSalesConfWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                wkSalesConfWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                // ADD 2008.10.28 >>>
                wkSalesConfWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                // ADD 2008.10.28 <<<
                // 2010/06/29 Add >>>
                wkSalesConfWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                // 2010/06/29 Add <<<
                // --- ADD  大矢睦美  2010/07/14 ---------->>>>>
                wkSalesConfWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                // --- ADD  大矢睦美  2010/07/14 ----------<<<<<
                // --- ADD  施健  2010/07/18 ---------->>>>>
                wkSalesConfWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));
                // --- ADD  施健  2010/07/18 ----------<<<<<


                //粗利率(明細)
                if (wkSalesConfWork.SalesMoneyTaxExc == 0)
                {
                    wkSalesConfWork.GrossMarginRateDtl = 0;
                }
                else
                {
                    wkSalesConfWork.GrossMarginRateDtl = (wkSalesConfWork.SalesMoneyTaxExc - wkSalesConfWork.Cost) * 100 / (double)wkSalesConfWork.SalesMoneyTaxExc;
                }

                //粗利チェックマーク(明細)
                if (wkSalesConfWork.GrossMarginRateDtl < salesConfShWork.GrsProfitCheckLower)
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin1Mark;
                }
                else if (wkSalesConfWork.GrossMarginRateDtl < salesConfShWork.GrsProfitCheckBest)
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin2Mark;
                }
                else if (wkSalesConfWork.GrossMarginRateDtl < salesConfShWork.GrsProfitCheckUpper)
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin3Mark;
                }
                else
                {
                    wkSalesConfWork.GrossMarginMarkDtl = salesConfShWork.GrossMargin4Mark;
                }
            }
            #endregion

            return wkSalesConfWork;
        }

        #endregion
        // ↑ 2007.10.18 980081 e
    }
}

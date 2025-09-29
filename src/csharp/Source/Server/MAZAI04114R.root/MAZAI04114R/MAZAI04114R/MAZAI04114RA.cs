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

using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;  // ADD 2020/06/18 譚洪 PMKOBETSU-4005 

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品在庫検索DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品在庫検索の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21015　金巻　芳則</br>
    /// <br>Date       : 2007.01.18</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>
    /// <br>Update Note: 2008.07.09 長内 PM.NS用に修正</br>
    /// <br>Update Note: 2009/12/18 李侠</br>
    /// <br>             PM.NS-5・保守依頼④のハイフン付きの品番ではハイフン入力無しでも検索可能へ変更</br>
    /// <br>Update Note: 2011/03/22 曹文傑</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// <br></br>
    /// <br>Update Note: 2012/04/10 西 毅 </br>
    /// <br>             在庫照会の抽出専用クエリ作成</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class GoodsStockSearchDB : RemoteDB, IGoodsStockSearchDB
    {
        //private StockDB _stockDB = new StockDB();

        /// <summary>検索タイプ</summary>
        private enum ct_SearchType
        {
            /// <summary>在庫データ</summary>
            Stock = 1,
            ///// <summary>製番在庫データ</summary>
            //ProductStock = 2
        }

        /// <summary>
        /// 商品在庫検索DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// </remarks>
        public GoodsStockSearchDB()
            :
            base("MAZAI04116D", "Broadleaf.Application.Remoting.ParamData.GoodsStockSearchWork", "STOCKRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを戻します
        /// </summary>
        /// <param name="goodsStockSearchWork">検索結果</param>
        /// <param name="paragoodsStockSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br>Update Note: 2011/03/22 曹文傑</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(out object goodsStockSearchWork, object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsStockSearchWork = null;

            // ---ADD 2011/03/22---------->>>>>
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            StockSearchParaWork goodsStockSearchParaWork = paragoodsStockSearchWork as StockSearchParaWork;
            // ---ADD 2011/03/22----------<<<<<
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, goodsStockSearchParaWork.EnterpriseCode, "在庫照会", "抽出開始");
                // ---ADD 2011/03/22----------<<<<<

                return SearchGoodsStockSearchProc(out goodsStockSearchWork, paragoodsStockSearchWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsStockSearchDB.Search");
                goodsStockSearchWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                // ---ADD 2011/03/22---------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, goodsStockSearchParaWork.EnterpriseCode, "在庫照会", "抽出終了");
                // ---ADD 2011/03/22----------<<<<<

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }
        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsStockSearchWork">検索結果</param>
        /// <param name="paragoodsStockSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>
        public int SearchGoodsStockSearchProc(out object objgoodsStockSearchWork, object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            StockSearchParaWork goodsStockSearchParaWork = null;
            CustomSerializeArrayList goodsstocksearchWorkList = new CustomSerializeArrayList();

            goodsStockSearchParaWork = paragoodsStockSearchWork as StockSearchParaWork;

            ArrayList goodsStockList = null;

            //データ取得区分
            status = SearchGoodsStockProc(out goodsStockList, goodsStockSearchParaWork, readMode, logicalMode, ref sqlConnection);

            if (goodsStockList != null)
                if (goodsStockList.Count > 0) goodsstocksearchWorkList.Add(goodsStockList);


            objgoodsStockSearchWork = goodsstocksearchWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="goodsStockSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>
        public int SearchGoodsStockProc(out ArrayList retList, StockSearchParaWork goodsStockSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchGoodsStockProcProc(out retList, goodsStockSearchParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="goodsStockSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>
        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④のハイフン付きの品番ではハイフン入力無しでも検索可能へ変更</br>
        private int SearchGoodsStockProcProc( out ArrayList retList, StockSearchParaWork goodsStockSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList goodsStockList = new ArrayList();
            string selectTxt = "";
            try
            {
                selectTxt += "SELECT DISTINCT" + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                // --- ADD 2009/12/18 ---------->>>>>
                if (!goodsStockSearchParaWork.GoodsNo.Contains("-"))
                {   
                    selectTxt += ",(SELECT REPLACE(GOODSNORF, '-', '') AS GOODSNORFNOHYPHEN" + Environment.NewLine;
                    selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "  ,WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "  ,GOODSNORF" + Environment.NewLine;
                    selectTxt += "FROM STOCKRF) AS STOCKRFNOHYPHEN" + Environment.NewLine;
                }
                // --- ADD 2009/12/18 ----------<<<<<
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsStockSearchParaWork, logicalMode, ct_SearchType.Stock);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    goodsStockList.Add(CopyToStockEachWarehouseWorkFromReader(ref myReader));

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

            retList = goodsStockList;

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsStockSearchParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="searchType">検索タイプ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>

        /// <br>Update Note: 2009/12/18 李侠</br>
        /// <br>             PM.NS-5・保守依頼④のハイフン付きの品番ではハイフン入力無しでも検索可能へ変更</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSearchParaWork goodsStockSearchParaWork, ConstantManagement.LogicalMode logicalMode, ct_SearchType searchType)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "STOCK.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (goodsStockSearchParaWork.SectionCode != "")
            {
                retstring += "AND STOCK.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.SectionCode);
            }

            //メーカーコード
            if (goodsStockSearchParaWork.GoodsMakerCd > 0)
            {
                retstring += "AND STOCK.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsStockSearchParaWork.GoodsMakerCd);
            }

            //メーカーコード
            if (goodsStockSearchParaWork.GoodsMakerCds != null)
            {
                wkstring = "";
                foreach (int str in goodsStockSearchParaWork.GoodsMakerCds)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str.ToString() + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND STOCK.GOODSMAKERCDRF IN (" + wkstring + ") ";
                }
                retstring += Environment.NewLine;
            }

            //商品番号
            if (goodsStockSearchParaWork.GoodsNo != "")
            {
                // --- UPD 2009/12/18 ---------->>>>>
                //retstring += "AND STOCK.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;
                //SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                ////前方一致検索の場合
                //if (goodsStockSearchParaWork.GoodsNoSrchTyp == 1) goodsStockSearchParaWork.GoodsNo = goodsStockSearchParaWork.GoodsNo + "%";
                ////後方一致検索の場合
                //if (goodsStockSearchParaWork.GoodsNoSrchTyp == 2) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo;
                ////あいまい検索の場合
                //if (goodsStockSearchParaWork.GoodsNoSrchTyp == 3) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo + "%";
                //paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNo);
                if (goodsStockSearchParaWork.GoodsNo.Contains("-"))
                {
                    retstring += "AND STOCK.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    //前方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 1) goodsStockSearchParaWork.GoodsNo = goodsStockSearchParaWork.GoodsNo + "%";
                    //後方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 2) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo;
                    //あいまい検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 3) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo + "%";
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNo);
                }
                else
                {
                    retstring += "AND STOCKRFNOHYPHEN.GOODSNORFNOHYPHEN LIKE @GOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    //前方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 1) goodsStockSearchParaWork.GoodsNo = goodsStockSearchParaWork.GoodsNo + "%";
                    //後方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 2) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo;
                    //あいまい検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 3) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo + "%";
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNo);
                    retstring += "AND STOCKRFNOHYPHEN.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    retstring += "AND STOCKRFNOHYPHEN.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                    retstring += "AND STOCKRFNOHYPHEN.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                    retstring += "AND STOCKRFNOHYPHEN.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                }
                // --- UPD 2009/12/18 ----------<<<<<
            }
            else if (goodsStockSearchParaWork.GoodsNos != null)
            {
                wkstring = "";
                foreach (string str in goodsStockSearchParaWork.GoodsNos)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND STOCK.GOODSNORF IN (" + wkstring + ") ";
                }
                retstring += Environment.NewLine;
            }

            //商品名称
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.GoodsName) == false)
            {
                retstring += "AND GOODS.GOODSNAMERF LIKE @GOODSNAME" + Environment.NewLine;
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameSrchTyp == 1) goodsStockSearchParaWork.GoodsName = goodsStockSearchParaWork.GoodsName + "%";
                //後方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameSrchTyp == 2) goodsStockSearchParaWork.GoodsName = "%" + goodsStockSearchParaWork.GoodsName;
                //曖昧検索の場合
                if (goodsStockSearchParaWork.GoodsNameSrchTyp == 3) goodsStockSearchParaWork.GoodsName = "%" + goodsStockSearchParaWork.GoodsName + "%";
                
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsName);
            }

            //商品名称カナ
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.GoodsNameKana) == false)
            {
                retstring += "AND GOODS.GOODSNAMEKANARF LIKE @GOODSNAMEKANA" + Environment.NewLine;
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameKanaSrchTyp == 1) goodsStockSearchParaWork.GoodsNameKana = goodsStockSearchParaWork.GoodsNameKana + "%";
                //後方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameKanaSrchTyp == 2) goodsStockSearchParaWork.GoodsNameKana = "%" + goodsStockSearchParaWork.GoodsNameKana;
                //曖昧検索の場合
                if (goodsStockSearchParaWork.GoodsNameKanaSrchTyp == 3) goodsStockSearchParaWork.GoodsNameKana = "%" + goodsStockSearchParaWork.GoodsNameKana + "%";

                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNameKana);
            }

            //自社分類コード
            if (goodsStockSearchParaWork.EnterpriseGanreCode > 0)
            {
                retstring += "AND GOODS.ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraEnterPriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                paraEnterPriseGanreCode.Value = SqlDataMediator.SqlSetInt32(goodsStockSearchParaWork.EnterpriseGanreCode);
            }

            //BL商品コード
            if (goodsStockSearchParaWork.BLGoodsCode > 0)
            {
                retstring += "AND GOODS.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsStockSearchParaWork.BLGoodsCode);
            }

            //倉庫コード
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.WarehouseCode) == false)
            {
                retstring += "AND STOCK.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.WarehouseCode);
            }

            //倉庫コード
            if (goodsStockSearchParaWork.WarehouseCodes != null)
            {
                wkstring = "";
                foreach (string str in goodsStockSearchParaWork.WarehouseCodes)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str.ToString() + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND STOCK.WAREHOUSECODERF IN (" + wkstring + ") ";
                }
                retstring += Environment.NewLine;
            }

            //ゼロ在庫表示
            if (goodsStockSearchParaWork.ZeroStckDsp == 1)
            {
                retstring += "AND STOCK.SHIPMENTPOSCNTRF<>0 ";
            }

            //棚番
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.WarehouseShelfNo) == false)
            {
                retstring += "AND STOCK.WAREHOUSESHELFNORF LIKE @WAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraWareHouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsStockSearchParaWork.WarehouseShelfNoSrchTyp == 1) goodsStockSearchParaWork.WarehouseShelfNo = goodsStockSearchParaWork.WarehouseShelfNo + "%";
                //後方一致検索の場合
                if (goodsStockSearchParaWork.WarehouseShelfNoSrchTyp == 2) goodsStockSearchParaWork.WarehouseShelfNo = "%" + goodsStockSearchParaWork.WarehouseShelfNo;
                //曖昧検索の場合
                if (goodsStockSearchParaWork.WarehouseShelfNoSrchTyp == 3) goodsStockSearchParaWork.WarehouseShelfNo = "%" + goodsStockSearchParaWork.WarehouseShelfNo + "%";

                paraWareHouseShelfNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.WarehouseShelfNo);
            }
            
            //開始対象日付
            if (goodsStockSearchParaWork.St_Date != DateTime.MinValue)
            {
                if (goodsStockSearchParaWork.DateDiv == 0)
                {
                    //更新日付
                    retstring += "AND STOCK.STOCKCREATEDATERF>=@ST_DATE" + Environment.NewLine;
                }
                else
                {
                    //登録日付
                    retstring += "AND STOCK.UPDATEDATERF>=@ST_DATE" + Environment.NewLine;
                }
                
                SqlParameter paraSt_Date = sqlCommand.Parameters.Add("@ST_DATE", SqlDbType.Int);
                paraSt_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsStockSearchParaWork.St_Date);
            }

            //終了対象日付
            if (goodsStockSearchParaWork.Ed_Date != DateTime.MinValue)
            {
                if (goodsStockSearchParaWork.DateDiv == 0)
                {
                    //更新日付
                    retstring += "AND STOCK.STOCKCREATEDATERF<=@ED_DATE" + Environment.NewLine;
                    
                }
                else
                {
                    //登録日付
                    retstring += "AND STOCK.UPDATEDATERF<=@ED_DATE" + Environment.NewLine;
                }

                SqlParameter paraEd_Date = sqlCommand.Parameters.Add("@ED_DATE", SqlDbType.Int);
                paraEd_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsStockSearchParaWork.Ed_Date);
            }
            
            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockSearchRetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockSearchRetWork</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.07 長内 DC.NS用に修正</br>
        /// </remarks>
        private StockEachWarehouseWork CopyToStockEachWarehouseWorkFromReader(ref SqlDataReader myReader)
        {
            StockEachWarehouseWork wkStockEachWarehouseWork = new StockEachWarehouseWork();

            #region クラスへ格納
            wkStockEachWarehouseWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockEachWarehouseWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockEachWarehouseWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockEachWarehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockEachWarehouseWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockEachWarehouseWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockEachWarehouseWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockEachWarehouseWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockEachWarehouseWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockEachWarehouseWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockEachWarehouseWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockEachWarehouseWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockEachWarehouseWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockEachWarehouseWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockEachWarehouseWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockEachWarehouseWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockEachWarehouseWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockEachWarehouseWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            wkStockEachWarehouseWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockEachWarehouseWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockEachWarehouseWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockEachWarehouseWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockEachWarehouseWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockEachWarehouseWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockEachWarehouseWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            wkStockEachWarehouseWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockEachWarehouseWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            wkStockEachWarehouseWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            wkStockEachWarehouseWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            wkStockEachWarehouseWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkStockEachWarehouseWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            wkStockEachWarehouseWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkStockEachWarehouseWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockEachWarehouseWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockEachWarehouseWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkStockEachWarehouseWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            wkStockEachWarehouseWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            wkStockEachWarehouseWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            wkStockEachWarehouseWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            wkStockEachWarehouseWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockEachWarehouseWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockEachWarehouseWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            wkStockEachWarehouseWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkStockEachWarehouseWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockEachWarehouseWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockEachWarehouseWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkStockEachWarehouseWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            #endregion

            return wkStockEachWarehouseWork;
        }

        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2007.01.18</br>
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

        #region [在庫照会専用クエリ]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを戻します
        /// </summary>
        /// <param name="goodsStockSearchWork">検索結果</param>
        /// <param name="paragoodsStockSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します</br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2012/04/10</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search2(out object goodsStockSearchWork, object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            goodsStockSearchWork = null;

            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            StockSearchParaWork goodsStockSearchParaWork = paragoodsStockSearchWork as StockSearchParaWork;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, goodsStockSearchParaWork.EnterpriseCode, "在庫照会", "抽出開始");

                return SearchGoodsStockSearchProc2(out goodsStockSearchWork, paragoodsStockSearchWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "GoodsStockSearchDB.Search");
                goodsStockSearchWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, goodsStockSearchParaWork.EnterpriseCode, "在庫照会", "抽出終了");

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }
        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objgoodsStockSearchWork">検索結果</param>
        /// <param name="paragoodsStockSearchWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2012/04/10</br>
        /// <br></br>
        public int SearchGoodsStockSearchProc2(out object objgoodsStockSearchWork, object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            StockSearchParaWork goodsStockSearchParaWork = null;
            CustomSerializeArrayList goodsstocksearchWorkList = new CustomSerializeArrayList();

            goodsStockSearchParaWork = paragoodsStockSearchWork as StockSearchParaWork;

            ArrayList goodsStockList = null;

            //データ取得区分
            status = SearchGoodsStockProc2(out goodsStockList, goodsStockSearchParaWork, readMode, logicalMode, ref sqlConnection);

            if (goodsStockList != null)
                if (goodsStockList.Count > 0) goodsstocksearchWorkList.Add(goodsStockList);


            objgoodsStockSearchWork = goodsstocksearchWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="goodsStockSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2012/04/10</br>
        /// <br></br>
        public int SearchGoodsStockProc2(out ArrayList retList, StockSearchParaWork goodsStockSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchGoodsStockProcProc2(out retList, goodsStockSearchParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="goodsStockSearchParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の商品在庫検索情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2012/04/10</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br></br>
        private int SearchGoodsStockProcProc2(out ArrayList retList, StockSearchParaWork goodsStockSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

            ArrayList goodsStockList = new ArrayList();
            string selectTxt = "";
            try
            {
                selectTxt += "SELECT * FROM (" + Environment.NewLine;
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "   STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                selectTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                selectTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                selectTxt += "  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "  ,GOODSPRICEURF.PRICESTARTDATERF" + Environment.NewLine;
                selectTxt += "  ,GOODSPRICEURF.LISTPRICERF" + Environment.NewLine;
                selectTxt += "  ,GOODSPRICEURF.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "  ,GOODSPRICEURF.STOCKRATERF" + Environment.NewLine;
                selectTxt += "  ,GOODSPRICEURF.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "  ,ROW_NUMBER() OVER(PARTITION BY " + Environment.NewLine;
                selectTxt += "   STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "   ORDER BY " + Environment.NewLine;
                selectTxt += "   STOCK.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GOODSPRICEURF.PRICESTARTDATERF DESC" + Environment.NewLine;
                selectTxt += "  ) AS ROWNUM " + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += "ON " + Environment.NewLine;
                selectTxt += "     STOCK.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=GOODS.GOODSNORF" + Environment.NewLine;
                selectTxt += " LEFT JOIN (SELECT * FROM GOODSPRICEURF) AS GOODSPRICEURF" + Environment.NewLine;
                selectTxt += " ON GOODSPRICEURF.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSPRICEURF.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSPRICEURF.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString2(ref sqlCommand, goodsStockSearchParaWork, logicalMode, ct_SearchType.Stock);

                sqlCommand.CommandText += " ) A" + Environment.NewLine;
                sqlCommand.CommandText += " WHERE ROWNUM = 1" + Environment.NewLine;
                sqlCommand.CommandText += "ORDER BY GOODSMAKERCDRF , GOODSNORF ,PRICESTARTDATERF DESC " + Environment.NewLine;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //goodsStockList.Add(CopyToStockEachWarehouseWorkFromReader2(ref myReader));
                    goodsStockList.Add(CopyToStockEachWarehouseWorkFromReader2(ref myReader, convertDoubleRelease));
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<

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
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            retList = goodsStockList;

            return status;
        }
        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsStockSearchParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="searchType">検索タイプ</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2012/04/10</br>
        /// <br></br>
        private string MakeWhereString2(ref SqlCommand sqlCommand, StockSearchParaWork goodsStockSearchParaWork, ConstantManagement.LogicalMode logicalMode, ct_SearchType searchType)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "STOCK.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (goodsStockSearchParaWork.SectionCode != "")
            {
                retstring += "AND STOCK.SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.SectionCode);
            }

            //メーカーコード
            if (goodsStockSearchParaWork.GoodsMakerCd > 0)
            {
                retstring += "AND STOCK.GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsStockSearchParaWork.GoodsMakerCd);
            }

            //メーカーコード
            if (goodsStockSearchParaWork.GoodsMakerCds != null)
            {
                wkstring = "";
                foreach (int str in goodsStockSearchParaWork.GoodsMakerCds)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str.ToString() + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND STOCK.GOODSMAKERCDRF IN (" + wkstring + ") ";
                }
                retstring += Environment.NewLine;
            }

            //商品番号
            if (goodsStockSearchParaWork.GoodsNo != "")
            {
                if (goodsStockSearchParaWork.GoodsNo.Contains("-"))
                {
                    retstring += "AND STOCK.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    //前方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 1) goodsStockSearchParaWork.GoodsNo = goodsStockSearchParaWork.GoodsNo + "%";
                    //後方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 2) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo;
                    //あいまい検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 3) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo + "%";
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNo);
                }
                else
                {
                    retstring += " AND (GOODS.GOODSNORF LIKE @GOODSNO" + Environment.NewLine;
                    retstring += " OR GOODS.GOODSNONONEHYPHENRF LIKE @GOODSNONONEHYPHEN)" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    SqlParameter paraGoodsNoNoHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NChar);
                    //前方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 1) goodsStockSearchParaWork.GoodsNo = goodsStockSearchParaWork.GoodsNo + "%";
                    //後方一致検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 2) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo;
                    //あいまい検索の場合
                    if (goodsStockSearchParaWork.GoodsNoSrchTyp == 3) goodsStockSearchParaWork.GoodsNo = "%" + goodsStockSearchParaWork.GoodsNo + "%";
                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNo);
                    paraGoodsNoNoHyphen.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNo);
                }
            }
            else if (goodsStockSearchParaWork.GoodsNos != null)
            {
                wkstring = "";
                foreach (string str in goodsStockSearchParaWork.GoodsNos)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND STOCK.GOODSNORF IN (" + wkstring + ") ";
                }
                retstring += Environment.NewLine;
            }

            //商品名称
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.GoodsName) == false)
            {
                retstring += "AND GOODS.GOODSNAMERF LIKE @GOODSNAME" + Environment.NewLine;
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameSrchTyp == 1) goodsStockSearchParaWork.GoodsName = goodsStockSearchParaWork.GoodsName + "%";
                //後方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameSrchTyp == 2) goodsStockSearchParaWork.GoodsName = "%" + goodsStockSearchParaWork.GoodsName;
                //曖昧検索の場合
                if (goodsStockSearchParaWork.GoodsNameSrchTyp == 3) goodsStockSearchParaWork.GoodsName = "%" + goodsStockSearchParaWork.GoodsName + "%";

                paraGoodsNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsName);
            }

            //商品名称カナ
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.GoodsNameKana) == false)
            {
                retstring += "AND GOODS.GOODSNAMEKANARF LIKE @GOODSNAMEKANA" + Environment.NewLine;
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameKanaSrchTyp == 1) goodsStockSearchParaWork.GoodsNameKana = goodsStockSearchParaWork.GoodsNameKana + "%";
                //後方一致検索の場合
                if (goodsStockSearchParaWork.GoodsNameKanaSrchTyp == 2) goodsStockSearchParaWork.GoodsNameKana = "%" + goodsStockSearchParaWork.GoodsNameKana;
                //曖昧検索の場合
                if (goodsStockSearchParaWork.GoodsNameKanaSrchTyp == 3) goodsStockSearchParaWork.GoodsNameKana = "%" + goodsStockSearchParaWork.GoodsNameKana + "%";

                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.GoodsNameKana);
            }

            //自社分類コード
            if (goodsStockSearchParaWork.EnterpriseGanreCode > 0)
            {
                retstring += "AND GOODS.ENTERPRISEGANRECODERF=@ENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraEnterPriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                paraEnterPriseGanreCode.Value = SqlDataMediator.SqlSetInt32(goodsStockSearchParaWork.EnterpriseGanreCode);
            }

            //BL商品コード
            if (goodsStockSearchParaWork.BLGoodsCode > 0)
            {
                retstring += "AND GOODS.BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(goodsStockSearchParaWork.BLGoodsCode);
            }

            //倉庫コード
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.WarehouseCode) == false)
            {
                retstring += "AND STOCK.WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.WarehouseCode);
            }

            //倉庫コード
            if (goodsStockSearchParaWork.WarehouseCodes != null)
            {
                wkstring = "";
                foreach (string str in goodsStockSearchParaWork.WarehouseCodes)
                {
                    if (wkstring != "") wkstring += ",";
                    wkstring += "'" + str.ToString() + "'";
                }
                if (wkstring != "")
                {
                    retstring += "AND STOCK.WAREHOUSECODERF IN (" + wkstring + ") ";
                }
                retstring += Environment.NewLine;
            }

            //ゼロ在庫表示
            if (goodsStockSearchParaWork.ZeroStckDsp == 1)
            {
                retstring += "AND STOCK.SHIPMENTPOSCNTRF<>0 ";
            }

            //棚番
            if (string.IsNullOrEmpty(goodsStockSearchParaWork.WarehouseShelfNo) == false)
            {
                retstring += "AND STOCK.WAREHOUSESHELFNORF LIKE @WAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraWareHouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                //前方一致検索の場合
                if (goodsStockSearchParaWork.WarehouseShelfNoSrchTyp == 1) goodsStockSearchParaWork.WarehouseShelfNo = goodsStockSearchParaWork.WarehouseShelfNo + "%";
                //後方一致検索の場合
                if (goodsStockSearchParaWork.WarehouseShelfNoSrchTyp == 2) goodsStockSearchParaWork.WarehouseShelfNo = "%" + goodsStockSearchParaWork.WarehouseShelfNo;
                //曖昧検索の場合
                if (goodsStockSearchParaWork.WarehouseShelfNoSrchTyp == 3) goodsStockSearchParaWork.WarehouseShelfNo = "%" + goodsStockSearchParaWork.WarehouseShelfNo + "%";

                paraWareHouseShelfNo.Value = SqlDataMediator.SqlSetString(goodsStockSearchParaWork.WarehouseShelfNo);
            }

            //開始対象日付
            if (goodsStockSearchParaWork.St_Date != DateTime.MinValue)
            {
                if (goodsStockSearchParaWork.DateDiv == 0)
                {
                    //更新日付
                    retstring += "AND STOCK.STOCKCREATEDATERF>=@ST_DATE" + Environment.NewLine;
                }
                else
                {
                    //登録日付
                    retstring += "AND STOCK.UPDATEDATERF>=@ST_DATE" + Environment.NewLine;
                }

                SqlParameter paraSt_Date = sqlCommand.Parameters.Add("@ST_DATE", SqlDbType.Int);
                paraSt_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsStockSearchParaWork.St_Date);
            }

            //終了対象日付
            if (goodsStockSearchParaWork.Ed_Date != DateTime.MinValue)
            {
                if (goodsStockSearchParaWork.DateDiv == 0)
                {
                    //更新日付
                    retstring += "AND STOCK.STOCKCREATEDATERF<=@ED_DATE" + Environment.NewLine;

                }
                else
                {
                    //登録日付
                    retstring += "AND STOCK.UPDATEDATERF<=@ED_DATE" + Environment.NewLine;
                }

                SqlParameter paraEd_Date = sqlCommand.Parameters.Add("@ED_DATE", SqlDbType.Int);
                paraEd_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsStockSearchParaWork.Ed_Date);
            }

            //開始対象日付
            if (goodsStockSearchParaWork.pricestartdate != DateTime.MinValue)
            {
                //更新日付
                retstring += " AND GOODSPRICEURF.PRICESTARTDATERF <= @PRICESTARTDATE" + Environment.NewLine;
                SqlParameter parapricestartdate = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
                parapricestartdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsStockSearchParaWork.pricestartdate);
            }
            return retstring;
        }
        #endregion
        /// <summary>
        /// クラス格納処理 Reader → StockSearchRetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>StockSearchRetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20073　西 毅</br>
        /// <br>Date       : 2012/04/10</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        /// <br></br>
        /// </remarks>
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
        //private StockEachWarehouseWork CopyToStockEachWarehouseWorkFromReader2(ref SqlDataReader myReader)
        private StockEachWarehouseWork CopyToStockEachWarehouseWorkFromReader2(ref SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
        {
            StockEachWarehouseWork wkStockEachWarehouseWork = new StockEachWarehouseWork();

            #region クラスへ格納
            wkStockEachWarehouseWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkStockEachWarehouseWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkStockEachWarehouseWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkStockEachWarehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkStockEachWarehouseWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkStockEachWarehouseWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkStockEachWarehouseWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkStockEachWarehouseWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkStockEachWarehouseWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkStockEachWarehouseWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkStockEachWarehouseWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkStockEachWarehouseWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkStockEachWarehouseWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkStockEachWarehouseWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkStockEachWarehouseWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            wkStockEachWarehouseWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            wkStockEachWarehouseWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            wkStockEachWarehouseWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            wkStockEachWarehouseWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            wkStockEachWarehouseWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            wkStockEachWarehouseWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            wkStockEachWarehouseWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            wkStockEachWarehouseWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            wkStockEachWarehouseWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            wkStockEachWarehouseWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            wkStockEachWarehouseWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            wkStockEachWarehouseWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            wkStockEachWarehouseWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            wkStockEachWarehouseWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            wkStockEachWarehouseWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            wkStockEachWarehouseWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            wkStockEachWarehouseWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkStockEachWarehouseWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            wkStockEachWarehouseWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            wkStockEachWarehouseWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            wkStockEachWarehouseWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            wkStockEachWarehouseWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            wkStockEachWarehouseWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            wkStockEachWarehouseWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            wkStockEachWarehouseWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            wkStockEachWarehouseWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            wkStockEachWarehouseWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            wkStockEachWarehouseWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkStockEachWarehouseWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkStockEachWarehouseWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkStockEachWarehouseWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkStockEachWarehouseWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkStockEachWarehouseWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkStockEachWarehouseWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkStockEachWarehouseWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkStockEachWarehouseWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkStockEachWarehouseWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkStockEachWarehouseWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkStockEachWarehouseWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkStockEachWarehouseWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkStockEachWarehouseWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkStockEachWarehouseWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            //wkStockEachWarehouseWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = wkStockEachWarehouseWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = wkStockEachWarehouseWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = wkStockEachWarehouseWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            wkStockEachWarehouseWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            wkStockEachWarehouseWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            wkStockEachWarehouseWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            wkStockEachWarehouseWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));

            #endregion

            return wkStockEachWarehouseWork;
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD
        #endregion
    }
}

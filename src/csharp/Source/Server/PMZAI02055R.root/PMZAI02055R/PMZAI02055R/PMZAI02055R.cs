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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫看板印刷DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫看板印刷実データ操作を行うクラスです。</br>
    /// <br>Programmer :
    /// 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.10</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class StockSignOrderWorkDB : RemoteDB, IStockSignOrderWorkDB
    {
        /// <summary>
        /// 在庫看板印刷DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.10</br>
        /// </remarks>
        public StockSignOrderWorkDB()
            :
        base("PMZAI02057D", "Broadleaf.Application.Remoting.ParamData.StockSignResultWork", "StockRF") //基底クラスのコンストラクタ
        {
        }

        GoodsPriceUDB goodsPriceUDB = new GoodsPriceUDB();
        
        #region 在庫看板印刷
        /// <summary>
        /// 指定された企業コードの在庫看板印刷のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockSignResultWork">検索結果</param>
        /// <param name="stockSignOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの発行確認一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.10</br>
        public int Search(out object stockSignResultWork, object stockSignOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockSignResultWork = null;

            StockSignOrderCndtnWork _stockSignOrderCndtnWork = stockSignOrderCndtnWork as StockSignOrderCndtnWork;

            try
            {
                status = SearchProc(out stockSignResultWork, _stockSignOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSignOrderWork.Search Exception=" + ex.Message);
                stockSignResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        
        /// <summary>
        /// 指定された企業コードの在庫看板印刷のLISTを全て戻します
        /// </summary>
        /// <param name="stockSignResultWork">検索結果</param>
        /// <param name="_stockSignOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫看板印刷のLISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.10</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object stockSignResultWork, StockSignOrderCndtnWork _stockSignOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockSignResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                // メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = SearchOrderProc(ref al, ref sqlConnection, _stockSignOrderCndtnWork,readMode, logicalMode);
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockSignOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            stockSignResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockSignOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, StockSignOrderCndtnWork _stockSignOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	 STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	      ,STO.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,STO.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,STO.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,GOD.GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "        ,STO.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STO.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STO.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "        ,STO.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,STO.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STO" + Environment.NewLine;
                selectTxt += "LEFT JOIN  GOODSURF AS GOD" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "	    GOD.ENTERPRISECODERF=STO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOD.GOODSNORF=STO.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AND	GOD.GOODSMAKERCDRF=STO.GOODSMAKERCDRF" + Environment.NewLine;

                // WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _stockSignOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

               myReader = sqlCommand.ExecuteReader(); 
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockSignResultWork wkstockSignResultWork = new StockSignResultWork();
                    // 格納項目
                 
                    wkstockSignResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkstockSignResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkstockSignResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkstockSignResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkstockSignResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkstockSignResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkstockSignResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkstockSignResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkstockSignResultWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkstockSignResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkstockSignResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    #endregion

                    GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
                    
                    object goodsPriceUWork;
                    paraGoodsPriceUWork.EnterpriseCode = wkstockSignResultWork.EnterpriseCode;
                    paraGoodsPriceUWork.GoodsNo = wkstockSignResultWork.GoodsNo;
                    paraGoodsPriceUWork.GoodsMakerCd = wkstockSignResultWork.GoodsMakerCd;

                    //if (!myReader.IsClosed) myReader.Close();
                    status = goodsPriceUDB.Search(out goodsPriceUWork, paraGoodsPriceUWork, readMode, logicalMode);

                    ArrayList goodsPriceUWorkList = goodsPriceUWork as ArrayList;
                    DateTime today = DateTime.Now;
                    for (int i = 0; i < goodsPriceUWorkList.Count; i++)
                    {
                        GoodsPriceUWork work = goodsPriceUWorkList[i] as GoodsPriceUWork;

                        if (work.PriceStartDate < today)
                        {
                            wkstockSignResultWork.ListPrice = work.ListPrice;
                        }
                        else
                        {
                            break;
                        }
                    }

                    al.Add(wkstockSignResultWork);
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "publicationConfResultWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockSignOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockSignOrderCndtnWork _stockSignOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " STO.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.EnterpriseCode);

            // 論理削除区分
            retstring += " AND STO.LOGICALDELETECODERF = 0" + Environment.NewLine;

            // 拠点コード
            if (_stockSignOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockSignOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND STO.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // 倉庫コード
            if (_stockSignOrderCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STO.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.St_WarehouseCode);
            }
            if (_stockSignOrderCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STO.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.Ed_WarehouseCode);
            }

            // メーカーコード
            if (_stockSignOrderCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STO.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockSignOrderCndtnWork.St_GoodsMakerCd);
            }
            if (_stockSignOrderCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STO.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockSignOrderCndtnWork.Ed_GoodsMakerCd);
            }

            // 倉庫棚番
            if (_stockSignOrderCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STO.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockSignOrderCndtnWork.Ed_WarehouseShelfNo != "")
            {
                if (_stockSignOrderCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND STO.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND (STO.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR STO.WAREHOUSESHELFNORF IS NULL)" + Environment.NewLine;
                }
                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.Ed_WarehouseShelfNo);
            }

            // 品番
            if (_stockSignOrderCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STO.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.St_GoodsNo);
            }
            if (_stockSignOrderCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STO.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockSignOrderCndtnWork.Ed_GoodsNo);
            }

            // 印刷順
            if (_stockSignOrderCndtnWork.PrintType == 1)
            {
                retstring += " AND STO.SUPPLIERSTOCKRF > 0" + Environment.NewLine;
            }
            #endregion
            return retstring;
        }
    }
}


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
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫過剰一覧表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫過剰一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.11.07</br>
	/// <br></br>
	/// <br>Update Note: 2008.03.26 佐々木 健</br>
	/// <br>           : 商品コードの絞り込みを修正</br>
    /// <br>Update Note: 2008.07.14 森本 大輝</br>
    /// <br>           : PM.NS対応</br>
    /// <br>Update Note: 2009.04.23 長内 数馬</br>
    /// <br>           : MANTIS対応</br>
    /// <br>Update Note: 2009.05.28 長内 数馬</br>
    /// <br>           : MANTIS対応 12777</br>
    /// <br>Update Note: 2011/03/16 長内 数馬</br>
    /// <br>           : 速度チューニング リアル集計時の使用メソッドを変更</br>
    /// <br>Update Note: 2012/12/19 gezh</br>
    /// <br>           : 2013/01/16配信分　Redmine#33976 仕入先別過剰在庫一覧表の修正</br>
    /// </remarks>
    [Serializable]
    public class StockOverListWorkDB : RemoteDB, IStockOverListWorkDB
    {
        /// <summary>
        /// 在庫過剰一覧表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.07</br>
        /// </remarks>
        public StockOverListWorkDB()
            :
        base("DCZAI02193D", "Broadleaf.Application.Remoting.ParamData.StockOverListResultWork", "STOCKRF") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードの在庫過剰一覧表LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="stockOverListResultWork">検索結果</param>
        /// <param name="stockOverListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫過剰一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.07</br>
        public int Search(out object stockOverListResultWork, object stockOverListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockOverListResultWork = null;

            StockOverListCndtnWork _stockOverListCndtnWork = stockOverListCndtnWork as StockOverListCndtnWork;

            try
            {
                status = SearchProc(out stockOverListResultWork, _stockOverListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockOverListWorkDB.Search Exception=" + ex.Message);
                stockOverListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの在庫過剰一覧表LISTを全て戻します
        /// </summary>
        /// <param name="stockOverListResultWork">検索結果</param>
        /// <param name="_stockOverListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫過剰一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.11.07</br>
        /// <br>Update Note: 23015 森本 大輝</br>
        /// <br>Date       : 2008.07.14</br>
        private int SearchProc(out object stockOverListResultWork, StockOverListCndtnWork _stockOverListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockOverListResultWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return status;

            //SQL文生成
            sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();

            ArrayList stockOverList = new ArrayList();
            ArrayList retstockOverList = new ArrayList();
            Dictionary<string, StockHistoryWork> stockHisDic = new Dictionary<string, StockHistoryWork>();


            try
            {
                //在庫マスタ取得&月次済み在庫履歴の取得
                status = SearchStockProc(ref stockOverList, _stockOverListCndtnWork, readMode, logicalMode, ref sqlConnection);

                //在庫マスタから情報が取得出来ない場合は
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                //未出荷指定有りの場合のみ、月次未処理月のリアル集計より出荷回数を取得する
                if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                {
                    //リアル集計対象在庫履歴を取得
                    status = SearchStockHistory(ref stockHisDic, _stockOverListCndtnWork, ref sqlConnection);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

                    //在庫履歴のリアル集計結果を結果リストに格納
                    CopyToStockOverListResultWorkFromStockHistoryWork(ref stockOverList, stockHisDic);
                }

                //過剰在庫、未出荷指定の場合の判定
                foreach (StockOverListResultWork retWork in stockOverList)
                {
                    //過剰在庫か、あるいは指定月数未出荷の場合に抽出対象とする
                    if ( (retWork.MaximumStockCnt < retWork.ShipmentPosCnt) ||
                         ((_stockOverListCndtnWork.NoShipmentDiv != 0) && (retWork.SalesTimes <= 0))
                        )
                    {
                        retstockOverList.Add(retWork);
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
                base.WriteErrorLog(ex, "StockOverListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            stockOverListResultWork = retstockOverList;

            return status;
        }

        /// <summary>
        /// 指定された企業コードの在庫過剰一覧表LISTを全て戻します
        /// </summary>
        /// <param name="retStockOverList">検索結果</param>
        /// <param name="_stockOverListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫過剰一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.04.23</br>
        private int SearchStockProc(ref ArrayList retStockOverList, StockOverListCndtnWork _stockOverListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select文作成
                //結果取得
                //在庫マスタ取得項目
                selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "　STOCK.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,WAH.WAREHOUSENAMERF" + Environment.NewLine;
                //selectTxt += " ,GDSM.SUPPLIERCDRF" + Environment.NewLine;
                //selectTxt += " ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += " ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;

                if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                {
                    selectTxt += " ,HISSUB.SALESTIMES" + Environment.NewLine;
                }
                
                // -- UPD 2011/03/16 --------------------->>>
                //selectTxt += " FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 ---------------------<<<
                ////拠点情報設定マスタ
                //selectTxt += " LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                //selectTxt += " ON  SECI.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SECI.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                ////商品管理情報マスタ
                //selectTxt += " LEFT JOIN GOODSMNGRF GDSM" + Environment.NewLine;
                //selectTxt += " ON  GDSM.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND GDSM.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                //selectTxt += " AND GDSM.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                //selectTxt += " AND GDSM.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;
                //倉庫マスタ
                // -- UPD 2011/03/16 -------------------------->>>
                //selectTxt += " LEFT JOIN WAREHOUSERF WAH" + Environment.NewLine;
                selectTxt += " LEFT JOIN WAREHOUSERF WAH WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 --------------------------<<<
                selectTxt += " ON  WAH.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WAH.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " AND WAH.LOGICALDELETECODERF = 0" + Environment.NewLine;
                ////仕入先マスタ
                //selectTxt += " LEFT JOIN SUPPLIERRF SUP" + Environment.NewLine;
                //selectTxt += " ON  SUP.ENTERPRISECODERF = GDSM.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SUP.SUPPLIERCDRF = GDSM.SUPPLIERCDRF" + Environment.NewLine;
                //商品マスタ
                // -- UPD 2011/03/16 -------------------------->>>
                //selectTxt += " LEFT JOIN GOODSURF GDSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GDSU WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 --------------------------<<<
                selectTxt += " ON  GDSU.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;

                //未出荷指定判断
                if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                {
                    //在庫履歴データ
                    selectTxt += "LEFT JOIN" + Environment.NewLine;
                    selectTxt += "(" + Environment.NewLine;
                    selectTxt += "SELECT" + Environment.NewLine;
                    selectTxt += "  HIS.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.WAREHOUSECODERF" + Environment.NewLine;
                    //selectTxt += " ,HIS.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSNORF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " ,SUM(HIS.SALESTIMESRF) AS SALESTIMES" + Environment.NewLine;
                    // -- UPD 2011/03/16 -------------------------->>>
                    //selectTxt += "FROM STOCKHISTORYRF AS HIS" + Environment.NewLine;
                    selectTxt += "FROM STOCKHISTORYRF AS HIS WITH (READUNCOMMITTED)" + Environment.NewLine;
                    // -- UPD 2011/03/16 --------------------------<<<
                    selectTxt += MakeWhereStringHIS(ref sqlCommand, _stockOverListCndtnWork, logicalMode);
                    selectTxt += "GROUP BY" + Environment.NewLine;
                    selectTxt += "  HIS.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.WAREHOUSECODERF" + Environment.NewLine;
                    //selectTxt += " ,HIS.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSNORF" + Environment.NewLine;
                    selectTxt += " ,HIS.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += ") AS HISSUB" + Environment.NewLine;
                    selectTxt += "ON" + Environment.NewLine;
                    selectTxt += "     HISSUB.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    //selectTxt += " AND HISSUB.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                    selectTxt += " AND HISSUB.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                    selectTxt += " AND HISSUB.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += " AND HISSUB.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                }

                #endregion

                sqlCommand.CommandText = selectTxt;

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockOverListCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockOverListResultWork wkStockOverListResultWork = new StockOverListResultWork();

                    //格納項目
                    //wkStockOverListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //wkStockOverListResultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockOverListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockOverListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    //wkStockOverListResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //wkStockOverListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockOverListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockOverListResultWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkStockOverListResultWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkStockOverListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockOverListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockOverListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockOverListResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockOverListResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockOverListResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockOverListResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkStockOverListResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    wkStockOverListResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkStockOverListResultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    wkStockOverListResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    if (_stockOverListCndtnWork.NoShipmentDiv != 0)
                    {
                        wkStockOverListResultWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                    }

                    #endregion

                    retStockOverList.Add(wkStockOverListResultWork);

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
                base.WriteErrorLog(ex, "StockOverListWorkDB.SearchStockProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
                    myReader = null;
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }


        /// <summary>
        /// 在庫履歴リアル集計処理
        /// </summary>
        /// <param name="retStockHisDic">検索結果</param>
        /// <param name="_stockOverListCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫過剰一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.04.23</br>
        private int SearchStockHistory(ref Dictionary<string,StockHistoryWork> retStockHisDic, StockOverListCndtnWork _stockOverListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            try
            {
                //最終月次締年月を取得
                DateTime lastStockHisYm = GetLastStockHisYm(_stockOverListCndtnWork.EnterpriseCode, ref sqlConnection);

                DateTime st_Ym = DateTime.MinValue;

                if (lastStockHisYm == DateTime.MinValue)
                {
                    //一度も月次がかけられていない場合
                    st_Ym = _stockOverListCndtnWork.St_AddUpYearMonth;
                }
                else
                {
                    //月次済みの履歴はSearchStockProc内で取得しているため、それ以降をリアル集計対象とする。
                    st_Ym = lastStockHisYm.AddMonths(1);
                    
                    // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                    //リアル集計対象月よりも画面指定開始月の方が大きい場合は、画面指定開始月をリアル集計開始月とする
                    if (st_Ym.Year * 100 + st_Ym.Month < _stockOverListCndtnWork.St_AddUpYearMonth.Year * 100 + _stockOverListCndtnWork.St_AddUpYearMonth.Month)
                    {
                        st_Ym = _stockOverListCndtnWork.St_AddUpYearMonth;
                    }
                    // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                }

                //日付取得部品用に日付を１日変更
                st_Ym = new DateTime(st_Ym.Year, st_Ym.Month, 1);

                DateTime ed_Ym = _stockOverListCndtnWork.Ed_AddUpYearMonth;

                //月次未集計の対象期間
                Int32 monthRange = ((ed_Ym.Year) - (st_Ym.Year)) * 12 + (ed_Ym.Month) - (st_Ym.Month) + 1;

                ArrayList companyInfList = new ArrayList();
                CompanyInfWork companyInfWork = new CompanyInfWork();

                //自社情報読み込み
                CompanyInfDB companyInfDB = new CompanyInfDB();
                companyInfWork.EnterpriseCode = _stockOverListCndtnWork.EnterpriseCode;
                status = companyInfDB.Search(out companyInfList, companyInfWork, ref sqlConnection);
                companyInfWork = companyInfList[0] as CompanyInfWork;


                MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();

                //リアル集計の対象期間がある場合
                if (monthRange > 0)
                {
                    for (int i = 0; i < monthRange; i++)
                    {
                        //自社情報より、対象年月の開始終了日を取得
                        DateTime monthStart = DateTime.MinValue;
                        DateTime monthEnd = DateTime.MinValue;

                        FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                        finYearTableGenerator.GetDaysFromMonth(st_Ym, out monthStart, out monthEnd);

                        //リアル集計メソッド呼び出し
                        MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork(); //月次集計メソッド用パラメータ
                        monthlyAddUpWork.EnterpriseCode = _stockOverListCndtnWork.EnterpriseCode;
                        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //monthlyAddUpWork.AddUpDateSt = monthStart;    //月次開始日付をセット
                        monthlyAddUpWork.AddUpDateSt = monthStart.AddDays(-1);    //月次開始日付をセット
                        // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        monthlyAddUpWork.AddUpDateEd = monthEnd;
                        monthlyAddUpWork.AddUpDate = monthEnd;        //月次終了日付をセット
                        monthlyAddUpWork.LstMonAddUpProcDay = st_Ym.AddMonths(-1);  //前回履歴取得用に前月をセット
                        monthlyAddUpWork.AddUpYearMonth = st_Ym;

                        List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
                        // -- UPD 2011/03/16 ---------------------------------->>>
                        //string retMsg = null;
                        //bool msgDiv = true;

                        //status = monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                        status = GetSalesTimesProc(ref stockHistoryWorkList, monthlyAddUpWork, _stockOverListCndtnWork, ref sqlConnection);
                        // -- UPD 2011/03/16 ----------------------------------<<<
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //結果を格納
                            foreach (StockHistoryWork sthisWork in stockHistoryWorkList)
                            {
                                string keyString = sthisWork.WarehouseCode.Trim() + sthisWork.GoodsNo + sthisWork.GoodsMakerCd.ToString("0000");

                                if (retStockHisDic.ContainsKey(keyString))
                                {
                                    //既に存在した場合は加算
                                    (retStockHisDic[keyString] as StockHistoryWork).SalesTimes += sthisWork.SalesTimes;
                                }
                                else
                                {
                                    //存在しなかった場合は追加
                                    retStockHisDic.Add(keyString,sthisWork);
                                }
                            }

                        }
                        else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                         (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            //NOT_FOUND,EOFの場合は次へ
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else
                        {
                            //取得失敗
                            // -- UPD 2011/03/16 ----------------->>>
                            ////throw new Exception("在庫履歴集計モジュールからの取得に失敗。");
                            return status;
                            // -- UPD 2011/03/16 -----------------<<<
                        }

                        st_Ym = st_Ym.AddMonths(1);

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
                base.WriteErrorLog(ex, "StockOverListWorkDB.SearchStockHistory Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion


        /// <summary>
        /// 結果リスト生成処理
        /// </summary>
        /// <param name="retStockOverList">在庫リスト</param>
        /// <param name="stockHisDic">リアル集計分在庫履歴リスト</param>
        /// <returns>RsltInfo_PrevYearComparisonWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.04.23</br>
        /// <br></br>
        /// </remarks>
        private void CopyToStockOverListResultWorkFromStockHistoryWork(ref ArrayList retStockOverList, Dictionary<string,StockHistoryWork> stockHisDic)
        {
            foreach (StockOverListResultWork retWork in retStockOverList)
            {
                string keyString = retWork.WarehouseCode.Trim() + retWork.GoodsNo + retWork.GoodsMakerCd.ToString("0000");

                if (stockHisDic.ContainsKey(keyString))
                {
                    //リアル集計結果に該当した場合は、売上回数を加算
                    retWork.SalesTimes += (stockHisDic[keyString] as StockHistoryWork).SalesTimes;
                }
            }

        }

        /// <summary>
        /// 最終の在庫履歴レコード年月を戻します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最終の在庫履歴レコード年月を戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.04.23</br>
        /// <br></br>
        private DateTime GetLastStockHisYm(string enterpriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            DateTime retYm = DateTime.MinValue;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "  MAX(STOCKHIS.ADDUPYEARMONTHRF) AS ADDUPYEARMONTHRF" + Environment.NewLine;
                // -- UPD 2011/03/16 --------------------------->>>
                //selectTxt += " FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine;
                selectTxt += " FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/16 ---------------------------<<<
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += " STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //最終計上年月を取得
                    retYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                }

                //取得出来ない場合も正常とする
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockListWorkDB.GetLastStockHisYm Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();

                myReader = null;
            }
            return retYm;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockOverListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Update Note: 2012/12/19 gezh</br>
        /// <br>           : 2013/01/16配信分　Redmine#33976 仕入先別過剰在庫一覧表の修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockOverListCndtnWork _stockOverListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            //企業コード
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            ////拠点コード    ※配列で複数指定される
            //if (_stockOverListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockOverListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            //在庫登録日設定
            if (_stockOverListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                int startymdStockCreateDate = TDateTime.DateTimeToLongDate(_stockOverListCndtnWork.StockCreateDate);
                if (_stockOverListCndtnWork.StockCreateDateDiv == 0)
                {
                    //retstring += " AND STOCK.STOCKCREATEDATERF <= " + startymdStockCreateDate.ToString();  // DEL gezh 2012/12/19 for Redmine#33976
                    retstring += " AND ISNULL(STOCK.STOCKCREATEDATERF,0) <= " + startymdStockCreateDate.ToString();  // ADD gezh 2012/12/19 for Redmine#33976
                }
                else
                {
                    retstring += " AND STOCK.STOCKCREATEDATERF >= " + startymdStockCreateDate.ToString();
                }
            }

            //倉庫コード設定
            if (_stockOverListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseCode);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseCode);
            }

            ////仕入先コード設定
            //if (_stockOverListCndtnWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND SUP.SUPPLIERCDRF>=@STSTOCKSUPPLIERCODE";
            //    SqlParameter paraStStockSupplierCode = sqlCommand.Parameters.Add("@STSTOCKSUPPLIERCODE", SqlDbType.Int);
            //    paraStStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_SupplierCd);
            //}
            //if (_stockOverListCndtnWork.Ed_SupplierCd != 999999)
            //{
            //    retstring += " AND SUP.SUPPLIERCDRF<=@EDSTOCKSUPPLIERCODERF";
            //    SqlParameter paraEdStockSupplierCode = sqlCommand.Parameters.Add("@EDSTOCKSUPPLIERCODERF", SqlDbType.Int);
            //    paraEdStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_SupplierCd);
            //}

            //メーカーコード設定
            if (_stockOverListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockOverListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_GoodsMakerCd);
            }

            //棚番設定
            if (_stockOverListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO";
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                if (_stockOverListCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO";
                }
                else
                {
                    retstring += " AND (STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR STOCK.WAREHOUSESHELFNORF IS NULL)";
                }

                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseShelfNo + "%");
            }

            //商品番号設定
            if (_stockOverListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_GoodsNo);
            }
            if (_stockOverListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
				paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo);
			}

            //商品区分設定
            if (_stockOverListCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE";
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_EnterpriseGanreCode);
            }
            if (_stockOverListCndtnWork.Ed_EnterpriseGanreCode != 9999)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE";
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_EnterpriseGanreCode);
            }

            //BL商品コード設定
            if (_stockOverListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODERF";
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STBLGOODSCODERF", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_BLGoodsCode);
            }
            if (_stockOverListCndtnWork.Ed_BLGoodsCode != 99999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODERF";
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDBLGOODSCODERF", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_BLGoodsCode);
            }

            //部品管理区分１  ※配列で複数指定される
            if (_stockOverListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockOverListCndtnWork.PartsManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ";
                }
            }

            //部品管理区分２  ※配列で複数指定される
            if (_stockOverListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockOverListCndtnWork.PartsManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ";
                }
            }

            ////過剰在庫判断(最高在庫数＜出荷可能数)
            //retstring += " AND STOCK.MAXIMUMSTOCKCNTRF<STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;

            ////未出荷在庫判断
            //if (_stockOverListCndtnWork.NoShipmentDiv != 0)
            //{
            //    retstring += " AND (HISSUB.SALESTIMES<=0 OR HISSUB.SALESTIMES IS NULL)" + Environment.NewLine;
            //}

            #endregion
            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockOverListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereStringHIS(ref SqlCommand sqlCommand, StockOverListCndtnWork _stockOverListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            //企業コード
            retstring += " HIS.ENTERPRISECODERF=@@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND HIS.LOGICALDELETECODERF=@@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND HIS.LOGICALDELETECODERF<@@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            ////拠点コード    ※配列で複数指定される
            //if (_stockOverListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockOverListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND HIS.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            //倉庫コード設定
            if (_stockOverListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND HIS.WAREHOUSECODERF>=@@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseCode);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND HIS.WAREHOUSECODERF<=@@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseCode);
            }

            //メーカーコード設定
            if (_stockOverListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND HIS.GOODSMAKERCDRF>=@@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockOverListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND HIS.GOODSMAKERCDRF<=@@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_GoodsMakerCd);
            }

            //商品番号設定
            if (_stockOverListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND HIS.GOODSNORF>=@@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_GoodsNo);
            }
            if (_stockOverListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND HIS.GOODSNORF<=@@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@@EDGOODSNO", SqlDbType.NVarChar);

				// 2008.03.26 >>
                //paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo + "%");
				paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo);
				// 2008.03.26 <<
			}

            //年月度設定
            if (_stockOverListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND HIS.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockOverListCndtnWork.St_AddUpYearMonth);
            }
            if (_stockOverListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND HIS.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockOverListCndtnWork.Ed_AddUpYearMonth);
            }
            
            #endregion
            return retstring;
        }

        // -- ADD 2011/03/16 ------------------------------>>>
        /// <summary>
        /// 指定された企業コードの在庫過剰一覧表LISTを全て戻します
        /// </summary>
        /// <param name="retStockOverList">検索結果</param>
        /// <param name="_stockOverListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの在庫過剰一覧表LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.04.23</br>
        private int GetSalesTimesProc(ref List<StockHistoryWork> retStockHistoryList, MonthlyAddUpWork monthlyAddUpWork, StockOverListCndtnWork _stockOverListCndtnWork,  ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select文作成
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSNORF," + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=20 AND STPAYCNT.ACPAYTRANSCDRF=10) AND DELSLIPNUM IS NULL) THEN 1 ELSE 0 END) AS SALESTIMESRF--売上回数" + Environment.NewLine;
                selectTxt += "   FROM  " + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "      SELECT " + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYSLIPNUMRF, --伝票番号" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYSLIPCDRF,  --受払元伝票区分" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYTRANSCDRF,  --受払元取引区分" + Environment.NewLine;
                selectTxt += "       DELSTOCKACPAYHIST.ACPAYSLIPNUMRF AS DELSLIPNUM --伝票番号" + Environment.NewLine;
                selectTxt += "      FROM" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "     LEFT JOIN" + Environment.NewLine;
                selectTxt += "      (" + Environment.NewLine;
                selectTxt += "        SELECT" + Environment.NewLine;
                selectTxt += "         LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "         ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "         WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "         GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "         GOODSNORF," + Environment.NewLine;
                selectTxt += "         ACPAYSLIPNUMRF --受払元伝票番号" + Environment.NewLine;
                selectTxt += "        FROM" + Environment.NewLine;
                selectTxt += "         STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "        WHERE" + Environment.NewLine;
                selectTxt += "            ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                selectTxt += "        AND ACPAYTRANSCDRF = 21 " + Environment.NewLine;
                selectTxt += "      ) AS DELSTOCKACPAYHIST" + Environment.NewLine;
                selectTxt += "       ON  STOCKACPAYHIST.ENTERPRISECODERF = DELSTOCKACPAYHIST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.WAREHOUSECODERF = DELSTOCKACPAYHIST.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.GOODSMAKERCDRF = DELSTOCKACPAYHIST.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.GOODSNORF = DELSTOCKACPAYHIST.GOODSNORF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.ACPAYSLIPNUMRF = DELSTOCKACPAYHIST.ACPAYSLIPNUMRF          " + Environment.NewLine;
                selectTxt += "      WHERE STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >@FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                selectTxt += "   ) AS STPAYCNT" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereStringSalesTime(ref sqlCommand, monthlyAddUpWork, _stockOverListCndtnWork);

                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSNORF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                #endregion



                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    StockHistoryWork stockhisWork = new StockHistoryWork();

                    //格納項目
                    stockhisWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockhisWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockhisWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockhisWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));

                    #endregion

                    retStockHistoryList.Add(stockhisWork);

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
                base.WriteErrorLog(ex, "StockOverListWorkDB.GetSalesTimesProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
                    myReader = null;
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_stockOverListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereStringSalesTime(ref SqlCommand sqlCommand, MonthlyAddUpWork monthlyAddUpWork, StockOverListCndtnWork _stockOverListCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE " + Environment.NewLine;

            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaAddUpDateSt = sqlCommand.Parameters.Add("@FINDADDUPDATEST", SqlDbType.Int);
            SqlParameter findParaAddUpDateEd = sqlCommand.Parameters.Add("@FINDADDUPDATEED", SqlDbType.Int);

            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.EnterpriseCode);
            findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDateSt);
            findParaAddUpDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDate);

            //企業コード
            retstring += " STPAYCNT.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

            //倉庫コード設定
            if (_stockOverListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STPAYCNT.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_WarehouseCode);
            }
            if (_stockOverListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STPAYCNT.WAREHOUSECODERF<=@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_WarehouseCode);
            }

            //メーカーコード設定
            if (_stockOverListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STPAYCNT.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockOverListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STPAYCNT.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockOverListCndtnWork.Ed_GoodsMakerCd);
            }

            //商品番号設定
            if (_stockOverListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STPAYCNT.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.St_GoodsNo);
            }
            if (_stockOverListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STPAYCNT.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockOverListCndtnWork.Ed_GoodsNo);
            }
            #endregion
            return retstring;
        }
        // -- ADD 2011/03/16 ------------------------------<<<

    }

}

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library;
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
    /// 自動発注（発注点）DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自動発注（発注点）の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2007.10.23</br>
    /// <br></br>
    /// <br>Update Note: 商品マスタ、商品管理情報マスタの結合条件に論理削除区分を追加</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/16</br>
    /// <br></br>
    /// <br>Update Note: READUNCOMMITTED対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/09</br>
    /// </remarks>
    [Serializable]
    public class OrderPointOrderWorkDB : RemoteDB, IOrderPointOrderWorkDB
    {
        /// <summary>
        /// 自動発注（発注点）DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.10.23</br>
        /// </remarks>
        public OrderPointOrderWorkDB()
            :
        base("DCHAT01213D", "Broadleaf.Application.Remoting.ParamData.AutoOrderResultWork", "STOCKRF") //基底クラスのコンストラクタ
        {
        }

        #region 自動発注（発注点）
        /// <summary>
        /// 指定された企業コードの自動発注（発注点）LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="orderPointOrderResultWork">検索結果</param>
        /// <param name="orderPointOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの自動発注（発注点）LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.10.23</br>
        public int Search(out object autoOrderResultWork, object orderPointOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            autoOrderResultWork = null;

            OrderPointOrderCndtnWork _orderPointOrderCndtnWork = orderPointOrderCndtnWork as OrderPointOrderCndtnWork;

            try
            {
                status = SearchProc(out autoOrderResultWork, _orderPointOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointOrderWorkDB.Search Exception=" + ex.Message);
                autoOrderResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの自動発注（発注点）LISTを全て戻します
        /// </summary>
        /// <param name="orderPointOrderResultWork">検索結果</param>
        /// <param name="_orderPointOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの自動発注（発注点）LISTを全て戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2007.10.23</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.23 長内 DC.NS用に修正</br>
        private int SearchProc(out object autoOrderResultWork, OrderPointOrderCndtnWork _orderPointOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            autoOrderResultWork = null;

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


                status = SearchOrderPointOrderProc(ref al, ref sqlConnection, _orderPointOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            autoOrderResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderBrokenListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderPointOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, OrderPointOrderCndtnWork _orderPointOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,MAK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "  ,GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,GOODSM.SUPPLIERLOTRF" + Environment.NewLine;
                selectTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                //selectTxt += "  ,STOCK.AUTOORDERCOUNTRF" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                //商品管理情報マスタ
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += "LEFT JOIN GOODSMNGRF AS GOODSM" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSMNGRF AS GOODSM WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     GOODSM.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSM.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " AND GOODSM.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSM.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                // 2009/10/16 Add >>>
                selectTxt += " AND GOODSM.LOGICALDELETECODERF=0" + Environment.NewLine;
                // 2009/10/16 Add <<<
                //メーカーマスタ
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += "LEFT JOIN MAKERURF AS MAK" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     MAK.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAK.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                //商品マスタ
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     GOODS.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                // 2009/10/16 Add >>>
                selectTxt += " AND GOODS.LOGICALDELETECODERF=0" + Environment.NewLine;
                // 2009/10/16 Add <<<
                //拠点情報マスタ
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SEC.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                //倉庫マスタ
                // -- UPD 2010/06/09 ------------------------------------------>>>
                //selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 ------------------------------------------<<<
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     WARE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WARE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _orderPointOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    AutoOrderResultWork wkAutoOrderResultWork = new AutoOrderResultWork();
                    
                    //格納項目
                    wkAutoOrderResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkAutoOrderResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkAutoOrderResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkAutoOrderResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkAutoOrderResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkAutoOrderResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkAutoOrderResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    wkAutoOrderResultWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    wkAutoOrderResultWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    wkAutoOrderResultWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    wkAutoOrderResultWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    wkAutoOrderResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkAutoOrderResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkAutoOrderResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkAutoOrderResultWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    wkAutoOrderResultWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    wkAutoOrderResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkAutoOrderResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkAutoOrderResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkAutoOrderResultWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    wkAutoOrderResultWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    wkAutoOrderResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkAutoOrderResultWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    wkAutoOrderResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkAutoOrderResultWork.SupplierLot = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERLOTRF"));
                    //wkAutoOrderResultWork.AutoOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("AUTOORDERCOUNTRF"));
                    wkAutoOrderResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));

                    #endregion

                    double standardCnt = wkAutoOrderResultWork.ShipmentPosCnt;

                    // 2008.12.10 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 帳票タイプ区分PrtPaperTypeDiv(0:発注一覧表,1:発注残一覧表) で処理を分ける
                    switch (_orderPointOrderCndtnWork.PrtPaperTypeDiv)
                    {
                        case 0:     // 0:発注一覧表
                            {
                                //現在庫数基準（0:ﾏｲﾅｽはｾﾞﾛで計算する）
                                if ((_orderPointOrderCndtnWork.StkCntStandard == 0) && (standardCnt < 0))
                                {
                                    standardCnt = 0;
                                }

                                //現在庫数＋発注残
                                standardCnt += wkAutoOrderResultWork.SalesOrderCount;

                                //貸出数計算(0:する)
                                if (_orderPointOrderCndtnWork.LendCntCalc == 0)
                                {
                                    standardCnt += wkAutoOrderResultWork.ShipmentCnt;
                                }

                                double orderPoint;

                                //発注基準
                                if (_orderPointOrderCndtnWork.OrderStandard == 0)
                                {
                                    //発注点最低在庫数
                                    orderPoint = wkAutoOrderResultWork.MinimumStockCnt;
                                }
                                else
                                {
                                    //発注点最高在庫数
                                    orderPoint = wkAutoOrderResultWork.MaximumStockCnt;
                                }

                                if (standardCnt < orderPoint)
                                {
                                    wkAutoOrderResultWork.AutoOrderCount = CalculateConsTax.Fraction(wkAutoOrderResultWork.MaximumStockCnt - standardCnt, -13); //-13:円未満切り上げ(小数第一位を処理する)

                                    al.Add(wkAutoOrderResultWork);
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                break;
                            }
                        case 1:     // 1:発注残一覧表
                            {
                                // 発注数(発注残)が0以外の場合に抽出
                                if (wkAutoOrderResultWork.SalesOrderCount != 0)
                                {
                                    al.Add(wkAutoOrderResultWork);
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                break;
                            }
                    }

                    /*
                    //現在庫数基準（0:ﾏｲﾅｽはｾﾞﾛで計算する）
                    if ((_orderPointOrderCndtnWork.StkCntStandard == 0) && (standardCnt < 0))
                    {
                        standardCnt = 0;
                    }

                    //現在庫数＋発注残
                    standardCnt += wkAutoOrderResultWork.SalesOrderCount;

                    //貸出数計算(0:する)
                    if (_orderPointOrderCndtnWork.LendCntCalc == 0)
                    {
                        standardCnt += wkAutoOrderResultWork.ShipmentCnt;
                    }

                    double orderPoint;

                    //発注基準
                    if (_orderPointOrderCndtnWork.OrderStandard == 0)
                    {
                        //発注点最低在庫数
                        orderPoint = wkAutoOrderResultWork.MinimumStockCnt;
                    }
                    else
                    {
                        //発注点最高在庫数
                        orderPoint = wkAutoOrderResultWork.MaximumStockCnt;
                    }

                    if (standardCnt < orderPoint)
                    {
                        wkAutoOrderResultWork.AutoOrderCount = wkAutoOrderResultWork.MaximumStockCnt - standardCnt;

                        al.Add(wkAutoOrderResultWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    */
                    // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OrderPointOrderWorkDB.SearchOrderPointOrderProc Exception=" + ex.Message);
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
        /// <param name="_orderPointOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, OrderPointOrderCndtnWork _orderPointOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            //企業コード
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_orderPointOrderCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード
            if (_orderPointOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _orderPointOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }

            //倉庫コード設定
            if (_orderPointOrderCndtnWork.WarehouseCodes != null)
            {
                string warehouseCodestr = "";
                foreach (string warecdstr in _orderPointOrderCndtnWork.WarehouseCodes)
                {
                    if (warehouseCodestr != "")
                    {
                        warehouseCodestr += ",";
                    }
                    warehouseCodestr += "'" + warecdstr + "'";
                }

                if (warehouseCodestr != "")
                {
                    retstring += " AND STOCK.WAREHOUSECODERF IN (" + warehouseCodestr + ") " + Environment.NewLine;
                }
            }
            else
            {
                if (_orderPointOrderCndtnWork.St_WarehouseCode != "")
                {
                    retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                    SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                    paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_orderPointOrderCndtnWork.St_WarehouseCode);
                }
                if (_orderPointOrderCndtnWork.Ed_WarehouseCode != "")
                {
                    retstring += " AND (STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STOCK.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine;
                    SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                    paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_orderPointOrderCndtnWork.Ed_WarehouseCode + "%");
                }
            }

            //仕入先コード設定
            if (_orderPointOrderCndtnWork.SupplierCodes != null)
            {
                string suppliserCodestr = "";
                foreach (int supcdstr in _orderPointOrderCndtnWork.SupplierCodes)
                {
                    if (suppliserCodestr != "")
                    {
                        suppliserCodestr += ",";
                    }
                    suppliserCodestr += "'" + supcdstr + "'";
                }

                if (suppliserCodestr != "")
                {
                    retstring += " AND (STOCK.STOCKSUPPLIERCODERF IN (" + suppliserCodestr + ") OR STOCK.STOCKSUPPLIERCODERF=0)" + Environment.NewLine;
                }
            }
            else
            {
                string wkstring = string.Empty;
                if (_orderPointOrderCndtnWork.St_SupplierCode != 0)
                {
                    wkstring += " AND (STOCK.STOCKSUPPLIERCODERF>=@STSTOCKSUPPLIERCODE" + Environment.NewLine;
                    SqlParameter paraStSupplierCode = sqlCommand.Parameters.Add("@STSTOCKSUPPLIERCODE", SqlDbType.Int);
                    paraStSupplierCode.Value = SqlDataMediator.SqlSetInt32(_orderPointOrderCndtnWork.St_SupplierCode);
                }

                // 2008.12.10 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (wkstring != string.Empty)
                {
                    retstring += wkstring + " OR STOCK.STOCKSUPPLIERCODERF=0)" + Environment.NewLine;
                }

                wkstring = string.Empty;
                // 2008.12.10 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if (_orderPointOrderCndtnWork.Ed_SupplierCode != 0)
                {
                    wkstring += " AND (STOCK.STOCKSUPPLIERCODERF<=@EDSTOCKSUPPLIERCODE" + Environment.NewLine;
                    SqlParameter paraEdSupplierCode = sqlCommand.Parameters.Add("@EDSTOCKSUPPLIERCODE", SqlDbType.Int);
                    paraEdSupplierCode.Value = SqlDataMediator.SqlSetInt32(_orderPointOrderCndtnWork.Ed_SupplierCode);
                }

                if (wkstring != string.Empty)
                {
                    // 2008.12.10 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //retstring += retstring + " OR STOCK.STOCKSUPPLIERCODERF=0)" + Environment.NewLine;
                    retstring += wkstring + " OR STOCK.STOCKSUPPLIERCODERF=0)" + Environment.NewLine;
                    // 2008.12.10 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }

            // -- ADD 2010/06/09 -------------------------------->>>
            //受託在庫区分(0:発注対象としない)
            if (_orderPointOrderCndtnWork.TrustStockDiv == 0)
            {
                retstring += " AND STOCK.STOCKDIVRF=0" + Environment.NewLine;
            }

            if (_orderPointOrderCndtnWork.StkCntStandard == 1)
            {
                retstring += " AND (STOCK.MINIMUMSTOCKCNTRF<>0 OR STOCK.MAXIMUMSTOCKCNTRF <> 0)" + Environment.NewLine;
            }

            //商品マスタに未登録の場合は抽出しない
            retstring += " AND NOT GOODS.ENTERPRISECODERF IS NULL" + Environment.NewLine;
            // -- ADD 2010/06/09 --------------------------------<<<
            #endregion
            return retstring;
        }
    }
}

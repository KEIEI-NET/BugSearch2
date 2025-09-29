//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 型式別出荷実績表
// プログラム概要   : 型式別出荷実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//Update Note : 2010/05/07 王海立 redmine #7001
//              型式別出荷対応表の受注ステータスについて、仕様の変更
//Update Note : 2010/05/13 王海立 redmine #7109
//              ２点仕様変更の対応
//Update Note : 2010/05/16 王海立 redmine #7109
//              棚番と現在庫数印字
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhshh
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// Update Note : 2010.05.19 zhangsf Redmine #7784の対応
//             : ・型式別出荷対応表／各種修正
//----------------------------------------------------------------------------//
// Update Note : 2014/11/20 wujun
// 管理番号    : 11002003-00   Redmine#43035 #52既存障害の対応
//             : 伝票情報が全く同様な伝票が複数存在した場合、集計結果不正の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 型式別出荷実績表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 型式別出荷実績表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : zhshh</br>
    /// <br>Date       : 2010.04.22</br>
    /// </remarks>
    [Serializable]
    public class ModelShipResultDB : RemoteDB, IModelShipResultDB
    {
        /// <summary>
        /// 型式別出荷実績表コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// </remarks>
        public ModelShipResultDB()
            :
        base("PMSYA02209D", "Broadleaf.Application.Remoting.ParamData.ModelShipResultWork", "MODELSHIPRESULTWORK") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードの型式別出荷実績表を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="modelShipRsltCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの型式別出荷データを全て戻します（論理削除除く）</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/08 王海立 REDMINE #7109の対応</br>
        public int Search(out object modelShipResultWork, object modelShipRsltCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            modelShipResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                status = SearchProc(out modelShipResultWork, modelShipRsltCndtnWork, ref sqlConnection);

                // --- DEL 2010/05/08 ---------->>>>>
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    //対応品番の取得
                //    status = SearchGoodNoProc(ref modelShipResultWork, modelShipRsltCndtnWork, ref sqlConnection);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //    }
                //}
                // --- DEL 2010/05/08 ----------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ModelShipResultDB.Search");
                modelShipResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードの型式別出荷実績表を全て戻します
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="_modelShipRsltCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/16 王海立 在庫マスタを読み込む処理の追加</br>
        /// <br>Update Note: 2014/11/20 wujun</br>
        /// <br>管理番号   : 11002003-00　RedMine#43035 #52既存障害の対応</br>
        /// <br>         　: 伝票情報が全く同様な伝票が複数存在した場合、集計結果不正の対応</br>
        private int SearchProc(out object modelShipResultWork, object _modelShipRsltCndtnWork, ref SqlConnection sqlConnection)
        {
            ModelShipRsltCndtnWork modelShipRsltCndtnWork = _modelShipRsltCndtnWork as ModelShipRsltCndtnWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            modelShipResultWork = new ArrayList();
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append(" AA.SALESSLIPNUMRF SALESSLIPNUMRF, ");//売上伝票番号  //  ADD 2014/11/20 wujun FOR Redmine#43035
                sb.Append(" AA.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");//実績計上拠点コード
                sb.Append(" AA.SALESDATERF SALESDATERF, ");//売上日付
                sb.Append(" AB.SALESROWNORF SALESROWNORF, ");//売上行番号			
                sb.Append(" AB.GOODSKINDCODERF GOODSKINDCODERF, ");//商品属性			
                sb.Append(" AB.GOODSMAKERCDRF GOODSMAKERCDRF, ");//商品メーカーコード			
                sb.Append(" AB.GOODSNORF GOODSNORF, ");//商品番号			
                sb.Append(" AB.GOODSNAMEKANARF GOODSNAMERF, ");//商品名称カナ			
                sb.Append(" AB.BLGOODSCODERF BLGOODSCODERF, ");//BL商品コード			
                sb.Append(" AB.SALESUNPRCTAXEXCFLRF SALESUNPRCTAXEXCFLRF, ");//売上単価（税抜，浮動）			
                sb.Append(" AB.SHIPMENTCNTRF SHIPMENTCNTRF, ");//出荷数			
                sb.Append(" AB.SALESORDERDIVCDRF SALESORDERDIVCDRF, ");//売上在庫取寄せ区分			
                sb.Append(" AB.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, ");//売上金額（税抜き）			
                sb.Append(" SECINFOSETRF.SECTIONGUIDESNMRF SECTIONGUIDESNMRF, ");//拠点ガイド略称					
                sb.Append(" BLGOODSCDURF.BLGOODSHALFNAMERF BLGOODSHALFNAMERF, ");//BL商品コード名称（半角）	
                sb.Append(" AC.CARMNGNORF CARMNGNORF, ");//車両管理番号			
                sb.Append(" AC.MAKERCODERF MAKERCODERF, ");//メーカーコード			
                sb.Append(" AC.MODELCODERF MODELCODERF, ");//車種コード			
                sb.Append(" AC.MODELSUBCODERF MODELSUBCODERF, ");//車種サブコード			
                sb.Append(" AC.MODELHALFNAMERF MODELHALFNAMERF, ");//車種半角名称			
                sb.Append(" AC.SERIESMODELRF SERIESMODELRF, ");//シリーズ型式			
                sb.Append(" AC.CATEGORYSIGNMODELRF CATEGORYSIGNMODELRF, ");//型式（類別番号）			
                sb.Append(" AC.FULLMODELRF FULLMODELRF, ");//型式（フル）
                // --- ADD 2010/05/16 ---------->>>>>
                sb.Append(" STOCKRF.SUPPLIERSTOCKRF SUPPLIERSTOCKRF, ");//現在庫数
                sb.Append(" STOCKRF.WAREHOUSESHELFNORF WAREHOUSESHELFNORF, ");//棚番
                // --- ADD 2010/05/16 ----------<<<<<
                sb.Append(" MAKERURF.MAKERNAMERF MAKERNAMERF ");//メーカー名称(純正)

                sb.Append(" FROM ");
                //売上履歴データ
                sb.Append(" SALESHISTORYRF AA WITH (READUNCOMMITTED) ");
                //拠点情報設定マスタ
                sb.Append(" LEFT JOIN SECINFOSETRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON SECINFOSETRF.ENTERPRISECODERF = AA.ENTERPRISECODERF ");
                sb.Append(" AND SECINFOSETRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND SECINFOSETRF.SECTIONCODERF=AA.RESULTSADDUPSECCDRF ");
                //売上履歴明細データ
                sb.Append(" ,SALESHISTDTLRF AB WITH (READUNCOMMITTED) ");

                //ＢＬ商品コードマスタ(ユーザー)
                sb.Append(" LEFT JOIN BLGOODSCDURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON BLGOODSCDURF.ENTERPRISECODERF=AB.ENTERPRISECODERF ");
                sb.Append(" AND BLGOODSCDURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND BLGOODSCDURF.BLGOODSCODERF=AB.BLGOODSCODERF ");
                //メーカーマスタ
                sb.Append(" LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON MAKERURF.ENTERPRISECODERF=AB.ENTERPRISECODERF ");
                sb.Append(" AND MAKERURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND MAKERURF.GOODSMAKERCDRF=AB.GOODSMAKERCDRF ");
                // --- ADD 2010/05/16 ---------->>>>>
                //在庫マスタ
                sb.Append(" LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON STOCKRF.ENTERPRISECODERF=AB.ENTERPRISECODERF ");
                sb.Append(" AND STOCKRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND STOCKRF.GOODSMAKERCDRF=AB.GOODSMAKERCDRF ");
                sb.Append(" AND STOCKRF.GOODSNORF=AB.GOODSNORF ");
                sb.Append(" AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                // --- ADD 2010/05/16 ----------<<<<<
                //受注マスタ(車輌)
                sb.Append(" ,ACCEPTODRCARRF AC WITH (READUNCOMMITTED) ");

                sb.Append(MakeWhereStringA(ref sqlCommand, modelShipRsltCndtnWork));

                sb.Append(" UNION ");

                sb.Append("SELECT ");
                sb.Append(" CN.SALESSLIPNUMRF SALESSLIPNUMRF, ");//売上伝票番号  //  ADD 2014/11/20 wujun FOR Redmine#43035
                sb.Append(" CN.RESULTSADDUPSECCDRF RESULTSADDUPSECCDRF, ");//実績計上拠点コード
                sb.Append(" CN.SALESDATERF SALESDATERF, ");//売上日付
                sb.Append(" CN.SALESROWNORF SALESROWNORF, ");//売上行番号			
                sb.Append(" CN.GOODSKINDCODERF GOODSKINDCODERF, ");//商品属性			
                sb.Append(" CN.GOODSMAKERCDRF GOODSMAKERCDRF, ");//商品メーカーコード			
                sb.Append(" CN.GOODSNORF GOODSNORF, ");//商品番号			
                sb.Append(" CN.GOODSNAMERF GOODSNAMERF, ");//商品名称			
                sb.Append(" CN.BLGOODSCODERF BLGOODSCODERF, ");//BL商品コード			
                sb.Append(" CN.SALESUNPRCTAXEXCFLRF SALESUNPRCTAXEXCFLRF, ");//売上単価（税抜，浮動）			
                sb.Append(" CN.SHIPMENTCNTRF SHIPMENTCNTRF, ");//出荷数			
                sb.Append(" CN.SALESORDERDIVCDRF SALESORDERDIVCDRF, ");//売上在庫取寄せ区分			
                sb.Append(" CN.SALESMONEYTAXEXCRF SALESMONEYTAXEXCRF, ");//売上金額（税抜き）			
                sb.Append(" SECINFOSETRF.SECTIONGUIDESNMRF SECTIONGUIDESNMRF, ");//拠点ガイド略称					
                sb.Append(" BLGOODSCDURF.BLGOODSHALFNAMERF BLGOODSHALFNAMERF, ");//BL商品コード名称（半角）	
                sb.Append(" AC.CARMNGNORF CARMNGNORF, ");//車両管理番号			
                sb.Append(" AC.MAKERCODERF MAKERCODERF, ");//メーカーコード			
                sb.Append(" AC.MODELCODERF MODELCODERF, ");//車種コード			
                sb.Append(" AC.MODELSUBCODERF MODELSUBCODERF, ");//車種サブコード			
                sb.Append(" AC.MODELHALFNAMERF MODELHALFNAMERF, ");//車種半角名称			
                sb.Append(" AC.SERIESMODELRF SERIESMODELRF, ");//シリーズ型式			
                sb.Append(" AC.CATEGORYSIGNMODELRF CATEGORYSIGNMODELRF, ");//型式（類別番号）			
                sb.Append(" AC.FULLMODELRF FULLMODELRF, ");//型式（フル）
                // --- ADD 2010/05/16 ---------->>>>>
                sb.Append(" STOCKRF.SUPPLIERSTOCKRF SUPPLIERSTOCKRF, ");//現在庫数
                sb.Append(" STOCKRF.WAREHOUSESHELFNORF WAREHOUSESHELFNORF, ");//棚番
                // --- ADD 2010/05/16 ----------<<<<<
                sb.Append(" MAKERURF.MAKERNAMERF MAKERNAMERF ");//メーカー名称(純正)

                sb.Append(" FROM ");
                //受注マスタ(車輌)
                sb.Append(" ACCEPTODRCARRF AC WITH (READUNCOMMITTED), ");
                //車輌部品データ(コンバート)
                sb.Append(" CNVCARPARTSRF CN WITH (READUNCOMMITTED) ");
                //拠点情報設定マスタ
                sb.Append(" LEFT JOIN SECINFOSETRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON SECINFOSETRF.ENTERPRISECODERF = CN.ENTERPRISECODERF ");
                sb.Append(" AND SECINFOSETRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND SECINFOSETRF.SECTIONCODERF=CN.RESULTSADDUPSECCDRF ");
                //ＢＬ商品コードマスタ(ユーザー)
                sb.Append(" LEFT JOIN BLGOODSCDURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON BLGOODSCDURF.ENTERPRISECODERF=CN.ENTERPRISECODERF ");
                sb.Append(" AND BLGOODSCDURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND BLGOODSCDURF.BLGOODSCODERF=CN.BLGOODSCODERF ");
                //メーカーマスタ
                sb.Append(" LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
                sb.Append(" ON MAKERURF.ENTERPRISECODERF=CN.ENTERPRISECODERF ");
                sb.Append(" AND MAKERURF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND MAKERURF.GOODSMAKERCDRF=CN.GOODSMAKERCDRF ");
                // --- ADD 2010/05/16 ---------->>>>>
                //在庫マスタ
                sb.Append(" LEFT JOIN STOCKRF WITH (READUNCOMMITTED) ");
                sb.Append(" ON STOCKRF.ENTERPRISECODERF=CN.ENTERPRISECODERF ");
                sb.Append(" AND STOCKRF.LOGICALDELETECODERF=0 ");
                sb.Append(" AND STOCKRF.GOODSMAKERCDRF=CN.GOODSMAKERCDRF ");
                sb.Append(" AND STOCKRF.GOODSNORF=CN.GOODSNORF ");
                sb.Append(" AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                // --- ADD 2010/05/16 ----------<<<<<

                sb.Append(MakeWhereStringB(ref sqlCommand, modelShipRsltCndtnWork));

                // 画面の集計方法が「全社」を選択の場合
                if (modelShipRsltCndtnWork.GroupBySectionDiv == 0)
                {
                    //車種メーカー、車種コード、車種サブコード、フル型式、ＢＬコード、出荷メーカー、出荷品番
                    sb.Append(" ORDER BY ");
                    sb.Append(" MAKERCODERF, ");
                    sb.Append(" MODELCODERF, ");
                    sb.Append(" MODELSUBCODERF, ");
                    sb.Append(" FULLMODELRF, ");
                    sb.Append(" BLGOODSCODERF, ");
                    sb.Append(" GOODSMAKERCDRF, ");
                    sb.Append(" GOODSNORF ");

                }
                // 画面の集計方法が「拠点毎」を選択の場合
                else if (modelShipRsltCndtnWork.GroupBySectionDiv == 1)
                {
                    //実績計上拠点コード、車種メーカー、車種コード、車種サブコード、フル型式、ＢＬコード、出荷メーカー、出荷品番
                    sb.Append(" ORDER BY ");
                    sb.Append(" RESULTSADDUPSECCDRF, ");
                    sb.Append(" MAKERCODERF, ");
                    sb.Append(" MODELCODERF, ");
                    sb.Append(" MODELSUBCODERF, ");
                    sb.Append(" FULLMODELRF, ");
                    sb.Append(" BLGOODSCODERF, ");
                    sb.Append(" GOODSMAKERCDRF, ");
                    sb.Append(" GOODSNORF ");
                }

                // --- ADD 2010/05/13 ---------->>>>>
                //倉庫コード
                SqlParameter Para_WarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Char);
                Para_WarehouseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.WarehouseCode);
                // --- ADD 2010/05/13 ----------<<<<<

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    ModelShipResultWork wkModelShipResultWork = new ModelShipResultWork();

                    //仕入データ結果取得内容格納
                    wkModelShipResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkModelShipResultWork.SalesDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkModelShipResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkModelShipResultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    wkModelShipResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkModelShipResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkModelShipResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkModelShipResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkModelShipResultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                    wkModelShipResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkModelShipResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkModelShipResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkModelShipResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkModelShipResultWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
                    wkModelShipResultWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                    wkModelShipResultWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                    wkModelShipResultWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                    wkModelShipResultWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                    wkModelShipResultWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));
                    wkModelShipResultWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));
                    wkModelShipResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                    wkModelShipResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkModelShipResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                    // --- ADD 2010/05/16 ---------->>>>>
                    //仕入在庫数
                    wkModelShipResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    //倉庫棚番
                    wkModelShipResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    // --- ADD 2010/05/16 ----------<<<<<
                    #endregion

                    al.Add(wkModelShipResultWork);
                }
                if (al.Count < 1)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
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
                if (null != sqlCommand)
                {
                    sqlCommand.Dispose();
                }
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }
            }

            modelShipResultWork = al;

            return status;
        }

        // --- ADD 2010/05/08 ---------->>>>>
        /// <summary>
        /// 指定された条件の在庫情報を全て戻します（論理削除除く）
        /// </summary>
        /// <param name="modelShipResultWork">検索結果</param>
        /// <param name="enterpriseCode">検索パラメータ</param>
        /// <param name="warehouseCode">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫情報データを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.05.08</br>
        //public int SearchStock(ref object modelShipResultWorkObject, string warehouseCode)//DEL 2010/05/13
        public int SearchStock(ref object modelShipResultWorkObject, string enterpriseCode, string warehouseCode)//ADD 2010/05/13
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (null == sqlConnection)
                {
                    return status;
                }
                sqlConnection.Open();

                //status = SearchStockProc(ref modelShipResultWorkObject, warehouseCode, ref sqlConnection);//DEL 2010/05/13
                status = SearchStockProc(ref modelShipResultWorkObject, enterpriseCode, warehouseCode, ref sqlConnection);//ADD 2010/05/13
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ModelShipResultDB.SearchStock");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 仕入在庫数と倉庫棚番の取得
        /// </summary>
        /// <param name="modelShipResultWorkObject">検索結果</param>
        /// <param name="enterpriseCode">検索パラメータ</param>
        /// <param name="warehouseCode">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入在庫数と倉庫棚番を取得します。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010.05.08</br>
        /// <br>Update Note: 2010/05/13 王海立 在庫マスタのチェック障害の対応</br>
        //private int SearchStockProc(ref object modelShipResultWorkObject, string warehouseCode, ref SqlConnection sqlConnection)//DEL 2010/05/13
        private int SearchStockProc(ref object modelShipResultWorkObject, string enterpriseCode, string warehouseCode, ref SqlConnection sqlConnection)//ADD 2010/05/13
        {
            ArrayList modelShipResultWorkList = modelShipResultWorkObject as ArrayList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            // --- ADD 2010/05/13 ---------->>>>>
            //ModelShipResultWork newWork = null;//DEL 2010/05/16
            bool isFind = false;
            // --- ADD 2010/05/13 ----------<<<<<

            foreach (ModelShipResultWork modelShipResultWorkTmp in modelShipResultWorkList)
            {
                // --- DEL 2010/05/13 ---------->>>>>
                ////商品種別が 0:純正、倉庫コードが１以上の場合
                //if (modelShipResultWorkTmp.GoodsKindCode != 0 
                //    || warehouseCode.CompareTo("000001") < 0 
                //    || modelShipResultWorkTmp.JoinDestMakerCd == 0 
                //    || string.IsNullOrEmpty(modelShipResultWorkTmp.JoinDestPartsNo))
                //{
                //    continue;
                //}
                // --- DEL 2010/05/13 ----------<<<<<
                try
                {
                    sqlCommand = new SqlCommand("", sqlConnection);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT ");
                    sb.Append("SUPPLIERSTOCKRF, ");
                    // --- UPD 2010/05/13 ---------->>>>>
                    sb.Append("WAREHOUSESHELFNORF ");
                    //sb.Append("WAREHOUSESHELFNORF, ");
                    //sb.Append("MAKERNAMERF ");
                    // --- UPD 2010/05/13 ----------<<<<<
                    sb.Append("FROM ");
                    sb.Append("STOCKRF WITH (READUNCOMMITTED) ");
                    // --- DEL 2010/05/13 ---------->>>>>
                    //sb.Append("LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
                    //sb.Append("ON MAKERURF.ENTERPRISECODERF=STOCKRF.ENTERPRISECODERF ");
                    //sb.Append("AND MAKERURF.LOGICALDELETECODERF=0 ");
                    //sb.Append("AND MAKERURF.GOODSMAKERCDRF=STOCKRF.GOODSMAKERCDRF ");
                    // --- DEL 2010/05/13 ----------<<<<<
                    sb.Append("WHERE ");
                    sb.Append("STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sb.Append("AND STOCKRF.LOGICALDELETECODERF=0 ");
                    sb.Append("AND STOCKRF.SUPPLIERSTOCKRF>0 ");
                    sb.Append("AND STOCKRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD ");
                    sb.Append("AND STOCKRF.GOODSNORF=@FINDGOODSNO ");
                    sb.Append("AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");

                    //企業コード
                    SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
                    //Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.EnterpriseCode);
                    Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    //結合先メーカーコード
                    SqlParameter Para_JoinDestMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    Para_JoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(modelShipResultWorkTmp.JoinDestMakerCd);
                    //結合先品番(－付き品番)
                    SqlParameter Para_JoinDestPartsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.Char);
                    Para_JoinDestPartsNo.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.JoinDestPartsNo);
                    //倉庫コード
                    SqlParameter Para_WarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Char);
                    Para_WarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseCode);

                    sqlCommand.CommandText = sb.ToString();

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        #region 抽出結果-値セット
                        // --- DEL 2010/05/13 ---------->>>>>
                        ////仕入在庫数
                        //modelShipResultWorkTmp.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                        ////倉庫棚番
                        //modelShipResultWorkTmp.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        ////メーカー名称2
                        //modelShipResultWorkTmp.MakerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        // --- DEL 2010/05/13 ----------<<<<<
                        // --- ADD 2010/05/13 ---------->>>>>
                        // --- DEL 2010/05/16 ---------->>>>>
                        //newWork = new ModelShipResultWork();
                        ////仕入在庫数
                        //newWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                        ////倉庫棚番
                        //newWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                        // --- DEL 2010/05/16 ----------<<<<<

                        isFind = true;
                        // --- ADD 2010/05/13 ----------<<<<<
                        #endregion

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
                    if (null != sqlCommand)
                    {
                        sqlCommand.Dispose();
                    }
                    if (null != myReader && !myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
                // --- ADD 2010/05/13 ---------->>>>>
                // 在庫情報を取得し、結果を戻す
                if (isFind)
                {
                    modelShipResultWorkList = new ArrayList();
                    // --- UPD 2010/05/16 ---------->>>>>
                    //modelShipResultWorkList.Add(newWork);
                    modelShipResultWorkList.Add(modelShipResultWorkTmp);
                    // --- UPD 2010/05/16 ----------<<<<<
                    break;
                }
                // それ以外の場合、次の結合表示順位の結合先情報に対して同じチェックを行う
                // --- ADD 2010/05/13 ----------<<<<<
            }
            // --- ADD 2010/05/13 ---------->>>>>
            // 在庫情報を取得しない、結果リストをクリアする
            if (!isFind)
            {
                modelShipResultWorkList = new ArrayList();
            }
            modelShipResultWorkObject = modelShipResultWorkList as object;
            // --- ADD 2010/05/13 ----------<<<<<

            return status;
        }
        // --- ADD 2010/05/08 ----------<<<<<

        // --- DEL 2010/05/08 ---------->>>>>
        #region DEL 2010/05/08
        ///// <summary>
        ///// 対応品番の取得
        ///// </summary>
        ///// <param name="modelShipResultWork">検索パラメータ</param>
        ///// <param name="_modelShipRsltCndtnWork">検索パラメータ</param>
        ///// <param name="sqlConnection">コネクション</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 対応品番を取得します。</br>
        ///// <br>Programmer : zhshh</br>
        ///// <br>Date       : 2010.04.22</br>
        //private int SearchGoodNoProc(ref object modelShipResultWork, object _modelShipRsltCndtnWork, ref SqlConnection sqlConnection)
        //{
        //    //結合マスタの結合先品番（優良品番）と結合先メーカー（優良メーカー）のリストの取得
        //    ArrayList modelShipResultWorkList = modelShipResultWork as ArrayList;

        //    ModelShipRsltCndtnWork modelShipRsltCndtnWork = _modelShipRsltCndtnWork as ModelShipRsltCndtnWork;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    ArrayList newModelShipResultWorkList = null;   //抽出結果

        //    foreach(ModelShipResultWork modelShipResultWorkTmp in modelShipResultWorkList)
        //    {
        //        newModelShipResultWorkList = new ArrayList();

        //        //商品種別が 0:純正、倉庫コードが１以上の場合
        //        if (modelShipResultWorkTmp.GoodsKindCode == 0 && modelShipRsltCndtnWork.WarehouseCode.CompareTo("000001") >= 0)
        //        {
        //            try
        //            {
        //                sqlCommand = new SqlCommand("", sqlConnection);

        //                StringBuilder sb = new StringBuilder();
        //                sb.Append("SELECT ");
        //                sb.Append("JOINDESTMAKERCDRF, ");
        //                sb.Append("JOINDESTPARTSNORF ");
        //                sb.Append("FROM ");
        //                sb.Append("JOINPARTSURF WITH (READUNCOMMITTED)");
        //                sb.Append("WHERE ");
        //                sb.Append("ENTERPRISECODERF= @FINDENTERPRISECODE ");
        //                sb.Append("AND LOGICALDELETECODERF=0 ");
        //                sb.Append("AND JOINSOURCEMAKERCODERF= @FINDJOINSOURCEMAKERCODE ");
        //                sb.Append("AND JOINSOURPARTSNOWITHHRF= @FINDJOINSOURPARTSNOWITHH ");
        //                sb.Append("AND JOINDESTMAKERCDRF IN (");
        //                sb.Append("SELECT ");
        //                sb.Append("PARTSMAKERCDRF ");
        //                sb.Append("FROM ");
        //                sb.Append("PRMSETTINGURF WITH (READUNCOMMITTED)");
        //                sb.Append("WHERE ");
        //                sb.Append("ENTERPRISECODERF= @FINDENTERPRISECODE ");
        //                sb.Append("AND LOGICALDELETECODERF=0 ");
        //                sb.Append(") ");
        //                sb.Append("ORDER BY ");
        //                sb.Append("JOINDISPORDERRF ");

        //                //企業コード
        //                SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
        //                Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.EnterpriseCode);
        //                //結合元メーカーコード
        //                SqlParameter Para_JoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
        //                Para_JoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(modelShipResultWorkTmp.GoodsMakerCd);
        //                //結合元品番(－付き品番)
        //                SqlParameter Para_JoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.Char);
        //                Para_JoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.GoodsNo);

        //                sqlCommand.CommandText = sb.ToString();

        //                myReader = sqlCommand.ExecuteReader();

        //                while (myReader.Read())
        //                {
        //                    #region 抽出結果-値セット
        //                    ModelShipResultWork wkModelShipResultWork = new ModelShipResultWork();
        //                    //結合先メーカーコード
        //                    wkModelShipResultWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
        //                    //結合先品番(－付き品番)    
        //                    wkModelShipResultWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
        //                    #endregion

        //                    newModelShipResultWorkList.Add(wkModelShipResultWork);
        //                }
        //                if (newModelShipResultWorkList.Count >= 1)
        //                {
        //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //                }

        //            }
        //            catch (SqlException ex)
        //            {
        //                //基底クラスに例外を渡して処理してもらう
        //                status = base.WriteSQLErrorLog(ex);
        //            }
        //            finally
        //            {
        //                if (null != sqlCommand)
        //                {
        //                    sqlCommand.Dispose();
        //                }
        //                if (null != myReader && !myReader.IsClosed)
        //                {
        //                    myReader.Close();
        //                }
        //            }

        //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                ModelShipResultWork newModelShipResultWork;
        //                //仕入在庫数と倉庫棚番の取得
        //                status = SearchStockProc(newModelShipResultWorkList, modelShipResultWorkTmp, out newModelShipResultWork, _modelShipRsltCndtnWork, ref sqlConnection);

        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //                {
        //                    //仕入在庫数
        //                    modelShipResultWorkTmp.SupplierStock = newModelShipResultWork.SupplierStock;
        //                    //倉庫棚番
        //                    modelShipResultWorkTmp.WarehouseShelfNo = newModelShipResultWork.WarehouseShelfNo;
        //                    //結合先メーカーコード
        //                    modelShipResultWorkTmp.JoinDestMakerCd = newModelShipResultWork.JoinDestMakerCd;
        //                    //結合先品番(－付き品番)
        //                    modelShipResultWorkTmp.JoinDestPartsNo = newModelShipResultWork.JoinDestPartsNo;
        //                    //メーカー名称2
        //                    modelShipResultWorkTmp.MakerName2 = newModelShipResultWork.MakerName2;
        //                    //結合元メーカーコード
        //                    modelShipResultWorkTmp.JoinSourceMakerCode = modelShipResultWorkTmp.GoodsMakerCd;
        //                    //結合元品番(－付き品番)
        //                    modelShipResultWorkTmp.JoinSourPartsNoWithH = modelShipResultWorkTmp.GoodsNo;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 仕入在庫数と倉庫棚番の取得
        ///// </summary>
        ///// <param name="modelShipResultWorkList">検索パラメータ</param>
        ///// <param name="modelShipResultWork">検索パラメータ</param>
        ///// <param name="newModelShipResultWork">検索結果</param>
        ///// <param name="_modelShipRsltCndtnWork">検索パラメータ</param>
        ///// <param name="sqlConnection">コネクション</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 仕入在庫数と倉庫棚番を取得します。</br>
        ///// <br>Programmer : zhshh</br>
        ///// <br>Date       : 2010.04.22</br>
        //private int SearchStockProc(ArrayList modelShipResultWorkList, ModelShipResultWork modelShipResultWork, out ModelShipResultWork newModelShipResultWork, object _modelShipRsltCndtnWork, ref SqlConnection sqlConnection)
        //{
        //    ModelShipRsltCndtnWork modelShipRsltCndtnWork = _modelShipRsltCndtnWork as ModelShipRsltCndtnWork;

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;

        //    newModelShipResultWork = new ModelShipResultWork();//抽出結果

        //    foreach (ModelShipResultWork modelShipResultWorkTmp in modelShipResultWorkList)
        //    {
        //        try
        //        {
        //            sqlCommand = new SqlCommand("", sqlConnection);

        //            StringBuilder sb = new StringBuilder();
        //            sb.Append("SELECT ");
        //            sb.Append("SUPPLIERSTOCKRF, ");
        //            sb.Append("WAREHOUSESHELFNORF, ");
        //            sb.Append("MAKERNAMERF ");
        //            sb.Append("FROM ");
        //            sb.Append("STOCKRF WITH (READUNCOMMITTED) ");
        //            sb.Append("LEFT JOIN MAKERURF WITH (READUNCOMMITTED) ");
        //            sb.Append("ON MAKERURF.ENTERPRISECODERF=STOCKRF.ENTERPRISECODERF ");
        //            sb.Append("AND MAKERURF.LOGICALDELETECODERF=0 ");
        //            sb.Append("AND MAKERURF.GOODSMAKERCDRF=STOCKRF.GOODSMAKERCDRF ");
        //            sb.Append("WHERE ");
        //            sb.Append("STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
        //            sb.Append("AND STOCKRF.LOGICALDELETECODERF=0 ");
        //            sb.Append("AND STOCKRF.SUPPLIERSTOCKRF>0 ");
        //            sb.Append("AND STOCKRF.GOODSMAKERCDRF=@FINDGOODSMAKERCD ");
        //            sb.Append("AND STOCKRF.GOODSNORF=@FINDGOODSNO ");
        //            sb.Append("AND STOCKRF.WAREHOUSECODERF=@FINDWAREHOUSECODE ");

        //            //企業コード
        //            SqlParameter Para_EnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.Char);
        //            Para_EnterpriseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.EnterpriseCode);
        //            //結合先メーカーコード
        //            SqlParameter Para_JoinDestMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
        //            Para_JoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(modelShipResultWorkTmp.JoinDestMakerCd);
        //            //結合先品番(－付き品番)
        //            SqlParameter Para_JoinDestPartsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.Char);
        //            Para_JoinDestPartsNo.Value = SqlDataMediator.SqlSetString(modelShipResultWorkTmp.JoinDestPartsNo);
        //            //倉庫コード
        //            SqlParameter Para_WarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.Char);
        //            Para_WarehouseCode.Value = SqlDataMediator.SqlSetString(modelShipRsltCndtnWork.WarehouseCode);

        //            sqlCommand.CommandText = sb.ToString();

        //            myReader = sqlCommand.ExecuteReader();

        //            if (myReader.Read())
        //            {
        //                #region 抽出結果-値セット
        //                //結合先メーカーコード
        //                newModelShipResultWork.JoinDestMakerCd = modelShipResultWorkTmp.JoinDestMakerCd;
        //                //結合先品番(－付き品番)
        //                newModelShipResultWork.JoinDestPartsNo = modelShipResultWorkTmp.JoinDestPartsNo;
        //                //仕入在庫数
        //                newModelShipResultWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
        //                //倉庫棚番
        //                newModelShipResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
        //                //メーカー名称2
        //                newModelShipResultWork.MakerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
        //                #endregion

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            //基底クラスに例外を渡して処理してもらう
        //            status = base.WriteSQLErrorLog(ex);
        //        }
        //        finally
        //        {
        //            if (null != sqlCommand)
        //            {
        //                sqlCommand.Dispose();
        //            }
        //            if (null != myReader && !myReader.IsClosed)
        //            {
        //                myReader.Close();
        //            }
        //        }

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            break;
        //        }
        //    }

        //    return status;
        //}
        #endregion
        // --- DEL 2010/05/08 ----------<<<<<
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_modelShipRsltCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/07 王海立 受注ステータスの仕様変更</br>
        /// <br>Update Note: 2010/05/13 王海立 ２点仕様変更の対応</br>
        /// </remarks>
        private string MakeWhereStringA(ref SqlCommand sqlCommand, ModelShipRsltCndtnWork _modelShipRsltCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            // 売上履歴データ.企業コード ＝ 売上履歴明細データ.企業コード
            retstring += " AA.ENTERPRISECODERF=AB.ENTERPRISECODERF";

            // 売上履歴データ.受注ステータス ＝ 売上履歴明細データ.受注ステータス
            retstring += " AND AA.ACPTANODRSTATUSRF=AB.ACPTANODRSTATUSRF";

            // --- UPD 2010/05/07 ---------->>>>>
            //// 売上履歴データ.受注ステータス ＝ 受注マスタ(車輌).受注ステータス
            //retstring += " AND AA.ACPTANODRSTATUSRF=AC.ACPTANODRSTATUSRF";
            // 受注マスタ（車輌）のjoin条件
            retstring += " AND AC.ACPTANODRSTATUSRF='7'";
            // --- UPD 2010/05/07 ----------<<<<<

            // 売上履歴データ.売上伝票番号 ＝ 売上履歴明細データ.売上伝票番号
            retstring += " AND AA.SALESSLIPNUMRF=AB.SALESSLIPNUMRF";

            // 売上履歴明細データ.企業コード ＝ 受注マスタ(車輌).企業コード
            retstring += " AND AB.ENTERPRISECODERF=AC.ENTERPRISECODERF";

            // 売上履歴明細データ.受注番号 ＝ 受注マスタ(車輌).受注番号
            retstring += " AND AB.ACCEPTANORDERNORF=AC.ACCEPTANORDERNORF";

            // 売上履歴データ.企業コード＝ログイン担当者の企業コード
            retstring += " AND AA.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.EnterpriseCode);

            //売上履歴データ.論理削除区分 が 0
            retstring += " AND AA.LOGICALDELETECODERF = 0 ";
            //売上履歴データ.受注ステータスが 30(売上)
            retstring += " AND AA.ACPTANODRSTATUSRF = 30 ";

            //拠点コード
            if (_modelShipRsltCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _modelShipRsltCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND AA.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // 売上履歴データ.売上日付																																	
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateSt))
            {
                retstring += "AND AA.SALESDATERF>=@ST_SALESDAYRF ";
                SqlParameter Para_St_salesDate = sqlCommand.Parameters.Add("@ST_SALESDAYRF", SqlDbType.Int);
                Para_St_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateEd))
            {
                retstring += "AND AA.SALESDATERF<=@ED_SALESDAYRF ";
                SqlParameter Para_Ed_salesDate = sqlCommand.Parameters.Add("@ED_SALESDAYRF", SqlDbType.Int);
                Para_Ed_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateEd);
            }

            // 売上履歴データ.伝票検索日付
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateSt))
            {
                retstring += "AND AA.SEARCHSLIPDATERF>=@ST_SECHSDAYRF ";
                SqlParameter Para_St_sechDate = sqlCommand.Parameters.Add("@ST_SECHSDAYRF", SqlDbType.Int);
                Para_St_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateEd))
            {
                retstring += "AND AA.SEARCHSLIPDATERF<=@ED_SECHSDAYRF ";
                SqlParameter Para_Ed_sechDate = sqlCommand.Parameters.Add("@ED_SECHSDAYRF", SqlDbType.Int);
                Para_Ed_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateEd);
            }

            // 受注マスタ(車輌).論理削除区分 ＝ 「0：有効」
            retstring += " AND AC.LOGICALDELETECODERF = 0 ";

            // 受注マスタ(車輌).車両管理番号 ≠	 0
            retstring += " AND AC.CARMNGNORF <> 0 ";

            // 受注マスタ(車輌).メーカーコード
            if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)
            {
                retstring += " AND AC.MAKERCODERF>=@ACST_MAKERCODERF ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MAKERCODERF", SqlDbType.Int);
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarMakerCodeEd)
            {
                retstring += " AND AC.MAKERCODERF<=@ACED_MAKERCODERF ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MAKERCODERF", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeEd);
            }

            // 受注マスタ(車輌).車種コード
            //if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)// DEL 2010.05.19 zhangsf FOR Redmine #7784
            if (0 != _modelShipRsltCndtnWork.CarModelCodeSt)// ADD 2010.05.19 zhangsf FOR Redmine #7784
            {
                retstring += " AND AC.MODELCODERF>=@ACST_MODELCODERF ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MODELCODERF", SqlDbType.Int);
                //Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);// ADD 2010.05.19 zhangsf FOR Redmine #7784
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeSt);// ADD 2010.05.19 zhangsf FOR Redmine #7784
            }

            if (0 != _modelShipRsltCndtnWork.CarModelCodeEd)
            {
                retstring += " AND AC.MODELCODERF<=@ACED_MODELCODERF ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MODELCODERF", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeEd);
            }

            // 受注マスタ(車輌).車種サブコード
            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeSt)
            {
                retstring += " AND AC.MODELSUBCODERF>=@ACST_MODELSUBCODERF ";
                SqlParameter Para_St_CarModelSubCode = sqlCommand.Parameters.Add("@ACST_MODELSUBCODERF", SqlDbType.Int);
                Para_St_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeEd)
            {
                retstring += " AND AC.MODELSUBCODERF<=@ACED_MODELSUBCODERF ";
                SqlParameter Para_Ed_CarModelSubCode = sqlCommand.Parameters.Add("@ACED_MODELSUBCODERF", SqlDbType.Int);
                Para_Ed_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeEd);
            }

            // 売上履歴明細データ.論理削除区分 ＝ 「0：有効」
            retstring += " AND AB.LOGICALDELETECODERF = 0 ";

            // --- UPD 2010/05/13 ---------->>>>>
            //// 売上履歴明細データ.売上伝票区分 ＝ 「0：売上」OR「1：返品」OR 「2：値引」
            //retstring += " AND ( AB.SALESSLIPCDDTLRF = 0 OR  AB.SALESSLIPCDDTLRF = 1 OR  AB.SALESSLIPCDDTLRF = 2 )";
            // 売上履歴明細データ.売上伝票区分 ＝ 「0：売上」OR「1：返品」
            retstring += " AND ( AB.SALESSLIPCDDTLRF = 0 OR  AB.SALESSLIPCDDTLRF = 1 )";
            // --- UPD 2010/05/13 ----------<<<<<

            // 売上履歴明細データ.BL商品コード
            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeSt)
            {
                retstring += " AND AB.BLGOODSCODERF>=@ST_GOODSCODERF ";
                SqlParameter Para_St_BLgoodsCode = sqlCommand.Parameters.Add("@ST_GOODSCODERF", SqlDbType.Int);
                Para_St_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeEd)
            {
                retstring += " AND AB.BLGOODSCODERF<=@ED_GOODSCODERF ";
                SqlParameter Para_Ed_BLgoodsCode = sqlCommand.Parameters.Add("@ED_GOODSCODERF", SqlDbType.Int);
                Para_Ed_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeEd);
            }

            // 売上履歴明細データ.商品メーカーコード
            if (0 != _modelShipRsltCndtnWork.MakerCodeSt)
            {
                retstring += " AND AB.GOODSMAKERCDRF>=@CNST_GOODSMAKERCDRF ";
                SqlParameter Para_St_MakerCode = sqlCommand.Parameters.Add("@CNST_GOODSMAKERCDRF", SqlDbType.Int);
                Para_St_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.MakerCodeEd)
            {
                retstring += " AND AB.GOODSMAKERCDRF<=@CNED_GOODSMAKERCDRF ";
                SqlParameter Para_Ed_MakerCode = sqlCommand.Parameters.Add("@CNED_GOODSMAKERCDRF", SqlDbType.Int);
                Para_Ed_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeEd);
            }

            // 売上履歴明細データ.商品番号
            retstring += " AND AB.GOODSNORF<>'' ";

            // 売上履歴明細データ.売上在庫取寄せ区分 
            if (_modelShipRsltCndtnWork.RsltTtlDiv == 1)
            {
                // 1:在庫
                retstring += " AND AB.SALESORDERDIVCDRF = 1 ";
            }
            else if (_modelShipRsltCndtnWork.RsltTtlDiv == 2)
            {
                // 2:取寄せ
                retstring += " AND AB.SALESORDERDIVCDRF = 0 ";
            }

            // --- UPD 2010/05/13 ---------->>>>>
            //// 受注マスタ(車輌).シリーズ型式 型式（類別記号）
            //if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            //{
            //    // 0:と一致 1:で始まる 2:を含む 3:で終わる
            //    if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODELRF ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
            //    }
            //}
            // 受注マスタ(車輌).フル型式
            if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            {
                // 0:と一致 1:で始まる 2:を含む 3:で終わる
                if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
                {
                    retstring += " AND AC.FULLMODELRF = @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODELRF ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODELRF", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
                }
            }
            // --- UPD 2010/05/13 ----------<<<<<

            #endregion
            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_modelShipRsltCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
        /// <br>Update Note: 2010/05/13 王海立 ２点仕様変更の対応</br>
        /// </remarks>
        private string MakeWhereStringB(ref SqlCommand sqlCommand, ModelShipRsltCndtnWork _modelShipRsltCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            // 車輌部品データ(コンバート).企業コード ＝ 受注マスタ(車輌).企業コード
            retstring += " AC.ENTERPRISECODERF=CN.ENTERPRISECODERF";

            // 車輌部品データ(コンバート).受注番号 ＝ 受注マスタ(車輌).受注番号
            retstring += " AND AC.ACCEPTANORDERNORF=CN.ACCEPTANORDERNORF";

            // 車輌部品データ(コンバート).受注ステータス ＝ 受注マスタ(車輌).受注ステータス
            retstring += " AND AC.ACPTANODRSTATUSRF=CN.ACPTANODRSTATUSRF";

            // 車輌部品データ(コンバート).論理削除区分 ＝ 受注マスタ(車輌).論理削除区分
            retstring += " AND AC.LOGICALDELETECODERF=CN.LOGICALDELETECODERF";

            // 車輌部品データ(コンバート).データ入力システム ＝ 受注マスタ(車輌).データ入力システム
            retstring += " AND AC.DATAINPUTSYSTEMRF=CN.DATAINPUTSYSTEMRF";

            // 車輌部品データ(コンバート).企業コード＝ログイン担当者の企業コード
            retstring += " AND CN.ENTERPRISECODERF=@FINDENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.EnterpriseCode);

            retstring += " AND CN.LOGICALDELETECODERF = 0 ";
            retstring += " AND (CN.ACPTANODRSTATUSRF = 7 OR CN.ACPTANODRSTATUSRF = 8)";

            //拠点コード
            if (_modelShipRsltCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _modelShipRsltCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND CN.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // 車輌部品データ(コンバート).売上日付																																	
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateSt))
            {
                retstring += "AND CN.SALESDATERF>=@CNST_SALESDAY ";
                SqlParameter Para_St_salesDate = sqlCommand.Parameters.Add("@CNST_SALESDAY", SqlDbType.Int);
                Para_St_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.SalesDateEd))
            {
                retstring += "AND CN.SALESDATERF<=@CNED_SALESDAY ";
                SqlParameter Para_Ed_salesDate = sqlCommand.Parameters.Add("@CNED_SALESDAY", SqlDbType.Int);
                Para_Ed_salesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.SalesDateEd);
            }

            // 車輌部品データ(コンバート).売上日付
            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateSt))
            {
                retstring += "AND CN.SALESDATERF>=@CNST_SECHSDAY ";
                SqlParameter Para_St_sechDate = sqlCommand.Parameters.Add("@CNST_SECHSDAY", SqlDbType.Int);
                Para_St_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateSt);
            }

            if (!DateTime.MinValue.Equals(_modelShipRsltCndtnWork.InputDateEd))
            {
                retstring += "AND CN.SALESDATERF<=@CNED_SECHSDAY ";
                SqlParameter Para_Ed_sechDate = sqlCommand.Parameters.Add("@CNED_SECHSDAY", SqlDbType.Int);
                Para_Ed_sechDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_modelShipRsltCndtnWork.InputDateEd);
            }

            // 車輌部品データ(コンバート).BL商品コード
            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeSt)
            {
                retstring += " AND CN.BLGOODSCODERF>=@CNST_GOODSCODE ";
                SqlParameter Para_St_BLgoodsCode = sqlCommand.Parameters.Add("@CNST_GOODSCODE", SqlDbType.Int);
                Para_St_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.BLGoodsCodeEd)
            {
                retstring += " AND CN.BLGOODSCODERF<=@CNED_GOODSCODE ";
                SqlParameter Para_Ed_BLgoodsCode = sqlCommand.Parameters.Add("@CNED_GOODSCODE", SqlDbType.Int);
                Para_Ed_BLgoodsCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.BLGoodsCodeEd);
            }

            // 車輌部品データ(コンバート).商品メーカーコード
            if (0 != _modelShipRsltCndtnWork.MakerCodeSt)
            {
                retstring += " AND CN.GOODSMAKERCDRF>=@CNST_GOODSMAKERCD ";
                SqlParameter Para_St_MakerCode = sqlCommand.Parameters.Add("@CNST_GOODSMAKERCD", SqlDbType.Int);
                Para_St_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.MakerCodeEd)
            {
                retstring += " AND CN.GOODSMAKERCDRF<=@CNED_GOODSMAKERCD ";
                SqlParameter Para_Ed_MakerCode = sqlCommand.Parameters.Add("@CNED_GOODSMAKERCD", SqlDbType.Int);
                Para_Ed_MakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.MakerCodeEd);
            }

            // 車輌部品データ(コンバート).商品番号
            retstring += " AND CN.GOODSNORF<>'' ";

            // 車輌部品データ(コンバート).売上在庫取寄せ区分 
            if (_modelShipRsltCndtnWork.RsltTtlDiv == 1)
            {
                // 1:在庫
                retstring += " AND CN.SALESORDERDIVCDRF = 1 ";
            }
            else if (_modelShipRsltCndtnWork.RsltTtlDiv == 2)
            {
                // 2:取寄せ
                retstring += " AND CN.SALESORDERDIVCDRF = 0 ";
            }

            // 受注マスタ(車輌).車両管理番号 ≠	 0
            retstring += " AND AC.CARMNGNORF <> 0 ";

            // --- UPD 2010/05/13 ---------->>>>>
            //// 受注マスタ(車輌).シリーズ型式 型式（類別記号）
            //if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            //{
            //    // 0:と一致 1:で始まる 2:を含む 3:で終わる
            //    if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
            //    }
            //    else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
            //    {
            //        retstring += " AND AC.SERIESMODELRF + '-' + AC.CATEGORYSIGNMODELRF LIKE @ACMODEL ";
            //        SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
            //        Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
            //    }
            //}
            // 受注マスタ(車輌).フル型式
            if (!string.IsNullOrEmpty(_modelShipRsltCndtnWork.ModelName))
            {
                // 0:と一致 1:で始まる 2:を含む 3:で終わる
                if (_modelShipRsltCndtnWork.ModelOutDiv == 0)
                {
                    retstring += " AND AC.FULLMODELRF = @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName);
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 1)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString(_modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 2)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName + "%");
                }
                else if (_modelShipRsltCndtnWork.ModelOutDiv == 3)
                {
                    retstring += " AND AC.FULLMODELRF LIKE @ACMODEL ";
                    SqlParameter Para_Model = sqlCommand.Parameters.Add("@ACMODEL", SqlDbType.NChar);
                    Para_Model.Value = SqlDataMediator.SqlSetString("%" + _modelShipRsltCndtnWork.ModelName);
                }
            }
            // --- UPD 2010/05/13 ----------<<<<<

            // 受注マスタ(車輌).メーカーコード
            if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)
            {
                retstring += " AND AC.MAKERCODERF>=@ACST_MAKERCODE ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MAKERCODE", SqlDbType.Int);
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarMakerCodeEd)
            {
                retstring += " AND AC.MAKERCODERF<=@ACED_MAKERCODE ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MAKERCODE", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeEd);
            }

            // 受注マスタ(車輌).車種コード
            //if (0 != _modelShipRsltCndtnWork.CarMakerCodeSt)// DEL 2010.05.19 zhangsf FOR Redmine #7784
            if (0 != _modelShipRsltCndtnWork.CarModelCodeSt)// ADD 2010.05.19 zhangsf FOR Redmine #7784
            {
                retstring += " AND AC.MODELCODERF>=@ACST_MODELCODE ";
                SqlParameter Para_St_CarMakerCode = sqlCommand.Parameters.Add("@ACST_MODELCODE", SqlDbType.Int);
                //Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarMakerCodeSt);// DEL 2010.05.19 zhangsf FOR Redmine #7784
                Para_St_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeSt);// ADD 2010.05.19 zhangsf FOR Redmine #7784
            }

            if (0 != _modelShipRsltCndtnWork.CarModelCodeEd)
            {
                retstring += " AND AC.MODELCODERF<=@ACED_MODELCODE ";
                SqlParameter Para_Ed_CarMakerCode = sqlCommand.Parameters.Add("@ACED_MODELCODE", SqlDbType.Int);
                Para_Ed_CarMakerCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelCodeEd);
            }

            // 受注マスタ(車輌).車種サブコード
            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeSt)
            {
                retstring += " AND AC.MODELSUBCODERF>=@ACST_MODELSUBCODE ";
                SqlParameter Para_St_CarModelSubCode = sqlCommand.Parameters.Add("@ACST_MODELSUBCODE", SqlDbType.Int);
                Para_St_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeSt);
            }

            if (0 != _modelShipRsltCndtnWork.CarModelSubCodeEd)
            {
                retstring += " AND AC.MODELSUBCODERF<=@ACED_MODELSUBCODE ";
                SqlParameter Para_Ed_CarModelSubCode = sqlCommand.Parameters.Add("@ACED_MODELSUBCODE", SqlDbType.Int);
                Para_Ed_CarModelSubCode.Value = SqlDataMediator.SqlSetInt32(_modelShipRsltCndtnWork.CarModelSubCodeEd);
            }

            #endregion
            return retstring;
        }


        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : zhshh</br>
        /// <br>Date       : 2010.04.22</br>
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
        #endregion  //コネクション生成処理
    }
}

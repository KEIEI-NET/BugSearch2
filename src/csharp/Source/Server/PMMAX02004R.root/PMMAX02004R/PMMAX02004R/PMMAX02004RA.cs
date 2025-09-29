//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品MAX入荷予約
// プログラム概要   : 画面抽出条件を満たしたデータを戻る
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11270001-00  作成担当 : 陳艶丹
// 作 成 日  2016/01/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 譚洪
// 作 成 日  2020/06/18   修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources; 
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common; // ADD 2020/06/18 譚洪 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部品MAX入荷予約DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 部品MAX入荷予約データの実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2016/01/21</br>
    /// <br>Update Note : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class PartsMaxStockArrivalDB : RemoteDB, IPartsMaxStockArrivalDB
    {
        #region コンスト
        /// <summary>
        /// 部品MAX入荷予約コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public PartsMaxStockArrivalDB()
        {
        }
        #endregion

        #region public
        /// <summary>
        /// 指定された企業コードの部品MAX入荷予約件数取得処理
        /// </summary>
        /// <param name="searchCount">検索結果</param>
        /// <param name="partsMaxStockArrivalCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの部品MAX入荷予約件数取得処理します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public int SearchCount(out int searchCount, object partsMaxStockArrivalCndtnWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            searchCount = 0;
            object partsMaxStockArrivalResultWork = null;
            errMessage = string.Empty;
            bool moveDiv = true;
            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnction = null;
            //コネクション生成
            using (sqlConnction = new SqlConnection(connectionText))
            {
                try
                {
                    sqlConnction.Open();
                    PartsMaxStockArrivalCondt cndtnWork = partsMaxStockArrivalCndtnWork as PartsMaxStockArrivalCondt;

                    status = SearchProc(out partsMaxStockArrivalResultWork, out searchCount, cndtnWork, out errMessage, ref sqlConnction, moveDiv, 0);

                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "PartsMaxStockArrivalDB.Search");
                    errMessage = ex.Message;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    // コネクション破棄
                    if (sqlConnction != null) sqlConnction.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された企業コードの部品MAX入荷予約データの全て戻る処理
        /// </summary>
        /// <param name="partsMaxStockArrivalResultWork">検索結果</param>
        /// <param name="partsMaxStockArrivalCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの部品MAX入荷予約データLISTを全て戻します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public int Search(out object partsMaxStockArrivalResultWork, object partsMaxStockArrivalCndtnWork, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            partsMaxStockArrivalResultWork = null;
            errMessage = string.Empty;
            bool moveDiv = false;
            int searchCount = 0;
            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnction = null;
            //コネクション生成
            using (sqlConnction = new SqlConnection(connectionText))
            {
                try
                {
                    sqlConnction.Open();
                    PartsMaxStockArrivalCondt cndtnWork = partsMaxStockArrivalCndtnWork as PartsMaxStockArrivalCondt;

                    status = SearchProc(out partsMaxStockArrivalResultWork, out searchCount, cndtnWork, out errMessage, ref sqlConnction, moveDiv, loopIndex);

                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "PartsMaxStockArrivalDB.Search");
                    partsMaxStockArrivalResultWork = new ArrayList();
                    errMessage = ex.Message;
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    // コネクション破棄
                    if (sqlConnction != null) sqlConnction.Close();
                }
            }

            return status;
        }
        #endregion

        #region private
        /// <summary>
        /// 指定された条件の在庫移動データを全て戻る処理
        /// </summary>
        /// <param name="partsMaxStockArrivalResultWork">在庫移動データ結果</param>
        /// <param name="searchCount">在庫移動データ件数</param>
        /// <param name="cndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="moveDiv">件数取得と在庫移動データ区分</param>
        /// <param name="loopIndex">ループIndex</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の在庫移動データを全て戻る。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// <br>Update Note : PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/06/18</br>
        /// </remarks>
        private int SearchProc(out object partsMaxStockArrivalResultWork, out int searchCount, PartsMaxStockArrivalCondt cndtnWork, out string errMessage, ref SqlConnection sqlConnection, bool moveDiv, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            partsMaxStockArrivalResultWork = null;
            searchCount = 0;
            ArrayList al = new ArrayList(); //抽出結果
            StringBuilder sqlTxt = new StringBuilder(string.Empty);
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            // 検索クエリ文の構築
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    if (moveDiv)
                    {
                        // Selectコマンド
                        sqlTxt.Append(MakeMoveCountString());
                        sqlTxt.Append(MakeMoveWhereString(cndtnWork, moveDiv));
                    }
                    else
                    {
                        // Selectコマンド
                        sqlTxt.Append(MakeMoveSelectString(loopIndex, cndtnWork));
                        SqlParameter paraGoodsDate = sqlCommand.Parameters.Add("@DATE", SqlDbType.Int);
                        paraGoodsDate.Value = SqlDataMediator.SqlSetInt32(Int32.Parse(DateTime.Today.ToString("yyyyMMdd")));

                    }


                    //検索条件
                    // 企業コード
                    SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
                    paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // 論理削除区分
                    SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
                    paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                    // 出庫拠点コード
                    if (!string.IsNullOrEmpty(cndtnWork.BfSectionCode))
                    {
                        SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                        paraBfSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.BfSectionCode);
                    }
                    // 入庫拠点コード
                    if (!string.IsNullOrEmpty(cndtnWork.AfSectionCode))
                    {
                        SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                        paraAfSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.AfSectionCode);
                    }
                    SqlParameter para_St_Date = sqlCommand.Parameters.Add("@ARRIVALGOODSDAYST", SqlDbType.Int);
                    para_St_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.ShipDateSt);

                    SqlParameter para_Ed_Date = sqlCommand.Parameters.Add("@ARRIVALGOODSDAYED", SqlDbType.Int);
                    para_Ed_Date.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.ShipDateEd);


                    sqlCommand.CommandText = sqlTxt.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 抽出結果-値セット
                            if (moveDiv)
                            {
                                searchCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDT_COUNT"));

                            }
                            else
                            {
                                //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                                // 在庫移動データ抽出結果-値セット
                                //al.Add(CopyMoveDataFromSqlDataReader(myReader));
                                al.Add(CopyMoveDataFromSqlDataReader(myReader, convertDoubleRelease));
                                //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                            }
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (al.Count == 0 && !moveDiv)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "PartsMaxStockArrivalDB.SearchProc Exception=" + ex.Message, status);
                }
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                finally
                {
                    // 解放
                    convertDoubleRelease.Dispose();
                }
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }


            partsMaxStockArrivalResultWork = al;

            return status;
        }

        /// <summary>
        /// 移動データ検索文
        /// </summary>
        /// <remarks>
        /// <br>Note        : 移動データ検索文処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private string MakeMoveSelectString(int loopIndex, PartsMaxStockArrivalCondt cndtnWork)
        {
            StringBuilder selectTxt = new StringBuilder();
            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("* FROM ").Append(Environment.NewLine);
            selectTxt.Append("( ").Append(Environment.NewLine);
            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("ROW_NUMBER() OVER(ORDER BY SUB_MOVE.STOCKMOVESLIPNORF, SUB_MOVE.STOCKMOVEROWNORF) AS ROWID ").Append(Environment.NewLine);
            selectTxt.Append(",*  ").Append(Environment.NewLine);
            selectTxt.Append("FROM ").Append(Environment.NewLine);
            selectTxt.Append("( ").Append(Environment.NewLine);

            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("STMOVE.ENTERPRISECODERF ").Append(Environment.NewLine);        // 企業コード
            selectTxt.Append(",STMOVE.SHIPMENTFIXDAYRF ").Append(Environment.NewLine);       // 出荷確定日
            selectTxt.Append(",STMOVE.STOCKMOVESLIPNORF ").Append(Environment.NewLine);      // 在庫移動伝票番号
            selectTxt.Append(",STMOVE.STOCKMOVEROWNORF ").Append(Environment.NewLine);       // 在庫移動行番号
            selectTxt.Append(",STMOVE.GOODSNORF ").Append(Environment.NewLine);              // 商品番号
            selectTxt.Append(",STMOVE.GOODSNAMERF ").Append(Environment.NewLine);            // 商品名称
            selectTxt.Append(",STMOVE.GOODSMAKERCDRF ").Append(Environment.NewLine);         // 商品メーカーコード
            selectTxt.Append(",STMOVE.MAKERNAMERF ").Append(Environment.NewLine);            // メーカー名称
            selectTxt.Append(",STMOVE.BLGOODSCODERF ").Append(Environment.NewLine);          // BL商品コード
            selectTxt.Append(",STMOVE.MOVECOUNTRF ").Append(Environment.NewLine);            // 移動数
            selectTxt.Append(",STMOVE.BFSECTIONCODERF ").Append(Environment.NewLine);        // 移動元拠点コード
            selectTxt.Append(",STMOVE.BFSECTIONGUIDESNMRF ").Append(Environment.NewLine);    // 移動元拠点ガイド略称
            selectTxt.Append(",STMOVE.BFENTERWAREHCODERF ").Append(Environment.NewLine);     // 移動元倉庫コード
            selectTxt.Append(",STMOVE.BFENTERWAREHNAMERF ").Append(Environment.NewLine);     // 移動元倉庫名称
            selectTxt.Append(",STMOVE.AFSECTIONCODERF ").Append(Environment.NewLine);        // 移動先拠点コード
            selectTxt.Append(",STMOVE.AFSECTIONGUIDESNMRF ").Append(Environment.NewLine);    // 移動先拠点ガイド略称
            selectTxt.Append(",STMOVE.AFENTERWAREHCODERF ").Append(Environment.NewLine);     // 移動先倉庫コード
            selectTxt.Append(",STMOVE.AFENTERWAREHNAMERF ").Append(Environment.NewLine);     // 移動先倉庫名称
            selectTxt.Append(" ,STMOVE.SUPPLIERCDRF ").Append(Environment.NewLine);          // 仕入先コード
            selectTxt.Append(",BLGOODSCDU.GOODSRATEGRPCODERF ").Append(Environment.NewLine); // 商品掛率G
            selectTxt.Append(",BLGOODSCDU.BLGROUPCODERF ").Append(Environment.NewLine);      // BLグループコード
            selectTxt.Append(",GOODSU.GOODSRATERANKRF ").Append(Environment.NewLine);// 商品掛率ランク
            selectTxt.Append(",GOODSU.TAXATIONDIVCDRF ").Append(Environment.NewLine);// 課税区分

            selectTxt.Append(",BLGROUPU.GOODSMGROUPRF ").Append(Environment.NewLine);// 商品中分類コード
            selectTxt.Append(",WAREHOUSE.SECTIONCODERF  ").Append(Environment.NewLine);// 管理拠点コード

            selectTxt.Append(",GSP.OPENPRICEDIVRF ").Append(Environment.NewLine);            //オープン価格区分
            selectTxt.Append(",GSP.PRICESTARTDATERF, -- 価格マスタ.価格開始日").Append(Environment.NewLine);
            selectTxt.Append(" GSP.LISTPRICERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GSP.SALESUNITCOSTRF, ").Append(Environment.NewLine);
            selectTxt.Append(" GSP.STOCKRATERF, ").Append(Environment.NewLine);                                             
            selectTxt.Append(" GSP.OFFERDATERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GSP.UPDATEDATERF ").Append(Environment.NewLine);
            selectTxt.Append("FROM STOCKMOVERF AS STMOVE WITH (READUNCOMMITTED) --在庫移動データ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --商品マスタ").Append(Environment.NewLine);
            selectTxt.Append(" ON STMOVE.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- 企業コード ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- 商品メーカーコード ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.GOODSNORF = GOODSU.GOODSNORF -- 商品番号 ").Append(Environment.NewLine);
            selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --ＢＬ商品コードマスタ(ユーザー)").Append(Environment.NewLine);
            selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL商品コード ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BLグループマスタ（ユーザー登録分）").Append(Environment.NewLine);
            selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
            selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BLグループコード ").Append(Environment.NewLine);

            selectTxt.Append(" LEFT JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) --倉庫マスタ").Append(Environment.NewLine);
            selectTxt.Append(" ON STMOVE.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
            selectTxt.Append(" AND STMOVE.AFENTERWAREHCODERF = WAREHOUSE.WAREHOUSECODERF-- 倉庫コード ").Append(Environment.NewLine);

            selectTxt.Append("LEFT JOIN  GOODSPRICEURF AS GSP WITH (READUNCOMMITTED) --価格マスタ").Append(Environment.NewLine);
            selectTxt.Append("ON STMOVE.ENTERPRISECODERF = GSP.ENTERPRISECODERF ").Append(Environment.NewLine);
            selectTxt.Append("AND STMOVE.GOODSMAKERCDRF = GSP.GOODSMAKERCDRF ").Append(Environment.NewLine);
            selectTxt.Append("AND STMOVE.GOODSNORF = GSP.GOODSNORF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP.PRICESTARTDATERF =  ").Append(Environment.NewLine);
            selectTxt.Append("(SELECT MAX(PRICESTARTDATERF) ").Append(Environment.NewLine);
            selectTxt.Append("FROM GOODSPRICEURF GSP_B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            selectTxt.Append("WHERE GSP_B.ENTERPRISECODERF=STMOVE.ENTERPRISECODERF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSMAKERCDRF=STMOVE.GOODSMAKERCDRF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSNORF=STMOVE.GOODSNORF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.PRICESTARTDATERF <= @DATE)").Append(Environment.NewLine);
            selectTxt.Append(MakeMoveWhereString(cndtnWork, false));

            selectTxt.Append(") AS SUB_MOVE ").Append(Environment.NewLine);
            selectTxt.Append(") AS MOVE ").Append(Environment.NewLine);
            selectTxt.Append("WHERE ").Append(Environment.NewLine);
            selectTxt.Append("ROWID BETWEEN " ).Append(Environment.NewLine);
            selectTxt.Append(loopIndex * cndtnWork.DataSize + 1).Append(Environment.NewLine);
            selectTxt.Append(" AND ").Append(Environment.NewLine);
            selectTxt.Append((loopIndex + 1) * cndtnWork.DataSize).Append(Environment.NewLine);

            return selectTxt.ToString();

        }

         /// <summary>
        /// 移動データ検索文
        /// </summary>
        /// <remarks>
        /// <br>Note        : 移動データ検索文処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private string MakeMoveWhereString(PartsMaxStockArrivalCondt cndtnWork, bool moveDiv)
        {
            StringBuilder sqlTxt = new StringBuilder();
            //検索条件
            sqlTxt.Append(" WHERE ").Append(Environment.NewLine);

            // 企業コード
            sqlTxt.Append(" STMOVE.ENTERPRISECODERF=@ENTERPRISECODERF ").Append(Environment.NewLine);

            // 論理削除区分
            sqlTxt.Append(" AND STMOVE.LOGICALDELETECODERF=@ALOGICALDELETECODERF").Append(Environment.NewLine);


            // 出庫拠点コード
            if (!string.IsNullOrEmpty(cndtnWork.BfSectionCode))
            {
                sqlTxt.Append(" AND STMOVE.BFSECTIONCODERF=@BFSECTIONCODE ").Append(Environment.NewLine);
               
            }
            // 入庫拠点コード
            if (!string.IsNullOrEmpty(cndtnWork.AfSectionCode))
            {
                sqlTxt.Append(" AND STMOVE.AFSECTIONCODERF=@AFSECTIONCODE ").Append(Environment.NewLine);
               
            }
            sqlTxt.Append(" AND STMOVE.STOCKMOVEFORMALRF IN (1, 2) ").Append(Environment.NewLine);
            // 出荷日付
            sqlTxt.Append(" AND STMOVE.SHIPMENTFIXDAYRF BETWEEN @ARRIVALGOODSDAYST AND @ARRIVALGOODSDAYED").Append(Environment.NewLine);

            // 移動先倉庫コード     ※配列で複数指定される
            if (cndtnWork.AfWarehouseCodeList != null)
            {
                string warehouseCodestr = "";
                foreach (string whsCdstr in cndtnWork.AfWarehouseCodeList)
                {
                    if (warehouseCodestr != "")
                    {
                        warehouseCodestr += ",";
                    }
                    warehouseCodestr += "'" + whsCdstr + "'";
                }

                if (warehouseCodestr != "")
                {
                    sqlTxt.Append(" AND STMOVE.AFENTERWAREHCODERF IN (" + warehouseCodestr + ") ").Append(Environment.NewLine);
                }
            }

            // 移動元倉庫コード     ※配列で複数指定される
            if (cndtnWork.BfWarehouseCodeList != null)
            {
                string warehouseCdstr = "";
                foreach (string whCdstr in cndtnWork.BfWarehouseCodeList)
                {
                    if (warehouseCdstr != "")
                    {
                        warehouseCdstr += ",";
                    }
                    warehouseCdstr += "'" + whCdstr + "'";
                }

                if (warehouseCdstr != "")
                {
                    sqlTxt.Append(" AND STMOVE.BFENTERWAREHCODERF IN (" + warehouseCdstr + ") ").Append(Environment.NewLine);
                }
            }
            return sqlTxt.ToString();

        }

        /// <summary>
        /// 件数検索文
        /// </summary>
        /// <remarks>
        /// <br>Note        : 件数検索文</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private string MakeMoveCountString()
        {
            StringBuilder selectTxt = new StringBuilder();
            selectTxt.Append("SELECT ").Append(Environment.NewLine);
            selectTxt.Append("COUNT(*) AS SALESDT_COUNT ").Append(Environment.NewLine);
            selectTxt.Append("FROM STOCKMOVERF AS STMOVE WITH (READUNCOMMITTED) --在庫移動データ").Append(Environment.NewLine);
            return selectTxt.ToString();

        }

        /// <summary>
        /// 移動データの格納
        /// </summary>
        /// <returns>移動データ</returns>
        /// <remarks>
        /// <br>Note       : 移動データの格納を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        /// <br>Update Note : PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
        //private PartsMaxStockArrivalWork CopyMoveDataFromSqlDataReader(SqlDataReader myReader)
        private PartsMaxStockArrivalWork CopyMoveDataFromSqlDataReader(SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
        {
            PartsMaxStockArrivalWork moveDataExportResultWork = new PartsMaxStockArrivalWork();

            #region 検索結果の格納
            moveDataExportResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            moveDataExportResultWork.ShipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            moveDataExportResultWork.StockMoveSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF"));
            moveDataExportResultWork.StockMoveSlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            moveDataExportResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            moveDataExportResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            moveDataExportResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            moveDataExportResultWork.GoodsMakerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            moveDataExportResultWork.BLGoodsCod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            moveDataExportResultWork.ShipmentCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
            moveDataExportResultWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF")).Trim();
            moveDataExportResultWork.BfSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF"));
            moveDataExportResultWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF")).Trim();
            moveDataExportResultWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
            moveDataExportResultWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF")).Trim();
            moveDataExportResultWork.AfSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF"));
            moveDataExportResultWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF")).Trim();
            moveDataExportResultWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
            moveDataExportResultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));// オープン価格区分
            moveDataExportResultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            //moveDataExportResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = moveDataExportResultWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = moveDataExportResultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = moveDataExportResultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            moveDataExportResultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            moveDataExportResultWork.GpuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));// 価格マスタの原価単価
            moveDataExportResultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            moveDataExportResultWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            moveDataExportResultWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            moveDataExportResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// 拠点コード
            moveDataExportResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));// 仕入先コード
            moveDataExportResultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));//商品掛率グループコード
            moveDataExportResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BLグループコード
            moveDataExportResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));//商品中分類コード
            moveDataExportResultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//商品掛率ランク
            moveDataExportResultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));//課税区

            #endregion

            return moveDataExportResultWork;
        }
        #endregion

    }
}

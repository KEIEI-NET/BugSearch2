//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先別見積書・棚卸表 
// プログラム概要   : 得意先別見積書・棚卸表 DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10970531-00  作成担当 : songg
// 作 成 日  K2013/12/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 呉元嘯
// 修 正 日  2020/08/20   修正内容 : PMKOBETSU-4005 価格マスタ　定価数値変換対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先別見積書・棚卸表DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別見積書・棚卸表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : K2013/12/03</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2020/08/20</br>
    /// </remarks>
    [Serializable]
    public class TakekawaQuotaInventWorkDB : RemoteDB, ITakekawaQuotaInventWorkDB
    {
        /// <summary>
        /// 得意先別見積書・棚卸表DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        public TakekawaQuotaInventWorkDB()
            :
            base("PMMIT02009DC", "Broadleaf.Application.Remoting.ParamData.TakekawaQuotaInventResultWork", "SUPLIERPAYRF")
        {
        }

        #region ■ [Search]
        /// <summary>
        /// 指定された条件の得意先別見積書・棚卸表を戻します
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">検索結果</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name="takekawaQuotaInventCndtnWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 指定された条件の得意先別見積書・棚卸表を戻します</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        public int Search(out object takekawaQuotaInventResultWork, 
            out object goodsPriceUWorkList,
            object takekawaQuotaInventCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            takekawaQuotaInventResultWork = null;
            goodsPriceUWorkList = null;
            SqlConnection sqlConnection = null;

            TakekawaQuotaInventCndtnWork paraCndtnWork = takekawaQuotaInventCndtnWork as TakekawaQuotaInventCndtnWork;
            try
            {
                //SQL文生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // 選択区分：0:見積書,1:棚卸表
                if (paraCndtnWork.SelectFlg == 0)
                {
                    status = SearchProcForQuotation(out takekawaQuotaInventResultWork,
                        out goodsPriceUWorkList,
                        paraCndtnWork, logicalMode, ref sqlConnection);
                }
                else
                {
                    status = SearchProcForInventory(out takekawaQuotaInventResultWork,
                        out goodsPriceUWorkList,
                        paraCndtnWork, logicalMode, ref sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.Search Exception=" + ex.Message);
                takekawaQuotaInventResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion  //[Search]

        #region
        /// <summary>
        /// 売上全体設定の取得処理
        /// </summary>
        /// <param name="takekawaQuotaInventCndtnWork">検索条件</param>
        /// <returns>すべて売上全体設定</returns>
        /// <remarks>
        /// <br>Note       : 売上全体設定の取得処理を行う。</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        private Dictionary<string, SalesTtlStWork> GetSalesTtlSt(TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork)
        {
            SalesTtlStDB salesTtlStDB = new SalesTtlStDB();
            object tempSalesTtlStList = null;

            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode; // 企業コード設定
            ArrayList salesTtlStWorkList = new ArrayList();
            salesTtlStWorkList.Add(salesTtlStWork);
            salesTtlStDB.Search(out tempSalesTtlStList, salesTtlStWorkList, 0, ConstantManagement.LogicalMode.GetData0);

            Dictionary<string, SalesTtlStWork> salesTtlStWorkDic = new Dictionary<string, SalesTtlStWork>();
            foreach (SalesTtlStWork tempSalesTtlStWork in (ArrayList)tempSalesTtlStList)
            {
                if (!salesTtlStWorkDic.ContainsKey(tempSalesTtlStWork.SectionCode.Trim()))
                {
                    salesTtlStWorkDic.Add(tempSalesTtlStWork.SectionCode.Trim(), tempSalesTtlStWork);
                }
            }

            return salesTtlStWorkDic;
        }
        #endregion

        #region ■ [SearchProcForQuotation]得意先別見積書検索
        /// <summary>
        /// 得意先別見積書LISTを全て戻します
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">検索結果</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name="takekawaQuotaInventCndtnWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 得意先別見積書・棚卸表LISTを全て戻します</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProcForQuotation(out object takekawaQuotaInventResultWork,
            out object goodsPriceUWorkList,
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,
            ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //初期処理
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            takekawaQuotaInventResultWork = null;
            goodsPriceUWorkList = null;

            // 全て売上全体設定情報検索
            Dictionary<string, SalesTtlStWork> salesTtlStDic = GetSalesTtlSt(takekawaQuotaInventCndtnWork);

            ArrayList retList = new ArrayList();   //抽出結果

            ArrayList tempGoodsPriceUWorkList = new ArrayList(); // 価格マスタリスト

            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);

                #region [Select文作成]
                selectTxt.Append(" SELECT  ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.PRICESTARTDATERF, -- 価格マスタ.価格開始日").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.LISTPRICERF, --価格マスタ.定価（浮動）").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.SALESUNITCOSTRF, --価格マスタ.原価単価").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.STOCKRATERF, --価格マスタ.仕入率").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OPENPRICEDIVRF, --価格マスタ.オープン価格区分").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OFFERDATERF, --価格マスタ.提供日付").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.UPDATEDATERF, --価格マスタ.更新年月日").Append(Environment.NewLine);

                selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BLグループコード").Append(Environment.NewLine);

                selectTxt.Append(" STOCK.ENTERPRISECODERF, -- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.WAREHOUSECODERF, -- 倉庫コード ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.WAREHOUSESHELFNORF, -- 倉庫棚番 ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.GOODSMAKERCDRF, -- 商品メーカーコード ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.GOODSNORF, -- 商品番号 ").Append(Environment.NewLine);
                selectTxt.Append(" STOCK.SECTIONCODERF AS STOCK_SECTIONCODERF, --在庫の拠点コード").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNAMERF, -- 商品名称 ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNORF AS GOODSU_GOODSNORF, -- 商品マスタの論理削除判断用項目 ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.BLGOODSCODERF, -- ＢＬ商品コード ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSRATERANKRF, -- 商品掛率ランク ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.TAXATIONDIVCDRF,-- 課税区分 ").Append(Environment.NewLine);

                selectTxt.Append(" BLGROUPU.GOODSMGROUPRF, -- 商品中分類コード ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.WAREHOUSECODERF, -- 倉庫コード ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.WAREHOUSENAMERF, -- 倉庫名称 ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.CUSTOMERCODERF, --得意先コード ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAMERF,-- 得意先名称１ ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAME2RF, -- 得意先名称２ ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.MNGSECTIONCODERF AS SECTIONCODERF, -- 拠点コード ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESUNPRCFRCPROCCDRF, --売上単価端数処理コード ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESCNSTAXFRCPROCCDRF, --売上消費税端数処理コード ").Append(Environment.NewLine);

                selectTxt.Append(" CLAIMER.CUSTCTAXLAYREFCDRF,--請求先の得意先消費税転嫁方式参照区分").Append(Environment.NewLine);
                selectTxt.Append(" CLAIMER.CONSTAXLAYMETHODRF,--請求先の消費税転嫁方式").Append(Environment.NewLine);

                selectTxt.Append(" SECINFOSET.SECTIONGUIDENMRF, --拠点ガイド名称 ").Append(Environment.NewLine);
                selectTxt.Append(" SECINFOSET.COMPANYNAMECD1RF, --自社名称コード1 ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.POSTNORF, -- 郵便番号 ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS1RF, -- 住所1（都道府県市区郡・町村・字） ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS3RF -- 住所3（番地） ").Append(Environment.NewLine);
                
                selectTxt.Append(" FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) -- 在庫マスタ ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --商品マスタ").Append(Environment.NewLine);
                selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- 商品メーカーコード ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSNORF = GOODSU.GOODSNORF -- 商品番号 ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --ＢＬ商品コードマスタ(ユーザー)").Append(Environment.NewLine);
                selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL商品コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BLグループマスタ（ユーザー登録分）").Append(Environment.NewLine);
                selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BLグループコード ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) --倉庫マスタ").Append(Environment.NewLine);
                selectTxt.Append(" ON STOCK.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF-- 倉庫コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                
                selectTxt.Append(" INNER JOIN CUSTOMERRF AS CUSTOMER WITH (READUNCOMMITTED) --得意先マスタ").Append(Environment.NewLine);
                selectTxt.Append(" ON WAREHOUSE.ENTERPRISECODERF = CUSTOMER.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF = CUSTOMER.CUSTOMERCODERF--得意先コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);


                selectTxt.Append(" LEFT JOIN CUSTOMERRF AS CLAIMER WITH (READUNCOMMITTED) --得意先マスタ（請求先情報）").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = CLAIMER.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.CLAIMCODERF = CLAIMER.CUSTOMERCODERF--得意先コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CLAIMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                
                selectTxt.Append(" INNER JOIN SECINFOSETRF AS SECINFOSET WITH (READUNCOMMITTED)-- 拠点情報設定マスタ ").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = SECINFOSET.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF = SECINFOSET.SECTIONCODERF-- 拠点コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                
                selectTxt.Append(" LEFT JOIN COMPANYNMRF AS COMPANYNM WITH (READUNCOMMITTED)--自社名称マスタ ").Append(Environment.NewLine);
                selectTxt.Append(" ON SECINFOSET.ENTERPRISECODERF = COMPANYNM.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.COMPANYNAMECD1RF = COMPANYNM.COMPANYNAMECDRF--自社名称コード ").Append(Environment.NewLine);

                // 性能アップ
                // 価格マスタ情報を取得する
                selectTxt.Append(" LEFT JOIN GOODSPRICEURF AS GOODSPRICEU WITH (READUNCOMMITTED)--価格マスタ ").Append(Environment.NewLine);
                selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSPRICEU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSPRICEU.GOODSMAKERCDRF--商品メーカーコード ").Append(Environment.NewLine);
                selectTxt.Append(" AND STOCK.GOODSNORF = GOODSPRICEU.GOODSNORF--商品番号 ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSPRICEU.LOGICALDELETECODERF = 0--論理削除区分 ").Append(Environment.NewLine);


                #region where
                selectTxt.Append("  WHERE  ").Append(Environment.NewLine);
                selectTxt.Append("  STOCK.ENTERPRISECODERF = @ENTERPRISECODE1 -- 企業コード ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.EnterpriseCode);
                selectTxt.Append("  AND STOCK.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                //拠点コード
                if (takekawaQuotaInventCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in takekawaQuotaInventCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt.Append(" AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ")");
                        selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF IN (" + sectionCodestr + ")");
                    }
                    selectTxt.Append(Environment.NewLine);
                }


                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim()))
                {
                    selectTxt.Append(" AND STOCK.WAREHOUSECODERF >= @WAREHOUSECODEST1 -- 倉庫コード開始 ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEST1 = sqlCommand.Parameters.Add("@WAREHOUSECODEST1", SqlDbType.NChar);
                    paraWAREHOUSECODEST1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim());
                }

                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim()))
                {
                    selectTxt.Append(" AND STOCK.WAREHOUSECODERF <= @WAREHOUSECODEED1 -- 倉庫コード終了 ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEED1 = sqlCommand.Parameters.Add("@WAREHOUSECODEED1", SqlDbType.NChar);
                    paraWAREHOUSECODEED1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim());

                }

                if (takekawaQuotaInventCndtnWork.GoodsMakerCdSt != 0)
                {
                    selectTxt.Append(" AND STOCK.GOODSMAKERCDRF >= @GOODSMAKERCDST1 -- メーカー開始 ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDST1 = sqlCommand.Parameters.Add("@GOODSMAKERCDST1", SqlDbType.Int);
                    paraGOODSMAKERCDST1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdSt);
                }

                if (takekawaQuotaInventCndtnWork.GoodsMakerCdEd != 0)
                {
                    selectTxt.Append(" AND STOCK.GOODSMAKERCDRF <= @GOODSMAKERCDED1 -- メーカー終了 ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDED1 = sqlCommand.Parameters.Add("@GOODSMAKERCDED1", SqlDbType.Int);
                    paraGOODSMAKERCDED1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdEd);
                }

                if (takekawaQuotaInventCndtnWork.CustomerCodeSt != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF >= @CUSTOMERCODEST4 -- 得意先開始 ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEST4 = sqlCommand.Parameters.Add("@CUSTOMERCODEST4", SqlDbType.Int);
                    paraCUSTOMERCODEST4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeSt);
                }
                if (takekawaQuotaInventCndtnWork.CustomerCodeEd != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF <= @CUSTOMERCODEED4 -- 得意先終了 ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEED4 = sqlCommand.Parameters.Add("@CUSTOMERCODEED4", SqlDbType.Int);
                    paraCUSTOMERCODEED4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeEd);
                }
                #endregion


                selectTxt.Append("  --拠点, 得意先, 倉庫, 棚番, 品番,メーカー ASC").Append(Environment.NewLine);
                selectTxt.Append("  --価格開始日 DESC").Append(Environment.NewLine);
                selectTxt.Append(" ORDER BY CUSTOMER.MNGSECTIONCODERF ASC, WAREHOUSE.CUSTOMERCODERF ASC, WAREHOUSE.WAREHOUSECODERF ASC, STOCK.WAREHOUSESHELFNORF ASC, STOCK.GOODSNORF ASC, STOCK.GOODSMAKERCDRF ASC ").Append(Environment.NewLine);
                selectTxt.Append(" , GOODSPRICEU.PRICESTARTDATERF DESC ").Append(Environment.NewLine);

                #endregion

                sqlCommand.CommandText = selectTxt.ToString();

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();


                // 仕入先取得用
                GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
                Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //拠点＋メーカー＋品番
                Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //拠点＋中分類＋メーカー＋ＢＬ
                Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //拠点＋中分類＋メーカー
                Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //拠点＋メーカー

                // 商品管理情報すべて取得
                goodsSupplierGetter.GetGoodsMngInfo(takekawaQuotaInventCndtnWork.EnterpriseCode,
                    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);


                // key : メーカー　＋　品番
                Dictionary<string, string> goodsDic = new Dictionary<string, string>();

                // ＢＬ商品コードマスタDictionary(キー：BL商品コード)
                Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic = new Dictionary<int, BLGoodsCdUWork>();


                while (myReader.Read())
                {
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                    //TakekawaQuotaInventResultWork resultWork = CopyToTakekawaQuotaResultWorkFromReader(ref myReader,
                    //    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                    //    takekawaQuotaInventCndtnWork, ref goodsSupplierGetter, ref goodsDic, ref tempGoodsPriceUWorkList,
                    //    ref salesTtlStDic,
                    //    ref blGoodsCdUDic);
                    TakekawaQuotaInventResultWork resultWork = CopyToTakekawaQuotaResultWorkFromReader(ref myReader,
                        ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                        takekawaQuotaInventCndtnWork, ref goodsSupplierGetter, ref goodsDic, ref tempGoodsPriceUWorkList,
                        ref salesTtlStDic,
                        ref blGoodsCdUDic, convertDoubleRelease);
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
                    if (null != resultWork)
                    {
                        retList.Add(resultWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // データがない場合、
                if ((null == retList) || (retList.Count == 0))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }

            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchProcForQuotation Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }

                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            }

            takekawaQuotaInventResultWork = retList;
            goodsPriceUWorkList = tempGoodsPriceUWorkList;

            return status;
        }
        #endregion  //[SearchProcForQuotation]

        #region ■ [SearchProcForInventory]得意先別棚卸表検索
        /// <summary>
        /// 指定された企業コードの得意先別棚卸表LISTを全て戻します
        /// </summary>
        /// <param name="takekawaQuotaInventResultWork">検索結果</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name="takekawaQuotaInventCndtnWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 指定された企業コードの得意先別棚卸表LISTを全て戻します</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        private int SearchProcForInventory(out object takekawaQuotaInventResultWork,
            out object goodsPriceUWorkList, 
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork, 
            ConstantManagement.LogicalMode logicalMode, 
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //初期処理
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            takekawaQuotaInventResultWork = null;
            goodsPriceUWorkList = null;

            // 全て売上全体設定情報検索
            Dictionary<string, SalesTtlStWork> salesTtlStDic = GetSalesTtlSt(takekawaQuotaInventCndtnWork);

            ArrayList retList = new ArrayList();   //抽出結果

            ArrayList tempGoodsPriceUWorkList = new ArrayList(); // 価格マスタリスト

            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);

                #region [Select文作成]
                selectTxt.Append(" SELECT  ").Append(Environment.NewLine);

                selectTxt.Append(" GOODSPRICEU.PRICESTARTDATERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.LISTPRICERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.SALESUNITCOSTRF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.STOCKRATERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OPENPRICEDIVRF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.OFFERDATERF, ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSPRICEU.UPDATEDATERF, ").Append(Environment.NewLine);

                selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BLグループコード").Append(Environment.NewLine);

                selectTxt.Append(" CASE WHEN INVENTORYDATA.INVENTORYDAYRF IS NOT NULL THEN INVENTORYDATA.INVENTORYSTOCKCNTRF ELSE INVENTORYDATA.STOCKTOTALRF END AS INVENTORYSTOCKCNTRF, --棚卸在庫数(画面表示用) ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.INVENTORYSTOCKCNTRF AS INVENTORYSTOCKCNTRF1, --棚卸在庫数(チェック用) ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.SUPPLIERCDRF, -- 仕入先コード ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.ENTERPRISECODERF, -- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.WAREHOUSECODERF, -- 倉庫コード ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.WAREHOUSESHELFNORF, -- 倉庫棚番 ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.GOODSMAKERCDRF, -- 商品メーカーコード ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.GOODSNORF, -- 商品番号 ").Append(Environment.NewLine);
                selectTxt.Append(" INVENTORYDATA.SECTIONCODERF AS INVENTORYDATA_SECTIONCODERF, -- 棚卸データの拠点コード ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.BLGOODSCODERF, -- BL商品コード ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNAMERF, -- 商品名称 ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSNORF AS GOODSU_GOODSNORF, -- 商品マスタの論理削除判断用項目 ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.GOODSRATERANKRF, -- 商品掛率ランク ").Append(Environment.NewLine);
                selectTxt.Append(" GOODSU.TAXATIONDIVCDRF,-- 課税区分 ").Append(Environment.NewLine);

                selectTxt.Append(" BLGROUPU.GOODSMGROUPRF, -- 商品中分類コード ").Append(Environment.NewLine);

                selectTxt.Append(" WAREHOUSE.WAREHOUSECODERF, -- 倉庫コード ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.WAREHOUSENAMERF, -- 倉庫名称 ").Append(Environment.NewLine);
                selectTxt.Append(" WAREHOUSE.CUSTOMERCODERF, --得意先コード ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAMERF,-- 得意先名称１ ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.NAME2RF, -- 得意先名称２ ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.MNGSECTIONCODERF AS SECTIONCODERF, -- 拠点コード ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESUNPRCFRCPROCCDRF, --売上単価端数処理コード ").Append(Environment.NewLine);
                selectTxt.Append(" CUSTOMER.SALESCNSTAXFRCPROCCDRF, --売上消費税端数処理コード ").Append(Environment.NewLine);

                selectTxt.Append(" CLAIMER.CUSTCTAXLAYREFCDRF,--請求先の得意先消費税転嫁方式参照区分").Append(Environment.NewLine);
                selectTxt.Append(" CLAIMER.CONSTAXLAYMETHODRF,--請求先の消費税転嫁方式").Append(Environment.NewLine);

                selectTxt.Append(" SECINFOSET.SECTIONGUIDENMRF, --拠点ガイド名称 ").Append(Environment.NewLine);
                selectTxt.Append(" SECINFOSET.COMPANYNAMECD1RF, --自社名称コード1 ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.POSTNORF, -- 郵便番号 ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS1RF, -- 住所1（都道府県市区郡・町村・字） ").Append(Environment.NewLine);
                selectTxt.Append(" COMPANYNM.ADDRESS3RF -- 住所3（番地） ").Append(Environment.NewLine);
                selectTxt.Append(" FROM INVENTORYDATARF AS INVENTORYDATA WITH (READUNCOMMITTED)  -- 棚卸データ ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --商品マスタ").Append(Environment.NewLine);
                selectTxt.Append(" ON INVENTORYDATA.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- 商品メーカーコード ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSNORF = GOODSU.GOODSNORF -- 商品番号 ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --ＢＬ商品コードマスタ(ユーザー)").Append(Environment.NewLine);
                selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL商品コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BLグループマスタ（ユーザー登録分）").Append(Environment.NewLine);
                selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BLグループコード ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append(" ON INVENTORYDATA.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF-- 倉庫コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN CUSTOMERRF AS CUSTOMER WITH (READUNCOMMITTED) --得意先マスタ").Append(Environment.NewLine);
                selectTxt.Append(" ON WAREHOUSE.ENTERPRISECODERF = CUSTOMER.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF = CUSTOMER.CUSTOMERCODERF--得意先コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN CUSTOMERRF AS CLAIMER WITH (READUNCOMMITTED) --得意先マスタ（請求先情報）").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = CLAIMER.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.CLAIMCODERF = CLAIMER.CUSTOMERCODERF--得意先コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CLAIMER.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                selectTxt.Append(" INNER JOIN SECINFOSETRF AS SECINFOSET WITH (READUNCOMMITTED)-- 拠点情報設定マスタ ").Append(Environment.NewLine);
                selectTxt.Append(" ON CUSTOMER.ENTERPRISECODERF = SECINFOSET.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF = SECINFOSET.SECTIONCODERF-- 拠点コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                selectTxt.Append(" LEFT JOIN COMPANYNMRF AS COMPANYNM WITH (READUNCOMMITTED)--自社名称マスタ ").Append(Environment.NewLine);
                selectTxt.Append(" ON SECINFOSET.ENTERPRISECODERF = COMPANYNM.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND SECINFOSET.COMPANYNAMECD1RF = COMPANYNM.COMPANYNAMECDRF--自社名称コード ").Append(Environment.NewLine);

                // 性能アップ
                // 価格マスタ情報を取得する
                selectTxt.Append(" LEFT JOIN GOODSPRICEURF AS GOODSPRICEU WITH (READUNCOMMITTED)--価格マスタ ").Append(Environment.NewLine);
                selectTxt.Append(" ON INVENTORYDATA.ENTERPRISECODERF = GOODSPRICEU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSMAKERCDRF = GOODSPRICEU.GOODSMAKERCDRF--商品メーカーコード ").Append(Environment.NewLine);
                selectTxt.Append(" AND INVENTORYDATA.GOODSNORF = GOODSPRICEU.GOODSNORF--商品番号 ").Append(Environment.NewLine);
                selectTxt.Append(" AND GOODSPRICEU.LOGICALDELETECODERF = 0--論理削除区分 ").Append(Environment.NewLine);

                selectTxt.Append("  WHERE  ").Append(Environment.NewLine);
                selectTxt.Append("  INVENTORYDATA.ENTERPRISECODERF = @ENTERPRISECODE1 -- 企業コード ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.EnterpriseCode);

                selectTxt.Append("  AND INVENTORYDATA.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);

                //拠点コード
                if (takekawaQuotaInventCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in takekawaQuotaInventCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt.Append(" AND INVENTORYDATA.SECTIONCODERF IN (" + sectionCodestr + ")");
                        selectTxt.Append(" AND CUSTOMER.MNGSECTIONCODERF IN (" + sectionCodestr + ")");
                    }
                    selectTxt.Append(Environment.NewLine);
                }


                if (takekawaQuotaInventCndtnWork.StSupplierCd != 0)
                {
                    selectTxt.Append(" AND INVENTORYDATA.SUPPLIERCDRF >= @STSUPPLIERCD1 -- 仕入先開始 ").Append(Environment.NewLine);
                    SqlParameter paraSTSUPPLIERCD1 = sqlCommand.Parameters.Add("@STSUPPLIERCD1", SqlDbType.Int);
                    paraSTSUPPLIERCD1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.StSupplierCd);
                }

                if (takekawaQuotaInventCndtnWork.EdSupplierCd != 0)
                {
                    selectTxt.Append(" AND INVENTORYDATA.SUPPLIERCDRF <= @EDSUPPLIERCD1 -- 仕入先終了 ").Append(Environment.NewLine);
                    SqlParameter paraEDSUPPLIERCD1 = sqlCommand.Parameters.Add("@EDSUPPLIERCD1", SqlDbType.Int);
                    paraEDSUPPLIERCD1.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.EdSupplierCd);
                }


                if (takekawaQuotaInventCndtnWork.GoodsMakerCdSt != 0)
                {
                    selectTxt.Append(" AND GOODSU.GOODSMAKERCDRF >= @GOODSMAKERCDST2 -- メーカー開始 ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDST2 = sqlCommand.Parameters.Add("@GOODSMAKERCDST2", SqlDbType.Int);
                    paraGOODSMAKERCDST2.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdSt);
                }

                if (takekawaQuotaInventCndtnWork.GoodsMakerCdEd != 0)
                {
                    selectTxt.Append(" AND GOODSU.GOODSMAKERCDRF <= @GOODSMAKERCDED2 -- メーカー終了 ").Append(Environment.NewLine);
                    SqlParameter paraGOODSMAKERCDED2 = sqlCommand.Parameters.Add("@GOODSMAKERCDED2", SqlDbType.Int);
                    paraGOODSMAKERCDED2.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.GoodsMakerCdEd);
                }

                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim()))
                {
                    selectTxt.Append(" AND WAREHOUSE.WAREHOUSECODERF >= @WAREHOUSECODEST4 -- 倉庫コード開始 ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEST4 = sqlCommand.Parameters.Add("@WAREHOUSECODEST4", SqlDbType.NChar);
                    paraWAREHOUSECODEST4.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeSt.Trim());
                }

                if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim()))
                {
                    selectTxt.Append(" AND WAREHOUSE.WAREHOUSECODERF <= @WAREHOUSECODEED4 -- 倉庫コード終了 ").Append(Environment.NewLine);
                    SqlParameter paraWAREHOUSECODEED4 = sqlCommand.Parameters.Add("@WAREHOUSECODEED4", SqlDbType.NChar);
                    paraWAREHOUSECODEED4.Value = SqlDataMediator.SqlSetString(takekawaQuotaInventCndtnWork.WarehouseCodeEd.Trim());
                }

                if (takekawaQuotaInventCndtnWork.CustomerCodeSt != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF >= @CUSTOMERCODEST4 -- 得意先開始 ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEST4 = sqlCommand.Parameters.Add("@CUSTOMERCODEST4", SqlDbType.Int);
                    paraCUSTOMERCODEST4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeSt);
                }
                if (takekawaQuotaInventCndtnWork.CustomerCodeEd != 0)
                {
                    selectTxt.Append(" AND WAREHOUSE.CUSTOMERCODERF <= @CUSTOMERCODEED4 -- 得意先終了 ").Append(Environment.NewLine);
                    SqlParameter paraCUSTOMERCODEED4 = sqlCommand.Parameters.Add("@CUSTOMERCODEED4", SqlDbType.Int);
                    paraCUSTOMERCODEED4.Value = SqlDataMediator.SqlSetInt32(takekawaQuotaInventCndtnWork.CustomerCodeEd);
                }


                selectTxt.Append("  --拠点, 得意先, 倉庫, 棚番, 品番,メーカー ").Append(Environment.NewLine);
                selectTxt.Append(" ORDER BY CUSTOMER.MNGSECTIONCODERF ASC, WAREHOUSE.CUSTOMERCODERF ASC, WAREHOUSE.WAREHOUSECODERF ASC, INVENTORYDATA.WAREHOUSESHELFNORF ASC, INVENTORYDATA.GOODSNORF ASC, INVENTORYDATA.GOODSMAKERCDRF ASC ").Append(Environment.NewLine);
                selectTxt.Append(" , GOODSPRICEU.PRICESTARTDATERF DESC ").Append(Environment.NewLine);

                #endregion

                sqlCommand.CommandText = selectTxt.ToString();

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();


                // key : メーカー　＋　品番
                Dictionary<string, string> goodsDic = new Dictionary<string, string>();

                // ＢＬ商品コードマスタDictionary(キー：BL商品コード)
                Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic = new Dictionary<int, BLGoodsCdUWork>();

                while (myReader.Read())
                {
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                    //TakekawaQuotaInventResultWork resultWork = CopyToTakekawaInventResultWorkFromReader(ref myReader, takekawaQuotaInventCndtnWork,
                    //    ref goodsDic, ref tempGoodsPriceUWorkList, ref salesTtlStDic, ref blGoodsCdUDic);
                    TakekawaQuotaInventResultWork resultWork = CopyToTakekawaInventResultWorkFromReader(ref myReader, takekawaQuotaInventCndtnWork,
                        ref goodsDic, ref tempGoodsPriceUWorkList, ref salesTtlStDic, ref blGoodsCdUDic, convertDoubleRelease);
                    // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<

                    if (resultWork != null)
                    {
                        retList.Add(resultWork);
                    }
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
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchProcForInventory Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }

                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            }

            takekawaQuotaInventResultWork = retList;
            goodsPriceUWorkList = tempGoodsPriceUWorkList; 

            return status;
        }
        #endregion  //[SearchProcForInventory]

        #region ■ [得意先別見積書抽出結果クラス格納処理]
        /// <summary>
        /// 得意先別見積書・棚卸表抽出結果クラス格納処理 Reader → TakekawaQuotaInventResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsMngDic1">拠点＋メーカー＋品番Dictionary</param>
        /// <param name="goodsMngDic2">拠点＋中分類＋メーカー＋ＢＬコードDictionary</param>
        /// <param name="goodsMngDic3">拠点＋中分類＋メーカーDictionary</param>
        /// <param name="goodsMngDic4">拠点＋メーカーDictionary</param>
        /// <param name="takekawaQuotaInventCndtnWork">検索条件</param>
        /// <param name="goodsSupplierGetter">GoodsSupplierGetter</param>
        /// <param name="goodsDic">商品情報チェック用Dictionary</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name="salesTtlStDic">全て売上全体設定情報Dictionary</param>
        /// <param name="blGoodsCdUDic">ＢＬ商品コードマスタDictionary</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>TakekawaQuotaInventResultWork</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
        //private TakekawaQuotaInventResultWork CopyToTakekawaQuotaResultWorkFromReader(ref SqlDataReader myReader,
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // 拠点＋メーカー＋品番
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // 拠点＋中分類＋メーカー＋ＢＬコード
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // 拠点＋中分類＋メーカー
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // 拠点＋メーカー
        //    TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,// 検索条件
        //    ref GoodsSupplierGetter goodsSupplierGetter,
        //    ref Dictionary<string, string> goodsDic, 
        //    ref ArrayList goodsPriceUWorkList,
        //    ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
        //    ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic)
        private TakekawaQuotaInventResultWork CopyToTakekawaQuotaResultWorkFromReader(ref SqlDataReader myReader,
            ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // 拠点＋メーカー＋品番
            ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // 拠点＋中分類＋メーカー＋ＢＬコード
            ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // 拠点＋中分類＋メーカー
            ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // 拠点＋メーカー
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,// 検索条件
            ref GoodsSupplierGetter goodsSupplierGetter,
            ref Dictionary<string, string> goodsDic,
            ref ArrayList goodsPriceUWorkList,
            ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
            ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic,
            ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
        {
            //フィルタ
            // 在庫マスタの拠点コードと得意先の管理拠点不同で、対象外とする
            string customerMngSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();
            string stockSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCK_SECTIONCODERF")).Trim();
            if (!customerMngSection.Equals(stockSection))
            {
                return null;
            }

            TakekawaQuotaInventResultWork resultWork = new TakekawaQuotaInventResultWork();
            #region [抽出結果-値セット]
            resultWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // 拠点名称
            resultWork.SectionPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));// 拠点郵便番号
            resultWork.SectionAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));// 拠点住所①
            resultWork.SectionAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));// 拠点住所②
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));// 倉庫コード
            resultWork.WarehouseNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// 倉庫名称
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));// 倉庫棚番
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));// 商品番号
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));// 商品名称
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));// 商品メーカーコード
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// 拠点コード
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));// 得意先コード
            resultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));// 得意先名称１
            resultWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));// 得意先名称１
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));// BL商品コード

            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BLグループコード
            resultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));//商品掛率グループコード
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//商品掛率ランク
            resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));//課税区分

            resultWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));//得意先の売上単価端数処理コード
            resultWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));//得意先の売上消費税端数処理コード

            resultWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));// 請求先の得意先消費税転嫁方式参照区分
            resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// 請求先の消費税転嫁方式




            // 得意先の管理拠点より、売上全体設定情報取得
            SalesTtlStWork tempSalesTtlStWork = null;
            if (salesTtlStDic.ContainsKey(resultWork.SectionCode.Trim()))
            {
                tempSalesTtlStWork = salesTtlStDic[resultWork.SectionCode.Trim()];
            }

            // 自拠点がない場合、全体の売り上げ全体設定情報取得
            if (null == tempSalesTtlStWork)
            {
                if (salesTtlStDic.ContainsKey("00"))
                {
                    tempSalesTtlStWork = salesTtlStDic["00"];
                }
            }

            // BLコード０対応判断処理
            if ((null != tempSalesTtlStWork) && (resultWork.BLGoodsCode == 0) && 
                (tempSalesTtlStWork.BLGoodsCdZeroSuprt == 1) && // BLコード０対応フラグ
                    (tempSalesTtlStWork.BLGoodsCdChange > 0)) // 変換コードがある
            {
                // 変換コード再度設定
                resultWork.BLGoodsCode = tempSalesTtlStWork.BLGoodsCdChange;

                #region BLGoodsCode再度変更の場合、相関情報再度設定が必要です。
                if (blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                {
                    // BLグループコード
                    resultWork.BLGroupCode = blGoodsCdUDic[resultWork.BLGoodsCode].BLGroupCode;
                    // 商品掛率グループコード
                    resultWork.GoodsRateGrpCode = blGoodsCdUDic[resultWork.BLGoodsCode].GoodsRateGrpCode;
                }
                else
                {
                    BLGoodsCdUWork tempBLGoodsCdUWork = new BLGoodsCdUWork();

                    // BL商品情報再検索
                    int blGoodsCdU_status = this.SearchBLInfo(takekawaQuotaInventCndtnWork.EnterpriseCode,
                        resultWork.BLGoodsCode,
                        out tempBLGoodsCdUWork);
                    if (0 == blGoodsCdU_status)
                    {
                        // BLグループコード
                        resultWork.BLGroupCode = tempBLGoodsCdUWork.BLGroupCode;
                        // 商品掛率グループコード
                        resultWork.GoodsRateGrpCode = tempBLGoodsCdUWork.GoodsRateGrpCode;

                        if (!blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                        {
                            blGoodsCdUDic.Add(resultWork.BLGoodsCode, tempBLGoodsCdUWork);
                        }
                    }
                }
                #endregion
            }

            // BLコードフィルタ処理
            if ((resultWork.BLGoodsCode < takekawaQuotaInventCndtnWork.BLGoodsCodeSt)
                    || (resultWork.BLGoodsCode > takekawaQuotaInventCndtnWork.BLGoodsCodeEd))
            {
                return null;
            }

            // 開始部品棚番判定
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoSt))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, "<", takekawaQuotaInventCndtnWork.WarehouseShelfNoSt, 8))
                {
                    return null;
                }
            }

            // 終了部品棚番判定
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoEd))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, ">", takekawaQuotaInventCndtnWork.WarehouseShelfNoEd, 8))
                {
                    return null;
                }
            }

            // 仕入先コード
            int supplierCd = 0;

            #region 商品仕入取得データクラス
            GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
            goodsSupplierDataWork.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode;// 企業コード
            goodsSupplierDataWork.SectionCode = resultWork.SectionCode;      　// 得意先の管理拠点コード
            goodsSupplierDataWork.GoodsMakerCd = resultWork.GoodsMakerCd;     // メーカーコード
            goodsSupplierDataWork.GoodsNo = resultWork.GoodsNo;              // 商品番号
            goodsSupplierDataWork.BLGoodsCode = resultWork.BLGoodsCode;     // BLコード
            goodsSupplierDataWork.GoodsMGroup = resultWork.GoodsRateGrpCode; // 商品中分類
            goodsSupplierGetter.GetSupplierInfo(ref goodsSupplierDataWork, goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4);

            // 拠点より検索しない場合、全社で再度検索します。
            if (null != goodsSupplierDataWork)
            {
                supplierCd = goodsSupplierDataWork.SupplierCd;
            }
            else
            {
                supplierCd = 0;
            }

            // 仕入先コード設定
            resultWork.SupplierCd = supplierCd;


            // ★★★仕入先コードフィルタ処理★★★
            if ((supplierCd < takekawaQuotaInventCndtnWork.StSupplierCd) 
                || (supplierCd > takekawaQuotaInventCndtnWork.EdSupplierCd))
            {
                return null;
            }
            #endregion

            #region 価格マスタ情報取得
            // 価格マスタ情報取得
            GoodsPriceUWork tempGoodsPriceUWork = new GoodsPriceUWork();
            tempGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            tempGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            tempGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            //tempGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = tempGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = tempGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            tempGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            tempGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            tempGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            tempGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            tempGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            tempGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            if ((tempGoodsPriceUWork.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(tempGoodsPriceUWork.GoodsNo)))
            {
                goodsPriceUWorkList.Add(tempGoodsPriceUWork);
            }
            #endregion

            // 画面表示用在庫情報は一つ取得
            // key : 倉庫 + 品番 ＋メーカー
            string key = resultWork.WarehouseCode + ":"
              + resultWork.GoodsNo + ":"
              + resultWork.GoodsMakerCd.ToString();
            if (goodsDic.ContainsKey(key))
            {
                return null;
            }
            else
            {
                goodsDic.Add(key, key);
            }


            // 商品がない場合、商品名称再度設定が必要です
            if (string.IsNullOrEmpty(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSU_GOODSNORF"))))
            {
                resultWork.GoodsName = "********************";
            }


            #endregion  //[抽出結果-値セット]

            return resultWork;
        }

        /// <summary>
        /// 得意先別棚卸表抽出結果クラス格納処理 Reader → TakekawaQuotaInventResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="takekawaQuotaInventCndtnWork">検索条件</param>
        /// <param name="goodsDic">商品チェック用Dictionary</param>
        /// <param name="goodsPriceUWorkList">価格マスタリスト</param>
        /// <param name="salesTtlStDic">全て売上全体設定情報Dictionary</param>
        /// <param name="blGoodsCdUDic">ＢＬ商品コードマスタDictionary</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>TakekawaQuotaInventResultWork</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2020/08/20</br>
        /// </remarks>
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
        //private TakekawaQuotaInventResultWork CopyToTakekawaInventResultWorkFromReader(ref SqlDataReader myReader, 
        //    TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,
        //    ref Dictionary<string, string> goodsDic, 
        //    ref ArrayList goodsPriceUWorkList,
        //    ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
        //    ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic)
        private TakekawaQuotaInventResultWork CopyToTakekawaInventResultWorkFromReader(ref SqlDataReader myReader,
            TakekawaQuotaInventCndtnWork takekawaQuotaInventCndtnWork,
            ref Dictionary<string, string> goodsDic,
            ref ArrayList goodsPriceUWorkList,
            ref Dictionary<string, SalesTtlStWork> salesTtlStDic,
            ref Dictionary<int, BLGoodsCdUWork> blGoodsCdUDic,
            ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
        {
            //フィルタ
            // 棚卸データの拠点コードと得意先の管理拠点不同で、対象外とする
            string customerMngSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")).Trim();
            string inventorySection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INVENTORYDATA_SECTIONCODERF")).Trim();
            if (!customerMngSection.Equals(inventorySection))
            {
                return null;
            }

            TakekawaQuotaInventResultWork resultWork = new TakekawaQuotaInventResultWork();
            #region [抽出結果-値セット]
            resultWork.SectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // 拠点名称
            resultWork.SectionPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));// 拠点郵便番号
            resultWork.SectionAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));// 拠点住所①
            resultWork.SectionAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));// 拠点住所②
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));// 倉庫コード
            resultWork.WarehouseNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// 倉庫名称
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));// 倉庫棚番
            resultWork.StockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("InventoryStockCntRF"));// 棚卸在庫数(画面表示用)
            resultWork.InventoryStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INVENTORYSTOCKCNTRF1"));// 棚卸在庫数(チェック用)
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));// 商品番号
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));// 商品名称
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));// 商品メーカーコード
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// 拠点コード
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));// 得意先コード
            resultWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));// 得意先名称１
            resultWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));// 得意先名称１
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));// ＢＬ商品コード
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));// 仕入先コード

            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BLグループコード
            resultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));//商品掛率グループコード
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//商品掛率ランク
            resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));//課税区分

            resultWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));//得意先の売上単価端数処理コード
            resultWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));//得意先の売上消費税端数処理コード

            resultWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));// 請求先の得意先消費税転嫁方式参照区分
            resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// 請求先の消費税転嫁方式

            // 得意先の管理拠点より、売上全体設定情報取得
            SalesTtlStWork tempSalesTtlStWork = null;
            if (salesTtlStDic.ContainsKey(resultWork.SectionCode.Trim()))
            {
                tempSalesTtlStWork = salesTtlStDic[resultWork.SectionCode.Trim()];
            }

            // 自拠点がない場合、全体の売り上げ全体設定情報取得
            if (null == tempSalesTtlStWork)
            {
                if (salesTtlStDic.ContainsKey("00"))
                {
                    tempSalesTtlStWork = salesTtlStDic["00"];
                }
            }


            if ((null != tempSalesTtlStWork) && 
                (resultWork.BLGoodsCode == 0) &&
                (tempSalesTtlStWork.BLGoodsCdZeroSuprt == 1) && // BLコード０対応フラグ
                (tempSalesTtlStWork.BLGoodsCdChange > 0)) // 変換コードがある
            {
                resultWork.BLGoodsCode = tempSalesTtlStWork.BLGoodsCdChange;

                #region BLGoodsCode再度変更の場合、相関情報再度設定が必要です。
                if (blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                {
                    // BLグループコード
                    resultWork.BLGroupCode = blGoodsCdUDic[resultWork.BLGoodsCode].BLGroupCode;
                    // 商品掛率グループコード(中分類)
                    resultWork.GoodsRateGrpCode = blGoodsCdUDic[resultWork.BLGoodsCode].GoodsRateGrpCode;
                }
                else
                {
                    BLGoodsCdUWork tempBLGoodsCdUWork = new BLGoodsCdUWork();

                    // BL商品情報再検索
                    int blGoodsCdU_status = this.SearchBLInfo(takekawaQuotaInventCndtnWork.EnterpriseCode,
                        resultWork.BLGoodsCode,
                        out tempBLGoodsCdUWork);
                    if (0 == blGoodsCdU_status)
                    {
                        // BLグループコード
                        resultWork.BLGroupCode = tempBLGoodsCdUWork.BLGroupCode;
                        // 商品掛率グループコード
                        resultWork.GoodsRateGrpCode = tempBLGoodsCdUWork.GoodsRateGrpCode;

                        if (!blGoodsCdUDic.ContainsKey(resultWork.BLGoodsCode))
                        {
                            blGoodsCdUDic.Add(resultWork.BLGoodsCode, tempBLGoodsCdUWork);
                        }
                    }
                }
                #endregion
            }

            // BLコードフィルタ処理
            if ((resultWork.BLGoodsCode < takekawaQuotaInventCndtnWork.BLGoodsCodeSt)
                    || (resultWork.BLGoodsCode > takekawaQuotaInventCndtnWork.BLGoodsCodeEd))
            {
                return null;
            }

            // 開始部品棚番判定
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoSt))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, "<", takekawaQuotaInventCndtnWork.WarehouseShelfNoSt, 8))
                {
                    return null;
                }
            }

            // 終了部品棚番判定
            if (!string.IsNullOrEmpty(takekawaQuotaInventCndtnWork.WarehouseShelfNoEd))
            {
                if (xCOMPSTR(resultWork.WarehouseShelfNo, ">", takekawaQuotaInventCndtnWork.WarehouseShelfNoEd, 8))
                {
                    return null;
                }
            }

            #region 価格マスタ情報取得
            // 価格マスタ情報取得
            GoodsPriceUWork tempGoodsPriceUWork = new GoodsPriceUWork();
            tempGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            tempGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            tempGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ---------->>>>>
            //tempGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = takekawaQuotaInventCndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = tempGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = tempGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            tempGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            // --- UPD 2020/08/20 呉元嘯 PMKOBETSU-4005 ----------<<<<<
            tempGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            tempGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            tempGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            tempGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            tempGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            if ((tempGoodsPriceUWork.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(tempGoodsPriceUWork.GoodsNo)))
            {
                goodsPriceUWorkList.Add(tempGoodsPriceUWork);
            }
            #endregion

            // 画面表示用在庫情報は一つ取得
            // key : 倉庫　＋　品番　＋メーカー +
            string key = resultWork.WarehouseCode + ":"
              + resultWork.GoodsNo + ":"
              + resultWork.GoodsMakerCd.ToString();

            if (goodsDic.ContainsKey(key))
            {
                return null;
            }
            else
            {
                goodsDic.Add(key, key);
            }

            // 商品がない場合、商品名称再度設定が必要です
            if (string.IsNullOrEmpty(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSU_GOODSNORF"))))
            {
                resultWork.GoodsName = "********************";
            }
            #endregion  //[抽出結果-値セット]
            return resultWork;
        }
        #endregion

        #region BL商品コードより、BL商品コードマスタ情報検索処理
        /// <summary>
        /// BL商品コードより、BL商品コードマスタとBLグループ情報検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="blGoodsCode">bl商品コード</param>
        /// <param name="blGoodsCdUWork">BL商品コードマスタ情報</param>
        /// <returns></returns>
        private int SearchBLInfo(string enterpriseCode, int blGoodsCode, out BLGoodsCdUWork blGoodsCdUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            blGoodsCdUWork = null;

            SqlConnection sqlConnection = null;

            try
            {
                //SQL文生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();


                status = SearchBlInfoProc(ref sqlConnection, enterpriseCode, blGoodsCode,
                    out blGoodsCdUWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchBLInfo Exception=" + ex.Message);
                blGoodsCdUWork = null;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 指定された企業コードのBL商品コードマスタ情報戻します
        /// </summary>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <param name="blGoodsCdUWork">BL商品コードマスタ情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        private int SearchBlInfoProc(ref SqlConnection sqlConnection, 
            string enterpriseCode, int blGoodsCode,
            out BLGoodsCdUWork blGoodsCdUWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //初期処理
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            blGoodsCdUWork = null;

            try
            {
                StringBuilder selectTxt = new StringBuilder();
                sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection);


                selectTxt.Append(" SELECT ").Append(Environment.NewLine);
                selectTxt.Append(" BLGOODSCDU.BLGOODSCODERF,-- BL商品コード ").Append(Environment.NewLine);
                selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BLグループコード  ").Append(Environment.NewLine);
                selectTxt.Append(" BLGROUPU.GOODSMGROUPRF -- 商品中分類コード ").Append(Environment.NewLine);
                selectTxt.Append(" FROM BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED)  --ＢＬコードマスタ(ユーザー) ").Append(Environment.NewLine);
                selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED)  --BLグループマスタ（ユーザー登録分） ").Append(Environment.NewLine);
                selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);
                selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BLグループコード ").Append(Environment.NewLine);

                selectTxt.Append(" WHERE ").Append(Environment.NewLine);
                selectTxt.Append(" BLGOODSCDU.ENTERPRISECODERF = @ENTERPRISECODE1 -- 企業コード ").Append(Environment.NewLine);
                SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
                paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                selectTxt.Append(" AND BLGOODSCDU.BLGOODSCODERF = @BLGOODSCODE -- BLコード ").Append(Environment.NewLine);

                SqlParameter paraBLGOODSCODE = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.NChar);
                paraBLGOODSCODE.Value = SqlDataMediator.SqlSetInt32(blGoodsCode);

                selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

                sqlCommand.CommandText = selectTxt.ToString();

                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    CopyToBlInfoResultWorkFromReader(ref myReader, out blGoodsCdUWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }

            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                blGoodsCdUWork = null;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TakekawaQuotaInventWorkDB.SearchBlInfoProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                blGoodsCdUWork = null;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// BL商品コードマスタ情報抽出結果クラス格納処理 Reader → BLGoodsCdUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blGoodsCdUWork">ＢＬ商品コードマスタクラス</param>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
        /// </remarks>
        private void CopyToBlInfoResultWorkFromReader(ref SqlDataReader myReader, 
            out BLGoodsCdUWork blGoodsCdUWork)
        {
            blGoodsCdUWork = new BLGoodsCdUWork();

            blGoodsCdUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL商品コード
            blGoodsCdUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));    // BLグループコード
            blGoodsCdUWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));// 商品中分類コード
        }
        #endregion

        #region ■ [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : K2013/12/03</br>
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

        #region 文字列比較処理
        /// <summary>
        /// 文字列比較処理　
        /// </summary>
        /// <param name="sStr1">比較対象文字列１</param>
        /// <param name="sCTL">コントロール</param>
        /// <param name="sStr2">比較対象文字列２</param>
        /// <param name="iMaxLen">比較最大文字列長</param>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note		: 文字列を比較します</br>
        /// <br>Programmer	: songg</br>
        /// <br>Date		: K2013/12/03</br>
        /// </remarks>
        private Boolean xCOMPSTR(string sStr1, string sCTL, string sStr2, int iMaxLen)
        {
            string pStr1 = string.Empty;
            string pStr2 = string.Empty;
            int iDumyLen;
            int iLen1;
            int iLen2;
            int iRet;
            int iIdx;
            int iStrLen;
            string sWrk1;
            string sWrk2;
            string sDumySpace;

            Boolean result = false;
            sWrk1 = sStr1;
            sWrk2 = sStr2;

            // 比較文字列１の編集
            iStrLen = sStr1.Length;
            iDumyLen = iMaxLen - iStrLen;
            sDumySpace = "";
            for (iIdx = 1; iIdx <= iDumyLen; iIdx++)
            {
                sDumySpace = sDumySpace + " ";
            }
            sWrk1 = sWrk1 + sDumySpace;


            iLen1 = 0;


            // 比較文字列２の編集
            iStrLen = sStr2.Length;
            iDumyLen = iMaxLen - iStrLen;
            sDumySpace = "";
            for (iIdx = 1; iIdx <= iDumyLen; iIdx++)
            {
                sDumySpace = sDumySpace + " ";
            }
            sWrk2 = sWrk2 + sDumySpace;

            // 比較文字列２の'*'の検索
            iLen2 = sWrk2.LastIndexOf('*');

            if ((iLen1 <= 0) && (iLen2 <= 0))
            {
                iLen1 = iMaxLen;
                iLen2 = iMaxLen;
            }
            else
            {
                if (iLen1 <= 0)
                {
                    iLen1 = iLen2;
                }
                else
                {
                    iLen2 = iLen1;
                }
            }

            //文字列比較
            pStr1 = sWrk1.Substring(0, iLen1);

            pStr2 = sWrk2.Substring(0, iLen2);

            iRet = string.Compare(pStr1, pStr2, StringComparison.Ordinal);

            // sStr1 = Str2
            if (sCTL.Equals("="))
            {
                if (iRet == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 > Str2
            if (sCTL.Equals(">"))
            {
                if (iRet > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 < Str2
            if (sCTL.Equals("<"))
            {
                if (iRet < 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 >= Str2
            if (sCTL.Equals(">="))
            {
                if (iRet >= 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            // sStr1 <= Str2
            if (sCTL.Equals("<="))
            {
                if (iRet <= 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }
        #endregion

    }
}


    


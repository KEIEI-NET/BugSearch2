//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新 DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00  作成担当 : 宋剛
// 作 成 日 : 2016/01/22   修正内容 : 新規作成
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
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 出品一括更新DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 出品一括更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 宋剛</br>
    /// <br>Date        : 2016/01/22</br>
    /// <br>Update Note : PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date        : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class PartsMaxStockUpdDB : RemoteDB, IPartsMaxStockUpdDB
    {
        #region Private Const
        // 最大検索件数
        private const int MAXCOUNT = 100000;
        #endregion

        #region PartsMaxStockUpdDB　コンストラクタ
        /// <summary>
        /// 出品一括更新コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public PartsMaxStockUpdDB()
        {
        }
        #endregion

        #region Private Method
        /// <summary>
        /// SELECTのSQL文
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索条件</param>
        /// <returns>select文</returns>
        /// <br>Note       : SELECTのSQL文を戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        private String GetSelectStr(SqlCommand sqlCommand, PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork)
        {
            StringBuilder selectTxt = new StringBuilder();

            selectTxt.Append(" SELECT  ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.PRICESTARTDATERF, -- 価格マスタ.価格開始日").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.LISTPRICERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.SALESUNITCOSTRF, ").Append(Environment.NewLine); // 価格マスタの原価単価
            selectTxt.Append(" GOODSPRICEU.STOCKRATERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.OPENPRICEDIVRF, --価格マスタ.オープン価格区分").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSPRICEU.OFFERDATERF, ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSPRICEU.UPDATEDATERF, ").Append(Environment.NewLine);

            selectTxt.Append(" BLGOODSCDU.BLGROUPCODERF, --BLグループコード").Append(Environment.NewLine);
            selectTxt.Append(" BLGOODSCDU.GOODSRATEGRPCODERF, --商品掛率グループコード").Append(Environment.NewLine);
            selectTxt.Append(" STOCK.ENTERPRISECODERF, -- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.WAREHOUSECODERF, -- 倉庫コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.GOODSMAKERCDRF, -- 商品メーカーコード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.GOODSNORF, -- 商品番号 ").Append(Environment.NewLine);                                     
            selectTxt.Append(" STOCK.SHIPMENTPOSCNTRF, --出荷可能数").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSU.GOODSNAMERF, -- 商品名称 ").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSU.BLGOODSCODERF, -- ＢＬ商品コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" GOODSU.GOODSRATERANKRF, -- 商品掛率ランク ").Append(Environment.NewLine);
            selectTxt.Append(" GOODSU.TAXATIONDIVCDRF,-- 課税区分 ").Append(Environment.NewLine);
            selectTxt.Append(" MAKERU.MAKERNAMERF, -- 商品メーカー名称 ").Append(Environment.NewLine);                                     
            selectTxt.Append(" BLGROUPU.GOODSMGROUPRF, -- 商品中分類コード ").Append(Environment.NewLine);
            selectTxt.Append(" WAREHOUSE.WAREHOUSENAMERF, -- 倉庫名称 ").Append(Environment.NewLine);                                     
            selectTxt.Append(" WAREHOUSE.SECTIONCODERF --倉庫マスタの管理拠点 ").Append(Environment.NewLine);                                     


            selectTxt.Append(" FROM STOCKRF AS STOCK WITH (READUNCOMMITTED) -- 在庫マスタ ").Append(Environment.NewLine);
            // 商品マスタ
            selectTxt.Append(" LEFT JOIN GOODSURF AS GOODSU WITH (READUNCOMMITTED) --商品マスタ").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSU.ENTERPRISECODERF -- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSU.GOODSMAKERCDRF -- 商品メーカーコード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSNORF = GOODSU.GOODSNORF -- 商品番号 ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND GOODSU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" LEFT JOIN MAKERURF AS MAKERU WITH (READUNCOMMITTED) --メーカーマスタ（ユーザー登録分）").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = MAKERU.ENTERPRISECODERF -- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = MAKERU.GOODSMAKERCDRF -- 商品メーカーコード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND MAKERU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" LEFT JOIN BLGOODSCDURF AS BLGOODSCDU WITH (READUNCOMMITTED) --ＢＬ商品コードマスタ(ユーザー)").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON GOODSU.ENTERPRISECODERF = BLGOODSCDU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND GOODSU.BLGOODSCODERF = BLGOODSCDU.BLGOODSCODERF-- BL商品コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND BLGOODSCDU.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" LEFT JOIN BLGROUPURF AS BLGROUPU WITH (READUNCOMMITTED) --BLグループマスタ（ユーザー登録分）").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON BLGOODSCDU.ENTERPRISECODERF = BLGROUPU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND BLGOODSCDU.BLGROUPCODERF = BLGROUPU.BLGROUPCODERF-- BLグループコード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND BLGROUPU.LOGICALDELETECODERF = 0-- 論理削除区分 ").Append(Environment.NewLine);                                     

            selectTxt.Append(" INNER JOIN WAREHOUSERF AS WAREHOUSE WITH (READUNCOMMITTED) --倉庫マスタ").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = WAREHOUSE.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.WAREHOUSECODERF = WAREHOUSE.WAREHOUSECODERF-- 倉庫コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND WAREHOUSE.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

            // 価格マスタ情報を取得する
            selectTxt.Append(" LEFT JOIN GOODSPRICEURF AS GOODSPRICEU WITH (READUNCOMMITTED)--価格マスタ ").Append(Environment.NewLine);                                     
            selectTxt.Append(" ON STOCK.ENTERPRISECODERF = GOODSPRICEU.ENTERPRISECODERF-- 企業コード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = GOODSPRICEU.GOODSMAKERCDRF--商品メーカーコード ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND STOCK.GOODSNORF = GOODSPRICEU.GOODSNORF--商品番号 ").Append(Environment.NewLine);                                     
            selectTxt.Append(" AND GOODSPRICEU.LOGICALDELETECODERF = 0--論理削除区分 ").Append(Environment.NewLine);                                     

            selectTxt.Append("AND GOODSPRICEU.PRICESTARTDATERF =  ").Append(Environment.NewLine);
            selectTxt.Append("(SELECT MAX(PRICESTARTDATERF) ").Append(Environment.NewLine);
            selectTxt.Append("FROM GOODSPRICEURF GSP_B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

            selectTxt.Append("WHERE GSP_B.ENTERPRISECODERF=STOCK.ENTERPRISECODERF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.GOODSNORF=STOCK.GOODSNORF ").Append(Environment.NewLine);
            selectTxt.Append("AND GSP_B.PRICESTARTDATERF <= @PRICESTARTDATE)").Append(Environment.NewLine);
            SqlParameter paraPRICESTARTDATE = sqlCommand.Parameters.Add("@PRICESTARTDATE", SqlDbType.Int);
            paraPRICESTARTDATE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.PriceStartDate);

            return selectTxt.ToString();
        }

        /// <summary>
        /// WHERE文のSQL文
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索条件</param>
        /// <returns>where文のSQL文</returns>
        /// <br>Note       : WHEREのSQL文を戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        private String GetWhereStr(SqlCommand sqlCommand, PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork)
        {
            StringBuilder selectTxt = new StringBuilder();

            selectTxt.Append("  WHERE  ").Append(Environment.NewLine);
            selectTxt.Append("  STOCK.ENTERPRISECODERF = @ENTERPRISECODE1 -- 企業コード ").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(partsMaxStockUpdateCndtnWork.EnterpriseCode);
            selectTxt.Append("  AND STOCK.LOGICALDELETECODERF = 0 -- 論理削除区分 ").Append(Environment.NewLine);


            // 倉庫ｺｰﾄﾞリスト
            if (null != partsMaxStockUpdateCndtnWork.WarehouseCodes &&
                partsMaxStockUpdateCndtnWork.WarehouseCodes.Length > 0)
            {
                string warehouseCodestr = "";
                foreach (string warehousecdstr in partsMaxStockUpdateCndtnWork.WarehouseCodes)
                {
                    if (warehouseCodestr != "")
                    {
                        warehouseCodestr += ",";
                    }
                    warehouseCodestr += "'" + warehousecdstr + "'";
                }

                if (warehouseCodestr != "")
                {
                    selectTxt.Append(" AND STOCK.WAREHOUSECODERF IN (" + warehouseCodestr + ") -- 倉庫コード ").Append(Environment.NewLine);
                }
            }

            // 在庫最終更新日付
            // 在庫.更新年月日 >= 画面.在庫最終更新日付
            if (partsMaxStockUpdateCndtnWork.LastStockUpdDate != 0)
            {
                selectTxt.Append(" AND STOCK.UPDATEDATERF >= @LASTSTOCKUPDDATE  ").Append(Environment.NewLine);
                SqlParameter paraLASTSTOCKUPDDATE = sqlCommand.Parameters.Add("@LASTSTOCKUPDDATE", SqlDbType.Int);
                paraLASTSTOCKUPDDATE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.LastStockUpdDate);
            }

            // 商品.BLコード = 画面.BLコード
            if (partsMaxStockUpdateCndtnWork.BLGoodsCode != 0)
            {
                selectTxt.Append(" AND GOODSU.BLGOODSCODERF = @BLGOODSCODE  ").Append(Environment.NewLine);
                SqlParameter paraBLGOODSCODE = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                paraBLGOODSCODE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.BLGoodsCode);
            }

            // メーカー
            if (partsMaxStockUpdateCndtnWork.GoodsMakerCd != 0)
            {
                selectTxt.Append(" AND STOCK.GOODSMAKERCDRF = @GOODSMAKERCD -- メーカー ").Append(Environment.NewLine);
                SqlParameter paraGOODSMAKERCD = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                paraGOODSMAKERCD.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.GoodsMakerCd);
            }

            // BLコードマスタ.商品掛率グループコード = 画面.商品掛率G
            if (partsMaxStockUpdateCndtnWork.RateGrpCode != 0)
            {
                selectTxt.Append(" AND BLGOODSCDU.GOODSRATEGRPCODERF = @RATEGRPCODE -- 商品掛率G ").Append(Environment.NewLine);
                SqlParameter paraRATEGRPCODE = sqlCommand.Parameters.Add("@RATEGRPCODE", SqlDbType.Int);
                paraRATEGRPCODE.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.RateGrpCode);
            }


            //グループコードマスタ.中分類コード = 画面.中分類
            if (partsMaxStockUpdateCndtnWork.GoodsMGroup != 0)
            {
                selectTxt.Append(" AND BLGROUPU.GOODSMGROUPRF = @GOODSMGROUP -- 中分類 ").Append(Environment.NewLine);
                SqlParameter paraGOODSMGROUP = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                paraGOODSMGROUP.Value = SqlDataMediator.SqlSetInt32(partsMaxStockUpdateCndtnWork.GoodsMGroup);
            }

            selectTxt.Append(" ORDER BY STOCK.WAREHOUSECODERF, STOCK.GOODSMAKERCDRF, STOCK.GOODSNORF");

            return selectTxt.ToString();
        }

        /// <summary>
        /// 出品一括更新抽出結果クラス格納処理 Reader → PartsMaxStockUpdateResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsMngDic1">拠点＋メーカー＋品番Dictionary</param>
        /// <param name="goodsMngDic2">拠点＋中分類＋メーカー＋ＢＬコードDictionary</param>
        /// <param name="goodsMngDic3">拠点＋中分類＋メーカーDictionary</param>
        /// <param name="goodsMngDic4">拠点＋メーカーDictionary</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索条件</param>
        /// <param name="goodsSupplierGetter">GoodsSupplierGetter</param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns>PartsMaxStockUpdateResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
        //private PartsMaxStockUpdateResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader,
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // 拠点＋メーカー＋品番
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // 拠点＋中分類＋メーカー＋ＢＬコード
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // 拠点＋中分類＋メーカー
        //    ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // 拠点＋メーカー
        //    PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,// 検索条件
        //    ref GoodsSupplierGetter goodsSupplierGetter)
        private PartsMaxStockUpdateResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader,
            ref Dictionary<string, GoodsMngWork> goodsMngDic1,     // 拠点＋メーカー＋品番
            ref Dictionary<string, GoodsMngWork> goodsMngDic2,     // 拠点＋中分類＋メーカー＋ＢＬコード
            ref Dictionary<string, GoodsMngWork> goodsMngDic3,     // 拠点＋中分類＋メーカー
            ref Dictionary<string, GoodsMngWork> goodsMngDic4,     // 拠点＋メーカー
            PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,// 検索条件
            ref GoodsSupplierGetter goodsSupplierGetter, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
        {
            PartsMaxStockUpdateResultWork resultWork = new PartsMaxStockUpdateResultWork();
            #region [抽出結果-値セット]

            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));// 倉庫コード
            resultWork.WarehouseNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));// 倉庫名称
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));// 商品番号
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));// 商品名称
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));// 商品メーカーコード
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));// 倉庫の管理拠点コード
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));// メーカー名称
            resultWork.StockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));// 在庫マスタ.出荷可能数
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));// BL商品コード
            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));//BLグループコード    BLコードマスタ．BLｸﾞﾙｰﾌﾟｺｰﾄﾞ
            resultWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));//商品掛率グループコード    BLコードマスタ.商品掛率グループコード 
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));//商品掛率ランク    商品マスタ(ユーザー)．商品掛率ランク
            resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));// 課税区分

            resultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            //resultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = partsMaxStockUpdateCndtnWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = resultWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = resultWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            resultWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            resultWork.GpuSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));// 価格マスタの原価単価
            resultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));// オープン価格区分
            resultWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            resultWork.UpdateDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            // 仕入先コード
            int supplierCd = 0;

            #region 商品仕入取得データクラス
            GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
            goodsSupplierDataWork.EnterpriseCode = partsMaxStockUpdateCndtnWork.EnterpriseCode;// 企業コード
            goodsSupplierDataWork.SectionCode = resultWork.SectionCode;      　// 得意先の管理拠点コード
            goodsSupplierDataWork.GoodsMakerCd = resultWork.GoodsMakerCd;     // メーカーコード
            goodsSupplierDataWork.GoodsNo = resultWork.GoodsNo;              // 商品番号
            goodsSupplierDataWork.BLGoodsCode = resultWork.BLGoodsCode;     // BLコード

            int goodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));// 商品中分類
            goodsSupplierDataWork.GoodsMGroup = goodsMGroup; // 商品中分類
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
            if ((partsMaxStockUpdateCndtnWork.SupplierCd != 0)
                && (supplierCd != partsMaxStockUpdateCndtnWork.SupplierCd))
            {
                return null;
            }
            #endregion

            #endregion  //[抽出結果-値セット]

            return resultWork;
        }
        #endregion  //[Search]

        #region 検索件数取得
        /// <summary>
        /// 指定された企業コードの部品MAX件数取得処理
        /// </summary>
        /// <param name="searchCount">検索件数</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された企業コードの部品MAX件数取得処理します</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        public int SearchCount(out int searchCount, object partsMaxStockUpdateCndtnWork, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            searchCount = 0;
            errMessage = "";
            PartsMaxStockUpdateCndtnWork paraCndtnWork = partsMaxStockUpdateCndtnWork as PartsMaxStockUpdateCndtnWork;

            try
            {
                //SQL文生成
                using (SqlConnection sqlConnection = CreateSqlConnection(true))
                {
                    if (sqlConnection == null) return status;

                    status = SearchCountProc(out searchCount,
                        paraCndtnWork, sqlConnection);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.SearchCount Exception=" + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 出品一括更新件数を全て戻します
        /// </summary>
        /// <param name="searchCount">検索件数</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 出品一括更新LISTを全て戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchCountProc(out int searchCount,
            PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,
            SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            searchCount = 0;

            //初期処理
            SqlDataReader myReader = null;

            ArrayList retList = new ArrayList();   //抽出結果
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            try
            {
                StringBuilder selectTxt = new StringBuilder();
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection))
                {
                    // [Select文作成]
                    #region [Select文作成]
                    selectTxt.Append(GetSelectStr(sqlCommand, partsMaxStockUpdateCndtnWork));
                    #endregion

                    // [Where文作成]
                    #region [Where文作成]
                    selectTxt.Append(GetWhereStr(sqlCommand, partsMaxStockUpdateCndtnWork));
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
                    goodsSupplierGetter.GetGoodsMngInfo(partsMaxStockUpdateCndtnWork.EnterpriseCode,
                        ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);


                    while (myReader.Read())
                    {
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                        //PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                        //    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                        //    partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter);
                        PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                            ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                            partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter, convertDoubleRelease);
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                        if (null != resultWork)
                        {
                            ++searchCount;

                            if (searchCount > MAXCOUNT)
                            {
                                break;
                            }
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // データがない場合、
                    if (searchCount == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    else if (searchCount > MAXCOUNT)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
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
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.SearchCountProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            return status;
        }
        #endregion
        
        #region データ取得
        /// 指定された条件の出品一括更新を戻します
        /// <param name="partsMaxStockUpdateResultWork">検索結果</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <br>Note       : 指定された条件の出品一括更新を戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        public int Search(out object partsMaxStockUpdateResultWork,
            object partsMaxStockUpdateCndtnWork, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            partsMaxStockUpdateResultWork = null;
            errMessage = string.Empty;

            PartsMaxStockUpdateCndtnWork paraCndtnWork = partsMaxStockUpdateCndtnWork as PartsMaxStockUpdateCndtnWork;
            try
            {
                //SQL文生成
                using (SqlConnection sqlConnection = CreateSqlConnection(true))
                {
                    if (sqlConnection == null) return status;


                    status = SearchProc(out partsMaxStockUpdateResultWork,
                        paraCndtnWork, sqlConnection, out errMessage, loopIndex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.Search Exception=" + ex.Message);
                partsMaxStockUpdateResultWork = new ArrayList();
                errMessage = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 出品一括更新LISTを全て戻します
        /// </summary>
        /// <param name="partsMaxStockUpdateResultWork">検索結果</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 出品一括更新LISTを全て戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        private int SearchProc(out object partsMaxStockUpdateResultWork,
            PartsMaxStockUpdateCndtnWork partsMaxStockUpdateCndtnWork,
            SqlConnection sqlConnection, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            errMessage = "";
            //初期処理
            SqlDataReader myReader = null;
            partsMaxStockUpdateResultWork = null;

            ArrayList retList = new ArrayList();   //抽出結果
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            try
            {
                StringBuilder selectTxt = new StringBuilder();
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt.ToString(), sqlConnection))
                {
                    // [Select文作成]
                    #region [Select文作成]
                    selectTxt.Append(GetSelectStr(sqlCommand, partsMaxStockUpdateCndtnWork));
                    #endregion

                    // [Where文作成]
                    #region [Where文作成]
                    selectTxt.Append(GetWhereStr(sqlCommand, partsMaxStockUpdateCndtnWork));
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
                    goodsSupplierGetter.GetGoodsMngInfo(partsMaxStockUpdateCndtnWork.EnterpriseCode,
                        ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4);


                    // key : メーカー　＋　品番
                    Dictionary<string, string> goodsDic = new Dictionary<string, string>();

                    int cnt = 0;
                    while (myReader.Read())
                    {
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                        //PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                        //    ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                        //    partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter);
                        PartsMaxStockUpdateResultWork resultWork = CopyToResultWorkFromReader(ref myReader,
                            ref goodsMngDic1, ref goodsMngDic2, ref goodsMngDic3, ref goodsMngDic4,
                            partsMaxStockUpdateCndtnWork, ref goodsSupplierGetter, convertDoubleRelease);
                        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                        if (null != resultWork)
                        {
                            cnt++;

                            if ((cnt >= (loopIndex * partsMaxStockUpdateCndtnWork.DataSize + 1))
                                &&
                                (cnt <= ((loopIndex + 1) * partsMaxStockUpdateCndtnWork.DataSize)))
                            {
                                retList.Add(resultWork);
                            }
                        }


                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    // データがない場合、
                    if ((null == retList) || (retList.Count == 0))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
            }

            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errMessage = ex.Message;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PartsMaxStockUpdDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.Message;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }

            partsMaxStockUpdateResultWork = retList;

            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection生成処理。</br>
        /// <br>Programmer  : 宋剛</br>
        /// <br>Date        : 2016/01/22</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection返す
            return retSqlConnection;
        }
        #endregion  //コネクション生成処理
    }
}

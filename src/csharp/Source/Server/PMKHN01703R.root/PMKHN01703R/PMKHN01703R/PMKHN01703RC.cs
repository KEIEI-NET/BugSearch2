//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業商品在庫マスタ変換処理
// プログラム概要   : 条件を満たしたデータをテキストファイルへ出力する
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/02/26  修正内容 : Redmine#44209 メッセージの文言対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/03/02  修正内容 : Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 呉軍
// 作 成 日  2015/04/15  修正内容 : Redmine#45436 №78在庫受払履歴データ登録不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 呉軍
// 作 成 日  2015/04/17  修正内容 : Redmine#45436 №78在庫調整作成条件の修正
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 時シン
// 作 成 日  2015/04/27  修正内容 : レビュー結果対応(statusにより判断処理の追加) 
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 西 毅
// 作 成 日  2015/06/20  修正内容 : 倉庫マスタが1件もない場合にエラーで終了してしまう不具合の修正
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 譚洪
// 作 成 日  2020/06/18  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
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
using System.Text.RegularExpressions;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 明治産業商品在庫マスタ変換処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note        : 商品在庫マスタ変換処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2015/01/26</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsStockDB : RemoteDB
    {
        # region メッセージ
        //----- DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応----->>>>>
        //// 排他チェックメッセージ
        //private const string EXISTMSG = "変換先品番が既に登録されました";
        //// 論理削除チェックメッセージ
        //private const string DELETEMSG = "論理削除データ";
        //// 更新失敗の場合
        //private const string DELETEERRMSG = "排他エラー、変換元品番の削除に失敗しました";
        //// 変換元異常エラーの場合
        //private const string OLDEXCEPTIONMSG = "削除エラー、変換元品番の削除に失敗しました";
        //// 変換先異常エラーの場合
        //private const string NEWEXCEPTIONMSG = "登録エラー、変換先品番の登録に失敗しました";
        ////　商品マスタエラーが発生する場合
        //private const string GOODSMSTERRMSG = "商品マスタエラーの為、処理出来ませんでした。商品マスタのエラーログを確認して下さい";
        ////　価格マスタエラーが発生する場合
        //private const string PRICEMSTERRMSG = "価格マスタエラーの為、処理出来ませんでした。価格マスタのエラーログを確認して下さい";
        ////　同じ品番、価格マスタエラーが発生する場合
        //private const string PRICEMSTERRMSG2 = "同一品番の価格設定でエラーがあった為、当該品番処理出来ませんでした";
        ////　在庫マスタエラーが発生する場合
        //private const string STOCKMSTERRMSG = "在庫マスタエラーの為、処理出来ませんでした。在庫マスタのエラーログを確認して下さい";
        ////　同じ品番、在庫マスタエラーが発生する場合
        //private const string STOCKMSTERRMSG2 = "同一品番の在庫設定でエラーがあった為、当該品番処理出来ませんでした";
        ////　不整合データがある場合
        //private const string UNNORMALDATA = "商品マスタが存在しない為、当該品番処理できませんでした";
        //----- DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応-----<<<<<
        # endregion

        #region 既存のリモート
        private GoodsPriceUDB _iGoodsPriceUDB;
        private StockAdjustDB _iStockAdjustDB;
        private GoodsUDB _iGoodsUDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        #region MeijiGoodsStockDB
        /// <summary>
        /// 商品在庫マスタ変換処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 特になし</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsStockDB()
        {
            // 商品マスタ
            if (this._iGoodsUDB == null)
            {
                this._iGoodsUDB = new GoodsUDB();
            }
            // 価格マスタ
            if (this._iGoodsPriceUDB == null)
            {
                this._iGoodsPriceUDB = new GoodsPriceUDB();
            }
            // 商品在庫調整マスタ
            if (this._iStockAdjustDB == null)
            {
                this._iStockAdjustDB = new StockAdjustDB();
            }
            // 品番変換処理共通
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
        }
        #endregion

        #region 共通メソッド
        #region Mainメッソード
        /// <summary>
        /// 品番変換処理
        /// </summary>
        /// <param name="goodsSuccessResultWork">商品マスタ変換成功リスト</param>
        /// <param name="goodsErrorResultWork">商品マスタ変換失敗リスト</param>
        /// <param name="goodsUpdateCount">商品マスタ読込件数</param>
        /// <param name="goodsPriceCount">価格マスタ読込件数</param>
        /// <param name="stockCount">在庫マスタ読込件数</param>
        /// <param name="updateMode">画面に処理区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="goodsChangeAllCndWorkWork">条件ワーク</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        /// </remarks>
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        //public int WriteGoods(out object goodsSuccessResultWork, out object goodsErrorResultWork, out object priceSuccessResultWork, out object priceErrorResultWork,
        //    out object stockSuccessResultWork, out object stockErrorResultWork, out int goodsUpdateCount, out int goodsPriceCount, out int stockCount, int updateMode,
        //    string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork)
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        public int WriteGoods(out object goodsSuccessResultWork, out object goodsErrorResultWork, out int goodsUpdateCount, out int goodsPriceCount, out int stockCount, 
            int updateMode, string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork)
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        {
            // コネクション
            SqlConnection sqlConnection = null;
            // トランザクション
            SqlTransaction sqlTransaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region 商品マスタ
            // 商品マスタログ
            goodsUpdateCount = 0;
            goodsSuccessResultWork = null;
            goodsErrorResultWork = null;
            ArrayList goodsSuccessResultWorkList = new ArrayList();
            ArrayList goodsErrorResultWorkList = new ArrayList();
            #endregion

            #region 価格情報
            // 価格情報ログ
            goodsPriceCount = 0;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //priceSuccessResultWork = null;
            //priceErrorResultWork = null;
            //ArrayList priceSuccessResultWorkList = new ArrayList();
            //ArrayList priceErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            #endregion

            #region 在庫マスタ
            // 在庫マスタログ
            stockCount = 0;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //stockSuccessResultWork = null;
            //stockErrorResultWork = null;
            //ArrayList stockSuccessResultWorkList = new ArrayList();
            //ArrayList stockErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            #endregion

            try
            {
                // コネクション生成
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this._iGoodsNoChgCommonDB.CreateTransaction(ref sqlConnection);

                // 商品在庫マスタ変換処理
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                //status = WriteInProc(out goodsSuccessResultWorkList, out goodsErrorResultWorkList, out priceSuccessResultWorkList, out priceErrorResultWorkList,
                //    out stockSuccessResultWorkList, out stockErrorResultWorkList, out goodsUpdateCount, out goodsPriceCount, out stockCount, updateMode, enterPriseCode,
                //    goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                status = WriteInProc(out goodsSuccessResultWorkList, out goodsErrorResultWorkList, out goodsUpdateCount, out goodsPriceCount, out stockCount, 
                    updateMode, enterPriseCode, goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

                // 戻られるリスト
                // 商品マスタ
                goodsSuccessResultWork = goodsSuccessResultWorkList;
                goodsErrorResultWork = goodsErrorResultWorkList;
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                //// 価格情報
                //priceSuccessResultWork = priceSuccessResultWorkList;
                //priceErrorResultWork = priceErrorResultWorkList;
                //// 在庫マスタ
                //stockSuccessResultWork = stockSuccessResultWorkList;
                //stockErrorResultWork = stockErrorResultWorkList;
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.WriteIn");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 商品マスタ、価格マスタ、在庫マスタに品番変換処理
        /// </summary>
        /// <param name="goodsSuccessResultWorkList">商品取込成功リスト</param>
        /// <param name="goodsErrorResultWorkList">商品取込失敗リスト</param>
        /// <param name="updateCountGoods">商品マスタ読込件数</param>
        /// <param name="updateCountPrice">価格マスタ読込件数</param>
        /// <param name="updateCountStock">在庫マスタ読込件数</param>
        /// <param name="updateMode">画面に処理区分</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="goodsChangeAllCndWorkWork">条件ワーク</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/03/02 時シン </br>
        /// <br>            : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        /// </remarks>
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        //private int WriteInProc(out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList, out ArrayList priceSuccessResultWorkList, out ArrayList priceErrorResultWorkList
        //    , out ArrayList stockSuccessResultWorkList, out ArrayList stockErrorResultWorkList, out int updateCountGoods, out int updateCountPrice, out int updateCountStock
        //    , int updateMode, string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        private int WriteInProc(out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList, out int updateCountGoods, out int updateCountPrice, out int updateCountStock, 
            int updateMode, string enterPriseCode, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 商品マスタ
            goodsSuccessResultWorkList = new ArrayList();
            goodsErrorResultWorkList = new ArrayList();
            ArrayList goodsDataList = new ArrayList();
            updateCountGoods = 0;

            // 価格情報 
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //priceSuccessResultWorkList = new ArrayList();
            //priceErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            ArrayList priceDataList = new ArrayList();
            updateCountPrice = 0;

            // 在庫マスタ
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //stockSuccessResultWorkList = new ArrayList();
            //stockErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            ArrayList stockDataList = new ArrayList();
            updateCountStock = 0;

            // 品番変換エラーデータ、更新追加Dictionary
            Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();

            // メーカーDictionary
            Dictionary<int, string> makerDic = new Dictionary<int, string>();
            // 倉庫Dictionary
            Dictionary<int, string> wareHouseDic = new Dictionary<int, string>();
            // BL商品Dictionary
            Dictionary<int, string> blGoodsDic = new Dictionary<int, string>();
            // 拠点Dictionary
            Dictionary<string, string> sectionDic = new Dictionary<string, string>();
            // 新旧品番のDictionary
            Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();

            try
            {
                // メーカー、倉庫、BL商品情報の検索
                status = this.SearchWorkDate(out makerDic, out wareHouseDic, out blGoodsDic, out sectionDic, enterPriseCode);

                #region 商品マスタ、価格マスタ、在庫マスタ新旧品番データ取得
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.SearchGoodsPirceStockALL(out goodsDataList, out priceDataList, out stockDataList, out goodsNoAllDic, updateMode, enterPriseCode);
                }
                else
                {
                    return status;
                }
                #endregion 新旧品番データ取得

                #region 品番変換エラーデータを削除する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this._iGoodsNoChgCommonDB.DeleteGoodsNoChangeErrorDataProc(enterPriseCode, GoodsNoChgCommonDB.GOODSMST, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    return status;
                }
                #endregion

                #region 商品マスタの品番毎に、対応する商品マスタ、価格マスタ、在庫マスタ新旧品番変換
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 読込件数のセット
                    updateCountGoods = goodsDataList.Count;
                    updateCountPrice = priceDataList.Count;
                    updateCountStock = stockDataList.Count;

                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                    //status = this.GoodsStockChgPrc(goodsDataList, priceDataList, stockDataList, makerDic, wareHouseDic, blGoodsDic, sectionDic, goodsNoAllDic,
                    //    out goodsNoChgErrDic, out goodsSuccessResultWorkList, out goodsErrorResultWorkList, out priceSuccessResultWorkList, out priceErrorResultWorkList,
                    //    out stockSuccessResultWorkList, out stockErrorResultWorkList, goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                    status = this.GoodsStockChgPrc(goodsDataList, priceDataList, stockDataList, makerDic, wareHouseDic, blGoodsDic, sectionDic, goodsNoAllDic, out goodsNoChgErrDic, 
                        out goodsSuccessResultWorkList, out goodsErrorResultWorkList, goodsChangeAllCndWorkWork, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                }
                else
                {
                    return status;
                }
                #endregion 商品マスタの品番毎に、対応する商品マスタ、価格マスタ、在庫マスタ新旧品番変換

                #region 品番変換エラーデータを追加する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this._iGoodsNoChgCommonDB.WriteGoodsNoChangeErrorDataProc(goodsNoChgErrDic, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    return status;
                }
                #endregion
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.WriteInProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region 総括検索
        /// <summary>
        /// 指定された条件の商品マスタ、価格マスタ、在庫マスタ情報LISTを戻します
        /// </summary>
        /// <param name="goodsuWorkList">商品検索結果</param>
        /// <param name="goodsPriceWorkList">価格検索結果</param>
        /// <param name="stockWorkList">在庫検索結果</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件の商品マスタ、価格マスタ、在庫マスタ情報LISTを戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchGoodsPirceStockALL(out ArrayList goodsuWorkList, out ArrayList goodsPriceWorkList, 
            out ArrayList stockWorkList, out Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode)
        {
            // 戻るパラーメタ
            goodsuWorkList = new ArrayList();
            goodsPriceWorkList = new ArrayList();
            stockWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション
            SqlConnection goodsStockConnection = null;

            try
            {
                goodsStockConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // 商品マスタ検索
                status = this.SearchGoodsUProcProc(out goodsuWorkList, ref goodsNoAllDic, updateMode, enterPriseCode, ref goodsStockConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return status;
                }

                // 価格マスタ検索
                status = this.SearchGoodsPriceProc(out goodsPriceWorkList, ref goodsNoAllDic, updateMode, enterPriseCode, ref goodsStockConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return status;
                }

                // 在庫マスタ検索
                status = this.SearchStockInfoListProc(out stockWorkList, ref goodsNoAllDic, updateMode, enterPriseCode, ref goodsStockConnection);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.SearchGoodsPirceStockALL");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (goodsStockConnection != null)
                {
                    goodsStockConnection.Close();
                    goodsStockConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region 総括変換
        /// <summary>
        /// 指定された条件の商品マスタ、価格マスタ、在庫マスタを変換する
        /// </summary>
        /// <param name="goodsDataList">商品検索結果</param>
        /// <param name="priceDataList">価格検索結果</param>
        /// <param name="stockDataList">在庫検索結果</param>
        /// <param name="makerDic">メーカーのDictionary</param>
        /// <param name="wareHouseDic">倉庫のDictionary</param>
        /// <param name="blGoodsDic">ＢＬコードのDictionary</param>
        /// <param name="sectionDic">拠点のDictionary</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="goodsNoChgErrDic">品番変換失敗のDictionary</param>
        /// <param name="goodsSuccessResultWorkList">商品取込成功リスト</param>
        /// <param name="goodsErrorResultWorkList">商品取込失敗リスト</param>
        /// <param name="goodsChangeAllCndWorkWork">条件ワーク</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件の商品マスタ、価格マスタ、在庫マスタ情報LISTを戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        //private int GoodsStockChgPrc(ArrayList goodsDataList, ArrayList priceDataList, ArrayList stockDataList, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic,
        //    Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic,
        //    out Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic, out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList,
        //    out ArrayList priceSuccessResultWorkList, out ArrayList priceErrorResultWorkList, out ArrayList stockSuccessResultWorkList, out ArrayList stockErrorResultWorkList,
        //    GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        private int GoodsStockChgPrc(ArrayList goodsDataList, ArrayList priceDataList, ArrayList stockDataList, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic,
            Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic,
            out Dictionary<string, GoodsNoChangeErrorDataWork> goodsNoChgErrDic, out ArrayList goodsSuccessResultWorkList, out ArrayList goodsErrorResultWorkList,
            GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // ログリスト
            goodsSuccessResultWorkList = new ArrayList();
            goodsErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //priceSuccessResultWorkList = new ArrayList();
            //priceErrorResultWorkList = new ArrayList();
            //stockSuccessResultWorkList = new ArrayList();
            //stockErrorResultWorkList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            // 各リスト
            ArrayList chgPirceList = new ArrayList();
            ArrayList chgStockList = new ArrayList();
            ArrayList successLogList = null;

            string message = "";
            MeijiGoodsStockWork meijiGoodsStockWork = null;
            Object errorWork = new Object();
            GoodsPriceUWork priceResultWork;
            GoodsUWork goodsStockWork;
            GoodsUWork goodsChgWork;
            goodsNoChgErrDic = new Dictionary<string, GoodsNoChangeErrorDataWork>();
            Dictionary<string, string> goodsStockAllDic = new Dictionary<string, string>();

            // 商品マスタ、価格マスタ、在庫マスタに全て品番を作成
            SetGoodsDic(goodsDataList, priceDataList, stockDataList, out goodsStockAllDic);

            #region 商品マスタ、価格マスタ、在庫マスタに新旧品番を変換する
            foreach (string goodsNoKey in goodsStockAllDic.Keys)
            {
                // 品番対応の商品マスタリスト、価格マスタリスト、在庫マスタリストを取得する
                GetGoodsWork(goodsNoKey, goodsDataList, out goodsChgWork);
                GetPriceList(goodsNoKey, priceDataList, out chgPirceList);
                GetStockList(goodsNoKey, stockDataList, out chgStockList);

                #region 商品マスタに該当品番がない
                if (goodsChgWork == null || 
                    goodsChgWork.GoodsMakerCd == 0 || string.IsNullOrEmpty(goodsChgWork.GoodsNo.Trim()))
                {
                    // 不整合データログのセット
                    //SetUnNormalData(goodsNoKey, goodsNoAllDic[goodsNoKey], chgPirceList, chgStockList, ref priceErrorResultWorkList, ref stockErrorResultWorkList);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    SetUnNormalData(goodsNoKey, goodsNoAllDic[goodsNoKey], chgPirceList, chgStockList, ref goodsErrorResultWorkList);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応

                    // 品番更新エラーデータの作成
                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = this.GoodsNoChgErrData(goodsNoKey, goodsNoAllDic);
                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);
                    continue;
                }
                #endregion

                #region 商品マスタに該当品番がある場合
                successLogList = new ArrayList();
                goodsStockWork = this.CloneGoodsUWorkWork(goodsChgWork);
                sqlTransaction.Save("GoodsStockSavePoint");

                #region 商品マスタに新旧品番を変換する
                status = this.GoodsMstChg(goodsNoKey, goodsChgWork, goodsNoAllDic,
                    out message, ref sqlConnection, ref sqlTransaction);
                // ログセット
                SetLog(goodsNoAllDic[goodsNoKey], null, message, out meijiGoodsStockWork);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラーワークセット
                    errorWork = goodsChgWork;
                }
                else
                {
                    // 成功データセット
                    successLogList.Add(meijiGoodsStockWork);
                }
                #endregion

                #region 価格マスタに新旧品番を変換する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (GoodsPriceUWork goodsPriceUWork in chgPirceList)
                    {
                        status = this.PriceMstChg(goodsNoKey, goodsChgWork, goodsPriceUWork, goodsNoAllDic,
                            out message, ref sqlConnection, ref sqlTransaction);

                        // ログセット
                        SetLog(goodsNoAllDic[goodsNoKey], goodsPriceUWork, message, out meijiGoodsStockWork);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // エラーワークセット
                            errorWork = goodsPriceUWork;
                            break;
                        }
                        else
                        {
                            successLogList.Add(meijiGoodsStockWork);
                        }
                    }
                }
                #endregion

                #region 在庫マスタに新旧品番を変換する
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    int stockRowNo = 0;// 在庫調整明細の行番号
                    // 在庫調整の価格をセットするために、最新の価格を取得する
                    GetNewPrice(chgPirceList, out priceResultWork);

                    foreach (StockWork stockWork in chgStockList)
                    {
                        stockRowNo = stockRowNo + 1;
                        status = this.StockMstChg(goodsNoKey, goodsStockWork, priceResultWork,
                            stockWork, goodsNoAllDic, out message, makerDic, wareHouseDic, blGoodsDic, sectionDic,
                            goodsChangeAllCndWorkWork, stockRowNo, ref sqlConnection, ref sqlTransaction);

                        // ログセット
                        SetLog(goodsNoAllDic[goodsNoKey], stockWork, message, out meijiGoodsStockWork);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // エラーワークセット
                            errorWork = stockWork;
                            break;
                        }
                        else
                        {
                            successLogList.Add(meijiGoodsStockWork);
                        }
                    }
                }
                #endregion

                #region ログの作成
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // エラーログのセット
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                    //SetErrLog(errorWork, meijiGoodsStockWork, goodsNoAllDic[goodsNoKey], goodsChgWork, chgPirceList, chgStockList,
                    //    ref goodsErrorResultWorkList, ref priceErrorResultWorkList, ref stockErrorResultWorkList);
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                    SetErrLog(errorWork, meijiGoodsStockWork, goodsNoAllDic[goodsNoKey], goodsChgWork, chgPirceList, chgStockList, ref goodsErrorResultWorkList);
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

                    // 品番更新エラーデータの作成
                    GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = this.GoodsNoChgErrData(goodsNoKey, goodsNoAllDic);
                    goodsNoChgErrDic.Add(goodsNoKey, goodsNoChangeErrorDataWork);

                    sqlTransaction.Rollback("GoodsStockSavePoint");
                }
                else
                {
                    // 成功ログのセット
                    //SetSuccessLog(successLogList, ref goodsSuccessResultWorkList, ref priceSuccessResultWorkList, ref stockSuccessResultWorkList);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    goodsSuccessResultWorkList.AddRange(successLogList);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                }
                #endregion

                #endregion
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            #endregion
            return status;
        }
        #endregion

        #region 価格ワーク取得
        /// <summary>
        /// 価格開始日によって、対応する価格ワーク取得
        /// </summary>
        /// <param name="priceDataList"></param>
        /// <param name="priceResultWork"></param>
        /// <returns></returns>
        /// <br>Note        : 価格開始日によって、対応する価格ワーク取得</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetNewPrice(ArrayList priceDataList, out GoodsPriceUWork priceResultWork)
        {
            DateTime dateTime = DateTime.MinValue;
            priceResultWork = new GoodsPriceUWork();
            foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
            {
                if (DateTime.Compare(goodsPriceUWork.PriceStartDate, dateTime) > 0 &&
                    DateTime.Compare(goodsPriceUWork.PriceStartDate, DateTime.Now) <= 0)
                {
                    dateTime = goodsPriceUWork.PriceStartDate;
                    priceResultWork = goodsPriceUWork;
                }
            }
        }
        #endregion

        #region 全て品番Dictionaryの作成
        /// <summary>
        /// 商品、価格、在庫マスタの戻り値に従い、Dictionaryの作成
        /// </summary>
        /// <param name="goodsDataList">商品リスト</param>
        /// <param name="priceDataList">価格リスト</param>
        /// <param name="stockDataList">在庫リスト</param>
        /// <param name="goodsStockAllDic">全て品番Dictionary</param>
        /// <returns></returns>
        /// <br>Note        : 商品マスタの戻り値に従い、Dictionaryの作成</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private void SetGoodsDic(ArrayList goodsDataList, ArrayList priceDataList, ArrayList stockDataList, out Dictionary<string, string> goodsStockAllDic)
        {
            goodsStockAllDic = new Dictionary<string, string>();
            string goodsKey = "";
            // 商品マスタ
            foreach (GoodsUWork goodsUWork in goodsDataList)
            {
                goodsKey = goodsUWork.GoodsMakerCd.ToString() + "-" + goodsUWork.GoodsNo.Trim();
                if (!goodsStockAllDic.ContainsKey(goodsKey))
                {
                    goodsStockAllDic.Add(goodsKey, goodsKey);
                }
            }
            // 価格マスタ
            foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
            {
                goodsKey = goodsPriceUWork.GoodsMakerCd.ToString() + "-" + goodsPriceUWork.GoodsNo.Trim();
                if (!goodsStockAllDic.ContainsKey(goodsKey))
                {

                    goodsStockAllDic.Add(goodsKey, goodsKey);
                }
            }
            // 在庫マスタ
            foreach (StockWork stockWork in stockDataList)
            {
                goodsKey = stockWork.GoodsMakerCd.ToString() + "-" + stockWork.GoodsNo.Trim();
                if (!goodsStockAllDic.ContainsKey(goodsKey))
                {
                    goodsStockAllDic.Add(goodsKey, goodsKey);
                }
            }
        }
        #endregion

        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        #region 成功ログのセット
        ///// <summary>
        ///// 成功ログの作成
        ///// </summary>
        ///// <param name="successLogList">成功ログリスト</param>
        ///// <param name="goodsSuccessResultWorkList">商品リスト</param>
        ///// <param name="priceSuccessResultWorkList">価格リスト</param>
        ///// <param name="stockSuccessResultWorkList">在庫リスト</param>
        ///// <returns></returns>
        ///// <br>Note        : 成功ログの作成</br>
        ///// <br>Programmer  : 陳永康</br>
        ///// <br>Date        : 2015/01/26</br>
        //private void SetSuccessLog(ArrayList successLogList, ref ArrayList goodsSuccessResultWorkList, ref ArrayList priceSuccessResultWorkList, ref ArrayList stockSuccessResultWorkList)
        //{
        //    foreach (MeijiGoodsStockWork successLogWork in successLogList)
        //    {
        //        // 商品マスタ
        //        if (successLogWork.MstDiv == 0)
        //        {
        //            goodsSuccessResultWorkList.Add(successLogWork);
        //        }
        //        // 価格マスタ
        //        else if (successLogWork.MstDiv == 1)
        //        {
        //            priceSuccessResultWorkList.Add(successLogWork);
        //        }
        //        // 在庫マスタ
        //        else if (successLogWork.MstDiv == 2)
        //        {
        //            stockSuccessResultWorkList.Add(successLogWork);
        //        }
        //        else
        //        {
        //            // なし
        //        }
        //    }
        //}
        #endregion
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

        #region 不整合データログセット
        /// <summary>
        /// 不整合データ処理
        /// </summary>
        /// <param name="goodsNoKey">キー</param>
        /// <param name="sinFuWork">新旧品番対応するワーク</param>
        /// <param name="priceDataList">価格リスト</param>
        /// <param name="stockDataList">在庫リスト</param>
        /// <param name="goodsErrorResultWorkList">商品在庫エラーリスト</param>
        /// <returns></returns>
        /// <br>Note        : エラーログの作成</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private void SetUnNormalData(string goodsNoKey, MeijiGoodsStockWork sinFuWork, ArrayList priceDataList, ArrayList stockDataList, ref ArrayList goodsErrorResultWorkList)
        {
            string goodsKey = "";
            MeijiGoodsStockWork meijiGoodsStockWork;
            // 価格マスタ、不整合データのログ出力
            foreach(GoodsPriceUWork priceWork in priceDataList)
            {
                goodsKey = priceWork.GoodsMakerCd.ToString() + "-" + priceWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(goodsKey))
                {
                    //SetLog(sinFuWork, priceWork, UNNORMALDATA, out meijiGoodsStockWork); // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    SetLog(sinFuWork, priceWork, string.Format(GoodsNoChgCommonDB.UNNORMALDATA, "価格マスタ"), out meijiGoodsStockWork); // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    //priceErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                }
            }
            // 倉庫マスタ、不整合データのログ出力
            foreach (StockWork stockWork in stockDataList)
            {
                goodsKey = stockWork.GoodsMakerCd.ToString() + "-" + stockWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(goodsKey))
                {
                    //SetLog(sinFuWork, stockWork, UNNORMALDATA, out meijiGoodsStockWork); // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    SetLog(sinFuWork, stockWork, string.Format(GoodsNoChgCommonDB.UNNORMALDATA, "在庫マスタ"), out meijiGoodsStockWork); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    //stockErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                }
            }
        }
        #endregion

        #region エラーログのセット
        /// <summary>
        /// エラーログのセット
        /// </summary>
        /// <param name="errorWork">エラーが発生するワーク</param>
        /// <param name="errorLogWork">エラーワーク</param>
        /// <param name="sinFuWork">新旧品番対応するワーク</param>
        /// <param name="goodsWork">商品ワーク</param>
        /// <param name="priceDataList">価格リスト</param>
        /// <param name="stockDataList">在庫リスト</param>
        /// <param name="goodsErrorResultWorkList">商品エラーリスト</param>
        /// <returns></returns>
        /// <br>Note        : エラーログの作成</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/03/02 時シン </br>
        /// <br>            : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        //private void SetErrLog(object errorWork, MeijiGoodsStockWork errorLogWork, MeijiGoodsStockWork sinFuWork, GoodsUWork goodsWork, ArrayList priceDataList, ArrayList stockDataList,
        //    ref ArrayList goodsErrorResultWorkList, ref ArrayList priceErrorResultWorkList, ref ArrayList stockErrorResultWorkList)
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        private void SetErrLog(object errorWork, MeijiGoodsStockWork errorLogWork, MeijiGoodsStockWork sinFuWork, GoodsUWork goodsWork, ArrayList priceDataList, ArrayList stockDataList,
            ref ArrayList goodsErrorResultWorkList)
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        {
            MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();
            String errorMsg = "";
            int dbFlag = 0;
            Type wktype = errorWork.GetType();
            switch (wktype.Name)
            {
                case "GoodsUWork":
                    {
                        dbFlag = 0;
                        //errorMsg = GOODSMSTERRMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        errorMsg = string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG, "商品マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        break;
                    }
                case "GoodsPriceUWork":
                    {
                        dbFlag = 1;
                        //errorMsg = PRICEMSTERRMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        errorMsg = string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG, "価格マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        break;
                    }
                case "StockWork":
                    {
                        dbFlag = 2;
                        //errorMsg = STOCKMSTERRMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        errorMsg = string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG, "在庫マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        break;
                    }
            }

            // 商品マスタのエラーログセット
            if (dbFlag == 0)
            {
                errorLogWork.MstDiv = 0; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                goodsErrorResultWorkList.Add(errorLogWork);
            }
            else
            {
                SetLog(sinFuWork, goodsWork, errorMsg, out meijiGoodsStockWork);
                goodsErrorResultWorkList.Add(meijiGoodsStockWork);
            }

            // 価格マスタエラーログセット
            if (dbFlag == 1)
            {
                GoodsPriceUWork errWorkPrice = (GoodsPriceUWork)errorWork;
                foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
                {
                    if (errWorkPrice.GoodsMakerCd == goodsPriceUWork.GoodsMakerCd &&
                        errWorkPrice.GoodsNo.Trim().Equals(goodsPriceUWork.GoodsNo.Trim()) &&
                        errWorkPrice.PriceStartDate.ToString().Equals(goodsPriceUWork.PriceStartDate.ToString()))
                    {
                        errorLogWork.MstDiv = 1; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                        //priceErrorResultWorkList.Add(errorLogWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                        goodsErrorResultWorkList.Add(errorLogWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    }
                    else
                    {
                        //SetLog(sinFuWork, goodsPriceUWork, PRICEMSTERRMSG2, out meijiGoodsStockWork); // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        SetLog(sinFuWork, goodsPriceUWork, string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG2, "価格マスタ"), out meijiGoodsStockWork); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        //priceErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                        goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    }
                }
            }
            else
            {
                foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
                {
                    SetLog(sinFuWork, goodsPriceUWork, errorMsg, out meijiGoodsStockWork);
                    //priceErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                }
            }


            // 在庫マスタエラーログセット
            if (dbFlag == 2)
            {
                StockWork errWorkStock = (StockWork)errorWork;
                foreach (StockWork stockWork in stockDataList)
                {
                    if (errWorkStock.GoodsMakerCd == stockWork.GoodsMakerCd &&
                        errWorkStock.GoodsNo.Trim().Equals(stockWork.GoodsNo.Trim()) &&
                        errWorkStock.WarehouseCode.Trim().Equals(stockWork.WarehouseCode.Trim()))
                    {
                        errorLogWork.MstDiv = 2; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                        //stockErrorResultWorkList.Add(errorLogWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                        goodsErrorResultWorkList.Add(errorLogWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    }
                    else
                    {
                        //SetLog(sinFuWork, stockWork, STOCKMSTERRMSG2, out meijiGoodsStockWork); // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        SetLog(sinFuWork, stockWork, string.Format(GoodsNoChgCommonDB.GOODSMSTERRMSG2, "在庫マスタ"), out meijiGoodsStockWork); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        //stockErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                        goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    }
                }
            }
            else
            {
                foreach (StockWork stockWork in stockDataList)
                {
                    SetLog(sinFuWork, stockWork, errorMsg, out meijiGoodsStockWork);
                    //stockErrorResultWorkList.Add(meijiGoodsStockWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                    goodsErrorResultWorkList.Add(meijiGoodsStockWork);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
                }
            }
        }
        #endregion

        #region ログの作成
        /// <summary>
        /// ログの作成
        /// </summary>
        /// <param name="SinFuWork">新旧品番対応ワーク</param>
        /// <param name="para">パラーメタ</param>
        /// <param name="message">メッセージ</param>
        /// <param name="meijiGoodsStockWork">ログワーク</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private void SetLog(MeijiGoodsStockWork SinFuWork, object para, string message, out MeijiGoodsStockWork meijiGoodsStockWork)
        {
            meijiGoodsStockWork = new MeijiGoodsStockWork();
            meijiGoodsStockWork.NewGoodsNo = SinFuWork.NewGoodsNo;
            meijiGoodsStockWork.GoodsMakerCd = SinFuWork.GoodsMakerCd;
            meijiGoodsStockWork.OldGoodsNo = SinFuWork.OldGoodsNo;
            meijiGoodsStockWork.OutNote = message;
            meijiGoodsStockWork.MstDiv = 0;
            if (para != null)
            {
                Type wktype = para.GetType();
                switch (wktype.Name)
                {
                    case "GoodsPriceUWork":
                        {
                            meijiGoodsStockWork.PriceStartDate = ((GoodsPriceUWork)para).PriceStartDate;
                            meijiGoodsStockWork.MstDiv = 1;
                            break;
                        }
                    case "StockWork":
                        {
                            meijiGoodsStockWork.WareCode = ((StockWork)para).WarehouseCode;
                            meijiGoodsStockWork.MstDiv = 2;
                            break;
                        }
                }
            }

        }
        #endregion

        #region 商品ワークの取得
        /// <summary>
        /// 商品ワークに従い、商品ワークの取得
        /// </summary>
        /// <param name="goodsNoKey">キー</param>
        /// <param name="goodsDataList">商品リスト</param>
        /// <param name="goodsChgWork">戻り商品ワーク</param>
        /// <returns></returns>
        /// <br>Note        : 商品ワークに従い、商品ワークの取得</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetGoodsWork(string goodsNoKey, ArrayList goodsDataList, out GoodsUWork goodsChgWork)
        {
            string goodsKey = "";
            goodsChgWork = new GoodsUWork();
            // 商品ワークに従い、商品リストの作成
            foreach (GoodsUWork goodsUWork in goodsDataList)
            {
                goodsKey = goodsUWork.GoodsMakerCd.ToString() + "-" + goodsUWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(goodsKey))
                {
                    goodsChgWork = goodsUWork;
                }
            }
        }
        #endregion

        #region 在庫リストの取得
        /// <summary>
        /// 商品ワークに従い、在庫リストの取得
        /// </summary>
        /// <param name="goodsNoKey"></param>
        /// <param name="stockDataList"></param>
        /// <param name="chgStockList"></param>
        /// <returns></returns>
        /// <br>Note        : 商品ワークに従い、在庫リストの取得</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetStockList(string goodsNoKey, ArrayList stockDataList, out ArrayList chgStockList)
        {
            string stockChgKey = "";
            chgStockList = new ArrayList();
            foreach (StockWork stockChgWork in stockDataList)
            {
                stockChgKey = stockChgWork.GoodsMakerCd.ToString() + "-" + stockChgWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(stockChgKey))
                {
                    chgStockList.Add(stockChgWork);
                }
            }
        }
        #endregion

        #region 価格リストの取得
        /// <summary>
        /// 商品ワークに従い、価格リストの取得
        /// </summary>
        /// <param name="goodsNoKey"></param>
        /// <param name="priceDataList"></param>
        /// <param name="chgPirceList"></param>
        /// <returns></returns>
        /// <br>Note        : 商品ワークに従い、在庫リストの取得</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private void GetPriceList(string goodsNoKey, ArrayList priceDataList, out ArrayList chgPirceList)
        {
            string priceKey = "";
            chgPirceList = new ArrayList();
            // 商品ワークに従い、価格リストの作成
            foreach (GoodsPriceUWork goodsPriceUWork in priceDataList)
            {
                priceKey = goodsPriceUWork.GoodsMakerCd.ToString() + "-" + goodsPriceUWork.GoodsNo.Trim();
                if (goodsNoKey.Equals(priceKey))
                {
                    chgPirceList.Add(goodsPriceUWork);
                }
            }
        }
        #endregion

        #region 品番変換エラーデータの作成
        /// <summary>
        /// 品番変換エラーデータの作成処理
        /// </summary>
        /// <param name="goodsNoKey">メーカー＋品番キー</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private GoodsNoChangeErrorDataWork GoodsNoChgErrData(string goodsNoKey, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic)
        {
            GoodsNoChangeErrorDataWork goodsNoChangeErrorDataWork = new GoodsNoChangeErrorDataWork();
            goodsNoChangeErrorDataWork.MasterDivCd = GoodsNoChgCommonDB.GOODSMST;
            goodsNoChangeErrorDataWork.GoodsMakerCd = goodsNoAllDic[goodsNoKey].GoodsMakerCd;
            goodsNoChangeErrorDataWork.ChgSrcGoodsNo = goodsNoAllDic[goodsNoKey].OldGoodsNo;
            goodsNoChangeErrorDataWork.ChgDestGoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;

            return goodsNoChangeErrorDataWork;
        }
        #endregion

        #region 初期Dictionaryの取得
        /// <summary>
        /// 企業コードによって、メーカー、倉庫、ＢＬコード、拠点情報のDictionary作成
        /// </summary>
        /// <param name="makerNameDic">メーカーのDictionary</param>
        /// <param name="wareHouseNameDic">倉庫のDictionary</param>
        /// <param name="blGoodsNameDic">ＢＬコードのDictionary</param>
        /// <param name="sectionNameDic">拠点のDictionary</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note      　: レビュー結果対応(statusにより判断処理の追加) </br>
        /// <br>Programmer　: 時シン</br>
        /// <br>Date        : 2015/04/27</br>
        /// </remarks>
        private int SearchWorkDate(out Dictionary<int, string> makerNameDic, out Dictionary<int, string> wareHouseNameDic,
            out Dictionary<int, string> blGoodsNameDic, out Dictionary<string, string> sectionNameDic, string enterPriseCode)
        {
            // 各マスタのDictionary
            makerNameDic = new Dictionary<int, string>();
            wareHouseNameDic = new Dictionary<int, string>();
            blGoodsNameDic = new Dictionary<int, string>();
            sectionNameDic = new Dictionary<string, string>();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // コネクション生成
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);

                // BLコードマスタ
                BLGoodsCdUDB bLGoodsCdUDB = new BLGoodsCdUDB();
                ArrayList retal = null;
                BLGoodsCdUWork bLGoodsCdUWork = new BLGoodsCdUWork();
                bLGoodsCdUWork.EnterpriseCode = enterPriseCode;
                status = bLGoodsCdUDB.SearchBLGoodsCdProc(out retal, bLGoodsCdUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
                foreach (BLGoodsCdUWork bLGoodsWork in retal)
                {
                    if (!blGoodsNameDic.ContainsKey(bLGoodsWork.BLGoodsCode))
                    {
                        blGoodsNameDic.Add(bLGoodsWork.BLGoodsCode, bLGoodsWork.BLGoodsHalfName);
                    }
                }

                // メーカーマスタ（ユーザー登録
                MakerUDB makerUDB = new MakerUDB();
                retal = null;
                MakerUWork makerUWork = new MakerUWork();
                makerUWork.EnterpriseCode = enterPriseCode;
                status = makerUDB.SearchMakerProc(out retal, makerUWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
                foreach (MakerUWork makerWork in retal)
                {
                    if (!makerNameDic.ContainsKey(makerWork.GoodsMakerCd))
                    {
                        makerNameDic.Add(makerWork.GoodsMakerCd, makerWork.MakerName);
                    }
                }

                // 倉庫マスタ
                WarehouseDB warehouseDB = new WarehouseDB();
                retal = null;
                WarehouseWork warehouseWork = new WarehouseWork();
                warehouseWork.EnterpriseCode = enterPriseCode;
                status = warehouseDB.SearchWarehouseProc(out retal, warehouseWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
                //----- UPD 2015/06/20 T.Nishi 倉庫マスタが1件もない場合にエラーで終了してしまう不具合の修正 ------>>>>>
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                 && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                //----- UPD 2015/06/20 T.Nishi 倉庫マスタが1件もない場合にエラーで終了してしまう不具合の修正 ------<<<<<
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
                int WareHouseCode = 0;
                foreach (WarehouseWork wareWork in retal)
                {
                    WareHouseCode = Convert.ToInt32(wareWork.WarehouseCode.Trim());
                    if (!wareHouseNameDic.ContainsKey(WareHouseCode))
                    {
                        wareHouseNameDic.Add(WareHouseCode, wareWork.WarehouseName);
                    }
                }

                // 拠点情報設定マスタ
                SecInfoSetDB secInfoSetDB = new SecInfoSetDB();
                retal = null;
                SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
                secInfoSetWork.EnterpriseCode = enterPriseCode;
                status = secInfoSetDB.Search(out retal, secInfoSetWork, 0, ConstantManagement.LogicalMode.GetData01, ref sqlConnection);
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------>>>>>
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }
                //----- ADD 2015/04/27 時シン レビュー結果対応(statusにより判断処理の追加) ------<<<<<
                foreach (SecInfoSetWork sectionWork in retal)
                {
                    if (!sectionNameDic.ContainsKey(sectionWork.SectionCode.Trim()))
                    {
                        sectionNameDic.Add(sectionWork.SectionCode.Trim(), sectionWork.SectionGuideNm);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.SearchWorkDate Exception=" + ex.Message);
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

            return status;
        }
        #endregion
        #endregion

        #region 商品マスタ
        #region 商品検索
        /// <summary>
        /// 指定された条件の商品マスタ（ユーザー登録分）情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="goodsuWorkList">検索結果</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件の商品マスタ（ユーザー登録分）情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchGoodsUProcProc(out ArrayList goodsuWorkList, ref Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, 
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string goodsNoKey = "";
            goodsuWorkList = new ArrayList();
            goodsNoAllDic = new Dictionary<string, MeijiGoodsStockWork>();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   GOODS.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNORF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNAMEKANARF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.JANRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.DISPLAYORDERRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSRATERANKRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNONONEHYPHENRF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSKINDCODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE1RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSNOTE2RF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.GOODSSPECIALNOTERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.UPDATEDATERF" + Environment.NewLine;
                sqlTxt += "  ,GOODS.OFFERDATADIVRF" + Environment.NewLine;
                sqlTxt += "  ,B.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlTxt += "FROM" + Environment.NewLine;
                sqlTxt += "  GOODSURF AS GOODS WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GOODS.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    sqlTxt += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sqlTxt += " ON GOODS.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sqlTxt += " AND GOODS.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    sqlTxt += " AND B.MASTERDIVCDRF = 1 " + Environment.NewLine;
                }

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlTxt = "";
                sqlTxt += "WHERE" + Environment.NewLine;

                //企業コード
                sqlTxt += " GOODS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

                //論理削除区分
                sqlTxt += " AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                sqlTxt += " ORDER BY GOODS.ENTERPRISECODERF, GOODS.GOODSMAKERCDRF, GOODS.GOODSNORF ";

                sqlCommand.CommandText += sqlTxt;
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // 商品ワークと新旧品番ワークの作成
                    GoodsUWork goodsUWork = new GoodsUWork();
                    MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();
                    CopyToGoodsUWorkFromReader(ref myReader, out goodsUWork, out meijiGoodsStockWork);
                    // 新旧品番Dictionaryの作成
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }
                    // 結果リストの作成
                    goodsuWorkList.Add(goodsUWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region 商品マスタに新旧品番の変換
        /// <summary>
        /// 商品マスタに新旧品番の変換処理
        /// </summary>
        /// <param name="goodsNoKey">メーカー＋品番キー</param>
        /// <param name="goodsChgWork">商品ワーク</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/17</br>
        /// </remarks>
        private int GoodsMstChg(string goodsNoKey, GoodsUWork goodsChgWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, 
            out string message, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDeleteDiv = 0;
            // リストの作成
            ArrayList deleteWorkList = new ArrayList();
            ArrayList insertWorkList = new ArrayList();
            message = "";

            try
            {
                // 旧品番の削除
                deleteWorkList.Add(goodsChgWork);
                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                try
                {
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                    status = this._iGoodsUDB.DeleteGoodsUProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "DeleteGoodsUProc");
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                deleteWorkList.Clear();

                // 削除の場合異常が発生する
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 排他異常が発生する場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                        || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        //message = DELETEERRMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        message = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "商品マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    }
                    // それ以外異常の場合
                    else
                    {
                        //message = OLDEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        message = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    }
                }
                // 削除が正常の場合
                else
                {
                    // 商品登録用のパラメータにセット
                    // 旧→新品番で変換
                    goodsChgWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                    goodsChgWork.GoodsNoNoneHyphen = goodsNoAllDic[goodsNoKey].NewGoodsNo.Replace("-", "");
                    goodsChgWork.UpdateDateTime = DateTime.MinValue;
                    logicalDeleteDiv = goodsChgWork.LogicalDeleteCode;
                    insertWorkList.Add(goodsChgWork);

                    // 新品番で商品マスタ登録
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                    try
                    {
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                        status = this._iGoodsUDB.WriteGoodsUProc(ref insertWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "WriteGoodsUProc");
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<

                    // 登録時異常が発生する場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 排他異常が発生する場合
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                            || status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                        {
                            //message = EXISTMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = string.Format(GoodsNoChgCommonDB.EXISTMSG, "商品マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                        // それ以外異常の場合
                        else
                        {
                            //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                    }
                    // 新品番登録正常の場合
                    else
                    {
                        // 元データが論理削除の場合、新品番も論理削除分として変更する
                        if (logicalDeleteDiv == 1)
                        {
                            // 新品番論理削除
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                status = this._iGoodsUDB.LogicalDeleteGoodsUProc(ref insertWorkList, 0, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "LogicalDeleteGoodsUProc");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                //message = DELETEMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                message = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            }
                            else
                            {
                                //message = NEWEXCEPTIONMSG;// DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            }
                        }
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.GoodsMstChg");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region 商品ワークのClone
        /// <summary>
        /// ワークのClone
        /// </summary>
        /// <param name="work">商品ワーク</param>
        /// <returns></returns>
        private GoodsUWork CloneGoodsUWorkWork(GoodsUWork work)
        {
            GoodsUWork copyGoodsUWork = new GoodsUWork();

            copyGoodsUWork.CreateDateTime = work.CreateDateTime;
            copyGoodsUWork.UpdateDateTime = work.UpdateDateTime;
            copyGoodsUWork.EnterpriseCode = work.EnterpriseCode;
            copyGoodsUWork.FileHeaderGuid = work.FileHeaderGuid;
            copyGoodsUWork.UpdEmployeeCode = work.UpdEmployeeCode;
            copyGoodsUWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            copyGoodsUWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            copyGoodsUWork.LogicalDeleteCode = work.LogicalDeleteCode;
            copyGoodsUWork.GoodsMakerCd = work.GoodsMakerCd;
            copyGoodsUWork.GoodsNo = work.GoodsNo;
            copyGoodsUWork.GoodsName = work.GoodsName;
            copyGoodsUWork.GoodsNameKana = work.GoodsNameKana;
            copyGoodsUWork.Jan = work.Jan;
            copyGoodsUWork.BLGoodsCode = work.BLGoodsCode;
            copyGoodsUWork.DisplayOrder = work.DisplayOrder;
            copyGoodsUWork.GoodsRateRank = work.GoodsRateRank;
            copyGoodsUWork.TaxationDivCd = work.TaxationDivCd;
            copyGoodsUWork.GoodsNoNoneHyphen = work.GoodsNoNoneHyphen;
            copyGoodsUWork.OfferDate = work.OfferDate;
            copyGoodsUWork.GoodsKindCode = work.GoodsKindCode;
            copyGoodsUWork.GoodsNote1 = work.GoodsNote1;
            copyGoodsUWork.GoodsNote2 = work.GoodsNote2;
            copyGoodsUWork.GoodsSpecialNote = work.GoodsSpecialNote;
            copyGoodsUWork.EnterpriseGanreCode = work.EnterpriseGanreCode;
            copyGoodsUWork.UpdateDate = work.UpdateDate;
            copyGoodsUWork.OfferDataDiv = work.OfferDataDiv;

            return copyGoodsUWork;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkGoodsUWork">GoodsUWork</param>
        /// <param name="meijiGoodsStockWork">MeijiGoodsStockWork</param>
        /// <returns>GoodsUWork</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br></br>
        /// </remarks>
        private void CopyToGoodsUWorkFromReader(ref SqlDataReader myReader, out GoodsUWork wkGoodsUWork, out MeijiGoodsStockWork meijiGoodsStockWork)
        {
            wkGoodsUWork = new GoodsUWork();
            meijiGoodsStockWork = new MeijiGoodsStockWork();

            wkGoodsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsUWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            wkGoodsUWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            wkGoodsUWork.Jan = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JANRF"));
            wkGoodsUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkGoodsUWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
            wkGoodsUWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            wkGoodsUWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            wkGoodsUWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            wkGoodsUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsUWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            wkGoodsUWork.GoodsNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE1RF"));
            wkGoodsUWork.GoodsNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNOTE2RF"));
            wkGoodsUWork.GoodsSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSSPECIALNOTERF"));
            wkGoodsUWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            wkGoodsUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            wkGoodsUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

            meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
        }
        #endregion
        #endregion

        #region 在庫マスタ
        #region 在庫検索（全部キー）
        /// <summary>
        /// 在庫マスタ検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="wareHouseCode">倉庫コード</param>
        /// <returns></returns>
        /// <br>Note        : 在庫マスタ検索処理</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private int SearchStockInfoProc(string enterpriseCode, string goodsNo, Int32 goodsMakerCd, string wareHouseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF FROM STOCKRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWareHouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);
                findParaWareHouseCode.Value = SqlDataMediator.SqlSetString(wareHouseCode);

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region 在庫検索
        /// <summary>
        /// 在庫マスタ検索処理
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <br>Note        : 在庫マスタ検索処理</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <returns>STATUS</returns>
        private int SearchStockInfoListProc(out ArrayList stockList, ref Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            stockList = new ArrayList();
            string goodsNoKey = "";
            try
            {
                //Selectコマンドの生成
                string sql = string.Empty;
                sql = "SELECT A.CREATEDATETIMERF, A.UPDATEDATETIMERF, A.ENTERPRISECODERF, A.FILEHEADERGUIDRF, A.UPDEMPLOYEECODERF, A.UPDASSEMBLYID1RF, " + Environment.NewLine;
                sql += "A.UPDASSEMBLYID2RF, A.LOGICALDELETECODERF, A.SECTIONCODERF, A.WAREHOUSECODERF, A.GOODSMAKERCDRF, A.GOODSNORF, A.STOCKUNITPRICEFLRF, A.SUPPLIERSTOCKRF, " + Environment.NewLine;
                sql += "A.ACPODRCOUNTRF, A.MONTHORDERCOUNTRF, A.SALESORDERCOUNTRF, A.STOCKDIVRF, A.MOVINGSUPLISTOCKRF, A.SHIPMENTPOSCNTRF, A.STOCKTOTALPRICERF, A.LASTSTOCKDATERF, " + Environment.NewLine;
                sql += "A.LASTSALESDATERF, A.LASTINVENTORYUPDATERF, A.MINIMUMSTOCKCNTRF, A.MAXIMUMSTOCKCNTRF, A.NMLSALODRCOUNTRF, A.SALESORDERUNITRF, A.STOCKSUPPLIERCODERF, " + Environment.NewLine;
                sql += "A.GOODSNONONEHYPHENRF, A.WAREHOUSESHELFNORF, A.DUPLICATIONSHELFNO1RF, A.DUPLICATIONSHELFNO2RF, A.PARTSMANAGEMENTDIVIDE1RF, A.PARTSMANAGEMENTDIVIDE2RF, " + Environment.NewLine;
                sql += "A.STOCKNOTE1RF, A.STOCKNOTE2RF, A.SHIPMENTCNTRF, A.ARRIVALCNTRF, A.STOCKCREATEDATERF, A.UPDATEDATERF, B.CHGDESTGOODSNORF FROM STOCKRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine;
                if (updateMode == 0)
                {
                    sql += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sql += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sql += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sql += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                }
                else
                {
                    sql += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                    sql += " ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                    sql += " AND A.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                    sql += " AND A.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                    sql += " AND B.MASTERDIVCDRF = 1 " + Environment.NewLine;
                }
                sql += " WHERE A.ENTERPRISECODERF=@FINDENTERPRISECODE AND B.LOGICALDELETECODERF=@FINDLOGICALDELETECODERF ";
                sql += " ORDER BY A.ENTERPRISECODERF, A.GOODSMAKERCDRF, A.GOODSNORF, A.WAREHOUSECODERF ";
                sqlCommand = new SqlCommand(sql, sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);


                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockWork _stockWork = new StockWork();
                    MeijiGoodsStockWork meijiGoodsStockWork = new MeijiGoodsStockWork();

                    _stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    _stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    _stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    _stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    _stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    _stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    _stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    _stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    _stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    _stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    _stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    _stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    _stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    _stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    _stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    _stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    _stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    _stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    _stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    _stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    _stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    _stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    _stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    _stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    _stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    _stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    _stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    _stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    _stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    _stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    _stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    _stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    _stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    _stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    _stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    _stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    _stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    _stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    _stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    _stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    _stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                    stockList.Add(_stockWork);
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region 在庫ワークのClone
        /// <summary>
        /// ワークのClone
        /// </summary>
        /// <param name="work">在庫ワーク</param>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private StockWork CloneStockWork(StockWork work)
        {
            StockWork copyStockWork = new StockWork();

            copyStockWork.CreateDateTime = work.CreateDateTime;
            copyStockWork.UpdateDateTime = work.UpdateDateTime;
            copyStockWork.EnterpriseCode = work.EnterpriseCode;
            copyStockWork.FileHeaderGuid = work.FileHeaderGuid;
            copyStockWork.UpdEmployeeCode = work.UpdEmployeeCode;
            copyStockWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            copyStockWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            copyStockWork.LogicalDeleteCode = work.LogicalDeleteCode;
            copyStockWork.SectionCode = work.SectionCode;
            copyStockWork.WarehouseCode = work.WarehouseCode;
            copyStockWork.GoodsMakerCd = work.GoodsMakerCd;
            copyStockWork.GoodsNo = work.GoodsNo;
            copyStockWork.StockUnitPriceFl = work.StockUnitPriceFl;
            copyStockWork.SupplierStock = work.SupplierStock;
            copyStockWork.AcpOdrCount = work.AcpOdrCount;
            copyStockWork.MonthOrderCount = work.MonthOrderCount;
            copyStockWork.SalesOrderCount = work.SalesOrderCount;
            copyStockWork.StockDiv = work.StockDiv;
            copyStockWork.MovingSupliStock = work.MovingSupliStock;
            copyStockWork.ShipmentPosCnt = work.ShipmentPosCnt;
            copyStockWork.StockTotalPrice = work.StockTotalPrice;
            copyStockWork.LastStockDate = work.LastStockDate;
            copyStockWork.LastSalesDate = work.LastSalesDate;
            copyStockWork.LastInventoryUpdate = work.LastInventoryUpdate;
            copyStockWork.MinimumStockCnt = work.MinimumStockCnt;
            copyStockWork.MaximumStockCnt = work.MaximumStockCnt;
            copyStockWork.NmlSalOdrCount = work.NmlSalOdrCount;
            copyStockWork.SalesOrderUnit = work.SalesOrderUnit;
            copyStockWork.StockSupplierCode = work.StockSupplierCode;
            copyStockWork.GoodsNoNoneHyphen = work.GoodsNoNoneHyphen;
            copyStockWork.WarehouseShelfNo = work.WarehouseShelfNo;
            copyStockWork.DuplicationShelfNo1 = work.DuplicationShelfNo1;
            copyStockWork.DuplicationShelfNo2 = work.DuplicationShelfNo2;
            copyStockWork.PartsManagementDivide1 = work.PartsManagementDivide1;
            copyStockWork.PartsManagementDivide2 = work.PartsManagementDivide2;
            copyStockWork.StockNote1 = work.StockNote1;
            copyStockWork.StockNote2 = work.StockNote2;
            copyStockWork.ShipmentCnt = work.ShipmentCnt;
            copyStockWork.ArrivalCnt = work.ArrivalCnt;
            copyStockWork.StockCreateDate = work.StockCreateDate;
            copyStockWork.UpdateDate = work.UpdateDate;

            return copyStockWork;
        }
        #endregion

        #region 在庫マスタに新旧品番の変換
        /// <summary>
        /// 在庫マスタに新旧品番の変換処理
        /// </summary>
        /// <param name="goodsNoKey">メーカー＋品番キー</param>
        /// <param name="goodsChgWork">商品ワーク</param>
        /// <param name="goodsPriceUWork">価格ワーク</param>
        /// <param name="stockWork">在庫ワーク</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="makerDic">メーカーコードDictionary</param>
        /// <param name="wareHouseDic">倉庫Dictionary</param>
        /// <param name="blGoodsDic">BL商品コードDictionary</param>
        /// <param name="goodsChangeAllCndWorkWork">条件ワーク</param>
        /// <param name="sectionDic">拠点Dictionary</param>
        /// <param name="stockRowNo">行番号</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        private int StockMstChg(string goodsNoKey, GoodsUWork goodsChgWork, GoodsPriceUWork goodsPriceUWork, StockWork stockWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic,
            out string message, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic, Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic,
            GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, int stockRowNo, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // エラーメッセージ
            message = string.Empty;
            string message2 = string.Empty;
            // リスト
            ArrayList changeWorkList = new ArrayList();
            ArrayList deletePartList = new ArrayList();
            CustomSerializeArrayList insertWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList stockAdjustCsList = new CustomSerializeArrayList();

            int logicalDeleteCode = 0;
            object stockWorkObj = null;
            try
            {
                logicalDeleteCode = stockWork.LogicalDeleteCode;
                // 新品番在庫マスタの排他チェック
                status = this.SearchStockInfoProc(stockWork.EnterpriseCode, goodsNoAllDic[goodsNoKey].NewGoodsNo, stockWork.GoodsMakerCd, stockWork.WarehouseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //message = EXISTMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    message = message = string.Format(GoodsNoChgCommonDB.EXISTMSG, "在庫マスタ"); ; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                }
                else if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // 在庫マスタ・在庫調整・在庫調整明細、在庫受付履歴登録
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 旧品番削除
                    // 削除データ準備
                    SetOldStockData(goodsNoKey, goodsChangeAllCndWorkWork, stockWork, goodsChgWork, goodsPriceUWork, 
                        goodsNoAllDic, makerDic, wareHouseDic, blGoodsDic, sectionDic, stockRowNo, out stockWorkObj);

                    if (stockWorkObj != null)
                    {
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                        try
                        {
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                            status = this._iStockAdjustDB.WriteBatch(ref stockWorkObj, out message2, ref sqlConnection, ref sqlTransaction);
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "WriteBatch");
                            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                    }

                    // 削除の場合異常が発生する
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 排他異常が発生する場合
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                            || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            //message = DELETEERRMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "在庫マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                        // それ以外異常の場合
                        else
                        {
                            //message = OLDEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                    }
                    // 新品番登録
                    else
                    {
                        // 新品番登録用データ準備 
                        //SetNewStockData(ref stockWorkObj, goodsNoAllDic[goodsNoKey], logicalDeleteCode); // DEL 呉軍 2015/04/15 Redmine45436の№78
                        // ADD 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
                        SetNewStockData(ref stockWorkObj, goodsChangeAllCndWorkWork, goodsNoAllDic[goodsNoKey], logicalDeleteCode,
                            goodsChgWork, goodsPriceUWork, makerDic, wareHouseDic, blGoodsDic, sectionDic, stockRowNo);
                        // ADD 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<

                        if (stockWorkObj != null)
                        {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            try
                            {
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                                status = this._iStockAdjustDB.WriteBatch(ref stockWorkObj, out message2, ref sqlConnection, ref sqlTransaction);
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                            }
                            catch (Exception ex)
                            {
                                base.WriteErrorLog(ex, "WriteBatch");
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                        }

                        // 既存WriteBatchメソッドの登録処理は排他チェックエラーがない
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                        else
                        {
                            // 既存WriteBatchメソッドの登録処理は論理削除区分を有効になるできないので、そのまま更新OK
                            if (logicalDeleteCode == 1)
                            {
                                //message = DELETEMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                                message = GoodsNoChgCommonDB.DELETEMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.StockMstChg");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
       
            return status;
        }
        #endregion

        #region 新品番在庫情報の作成
        /// <summary>
        /// 新品番在庫情報の作成
        /// </summary>
        /// <param name="stockObj">戻りObject</param>
        /// <param name="goodsChangeAllCndWorkWork">変換条件ワーク</param>
        /// <param name="meijiGoodsStockWork">新旧品番対応ワーク</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
        /// <param name="goodsChgWork">商品情報ワーク</param>
        /// <param name="goodsPriceUWork">価格情報ワーク</param>
        /// <param name="makerDic">メーカー情報Dictionary</param>
        /// <param name="wareHouseDic">倉庫情報Dictionary</param>
        /// <param name="blGoodsDic">BLコード情報Dictionary</param>
        /// <param name="sectionDic">拠点情報Dictionary</param>
        /// <param name="rowNo">行番号</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note : 2015/04/15 呉軍</br>
        /// <br>            : Redmine#45436 №78在庫受払履歴データ登録不具合の修正</br>
        /// </remarks>
        //private void SetNewStockData(ref object stockObj, MeijiGoodsStockWork meijiGoodsStockWork, int logicalDeleteCode)　// DEL 呉軍 2015/04/15 Redmine45436の№78
        // ADD 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
        private void SetNewStockData(ref object stockObj,GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, MeijiGoodsStockWork meijiGoodsStockWork, int logicalDeleteCode,
                     GoodsUWork goodsChgWork, GoodsPriceUWork goodsPriceUWork, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic,
                     Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, int rowNo)
        // ADD 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<
        {
            CustomSerializeArrayList stockAdjustCsList = (CustomSerializeArrayList)stockObj;
            CustomSerializeArrayList insertWorkList = null;

            ArrayList stockAdjustWorkList = new ArrayList();// 在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = new ArrayList();// 在庫調整明細データリスト
            ArrayList stockOldWorkList = new ArrayList();// 在庫データリスト

            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            StockWork stockWork = new StockWork();

            // 在庫調整データ、在庫調整明細データ、在庫データリスト取得
            if (stockAdjustCsList != null && stockAdjustCsList.Count > 0)
            {
                insertWorkList = (CustomSerializeArrayList)stockAdjustCsList[0];
            }
            if (insertWorkList != null && insertWorkList.Count > 0)
            {
                stockAdjustWorkList = (ArrayList)insertWorkList[0];
                stockAdjustDtlWorkList = (ArrayList)insertWorkList[1];
                stockOldWorkList = (ArrayList)insertWorkList[2];
            }

            // 在庫調整、在庫調整明細、在庫ワークの取得
            // DEL 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
            //if (stockAdjustWorkList != null && stockAdjustWorkList.Count > 0)
            //{
            //    stockAdjustWork = (StockAdjustWork)stockAdjustWorkList[0];
            //}
            //if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
            //{
            //    stockAdjustDtlWork = (StockAdjustDtlWork)stockAdjustDtlWorkList[0];
            //}
            // DEL 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<
            if (stockOldWorkList != null && stockOldWorkList.Count > 0)
            {
                stockWork = (StockWork)stockOldWorkList[0];
            }

            #region DEL
            //----- DEL 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
            //double allCount = stockWork.SupplierStock + stockWork.SalesOrderCount + stockWork.ShipmentCnt; 

            //if (allCount > 0) 
            //{ 
                //// 在庫調整データ
                //stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                //stockAdjustWork.StockAdjustSlipNo = 0;
                //// 在庫調整明細データ
                //stockAdjustDtlWork.StockAdjustSlipNo = 0;
                //stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                //stockAdjustDtlWork.AdjustCount = stockWork.SupplierStock;
                //stockAdjustDtlWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
            //}

            //// 在庫データ
            //stockWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
            //stockWork.GoodsNoNoneHyphen = meijiGoodsStockWork.NewGoodsNo.Replace("-", "");
            //stockWork.UpdateDateTime = DateTime.MinValue;
            //stockWork.LogicalDeleteCode = logicalDeleteCode;
            //stockWork.MovingSupliStock = 0;
            //stockWork.AcpOdrCount = 0;
            //stockWork.ArrivalCnt = 0;
            //stockWork.SupplierStock = stockWork.ShipmentPosCnt + stockWork.ShipmentCnt;
            //----- DEL 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<
            #endregion

            // ADD 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
            #region  在庫データ補正
            // 品番←新品番
            stockWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
            stockWork.GoodsNoNoneHyphen = meijiGoodsStockWork.NewGoodsNo.Replace("-", "");
            stockWork.UpdateDateTime = DateTime.MinValue;
            stockWork.LogicalDeleteCode = logicalDeleteCode;
            // 移動中仕入在庫数：ゼロ固定
            stockWork.MovingSupliStock = 0;
            // 受注数：ゼロ固定
            stockWork.AcpOdrCount = 0;
            // 入荷数(未計上)：ゼロ固定
            stockWork.ArrivalCnt = 0;
            // 仕入在庫数：旧品番在庫の出荷可能数+出荷数(未計上)
            stockWork.SupplierStock = stockWork.ShipmentPosCnt + stockWork.ShipmentCnt;
            #endregion

            // DEL 呉軍 2015/04/17 Redmine45436の№78 ----->>>>>
            //// 出荷可能数と出荷数(未計上)にいずれがゼロではない場合、在庫調整データ作成する
            //if (stockWork.ShipmentPosCnt != 0 || stockWork.ShipmentCnt != 0)
            // DEL 呉軍 2015/04/17 Redmine45436の№78 -----<<<<<
            // ADD 呉軍 2015/04/17 Redmine45436の№78 ----->>>>>
            // 新品番在庫の仕入在庫数がゼロではない場合のみ、在庫調整データ作成する
            if (stockWork.SupplierStock != 0)
            // ADD 呉軍 2015/04/17 Redmine45436の№78 -----<<<<<
            {
                #region 在庫調整データの作成
                if (stockAdjustWorkList != null && stockAdjustWorkList.Count > 0)
                {
                    stockAdjustWork = (StockAdjustWork)stockAdjustWorkList[0];
                    stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                    stockAdjustWork.StockAdjustSlipNo = 0;
                }
                else
                {
                    if (stockAdjustWorkList == null)
                    {
                        stockAdjustWorkList = new ArrayList();
                    }
                    stockAdjustWork.EnterpriseCode = stockWork.EnterpriseCode;
                    stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                    stockAdjustWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode.Trim();
                    stockAdjustWork.StockAdjustSlipNo = 0;
                    stockAdjustWork.AcPaySlipCd = 42;
                    stockAdjustWork.AcPayTransCd = 30;
                    stockAdjustWork.AdjustDate = DateTime.Now;
                    stockAdjustWork.InputDay = DateTime.Now;
                    stockAdjustWork.StockSectionCd = stockWork.SectionCode;
                    if (sectionDic.ContainsKey(stockWork.SectionCode.Trim()))
                    {
                        stockAdjustWork.StockSectionGuideNm = sectionDic[stockWork.SectionCode.Trim()].Trim();
                    }
                    stockAdjustWork.StockInputCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                    stockAdjustWork.StockInputName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                    stockAdjustWork.StockAgentCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                    stockAdjustWork.StockAgentName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                    stockAdjustWork.StockSubttlPrice = 0;
                    //stockAdjustWork.SlipNote = ""; // DEL 呉軍 2015/04/27 レビュー結果対応

                    stockAdjustWorkList.Add(stockAdjustWork);
                } 
                #endregion

                #region 在庫調整明細データの作成
                if (stockAdjustDtlWorkList != null && stockAdjustDtlWorkList.Count > 0)
                {
                    stockAdjustDtlWork = (StockAdjustDtlWork)stockAdjustDtlWorkList[0];
                    stockAdjustDtlWork.StockAdjustSlipNo = 0;
                    stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                    stockAdjustDtlWork.AdjustCount = stockWork.SupplierStock;
                    stockAdjustDtlWork.GoodsNo = meijiGoodsStockWork.NewGoodsNo;
                }
                else
                {
                    if (stockAdjustDtlWorkList == null)
                    {
                        stockAdjustDtlWorkList = new ArrayList();
                    }
                    stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                    //stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue; // DEL 呉軍 2015/04/27 レビュー結果対応
                    stockAdjustDtlWork.EnterpriseCode = stockWork.EnterpriseCode;
                    // 拠点のセット
                    stockAdjustDtlWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode;
                    if (sectionDic.ContainsKey(goodsChangeAllCndWorkWork.LoginSectionCode.Trim()))
                    {
                        stockAdjustDtlWork.SectionGuideNm = sectionDic[goodsChangeAllCndWorkWork.LoginSectionCode.Trim()].Trim();
                    }
                    stockAdjustDtlWork.StockAdjustSlipNo = 0;
                    stockAdjustDtlWork.StockAdjustRowNo = rowNo;
                    stockAdjustDtlWork.SupplierFormalSrc = 0;
                    stockAdjustDtlWork.StockSlipDtlNumSrc = 0;
                    stockAdjustDtlWork.AcPaySlipCd = 42;
                    stockAdjustDtlWork.AcPayTransCd = 30;
                    stockAdjustDtlWork.AdjustDate = DateTime.Now;
                    stockAdjustDtlWork.InputDay = DateTime.Now;
                    stockAdjustDtlWork.StockUnitPriceFl = 0;
                    stockAdjustDtlWork.BfStockUnitPriceFl = 0;
                    stockAdjustDtlWork.GoodsMakerCd = stockWork.GoodsMakerCd;
                    if (makerDic.ContainsKey(stockWork.GoodsMakerCd))
                    {
                        stockAdjustDtlWork.MakerName = makerDic[stockWork.GoodsMakerCd];
                    }
                    stockAdjustDtlWork.AdjustCount = stockWork.SupplierStock;
                    stockAdjustDtlWork.DtlNote = "";
                    stockAdjustDtlWork.WarehouseCode = stockWork.WarehouseCode;
                    // 倉庫情報のセット
                    if (!string.IsNullOrEmpty(stockWork.WarehouseCode.Trim()))
                    {
                        int wareHouseCodeKey = Convert.ToInt32(stockWork.WarehouseCode.Trim());
                        if (wareHouseDic.ContainsKey(wareHouseCodeKey))
                        {
                            stockAdjustDtlWork.WarehouseName = wareHouseDic[wareHouseCodeKey];
                        }
                    }
                    stockAdjustDtlWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                    stockAdjustDtlWork.StockPriceTaxExc = 0;
                    stockAdjustDtlWork.GoodsNo = stockWork.GoodsNo;

                    // 商品情報のセット
                    stockAdjustDtlWork.GoodsName = goodsChgWork.GoodsName;
                    stockAdjustDtlWork.BLGoodsCode = goodsChgWork.BLGoodsCode;
                    if (blGoodsDic.ContainsKey(stockAdjustDtlWork.BLGoodsCode))
                    {
                        stockAdjustDtlWork.BLGoodsFullName = blGoodsDic[stockAdjustDtlWork.BLGoodsCode];
                    }

                    // 価格情報のセット
                    stockAdjustDtlWork.ListPriceFl = goodsPriceUWork.ListPrice;
                    stockAdjustDtlWork.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
                    stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                }
                #endregion
            }
            // ADD 呉軍 2015/04/17 Redmine45436の№78 ----->>>>>
            else
            {
                //在庫調整のデータリストと明細リストクリアする
                ArrayList emptyList = new ArrayList();
                object emptyObj = emptyList;
                CustomSerializeArrayList level01List = new CustomSerializeArrayList();
                level01List.Add(emptyObj); // [0]
                level01List.Add(emptyObj); // [1]
                object thirdObj = stockOldWorkList;
                level01List.Add(thirdObj); // [2]

                object level01Obj = level01List;
                CustomSerializeArrayList topList = new CustomSerializeArrayList();
                topList.Add(level01Obj);
                stockObj = topList;

                // メモリの解放
                emptyList = null;
                emptyObj = null;
                thirdObj = null;
                level01List = null;
                level01Obj = null;
                topList = null;
            }
            // ADD 呉軍 2015/04/17 Redmine45436の№78 -----<<<<<
            // ADD 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<
        }
        #endregion

        #region 旧品番在庫情報の作成
        /// <summary>
        /// 旧品番在庫情報の作成
        /// </summary>
        /// <param name="goodsNoKey">メーカー＋品番のキー</param>
        /// <param name="goodsChangeAllCndWorkWork">条件ワーク</param>
        /// <param name="stockWork">在庫ワーク</param>
        /// <param name="goodsChgWork">商品ワーク</param>
        /// <param name="goodsPriceUWork">価格ワーク</param>
        /// <param name="goodsNoAllDic">新旧品番対応Dictionary</param>
        /// <param name="makerDic">メーカーDictionary</param>
        /// <param name="wareHouseDic">倉庫Dictionary</param>
        /// <param name="blGoodsDic">ＢＬコードDictionary</param>
        /// <param name="sectionDic">拠点Dictionary</param>
        /// <param name="rowNo">在庫調整明細行番号</param>
        /// <param name="stockObj">戻りObject</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note : 2015/04/15 呉軍</br>
        /// <br>            : Redmine#45436 №78在庫受払履歴データ登録不具合の修正</br>
        /// </remarks>
        private void SetOldStockData(string goodsNoKey, GoodsChangeAllCndWorkWork goodsChangeAllCndWorkWork, StockWork stockWork, GoodsUWork goodsChgWork, 
            GoodsPriceUWork goodsPriceUWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, Dictionary<int, string> makerDic, Dictionary<int, string> wareHouseDic, 
            Dictionary<int, string> blGoodsDic, Dictionary<string, string> sectionDic, int rowNo, out object stockObj)
        {
            ArrayList stockAdjustWorkList = new ArrayList();// 在庫調整データリスト
            ArrayList stockAdjustDtlWorkList = new ArrayList();// 在庫調整明細データリスト
            ArrayList stockOldWorkList = new ArrayList();// 在庫データリスト

            CustomSerializeArrayList insertWorkList = new CustomSerializeArrayList();
            CustomSerializeArrayList stockAdjustCsList = new CustomSerializeArrayList();

            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            stockObj = null;

            // DEL 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
            //// 在庫調整データ・在庫調整明細データの作成
            //double allCount = stockWork.SupplierStock + stockWork.AcpOdrCount + stockWork.SalesOrderCount
            //        + stockWork.MovingSupliStock + stockWork.ShipmentCnt + stockWork.ArrivalCnt;
            // DEL 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<

            #region 在庫データの作成
            stockWork.LogicalDeleteCode = 3;
            stockOldWorkList.Add(stockWork);
            #endregion

            // DEL 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
            //// 在庫データ作成
            //if (allCount > 0)
            // DEL 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<
            // ADD 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
            // 旧品番現在庫数がある場合のみ在庫調整データを作成する
            if (stockWork.ShipmentPosCnt != 0)
            // ADD 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<
            {
                #region 在庫調整データの作成
                stockAdjustWork.UpdateDateTime = DateTime.MinValue;
                stockAdjustWork.EnterpriseCode = stockWork.EnterpriseCode;
                stockAdjustWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode.Trim();
                stockAdjustWork.AcPaySlipCd = 42;
                stockAdjustWork.AcPayTransCd = 30;
                stockAdjustWork.AdjustDate = DateTime.Now;
                stockAdjustWork.InputDay = DateTime.Now;
                stockAdjustWork.StockSectionCd = stockWork.SectionCode;
                if (sectionDic.ContainsKey(stockWork.SectionCode.Trim()))
                {
                    stockAdjustWork.StockSectionGuideNm = sectionDic[stockWork.SectionCode.Trim()].Trim();
                }
                stockAdjustWork.StockInputCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                stockAdjustWork.StockInputName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                stockAdjustWork.StockAgentCode = goodsChangeAllCndWorkWork.LoginEmpleeCode;
                stockAdjustWork.StockAgentName = goodsChangeAllCndWorkWork.LoginEmpleeName;
                stockAdjustWork.StockSubttlPrice = 0;
                //stockAdjustWork.SlipNote = ""; // DEL 呉軍 2015/04/27 レビュー結果対応
                stockAdjustWorkList.Add(stockAdjustWork);
                #endregion

                #region 在庫調整明細データの作成
                stockAdjustDtlWork.UpdateDateTime = DateTime.MinValue;
                stockAdjustDtlWork.EnterpriseCode = stockWork.EnterpriseCode;
                // 拠点のセット
                stockAdjustDtlWork.SectionCode = goodsChangeAllCndWorkWork.LoginSectionCode;
                if (sectionDic.ContainsKey(goodsChangeAllCndWorkWork.LoginSectionCode.Trim()))
                {
                    stockAdjustDtlWork.SectionGuideNm = sectionDic[goodsChangeAllCndWorkWork.LoginSectionCode.Trim()].Trim();
                }
                stockAdjustDtlWork.StockAdjustRowNo = rowNo;
                stockAdjustDtlWork.SupplierFormalSrc = 0;
                stockAdjustDtlWork.StockSlipDtlNumSrc = 0;
                stockAdjustDtlWork.AcPaySlipCd = 42;
                stockAdjustDtlWork.AcPayTransCd = 30;
                stockAdjustDtlWork.AdjustDate = DateTime.Now;
                stockAdjustDtlWork.InputDay = DateTime.Now;
                stockAdjustDtlWork.StockUnitPriceFl = 0;
                stockAdjustDtlWork.BfStockUnitPriceFl = 0;
                stockAdjustDtlWork.GoodsMakerCd = stockWork.GoodsMakerCd;
                if (makerDic.ContainsKey(stockWork.GoodsMakerCd))
                {
                    stockAdjustDtlWork.MakerName = makerDic[stockWork.GoodsMakerCd];
                }
                //stockAdjustDtlWork.AdjustCount = (-1) * stockWork.SupplierStock; // DEL 呉軍 2015/04/15 Redmine45436の№78
                // ADD 呉軍 2015/04/15 Redmine45436の№78 ----->>>>>
                // 調整数：仕入在庫数⇒現在庫数に変更
                stockAdjustDtlWork.AdjustCount = (-1) * stockWork.ShipmentPosCnt;
                // ADD 呉軍 2015/04/15 Redmine45436の№78 -----<<<<<

                stockAdjustDtlWork.DtlNote = "";
                stockAdjustDtlWork.WarehouseCode = stockWork.WarehouseCode;
                // 倉庫情報のセット
                if (!string.IsNullOrEmpty(stockWork.WarehouseCode.Trim()))
                {
                    int wareHouseCodeKey = Convert.ToInt32(stockWork.WarehouseCode.Trim());
                    if (wareHouseDic.ContainsKey(wareHouseCodeKey))
                    {
                        stockAdjustDtlWork.WarehouseName = wareHouseDic[wareHouseCodeKey];
                    }
                }
                stockAdjustDtlWork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                stockAdjustDtlWork.StockPriceTaxExc = 0;
                stockAdjustDtlWork.GoodsNo = stockWork.GoodsNo;

                // 商品情報のセット
                stockAdjustDtlWork.GoodsName = goodsChgWork.GoodsName;
                stockAdjustDtlWork.BLGoodsCode = goodsChgWork.BLGoodsCode;
                if (blGoodsDic.ContainsKey(stockAdjustDtlWork.BLGoodsCode))
                {
                    stockAdjustDtlWork.BLGoodsFullName = blGoodsDic[stockAdjustDtlWork.BLGoodsCode];
                }

                // 価格情報のセット
                stockAdjustDtlWork.ListPriceFl = goodsPriceUWork.ListPrice;
                stockAdjustDtlWork.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
                stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                #endregion
            }

            #region 旧品番更新用データのリスト
            insertWorkList.Add(stockAdjustWorkList);
            insertWorkList.Add(stockAdjustDtlWorkList);
            insertWorkList.Add(stockOldWorkList);
            stockAdjustCsList.Add(insertWorkList);
            #endregion

            // 戻り値セット
            stockObj = stockAdjustCsList;
        }
        #endregion
        #endregion

        #region 価格マスタ
        #region 価格WriteワークのClone
        /// <summary>
        /// ワークのClone
        /// </summary>
        /// <param name="work">価格ワーク</param>
        /// <returns></returns>
        private GoodsPriceUWork ClonePriceWork(GoodsPriceUWork work)
        {
            GoodsPriceUWork copyPriceWork = new GoodsPriceUWork();

            copyPriceWork.CreateDateTime = work.CreateDateTime;
            copyPriceWork.UpdateDateTime = work.UpdateDateTime;
            copyPriceWork.EnterpriseCode = work.EnterpriseCode;
            copyPriceWork.FileHeaderGuid = work.FileHeaderGuid;
            copyPriceWork.UpdEmployeeCode = work.UpdEmployeeCode;
            copyPriceWork.UpdAssemblyId1 = work.UpdAssemblyId1;
            copyPriceWork.UpdAssemblyId2 = work.UpdAssemblyId2;
            copyPriceWork.LogicalDeleteCode = work.LogicalDeleteCode;
            copyPriceWork.GoodsMakerCd = work.GoodsMakerCd;
            copyPriceWork.GoodsNo = work.GoodsNo;
            copyPriceWork.PriceStartDate = work.PriceStartDate;
            copyPriceWork.ListPrice = work.ListPrice;
            copyPriceWork.SalesUnitCost = work.SalesUnitCost;
            copyPriceWork.StockRate = work.StockRate;
            copyPriceWork.OpenPriceDiv = work.OpenPriceDiv;
            copyPriceWork.OfferDate = work.OfferDate;
            copyPriceWork.UpdateDate = work.UpdateDate;

            return copyPriceWork;
        }
        #endregion

        #region 価格検索
        /// <summary>
        /// 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="GoodsPriceUWorkList">検索結果</param>
        /// <param name="goodsNoAllDic">新旧品番のDictionary</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 指定された条件の商品価格マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        public int SearchGoodsPriceProc(out ArrayList GoodsPriceUWorkList, ref Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, int updateMode, string enterPriseCode, 
            ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            GoodsPriceUWorkList = new ArrayList();
            string goodsNoKey = "";
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);
                sqlCommand.CommandText += CreateQueryString(ref sqlCommand, updateMode, enterPriseCode);
                // クエリ実行時のタイムアウト時間を10分に設定する
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // 価格ワークと新旧品番ワークの作成
                    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
                    MeijiGoodsStockWork meijiGoodsStockWork;
                    // クラス格納処理 Reader → GoodsPriceUWork
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                    //CopyToGoodsPriceUWorkFromReader(ref myReader, out goodsPriceUWork, out meijiGoodsStockWork);
                    CopyToGoodsPriceUWorkFromReader(ref myReader, out goodsPriceUWork, out meijiGoodsStockWork, convertDoubleRelease);
                    //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
                    GoodsPriceUWorkList.Add(goodsPriceUWork);
                    goodsNoKey = meijiGoodsStockWork.GoodsMakerCd.ToString() + "-" + meijiGoodsStockWork.OldGoodsNo.Trim();
                    if (!goodsNoAllDic.ContainsKey(goodsNoKey))
                    {
                        goodsNoAllDic.Add(goodsNoKey, meijiGoodsStockWork);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                //基底クラスに例外を渡して処理してもらう
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
                // 解放
                convertDoubleRelease.Dispose();
                //----- ADD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            }
            return status;
        }
        #endregion

        #region [クエリ文字列生成]
        /// <summary>
        /// Search検索文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="updateMode">更新モード</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <returns>クエリ文字列</returns>
        /// <br>Note        : 商品価格マスタの検索用クエリ文字列を生成して戻します</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        private string CreateQueryString(ref SqlCommand sqlCommand, int updateMode, string enterPriseCode)
        {
            string sqlText = String.Empty;

            sqlText += "SELECT" + Environment.NewLine;
            sqlText += " GOODSPRICEURF.CREATEDATETIMERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDATEDATETIMERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.ENTERPRISECODERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.FILEHEADERGUIDRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDEMPLOYEECODERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDASSEMBLYID1RF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDASSEMBLYID2RF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.LOGICALDELETECODERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.GOODSMAKERCDRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.GOODSNORF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.PRICESTARTDATERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.LISTPRICERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.SALESUNITCOSTRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.STOCKRATERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.OPENPRICEDIVRF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.OFFERDATERF, " + Environment.NewLine;
            sqlText += " GOODSPRICEURF.UPDATEDATERF, " + Environment.NewLine;
            sqlText += " B.CHGDESTGOODSNORF " + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF WITH (READUNCOMMITTED) " + Environment.NewLine;
            if (updateMode == 0)
            {
                sqlText += " INNER JOIN GOODSNOCHANGERF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " ON GOODSPRICEURF.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
            }
            else
            {
                sqlText += " INNER JOIN GOODSNOCHANGEERRDTRF B WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " ON GOODSPRICEURF.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSNORF = B.CHGSRCGOODSNORF " + Environment.NewLine;
                sqlText += " AND GOODSPRICEURF.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += " AND B.MASTERDIVCDRF = 1 " + Environment.NewLine;
            }
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  GOODSPRICEURF.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

            // 企業コード
            SqlParameter findparaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findparaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);

            //論理削除区分
            sqlText += " AND B.LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
            sqlText += " ORDER BY GOODSPRICEURF.ENTERPRISECODERF, GOODSPRICEURF.GOODSMAKERCDRF, GOODSPRICEURF.GOODSNORF, GOODSPRICEURF.PRICESTARTDATERF ";

            return sqlText;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsPriceUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="wkGoodsPriceUWork">価格ワーク</param>
        /// <param name="meijiGoodsStockWork">新旧品番対応ワーク</param>
        /// <param name="convertDoubleRelease">数値変換部品</param>
        /// <returns>GoodsPriceUWork</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
        //private void CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader, out GoodsPriceUWork wkGoodsPriceUWork, out MeijiGoodsStockWork meijiGoodsStockWork)
        private void CopyToGoodsPriceUWorkFromReader(ref SqlDataReader myReader, out GoodsPriceUWork wkGoodsPriceUWork, out MeijiGoodsStockWork meijiGoodsStockWork, ConvertDoubleRelease convertDoubleRelease)
        //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
        {
            wkGoodsPriceUWork = new GoodsPriceUWork();
            meijiGoodsStockWork = new MeijiGoodsStockWork();

            wkGoodsPriceUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkGoodsPriceUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkGoodsPriceUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkGoodsPriceUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkGoodsPriceUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkGoodsPriceUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkGoodsPriceUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkGoodsPriceUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkGoodsPriceUWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            wkGoodsPriceUWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            wkGoodsPriceUWork.PriceStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ---------->>>>>
            //wkGoodsPriceUWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
            convertDoubleRelease.EnterpriseCode = wkGoodsPriceUWork.EnterpriseCode;
            convertDoubleRelease.GoodsMakerCd = wkGoodsPriceUWork.GoodsMakerCd;
            convertDoubleRelease.GoodsNo = wkGoodsPriceUWork.GoodsNo;
            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));

            // 変換処理実行
            convertDoubleRelease.ReleaseProc();

            wkGoodsPriceUWork.ListPrice = convertDoubleRelease.ConvertInfParam.ConvertGetParam;
            //----- UPD 2020/06/18 譚洪 PMKOBETSU-4005 ----------<<<<<
            wkGoodsPriceUWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            wkGoodsPriceUWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            wkGoodsPriceUWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            wkGoodsPriceUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkGoodsPriceUWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

            meijiGoodsStockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            meijiGoodsStockWork.OldGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            meijiGoodsStockWork.NewGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
        }
        #endregion

        #region 価格マスタに新旧品番の変換
        /// <summary>
        /// 価格マスタに新旧品番の変換処理
        /// </summary>
        /// <param name="goodsNoKey">メーカー＋品番キー</param>
        /// <param name="goodsChgWork">商品ワーク</param>
        /// <param name="goodsPriceUWork">価格ワーク</param>
        /// <param name="goodsNoAllDic">商品のDictionary</param>
        /// <param name="message">メッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>Note        : Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : 2015/04/17</br>
        /// </remarks>
        private int PriceMstChg(string goodsNoKey, GoodsUWork goodsChgWork, GoodsPriceUWork goodsPriceUWork, Dictionary<string, MeijiGoodsStockWork> goodsNoAllDic, 
            out string message, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList addWorkList = new ArrayList();
            Dictionary<string, GoodsPriceUWork> goodsPriceGetDic = new Dictionary<string, GoodsPriceUWork>();
            int logicalDeleteDiv = 0;
            // 更新リスト
            ArrayList changeWorkList = new ArrayList();
            ArrayList deleteWorkList = new ArrayList();
            // 追加リスト
            ArrayList insertWorkList = new ArrayList();
            ArrayList insertErrorWorkList = new ArrayList();
            message = "";

            try
            {
                // 旧品番の削除
                deleteWorkList.Add(goodsPriceUWork);
                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                try
                {
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                    status = this._iGoodsPriceUDB.DeleteGoodsPriceProc(deleteWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "DeleteGoodsPriceProc");
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                deleteWorkList.Clear();

                // 削除の場合異常が発生する
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 排他異常が発生する場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                        || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                    {
                        //message = DELETEERRMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        message = string.Format(GoodsNoChgCommonDB.UPDATEFAIL, "価格マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    }
                    // それ以外異常の場合
                    else
                    {
                        //message = OLDEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        message = GoodsNoChgCommonDB.OLDEXCEPTIONMSG; // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                    }
                }
                // 削除が正常の場合
                else
                {
                    // 価格登録用のパラメータにセット
                    // 旧→新品番で変換
                    goodsPriceUWork.GoodsNo = goodsNoAllDic[goodsNoKey].NewGoodsNo;
                    goodsPriceUWork.UpdateDateTime = DateTime.MinValue;
                    logicalDeleteDiv = goodsPriceUWork.LogicalDeleteCode;
                    insertWorkList.Add(goodsPriceUWork);

                    // 新品番で価格マスタ登録
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                    try
                    {
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<
                        status = this._iGoodsPriceUDB.WriteGoodsPriceProc(ref insertWorkList, out insertErrorWorkList, ref sqlConnection, ref sqlTransaction);
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------>>>>>
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "WriteGoodsPriceProc");
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    //----- ADD 2015/04/17 時シン Redmine#45436 部品を使用してマスタの削除/登録を実行している箇所を例外キャッチする対応------<<<<<

                    // 登録時異常が発生する場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 排他異常が発生する場合
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE
                            || status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                        {
                            //message = EXISTMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = string.Format(GoodsNoChgCommonDB.EXISTMSG, "価格マスタ"); // ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                        // それ以外異常の場合
                        else
                        {
                            //message = NEWEXCEPTIONMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = GoodsNoChgCommonDB.NEWEXCEPTIONMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                    }
                    // 新品番登録正常の場合
                    else
                    {
                        // 元データが論理削除の場合、新品番も論理削除分として変更する
                        if (logicalDeleteDiv == 1)
                        {
                            //message = DELETEMSG; // DEL 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                            message = GoodsNoChgCommonDB.DELETEMSG;// ADD 2015/02/26 時シン Redmine#44209 メッセージの文言対応
                        }
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsStockDB.PriceMstChg");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion
        #endregion
    }
}

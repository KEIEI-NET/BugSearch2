//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐
// プログラム概要   : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐インターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/06/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : ハンディターミナル二次開発の対応
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 譚洪
// 作 成 日  2020/03/09  修正内容 : PMKOBETSU-3268の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ﾊﾝﾃﾞｨﾀｰﾐﾅﾙ常駐 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/06/06</br>
    /// <br>Update Note: 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>           : ハンディターミナル二次開発の対応</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public interface IPmHandy
    {
        /// <summary>
        /// ログイン情報取得
        /// </summary>
        /// <param name="paraHandyLoginInfoObj">ログイン情報抽出条件リスト</param>
        /// <param name="resultHandyLoginInfoObj">ログイン情報結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ログイン情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        int SearchHandyLoginInfo(
            ref object paraHandyLoginInfoObj,
            out object resultHandyLoginInfoObj);

        /// <summary>
        /// 在庫情報(通常)取得
        /// </summary>
        /// <param name="paraHandyStockCondObj">在庫情報(通常)抽出条件リスト</param>
        /// <param name="resultHandyStockObj">在庫情報(通常)結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報(通常)を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        int SearchHandyStock(
            ref object paraHandyStockCondObj,
            out object resultHandyStockObj);

        /// <summary>
        /// 在庫情報(一括検品)取得
        /// </summary>
        /// <param name="paraHandyStockCondObj">在庫情報(一括検品)抽出条件リスト</param>
        /// <param name="resultHandyStockObj">在庫情報(一括検品)結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報(一括検品)を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        int SearchHandyStockInspect(
            ref object paraHandyStockCondObj,
            out object resultHandyStockObj);

        /// <summary>
        /// 検品対象取得(伝票番号)処理
        /// </summary>
        /// <param name="paraHandyInspectCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyInspectObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象取得(伝票番号)を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        int SearchHandyInspectDataSlipNum(
            ref object paraHandyInspectCondObj,
            out object resultHandyInspectObj);

        /// <summary>
        /// 検品対象取得(一括検品)処理
        /// </summary>
        /// <param name="paraHandyInspectCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyInspectObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象取得(一括検品)を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        int SearchHandyInspectDataTotal(
            ref object paraHandyInspectCondObj,
            out object resultHandyInspectObj);

        /// <summary>
        /// 商品バーコード関連付けマスタ登録
        /// </summary>
        /// <param name="paraHandyGoodsBarCodeObj">登録オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタを登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        int InsertHandyGoodsBarCode(
            ref object paraHandyGoodsBarCodeObj);

        /// <summary>
        /// 検品データ登録処理
        /// </summary>
        /// <param name="retObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品データを登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        int WriteInspectData(ref object retObj);

        /// <summary>
        /// 検品データ登録(先行検品)処理
        /// </summary>
        /// <param name="retObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        int WriteSenKouInspect(ref object retObj);

        // ------ ADD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// ハンディターミナル発注先ガイド情報抽出処理
        /// </summary>
        /// <param name="paraHandySupplierGuideCondObj">ハンディターミナル発注先ガイド情報抽出条件リスト</param>
        /// <param name="resultHandySupplierGuideObj">ハンディターミナル発注先ガイド情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル発注先ガイド情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchHandySupplierGuide(ref object paraHandySupplierGuideCondObj, out object resultHandySupplierGuideObj);

        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（入庫更新）_一覧抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_一覧情報を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchHandyStockSupplierList(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj);

        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_明細抽出処理
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（入庫更新）_明細抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（入庫更新）_明細抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_明細を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchHandyStockSupplierSlipNum(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj);

        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_登録処理
        /// </summary>
        /// <param name="retObj">ハンディターミナル在庫仕入（入庫更新）登録データ</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int WriteHandyStockSupplier(ref object retObj);

        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）_明細抽出処理
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">ハンディターミナル在庫仕入（UOE以外）_明細抽出条件リスト</param>
        /// <param name="resultHandyStockSupplierObj">ハンディターミナル在庫仕入（UOE以外）_明細抽出結果リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（UOE以外）_明細を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchHandyNonUOEStockSupplier(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj);

        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）_登録処理
        /// </summary>
        /// <param name="retObj">ハンディターミナル在庫仕入（UOE以外）登録データ</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（UOE以外）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int WriteHandyNonUOEInspect(ref object retObj);

        /// <summary>
        /// ハンディターミナル委託在庫補充_倉庫情報抽出処理
        /// </summary>
        /// <param name="paraHandyWarehouseInfoCondObj">ハンディターミナル委託在庫補充_倉庫情報抽出条件リスト</param>
        /// <param name="resultHandyWarehouseInfoObj">ハンディターミナル委託在庫補充_倉庫情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_倉庫情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchHandyWarehouseInfo(ref object paraHandyWarehouseInfoCondObj, out object resultHandyWarehouseInfoObj);

        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報抽出処理
        /// </summary>
        /// <param name="paraHandyInspectInfoCondObj">ハンディターミナル委託在庫補充_検品情報抽出条件リスト</param>
        /// <param name="resultHandyInspectInfoObj">ハンディターミナル委託在庫補充_検品情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchHandyInspectInfo(ref object paraHandyInspectInfoCondObj, out object resultHandyInspectInfoObj);

        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報登録処理
        /// </summary>
        /// <param name="inspectDataListObj">ハンディターミナル委託在庫補充_検品情報登録データ</param>
        /// <returns>登録結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int WriteHandyConsStockRepInspect(ref object inspectDataListObj);
        // ------ ADD 2017/08/02 譚洪 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// ハンディターミナル在庫仕入取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫仕入情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchStock(
            ref object condObj,
            out object retObj);

        /// <summary>
        /// 在庫仕入_検品データ登録(先行検品)処理
        /// </summary>
        /// <param name="retObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int WriteHandyInspect(ref object retObj);

        /// <summary>
        /// ハンディターミナル在庫移動情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫仕入情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int SearchStockMoveData(
            ref object condObj,
            out object retObj);

        /// <summary>
        /// 在庫移動（出荷・入荷）検品データ登録処理
        /// </summary>
        /// <param name="retObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        int WriteStockMoveInspect(ref object retObj);
        // ------ ADD 2017/08/02 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        // ------ ADD 2017/08/16 陳艶丹 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象確認処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象が存在しているかの確認を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        int SearchCount(
            ref object condObj);

        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="refObj">検索结果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks> 
        /// <br>Note       : 棚卸対象と取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        int SearchInventory(
            ref object condObj,
            out object refObj);

        /// <summary>
        /// 棚卸処理(一斉)_棚卸データ登録処理
        /// </summary>
        /// <param name="refObj">更新条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks> 
        /// <br>Note       : 棚卸データ登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        int WriteInventoryData(ref object refObj);

        /// <summary>
        /// 棚卸処理(循環)_倉庫存在確認処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 倉庫データを検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        int SearchStockCount(ref object condObj);

        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 在庫情報を検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        int SearchStockCircul(ref object condObj, out object retObj);

        /// <summary>
        /// 棚卸処理（循環)_棚卸情報登録
        /// </summary>
        /// <param name="inventoryDataObj">棚卸情報データオブジェクト</param>
        /// <param name="retObj">棚卸通番オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 棚卸情報を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        int WriteCirculInventoryData(ref object inventoryDataObj, out object retObj);

        // ------ ADD 2017/08/16 陳艶丹 ハンディターミナル二次開発 --------- <<<<

        /// <summary>
        /// 読込最大件数取得
        /// </summary>
        /// <returns>読込最大件数</returns>
        /// <remarks>
        /// <br>Note       : 読込最大件数を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        int GetReadingCount();

        /// <summary>
        /// 書込最大件数取得
        /// </summary>
        /// <returns>書込最大件数</returns>
        /// <remarks>
        /// <br>Note       : 書込最大件数を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        int GetWritingCount();

        /// <summary>
        /// 読込最大件数設定
        /// </summary>
        /// <param name="readMaxCount">読込最大件数</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : 読込最大件数を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        void SetReadMaxCount(int readMaxCount);

        /// <summary>
        /// 書込最大件数設定
        /// </summary>
        /// <param name="writeMaxCount">書込最大件数</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : 書込最大件数を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        void SetWriteMaxCount(int writeMaxCount);

        /// <summary>
        /// スレッド待ち時間設定
        /// </summary>
        /// <param name="threadWaitTime">スレッド待ち時間</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : スレッド待ち時間を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        void SetThreadWaitTime(int threadWaitTime);

        /// <summary>
        /// 終了フラグ設定
        /// </summary>
        /// <param name="closeFlg">終了フラグ</param>
        /// <returns>True：画面終了 FALSE：画面終了しない</returns>
        /// <remarks>
        /// <br>Note       : 終了フラグを設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/06/06</br>
        /// </remarks>
        void SetCloseFlg(bool closeFlg);

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 倉庫リスト取得
        /// </summary>
        /// <param name="paraHandyWarehouseListCondObj">ハンディターミナル倉庫リスト_抽出条件リスト</param>
        /// <param name="resultHandyWarehouseListObj">ハンディターミナル倉庫リスト_抽出結果リスト</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル倉庫リストを処理します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        int SearchHandyWarehouseList(ref object paraHandyWarehouseListCondObj, out object resultHandyWarehouseListObj);
        // --- ADD 2019/11/13 ----------<<<<<

        // --- ADD 2020/03/09 譚洪 PMKOBETSU-3268の対応 ---------->>>>>
        /// <summary>
        /// パターン検索
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件</param>
        /// <param name="resultHandyStockInfoListObj">検索結果</param>
        /// <param name="makerGoodsSerchHisNoObj">パターン検索履歴通番</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : パターン検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int SearchHandyStockPaturn(ref object paraHandyStockInfoCondObj, out object resultHandyStockInfoListObj, out object makerGoodsSerchHisNoObj);

        /// <summary>
        /// 品番検索処理
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件</param>
        /// <param name="resultHandyStockInfoListObj">検索結果</param>
        /// <param name="makerGoodsSerchHisNoObj">パターン検索履歴通番</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 品番検索処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int SearchHandyStockGoodsNo(ref object paraHandyStockInfoCondObj, out object resultHandyStockInfoListObj, out object makerGoodsSerchHisNoObj);

        /// <summary>
        /// UOE発注データ検索処理
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件</param>
        /// <param name="count">戻り件数</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データ検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int CheckHandyUOEOrder(ref object paraHandyStockInfoCondObj, out object count);

        /// <summary>
        /// 在庫登録
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : パターン検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int WriteHandyStock(ref object paraHandyStockInfoCondObj);

        /// <summary>
        /// メーカーマスタ全検索
        /// </summary>
        /// <param name="resultHandyMakerInfoObj">検索結果</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタ全検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int SearchHandyMakerList(out object resultHandyMakerInfoObj);

        /// <summary>
        /// メーカー情報検索
        /// </summary>
        /// <param name="resultHandyMakerInfoObj">検索結果</param>
        /// <param name="paraEnterpriseCode">企業コード</param>
        /// <param name="paraMakerCd">メーカーコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタ検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int SearchHandyMakerInfo(out object resultHandyMakerInfoObj, string paraEnterpriseCode, int paraMakerCd);

        /// <summary>
        /// 仕入先マスタ全検索
        /// </summary>
        /// <param name="resultHandySupplierInfoObj">検索結果</param>
        /// <returns>抽出結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ全検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int SearchHandySupplierList(out object resultHandySupplierInfoObj);

        /// <summary>
        /// 仕入先マスタ検索
        /// </summary>
        /// <param name="resultHandySupplierInfoObj">検索結果</param>
        /// <param name="paraEnterpriseCode">企業コード</param>
        /// <param name="paraSupplierCode">仕入先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ全検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        int SearchHandySupplierInfo(out object resultHandySupplierInfoObj, string paraEnterpriseCode, int paraSupplierCode);
        // --- ADD 2020/04/10 M.KISHI ---------->>>>>
        /// <summary>
        /// 倉庫名取得
        /// </summary>
        /// <param name="resultWarehouseName">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="warehousecode">倉庫コード</param>
        /// <returns>ステータス</returns>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 倉庫名を取得する。</br>
        /// <br>Programmer : M.KISHI</br>
        /// <br>Date       : 2020/04/10</br>
        /// </remarks>
        int SearchHandyWarehouseInfoForStock(out object resultWarehouseName,
                                            object enterpriseCode,
                                            object warehousecode);
        // --- ADD 2020/04/10 M.KISHI ----------<<<<<

    }
}

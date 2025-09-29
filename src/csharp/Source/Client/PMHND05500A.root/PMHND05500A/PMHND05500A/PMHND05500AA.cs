//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル循環棚卸アクセスクラス
// プログラム概要   : ハンディターミナル循環棚卸アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル循環棚卸アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル循環棚卸アクセスクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public class HandyCirculInventAcs
    {
        #region [定数]
        /// <summary>処理が正常に終了した場合のステータス</summary>
        private const int StatusNomal = 0;
        /// <summary>情報が見つからない場合のステータス</summary>
        private const int StatusNotFound = 4;
        /// <summary>タイムアウト発生した場合のステータス</summary>
        private const int StatusTimeout = 5;
        /// <summary>DB処理等でエラーが発生した場合のステータス</summary>
        private const int StatusError = -1;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND05500A_";
        /// <summary>デフォルトログファイル拡張子</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>デフォルトログファイル名称日付フォーマット</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>企業コード</summary>
        private const string EnterpriseCode = "企業コード:";
        /// <summary>従業員コード</summary>
        private const string EmployeeCode = "従業員コード:";
        /// <summary>コンピュータ名</summary>
        private const string MachineName = "コンピュータ名:";
        /// <summary>処理区分</summary>
        private const string ProcDiv = "処理区分:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>商品バーコード</summary>
        private const string GoodsBarCode = "商品バーコード:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>循環棚卸通番</summary>
        private const string InventorySeqNo = "循環棚卸通番:";
        /// <summary>棚番</summary>
        private const string WarehouseShelfNo = "棚番:";
        /// <summary>棚卸数</summary>
        private const string InventoryStockCnt = "棚卸数:";
        /// <summary>備考</summary>
        private const string Note = "備考:";
        /// <summary>初回フラグ</summary>
        private const string FirstFlg = "初回フラグ:"; 
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgNull = "検索条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgParam = "入力パラメータエラーが発生しました。";
        #endregion

        // ===================================================================================== //
        // Static 変数
        // ===================================================================================== //
        #region Static Members
        /// <summary>ログ用ロック</summary>
        static object LogLockObj = null;
        #endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public HandyCirculInventAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// 棚卸処理（循環)_倉庫存在確認処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理（循環)指定倉庫に在庫情報が存在しているかを確認します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStockCount(object condObj)
        {
            int status = StatusError;

            // 検索条件
            HandyInventoryCondWork circulInventCondWork = condObj as HandyInventoryCondWork;

            // パラメータがnullの場合、
            if (circulInventCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull, 1);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 入力パラメータ企業コード、従業員コード、コンピュータ名、倉庫コードは空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(circulInventCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.WarehouseCode))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 1);
                    return status;
                }
            }
            try
            {
                #region 倉庫存在確認
                byte[] condByte = XmlByteSerializer.Serialize(circulInventCondWork);
                IHandyInventoryDataDB iInventoryDataDBObj = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                status = iInventoryDataDBObj.SearchStockCount(condByte);

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 倉庫に在庫情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // 読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    status = StatusError;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(circulInventCondWork, ex.ToString(), 1);
                status = StatusError;
            }
            finally
            {
                // 処理なし。
            }

            return status;
        }

        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理（循環)の指定在庫品の在庫情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStock(object condObj,out object retObj)
        {
            int status = StatusError;
            retObj = null;
            // 検索条件
            HandyStockCondWork stockCondWork = new HandyStockCondWork();
            HandyInventoryCondWork circulInventCondWork = condObj as HandyInventoryCondWork;
            // 処理区分：現状は未使用の為、デフォルト値が「0:初回読込」
            // --- MOD 2019/11/13 ---------->>>>>
            //stockCondWork.OpDiv = circulInventCondWork.ProcDiv;
            stockCondWork.OpDiv = circulInventCondWork.ProcDiv;
            if (string.IsNullOrEmpty(circulInventCondWork.GoodsBarCode) && !string.IsNullOrEmpty(circulInventCondWork.GoodsNo))
            {
                // 品番検索
                stockCondWork.GoodsNo = circulInventCondWork.GoodsNo;
            }
            // --- MOD 2019/11/13 ----------<<<<<
            // 企業コード
            stockCondWork.EnterpriseCode = circulInventCondWork.EnterpriseCode;
            // 従業員コード
            stockCondWork.EmployeeCode = circulInventCondWork.EmployeeCode;
            // コンピュータ名
            stockCondWork.MachineName = circulInventCondWork.MachineName;
            // 倉庫コード
            stockCondWork.WarehouseCode = circulInventCondWork.WarehouseCode;
            // 商品バーコード
            stockCondWork.CustomerGoodsCode = circulInventCondWork.GoodsBarCode;

            // パラメータがnullの場合、
            if (circulInventCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull, 2);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // --- MOD 2019/11/13 ---------->>>>>
                // 入力パラメータ企業コード、従業員コード、コンピュータ名、倉庫コード、商品バーコードは空がある場合、エラーを戻ります。
                //if (string.IsNullOrEmpty(circulInventCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(circulInventCondWork.MachineName.Trim())
                //    || string.IsNullOrEmpty(circulInventCondWork.WarehouseCode.Trim())
                //    || string.IsNullOrEmpty(circulInventCondWork.GoodsBarCode.Trim())
                //    || circulInventCondWork.ProcDiv != 0)
                //{
                //    // エラーメッセージに引数の名前と値をログ出力します。
                //    this.WriteLog(circulInventCondWork, ErrorMsgParam, 2);
                //    return status;
                //}
                // 2019/11 入力パラメータ企業コード、従業員コード、コンピュータ名、倉庫コード、商品バーコード＋商品番号は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(circulInventCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.WarehouseCode.Trim())
                    || (string.IsNullOrEmpty(circulInventCondWork.GoodsBarCode.Trim()) && string.IsNullOrEmpty(circulInventCondWork.GoodsNo.Trim()))
                    || circulInventCondWork.ProcDiv != 0)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 2);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }
            try
            {
                #region 棚卸処理（循環)_在庫情報取得処理
                byte[] condByte = XmlByteSerializer.Serialize(stockCondWork);
                IHandyInventoryDataDB iInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                status = iInventoryDataDB.SearchStockHandy(condByte, out retObj);

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 在庫情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // 読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    status = StatusError;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(circulInventCondWork, ex.ToString(), 2);
                status = StatusError;
            }
            finally
            {
                // 処理なし。
            }

            return status;
        }

        # region [棚卸情報登録]
        /// <summary>
        /// 棚卸処理（循環)_棚卸情報登録
        /// </summary>
        /// <param name="inventoryDataObj">登録パラメータ</param>
        /// <param name="retObj">循環棚卸通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸情報を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteCirculInventoryData(object inventoryDataObj, out object retObj)
        {
            int status = StatusError;
            retObj = null;
            HandyInventoryCondWork circulInventCondWork = inventoryDataObj as HandyInventoryCondWork;
            // パラメータがnullの場合、
            if (circulInventCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull, 3);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目のチェック
                if (String.IsNullOrEmpty(circulInventCondWork.EnterpriseCode.Trim()) ||            // 企業コード
                    String.IsNullOrEmpty(circulInventCondWork.MachineName.Trim()) ||            // コンピュータ名
                    String.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim()) ||           // 従業員コード
                    String.IsNullOrEmpty(circulInventCondWork.WarehouseCode.Trim()) ||           // 倉庫コード
                    (circulInventCondWork.GoodsMakerCd <= 0) ||           // メーカーコード
                    (circulInventCondWork.CirculInventSeqNo < 0) ||      // 循環棚卸通番
                    (circulInventCondWork.InventoryStockCnt < 0) ||      // 棚卸数
                    (circulInventCondWork.FirstFlg <= 0) ||      // 初回フラグ
                    String.IsNullOrEmpty(circulInventCondWork.GoodsNo.Trim()))                  // 商品番号
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                    return status;
                }

                // 桁のチェック
                if (circulInventCondWork.GoodsMakerCd > 999999 ||
                    circulInventCondWork.GoodsNo.Length > 40 ||
                    circulInventCondWork.WarehouseCode.Length > 6 ||
                    circulInventCondWork.CirculInventSeqNo > 999999999 ||
                    circulInventCondWork.InventoryStockCnt > 99999999.99 ||
                    circulInventCondWork.WarehouseShelfNo.Length > 8 ||
                    circulInventCondWork.Note.TrimEnd().Length > 20 ||
                    circulInventCondWork.MachineName.Length > 20 ||
                    circulInventCondWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                    return status;
                }

                // 引数.初回フラグが「1,2」以外の場合、ST_ERR(-1)を返却します。
                if (circulInventCondWork.FirstFlg != 1 && circulInventCondWork.FirstFlg != 2)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                    return status;
                }
                // 引数.初回フラグが「1」の場合、引数.循環棚卸通番がゼロ以外であれば、ST_ERR(-1)を返却します。
                if (circulInventCondWork.FirstFlg == 1)
                {
                    if (circulInventCondWork.CirculInventSeqNo != 0)
                    {
                        // エラーメッセージに引数の名前と値をログ出力します。
                        this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                        return status;
                    }
                }
                // 引数.初回フラグが「2」の場合、引数.循環棚卸通番がゼロであれば、ST_ERR(-1)を返却します。
                else
                {
                    if (circulInventCondWork.CirculInventSeqNo == 0)
                    {
                        // エラーメッセージに引数の名前と値をログ出力します。
                        this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                        return status;
                    }
                }
            }
            try
            {
                List<GoodsUnitData> goodsUnitDataList;
                string msg;
                // 検索条件を作成
                GoodsCndtn cnd = new GoodsCndtn();
                cnd.ListPriorWarehouse = new List<string>();
                // 企業コード
                cnd.EnterpriseCode = circulInventCondWork.EnterpriseCode;
                // 拠点コード
                cnd.SectionCode = circulInventCondWork.BelongSectionCode;
                // 商品番号
                cnd.GoodsNo = circulInventCondWork.GoodsNo;
                // 商品メーカーコード
                cnd.GoodsMakerCd = circulInventCondWork.GoodsMakerCd;
                // 優先倉庫コードリスト
                cnd.ListPriorWarehouse.Add(circulInventCondWork.WarehouseCode);
                // 商品番号検索区分(0：完全一致固定)
                cnd.GoodsNoSrchTyp = 0;
                // 商品属性(9：全て)
                cnd.GoodsKindCode = 9;
                // 価格適用日(システム日付)
                cnd.PriceApplyDate = DateTime.Now;
                // 在庫調整明細データリスト
                ArrayList stockAdjustDtlList = new ArrayList();
                // 在庫調整データリスト
                ArrayList stockAdjustList = new ArrayList();
                // 在庫更新用リスト
                ArrayList stockUpdateList = new ArrayList();
                // 循環棚卸履歴明細データリスト
                ArrayList circulInventHisDtlList = new ArrayList();
                // 循環棚卸履歴データリスト
                ArrayList circulInventHisDataList = new ArrayList();
                CustomSerializeArrayList csArrayList = new CustomSerializeArrayList();
                CustomSerializeArrayList upArrayList = new CustomSerializeArrayList();
                long stockPriceTaxExc;
                // 商品連結情報取得
                GoodsAcs goodsObj = new GoodsAcs();
                status = goodsObj.Search(cnd, out goodsUnitDataList, out msg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {
                        foreach (Stock stock in goodsUnitData.StockList)
                        {
                            if (stock.WarehouseCode == circulInventCondWork.WarehouseCode)
                            {
                                // 取得した商品連結情報から、在庫情報．出荷可能数＜＞引数.棚卸数の場合、在庫調整情報データリストを作成する
                                if (stock.ShipmentPosCnt != circulInventCondWork.InventoryStockCnt)
                                {
                                    // 在庫調整明細データリストの作成
                                    stockAdjustDtlList.Add(CreateStockAdjustDtl(goodsUnitData, circulInventCondWork, stock, out stockPriceTaxExc));
                                    csArrayList.Add(stockAdjustDtlList);
                                    // 在庫調整データリストの作成
                                    stockAdjustList.Add(CreateStockAdjust(circulInventCondWork, stockPriceTaxExc));
                                    csArrayList.Add(stockAdjustList);
                                }
                                // 在庫情報．出荷可能数＜＞引数.棚卸数、もしくは棚番が変更された場合に在庫更新用リストを作成する
                                if (stock.ShipmentPosCnt != circulInventCondWork.InventoryStockCnt || stock.WarehouseShelfNo != circulInventCondWork.WarehouseShelfNo)
                                {
                                    // 在庫更新用リストの作成
                                    stockUpdateList.Add(GetStockWork(stock, circulInventCondWork));
                                    csArrayList.Add(stockUpdateList);
                                }
                                // 初回フラグが「1：初回」の場合のみ循環棚卸履歴データ作成
                                if (circulInventCondWork.FirstFlg == 1)
                                {
                                    // 循環棚卸履歴データの作成
                                    circulInventHisDataList.Add(GetCirculInventHisData(circulInventCondWork));
                                    csArrayList.Add(circulInventHisDataList);
                                }
                                // 循環棚卸履歴明細データリストの作成
                                circulInventHisDtlList.Add(GetCirculInventHisDtl(stock, circulInventCondWork));
                                csArrayList.Add(circulInventHisDtlList);
                                break;
                            }  
                        }
                    }
                    // データリストを格納する
                    upArrayList.Add(csArrayList);

                    object csArrayObj = upArrayList;
                    int circulInventSeqNo = 0;
                    IHandyInventoryDataDB iHandyInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                    // ＤＢ更新
                    status = iHandyInventoryDataDB.WriteCirculInvent(csArrayObj, out circulInventSeqNo);

                    // 登録が正常に終了した場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        HandyInventoryDataWork inventoryData = new HandyInventoryDataWork();
                        inventoryData.CirculInventSeqNo = circulInventSeqNo;
                        retObj = (object)inventoryData;
                        status = StatusNomal;
                    }
                    // 登録時のタイムアウト場合
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        status = StatusTimeout;
                    }
                    // DB処理等でエラーが発生した場合
                    else
                    {
                        status = StatusError;
                    }
                }
                else
                {
                    status = StatusError;
                }
               
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(circulInventCondWork, ex.ToString(), 3);
                status = StatusError;
            }
            finally
            {
                // 何もしない
            }

            return status;
        }
        # endregion

        # region [循環棚卸照会]
        /// <summary>
        /// 循環棚卸照会取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸照会情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCirculInvent(object condObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;
            try
            {
                IHandyInventoryDataDB iHandyInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                status = iHandyInventoryDataDB.SearchCirculInventData(condObj, out retObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion
        # endregion

        # region [private Methods]
        /// <summary>
        /// 在庫調整明細データワーククラス生成処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結情報</param>
        /// <param name="inventoryDataWork">パラメータ</param>
        /// <param name="stock"> 在庫情報</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <returns>データクラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラス生成処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private StockAdjustDtlWork CreateStockAdjustDtl(GoodsUnitData goodsUnitData, HandyInventoryCondWork inventoryDataWork, Stock stock, out long stockPriceTaxExc)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            // 企業コード
            stockAdjustDtlWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            stockAdjustDtlWork.LogicalDeleteCode = 0;
            // 拠点コード
            stockAdjustDtlWork.SectionCode = inventoryDataWork.BelongSectionCode;
            // 拠点名
            stockAdjustDtlWork.SectionGuideNm = GetSectionName(stockAdjustDtlWork.SectionCode.Trim());
            // 在庫調整伝票番号
            stockAdjustDtlWork.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            stockAdjustDtlWork.StockAdjustRowNo = 1;
            // 仕入形式(元)(ゼロ固定)
            stockAdjustDtlWork.SupplierFormalSrc = 0;
            // 仕入明細通番(元)(ゼロ固定)
            stockAdjustDtlWork.StockSlipDtlNumSrc = 0;
            // 受払元伝票区分(50:棚卸)
            stockAdjustDtlWork.AcPaySlipCd = 50;
            // 受払元取引区分(40:過不足更新)
            stockAdjustDtlWork.AcPayTransCd = 40;
            // 調整日付
            // 前回締処理日取得
            DateTime prevTotalDay = GetPrevTotalDay(inventoryDataWork.BelongSectionCode);
            if (DateTime.Now <= prevTotalDay)
            {
                // 棚卸実施日をセット
                stockAdjustDtlWork.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // 棚卸日をセット
                stockAdjustDtlWork.AdjustDate = DateTime.Now;
            }
            // 入力日付
            stockAdjustDtlWork.InputDay = DateTime.Now;
            // メーカーコード
            stockAdjustDtlWork.GoodsMakerCd = inventoryDataWork.GoodsMakerCd;
            // メーカー名称
            stockAdjustDtlWork.MakerName = goodsUnitData.MakerName;
            // 商品コード
            stockAdjustDtlWork.GoodsNo = inventoryDataWork.GoodsNo;
            // 商品名称
            stockAdjustDtlWork.GoodsName = goodsUnitData.GoodsName;
            // 仕入単価
            stockAdjustDtlWork.StockUnitPriceFl = GetStockUnitPrice(goodsUnitData, inventoryDataWork.BelongSectionCode, inventoryDataWork.EnterpriseCode);
            // 変更前仕入単価
            stockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;
            // 調整数
            stockAdjustDtlWork.AdjustCount = inventoryDataWork.InventoryStockCnt - stock.ShipmentPosCnt;
            // 明細備考
            stockAdjustDtlWork.DtlNote = string.Empty;
            // 倉庫コード
            stockAdjustDtlWork.WarehouseCode = inventoryDataWork.WarehouseCode;
            // 倉庫名称
            stockAdjustDtlWork.WarehouseName = stock.WarehouseName;
            // BLコード
            stockAdjustDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
            // BLコード名称
            stockAdjustDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
            // 倉庫棚番
            stockAdjustDtlWork.WarehouseShelfNo = stock.WarehouseShelfNo;
            // 仕入金額
            long retMoney = 0;
            StockMngTtlSt stockMngTtlStWork = new StockMngTtlSt();
            FractionCalculate.FracCalcMoney(stockAdjustDtlWork.AdjustCount * stockAdjustDtlWork.StockUnitPriceFl, 1.00, stockMngTtlStWork.FractionProcCd, out retMoney);
            stockAdjustDtlWork.StockPriceTaxExc = retMoney;
            stockPriceTaxExc = stockAdjustDtlWork.StockPriceTaxExc;
            // 定価
            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
            stockAdjustDtlWork.ListPriceFl = GetListPriceFl2(stockAdjustDtlWork.AdjustDate, goodsPriceList);
            // オープン価格区分
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                stockAdjustDtlWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            }

             return stockAdjustDtlWork;

        }

        /// <summary>
        /// 在庫調整データワーククラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <returns>在庫調整データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データワーククラスを生成します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(HandyInventoryCondWork data, long stockPriceTaxExc)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 論理削除区分
            workData.LogicalDeleteCode = 0;
            // 拠点コード
            workData.SectionCode = data.BelongSectionCode;
            // 拠点名
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim());
            // 受払元伝票区分(50：棚卸)
            workData.AcPaySlipCd = 50;
            // 受払元取引区分(40：過不足更新)
            workData.AcPayTransCd = 40;
            // 調整日付
            // 前回締処理日取得
            DateTime prevTotalDay = GetPrevTotalDay(data.BelongSectionCode);
            if (DateTime.Now <= prevTotalDay)
            {
                // 棚卸実施日をセット
                workData.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // 棚卸日をセット
                workData.AdjustDate = DateTime.Now;
            }
            // 入力日付
            workData.InputDay = DateTime.Now; 
            // 仕入拠点コード
            workData.StockSectionCd = data.BelongSectionCode;
            // 仕入拠点名称
            workData.StockSectionGuideNm = GetSectionName(data.BelongSectionCode.Trim());
            // 仕入入力者コード
            workData.StockInputCode = data.EmployeeCode;
            // 仕入入力者名称
            workData.StockInputName = GetEmployeeName(data.EnterpriseCode, data.EmployeeCode.Trim());
            // 仕入担当者コード
            workData.StockAgentCode = data.EmployeeCode;
            // 仕入担当者名称
            workData.StockAgentName = GetEmployeeName(data.EnterpriseCode, data.EmployeeCode.Trim());
            workData.SlipNote = string.Empty;
            // 仕入金額小計
            workData.StockSubttlPrice = stockPriceTaxExc;
            return workData;
        }

        /// <summary>
        /// 在庫データワーククラス生成処理
        /// </summary>
        /// <param name="stock">在庫情報</param>
        /// <param name="inventoryDataWork">パラメータ</param>
        /// <returns>在庫データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫データワーククラスを生成します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private StockWork GetStockWork(Stock stock, HandyInventoryCondWork inventoryDataWork)
        {
            StockWork stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime; // 作成日時
            stockWork.UpdateDateTime = stock.UpdateDateTime; // 更新日時
            stockWork.EnterpriseCode = inventoryDataWork.EnterpriseCode; // 企業コード
            stockWork.FileHeaderGuid = stock.FileHeaderGuid; // GUID
            stockWork.UpdEmployeeCode = inventoryDataWork.EnterpriseCode; // 更新従業員コード
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1; // 更新アセンブリID1
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2; // 更新アセンブリID2
            stockWork.LogicalDeleteCode = 0; // 論理削除区分
            stockWork.SectionCode = stock.SectionCode.TrimEnd(); // 拠点コード
            stockWork.WarehouseCode = inventoryDataWork.WarehouseCode.TrimEnd(); // 倉庫コード
            stockWork.GoodsMakerCd = inventoryDataWork.GoodsMakerCd; // 商品メーカーコード
            stockWork.GoodsNo = inventoryDataWork.GoodsNo.TrimEnd(); // 商品番号
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl; // 仕入単価（税抜,浮動）
            stockWork.SupplierStock = inventoryDataWork.InventoryStockCnt - stock.ShipmentPosCnt; // 仕入在庫数
            stockWork.AcpOdrCount = 0; // 受注数
            stockWork.MonthOrderCount = stock.MonthOrderCount; // M/O発注数
            stockWork.SalesOrderCount = 0; // 発注数
            stockWork.StockDiv = stock.StockDiv; // 在庫区分
            stockWork.MovingSupliStock = 0; // 移動中仕入在庫数
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt; // 出荷可能数
            stockWork.StockTotalPrice = stock.StockTotalPrice; // 在庫保有総額
            stockWork.LastStockDate = stock.LastStockDate; // 最終仕入年月日
            stockWork.LastSalesDate = stock.LastSalesDate; // 最終売上日
            stockWork.LastInventoryUpdate = DateTime.Now; // 最終棚卸更新日
            stockWork.MinimumStockCnt = stock.MinimumStockCnt; // 最低在庫数
            stockWork.MaximumStockCnt = stock.MaximumStockCnt; // 最高在庫数
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount; // 基準発注数
            stockWork.SalesOrderUnit = stock.SalesOrderUnit; // 発注単位
            stockWork.StockSupplierCode = stock.StockSupplierCode; // 在庫発注先コード
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen.TrimEnd(); // ハイフン無商品番号
            stockWork.WarehouseShelfNo = inventoryDataWork.WarehouseShelfNo.TrimEnd(); // 倉庫棚番
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1.TrimEnd(); // 重複棚番１
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2.TrimEnd(); // 重複棚番２
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1.TrimEnd(); // 部品管理区分１
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2.TrimEnd(); // 部品管理区分２
            stockWork.StockNote1 = stock.StockNote1.TrimEnd(); // 在庫備考１
            stockWork.StockNote2 = stock.StockNote2.TrimEnd(); // 在庫備考２
            stockWork.ShipmentCnt = 0; // 出荷数（未計上）
            stockWork.ArrivalCnt = 0; // 入荷数（未計上）
            stockWork.StockCreateDate = stock.StockCreateDate; // 在庫登録日
            stockWork.UpdateDate = DateTime.Now; // 更新年月日

            return stockWork;
        }

        /// <summary>
        /// 循環棚卸履歴データワーククラス生成処理
        /// </summary>
        /// <param name="inventoryDataWork">パラメータ</param>
        /// <returns>循環棚卸履歴データデータワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸履歴データデータワーククラスを生成します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private CirculInventHisDataWork GetCirculInventHisData(HandyInventoryCondWork inventoryDataWork)
        {
            CirculInventHisDataWork dataWork = new CirculInventHisDataWork();
            dataWork.EnterpriseCode = inventoryDataWork.EnterpriseCode; // 企業コード
            dataWork.UpdEmployeeCode = inventoryDataWork.EmployeeCode; // 更新従業員コード
            dataWork.LogicalDeleteCode = 0; // 論理削除区分
            dataWork.SectionCode = inventoryDataWork.BelongSectionCode.TrimEnd(); // 拠点コード
            dataWork.CirculInventSeqNo = 0; // 循環棚卸通番
            dataWork.WarehouseCode = inventoryDataWork.WarehouseCode; // 倉庫コード
            dataWork.Note = inventoryDataWork.Note.TrimEnd(); // 備考
            dataWork.EmployeeCode = inventoryDataWork.EmployeeCode; // 従業員コード
            return dataWork;
        }

        /// <summary>
        /// 循環棚卸履歴明細データワーククラス生成処理
        /// </summary>
        /// <param name="stock"> 在庫情報</param>
        /// <param name="inventoryDataWork">パラメータ</param>
        /// <returns>循環棚卸履歴明細データデータワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸履歴明細データデータワーククラスを生成します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private CirculInventHisDtlWork GetCirculInventHisDtl(Stock stock, HandyInventoryCondWork inventoryDataWork)
        {
            CirculInventHisDtlWork dtlWork = new CirculInventHisDtlWork();
            dtlWork.EnterpriseCode = inventoryDataWork.EnterpriseCode; // 企業コード
            dtlWork.UpdEmployeeCode = inventoryDataWork.EmployeeCode; // 更新従業員コード
            dtlWork.LogicalDeleteCode = 0; // 論理削除区分
            dtlWork.SectionCode = inventoryDataWork.BelongSectionCode.TrimEnd(); // 拠点コード
            dtlWork.CirculInventSeqNo = inventoryDataWork.CirculInventSeqNo; // 循環棚卸通番
            dtlWork.WarehouseCode = inventoryDataWork.WarehouseCode.TrimEnd(); // 倉庫コード
            dtlWork.GoodsMakerCd = inventoryDataWork.GoodsMakerCd; // 商品メーカーコード
            dtlWork.GoodsNo = inventoryDataWork.GoodsNo.TrimEnd(); // 商品番号
            dtlWork.WarehouseShelfNo = inventoryDataWork.WarehouseShelfNo.TrimEnd(); // 倉庫棚番
            dtlWork.PresentStockCnt = stock.ShipmentPosCnt; // 現在庫数量
            dtlWork.InventoryStockCnt = inventoryDataWork.InventoryStockCnt; // 棚卸在庫数
            dtlWork.InventoryDateTime = DateTime.Now; // 棚卸実施日時
            return dtlWork;
        }

        #region 従業員名称取得
        /// <summary>
        /// 従業員名称取得処理
        /// </summary>
        /// <param name="enterpriseCode"> 企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 従業員名称を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public string GetEmployeeName(string enterpriseCode, string employeeCode)
        {
            string EmployeeName = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                ArrayList retList;
                ArrayList retList2;
                EmployeeAcs employeeAcs = new EmployeeAcs();
                status = employeeAcs.Search(out retList, out retList2, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Employee employeeWork in retList)
                    {
                        if (employeeWork.LogicalDeleteCode == 0 && employeeWork.EmployeeCode.Trim().Equals(employeeCode.Trim().PadLeft(4, '0')))
                        {
                            EmployeeName = employeeWork.Name.Trim();
                        }
                    }
                }
            }
            catch
            {
                // 処理なし
            }

            return EmployeeName;
        }
        #endregion

        #region 拠点名称取得処理
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";
            try
            {
                SecInfoAcs secInfoObj = new SecInfoAcs();

                foreach (SecInfoSet secInfoSet in secInfoObj.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0 && secInfoSet.SectionCode.Trim().Equals(sectionCode.PadLeft(2, '0')))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                    }
                }
            }
            catch
            {
                // なし
            }

            return sectionName;
        }
        #endregion

        /// <summary>
        /// 最終月次更新日取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>最終月次更新日</returns>
        /// <remarks>
        /// <br>Note       : 最終月次更新日を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private DateTime GetPrevTotalDay(string sectionCode)
        {
            DateTime prevTotalDay = new DateTime();

            int status = StatusError;
            try
            {
                // 締日算出モジュール
                TotalDayCalculator totalDayCalculatorObj = TotalDayCalculator.GetInstance();
                status = totalDayCalculatorObj.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    status = totalDayCalculatorObj.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    prevTotalDay = new DateTime();
                }
            }
            catch
            {
                prevTotalDay = new DateTime();
            }
            return prevTotalDay;
        }

        /// <summary>
        /// 原単価取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>原単価</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ、商品連結データより原単価を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData, string sectionCode, string enterpriseCode)
        {
            Double stockUnitPrice = 0;

            // 商品連結データから単価算出結果オブジェクトを取得
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData, sectionCode, enterpriseCode);

            // 単価算出結果オブジェクトより原単価取得
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// 単価算出結果オブジェクト取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>単価算出結果オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 商品連結データより単価算出結果オブジェクトを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData, string sectionCode, string enterpriseCode)
        {
            // 単価算出パラメータ設定
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = sectionCode;    // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // 商品番号
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                       // 価格適用日
            unitPriceCalcParam.CountFl = 1;                                                             // 数量
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // 課税区分
            TaxRateSet taxRateSet = new TaxRateSet();
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            // 税率設定マスタ取得(税率コード=0固定)
            taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(taxRateSet, DateTime.Today);    // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // 仕入単価端数処理コード
            unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // 総額表示方法区分
            unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // 総額表示掛率適用区分
            unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;                    // 消費税転嫁方式

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            CompanyInf companyInf = null;                 // 自社情報
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out companyInf, enterpriseCode);
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            // 自社設定掛率優先順位区分(原単価算出用)
            if (companyInf != null)
            {
                unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
            unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// 商品価格取得処理
        /// </summary>
        /// <param name="targetDate">調整日付</param>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <returns>商品価格</returns>
        /// <remarks>
        /// <br>Note       : 商品価格を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private double GetListPriceFl2(DateTime targetDate, List<GoodsPrice> goodsPriceList)
        {
            double listPriceFl = 0;

            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsPrice retGoodsPrice = goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsPriceList);
            if (retGoodsPrice != null)
            {
                listPriceFl = retGoodsPrice.ListPrice;
            }

            return listPriceFl;
        }

        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="inventoryCondWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="mode">1:倉庫存在確認、2:在庫情報取得、3：棚卸情報登録</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void WriteLog(HandyInventoryCondWork inventoryCondWork, string errMsg, int mode)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + PathLog;

            lock (LogLockObj)
            {
                // フォルダが存在しない場合、
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                if (inventoryCondWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + inventoryCondWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + inventoryCondWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + inventoryCondWork.MachineName);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + inventoryCondWork.WarehouseCode);
                    if (mode == 2)
                    {
                        // 処理区分
                        writer.WriteLine(ProcDiv + inventoryCondWork.ProcDiv);
                        // 商品バーコード
                        writer.WriteLine(GoodsBarCode + inventoryCondWork.GoodsBarCode);
                    }
                    if (mode == 3)
                    {
                        // 循環棚卸通番
                        writer.WriteLine(InventorySeqNo + inventoryCondWork.CirculInventSeqNo);
                        // 棚卸数
                        writer.WriteLine(InventoryStockCnt + inventoryCondWork.InventoryStockCnt);
                        // 商品メーカーコード
                        writer.WriteLine(GoodsMakerCd + inventoryCondWork.GoodsMakerCd);
                        // 商品番号
                        writer.WriteLine(GoodsNo + inventoryCondWork.GoodsNo);
                        // 棚番
                        writer.WriteLine(WarehouseShelfNo + inventoryCondWork.WarehouseShelfNo);
                        // 備考
                        writer.WriteLine(Note + inventoryCondWork.Note.TrimEnd());
                        // 初回フラグ
                        writer.WriteLine(FirstFlg + inventoryCondWork.FirstFlg);
                    }
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}

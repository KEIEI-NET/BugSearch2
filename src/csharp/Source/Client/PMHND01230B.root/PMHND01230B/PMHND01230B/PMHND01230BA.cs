//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー品番パターン制御部品
// プログラム概要   : メーカー品番パターン制御部品 アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00  作成担当 : 譚洪
// 作 成 日  2020/03/09   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11601223-00   作成担当 : 呉元嘯
// 作 成 日  2021/06/21    修正内容 : PMKOBETSU-3268の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Reflection;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メーカー品番パターン制御部品アクセス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカー品番パターン制御部品アクセス</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/03/09</br>
    /// <br>Update Note: 2021/06/21 呉元嘯</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-3268の対応</br> 
    /// </remarks>
    public class HandyMakerGoodsContrAcs
    {
        # region ■ Constructor ■
        /// <summary>
        /// メーカー品番パターン制御部品アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br> Note      : メーカー品番パターン制御部品アクセスクラスコンストラクタ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public HandyMakerGoodsContrAcs()
        {
            LogLockObj = new object();
        }
        # endregion ■ Constructor ■

        # region ■ Const Members ■
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        /// <summary>情報が見つからない場合のステータス</summary>
        private const int StatusNotFound = 4;
        /// <summary>タイムアウト発生した場合のステータス</summary>
        private const int StatusTimeout = 5;
        /// <summary>DB処理等でエラーが発生した場合のステータス</summary>
        private const int StatusError = -1;
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgNull = "検索条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgParam = "入力パラメータエラーが発生しました。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgGoodsBarCodeRevn = "入力パーコードのバーコード関連マスタが複数件データを戻りました。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorWarehouseAcquisitionFailure = "倉庫情報の取得に失敗しました。";
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = "Log\\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND01230B_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>曖昧検索タブ</summary>
        private const string AmStr = "*";
        /// <summary>コンピューター名</summary>
        private const string EmployeeCode = "コンピューター名:";
        /// <summary>従業員コード</summary>
        private const string MachineName = "従業員コード:";
        /// <summary>企業コード</summary>
        private const string EnterpriseCode = "企業コード:";
        /// <summary>メーカーコード</summary>
        private const string GoodsMakerCd = "メーカーコード:";
        /// <summary>バーコード情報</summary>
        private const string BarCodeData = "バーコードデータ:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>倉庫棚番</summary>
        private const string WarehouseShelfNo = "倉庫棚番:";
        /// <summary>仕入先</summary>
        private const string SupplierCd = "仕入先:";
        /// <summary>入庫数</summary>
        private const string StockCount = "入庫数:";
        /// <summary>商品属性</summary>
        private const string GoodsKindCode = "商品属性:";
        /// <summary>課税区分</summary>
        private const string TaxationDivCd = "課税区分:";
        /// <summary>在庫区分</summary>
        private const string StockDiv = "在庫区分:";
        /// <summary>パターン検索履歴通番</summary>
        private const string MakerGoodsSerchHisNo = "パターン検索履歴通番:";

        // ===================================================================================== //
        // Static 変数
        // ===================================================================================== //
        #region Static Members
        /// <summary>ログ用ロック</summary>
        static object LogLockObj = null;
        # endregion

        # endregion ■ Const Members ■

        #region ■ パターン検索
        /// <summary>
        /// パターン検索
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <param name="makerGoodsSerchHisNoObj">検索履歴通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : パターン検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyStockPaturn(object condObj, out object retObj, out object makerGoodsSerchHisNoObj)
        {
            int status = StatusError;
            retObj = null;
            makerGoodsSerchHisNoObj = null;
            int makerGoodsSerchHisNo = 0;
            int makerGoodsPtrnNo = 0;
            string goodsNo = string.Empty;
            HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            // 検索条件
            HandyGoodsSearchCondWork condWork = condObj as HandyGoodsSearchCondWork;

            #region パラメータチェック
            // パラメータがnullの場合、
            if (condWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }
            else
            {
                //メーカー指定なしで呼ばれた場合は、品番検索を呼び出し
                if (condWork.GoodsMakerCd == 0)
                {
                    return this.SearchHandyStockGoodsNo(condObj, out retObj, out makerGoodsSerchHisNoObj);

                }

                // パラメータチェック
                // 入力パラメータ「企業コード、コンピューター名、従業員コード、メーカーコード、パーコード情報」は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(condWork.MachineName.Trim())
                    || condWork.GoodsMakerCd == 0
                    || string.IsNullOrEmpty(condWork.BarCodeData.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(condWork, ErrorMsgParam);
                    return status;
                }
            }
            #endregion

            try
            {
                #region 商品バーコード関連付けマスタ検索
                // 商品バーコード関連付けマスタ検索
                Object resultObj;
                ArrayList handyGoodsBarCodeRevnResultWork = new ArrayList();
                status = handyMakerGoodsPtrnAcs.SearchGoodsBarCodeRevn(condWork.EnterpriseCode, condWork.BarCodeData, 0, out resultObj);
                #endregion

                // バーコード関連マスタ情報あり場合⇒品番検索
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 商品バーコード関連マスタの抽出結果の1件目を使用
                    ArrayList goodsBarCodeRevnDataList = resultObj as ArrayList;

                    ArrayList resultList = new ArrayList();

                    foreach (object goods in goodsBarCodeRevnDataList)
                    {

                        GoodsBarCodeRevnWork work = (GoodsBarCodeRevnWork)goods;
                        goodsNo = work.GoodsNo;

                        object resultWk = null;

                        // 品番検索
                        status = SearchGoodsNo(condObj, work.GoodsMakerCd, goodsNo, 0, out resultWk);
                        if (status == StatusNomal)
                        {
                            foreach (HandyStockInsGoodsInfo info in (ArrayList)resultWk)
                            {
                                resultList.Add(info);
                            }
                        }
                        else if (status != StatusNotFound)
                        {
                            return status;
                        }

                    }

                    if (resultList.Count <= 0)
                    {
                        return StatusNotFound;
                    }

                    retObj = resultList;

                    // メーカー品番パターン検索履歴の登録
                    status = WriteHisByInsert(condWork, 0, 0, string.Empty, 1, out makerGoodsSerchHisNo);
                    makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;

                }
                // バーコード関連マスタ情報がない場合⇒メーカー品番パターンマスタを検索
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    #region メーカー品番パターンマスタ検索
                    // メーカー品番パターンマスタ検索
                    ArrayList retList = null;
                    ArrayList goodsNoList = new ArrayList();
                    status = handyMakerGoodsPtrnAcs.ReadByMakerAndBarCodeLength(out retList, condWork.EnterpriseCode, condWork.GoodsMakerCd, condWork.BarCodeData.Length, string.Empty, 1);
                    #endregion

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        #region メーカー品番パターンマスタ検索無し
                        if (retList.Count == 0)
                        {
                            // バーコード情報を品番とする
                            goodsNo = condWork.BarCodeData;

                            // 品番検索（曖昧検索）
                            status = SearchGoodsNo(condObj, condWork.GoodsMakerCd, goodsNo, 1, out retObj);

                            if (status != StatusNomal)
                            {
                                return status;
                            }

                            // メーカー品番パターン検索履歴の登録
                            status = WriteHisByInsert(condWork, makerGoodsPtrnNo, condWork.GoodsMakerCd, goodsNo, 0, out makerGoodsSerchHisNo);
                            makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;
                        }
                        #endregion

                        #region メーカー品番パターンマスタ検索あり
                        else
                        {
                            //検索品番より品番検索・履歴登録を行う
                            foreach (HandyMakerGoodsPtrnWork work in retList)
                            {
                                // メーカー品番パターンNo.
                                makerGoodsPtrnNo = work.MakerGoodsPtrnNo;
                                // 品番抽出
                                goodsNo = GetGoodsNo(condWork.BarCodeData, work);

                                // 品番検索（曖昧検索）
                                status = SearchGoodsNo(condObj, condWork.GoodsMakerCd, goodsNo, 1, out retObj);

                                if (status != StatusNomal)
                                {
                                    continue;
                                }

                                // メーカー品番パターン検索履歴の登録
                                status = WriteHisByInsert(condWork, makerGoodsPtrnNo, condWork.GoodsMakerCd, goodsNo, 0, out makerGoodsSerchHisNo);
                                makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;
                                if (status == StatusNomal)
                                {
                                    break;
                                }

                            }

                        }
                        #endregion
                    }
                    // 読込時のタイムアウト場合
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        return StatusTimeout;
                    }
                    // DB処理等でエラーが発生した場合
                    else
                    {
                        return StatusError;
                    }
                }
                // 読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    return StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    return StatusError;
                } 

            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(condWork, ex.ToString());
                status = StatusError;
            }

            return status;
        }

        /// <summary>
        /// メーカー品番パターン検索履歴の登録
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="makerGoodsPtrnNo">メーカー品番パターンNo.</param>
        /// <param name="goodsMakerCd">商品メーカー</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="callMode">0：パターン検索処理；1：パターン検索処理以外</param>
        /// <param name="makerGoodsSerchHisNo">検索履歴通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターン検索履歴の登録を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int WriteHisByInsert(HandyGoodsSearchCondWork condWork, int makerGoodsPtrnNo, int goodsMakerCd, string goodsNo, int callMode, out int makerGoodsSerchHisNo)
        {
            // 検索条件
            makerGoodsSerchHisNo = 0;
            HandyMakerGoodsPtrnHisResultWork searchHisWork = new HandyMakerGoodsPtrnHisResultWork();
            // 企業コード
            searchHisWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 実行日付
            searchHisWork.SearchDate = GetLongDate(DateTime.Today);
            // メーカーコード
            searchHisWork.GoodsMakerCd = goodsMakerCd;
            // バーコードデータ
            searchHisWork.BarCodeData = condWork.BarCodeData;
            // メーカー品番パターンNo.
            searchHisWork.MakerGoodsPtrnNo = makerGoodsPtrnNo;
            // 検索商品番号
            searchHisWork.SearchGoodsNo = goodsNo;
            // 使用回数
            searchHisWork.UseCount = 1;
            // 登録ステータス
            searchHisWork.EntryStatus = 0;
            // UOE発注データ区分
            searchHisWork.UOEOrderTdlKind = 0;

            // メーカー品番パターン検索履歴登録
            HandyMakerGoodsPtrnAcs HandyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            int status = HandyMakerGoodsPtrnAcs.WriteHis(ref searchHisWork, 0, callMode);

            // 情報取得が正常に終了した場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                makerGoodsSerchHisNo = searchHisWork.MakerGoodsSerchHisNo;
                status = StatusNomal;
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

            return status;
        }

        /// <summary>
        /// 日付数値取得処理
        /// </summary>
        /// <param name="date">DateTime型日付</param>
        /// <returns>数値日付(YYYYMMDD)</returns>
        /// <remarks>
        /// <br>Note       : 日付数値取得処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }

        /// <summary>
        /// パターン検索
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="mode">0：完全検索;1:曖昧検索</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : パターン検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int SearchGoodsNo(object condObj, int goodsMakerCd, string goodsNo, int mode, out object retObj)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // 0：完全検索;1:曖昧検索
            string goodsNoChange = (mode == 0) ? goodsNo : goodsNo + AmStr;
            string msg = string.Empty;
            retObj = null;
            HandyGoodsSearchCondWork condWork = condObj as HandyGoodsSearchCondWork;

            // 品番検索条件
            GoodsCndtn cndtn = new GoodsCndtn();
            // 企業コード
            cndtn.EnterpriseCode = condWork.EnterpriseCode;
            // 商品メーカー
            cndtn.GoodsMakerCd = goodsMakerCd;
            // 品番
            cndtn.GoodsNo = goodsNoChange;
            // 拠点
            cndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 価格開始日
            cndtn.PriceApplyDate = DateTime.Today;
            // 論理削除区分
            cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;

            // 品番検索(結合検索無し、同一品番表示なし)
            GoodsAcs handyGoodsAcs = new GoodsAcs();
            int status = handyGoodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                #region 検索結果セット
                ArrayList resultList = new ArrayList();
                ArrayList stockList = new ArrayList();
                HandyStockInsGoodsInfo goodInfo;
                HandyStockInsStockInfo stockInfo;

                //商品連結データ⇒ハンディ商品連結データにセット
                foreach (GoodsUnitData data in goodsUnitDataList)
                {
                    // 論理削除されたユーザー商品が対象外
                    if (data.OfferDataDiv == 0 && data.LogicalDeleteCode == 1) continue;
                    goodInfo = new HandyStockInsGoodsInfo();
                    stockList = new ArrayList();
                    goodInfo.GoodsMakerCd = data.GoodsMakerCd;
                    goodInfo.GoodsMakerShortName = data.MakerName;
                    goodInfo.GoodsNo = data.GoodsNo;
                    goodInfo.GoodsName = data.GoodsName;
                    goodInfo.SupplierCd = data.SupplierCd;
                    goodInfo.SupplierSNm = data.SupplierSnm;

                    //在庫情報
                    foreach (Stock stock in data.StockList)
                    {
                        stockInfo = new HandyStockInsStockInfo();
                        stockInfo.WarehouseCode = stock.WarehouseCode;
                        stockInfo.WarehouseShelfNo = stock.WarehouseShelfNo;
                        stockInfo.ShipmentPosCnt = stock.ShipmentPosCnt;
                        stockList.Add(stockInfo);
                    }
                    goodInfo.StockList = stockList;
                    resultList.Add(goodInfo);
                }
                retObj = (object)resultList;
                if (resultList.Count == 0)
                {
                    status = StatusNotFound;
                    return status;
                }
                #endregion
                status = StatusNomal;
            }
            else
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
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
            }
            return status;
        }

        /// <summary>
        /// 品番抽出
        /// </summary>
        /// <param name="barCodeData">パーコード情報</param>
        /// <param name="makerGoodsPtrnWork">メーカー品番パターンマスタ</param>
        /// <returns>品番</returns>
        /// <remarks>
        /// <br>Note       : 品番抽出を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private string GetGoodsNo(string barCodeData, HandyMakerGoodsPtrnWork makerGoodsPtrnWork)
        {
            string goodsNo = string.Empty;
            StringBuilder str = new StringBuilder();

            if (!string.IsNullOrEmpty(makerGoodsPtrnWork.ControlStr))
            {
                // 制御文字列
                char[] tempChar = makerGoodsPtrnWork.ControlStr.ToCharArray();
                // パーコード情報
                char[] barCodeChar = barCodeData.ToCharArray();

                for (int i = 0; i < tempChar.Length; i++)
                {
                    // バーコード情報と制御文字列を比較して品番を抽出する。
                    if (tempChar[i] == '1')
                    {
                        if (i < barCodeData.Length)
                        {
                            str.Append(barCodeChar[i].ToString());
                        }
                    }
                    else if (tempChar[i] == '9')
                    {
                        str.Append(barCodeChar[i].ToString());
                        break;
                    }
                }
            }
            goodsNo = str.ToString();
            // ヒットされない場合、バーコード文字列を品番として利用する
            if (string.IsNullOrEmpty(goodsNo))
            {
                goodsNo = barCodeData;
            }
            return goodsNo;
        }

        #endregion

        #region ■ 品番検索処理
        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <param name="makerGoodsSerchHisNoObj">検索履歴通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー指定の場合、品番検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyStockGoodsNo(object condObj, out object retObj, out object makerGoodsSerchHisNoObj)
        {
            int status = StatusError;
            retObj = null;
            int makerGoodsSerchHisNo = 0;
            makerGoodsSerchHisNoObj = null;

            // 検索条件
            HandyGoodsSearchCondWork condWork = condObj as HandyGoodsSearchCondWork;
            int mode = 0;
            int goodsMakerCd = 0;
            string goodsNo = string.Empty;

            #region パラメータチェック
            // パラメータがnullの場合
            if (condWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }
            else
            {
                // 0：パターン検索(メーカー未指定)/1：品番検索
                if (condWork.GoodsMakerCd == 0 && !string.IsNullOrEmpty(condWork.BarCodeData))
                {
                    mode = 0;
                }
                else
                {
                    mode = 1;
                }
                // パラメータチェック
                if (mode == 1)
                {
                    // 入力パラメータ「企業コード、コンピューター名、従業員コード、商品番号」は空がある場合、エラーを戻ります。
                    if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                        || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                        || string.IsNullOrEmpty(condWork.MachineName.Trim())
                        || string.IsNullOrEmpty(condWork.GoodsNo.Trim()))
                    {
                        // エラーメッセージに引数の名前と値をログ出力します。
                        this.WriteLog(condWork, ErrorMsgParam);
                        return status;
                    }
                }
                else
                {
                    // 入力パラメータ「企業コード、コンピューター名、従業員コード、パーコード情報」は空がある場合、エラーを戻ります。
                    if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                        || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                        || string.IsNullOrEmpty(condWork.MachineName.Trim())
                        || string.IsNullOrEmpty(condWork.BarCodeData.Trim()))
                    {
                        // エラーメッセージに引数の名前と値をログ出力します。
                        this.WriteLog(condWork, ErrorMsgParam);
                        return status;
                    }
                }
            }
            #endregion

            try
            {
                // メーカー
                goodsMakerCd = condWork.GoodsMakerCd;
                // 品番
                goodsNo = condWork.GoodsNo;

                // 0：品番検索(メーカー未指定)の場合
                if (mode == 0)
                {
                    #region 商品バーコード関連付けマスタ検索
                    // 商品バーコード関連付けマスタ検索
                    Object resultObj;
                    ArrayList handyGoodsBarCodeRevnResultWork = new ArrayList();
                    HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
                    status = handyMakerGoodsPtrnAcs.SearchGoodsBarCodeRevn(condWork.EnterpriseCode, condWork.BarCodeData, 0, out resultObj);
                    // 情報取得が正常に終了した場合
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        handyGoodsBarCodeRevnResultWork = resultObj as ArrayList;

                        ArrayList resultList = new ArrayList();

                        foreach (object workObj in handyGoodsBarCodeRevnResultWork)
                        {
                            GoodsBarCodeRevnWork work = (GoodsBarCodeRevnWork)workObj;

                            object resultWk = null;
                            // 品番検索
                            status = SearchGoodsNo(condObj, work.GoodsMakerCd, work.GoodsNo, mode, out resultWk);
                            if (status == StatusNomal)
                            {
                                foreach (HandyStockInsGoodsInfo info in (ArrayList)resultWk)
                                {
                                    resultList.Add(info);
                                }
                            }
                            else if (status != StatusNotFound)
                            {
                                return status;
                            }
                        }

                        if (resultList.Count <= 0)
                        {
                            return StatusNotFound;
                        }

                        retObj = resultList;

                        // メーカー品番パターン検索履歴の登録
                        status = WriteHisByInsert(condWork, 0, 0, string.Empty, 1, out makerGoodsSerchHisNo);
                        makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;

                        return status;
                    }
                    // 情報が見つからない場合
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        return StatusNotFound;
                    }
                    // 読込時のタイムアウト場合
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        return StatusTimeout;
                    }
                    // DB処理等でエラーが発生した場合
                    else
                    {
                        return StatusError;
                    }
                    #endregion
                }
                
                // 品番検索
                status = SearchGoodsNo(condObj, goodsMakerCd, goodsNo, mode, out retObj);
                if (status != StatusNomal)
                {
                    return status;
                }

                // メーカー品番パターン検索履歴の登録
                status = WriteHisByInsert(condWork, 0, goodsMakerCd, goodsNo, 1, out makerGoodsSerchHisNo);
                makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;

            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(condWork, ex.ToString());
                status = StatusError;
            }

            return status;
        }
        #endregion

        #region ■ 在庫登録
        /// <summary>
        /// 在庫登録
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫登録を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// <br>Update Note: 2021/06/21 呉元嘯</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-3268の対応</br> 
        /// </remarks>
        public int WriteHandyStock(object paraHandyStockInfoCondObj)
        {
            int status = StatusError;
            // 検索条件
            HandyGoodsUpdateCondWork condWork = paraHandyStockInfoCondObj as HandyGoodsUpdateCondWork;
            GoodsUnitData goodsUnitData = null;
            GoodsMngWork curMngWork = new GoodsMngWork();
            List<Stock> prevStockList = new List<Stock>();
            string msg = string.Empty;

            #region パラメータチェック
            // パラメータがnullの場合
            if (condWork == null)
            {
                // ログ出力します。
                this.WriteLogByUpdate(null, ErrorMsgNull);
                return status;
            }
            else
            {
                // パラメータチェック
                // 入力パラメータ「企業コード、コンピューター名、従業員コード、メーカーコード、商品番号、倉庫コード、入庫数、パターン検索履歴通番」は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(condWork.MachineName.Trim())
                    || condWork.GoodsMakerCd == 0
                    || string.IsNullOrEmpty(condWork.GoodsNo.Trim())
                    || condWork.StockCount == 0
                    || condWork.MakerGoodsSerchHisNo == 0)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLogByUpdate(condWork, ErrorMsgParam);
                    return status;
                }
            }
            #endregion

            WarehouseAcs warehouseAcs = new WarehouseAcs();
            Warehouse warehouseResult = null;

            try
            {
                // 倉庫情報取得
                status = warehouseAcs.Read(out warehouseResult, condWork.EnterpriseCode, string.Empty, condWork.WarehouseCode);
                if (warehouseResult == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.WriteLogByUpdate(condWork, ErrorWarehouseAcquisitionFailure);
                    status = StatusNotFound;
                    return status;
                }

                // 商品在庫検索
                status = SearchGoodsNo(condWork, out goodsUnitData);
                if (status != StatusNomal)
                {
                    return status;
                }

                if (goodsUnitData != null)
                {
                    // 更新用パラメータの作成
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        prevStockList.Add(stock.Clone());
                    }
                }

                // 更新用パラメータの作成
                bool isNewStock = true;
                if (goodsUnitData.StockList != null)
                {
                    foreach (Stock goodsStock in goodsUnitData.StockList)
                    {
                        if (!string.IsNullOrEmpty(condWork.WarehouseCode.Trim()) && condWork.WarehouseCode.Trim() == goodsStock.WarehouseCode.Trim())
                        {
                            isNewStock = false;
                        }
                    }
                }

                SetGoodsUnitData(ref goodsUnitData, condWork, ref curMngWork, warehouseResult);

                if (curMngWork.SupplierCd == 0) curMngWork = null;
                // 商品在庫更新呼出
                List<Rate> rateList = new List<Rate>();
                GoodsAcs handyGoodsAcs = new GoodsAcs();
                //-----UPD 2021/06/21 呉元嘯 PMKOBETSU-3268の対応----->>>>>
                //status = handyGoodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, curMngWork, out msg);
                status = handyGoodsAcs.WriteHandy(ref goodsUnitData, prevStockList, ref rateList, curMngWork, out msg, condWork.MachineName.Trim());
                //-----UPD 2021/06/21 呉元嘯 PMKOBETSU-3268の対応-----<<<<<
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 検索条件
                    HandyZaikoRegistMngWork mngWork = new HandyZaikoRegistMngWork();
                    // 企業コード
                    mngWork.EnterpriseCode = condWork.EnterpriseCode;
                    // 商品メーカー
                    mngWork.GoodsMakerCd = condWork.GoodsMakerCd;
                    // 品番
                    mngWork.GoodsNo = condWork.GoodsNo;
                    // 拠点
                    mngWork.SectionCode = warehouseResult.SectionCode;
                    // 拠点
                    mngWork.WarehouseCode = condWork.WarehouseCode;

                    if (isNewStock)
                    {
                        // ハンディ在庫登録管理データを登録
                        HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
                        status = handyMakerGoodsPtrnAcs.WriteMng(mngWork);
                    }

                    // メーカー品番パターン検索履歴データ更新
                    status = WriteHisByUpdate(condWork, condWork.GoodsNo, 1, 0);  

                }
                else
                {
                    // メーカー品番パターン検索履歴データ更新
                    status = WriteHisByUpdate(condWork, condWork.GoodsNo, -1, 0);
                }

            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLogByUpdate(condWork, ex.ToString());
                status = StatusError;
            }

            return status;
        }

        /// <summary>
        /// メーカー品番パターン検索履歴の登録
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="entryGoodsNo">確定番号</param>
        /// <param name="entryStatus">登録ステータス</param>
        /// <param name="uOEOrderTdlKind">UOE発注データ区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターン検索履歴の登録を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int WriteHisByUpdate(HandyGoodsUpdateCondWork condWork, string entryGoodsNo, int entryStatus, int uOEOrderTdlKind)
        {
            // 検索条件
            HandyMakerGoodsPtrnHisResultWork searchHisWork = new HandyMakerGoodsPtrnHisResultWork();
            // 企業コード
            searchHisWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // パターン検索履歴通番
            searchHisWork.MakerGoodsSerchHisNo = condWork.MakerGoodsSerchHisNo;
            // 実行日付
            searchHisWork.SearchDate = GetLongDate(DateTime.Today);
            // 確定品番
            searchHisWork.EntryGoodsNo = entryGoodsNo;
            // 登録ステータス
            searchHisWork.EntryStatus = entryStatus;
            // UOE発注データ区分
            searchHisWork.UOEOrderTdlKind = uOEOrderTdlKind;

            searchHisWork.SearchGoodsNo = condWork.GoodsNo;

            searchHisWork.GoodsMakerCd = condWork.GoodsMakerCd;

            // メーカー品番パターン検索履歴登録
            HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            int status = handyMakerGoodsPtrnAcs.WriteHis(ref searchHisWork, 1, 1);

            // 情報取得が正常に終了した場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = StatusNomal;
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
            return status;
        }

        /// <summary>
        /// 在庫登録用品番検索
        /// </summary>
        /// <param name="condWork">検索条件オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫登録用品番検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int SearchGoodsNo(HandyGoodsUpdateCondWork condWork, out GoodsUnitData goodsUnitData)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            string msg = string.Empty;
            goodsUnitData = null;

            // 品番検索条件
            GoodsCndtn cndtn = new GoodsCndtn();
            // 企業コード
            cndtn.EnterpriseCode = condWork.EnterpriseCode;
            // 商品メーカー
            cndtn.GoodsMakerCd = condWork.GoodsMakerCd;
            // 品番
            cndtn.GoodsNo = condWork.GoodsNo;
            // 拠点
            cndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 価格開始日
            cndtn.PriceApplyDate = DateTime.Today;
            // 論理削除区分
            cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;

            // 品番検索(結合検索無し、同一品番表示なし)
            GoodsAcs handyGoodsAcs = new GoodsAcs();
            int status = handyGoodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg);
            if (goodsUnitDataList.Count > 0) goodsUnitData = goodsUnitDataList[0];
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                GoodsUnitData wkGoodsUnitData;
                List<Rate> wkRateList;
                int wkStatus = handyGoodsAcs.ReadGoodsWithRate(condWork.EnterpriseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, ConstantManagement.LogicalMode.GetData01, out wkGoodsUnitData, out wkRateList);
                if (wkStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    goodsUnitData = wkGoodsUnitData;
                    status = StatusNomal;
                }
            }
            else
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
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
            }

            return status;
        }

        /// <summary>
        /// 更新用パラメータの作成
        /// </summary>
        /// <param name="data">商品連結データ</param>
        /// <param name="condWork">検索条件</param>
        /// <param name="curMngWork">商品管理情報マスタ</param>
        /// <param name="warehouseWork">倉庫情報</param>
        /// <remarks>
        /// <br>Note       : 更新用パラメータの作成を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SetGoodsUnitData(ref GoodsUnitData data, HandyGoodsUpdateCondWork condWork, ref GoodsMngWork curMngWork, Warehouse warehouseWork)
        {

            // 提供分新規データについて、新規として商品在庫を作成
            if (data.OfferKubun != 0 && data.LogicalDeleteCode == 0)
            {
                // 商品連結データ
                // 商品属性
                //data.GoodsKindCode = condWork.GoodsKindCode;  // 商品検索で取得した値を使用（設定画面の初期値0：純正で提供優良品を新規在庫登録した場合、商品属性が0：純正で登録されてしまう）
                
                // 課税区分
                //data.TaxationDivCd = condWork.TaxationDivCd;  // 商品検索で取得した値を使用

                // 在庫情報パラメータの作成
                Stock wkStock = new Stock();

                CreateNewStock(ref wkStock, condWork, warehouseWork);

                data.StockList.Add(wkStock);

                // 商品管理情報マスタパラメータの作成
                if (condWork.SupplierCd != 0)
                {
                    //「全社共通+メーカー＋品番」を新規登録する

                    CreateNewGoodsMng(ref curMngWork, condWork, warehouseWork);

                }
            }
            // 既に存在のユーザー在庫品：在庫数を更新 ※商品管理情報を作成不要
            else
            {
                // 商品連結データ
                // 商品属性
                // data.GoodsKindCode = condWork.GoodsKindCode;  // 商品検索で取得した値を使用
                // 課税区分
                // data.TaxationDivCd = condWork.TaxationDivCd;  // 商品検索で取得した値を使用

                // 復活する
                if (data.LogicalDeleteCode == 1)
                {
                    data.LogicalDeleteCode = 0;
                }

                // 在庫情報
                bool isAtStock = false;
                foreach (Stock stock in data.StockList)
                {
                    if (stock.WarehouseCode.Trim() == condWork.WarehouseCode.Trim())
                    {
                        // 在庫あり
                        if (stock.LogicalDeleteCode == 0)
                        {
                            // 仕入在庫数に引数.入庫数を加算する
                            stock.SupplierStock = stock.SupplierStock + condWork.StockCount;
                            // 在庫区分
                            stock.StockDiv = condWork.StockDiv;
                            // 倉庫棚番
                            stock.WarehouseShelfNo = condWork.WarehouseShelfNo;
                        }
                        // 在庫論理削除の商品⇒新規在庫として作成
                        else if (stock.LogicalDeleteCode == 1)
                        {
                            Stock wkStock = stock.Clone();

                            CreateNewStock(ref wkStock, condWork, warehouseWork);

                            data.StockList.Remove(stock);
                            data.StockList.Add(wkStock);
                        }
                        isAtStock = true;
                        break;
                    }
                }
                // 在庫なし⇒新規在庫として作成
                if (isAtStock == false)
                {
                    Stock wkStock = new Stock();

                    CreateNewStock(ref wkStock, condWork, warehouseWork);

                    data.StockList.Add(wkStock);
                }
            }
        }

        /// <summary>
        /// 新規商品在庫情報作成
        /// </summary>
        /// <param name="curMngWork">商品在庫情報</param>
        /// <param name="condWork">検索条件</param>
        /// <param name="warehouseWork">倉庫情報</param>
        /// <remarks>
        /// <br>Note       : 新規商品在庫情報作成を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CreateNewGoodsMng(ref GoodsMngWork curMngWork, HandyGoodsUpdateCondWork condWork, Warehouse warehouseWork)
        {
            curMngWork = new GoodsMngWork();
            curMngWork.EnterpriseCode = condWork.EnterpriseCode;
            curMngWork.LogicalDeleteCode = 0;

            curMngWork.SectionCode = "00";

            curMngWork.GoodsMGroup = 0;
            curMngWork.GoodsMakerCd = condWork.GoodsMakerCd;
            curMngWork.BLGoodsCode = 0;
            curMngWork.GoodsNo = string.Empty;
            curMngWork.SupplierCd = condWork.SupplierCd;
            curMngWork.SupplierLot = 0;
        }

        /// <summary>
        /// 新規在庫情報作成
        /// </summary>
        /// <param name="stock">在庫情報</param>
        /// <param name="condWork">検索条件</param>
        /// <param name="warehouseWork">倉庫情報</param>
        /// <remarks>
        /// <br>Note       : 新規在庫情報作成を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CreateNewStock(ref Stock stock, HandyGoodsUpdateCondWork condWork, Warehouse warehouseWork)
        {
            stock.EnterpriseCode = condWork.EnterpriseCode;
            stock.LogicalDeleteCode = 0;

            stock.SectionCode = warehouseWork.SectionCode;

            stock.WarehouseCode = condWork.WarehouseCode;
            // --- ADD 2020/04/22 ---------->>>>>
            stock.WarehouseName = condWork.WarehouseName;
            stock.PartsManagementDivide1 = "0";
            stock.PartsManagementDivide2 = "0";
            // --- ADD 2020/04/22 ----------<<<<<
            stock.GoodsMakerCd = condWork.GoodsMakerCd;
            stock.GoodsNo = condWork.GoodsNo;
            stock.StockUnitPriceFl = 0;
            stock.SupplierStock = condWork.StockCount;
            stock.AcpOdrCount = 0;
            stock.MonthOrderCount = 0;
            stock.SalesOrderCount = 0;
            stock.StockDiv = condWork.StockDiv;
            stock.MovingSupliStock = 0;
            stock.ShipmentPosCnt = 0;
            stock.StockTotalPrice = 0;
            stock.LastStockDate = DateTime.MinValue;
            stock.LastSalesDate = DateTime.MinValue;
            stock.LastInventoryUpdate = DateTime.MinValue;
            stock.MinimumStockCnt = 0;
            stock.MaximumStockCnt = 0;
            stock.NmlSalOdrCount = 0;
            stock.SalesOrderUnit = 0;
            stock.StockSupplierCode = 0;
            stock.GoodsNoNoneHyphen = condWork.GoodsNo.Replace("-", "");
            stock.WarehouseShelfNo = condWork.WarehouseShelfNo;
            stock.DuplicationShelfNo1 = string.Empty;
            stock.DuplicationShelfNo2 = string.Empty;
            stock.StockNote1 = string.Empty;
            stock.StockNote2 = string.Empty;
            stock.ShipmentCnt = 0;
            stock.ArrivalCnt = 0;
            stock.StockCreateDate = DateTime.Today;
            stock.UpdateDate = DateTime.Today;
        }

        #endregion

        #region ■ UOE発注データ検索
        /// <summary>
        /// UOE発注データ検索
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="count">検索件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー未指定の場合、品番検索を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyUOEOrder(object condObj, out object count)
        {
            int status = StatusError;
            count = null;
            int countR = 0;
            // 検索条件
            HandyGoodsUpdateCondWork condWork = condObj as HandyGoodsUpdateCondWork;

            #region パラメータチェック
            // パラメータがnullの場合、
            if (condWork == null)
            {
                // ログ出力します。
                this.WriteLogByUpdate(null, ErrorMsgNull);
                return status;
            }
            else
            {
                // パラメータチェック
                // 入力パラメータ「企業コード、コンピューター名、従業員コード、メーカーコード、商品番号、パターン検索履歴通番」は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(condWork.MachineName.Trim())
                    || condWork.GoodsMakerCd == 0
                    || string.IsNullOrEmpty(condWork.GoodsNo.Trim())
                    || condWork.MakerGoodsSerchHisNo == 0)

                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLogByUpdate(condWork, ErrorMsgParam);
                    return status;
                }
            }
            #endregion

            try
            {
                // UOE発注データ検索
                HandyMakerGoodsPtrnAcs HandyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
                status = HandyMakerGoodsPtrnAcs.SearchHandyUOEOrder(ref condObj, out countR);
                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    count = (object)countR;
                    // メーカー品番パターン検索履歴データ更新
                    // --- UPD 2020/04/28 M.KISHI ---------->>>>>
                    //status = WriteHisByUpdate(condWork, string.Empty, 0, 1);
                    int paraKind = 0;
                    if (countR > 0)
                    {
                        paraKind = 1;
                    }
                    status = WriteHisByUpdate(condWork, string.Empty, 0, paraKind);
                    // --- UPD 2020/04/28 M.KISHI ----------<<<<<

                }
                // 読込時のタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    return StatusTimeout;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    return StatusError;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLogByUpdate(condWork, ex.ToString());
                status = StatusError;
            }

            return status;

        }
        #endregion

        #region ■ エラーログ出力処理
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="condWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void WriteLog(HandyGoodsSearchCondWork condWork, string errMsg)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            try
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), PathLog);

                lock (LogLockObj)
                {
                    // フォルダが存在しない場合、
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                    writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                    DateTime writingDateTime = DateTime.Now;
                    writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                    // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                    if (condWork != null)
                    {
                        // 企業コード
                        writer.WriteLine(EnterpriseCode + condWork.EnterpriseCode);
                        // コンピューター名
                        writer.WriteLine(EmployeeCode + condWork.MachineName);
                        // 従業員コード
                        writer.WriteLine(MachineName + condWork.EmployeeCode);
                        // メーカーコード
                        writer.WriteLine(GoodsMakerCd + condWork.GoodsMakerCd);
                        // 商品番号
                        writer.WriteLine(GoodsNo + condWork.GoodsNo);
                        // パーコード情報
                        writer.WriteLine(BarCodeData + condWork.BarCodeData);
                    }
                }
            }
            catch
            {
                // 処理なし
            }
            finally
            {   
                // ファイルストリームがnullではない場合
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }

        }

        /// <summary>
        /// エラーログ出力処理（在庫更新用）
        /// </summary>
        /// <param name="condWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void WriteLogByUpdate(HandyGoodsUpdateCondWork condWork, string errMsg)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            try
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), PathLog);

                lock (LogLockObj)
                {
                    // フォルダが存在しない場合、
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                    writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                    DateTime writingDateTime = DateTime.Now;
                    writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                    // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                    if (condWork != null)
                    {
                        // 企業コード
                        writer.WriteLine(EnterpriseCode + condWork.EnterpriseCode);
                        // コンピューター名
                        writer.WriteLine(EmployeeCode + condWork.MachineName);
                        // 従業員コード
                        writer.WriteLine(MachineName + condWork.EmployeeCode);
                        // メーカーコード
                        writer.WriteLine(GoodsMakerCd + condWork.GoodsMakerCd);
                        // 商品番号
                        writer.WriteLine(GoodsNo + condWork.GoodsNo);
                        // 倉庫コード
                        writer.WriteLine(WarehouseCode + condWork.WarehouseCode);
                        // 倉庫棚番
                        writer.WriteLine(WarehouseShelfNo + condWork.WarehouseShelfNo);
                        // 仕入先
                        writer.WriteLine(SupplierCd + condWork.SupplierCd);
                        // 入庫数
                        writer.WriteLine(StockCount + condWork.StockCount);
                        // 商品属性
                        writer.WriteLine(GoodsKindCode + condWork.GoodsKindCode);
                        // 課税区分
                        writer.WriteLine(TaxationDivCd + condWork.TaxationDivCd);
                        // 在庫区分
                        writer.WriteLine(StockDiv + condWork.StockDiv);
                        // パターン検索履歴通番
                        writer.WriteLine(MakerGoodsSerchHisNo + condWork.MakerGoodsSerchHisNo);
                    }
                }
            }
            catch
            {
                // 処理なし
            }
            finally
            {
                // ファイルストリームがnullではない場合
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

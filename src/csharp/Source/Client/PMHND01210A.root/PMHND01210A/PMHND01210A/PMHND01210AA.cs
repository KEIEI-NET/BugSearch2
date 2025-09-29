//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫移動アクセスクラス
// プログラム概要   : ハンディターミナル在庫移動アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : 新規作成
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
using Broadleaf.Application.UIData;
using System.Collections.Generic;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル在庫移動アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫移動アクセスクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// </remarks>
    public class HandyStockMoveAcs
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
        /// <summary>伝票が検品対象外の場合</summary>
        private const int StatusNonTarget = 6;
        /// <summary>検品ステータス「3:検品済み」</summary>
        private const int InspectStatusInspected = 3;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND01210A_";
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
        /// <summary>在庫移動伝票番号</summary>
        private const string StockMoveSlipNo = "在庫移動伝票番号:";
        /// <summary>在庫移動伝票番号</summary>
        private const string StockMoveSlipNumNo = "在庫移動行番号:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>倉庫棚番</summary>
        private const string WarehouseShelfNo = "棚番:";
        /// <summary>検品区分</summary>
        private const string InspectCode = "検品区分:";
        /// <summary>検品数</summary>
        private const string InspectCnt = "検品数:";
        /// <summary>検品ステータス</summary>
        private const string InspectStatus = "検品ステータス:";
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgNull = "検索条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgParam = "入力パラメータエラーが発生しました。";
        /// <summary>在庫管理全体設定マスタ読込エラーメッセージ</summary>
        private const string StockMngTtlErrorMsg = "在庫管理全体設定マスタの取得が失敗しました。";
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
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public HandyStockMoveAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ハンディターミナル在庫移動伝票情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫移動伝票情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStockMoveData(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // 検索条件
            HandyStockMoveCondWork stockMoveCondWork = condObj as HandyStockMoveCondWork;

            // パラメータがnullの場合、
            if (stockMoveCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(stockMoveCondWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 入力パラメータ企業コード、従業員コード、コンピュータ名、伝票番号は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(stockMoveCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(stockMoveCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(stockMoveCondWork.MachineName.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(stockMoveCondWork, ErrorMsgParam);
                    return status;
                }
                // 処理区分が「15,16」以外の場合、ST_ERR(-1)を返却します。
                if (stockMoveCondWork.ProcDiv != 15 && stockMoveCondWork.ProcDiv != 16)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(stockMoveCondWork, ErrorMsgParam);
                    return status;
                }
            }
            try
            {
                // 在庫管理全体設定マスタ読込
                StockMngTtlSt RetWork = new StockMngTtlSt();
                StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                status = stockMngTtlStAcs.Read(out RetWork, stockMoveCondWork.EnterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 在庫移動確定区分取得
                    stockMoveCondWork.StockMoveFixCode = RetWork.StockMoveFixCode;
                }
                else
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(stockMoveCondWork, StockMngTtlErrorMsg);
                    return status;
                }

                #region 在庫移動伝票情報取得
                byte[] condByte = XmlByteSerializer.Serialize(stockMoveCondWork);
                IHandyStockMoveDB iStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
                // 在庫移動伝票情報取得を行います
                status = iStockMoveDBObj.Search(condByte, out retObj);

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    bool beenInspected = true;

                    foreach (HandyStockMoveWork retWork in retObj as ArrayList)
                    {
                        // 引数.処理区分が「16：在庫移動入荷検品」の場合､在庫移動確定区分が「1：確定あり」の場合
                        if (stockMoveCondWork.ProcDiv == 16 && stockMoveCondWork.StockMoveFixCode == 1)
                        {
                            // 検品ステータスが「3:検品済み」ではない場合&&移動状態ｶﾞ｢9：入荷済み｣ではない場合
                            if (retWork.InspectStatus != InspectStatusInspected && retWork.MoveStatus != 9)
                            {
                                // 検品対象とする
                                beenInspected = false;
                                break;
                            }
                        }
                        else
                        {
                            // 検品ステータスが「3:検品済み」ではない場合
                            if (retWork.InspectStatus != InspectStatusInspected)
                            {
                                // 検品対象とする
                                beenInspected = false;
                                break;
                            }
                        }
                    }
                    // 検品ステータス全部が「3:検品済み」の場合
                    if (beenInspected)
                    {
                        // 検品対象外とし、検品対象データを返却しません。
                        status = StatusNonTarget;
                    }
                    // 検品ステータスが「3:検品済み」以外のデータがある場合
                    else
                    {
                        status = StatusNomal;
                    }
                }
                // 在庫移動伝票情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // 読込時にタイムアウトが発生した場合
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
                this.WriteLog(stockMoveCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 処理なし。
            }

            return status;
        }

        # region [在庫移動（出荷・入荷）検品データ登録]
        /// <summary>
        /// 在庫移動（出荷・入荷）検品データ登録処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫移動（出荷・入荷）検品データ登録を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteStockMoveInspect(object inspectDataObj)
        {
            int status = StatusError;
            ArrayList inspectDataList = new ArrayList();
            ArrayList stockMoveList = new ArrayList();
            StockMoveWork stockWork = null;
            StockMoveSlipSearchCondWork stockMoveSlipSearchWork = null;
            int stockMoveFixCode = 0;
            int moveStockAutoInsDiv = 0;
            int procDiv = 0;
            bool firstFlg = true;
            bool searchFirstFlg = true;
            object reqObj = null;
            object resObj = null;
            bool stockMoveFixFlg = true;
            // パラメータがnullの場合、
            if (inspectDataObj == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }

            ArrayList inspectDataWorkList = inspectDataObj as ArrayList;
            IHandyStockMoveDB iHandyStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
            foreach (HandyInspectDataWork inspectDataWork in inspectDataWorkList)
            {
                // 必須入力項目のチェック
                if (String.IsNullOrEmpty(inspectDataWork.MachineName.Trim()) ||            // コンピュータ名
                    String.IsNullOrEmpty(inspectDataWork.EmployeeCode.Trim()) ||           // 従業員コード
                    String.IsNullOrEmpty(inspectDataWork.WarehouseCode.Trim()) ||           // 倉庫コード
                    String.IsNullOrEmpty(inspectDataWork.AcPaySlipNum.Trim()) ||           // 伝票番号
                    (inspectDataWork.AcPaySlipRowNo <= 0) ||           // 行番号
                    (inspectDataWork.GoodsMakerCd <= 0) ||           // メーカーコード
                    String.IsNullOrEmpty(inspectDataWork.GoodsNo.Trim()))                  // 商品番号
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }

                // 桁のチェック
                if (inspectDataWork.GoodsMakerCd > 999999 ||
                    inspectDataWork.GoodsNo.Length > 40 ||
                    inspectDataWork.WarehouseCode.Length > 6 ||
                    inspectDataWork.InspectCode > 99 ||
                    inspectDataWork.AcPaySlipNum.Length > 9 ||
                    inspectDataWork.AcPaySlipRowNo > 9999 ||
                    inspectDataWork.InspectStatus > 99 ||
                    inspectDataWork.InspectCnt > 99999999.99 ||
                    inspectDataWork.MachineName.Length > 20 ||
                    inspectDataWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }

                if (inspectDataWork.ProcDiv != 15 && inspectDataWork.ProcDiv != 16)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }

                // 受払元取引区分(10：通常)
                inspectDataWork.AcPayTransCd = 10;

                // ハンディターミナル区分:固定値(1:ハンディターミナル)
                inspectDataWork.HandTerminalCode = 1;

                // 処理区分が「15」の場合：30：移動出荷 
                if (inspectDataWork.ProcDiv == 15)
                {
                    inspectDataWork.AcPaySlipCd = 30;

                }
                else
                {
                    // 処理区分が「16」の場合：31：移動入荷
                    inspectDataWork.AcPaySlipCd = 31;
                }
                procDiv = inspectDataWork.ProcDiv;
                if (firstFlg)
                {
                    // 在庫管理全体設定マスタ読込
                    StockMngTtlSt retWork = new StockMngTtlSt();
                    StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                    status = stockMngTtlStAcs.Read(out retWork, inspectDataWork.EnterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 在庫移動確定区分取得
                        stockMoveFixCode = retWork.StockMoveFixCode;
                        moveStockAutoInsDiv = retWork.MoveStockAutoInsDiv;
                        firstFlg = false;
                    }
                    else
                    {
                        // エラーメッセージに引数の名前と値をログ出力します。
                        this.WriteLog(inspectDataWork, StockMngTtlErrorMsg);
                        return status;
                    }
                }

                inspectDataWork.StockMoveFixCode = stockMoveFixCode;

                // 検品データリストにセットする
                inspectDataList.Add(inspectDataWork);

                // 在庫移動確定区分が「1：入荷確定有り」の場合、処理区分が「16：移動入荷」の場合は入荷確定処理を行います。
                if (inspectDataWork.StockMoveFixCode == 1 && inspectDataWork.ProcDiv == 16)
                {
                    // 検品済み以外の明細が有る場合は入荷確定フラグをFalseにし、常に入荷確定しないとします。
                    if (inspectDataWork.InspectStatus != InspectStatusInspected)
                    {
                        stockMoveFixFlg = false;
                        stockMoveList.Clear();
                    }
                    if (stockMoveFixFlg)
                    {
                        if (searchFirstFlg)
                        {
                            // 検索条件ワーククラス
                            stockMoveSlipSearchWork = new StockMoveSlipSearchCondWork();
                            // 企業コード
                            stockMoveSlipSearchWork.EnterpriseCode = inspectDataWork.EnterpriseCode;
                            // 在庫移動伝票番号
                            stockMoveSlipSearchWork.StockMoveSlipNo = Convert.ToInt32(inspectDataWork.AcPaySlipNum.Trim());
                            // 移動状態(2：処理中)固定で検索
                            int[] moveStatus = { 2 };
                            stockMoveSlipSearchWork.MoveStatus = moveStatus;
                            // 在庫移動確定区分
                            stockMoveSlipSearchWork.StockMoveFixCode = inspectDataWork.StockMoveFixCode;
                            // 「1：出庫伝票」固定で出荷分検索
                            stockMoveSlipSearchWork.SlipDiv = 1;
                            // 検索条件を格納
                            reqObj = stockMoveSlipSearchWork as object;

                            // 在庫移動伝票情報を取得する
                            status = iHandyStockMoveDBObj.SearchStockMove(reqObj, out resObj);
                            searchFirstFlg = false;
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (StockMoveWork stMoveWork in resObj as ArrayList)
                            {
                                // 在庫移動伝票番号+在庫移動伝票行番号でヒットする
                                if (stMoveWork.StockMoveSlipNo == Convert.ToInt32(inspectDataWork.AcPaySlipNum.Trim()) &&
                                    stMoveWork.StockMoveRowNo == inspectDataWork.AcPaySlipRowNo)
                                {
                                    #region 出荷分在庫移動更新データリスト作成
                                    stockWork = new StockMoveWork();

                                    stockWork.AfEnterWarehCode = stMoveWork.AfEnterWarehCode;
                                    stockWork.AfEnterWarehName = stMoveWork.AfEnterWarehName;
                                    stockWork.AfSectionCode = stMoveWork.AfSectionCode;
                                    stockWork.AfSectionGuideSnm = stMoveWork.AfSectionGuideSnm;
                                    stockWork.AfShelfNo = stMoveWork.AfShelfNo;
                                    // 入荷日(システム日付)
                                    stockWork.ArrivalGoodsDay = DateTime.Now;
                                    stockWork.AutoGoodsInsDiv = stMoveWork.AutoGoodsInsDiv;
                                    stockWork.BfEnterWarehCode = stMoveWork.BfEnterWarehCode;
                                    stockWork.BfEnterWarehName = stMoveWork.BfEnterWarehName;
                                    stockWork.BfSectionCode = stMoveWork.BfSectionCode;
                                    stockWork.BfSectionGuideSnm = stMoveWork.BfSectionGuideSnm;
                                    stockWork.BfShelfNo = stMoveWork.BfShelfNo;
                                    stockWork.BLGoodsCode = stMoveWork.BLGoodsCode;
                                    stockWork.BLGoodsFullName = stMoveWork.BLGoodsFullName;
                                    stockWork.CreateDateTime = stMoveWork.CreateDateTime;
                                    stockWork.EnterpriseCode = inspectDataWork.EnterpriseCode;
                                    stockWork.FileHeaderGuid = stMoveWork.FileHeaderGuid;
                                    stockWork.GoodsMakerCd = stMoveWork.GoodsMakerCd;
                                    stockWork.GoodsName = stMoveWork.GoodsName;
                                    stockWork.GoodsNameKana = stMoveWork.GoodsNameKana;
                                    stockWork.GoodsNo = stMoveWork.GoodsNo;
                                    // 入力日(システム日付)
                                    stockWork.InputDay = DateTime.Now;
                                    stockWork.ListPriceFl = stMoveWork.ListPriceFl;
                                    stockWork.LogicalDeleteCode = 0;
                                    stockWork.MakerName = stMoveWork.MakerName;
                                    stockWork.MoveCount = stMoveWork.MoveCount;
                                    // 移動状態(9：入荷済み)
                                    stockWork.MoveStatus = 9;
                                    stockWork.Outline = stMoveWork.Outline;
                                    stockWork.ReceiveAgentCd = stMoveWork.ReceiveAgentCd;
                                    stockWork.ReceiveAgentNm = stMoveWork.ReceiveAgentNm;
                                    stockWork.ShipAgentCd = stMoveWork.ShipAgentCd;
                                    stockWork.ShipAgentNm = stMoveWork.ShipAgentNm;
                                    stockWork.StockDiv = stMoveWork.StockDiv;
                                    stockWork.StockMoveFixCode = inspectDataWork.StockMoveFixCode;
                                    stockWork.StockMoveFormal = stMoveWork.StockMoveFormal;
                                    stockWork.StockMovePrice = stMoveWork.StockMovePrice;
                                    stockWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                    stockWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                    stockWork.StockMvEmpCode = stMoveWork.StockMvEmpCode;
                                    stockWork.StockMvEmpName = stMoveWork.StockMvEmpName;
                                    stockWork.StockUnitPriceFl = stMoveWork.StockUnitPriceFl;
                                    stockWork.SupplierCd = stMoveWork.SupplierCd;
                                    stockWork.SupplierSnm = stMoveWork.SupplierSnm;
                                    stockWork.TaxationDivCd = stMoveWork.TaxationDivCd;
                                    stockWork.UpdAssemblyId1 = stMoveWork.UpdAssemblyId1;
                                    stockWork.UpdAssemblyId2 = stMoveWork.UpdAssemblyId2;
                                    stockWork.UpdateDateTime = stMoveWork.UpdateDateTime;
                                    // 更新拠点コード(引数．従業員コードの所属拠点コード)
                                    stockWork.UpdateSecCd = inspectDataWork.BelongSectionCode;
                                    // 更新従業員コード(引数．従業員コード)
                                    stockWork.UpdEmployeeCode = inspectDataWork.EmployeeCode;
                                    stockWork.WarehouseNote1 = stMoveWork.WarehouseNote1;
                                    stockWork.SlipPrintFinishCd = stMoveWork.SlipPrintFinishCd;
                                    stockWork.MoveStockAutoInsDiv = moveStockAutoInsDiv;
                                    stockWork.ShipmentScdlDay = stMoveWork.ShipmentScdlDay;
                                    stockWork.ShipmentFixDay = stMoveWork.ShipmentFixDay;

                                    stockMoveList.Add(stockWork);
                                    #endregion
                                }
                            }
                        }
                    }
                }
            }
            try
            {
                // 在庫移動確定区分が「1：入荷確定有り」、処理区分が「16：移動入荷」、全明細が検品済みの場合は入荷確定処理を行います。
                if (stockMoveFixCode == 1 && procDiv == 16 && stockMoveFixFlg)
                {
                    // カスタムシリアライズアレイリスト生成
                    CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

                    // 商品連結データワーククラスリスト作成
                    ArrayList saveGoodsUnitDataWorkList = CreateSaveGoodsUnitDataWorkListArrival(stockMoveList);

                    // カスタムシリアライズアレイリストに在庫移動データを格納
                    customSerializeArrayList.Add(stockMoveList);
                    // カスタムシリアライズアレイリストに商品連結データを追加
                    if (saveGoodsUnitDataWorkList.Count != 0)
                    {
                        customSerializeArrayList.Add(saveGoodsUnitDataWorkList);
                    }
                    // カスタムシリアライズアレイリストに検品データを格納
                    customSerializeArrayList.Add(inspectDataList);
                    // リモーティング引渡オブジェクト
                    object obj = customSerializeArrayList;
                    string msg;

                    IStockMoveDB iStockMoveDB = (IStockMoveDB)MediationStockMoveDB.GetStockMoveDB();
                    // 在庫移動伝票登録処理(入荷処理と検品登録)
                    status = iStockMoveDB.Write(ref obj, out msg);
                }
                // 常に入荷処理を行わない為、検品データ登録処理のみを行います
                else
                {
                    inspectDataObj = inspectDataList as object;
                    status = iHandyStockMoveDBObj.Write(ref inspectDataObj, 0);
                }

                // 登録が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
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
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(null, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 何もしない
            }

            return status;
        }
        # endregion
        # endregion

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="logObj">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private void WriteLog(object logObj, string errMsg)
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
                if (logObj is HandyStockMoveCondWork)
                {
                    HandyStockMoveCondWork handyStockCondWork = logObj as HandyStockMoveCondWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyStockCondWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyStockCondWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyStockCondWork.MachineName);
                    // 処理区分
                    writer.WriteLine(ProcDiv + handyStockCondWork.ProcDiv);
                    // 伝票番号
                    writer.WriteLine(StockMoveSlipNo + handyStockCondWork.StockMoveSlipNo);
                }
                // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                else if (logObj is HandyInspectDataWork)
                {
                    HandyInspectDataWork handyInspectDataWork = logObj as HandyInspectDataWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyInspectDataWork.EnterpriseCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyInspectDataWork.MachineName);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyInspectDataWork.EmployeeCode);
                    // 処理区分
                    writer.WriteLine(ProcDiv + handyInspectDataWork.ProcDiv);
                    // 在庫移動伝票番号
                    writer.WriteLine(StockMoveSlipNo + handyInspectDataWork.AcPaySlipNum);
                    // 在庫移動行番号
                    writer.WriteLine(StockMoveSlipNumNo + handyInspectDataWork.AcPaySlipRowNo);
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + handyInspectDataWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + handyInspectDataWork.GoodsNo);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + handyInspectDataWork.WarehouseCode);
                    // 検品区分
                    writer.WriteLine(InspectCode + handyInspectDataWork.InspectCode);
                    // 検品数
                    writer.WriteLine(InspectCnt + handyInspectDataWork.InspectCnt);
                    // 検品ステータス
                    writer.WriteLine(InspectStatus + handyInspectDataWork.InspectStatus);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }

        /// <summary>
        /// 商品データリスト作成処理
        /// </summary>
        /// <param name="stockMoveList">在庫移動データリスト</param>
        /// <returns>商品データリスト</returns>
        /// <remarks>
        /// <br>Note　　　  : 商品データリストを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private ArrayList CreateSaveGoodsUnitDataWorkListArrival(ArrayList stockMoveList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string errMsg;
            ArrayList saveGoodsUnitDataWorkList = new ArrayList();

            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsUnitDataWork goodsUnitDataWork;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string,GoodsUnitData>();

            foreach (StockMoveWork stockMoveWork in stockMoveList)
            {
                goodsUnitDataList = new List<GoodsUnitData>();

                if (goodsUnitDataDic.ContainsKey(stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()) == true)
                {
                    goodsUnitDataList.Add((GoodsUnitData)goodsUnitDataDic[stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()]);
                }
                else
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = stockMoveWork.EnterpriseCode;
                    goodsCndtn.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
                    goodsCndtn.GoodsNo = stockMoveWork.GoodsNo;

                    status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    {
                        goodsUnitDataDic.Add(stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim(), goodsUnitDataList[0]);
                    }
                }

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    if (goodsUnitData.OfferKubun != -1)
                    {
                        // 商品データがユーザー・提供のどちらかに存在する場合
                        if (goodsUnitDataList[0].OfferKubun != 0)
                        {
                            // 提供データの場合
                            goodsUnitDataWork = CopyToGoodsUnitDataWorkFromGoodsUnitData(goodsUnitDataList[0]);
                            UpdateGoodsUnitDataWork(ref goodsUnitDataWork, stockMoveWork);
                            saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                        }
                    }
                }
                else
                {
                    // 商品データがユーザー・提供両方に存在しない場合
                    goodsUnitDataWork = CreateGoodsUnitDataWork(stockMoveWork);
                    saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                }
            }

            return saveGoodsUnitDataWorkList;
        }

        /// <summary>
        /// クラスメンバコピー処理(商品連結データ→商品連結データワーク)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>商品連結データワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　  : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

            goodsUnitDataWork.CreateDateTime = goodsUnitData.CreateDateTime;
            goodsUnitDataWork.UpdateDateTime = goodsUnitData.UpdateDateTime;
            goodsUnitDataWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            goodsUnitDataWork.FileHeaderGuid = goodsUnitData.FileHeaderGuid;
            goodsUnitDataWork.UpdEmployeeCode = goodsUnitData.UpdEmployeeCode;
            goodsUnitDataWork.UpdAssemblyId1 = goodsUnitData.UpdAssemblyId1;
            goodsUnitDataWork.UpdAssemblyId2 = goodsUnitData.UpdAssemblyId2;
            goodsUnitDataWork.LogicalDeleteCode = goodsUnitData.LogicalDeleteCode;
            goodsUnitDataWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
            goodsUnitDataWork.GoodsNo = goodsUnitData.GoodsNo;
            goodsUnitDataWork.GoodsName = goodsUnitData.GoodsName;
            goodsUnitDataWork.GoodsNameKana = goodsUnitData.GoodsNameKana;
            goodsUnitDataWork.Jan = goodsUnitData.Jan;
            goodsUnitDataWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
            goodsUnitDataWork.DisplayOrder = goodsUnitData.DisplayOrder;
            goodsUnitDataWork.GoodsRateRank = goodsUnitData.GoodsRateRank;
            goodsUnitDataWork.TaxationDivCd = goodsUnitData.TaxationDivCd;
            goodsUnitDataWork.GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen;
            goodsUnitDataWork.OfferDate = goodsUnitData.OfferDate;
            goodsUnitDataWork.GoodsKindCode = goodsUnitData.GoodsKindCode;
            goodsUnitDataWork.GoodsNote1 = goodsUnitData.GoodsNote1;
            goodsUnitDataWork.GoodsNote2 = goodsUnitData.GoodsNote2;
            goodsUnitDataWork.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
            goodsUnitDataWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;
            goodsUnitDataWork.UpdateDate = goodsUnitData.UpdateDate;
            ArrayList priceWorkList = new ArrayList();
            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
            {
                priceWorkList.Add(CopyToGoodsPriceUWorkFromGoodsPrice(goodsPrice));
            }
            goodsUnitDataWork.PriceList = priceWorkList;
            ArrayList stockWorkList = new ArrayList();
            foreach (Stock stock in goodsUnitData.StockList)
            {
                stockWorkList.Add(CopyToStockWorkFromStock(stock));
            }
            goodsUnitDataWork.StockList = stockWorkList;

            return goodsUnitDataWork;
        }

        /// <summary>
        /// 商品データ更新処理
        /// </summary>
        /// <param name="goodsUnitDataWork">商品データワーククラス</param>
        /// <param name="stockMoveWork">在庫移動データワーククラス</param>
        /// <remarks>
        /// <br>Note　　　  : 商品データを更新します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private void UpdateGoodsUnitDataWork(ref GoodsUnitDataWork goodsUnitDataWork, StockMoveWork stockMoveWork)
        {
            goodsUnitDataWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsUnitDataWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            goodsUnitDataWork.GoodsName = stockMoveWork.GoodsName;
            goodsUnitDataWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
        }

        /// <summary>
        /// 商品データ作成処理
        /// </summary>
        /// <param name="stockMoveWork">在庫移動データ</param>
        /// <returns>商品データ</returns>
        /// <remarks>
        /// <br>Note　　　  : 商品データを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsUnitDataWork CreateGoodsUnitDataWork(StockMoveWork stockMoveWork)
        {
            GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

            goodsUnitDataWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            goodsUnitDataWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsUnitDataWork.GoodsNo = stockMoveWork.GoodsNo;
            goodsUnitDataWork.GoodsName = stockMoveWork.GoodsName;
            goodsUnitDataWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
            goodsUnitDataWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            goodsUnitDataWork.GoodsNoNoneHyphen = GetGoodsNoNoneHyphen(stockMoveWork.GoodsNo);
            ArrayList priceList = new ArrayList();
            priceList.Add(CreateGoodsPriceUWork(stockMoveWork));
            goodsUnitDataWork.PriceList = priceList;

            return goodsUnitDataWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(価格マスタ→価格マスタワーク)
        /// </summary>
        /// <param name="goodsPrice">価格マスタ</param>
        /// <returns>価格マスタワーク</returns>
        /// <remarks>
        /// <br>Note　　　  : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPrice(GoodsPrice goodsPrice)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
            goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
            goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
            goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
            goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
            goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
            goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
            goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
            goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
            goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
            goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
            goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
            goodsPriceUWork.StockRate = goodsPrice.StockRate;
            goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
            goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

            return goodsPriceUWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(在庫データ→在庫データワーク)
        /// </summary>
        /// <param name="stock">在庫データ</param>
        /// <returns>在庫データワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　  : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromStock(Stock stock)
        {
            StockWork stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime;
            stockWork.UpdateDateTime = stock.UpdateDateTime;
            stockWork.EnterpriseCode = stock.EnterpriseCode;
            stockWork.FileHeaderGuid = stock.FileHeaderGuid;
            stockWork.UpdEmployeeCode = stock.UpdEmployeeCode;
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1;
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2;
            stockWork.LogicalDeleteCode = stock.LogicalDeleteCode;
            stockWork.SectionCode = stock.SectionCode;
            stockWork.WarehouseCode = stock.WarehouseCode;
            stockWork.GoodsMakerCd = stock.GoodsMakerCd;
            stockWork.GoodsNo = stock.GoodsNo;
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl;
            stockWork.SupplierStock = stock.SupplierStock;
            stockWork.AcpOdrCount = stock.AcpOdrCount;
            stockWork.MonthOrderCount = stock.MonthOrderCount;
            stockWork.SalesOrderCount = stock.SalesOrderCount;
            stockWork.StockDiv = stock.StockDiv;
            stockWork.MovingSupliStock = stock.MovingSupliStock;
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt;
            stockWork.StockTotalPrice = stock.StockTotalPrice;
            stockWork.LastStockDate = stock.LastStockDate;
            stockWork.LastSalesDate = stock.LastSalesDate;
            stockWork.LastInventoryUpdate = stock.LastInventoryUpdate;
            stockWork.MinimumStockCnt = stock.MinimumStockCnt;
            stockWork.MaximumStockCnt = stock.MaximumStockCnt;
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount;
            stockWork.SalesOrderUnit = stock.SalesOrderUnit;
            stockWork.StockSupplierCode = stock.StockSupplierCode;
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
            stockWork.WarehouseShelfNo = stock.WarehouseShelfNo;
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1;
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2;
            stockWork.StockNote1 = stock.StockNote1;
            stockWork.StockNote2 = stock.StockNote2;
            stockWork.ShipmentCnt = stock.ShipmentCnt;
            stockWork.ArrivalCnt = stock.ArrivalCnt;
            stockWork.StockCreateDate = stock.StockCreateDate;
            stockWork.UpdateDate = stock.UpdateDate;

            return stockWork;
        }

        /// <summary>
        /// ハイフン無品番取得処理
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <returns>ハイフン無品番</returns>
        /// <remarks>
        /// <br>Note　　　  : ハイフン無品番を取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private string GetGoodsNoNoneHyphen(string goodsNo)
        {
            string goodsNoNoneHyphen = "";

            // ハイフンを削除します
            for (int i = goodsNo.Length - 1; i >= 0; i--)
            {
                if (goodsNo[i].ToString() == "-")
                {
                    goodsNo = goodsNo.Remove(i, 1);
                }
            }

            goodsNoNoneHyphen = goodsNo;
            return goodsNoNoneHyphen;
        }

        /// <summary>
        /// 価格ワーククラス作成処理
        /// </summary>
        /// <param name="stockMoveWork">在庫移動ワーククラス</param>
        /// <returns>価格ワーククラス</returns>
        /// <remarks>
        /// <br>Note　　　  : 価格ワーククラスを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsPriceUWork CreateGoodsPriceUWork(StockMoveWork stockMoveWork)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            goodsPriceUWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsPriceUWork.GoodsNo = stockMoveWork.GoodsNo;
            goodsPriceUWork.PriceStartDate = GetPriceStartDate(stockMoveWork.ShipmentFixDay);
            goodsPriceUWork.ListPrice = stockMoveWork.ListPriceFl;
            goodsPriceUWork.SalesUnitCost = stockMoveWork.StockUnitPriceFl;

            return goodsPriceUWork;
        }

        /// <summary>
        /// 価格開始日取得処理
        /// </summary>
        /// <param name="dateTime">出荷確定日</param>
        /// <returns>価格開始日</returns>
        /// <remarks>
        /// <br>Note　　　  : 価格ワーククラスを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private DateTime GetPriceStartDate(DateTime dateTime)
        {
            try
            {
                //--------------------------------------------------
                // 通常は、前回月次更新日の翌日
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if (prevTotalDay != DateTime.MinValue)
                {
                    // 前回月次更新日の翌日
                    return prevTotalDay.AddDays(1);
                }

                //--------------------------------------------------
                // （※新規搬入して一度も月次更新をしていないような場合）自社.期首日
                //--------------------------------------------------
                DateGetAcs dateGetAcs = DateGetAcs.GetInstance(); // 日付取得部品
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = dateGetAcs.GetCompanyInf();
                if (companyInf != null && companyInf.CompanyBiginDate != 0)
                {
                    dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList);
                    if (startMonthDateList != null && startMonthDateList.Count > 0)
                    {
                        // 期首日←最初の月の開始日
                        return startMonthDateList[0];
                    }
                }
                dateGetAcs = null;
            }
            catch
            {
            }

            // ※通常は発生しないが期首日も取得できなかった場合は既存処理と同様。
            return dateTime;
        }

        /// <summary>
        /// 前回月次更新日取得
        /// </summary>
        /// <returns>前回月次更新日</returns>
        /// <remarks>
        /// <br>Note　　　  : 価格ワーククラスを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private DateTime GetHisTotalDayMonthly()
        {
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance(); // 締日チェック部品

            int status;
            DateTime prevTotalDay;

            // 締日算出モジュールのキャッシュクリア
            totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                totalDayCalculator.InitializeHisMonthly();
                status = totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // 売上月次処理日取得
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // 仕入月次処理日取得
                        status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay);
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                totalDayCalculator.InitializeHisMonthlyAccRec();
                status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
            }

            totalDayCalculator = null;

            return prevTotalDay;
        }
        #endregion
    }
}

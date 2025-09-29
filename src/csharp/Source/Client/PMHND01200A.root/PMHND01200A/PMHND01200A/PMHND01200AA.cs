//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入アクセスクラス
// プログラム概要   : ハンディターミナル在庫仕入アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/02  修正内容 : 新規作成
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
using Broadleaf.Application.UIData;
using System.Collections.Generic;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル在庫仕入アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫仕入アクセスクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/02</br>
    /// </remarks>
    public class HandyStockAcs
    {
        #region [定数]
        //// <summary>処理が正常に終了した場合のステータス</summary>
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
        /// <summary>デフォルトログファイル名</summary>
        private const string DefaultNamePgid = "PMHND01200A_";
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
        private const string OpDiv = "処理区分:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>商品バーコード</summary>
        private const string CustomerGoodsCode = "商品バーコード:";
        /// <summary>倉庫棚番</summary>
        private const string WarehouseShelfNo = "棚番:";
        /// <summary>検品ステータス</summary>
        private const string InspectStatus = "検品ステータス:";
        /// <summary>検品区分</summary>
        private const string InspectCode = "検品区分:";
        /// <summary>検品数</summary>
        private const string InspectCnt = "検品数:";
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgNull = "検索条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgParam = "入力パラメータエラーが発生しました。";
        /// <summary>商品管理情報の取得エラーメッセージ</summary>
        private const string GoodsDataErrorMsg = "商品管理情報の取得が失敗しました。";
        #endregion

        #region ■ Private Member
        /// <summary>仕入先マスタローカルキャッシュ</summary>
        private Dictionary<string, Supplier> SupplierDic = new Dictionary<string, Supplier>();
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
        public HandyStockAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ハンディターミナル在庫仕入_在庫情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入の在庫情報取得処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStock(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;
            // --- DEL 2019/11/13 ---------->>>>>
            //HandyStockWork retWork = null;
            // --- DEL 2019/11/13 ---------->>>>>
            // --- ADD 2019/11/13 ---------->>>>>
            ArrayList retWorkArray = null;
            // --- ADD 2019/11/13 ----------<<<<<

            // 検索条件
            HandyStockCondWork stockCondWork = condObj as HandyStockCondWork;

            // パラメータがnullの場合、
            if (stockCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(stockCondWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 処理区分が「13」、「14」以外の場合はエラーとします。
                // 企業コード、従業員コード、コンピュータ名、倉庫コード、商品バーコードは空値の場合、エラーとします。
                // --- MOD 2019/11/13 ---------->>>>>
                //if ((stockCondWork.OpDiv != 13 && stockCondWork.OpDiv !=14)
                //    || string.IsNullOrEmpty(stockCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(stockCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(stockCondWork.MachineName.Trim())
                //    || string.IsNullOrEmpty(stockCondWork.WarehouseCode)
                //    || string.IsNullOrEmpty(stockCondWork.CustomerGoodsCode))
                //{
                //    // エラーメッセージに引数の名前と値をログ出力します。
                //    this.WriteLog(stockCondWork, ErrorMsgParam);
                //    return status;
                //}
                // 2019/11　企業コード、従業員コード、コンピュータ名、倉庫コード、商品バーコード＋商品番号は空値の場合、エラーとします。
                if ((stockCondWork.OpDiv != 13 && stockCondWork.OpDiv != 14)
                    || string.IsNullOrEmpty(stockCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(stockCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(stockCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(stockCondWork.WarehouseCode)
                    || (string.IsNullOrEmpty(stockCondWork.CustomerGoodsCode) && string.IsNullOrEmpty(stockCondWork.GoodsNo)))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(stockCondWork, ErrorMsgParam);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }

            try
            {
                #region 在庫情報取得
                byte[] condByte = XmlByteSerializer.Serialize(stockCondWork);
                // --- MOD 2019/11/13 ---------->>>>>
                //byte[] retByte = null;
                object retByte = null;
                // --- MOD 2019/11/13 ----------<<<<<
                // 在庫（仕入・移動）リモーティングオブジェクト
                IHandyStockMoveDB iStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
                // 在庫情報取得を行います。
                // MOD 2019/11/13 ---------->>>>>
                //status = iStockMoveDBObj.SearchStock(condByte, out retByte);
                status = iStockMoveDBObj.SearchStockHandy(condByte, out retByte);
                // MOD 2019/11/13 ----------<<<<<

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 返却パラメータセット
                    // --- MOD 2019/11/13 ---------->>>>>
                    //retObj = XmlByteSerializer.Deserialize(retByte, typeof(HandyStockWork));
                    //retWork = retObj as HandyStockWork;
                    retObj = retByte;
                    retWorkArray = retObj as ArrayList;
                    // --- MOD 2019/11/13 ----------<<<<<
                    // --- ADD 2019/11/13 ---------->>>>>
                    ArrayList retArray = new ArrayList();
                    foreach (HandyStockWork retWork in retWorkArray)
                    {
                        // --- ADD 2019/11/13 ----------<<<<<
                        GoodsUnitData goodsUnitData = null;
                        // 商品管理情報を取得します。（仕入先取得用）
                        this.GetGoodsMngInfo(ref goodsUnitData, retWork, stockCondWork);
                        int SupplierCd = 0;
                        if (goodsUnitData != null)
                        {
                            CacheSupplierData(stockCondWork.EnterpriseCode);
                            SupplierCd = goodsUnitData.SupplierCd;
                            // 仕入先マスタから仕入先名称を取得
                            if (SupplierDic.ContainsKey(SupplierCd.ToString("d06")))
                            {
                                // 仕入先マスタに存在
                                Supplier Supplier = SupplierDic[SupplierCd.ToString("d06")];
                                // 仕入先名称を設定
                                retWork.SupplierNm = Supplier.SupplierSnm;
                            }
                        }
                        else
                        {
                            // エラーログ出力します。
                            this.WriteLog(stockCondWork, GoodsDataErrorMsg);
                        }
                        // 在庫発注先コードのチェック
                        int StockSupplierCd = 0;
                        if (retWork.StockSupplierCode != 0)
                        {
                            StockSupplierCd = retWork.StockSupplierCode;
                        }
                        else
                        {
                            // 在庫発注先コードが未設定の場合、仕入先コードを発注先コードとする。
                            StockSupplierCd = SupplierCd;
                        }
                        // UOE発注先マスタ情報を取得します。（発注先名称取得用）
                        if (StockSupplierCd != 0)
                        {
                            retWork.StockSupplierCode = StockSupplierCd;
                            UOESupplierAcs uOESupplierAcs = new UOESupplierAcs();
                            UOESupplier UoeSupplier;
                            uOESupplierAcs.Read(out UoeSupplier, stockCondWork.EnterpriseCode, StockSupplierCd, retWork.SectionCode);
                            if (UoeSupplier != null)
                            {
                                // UOE発注先マスタに存在した場合はUOE発注先名称を発注先名称とする。
                                retWork.UOESupplierName = UoeSupplier.UOESupplierName;

                            }
                            else
                            {
                                // UOE発注先マスタに存在しない場合は仕入先名称を発注先名称とする。
                                retWork.UOESupplierName = retWork.SupplierNm;
                            }
                        }

                        // --- ADD 2019/11/13 ---------->>>>>
                        retArray.Add(retWork);
                    }
                    // --- ADD 2019/11/13 ----------<<<<<


                    // --- MOD 2019/11/13 ---------->>>>>
                    //retObj = retWork;
                    retObj = retArray;
                    // --- MOD 2019/11/13 ----------<<<<<

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
                this.WriteLog(stockCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // 処理なし。
            }

            return status;
        }

        # region [検品データ登録]
        /// <summary>
        /// 在庫仕入_検品データ登録(先行検品)処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫仕入（出荷・入荷）の検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteHandyInspect(object inspectDataObj)
        {
            int status = StatusError;
            HandyInspectDataWork inspectDataWork = inspectDataObj as HandyInspectDataWork;
            ArrayList inspectDataWorkList = new ArrayList();
            // パラメータがnullの場合、
            if (inspectDataWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目のチェック
                if (String.IsNullOrEmpty(inspectDataWork.MachineName.Trim()) ||            // コンピュータ名
                    String.IsNullOrEmpty(inspectDataWork.EmployeeCode.Trim()) ||           // 従業員コード
                    String.IsNullOrEmpty(inspectDataWork.WarehouseCode.Trim()) ||           // 倉庫コード
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
                    inspectDataWork.InspectStatus > 99 ||
                    inspectDataWork.InspectCnt > 99999999.99 ||
                    inspectDataWork.MachineName.Length > 20 ||
                    inspectDataWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }
                if (inspectDataWork.ProcDiv != 13 && inspectDataWork.ProcDiv != 14)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }
                // 受払元伝票番号(リモートにて採番)
                inspectDataWork.AcPaySlipNum = string.Empty;
                // 受払元伝票区分(10:仕入)
                inspectDataWork.AcPaySlipCd = 10;

                // 受払元行番号(0固定)
                inspectDataWork.AcPaySlipRowNo = 0;


                if (inspectDataWork.ProcDiv == 13)
                {
                    // 受払元取引区分(10：通常)
                    inspectDataWork.AcPayTransCd = 10;
                }
                else
                {
                    // 受払元取引区分(11：返品)
                    inspectDataWork.AcPayTransCd = 11;
                }

                // ハンディターミナル区分:固定値(1:ハンディターミナル)
                inspectDataWork.HandTerminalCode = 1;
                inspectDataWorkList.Add(inspectDataWork);
            }
            try
            {
                inspectDataObj = inspectDataWorkList as object;
                // 在庫（仕入・移動）リモーティングオブジェクト
                IHandyStockMoveDB iHandyStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
                // 検品データ(先行検品)を登録します。
                status = iHandyStockMoveDBObj.Write(ref inspectDataObj, 1);

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
                this.WriteLog(inspectDataWork, ex.ToString());
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

        #region 商品アクセスクラス(商品管理情報取得)
        /// <summary>
        /// 商品アクセスクラス(商品管理情報取得)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データクラス</param>
        /// <param name="resultWork">抽出結果データクラス</param>
        /// <param name="stockCondWork">検索条件</param>
        /// <remarks>
        /// <br>Note       : 商品管理情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private void GetGoodsMngInfo(ref GoodsUnitData goodsUnitData, HandyStockWork resultWork, HandyStockCondWork stockCondWork)
        {
            goodsUnitData = new GoodsUnitData();
            //商品アクセスクラスの初期化
            string message = "";
            GoodsAcs goodsObj = new GoodsAcs();
            goodsObj.IsGetSupplier = true;
            goodsObj.SearchInitial(stockCondWork.EnterpriseCode, stockCondWork.SectionCode.TrimEnd(), out message);

            // 抽出条件設定
            goodsUnitData.SectionCode = resultWork.SectionCode;            // 拠点コード
            goodsUnitData.GoodsMakerCd = resultWork.GoodsMakerCd;          // メーカーコード
            goodsUnitData.GoodsNo = resultWork.GoodsNo;                    // 品番
            goodsUnitData.BLGoodsCode = resultWork.BLGoodsCode;            // BLコード

            //BLコードマスタ取得(BLグループコード取得用)
            BLGoodsCdUMnt goodsCdUMnt;
            goodsObj.GetBLGoodsCd(resultWork.BLGoodsCode, out goodsCdUMnt);

            //BLグループコードマスタ取得(商品中分類コード取得用)
            BLGroupU bLGroupU = null;
            if (goodsCdUMnt != null)
            {
                goodsObj.GetBLGroup(goodsUnitData.EnterpriseCode, goodsCdUMnt.BLGloupCode, out bLGroupU);
            }

            //中分類セット
            if (bLGroupU != null)
            {
                goodsUnitData.GoodsMGroup = bLGroupU.GoodsMGroup;
            }

            // 商品管理情報の取得
            goodsObj.GetGoodsMngInfo(ref goodsUnitData);
        }
        #endregion

        #region 仕入先マスタのローカルキャッシュ
        /// <summary>
        /// 仕入先マスタのローカルキャッシュ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 仕入先マスタのローカルキャッシュを作成します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private void CacheSupplierData(string enterpriseCode)
        {
            int status = StatusError;
            ArrayList retList = new ArrayList();
            SupplierAcs supplierAcs = new SupplierAcs();

            // 仕入先マスタのローカルキャッシュをクリア
            SupplierDic = new Dictionary<string, Supplier>();

            // 仕入先マスタの取得
            status = supplierAcs.SearchAll(out retList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Supplier supplierWork in retList)
                {
                    if (supplierWork.LogicalDeleteCode == 0)
                    {
                        string key = supplierWork.SupplierCd.ToString("d06");
                        if (SupplierDic.ContainsKey(key))
                        {
                            // 既にキャッシュに存在している場合は削除
                            SupplierDic.Remove(key);
                        }
                        SupplierDic.Add(key, supplierWork);
                    }
                }
            }
        }
        #endregion

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="logObj">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer  : 陳艶丹</br>
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
                if (logObj is HandyStockCondWork)
                {
                    HandyStockCondWork handyStockCondWork = logObj as HandyStockCondWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyStockCondWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyStockCondWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyStockCondWork.MachineName);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyStockCondWork.OpDiv);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + handyStockCondWork.WarehouseCode);
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + handyStockCondWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + handyStockCondWork.GoodsNo);
                    // 商品バーコード
                    writer.WriteLine(CustomerGoodsCode + handyStockCondWork.CustomerGoodsCode);
                    // 倉庫棚番
                    writer.WriteLine(WarehouseShelfNo + handyStockCondWork.WarehouseShelfNo);
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
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + handyInspectDataWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + handyInspectDataWork.GoodsNo);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + handyInspectDataWork.WarehouseCode);
                    // 検品ステータス
                    writer.WriteLine(InspectStatus + handyInspectDataWork.InspectStatus);
                    // 検品区分
                    writer.WriteLine(InspectCode + handyInspectDataWork.InspectCode);
                    // 検品数
                    writer.WriteLine(InspectCnt + handyInspectDataWork.InspectCnt);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyInspectDataWork.ProcDiv);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}

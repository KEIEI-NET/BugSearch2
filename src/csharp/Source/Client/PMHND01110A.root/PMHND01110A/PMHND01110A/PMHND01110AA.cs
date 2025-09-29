//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入(UOE以外)明細情報取得アクセスクラス
// プログラム概要   : ハンディターミナル在庫仕入(UOE以外)明細情報取得アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル在庫仕入(UOE以外)明細情報取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報取得アクセスクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyNonUOEInspectAcs
    {
        #region [定数]
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // ﾛｸﾞｲﾝIDが見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // 仕入先伝票番号の重複チェックステータス
        private const int StatusRegists = 7;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND01110A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
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
        /// <summary>仕入SEQ番号</summary>
        private const string SupplierSlipNo = "仕入SEQ番号:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>検品ステータス</summary>
        private const string InspectStatus = "検品ステータス:";
        /// <summary>検品区分</summary>
        private const string InspectCode = "検品区分:";
        /// <summary>検品数</summary>
        private const string InspectCnt = "検品数:";
        /// <summary>仕入明細通番</summary>
        private const string StockSlipDtlNum = "仕入明細通番:";
        /// <summary>仕入先伝票番号</summary>
        private const string PartySaleSlipNum = "仕入先伝票番号:";

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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandyNonUOEInspectAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region ハンディターミナル在庫仕入(UOE以外)明細情報取得処理
        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)明細情報取得処理
        /// </summary>
        /// <param name="paraHandyNonUOEStockSupplierCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandyNonUOEStockSupplierObj">検索結果オブジェクト</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyNonUOEStockSupplier(ref object paraHandyNonUOEStockSupplierCondObj, out object resultHandyNonUOEStockSupplierObj)
        {
            resultHandyNonUOEStockSupplierObj = null;
            int status = StatusError;

            // 検索条件
            HandyNonUOEStockParamWork handyNonUOEStockParamWork = paraHandyNonUOEStockSupplierCondObj as HandyNonUOEStockParamWork;

            // パラメータがnullの場合、
            if (handyNonUOEStockParamWork == null)
            {
                // ログ出力します。
                this.WriteLog(handyNonUOEStockParamWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // パラメータチェック
                // 入力パラメータ「企業コード、従業員コード、コンピュータ名、処理区分」は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(handyNonUOEStockParamWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(handyNonUOEStockParamWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(handyNonUOEStockParamWork.MachineName.Trim())
                    // 引数.処理区分が「12」以外の場合、ST_ERR(-1)を返却します。
                    || handyNonUOEStockParamWork.OpDiv != 12)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(handyNonUOEStockParamWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region ハンディターミナル在庫仕入(UOE以外)明細情報を取得する
                // リモート取得
                IHandyStockSupplierDB iHandyStockSupplierDB = (IHandyStockSupplierDB)MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();

                // ハンディターミナル在庫仕入情報取得リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyNonUOEStockParamWork);

                status = iHandyStockSupplierDB.SearchNonUOEStockSupplier(condByte, out resultHandyNonUOEStockSupplierObj);

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
                this.WriteLog(handyNonUOEStockParamWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                //　処理なし。
            }

            return status;
        }
        # endregion

        # region [ハンディターミナル在庫仕入（UOE以外）_登録]
        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）の登録処理
        /// </summary>
        /// <param name="nonUOEInspectListObj">登録用パラメータオブジェクト</param>
        /// <returns>ステータス[0: 正常、 0以外: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル在庫仕入（UOE以外）を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int WriteHandyNonUOEInspect(ref object nonUOEInspectListObj)
        {
            int status = StatusError;

            // 登録用パラメータデータがない場合
            if (nonUOEInspectListObj == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }

            ArrayList nonUOEInspectList = nonUOEInspectListObj as ArrayList;
            Dictionary<long, string> nonUOEInspectDic = new Dictionary<long, string>();
            // 登録用検品データオブジェクト
            object nonUOEInspectWriteObj = null;
            // 登録用検品データリスト
            ArrayList nonUOEInspectWriteList = new ArrayList();

            foreach (HandyNonUOEInspectParamWork handyNonUOEInspectParamWork in nonUOEInspectList)
            {
                // 必須入力項目のチェック
                // コンピュータ名
                if (String.IsNullOrEmpty(handyNonUOEInspectParamWork.MachineName.Trim())
                    // 従業員コード
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.EmployeeCode.Trim())
                    // 企業コード
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.EnterpriseCode.Trim())
                    // 倉庫コード
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.WarehouseCode.Trim())
                    // 引数.処理区分が「12:在庫仕入（UOE以外）」以外の場合、ST_ERR(-1)を返却します。
                  || (handyNonUOEInspectParamWork.OpDiv != 12)
                    // メーカーコード
                  || (handyNonUOEInspectParamWork.GoodsMakerCd <= 0)
                    // 仕入SEQ番号
                  || (handyNonUOEInspectParamWork.SupplierSlipNo <= 0)
                    // 仕入明細通番
                  || (handyNonUOEInspectParamWork.StockSlipDtlNum <= 0)
                    // 商品番号
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.GoodsNo.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(handyNonUOEInspectParamWork, ErrorMsgParam);
                    return status;
                }

                // 桁のチェック
                if (handyNonUOEInspectParamWork.GoodsMakerCd > 999999
                    || handyNonUOEInspectParamWork.PartySaleSlipNum.Length > 19
                    || handyNonUOEInspectParamWork.GoodsNo.Length > 40
                    || handyNonUOEInspectParamWork.WarehouseCode.Length > 6
                    || handyNonUOEInspectParamWork.InspectStatus > 99
                    || handyNonUOEInspectParamWork.InspectCode > 99
                    || handyNonUOEInspectParamWork.InspectCnt > 99999999.99
                    || handyNonUOEInspectParamWork.MachineName.Length > 80
                    || handyNonUOEInspectParamWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(handyNonUOEInspectParamWork, ErrorMsgParam);
                    return status;
                }

                // 検品数>0の場合、検索パラメータディクショナリーを作成します。
                if (handyNonUOEInspectParamWork.InspectCnt > 0)
                {
                    if (!nonUOEInspectDic.ContainsKey(handyNonUOEInspectParamWork.StockSlipDtlNum))
                    {
                        nonUOEInspectDic.Add(handyNonUOEInspectParamWork.StockSlipDtlNum, string.Empty);
                    }

                    nonUOEInspectWriteList.Add(handyNonUOEInspectParamWork);
                }
            }

            // 引数.検品数>0のデータがない場合
            if (nonUOEInspectWriteList.Count == 0)
            {
                status = StatusNomal;
                return status;
            }

            try
            {
                // 入庫更新処理
                IHandyStockSupplierDB iHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();

                HandyNonUOEInspectParamWork handyNonUOEInspectParamWork = (HandyNonUOEInspectParamWork)nonUOEInspectList[0];

                // ハンディターミナル在庫仕入情報取得リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyNonUOEInspectParamWork);

                object orderListResultObj = null;
                status = iHandyStockSupplierDBAdapter.SearchHandyNonUOESlipInfo(condByte, out orderListResultObj);

                // 在庫仕入入力アクセス初期化失敗場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusError;
                    return status;
                }

                List<OrderListResultWork> orderListResultWorkList = new List<OrderListResultWork>();

                foreach (OrderListResultWork orderListResultWork in (ArrayList)orderListResultObj)
                {
                    if (nonUOEInspectDic.ContainsKey(orderListResultWork.StockSlipDtlNum))
                    {
                        orderListResultWorkList.Add(orderListResultWork);
                    }
                }

                // 在庫仕入入力アクセス初期化失敗場合
                if (orderListResultWorkList.Count == 0)
                {
                    status = StatusError;
                    return status;
                }

                object stockWriteDataListObj = null;
                // 引数.仕入先伝票番号がNULLの場合
                if (string.IsNullOrEmpty(handyNonUOEInspectParamWork.PartySaleSlipNum.Trim()))
                {
                    // 在庫仕入入力アクセス初期化
                    AdjustStockAcs adjustStockAcs = new AdjustStockAcs(handyNonUOEInspectParamWork.EnterpriseCode, handyNonUOEInspectParamWork.BelongSectionCode, out status);

                    // 在庫仕入入力アクセス初期化失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 在庫仕入情報のデータセット処理
                    status = adjustStockAcs.OrderListResultWorkToGridForHandy(handyNonUOEInspectParamWork.BelongSectionCode, orderListResultWorkList);

                    // 在庫仕入情報のデータセット処理失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 在庫仕入情報の仕入数、仕入後数の補正処理
                    status = adjustStockAcs.SetInspectDataForHandy(nonUOEInspectList);

                    // 在庫仕入情報の仕入数、仕入後数の補正処理が失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 在庫仕入情報登録データの取得処理
                    status = adjustStockAcs.GetSaveDBDataForHandy(handyNonUOEInspectParamWork.BelongSectionCode, handyNonUOEInspectParamWork.EmployeeCode, out stockWriteDataListObj);

                    // 在庫仕入情報登録データの取得処理が失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }
                }
                // 引数.仕入先伝票番号がNULLではない場合
                else
                {
                    // 仕入入力アクセス初期化
                    StockSlipInputAcs stockSlipInputAcs = new StockSlipInputAcs(handyNonUOEInspectParamWork.EnterpriseCode, handyNonUOEInspectParamWork.BelongSectionCode, orderListResultWorkList.Count, out status);

                    // 仕入入力アクセス初期化失敗場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 仕入先伝票番号の重複チェック
                    status = stockSlipInputAcs.ReadStockSlipForHandy(handyNonUOEInspectParamWork.EnterpriseCode, handyNonUOEInspectParamWork.BelongSectionCode, handyNonUOEInspectParamWork.PartySaleSlipNum, orderListResultWorkList[0].SupplierCd);

                    // ハンディ専用のReadStockSlipForHandyの戻り値が正常終了の場合、ST_REGISTS(7)を返却します。
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusRegists;
                        return status;
                    }
                    // 仕入先伝票番号重複しない場合、登録処理を続ける。
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // 処理なし。
                    }
                    // 仕入先伝票番号の重複チェック処理がタイムアウト場合
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        status = StatusTimeout;
                        return status;
                    }
                    // 仕入先伝票番号の重複チェック処理失敗場合
                    else
                    {
                        status = StatusError;
                        return status;
                    }

                    // 仕入明細データ行のデータセット処理
                    status = stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkListForHandy(handyNonUOEInspectParamWork.BelongSectionCode, orderListResultWorkList);

                    // 仕入明細データ行のデータセット処理が失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 検品数の設定処理
                    status = stockSlipInputAcs.SetInspectDataForHandy(nonUOEInspectList);

                    // 検品数の設定処理が失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // 仕入データの取得処理
                    status = stockSlipInputAcs.GetSaveDataForHandy(handyNonUOEInspectParamWork.EmployeeCode, handyNonUOEInspectParamWork.BelongSectionCode, out stockWriteDataListObj);

                    // 仕入データの取得処理が失敗の場合
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }
                }

                // 検品データ登録処理
                nonUOEInspectWriteObj = (object)nonUOEInspectWriteList;
                status = iHandyStockSupplierDBAdapter.WriteHandyStockData(ref nonUOEInspectWriteObj, ref stockWriteDataListObj);

                // 入庫更新(UOE以外)処理が正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 入庫更新(UOE以外)処理がタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // 入庫更新(UOE以外)処理失敗場合
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

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="logObj">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
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
                if (logObj is HandyNonUOEStockParamWork)
                {
                    HandyNonUOEStockParamWork handyNonUOEStockParamWork = logObj as HandyNonUOEStockParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyNonUOEStockParamWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyNonUOEStockParamWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyNonUOEStockParamWork.MachineName);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyNonUOEStockParamWork.OpDiv);
                    // 仕入SEQ番号
                    writer.WriteLine(SupplierSlipNo + handyNonUOEStockParamWork.SlipNo);
                }
                else if (logObj is HandyNonUOEInspectParamWork)
                {
                    HandyNonUOEInspectParamWork handyNonUOEInspectParamWork = logObj as HandyNonUOEInspectParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyNonUOEInspectParamWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyNonUOEInspectParamWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyNonUOEInspectParamWork.MachineName);
                    // 商品メーカーコード
                    writer.WriteLine(GoodsMakerCd + handyNonUOEInspectParamWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + handyNonUOEInspectParamWork.GoodsNo);
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + handyNonUOEInspectParamWork.WarehouseCode);
                    // 検品ステータス
                    writer.WriteLine(InspectStatus + handyNonUOEInspectParamWork.InspectStatus);
                    // 検品区分
                    writer.WriteLine(InspectCode + handyNonUOEInspectParamWork.InspectCode);
                    // 検品数
                    writer.WriteLine(InspectCnt + handyNonUOEInspectParamWork.InspectCnt);
                    // 処理区分
                    writer.WriteLine(OpDiv + handyNonUOEInspectParamWork.OpDiv);
                    // 仕入SEQ番号
                    writer.WriteLine(SupplierSlipNo + handyNonUOEInspectParamWork.SupplierSlipNo);
                    // 仕入明細通番
                    writer.WriteLine(StockSlipDtlNum + handyNonUOEInspectParamWork.StockSlipDtlNum);
                    // 仕入先伝票番号
                    writer.WriteLine(PartySaleSlipNum + handyNonUOEInspectParamWork.PartySaleSlipNum);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

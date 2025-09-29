//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル委託在庫補充アクセスクラス
// プログラム概要   : ハンディターミナル委託在庫補充アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 脇田　靖之
// 修 正 日  2017/12/14  修正内容 :ハンディターミナル三次対応
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル委託在庫補充アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル委託在庫補充アクセスクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    public class HandyConsStockRepAcs
    {
        #region [定数]
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // ﾛｸﾞｲﾝIDが見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // 検品対象外ステータス
        private const int StatusNonTarget = 6;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string LogPath = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string PgId = "PMHND01300A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string File = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>企業コード</summary>
        private const string EnterpriseCod = "企業コード:";
        /// <summary>従業員コード</summary>
        private const string EmployeeCode = "従業員コード:";
        /// <summary>コンピュータ名</summary>
        private const string MachineName = "コンピュータ名:";
        /// <summary>委託倉庫コード</summary>
        private const string ConsignWarehouseCode = "委託倉庫コード:";
        /// <summary>主管元倉庫コード</summary>
        private const string MainMngWarehouseCode = "主管元倉庫コード:";
        /// <summary>出荷日</summary>
        private const string ShipmentDay = "出荷日:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "委託先倉庫コード:";
        /// <summary>検品ステータス</summary>
        private const string InspectStatus = "検品ステータス:";
        /// <summary>検品区分</summary>
        private const string InspectCode = "検品区分:";
        /// <summary>検品数</summary>
        private const string InspectCnt = "検品数:";
        /// <summary>処理区分</summary>
        private const string OpDiv = "処理区分:";
        /// <summary>在庫調整伝票番号</summary>
        private const string AcPaySlipNum = "委託先在庫調整伝票番号:";
        /// <summary>在庫調整行番号</summary>
        private const string AcPaySlipRowNo = "委託先在庫調整行番号:";

        /// <summary>受払元伝票区分「70:補充入庫」</summary>
        private const int AcPaySlipCdData70 = 70;
        /// <summary>受払元取引区分「30:在庫数調整」</summary>
        private const int AcPayTransCdData30 = 30;
        /// <summary>ハンディターミナル区分「1:ハンディターミナル」</summary>
        private const int HandTerminalCodeData1 = 1;
        /// <summary>検品登録区分「0:検品データ登録」</summary>
        private const int InspectInsertModeData0 = 0;
        /// <summary>検品ステータス「3:検品済み」</summary>
        private const int InspectStatusData3 = 3;

        /// <summary>パラメータnullメッセージ</summary>
        private const string ConditionsError = "登録条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ParametersError = "入力パラメータエラーが発生しました。";
        #endregion

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
        public HandyConsStockRepAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [ハンディターミナル委託在庫補充_検品情報登録処理]
        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報登録処理
        /// </summary>
        /// <param name="inspectDataListObj">登録用パラメータオブジェクト</param>
        /// <returns>登録結果ステータス[0: 正常、 0以外: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int WriteHandyConsStockRepInspect(ref object inspectDataListObj)
        {
            int status = StatusError;

            // 登録用パラメータデータがない場合
            if (inspectDataListObj == null)
            {
                // ログ出力します。
                this.WriteLog(null, ConditionsError);
                return status;
            }

            ArrayList inspectDataList = inspectDataListObj as ArrayList;

            foreach (ConsStockRepInspectDataParamWork consStockRepInspectDataParamWork in inspectDataList)
            {
                // 必須入力項目のチェック
                // コンピュータ名
                if (string.IsNullOrEmpty(consStockRepInspectDataParamWork.MachineName.Trim())
                    // 従業員コード
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.EmployeeCode.Trim())
                    // 企業コード
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.EnterpriseCode.Trim())
                    // 引数.処理区分が「17」以外の場合、ST_ERR(-1)を返却します。
                  || consStockRepInspectDataParamWork.OpDiv != 17
                    // 委託先在庫調整伝票番号
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.AcPaySlipNum.Trim())
                    // 委託先在庫調整行番号
                  || consStockRepInspectDataParamWork.AcPaySlipRowNo <= 0
                    // 商品メーカーコード
                  || consStockRepInspectDataParamWork.GoodsMakerCd <= 0
                    // 商品番号
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.GoodsNo.Trim())
                    // 委託先倉庫コード
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.WarehouseCode.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(consStockRepInspectDataParamWork, ParametersError);
                    return status;
                }

                // 桁のチェック
                if (consStockRepInspectDataParamWork.GoodsMakerCd > 999999
                    || consStockRepInspectDataParamWork.AcPaySlipNum.Length > 9
                    || consStockRepInspectDataParamWork.AcPaySlipRowNo > 9999
                    || consStockRepInspectDataParamWork.GoodsNo.Length > 40
                    || consStockRepInspectDataParamWork.WarehouseCode.Length > 6
                    || consStockRepInspectDataParamWork.InspectStatus > 99
                    || consStockRepInspectDataParamWork.InspectCode > 99
                    || consStockRepInspectDataParamWork.InspectCnt > 99999999.99
                    || consStockRepInspectDataParamWork.MachineName.Length > 80
                    || consStockRepInspectDataParamWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(consStockRepInspectDataParamWork, ParametersError);
                    return status;
                }
            }

            try
            {
                ArrayList inspectDataWriteList = new ArrayList();
                HandyInspectDataWork handyInspectDataWork = null;
                foreach (ConsStockRepInspectDataParamWork consStockRepInspectDataParamWork in inspectDataList)
                {
                    handyInspectDataWork = new HandyInspectDataWork();
                    // 企業コード
                    handyInspectDataWork.EnterpriseCode = consStockRepInspectDataParamWork.EnterpriseCode;
                    // 受払元伝票区分「固定値(70:補充入庫)」
                    handyInspectDataWork.AcPaySlipCd = AcPaySlipCdData70;
                    // 受払元伝票番号
                    handyInspectDataWork.AcPaySlipNum = consStockRepInspectDataParamWork.AcPaySlipNum;
                    // 受払元行番号
                    handyInspectDataWork.AcPaySlipRowNo = consStockRepInspectDataParamWork.AcPaySlipRowNo;
                    // 受払元取引区分「固定値(30:在庫数調整)」
                    handyInspectDataWork.AcPayTransCd = AcPayTransCdData30;
                    // 商品メーカーコード
                    handyInspectDataWork.GoodsMakerCd = consStockRepInspectDataParamWork.GoodsMakerCd;
                    // 商品番号
                    handyInspectDataWork.GoodsNo = consStockRepInspectDataParamWork.GoodsNo;
                    // 倉庫コード
                    handyInspectDataWork.WarehouseCode = consStockRepInspectDataParamWork.WarehouseCode;
                    // 検品ステータス
                    handyInspectDataWork.InspectStatus = consStockRepInspectDataParamWork.InspectStatus;
                    // 検品数
                    handyInspectDataWork.InspectCnt = consStockRepInspectDataParamWork.InspectCnt;
                    // 検品区分
                    handyInspectDataWork.InspectCode = consStockRepInspectDataParamWork.InspectCode;
                    // ハンディターミナル区分「固定値(1:ハンディターミナル)」
                    handyInspectDataWork.HandTerminalCode = HandTerminalCodeData1;
                    // 端末名称
                    handyInspectDataWork.MachineName = consStockRepInspectDataParamWork.MachineName;
                    // 従業員コード
                    handyInspectDataWork.EmployeeCode = consStockRepInspectDataParamWork.EmployeeCode;
                    inspectDataWriteList.Add(handyInspectDataWork);
                }

                object inspectDataWriteListObj = (object)inspectDataWriteList;

                // 検品情報登録処理
                IInspectDataDB iInspectDataDBAdapter = MediationInspectDataDB.GetDeleteInspectDataDB();
                status = iInspectDataDBAdapter.WriteInspectData(ref inspectDataWriteListObj, InspectInsertModeData0);

                // 検品情報登録処理が正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 検品情報登録処理がタイムアウト場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // 検品情報登録失敗場合
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

        # region [ハンディターミナル委託在庫補充_倉庫情報抽出処理]
        /// <summary>
        /// ハンディターミナル委託在庫補充_倉庫情報抽出処理
        /// </summary>
        /// <param name="paraHandyWarehouseInfoCondObj">ハンディターミナル委託在庫補充_倉庫情報抽出条件リスト</param>
        /// <param name="resultHandyWarehouseInfoObj">ハンディターミナル委託在庫補充_倉庫情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス[0: 正常, 4:見つからない、5:タイムアウト -1: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_倉庫情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyWarehouseInfo(ref object paraHandyWarehouseInfoCondObj, out object resultHandyWarehouseInfoObj)
        {
            int status = StatusError;
            resultHandyWarehouseInfoObj = new object();

            ConsStockRepWarehouseParamWork consStockRepWarehouseParamWork = paraHandyWarehouseInfoCondObj as ConsStockRepWarehouseParamWork;

            // 必須入力項目のチェック
            // 企業コード
            if (string.IsNullOrEmpty(consStockRepWarehouseParamWork.EnterpriseCode.Trim())
            // コンピュータ名
              || string.IsNullOrEmpty(consStockRepWarehouseParamWork.MachineName.Trim())
                // 従業員コード
              || string.IsNullOrEmpty(consStockRepWarehouseParamWork.EmployeeCode.Trim())
                // 引数.倉庫コード
              || string.IsNullOrEmpty(consStockRepWarehouseParamWork.WarehouseCode))
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(consStockRepWarehouseParamWork, ParametersError);
                return status;
            }

            try
            {
                // ハンディターミナル委託在庫補充_倉庫情報抽出リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(consStockRepWarehouseParamWork);

                object consStockRepWarehouseListObj = null;
                IHandyConsStockRepDB iHandyConsStockRepDBAdapter = MediationHandyConsStockRepDB.GetHandyConsStockRepDB();
                status = iHandyConsStockRepDBAdapter.SearchHandyWarehouseInfo(condByte, out consStockRepWarehouseListObj);

                // ハンディターミナル委託在庫補充_倉庫情報を正常取得する場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    resultHandyWarehouseInfoObj = consStockRepWarehouseListObj;
                }
                // ハンディターミナル委託在庫補充_倉庫情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // ハンディターミナル委託在庫補充_倉庫情報読込時のタイムアウト場合
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

        # region [ハンディターミナル委託在庫補充_検品情報抽出処理]
        /// <summary>
        /// ハンディターミナル委託在庫補充_検品情報抽出処理
        /// </summary>
        /// <param name="paraHandyInspectInfoCondObj">ハンディターミナル委託在庫補充_検品情報抽出条件リスト</param>
        /// <param name="resultHandyInspectInfoObj">ハンディターミナル委託在庫補充_検品情報抽出結果リスト</param>
        /// <returns>抽出結果ステータス[0: 正常, 4:見つからない、5:タイムアウト -1: エラー]</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル委託在庫補充_検品情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyInspectInfo(ref object paraHandyInspectInfoCondObj, out object resultHandyInspectInfoObj)
        {
            int status = StatusError;
            resultHandyInspectInfoObj = new object();

            ConsStockRepInspectParamWork consStockRepInspectParamWork = paraHandyInspectInfoCondObj as ConsStockRepInspectParamWork;

            // 必須入力項目のチェック
            // 企業コード
            if (string.IsNullOrEmpty(consStockRepInspectParamWork.EnterpriseCode.Trim())
            // コンピュータ名
              || string.IsNullOrEmpty(consStockRepInspectParamWork.MachineName.Trim())
                // 従業員コード
              || string.IsNullOrEmpty(consStockRepInspectParamWork.EmployeeCode.Trim())
                // 委託倉庫コード
              || string.IsNullOrEmpty(consStockRepInspectParamWork.ConsignWarehouseCode.Trim())
            // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
              //  // 出荷日
              //|| consStockRepInspectParamWork.ShipmentDay <= 0)
                // 出荷日
              || consStockRepInspectParamWork.ShipmentDay <= 0
                // 主管倉庫コード
              || string.IsNullOrEmpty(consStockRepInspectParamWork.MainMngWarehouseCode.Trim()))
            // --- ADD 2017/12/14 Y.Wakita ----------<<<<<
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(consStockRepInspectParamWork, ParametersError);
                return status;
            }

            try
            {
                // ハンディターミナル委託在庫補充_検品情報抽出リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(consStockRepInspectParamWork);

                object inspectInfoObj = null;
                IHandyConsStockRepDB iHandyConsStockRepDBAdapter = MediationHandyConsStockRepDB.GetHandyConsStockRepDB();
                status = iHandyConsStockRepDBAdapter.SearchHandyInspectInfo(condByte, out inspectInfoObj);

                // ハンディターミナル委託在庫補充_検品情報を正常取得する場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultHandyInspectInfoList = new ArrayList();
                    ArrayList inspectInfoList = inspectInfoObj as ArrayList;

                    foreach (ConsStockRepInspectRetWork consStockRepInspectRetWork in inspectInfoList)
                    {
                        // 検品ステータスが「3:検品済み」ではない場合、検品対象とする｡
                        if (consStockRepInspectRetWork.InspectStatus != InspectStatusData3)
                        {
                            resultHandyInspectInfoList.Add(consStockRepInspectRetWork);
                        }
                    }
                    // 全ての検品ステータスが「 3:検品済み」の場合、検品対象外とします。
                    if (resultHandyInspectInfoList.Count == 0)
                    {
                        status = StatusNonTarget;
                    }
                    // 検品ステータスが「3:検品済み」以外のデータがある場合
                    else
                    {
                        status = StatusNomal;
                        resultHandyInspectInfoObj = (object)resultHandyInspectInfoList;
                    }
                }
                // ハンディターミナル委託在庫補充_検品情報が見つからない場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // ハンディターミナル委託在庫補充_検品情報読込時のタイムアウト場合
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
            string path = System.IO.Directory.GetCurrentDirectory() + LogPath;

            lock (LogLockObj)
            {
                // フォルダが存在しない場合、
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, PgId + DateTime.Now.ToString(DefaultTime) + File), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // パラメータがnullではない場合、エラーメッセージに引数の名前と値を出力します。
                if (logObj is ConsStockRepWarehouseParamWork)
                {
                    ConsStockRepWarehouseParamWork consStockRepWarehouseParamWork = logObj as ConsStockRepWarehouseParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + consStockRepWarehouseParamWork.EnterpriseCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + consStockRepWarehouseParamWork.MachineName);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + consStockRepWarehouseParamWork.EmployeeCode);
                    // 委託倉庫コード
                    writer.WriteLine(ConsignWarehouseCode + consStockRepWarehouseParamWork.WarehouseCode);
                }
                else if (logObj is ConsStockRepInspectParamWork)
                {
                    ConsStockRepInspectParamWork consStockRepInspectParamWork = logObj as ConsStockRepInspectParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + consStockRepInspectParamWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + consStockRepInspectParamWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + consStockRepInspectParamWork.MachineName);
                    // 委託倉庫コード
                    writer.WriteLine(ConsignWarehouseCode + consStockRepInspectParamWork.ConsignWarehouseCode);
                    // 出荷日
                    writer.WriteLine(ShipmentDay + consStockRepInspectParamWork.ShipmentDay);
                }
                else if (logObj is ConsStockRepInspectDataParamWork)
                {
                    ConsStockRepInspectDataParamWork consStockRepInspectDataParamWork = logObj as ConsStockRepInspectDataParamWork;
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + consStockRepInspectDataParamWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + consStockRepInspectDataParamWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + consStockRepInspectDataParamWork.MachineName);
                    // 処理区分
                    writer.WriteLine(OpDiv + consStockRepInspectDataParamWork.OpDiv);
                    // 委託先在庫調整伝票番号
                    writer.WriteLine(AcPaySlipNum + consStockRepInspectDataParamWork.AcPaySlipNum);
                    // 委託先在庫調整行番号
                    writer.WriteLine(AcPaySlipRowNo + consStockRepInspectDataParamWork.AcPaySlipRowNo);
                    // メーカーコード
                    writer.WriteLine(GoodsMakerCd + consStockRepInspectDataParamWork.GoodsMakerCd);
                    // 商品番号
                    writer.WriteLine(GoodsNo + consStockRepInspectDataParamWork.GoodsNo);
                    // 委託先倉庫コード
                    writer.WriteLine(WarehouseCode + consStockRepInspectDataParamWork.WarehouseCode);
                    // 検品数
                    writer.WriteLine(InspectCnt + consStockRepInspectDataParamWork.InspectCnt);
                    // 検品区分
                    writer.WriteLine(InspectCode + consStockRepInspectDataParamWork.InspectCode);
                    // 検品ステータス
                    writer.WriteLine(InspectStatus + consStockRepInspectDataParamWork.InspectStatus);
                }

                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

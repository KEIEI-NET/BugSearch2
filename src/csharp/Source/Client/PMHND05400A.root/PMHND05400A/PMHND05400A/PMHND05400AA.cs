//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル棚卸処理(一斉)アクセスクラス
// プログラム概要   : ハンディターミナル棚卸処理(一斉)アクセスクラスです
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル棚卸処理(一斉)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル棚卸処理(一斉)アクセスクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public class HandyInventAcs
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
        private const string DefaultNamePgid = "PMHND05400A_";
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
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品バーコード</summary>
        private const string GoodsBarCode = "商品バーコード:";
        /// <summary>循環棚卸通番</summary>
        private const string InventorySeqNo = "循環棚卸通番:";
        /// <summary>棚卸日</summary>
        private const string InventoryDate = "棚卸日:";
        /// <summary>棚卸数</summary>
        private const string InventoryStockCnt = "棚卸数:";
        /// <summary>拠点コード</summary>
        private const string SectionCode = "拠点コード:";
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
        public HandyInventAcs()
        {
            LogLockObj = new object(); 
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// 棚卸処理(一斉)_棚卸存在確認処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理(一斉)の棚卸対象情報が存在するかを確認します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCount(object condObj)
        {
            int status = StatusError;
            // 検索条件
            HandyInventoryCondWork handyInventoryCondWork = condObj as HandyInventoryCondWork;
            // パラメータがnullの場合、
            if (handyInventoryCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull, 1);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 入力パラメータ企業コード、従業員コード、コンピュータ名、倉庫コード、棚卸日は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(handyInventoryCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(handyInventoryCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(handyInventoryCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(handyInventoryCondWork.WarehouseCode)
                    || (handyInventoryCondWork.InventoryDate <=0))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(handyInventoryCondWork, ErrorMsgParam, 1);
                    return status;
                }
            }
            try
            {
                #region 棚卸対象確認処理
                // ハンディターミナル循環棚卸リモーティングオブジェクト
                IHandyInventoryDataDB iHandyDataObj = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                // 棚卸対象確認を実行します
                status = iHandyDataObj.SearchCount(condObj);
                // 棚卸情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 棚卸データ見つからない場合
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
                this.WriteLog(handyInventoryCondWork, ex.ToString(), 1);
                status = StatusError;
            }
            finally
            {
                // 処理なし。
            }
            return status;
        }

        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理(一斉)の棚卸対象情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// <br>Note       : 品番とバーコードが共に空の場合にエラーとなるよう修正</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchInventory(object condObj, out object retObj)
        {
            int status = StatusError;
            retObj = null;
            // 検索条件
            HandyInventoryCondWork inventoryCondWork = condObj as HandyInventoryCondWork;

            // パラメータがnullの場合、
            if (inventoryCondWork == null)
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
                //if (string.IsNullOrEmpty(inventoryCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(inventoryCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(inventoryCondWork.MachineName.Trim())
                //    || string.IsNullOrEmpty(inventoryCondWork.WarehouseCode)
                //    || string.IsNullOrEmpty(inventoryCondWork.GoodsBarCode))
                //{
                //    // エラーメッセージに引数の名前と値をログ出力します。
                //    this.WriteLog(inventoryCondWork, ErrorMsgParam, 2);
                //    return status;
                //}
                if (string.IsNullOrEmpty(inventoryCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(inventoryCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(inventoryCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(inventoryCondWork.WarehouseCode)
                    || (string.IsNullOrEmpty(inventoryCondWork.GoodsBarCode) && string.IsNullOrEmpty(inventoryCondWork.GoodsNo)))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inventoryCondWork, ErrorMsgParam, 2);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }
            try
            {
                #region 棚卸処理(一斉)_棚卸対象取得
                // ハンディターミナル循環棚卸リモーティングオブジェクト
                IHandyInventoryDataDB iHandyInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                // 棚卸情報取得を実行します
                // --- MOD 2019/11/13 ---------->>>>>
                //status = iHandyInventoryDataDB.Search(condObj, out retObj);
                status = iHandyInventoryDataDB.SearchHandy(condObj, out retObj);
                // --- MOD 2019/11/13 ----------<<<<<

                // 棚卸情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // 棚卸情報が見つからない場合
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
                this.WriteLog(inventoryCondWork, ex.ToString(), 2);
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
        /// 棚卸処理(一斉)_棚卸データ更新
        /// </summary>
        /// <param name="inventoryDataObj">登録パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸処理(一斉)の棚卸情報を棚卸データに登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteInventoryData(object inventoryDataObj)
        {
            int status = StatusError;
            HandyInventoryCondWork inventoryDataWork = inventoryDataObj as HandyInventoryCondWork;
            // パラメータがnullの場合、
            if (inventoryDataWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ErrorMsgNull, 3);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目のチェック
                if (String.IsNullOrEmpty(inventoryDataWork.MachineName.Trim()) ||            // コンピュータ名
                    String.IsNullOrEmpty(inventoryDataWork.EmployeeCode.Trim()) ||           // 従業員コード
                    String.IsNullOrEmpty(inventoryDataWork.WarehouseCode.Trim()) ||           // 倉庫コード
                    String.IsNullOrEmpty(inventoryDataWork.BelongSectionCode.Trim()) ||       // 拠点コード
                    (inventoryDataWork.CirculInventSeqNo <= 0) ||      // 循環棚卸通番
                    (inventoryDataWork.InventoryStockCnt < 0))     // 棚卸数
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inventoryDataWork, ErrorMsgParam, 3);
                    return status;
                }
                // 桁のチェック
                if (inventoryDataWork.WarehouseCode.Length > 6 ||
                    inventoryDataWork.CirculInventSeqNo > 999999 ||
                    inventoryDataWork.InventoryStockCnt > 99999999.99 ||
                    inventoryDataWork.BelongSectionCode.Length > 6 ||
                    inventoryDataWork.MachineName.Length > 20 ||
                    inventoryDataWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inventoryDataWork, ErrorMsgParam, 3);
                    return status;
                }
            }
            try
            {
                #region 棚卸処理(一斉)_棚卸データ更新
                // ハンディターミナル循環棚卸リモーティングオブジェクト
                IHandyInventoryDataDB iInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                // 棚卸データ登録を実行します。
                status = iInventoryDataDB.Write(inventoryDataObj);
                // 棚卸データ登録が正常に終了した場合
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
                #endregion
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(inventoryDataWork, ex.ToString(), 3);
                status = StatusError;
            }
            finally
            {
                // 処理なし。
            }
            return status;
        }
        # endregion
        # endregion

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="handyInventoryWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="mode">1:棚卸対象確認、2:棚卸対象取得、3：棚卸データ更新</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void WriteLog(HandyInventoryCondWork handyInventoryWork, string errMsg, int mode)
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
                if (handyInventoryWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyInventoryWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyInventoryWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyInventoryWork.MachineName);
                    if (mode == 1)
                    {
                        // 棚卸日
                        writer.WriteLine(InventoryDate + handyInventoryWork.InventoryDate);
                    }
                   
                    if (mode == 2)
                    {
                        // 商品バーコード
                        writer.WriteLine(GoodsBarCode + handyInventoryWork.GoodsBarCode);
                    }
                    if (mode == 3)
                    {
                        // 循環棚卸通番
                        writer.WriteLine(InventorySeqNo + handyInventoryWork.CirculInventSeqNo);
                        // 棚卸数
                        writer.WriteLine(InventoryStockCnt + handyInventoryWork.InventoryStockCnt);
                        // 拠点コード
                        writer.WriteLine(SectionCode + handyInventoryWork.BelongSectionCode);
                    }
                    // 倉庫コード
                    writer.WriteLine(WarehouseCode + handyInventoryWork.WarehouseCode);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

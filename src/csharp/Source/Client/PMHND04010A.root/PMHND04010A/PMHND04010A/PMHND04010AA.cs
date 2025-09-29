//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 検品対象取得(一括検品)アクセスクラス
// プログラム概要   : 検品対象取得(一括検品)アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/13  修正内容 : 新規作成
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
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 検品対象取得(一括検品)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品対象取得(一括検品)アクセスクラスです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/13</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyInspectTotalAcs
    {
        #region [定数]
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // ﾛｸﾞｲﾝIDが見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // 検品対象伝票ではない場合
        private const int StatusNonTarget = 6;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        // 検品ステータス（2:検品済み）
        private const int InspectStatusAlreadyPicking = 2;
        // 検品ステータス（3:検品済み）
        private const int InspectStatusInspected = 3;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND04010A_";
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
        private const string ProcDiv = "処理区分:";
        /// <summary>伝票番号</summary>
        private const string SlipNum = "伝票番号:";
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
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public HandyInspectTotalAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// 検品対象取得(一括検品)処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象取得(一括検品)を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public int SearchHandyInspectData(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // 検索条件
            HandyInspectCondWork handyInspectCondWork = condObj as HandyInspectCondWork;

            // パラメータがnullの場合、
            if (handyInspectCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(handyInspectCondWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目チェック
                if (String.IsNullOrEmpty(handyInspectCondWork.EnterpriseCode.Trim())  // 企業コードが空白の場合
                   || String.IsNullOrEmpty(handyInspectCondWork.MachineName.Trim())   // コンピュータ名が空白の場合
                   || String.IsNullOrEmpty(handyInspectCondWork.EmployeeCode.Trim())  // 従業員コードが空白の場合
                   || String.IsNullOrEmpty(handyInspectCondWork.SlipNum.Trim())       // 伝票番号が空白の場合
                   || (handyInspectCondWork.ProcDiv != 1                              // 処理区分が「1,2」以外の場合
                    && handyInspectCondWork.ProcDiv != 2))                       
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(handyInspectCondWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region 検品対象情報を取得する
                // リモート取得
                IHandyInspectDB iHandyInspectDB = (IHandyInspectDB)MediationHandyInspectDB.GetHandyInspectDB();

                // 検品対象取得(一括検品)リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyInspectCondWork);

                object resultObj;
                status = iHandyInspectDB.SearchTotal(condByte, out resultObj);

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList newRetList = new ArrayList();
                    ArrayList retList = resultObj as ArrayList;
                    foreach (HandyInspectWork retWork in retList)
                    {
                        // 検品ステータスが「3:検品済み」ではない場合、かつ、
                        // (検品ステータスが「2:ピッキング済み」　AND　出庫数 = 検品数)ではない場合
                        if (retWork.InspectStatus != InspectStatusInspected
                            && !(retWork.InspectStatus == InspectStatusAlreadyPicking
                                && retWork.ShipmentCnt == retWork.InspectCnt))
                        {
                            // 検品対象とする
                            newRetList.Add(retWork);
                        }
                    }
                    // 検品ステータス全部が「3:検品済み」の場合、或いは、
                    // (検品ステータスが「2:ピッキング済み」　AND　出庫数 = 検品数)場合、
                    if (newRetList.Count == 0)
                    {
                        // 検品対象外とする、検品対象データを返却しません。
                        status = StatusNonTarget;
                    }
                    // // 検品ステータスが「3:検品済み」以外のデータがある場合
                    else
                    {
                        status = StatusNomal;
                        retObj = (object)newRetList;
                    }
                }
                // 検品対象が見つからない場合
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
                this.WriteLog(handyInspectCondWork, ex.ToString());
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
        /// <param name="handyInspectCondWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(HandyInspectCondWork handyInspectCondWork, string errMsg)
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
                if (handyInspectCondWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyInspectCondWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + handyInspectCondWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyInspectCondWork.MachineName);
                    // 処理区分
                    writer.WriteLine(ProcDiv + handyInspectCondWork.ProcDiv);
                    // 伝票番号
                    writer.WriteLine(SlipNum + handyInspectCondWork.SlipNum);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}

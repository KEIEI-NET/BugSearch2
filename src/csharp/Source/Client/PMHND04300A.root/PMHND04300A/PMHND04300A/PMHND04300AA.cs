//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル発注先ガイド情報取得アクセスクラス
// プログラム概要   : ハンディターミナル発注先ガイド情報取得アクセスクラスです
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

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナル発注先ガイド情報取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル発注先ガイド情報取得アクセスクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    public class HandySupplierGuideAcs
    {
        #region [定数]
        // 情報取得が正常に終了したステータス
        private const int StatusNomal = 0;
        // ﾛｸﾞｲﾝIDが見つからないステータス
        private const int StatusNotFound = 4;
        // 読込時のタイムアウトステータス
        private const int StatusTimeout = 5;
        // DB処理等でエラーが発生したステータス
        private const int StatusError = -1;
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNamePgid = "PMHND04300A_";
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
        public HandySupplierGuideAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [ハンディターミナル発注先ガイド情報取得処理]
        /// <summary>
        /// ハンディターミナル発注先ガイド情報取得処理
        /// </summary>
        /// <param name="paraHandySupplierGuideCondObj">検索条件オブジェクト</param>
        /// <param name="resultHandySupplierGuideObj">検索結果オブジェクト</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル発注先ガイド情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandySupplierGuide(ref object paraHandySupplierGuideCondObj, out object resultHandySupplierGuideObj)
        {
            resultHandySupplierGuideObj = null;
            int status = StatusError;

            // 検索条件
            SupplierGuideParamWork supplierGuideParamWork = paraHandySupplierGuideCondObj as SupplierGuideParamWork;

            // パラメータがnullの場合、
            if (supplierGuideParamWork == null)
            {
                // ログ出力します。
                this.WriteLog(supplierGuideParamWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // パラメータチェック
                // 入力パラメータ「企業コード、従業員コード、コンピュータ名」は空がある場合、エラーを戻ります。
                if (string.IsNullOrEmpty(supplierGuideParamWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(supplierGuideParamWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(supplierGuideParamWork.MachineName.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(supplierGuideParamWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region ハンディターミナル発注先ガイド情報を取得する
                // リモート取得
                IHandySupplierGuideDB iHandySupplierGuideDB = (IHandySupplierGuideDB)MediationHandySupplierGuideDB.GetHandySupplierGuideDB();

                // ハンディターミナルログイン情報取得リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(supplierGuideParamWork);

                status = iHandySupplierGuideDB.Search(condByte, out resultHandySupplierGuideObj);

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
                this.WriteLog(supplierGuideParamWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                //　処理なし。
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// エラーログ出力処理
        /// </summary>
        /// <param name="supplierGuideParamWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void WriteLog(SupplierGuideParamWork supplierGuideParamWork, string errMsg)
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
                if (supplierGuideParamWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + supplierGuideParamWork.EnterpriseCode);
                    // 従業員コード
                    writer.WriteLine(EmployeeCode + supplierGuideParamWork.EmployeeCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + supplierGuideParamWork.MachineName);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

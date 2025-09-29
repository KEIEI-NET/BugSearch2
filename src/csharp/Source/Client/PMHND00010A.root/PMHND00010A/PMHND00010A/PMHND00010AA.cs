//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナルログイン情報取得アクセスクラス
// プログラム概要   : ハンディターミナルログイン情報取得アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : ハンディターミナル二次開発の対応
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 岸
// 作 成 日  2020/04/08  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ハンディターミナルログイン情報取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナルログイン情報取得アクセスクラスです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br>Update Note: 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>           : ハンディターミナル二次開発の対応</br>
    /// </remarks>
    public class HandyLoginInfoAcs
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
        private const string DefaultNamePgid = "PMHND00010A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>企業コード</summary>
        private const string EnterpriseCode = "企業コード:";
        /// <summary>ログインID</summary>
        private const string LoginId = "ログインID:";
        /// <summary>コンピュータ名</summary>
        private const string MachineName = "コンピュータ名:";
        /// <summary>パラメータnullメッセージ</summary>
        private const string ErrorMsgNull = "検索条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ErrorMsgParam = "入力パラメータエラーが発生しました。";

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>オプションOFF「0:OFF(使用不可)」</summary>
        private const int OptionOff = 0;
        /// <summary>オプションON「1:ON(使用可)」</summary>
        private const int OptionOn = 1;
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<
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
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public HandyLoginInfoAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ハンディターミナルログイン情報取得処理
        /// </summary>
        /// <param name="condObj">検索条件オブジェクト</param>
        /// <param name="retObj">検索結果オブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナルログイン情報を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// <br>Update Note: 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>管理番号   : 11370074-00</br>
        /// <br>           : ハンディターミナル二次開発の対応</br>
        /// </remarks>
        public int SearchHandyLoginInfo(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // 検索条件
            HandyLoginInfoCondWork handyLoginInfoCondWork = condObj as HandyLoginInfoCondWork;
            // パラメータがnullの場合、
            if (handyLoginInfoCondWork == null)
            {
                // ログ出力します。
                this.WriteLog(handyLoginInfoCondWork, ErrorMsgNull);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目チェック
                if (string.IsNullOrEmpty(handyLoginInfoCondWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(handyLoginInfoCondWork.LoginId.Trim())
                    || string.IsNullOrEmpty(handyLoginInfoCondWork.MachineName.Trim()))
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(handyLoginInfoCondWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region ログイン情報を取得する
                // リモート取得
                IHandyLoginInfoDB iHandyLoginInfoDB = (IHandyLoginInfoDB)MediationHandyLoginInfoDB.GetHandyLoginInfoDB();

                // ハンディターミナルログイン情報取得リモート呼び出し
                byte[] condByte = XmlByteSerializer.Serialize(handyLoginInfoCondWork);
                byte[] retByte = null;

                status = iHandyLoginInfoDB.Search(condByte, out retByte);

                // 情報取得が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 返却パラメータセット
                    object handyLoginInfoWorkObj = XmlByteSerializer.Deserialize(retByte, typeof(HandyLoginInfoWork));

                    // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
                    HandyLoginInfoWork handyLoginInfoWork = (HandyLoginInfoWork)handyLoginInfoWorkObj;

                    // 仕入支払管理「0:OFF(使用不可) 1:ON(使用可)」
                    PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.SupPayManageOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.SupPayManageOp = OptionOff;
                    }

                    // ハンディOP(社内)「0:OFF(使用不可) 1:ON(使用可)」
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Company);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.HandyHouOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.HandyHouOp = OptionOff;
                    }

                    // ハンディOP(仕入)「0:OFF(使用不可) 1:ON(使用可)」
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Stock);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.HandySupOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.HandySupOp = OptionOff;
                    }

                    // --- ADD 2020/04/08 ---------->>>>>
                    // ハンディOP(在庫登録)「0:OFF(使用不可) 1:ON(使用可)」
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InsStock);
                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        handyLoginInfoWork.HandyZaikoRegistOp = OptionOn;
                    }
                    else
                    {
                        handyLoginInfoWork.HandyZaikoRegistOp = OptionOff;
                    }
                    // --- ADD 2020/04/08 ----------<<<<<

                    retObj = handyLoginInfoWorkObj;
                    // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

                    status = StatusNomal;
                }
                // ﾛｸﾞｲﾝIDが見つからない場合
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
                this.WriteLog(handyLoginInfoCondWork, ex.ToString());
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
        /// <param name="handyLoginInfoCondWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(HandyLoginInfoCondWork handyLoginInfoCondWork, string errMsg)
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
                if (handyLoginInfoCondWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCode + handyLoginInfoCondWork.EnterpriseCode);
                    // ログインID
                    writer.WriteLine(LoginId + handyLoginInfoCondWork.LoginId);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyLoginInfoCondWork.MachineName);
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

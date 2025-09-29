//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 検品データ登録(先行検品)アクセスクラス
// プログラム概要   : 検品データ登録(先行検品)アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/06/30  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 検品データ登録(先行検品)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品データ登録(先行検品)アクセスクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/06/30</br>
    /// </remarks>
    public class HandySenKouInspectAcs
    {
        #region [定数]
        // 登録処理が正常に終了したステータス
        private const int NomalStatus = 0;
        // 登録処理がタイムアウトステータス
        private const int TimeoutStatus = 5;
        // DB処理等でエラーが発生したステータス
        private const int ErrorStatus = -1;
        // 在庫管理なしは"0"
        private const string Zero = "0";
        /// <summary>デフォルトエンコード</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>ログパス</summary>
        private const string LogPath = @"\Log\PMHND";
        /// <summary>デフォルトログファイル名称</summary>
        private const string PgId = "PMHND01010A_";
        /// <summary>デフォルトログファイル名称</summary>
        private const string File = ".log";
        /// <summary>デフォルトログファイル名称日期フォーマット</summary>
        private const string DefaultTime = "yyyyMMdd";
        /// <summary>デフォルトログ内容フォーマット</summary>
        private const string DefaultFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>企業コード</summary>
        private const string EnterpriseCod = "企業コード:";
        /// <summary>ログインID</summary>
        private const string LoginId = "従業員コード:";
        /// <summary>コンピュータ名</summary>
        private const string MachineName = "コンピュータ名:";
        /// <summary>商品メーカーコード</summary>
        private const string GoodsMakerCd = "商品メーカーコード:";
        /// <summary>商品番号</summary>
        private const string GoodsNo = "商品番号:";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCode = "倉庫コード:";
        /// <summary>検品区分</summary>
        private const string InspectCode = "検品区分:";
        /// <summary>検品数</summary>
        private const string InspectCnt = "検品数:";
        /// <summary>パラメータnullメッセージ</summary>
        private const string ConditionsError = "登録条件がnullです。";
        /// <summary>パラメータエラーメッセージ</summary>
        private const string ParametersError = "入力パラメータエラーが発生しました。";
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
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public HandySenKouInspectAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// 検品データ登録(先行検品)処理
        /// </summary>
        /// <param name="inspectDataObj">登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品データ(先行検品)を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int WriteSenKouInspect(object inspectDataObj)
        {
            int status = ErrorStatus;
            HandyInspectDataWork inspectDataWork = inspectDataObj as HandyInspectDataWork;
            // パラメータがnullの場合、
            if (inspectDataWork == null)
            {
                // ログ出力します。
                this.WriteLog(null, ConditionsError);
                return status;
            }
            // パラメータがnullではない場合、パラメータをチェックします。
            else
            {
                // 必須入力項目のチェック
                if (String.IsNullOrEmpty(inspectDataWork.MachineName.Trim()) ||            // コンピュータ名
                    String.IsNullOrEmpty(inspectDataWork.EmployeeCode.Trim()) ||           // 従業員コード
                    (inspectDataWork.GoodsMakerCd <= 0) ||           // メーカーコード
                    String.IsNullOrEmpty(inspectDataWork.GoodsNo.Trim()))                  // 商品番号
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ParametersError);
                    return status;
                }

                // 桁のチェック
                if (inspectDataWork.GoodsMakerCd > 999999 ||
                    inspectDataWork.GoodsNo.Length > 40 ||
                    inspectDataWork.WarehouseCode.Length > 6 ||
                    inspectDataWork.InspectCode > 9999 ||
                    inspectDataWork.InspectCnt > 99999999 ||
                    inspectDataWork.MachineName.Length > 20 ||
                    inspectDataWork.EmployeeCode.Length > 9)
                {
                    // エラーメッセージに引数の名前と値をログ出力します。
                    this.WriteLog(inspectDataWork, ParametersError);
                    return status;
                }
               
                inspectDataWork.AcPaySlipNum = string.Empty;
                // 受払元伝票区分(20:売上)
                inspectDataWork.AcPaySlipCd = 20;

                // 受払元行番号(0)
                inspectDataWork.AcPaySlipRowNo = 0;

                // 受払元取引区分(11)
                inspectDataWork.AcPayTransCd = 11;

                // 倉庫コード　(空の時は"0")
                if (String.IsNullOrEmpty(inspectDataWork.WarehouseCode))
                {
                    inspectDataWork.WarehouseCode = Zero;
                }

                // 検品ステータス(3:検品済み)
                inspectDataWork.InspectStatus = 3;

                // ハンディターミナル区分:固定値(1:ハンディターミナル)
                inspectDataWork.HandTerminalCode = 1;
            }
            try
            {
                // リモート取得
                IInspectDataDB iHandyInspectDB = (IInspectDataDB)MediationInspectDataDB.GetDeleteInspectDataDB();
                status = iHandyInspectDB.WriteInspectData(ref inspectDataObj, 1);

                // 登録処理が正常に終了した場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = NomalStatus;
                }
                // 登録処理がタイムアウトの場合
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = TimeoutStatus;
                }
                // DB処理等でエラーが発生した場合
                else
                {
                    status = ErrorStatus;
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージに引数の名前と値をログ出力します。
                this.WriteLog(inspectDataWork, ex.ToString());
                status = ErrorStatus;
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
        /// <param name="handyInspectDataWork">検索条件オブジェクト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       : エラーログ情報を出力します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        private void WriteLog(HandyInspectDataWork handyInspectDataWork, string errMsg)
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
                if (handyInspectDataWork != null)
                {
                    // 企業コード
                    writer.WriteLine(EnterpriseCod + handyInspectDataWork.EnterpriseCode);
                    // コンピュータ名
                    writer.WriteLine(MachineName + handyInspectDataWork.MachineName);
                    // ログインID
                    writer.WriteLine(LoginId + handyInspectDataWork.EmployeeCode);
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
                }
                // ファイルストリームがnullではない場合、
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}

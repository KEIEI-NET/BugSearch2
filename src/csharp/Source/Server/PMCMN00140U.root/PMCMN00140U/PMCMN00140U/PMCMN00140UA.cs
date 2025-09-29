//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新
// プログラム概要   : コンバート対象自動更新エントリポイント実装クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 佐々木亘
// 作 成 日  2020/06/15   修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------------//
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// コンバート対象自動更新メイン エントリ ポイント実装クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新のメイン エントリ ポイントを実装するクラスの定義と実装</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// </remarks>
    static class PMCMN00140U
    {
        #region 型宣言


        #endregion //型宣言

        #region 定数定義

        /// <summary>
        /// コンバート対象判定　コンバート対象
        /// </summary>
        private const bool CONVOBJ_ON = true;

        /// <summary>
        /// コンバート対象判定　コンバート対象外
        /// </summary>
        private const bool CONVOBJ_OFF = false;

        /// <summary>
        /// コンバート対象バージョン管理共通部品 認証オプション ON
        /// </summary>
        private const bool PMCINFO_ON = true;

        /// <summary>
        /// コンバート対象バージョン管理共通部品 認証オプション OFF
        /// </summary>
        private const bool PMCINFO_OFF = false;

        /// <summary>
        /// 起動パラメータ：スケジューラ
        /// </summary>
        private const string ARGS_Scheduler = "Scheduler";

        /// <summary>
        /// 起動パラメータ：配信
        /// </summary>
        private const string ARGS_Delivery = "Delivery";

        /// <summary>
        /// 起動モード：パラメータなし
        /// </summary>
        private const int MODE_None = 0;

        /// <summary>
        /// 起動モード：スケジューラ
        /// </summary>
        private const int MODE_Scheduler = 1;

        /// <summary>
        /// 起動モード：配信
        /// </summary>
        private const int MODE_Delivery = 2;

        /// <summary>
        /// USER_APレジストリキー　ルート
        /// </summary>
        private const string RegistryKeyUSER_APMain = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// USER_APレジストリキー　作業パス
        /// </summary>
        private const string RegistryKeyUSER_APInstallDirectory = "InstallDirectory";

        /// <summary>
        /// 作業パスデフォルト
        /// </summary>
        private const string WorkingDirDefault = @"C:\Program Files\Partsman\USER_AP";

        /// <summary>
        /// 操作ログ　開始
        /// </summary>
        private const string OperationLogTextAutoStart = "自動起動";

        /// <summary>
        /// 操作ログ　終了
        /// </summary>
        private const string OperationLogTextAutoEnd = "終了（自動起動時）";

        /// <summary>
        /// 操作ログ　スケジューラー
        /// </summary>
        private const string OperationLogTextScheduler = "スケジューラ";

        /// <summary>
        /// 操作ログ　配信
        /// </summary>
        private const string OperationLogTextDelivery = "配信";

        /// <summary>
        /// テキストログ　ログイン情報取得例外
        /// </summary>
        private const string LoggingTextGetLoginInfoErr = "ログイン情報取得失敗 ";

        /// <summary>
        /// テキストログ　ログイン情報取得例外
        /// </summary>
        private const string LoggingTextGetLoginInfoException = "catch() ログイン情報取得失敗 ";

        /// <summary>
        /// テキストログ　自動更新例外
        /// </summary>
        private const string LoggingTextGetAutoUpdateException = "catch() 自動更新失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象自動起動パラメータ不正
        /// </summary>
        private const string LoggingTextGetConvObjAutoExecParamErr = "コンバート対象自動起動パラメータ不正 ";

        /// <summary>
        /// テキストログ　コンバート対象バージョン管理呼出例外
        /// </summary>
        private const string LoggingTextGetConvObjVerMngException = "catch() コンバート対象バージョン管理呼出失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象判定例外
        /// </summary>
        private const string LoggingTextGetConvertObjEvalException = "catch() コンバート対象判定失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象自動更新例外
        /// </summary>
        private const string LoggingTextGetAutoExecException = "catch() コンバート対象自動更新失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象更新失敗
        /// </summary>
        private const string LoggingTextGetConvObjUpdateException = "コンバート対象更新失敗 ";

        /// <summary>
        /// テキストログ　自動更新実行判定
        /// </summary>
        private const string LoggingTextGetAutoUpdateExecException = "自動更新実行失敗 ";

        /// <summary>
        /// テキストログ　サービス起動失敗
        /// </summary>
        private const string LoggingTextGetServiceStartException = "サービス起動失敗 ";

        #endregion //定数定義

        #region プライベートフィールド

        /// <summary>
        /// パラメータ
        /// </summary>
        private static ConvObjDBParam codbp = null;

        /// <summary>
        /// ログ出力
        /// </summary>
        private static LogInfoAllCls logInfoAllCls = null;

        /// <summary>
        /// コンバート対象自動更新リモートオブジェクトインターフェース
        /// </summary>
        private static IConvObjDB IConvertObjectDB = null;

        /// <summary>
        /// サービス名
        /// </summary>
        private static string[] services = new string[1] { "PM001ServerService" };

        #endregion //プライベートフィールド

        #region メンバーフィールド
        /// <summary>
        /// 起動パラメータ一時保持領域
        /// </summary>
        private static string[] ExecParameter;
        #endregion //メンバーフィールド

        /// <summary>
        /// コンバート対象自動更新メイン エントリ ポイント
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新の起動時に実行されるメイン エントリ ポイント</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            // ２重起動チェック
            if (Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                WriteClcLog(string.Format("{0}", "ERR PMCMN00140UA Main Process Double Boot"));
                return;
            }

            int statusMethodColl = (int)ConvObjParam.StatusCode.Error;
            int statusConvObjAutoExec = (int)ConvObjParam.StatusCode.Error;
            int status = (int)ConvObjParam.StatusCode.Error;
            string msg = string.Empty;
            string workDir = null;
            int execMode = MODE_None;

            // パラメータ
            codbp = new ConvObjDBParam();

            PMCMN00140U.ExecParameter = args;

            // 起動モード
            if (PMCMN00140U.ExecParameter.Length > 0)
            {
                switch (PMCMN00140U.ExecParameter[0])
                {
                    case ARGS_Scheduler:  // スケジューラ
                        execMode = MODE_Scheduler;
                        break;
                    case ARGS_Delivery:  // 配信
                        execMode = MODE_Delivery;
                        break;
                    default:
                        break;
                }
            }
            else
            {
#if DEBUG
                execMode = MODE_Scheduler;
#endif
            }

            // レジストリキー取得
            RegistryKey key = Registry.LocalMachine.OpenSubKey(PMCMN00140U.RegistryKeyUSER_APMain);

            // 作業ディレクトリ取得
            if (key == null) // あってはいけないケース
            {
                workDir = PMCMN00140U.WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
            }
            else
            {
                workDir = key.GetValue(PMCMN00140U.RegistryKeyUSER_APInstallDirectory, PMCMN00140U.WorkingDirDefault).ToString();
            }

            try
            {
                System.IO.Directory.SetCurrentDirectory(workDir);
                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                statusMethodColl = ServerApplicationMethodCallControl.StartApplication(out msg, ref ExecParameter, ConstantManagement_SF_PRO.ProductCode);

                if (statusMethodColl != (int)ConvObjParam.StatusCode.Normal)
                {
                    // CLCログ出力
                    WriteClcLog(string.Format("{0},{1},statusMethodColl:{2},msg:{3}", "ERR PMCMN00140UA Main", PMCMN00140U.LoggingTextGetLoginInfoErr, statusMethodColl.ToString(), msg), statusMethodColl);
                }

            }
            catch (Exception ex)
            {
                statusMethodColl = (int)ConvObjParam.StatusCode.Error1001;
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},{1},statusMethodColl:{2},msg:{3}", "ERR PMCMN00140UA Main Exception", PMCMN00140U.LoggingTextGetLoginInfoException, statusMethodColl.ToString(), msg), statusMethodColl);
            }

            if (statusMethodColl == (int)ConvObjParam.StatusCode.Normal)
            {
                // 起動パラメータチェック
                if (execMode == MODE_None)
                {
                    statusMethodColl = (int)ConvObjParam.StatusCode.ParamErr;
                    // CLCログ出力
                    WriteClcLog(string.Format("{0},msg:{1},statusMethodColl:{2}", "ERR PMCMN00140UA Main", PMCMN00140U.LoggingTextGetLoginInfoException, statusMethodColl.ToString()), statusMethodColl);
                }
            }

            try
            {
                if (statusMethodColl == (int)ConvObjParam.StatusCode.Normal)
                {
                    // 操作履歴ログ登録（コンバート対象自動更新 処理開始）
                    PMCMN00140U.WriteOperationLog(PMCMN00140U.OperationLogTextAutoStart, PMCMN00140U.OperationLogTextAutoStart, execMode.ToString());

                    // CLCログ出力（コンバート対象自動更新 処理開始）
                    WriteClcLog(PMCMN00140U.OperationLogTextAutoStart);

                    try
                    {
                        // サービス起動確認（リトライ対象）
                        if (CtlService(true))
                        {
                            // 自動起動時処理
                            statusConvObjAutoExec = PMCMN00140U.ConverObjAutoExec();

                            if ((statusConvObjAutoExec != (int)ConvObjParam.StatusCode.Normal) && (statusConvObjAutoExec != (int)ConvObjParam.StatusCode.NormalNotFound))
                            {
                                status = (int)ConvObjParam.StatusCode.Error1002;
                                // CLCログ出力
                                WriteClcLog(string.Format("{0},msg:{1},status:{2},statusConvObjAutoExec:{3}", "ERR PMCMN00140UA Main", PMCMN00140U.LoggingTextGetAutoUpdateExecException, status.ToString(), statusConvObjAutoExec.ToString()), statusConvObjAutoExec);
                            }
                            else
                            {
                                status = statusConvObjAutoExec;
                            }
                        }
                        else
                        {
                            status = (int)ConvObjParam.StatusCode.Error1013;
                            // CLCログ出力
                            WriteClcLog(string.Format("{0},msg:{1},status:{2},statusConvObjAutoExec:{3}", "ERR PMCMN00140UA Main CtlService サービス起動", PMCMN00140U.LoggingTextGetServiceStartException, status.ToString(), statusConvObjAutoExec.ToString()), statusConvObjAutoExec);
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjParam.StatusCode.Error1003;
                        // CLCログ出力
                        WriteClcLog(ex, string.Format("{0},msg:{1},status:{2},statusConvObjAutoExec:{3}", "ERR PMCMN00140UA Main Exception", PMCMN00140U.LoggingTextGetAutoUpdateException, status.ToString(), statusConvObjAutoExec.ToString()), statusConvObjAutoExec);
                    }
                    finally
                    {
                        // 操作履歴ログ登録（コンバート対象自動更新 処理終了）
                        PMCMN00140U.WriteOperationLog(PMCMN00140U.OperationLogTextAutoEnd, string.Format("{0}:statusConvObjAutoExec:{1}", PMCMN00140U.OperationLogTextAutoEnd, statusConvObjAutoExec.ToString()), execMode.ToString());

                        // CLCログ出力（コンバート対象自動更新 処理終了）
                        WriteClcLog(string.Format("{0}:statusConvObjAutoExec:{1} execMode:{2}", PMCMN00140U.OperationLogTextAutoEnd, statusConvObjAutoExec.ToString(), execMode.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConvObjParam.StatusCode.Error1004;
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},msg:{1},status:{2},statusMethodColl:{3}", "ERR PMCMN00140UA Main Exception", PMCMN00140U.LoggingTextGetConvObjVerMngException, status.ToString(), statusMethodColl.ToString()), statusMethodColl);
            }
        }

        /// <summary>
        /// コンバート対象自動更新　実体
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 自動起動時のコンバート対象自動更新を実行</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static int ConverObjAutoExec()
        {
            int status = (int)ConvObjParam.StatusCode.Error1010;
            int statusConvObjAutoUpdate = (int)ConvObjParam.StatusCode.Error1010;

            if (IConvertObjectDB == null)
            {
                // コンバート対象自動更新リモートオブジェクト
                IConvertObjectDB = (IConvObjDB)MediationConvObjDB.GetConvObjDB();
            }

            try
            {
                // 抽出条件設定
                ConvObjWork convObjWork = new ConvObjWork();

                convObjWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                statusConvObjAutoUpdate = IConvertObjectDB.ConvObjAutoUpdate(ref convObjWork);
                if (statusConvObjAutoUpdate == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConvObjParam.StatusCode.Normal;
                }
                else if (statusConvObjAutoUpdate == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConvObjParam.StatusCode.NormalNotFound;
                }
                else
                {
                    status = (int)ConvObjParam.StatusCode.Error1011;
                    // CLCログ出力
                    WriteClcLog(string.Format("{0},msg:{1},status:{2},statusConvObjAutoUpdate:{3}", "ERR PMCMN00140UA ConverObjAutoExec", PMCMN00140U.LoggingTextGetConvObjUpdateException, status.ToString(), statusConvObjAutoUpdate.ToString()), statusConvObjAutoUpdate);
                }
            }
            catch (Exception ex)
            {
                // 例外エラー
                status = (int)ConvObjParam.StatusCode.Error1012;
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},msg:{1},status:{2},statusConvObjAutoUpdate:{3}", "ERR PMCMN00140UA ConverObjAutoExec Exception", PMCMN00140U.LoggingTextGetAutoExecException, status.ToString(), statusConvObjAutoUpdate.ToString()), statusConvObjAutoUpdate);
            }
            finally
            {
            }

            return status;
        }

        #region PM.NSログ
        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="errorText">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteClcLog(string errorText)
        {
            WriteClcLog(null, errorText, 0);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteClcLog(string errorText, int status)
        {
            WriteClcLog(null, errorText, status);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteClcLog(Exception ex, string errorText)
        {
            WriteClcLog(ex, errorText, 0);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteClcLog(Exception ex, string errorText, int status)
        {
            string message = string.Empty;

            if (logInfoAllCls == null)
            {
                logInfoAllCls = new LogInfoAllCls();
            }
            try
            {
                if (ex != null)
                {
                    message = string.Format("{0},ex:{1}", errorText, ex.Message);
                }
                else
                {
                    message = string.Format("{0}", errorText);
                }
                // CLCログ
                logInfoAllCls.ClcLogOutput(string.Format("{0},status:{1}", message, status.ToString()));
            }
            catch (Exception exp)
            {
                // Serverログ出力
                logInfoAllCls.WriteErrorServerLog(exp, string.Format("errorText:{0},message:{1}", errorText, message), status);
            }
        }

        /// <summary>
        /// オペレーションログ出力
        /// </summary>
        /// <param name="processName">処理名称</param>
        /// <param name="stepName">処理区分</param>
        /// <param name="data">更新内容</param>
        /// <remarks>
        /// <br>Note       : 引数の内容でオペレーションログに操作ログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteOperationLog(string processName, string stepName, string data)
        {
            if (logInfoAllCls == null)
            {
                logInfoAllCls = new LogInfoAllCls();
            }

            try
            {
                // Serverログ出力
                logInfoAllCls.WriteOperationLog(processName, stepName, data);
            }
            catch (Exception ex)
            {
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},processName:{1},stepName:{2},data:{3}", "ERR PMCMN00140UA WriteOperationLog Exception", processName, stepName, data));
            }
        }
        #endregion //PM.NSログ

        #region サービス開始・停止


        /// <summary>
        /// PM.NS系サービスの開始・停止を行う。
        /// </summary>
        /// <param name="flg">True:開始 False:停止</param>
        /// <returns>True:成功 False:失敗</returns>
        /// <remarks>
        /// <br>Note       : PM.NS系サービスの開始・停止を行う。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static bool CtlService(bool flg)
        {
            bool ret = true;

            int retryCnt = 0;

            // 正常終了するまでリトライ回数分リトライする
            while (retryCnt < codbp.RetryCount)
            {
                // リトライ時waitする
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);
                }

                try
                {
                    ret = CtlServiceProc(services, flg);
                }
                catch (Exception ex)
                {
                    ret = false;
                    // ログ出力
                    WriteClcLog(ex, string.Format("{0},[{1}],flg:{2}", "ERR PMCMN00140UA CtlService Exception", retryCnt.ToString(), flg ? "開始" : "停止"));
                }
                finally
                {
                    // 初期化
                }

                if (ret)
                {
                    // 正常終了のためリトライしない
                    break;
                }
                retryCnt += 1;
            }

            return ret;
        }

        /// <summary>
        /// PM.NS系サービスの開始・停止を行う。
        /// </summary>
        /// <param name="ser">処理対象のサービス名を含む配列</param>
        /// <param name="flg">True:開始 False:停止</param>
        /// <returns>True:成功 False:失敗</returns>
        /// <remarks>
        /// <br>Note       : PM.NS系サービスの開始・停止を行う。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static bool CtlServiceProc(string[] ser, bool flg)
        {
            bool ret = true;

            // サービス状態変更待機タイムアウト時間を3分に設定
            TimeSpan SERVICE_TIMEOUT_SEC = new TimeSpan(0, 3, 0);

            string service_name = string.Empty;

            if (ser.Length > 0)
            {
                try
                {
                    foreach (string str in ser)
                    {
                        service_name = str;

                        using (ServiceController sc = new ServiceController(str))
                        {
                            if (flg)
                            {
                                // 対象サービスの状態が実行中及び開始中以外の場合、サービスの開始処理を行う
                                if (sc.Status != ServiceControllerStatus.Running && sc.Status != ServiceControllerStatus.StartPending)
                                {
                                    // サービス開始
                                    sc.Start();
                                }

                                // 対象サービスの状態が実行中以外の場合、サービス状態変更待機を行う
                                if (sc.Status != ServiceControllerStatus.Running)
                                {
                                    try
                                    {
                                        sc.WaitForStatus(ServiceControllerStatus.Running, SERVICE_TIMEOUT_SEC);
                                    }
                                    catch (System.ServiceProcess.TimeoutException)
                                    {
                                        //タイムアウトの場合例外としない
                                    }

                                    // サービス状態変更待機後も実行中になっていない場合
                                    if (sc.Status != ServiceControllerStatus.Running)
                                    {
                                        ret = false;
                                        // CLCログ出力
                                        WriteClcLog(string.Format("{0},service_name:{1},Status:{2}", "ERR PMCMN00140UA CtlServiceProc サービス開始", service_name, sc.Status.ToString()));
                                    }
                                }
                            }
                            else
                            {
                                // 対象サービスの状態が停止及び停止中以外の場合、サービスの停止処理を行う
                                if (sc.Status != ServiceControllerStatus.Stopped && sc.Status != ServiceControllerStatus.StopPending)
                                {
                                    // サービス終了
                                    sc.Stop();
                                }

                                // 対象サービスの状態が停止以外の場合、サービス状態変更待機を行う
                                if (sc.Status != ServiceControllerStatus.Stopped)
                                {
                                    try
                                    {
                                        sc.WaitForStatus(ServiceControllerStatus.Stopped, SERVICE_TIMEOUT_SEC);
                                    }
                                    catch (System.ServiceProcess.TimeoutException)
                                    {
                                        //タイムアウトの場合例外としない
                                    }

                                    // サービス状態変更待機後も停止になっていない場合
                                    if (sc.Status != ServiceControllerStatus.Stopped)
                                    {
                                        ret = false;
                                        // CLCログ出力
                                        WriteClcLog(string.Format("{0},service_name:{1},Status:{2}", "ERR PMCMN00140UA CtlServiceProc サービス停止", service_name, sc.Status.ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ret = false;
                    // CLCログ出力
                    WriteClcLog(ex, string.Format("{0},service_name:{1},flg:{2}", "ERR PMCMN00140UA CtlServiceProc Exception", service_name, flg ? "開始" : "停止"));
                }
            }

            return ret;
        }
        #endregion //サービス開始・停止


    }
}
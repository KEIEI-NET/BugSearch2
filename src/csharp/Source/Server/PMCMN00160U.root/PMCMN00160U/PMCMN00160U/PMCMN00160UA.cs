//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動バックアップ
// プログラム概要   : コンバート対象自動バックアップエントリポイント実装クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 小原
// 作 成 日  2020/06/15   修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------------//
// 管理番号  11601223-00 作成担当 : 続木
// 修 正 日  2021/09/09  修正内容 : ローカルファイル削除漏れ、不要な例外出力抑止対応
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
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// コンバート対象自動バックアップメイン エントリ ポイント実装クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動バックアップのメイン エントリ ポイントを実装するクラスの定義と実装</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
    /// <br>Programmer : 続木</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>管理番号   : 11601223-00</br>
    /// </remarks>
    static class PMCMN00160U
    {
        #region 定数定義

        /// <summary>
        /// 起動パラメータ：サービス
        /// </summary>
        private const string ARGS_Service = "Service";

        /// <summary>
        /// 起動パラメータ：配信
        /// </summary>
        private const string ARGS_Delivery = "Delivery";

        /// <summary>
        /// 起動モード：パラメータなし
        /// </summary>
        private const int MODE_None = 0;

        /// <summary>
        /// 起動モード：サービス
        /// </summary>
        private const int MODE_Service = 1;

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
        private const string OperationLogTextAutoStart = "バックアップ自動起動";

        /// <summary>
        /// 操作ログ　終了
        /// </summary>
        private const string OperationLogTextAutoEnd = "終了（バックアップ自動起動時）";

        /// <summary>
        /// 操作ログ　サービス
        /// </summary>
        private const string OperationLogTextService = "サービス";

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
        /// テキストログ　バックアップ例外
        /// </summary>
        private const string LoggingTextGetAutoBkException = "catch() バックアップ失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象自動起動パラメータ不正
        /// </summary>
        private const string LoggingTextGetConvObjAutoExecParamErr = "コンバート対象自動起動パラメータ不正 ";

        /// <summary>
        /// テキストログ　コンバート対象バックアップ呼出例外
        /// </summary>
        private const string LoggingTextGetConvObjVerMngException = "catch() コンバート対象バックアップ呼出失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象自動バックアップ例外
        /// </summary>
        private const string LoggingTextGetAutoExecException = "catch() コンバート対象自動バックアップ失敗 ";

        /// <summary>
        /// テキストログ　コンバート対象バックアップ失敗
        /// </summary>
        private const string LoggingTextGetConvObjBkException = "コンバート対象バックアップ失敗 ";

        /// <summary>
        /// テキストログ　バックアップ実行判定
        /// </summary>
        private const string LoggingTextGetAutoBkExecException = "バックアップ実行失敗 ";

        /// <summary>
        /// テキストログ　サービス起動失敗
        /// </summary>
        private const string LoggingTextGetServiceStartException = "サービス起動失敗 ";

        /// <summary>
        /// テキストログ　初期処理失敗
        /// </summary>
        private const string LoggingTextInitException = "初期処理失敗 ";

        /// <summary>
        /// テキストログ　出力パス
        /// </summary>
        private const string LogTextOutputPath = @"\Log\PMCMN00160U";

        /// <summary>
        /// テキストログ　出力ファイル
        /// </summary>
        private const string LogTextOutputFile = @"\PMCMN00160UA.txt";

        /// <summary>
        /// 初回配信時判定ファイル
        /// </summary>
        private const string FirstDeliveryFile = @"\PMCMN00160U_Delivery.txt";


        #endregion //定数定義

        #region プライベートフィールド

        /// <summary>
        /// パラメータ
        /// </summary>
        private static ConvObjBkParam codbp = null;

        /// <summary>
        /// ログ出力
        /// </summary>
        private static LogInfoAllCls logInfoAllCls = null;

        /// <summary>
        /// コンバート対象自動バックアップリモートオブジェクトインターフェース
        /// </summary>
        private static IConvObjSingleBkDB _iConvObjSingleDB = null;

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

        /// <summary>
        /// 起動モード
        /// </summary>
        private static int _execMode;

        /// <summary>
        /// 実行フォルダ
        /// </summary>
        private static string _workDir;

        #endregion //メンバーフィールド

        /// <summary>
        /// コンバート対象自動バックアップメイン エントリ ポイント
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : コンバート対象自動バックアップの起動時に実行されるメイン エントリ ポイント</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        [STAThread]
        static void Main(String[] args)
        {
            int statusMethodColl = (int)ConvObjBkParam.StatusCode.Error;
            int statusConvObjAutoExec = (int)ConvObjBkParam.StatusCode.Error;
            int status = (int)ConvObjBkParam.StatusCode.Error;
            string msg = string.Empty;
            _execMode = MODE_None;

            try
            {
                // パラメータ
                codbp = new ConvObjBkParam();

                // ２重起動チェック
                if (Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    WriteClcLog(string.Format("{0}", "ERR PMCMN00160UA Main Process Double Boot"));
                    return;
                }

                PMCMN00160U.ExecParameter = args;

                // 起動モード
                if (PMCMN00160U.ExecParameter.Length > 0)
                {
                    switch (PMCMN00160U.ExecParameter[0])
                    {
                        case ARGS_Service:  // サービス
                            _execMode = MODE_Service;
                            break;
                        case ARGS_Delivery:  // 配信
                            _execMode = MODE_Delivery;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
#if DEBUG
                _execMode = MODE_Service;
#endif
                }

                // レジストリキー取得
                RegistryKey key = Registry.LocalMachine.OpenSubKey(PMCMN00160U.RegistryKeyUSER_APMain);

                // 作業ディレクトリ取得
                if (key == null) // あってはいけないケース
                {
                    _workDir = PMCMN00160U.WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    _workDir = key.GetValue(PMCMN00160U.RegistryKeyUSER_APInstallDirectory, PMCMN00160U.WorkingDirDefault).ToString();
                }
            }
            catch (Exception ex)
            {
                WriteAutoexcuteLog(string.Format("{0},ex:{1}", LoggingTextInitException, ex.ToString()));
            }


            try
            {
                System.IO.Directory.SetCurrentDirectory(_workDir);
                //アプリケーション開始準備処理
                //第二パラメータはアプリケーションのソフトウェアコードが指定できる場合は未定。出来ない場合はプロダクトコード
                statusMethodColl = ServerApplicationMethodCallControl.StartApplication(out msg, ref ExecParameter, ConstantManagement_SF_PRO.ProductCode);

                if (statusMethodColl != (int)ConvObjBkParam.StatusCode.Normal)
                {
                    // CLCログ出力
                    WriteClcLog(string.Format("{0},{1},statusMethodColl:{2},msg:{3}", "ERR PMCMN00160UA Main", PMCMN00160U.LoggingTextGetLoginInfoErr, statusMethodColl.ToString(), msg), statusMethodColl);
                }

            }
            catch (Exception ex)
            {
                statusMethodColl = (int)ConvObjBkParam.StatusCode.Error1001;
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},{1},statusMethodColl:{2},msg:{3}", "ERR PMCMN00160UA Main Exception", PMCMN00160U.LoggingTextGetLoginInfoException, statusMethodColl.ToString(), msg), statusMethodColl);
            }

            if (statusMethodColl == (int)ConvObjBkParam.StatusCode.Normal)
            {
                // 起動パラメータチェック
                if (_execMode == MODE_None)
                {
                    statusMethodColl = (int)ConvObjBkParam.StatusCode.ParamErr;
                    // CLCログ出力
                    WriteClcLog(string.Format("{0},msg:{1},statusMethodColl:{2}", "ERR PMCMN00160UA Main", PMCMN00160U.LoggingTextGetLoginInfoException, statusMethodColl.ToString()), statusMethodColl);
                }
            }

            try
            {
                // 配信時の複数回サービス再起動を考慮し、開始前に一定時間待機する
                if (codbp.BkCreateWait > 0)
                {
                    Thread.Sleep(codbp.BkCreateWait);
                }

                // 操作履歴ログ登録（コンバート対象自動バックアップ 処理開始）
                PMCMN00160U.WriteOperationLog(PMCMN00160U.OperationLogTextAutoStart, PMCMN00160U.OperationLogTextAutoStart, _execMode.ToString());

                // CLCログ出力（コンバート対象自動バックアップ 処理開始）
                WriteClcLog(PMCMN00160U.OperationLogTextAutoStart);

                try
                {
                    // サービス起動確認
                    if (CtlService(true))
                    {
                        // 自動起動時処理
                        statusConvObjAutoExec = PMCMN00160U.ConverObjAutoExec();

                        if ((statusConvObjAutoExec != (int)ConvObjBkParam.StatusCode.Normal) && (statusConvObjAutoExec != (int)ConvObjBkParam.StatusCode.NormalNotFound))
                        {
                            status = (int)ConvObjBkParam.StatusCode.Error1002;
                            // CLCログ出力
                            WriteClcLog(string.Format("{0},msg:{1},status:{2},statusConvObjAutoExec:{3}", "ERR PMCMN00160UA Main", PMCMN00160U.LoggingTextGetAutoBkExecException, status.ToString(), statusConvObjAutoExec.ToString()), statusConvObjAutoExec);
                        }
                        else
                        {
                            status = statusConvObjAutoExec;
                        }
                    }
                    else
                    {
                        status = (int)ConvObjBkParam.StatusCode.Error1013;
                        // CLCログ出力
                        WriteClcLog(string.Format("{0},msg:{1},status:{2},statusConvObjAutoExec:{3}", "ERR PMCMN00160UA Main CtlService サービス起動", PMCMN00160U.LoggingTextGetServiceStartException, status.ToString(), statusConvObjAutoExec.ToString()), statusConvObjAutoExec);
                    }

                }
                catch (Exception ex)
                {
                    status = (int)ConvObjBkParam.StatusCode.Error1003;
                    // CLCログ出力
                    WriteClcLog(ex, string.Format("{0},msg:{1},status:{2},statusConvObjAutoExec:{3}", "ERR PMCMN00160UA Main Exception", PMCMN00160U.LoggingTextGetAutoBkException, status.ToString(), statusConvObjAutoExec.ToString()), statusConvObjAutoExec);
                }

            }
            catch (Exception ex)
            {
                status = (int)ConvObjBkParam.StatusCode.Error1004;
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},msg:{1},status:{2},statusMethodColl:{3}", "ERR PMCMN00160UA Main Exception", PMCMN00160U.LoggingTextGetConvObjVerMngException, status.ToString(), statusMethodColl.ToString()), statusMethodColl);
            }
            finally
            {
                // 操作履歴ログ登録（コンバート対象自動バックアップ 処理終了）
                PMCMN00160U.WriteOperationLog(PMCMN00160U.OperationLogTextAutoEnd, string.Format("{0}:statusConvObjAutoExec:{1}", PMCMN00160U.OperationLogTextAutoEnd, statusConvObjAutoExec.ToString()), _execMode.ToString());

                // CLCログ出力（コンバート対象自動バックアップ 処理終了）
                WriteClcLog(string.Format("{0}:statusConvObjAutoExec:{1} execMode:{2}", PMCMN00160U.OperationLogTextAutoEnd, statusConvObjAutoExec.ToString(), _execMode.ToString()));
            }
        }

        /// <summary>
        /// コンバート対象自動バックアップ　実体
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 自動起動時のコンバート対象自動バックアップを実行</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
        /// <br>Programmer : 続木</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        private static int ConverObjAutoExec()
        {
            int status = (int)ConvObjBkParam.StatusCode.Error1010;
            int statusConvObjAutoUpdate = (int)ConvObjBkParam.StatusCode.Error1010;

            if (_iConvObjSingleDB == null)
            {
                // コンバート対象自動バックアップリモートオブジェクト
                _iConvObjSingleDB = (IConvObjSingleBkDB)MediationConvObjSingleBkDB.GetConvObjSingleBkDB();
            }

            try
            {
                // 抽出条件設定
                ConvObjSingleBkWork convObjSingleBkWork = new ConvObjSingleBkWork();

                convObjSingleBkWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                convObjSingleBkWork.BkFileName = string.Empty;
                int retryCnt = 0;

                // 初回配信時判定ファイルが存在する場合削除する
                string firstDeliveryPath = _workDir + FirstDeliveryFile;
                if (File.Exists(firstDeliveryPath))
                {
                    File.Delete(firstDeliveryPath);
                }

                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= codbp.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(codbp.RetryInterval);
                    }

                    statusConvObjAutoUpdate = _iConvObjSingleDB.ConvObjSingleBackupExec(ref convObjSingleBkWork);
                    if (statusConvObjAutoUpdate == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                    {
                        status = (int)ConvObjBkParam.StatusCode.Normal;
                        // 正常終了のためリトライしない
                        break;
                    }
                    else if (statusConvObjAutoUpdate == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                    {
                        status = (int)ConvObjBkParam.StatusCode.NormalNotFound;
                        // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
                        break;
                        // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<
                    }
                    else
                    {
                        status = (int)ConvObjBkParam.StatusCode.Error1011;
                        // CLCログ出力
                        WriteClcLog(string.Format("{0},msg:{1},status:{2},statusConvObjAutoUpdate:{3}", "ERR PMCMN00160UA ConverObjAutoExec", PMCMN00160U.LoggingTextGetConvObjBkException, status.ToString(), statusConvObjAutoUpdate.ToString()), statusConvObjAutoUpdate);
                    }

                    retryCnt += 1;
                }

            }
            catch (Exception ex)
            {
                // 例外エラー
                status = (int)ConvObjBkParam.StatusCode.Error1012;
                // CLCログ出力
                WriteClcLog(ex, string.Format("{0},msg:{1},status:{2},statusConvObjAutoUpdate:{3}", "ERR PMCMN00160UA ConverObjAutoExec Exception", PMCMN00160U.LoggingTextGetAutoExecException, status.ToString(), statusConvObjAutoUpdate.ToString()), statusConvObjAutoUpdate);
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
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteClcLog(string errorText)
        {
            WriteClcLog(new Exception(string.Empty), errorText, 0);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteClcLog(string errorText, int status)
        {
            WriteClcLog(new Exception(string.Empty), errorText, status);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 小原</br>
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
        /// <br>Programmer : 小原</br>
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
                // 配信時以外でCLCログ出力しない設定の場合終了する
                if (_execMode != MODE_Delivery)
                {
                    if (codbp != null)
                    {
                        if (codbp.ClcLogOutputInfo == (int)ConvObjBkParam.CLCOutputCode.Disable)
                        {
                            return;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(ex.Message))
                {
                    message = string.Format("{0},ex:{1}", errorText, ex.ToString());
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
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteOperationLog(string processName, string stepName, string data)
        {
            // 配信時以外は出力しない
            if (_execMode != MODE_Delivery)
            {
                return;
            }

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
                WriteClcLog(ex, string.Format("{0},processName:{1},stepName:{2},data:{3}", "ERR PMCMN00160UA WriteOperationLog Exception", processName, stepName, data));
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
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static bool CtlService(bool flg)
        {
            bool ret = true;

            try
            {
                ret = CtlServiceProc(services, flg);
            }
            catch (Exception ex)
            {
                ret = false;
                // ログ出力
                WriteClcLog(ex, string.Format("{0},flg:{2}", "ERR PMCMN00160UA CtlService Exception", flg ? "開始" : "停止"));
            }
            finally
            {
                // 初期化
            }

            return ret;
        }

        /// <summary>
        /// PM.NS系サービスの状態を確認。
        /// </summary>
        /// <param name="ser">処理対象のサービス名を含む配列</param>
        /// <param name="flg">True:開始 False:停止</param>
        /// <returns>True:成功 False:失敗</returns>
        /// <remarks>
        /// <br>Note       : PM.NS系サービスの開始・停止を行う。</br>
        /// <br>Programmer : 小原</br>
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
                                        WriteClcLog(string.Format("{0},service_name:{1},Status:{2}", "ERR PMCMN00160UA CtlServiceProc サービス開始", service_name, sc.Status.ToString()));
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
                                        WriteClcLog(string.Format("{0},service_name:{1},Status:{2}", "ERR PMCMN00160UA CtlServiceProc サービス停止", service_name, sc.Status.ToString()));
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
                    WriteClcLog(ex, string.Format("{0},service_name:{1},flg:{2}", "ERR PMCMN00160UA CtlServiceProc Exception", service_name, flg ? "開始" : "停止"));
                }
            }

            return ret;
        }
        #endregion //サービス開始・停止

        #region テキストログ出力
        /// <summary>
        /// テキストログ出力処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : テキストログ出力処理</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private static void WriteAutoexcuteLog(string errMessage)
        {
            string localWorkDir = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(_workDir))
                {
                    // レジストリキー取得
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(PMCMN00160U.RegistryKeyUSER_APMain);

                    // 作業ディレクトリ取得
                    if (key == null) // あってはいけないケース
                    {
                        localWorkDir = PMCMN00160U.WorkingDirDefault; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                    }
                    else
                    {
                        localWorkDir = key.GetValue(PMCMN00160U.RegistryKeyUSER_APInstallDirectory, PMCMN00160U.WorkingDirDefault).ToString();
                    }

                }
                else
                {
                    localWorkDir = _workDir;
                }

                string writePath = localWorkDir + LogTextOutputPath;
                if (!Directory.Exists(writePath))
                {
                    //ログ出力パスが生成されていなかった場合生成する
                    Directory.CreateDirectory(writePath);
                }

                StreamWriter writer = new StreamWriter(
                    writePath + LogTextOutputFile, true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.WriteLine(errMessage);
                writer.Flush();
                if (writer != null)
                    writer.Close();
            }
            catch
            {
                // ログ出力による例外は無視
            }
        }

        #endregion // テキストログ出力

    }
}
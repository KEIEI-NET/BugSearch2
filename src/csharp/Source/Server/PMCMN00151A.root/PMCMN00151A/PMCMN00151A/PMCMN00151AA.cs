//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 環境調査
// プログラム概要   : 環境調査アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 佐々木亘
// 作 成 日  2020/06/15   修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------------//
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 影響調査アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 影響調査のアクセス制御を行います。</br>
    /// <br>Programmer	: 佐々木亘</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvAcs
    {
        #region ■ Private Members

        #endregion ■ Private Members

        #region プライベートフィールド

        /// <summary>
        // パラメータ
        /// </summary>
        private static EnvSurvAcsParam esap = null;

        /// <summary>
        // 共通
        /// </summary>
        private static EnvSurvCommn esc = null;

        /// <summary>
        // データクラス
        /// </summary>
        private static EnvSurvDataParam esdp = null;

        /// <summary>
        /// 環境調査リモートオブジェクトインターフェース
        /// </summary>
        private static IEnvSurvObjDB iesod = null;

        #endregion //プライベートフィールド

        # region ■ Constructor

        /// <summary>
        /// 影響調査アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 影響調査アクセスクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvAcs()
        {
            try
            {
                // パラメータ
                esap = new EnvSurvAcsParam();

                // 共通クラス
                esc = new EnvSurvCommn();

                // データパラメータ
                esdp = new EnvSurvDataParam();

                // コンバート対象自動更新リモートオブジェクト
                iesod = (IEnvSurvObjDB)MediationEnvSurvObjDB.GetEnvSurvObjDB();

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
            }
        }

        #endregion ■ Constructor

        #region ■ Public Methods

        #region 影響調査ログ出力

        /// <summary>
        /// 影響調査ログ出力
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 調査結果を</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public int GetEnvSurvInfoLogOutput()
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            string logOutputMsg = string.Empty;

            try
            {
                // PC名を取得
                if (GetMachineNameInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // システム形態を取得
                if (GetSystemFormInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // CPU使用率を取得
                if (GetCpuUsageInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // メモリ使用量/容量を取得
                if (GetMemUsageCapInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // ディスク使用量/容量を取得
                if (GetDiskUsageCapInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // 全体バックアップ情報を取得
                if (GetFullBackupInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }

                // 価格マスタの件数を取得
                if (GetMstCountInfo(out logOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {
                    esdp.LogOutputMsg += logOutputMsg;
                }
                
                // CLCサーバへログ出力
                if (ClcLogOutput(esdp.LogOutputMsg) != (int)EnvSurvAcsParam.StatusCode.None)
                {

                }

                status = (int)EnvSurvAcsParam.StatusCode.Normal;
            }
            catch
            {
                status = (int)EnvSurvAcsParam.StatusCode.ExError;
            }

            return status;
        }

        #endregion // 影響調査ログ出力

        #endregion // ■ Public Methods

        #region ■ Private Methods

        #region PC名を取得する

        /// <summary>
        /// PC名を取得する。
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PC名を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetMachineNameInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string pcmn = string.Empty;

            int retryCnt = 0;

            // 取得判定
            if (esap.MachineNameInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // PC名取得
                        pcmn = Environment.MachineName;

                        if (!String.IsNullOrEmpty(pcmn))
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_PC, pcmn);
                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_PC, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_PC, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetMachineNameExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetMachineNameInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // PC名を取得する

        #region システム形態を取得する

        /// <summary>
        /// スタンドアロン、C/Sを判定
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : システム形態を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetSystemFormInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            RegistryKey registryKey = null;

            int retryCnt = 0;

            // 取得判定
            if (esap.SystemFormInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // クライアントレジストリ取得
                        registryKey = esc.GetRegistryKeyClient();
                        if (registryKey != null)
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_SYSFORM, EnvSurvAcsParam.LOGOUTPUT_SA);
                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_SYSFORM, EnvSurvAcsParam.LOGOUTPUT_CS);
                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_SYSFORM, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetSystemFormExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetSystemFormInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal || status == (int)EnvSurvAcsParam.StatusCode.NotFound)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }
            
            return status;
        }

        #endregion // システム形態を取得する

        #region CPU使用率を取得する

        /// <summary>
        /// CPU使用率を取得する
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : CPU使用率を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetCpuUsageInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string cpuUsage = string.Empty;

            int retryCnt = 0;

            // 取得判定
            if (esap.CpuUsageInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // CPU使用率取得
                        cpuUsage = esc.GetCpuCounter();
                        if (!String.IsNullOrEmpty(cpuUsage))
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_CPU, cpuUsage);
                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_CPU, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_CPU, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetCpuUsageExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetCpuUsageInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // CPU使用率を取得する

        #region メモリ使用量/容量を取得する

        /// <summary>
        /// メモリ使用量/容量を取得する
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メモリ使用量/容量を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetMemUsageCapInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string memUsageCap = string.Empty;

            int retryCnt = 0;

            // 取得判定
            if (esap.MemUsageInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // メモリ使用量/容量
                        memUsageCap = string.Format("{0}/{1}", esc.GetAvaliableMemory(), esc.GetTotalMemory());
                        if (!String.IsNullOrEmpty(memUsageCap))
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MEM, memUsageCap);
                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MEM, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MEM, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetMemUsageCapExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetMemUsageCapInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // メモリ使用量/容量を取得する

        #region ディスク使用量/容量を取得する

        /// <summary>
        /// ディスク使用量/容量を取得する
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ディスク使用量/容量を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDiskUsageCapInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string diskUsageCap = string.Empty;

            int retryCnt = 0;

            // 取得判定
            if (esap.DiskUsageInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        // ディスク使用量/容量
                        diskUsageCap = esc.GetAvaliableCapDisk();
                        if (!String.IsNullOrEmpty(diskUsageCap))
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_DISK, diskUsageCap);
                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_DISK, EnvSurvAcsParam.LOGOUTPUT_NA);
                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_DISK, EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetDiskUsageCapExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetDiskUsageCapInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // ディスク使用量/容量を取得する

        #region 全体バックアップ情報を取得する

        /// <summary>
        /// 全体バックアップ情報を取得する
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 全体バックアップ情報を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetFullBackupInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            object envFullBackupInfObj;

            int retryCnt = 0;

            // 取得判定
            if (esap.FullBackupInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        if (iesod == null)
                        {
                            // コンバート対象自動更新リモートオブジェクト
                            iesod = (IEnvSurvObjDB)MediationEnvSurvObjDB.GetEnvSurvObjDB();
                        }

                        // 
                        status = iesod.EnvFullBackupInfSearch(out envFullBackupInfObj);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {

                            foreach (EnvFullBackupInfWork envFullBackupInfWork in (ArrayList)envFullBackupInfObj)
                            {
                                // ログ出力内容格納
                                logOutputMsg = string.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP
                                    ,envFullBackupInfWork.DatabaseName
                                    ,envFullBackupInfWork.PhysicalDeviceName
                                    ,envFullBackupInfWork.BackupStartDate
                                    ,envFullBackupInfWork.BackupFinishDate
                                    ,envFullBackupInfWork.BackupSize
                                    ,envFullBackupInfWork.BackupType
                                    ,envFullBackupInfWork.MachineName
                                    ,envFullBackupInfWork.ServerName
                                    );
                            }
                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // 0件の場合も成功
                            // 情報はないため「NA」とする
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP_ERR, EnvSurvAcsParam.LOGOUTPUT_NA);
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP_ERR ,EnvSurvAcsParam.LOGOUTPUT_NA);
                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.Error;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_FULLBACKUP_ERR ,EnvSurvAcsParam.LOGOUTPUT_EXNA);
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetFullBackupExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetFullBackupInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal || status == (int)EnvSurvAcsParam.StatusCode.NotFound)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // 全体バックアップ情報を取得する

        #region マスタ件数を取得する

        /// <summary>
        /// マスタ件数を取得する
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : マスタ件数を取得します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetMstCountInfo(out string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            logOutputMsg = string.Empty;

            string mstCountInfo = string.Empty;
            int mstCount = 0;

            int retryCnt = 0;

            // 取得判定
            if (esap.TableCntInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        if (iesod == null)
                        {
                            // コンバート対象自動更新リモートオブジェクト
                            iesod = (IEnvSurvObjDB)MediationEnvSurvObjDB.GetEnvSurvObjDB();
                        }

                        // 
                        status = iesod.PriceMstInfCntSearch(out mstCount);
                        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) || (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MSTCNT, EnvSurvAcsParam.LOGOUTPUT_MST, mstCount.ToString());

                            // 成功
                            status = (int)EnvSurvAcsParam.StatusCode.Normal;
                        }
                        else
                        {
                            // ログ出力内容格納
                            logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MSTCNT, EnvSurvAcsParam.LOGOUTPUT_MST, EnvSurvAcsParam.LOGOUTPUT_NA);

                            // 取得できない
                            status = (int)EnvSurvAcsParam.StatusCode.NotFound;
                        }
                    }
                    catch(Exception ex)
                    {
                        // ログ出力内容格納
                        logOutputMsg = String.Format(EnvSurvAcsParam.LOGOUTPUT_INFO_MSTCNT, EnvSurvAcsParam.LOGOUTPUT_MST, EnvSurvAcsParam.LOGOUTPUT_EXNA);

                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.GetMstCountExError;
                        // エラーログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AA GetMstCountInfo Exception", ex.Message));
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 取得しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // マスタ件数を取得する

        #region CLCサーバへログ出力する

        /// <summary>
        /// CLCサーバへログ出力する
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : CLCサーバへログ出力する。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int ClcLogOutput(string logOutputMsg)
        {
            int status = (int)EnvSurvAcsParam.StatusCode.Error;

            string message = string.Empty;

            int retryCnt = 0;

            // 取得判定
            if (esap.ClcLogOutputInfo == (int)EnvSurvAcsParam.GetInfo.ON)
            {
                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt <= esap.RetryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(esap.RetryInterval);
                    }

                    try
                    {
                        esc.ClcLogOutput(logOutputMsg);
                        // 成功
                        status = (int)EnvSurvAcsParam.StatusCode.Normal;
                    }
                    catch
                    {
                        // 例外エラー
                        status = (int)EnvSurvAcsParam.StatusCode.ClcLogOutputExError;
                    }
                    finally
                    {
                        // 初期化
                    }

                    if (status == (int)EnvSurvAcsParam.StatusCode.Normal)
                    {
                        // 正常終了のためリトライしない
                        break;
                    }
                    retryCnt += 1;
                }
            }
            else
            {
                // 設定しない
                status = (int)EnvSurvAcsParam.StatusCode.None;
            }

            return status;
        }

        #endregion // CLCサーバへログ出力する

        #endregion ■ Private Methods
    }
}

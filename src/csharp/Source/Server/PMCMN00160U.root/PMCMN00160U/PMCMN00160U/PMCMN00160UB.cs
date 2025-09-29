//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動バックアップ
// プログラム概要   : コンバート対象自動バックアップ
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00  作成担当 : 小原
// 作 成 日  2020/06/15   修正内容 : ＥＢＥ対策
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic.Devices;
using System.IO;
using System.Net;

namespace Broadleaf.Application.Common
{
    public class LogInfoAllCls : RemoteDB
    {
        #region 定数定義

        /// <summary>
        /// 機能名
        /// </summary>
        private const string ApplicationName = "コンバート対象自動バックアップ";

        /// <summary>
        /// CLCログファイル名
        /// </summary>
        private const string CLCLogFileName = "PMCMN00160U_{0}_{1}.log";

        /// <summary>
        /// オペレーションコードデフォルト
        /// </summary>
        private const int OperationCodeDefault = 0;

        /// <summary>
        ///  オペレーションステータスデフォルト
        /// </summary>
        private const int OperationStatusDefault = 0;

        /// <summary>
        /// ENTERPRISECODE（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_ENTERPRISECODE = "ENTERPRISECODE={0},";

        /// <summary>
        /// PC（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// IPアドレス
        /// </summary>
        private const string LOGOUTPUT_INFO_IP = "IP={0},";

        /// <summary>
        /// CPU使用率 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_CPU = "CPU(%)={0},";

        /// <summary>
        /// メモリ使用量/容量 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_MEM = "MEM(MB)={0},";

        /// <summary>
        /// ディスク使用量/容量 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_DISK = "DISK(MB)={0}";

        /// <summary>
        /// 情報取得失敗 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// 情報取得例外 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// ログ出力内容
        /// </summary>
        private const string LOGOUTPUT_MESSAGE = "{0} SYSINFO:{1}";

        #endregion //定数定義

        #region プライベートフィールド

        /// <summary>
        /// アセンブリID
        /// </summary>
        private string AssemblyId = string.Empty;

        /// <summary>
        /// コンバート対象自動バックアップリモートオブジェクトインターフェース
        /// </summary>
        private IConvObjSingleBkDB IConvertObjectDB = null;

        /// <summary>
        /// パラメータ
        /// </summary>
        private static ConvObjBkParam codbp = null;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LogInfoAllCls()
        {
            // アセンブリ名をフルパスで取得
            string fullAssemblyName = this.GetType().Assembly.Location;
            // アセンブリ名のみを取得
            this.AssemblyId = System.IO.Path.GetFileName(fullAssemblyName);
            // パラメータ
            codbp = new ConvObjBkParam();
        }

        #endregion //コンストラクタ

        #region ログ出力
        /// <summary>
        /// サーバログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        public void WriteErrorServerLog(Exception ex, string errorText, int status)
        {
            WriteErrorServerLogProc(ex, errorText, status);
        }

        /// <summary>
        /// サーバログ出力
        /// </summary>
        /// <param name="ex">例外</param>
        /// <param name="errorText">エラーメッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <remarks>
        /// <br>Note       : サーバログにログを出力する</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private void WriteErrorServerLogProc(Exception ex, string errorText, int status)
        {
            try
            {
                base.WriteErrorLog(ex, errorText, status);
            }
            catch
            {
                // 例外
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
        public void WriteOperationLog(string processName, string stepName, string data)
        {
            WriteOperationLogProc(processName, stepName, data);
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
        private void WriteOperationLogProc(string processName, string stepName, string data)
        {
            const int LogDataMassageMaxLength = 500;
            const int LogOperationDataMaxLength = 80;

            try
            {
                OprtnHisLogWork writeParam = new OprtnHisLogWork();
                writeParam.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                writeParam.LogDataObjClassID = this.AssemblyId;
                writeParam.LogDataCreateDateTime = DateTime.Now;
                writeParam.LogDataKindCd = (int)LogDataKind.SystemLog;
                writeParam.LogDataObjAssemblyID = this.AssemblyId;
                writeParam.LogDataObjAssemblyNm = LogInfoAllCls.ApplicationName;
                writeParam.LogDataObjProcNm = processName;
                writeParam.LogOperationStatus = LogInfoAllCls.OperationStatusDefault;
                writeParam.LogDataMassage = stepName;
                if (!string.IsNullOrEmpty(stepName) && stepName.Length > LogDataMassageMaxLength)
                {
                    writeParam.LogDataMassage = stepName.Substring(0, LogDataMassageMaxLength);
                }
                writeParam.LogOperationData = data;
                if (!string.IsNullOrEmpty(data) && data.Length > LogOperationDataMaxLength)
                {
                    writeParam.LogDataMassage = data.Substring(0, LogOperationDataMaxLength);
                }

                // コンバート対象自動バックアップリモートオブジェクトの取得

                if (this.IConvertObjectDB == null)
                {
                    this.IConvertObjectDB = (IConvObjSingleBkDB)MediationConvObjSingleBkDB.GetConvObjSingleBkDB();
                }
                this.IConvertObjectDB.WriteOprtnHisLog(writeParam);
            }
            catch
            {
                // 例外
            }
        }
        #endregion

        #region CLCログ出力

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public void ClcLogOutput(string message)
        {
            ClcLogOutputProc(message);
        }

        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            DateTime now = DateTime.Now;

            string logFileName = string.Empty;

            KICLC00001C.LogHeader log = null;

            try
            {
                // 出力内容にシステム情報を付加する。
                string logoutput = string.Format(LOGOUTPUT_MESSAGE, message, GetSysInfo());

                // メッセージ内の改行コードをスペースに変換
                logoutput = logoutput.Replace("\r", "").Replace("\n", " ");

                // ログファイル名称作成
                // "PMCMN00160U_"+DateTimeのTicks+Guid文字列
                logFileName = string.Format(CLCLogFileName, now.Ticks.ToString(), Guid.NewGuid().ToString().Replace("-", ""));

                // ProgramData側へログ出力
                log = new KICLC00001C.LogHeader();
                log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00160U", logFileName, logoutput);

            }
            catch
            {
            }
            finally
            {
            }
        }

        #region システム情報取得
        /// <summary>
        /// システム情報取得
        /// </summary>
        /// <returns>システム情報文字列</returns>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string GetSysInfo()
        {
            StringBuilder sysInfo = new StringBuilder();

            #region 企業コード取得
            try
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, LoginInfoAcquisition.EnterpriseCode));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, LOGOUTPUT_EXNA));
            }
            #endregion PC名取得

            #region PC名取得
            try
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, Environment.MachineName));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_PC, LOGOUTPUT_EXNA));
            }
            #endregion PC名取得

            #region IPアドレス取得
            try
            {
                IPAddress[] adrList = Dns.GetHostAddresses(Environment.MachineName);
                StringBuilder ipAddress = new StringBuilder();
                foreach (IPAddress address in adrList)
                {
                    ipAddress.Append(address.ToString());
                    ipAddress.Append(" ");
                }
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, ipAddress.ToString()));
            }
            catch
            {
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_IP, LOGOUTPUT_EXNA));
            }
            #endregion PC名取得

            #region CPU使用率取得
            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                string cpuUsage = (cpuCounter.NextValue()).ToString("0");

                Thread.Sleep(1000);

                // 2回目の値を取得する
                cpuUsage = (cpuCounter.NextValue()).ToString("0");

                if (!string.IsNullOrEmpty(cpuUsage))
                {
                    // ログ出力内容格納
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_CPU, cpuUsage));
                }
                else
                {
                    // ログ出力内容格納
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_CPU, LOGOUTPUT_NA));
                }
            }
            catch
            {
                try
                {
                    // 失敗時はProcessor Informationから取得
                    PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

                    string cpuUsage = (cpuCounter.NextValue()).ToString("0");

                    Thread.Sleep(1000);

                    // 2回目の値を取得する
                    cpuUsage = (cpuCounter.NextValue()).ToString("0");

                    if (!string.IsNullOrEmpty(cpuUsage))
                    {
                        // ログ出力内容格納
                        sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_CPU, cpuUsage));
                    }
                    else
                    {
                        // ログ出力内容格納
                        sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_CPU, LOGOUTPUT_NA));
                    }
                }
                catch
                {
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_CPU, LOGOUTPUT_EXNA));
                }
            }
            #endregion CPU使用率取得

            #region メモリ使用量取得
            try
            {
                ComputerInfo ci = new ComputerInfo();

                string avaliableMemory = (Convert.ToInt64(ci.AvailablePhysicalMemory.ToString()) / 1024 / 1024).ToString();
                string totalMemory = (Convert.ToInt64(ci.TotalPhysicalMemory.ToString()) / 1024 / 1024).ToString();

                string memUsageCap = string.Format("{0}/{1}", avaliableMemory, totalMemory);
                if (!string.IsNullOrEmpty(memUsageCap))
                {
                    // ログ出力内容格納
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, memUsageCap));
                }
                else
                {
                    // ログ出力内容格納
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ログ出力内容格納
                sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_EXNA));
            }
            #endregion メモリ使用量取得

            #region ディスク容量取得
            try
            {
                DriveInfo[] driveList = null;

                string avaliableCapDisk = string.Empty;
                string defaultDir = string.Empty;

                driveList = DriveInfo.GetDrives();

                foreach (DriveInfo di in driveList)
                {
                    if ((di.IsReady == true) && (di.DriveType == DriveType.Fixed))
                    {
                        avaliableCapDisk += string.Format("{0}{1}/{2} ",
                            di.Name.TrimEnd('\\'),
                            (Convert.ToInt64(di.AvailableFreeSpace.ToString()) / 1024 / 1024).ToString(),
                            (Convert.ToInt64(di.TotalSize.ToString()) / 1024 / 1024).ToString());
                    }
                }

                if (!string.IsNullOrEmpty(avaliableCapDisk))
                {
                    // ログ出力内容格納
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_DISK, avaliableCapDisk));
                }
                else
                {
                    // ログ出力内容格納
                    sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ログ出力内容格納
                sysInfo.AppendLine(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_EXNA));
            }
            #endregion ディスク使用量取得

            return sysInfo.ToString();
        }
        #endregion // システム情報取得

        #endregion // CLCログ出力

    }
}

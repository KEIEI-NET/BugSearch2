//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象バックアップメンテナンス
// プログラム概要   : コンバート対象バックアップを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 小原
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Threading;
using System.Net;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンバート対象バックアップConvObjCLCLogDB
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バックアップConvObjCLCLogDB</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjSingleBkCLCLogDB
    {
        #region 定数

        /// <summary>
        /// 企業コード（ログ出力）
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
        private const string LOGOUTPUT_INFO_DISK = "DISK(MB)={0},";

        /// <summary>
        /// 情報取得失敗 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// 情報取得例外 （ログ出力）
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// 処理済みマスタ件数（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_BACKUP_MST = "BK_MST={0},";

        /// <summary>
        /// ログ出力内容（システム情報）
        /// </summary>
        private const string LOGOUTPUT_MESSAGE = "{0} SYSINFO:{1}";

        #endregion // 定数

        #region プライベート変数

        /// <summary>
        /// 企業コード（ログ出力）
        /// </summary>
        private string _enterpriseCode;

        /// <summary>
        /// 処理済みマスタ件数（ログ出力）
        /// </summary>
        private int _bkMstCnt;

        #endregion プライベート変数

        #region プロパティ

        /// <summary>
        /// 企業コード（ログ出力）
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 処理済みマスタ件数（ログ出力）
        /// </summary>
        public int BkMstCnt
        {
            get { return _bkMstCnt; }
            set { _bkMstCnt = value; }
        }

        #endregion // プロパティ

        #region コンストラクタ

        /// <summary>
        /// コンバート対象バックアップパラメータクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjSingleBkCLCLogDB()
        {
            _bkMstCnt = 0;
        }

        #endregion //コンストラクタ

        #region ■ Public Methods

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
            DateTime now = DateTime.Now;

            string logFileName = string.Empty;

            KICLC00001C.LogHeader log = null;

            try
            {
                // 出力内容にシステム情報を付加する。
                string logoutput = string.Format(LOGOUTPUT_MESSAGE, message, GetSysInfo());

                // 

                // メッセージ内の改行コードをスペースに変換
                logoutput = logoutput.Replace("\r", "").Replace("\n", " ").TrimEnd();

                // ログファイル名称作成
                // "PMCMN00163R_"+DateTimeのTicks+Guid文字列
                logFileName = string.Format("PMCMN00163R_{0}_{1}.log", now.Ticks.ToString(), Guid.NewGuid().ToString().Replace("-", ""));

                // ProgramData側へログ出力
                log = new KICLC00001C.LogHeader();
                log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00163R", logFileName, logoutput);

            }
            catch
            {
                // 例外 呼び出し元に戻す
                throw;
            }
            finally
            {
            }
        }
        #endregion // CLCログ出力

        #endregion // ■ Public Methods

        #region ■ Private Methods

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
            sysInfo.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, _enterpriseCode));
            #endregion 企業コード取得

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
            #endregion IPアドレス取得

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
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_MEM, memUsageCap));
                }
                else
                {
                    // ログ出力内容格納
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ログ出力内容格納
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_MEM, LOGOUTPUT_EXNA));
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
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_DISK, avaliableCapDisk));
                }
                else
                {
                    // ログ出力内容格納
                    sysInfo.Append(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_NA));
                }
            }
            catch
            {
                // ログ出力内容格納
                sysInfo.Append(string.Format(LOGOUTPUT_INFO_DISK, LOGOUTPUT_EXNA));
            }
            #endregion ディスク使用量取得

            #region マスタ件数付加

            // ログ出力内容格納
            sysInfo.Append(string.Format(LOGOUTPUT_BACKUP_MST, _bkMstCnt));

            #endregion マスタ件数付加

            return sysInfo.ToString();
        }
        #endregion // システム情報取得

        #endregion // ■ Private Methods

    }
}

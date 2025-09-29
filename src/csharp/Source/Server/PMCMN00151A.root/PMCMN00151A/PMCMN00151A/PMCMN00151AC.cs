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
using Broadleaf.Library.Resources;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Xml;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 影響調査共通クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 影響調査のアクセス制御を行います。</br>
    /// <br>Programmer	: 佐々木亘</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvCommn
    {
        #region ■ Private Members

        /// <summary>
        /// レジストキー文字列（CLIENT）
        /// </summary>
        private const string REG_KEY_CLIENT = @"Broadleaf\Product\Partsman";

        /// <summary>
        /// レジストキー文字列（USER_AP）
        /// </summary>
        private const string REG_KEY_USER_AP = @"Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// レジストキー文字列（KEY32）
        /// </summary>
        private const string REG_KEY32 = @"SOFTWARE\";

        /// <summary>
        /// レジストキー文字列（KEY64） ※取得できない場合
        /// </summary>
        private const string REG_KEY64 = @"SOFTWARE\WOW6432Node\";

        #endregion // ■ Private Members

        # region ■ Constructor

        /// <summary>
        /// 影響調査共通クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 影響調査データクラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public EnvSurvCommn()
        {
        }

        # endregion // ■ Constructor

        #region ■ Public Methods

        #region USER_APレジストリ取得

        /// <summary>
        /// USER_APレジストリ取得
        /// </summary>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public RegistryKey GetRegistryKeyUserAP()
        {
            RegistryKey registryKey = null;

            try
            {
                // レジストリ情報よりUSER_APのキー情報を取得
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + REG_KEY_USER_AP);
                if (registryKey == null)
                {
                    // 取得できない場合、念のため
                    registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + REG_KEY_USER_AP);
                }
            }
            catch(Exception ex)
            {
                // 例外
                registryKey = null;
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetRegistryKeyUserAP Exception", ex.Message));
            }

            return registryKey;
        }

        #endregion // USER_APレジストリ取得

        #region CLIENTレジストリ取得

        /// <summary>
        /// CLIENTレジストリ取得
        /// </summary>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public RegistryKey GetRegistryKeyClient()
        {
            RegistryKey registryKey = null;

            try
            {
                // レジストリ情報よりCLIENTのキー情報を取得
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + REG_KEY_CLIENT);
                if (registryKey == null)
                {
                    // 取得できない場合、念のため
                    registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + REG_KEY_CLIENT);
                }

            }
            catch(Exception ex)
            {
                // 例外
                registryKey = null;
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetRegistryKeyClient Exception", ex.Message));
            }

            return registryKey;
        }

        #endregion // CLIENTレジストリ取得

        #region CPU使用率取得

        /// <summary>
        /// CPU使用率取得
        /// </summary>
        /// <returns>CPU使用率</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public string GetCpuCounter()
        {

            PerformanceCounter cpuCounter = null;

            string cpuUsage = string.Empty;

            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                cpuUsage = (cpuCounter.NextValue()).ToString("0");

                Thread.Sleep(1000);

                // 2回目の値を取得する
                cpuUsage = (cpuCounter.NextValue()).ToString("0");

            }
            catch(Exception ex)
            {
                // 例外
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetCpuCounter Exception", ex.Message));
            }
            finally
            {
                // 取得できない場合
                if (String.IsNullOrEmpty(cpuUsage))
                {
                    cpuUsage = "NA";
                }

                cpuCounter.Dispose();
            }

            return cpuUsage;
        }

        #endregion // CPU使用率取得

        #region メモリ使用量取得

        /// <summary>
        /// メモリ使用量取得
        /// </summary>
        /// <returns>メモリ使用量</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public string GetAvaliableMemory()
        {

            ComputerInfo ci = null;

            string avaliableMemory = string.Empty;

            try
            {
                ci = new ComputerInfo();

                avaliableMemory = (Convert.ToInt64(ci.AvailablePhysicalMemory.ToString()) / 1024 / 1024).ToString();
            }
            catch(Exception ex)
            {
                // 例外
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetAvaliableMemory Exception", ex.Message));
            }
            finally
            {
                // 取得できない場合
                if (String.IsNullOrEmpty(avaliableMemory))
                {
                    avaliableMemory = "NA";
                }
            }

            return avaliableMemory;
        }

        #endregion // メモリ使用量取得

        #region メモリ容量取得

        /// <summary>
        /// メモリ容量取得
        /// </summary>
        /// <returns>メモリ容量</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public string GetTotalMemory()
        {

            ComputerInfo ci = null;

            string totalMemory = string.Empty;

            try
            {
                ci = new ComputerInfo();

                totalMemory = (Convert.ToInt64(ci.TotalPhysicalMemory.ToString()) / 1024 / 1024).ToString();
            }
            catch(Exception ex)
            {
                // 例外
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetTotalMemory Exception", ex.Message));
            }
            finally
            {
                // 取得できない場合
                if (String.IsNullOrEmpty(totalMemory))
                {
                    totalMemory = "NA";
                }
            }

            return totalMemory;
        }
        #endregion // メモリ容量取得

        #region ディスク使用量/容量取得
        /// <summary>
        /// ディスク使用量/容量取得
        /// </summary>
        /// <returns>ディスク使用量/容量</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        public string GetAvaliableCapDisk()
        {

            DriveInfo[] driveList = null;

            string avaliableCapDisk = string.Empty;
            string defaultDir = string.Empty;

            try
            {

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
            }
            catch(Exception ex)
            {
                // エラー情報出力
                ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AC GetAvaliableCapDisk Exception", ex.Message));
            }
            finally
            {
                // 取得できない場合
                if (String.IsNullOrEmpty(avaliableCapDisk))
                {
                    avaliableCapDisk = "NA";
                }
            }

            return avaliableCapDisk;
        }
        #endregion // ディスク使用量/容量取得

        #region CLCログ出力
        /// <summary>
        /// CLCログ出力
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
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
                // ログファイル名称作成
                // "PMCMN00150U_"+DateTimeのTicks+Guid文字列
                logFileName = string.Format("PMCMN00150U_{0}_{1}.log", now.Ticks.ToString(), Guid.NewGuid().ToString().Replace("-", ""));

                // ProgramData側へログ出力
                log = new KICLC00001C.LogHeader();
                log.WriteServiceLogHeader(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.ProductCode, "PMCMN00150U", logFileName, message);

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
    }
}

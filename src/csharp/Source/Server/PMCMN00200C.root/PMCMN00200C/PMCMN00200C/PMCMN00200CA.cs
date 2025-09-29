using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using Broadleaf.Application.Resources;
using System.Threading;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Text;
using System.Net;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// ログ出力部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : CLCログ、ログファイル出力を行うクラスです。</br>
    /// <br>Programmer : 32470 小原</br>
    /// <br>Date       : 2021/02/26</br>
    /// <br>Note       : Tread.Sleep()が実行されるか制御メソッドを追加します。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2021/03/25</br>
    /// </remarks>
    public class OutLogCommon
    { 
        #region 定数

        /// <summary>
        /// レジストキー文字列（CLIENT）
        /// </summary>
        private const string REG_KEY_CLIENT = @"Broadleaf\Product\Partsman";

        /// <summary>
        /// レジストキー文字列（SERVER）
        /// </summary>
        private const string REG_KEY_SERVER = @"Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// レジストキー文字列（KEY32）
        /// </summary>
        private const string REG_KEY32 = @"SOFTWARE\";

        /// <summary>
        /// レジストキー文字列（KEY64） ※取得できない場合
        /// </summary>
        private const string REG_KEY64 = @"SOFTWARE\WOW6432Node\";

        /// <summary>
        /// レジスト名文字列（インストールディレクトリ）
        /// </summary>
        private const string REG_INSTALL_DIRECTORY = @"InstallDirectory";

        /// <summary>
        /// UISettingsフォルダ
        /// </summary>
        private const string DIR_UISETTINGS = @"UISettings";

        /// <summary>
        /// ログ出力制御設定ファイル名　※先頭にPGIDを付与して使用
        /// </summary>
        private const string XML_FILE_NAME = @"{0}_LogOutCheckEnabler.xml";

        /// <summary>
        /// ログ出力フォルダ
        /// Log\PGIDフォルダに出力する
        /// </summary>
        private const string LOG_DIRECTORY = @"Log\{0}";

        /// <summary>
        /// PGID
        /// </summary>
        private const string PGID = "PMCMN00200C";

        /// <summary>
        /// CLCログファイル名
        /// PMCMN00200C+PGID+DateTimeのyyyyMMddmmssfff+従業員ID+Guid.NewGuid()
        /// </summary>
        private const string CLC_LOGFILE_NAME = "PMCMN00200C_{0}_{1:yyyyMMddHHmmssfff}_{2}_{3}.clc";

        /// <summary>
        /// ログファイル名
        /// PGID+DateTimeのyyyyMMdd+従業員ID
        /// </summary>
        private const string OUTPUT_FILE_NAME = "{0}_{1:yyyyMMdd}_{2}.log";

        /// <summary>
        /// NA
        /// </summary>
        private const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// EXNA
        /// </summary>
        private const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// ENTERPRISECODE（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_ENTERPRISECODE = "ENTERPRISECODE={0},";

        /// <summary>
        /// IPアドレス
        /// </summary>
        private const string LOGOUTPUT_INFO_IP = "IP={0},";

        /// <summary>
        /// PC（ログ出力）
        /// </summary>
        private const string LOGOUTPUT_INFO_PC = "PC={0},";

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
        /// メッセージ
        /// </summary>
        private const string LOGOUTPUT_MSG = "MSG={0},";

        /// <summary>
        /// 例外メッセージ
        /// </summary>
        private const string LOGOUTPUT_EXMSG = "EXMSG={0},";

        /// <summary>
        /// スタックトレース
        /// </summary>
        private const string LOGOUTPUT_STACKTRACE = "STACKTRACE={0}";

        /// <summary>
        /// CLC出力メッセージ最大文字数
        /// </summary>
        private const int CLCMSG_MAXCNT = 3000;

        // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
        /// <summary>
        /// Sleep実行モード(0:実行される 1:実行されない)
        /// </summary>
        private const int EXECUTE_MODE = 0;

        /// <summary>
        /// タブ区切
        /// </summary>
        private const string TAB_DELIMITED = "\t";

        // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public OutLogCommon()
        {
        }

        #endregion // コンストラクタ

        // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
        #region publicメソッド
        /// <summary>
        /// クライアントログ出力
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログ出力メッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="sleepMode">Sleep実行モード(0:実行される 1:実行されない)</param>
        /// <remarks>
        /// <br>Note       : クライアントログ出力を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLogWithSettingSleep(string pgid, string message, string enterpriseCode, string employeeCode, int sleepMode)
        {
            try
            {
                OutputClientLogWithSettingSleep(pgid, message, enterpriseCode, employeeCode, null, sleepMode);
            }
            catch
            {
                // 例外時は後続処理に影響させない
            }
        }

        /// <summary>
        /// クライアントログ出力
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログ出力メッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="sleepMode">Sleep実行モード(0:実行される 1:実行されない)</param>
        /// <remarks>
        /// <br>Note       : クライアントログ出力を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLogWithSettingSleep(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex, int sleepMode)
        {
            bool clcLogOutDiv;
            bool logOutFileDiv;
            string installDir = string.Empty;

            try
            {
                // 設定ファイル取得
                GetClientXml(pgid, out clcLogOutDiv, out logOutFileDiv);

                if (clcLogOutDiv)
                {
                    // CLCログ出力
                    OutputClientClcLog(pgid, message, enterpriseCode, employeeCode, ex, sleepMode);

                }

                if (logOutFileDiv)
                {
                    // カレントディレクトリ取得
                    installDir = GetCurrentDirectory(REG_KEY_CLIENT);

                    if (!string.IsNullOrEmpty(installDir))
                    {
                        // カレントディレクトリ取得できた場合
                        // ログファイル出力
                        WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex, sleepMode);
                    }
                }
            }
            catch
            {
                // 例外時は後続処理に影響させない
            }
        }
        #endregion
        // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<

        #region publicメソッド 

        /// <summary>
        /// クライアントログ出力
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログ出力メッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <remarks>
        /// <br>Note       : クライアントログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLog(string pgid, string message, string enterpriseCode, string employeeCode)
        {
            try
            {
                OutputClientLog(pgid, message, enterpriseCode, employeeCode, null);
            }
            catch
            {
                // 例外時は後続処理に影響させない
            }
        }
        
        /// <summary>
        /// クライアントログ出力
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログ出力メッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="ex">例外オブジェクト</param>
        /// <remarks>
        /// <br>Note       : クライアントログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()が実行されるか制御メソッドを追加します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public void OutputClientLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        {
            bool clcLogOutDiv;
            bool logOutFileDiv;
            string installDir = string.Empty;

            try
            {
                // 設定ファイル取得
                GetClientXml(pgid, out clcLogOutDiv, out logOutFileDiv);

                if (clcLogOutDiv)
                {
                    // CLCログ出力
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //OutputClientClcLog(pgid, message, enterpriseCode, employeeCode, ex);
                    OutputClientClcLog(pgid, message, enterpriseCode, employeeCode, ex, EXECUTE_MODE);
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
    
                }

                if (logOutFileDiv)
                {
                    // カレントディレクトリ取得
                    installDir = GetCurrentDirectory(REG_KEY_CLIENT);

                    if (!string.IsNullOrEmpty(installDir))
                    {
                        // カレントディレクトリ取得できた場合
                        // ログファイル出力
                        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                        //WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex);
                        WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex, EXECUTE_MODE);
                        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
                    }
                }
            }
            catch
            {
                // 例外時は後続処理に影響させない
            }
        }

        /// <summary>
        /// サーバーログ出力
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログ出力メッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <remarks>
        /// <br>Note       : サーバーログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public void OutputServerLog(string pgid, string message, string enterpriseCode, string employeeCode)
        {
            try
            {
                OutputServerLog(pgid, message, enterpriseCode, employeeCode, null);
            }
            catch
            {
                // 例外時は後続処理に影響させない
            }
        }

        /// <summary>
        /// サーバーログ出力
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログ出力メッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="ex">例外オブジェクト</param>
        /// <remarks>
        /// <br>Note       : サーバーログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()が実行されるか制御メソッドを追加します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        public void OutputServerLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        {
            bool clcLogOutDiv;
            bool logOutFileDiv;
            string installDir = string.Empty;

            try
            {
                // 設定ファイル取得
                GetServerXml(pgid, out clcLogOutDiv, out logOutFileDiv);

                if (clcLogOutDiv)
                {
                    // CLCログ出力
                    OutputServerClcLog(pgid, message, enterpriseCode, employeeCode, ex);

                }

                if (logOutFileDiv)
                {
                    // カレントディレクトリ取得
                    installDir = GetCurrentDirectory(REG_KEY_SERVER);

                    if (!string.IsNullOrEmpty(installDir))
                    {
                        // カレントディレクトリ取得できた場合
                        // ログファイル出力
                        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                        //WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex);
                        WriteLog(installDir, pgid, message, enterpriseCode, employeeCode, ex, EXECUTE_MODE);
                        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
                    }
                }
            }
            catch
            {
                // 例外時は後続処理に影響させない
            }
        }

        #endregion // publicメソッド

        #region privateメソッド

        #region クライアントXML情報取得

        /// <summary>
        /// クライアントXML情報取得
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="clcLogOutDiv">CLCログ出力制御 true:出力する false:出力しない</param>
        /// <param name="logOutFileDiv">ログファイル出力制御 true:出力する false:出力しない</param>
        /// <remarks>
        /// <br>Note       : クライアントXML情報取得を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        private void GetClientXml(string pgid, out bool clcLogOutDiv, out bool logOutFileDiv)
        {
            string installDir = string.Empty;
            string uisettingsDir = string.Empty;
            string xmlFile = string.Empty;
            string xmlPath = string.Empty;

            // 戻りパラメータ初期値
            clcLogOutDiv = false;
            logOutFileDiv = false;

            // カレントディレクトリ取得
            installDir = GetCurrentDirectory(REG_KEY_CLIENT);

            if (!string.IsNullOrEmpty(installDir))
            {
                // カレントディレクトリ取得が成功した場合
                // UISettingフォルダ
                uisettingsDir = Path.Combine(installDir, DIR_UISETTINGS);

                // XMLファイル名　PGID_LogOutCheckEnabler.xml
                xmlFile = string.Format(XML_FILE_NAME, pgid);

                // フルパス
                xmlPath = Path.Combine(uisettingsDir, xmlFile);

                if (UserSettingController.ExistUserSetting(xmlPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        // ログ出力可否制御ファイルを読み込む
                        while (reader.Read())
                        {
                            //CLCログ出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement("ClcLogOutDiv")) clcLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ClcLogOutDiv").Trim());
                            //ログファイル出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement("LogOutFileDiv")) logOutFileDiv = Convert.ToBoolean(reader.ReadElementString("LogOutFileDiv").Trim());
                        }
                    }
                }
            }
        }

        #endregion // クライアントXML情報取得

        #region クライアントXML情報取得

        /// <summary>
        /// サーバーXML情報取得
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="clcLogOutDiv">CLCログ出力制御 true:出力する false:出力しない</param>
        /// <param name="logOutFileDiv">ログファイル出力制御 true:出力する false:出力しない</param>
        /// <remarks>
        /// <br>Note       : サーバーXML情報取得を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        private void GetServerXml(string pgid, out bool clcLogOutDiv, out bool logOutFileDiv)
        {
            string installDir = string.Empty;
            string xmlFile = string.Empty;
            string xmlPath = string.Empty;

            // 戻りパラメータ初期値
            clcLogOutDiv = false;
            logOutFileDiv = false;

            // カレントディレクトリ取得
            installDir = GetCurrentDirectory(REG_KEY_SERVER);

            if (!string.IsNullOrEmpty(installDir))
            {
                // カレントディレクトリ取得が成功した場合

                // XMLファイル名　PGID_LogOutCheckEnabler.xml
                xmlFile = string.Format(XML_FILE_NAME, pgid);

                // フルパス
                xmlPath = Path.Combine(installDir, xmlFile);

                // XML設定情報取得
                // XMLファイルがない場合はログ出力しない
                if (File.Exists(xmlPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        // ログ出力可否制御ファイルを読み込む
                        while (reader.Read())
                        {
                            //CLCログ出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement("ClcLogOutDiv")) clcLogOutDiv = Convert.ToBoolean(reader.ReadElementString("ClcLogOutDiv").Trim());
                            //ログファイル出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement("LogOutFileDiv")) logOutFileDiv = Convert.ToBoolean(reader.ReadElementString("LogOutFileDiv").Trim());
                        }
                    }
                }
            }
        }

        #endregion // クライアントXML情報取得

        #region カレントディレクトリ取得

        /// <summary>
        /// カレントディレクトリのパス取得
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <returns>カレントディレクトリフルパス</returns>
        /// <remarks>
        /// <br>Note       : カレントディレクトリのパスを取得します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        private string GetCurrentDirectory(string regKeyStr)
        {
            string defaultDir = string.Empty;

            // 戻り値初期値
            string homeDir = string.Empty;

            try
            {
                // 実行ファイル格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory;
            }
            catch
            {
                // 初期ディレクトリは念のための処理のため、
                // 取得できなくても処理続行する
            }

            try
            {
                // レジストリ情報よりキー情報を取得
                RegistryKey registryKey = GetRegistryKey(regKeyStr);

                if (registryKey != null)
                {
                    homeDir = registryKey.GetValue(REG_INSTALL_DIRECTORY, defaultDir).ToString();
                }
            }
            catch
            {
                // 例外時初期ディレクトリ取得可能性があるため処理続行
            }

            // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
            if (!Directory.Exists(homeDir))
            {
                homeDir = defaultDir;
            }

            return homeDir;
        }

        #endregion // カレントディレクトリ取得

        #region レジストリキー情報取得

        /// <summary>
        /// レジストリキー情報取得
        /// 当関数で例外処理は不要なため呼び出し元で実装する
        /// </summary>
        /// <param name="regKeyStr">取得レジストリキー</param>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Note       : レジストリキー情報を取得します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        private RegistryKey GetRegistryKey(string regKeyStr)
        {
            RegistryKey registryKey = null;

            // レジストリ情報よりキー情報を取得
            registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + regKeyStr);

            if (registryKey == null)
            {
                // 取得できない場合、念のため
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + regKeyStr);
            }

            return registryKey;
        }

        #endregion // レジストリ取得

        #region クライアントCLCログ出力

        /// <summary>
        /// クライアントCLCログ出力
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="sleepMode">Sleep実行モード(0:実行される 1:実行されない)</param>
        /// <remarks>
        /// <br>Note       : クライアントCLCログ出力</br>
        /// <br>Programer  : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()が実行されるか制御メソッドを追加します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
        //private void OutputClientClcLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        private void OutputClientClcLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex, int sleepMode)
        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
        {
            DateTime now = DateTime.Now;

            StringBuilder builder = new StringBuilder();
            string logContents = string.Empty;

            try
            {
                // 企業コード格納
                builder.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, enterpriseCode));
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                // システム情報格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //builder.Append(GetSysInfo());
                builder.Append(TAB_DELIMITED);
                builder.Append(GetSysInfo(sleepMode));
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                // メッセージ格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //builder.Append(string.Format(LOGOUTPUT_MSG, message));
                builder.Append(TAB_DELIMITED);
                builder.Append(string.Format(LOGOUTPUT_MSG, message).Replace("\r", " ").Replace("\n", " ").Replace("\t", " "));
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }


            if (ex != null)
            {
                try
                {
                    // 例外メッセージ展開
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
                }
                catch
                {
                    // 設定失敗時も処理続行
                }

                try
                {
                    // スタックトレース展開
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
                }
                catch
                {
                    // 設定失敗時も処理続行
                }
            }
            // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
            //exがnullの場合も、空のタブ2つというような出力にする
            else
            {
                builder.Append(TAB_DELIMITED);
                builder.Append(TAB_DELIMITED);
            }
            // 1行の最後（末尾）に、行末は空のタブを付与する
            builder.Append(TAB_DELIMITED);
            // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<

            if (builder.ToString().Length > CLCMSG_MAXCNT)
            {
                // CLCメッセージ文字列が最大数を超えている場合、最大数に設定
                logContents = builder.ToString().Substring(0, CLCMSG_MAXCNT);
            }
            else
            {
                logContents = builder.ToString();
            }

            // Guid取得
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            // clcログファイル名:PMCMN00200C+PGID+DateTimeのyyyyMMddmmssfff+従業員ID+Guid.NewGuid()
            string ClclogFileName = string.Format(CLC_LOGFILE_NAME, pgid, now, employeeCode.Trim(), guid);

            // ProgramData側へログ出力
            KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
            log.WriteProductLogHeader(ConstantManagement_SF_PRO.ProductCode, ClclogFileName, logContents);
        }

        #endregion // クライアントCLCログ出力

        #region サーバーCLCログ出力

        /// <summary>
        /// サーバーCLCログ出力
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="ex">例外オブジェクト</param>
        /// <remarks>
        /// <br>Note       : サーバーCLCログ出力</br>
        /// <br>Programer  : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()が実行されるか制御メソッドを追加します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        private void OutputServerClcLog(string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        {
            DateTime now = DateTime.Now;

            StringBuilder builder = new StringBuilder();
            string logContents = string.Empty;

            try
            {
                // 企業コード格納
                builder.Append(string.Format(LOGOUTPUT_INFO_ENTERPRISECODE, enterpriseCode));
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                // システム情報格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //builder.Append(GetSysInfo());
                builder.Append(TAB_DELIMITED);
                builder.Append(GetSysInfo(EXECUTE_MODE));
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                // メッセージ格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //builder.Append(string.Format(LOGOUTPUT_MSG, message));
                builder.Append(TAB_DELIMITED);
                builder.Append(string.Format(LOGOUTPUT_MSG, message.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }


            if (ex != null)
            {
                try
                {
                    // 例外メッセージ展開
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_EXMSG, ex.Message.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                }
                catch
                {
                    // 設定失敗時も処理続行
                }

                try
                {
                    // スタックトレース展開
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ")));
                    builder.Append(TAB_DELIMITED);
                    builder.Append(string.Format(LOGOUTPUT_STACKTRACE, ex.StackTrace.Replace("\r", " ").Replace("\n", " ").Replace("\t", " ")));
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                }
                catch
                {
                    // 設定失敗時も処理続行
                }
            }
            // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
            else
            {
                // exがnullの場合も、空のタブ2つというような出力にする
                builder.Append(TAB_DELIMITED);
                builder.Append(TAB_DELIMITED);
            }
            // 1行の最後（末尾）に、行末は空のタブを付与する
            builder.Append(TAB_DELIMITED);
            // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<

            if (builder.ToString().Length > CLCMSG_MAXCNT)
            {
                // CLCメッセージ文字列が最大数を超えている場合、最大数に設定
                logContents = builder.ToString().Substring(0, CLCMSG_MAXCNT);
            }
            else
            {
                logContents = builder.ToString();
            }

            // Guid取得
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            // clcログファイル名:PMCMN00200C+PGID+DateTimeのyyyyMMddmmssfff+従業員ID+Guid.NewGuid()
            string ClclogFileName = string.Format(CLC_LOGFILE_NAME, pgid, now, employeeCode.Trim(), guid);

            // ProgramData側へログ出力
            KICLC00001C.LogHeader log = new KICLC00001C.LogHeader();
            log.WriteServiceLogHeader(ConstantManagement_SF_PRO.ProductCode, PGID, ClclogFileName, logContents);
        }

        #endregion // クライアントCLCログ出力

        #region システム情報取得
        /// <summary>
        /// システム情報取得
        /// </summary>
        /// <param name="sleepMode">Sleep実行モード(0:実行される 1:実行されない)</param>
        /// <returns>システム情報文字列</returns>
        /// <remarks>
        /// <br>Note       : クライアントCLCログ出力</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
        //private string GetSysInfo()
        private string GetSysInfo(int sleepMode)
        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
        {
            StringBuilder sysInfo = new StringBuilder();

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

                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //Thread.Sleep(1000);
                if (sleepMode == EXECUTE_MODE) Thread.Sleep(1000);
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<

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

                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //Thread.Sleep(1000);
                    if (sleepMode == EXECUTE_MODE) Thread.Sleep(1000);
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<

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

            return sysInfo.ToString();
        }

        #endregion // システム情報取得

        #region LOGフォルダへログ出力

        /// <summary>
        /// LOGフォルダへログ出力
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="currentDir">カレントディレクトリ</param>
        /// <param name="pgid">プログラムID</param>
        /// <param name="message">ログメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="sleepMode">Sleep実行モード(0:実行される 1:実行されない)</param>
        /// <remarks>
        /// <br>Note       : LOGフォルダへログ出力を行います。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2021/02/26</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>Note       : Tread.Sleep()が実行されるか制御メソッドを追加します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br>管理番号   : 11601223-00</br>
        /// </remarks>
        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
        //private void WriteLog(string currentDir, string pgid, string message, string enterpriseCode, string employeeCode, Exception ex)
        private void WriteLog(string currentDir, string pgid, string message, string enterpriseCode, string employeeCode, Exception ex, int sleepMode)
        // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
        {
            string logDirName = string.Empty;
            string logDir = string.Empty;
            string logFileName = string.Empty;
            string logPath = string.Empty;

            DateTime now = DateTime.Now;

            StringBuilder logContents = new StringBuilder();

            try
            {
                // ログ出力日時格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //logContents.AppendLine(now.ToString());
                logContents.Append(now.ToString());
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                // システム情報格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //logContents.AppendLine(GetSysInfo());
                logContents.Append(TAB_DELIMITED);
                logContents.Append(GetSysInfo(sleepMode));
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                // メッセージ格納
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                //logContents.AppendLine(string.Format(LOGOUTPUT_MSG, message));
                logContents.Append(TAB_DELIMITED);
                logContents.Append(string.Format(LOGOUTPUT_MSG, message.Replace(TAB_DELIMITED, " ").Replace("\r", " ").Replace("\n", " ")));
                // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            try
            {
                if (ex != null)
                {
                    // 例外情報格納
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                    //logContents.AppendLine(ex.ToString());
                    logContents.Append(TAB_DELIMITED);
                    logContents.Append(ex.ToString().Replace(TAB_DELIMITED, " ").Replace("\r", " ").Replace("\n", " "));
                    // ---UPD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
                }
                // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------>>>>>
                else
                {
                    // exがnullの場合も、空のタブ2つというような出力にする
                    logContents.Append(TAB_DELIMITED);
                    logContents.Append(TAB_DELIMITED);
                }
                // ---ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応 ------<<<<<
            }
            catch
            {
                // 設定失敗時も処理続行
            }

            // 1行の最後（末尾）に、行末は空のタブを付与する
            logContents.Append(TAB_DELIMITED);// ADD 陳艶丹 2021/03/25 PMKOBETSU-4133の対応
            // ログファイル名　PGID+DateTimeのyyyyMMdd+従業員ID
            logFileName = string.Format(OUTPUT_FILE_NAME, pgid, now, employeeCode.Trim());

            // ログフォルダ名設定
            logDirName = string.Format(LOG_DIRECTORY, PGID);

            // ログフォルダ
            logDir = Path.Combine(currentDir, logDirName);

            if (!Directory.Exists(logDir))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logDir);
            }

            logPath = Path.Combine(logDir, logFileName);

            // ログ出力
            using (StreamWriter writer = new StreamWriter(logPath, true, Encoding.Default))
            {
                writer.WriteLine(logContents.ToString());
            }
        }

        #endregion // LOGフォルダへログ出力

        #endregion // privateメソッド

    }
}

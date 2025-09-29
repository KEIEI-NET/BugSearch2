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
using Microsoft.Win32;
using System;
using System.Collections;
using System.IO;
using System.Xml;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 設定パラメータ
    /// </summary>
    /// <remarks>
    /// <br>Note		: 影響調査のアクセス制御を行います。</br>
    /// <br>Programmer	: 佐々木亘</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class EnvSurvAcsParam
    {
        #region ■ Private Members

        #endregion ■ Private Members

        #region 列挙体

        /// <summary>
        /// 環境調査の結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>取得しない</summary>
            None = 1
          , /// <summary>取得できない</summary>
            NotFound = 4
          , /// <summary>Error</summary>
            Error = 9
          , /// <summary>認証取得時例外エラー</summary>
            Error1001 = 1001
          , /// <summary>ExError</summary>
            ExError = 2000
          , /// <summary>PC名取得時例外エラー</summary>
            GetMachineNameExError = 5000
          , /// <summary>システム形態例外エラー</summary>
            GetSystemFormExError = 5010
          , /// <summary>CPU使用率取得例外エラー</summary>
            GetCpuUsageExError = 5020
          , /// <summary>メモリ使用量/容量取得例外エラー</summary>
            GetMemUsageCapExError = 5030
          , /// <summary>ディスク使用量/容量取得例外エラー</summary>
            GetDiskUsageCapExError = 5040
          , /// <summary>全体バックアップ取得例外エラー</summary>
            GetFullBackupExError = 5040
          , /// <summary>マスタ件数取得例外エラー</summary>
            GetMstCountExError = 5040
          , /// <summary>CLCログ出力例外エラー</summary>
            ClcLogOutputExError = 6000
          , /// <summary>パラメータエラー</summary>
            ParamErr = 8000
        };

        /// <summary>
        /// 環境調査の結果ステータス列挙体
        /// </summary>
        public enum GetInfo
        {
            /// <summary>取得する</summary>
            ON = 0
          , /// <summary>取得しない</summary>
            OFF = 1
        };

        /// <summary>
        /// 存在情報列挙体
        /// </summary>
        public enum GetExistInfo
        {
            /// <summary>存在する</summary>
            Exist = 0
          , /// <summary>存在しない</summary>
            NotExist = 1
        };

        #endregion //列挙体

        #region 定数

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00151A_Setting.xml";

        /// <summary>
        /// リトライ回数
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// リトライ間隔(ミリ秒)
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 5000;

        /// <summary>
        /// PC名を取得（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_MACHINE_NAME_INFO = 0;

        /// <summary>
        /// システム形態を取得（スタンドアロン、C/S）（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_SYSTEM_FORM_INFO = 0;

        /// <summary>
        /// CPU使用率を取得（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_CPU_USAGE_INFO = 0;

        /// <summary>
        /// メモリ使用量/容量を取得（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_MEM_USAGE_INFO = 0;

        /// <summary>
        /// ディスク使用量/容量を取得（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_DISK_USAGE_INFO = 0;

        /// <summary>
        /// 全体バックアップ情報を取得（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_FULL_BACKUP_INFO = 0;

        /// <summary>
        /// 価格マスタの件数を取得（0：取得する、1：取得しない）
        /// </summary>
        private const int GET_TABLE_CNT_INFO = 0;


        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        public const int GET_CLC_LOG_OUTPUT_INFO = 0;

        /// <summary>
        /// NA
        /// </summary>
        public const string LOGOUTPUT_NA = "NA";

        /// <summary>
        /// EXNA
        /// </summary>
        public const string LOGOUTPUT_EXNA = "EXNA";

        /// <summary>
        /// PC（ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_PC = "PC={0},";

        /// <summary>
        /// システム形態 （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_SYSFORM = "{0},";

        /// <summary>
        /// スタンドアロン
        /// </summary>
        public const string LOGOUTPUT_SA = "SA";

        /// <summary>
        /// C/S
        /// </summary>
        public const string LOGOUTPUT_CS = "CS";

        /// <summary>
        /// オプション （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_OPT = "{0},";

        /// <summary>
        /// オプション 設定あり
        /// </summary>
        public const string LOGOUTPUT_ON = "ON";

        /// <summary>
        /// オプション 設定なし
        /// </summary>
        public const string LOGOUTPUT_OFF = "OFF";

        /// <summary>
        /// CPU使用率 （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_CPU = "CPU(%)={0},";

        /// <summary>
        /// メモリ使用量/容量 （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_MEM = "MEM(MB)={0},";

        /// <summary>
        /// ディスク使用量/容量 （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_DISK = "DISK(MB)={0},";

        /// <summary>
        /// 全体バックアップ （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_FULLBACKUP = "{0}={1},{2},{3},{4},{5},{6},{7},";

        /// <summary>
        /// 全体バックアップエラー時 （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_FULLBACKUP_ERR = "DB={0},";

        /// <summary>
        /// マスタ件数 （ログ出力）
        /// </summary>
        public const string LOGOUTPUT_INFO_MSTCNT = "{0}={1},";

        /// <summary>
        /// マスタ
        /// </summary>
        public const string LOGOUTPUT_MST = "MST";

        #endregion // 定数

        #region プライベートフィールド

        /// <summary>
        /// リトライ回数
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// リトライ間隔
        /// </summary>
        private int _retryInterval;

        /// <summary>
        /// PC名を取得（0：取得する、1：取得しない）
        /// </summary>
        private int _machineNameInfo;

        /// <summary>
        /// システム形態を取得（スタンドアロン、C/S）（0：取得する、1：取得しない）
        /// </summary>
        private int _systemFormInfo;

        /// <summary>
        /// CPU使用率を取得（0：取得する、1：取得しない）
        /// </summary>
        private int _cpuUsageInfo;

        /// <summary>
        /// メモリ使用量/容量を取得（0：取得する、1：取得しない）
        /// </summary>
        private int _memUsageInfo;

        /// <summary>
        /// ディスク使用量/容量を取得（0：取得する、1：取得しない）
        /// </summary>
        private int _diskUsageInfo;

        /// <summary>
        /// 全体バックアップ情報を取得（0：取得する、1：取得しない）
        /// </summary>
        private int _fullBackupInfo;

        /// <summary>
        /// 価格マスタの件数を取得（0：取得する、1：取得しない）
        /// </summary>
        private int _tableCntInfo;

        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        private int _clcLogOutputInfo;

        // EnvSurvCommn
        private EnvSurvCommn esc = null;

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
        public EnvSurvAcsParam()
        {
            try
            {
                // EnvSurvCommn
                esc = new EnvSurvCommn();

                #region 設定ファイル取得

                // 初期値設定
                _retryCount = RETRY_COUNT_DEFAULT;                     // リトライ回数
                _retryInterval = RETRY_INTERVAL_DEFAULT;               // リトライ間隔(秒)
                _machineNameInfo = GET_MACHINE_NAME_INFO;              // PC名を取得
                _systemFormInfo = GET_SYSTEM_FORM_INFO;                // システム形態を取得
                _cpuUsageInfo = GET_CPU_USAGE_INFO;                    // CPU使用率を取得
                _memUsageInfo = GET_MEM_USAGE_INFO;                    // メモリ使用量/容量を取得
                _diskUsageInfo = GET_DISK_USAGE_INFO;                  // ディスク使用量/容量を取得
                _fullBackupInfo = GET_FULL_BACKUP_INFO;                // 全体バックアップ情報を取得
                _tableCntInfo = GET_TABLE_CNT_INFO;                    // 件数取得対象テーブルの件数を取得
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;           // CLCサーバにログ出力

                string fileName = this.InitializeXmlSettings();

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    try
                    {
                        using (XmlReader reader = XmlReader.Create(fileName, settings))
                        {
                            while (reader.Read())
                            {
                                if (reader.IsStartElement("RetryCount")) _retryCount = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("RetryInterval")) _retryInterval = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetMachineNameInfo")) _machineNameInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetSystemFormInfo")) _systemFormInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetCpuUsageInfo")) _cpuUsageInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetMemUsageInfo")) _memUsageInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetDiskUsageInfo")) _diskUsageInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetFullBackupInfo")) _fullBackupInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetTableCntInfo")) _tableCntInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        //ログ出力
                        esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AB EnvSurvAcsParam Exception", ex.Message));
                    }
                }
                #endregion // タイムアウト


            }
            catch (Exception)
            {
                // オフライン時はnullをセット
            }
        }

        # endregion ■ Constructor

        #region ■ Public Methods

        #region プロパティ

        /// <summary>
        /// リトライ回数
        /// </summary>
        public int RetryCount
        {
            get { return _retryCount; }
            set { _retryCount = value; }
        }

        /// <summary>
        /// リトライ間隔(秒)
        /// </summary>
        public int RetryInterval
        {
            get { return _retryInterval; }
            set { _retryInterval = value; }
        }

        /// <summary>
        /// PC名を取得
        /// </summary>
        public int MachineNameInfo
        {
            get { return _machineNameInfo; }
            set { _machineNameInfo = value; }
        }

        /// <summary>
        ///システム形態を取得
        /// </summary>
        public int SystemFormInfo
        {
            get { return _systemFormInfo; }
            set { _systemFormInfo = value; }
        }

        /// <summary>
        /// CPU使用率を取得
        /// </summary>
        public int CpuUsageInfo
        {
            get { return _cpuUsageInfo; }
            set { _cpuUsageInfo = value; }
        }

        /// <summary>
        /// メモリ使用量/容量を取得
        /// </summary>
        public int MemUsageInfo
        {
            get { return _memUsageInfo; }
            set { _memUsageInfo = value; }
        }

        /// <summary>
        /// ディスク使用量/容量を取得
        /// </summary>
        public int DiskUsageInfo
        {
            get { return _diskUsageInfo; }
            set { _diskUsageInfo = value; }
        }

        /// <summary>
        /// 全体バックアップ情報を取得
        /// </summary>
        public int FullBackupInfo
        {
            get { return _fullBackupInfo; }
            set { _fullBackupInfo = value; }
        }

        /// <summary>
        /// 価格マスタの件数を取得
        /// </summary>
        public int TableCntInfo
        {
            get { return _tableCntInfo; }
            set { _tableCntInfo = value; }
        }

        /// <summary>
        /// CLCサーバにログ出力
        /// </summary>
        public int ClcLogOutputInfo
        {
            get { return _clcLogOutputInfo; }
            set { _clcLogOutputInfo = value; }
        }

        #endregion  // プロパティ

        #endregion // ■ Public Methods

        #region ■ Private Methods

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル設定情報取得処理
        /// ファイルが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch(Exception ex)
            {
                //ログ出力
                esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AB InitializeXmlSettings Exception", ex.Message));
            }

            return path;
        }
        #endregion  //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダのパス取得
        /// フォルダが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = esc.GetRegistryKeyUserAP();

                if (keyForUSERAP == null)
                {
                    // レジストリ情報を取得できない場合は初期ディレクトリ
                    // 運用上ありえないケース
                    homeDir = defaultDir;
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch(Exception ex)
            {
                //ログ出力
                esc.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00151AB GetCurrentDirectory Exception", ex.Message));

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // カレントフォルダ


        #endregion // ■ Private Methods
    }
}

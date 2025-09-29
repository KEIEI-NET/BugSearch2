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
// 管理番号  11601223-00 作成担当 : 続木
// 修 正 日  2021/09/09  修正内容 : ローカルファイル削除漏れ、不要な例外出力抑止対応
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンバート対象バックアップConvObjSingleBkDBParam
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バックアップConvObjSingleBkDBParam</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br>Update Note: ローカルファイル削除漏れ、不要な例外出力抑止対応</br>
    /// <br>Programmer : 続木</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjSingleBkDBParam
    {
        #region 列挙体

        /// <summary>
        /// コンバート対象バックアップの結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>成功（コンバートなし）</summary>
            NormalNotFound = 4
          , /// <summary>Error</summary>
            Error = 9
          , /// <summary>バックアップ処理開始</summary>
            BkStart = 1000

          , /// <summary>価格マスタ取得</summary>
            MstGet = 2000
          , /// <summary>DataTable作成</summary>
            DataTableCreate = 2001
          , /// <summary>価格マスタ取得SQL例外エラー(2008)</summary>
            MstGetSqlExError = 2008
          , /// <summary>価格マスタ取得例外エラー(2009)</summary>
            MstGetExError = 2009
          , /// <summary>DataTable展開</summary>
            DataTableDeploy = 2010
          , /// <summary>DataTableバックアップ</summary>
            DataTableBackup = 2020
          , /// <summary>DataTableバックアップエラー(2027)</summary>
            DataTableBackupError2027 = 2027
          , /// <summary>DataTableバックアップ例外エラー(2028)</summary>
            DataTableBackupError2028 = 2028
          , /// <summary>DataTableバックアップエラー(2029)</summary>
            DataTableBackupExError = 2029
          , /// <summary>バックアップ処理インスタンス生成</summary>
            ConvObjBackupCreate = 2080
          , /// <summary>バックアップ圧縮</summary>
            ConvObjBackupZipEntry = 2082
          , /// <summary>バックアップインスタンス解放例外エラー</summary>
            ConvObjBackupZipEntryExError = 2083
          , /// <summary>バックアップ情報登録</summary>
            BkInfoEnt = 2100
          , /// <summary>バックアップ情報登録エラー</summary>
            BkInfoEntError = 2101
          , /// <summary>バックアップ情報登録パラメータエラー(2107)</summary>
            BkInfoEntParamError = 2107
          , /// <summary>バックアップ情報登録SQL例外エラー(2108)</summary>
            BkInfoEntSqlExError = 2108
          , /// <summary>バックアップ情報登録例外エラー(2109)</summary>
            BkInfoEntExError = 2109
          , /// <summary>バックアップ作業ディレクトリ取得</summary>
            BkGetDirectory = 2300
          , /// <summary>バックアップデータ文字列変換</summary>
            BkConvStr = 2301
          , /// <summary>バックアップデータ暗号化</summary>
            BkEncrypt = 2302
          , /// <summary>バックアップファイル生成</summary>
            BkStream = 2303
          , /// <summary>バックアップデータエントリ挿入(2304)</summary>
            BkEntryPut = 2304
          , /// <summary>バックアップデータ書き込み</summary>
            BkWrite = 2305
          , /// <summary>バックアップデータ圧縮元ファイル削除(2306)</summary>
            BkSourceDel = 2306

          , /// <summary>コンバート対象バックアップ　データベース接続エラー(3001)</summary>
            COAUPError3001 = 3001
          , /// <summary>コンバート対象バックアップ　トランザクション開始エラー(3002)</summary>
            COAUPError3002 = 3002
          , /// <summary>コンバート対象バックアップ　アプリケーションロック　リソース名取得エラー(3003)</summary>
            COAUPError3003 = 3003
          , /// <summary>コンバート対象バックアップ　アプリケーションロックエラー(3004)</summary>
            COAUPError3004 = 3004
          , /// <summary>コンバート対象バックアップ　バックアップ情報取得エラー(3005)</summary>
            COAUPError3005 = 3005
          , /// <summary>コンバート対象バックアップ　バックアップ世代取得(3006)</summary>
            COAUPError3006 = 3006
          , /// <summary>コンバート対象バックアップ　アプリケーションロックリリースエラー(3008)</summary>
            COAUPError3008 = 3008

          , /// <summary>AWSアップロード(4001)</summary>
            AWSUpload = 4001
          , /// <summary>AWSアップロード例外エラー(4009)</summary>
            AWSUploadExError = 4001

          , /// <summary>旧バックアップ削除例外エラー(4109)</summary>
            OldBkDeleteExError = 4109
          , /// <summary>旧バックアップ削除 コンバート対象管理マスタ取得エラー(4111)</summary>
            OldBkDeleteGetConvObjBkMngError = 4111
          , /// <summary>旧バックアップ削除 コンバート対象管理マスタ取得SQLエラー(4118)</summary>
            OldBkDeleteGetConvObjBkMngSqlError = 4118
          , /// <summary>旧バックアップ削除 コンバート対象管理マスタ取得例外エラー(4119)</summary>
            OldBkDeleteGetConvObjBkMngExError = 4119
          , /// <summary>旧バックアップ削除 AWSファイル削除エラー(4121)</summary>
            OldBkDeleteAWSDeleteError = 4121
          , /// <summary>旧バックアップ削除 AWSファイル例外エラー(4129)</summary>
            OldBkDeleteAWSDeleteExError = 4129
          , /// <summary>旧バックアップ削除 ローカルファイル削除エラー(4131)</summary>
            OldBkDeleteLocalDeleteError = 4131
          , /// <summary>旧バックアップ削除 ローカルファイル例外エラー(4139)</summary>
            OldBkDeleteLocalDeleteExError = 4139
          , /// <summary>旧バックアップ削除 コンバート対象管理マスタ削除エラー(4131)</summary>
            OldBkDeleteUpdConvObjBkMngError = 4141
          , /// <summary>旧バックアップ削除 コンバート対象管理マスタSQL例外エラー(4139)</summary>
            OldBkDeleteUpdConvObjBkMngSqlExError = 4149
          , /// <summary>旧バックアップ削除 コンバート対象管理マスタ例外エラー(4139)</summary>
            OldBkDeleteUpdConvObjBkMngExError = 4149
          // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応-------->>>>>
          , /// <summary>旧バックアップ削除 ローカルバックアップファイルパス取得例外エラー(4159)</summary>
            OldBkDeleteGetLocalFilesExError = 4159
          // ------ ADD 2021/09/09 続木 バックアップ削除漏れ、不要な例外出力抑止対応--------<<<<<

          , /// <summary>データベース接続エラー(5001)</summary>
            GetDataBaseConnectError = 5001
          , /// <summary>データベース接続例外エラー(5009)</summary>
            GetDataBaseConnectExError = 5009
          , /// <summary>データベース接続エラー(5101)</summary>
            AWSGetDataBaseConnectError = 5101
          , /// <summary>データベース接続例外エラー(5109)</summary>
            AWSGetDataBaseConnectExError = 5109
          , /// <summary>トランザクション開始エラー(6001)</summary>
            GetDataBaseTransactionError = 6001
          , /// <summary>トランザクション開始例外エラー(6009)</summary>
            GetDataBaseTransactionExError = 6009
          , /// <summary>バックアップ情報チェックエラー(7001)</summary>
            EnvBackupInfError = 7001
          , /// <summary>バックアップ取得済み(7002)</summary>
            EnvBackupExists = 7002
          , /// <summary>バックアップSQL例外エラー(7008)</summary>
            EnvBackupInfSqlExError = 7008
          , /// <summary>バックアップ例外エラー(7009)</summary>
            EnvBackupInfExError = 7009
          , /// <summary>バックアップ情報取得エラー(7101)</summary>
            EnvBackupInfGetError = 7101
          , /// <summary>バックアップ情報取得SQL例外エラー(7108)</summary>
            EnvBackupInfGetSqlExError = 7108
          , /// <summary>バックアップ情報取得例外エラー(7109)</summary>
            EnvBackupInfGetExError = 7109
          , /// <summary>コンバート対象エラー(8001)</summary>
            VerObjMstBkProcError = 8001
          , /// <summary>DBアプリケーションロックエラー(9001)</summary>
            GetApplicationLockError = 9001
          , /// <summary>DBアプリケーションロックタイムアウトエラー(9004)</summary>
            GetApplicationLockTimeout = 9004
          , /// <summary>DBアプリケーションロック例外エラー(9009)</summary>
            GetApplicationLockExError = 9009
        };

        /// <summary>
        /// 制御（0：チェックする、1：チェックしない）
        /// </summary>
        public enum CheckObjCode
        {
            /// <summary>チェックする</summary>
            ON = 0
          , /// <summary>チェックしない</summary>
            OFF = 1
        };

        /// <summary>
        /// 出力（0：出力する、1：出力しない）
        /// </summary>
        public enum OutputCode
        {
            /// <summary>出力する</summary>
            ON = 0
          , /// <summary>出力しない</summary>
            OFF = 1
        };

        #endregion //列挙体

        #region 定数

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00163R_Setting.xml";

        /// <summary>
        /// リトライ回数
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// リトライ間隔(ミリ秒)　10000ミリ秒・・・　10秒
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 10000;

        /// <summary>
        /// バックアップ世代
        /// </summary>
        private const int BK_GENERATION = 3;

        /// <summary>
        /// DBコマンドタイムアウト（秒）　1800秒・・・30分
        /// </summary>
        private const int DB_COMMAND_TIMEOUT = 1800;

        /// <summary>
        /// アプリケーションロックタイムアウト（ミリ秒） 1800000ミリ秒・・・30分
        /// </summary>
        private const int APPLICATION_LOCK_TIMEOUT = 1800000;

        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        private const int GET_CLC_LOG_OUTPUT_INFO = 1;

        /// <summary>
        ///  WebRequest Access Check（0：する、1：しない）
        /// </summary>
        private const int GET_WEB_ACCESS_CHECK_CONTROL = 0;

        #endregion // 定数

        #region プライベートフィールド

        /// <summary>
        /// リトライ回数
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// リトライ間隔(ミリ秒)
        /// </summary>
        private int _retryInterval;

        /// <summary>
        /// バックアップ世代
        /// </summary>
        private int _bkGeneration;

        /// <summary>
        /// DBコマンドタイムアウト（秒）
        /// </summary>
        private int _dbCommandTimeout;

        /// <summary>
        /// アプリケーションロックタイムアウト（ミリ秒）
        /// </summary>
        private int _dbApplicationLockTimeout;

        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        private int _clcLogOutputInfo;

        /// <summary>
        /// WebRequest Access Check（0：する、1：しない）
        /// </summary>
        private int _webAccessCheckControl;

        #endregion //プライベートフィールド

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
        public ConvObjSingleBkDBParam()
        {
            try
            {
                #region 設定ファイル取得

                // 初期値設定
                _retryCount = RETRY_COUNT_DEFAULT;                                      // リトライ回数
                _retryInterval = RETRY_INTERVAL_DEFAULT;                                // リトライ間隔(ミリ秒)
                _bkGeneration = BK_GENERATION;                                          // バックアップ世代
                _dbCommandTimeout = DB_COMMAND_TIMEOUT;                                 // DBコマンドタイムアウト（秒）
                _dbApplicationLockTimeout = APPLICATION_LOCK_TIMEOUT;                   // アプリケーションロックタイムアウト（ミリ秒）
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;                            // CLCサーバにログ出力
                _webAccessCheckControl = GET_WEB_ACCESS_CHECK_CONTROL;                  // WebRequest Access Check

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
                                if (reader.IsStartElement("BkGeneration")) _bkGeneration = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbCommandTimeout")) _dbCommandTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbApplicationLockTimeout")) _dbApplicationLockTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("WebAccessCheckControl")) _webAccessCheckControl = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                    catch
                    {
                        //ログ出力
                    }
                }
                #endregion // 設定ファイル取得

            }
            catch
            {
                // オフライン時はnullをセット
            }
        }

        #endregion //コンストラクタ

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
        /// バックアップ世代
        /// </summary>
        public int BkGeneration
        {
            get { return _bkGeneration; }
            set { _bkGeneration = value; }
        }

        /// <summary>
        /// DBコマンドタイムアウト（秒）
        /// </summary>
        public int DbCommandTimeout
        {
            get { return _dbCommandTimeout; }
            set { _dbCommandTimeout = value; }
        }

        /// <summary>
        /// アプリケーションロックタイムアウト（ミリ秒）
        /// </summary>
        public int DbApplicationLockTimeout
        {
            get { return _dbApplicationLockTimeout; }
            set { _dbApplicationLockTimeout = value; }
        }

        /// <summary>
        /// CLCサーバにログ出力
        /// </summary>
        public int ClcLogOutputInfo
        {
            get { return _clcLogOutputInfo; }
            set { _clcLogOutputInfo = value; }
        }

        /// <summary>
        /// WebRequest Access Check
        /// </summary>
        public int WebAccessCheckControl
        {
            get { return _webAccessCheckControl; }
            set { _webAccessCheckControl = value; }
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
        /// <br>Programmer : 小原</br>
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
            catch
            {
                //ログ出力
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
        /// <br>Programmer : 小原</br>
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
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
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
            catch
            {
                //ログ出力
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

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新メンテナンス
// プログラム概要   : コンバート対象自動更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンバート対象自動更新ConvObjDBParam
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新ConvObjDBParam</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjDBParam
    {
        #region 列挙体

        /// <summary>
        /// コンバート対象自動更新の結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>成功（コンバートなし）</summary>
            NormalNotFound = 4
          , /// <summary>Error</summary>
            Error = 9
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
          , /// <summary>DataTable変換</summary>
            DataTableConv = 2030
          , /// <summary>一時テーブル作成</summary>
            TempTableCreate = 2040
          , /// <summary>一時テーブル作成SQL例外エラー(2048)</summary>
            TempTableCreateSqlExError = 2048
          , /// <summary>一時テーブル登録</summary>
            TempTableIns = 2050
          , /// <summary>一時テーブル登録SQL例外エラー(2051)</summary>
            TempTableInsSqlExError = 2051
          , /// <summary>一時テーブル最終登録</summary>
            TempTableLastIns = 2052
          , /// <summary>一時テーブル最終登録SQL例外エラー(2053)</summary>
            TempTableLastInsSqlExError = 2053
          , /// <summary>マスタ更新</summary>
            MstUpd = 2060
          , /// <summary>マスタ更新SQL例外エラー(2068)</summary>
            MstUpdSqlExError = 2068
          , /// <summary>マスタ更新例外エラー(2069)</summary>
            MstUpdExError = 2069
          , /// <summary>一時テーブル削除</summary>
            TempTableDelete = 2070
          , /// <summary>一時テーブル削除SQL例外エラー</summary>
            TempTableDeleteSqlExError = 2078
          , /// <summary>バックアップ処理インスタンス生成</summary>
            ConvObjBackupCreate = 2080
          , /// <summary>バックアップ処理インスタンス生成例外エラー</summary>
            ConvObjBackupCreateExError = 2081
          , /// <summary>バックアップインスタンス解放</summary>
            ConvObjBackupDispose = 2082
          , /// <summary>バックアップインスタンス解放例外エラー</summary>
            ConvObjBackupDisposeExError = 2083
          , /// <summary>バージョン管理マスタ更新</summary>
            VerObjVerMstUpd = 2100
          , /// <summary>バージョン管理マスタ更新SQL例外エラー(2108)</summary>
            VerObjVerMstUpdSqlExError = 2108
          , /// <summary>XACT_ABORT ON</summary>
            XactAbortOn = 2150
          , /// <summary>価格マスタ件数取得</summary>
            MstCntGet = 2200
          , /// <summary>価格マスタ件数取得SQL例外エラー(2008)</summary>
            MstCntGetSqlExError = 2208
          , /// <summary>価格マスタ件数取得例外エラー(2009)</summary>
            MstCntGetExError = 2209
          , /// <summary>単一バックアップ作業ディレクトリ取得</summary>
            BkGetDirectory = 2300
          , /// <summary>バックアップデータ文字列変換</summary>
            BkConvStr = 2301
          , /// <summary>バックアップデータ暗号化</summary>
            BkEncrypt = 2302
          , /// <summary>バックアップファイル生成</summary>
            BkStream = 2303
          , /// <summary>バックアップデータエントリ挿入(2310)</summary>
            BkEntryPut = 2304
          , /// <summary>バックアップデータ書き込み</summary>
            BkWrite = 2305

          , /// <summary>コンバート対象自動更新　データベース接続エラー(3001)</summary>
            COAUPError3001 = 3001
          , /// <summary>コンバート対象自動更新　トランザクション開始エラー(3002)</summary>
            COAUPError3002 = 3002
          , /// <summary>コンバート対象自動更新　アプリケーションロック　リソース名取得エラー(3003)</summary>
            COAUPError3003 = 3003
          , /// <summary>コンバート対象自動更新　アプリケーションロックエラー(3004)</summary>
            COAUPError3004 = 3004
          , /// <summary>コンバート対象自動更新　全体バックアップ範囲外（古い）(3005)</summary>
            COAUPError3005 = 3005
          , /// <summary>コンバート対象自動更新　全体バックアップされていない(3006)</summary>
            COAUPError3006 = 3006
          , /// <summary>コンバート対象自動更新　全体バックアップ情報取得エラー(3007)</summary>
            COAUPError3007 = 3007
          , /// <summary>コンバート対象自動更新　アプリケーションロックリリースエラー(3008)</summary>
            COAUPError3008 = 3008

          , /// <summary>データベース接続エラー(5001)</summary>
            GetDataBaseConnectError = 5001
          , /// <summary>データベース接続例外エラー(5009)</summary>
            GetDataBaseConnectExError = 5009
          , /// <summary>トランザクション開始エラー(6001)</summary>
            GetDataBaseTransactionError = 6001
          , /// <summary>トランザクション開始例外エラー(6009)</summary>
            GetDataBaseTransactionExError = 6009
          , /// <summary>全体バックアップエラー(7001)</summary>
            EnvFullBackupInfError = 7001
          , /// <summary>全体バックアップ範囲外(7002)</summary>
            EnvFullBackupInfOutOfRange = 7002
          , /// <summary>全体バックアップ未実施中断(7003)</summary>
            EnvFullBackupInfInterruption = 7003
          , /// <summary>全体バックアップSQL例外エラー(7008)</summary>
            EnvFullBackupInfSqlExError = 7008
          , /// <summary>全体バックアップ例外エラー(7009)</summary>
            EnvFullBackupInfExError = 7009
          , /// <summary>全体バックアップ購入チェックエラー(7010)</summary>
            EnvFullBackupInfPurchaseError = 7010
          , /// <summary>全体バックアップ購入チェック例外エラー(7011)</summary>
            EnvFullBackupInfPurchaseExError = 7011
          , /// <summary>コンバート対象エラー(8001)</summary>
            VerObjMstUpdProcError = 8001
          , /// <summary>DBアプリケーションロックエラー(9001)</summary>
            GetApplicationLockError = 9001
          , /// <summary>DBアプリケーションロックタイムアウトエラー(9004)</summary>
            GetApplicationLockTimeout = 9004
          , /// <summary>DBアプリケーションロック例外エラー(9009)</summary>
            GetApplicationLockExError = 9009
        };

        /// <summary>
        /// コンバート対象かどうかを判断（0：判断する、1：判断せず強制的に設定する、2：判断せず強制的に解除する）
        /// </summary>
        public enum ConvObjCode
        {
            /// <summary>判断する</summary>
            Decide = 0
          , /// <summary>判断せず強制的に設定する</summary>
            ForceSetting = 1
          , /// <summary>判断せず強制的に解除する</summary>
            ForceCancel = 2
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

        #region 定数定義

        /// <summary>
        /// コンバート対象判定　コンバート対象
        /// </summary>
        public const bool CONVOBJ_ON = true;

        /// <summary>
        /// コンバート対象判定　コンバート対象外
        /// </summary>
        public const bool CONVOBJ_OFF = false;

        /// <summary>
        /// DB名
        /// </summary>
        public const string PMUSERDBName = "PM_USER_DB";

        /// <summary>
        /// バックアップの種類
        /// </summary>
        public const string PMUSERDBType = "D";


        #endregion //定数定義

        #region 定数

        /// <summary>
        /// コンバート対象自動更新処理で例外が発生しました。
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "コンバート対象自動更新処理で例外が発生しました。";

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_Setting.xml";

        /// <summary>
        /// リトライ回数
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// リトライ間隔(ミリ秒)　10000ミリ秒・・・　10秒
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 10000;

        /// <summary>
        /// DBコマンドタイムアウト（秒）　1800秒・・・30分
        /// </summary>
        private const int DB_COMMAND_TIMEOUT = 1800;

        /// <summary>
        /// アプリケーションロックタイムアウト（ミリ秒） 1800000ミリ秒・・・30分
        /// </summary>
        private const int APPLICATION_LOCK_TIMEOUT = 1800000;

        /// <summary>
        /// アプリケーションロック・リリースを制御（0：ロック・リリースする、1：ロック・リリースしない）
        /// </summary>
        private const int APPLICATION_LOCK_RELEASE_CONTROL = 0;

        /// <summary>
        /// DB全体バックアップチェックを制御（0：チェックする、1：チェックしない）
        /// </summary>
        private const int DB_FULL_BACKUP_CHECK_CONTROL = 0;

        /// <summary>
        /// DB全体バックアップされていない場合、処理を中断するか制御（0：中断する、1：中断しない）
        /// </summary>
        private const int DB_FULL_BACKUP_SUSPENSION_CONTROL = 0;

        /// <summary>
        /// DB全体バックアップチェック範囲（0：制限あり、1：制限なし）
        /// </summary>
        private const int DB_FULL_BACKUP_CHECK_RANGE_CONTROL = 0;

        /// <summary>
        /// DB全体バックアップチェック範囲時間（0：実行時間を起点に48時間以内、999：実行時間を起点に指定時間以内）　単位：時間
        /// </summary>
        private const int DB_FULL_BACKUP_CHECK_RANGE_TIME = 0;

        /// <summary>
        /// コンバート対象かどうかを判断（0：判断する、1：判断せず強制的に設定する、2：判断せず強制的に解除する）
        /// </summary>
        private const int CONVERSION_TARGET_CONTROL = 0;

        /// <summary>
        /// 価格マスタのバックアップを制御（0：アックアップする、1：バックアップしない）
        /// </summary>
        private const int MST_BACKUP_CONTROL = 0;

        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        private const int GET_CLC_LOG_OUTPUT_INFO = 0;

        /// <summary>
        ///  WebRequest Access Check（0：する、1：しない）
        /// </summary>
        private const int GET_WEB_ACCESS_CHECK_CONTROL = 0;

        /// <summary>
        ///  価格マスタ更新単位件数（更新件数）
        /// </summary>
        private const int MST_UPDATE_BREAK_COUNT = 100000;

        /// <summary>
        /// 検索タイプのオプションチェックを制御（0：チェックする、1：チェックしない）
        /// </summary>
        private const int SEARCH_TYPE_OPTION_CHECK_CONTROL = 0;

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
        /// DBコマンドタイムアウト（秒）
        /// </summary>
        private int _dbCommandTimeout;

        /// <summary>
        /// アプリケーションロックタイムアウト（ミリ秒）
        /// </summary>
        private int _dbApplicationLockTimeout;

        /// <summary>
        /// アプリケーションロック・リリースを制御（0：ロック・リリースする、1：ロック・リリースしない）
        /// </summary>
        private int _applicationLockReleaseControl;

        /// <summary>
        /// DB全体バックアップチェックを制御（0：チェックする、1：チェックしない）
        /// </summary>
        private int _dbFullBackupCheckControl;

        /// <summary>
        /// DB全体バックアップされていない場合、処理を中断するか制御（0：中断する、1：中断しない）
        /// </summary>
        private int _dbFullBackupSuspensionControl;

        /// <summary>
        /// DB全体バックアップチェック範囲（0：制限あり、1：制限なし）
        /// </summary>
        private int _dbFullBackupCheckRangeControl;

        /// <summary>
        /// DB全体バックアップチェック範囲時間（0：実行時間を起点に48時間以内、999：実行時間を起点に指定時間以内）　単位：時間
        /// </summary>
        private int _dbFullBackupCheckRangeTime;

        /// <summary>
        /// コンバート対象かどうかを判断（0：判断する、1：判断せず強制的に設定する、2：判断せず強制的に解除する）
        /// </summary>
        private int _conversionTargetControl;

        /// <summary>
        /// 価格マスタのバックアップを制御（0：アックアップする、1：バックアップしない）
        /// </summary>
        private int _mstBackupControl;

        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        private int _clcLogOutputInfo;

        /// <summary>
        /// WebRequest Access Check（0：する、1：しない）
        /// </summary>
        private int _webAccessCheckControl;

        /// <summary>
        /// 価格マスタ更新単位件数（更新件数）
        /// </summary>
        private int _mstUpdateBreakCount;

        /// <summary>
        /// 検索タイプのオプションチェックを制御（0：チェックする、1：チェックしない）
        /// </summary>
        private int _searchTypeOptionCheckControl;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象自動更新パラメータクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjDBParam()
        {
            try
            {
                #region 設定ファイル取得

                // 初期値設定
                _retryCount = RETRY_COUNT_DEFAULT;                                      // リトライ回数
                _retryInterval = RETRY_INTERVAL_DEFAULT;                                // リトライ間隔(ミリ秒)
                _dbCommandTimeout = DB_COMMAND_TIMEOUT;                                 // DBコマンドタイムアウト（秒）
                _dbApplicationLockTimeout = APPLICATION_LOCK_TIMEOUT;                   // アプリケーションロックタイムアウト（ミリ秒）
                _applicationLockReleaseControl = APPLICATION_LOCK_RELEASE_CONTROL;      // アプリケーションロック・リリースを制御（0：ロック・リリースする、1：ロック・リリースしない）
                _dbFullBackupCheckControl = DB_FULL_BACKUP_CHECK_CONTROL;               // DB全体バックアップチェックを制御（0：チェックする、1：チェックしない）
                _dbFullBackupSuspensionControl = DB_FULL_BACKUP_SUSPENSION_CONTROL;     // DB全体バックアップされていない場合、処理を中断するか制御（0：中断する、1：中断しない）
                _dbFullBackupCheckRangeControl = DB_FULL_BACKUP_CHECK_RANGE_CONTROL;    // DB全体バックアップチェック範囲（0：制限あり、1：制限なし）
                _dbFullBackupCheckRangeTime = DB_FULL_BACKUP_CHECK_RANGE_TIME;          // DB全体バックアップチェック範囲時間（0：実行時間を起点に48時間以内、999：実行時間を起点に指定時間以内）　単位：時間
                _conversionTargetControl = CONVERSION_TARGET_CONTROL;                   // コンバート対象かどうかを判断（0：判断する、1：判断せず強制的に設定する、2：判断せず強制的に解除する）
                _mstBackupControl = MST_BACKUP_CONTROL;                                 // 価格マスタのバックアップを制御（0：アックアップする、1：バックアップしない）
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;                            // CLCサーバにログ出力
                _webAccessCheckControl = GET_WEB_ACCESS_CHECK_CONTROL;                  // WebRequest Access Check
                _mstUpdateBreakCount = MST_UPDATE_BREAK_COUNT;                          // 価格マスタ更新単位件数（更新件数）
                _searchTypeOptionCheckControl = SEARCH_TYPE_OPTION_CHECK_CONTROL;       // 検索タイプのオプションチェックを制御（0：チェックする、1：チェックしない）

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
                                if (reader.IsStartElement("DbCommandTimeout")) _dbCommandTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbApplicationLockTimeout")) _dbApplicationLockTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("ApplicationLockReleaseControl")) _applicationLockReleaseControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupCheckControl")) _dbFullBackupCheckControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupSuspensionControl")) _dbFullBackupSuspensionControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupCheckRangeControl")) _dbFullBackupCheckRangeControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("DbFullBackupCheckRangeTime")) _dbFullBackupCheckRangeTime = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("ConversionTargetControl")) _conversionTargetControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("MstBackupControl")) _mstBackupControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("WebAccessCheckControl")) _webAccessCheckControl = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("MstUpdateBreakCount")) _mstUpdateBreakCount = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("SearchTypeOptionCheckControl")) _searchTypeOptionCheckControl = reader.ReadElementContentAsInt();
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
        /// アプリケーションロック・リリースを制御（0：ロック・リリースする、1：ロック・リリースしない）
        /// </summary>
        public int ApplicationLockReleaseControl
        {
            get { return _applicationLockReleaseControl; }
            set { _applicationLockReleaseControl = value; }
        }

        /// <summary>
        /// DB全体バックアップチェックを制御（0：チェックする、1：チェックしない）
        /// </summary>
        public int DbFullBackupCheckControl
        {
            get { return _dbFullBackupCheckControl; }
            set { _dbFullBackupCheckControl = value; }
        }

        /// <summary>
        /// DB全体バックアップされていない場合、処理を中断するか制御（0：中断する、1：中断しない）
        /// </summary>
        public int DbFullBackupSuspensionControl
        {
            get { return _dbFullBackupSuspensionControl; }
            set { _dbFullBackupSuspensionControl = value; }
        }

        /// <summary>
        /// DB全体バックアップチェック範囲（0：制限あり、1：制限なし）
        /// </summary>
        public int DbFullBackupCheckRangeControl
        {
            get { return _dbFullBackupCheckRangeControl; }
            set { _dbFullBackupCheckRangeControl = value; }
        }

        /// <summary>
        /// DB全体バックアップチェック範囲時間（0：実行時間を起点に48時間以内、999：実行時間を起点に指定時間以内）　単位：時間
        /// </summary>
        public int DbFullBackupCheckRangeTime
        {
            get { return _dbFullBackupCheckRangeTime; }
            set { _dbFullBackupCheckRangeTime = value; }
        }

        /// <summary>
        /// コンバート対象かどうかを判断（0：判断する、1：判断せず強制的に設定する、2：判断せず強制的に解除する）
        /// </summary>
        public int ConversionTargetControl
        {
            get { return _conversionTargetControl; }
            set { _conversionTargetControl = value; }
        }

        /// <summary>
        /// 価格マスタのバックアップを制御（0：アックアップする、1：バックアップしない）
        /// </summary>
        public int MstBackupControl
        {
            get { return _mstBackupControl; }
            set { _mstBackupControl = value; }
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

        /// <summary>
        /// 価格マスタ更新単位件数（更新件数）
        /// </summary>
        public int MstUpdateBreakCount
        {
            get { return _mstUpdateBreakCount; }
            set { _mstUpdateBreakCount = value; }
        }

        /// <summary>
        /// 検索タイプのオプションチェックを制御（0：チェックする、1：チェックしない）
        /// </summary>
        public int SearchTypeOptionCheckControl
        {
            get { return _searchTypeOptionCheckControl; }
            set { _searchTypeOptionCheckControl = value; }
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

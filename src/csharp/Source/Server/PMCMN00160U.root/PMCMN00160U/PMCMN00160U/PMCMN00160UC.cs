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
using Broadleaf.Application.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 設定パラメータ
    /// </summary>
    /// <remarks>
    /// <br>Note		: コンバート対象自動バックアップのアクセス制御を行います。</br>
    /// <br>Programmer	: 小原</br>
    /// <br>Date		: 2020/06/15</br>
    /// </remarks>
    public class ConvObjBkParam
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

        #region 列挙体

        /// <summary>
        /// コンバート対象自動バックアップの結果ステータス列挙体
        /// </summary>
        public enum StatusCode
        {
            /// <summary>成功</summary>
            Normal = 0
          , /// <summary>成功（コンバートなし）</summary>
            NormalNotFound = 4
          , /// <summary>オプション無効</summary>
            OptPmSecurityMeasuresInvalid = -1
          , /// <summary>致命的エラー</summary>
            Error = -1000
          , /// <summary>致命的エラー(1001)</summary>
            Error1001 = -1001
          , /// <summary>致命的エラー(1002)</summary>
            Error1002 = -1002
          , /// <summary>致命的エラー(1003)</summary>
            Error1003 = -1003
          , /// <summary>致命的エラー(1004)</summary>
            Error1004 = -1004
          , /// <summary>致命的エラー(1005)</summary>
            Error1005 = -1005
          , /// <summary>パラメータ不正(1009)</summary>
            ParamErr = -1009
          , /// <summary>致命的エラー(1010)</summary>
            Error1010 = -1010
          , /// <summary>致命的エラー(1011)</summary>
            Error1011 = -1011
          , /// <summary>致命的エラー(1012)</summary>
            Error1012 = -1012
          , /// <summary>致命的エラー(1013)</summary>
            Error1013 = -1013
        };

        /// <summary>
        /// CLCログ出力
        /// </summary>
        public enum CLCOutputCode
        {
            /// <summary>出力する</summary>
            Enable = 0
          , /// <summary>出力しない</summary>
            Disable = 1
        };

        #endregion //列挙体

        #region 定数

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00160U_Setting.xml";

        /// <summary>
        /// リトライ回数
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 5;

        /// <summary>
        /// リトライ間隔(ミリ秒)
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 5000;

        /// <summary>
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        public const int GET_CLC_LOG_OUTPUT_INFO = 1;

        /// <summary>
        /// バックアップ作成待ち時間(ミリ秒)
        /// </summary>
        public const int BK_CREATE_WAIT_DEFAULT = 60000;

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
        /// CLCサーバにログ出力（0：出力する、1：出力しない）
        /// </summary>
        private int _clcLogOutputInfo;

        /// <summary>
        /// バックアップ作成待ち時間(ミリ秒)
        /// </summary>
        private int _bkCreateWait;

        /// <summary>
        /// ログ出力
        /// </summary>
        private static LogInfoAllCls logInfoAllCls = null;

        #endregion //プライベートフィールド


        # region ■ Constructor

        /// <summary>
        /// 設定パラメータコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 設定パラメータの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        public ConvObjBkParam()
        {
            try
            {
                #region 設定ファイル取得

                // 初期値設定
                _retryCount = RETRY_COUNT_DEFAULT;                                      // リトライ回数
                _retryInterval = RETRY_INTERVAL_DEFAULT;                                // リトライ間隔(秒)
                _clcLogOutputInfo = GET_CLC_LOG_OUTPUT_INFO;                            // CLCサーバにログ出力
                _bkCreateWait = BK_CREATE_WAIT_DEFAULT;                                 // バックアップ作成待ち時間

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
                                if (reader.IsStartElement("GetClcLogOutputInfo")) _clcLogOutputInfo = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("BkCreateWait")) _bkCreateWait = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        if (_clcLogOutputInfo == (int)CLCOutputCode.Enable)
                        {
                            //ログ出力
                            logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC ConvObjBkParam Exception", ex.Message));
                        }
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
        /// リトライ間隔(ミリ秒)
        /// </summary>
        public int RetryInterval
        {
            get { return _retryInterval; }
            set { _retryInterval = value; }
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
        /// バックアップ作成待ち時間(ミリ秒)
        /// </summary>
        public int BkCreateWait
        {
            get { return _bkCreateWait; }
            set { _bkCreateWait = value; }
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
            catch(Exception ex)
            {
                //ログ出力
                logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC InitializeXmlSettings Exception", ex.Message));
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
                RegistryKey keyForUSERAP = GetRegistryKeyUserAP();

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
                logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC GetCurrentDirectory Exception", ex.Message));

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // カレントフォルダ

        #region USER_APレジストリ取得

        /// <summary>
        /// USER_APレジストリ取得
        /// </summary>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private RegistryKey GetRegistryKeyUserAP()
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
            catch (Exception ex)
            {
                // 例外
                registryKey = null;
                if (_clcLogOutputInfo == (int)CLCOutputCode.Enable)
                {
                    logInfoAllCls.ClcLogOutput(string.Format("{0}:{1}", "ERR PMCMN00160UC GetRegistryKeyUserAP Exception", ex.Message));
                }
            }

            return registryKey;
        }

        #endregion // USER_APレジストリ取得

        #endregion // ■ Private Methods
    }
}

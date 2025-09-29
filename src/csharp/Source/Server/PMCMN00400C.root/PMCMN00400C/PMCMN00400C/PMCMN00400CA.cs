//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リトライ取得部品
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11770032-00  作成担当 : 譚洪
// 作 成 日  2021/06/10   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Microsoft.Win32;
using System.IO;
using System.Xml;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// リトライ設定取得出力部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : リトライ設定取得を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2021/06/10</br>
    /// </remarks>
    public class RetryXmlGetCommon
    { 
        #region 定数
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
        // リトライ設定XMLファイル
        /// </summary>
        private const string XML_FILE_NAME = @"{0}_RetrySetting.xml";
        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : 2021/06/10</br>
        /// </remarks>
        public RetryXmlGetCommon()
        {
        }

        #endregion // コンストラクタ

        #region publicメソッド 
        /// <summary>
        /// XML情報取得
        /// </summary>
        /// <param name="pgid">プログラムID</param>
        /// <param name="retryCount">リトライ回数(default)</param> 
        /// <param name="retryInterval">リトライ間隔(default)</param>
        /// <param name="retrySettingInfo">リトライ設定ワーク</param> 
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : 2021/06/10</br>
        /// </remarks>
        public void GetXmlInfo(string pgid, int retryCount, int retryInterval, ref RetrySet retrySettingInfo)
        {
            // XML配置パス
            string installDir = string.Empty;
            // XML設定ファイル
            string xmlFile = string.Empty;
            try
            {
                retrySettingInfo = new RetrySet();
                // カレントディレクトリ取得
                installDir = GetCurrentDirectory(REG_KEY_SERVER);

                // XMLファイル名　PGID_RetrySetting.xml
                xmlFile = string.Format(XML_FILE_NAME, pgid);

                if (UserSettingController.ExistUserSetting(Path.Combine(installDir, xmlFile)))
                {
                    // XMLからリトライ回数とリトライ間隔を取得する
                    retrySettingInfo = UserSettingController.DeserializeUserSetting<RetrySet>(Path.Combine(installDir, xmlFile));
                }
                else
                {
                    // リトライ回数-デフォルト
                    retrySettingInfo.RetryCount = retryCount;
                    // リトライ間隔-デフォルト
                    retrySettingInfo.RetryInterval = retryInterval;
                }
            }
            catch
            {
                if (retrySettingInfo == null) retrySettingInfo = new RetrySet();
                // リトライ回数-デフォルト
                retrySettingInfo.RetryCount = retryCount;
                // リトライ間隔-デフォルト
                retrySettingInfo.RetryInterval = retryInterval;
            }
        }

        #endregion // publicメソッド

        #region privateメソッド

        #region カレントディレクトリ取得

        /// <summary>
        /// カレントディレクトリのパス取得
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <returns>カレントディレクトリフルパス</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : 2021/06/10</br>
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
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : 2021/06/10</br>
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

        #endregion // privateメソッド

    }

    # region
    /// <summary>
    /// リトライ設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リトライ設定クラス</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2021/06/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RetrySet
    {
        // リトライ回数
        private int _retryCount;

        // リトライ間隔
        private int _retryInterval;

        /// <summary>
        /// リトライ設定クラス
        /// </summary>
        public RetrySet()
        {

        }

        /// <summary>リトライ回数</summary>
        public int RetryCount
        {
            get { return this._retryCount; }
            set { this._retryCount = value; }
        }

        /// <summary>リトライ間隔</summary>
        public int RetryInterval
        {
            get { return this._retryInterval; }
            set { this._retryInterval = value; }
        }
    }
    # endregion
}

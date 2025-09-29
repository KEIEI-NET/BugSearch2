//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : タイムアウト取得部品
// プログラム概要   : タイムアウト取得部品
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11770032-00  作成担当 : 佐々木亘
// 作 成 日  2021/04/08   修正内容 : タイムアウト取得部品新規作成
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Xml;
using Microsoft.Win32;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// タイムアウト取得部品
    /// </summary>
    /// <remarks>
    /// <br>Note		: タイムアウト設定値を取得します。</br>
    /// <br>Programmer	: 佐々木亘</br>
    /// <br>Date		: 2021/04/08</br>
    /// </remarks>
    public class CommTimeoutConf
    {
        #region ■ Private Members

        #endregion ■ Private Members

        #region プライベートフィールド

        /// <summary>
        // タイムアウト時間設定ファイル
        /// </summary>
        private const string DBCOMMANDTIMEOUT_XML_FILE_NAME = "{0}_DbCmdTimeout.xml";

        /// <summary>
        // XMLファイルが無い時のデフォルト値
        /// </summary>
        private const int DB_COMMAND_TIMEOUT_DEF = 120;

        /// <summary>
        // レジストリ文字列値の名前
        /// </summary>
        private const string REG_STR_VALUE_NAME = "InstallDirectory";

        /// <summary>
        // XMLコマンドタイムアウト項目名
        /// </summary>
        private const string XML_ELEMENT_SQL_COMMANDTIMEOUT = "SqlCommandTimeout";
        
        /// <summary>
        // レジストリサブキー（32bitOS）
        /// </summary>
        private const string USER_AP_SUB_KEY_x86 = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        // レジストリサブキー（64bitOS）
        /// </summary>
        private const string USER_AP_SUB_KEY_x64 = @"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP";


        #endregion //プライベートフィールド

        # region ■ Constructor

        /// <summary>
        /// タイムアウト設定値取得クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : タイムアウト設定値取得クラスの新しいインスタンスを生成します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2021/04/08</br>
        /// </remarks>
        public CommTimeoutConf()
        {
        }

        #endregion ■ Constructor

        #region ■ Public Methods

        #region タイムアウト設定値取得

        /// <summary>
        /// タイムアウト設定値取得
        /// </summary>
        /// <param name="assemblyId">設定ファイル名のアセンブリID</param>
        /// <returns>タイムアウト時間（秒）</returns>
        /// <remarks>
        /// <br>Note       : タイムアウト値取得</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2021/04/08</br>
        /// </remarks>
        public int GetDbCommandTimeout(string assemblyId)
        {
            return GetDbCommandTimeout(assemblyId, DB_COMMAND_TIMEOUT_DEF);
        }

        /// <summary>
        /// タイムアウト設定値取得
        /// </summary>
        /// <param name="assemblyId">設定ファイル名のアセンブリID</param>
        /// <param name="defDbCommandTimeout">デフォルトタイムアウト時間（秒）</param>
        /// <returns>タイムアウト時間（秒）</returns>
        /// <remarks>
        /// <br>Note       : タイムアウト値取得</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date	   : 2021/04/08</br>
        /// </remarks>
        public int GetDbCommandTimeout(string assemblyId, int defDbCommandTimeout)
        {
            return GetXmlInfoDbCommandTimeout(assemblyId, defDbCommandTimeout);
        }

        #endregion // タイムアウト設定値取得

        #endregion // ■ Public Methods

        #region ■ Private Methods

        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="assemblyId">設定ファイル名のアセンブリID</param>
        /// <param name="defDbCommandTimeout">デフォルトタイムアウト時間（秒）</param>
        /// <returns>タイムアウト時間（秒）</returns>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 佐々木亘</br>
        /// <br>Date         : 2021/04/08</br>
        /// </remarks>
        private int GetXmlInfoDbCommandTimeout(string assemblyId, int defDbCommandTimeout)
        {
            // タイムアウト時間設定
            int retDbCommandTimeout = defDbCommandTimeout;

            // XMLファイルFULLPATH
            string xmlFileName = string.Empty;

            XmlReaderSettings xmlReaderSettings = null;

            // XMLファイルFULLPATH取得
            xmlFileName = this.InitializeXmlSettings(assemblyId);

            if (xmlFileName != string.Empty)
            {
                xmlReaderSettings = new XmlReaderSettings();
                try
                {
                    using (XmlReader xmlReader = XmlReader.Create(xmlFileName, xmlReaderSettings))
                    {
                        while (xmlReader.Read())
                        {
                            // XMLファイルからタイムアウト時間を取得
                            if (xmlReader.IsStartElement(XML_ELEMENT_SQL_COMMANDTIMEOUT))
                            {
                                retDbCommandTimeout = xmlReader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch
                {
                    // 例外発生時はデフォルト値を返却
                    retDbCommandTimeout = DB_COMMAND_TIMEOUT_DEF;
                }
            }

            return retDbCommandTimeout;

        }
        #endregion // 設定ファイル取得

        #region XMLファイル名取得
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <param name="assemblyId">設定ファイル名のアセンブリID</param>
        /// <returns>XMLファイルFULLPATH</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 佐々木亘</br>
        /// <br>Date         : 2021/04/08</br>
        /// </remarks>
        private string InitializeXmlSettings(string assemblyId)
        {
            string homeDir = string.Empty;
            string xmlFilePath = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名連結
                xmlFilePath = Path.Combine(homeDir, string.Format(DBCOMMANDTIMEOUT_XML_FILE_NAME, assemblyId));

                // ファイル存在しない場合、空白を設定する
                if (!File.Exists(xmlFilePath))
                {
                    xmlFilePath = string.Empty;
                }
            }
            catch
            {
                // 例外発生時は空白を返却
                xmlFilePath = string.Empty;
            }
            return xmlFilePath;
        }
        #endregion //XMLファイル名取得

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>カレントフォルダ</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ取得</br>
        /// <br>Programmer   : 佐々木亘</br>
        /// <br>Date         : 2021/04/08</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defCurrentDir = string.Empty;
            string retHomeDir = string.Empty;

            // XMLファイル格納ディレクトリ取得（カレントフォルダ）
            try
            {
                // dll格納パスを初期ディレクトリとする
                defCurrentDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(USER_AP_SUB_KEY_x86);

                if (registryKey == null)
                {
                    registryKey = Registry.LocalMachine.OpenSubKey(USER_AP_SUB_KEY_x64);
                    if (registryKey == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        retHomeDir = defCurrentDir;
                    }
                    else
                    {
                        retHomeDir = registryKey.GetValue(REG_STR_VALUE_NAME, defCurrentDir).ToString();
                    }
                }
                else
                {
                    retHomeDir = registryKey.GetValue(REG_STR_VALUE_NAME, defCurrentDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(retHomeDir))
                {
                    retHomeDir = defCurrentDir;
                }
            }
            catch
            {
                // 例外時、カレントフォルダを返却
                if (!string.IsNullOrEmpty(defCurrentDir))
                {
                    retHomeDir = defCurrentDir;
                }
            }
            return retHomeDir;
        }
        #endregion // カレントフォルダ

        #endregion ■ Private Methods
    }
}

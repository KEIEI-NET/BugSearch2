//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新メンテナンス
// プログラム概要   : コンバート対象自動更新を行う
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
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンバート対象自動更新ConvObjEnterpriseParamDB
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新ConvObjEnterpriseParamDB</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjEnterpriseParamDB : RemoteWithAppLockDB
    {
        #region 定数

        /// <summary>
        /// コンバート対象自動更新処理で例外が発生しました。
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "コンバート対象自動更新処理で例外が発生しました。";

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_EnterpriseSetting.xml";

        #endregion // 定数

        #region プライベートフィールド

        /// <summary>
        /// コンバート対象外企業コードリスト
        /// </summary>
        private string[] _convertOffEnterpriseCodeList;

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象自動更新コンバート対象外企業パラメータクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjEnterpriseParamDB()
        {
            try
            {
                #region 設定ファイル取得

                // 初期値設定
                _convertOffEnterpriseCodeList = null;                                   // コンバート対象外企業リスト

                string fileName = this.InitializeXmlSettings();
                string convertOffEnterpriseCode = string.Empty;

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("ConvertOffEnterpriseCodeList")) convertOffEnterpriseCode = reader.ReadElementContentAsString();
                        }

                        if (!string.IsNullOrEmpty(convertOffEnterpriseCode))
                        {
                            // カンマ区切りのリストを配列に変換
                            _convertOffEnterpriseCodeList = convertOffEnterpriseCode.Split(',');
                        }
                    }
                }
                else
                {
                    // ログ出力
                    base.WriteErrorLog("ConvObjEnterpriseParamDB.ConvObjEnterpriseParamDB Exception");

                    // 設定ファイルが存在しない場合中断
                    throw new Exception("ConvObjEnterpriseParamDB Exception");
                }
                #endregion // 設定ファイル取得

            }
            catch(Exception ex)
            {
                // ログ出力
                base.WriteErrorLog(ex, "ConvObjEnterpriseParamDB.ConvObjEnterpriseParamDB Exception");

                // 設定ファイルが存在しない場合中断
                throw;
            }
        }

        #endregion //コンストラクタ

        #region ■ Public Methods

        #region プロパティ

        /// <summary>
        /// コンバート対象外企業リスト
        /// </summary>
        public string[] ConvertOffEnterpriseCodeList
        {
            get { return _convertOffEnterpriseCodeList; }
            set { _convertOffEnterpriseCodeList = value; }
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

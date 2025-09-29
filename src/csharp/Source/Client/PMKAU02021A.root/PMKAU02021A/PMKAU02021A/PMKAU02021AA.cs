//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 電子帳簿連携設定
// プログラム概要   : 電子帳簿連携設定
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00 作成担当 : 3H 尹安
// 作 成 日  2022/03/25  新規作成
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 電子帳簿連携設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        :  電子帳簿連携設定を行う</br>
    /// <br>Programmer	: 3H 尹安</br>
    /// <br>Date		: 2022/03/25</br>
    /// </remarks>
    public class EbooksLinkSetAcs
    {
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/25</br>
        /// </remarks>
        public EbooksLinkSetAcs()
        {
        }
        #endregion

        # region ■Private Members
        /// <summary>電子帳簿連携サポート設定XMLファイル名</summary>
        private const string ctXML_EBOOKLINK_FILE_NAME = "MAKAU03000U_EbooksLinkSetting.XML";
        /// <summary>インストールディレクトリ</summary>
        private const string ctInstallDirectory = "InstallDirectory";
        /// <summary>インストール レジストリキー</summary>
        private const string ctRegistryKey = @"SOFTWARE\Broadleaf\Product\Partsman";
        /// <summary>取引先リスト受け渡しフォルダ初期値</summary>
        private const string ctIniCustomFolderPath = @"eBooks\Customer";
        /// <summary>電子帳簿受け渡しフォルダ初期値</summary>
        private const string ctIniEBooksFolderPath = @"eBooks\eBooks";
        #endregion

        # region[電子帳簿連携サポート設定情報を取得]
        /// <summary>
        /// 電子帳簿連携サポート設定情報を取得
        /// </summary>
        /// <returns>電子帳簿受け渡しフォルダパス</returns>
        public void GetEBooksFolderPath(out EBooksLinkSetInfo eBooksLinkSetInfo)
        {
            eBooksLinkSetInfo = new EBooksLinkSetInfo();
            // Partsmanインストールフォルダ>
            string sInstallFolderPath = GetInstallDirectory();

            // 電子帳簿受け渡しフォルダ　デフォルト値
            eBooksLinkSetInfo.EBooksFolder = Path.Combine(sInstallFolderPath, ctIniEBooksFolderPath);
            // 取引先リスト受け渡しフォルダ　デフォルト値
            eBooksLinkSetInfo.CustomFolder = Path.Combine(sInstallFolderPath, ctIniCustomFolderPath);

            // 電子帳簿連携サポート設定情報XMLファイル存在の判断           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME)))
            {
                EBooksLinkSetInfo _eBooksLinkSetInfo = new EBooksLinkSetInfo();
                    _eBooksLinkSetInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME));

                    // 電子帳簿受け渡しフォルダ 設定の場合、
                    if (!string.IsNullOrEmpty(_eBooksLinkSetInfo.EBooksFolder))
                    {
                        eBooksLinkSetInfo.EBooksFolder = _eBooksLinkSetInfo.EBooksFolder;
                    }

                    // 取引先リスト受け渡しフォルダ 設定の場合、
                    if (!string.IsNullOrEmpty(_eBooksLinkSetInfo.CustomFolder))
                    {
                        eBooksLinkSetInfo.CustomFolder = _eBooksLinkSetInfo.CustomFolder;
                    }
            }
        }
        # endregion

        # region[電子帳簿連携サポート設定情報を書き込み]
        /// <summary>
        /// 電子帳簿連携サポート設定情報を書き込み
        /// </summary>
        /// <param name="_eBooksLinkSetInfo">電子帳簿連携サポート設定情報</param>
        /// <returns>ステータス</returns>
        public int WriteEBooksFolderPath(ref EBooksLinkSetInfo _eBooksLinkSetInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                // 「フォルダパス」の情報をXMLにシリアライズする
                UserSettingController.SerializeUserSetting(_eBooksLinkSetInfo, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME));
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region [PMNSのインストールパス取得]
        /// <summary>
        /// PMNSのインストールパス
        /// </summary>
        private string GetInstallDirectory()
        {
            // クライアント
            string sKeyPath = @String.Format(@ctRegistryKey);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(sKeyPath);
            string directoryPath = "";
            if (key.GetValue(ctInstallDirectory) != null)
            {
                directoryPath = (string)key.GetValue(ctInstallDirectory);
            }
            return directoryPath;
        }
        # endregion
    }

    # region [電子帳簿連携サポート設定情報XML]
    /// <summary>
    /// 電子帳簿連携サポート設定情報
    /// </summary>
    /// <remarks> 
    /// </remarks>
    public class EBooksLinkSetInfo
    {
        /// <summary>
        /// 電子帳簿連携サポート設定情報
        /// </summary>
        public EBooksLinkSetInfo()
        {

        }

        /// <summary>電子帳簿受け渡しフォルダ</summary>
        private string _eBooksFolder;
        /// <summary>取引先リスト受け渡しフォルダ</summary>
        private string _customFolder;

        /// <summary>電子帳簿受け渡しフォルダ</summary>
        public string EBooksFolder
        {
            get { return _eBooksFolder; }
            set { _eBooksFolder = value; }
        }

        /// <summary>取引先リスト受け渡しフォルダ</summary>
        public string CustomFolder
        {
            get { return _customFolder; }
            set { _customFolder = value; }
        }
    }
    #endregion
}

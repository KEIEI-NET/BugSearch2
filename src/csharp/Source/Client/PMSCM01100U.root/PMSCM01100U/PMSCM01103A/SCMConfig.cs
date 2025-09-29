//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.IO;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCMのコンフィグクラス
    /// </summary>
    public static class SCMConfig
    {
        /// <summary>デフォルトホームパス</summary>
        private const string DEFAULT_HOME_PATH = ".\\Log";

        /// <summary>デフォルトログフォルダ名称</summary>
        private const string DEFAULT_LOG_FOLDER_NAME = "SCMSend";

        /// <summary>送信フォルダ名称</summary>
        private const string SENDING_FOLDER_NAME = "Send";

        /// <summary>受信フォルダ名称</summary>
        private const string RECEIVED_FOLDER_NAME = "Recv";

        /// <summary>
        /// デフォルトのログデータのパスを取得します。
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>.\Log\SCMSend</returns>
        public static string GetSCMDefaultLogPath(string path)
        {
            MakeFolderIf(DEFAULT_HOME_PATH);
            MakeFolderIf(Path.Combine(DEFAULT_HOME_PATH, DEFAULT_LOG_FOLDER_NAME));
            return Path.Combine(DEFAULT_HOME_PATH, DEFAULT_LOG_FOLDER_NAME);
        }

        #region <送信用フォルダ>

        /// <summary>
        /// 送信用SCM回答データのパスを取得します。
        /// </summary>
        /// <param name="scmTotalSetting">SCM全体設定</param>
        /// <returns>
        /// SCM全体設定.旧システム連携フォルダ + "\Send" ※<c>string.Empty</c>または存在しないパスの場合、デフォルトパス + "\Send"
        /// </returns>
        public static string GetSCMSendingDataPath(SCMTtlSt scmTotalSetting)
        {
            MakeFolderIf(scmTotalSetting.OldSysCoopFolder.Trim());
            return GetSCMSendingDataPath(scmTotalSetting.OldSysCoopFolder.Trim());
        }

        /// <summary>
        /// 送信用SCM回答データのパスを取得します。
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>
        /// パス + "\Send" ※<c>string.Empty</c>または存在しないパスの場合、デフォルトパス + "\Send"
        /// </returns>
        private static string GetSCMSendingDataPath(string path)
        {
            return GetSCMDataPath(path, SENDING_FOLDER_NAME);
        }

        #endregion // </送信用フォルダ>

        #region <受信用フォルダ>

        /// <summary>
        /// 受信用SCM回答データのパスを取得します。
        /// </summary>
        /// <param name="scmTotalSetting">SCM全体設定</param>
        /// <returns>
        /// SCM全体設定.旧システム連携フォルダ + "\Recv" ※<c>string.Empty</c>または存在しないパスの場合、デフォルトパス + "\Recv"
        /// </returns>
        public static string GetSCMReceivedDataPath(SCMTtlSt scmTotalSetting)
        {
            MakeFolderIf(scmTotalSetting.OldSysCoopFolder.Trim());
            return GetSCMReceivedDataPath(scmTotalSetting.OldSysCoopFolder.Trim());
        }

        /// <summary>
        /// 受信用SCM回答データのパスを取得します。
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>
        /// パス + "\Recv" ※<c>string.Empty</c>または存在しないパスの場合、デフォルトパス + "\Recv"
        /// </returns>
        public static string GetSCMReceivedDataPath(string path)
        {
            MakeFolderIf(path);
            return GetSCMDataPath(path, RECEIVED_FOLDER_NAME);
        }

        #endregion // </受信用フォルダ>

        /// <summary>
        /// 連携用データパスを取得します。
        /// </summary>
        /// <param name="path">パス</param>
        /// <param name="folderName">送信または受信フォルダ名称</param>
        /// <returns>
        /// パス + "\Send/Recv" ※<c>string.Empty</c>または存在しないパスの場合、デフォルトパス + "\Send/Recv"
        /// </returns>
        private static string GetSCMDataPath(
            string path,
            string folderName
        )
        {
            // 空 または パスが存在しない場合、デフォルトパスを返す
            if (string.IsNullOrEmpty(path.Trim()) || !Directory.Exists(path))
            {
                string defaultDataPath = Path.Combine(DEFAULT_HOME_PATH, folderName);
                {
                    MakeFolderIf(DEFAULT_HOME_PATH);
                    MakeFolderIf(defaultDataPath);
                }
                return defaultDataPath;
            }
            DirectoryInfo dataPath = new DirectoryInfo(path);
            {
                if (dataPath.Name.Equals(folderName))
                {
                    return path;
                }
            }
            string dataPathName = Path.Combine(path, folderName);
            MakeFolderIf(dataPathName);
            return dataPathName;
        }

        /// <summary>
        /// フォルダが存在しなければ、作成します。
        /// </summary>
        /// <param name="path">フォルダパス</param>
        public static void MakeFolderIf(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}

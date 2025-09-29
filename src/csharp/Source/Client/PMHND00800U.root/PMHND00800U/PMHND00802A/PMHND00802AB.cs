//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : HTプログラム導入処理
// プログラム概要   : HTプログラム導入処理ＵＩクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 森山　浩
// 作 成 日  2017/12/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HTプログラム導入設定ファイル情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : HTプログラム導入設定ファイル情報クラスの定義と実装</br>
    /// <br>Programmer : 森山　浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00802AB
    {

        #region << private変数 >>

        /// <summary>
        /// ハンディターミナル側のバージョンファイル保存場所
        /// </summary>
        public static string versionFileDir;

        /// <summary>
        /// クライアント側の受信ファイル一時保存場所
        /// </summary>
        public static string recvFileTempDir;

        /// <summary>
        /// クライアント側の送信ファイル保存場所
        /// </summary>
        /// 
        public static string sendFileDir;
        /// <summary>
        /// クライアント側の設定ファイル保存場所
        /// </summary>
        public static string sendSettingFileDir;

        /// <summary>
        /// クライアント側の設定ファイルのファイル名
        /// </summary>
        public static string settingFileName;

        /// <summary>
        /// バージョン情報のファイル名
        /// </summary>
        public static string versionFileName;

        /// <summary>
        /// ハンディターミナル側の設定ファイル保存場所
        /// </summary>
        public static string htSettingDir;

        /// <summary>
        /// 設定ファイルのバックアップ保存場所
        /// </summary>
        public static string settingBackupDir;

        /// <summary>
        /// 受信時のタイムアウト時間（秒）
        /// </summary>
        public static int recvTimeoutVal = -1;

        /// <summary>
        /// 送信時のタイムアウト時間（秒）
        /// </summary>
        public static int sendTimeoutVal = -1;

        #endregion

        /// public propaty name  :  HtVersionFileDir
        /// <summary>ハンディターミナル側のバージョンファイル保存場所</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンディターミナル側のバージョンファイル保存場所</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HtVersionFileDir
        {
            get { return versionFileDir; }
            set { versionFileDir = value; }
        }

        /// public propaty name  :  RecvFileTempDir
        /// <summary>クライアント側の受信ファイル一時保存場所</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クライアント側の受信ファイル一時保存場所</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RecvFileTempDir
        {
            get { return recvFileTempDir; }
            set { recvFileTempDir = value; }
        }

        /// public propaty name  :  SendFileDir
        /// <summary>クライアント側の送信ファイル保存場所</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クライアント側の送信ファイル保存場所</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendFileDir
        {
            get { return sendFileDir; }
            set { sendFileDir = value; }
        }

        /// public propaty name  :  SendSettingFileDir
        /// <summary>クライアント側の設定ファイル保存場所</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クライアント側の設定ファイル保存場所</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SendSettingFileDir
        {
            get { return sendSettingFileDir; }
            set { sendSettingFileDir = value; }
        }

        /// public propaty name  :  SettingFileName
        /// <summary>クライアント側の設定ファイルのファイル名</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   クライアント側の設定ファイルのファイル名</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SettingFileName
        {
            get { return settingFileName; }
            set { settingFileName = value; }
        }

        /// public propaty name  :  VersionFileName
        /// <summary>バージョン情報のファイル名</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バージョン情報のファイル名</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string VersionFileName
        {
            get { return versionFileName; }
            set { versionFileName = value; }
        }

        /// public propaty name  :  HtSettingDir
        /// <summary>ハンディターミナル側の設定ファイル保存場所</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンディターミナル側の設定ファイル保存場所</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HtSettingDir
        {
            get { return htSettingDir; }
            set { htSettingDir = value; }
        }
        /// public propaty name  :  SettingBackupDir
        /// <summary>設定ファイルのバックアップ保存場所</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   設定ファイルのバックアップ保存場所</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SettingBackupDir
        {
            get { return settingBackupDir; }
            set { settingBackupDir = value; }
        }
        /// public propaty name  :  RecvTimeoutVal
        /// <summary>受信時のタイムアウト時間（秒）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信時のタイムアウト時間（秒）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int RecvTimeoutVal
        {
            get { return recvTimeoutVal; }
            set { recvTimeoutVal = value; }
        }
        /// public propaty name  :  SendTimeoutVal
        /// <summary>送信時のタイムアウト時間（秒）</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信時のタイムアウト時間（秒）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SendTimeoutVal
        {
            get { return sendTimeoutVal; }
            set { sendTimeoutVal = value; }
        }

    }
}

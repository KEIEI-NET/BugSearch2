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
using System.Threading;

using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// HTプログラム導入処理ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : HTプログラム導入処理ＵＩクラスの定義と実装</br>
    /// <br>Programmer : 森山　浩</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public partial class PMHND008000UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region　コンスト Memebers

        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMHND0800U";

        /// <summary>プログラム名称</summary>
        private const string AssemblyName = "HTプログラム導入処理";

        /// <summary>XML設定ファイルのフォルダ名</summary>
        private static string ctXMLDir = "UISettings";

        /// <summary>XML設定ファイル名称</summary>
        private static string ctXmlFileName = "PMHND00800U_UserSetting.xml";

        /// <summary>デフォルト値：ハンディターミナル側のバージョンファイル保存場所</summary>
        private static string ctDefaultVersionFileDir = "2:HttPg\\";

        /// <summary>デフォルト値：クライアント側の受信ファイル一時保存場所</summary>
        private static string ctDefaiultRecvFileTempDir = "Temp\\";

        /// <summary>デフォルト値：クライアント側の送信ファイル保存場所</summary>
        private static string ctDeaultSendFileDir = "Temp\\HttPg\\";

        /// <summary>デフォルト値：クライアント側の設定ファイル保存場所</summary>
        private static string ctDeaultSendSettingFileDir = "Setting\\";

        /// <summary>デフォルト値：クライアント側の設定ファイルのファイル名</summary>
        private static string ctDeaultSettingFileName = "Init_System.ini";

        /// <summary>デフォルト値：バージョン情報のファイル名</summary>
        private static string ctDefaultVersionFileName = "HTTVER.TXT";

        /// <summary>デフォルト値：ハンディターミナル側の設定ファイル保存場所</summary>
        private static string ctDefaultHtSettingDir = "2:HttPg\\Setting\\";

        /// <summary>デフォルト値：設定ファイルのバックアップ保存場所</summary>
        private static string ctDefaultSettingBackupDir = "Temp\\HttBakup\\";

        /// <summary>デフォルト値：受信時のタイムアウト時間（秒）</summary>
        private static int ctDefaultRecvTimeoutVal = 10;

        /// <summary>デフォルト値：送信時のタイムアウト時間（秒）</summary>
        private static int ctDefaultSendTimeoutVal = 10;

        /// <summary>ヴァージョン情報ファイルの項目区切り（カンマ）</summary>
        private static char Delimiter = ',';

        /// <summary>フォルダ区切り区切り（円マーク）</summary>
        private static string ctYen = "\\";

        /// <summary>設定ファイルの拡張子</summary>
        private static string IniFileExtension = ".ini";

        /// <summary>日付書式（バックアップフォルダ用）</summary>
        private static string DateFormat = "yyyyMMddHHmmss";

        //  ハンディターミナル側のバージョンファイル保存場所
        private const string ctElement_HtVersionFileDir = "HtVersionFileDir";

        // クライアント側の受信ファイル一時保存場所
        private const string ctElement_RecvFileTempDir = "RecvFileTempDir";

        // クライアント側の送信ファイル保存場所
        private const string ctElement_SendFileDir = "SendFileDir";

        // クライアント側の設定ファイル保存場所
        private const string ctElement_SendSettingFileDir = "SendSettingFileDir";

        // クライアント側の設定ファイル保存場所
        private const string ctElement_SettingFileName = "SettingFileName";

        // バージョン情報のファイル名
        private const string ctElement_VersionFileName = "VersionFileName";

        // ハンディターミナル側の設定ファイル保存場所
        private const string ctElement_HtSettingDir = "HtSettingDir";

        // 設定ファイルのバックアップ保存場所
        private const string ctElement_SettingBackupDir = "SettingBackupDir";

        // 受信時のタイムアウト時間（秒）
        private const string ctElement_RecvTimeoutVal = "RecvTimeoutVal";

        // 送信時のタイムアウト時間（秒）
        private const string ctElement_SendTimeoutVal = "SendTimeoutVal";

        public enum SendMode : int
        {
            MODE_NORMAL = 0,    // 通常
            MODE_NOT_ALL = 1,   // 設定ファイル以外
            MODE_ALL = 2,       // 全て
        } ;
        #endregion

        // ===================================================================================== //
        // 出力メッセージ
        // ===================================================================================== //
        #region 出力メッセージ

        private static string NewVersionFileMsg = "最新バージョンのファイルがあります。";

        private static string AllreadyNewVerMsg = "最新のプログラムが導入されています。";

        private static string ProgChangeMsg = "プログラムの入替を行います。";

        private static string CompProgChgMsg = "プログラムの入替が完了しました。";

        private static string EndButtonMsg = "ハンディシステムの「終了」ボタンを押してプログラムを終了してください。";

        private static string SendBottunMsg = "通信ユニットに接続して「送信」ボタンを押してください。";

        private static string ContinuedMsg = "続けて他のハンディターミナル機器へプログラムの入替を行えます。";

        private static string HttProgChgMsg = "ハンディターミナル機器へプログラムの入替を行えます。";

        #endregion

        #region エラーメッセージ
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region Private Members

        /// <summary>
        /// モード（通常メニューモード＝0、サポートメニューモード＝1）
        /// </summary>
        private int Mode;

        /// <summary>
        /// カレントディレクトリ
        /// </summary>
        private string CurrentDir;

        /// <summary>
        /// 設定ファイル情報
        /// </summary>
        private PMHND00802AB SettingInfo;

        /// <summary>
        ///  HTプログラム導入処理 アクセスクラス
        /// </summary>
        private PMHND00802AA pmhnd00802aa;

        /// <summary>
        /// ロガー
        /// </summary>
        PMHND00804AE logger = null;

        /// <summary>
        /// 送信ファイルリスト
        /// </summary>
        private List<string> SendFileList = new List<string>();

        /// <summary>
        /// クライアント側バージョン情報
        /// </summary>
        List<PMHND00803AD> clVerInfoList = new List<PMHND00803AD>();

        /// <summary>
        /// 送信済みチェック用
        /// </summary>
        private bool isSending = false;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="mode">モード</param>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        public PMHND008000UA(int mode)
        {
            InitializeComponent();
            this.Mode = mode;

            // PM.NSインストールディレクトリ
            string keyPath = @String.Format(@"SOFTWARE\Broadleaf\Product\Partsman");
            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            if (key.GetValue("InstallDirectory") != null)
            {
                CurrentDir = (string)key.GetValue("InstallDirectory");
            }
            key.Close();

            // 設定ファイル読込
            ReadSettingFile();

            // HTプログラム導入処理アクセスクラス
            pmhnd00802aa = new PMHND00802AA(this.SettingInfo);

            logger = PMHND00804AE.getInstance();


            // 画面初期表示処理
            InitialDisplay(this.Mode);

        }
        #endregion

        // ===================================================================================== //
        // 画面操作処理
        // ===================================================================================== //
        #region Control Event Methods

        #region フォームロードイベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMHND00800UA_Load(object sender, EventArgs e)
        {
            bool status;
            string errMsg = string.Empty;

            // ---------------------------------------
            // 多重起動の防止
            // ---------------------------------------
            Mutex mutex = new Mutex(false, "PMHND00800U");

            // ミューテックスの所有権を要求
            if (!mutex.WaitOne(0, false))
            {
                if (this.Mode != PMHND00802AC.VersionCheckMode)
                {
                    //すでに起動していると判断して終了
                    System.Windows.Forms.MessageBox.Show(
                        "バージョンチェックまたは導入処理が起動しています。\n多重起動はできません。",
                        "注意 - <HTプログラム導入処理>",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Exclamation
                    );
                }
                this.Close();
                return;
            }

            if (this.Mode == PMHND00802AC.VersionCheckMode)
            {
                // HTシステムファイルチェック
                // HTシステムファイルが存在しない場合、処理を終了
                status = HtSystemFileCheck();
                if (!status)
                {
                    this.Close();
                    return;
                }

                // バージョンチェック
                // 最新のバージョンでない場合、フォーム、メッセージを表示せずに終了する
                status = VersionCheck(out errMsg);
                if (status)
                {
                    // 最新バージョンのファイルがあります。
                    this.messageLabel.Text = NewVersionFileMsg;

                    // ハンディターミナル機器へプログラムの入替を行えます。
                    this.notificateLabel.Text = HttProgChgMsg + Environment.NewLine;
                    // ハンディシステムの「終了」ボタンを押してプログラムを終了してください。
                    this.notificateLabel.Text += EndButtonMsg + Environment.NewLine;
                    // 通信ユニットに接続して「送信」ボタンを押してください。
                    this.notificateLabel.Text += SendBottunMsg;
                }
                else
                {
                    // 最新のバージョンでない場合、フォーム、メッセージを表示せずに終了する
                    this.Close();
                    return;
                }
            }

            if (this.Mode == PMHND00802AC.SupportMenuMode)
            {
                this.Text += "（サポート）";
            }
            this.ActiveControl = this.sendButton;
            
        }
        #endregion

        #region 送信ボタンクリックイベント
        /// <summary>
        /// 送信ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            int status;
            
            string errMsg = string.Empty;

            // HTシステムファイルチェック
            // HTシステムファイルが存在しない場合、処理を終了
            if (!HtSystemFileCheck())
            {
                errMsg = "最新バージョンのファイルがありません。\nハンディターミナル機器へプログラムの入替は行えません。";
                // エラーメッセージ出力
                this.messageLabel.Text = errMsg;
                this.messageLabel.ForeColor = Color.Red;
                this.notificateLabel.Text = string.Empty;

                logger.WriteLog(errMsg);
                return;
            }

            // ファイル入替方法を無効化
            this.uos_SendDiv.Enabled = false;
            // 送信ボタンを無効化
            this.sendButton.Enabled = false;
            // キャンセルボタンを無効化
            this.cancelButton.Enabled = false;

            // プログラムの入替を行います。
            this.messageLabel.Text = ProgChangeMsg;
            this.messageLabel.ForeColor = Color.Black;

            this.notificateLabel.Text = string.Empty;
            this.notificateLabel.ForeColor = Color.Black;

            if (Mode != PMHND00802AC.VersionCheckMode)
            {
                isSending = true;
            }

            // 通常メニューモードの場合、通常メニューモードで動作する
            if (Mode != PMHND00802AC.SupportMenuMode)
            {
                status = FileChange(SendMode.MODE_NORMAL, out errMsg);
            }
            // 
            else
            {
                status = SupportModeModeProc(out errMsg);
            }

            if (status == 0)
            {
                // 続けて他のハンディターミナル機器へプログラムの入替を行えます。
                this.notificateLabel.Text = ContinuedMsg + Environment.NewLine;
                // ハンディシステムの「終了」ボタンを押してプログラムを終了してください。
                this.notificateLabel.Text += EndButtonMsg + Environment.NewLine;
                // 通信ユニットに接続して「送信」ボタンを押してください。
                this.notificateLabel.Text += SendBottunMsg;
            }
            else
            {
                // エラーメッセージ出力
                this.messageLabel.Text = errMsg;
                this.messageLabel.ForeColor = Color.Red;
                logger.WriteLog(errMsg);

                if (errMsg.IndexOf("「送信」ボタン") <= 0)
                {
                    this.notificateLabel.Text = "再度「送信」ボタンを押してください。";
                    this.notificateLabel.ForeColor = Color.Red;
                }
            }

            isSending = true;

            // ファイル入替方法を有効化
            this.uos_SendDiv.Enabled = true;
            // 送信ボタンを有効化
            this.sendButton.Enabled = true;
            // キャンセルボタンを有効化
            this.cancelButton.Enabled = true;

            this.sendButton.Focus();

        }
        #endregion

        #region キャンセルボタンクリックイベント
        /// <summary>
        /// キャンセルボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region private

        #region 画面初期表示処理
        /// <summary>
        /// 画面初期表示処理
        /// </summary>
        /// <param name="mode">モード</param>
        /// <returns>なし</returns>
        /// <remarks>
        /// <br>Note       :画面の初期表示処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private void InitialDisplay(int mode)
        {
            // プログラムの入れ替えを行います。
            this.messageLabel.Text = ProgChangeMsg;

            // ハンディシステムの「終了」ボタンを押してプログラムを終了してください。
            this.notificateLabel.Text = EndButtonMsg + Environment.NewLine;

            // 通信ユニットに接続して「送信」ボタンを押してください。
            this.notificateLabel.Text += SendBottunMsg;

            // 通常メニュー起動の場合、選択ラジオボタンを表示しない
            if (mode != PMHND00802AC.SupportMenuMode)
            {
                this.radioPanel.Hide();
                this.radioPanelLabel.Hide();
                this.uos_SendDiv.Hide();
            }

        }
        #endregion

        #region HTシステムファイルチェック処理
        /// <summary>
        /// HTシステムファイルチェック処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : HTシステムファイルチェック処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool HtSystemFileCheck()
        {
            // システムファイル送信場所
            string systemFileDir = Path.Combine(CurrentDir, SettingInfo.SendFileDir);

            // フォルダチェック
            if (Directory.Exists(systemFileDir))
            {
                // システムファイル有無チェック
                string[] files = Directory.GetFiles(systemFileDir, "*", SearchOption.AllDirectories);

                if (files != null && files.Length > 0)
                {
                    return true;
                }
            }

            return false;

        }
        #endregion

        #region XML設定ファイル読込処理
        /// <summary>
        /// XML設定ファイル読込処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : XML設定ファイルから、設定情報を読み込む処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private void ReadSettingFile()
        {
            XmlDocument xmlDoc = null;

            // XMLファイル設定情報
            SettingInfo = new PMHND00802AB();

            // XML設定ファイルフルパスを作成
            string pmXmlPath = Path.Combine(CurrentDir, ctXMLDir);
            pmXmlPath = Path.Combine(pmXmlPath, ctXmlFileName);

            if (!(File.Exists(pmXmlPath)))
            {
                // 設定ファイルが存在しない場合、設定ファイルを新規作成する
                MakeSettingFile(pmXmlPath);
            }

            string errMsg = string.Empty;

            try
            {
                // XMLファイル読み込み
                xmlDoc = new XmlDocument();
                xmlDoc.Load(pmXmlPath);
                XmlNodeList infoList = xmlDoc.SelectNodes("UserSettingInfo");

                // nodeが存在しない場合、次のforeachで例外を発生させて、default値を適用させる

                // ノード（UserSettingInfo）の数分ループ
                foreach (XmlNode infoNode in infoList)
                {
                    XmlNodeList childNodeList = infoNode.ChildNodes;

                    // UserSettingInfoの子ノードの数分ループ
                    foreach (XmlNode childNode in childNodeList)
                    {
                        // UserSettingInfoの子ノードのタグ名が空の場合、次ノードを処理する
                        if (string.IsNullOrEmpty(childNode.Name))
                        {
                            continue;
                        }
                        switch (childNode.Name)
                        {

                            case ctElement_HtVersionFileDir:         // ハンディターミナル側のバージョンファイル保存場所
                                {
                                    SettingInfo.HtVersionFileDir = childNode.InnerText ?? string.Empty;
                                    // フォルダ名の最後に"\"がない場合、最後に"\"を補完する
                                    if (!SettingInfo.HtVersionFileDir.EndsWith(ctYen))
                                    {
                                        SettingInfo.HtVersionFileDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_RecvFileTempDir:        // クライアント側の受信ファイル一時保存場所
                                {
                                    SettingInfo.RecvFileTempDir = childNode.InnerText ?? string.Empty;
                                    // フォルダ名の最後に"\"がない場合、最後に"\"を補完する
                                    if (!SettingInfo.RecvFileTempDir.EndsWith(ctYen))
                                    {
                                        SettingInfo.RecvFileTempDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SendFileDir:            // クライアント側の送信ファイル保存場所
                                {
                                    SettingInfo.SendFileDir = childNode.InnerText ?? string.Empty;
                                    // フォルダ名の最後に"\"がない場合、最後に"\"を補完する
                                    if (!SettingInfo.SendFileDir.EndsWith("\\"))
                                    {
                                        SettingInfo.SendFileDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SendSettingFileDir:            // クライアント側の設定ファイル保存場所
                                {
                                    SettingInfo.SendSettingFileDir = childNode.InnerText ?? string.Empty;
                                    // フォルダ名の最後に"\"がない場合、最後に"\"を補完する
                                    if (!SettingInfo.SendSettingFileDir.EndsWith("\\"))
                                    {
                                        SettingInfo.SendSettingFileDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SettingFileName:            // クライアント側の設定ファイルのファイル名
                                {
                                    SettingInfo.SettingFileName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case ctElement_VersionFileName:        // バージョン情報のファイル名
                                {
                                    SettingInfo.VersionFileName = childNode.InnerText ?? string.Empty;
                                    break;
                                }
                            case ctElement_HtSettingDir:           // ハンディターミナル側の設定ファイル保存場所
                                {
                                    SettingInfo.HtSettingDir = childNode.InnerText ?? string.Empty;
                                    // フォルダ名の最後に"\"がない場合、最後に"\"を補完する
                                    if (!SettingInfo.HtSettingDir.EndsWith("\\"))
                                    {
                                        SettingInfo.HtSettingDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_SettingBackupDir:       // 設定ファイルのバックアップ保存場所
                                {
                                    SettingInfo.SettingBackupDir = childNode.InnerText ?? string.Empty;
                                    // フォルダ名の最後に"\"がない場合、最後に"\"を補完する
                                    if (!SettingInfo.SettingBackupDir.EndsWith("\\"))
                                    {
                                        SettingInfo.SettingBackupDir += ctYen;
                                    }
                                    break;
                                }
                            case ctElement_RecvTimeoutVal:         // 受信時のタイムアウト時間（秒）
                                {
                                    try
                                    {
                                        SettingInfo.RecvTimeoutVal = int.Parse(childNode.InnerText);
                                    }
                                    catch
                                    {
                                        // 未設定の場合はデフォルト値を使用するので、ここでは何もしない
                                    }
                                    break;
                                }
                            case ctElement_SendTimeoutVal:         // 送信時のタイムアウト時間（秒）
                                {
                                    try
                                    {
                                        SettingInfo.SendTimeoutVal = int.Parse(childNode.InnerText);
                                    }
                                    catch
                                    {
                                        // 未設定の場合はデフォルト値を使用するので、ここでは何もしない
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                    break;
                }

            }
            catch
            {
                // 設定ファイルが存在しない場合はデフォルト値を使用するので、ここでは何もしない
            }
            finally
            {
                if (xmlDoc != null)
                {
                    xmlDoc = null;
                }
            }

            // 未設定の場合、デフォルト値を設定する
            //  ハンディターミナル側のバージョンファイル保存場所
            if (String.IsNullOrEmpty(SettingInfo.HtVersionFileDir))
            {
                SettingInfo.HtVersionFileDir = ctDefaultVersionFileDir;
            }
            // クライアント側の受信ファイル一時保存場所
            if (String.IsNullOrEmpty(SettingInfo.RecvFileTempDir))
            {
                SettingInfo.RecvFileTempDir = Path.Combine(CurrentDir, ctDefaiultRecvFileTempDir);
            }
            // クライアント側の送信ファイル保存場所
            if (String.IsNullOrEmpty(SettingInfo.SendFileDir))
            {
                SettingInfo.SendFileDir = Path.Combine(CurrentDir, ctDeaultSendFileDir);
            }
            // クライアント側の設定ファイルのファイル名
            if (String.IsNullOrEmpty(SettingInfo.SettingFileName))
            {
                SettingInfo.SettingFileName = ctDeaultSettingFileName;
            }
            // バージョン情報のファイル名
            if (String.IsNullOrEmpty(SettingInfo.VersionFileName))
            {
                SettingInfo.VersionFileName = ctDefaultVersionFileName;
            }
            // ハンディターミナル側の設定ファイル保存場所
            if (String.IsNullOrEmpty(SettingInfo.HtSettingDir))
            {
                SettingInfo.HtSettingDir = ctDefaultHtSettingDir;
            }
            // 設定ファイルのバックアップ保存場所
            if (String.IsNullOrEmpty(SettingInfo.SettingBackupDir))
            {
                SettingInfo.SettingBackupDir = Path.Combine(CurrentDir, ctDefaultSettingBackupDir);
            }
            // 受信時のタイムアウト時間（秒）
            if (SettingInfo.RecvTimeoutVal == -1)
            {
                SettingInfo.RecvTimeoutVal = ctDefaultRecvTimeoutVal;
            }
            // 送信時のタイムアウト時間（秒）
            if (SettingInfo.SendTimeoutVal == -1)
            {
                SettingInfo.SendTimeoutVal = ctDefaultSendTimeoutVal;
            }
            
            return;

        }
        #endregion


        #region XML設定ファイル作成処理
        /// <summary>
        /// XML設定ファイル作成処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : XML設定ファイルから、設定情報を書き込む処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private void MakeSettingFile(string pmXmlPath)
        {
            XmlElement root = null;
            XmlDocument xmldoc = new XmlDocument();

            XmlDeclaration xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", null, null);
            XmlNode xmlNode = xmldoc.CreateNode(XmlNodeType.Element, "UserSettingInfo", "");
            xmldoc.AppendChild(xmlNode);
            xmldoc.InsertBefore(xmlDeclaration, xmlNode);
            root = xmldoc.DocumentElement;

            root.SetAttribute("xmlns:xsi", @"http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("xmlns:xsd", @"http://www.w3.org/2001/XMLSchema");

            XmlElement element = null;

            //  ハンディターミナル側のバージョンファイル保存場所
            element = xmldoc.CreateElement(ctElement_HtVersionFileDir);
            element.InnerText = ctDefaultVersionFileDir;
            root.AppendChild(element);

            // クライアント側の受信ファイル一時保存場所
            element = xmldoc.CreateElement(ctElement_RecvFileTempDir);
            element.InnerText = Path.Combine(CurrentDir, ctDefaiultRecvFileTempDir);
            root.AppendChild(element);

            // クライアント側の送信ファイル保存場所
            element = xmldoc.CreateElement(ctElement_SendFileDir);
            element.InnerText = Path.Combine(CurrentDir, ctDeaultSendFileDir);
            root.AppendChild(element);

            // クライアント側の設定ファイル保存場所
            element = xmldoc.CreateElement(ctElement_SendSettingFileDir);
            element.InnerText = ctDeaultSendSettingFileDir;
            root.AppendChild(element);

            // クライアント側の設定ファイルのファイル名
            element = xmldoc.CreateElement(ctElement_SettingFileName);
            element.InnerText = ctDeaultSettingFileName;
            root.AppendChild(element);

            // バージョン情報のファイル名
            element = xmldoc.CreateElement(ctElement_VersionFileName);
            element.InnerText = ctDefaultVersionFileName;
            root.AppendChild(element);

            // ハンディターミナル側の設定ファイル保存場所
            element = xmldoc.CreateElement(ctElement_HtSettingDir);
            element.InnerText = ctDefaultHtSettingDir;
            root.AppendChild(element);

            // 設定ファイルのバックアップ保存場所
            element = xmldoc.CreateElement(ctElement_SettingBackupDir);
            element.InnerText = Path.Combine(CurrentDir, ctDefaultSettingBackupDir);
            root.AppendChild(element);

            // 受信時のタイムアウト時間（秒）
            element = xmldoc.CreateElement(ctElement_RecvTimeoutVal);
            element.InnerText = ctDefaultRecvTimeoutVal.ToString();
            root.AppendChild(element);

            // 送信時のタイムアウト時間（秒）
            element = xmldoc.CreateElement(ctElement_SendTimeoutVal);
            element.InnerText = ctDefaultSendTimeoutVal.ToString();
            root.AppendChild(element);

            // ファイルに保存する
            xmldoc.Save(pmXmlPath);
        }
        #endregion

        #region バージョンチェック処理
        /// <summary>
        /// バージョンチェック処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 通常メニューモードの処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VersionCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // クライアント側の受信フォルダ
            string recvPath = Path.Combine(CurrentDir, SettingInfo.RecvFileTempDir);

            // クライアント側の受信ファイル一時保存場所にバージョン情報ファイルがあれば削除する。
            if (File.Exists(recvPath + SettingInfo.VersionFileName))
            {
                File.Delete(recvPath + SettingInfo.VersionFileName);
            }

            // 比較結果
            bool compareResult;
            string[] FileNames = new string[1];
            FileNames[0] = SettingInfo.VersionFileName;
            string[] remotePaths = new string[1];
            remotePaths[0] = SettingInfo.HtVersionFileDir;

            // バージョン情報ファイル受信
            BTCOMM_RESULT result;
            result = pmhnd00802aa.RecvFile(recvPath,
                                    remotePaths,
                                    FileNames,
                                    out errMsg);
            if (result.Equals(BTCOMM_RESULT.BTCOMM_OK))
            {
                // バージョンファイル比較処理
                compareResult = VersionFileCompare(out errMsg);
            }
            else if (result.Equals(BTCOMM_RESULT.BTCOMM_FILENOTFOUND))
            {
                clVerInfoList.Clear();
                // バージョン情報ファイルが存在しない場合、クライアントが最新
                // クライアント側バージョン情報取得
                bool status = GetVersionInfo(SettingInfo.SendFileDir, ref clVerInfoList);
                if (!status)
                {
                    if (Mode != PMHND00802AC.VersionCheckMode)
                    {
                        // エラーメッセージを出す
                        errMsg = String.Format("バージョン情報の取得に失敗しました。", result);
                    }
                    return false;
                }

                // 端末側バージョン情報
                List<PMHND00803AD> htVerInfoList = new List<PMHND00803AD>();

                // バージョン比較処理
                status = VerInfoCompare(clVerInfoList, htVerInfoList);

                return status;
            }
            else
            {
                if (Mode != PMHND00802AC.VersionCheckMode)
                {
                    // エラーメッセージを出す
                    errMsg = String.Format(errMsg, result);
                }
                return false;
            }

            return compareResult;
        }
        #endregion

        #region バージョン情報ファイル比較処理
        /// <summary>
        /// バージョン情報ファイル比較処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : バージョン情報ファイル比較処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VersionFileCompare(out string errMsg)
        {
            // 比較結果
            bool status = false;

            errMsg = string.Empty;
            
            // 端末側バージョン情報ファイル名
            string htVerFName = Path.Combine(CurrentDir, SettingInfo.RecvFileTempDir);
            htVerFName = Path.Combine(htVerFName, SettingInfo.VersionFileName);

            // 端末側バージョン情報
            List<PMHND00803AD> htVerInfoList = new List<PMHND00803AD>();

            // 端末側バージョン情報ファイル読込処理
            bool readStatus = ReadHtVersionFile(htVerFName, ref htVerInfoList);
            if (!readStatus)
            {
                errMsg = "端末側バージョン情報ファイル読込失敗";
                return false;
            }

            // クライアント側バージョン情報ファイルがあれば削除する。
            if (File.Exists(SettingInfo.SendFileDir + SettingInfo.VersionFileName))
            {
                File.Delete(SettingInfo.SendFileDir + SettingInfo.VersionFileName);
            }

            // クライアント側バージョン情報取得
            clVerInfoList.Clear();
            readStatus = GetVersionInfo(SettingInfo.SendFileDir, ref clVerInfoList);
            if (!readStatus)
            {
                errMsg = "クライアント側バージョン情報取得失敗";
                return false;
            }

            // バージョン情報比較処理
            status = VerInfoCompare(clVerInfoList, htVerInfoList);

            return status;
        }
        #endregion

        #region バージョン情報ファイル読込処理
        /// <summary>
        /// バージョン情報ファイル読込処理
        /// </summary>
        /// <param name="fileName">バージョン情報ファイル名</param>
        /// <param name="htVerInfoList">バージョン情報リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : バージョン情報ファイル読込処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool ReadHtVersionFile(string fileName, ref List<PMHND00803AD> htVerInfoList)
        {
            string errMsg = string.Empty;
            try
            {
                string strBuffer;
                using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("Shift_JIS")))
                {
                    // 1行読込
                    strBuffer = sr.ReadLine();

                    while (strBuffer != null)
                    {
                        // カンマ区切りで分割
                        char[] delimiters = new char[1];
                        delimiters[0] = Delimiter;
                        string[] temp = strBuffer.Split(delimiters);

                        // バージョン情報に値を設定
                        PMHND00803AD htVerInfo = new PMHND00803AD();
                        htVerInfo.FileName = temp[0].Trim();
                        htVerInfo.ChangeDateTime = DateTime.Parse(temp[1].Trim());
                        htVerInfoList.Add(htVerInfo);

                        // 1行読込
                        strBuffer = sr.ReadLine();
                    }
                }
            }
            catch (Exception exc)
            {
                // エラーメッセージを出す
                errMsg = "バージョン情報ファイルの読込に失敗しました。(" + fileName + ")" + exc.Message;
                logger.WriteLog(errMsg);
            }

            return true;
        }
        #endregion

        #region バージョン情報比較処理
        /// <summary>
        /// バージョン情報比較処理
        /// </summary>
        /// <param name="verInfoList1">バージョン情報1</param>
        /// <param name="verInfoList2">バージョン情報2</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : バージョン情報比較処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VerInfoCompare(List<PMHND00803AD> verInfoList1, List<PMHND00803AD> verInfoList2)
        {
            bool status = false;

            // 送信ファイルリストをクリア
            SendFileList.Clear();

            // クライアント側バージョン情報リストをループ
            foreach (PMHND00803AD clVerInfo in verInfoList1)
            {
                // 設定ファイルを除く
                if (clVerInfo.fileName.ToLower() == SettingInfo.SettingFileName.ToLower())
                {
                    continue;
                }

                // ファイル有無
                bool isExist = false;
                // 端末側バージョン情報をループ
                foreach (PMHND00803AD htVerInfo in verInfoList2)
                {
                    if (clVerInfo.FileName.ToLower() != htVerInfo.FileName.ToLower())
                    {
                        continue;
                    }

                    // ファイルなしをありにする
                    isExist = true;

                    // クライアント側の更新時間が新しい場合
                    if (clVerInfo.ChangeDateTime.ToString(DateFormat).CompareTo(htVerInfo.ChangeDateTime.ToString(DateFormat)) > 0)
                    {
                        status = true;

                        // 送信ファイルリストに、ファイル名を追加
                        SendFileList.Add(clVerInfo.FileName);
                    }
                    break;
                }
                // クライアントにあって、HTになければ送信ファイルリストに追加
                if (!isExist)
                {
                    status = true;
                    SendFileList.Add(clVerInfo.FileName);
                }
            }
            return status;
        }
        #endregion

        #region ファイルバージョン情報取得処理
        /// <summary>
        /// ファイルバージョン情報取得処理
        /// </summary>
        /// <param name="path">バージョン情報を取得するファイルが格納されているパス</param>
        /// <param name="verInfoList">バージョン情報リスト</param>
        /// <returns>処理結果</returns>
        /// <remarks>指定されたパスのファイルバージョン情報取得処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool  GetVersionInfo(string path, ref List<PMHND00803AD> verInfoList)
        {
            // クライアント側送信フォルダ
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            if (files == null || files.Length == 0)
            {
                return false;
            }
            // ファイルリストでループ
            foreach (string fileName in files)
            {
                // ファイル名のみを取得
                string fName = Path.GetFileName(fileName);

                // 最終更新日付を取得
                DateTime dateTime = File.GetLastWriteTime(fileName);
                dateTime.AddMilliseconds( -1 * dateTime.Millisecond);

                PMHND00803AD versionInfo = new PMHND00803AD();
                versionInfo.FileName = fName;
                versionInfo.ChangeDateTime = dateTime;
                verInfoList.Add(versionInfo);
            }

            return true;
        }
        #endregion

        #region サポートメニューモード処理
        /// <summary>
        /// サポートメニューモード処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : サポートメニューモードの処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private int SupportModeModeProc(out string errMsg)
        {
            int status = -1;
            errMsg = string.Empty;

            // 「ファイル日付が異なるファイルのみ入れ替えする」にチェックされた場合の動作
            if (this.uos_SendDiv.CheckedIndex == 0)
            {
                // 通常メニューモードと同じ動作
                status = FileChange(SendMode.MODE_NORMAL, out errMsg);
            }
            // 「設定ファイルを除き、全てのファイルを入替する。」にチェックされた場合の動作
            if (this.uos_SendDiv.CheckedIndex == 1)
            {
                // 設定ファイルを除いて、全てのファイルを入れ替える
                status = FileChange(SendMode.MODE_NOT_ALL, out errMsg);
            }
            // 「全てのファイルを入替する。（入替後にハンディ機器の再設定が必要）」にチェックされた場合の動作
            if (this.uos_SendDiv.CheckedIndex == 2)
            {
                // 全てのファイルを入れ替える
                status = FileChange(SendMode.MODE_ALL, out errMsg);
            }
            return status;
        }
        #endregion

        #region ファイル入れ替え処理
        /// <summary>
        /// ファイル入れ替え処理
        /// </summary>
        /// <param name="mode">処理モード</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : ファイル入れ替えの処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private int FileChange(SendMode mode,out string errMsg)
        {
            int status = -1;
            errMsg = string.Empty;

            // 全ファイルのファイル名称リストを作成
            string[] files;
            string[] fNames;
            string[] remotePath;

            // クライアント側バージョン情報ファイルがあれば削除する。
            if (File.Exists(SettingInfo.SendFileDir + SettingInfo.VersionFileName))
            {
                File.Delete(SettingInfo.SendFileDir + SettingInfo.VersionFileName);
            }

            if (mode == SendMode.MODE_NORMAL)
            {
                // 初期処理からの遷移でない場合、バージョンチェックを行う
                if (this.isSending)
                {
                    // バージョンチェック
                    // 最新のバージョンでない場合、「最新のファイルが適用済みです。」のメッセージを表示
                    bool isNewVersion = VersionCheck(out errMsg);
                    if (!isNewVersion)
                    {
                        if (errMsg != string.Empty) return status;

                        this.messageLabel.Text = AllreadyNewVerMsg;
                        status = 0;
                        return status;
                    }
                }

                // 送信ファイルのリストでループする
                List<string> newSendFileList = new List<string>();
                foreach (string filename in SendFileList)
                {
                    // 設定ファイルを除く
                    if (filename.ToLower() == SettingInfo.SettingFileName.ToLower())
                    {
                        continue;
                    }

                    // 拡張子取得
                    string ext = Path.GetExtension(filename);

                    if (ext.ToLower() == IniFileExtension)
                    {
                        newSendFileList.Add(SettingInfo.SendSettingFileDir + filename);
                    }
                    else
                    {
                        newSendFileList.Add(filename);
                    }
                }

                // バージョン情報ファイルを追加
                newSendFileList.Add(SettingInfo.VersionFileName);

                fNames = newSendFileList.ToArray();

                remotePath = new string[newSendFileList.Count];
                for (int ii = 0; ii < fNames.Length; ii++)
                {
                    remotePath[ii] = SettingInfo.HtVersionFileDir;
                }
            }
            else
            {
                // 送信ファイルリストをクリア
                SendFileList.Clear();

                // 全ファイルのファイル名称リストを作成
                files = Directory.GetFiles(SettingInfo.SendFileDir, "*", SearchOption.AllDirectories);
                fNames = new string[files.Length + 1];
                remotePath = new string[files.Length + 1];

                int ii = 0;
                foreach (string fName in files)
                {
                    if (mode == SendMode.MODE_NOT_ALL)
                    {
                        // 設定ファイルを除く
                        if (Path.GetFileName(fName).ToLower() == SettingInfo.SettingFileName.ToLower())
                        {
                            continue;
                        }
                    }
                    // 拡張子取得
                    string ext = Path.GetExtension(fName);

                    if (ext.ToLower() == IniFileExtension)
                    {
                        fNames[ii] = SettingInfo.SendSettingFileDir + Path.GetFileName(fName);
                    }
                    else
                    {
                        fNames[ii] = Path.GetFileName(fName);
                    }
                    remotePath[ii] = SettingInfo.HtVersionFileDir;
                    // 送信ファイルリストに追加
                    SendFileList.Add(fNames[ii]);

                    ii++;
                }

                // バージョン情報ファイル
                fNames[ii] = SettingInfo.VersionFileName;
                remotePath[ii] = SettingInfo.HtVersionFileDir;

                if (mode == SendMode.MODE_NOT_ALL)
                {
                    // 設定ファイルの領域削除
                    ii++;

                    Array.Resize(ref fNames, ii);
                    Array.Resize(ref remotePath, ii);
                }
                else if (mode == SendMode.MODE_ALL)
                {
                    // 設定ファイルのバックアップ
                    bool sfbStatus = SettingFileBackup(out errMsg);
                }
            }

            // バージョン情報ファイル作成
            bool creStatus = VersionFileCreate();
            if (!creStatus)
            {
                errMsg = "バージョン情報ファイルの作成に失敗しました。";
                return status;
            }

            // ファイルを送信
            BTCOMM_RESULT result = pmhnd00802aa.SendFile(SettingInfo.SendFileDir, SettingInfo.SendSettingFileDir, remotePath, fNames, out errMsg);
            if (!result.Equals(BTCOMM_RESULT.BTCOMM_OK))
            {
                // エラーメッセージを表示
                return status;
            }

            // 送信ファイルリストをクリア
            SendFileList.Clear();

            // クライアント側バージョン情報ファイルがあれば削除する。
            if (File.Exists(SettingInfo.SendFileDir + SettingInfo.VersionFileName))
            {
                File.Delete(SettingInfo.SendFileDir + SettingInfo.VersionFileName);
            }

            status = 0;

            // プログラムの入替が完了しました。
            this.messageLabel.Text = CompProgChgMsg;

            return status;
        }
        #endregion

        #region 設定ファイルバックアップ処理
        /// <summary>
        /// 設定ファイルバックアップ処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 設定ファイルバックアップ処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool SettingFileBackup(out string errMsg)
        {
            // クライアント側の受信フォルダ
            string recvPath = Path.Combine(CurrentDir, SettingInfo.RecvFileTempDir);

            // 設定ファイルリスト
            List<string> iniFileList = new List<string>();

            // 送信ファイルリストから、設定ファイルを抽出
            foreach (string filename in SendFileList)
            {
                string extension = Path.GetExtension(filename);
                if (extension.ToLower() == IniFileExtension)
                {
                    iniFileList.Add(Path.GetFileName(filename));
                }
            }

            string[] remotePaths = new string[iniFileList.Count];
            for (int ii = 0; ii < remotePaths.Length; ii++ )
            {
                remotePaths[ii] = SettingInfo.HtSettingDir;
            }

            string[] fileNames = iniFileList.ToArray();

            // ファイル受信
            BTCOMM_RESULT result;
            result = pmhnd00802aa.RecvFile(recvPath,
                                    remotePaths,
                                    fileNames,
                                    out errMsg);
            if (result.Equals(BTCOMM_RESULT.BTCOMM_OK) )
            {
                // 正常終了の場合
                // バックアップフォルダへコピー
                // バックアップフォルダ作成
                DateTime now = DateTime.Now;
                // バックアップ先フォルダの下に日付フォルダを作成
                string bkupdir = Path.Combine(SettingInfo.SettingBackupDir, now.ToString(DateFormat));
                Directory.CreateDirectory(bkupdir);

                for (int ii = 0; ii < fileNames.Length; ii++)
                {
                    string sourceFile = SettingInfo.RecvFileTempDir + fileNames[ii];
                    string destFile = Path.Combine(bkupdir, fileNames[ii]);
                    File.Move(sourceFile, destFile);
                }

                return true;
            }
            else if (result.Equals(BTCOMM_RESULT.BTCOMM_FILENOTFOUND))
            {
                // ファイル無しの場合、コピーせずに正常終了する
                return true;
            }

            return false;
        }
        #endregion

        #region バージョン情報ファイル作成処理
        /// <summary>
        /// バージョン情報ファイル作成処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : バージョン情報ファイル作成処理を行います。</br>
        /// <br>Programmer : 森山　浩</br>
        /// <br>Date       : 2017/12/22</br>
        /// </remarks>
        private bool VersionFileCreate()
        {
            // クライアント側バージョン情報取得
            clVerInfoList.Clear();
            bool readStatus = GetVersionInfo(SettingInfo.SendFileDir, ref clVerInfoList);
            if (!readStatus)
            {
                //errMsg = "クライアント側バージョン情報取得失敗";
                return readStatus;
            }

            // バージョン情報ファイル名
            string verFName = Path.Combine(SettingInfo.SendFileDir, SettingInfo.VersionFileName);

            // バージョン情報ファイル作成
            using (StreamWriter sw = new StreamWriter(verFName, false, Encoding.GetEncoding("Shift_jis")))
            {
                foreach (PMHND00803AD verInfo in clVerInfoList)
                {
                    string lineBuffer = string.Empty;
                    lineBuffer += verInfo.FileName + Delimiter;
                    lineBuffer += verInfo.ChangeDateTime.ToString();
                    sw.WriteLine(lineBuffer);
                }
            };

            return true;
        }
        #endregion
        #endregion

    }
}
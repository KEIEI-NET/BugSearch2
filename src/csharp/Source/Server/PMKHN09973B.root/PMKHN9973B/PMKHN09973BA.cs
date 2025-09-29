using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Management;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ツール動作
    /// </summary>
    /// <remarks>
    /// <br>Note       : ツールアクセスクラス</br>
    /// <br>Programmer : BroadLeaf</br>
    /// </remarks>
    public class DevelopToolMonitoringS : MarshalByRefObject
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region コンスト Memebers

        /// <summary>メソッド戻り値　 0:正常</summary>
        private const int STATUS_NORMAL = 0;
        /// <summary>メソッド戻り値　-1:異常</summary>
        private const int STATUS_ERROR = -1;
        /// <summary>オプション 0:ON（有効）</summary>
        private const int OPTION_ON = 0;
        /// <summary>オプション -1:OFF（無効）</summary>
        private const int OPTION_OFF = -1;

        /// <summary>該当　0:あり</summary>
        private const int TARGET_EXISTS = 0;
        /// <summary>該当　-1:なし</summary>
        private const int TARGET_NOTEXISTS = -1;

        /// <summary>メッセージ　ファイル存在チェック</summary>
        private const string LOGMESSAGE_FILE_EXISTS = "ファイルは存在します。({0})";

        /// <summary>開始オプション　0：クライアント</summary>
        public const int STARTOPTION_CLIENT = 0;
        /// <summary>開始オプション　1：サーバ</summary>
        public const int STARTOPTION_SERVER = 1;
        #endregion

        // ===================================================================================== //
        // Static 変数
        // ===================================================================================== //
        #region Static Members
        /// <summary>クライアントインストールパス</summary>
        private string ClientPath = string.Empty;
        /// <summary>APサーバインストールパス</summary>
        private string ServerPath = string.Empty;
        #endregion

        // ===================================================================================== //
        // イベント定義
        // ===================================================================================== //
        /// <summary>ログ出力イベント</summary>
        public delegate void WriteLogHandler(object sender, string message);
        public event WriteLogHandler WriteLog;

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        public DevelopToolMonitoringS()
        {

        }
        #endregion

        /// <summary>
        /// 開始処理
        /// </summary>
        /// <return>結果</return>
        /// <remarks>
        /// <br>Note       : 処理開始</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        public void Start()
        {
            try
            {
                // レジストリ情報取得
                if (GetRegistoryInfo() != STATUS_NORMAL)
                {
                    return;
                }

                // ファイルチェック
                CheckFileExists();
            }
            catch (Exception ex)
            {
                // 例外エラー処理
                ExceptionCahctProcess(ex);
            }
        }

        // ===================================================================================== //
        // レジストリ情報取得
        // ===================================================================================== //
        #region レジストリ情報取得処理
        /// <summary>
        /// レジストリ情報取得
        /// </summary>
        /// <returns>STATUS(0:正常,-1:異常)</returns>
        /// <remarks>
        /// <br>Note       : レジストリ情報を取得します。</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private int GetRegistoryInfo()
        {
            // 変数定義
            int result = STATUS_ERROR;  // 返却するステータス
            ClientPath = string.Empty;  // クライアントパス
            ServerPath = string.Empty;  // サーバパス 

            try
            {
                // レジストリベースロケーション取得
                RegistryKey regLocalMachine = Registry.LocalMachine;
                RegistryKey regSoftware = regLocalMachine.OpenSubKey("SOFTWARE", true);

                // クライアントパス取得
                try
                {
                    // レジストリ値取得
                    RegistryKey regClientPath = regSoftware.OpenSubKey(@"Broadleaf\Product\Partsman", true);
                    ClientPath = regClientPath.GetValue("InstallDirectory").ToString();
                }
                catch
                {
                    // レジストリ取得でエラーが発生した場合は、パスをクリア
                    ClientPath = string.Empty;
                }

                if (!string.IsNullOrEmpty(ClientPath))
                {
                    if (!Directory.Exists(ClientPath))
                    {
                        // レジストリから取得したパスが存在しない場合は、パスをクリア
                        ClientPath = string.Empty;
                    }
                }

                // サーバパス取得
                try
                {
                    // レジストリ値取得
                    RegistryKey regServerPath = regSoftware.OpenSubKey(@"Broadleaf\service\Partsman\USER_AP", true);
                    ServerPath = regServerPath.GetValue("InstallDirectory").ToString();
                }
                catch
                {
                    // レジストリ取得でエラーが発生した場合は、パスをクリア
                    ServerPath = string.Empty;
                }

                if (!string.IsNullOrEmpty(ServerPath))
                {
                    if (!Directory.Exists(ServerPath))
                    {
                        // レジストリから取得したパスが存在しない場合は、パスをクリア
                        ServerPath = string.Empty;
                    }
                }

                // クライアントパス、サーバパスを正常に取得できない場合はエラーとする
                if (string.IsNullOrEmpty(ClientPath) && string.IsNullOrEmpty(ServerPath))
                {
                    result = STATUS_ERROR;
                }
                else
                {
                    // どちらかが取得できれば正常とする
                    result = STATUS_NORMAL;
                }
            }
            catch
            {
                // 例外発生時はエラーとする
                result = STATUS_ERROR;
            }

            // 設定された戻り値を返却
            return result;
        }
        #endregion

        /// <summary>
        /// 確認処理
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <remarks>
        /// <br>Note       : 確認処理</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void Check(string name, string message, string mesPara)
        {
            try
            {
                if (File.Exists(name))
                {
                    FileVersionInfo inf = FileVersionInfo.GetVersionInfo(name);

                    if (inf.FileDescription == "PMCChecker" || inf.ProductName == "PMCChecker" || inf.OriginalFilename == "PMCChecker.exe")
                    {
                        // ログ出力
                        WriteLogAction(message, mesPara);
                    }

                }
            }
            catch (Exception ex)
            {
                // 例外エラー処理
                ExceptionCahctProcess(ex);
            }

        }

        // ===================================================================================== //
        // ファイル存在チェック
        // ===================================================================================== //
        /// <summary>
        /// ファイル存在チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : ファイルの存在チェックを行います。</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void CheckFileExists()
        {
            try
            {
                // クライアントファイルチェック
                if (!string.IsNullOrEmpty(ClientPath))
                {
                    string[] files = Directory.GetFiles(ClientPath, "*.exe");

                    if (files != null && files.Length > 0)
                    {
                        foreach (string f in files)
                        {
                            Check(f, LOGMESSAGE_FILE_EXISTS, Path.GetFileName(f));
                        }
                    }

                }

                // サーバファイルチェック
                if (!string.IsNullOrEmpty(ServerPath))
                {
                    string[] files = Directory.GetFiles(ServerPath, "*.exe");

                    if (files != null && files.Length > 0)
                    {
                        foreach (string f in files)
                        {
                            Check(f, LOGMESSAGE_FILE_EXISTS, Path.GetFileName(f));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionCahctProcess(ex);
            }
        }

        // ===================================================================================== //
        // ログ出力
        // ===================================================================================== //
        /// <summary>
        /// ログ出力
        /// </summary>
        /// <param name="paramLogMessage">ログ出力メッセージ</param>
        /// <param name="paramPaturn">ログ出力メッセージパラメータ</param>
        /// <remarks>
        /// <br>Note       : ログ出力を行います。</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void WriteLogAction(string paramLogMessage, string paramPaturn)
        {
            try
            {
                // ログ出力イベント発生
                WriteLog(this, string.Format(paramLogMessage, paramPaturn));
            }
            catch(Exception ex)
            {
                ExceptionCahctProcess(ex);
            }
        }

        // ===================================================================================== //
        // 例外をキャッチした時の処理
        // ===================================================================================== //
        /// <summary>
        /// 例外をキャッチした時の処理
        /// </summary>
        /// <param name="paraEx">今後の為に例外情報を受け取っておく</param>
        /// <remarks>
        /// <br>Note       : 例外をキャッチした際の呼び先</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void ExceptionCahctProcess(Exception paraEx)
        {
            // 何もしない
        }
    }
}

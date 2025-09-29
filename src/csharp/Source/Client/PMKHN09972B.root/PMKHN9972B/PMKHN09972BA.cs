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
    public class DevelopToolMonitoring : MarshalByRefObject
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
        /// <summary>メッセージ　ファイル作成チェック</summary>
        private const string LOGMESSAGE_FILE_CREATE = "ファイルは作成されました。({0})";
        /// <summary>メッセージ　ファイル変更チェック</summary>
        private const string LOGMESSAGE_FILE_CHANGE = "ファイルは変更されました。({0})";
        /// <summary>メッセージ　ファイル削除チェック</summary>
        private const string LOGMESSAGE_FILE_DELETE = "ファイルは削除されました。({0})";
        /// <summary>メッセージ　ファイル名変更チェック</summary>
        private const string LOGMESSAGE_FILE_RENAME = "ファイル名は変更されました。({0})";

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

        /// <summary>オブジェクト（クライアント）</summary>
        private FileSystemWatcher clientDirectoryWatcher = null;
        /// <summary>オブジェクト（サーバ）</summary>
        private FileSystemWatcher serverDirectoryWatcher = null;
        /// <summary>リスト</summary>
        private List<string> fList = new List<string>();
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
        public DevelopToolMonitoring()
        {

        }
        #endregion

        /// <summary>
        /// 開始処理
        /// </summary>
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

                // ファイル処理開始
                StartDirectoryMonitoring();
                
            }
            catch (Exception ex)
            {
                // 例外エラー処理
                ExceptionCahctProcess(ex);
            }
        }

        public void Dispose()
        {
            try
            {
                if (clientDirectoryWatcher != null)
                {
                    clientDirectoryWatcher.Dispose();
                    clientDirectoryWatcher = null;
                }
                if (serverDirectoryWatcher != null)
                {
                    serverDirectoryWatcher.Dispose();
                    serverDirectoryWatcher = null;
                }
            }
            catch
            {

            }
        }

        // ===================================================================================== //
        // ファイル作成時イベントハンドラ
        // ===================================================================================== //
        /// <summary>
        /// ファイル作成時イベントハンドラ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ファイル変更時</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void FileCreated(object sender, FileSystemEventArgs e)
        {

            try
            {
                string ext = Path.GetExtension(e.FullPath);

                if (ext.ToUpper() == ".EXE")
                {
                    Check(e.FullPath, LOGMESSAGE_FILE_CREATE, Path.GetFileName(e.FullPath));

                }
            }
            catch(Exception ex)
            {
                // 例外エラー処理
                ExceptionCahctProcess(ex);
            }
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {

            try
            {
                string ext = Path.GetExtension(e.FullPath);

                if (ext.ToUpper() == ".EXE")
                {
                    Check(e.FullPath, LOGMESSAGE_FILE_CHANGE, Path.GetFileName(e.FullPath));

                }
            }
            catch (Exception ex)
            {
                // 例外エラー処理
                ExceptionCahctProcess(ex);
            }
        }
        
        // ===================================================================================== //
        // ファイル削除時イベントハンドラ
        // ===================================================================================== //
        /// <summary>
        /// ファイル削除時イベントハンドラ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ファイル削除時</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                string ext = Path.GetExtension(e.FullPath);

                if (ext.ToUpper() == ".EXE")
                {
                    if (fList.Contains(e.FullPath))
                    {
                        // ログ出力
                        WriteLogAction(LOGMESSAGE_FILE_DELETE, Path.GetFileName(e.FullPath));
                    }
                }
            }
            catch(Exception ex)
            {
                // 例外エラー処理
                ExceptionCahctProcess(ex);
            }
        }

        // ===================================================================================== //
        // ファイル名変更時イベントハンドラ
        // ===================================================================================== //
        /// <summary>
        /// ファイル名変更時イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ファイル名が変更された</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            try
            {
                string ext = Path.GetExtension(e.FullPath);

                if (ext.ToUpper() == ".EXE")
                {
                    Check(e.FullPath, LOGMESSAGE_FILE_RENAME, Path.GetFileName(e.OldFullPath) + "→" + Path.GetFileName(e.FullPath));
                }
            }
            catch(Exception ex)
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

                        if (!fList.Contains(name))
                        {
                            fList.Add(name);
                        }
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
            catch(Exception ex)
            {
                ExceptionCahctProcess(ex);
            }
        }


        // ===================================================================================== //
        // ファイル開始
        // ===================================================================================== //
        /// <summary>
        /// ファイル開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ファイル開始処理を行います。</br>
        /// <br>Programmer : BroadLeaf</br>
        /// <br>Date       : 2020/01/24</br>
        /// </remarks>
        private void StartDirectoryMonitoring()
        {
            try
            {
                // クライアントオブジェクト起動
                if (!string.IsNullOrEmpty(ClientPath))
                {
                    clientDirectoryWatcher = new FileSystemWatcher();

                    // パスの設定
                    clientDirectoryWatcher.Path = ClientPath;

                    // イベント種類の設定
                    clientDirectoryWatcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                    // イベントハンドラ追加
                    clientDirectoryWatcher.Created += new FileSystemEventHandler(FileCreated);
                    clientDirectoryWatcher.Changed += new FileSystemEventHandler(FileChanged);
                    clientDirectoryWatcher.Deleted += new FileSystemEventHandler(FileDeleted);
                    clientDirectoryWatcher.Renamed += new RenamedEventHandler(FileRenamed);

                    // 開始
                    clientDirectoryWatcher.EnableRaisingEvents = true;

                }

                // サーバオブジェクト起動
                if (!string.IsNullOrEmpty(ServerPath))
                {
                    serverDirectoryWatcher = new FileSystemWatcher();

                    // パスの設定
                    serverDirectoryWatcher.Path = ServerPath;

                    // イベント種類の設定
                    serverDirectoryWatcher.NotifyFilter =NotifyFilters.Attributes
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                    // イベントハンドラ追加
                    serverDirectoryWatcher.Created += new FileSystemEventHandler(FileCreated);
                    serverDirectoryWatcher.Changed += new FileSystemEventHandler(FileChanged);
                    serverDirectoryWatcher.Deleted += new FileSystemEventHandler(FileDeleted);
                    serverDirectoryWatcher.Renamed += new RenamedEventHandler(FileRenamed);

                    // 開始
                    serverDirectoryWatcher.EnableRaisingEvents = true;

                }
            }
            catch(Exception ex)
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

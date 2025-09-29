//****************************************************************************//
// システム         : NS待機処理
// プログラム名称   : NS待機処理フォーム
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/10/08  修正内容 : PM7待機処理でデータ送信可能とする
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// NS待機処理フォーム
    /// </summary>
    public partial class SCMSendingDataWatcherForm : Form
    {
        //>>>2010/10/08
        #region プロパティ
        /// <summary>
        /// 起動パラメータ
        /// </summary>
        public string[] Args
        {
            set { this._args = value; }
            get { return this._args; }
        }

        private string[] _args;
        #endregion
        //<<<2010/10/08

        #region コンフィグ

        /// <summary>コンフィグ</summary>
        private SCMSendingDataWatcherConfig _config;
        /// <summary>コンフィグを取得します。</summary>
        private SCMSendingDataWatcherConfig Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new SCMSendingDataWatcherConfig();
                }
                return _config;
            }
        }

        #endregion // コンフィグ

        #region 送信処理の待ち行列

        /// <summary>送信処理の待ち行列</summary>
        private readonly SendingCommandQueue _sendingQueue = new SendingCommandQueue();
        /// <summary>送信処理の待ち行列を取得します。</summary>
        private SendingCommandQueue SendingQueue { get { return _sendingQueue; } }

        #endregion // 送信処理の待ち行列

        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMSendingDataWatcherForm()
        {
            #region Designer Code

            InitializeComponent();

            #endregion // Designer Code
        }

        #endregion // Constructor

        #region Load

        /// <summary>
        /// NS待機処理フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SCMSendingDataWatcherForm_Load(object sender, EventArgs e)
        {
            // 暗号化されたXMLファイルの編集を可能とする
            this.AllowDrop = File.Exists(Path.Combine(Environment.CurrentDirectory, "_DEBUG_.ini"));

            // 動作設定を表示
            string watchingPath = Config.GetSendingDataFolderPath();
            watchingPath = string.IsNullOrEmpty(watchingPath) ? "未設定" : watchingPath;

            this.txtLog.Text += "企業コード：" + Config.EnterpriseCode + Environment.NewLine;
            this.txtLog.Text += "拠点コード：" + Config.SectionCode + Environment.NewLine;
            this.txtLog.Text += "監視パス：" + watchingPath + (SendingFileWatcher.IncludeSubdirectories ? " (サブ含)" : "") + Environment.NewLine;
            this.txtLog.Text += "監視ファイル：" + Config.WatchingNameFilter + Environment.NewLine;
            this.txtLog.Text += "回答送信処理：" + Config.SendingAppName + Environment.NewLine;
            this.txtLog.Text += "コマンドライン引数：" + Config.GetCommandLineArg() + Environment.NewLine;
            this.txtLog.Text += Environment.NewLine;

            InitializeSendingFileWatcher();
        }

        #endregion // Load

        // 2010/06/22 一応、定義だけしておく（画面上はログ表示用のテキストボックスで隠しています）
        #region 開始と停止

        /// <summary>
        /// [開始]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //this.lblState.Text = GetStateName(State.Wating);

            //this.btnStop.Enabled = true;
            //this.btnStart.Enabled = false;
        }

        /// <summary>
        /// [停止]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //this.lblState.Text = GetStateName(State.Stoping);

            //this.btnStart.Enabled = true;
            //this.btnStop.Enabled = false;
        }

        #endregion // 開始と停止

        #region 状態

        /// <summary>
        /// 状態列挙型
        /// </summary>
        private enum State : int
        {
            /// <summary>なし</summary>
            None,
            /// <summary>送信待機中</summary>
            Wating,
            /// <summary>送信停止中</summary>
            Stoping,
            /// <summary>送信中</summary>
            Sending
        }

        /// <summary>
        /// 状態の名称を取得します。
        /// </summary>
        /// <param name="state">状態</param>
        /// <returns>状態に応じた名称</returns>
        private static string GetStateName(State state)
        {
            switch (state)
            {
                case State.Wating:
                    return "送信待機中";
                case State.Stoping:
                    return "送信停止中";
                case State.Sending:
                    return "送信中";
                default:
                    return "NS待機処理";
            }
        }

        /// <summary>
        /// 状態の更新イベントパラメータクラス
        /// </summary>
        private class UpdateStateEventArgs : EventArgs
        {
            #region 状態

            /// <summary>状態</summary>
            private readonly State _state;
            /// <summary>状態を取得します。</summary>
            public State State { get { return _state; } }

            /// <summary>状態の名称を取得します。</summary>
            public string StateName { get { return GetStateName(State); } }

            #endregion // 状態

            #region ログ

            /// <summary>ログ</summary>
            private readonly string _log;
            /// <summary>ログを取得します。</summary>
            public string Log { get { return _log; } }

            #endregion // ログ

            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="state">状態</param>
            /// <param name="log">ログ</param>
            public UpdateStateEventArgs(
                State state,
                string log
            )
            {
                _state = state;
                _log = log;
            }

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="state">状態</param>
            public UpdateStateEventArgs(State state) : this(state, string.Empty) { }

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public UpdateStateEventArgs() : this(State.None, string.Empty) { }

            #endregion // Constructor
        }

        /// <summary>
        /// 受信スレッド用状態の更新処理コールバック
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private delegate void UpdateStateCallback(object sender, UpdateStateEventArgs e);

        /// <summary>
        /// 状態を更新します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void UpdateState(
            object sender,
            UpdateStateEventArgs e
        )
        {
            if (InvokeRequired)
            {
                // 受信スレッドからのイベント処理
                Invoke(new UpdateStateCallback(UpdateState), new object[] { sender, e });
            }
            else
            {
                // 状態の表示は「送信中」を優先
                if (!IsSending)
                {
                    this.lblState.Text = e.StateName + "...";
                }
                
                // ログを更新
                if (!string.IsNullOrEmpty(e.Log))
                {
                    this.txtLog.Text += e.Log + Environment.NewLine;

                    // 最新の書き込み部分にスクロール
                    this.txtLog.SelectionStart = this.txtLog.TextLength;
                    this.txtLog.ScrollToCaret();
                }
            }
        }

        #endregion // 状態

        #region 送信ファイルの監視

        /// <summary>
        /// 送信ファイルの監視者を取得します。
        /// </summary>
        private FileSystemWatcher SendingFileWatcher
        {
            get { return this.sendingFileWatcher; }
        }

        /// <summary>
        /// 送信ファイルの監視者を初期化します。
        /// </summary>
        private void InitializeSendingFileWatcher()
        {
            #region Guard Phrase

            if (SendingFileWatcher == null) return;

            #endregion // Guard Phrase

            if (!Config.CanWatch())
            {
                this.lblState.Text = "旧システム連携が未設定";
                return;
            }

            SendingFileWatcher.Path = Config.GetSendingDataFolderPath();
            SendingFileWatcher.Filter = Config.WatchingNameFilter;
            SendingFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            SendingFileWatcher.SynchronizingObject = this;
            SendingFileWatcher.EnableRaisingEvents = true;  // 監視を開始
        }

        /// <summary>イベント処理中フラグ</summary>
        private bool _isHandling = false;
        /// <summary>イベント処理中フラグを取得または設定します。</summary>
        /// <remarks>
        /// FileSystemWatcher の Changed イベントはファイルの更新の仕方によって複数回発生するので、
        /// イベントハンドラによる処理は 1回 だけにする目的で本フラグを使用します。
        /// </remarks>
        private bool IsHandling
        {
            get { return _isHandling; }
            set { _isHandling = value; }
        }

        #region 前回の情報

        /// <summary>前回検出したデータ</summary>
        private string _previousHandledData = string.Empty;
        /// <summary>前回検出したデータを取得または設定します。</summary>
        private string PreviousHandledData
        {
            get { return _previousHandledData; }
            set { _previousHandledData = value; }
        }

        /// <summary>前回検出した日時</summary>
        private DateTime _previousHandledDateTime = DateTime.MinValue;
        /// <summary>前回検出した日時を取得または設定します。</summary>
        private DateTime PreviousHandledDateTime
        {
            get { return _previousHandledDateTime; }
            set { _previousHandledDateTime = value; }
        }

        /// <summary>
        /// 検出済みを判定するイベント間隔を取得します。
        /// </summary>
        /// <remarks>
        /// 動作環境によって調整が必要な場合、設定値をconfigファイル等に外出しすること
        /// </remarks>
        private static TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds(100.0); }
        }

        /// <summary>
        /// 検出済みであるか判断します。
        /// </summary>
        /// <param name="dataPath">送信データパス</param>
        /// <returns>
        /// 以下の場合、未検出と判断します。
        /// ①送信データパスが異なる。
        /// ②前回検出した日時より○○秒以上経過している。
        /// </returns>
        private bool IsHandled(string dataPath)
        {
            if (!dataPath.Equals(PreviousHandledData))
            {
                return false;
            }
            if (DateTime.Now - PreviousHandledDateTime >= Interval)
            {
                return false;
            }
            return true;
        }

        #endregion // 前回の情報

        /// <summary>
        /// 送信ファイルの監視者のChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingFileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (IsHandling) return;

            try
            {
                IsHandling = true;

                if (!IsSendingFile(e.FullPath)) return;

                if (IsHandled(e.FullPath)) return;

                string log = LogUtil.GetLine(
                    e.FullPath,
                    "送信データフォルダに更新がありました。"
                );

                UpdateState(this, new UpdateStateEventArgs(State.Wating, log));

                try
                {
                    BeginSending(e.FullPath);
                }
                catch (InvalidOperationException ex)    // SendingDirector : BackgroundWorker より
                {
                    Debug.WriteLine(ex);
                }

                #region ボツ

                //int maxCount = 10;
                //for (int i = 0; i < maxCount; i++)
                //{
                //    try
                //    {
                //        if (File.Exists(e.FullPath))
                //        {
                //            BeginSending(e.FullPath);
                //            break;
                //        }
                //    }
                //    catch (InvalidOperationException ex)
                //    {
                //        Debug.WriteLine(ex);
                //        break;
                //    }
                //    catch (Exception ex)
                //    {
                //        Debug.WriteLine(ex);
                //        Thread.Sleep(500);
                //    }
                //}

                #endregion // ボツ

                PreviousHandledData = e.FullPath;
                PreviousHandledDateTime = DateTime.Now;
            }
            finally
            {
                IsHandling = false;
            }
        }

        /// <summary>
        /// 送信ファイルであるか判断します。
        /// </summary>
        /// <param name="filePathName">ファイルのフルパス</param>
        /// <returns>
        /// 得先別フォルダ\伝票別フォルダ に保存されていれば送信ファイルと判断します。
        /// </returns>
        private static bool IsSendingFile(string filePathName)
        {
            string[] pathTokens = filePathName.Split('\\');

            int slipDirIndex = pathTokens.Length - 1 - 1;
            if (slipDirIndex < 0) return false;

            int customerDirIndex = slipDirIndex - 1;
            if (customerDirIndex < 0) return false;

            if (!IsSlipDataFolder(pathTokens[slipDirIndex]))
            {
                return false;
            }

            return IsCustomerDataFolder(pathTokens[customerDirIndex]);
        }

        /// <summary>
        /// 伝票別データフォルダであるか判断します。
        /// </summary>
        /// <param name="folderName">フォルダ名</param>
        /// <returns>
        /// フォルダ名が 0#_0000000# であれば、伝票別データフォルダと判断します。
        /// </returns>
        private static bool IsSlipDataFolder(string folderName)
        {
            string[] nameTokens = folderName.Split('_');
            if (!nameTokens.Length.Equals(2)) return false;

            if (!nameTokens[0].Length.Equals(2)) return false;
            int slipTypeNo = -1;
            if (!int.TryParse(nameTokens[0], out slipTypeNo))
            {
                return false;
            }

            if (!nameTokens[1].Length.Equals(8)) return false;
            int slipNo = -1;
            if (!int.TryParse(nameTokens[1], out slipNo))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 得意先別データフォルダであるか判断します。
        /// </summary>
        /// <param name="folderName">フォルダ名</param>
        /// <returns>
        /// フォルダ名が 8桁の数字 であれば、得意先別データフォルダと判断します。
        /// </returns>
        private static bool IsCustomerDataFolder(string folderName)
        {
            if (folderName.Length.Equals(8))
            {
                int customerNo = -1;
                return int.TryParse(folderName, out customerNo);
            }
            return false;
        }

        /// <summary>
        /// 送信ファイルの監視者のCreatedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (IsHandling) return;

            IsHandling = true;

            Debug.Print(e.FullPath + " が作成されました。");

            IsHandling = false;
        }

        /// <summary>
        /// 送信ファイルの監視者のDeletedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingFileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (IsHandling) return;

            IsHandling = true;

            Debug.Print(e.FullPath + " が削除されました。");

            IsHandling = false;
        }

        /// <summary>
        /// 送信ファイルの監視者のRenamedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingFileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (IsHandling) return;

            IsHandling = true;

            Debug.Print(e.FullPath + " がリネームされました。");

            IsHandling = false;
        }

        #endregion // 送信データの監視

        /// <summary>
        /// 送信処理を開始します。
        /// </summary>
        /// <param name="commandName">
        /// コマンド名称（通常は更新のあった送信データフォルダのフルパス）
        /// </param>
        private void BeginSending(string commandName)
        {
            //>>>2010/10/08
            string commandLineArgs = Config.GetCommandLineArg();
            if ((this._args != null) && (this._args.Length > 1))
            {
                commandLineArgs = this._args[0] + " " + this._args[1] + " " + commandLineArgs;
            }
            //<<<2010/10/08

            // 送信コマンドを構築
            ISendingCommand sendingCommand = new SendingCommand(
                commandName,
                Config.SendingAppName,
                //>>>2010/10/08
                //Config.GetCommandLineArg()
                commandLineArgs
                //<<<2010/10/08 
            );

            // 送信処理の待ち行列に追加
            SendingQueue.Enqueue(sendingCommand);

            // 送信処理を開始
            if (!IsSending)
            {
                if (!SendingDirector.IsBusy)
                {
                    SendingDirector.RunWorkerAsync();
                }
                //SendingDirector.CancelAsync();
            }
        }

        #region 送信処理の監督

        /// <summary>
        /// 送信処理の監督者を取得します。
        /// </summary>
        private BackgroundWorker SendingDirector
        {
            get { return this.sendingDirector; }
        }

        /// <summary>送信中フラグ</summary>
        private bool _isSending = false;
        /// <summary>送信中フラグを取得または設定します。</summary>
        private bool IsSending
        {
            get { return _isSending; }
            set { _isSending = value; }
        }

        /// <summary>
        /// 送信処理の監督者のDoWorkイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingDirector_DoWork(object sender, DoWorkEventArgs e)
        {
            if (IsSending) return;

            int seq = 0;
            while (SendingQueue.ExistsCommand)
            {
                seq++;

                // 送信処理の待ち行列から送信コマンドを取り出す
                ISendingCommand sendingCommand = SendingQueue.Dequeue();

                UpdateState(
                    this,
                    new UpdateStateEventArgs(State.Sending, LogUtil.GetLine(sendingCommand.Name, seq, "回答送信処理を起動"))
                );
                IsSending = true;   // 状態の更新処理の後でフラグを立てること

                // 回答送信処理を実行(送信コマンド側で回答送信処理のプロセス監視を実施しています)
                int status = sendingCommand.Execute();
                if (!status.Equals(0))
                {
                    // 処理に失敗したら終了
                    break;
                }
            }   // 処理が終了したら次の送信コマンドを実行

            // 送信コマンドが無くなったら、終了→RunWorkerCompletedイベント
            e.Cancel = true;
        }

        /// <summary>
        /// 送信処理の監督者のProgressChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingDirector_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine(e.ProgressPercentage.ToString() + " %");
        }

        /// <summary>
        /// 送信処理の監督者のRunWorkerCompletedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void sendingDirector_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsSending = false;  // フラグを落としてから状態の更新処理を行うこと
            UpdateState(
                this,
                new UpdateStateEventArgs(State.Wating, LogUtil.GetLine("全ての送信処理が終了しました。"))
            );
        }

        #endregion // 送信処理の監督

        #region 現在の日時

        /// <summary>
        /// 現在の日時タイマのTickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void timerNow_Tick(object sender, EventArgs e)
        {
            // 日付
            string dateText = DateTime.Now.ToString("yyyy/MM/dd");
            if (!this.dateStatusLabel.Text.Equals(dateText))
            {
                this.dateStatusLabel.Text = dateText;
            }

            // 時刻
            string timeText = DateTime.Now.ToString("HH:mm:ss");
            if (!this.timeStatusLabel.Text.Equals(timeText))
            {
                this.timeStatusLabel.Text = timeText;
            }
        }

        #endregion // 現在の日時

        #region 閉じる

        /// <summary>
        /// [閉じる]ボタンのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントハンドラ</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion // 閉じる

        #region 暗号化されたXMLファイルの編集

        /// <summary>
        /// NS待機処理フォームのDragEnterイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SCMSendingDataWatcherForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// NS待機処理フォームのDragDropイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SCMSendingDataWatcherForm_DragDrop(object sender, DragEventArgs e)
        {
            DialogResult result = MessageBox.Show("はい：復号化／いいえ：暗号化", "3DES", MessageBoxButtons.YesNoCancel);
            if (result.Equals(DialogResult.Cancel)) return;

            // ドラッグ＆ドロップされたファイル
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePathName in files)
            {
                if (!File.Exists(filePathName)) continue;

                if (result.Equals(DialogResult.Yes))
                {
                    LogUtil.DecodeFile(filePathName);
                }
                else
                {
                    LogUtil.EncodeFile(filePathName);
                }

                Process.Start("NotePad", filePathName);
            }
        }

        #endregion // 暗号化されたXMLファイルの編集
    }
}
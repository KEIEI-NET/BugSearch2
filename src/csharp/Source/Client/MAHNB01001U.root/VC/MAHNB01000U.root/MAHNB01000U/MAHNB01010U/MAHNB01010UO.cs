using System;
using System.ComponentModel;
using System.Threading;

using Infragistics.Win.UltraWinStatusBar;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 処理中の進捗表示クラス
    /// </summary>
    public sealed class NowRunningProgress : IDisposable
    {
        #region IDisposable メンバ

        /// <summary>処分済フラグ</summary>
        private bool _disposed;
        /// <summary>処分済フラグを取得または設定します。</summary>
        private bool Disposed
        {
            get { return _disposed; }
            set { _disposed = value; }
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Disposed = true;
        }

        /// <summary>
        /// 処分します。
        /// </summary>
        /// <param name="disposing">マネージオブジェクトの処分フラグ</param>
        private void Dispose(bool disposing)
        {
            if (Disposed) return;

            // マネージオブジェクト
            if (disposing)
            {
                Worker.CancelAsync();
            }
            // アンマネージオブジェクト
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~NowRunningProgress()
        {
            Dispose(false);
        }

        #endregion // IDisposable メンバ

        #region コンフィグ

        /// <summary>最大カウント数</summary>
        private const int MAX_COUNT = 5;
        /// <summary>最大カウント数を取得します。</summary>
        private static int MaxCount { get { return MAX_COUNT; } }

        /// <summary>待ち時間[msec]</summary>
        private const int SLEEP_TIME = 1000;
        /// <summary>待ち時間[msec]を取得します。</summary>
        public int SleepTime { get { return SLEEP_TIME; } }

        #endregion // コンフィグ

        #region バックグランド

        /// <summary>バックグランド実行者</summary>
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        /// <summary>バックグランド実行者を取得します。</summary>
        private BackgroundWorker Worker { get { return _worker; } }

        /// <summary>
        /// バックグランド実行者のDoWorkイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                for (int i = 0; i <= MaxCount; i++)
                {
                    if (Worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                    Worker.ReportProgress(i);
                    Thread.Sleep(SleepTime);
                }
            } while (!Worker.CancellationPending);

            e.Result = "Runned";
        }

        /// <summary>
        /// バックグランド実行者のProgressChangedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress(e.ProgressPercentage, MaxCount);
        }

        /// <summary>
        /// バックグランド実行者のRunWorkerCompletedイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunFinally();
        }

        #endregion // バックグランド

        #region ステータスバー

        /// <summary>ステータス(テキスト)</summary>
        private readonly UltraStatusPanel _statusText;
        /// <summary>ステータス(テキスト)を取得します。</summary>
        private UltraStatusPanel StatusText { get { return _statusText; } }

        /// <summary>ステータス(進捗バー)</summary>
        private readonly UltraStatusPanel _progressBar;
        /// <summary>ステータス(進捗バー)を取得します。</summary>
        private UltraStatusPanel ProgressBar { get { return _progressBar; } }

        /// <summary>
        /// ステータスを更新します。
        /// </summary>
        private void UpdateStatus()
        {
            ProgressBar.UltraStatusBar.Update();
            if (StatusText.UltraStatusBar != ProgressBar.UltraStatusBar)
            {
                StatusText.UltraStatusBar.Update();
            }
        }

        #endregion // ステータスバー

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="statusText">ステータス(テキスト)</param>
        /// <param name="progressBar">ステータス(進捗バー)</param>
        public NowRunningProgress(
            UltraStatusPanel statusText,
            UltraStatusPanel progressBar
        )
        {
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += new DoWorkEventHandler(this.DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChanged);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);

            _statusText = statusText;
            _progressBar = progressBar;

            RunInitially();
            Run();
        }

        #endregion // Constructor

        /// <summary>
        /// 実行前処理を行います。
        /// </summary>
        private void RunInitially()
        {
            StatusText.Text = "処理中...";
            ProgressBar.Visible = true;
            UpdateStatus();
        }

        /// <summary>
        /// 実行します。
        /// </summary>
        private void Run()
        {
            Worker.RunWorkerAsync();
        }

        /// <summary>
        /// 進捗を更新します。
        /// </summary>
        /// <param name="count">カウント数</param>
        /// <param name="maxCount">最大カウント数</param>
        private void UpdateProgress(int count, int maxCount)
        {
            ProgressBar.ProgressBarInfo.Maximum = maxCount;
            ProgressBar.ProgressBarInfo.Value = count;
            UpdateStatus();
        }

        /// <summary>
        /// 実行後処理を行います。
        /// </summary>
        private void RunFinally()
        {
            StatusText.Text = string.Empty;
            ProgressBar.Visible = false;
            UpdateStatus();
        }
    }
}

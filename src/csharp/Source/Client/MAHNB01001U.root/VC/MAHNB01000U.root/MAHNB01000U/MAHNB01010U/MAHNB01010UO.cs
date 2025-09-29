using System;
using System.ComponentModel;
using System.Threading;

using Infragistics.Win.UltraWinStatusBar;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������̐i���\���N���X
    /// </summary>
    public sealed class NowRunningProgress : IDisposable
    {
        #region IDisposable �����o

        /// <summary>�����σt���O</summary>
        private bool _disposed;
        /// <summary>�����σt���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool Disposed
        {
            get { return _disposed; }
            set { _disposed = value; }
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Disposed = true;
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W�I�u�W�F�N�g�̏����t���O</param>
        private void Dispose(bool disposing)
        {
            if (Disposed) return;

            // �}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
                Worker.CancelAsync();
            }
            // �A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~NowRunningProgress()
        {
            Dispose(false);
        }

        #endregion // IDisposable �����o

        #region �R���t�B�O

        /// <summary>�ő�J�E���g��</summary>
        private const int MAX_COUNT = 5;
        /// <summary>�ő�J�E���g�����擾���܂��B</summary>
        private static int MaxCount { get { return MAX_COUNT; } }

        /// <summary>�҂�����[msec]</summary>
        private const int SLEEP_TIME = 1000;
        /// <summary>�҂�����[msec]���擾���܂��B</summary>
        public int SleepTime { get { return SLEEP_TIME; } }

        #endregion // �R���t�B�O

        #region �o�b�N�O�����h

        /// <summary>�o�b�N�O�����h���s��</summary>
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        /// <summary>�o�b�N�O�����h���s�҂��擾���܂��B</summary>
        private BackgroundWorker Worker { get { return _worker; } }

        /// <summary>
        /// �o�b�N�O�����h���s�҂�DoWork�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
        /// �o�b�N�O�����h���s�҂�ProgressChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress(e.ProgressPercentage, MaxCount);
        }

        /// <summary>
        /// �o�b�N�O�����h���s�҂�RunWorkerCompleted�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunFinally();
        }

        #endregion // �o�b�N�O�����h

        #region �X�e�[�^�X�o�[

        /// <summary>�X�e�[�^�X(�e�L�X�g)</summary>
        private readonly UltraStatusPanel _statusText;
        /// <summary>�X�e�[�^�X(�e�L�X�g)���擾���܂��B</summary>
        private UltraStatusPanel StatusText { get { return _statusText; } }

        /// <summary>�X�e�[�^�X(�i���o�[)</summary>
        private readonly UltraStatusPanel _progressBar;
        /// <summary>�X�e�[�^�X(�i���o�[)���擾���܂��B</summary>
        private UltraStatusPanel ProgressBar { get { return _progressBar; } }

        /// <summary>
        /// �X�e�[�^�X���X�V���܂��B
        /// </summary>
        private void UpdateStatus()
        {
            ProgressBar.UltraStatusBar.Update();
            if (StatusText.UltraStatusBar != ProgressBar.UltraStatusBar)
            {
                StatusText.UltraStatusBar.Update();
            }
        }

        #endregion // �X�e�[�^�X�o�[

        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="statusText">�X�e�[�^�X(�e�L�X�g)</param>
        /// <param name="progressBar">�X�e�[�^�X(�i���o�[)</param>
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
        /// ���s�O�������s���܂��B
        /// </summary>
        private void RunInitially()
        {
            StatusText.Text = "������...";
            ProgressBar.Visible = true;
            UpdateStatus();
        }

        /// <summary>
        /// ���s���܂��B
        /// </summary>
        private void Run()
        {
            Worker.RunWorkerAsync();
        }

        /// <summary>
        /// �i�����X�V���܂��B
        /// </summary>
        /// <param name="count">�J�E���g��</param>
        /// <param name="maxCount">�ő�J�E���g��</param>
        private void UpdateProgress(int count, int maxCount)
        {
            ProgressBar.ProgressBarInfo.Maximum = maxCount;
            ProgressBar.ProgressBarInfo.Value = count;
            UpdateStatus();
        }

        /// <summary>
        /// ���s�㏈�����s���܂��B
        /// </summary>
        private void RunFinally()
        {
            StatusText.Text = string.Empty;
            ProgressBar.Visible = false;
            UpdateStatus();
        }
    }
}

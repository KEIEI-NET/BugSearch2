//****************************************************************************//
// �V�X�e��         : NS�ҋ@����
// �v���O��������   : NS�ҋ@�����t�H�[��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/10/08  �C�����e : PM7�ҋ@�����Ńf�[�^���M�\�Ƃ���
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
    /// NS�ҋ@�����t�H�[��
    /// </summary>
    public partial class SCMSendingDataWatcherForm : Form
    {
        //>>>2010/10/08
        #region �v���p�e�B
        /// <summary>
        /// �N���p�����[�^
        /// </summary>
        public string[] Args
        {
            set { this._args = value; }
            get { return this._args; }
        }

        private string[] _args;
        #endregion
        //<<<2010/10/08

        #region �R���t�B�O

        /// <summary>�R���t�B�O</summary>
        private SCMSendingDataWatcherConfig _config;
        /// <summary>�R���t�B�O���擾���܂��B</summary>
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

        #endregion // �R���t�B�O

        #region ���M�����̑҂��s��

        /// <summary>���M�����̑҂��s��</summary>
        private readonly SendingCommandQueue _sendingQueue = new SendingCommandQueue();
        /// <summary>���M�����̑҂��s����擾���܂��B</summary>
        private SendingCommandQueue SendingQueue { get { return _sendingQueue; } }

        #endregion // ���M�����̑҂��s��

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
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
        /// NS�ҋ@�����t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void SCMSendingDataWatcherForm_Load(object sender, EventArgs e)
        {
            // �Í������ꂽXML�t�@�C���̕ҏW���\�Ƃ���
            this.AllowDrop = File.Exists(Path.Combine(Environment.CurrentDirectory, "_DEBUG_.ini"));

            // ����ݒ��\��
            string watchingPath = Config.GetSendingDataFolderPath();
            watchingPath = string.IsNullOrEmpty(watchingPath) ? "���ݒ�" : watchingPath;

            this.txtLog.Text += "��ƃR�[�h�F" + Config.EnterpriseCode + Environment.NewLine;
            this.txtLog.Text += "���_�R�[�h�F" + Config.SectionCode + Environment.NewLine;
            this.txtLog.Text += "�Ď��p�X�F" + watchingPath + (SendingFileWatcher.IncludeSubdirectories ? " (�T�u��)" : "") + Environment.NewLine;
            this.txtLog.Text += "�Ď��t�@�C���F" + Config.WatchingNameFilter + Environment.NewLine;
            this.txtLog.Text += "�񓚑��M�����F" + Config.SendingAppName + Environment.NewLine;
            this.txtLog.Text += "�R�}���h���C�������F" + Config.GetCommandLineArg() + Environment.NewLine;
            this.txtLog.Text += Environment.NewLine;

            InitializeSendingFileWatcher();
        }

        #endregion // Load

        // 2010/06/22 �ꉞ�A��`�������Ă����i��ʏ�̓��O�\���p�̃e�L�X�g�{�b�N�X�ŉB���Ă��܂��j
        #region �J�n�ƒ�~

        /// <summary>
        /// [�J�n]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //this.lblState.Text = GetStateName(State.Wating);

            //this.btnStop.Enabled = true;
            //this.btnStart.Enabled = false;
        }

        /// <summary>
        /// [��~]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            //this.lblState.Text = GetStateName(State.Stoping);

            //this.btnStart.Enabled = true;
            //this.btnStop.Enabled = false;
        }

        #endregion // �J�n�ƒ�~

        #region ���

        /// <summary>
        /// ��ԗ񋓌^
        /// </summary>
        private enum State : int
        {
            /// <summary>�Ȃ�</summary>
            None,
            /// <summary>���M�ҋ@��</summary>
            Wating,
            /// <summary>���M��~��</summary>
            Stoping,
            /// <summary>���M��</summary>
            Sending
        }

        /// <summary>
        /// ��Ԃ̖��̂��擾���܂��B
        /// </summary>
        /// <param name="state">���</param>
        /// <returns>��Ԃɉ���������</returns>
        private static string GetStateName(State state)
        {
            switch (state)
            {
                case State.Wating:
                    return "���M�ҋ@��";
                case State.Stoping:
                    return "���M��~��";
                case State.Sending:
                    return "���M��";
                default:
                    return "NS�ҋ@����";
            }
        }

        /// <summary>
        /// ��Ԃ̍X�V�C�x���g�p�����[�^�N���X
        /// </summary>
        private class UpdateStateEventArgs : EventArgs
        {
            #region ���

            /// <summary>���</summary>
            private readonly State _state;
            /// <summary>��Ԃ��擾���܂��B</summary>
            public State State { get { return _state; } }

            /// <summary>��Ԃ̖��̂��擾���܂��B</summary>
            public string StateName { get { return GetStateName(State); } }

            #endregion // ���

            #region ���O

            /// <summary>���O</summary>
            private readonly string _log;
            /// <summary>���O���擾���܂��B</summary>
            public string Log { get { return _log; } }

            #endregion // ���O

            #region Constructor

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="state">���</param>
            /// <param name="log">���O</param>
            public UpdateStateEventArgs(
                State state,
                string log
            )
            {
                _state = state;
                _log = log;
            }

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="state">���</param>
            public UpdateStateEventArgs(State state) : this(state, string.Empty) { }

            /// <summary>
            /// �f�t�H���g�R���X�g���N�^
            /// </summary>
            public UpdateStateEventArgs() : this(State.None, string.Empty) { }

            #endregion // Constructor
        }

        /// <summary>
        /// ��M�X���b�h�p��Ԃ̍X�V�����R�[���o�b�N
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private delegate void UpdateStateCallback(object sender, UpdateStateEventArgs e);

        /// <summary>
        /// ��Ԃ��X�V���܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void UpdateState(
            object sender,
            UpdateStateEventArgs e
        )
        {
            if (InvokeRequired)
            {
                // ��M�X���b�h����̃C�x���g����
                Invoke(new UpdateStateCallback(UpdateState), new object[] { sender, e });
            }
            else
            {
                // ��Ԃ̕\���́u���M���v��D��
                if (!IsSending)
                {
                    this.lblState.Text = e.StateName + "...";
                }
                
                // ���O���X�V
                if (!string.IsNullOrEmpty(e.Log))
                {
                    this.txtLog.Text += e.Log + Environment.NewLine;

                    // �ŐV�̏������ݕ����ɃX�N���[��
                    this.txtLog.SelectionStart = this.txtLog.TextLength;
                    this.txtLog.ScrollToCaret();
                }
            }
        }

        #endregion // ���

        #region ���M�t�@�C���̊Ď�

        /// <summary>
        /// ���M�t�@�C���̊Ď��҂��擾���܂��B
        /// </summary>
        private FileSystemWatcher SendingFileWatcher
        {
            get { return this.sendingFileWatcher; }
        }

        /// <summary>
        /// ���M�t�@�C���̊Ď��҂����������܂��B
        /// </summary>
        private void InitializeSendingFileWatcher()
        {
            #region Guard Phrase

            if (SendingFileWatcher == null) return;

            #endregion // Guard Phrase

            if (!Config.CanWatch())
            {
                this.lblState.Text = "���V�X�e���A�g�����ݒ�";
                return;
            }

            SendingFileWatcher.Path = Config.GetSendingDataFolderPath();
            SendingFileWatcher.Filter = Config.WatchingNameFilter;
            SendingFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            SendingFileWatcher.SynchronizingObject = this;
            SendingFileWatcher.EnableRaisingEvents = true;  // �Ď����J�n
        }

        /// <summary>�C�x���g�������t���O</summary>
        private bool _isHandling = false;
        /// <summary>�C�x���g�������t���O���擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks>
        /// FileSystemWatcher �� Changed �C�x���g�̓t�@�C���̍X�V�̎d���ɂ���ĕ����񔭐�����̂ŁA
        /// �C�x���g�n���h���ɂ�鏈���� 1�� �����ɂ���ړI�Ŗ{�t���O���g�p���܂��B
        /// </remarks>
        private bool IsHandling
        {
            get { return _isHandling; }
            set { _isHandling = value; }
        }

        #region �O��̏��

        /// <summary>�O�񌟏o�����f�[�^</summary>
        private string _previousHandledData = string.Empty;
        /// <summary>�O�񌟏o�����f�[�^���擾�܂��͐ݒ肵�܂��B</summary>
        private string PreviousHandledData
        {
            get { return _previousHandledData; }
            set { _previousHandledData = value; }
        }

        /// <summary>�O�񌟏o��������</summary>
        private DateTime _previousHandledDateTime = DateTime.MinValue;
        /// <summary>�O�񌟏o�����������擾�܂��͐ݒ肵�܂��B</summary>
        private DateTime PreviousHandledDateTime
        {
            get { return _previousHandledDateTime; }
            set { _previousHandledDateTime = value; }
        }

        /// <summary>
        /// ���o�ς݂𔻒肷��C�x���g�Ԋu���擾���܂��B
        /// </summary>
        /// <remarks>
        /// ������ɂ���Ē������K�v�ȏꍇ�A�ݒ�l��config�t�@�C�����ɊO�o�����邱��
        /// </remarks>
        private static TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds(100.0); }
        }

        /// <summary>
        /// ���o�ς݂ł��邩���f���܂��B
        /// </summary>
        /// <param name="dataPath">���M�f�[�^�p�X</param>
        /// <returns>
        /// �ȉ��̏ꍇ�A�����o�Ɣ��f���܂��B
        /// �@���M�f�[�^�p�X���قȂ�B
        /// �A�O�񌟏o����������聛���b�ȏ�o�߂��Ă���B
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

        #endregion // �O��̏��

        /// <summary>
        /// ���M�t�@�C���̊Ď��҂�Changed�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
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
                    "���M�f�[�^�t�H���_�ɍX�V������܂����B"
                );

                UpdateState(this, new UpdateStateEventArgs(State.Wating, log));

                try
                {
                    BeginSending(e.FullPath);
                }
                catch (InvalidOperationException ex)    // SendingDirector : BackgroundWorker ���
                {
                    Debug.WriteLine(ex);
                }

                #region �{�c

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

                #endregion // �{�c

                PreviousHandledData = e.FullPath;
                PreviousHandledDateTime = DateTime.Now;
            }
            finally
            {
                IsHandling = false;
            }
        }

        /// <summary>
        /// ���M�t�@�C���ł��邩���f���܂��B
        /// </summary>
        /// <param name="filePathName">�t�@�C���̃t���p�X</param>
        /// <returns>
        /// ����ʃt�H���_\�`�[�ʃt�H���_ �ɕۑ�����Ă���Α��M�t�@�C���Ɣ��f���܂��B
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
        /// �`�[�ʃf�[�^�t�H���_�ł��邩���f���܂��B
        /// </summary>
        /// <param name="folderName">�t�H���_��</param>
        /// <returns>
        /// �t�H���_���� 0#_0000000# �ł���΁A�`�[�ʃf�[�^�t�H���_�Ɣ��f���܂��B
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
        /// ���Ӑ�ʃf�[�^�t�H���_�ł��邩���f���܂��B
        /// </summary>
        /// <param name="folderName">�t�H���_��</param>
        /// <returns>
        /// �t�H���_���� 8���̐��� �ł���΁A���Ӑ�ʃf�[�^�t�H���_�Ɣ��f���܂��B
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
        /// ���M�t�@�C���̊Ď��҂�Created�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (IsHandling) return;

            IsHandling = true;

            Debug.Print(e.FullPath + " ���쐬����܂����B");

            IsHandling = false;
        }

        /// <summary>
        /// ���M�t�@�C���̊Ď��҂�Deleted�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingFileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (IsHandling) return;

            IsHandling = true;

            Debug.Print(e.FullPath + " ���폜����܂����B");

            IsHandling = false;
        }

        /// <summary>
        /// ���M�t�@�C���̊Ď��҂�Renamed�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingFileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (IsHandling) return;

            IsHandling = true;

            Debug.Print(e.FullPath + " �����l�[������܂����B");

            IsHandling = false;
        }

        #endregion // ���M�f�[�^�̊Ď�

        /// <summary>
        /// ���M�������J�n���܂��B
        /// </summary>
        /// <param name="commandName">
        /// �R�}���h���́i�ʏ�͍X�V�̂��������M�f�[�^�t�H���_�̃t���p�X�j
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

            // ���M�R�}���h���\�z
            ISendingCommand sendingCommand = new SendingCommand(
                commandName,
                Config.SendingAppName,
                //>>>2010/10/08
                //Config.GetCommandLineArg()
                commandLineArgs
                //<<<2010/10/08 
            );

            // ���M�����̑҂��s��ɒǉ�
            SendingQueue.Enqueue(sendingCommand);

            // ���M�������J�n
            if (!IsSending)
            {
                if (!SendingDirector.IsBusy)
                {
                    SendingDirector.RunWorkerAsync();
                }
                //SendingDirector.CancelAsync();
            }
        }

        #region ���M�����̊ē�

        /// <summary>
        /// ���M�����̊ē҂��擾���܂��B
        /// </summary>
        private BackgroundWorker SendingDirector
        {
            get { return this.sendingDirector; }
        }

        /// <summary>���M���t���O</summary>
        private bool _isSending = false;
        /// <summary>���M���t���O���擾�܂��͐ݒ肵�܂��B</summary>
        private bool IsSending
        {
            get { return _isSending; }
            set { _isSending = value; }
        }

        /// <summary>
        /// ���M�����̊ē҂�DoWork�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingDirector_DoWork(object sender, DoWorkEventArgs e)
        {
            if (IsSending) return;

            int seq = 0;
            while (SendingQueue.ExistsCommand)
            {
                seq++;

                // ���M�����̑҂��s�񂩂瑗�M�R�}���h�����o��
                ISendingCommand sendingCommand = SendingQueue.Dequeue();

                UpdateState(
                    this,
                    new UpdateStateEventArgs(State.Sending, LogUtil.GetLine(sendingCommand.Name, seq, "�񓚑��M�������N��"))
                );
                IsSending = true;   // ��Ԃ̍X�V�����̌�Ńt���O�𗧂Ă邱��

                // �񓚑��M���������s(���M�R�}���h���ŉ񓚑��M�����̃v���Z�X�Ď������{���Ă��܂�)
                int status = sendingCommand.Execute();
                if (!status.Equals(0))
                {
                    // �����Ɏ��s������I��
                    break;
                }
            }   // �������I�������玟�̑��M�R�}���h�����s

            // ���M�R�}���h�������Ȃ�����A�I����RunWorkerCompleted�C�x���g
            e.Cancel = true;
        }

        /// <summary>
        /// ���M�����̊ē҂�ProgressChanged�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingDirector_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine(e.ProgressPercentage.ToString() + " %");
        }

        /// <summary>
        /// ���M�����̊ē҂�RunWorkerCompleted�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void sendingDirector_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsSending = false;  // �t���O�𗎂Ƃ��Ă����Ԃ̍X�V�������s������
            UpdateState(
                this,
                new UpdateStateEventArgs(State.Wating, LogUtil.GetLine("�S�Ă̑��M�������I�����܂����B"))
            );
        }

        #endregion // ���M�����̊ē�

        #region ���݂̓���

        /// <summary>
        /// ���݂̓����^�C�}��Tick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void timerNow_Tick(object sender, EventArgs e)
        {
            // ���t
            string dateText = DateTime.Now.ToString("yyyy/MM/dd");
            if (!this.dateStatusLabel.Text.Equals(dateText))
            {
                this.dateStatusLabel.Text = dateText;
            }

            // ����
            string timeText = DateTime.Now.ToString("HH:mm:ss");
            if (!this.timeStatusLabel.Text.Equals(timeText))
            {
                this.timeStatusLabel.Text = timeText;
            }
        }

        #endregion // ���݂̓���

        #region ����

        /// <summary>
        /// [����]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion // ����

        #region �Í������ꂽXML�t�@�C���̕ҏW

        /// <summary>
        /// NS�ҋ@�����t�H�[����DragEnter�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void SCMSendingDataWatcherForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// NS�ҋ@�����t�H�[����DragDrop�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void SCMSendingDataWatcherForm_DragDrop(object sender, DragEventArgs e)
        {
            DialogResult result = MessageBox.Show("�͂��F�������^�������F�Í���", "3DES", MessageBoxButtons.YesNoCancel);
            if (result.Equals(DialogResult.Cancel)) return;

            // �h���b�O���h���b�v���ꂽ�t�@�C��
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

        #endregion // �Í������ꂽXML�t�@�C���̕ҏW
    }
}
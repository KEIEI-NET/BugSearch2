using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �ȈՃX�g�b�v�E�H�b�`�N���X
    /// </summary>
    public sealed class SimpleStopWatch : IDisposable
    {
        #region <IDisposable �����o>

        /// <summary>
        /// �������܂��B
        /// </summary>
        public void Dispose()
        {
            Flash();
        }

        #endregion  // </IDisposable �����o>

        #region <�o�͐ݒ�>

        private const string CAN_PRINT_FLAG_FILE = "_DEBUG_.ini";

        private bool CanPrint
        {
            get
            {
                return File.Exists(Path.Combine(CurrentPath, CAN_PRINT_FLAG_FILE));
            }
        }

        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DEFAULT_ENCODING = "shift_jis";
        /// <summary>���݂̃G���R�[�h</summary>
        private string _currentEncoding = string.Empty;
        /// <summary>���݂̃G���R�[�h���擾���܂��B</summary>
        private string CurrentEncoding
        {
            get
            {
                if (string.IsNullOrEmpty(_currentEncoding.Trim()))
                {
                    return DEFAULT_ENCODING;
                }
                return _currentEncoding;
            }
        }

        /// <summary>�f�t�H���g�̌v�����e���o�͂���t�@�C����</summary>
        private const string DEFAULT_OUTPUT_FILE_NAME = "SimpleStopWatch.txt";
        /// <summary>�v�����e���o�͂���t�@�C����</summary>
        private string _outputFileName = string.Empty;
        /// <summary>�v�����e���o�͂���t�@�C�������擾���܂��B</summary>
        private string OutputFileName
        {
            get
            {
                if (string.IsNullOrEmpty(_outputFileName.Trim()))
                {
                    return DEFAULT_OUTPUT_FILE_NAME;
                }
                return _outputFileName;
            }
        }

        /// <summary>�f�t�H���g�p�X</summary>
        private const string DEFAULT_PATH = "D:\\scmwork";
        /// <summary>���݂̃p�X</summary>
        private string _currentPath = string.Empty;
        /// <summary>���݂̃p�X���擾���܂��B</summary>
        private string CurrentPath
        {
            get
            {
                if (string.IsNullOrEmpty(_currentPath.Trim()))
                {
                    return DEFAULT_PATH;
                }
                return _currentPath;
            }
        }

        /// <summary>
        /// �o�̓t�@�C���̃t���p�X���擾���܂��B
        /// </summary>
        private string OutputFullPath
        {
            get { return Path.Combine(CurrentPath, OutputFileName); }
        }

        #endregion // </�o�͐ݒ�>

        #region <�v������>

        /// <summary>���݂̃X�g�b�v�E�H�b�`</summary>
        private Stopwatch _currentStopWatch;
        /// <summary>���݂̃X�g�b�v�E�H�b�`���擾���܂��B</summary>
        private Stopwatch CurrentStopWatch
        {
            get
            {
                if (_currentStopWatch == null)
                {
                    _currentStopWatch = new Stopwatch();
                }
                return _currentStopWatch;
            }
        }

        /// <summary>���݂̌v������</summary>
        private string _currentItem;
        /// <summary>���݂̌v�����ڂ��擾�܂��͐ݒ肵�܂��B</summary>
        private string CurrentItem
        {
            get { return _currentItem; }
            set { _currentItem = value; }
        }

        #endregion // </�v������>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SimpleStopWatch() : this(string.Empty) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="outputFileName">�v�����e���o�͂���t�@�C����</param>
        public SimpleStopWatch(string outputFileName)
        {
            _outputFileName = outputFileName;
        }

        #endregion // </Constructor>

        /// <summary>
        /// �o�ߎ���[msec]���擾���܂��B
        /// </summary>
        private long ElapsedMilliseconds
        {
            get { return CurrentStopWatch.ElapsedMilliseconds; }
        }

        /// <summary>
        /// �v�����J�n���܂��B
        /// </summary>
        /// <param name="item">�v�����鍀�ږ�</param>
        public void Start(string item)
        {
            if (!item.Equals(CurrentItem)) CurrentStopWatch.Reset();

            CurrentItem = item;
            CurrentStopWatch.Start();
        }

        /// <summary>
        /// �v�����~���܂��B
        /// </summary>
        public void Stop()
        {
            CurrentStopWatch.Stop();
            Print(string.Format("{0}\t�o�ߎ���={1}\t[msec]",
                CurrentItem,
                ElapsedMilliseconds
            ));
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        public void Memo(string msg)
        {
            Print(msg);
        }

        /// <summary>
        /// �v�����ʂ��t�@�C���ɏo�͂��܂��B
        /// </summary>
        private void Flash()
        {
            Print(string.Format("�Ō�̌v�����ځF{0}\t�o�ߎ���={1}\t[msec]",
                CurrentItem,
                ElapsedMilliseconds
            ));
        }

        /// <summary>
        /// �t�@�C���ɏo�͂��܂��B
        /// </summary>
        /// <param name="line">�o�͓��e</param>
        private void Print(string line)
        {
            if (!CanPrint) return;

            FileStream fileStream   = new FileStream(OutputFullPath, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer     = new StreamWriter(fileStream, Encoding.GetEncoding(CurrentEncoding));
            try
            {
                writer.WriteLine(line);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (writer != null)     writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
    }
}

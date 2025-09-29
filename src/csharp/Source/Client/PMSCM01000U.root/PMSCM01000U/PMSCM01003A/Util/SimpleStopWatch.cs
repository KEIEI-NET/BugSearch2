using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 簡易ストップウォッチクラス
    /// </summary>
    public sealed class SimpleStopWatch : IDisposable
    {
        #region <IDisposable メンバ>

        /// <summary>
        /// 処分します。
        /// </summary>
        public void Dispose()
        {
            Flash();
        }

        #endregion  // </IDisposable メンバ>

        #region <出力設定>

        private const string CAN_PRINT_FLAG_FILE = "_DEBUG_.ini";

        private bool CanPrint
        {
            get
            {
                return File.Exists(Path.Combine(CurrentPath, CAN_PRINT_FLAG_FILE));
            }
        }

        /// <summary>デフォルトエンコード</summary>
        private const string DEFAULT_ENCODING = "shift_jis";
        /// <summary>現在のエンコード</summary>
        private string _currentEncoding = string.Empty;
        /// <summary>現在のエンコードを取得します。</summary>
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

        /// <summary>デフォルトの計測内容を出力するファイル名</summary>
        private const string DEFAULT_OUTPUT_FILE_NAME = "SimpleStopWatch.txt";
        /// <summary>計測内容を出力するファイル名</summary>
        private string _outputFileName = string.Empty;
        /// <summary>計測内容を出力するファイル名を取得します。</summary>
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

        /// <summary>デフォルトパス</summary>
        private const string DEFAULT_PATH = "D:\\scmwork";
        /// <summary>現在のパス</summary>
        private string _currentPath = string.Empty;
        /// <summary>現在のパスを取得します。</summary>
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
        /// 出力ファイルのフルパスを取得します。
        /// </summary>
        private string OutputFullPath
        {
            get { return Path.Combine(CurrentPath, OutputFileName); }
        }

        #endregion // </出力設定>

        #region <計測項目>

        /// <summary>現在のストップウォッチ</summary>
        private Stopwatch _currentStopWatch;
        /// <summary>現在のストップウォッチを取得します。</summary>
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

        /// <summary>現在の計測項目</summary>
        private string _currentItem;
        /// <summary>現在の計測項目を取得または設定します。</summary>
        private string CurrentItem
        {
            get { return _currentItem; }
            set { _currentItem = value; }
        }

        #endregion // </計測項目>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SimpleStopWatch() : this(string.Empty) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="outputFileName">計測内容を出力するファイル名</param>
        public SimpleStopWatch(string outputFileName)
        {
            _outputFileName = outputFileName;
        }

        #endregion // </Constructor>

        /// <summary>
        /// 経過時間[msec]を取得します。
        /// </summary>
        private long ElapsedMilliseconds
        {
            get { return CurrentStopWatch.ElapsedMilliseconds; }
        }

        /// <summary>
        /// 計測を開始します。
        /// </summary>
        /// <param name="item">計測する項目名</param>
        public void Start(string item)
        {
            if (!item.Equals(CurrentItem)) CurrentStopWatch.Reset();

            CurrentItem = item;
            CurrentStopWatch.Start();
        }

        /// <summary>
        /// 計測を停止します。
        /// </summary>
        public void Stop()
        {
            CurrentStopWatch.Stop();
            Print(string.Format("{0}\t経過時間={1}\t[msec]",
                CurrentItem,
                ElapsedMilliseconds
            ));
        }

        /// <summary>
        /// メモします。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Memo(string msg)
        {
            Print(msg);
        }

        /// <summary>
        /// 計測結果をファイルに出力します。
        /// </summary>
        private void Flash()
        {
            Print(string.Format("最後の計測項目：{0}\t経過時間={1}\t[msec]",
                CurrentItem,
                ElapsedMilliseconds
            ));
        }

        /// <summary>
        /// ファイルに出力します。
        /// </summary>
        /// <param name="line">出力内容</param>
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

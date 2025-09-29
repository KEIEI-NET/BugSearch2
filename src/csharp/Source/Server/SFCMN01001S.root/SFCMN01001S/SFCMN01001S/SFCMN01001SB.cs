using System;
using System.Data;
using System.ServiceProcess;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using System.Xml;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace Broadleaf.ServiceProcess
{

    /// <summary>
    /// コンバート対象バックアップ実行クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象のバックアップ処理を実行します。</br>
    /// <br>Programmer : 32470　小原 卓也</br>
    /// <br>Date       : 2020.06.15</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjBkExec 
    {
        // 定時起動設定
        private const string ct_BkSettingFile = "SFCMN01001S_BkSetting.XML"; // 設定ファイル
        private const int ct_DefaultBkStarthh = 2;                           // バックアップ開始（時間）
        private const int ct_DefaultBkStartmm = 0;                           // バックアップ開始（分）
        private const string ct_ConvObjBkExec = "PMCMN00160U.exe";           // バックアップ実行プログラム
        private const string ct_ConvObjBkProcName = "PMCMN00160U";           // バックアップ実行プログラムプロセス名
        private const string ct_FirstDeliveryFile = "PMCMN00160U_Delivery.txt"; // 初回実行時配信ファイル

        /// <summary>
        /// 起動パラメータ：サービス
        /// </summary>
        private const string ARGS_Service = "Service";

        // 一日(millisecond)
        private const int INTERVAL_1DAY = 86400000;

        // 1分(millisecond)
        private const int INTERVAL_1MINUTE = 60000;

        // バックアップ開始タイマー
        private System.Timers.Timer _ConvObjBkExecTimer = null;

        // バックアップ作成処理実行スレッド
        private Thread _threadBk = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConvObjBkExec()
        {
        }

        /// <summary>
        /// バックアップ処理開始
        /// 初回起動時にバックアップ実行
        /// 定時でバックアップ実行（設定ファイルに実行時間保持）
        /// </summary>
        public void ConvertObjBkStart()
        {
            int interval = 0;

            try
            {
                // USER_APフォルダ取得
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                // 実行ファイルパス設定
                string filePath = Path.Combine(fileDir, ct_FirstDeliveryFile);

                // 初回配信時のファイルがない場合バックアップ処理実行
                if (!File.Exists(filePath))
                {
                    // すでに実行中のプロセスが存在する場合は終了する
                    Process[] ps = Process.GetProcessesByName(ct_ConvObjBkProcName);
                    {
                        foreach (Process p in ps)
                        {
                            p.Kill();
                        }
                    }

                    // 起動時のバックアップ処理実行
                    // サービスに影響しないよう別スレッドで実行する
                    _threadBk = new Thread(new ThreadStart(ConvertObjBkExec));
                    _threadBk.Start();
                    _threadBk.IsBackground = true;
                }

                // バックアップ処理タイマー設定
                _ConvObjBkExecTimer = new System.Timers.Timer();
                _ConvObjBkExecTimer.Enabled = false;
                _ConvObjBkExecTimer.Elapsed += new System.Timers.ElapsedEventHandler(ConvObjBkTimer_Elapsed);
                
                // インターバル設定
                SetConvObjBkExecTimer(ref interval);
                _ConvObjBkExecTimer.Interval = interval;

                _ConvObjBkExecTimer.Enabled = true; // バックアップ実行タイマー起動

            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkStart", ex.Message, ex, -1);
            }
            finally
            {
            }

        }

        /// <summary>
        /// サービス終了時に後処理を行う
        /// </summary>
        public void ConvertObjBkStop()
        {
            try
            {
                if (_ConvObjBkExecTimer.Enabled)
                {
                    _ConvObjBkExecTimer.Enabled = false; // バックアップ実行タイマー停止
                }

                if (_threadBk != null)
                {
                    // スレッド終了
                    _threadBk.Abort();
                    _threadBk = null;
                }

                // すでに実行中のプロセスが残っている場合は終了する
                Process[] ps = Process.GetProcessesByName(ct_ConvObjBkProcName);
                {
                    foreach (Process p in ps)
                    {
                        p.Kill();
                    }
                }


            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkStop", ex.Message, ex, -1);
            }
        }

        /// <summary>
        /// バックアップ処理起動
        /// </summary>
        private void ConvertObjBkExec()
        {
            try
            {
                // USER_APフォルダ取得
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                // 実行ファイルパス設定
                string filePath = Path.Combine(fileDir, ct_ConvObjBkExec);

                Process ps = new Process();
                ps.StartInfo.FileName = filePath;
                ps.StartInfo.Arguments = ARGS_Service;
                ps.Start();
            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkExec", ex.Message, ex, -1);
            }
            finally
            {
            }
        }

        /// <summary>
        /// エラーLog生成
        /// </summary>
        /// <param name="pgId"></param>
        /// <param name="method"></param>
        /// <param name="Msg"></param>
        /// <param name="ex"></param>
        /// <param name="status"></param>
        private void WriteErrorLog(string pgId, string method, string Msg, Exception ex, int status)
        {
            try
            {
                string exceptionMsg = "無し";
                if (ex != null) exceptionMsg = ex.Message;
                string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}", method, Msg, exceptionMsg);
                LogTextOut logTextOut = new LogTextOut();
                logTextOut.Output(pgId, msg, status);
                // CLCログ出力部品呼出追加
                CLCLogTextOut clcLogTextOut = new CLCLogTextOut();
                clcLogTextOut.OutputClcLog(pgId, null, msg, status, ex);
            }
            catch
            {
                // ログ出力は例外発生時も続行
            }
            finally
            {
            }
        }

        /// <summary>
        /// バックアップ実行監視タイマー設定
        /// </summary>
        private int SetConvObjBkExecTimer(ref int interval)
        {
            // LSMサービス監視タイマー設定ファイル読込
            ConvObjBkExecInfo convObjBkExecInfo = new ConvObjBkExecInfo();
            int status = ReadBkSettingFile(ref convObjBkExecInfo);

            try
            {
                // 定期起動時刻
                TimeSpan ts = new TimeSpan(convObjBkExecInfo.BkStartTime_HH, convObjBkExecInfo.BkStartTime_mm, 0);
                int execTime = Convert.ToInt32(ts.TotalMilliseconds);

                // システム時間取得
                int systemTime = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalMilliseconds);

                if (execTime > systemTime)
                {
                    // 定時起動時刻 > システム時刻
                    // 定時起動時刻 - システム時刻をタイマーとする
                    interval = (execTime - systemTime);
                }
                else
                {
                    // 定時起動時刻 + 1日 - システム時刻をタイマーとする
                    interval = (execTime + INTERVAL_1DAY) - systemTime;
                }
            }
            catch(Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "SetConvObjBkExecTimer", ex.Message, ex, -1);
                // 例外発生時は1分後にリトライ
                interval = INTERVAL_1MINUTE;
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// バックアップ実行タイマー設定ファイル読込
        /// </summary>
        private int ReadBkSettingFile(ref ConvObjBkExecInfo convObjBkExecInfo)
        {
            int status = 0;

            FileStream fs = null;

            convObjBkExecInfo.BkStartTime_HH = ct_DefaultBkStarthh;
            convObjBkExecInfo.BkStartTime_mm = ct_DefaultBkStartmm;

            try
            {
                // 設定ファイル読み込み(ユーザーAPサービスと同一フォルダに存在)
                string fileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(fileDir, ct_BkSettingFile);

                convObjBkExecInfo = UserSettingController.DeserializeUserSetting<ConvObjBkExecInfo>(filePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                // ファイルが存在しない場合は初期値を設定する
                convObjBkExecInfo.BkStartTime_HH = ct_DefaultBkStarthh;
                convObjBkExecInfo.BkStartTime_mm = ct_DefaultBkStartmm;
            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvertObjBkStart", ex.Message, ex, -1);
                // 例外発生時は初期値を設定する
                convObjBkExecInfo.BkStartTime_HH = ct_DefaultBkStarthh;
                convObjBkExecInfo.BkStartTime_mm = ct_DefaultBkStartmm;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// バックアップ実行タイマー処理
        /// </summary>
        void ConvObjBkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                int interval = 0;
                long now = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                long day = long.Parse(DateTime.Now.ToString("yyyyMMdd"));       // 起動日付

                //----------------------------------------
                // バックアップ定期起動
                //----------------------------------------
                // 起動時のバックアップ処理実行
                // サービスに影響しないよう別スレッドで実行する
                _threadBk = new Thread(new ThreadStart(ConvertObjBkExec));
                _threadBk.Start();
                _threadBk.IsBackground = true;

                // インターバル設定
                SetConvObjBkExecTimer(ref interval);
                _ConvObjBkExecTimer.Interval = interval;
            }
            catch (Exception ex)
            {
                WriteErrorLog(typeof(ConvObjBkExec).Assembly.FullName, "ConvObjBkTimer_Elapsed", ex.Message, ex, -1);
            }
        }

    }

    /// <summary>
    /// バックアップ起動監視設定ファイル情報
    /// </summary>
    public class ConvObjBkExecInfo
    {
        /// <summary>定期起動時刻(時)</summary>
        private int _bkStartTime_HH;
        /// <summary>定期起動時刻(分)</summary>
        private int _bkStartTime_mm;

        /// <summary>
        /// 定期起動時刻
        /// </summary>
        public int BkStartTime_HH
        {
            get
            {
                return _bkStartTime_HH;
            }
            set
            {
                _bkStartTime_HH = value;
            }
        }
        /// <summary>
        /// 定期起動時刻
        /// </summary>
        public int BkStartTime_mm
        {
            get
            {
                return _bkStartTime_mm;
            }
            set
            {
                _bkStartTime_mm = value;
            }
        }

    }
}

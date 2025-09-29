using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Threading;
using System.IO;
using System.Web;
using System.Net;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部品MAX連携部品
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NSシステムから部品MAXにアクセスするための手段を提供する。</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2016/01/25</br>
    /// <br></br>
    /// </remarks>
    public class BuhinMaxExhibitStockProvider
    {
        # region Private Members
        private readonly object _lockObject = new object();
        private BuhinMaxRequest _buhinMaxRequest;
        private Thread _maxThread;

        private string _loginID;            // 認証ID
        private string _password;           // 認証パスワード
        private string _csvFileFullName;    // 保存したCSVファイル名
        private string _errFileName;        // エラー内容を保存したCSVファイル名
        private string _wkFileName;         // 分割した内容を保存したCSVファイル名

        private volatile string _errorMessage;       // エラーメッセージ
        private volatile int _registStatus;          // アップロード処理のステータス

        private volatile int _maxProcStatus;                        // アップロード処理のステータス
        private volatile Dictionary<DateTime, string> _messagelist; // 通知メッセージリスト
        private volatile int _timeLeftSeconds;                      // 残り時間
        private volatile string _errorListCsvFileFullName;          // エラーリストCSVファイル名

        /// <summary>
        /// 認証ID
        /// </summary>
        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }
        /// <summary>
        /// 認証パスワード
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// 保存したCSVファイル名
        /// </summary>
        public string CsvFileFullName
        {
            get { return _csvFileFullName; }
            set { _csvFileFullName = value; }
        }
        /// <summary>
        /// エラー内容を保存したCSVファイル名
        /// </summary>
        public string ErrFileName
        {
            get { return _errFileName; }
            set { _errFileName = value; }
        }
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        /// <summary>
        /// 登録機能ステータス
        /// </summary>
        public int RegistStatus
        {
            get { return _registStatus; }
            set { _registStatus = value; }
        }
        /// <summary>
        /// 分割した内容を保存したCSVファイル名
        /// </summary>
        public string WkFileName
        {
            get { return _wkFileName; }
            set { _wkFileName = value; }
        }
        /// <summary>
        /// アップロード処理のステータス
        /// </summary>
        public int MaxProcStatus
        {
            get { return _maxProcStatus; }
            set { _maxProcStatus = value; }
        }
        /// <summary>
        /// 通知メッセージリスト
        /// </summary>
        public Dictionary<DateTime, string> Messagelist
        {
            get { return _messagelist; }
            set { _messagelist = value; }
        }
        /// <summary>
        /// 残り時間
        /// </summary>
        public int TimeLeftSeconds
        {
            get { return _timeLeftSeconds; }
            set { _timeLeftSeconds = value; }
        }
        /// <summary>
        /// エラーリストCSVファイル名
        /// </summary>
        public string ErrorListCsvFileFullName
        {
            get { return _errorListCsvFileFullName; }
            set { _errorListCsvFileFullName = value; }
        }

        # endregion Private Members

        #region 出品・在庫一括登録機能
        /// <summary>
        /// 出品・在庫一括登録機能
        /// </summary>
        /// <param name="loginID">入荷予約対象となる店舗にログインするための認証ID</param>
        /// <param name="password">入荷予約対象となる店舗にログインするための認証パスワード</param>
        /// <param name="csvFileFullName">登録する入荷予約情報を保存したCSVファイル名</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns></returns>
        public int Regist(string loginID, string password, string csvFileFullName, ref string errorMessage)
        {
            int status = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;

            try
            {
                #region パラメータチェック
                // 認証ID
                if (string.IsNullOrEmpty(loginID))
                {
                    // null or 空文字
                    throw new NullReferenceException();
                }
                // 認証パスワード
                if (string.IsNullOrEmpty(password))
                {
                    // null or 空文字
                    throw new NullReferenceException();
                }
                // CSVファイル名
                if (string.IsNullOrEmpty(csvFileFullName))
                {
                    // null or 空文字
                    throw new NullReferenceException();
                }
                // CSVファイル存在
                if (!(File.Exists(csvFileFullName)))
                {
                    // ファイルが存在しない
                    throw new FileNotFoundException();
                }
                #endregion パラメータチェック

                // エラーファイル名作成
                string fileExtension = Path.GetExtension(csvFileFullName);
                string errFileName = "_" + DateTime.Now.ToString("yyyy.MM.dd_HHmmss") + fileExtension;
                // 分割ファイル名作成
                //string wkFileName = "_E" + fileExtension;
                string wkFileName = Environment.TickCount.ToString() +"_E" + fileExtension;

                // 変数設定
                this.LoginID = loginID;
                this.Password = password;
                this.CsvFileFullName = csvFileFullName;
                this.ErrFileName = csvFileFullName.Replace(fileExtension, errFileName);
                //this.WkFileName = csvFileFullName.Replace(fileExtension, wkFileName);
                this.WkFileName = Path.GetDirectoryName(csvFileFullName) + "\\" + wkFileName;

                // 部品MAX登録処理
                this._maxThread = new Thread(this.BuhinMaxThread);
                if (!this._maxThread.IsAlive)
                {
                    this._maxThread.IsBackground = true;
                    this._maxThread.Start();
                    lock (_lockObject)
                    {
                        // ロックが開放されるまで待つ
                        Monitor.Wait(_lockObject);
                    }
                }

                errorMessage = this.ErrorMessage;
                status = this.RegistStatus;
            }
            catch (NullReferenceException)
            {
                errorMessage = "パラメータに誤りがあります。";
            }
            catch (FileNotFoundException)
            {
                errorMessage = "ファイルが存在しません。";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return status;
        }
        #endregion 出品・在庫一括登録機能

        #region 登録状態取得機能
        /// <summary>
        /// 登録状態取得機能
        /// </summary>
        /// <param name="readMessageDateTime">メッセージ読込対象とする更新日付情報</param>
        /// <param name="errorListCsvFileFullName">部分的に登録できなかったエラーリストCSVファイル名</param>
        /// <param name="timeLeftSeconds">残り時間</param>
        /// <param name="messagelist">通知メッセージリスト</param>
        /// <returns></returns>
        public int GetRegistStatus(DateTime readMessageDateTime, ref string errorListCsvFileFullName, ref int timeLeftSeconds, ref List<string> messagelist)
        {
            int status = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;
            try
            {
                // エラーリストCSVファイル名
                errorListCsvFileFullName = this.ErrorListCsvFileFullName;

                // 残り時間
                TimeSpan ts = new TimeSpan(0, 0, this.TimeLeftSeconds);
                timeLeftSeconds = ts.Minutes;

                // 通知メッセージリスト
                Dictionary<DateTime, string> messagelist_wk = new Dictionary<DateTime, string>();
                foreach (DateTime key in this.Messagelist.Keys)
                {
                    messagelist_wk.Add(key, this.Messagelist[key]);
                }

                foreach (DateTime messageDateTime in messagelist_wk.Keys)
                {
                    if (messagelist == null)
                        messagelist = new List<string>();

                    if (readMessageDateTime < messageDateTime)
                    {
                        // 更新日付情報より新しい場合
                        //string message = messageDateTime.ToString("HH:mm") + " " + this.Messagelist[messageDateTime];
                        string message = this.Messagelist[messageDateTime];
                        messagelist.Add(message);
                    }
                }

                // ステータス
                status = this.MaxProcStatus;
            }
            catch (Exception ex)
            {
                messagelist.Add(ex.Message);
            }
            return status;
        }
        #endregion 登録状態取得機能

        #region 分割ファイル送信スレッド
        /// <summary>
        /// 分割ファイル送信スレッド
        /// </summary>
        public void BuhinMaxThread()
        {
            int status = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;
            string message = string.Empty;

            try
            {
                // 状態監視用ステータス
                this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_SYS_ERROR;

                string textString = string.Empty;
                int allLineCount = -1;      // 総レコード数
                int procCount = 0;          // 処理済レコード数
                bool somefail_Flg = false;  // 一部失敗フラグ
                string urlLogin = string.Empty;
                string urlPost = string.Empty;
                string fileHeader = string.Empty;

                // ファイルオープン
                using (StreamReader sr = new StreamReader(this.CsvFileFullName, Encoding.GetEncoding("Shift_JIS")))
                {
                    // 総レコード件数取得
                    while (sr.Peek() >= 0)
                    {
                        sr.ReadLine();
                        allLineCount += 1;
                    }
                }

                if (allLineCount <= 0)
                {
                    // ファイルの中身がない
                    throw new NullReferenceException();
                }

                // 部品MAX連携オブジェクト生成
                _buhinMaxRequest = new BuhinMaxRequest();

                #region DEL
                //// XMLファイルよりURLを取得する
                //BuhinMaxUrlInfo buhinMaxUrlInfo;
                //status = _buhinMaxRequest.DecryptFile(out buhinMaxUrlInfo, out message);
                //if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                //{
                //    // 1回目のリクエスト／レスポンス用
                //    this.RegistStatus = status;
                //    this.ErrorMessage = message;

                //    lock (_lockObject)
                //    {
                //        // ロックを開放する
                //        Monitor.PulseAll(_lockObject);
                //    }

                //    // 状態監視用ステータス
                //    this.MaxProcStatus = status;

                //    return;
                //}
                #endregion DEL

                this._messagelist = new Dictionary<DateTime, string>();
                // <<----- 通知メッセージ作成 ----->>
                this.SetMessagelist("部品MAXへログインします。");

                //認証用クッキーを格納するコンテナを生成
                CookieContainer cc = new CookieContainer();

                status = _buhinMaxRequest.CreateLogInUrl(out urlLogin, out message);
                if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                {
                    // 1回目のリクエスト／レスポンス用
                    this.RegistStatus = status;
                    this.ErrorMessage = message;

                    lock (_lockObject)
                    {
                        // ロックを開放する
                        Monitor.PulseAll(_lockObject);
                    }

                    // 状態監視用ステータス
                    this.MaxProcStatus = status;

                    return;
                }

                // 部品MAXログイン処理
                status = _buhinMaxRequest.LoginBuhinMax(this.LoginID, this.Password, urlLogin, ref cc, out message);
                if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                {
                    // ----------
                    // ログイン失敗

                    // 1回目のリクエスト／レスポンス用
                    this.RegistStatus = status;
                    this.ErrorMessage = message;

                    lock (_lockObject)
                    {
                        // ロックを開放する
                        Monitor.PulseAll(_lockObject);
                    }

                    // 状態監視用ステータス
                    this.MaxProcStatus = status;

                    return;
                }

                // <<----- 通知メッセージ作成 ----->>
                this.SetMessagelist("部品MAXへアップロードを実行します。");

                status = _buhinMaxRequest.CreateDeriveryUrl(out urlPost, out message);
                if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                {
                    // 1回目のリクエスト／レスポンス用
                    this.RegistStatus = status;
                    this.ErrorMessage = message;

                    lock (_lockObject)
                    {
                        // ロックを開放する
                        Monitor.PulseAll(_lockObject);
                    }

                    // 状態監視用ステータス
                    this.MaxProcStatus = status;

                    return;
                }

                DateTime timeStart = DateTime.Now;  // 処理開始時間
                TimeSpan timeProcess;               // 処理時間

                bool fastFlg = true;

                // ファイルオープン
                using (StreamReader sr = new StreamReader(this.CsvFileFullName, Encoding.GetEncoding("Shift_JIS")))
                {
                    int counter = 0;
                    while (true)
                    {
                        if (fastFlg)
                        {
                            // ヘッダー行を飛ばす
                            fileHeader = sr.ReadLine();
                            fastFlg = false;
                            continue;
                        }
                        textString = sr.ReadLine();

                        // 送信用ファイル作成
                        using (StreamWriter sw = new StreamWriter(this.WkFileName, true, Encoding.GetEncoding("Shift_JIS")))
                        {
                            if (counter == 0)
                            {
                                // ヘッダー行出力
                                sw.WriteLine(fileHeader);
                            }
                            sw.WriteLine(textString);
                        }
                        counter++;

                        if (counter == 10 || sr.EndOfStream == true)
                        {
                            // 分割ファイルを送信
                            status = _buhinMaxRequest.PostBuhinMax(urlPost, this.WkFileName, ref cc, out message);

                            if (status != (int)BuhinMaxRequest.MAX_Status.ct_NORMAL)
                            {
                                // ----------
                                // 送信失敗
                                // ----------

                                // 1回目のリクエスト／レスポンス用
                                this.RegistStatus = status;
                                this.ErrorMessage = message;

                                // <<----- 通知メッセージ作成 ----->>
                                this.SetMessagelist(message);

                                // 送信用ファイル削除
                                if (File.Exists(this.WkFileName))
                                {
                                    File.Delete(this.WkFileName);
                                }

                                lock (_lockObject)
                                {
                                    // ロックを開放する
                                    Monitor.PulseAll(_lockObject);
                                }
                                // 状態監視用ステータス
                                this.MaxProcStatus = status;

                                return;
                            }

                            if (message != string.Empty)
                            {
                                // <<----- 通知メッセージ作成 ----->>
                                this.SetMessagelist(message);

                                // 一部エラーがある場合
                                if (!(File.Exists(this.ErrFileName)))
                                {
                                    // ヘッダー行出力
                                    using (StreamWriter sw = new StreamWriter(this.ErrFileName, true, Encoding.GetEncoding("Shift_JIS")))
                                    {
                                        sw.WriteLine(fileHeader);
                                    }
                                }

                                using (StreamReader sr_err = new StreamReader(this.WkFileName, Encoding.GetEncoding("Shift_JIS")))
                                {
                                    string textStringErr;
                                    fastFlg = true;
                                    while ((textStringErr = sr_err.ReadLine()) != null)
                                    {
                                        if (fastFlg)
                                        {
                                            // ヘッダー行を飛ばす
                                            fastFlg = false;
                                            continue;
                                        }
                                        using (StreamWriter sw = new StreamWriter(this.ErrFileName, true, Encoding.GetEncoding("Shift_JIS")))
                                        {
                                            sw.WriteLine(textStringErr);
                                        }
                                    }
                                }
                                this.ErrorListCsvFileFullName = this.ErrFileName;
                                somefail_Flg = true;
                            }

                            // 処理時間
                            timeProcess = DateTime.Now - timeStart;

                            // 処理済件数
                            procCount += counter;

                            // 1回目のリクエスト／レスポンス用
                            this.RegistStatus = status;
                            this.ErrorMessage = message;

                            // 送信用ファイル削除
                            if (File.Exists(this.WkFileName))
                            {
                                File.Delete(this.WkFileName);
                            }

                            lock (_lockObject)
                            {
                                // ロックを開放する
                                Monitor.PulseAll(_lockObject);
                            }

                            if (sr.EndOfStream == true)
                            {
                                // 残り時間 = 0
                                this._timeLeftSeconds = 0;
                                break;
                            }
                            else
                            {
                                // 残り時間 = ( 処理時間 / 処理回数 ) X ( 総レコード件数 - 処理済件数 )
                                this._timeLeftSeconds = (int)(timeProcess.TotalSeconds / counter) * (allLineCount - procCount);
                                timeStart = DateTime.Now;  // 処理開始時間
                                this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_RUN;    // 実行中
                            }
                            // カウンタクリア
                            counter = 0;
                        }
                    }

                    if (somefail_Flg)
                    {
                        // 状態監視用ステータス
                        this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_SOME_FAIL;  // 一部失敗
                    }
                    else
                    {
                        // 状態監視用ステータス
                        this.MaxProcStatus = (int)BuhinMaxRequest.MAX_Status.ct_NORMAL;     // 正常
                    }

                    // <<----- 通知メッセージ作成 ----->>
                    this.SetMessagelist("部品MAXへアップロードが完了しました。");
                }
            }
            catch (NullReferenceException)
            {
                message = "部品MAXへアップロードする情報がありません。";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // <<----- 通知メッセージ作成 ----->>
                this.SetMessagelist(ex.Message);
            }
            finally
            {
                // 1回目のリクエスト／レスポンス用
                this.RegistStatus = status;
                this.ErrorMessage = message;

                // 送信用ファイル削除
                if (File.Exists(this.WkFileName))
                {
                    File.Delete(this.WkFileName);
                }

                lock (_lockObject)
                {
                    // ロックを開放する
                    Monitor.PulseAll(_lockObject);
                }
            }
        }
        #endregion 分割ファイル送信スレッド

        #region 実行状況ログ作成
        /// <summary>
        /// 実行状況ログ作成
        /// </summary>
        /// <param name="message">メッセージ</param>
        private void SetMessagelist(string message)
        {
            try
            {
                if (this._messagelist == null)
                    this._messagelist = new Dictionary<DateTime, string>();

                this._messagelist.Add(DateTime.Now, message);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
        #endregion 実行状況ログ作成
    }
}

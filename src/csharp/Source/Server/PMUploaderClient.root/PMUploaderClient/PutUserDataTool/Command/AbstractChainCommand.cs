using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;

namespace PutUserDataTool
{
    public abstract class AbstractChainCommand : ICommand
    {
        public const string SEND_RESULT_URL = "{0}/pmuploader/pm/taskresult";


        public const int DATA_SPLIT_SIZE = 1000;

        private Task _task;

        private AbstractChainCommand _chain;

        public AbstractChainCommand Chain
        {
            get { return this._chain; }
            set { this._chain = value; }
        }

        protected Task SelfTask
        {
            get { return this._task; }
        }

        public AbstractChainCommand(Task task)
        {
            this._task = task;
        }

        public void Execute()
        {
            DateTime now = DateTime.Now;
            DateTime startTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            startTime = startTime.Add(this.ToTimeSpan(this.SelfTask.StartTime));
            DateTime endTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
            endTime = endTime.Add(this.ToTimeSpan(this.SelfTask.EndTime));

            if (now < startTime || now > endTime)
            {
                Logger.GetInstance().Log(string.Format("実行時間外のため処理をスキップします。[{0:yyyy.MM.dd HH:mm:ss}-{1:yyyy.MM.dd HH:mm:ss}", startTime, endTime), true);
            }
            else
            {
                Logger.GetInstance().Log(SelfTask.Name, true);
                this.ExecuteMain();
            }
            if (_chain != null)
            {
                this._chain.Execute();
            }
        }

        protected abstract void ExecuteMain();

        /// <summary>
        /// 取得結果送信
        /// </summary>
        /// <returns>ステータス</returns>
        /// <param name="lstResult">取得結果</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Programmer : YuyaNoguchi</br>
        /// <br>Date       : 2015/03/19</br>
        /// </remarks>
        protected void SendTaskResult(Result result)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            StreamWriter writer = null;
            Stream outStream = null;
            for (int i = 0; i <= ToolApplication.SERVER_RETRY_COUNT; i++)
            {
                try
                {
                    #region リクエスト生成
                    req = System.Net.WebRequest.Create(string.Format(SEND_RESULT_URL, ToolApplication.GetInstance().BaseUrl)) as HttpWebRequest;
                    //メソッドにPOSTを指定
                    req.Method = "POST";
                    //通信試行回数:3回(10秒間隔)
                    req.Timeout = 30000;
                    //ヘッダ追加
                    req.Headers.Add("X-BLNS-CODE", ToolApplication.GetInstance().EnterpriseCode);
                    req.Headers.Add("X-BLNS-AUTH", ToolApplication.GetInstance().AuthCode);
                    req.Headers.Add("X-BLNS-PMDBID", ToolApplication.GetInstance().PmDbId);
                    #endregion

                    req.Headers.Add("X-BLNS-UP-TASKNO", result.TaskNo);
                    req.Headers.Add("X-BLNS-UP-TASK-SEPARATE-NO", result.SeparateNo);
                    req.Headers.Add("X-BLNS-UP-TASK-START-DATE", result.StartDate);

                    #region 送信
                    outStream = req.GetRequestStream();
                    writer = new StreamWriter(outStream, Encoding.UTF8);
                    writer.WriteLine(result.DataText);
                    writer.Flush();
                    writer.Close();
                    #endregion

                    res = req.GetResponse() as HttpWebResponse;
                    if (res != null && res.StatusCode == HttpStatusCode.OK)
                    {
                        Logger.GetInstance().Log(".", false);
                        return;
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                    string status = "unkown";
                    if (errorResponse != null)
                    {
                        status = errorResponse.StatusCode.ToString();
                    }
                    Logger.GetInstance().Log(string.Format("送信時にエラーが発生しました。(STATUS={0}、{1}回目)", status, (i + 1)), ex, true);
                    if (i == ToolApplication.SERVER_RETRY_COUNT)
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Logger.GetInstance().Log(string.Format("送信時にエラーが発生しました。({0}回目)", (i + 1)), ex, true);
                    if (i == ToolApplication.SERVER_RETRY_COUNT)
                    {
                        throw;
                    }
                }
                finally
                {
                    if (outStream != null) outStream.Close();
                    if (writer != null) writer.Close();
                    if (res != null) res.Close();
                }
                RandomSleep();
            }
        }

        /// <summary>
        /// 取得結果送信
        /// </summary>
        /// <returns>ステータス</returns>
        /// <param name="lstResult">取得結果</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Programmer : YuyaNoguchi</br>
        /// <br>Date       : 2015/03/19</br>
        /// </remarks>
        protected void SendTaskResult(FileResult result)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            Stream outStream = null;
            FileStream inStream = null;
            for (int i = 0; i <= ToolApplication.SERVER_RETRY_COUNT; i++)
            {
                try
                {
                    #region リクエスト生成
                    req = System.Net.WebRequest.Create(string.Format(SEND_RESULT_URL, ToolApplication.GetInstance().BaseUrl)) as HttpWebRequest;
                    //メソッドにPOSTを指定
                    req.Method = "POST";
                    //通信試行回数:3回(10秒間隔)
                    req.Timeout = 30000;
                    //ヘッダ追加
                    req.Headers.Add("X-BLNS-CODE", ToolApplication.GetInstance().EnterpriseCode);
                    req.Headers.Add("X-BLNS-AUTH", ToolApplication.GetInstance().AuthCode);
                    req.Headers.Add("X-BLNS-PMDBID", ToolApplication.GetInstance().PmDbId);
                    #endregion

                    req.Headers.Add("X-BLNS-UP-TASKNO", result.TaskNo);
                    req.Headers.Add("X-BLNS-UP-TASK-SEPARATE-NO", result.SeparateNo);
                    req.Headers.Add("X-BLNS-UP-TASK-START-DATE", result.StartDate);
                    req.Headers.Add("X-BLNS-UP-TASK-ZIP-NAME", result.File.Name);

                    #region 送信
                    outStream = req.GetRequestStream();
                    inStream = new FileStream(result.File.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    byte[] bytes = new byte[1024];
                    int len = -1;
                    while ((len = inStream.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        outStream.Write(bytes, 0, len);
                    }
                    outStream.Flush();
                    outStream.Close();
                    #endregion

                    res = req.GetResponse() as HttpWebResponse;
                    if (res != null && res.StatusCode == HttpStatusCode.OK)
                    {
                        Logger.GetInstance().Log(".", false);
                        return;
                    }
                }
                catch (WebException ex)
                {
                    HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                    string status = "unkown";
                    if (errorResponse != null)
                    {
                        status = errorResponse.StatusCode.ToString();
                    }
                    Logger.GetInstance().Log(string.Format("送信時にエラーが発生しました。(STATUS={0}、{1}回目)", status, (i + 1)), ex, true);
                    if (i == ToolApplication.SERVER_RETRY_COUNT | status == HttpStatusCode.ServiceUnavailable.ToString())
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Logger.GetInstance().Log(string.Format("送信時にエラーが発生しました。({0}回目)", (i + 1)), ex, true);
                    if (i == ToolApplication.SERVER_RETRY_COUNT)
                    {
                        throw;
                    }
                }
                finally
                {
                    if (outStream != null) outStream.Close();
                    if (res != null) res.Close();
                }
                RandomSleep();
            }
        }

        protected void RandomSleep()
        {
            Random r = new Random(ToolApplication.GetInstance().EnterpriseCode.GetHashCode());
            Thread.Sleep(r.Next(5) * 1000 + 2000);
        }

        protected TimeSpan ToTimeSpan(String hhmmss)
        {
            if (string.IsNullOrEmpty(hhmmss))
            {
                return new TimeSpan(0, 0, 0);
            }
            try
            {
                return new TimeSpan(
                        Int32.Parse(hhmmss.Substring(0, 2)),
                        Int32.Parse(hhmmss.Substring(2, 2)),
                        Int32.Parse(hhmmss.Substring(4, 2))
                    );
            }
            catch
            {
                return new TimeSpan(0, 0, 0);
            }
        }
    }
}

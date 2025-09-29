using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

namespace PutUserDataTool
{
    public class TaskManager
    {

        public const string GET_TASK_URL = "{0}/pmuploader/pm/taskinfo";

        /// <summary>
        /// PSNAP���^�X�N�����擾
        /// </summary>
        /// <returns>sqlCommand</returns>
        /// <remarks>
        /// <br>Programmer : Hirose</br>
        /// <br>Date       : 2015/03/19</br>
        /// </remarks>
        public List<Task> GetTask()
        {
            List<Task> answer = new List<Task>();

            string[] lineTokens = null;
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            Stream s = null;
            StreamReader sr = null;

            for (int i = 0; i <= ToolApplication.SERVER_RETRY_COUNT; i++)
            {
                try
                {
                    req = WebRequest.Create(string.Format(GET_TASK_URL, ToolApplication.GetInstance().BaseUrl)) as HttpWebRequest;
                    req.Method = "GET";
                    req.Headers.Add("X-BLNS-CODE", ToolApplication.GetInstance().EnterpriseCode);
                    req.Headers.Add("X-BLNS-AUTH", ToolApplication.GetInstance().AuthCode);
                    req.Headers.Add("X-BLNS-PMDBID", ToolApplication.GetInstance().PmDbId);

                    res = (HttpWebResponse)req.GetResponse();

                    s = res.GetResponseStream();
                    sr = new StreamReader(s);
                    char[] separators = new char[] { '=' };
                    while (sr.Peek() >= 0)
                    {
                        lineTokens = sr.ReadLine().Split('\t');
                        Task task = new Task();
                        foreach (string token in lineTokens)
                        {
                            if (token.StartsWith("no="))
                            {
                                task.No = token.Split(separators, 2)[1];
                            }
                            else if (token.StartsWith("name="))
                            {
                                task.Name = token.Split(separators, 2)[1];
                            }
                            else if (token.StartsWith("taskType="))
                            {
                                task.TaskType = token.Split(separators, 2)[1];
                            }
                            else if (token.StartsWith("command="))
                            {
                                task.Command = token.Split(separators, 2)[1];
                            }
                            else if (token.StartsWith("startTime="))
                            {
                                task.StartTime = token.Split(separators, 2)[1];
                            }
                            else if (token.StartsWith("endTime="))
                            {
                                task.EndTime = token.Split(separators, 2)[1];
                            }
                        }
                        if (!string.IsNullOrEmpty(task.TaskType))
                        {
                            answer.Add(task);
                        }
                    }
                    answer.Sort(delegate(Task a, Task b)
                    {
                        Int32 a1, b1;
                        Int32.TryParse(a.No, out a1);
                        Int32.TryParse(b.No, out b1);
                        return a1.CompareTo(b1);
                    });
                    break;
                }
                catch (WebException ex)
                {
                    HttpWebResponse errorResponse =  ex.Response as HttpWebResponse;
                    string status = "unkown";
                    if (errorResponse != null)
                    {
                        status = errorResponse.StatusCode.ToString();
                    }
                    Logger.GetInstance().Log(string.Format("�^�X�N���擾���ɃG���[���������Ă��܂��B(STATUS={0}�A{1}���)",status, (i + 1)), ex, true);
                    if (i == ToolApplication.SERVER_RETRY_COUNT | status == HttpStatusCode.ServiceUnavailable.ToString())
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Logger.GetInstance().Log(string.Format("�^�X�N���擾���ɃG���[���������Ă��܂��B({0}���)", (i + 1)), ex, true);
                    if (i == ToolApplication.SERVER_RETRY_COUNT)
                    {
                        throw;
                    }
                }
                finally
                {
                    if (res != null) res.Close();
                    if (s != null) s.Close();
                    if (sr != null) sr.Close();
                    if (res != null) res.Close();
                }
                RandomSleep();
            }
            return answer;
        }

        protected void RandomSleep()
        {
            Random r = new Random(ToolApplication.GetInstance().EnterpriseCode.GetHashCode());
            Thread.Sleep(r.Next(5) * 1000 + 2000);
        }
    }
}

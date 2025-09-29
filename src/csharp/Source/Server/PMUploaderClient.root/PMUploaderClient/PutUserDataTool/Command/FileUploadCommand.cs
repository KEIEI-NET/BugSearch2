using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PutUserDataTool
{
    public class FileUploadCommand : AbstractChainCommand
    {
        public FileUploadCommand(Task task)
            : base(task)
        {
        }

        protected override void ExecuteMain()
        {
            string[] tokens = this.SelfTask.Command.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string dir = string.Empty;
            DateTime checkStartDateTime;
            DateTime checkEndDateTime;
            if (tokens.Length <= 0)
            {
                dir = this.SelfTask.Command;//
            }
            else
            {
                dir = tokens[0];
            }
            checkStartDateTime = (tokens.Length > 1) ? DateTime.ParseExact(tokens[1], "yyyyMMddHHmmss", null) : DateTime.Now.AddDays(-7);
            checkEndDateTime = (tokens.Length > 2) ? DateTime.ParseExact(tokens[2], "yyyyMMddHHmmss", null) : DateTime.MaxValue;
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(ToolApplication.GetInstance().HomeDir, dir));

            if (dirInfo.Exists)
            {
                int separateNo = 1;
                FileResult fileResult = new FileResult();
                fileResult.StartDate = DateTime.Now.ToString("yyyyMMdd", null);
                fileResult.Name = SelfTask.Name;
                fileResult.TaskNo = SelfTask.No;
                this.ExecuteMainProc(dirInfo, checkStartDateTime, checkEndDateTime, ref separateNo, ref fileResult);
            }

            #region 終了通知
            Result result = new Result();
            result.StartDate = DateTime.Now.ToString("yyyyMMdd", null);
            result.Name = SelfTask.Name;
            result.TaskNo = SelfTask.No;
            result.DataText = string.Empty;
            result.SeparateNo = Result.SEPARATE_NO_END;
            //ファイル送信
            SendTaskResult(result);
            #endregion
        }

        protected void ExecuteMainProc(DirectoryInfo dirInfo, DateTime checkStartDateTime, DateTime checkEndTime, ref int separateNo, ref FileResult result)
        {
            try
            {
                foreach (FileInfo f in dirInfo.GetFiles())
                {
                    if (f.LastWriteTime < checkStartDateTime)
                    {
                        //古いのは無視
                        continue;
                    }
                    else if (f.LastWriteTime > checkEndTime)
                    {
                        //新しすぎるのも無視
                        continue;
                    }
                    result.File = f;
                    result.SeparateNo = separateNo + "";
                    separateNo++;
                    SendTaskResult(result);
                }
                /*
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    this.ExecuteMainProc(subDir, checkStartDateTime, checkEndTime, ref separateNo, ref result);
                }
                */
            }
            catch (Exception ex)
            {
                try
                {
                    Result dResult = new Result();
                    dResult.StartDate = DateTime.Now.ToString("yyyyMMdd", null);
                    dResult.Name = SelfTask.Name;
                    dResult.TaskNo = SelfTask.No;
                    dResult.SeparateNo = separateNo + "";
                    dResult.DataText = "ERROR\t" + ex.Message + "\r\n" + ex.StackTrace;
                    separateNo++;
                    //ファイル送信
                    SendTaskResult(dResult);
                }
                catch (Exception)
                {
                    //ignore error.
                }
                Logger.GetInstance().Log("ファイル読み込みにエラーが発生しています。", ex, true);
                throw;
            }
            finally
            {
            }
        }
    }
}

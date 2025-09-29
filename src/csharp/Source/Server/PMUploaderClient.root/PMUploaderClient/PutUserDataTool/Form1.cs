using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PutUserDataTool
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Logger.GetInstance().AddWriteLog(new Logger.WriteLog(this.WriteLog));
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.btnExecute.Enabled = false;
            // 時間のかかる処理を別スレッドで開始
            bgWorker.RunWorkerAsync();
            // DoWorkイベント発生
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                bgWorker.ReportProgress(1);
                Logger.GetInstance().Log("サーバーとの通信確認を行います。", true);
                if (ToolApplication.GetInstance().ServerConnectCheck())
                {
                    Logger.GetInstance().Log("サーバーとの通信状況は問題ありません。", true);
                }
                else
                {
                    Logger.GetInstance().Log("サーバーとの通信が正常に行えません。", true);
                    e.Result = "失　敗";
                    return;
                }

                Logger.GetInstance().Log("実行情報を取得します。", true);
                TaskManager taskManager = new TaskManager();
                List<Task> taskList = taskManager.GetTask();
                Logger.GetInstance().Log(string.Format("実行情報を取得しました。[残実行数={0}]", taskList.Count), true);
                bgWorker.ReportProgress(5);
                if (taskList.Count > 0)
                {
                    ICommand cmd = CommandFactory.GetInstance().GetCommand(taskList);
                    cmd.Execute();
                    Logger.GetInstance().Log("全ての処理が完了しました。", true);
                }
                else
                {
                    Logger.GetInstance().Log("全ての処理が既に完了しています。", true);
                }
                e.Result = "成　功";
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log("実行処理中にエラーが発生しました。", ex, true);
                e.Result = "失　敗";
            }
        }

        public void WriteLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new SetStatusDelegate(SetStatus), new object[] { message });
            }
            else
            {
                SetStatus(message);
            }

        }

        delegate void SetStatusDelegate(string message);

        void SetStatus(string message)
        {
            string buffer = textBox1.Text;
            if (buffer.Length > 20000)
            {
                buffer = buffer.Remove(0, 10000);
            }
            buffer += message;
            if (buffer.StartsWith(Environment.NewLine))
            {
                buffer = buffer.Substring(Environment.NewLine.Length);
            }
            textBox1.Text = buffer;
            textBox1.SelectionStart = buffer.Length;
            textBox1.ScrollToCaret();
            this.Refresh();
        }

        private void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage < 100)
            {
                this.lblResultSts.Text = "実行中";
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.lblResultSts.Text = e.Result as string;
            this.btnExecute.Enabled = true;
        }
    }
}
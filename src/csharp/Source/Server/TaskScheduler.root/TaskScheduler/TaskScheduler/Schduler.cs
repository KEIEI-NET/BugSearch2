using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Broadleaf.ServiceProcess;
using Broadleaf.Application.UIData;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Library.Diagnostics;
using System.Runtime.Remoting;

namespace TaskScheduler
{
    public partial class Form1 : Form
    {
        #region [ Private Member ]
        private System.Timers.Timer timer = null;
        //private const string ct_cfgFile = "PriceUpdCfg.xml";
        private const string ct_cfgFile = "PMCMN06200S.XML";
        private conf _dtHist;
        private List<CheckCondWork> lstChk = new List<CheckCondWork>();
        private string workDir; // 実行ファイルのあるディレクトリ
        private readonly string[] lstCaption = new string[5] { "ﾁｪｯｸ開始時刻\r  [HHMM]", "ﾁｪｯｸ終了時刻\r  [HHMM]", "実行Pg名", "起動ﾊﾟﾗﾒｰﾀ", "ﾁｪｯｸ間隔\r(時間）" };
        #endregion

        public Form1()
        {
            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Enabled = false;
            timer.Interval = 60000; // 1分間隔
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // あってはいけないケース
            {
                //WriteErrorLog(this.ServiceName, "Constructor", "レジストリ情報なし", null, -1);
                workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                //workDir = @"C:\Program Files\Sucheduler\TaskScheduler\bin\Debug";
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                //workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Sucheduler\TaskScheduler\bin\Debug").ToString();
            }

            string[] args = null;
            OnStart(args);
        }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void SchedulerService()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new ServiceBase() };

            //string msg = "";
            //string[] _parameter = new string[0];
            //int status = ServerApplicationMethodCallControl.StartApplication(
            //            out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode);
            ServiceBase.Run(ServicesToRun);
        }

        // 一定時間経過
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int chkTime = dt.Hour * 100 + dt.Minute;

            for (int i = 0; i < lstChk.Count; i++)
            {
                if (lstChk[i].ChkStTime1 <= chkTime && lstChk[i].ChkEdTime1 >= chkTime
                    && lstChk[i].ChkStTime2 <= chkTime && lstChk[i].ChkEdTime2 >= chkTime) // チェック時間帯か
                {
                    lstChk[i].HourCnt++;
                    //if (lstChk[i].HourCnt == 60
                    ) // １時間経過
                    foreach (CheckCondWork chkWork in lstChk)
                    {
                        // 価格改正用
                        if (chkWork.PgId == workDir + "\\PMKHN09210U.exe")
                        {
                            if (lstChk[i].HourCnt == 2) // １時間経過
                            {
                                lstChk[i].HourCnt = 0;

                                lstChk[i].RemainedTm--; // 残り時間を1時間減らす。
                                if (lstChk[i].RemainedTm == 0) // チェック間隔に達した？
                                {
                                    lstChk[i].RemainedTm = lstChk[i].ChkInterval;
                                    Process.Start(lstChk[i].PgId, lstChk[i].PgParam);
                                    //timer.Enabled = false;
                                    //lstChk.Clear();
                                }
                            }
                        }
                        // 拠点管理用(未実装)
                        //else if (chkWork.PgId == workDir + "\\     .exe")
                        //{
                        //    if (lstChk[i].HourCnt == 2) // １時間経過
                        //    {
                        //        lstChk[i].HourCnt = 0;

                        //        lstChk[i].RemainedTm--; // 残り時間を1時間減らす。
                        //        if (lstChk[i].RemainedTm == 0) // チェック間隔に達した？
                        //        {
                        //            lstChk[i].RemainedTm = lstChk[i].ChkInterval;
                        //            Process.Start(lstChk[i].PgId, lstChk[i].PgParam);
                        //            //timer.Enabled = false;
                        //            //lstChk.Clear();
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        // ボタンクリック時
        void timer_Elapsed_Click(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int chkTime = dt.Hour * 100 + dt.Minute;

            for (int i = 0; i < lstChk.Count; i++)
            {
                if (lstChk[i].ChkStTime1 <= chkTime && lstChk[i].ChkEdTime1 >= chkTime
                    && lstChk[i].ChkStTime2 <= chkTime && lstChk[i].ChkEdTime2 >= chkTime) // チェック時間帯か

                {
                    lstChk[i].HourCnt++;

                    lstChk[i].HourCnt = 0;

                    lstChk[i].RemainedTm--; // 残り時間を1時間減らす。

                    lstChk[i].RemainedTm = lstChk[i].ChkInterval;
                    Process.Start(lstChk[i].PgId, lstChk[i].PgParam);
                    OnStop();
                    //lstChk.Clear();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void OnStart(string[] args)
        {
            try
            {
                if (ReadCfgFile() == 0) // 設定ファイル読み込みOK
                {
                    for (int i = 0; i < _dtHist.Conf.Count; i++)
                    {
                        CheckCondWork cond = new CheckCondWork();
                        cond.ChkStTime1 = _dtHist.Conf[i].ChkStTime;
                        if (_dtHist.Conf[i].ChkStTime < _dtHist.Conf[i].ChkEdTime) // 例 1800 ~ 2300
                        {
                            cond.ChkEdTime1 = _dtHist.Conf[i].ChkEdTime;
                            cond.ChkStTime2 = 0;     // 第2チェック条件は常にTrueになるようにする。
                            cond.ChkEdTime2 = 2400;  // 第2チェック条件は常にTrueになるようにする。
                        }
                        else                                                       // 例 2100 ~ 0300
                        {
                            cond.ChkEdTime1 = 2400;
                            cond.ChkStTime2 = 0;
                            cond.ChkEdTime2 = _dtHist.Conf[i].ChkEdTime;
                        }
                        cond.ChkInterval = _dtHist.Conf[i].ChkInterval;
                        cond.RemainedTm = _dtHist.Conf[i].ChkInterval;
                        cond.PgId = Path.Combine(workDir, _dtHist.Conf[i].PgId);
                        cond.PgParam = _dtHist.Conf[i].RunParam;
                        lstChk.Add(cond);
                    }
                    if (lstChk.Count > 0)
                        timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //WriteErrorLog(this.ServiceName, "OnStart", ex.Message, ex, -1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void OnStop()
        {
            timer.Enabled = false;
        }

        /// <summary>
        /// 設定ファイル読込み
        /// </summary>
        /// <returns></returns>
        private int ReadCfgFile()
        {
            int status = 0;
            _dtHist = new conf();
            try
            {
                string fileNm = Path.Combine(workDir, ct_cfgFile);

                FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] tmp = new byte[fs.Length];
                int cnt = fs.Read(tmp, 0, (int)fs.Length);
                for (int i = 0; i < cnt; i++)
                {
                    tmp[i] += 8;
                }
                MemoryStream ms = new MemoryStream(tmp);
                _dtHist.ReadXml(ms);
                fs.Dispose();
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 設定ファイル書込み
        /// </summary>
        /// <returns></returns>
        private int WriteCfgFile()
        {
            int status = 0;
            string xml = _dtHist.GetXml();
            try
            {
                byte[] tmp = Encoding.Default.GetBytes(xml);
                string fileNm = Path.Combine(workDir, ct_cfgFile);


                FileStream fs = new FileStream(fileNm, FileMode.Create, FileAccess.Write, FileShare.Write);
                //FileStream fs = new FileStream(ct_cfgFile, FileMode.Create);
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] -= 8;
                }
                fs.Write(tmp, 0, tmp.Length);
                fs.Close();
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        ///// <summary>
        ///// エラーLog生成
        ///// </summary>
        ///// <param name="pgId"></param>
        ///// <param name="method"></param>
        ///// <param name="Msg"></param>
        ///// <param name="ex"></param>
        ///// <param name="status"></param>
        //private void WriteErrorLog(string pgId, string method, string Msg, Exception ex, int status)
        //{
        //    string exceptionMsg = "無し";
        //    if (ex != null)
        //        exceptionMsg = ex.Message;
        //    string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}", method, Msg, exceptionMsg);
        //    LogTextOut logTextOut = new LogTextOut();
        //    logTextOut.Output(pgId, msg, status);
        //    this.Stop();
        //}



        private void button1_Click(object sender, EventArgs e)
        {

            sender = null;
            System.Timers.ElapsedEventArgs a  = null;

            string[] args = null;
            //OnStart(args);
            timer_Elapsed_Click(sender, a);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (ReadCfgFile() != 0)
            {
                MessageBox.Show("設定ファイルの読み込みに失敗しました。", Text, MessageBoxButtons.OK);
            }
            gridConf.DataSource = _dtHist.Conf;
            for (int i = 0; i < gridConf.Columns.Count; i++)
            {
                gridConf.Columns[i].HeaderText = lstCaption[i];
            }

            gridConf.Columns[0].Width = 125; // ﾁｪｯｸ開始時刻
            gridConf.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[0].ValueType = typeof(int);
            gridConf.Columns[1].Width = 125; // ﾁｪｯｸ終了時刻
            gridConf.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[2].Width = 200; // 実行Pg名
            gridConf.Columns[3].Width = 80;  // 起動ﾊﾟﾗﾒｰﾀ
            gridConf.Columns[4].Width = 100; // ﾁｪｯｸ間隔
            gridConf.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WriteCfgFile();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnStop();
        }


    }
}
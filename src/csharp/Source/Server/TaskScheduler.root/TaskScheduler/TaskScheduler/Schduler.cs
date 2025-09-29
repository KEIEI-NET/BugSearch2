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
        private string workDir; // ���s�t�@�C���̂���f�B���N�g��
        private readonly string[] lstCaption = new string[5] { "�����J�n����\r  [HHMM]", "�����I������\r  [HHMM]", "���sPg��", "�N�����Ұ�", "�����Ԋu\r(���ԁj" };
        #endregion

        public Form1()
        {
            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Enabled = false;
            timer.Interval = 60000; // 1���Ԋu
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);

            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // �����Ă͂����Ȃ��P�[�X
            {
                //WriteErrorLog(this.ServiceName, "Constructor", "���W�X�g�����Ȃ�", null, -1);
                workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
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
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
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

        // ��莞�Ԍo��
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int chkTime = dt.Hour * 100 + dt.Minute;

            for (int i = 0; i < lstChk.Count; i++)
            {
                if (lstChk[i].ChkStTime1 <= chkTime && lstChk[i].ChkEdTime1 >= chkTime
                    && lstChk[i].ChkStTime2 <= chkTime && lstChk[i].ChkEdTime2 >= chkTime) // �`�F�b�N���ԑт�
                {
                    lstChk[i].HourCnt++;
                    //if (lstChk[i].HourCnt == 60
                    ) // �P���Ԍo��
                    foreach (CheckCondWork chkWork in lstChk)
                    {
                        // ���i�����p
                        if (chkWork.PgId == workDir + "\\PMKHN09210U.exe")
                        {
                            if (lstChk[i].HourCnt == 2) // �P���Ԍo��
                            {
                                lstChk[i].HourCnt = 0;

                                lstChk[i].RemainedTm--; // �c�莞�Ԃ�1���Ԍ��炷�B
                                if (lstChk[i].RemainedTm == 0) // �`�F�b�N�Ԋu�ɒB�����H
                                {
                                    lstChk[i].RemainedTm = lstChk[i].ChkInterval;
                                    Process.Start(lstChk[i].PgId, lstChk[i].PgParam);
                                    //timer.Enabled = false;
                                    //lstChk.Clear();
                                }
                            }
                        }
                        // ���_�Ǘ��p(������)
                        //else if (chkWork.PgId == workDir + "\\     .exe")
                        //{
                        //    if (lstChk[i].HourCnt == 2) // �P���Ԍo��
                        //    {
                        //        lstChk[i].HourCnt = 0;

                        //        lstChk[i].RemainedTm--; // �c�莞�Ԃ�1���Ԍ��炷�B
                        //        if (lstChk[i].RemainedTm == 0) // �`�F�b�N�Ԋu�ɒB�����H
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

        // �{�^���N���b�N��
        void timer_Elapsed_Click(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int chkTime = dt.Hour * 100 + dt.Minute;

            for (int i = 0; i < lstChk.Count; i++)
            {
                if (lstChk[i].ChkStTime1 <= chkTime && lstChk[i].ChkEdTime1 >= chkTime
                    && lstChk[i].ChkStTime2 <= chkTime && lstChk[i].ChkEdTime2 >= chkTime) // �`�F�b�N���ԑт�

                {
                    lstChk[i].HourCnt++;

                    lstChk[i].HourCnt = 0;

                    lstChk[i].RemainedTm--; // �c�莞�Ԃ�1���Ԍ��炷�B

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
                if (ReadCfgFile() == 0) // �ݒ�t�@�C���ǂݍ���OK
                {
                    for (int i = 0; i < _dtHist.Conf.Count; i++)
                    {
                        CheckCondWork cond = new CheckCondWork();
                        cond.ChkStTime1 = _dtHist.Conf[i].ChkStTime;
                        if (_dtHist.Conf[i].ChkStTime < _dtHist.Conf[i].ChkEdTime) // �� 1800 ~ 2300
                        {
                            cond.ChkEdTime1 = _dtHist.Conf[i].ChkEdTime;
                            cond.ChkStTime2 = 0;     // ��2�`�F�b�N�����͏��True�ɂȂ�悤�ɂ���B
                            cond.ChkEdTime2 = 2400;  // ��2�`�F�b�N�����͏��True�ɂȂ�悤�ɂ���B
                        }
                        else                                                       // �� 2100 ~ 0300
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
        /// �ݒ�t�@�C���Ǎ���
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
        /// �ݒ�t�@�C��������
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
        ///// �G���[Log����
        ///// </summary>
        ///// <param name="pgId"></param>
        ///// <param name="method"></param>
        ///// <param name="Msg"></param>
        ///// <param name="ex"></param>
        ///// <param name="status"></param>
        //private void WriteErrorLog(string pgId, string method, string Msg, Exception ex, int status)
        //{
        //    string exceptionMsg = "����";
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
                MessageBox.Show("�ݒ�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B", Text, MessageBoxButtons.OK);
            }
            gridConf.DataSource = _dtHist.Conf;
            for (int i = 0; i < gridConf.Columns.Count; i++)
            {
                gridConf.Columns[i].HeaderText = lstCaption[i];
            }

            gridConf.Columns[0].Width = 125; // �����J�n����
            gridConf.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[0].ValueType = typeof(int);
            gridConf.Columns[1].Width = 125; // �����I������
            gridConf.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridConf.Columns[2].Width = 200; // ���sPg��
            gridConf.Columns[3].Width = 80;  // �N�����Ұ�
            gridConf.Columns[4].Width = 100; // �����Ԋu
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
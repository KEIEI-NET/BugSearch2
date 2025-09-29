using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginID = textBox1.Text;
            string password = textBox2.Text;
            string csvFileFullName = textBox3.Text;

            string errorMessage = string.Empty;
            int timeLeftSeconds = 0;
            string errorListCsvFileFullName = string.Empty;      

            List<string> messagelist = new List<string>();

            this.label5.Text = string.Empty;
            this.label15.Text = string.Empty;

            this.label11.Text = string.Empty;
            this.label12.Text = string.Empty;
            this.label13.Text = string.Empty;
            this.label14.Text = string.Empty;
            this.label17.Text = string.Empty;
            
            BuhinMaxStockArrivalProvider aaa = new BuhinMaxStockArrivalProvider();

            // 登録
            int status1 = aaa.Regist(loginID, password, csvFileFullName, ref errorMessage);
            this.label5.Text = errorMessage;
            this.label15.Text = status1.ToString();

            // 状態取得
            if (status1 == 0)
            {
                int status2 = aaa.GetRegistStatus(System.DateTime.Now.AddSeconds(-10), ref errorListCsvFileFullName, ref timeLeftSeconds, ref messagelist);

                this.label11.Text = errorListCsvFileFullName;

                this.label12.Text = timeLeftSeconds.ToString();

                if (messagelist.Count > 0)
                {
                    this.label13.Text = messagelist[0].ToString();
                }
                this.label14.Text = status2.ToString();


                while (status2 == 100)
                {
                    // 5秒待機する。
                    System.Threading.Thread.Sleep(5000);
                    status2 = aaa.GetRegistStatus(System.DateTime.Now.AddSeconds(-10), ref errorListCsvFileFullName, ref timeLeftSeconds, ref messagelist);

                    this.label11.Text = errorListCsvFileFullName;

                    this.label12.Text = timeLeftSeconds.ToString();

                    if (messagelist.Count > 0)
                    {
                        this.label13.Text = messagelist[0].ToString();
                    }
                    this.label14.Text = status2.ToString();

                    if (status2 == 0 || status2 == 5 || status2 == 1000)
                    {
                        this.label13.Text = messagelist[messagelist.Count - 1].ToString();
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loginID = textBox1.Text;
            string password = textBox2.Text;
            string csvFileFullName = textBox3.Text;

            string errorMessage = string.Empty;
            int timeLeftSeconds = 0;
            string errorListCsvFileFullName = string.Empty;

            List<string> messagelist = new List<string>();

            this.label5.Text = string.Empty;
            this.label15.Text = string.Empty;

            this.label11.Text = string.Empty;
            this.label12.Text = string.Empty;
            this.label13.Text = string.Empty;
            this.label14.Text = string.Empty;
            this.label17.Text = string.Empty;

            BuhinMaxExhibitStockProvider aaa = new BuhinMaxExhibitStockProvider();

            // 登録
            int status1 = aaa.Regist(loginID, password, csvFileFullName, ref errorMessage);
            this.label5.Text = errorMessage;
            this.label15.Text = status1.ToString();

            // 状態取得
            if (status1 == 0)
            {
                int status2 = aaa.GetRegistStatus(System.DateTime.Now.AddSeconds(-10), ref errorListCsvFileFullName, ref timeLeftSeconds, ref messagelist);

                this.label11.Text = errorListCsvFileFullName;

                this.label12.Text = timeLeftSeconds.ToString();

                if (messagelist.Count > 0)
                {
                    this.label13.Text = messagelist[0].ToString();
                }
                this.label14.Text = status2.ToString();


                while (status2 == 100)
                {
                    // 5秒待機する。
                    System.Threading.Thread.Sleep(5000);
                    status2 = aaa.GetRegistStatus(System.DateTime.Now.AddSeconds(-10), ref errorListCsvFileFullName, ref timeLeftSeconds, ref messagelist);

                    this.label11.Text = errorListCsvFileFullName;

                    this.label12.Text = timeLeftSeconds.ToString();

                    if (messagelist.Count > 0)
                    {
                        this.label13.Text = messagelist[0].ToString();
                    }
                    this.label14.Text = status2.ToString();

                    if (status2 == 0 || status2 == 5 || status2 == 1000)
                    {
                        this.label13.Text = messagelist[messagelist.Count - 1].ToString();
                        break;
                    }
                }
            }
        }
    }
}
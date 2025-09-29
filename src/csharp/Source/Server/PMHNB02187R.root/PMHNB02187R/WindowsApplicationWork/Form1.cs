using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWork
{
    public partial class Form1 : Form
    {
        ICustSalesDistributionReportResultDB custSalesDistributionReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //集計単位
            //0:得意先 1:担当者 2:地区
            comboBox1.Items.Add("0:得意先");
            comboBox1.Items.Add("1:担当者");
            comboBox1.Items.Add("2:地区");
            comboBox1.SelectedIndex = 0;

            //集計方法
            comboBox2.Items.Add("0:する");
            comboBox2.Items.Add("1:しない");
            comboBox2.SelectedIndex = 0;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            custSalesDistributionReportResultDB = MediationCustSalesDistributionReportResultDB.GetCustSalesDistributionReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustSalesDistributionReportParamWork paramWork = null;

            paramWork = new CustSalesDistributionReportParamWork();

            //企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            //拠点コード
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCode = SectionCodes;

            //発行タイプ
            paramWork.PrintDiv = comboBox1.SelectedIndex;

            //実績集計区分
            paramWork.SearchDiv = comboBox2.SelectedIndex;

            //対象日付
            paramWork.StSalesDate = Int32.Parse(textBox3.Text);
            paramWork.EdSalesDate = Int32.Parse(textBox4.Text);


            //得意先コード
            paramWork.StCustomerCode = Int32.Parse(textBox7.Text);
            paramWork.EdCustomerCode = Int32.Parse(textBox8.Text);

            //従業員コード
            paramWork.StSalesEmployeeCd = textBox9.Text;
            paramWork.EdSalesEmployeeCd = textBox10.Text;

            //地区コード
            paramWork.StSalesAreaCode = Int32.Parse(textBox11.Text);
            paramWork.EdSalesAreaCode = Int32.Parse(textBox12.Text);


            ArrayList al = new ArrayList();
            al.Add(paramWork);
            dataGridView2.DataSource = al;

            Search();


        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = custSalesDistributionReportResultDB.Search(out objResult, objParam);
                if (status != 0)
                {
                    Text = "該当データ無し ST=" + Convert.ToString(status);
                }
                else
                {
                    // XMLの読み込み
                    Text = "該当データ有り  HIT " + ((ArrayList)objResult).Count.ToString() + "件";

                    if (objResult != null)
                    {
                        dataGridView1.DataSource = objResult;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
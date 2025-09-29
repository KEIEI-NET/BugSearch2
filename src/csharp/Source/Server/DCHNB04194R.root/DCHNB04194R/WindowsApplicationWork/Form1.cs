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
using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;

namespace WindowsApplicationWork
{
    public partial class Form1 : Form
    {
        ISalesAnnualDataSelectResultDB salesAnnualDataSelectResultDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            textBox3.Text = "1";
            textBox8.Text = "200801";
            textBox9.Text = "200812";
            textBox7.Text = "20080821";
            textBox10.Text = "20080920";
            textBox11.Text = "20080820";
            textBox12.Text = "20080820";
            textBox13.Text = "200809";
            
            //0:拠点,1:得意先,2:担当者,3:受注者,4:発行者,5:地区,6:業種
            comboBox1.Items.Add("0:拠点");
            comboBox1.Items.Add("1:得意先");
            comboBox1.Items.Add("2:担当者");
            comboBox1.Items.Add("3:地区");
            comboBox1.Items.Add("4:業種");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("0:年度実績");
            comboBox2.Items.Add("1:残高照会(請求・入金)");
            comboBox2.Items.Add("2:残高照会(当月当期売上)");
            comboBox2.SelectedIndex = 0;

            comboBox3.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesAnnualDataSelectResultDB = MediationSalesAnnualDataSelectResultDB.GetSalesAnnualDataSelectResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = null;

            salesAnnualDataSelectParamWork = new SalesAnnualDataSelectParamWork();

            // 企業コード
            salesAnnualDataSelectParamWork.EnterpriseCode = textBox1.Text;

            // 拠点コード
            salesAnnualDataSelectParamWork.SectionCode = textBox2.Text;

            //得意先コード
            salesAnnualDataSelectParamWork.CustomerCode = textBox3.Text == "" ? 0 : Convert.ToInt32(textBox3.Text);
            
            //従業員コード
            salesAnnualDataSelectParamWork.EmployeeCode = textBox4.Text;

            //販売エリアコード
            salesAnnualDataSelectParamWork.SalesAreaCode = textBox5.Text=="" ? 0 : Convert.ToInt32(textBox5.Text);

            //業種コード
            salesAnnualDataSelectParamWork.BusinessTypeCode = textBox6.Text=="" ? 0 : Convert.ToInt32(textBox6.Text);

            //開始年月
            salesAnnualDataSelectParamWork.YearMonthSt = textBox8.Text == "" ? 200801 : Convert.ToInt32(textBox8.Text);

            //終了年月
            salesAnnualDataSelectParamWork.YearMonthEd = textBox9.Text == "" ? 200812 : Convert.ToInt32(textBox9.Text);

            //集計区分
            salesAnnualDataSelectParamWork.TotalDiv = comboBox1.SelectedIndex;

            //検索区分
            salesAnnualDataSelectParamWork.SearchDiv = comboBox2.SelectedIndex;

            // 従業員区分
            int EmployeeDiv = 10;
            if (comboBox3.SelectedIndex == 0)
            {
                EmployeeDiv = 10;
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                EmployeeDiv = 20;

            }
            else
            {
                EmployeeDiv = 30;
            }

            salesAnnualDataSelectParamWork.EmployeeDivCd = EmployeeDiv;
            

            // 計上年月日           
            salesAnnualDataSelectParamWork.StAddUpDate = Convert.ToInt32(textBox7.Text);
            salesAnnualDataSelectParamWork.EdAddUpDate = Convert.ToInt32(textBox10.Text);

            ArrayList al = new ArrayList();
            al.Add(salesAnnualDataSelectParamWork);
            dataGridView2.DataSource = al;

            Search();


        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                dataGridView1.DataSource = null;
                int status = salesAnnualDataSelectResultDB.Search(out objResult, objParam);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = null;

            salesAnnualDataSelectParamWork = new SalesAnnualDataSelectParamWork();

            // 企業コード
            salesAnnualDataSelectParamWork.EnterpriseCode = textBox1.Text;

            // 拠点コード
            salesAnnualDataSelectParamWork.SectionCode = textBox2.Text;

            //得意先コード
            salesAnnualDataSelectParamWork.CustomerCode = textBox3.Text == "" ? 0 : Convert.ToInt32(textBox3.Text);

            //従業員コード
            salesAnnualDataSelectParamWork.EmployeeCode = textBox4.Text;

            //販売エリアコード
            salesAnnualDataSelectParamWork.SalesAreaCode = textBox5.Text == "" ? 0 : Convert.ToInt32(textBox5.Text);

            //業種コード
            salesAnnualDataSelectParamWork.BusinessTypeCode = textBox6.Text == "" ? 0 : Convert.ToInt32(textBox6.Text);

            //開始年月
            salesAnnualDataSelectParamWork.YearMonthSt = textBox8.Text == "" ? 200801 : Convert.ToInt32(textBox8.Text);

            //終了年月
            salesAnnualDataSelectParamWork.YearMonthEd = textBox9.Text == "" ? 200812 : Convert.ToInt32(textBox9.Text);

            //集計区分
            salesAnnualDataSelectParamWork.TotalDiv = comboBox1.SelectedIndex;

            //検索区分
            salesAnnualDataSelectParamWork.SearchDiv = comboBox2.SelectedIndex;

            // 従業員区分
            int EmployeeDiv = 10;
            if (comboBox3.SelectedIndex == 0)
            {
                EmployeeDiv = 10;
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                EmployeeDiv = 20;

            }
            else
            {
                EmployeeDiv = 30;
            }

            salesAnnualDataSelectParamWork.EmployeeDivCd = EmployeeDiv;



            // 集計年月日           
            salesAnnualDataSelectParamWork.StAddUpDate = Convert.ToInt32(textBox7.Text);
            salesAnnualDataSelectParamWork.EdAddUpDate = Convert.ToInt32(textBox10.Text);

            //得意先締日
            salesAnnualDataSelectParamWork.CustTotalDay = Convert.ToInt32(textBox11.Text);
            //自社締日
            salesAnnualDataSelectParamWork.SecTotalDay = Convert.ToInt32(textBox12.Text);
            //計上年月
            salesAnnualDataSelectParamWork.AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM",Convert.ToInt32(textBox13.Text));


            ArrayList al = new ArrayList();
            al.Add(salesAnnualDataSelectParamWork);
            dataGridView2.DataSource = al;

            CustSearch();

        }

        private void CustSearch()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                dataGridView1.DataSource = null;
                int status = salesAnnualDataSelectResultDB.CustSearch(out objResult, objParam);
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


    }
}
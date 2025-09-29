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
        IStockMonthYearReportResultDB stockMonthYearReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
            textBox2.Text = "000001";
            //textBox7.Text = "0";
            textBox8.Text = "2007/01";
            textBox9.Text = "2007/12";
            //textBox10.Text = "1";
            textBox11.Text = "2007/01";
            textBox12.Text = "2007/01";
            comboBox1.Items.Add("0:拠点別");
            comboBox1.Items.Add("1:仕入先別");
            comboBox1.Items.Add("2:担当者別");
            comboBox1.Items.Add("3:部署別");
            comboBox1.Items.Add("4:メーカー別");
            comboBox1.Items.Add("5:仕入先別メーカー別");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("0: 全社");
            comboBox2.Items.Add("1: 拠点別");
            comboBox2.SelectedIndex = 1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockMonthYearReportResultDB = MediationStockMonthYearReportResultDB.GetStockMonthYearReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockMonthYearReportParamWork paramWork = null;

            paramWork = new StockMonthYearReportParamWork();

            // 企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            //拠点別集計区分
            //0:全社集計／1:拠点別集計
            paramWork.TtlType = comboBox2.SelectedIndex;
            
            // 拠点コード
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            SectionCodes[1] = "000002";
            paramWork.SectionCodes = SectionCodes;

            //部署管理区分
            paramWork.SectionDiv = 2;

            //開始年月
            paramWork.StockDateYmSt = Convert.ToDateTime(textBox11.Text);

            //終了年月
            paramWork.StockDateYmEd = Convert.ToDateTime(textBox12.Text);

            //開始期年月
            paramWork.AnnualStockDateYmSt = Convert.ToDateTime(textBox8.Text);

            //終了期年月
            paramWork.AnnualStockDateYmEd = Convert.ToDateTime(textBox9.Text);

            //担当従業員コード
            paramWork.EmployeeCodeSt = "";
            paramWork.EmployeeCodeEd = "";

            //仕入先コード
            paramWork.SupplierCdSt = 0;
            paramWork.SupplierCdEd = 0;

            //商品メーカーコード
            paramWork.GoodsMakerCdSt = 0;
            paramWork.GoodsMakerCdEd = 0;


            //集計区分
            paramWork.TotalType = comboBox1.SelectedIndex;


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
                int status = stockMonthYearReportResultDB.Search(out objResult, objParam);
                if (status != 0)
                {
                    Text = "該当データ無し";
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
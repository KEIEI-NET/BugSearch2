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
        ISalesDayMonthReportResultDB salesDayMonthReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //集計単位
            //0:得意先別 1:担当者別 2:受注者別 3:発行者別 4:地区別 5:業種別 6:販売区分別
            comboBox1.Items.Add("0:得意先別");
            comboBox1.Items.Add("1:担当者別");
            comboBox1.Items.Add("2:受注者別");
            comboBox1.Items.Add("3:発行者別");
            comboBox1.Items.Add("4:地区別");
            comboBox1.Items.Add("5:業種別");
            comboBox1.Items.Add("6:販売区分別");
            comboBox1.SelectedIndex = 0;

            //集計方法
            //0:全社 1:拠点毎
            comboBox2.Items.Add("0:全社");
            comboBox2.Items.Add("1:拠点毎");
            comboBox2.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesDayMonthReportResultDB = MediationSalesDayMonthReportResultDB.GetSalesDayMonthReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region [old]
            /*
            SalesDayMonthReportParamWork salesDayMonthReportParamWork = null;

            salesDayMonthReportParamWork = new SalesDayMonthReportParamWork();

            // 企業コード
            salesDayMonthReportParamWork.EnterpriseCode = textBox1.Text;

            // 拠点コード
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            salesDayMonthReportParamWork.SectionCodes = SectionCodes;

            //集計方法
            salesDayMonthReportParamWork.TtlType = comboBox2.SelectedIndex;

            //担当従業員コード
            salesDayMonthReportParamWork.SalesEmployeeCdSt = "";
            salesDayMonthReportParamWork.SalesEmployeeCdEd = "";

            //受注従業員コード
            salesDayMonthReportParamWork.FrontEmployeeCdSt = "";
            salesDayMonthReportParamWork.FrontEmployeeCdEd = "";

            //発行従業員コード
            salesDayMonthReportParamWork.SalesInputCodeSt = "";
            salesDayMonthReportParamWork.SalesInputCodeEd = "";

            //販売エリアコード
            salesDayMonthReportParamWork.SalesAreaCodeSt = 0;
            salesDayMonthReportParamWork.SalesAreaCodeEd = 0;

            //業種コード
            salesDayMonthReportParamWork.BusinessTypeCodeSt = 0;
            salesDayMonthReportParamWork.BusinessTypeCodeEd = 0;

            //開始年月日
            salesDayMonthReportParamWork.SalesDateSt = Convert.ToDateTime(textBox11.Text);

            //終了年月日
            salesDayMonthReportParamWork.SalesDateEd = Convert.ToDateTime(textBox12.Text);

            //開始年月
            salesDayMonthReportParamWork.MonthReportDateSt = Convert.ToDateTime(textBox8.Text);

            //終了年月
            salesDayMonthReportParamWork.MonthReportDateEd = Convert.ToDateTime(textBox9.Text);

            //月間目標月
            salesDayMonthReportParamWork.TargetMonth = Convert.ToDateTime(textBox7.Text.Substring(0, 7));

            //集計区分
            salesDayMonthReportParamWork.TotalType = comboBox1.SelectedIndex;
            */
            #endregion

            SalesDayMonthReportParamWork salesDayMonthReportParamWork = null;

            salesDayMonthReportParamWork = new SalesDayMonthReportParamWork();

            //企業コード
            salesDayMonthReportParamWork.EnterpriseCode = textBox1.Text;

            //拠点コード
            string[] SectionCodes = new string[2];
            if (textBox2.Text == "")
            {
                SectionCodes = null;
            }
            else
            {
                SectionCodes[0] = textBox2.Text;
            }
            salesDayMonthReportParamWork.SectionCodes = SectionCodes;

            //開始対象日付(期間)
            salesDayMonthReportParamWork.SalesDateSt = DateTime.ParseExact(textBox3.Text, "yyyyMMdd", null);
            //終了対象日付(期間)
            salesDayMonthReportParamWork.SalesDateEd = DateTime.ParseExact(textBox4.Text, "yyyyMMdd", null);
            //開始対象日付(当月)
            salesDayMonthReportParamWork.MonthReportDateSt = DateTime.ParseExact(textBox5.Text, "yyyyMMdd", null);
            //終了対象日付(当月)
            salesDayMonthReportParamWork.MonthReportDateEd = DateTime.ParseExact(textBox6.Text, "yyyyMMdd", null);

            salesDayMonthReportParamWork.TotalType = comboBox1.SelectedIndex;          //集計単位
            salesDayMonthReportParamWork.TtlType = comboBox2.SelectedIndex;            //集計方法
            salesDayMonthReportParamWork.OutType = Int32.Parse(textBox11.Text);        //出力順

            salesDayMonthReportParamWork.CustomerCodeSt = Int32.Parse(textBox7.Text);  //開始得意先コード
            salesDayMonthReportParamWork.CustomerCodeEd = Int32.Parse(textBox8.Text);  //終了得意先コード
            salesDayMonthReportParamWork.SrchCodeSt = textBox9.Text;                   //開始検索コード
            salesDayMonthReportParamWork.SrchCodeEd = textBox10.Text;                  //終了検索コード

            ArrayList al = new ArrayList();
            al.Add(salesDayMonthReportParamWork);
            dataGridView2.DataSource = al;

            Search();
        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = salesDayMonthReportResultDB.Search(out objResult, objParam);
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
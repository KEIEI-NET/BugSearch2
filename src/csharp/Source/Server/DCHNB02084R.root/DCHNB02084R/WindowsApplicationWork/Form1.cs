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
        ISalesMonthYearReportResultDB salesMonthYearReportResultDB = null;
        
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

            //印刷タイプ
            //0:当月 1:当期 2:当月＆当期
            comboBox3.Items.Add("0:当月");
            comboBox3.Items.Add("1:当期");
            comboBox3.Items.Add("2:当月＆当期");
            comboBox3.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesMonthYearReportResultDB = MediationSalesMonthYearReportResultDB.GetSalesMonthYearReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesMonthYearReportParamWork salesMonthYearReportParamWork = null;

            salesMonthYearReportParamWork = new SalesMonthYearReportParamWork();

            #region [Old]
            /*
            // 企業コード
            salesMonthYearReportParamWork.EnterpriseCode = textBox1.Text;

            //拠点別集計区分
            //0:全社集計／1:拠点別集計
            salesMonthYearReportParamWork.TtlType = comboBox2.SelectedIndex;
            
            // 拠点コード
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            SectionCodes[1] = "";
            salesMonthYearReportParamWork.SectionCodes = SectionCodes;

            //部署管理区分
            salesMonthYearReportParamWork.SectionDiv = 2;

            //開始年月
            salesMonthYearReportParamWork.AddUpYearMonthSt = Convert.ToDateTime(textBox11.Text);

            //終了年月
            salesMonthYearReportParamWork.AddUpYearMonthEd = Convert.ToDateTime(textBox12.Text);

            //開始期年月
            salesMonthYearReportParamWork.AnnualAddUpYearMonthSt = Convert.ToDateTime(textBox8.Text);

            //終了期年月
            salesMonthYearReportParamWork.AnnualAddUpYaerMonthEd = Convert.ToDateTime(textBox9.Text);

            //担当従業員コード
            salesMonthYearReportParamWork.SalesEmployeeCdSt = "";
            salesMonthYearReportParamWork.SalesEmployeeCdEd = "";

            //得意先コード
            salesMonthYearReportParamWork.CustomerCodeSt = 0;
            salesMonthYearReportParamWork.CustomerCodeEd = 0;

            //商品メーカーコード
            salesMonthYearReportParamWork.GoodsMakerCdSt = 0;
            salesMonthYearReportParamWork.GoodsMakerCdEd = 0;


            //集計区分
            salesMonthYearReportParamWork.TotalType = comboBox1.SelectedIndex;
             */
            #endregion

            //企業コード
            salesMonthYearReportParamWork.EnterpriseCode = textBox1.Text;
            
            //拠点コード
            string[] SectionCodes = new string[2];
            if (textBox2.Text != "")
            {
                SectionCodes[0] = textBox2.Text;
            }
            else
            {
                SectionCodes = null;
            }
            salesMonthYearReportParamWork.SectionCodes = SectionCodes;
            
            //開始対象年月(当月)
            salesMonthYearReportParamWork.AddUpYearMonthSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            //終了対象年月(当月)
            salesMonthYearReportParamWork.AddUpYearMonthEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);

            //開始対象年月(当期)
            salesMonthYearReportParamWork.AnnualAddUpYearMonthSt = DateTime.ParseExact(textBox10.Text, "yyyyMM", null);
            //終了対象年月(当期)
            salesMonthYearReportParamWork.AnnualAddUpYaerMonthEd = DateTime.ParseExact(textBox11.Text, "yyyyMM", null);


            salesMonthYearReportParamWork.TotalType = comboBox1.SelectedIndex;          //集計単位
            salesMonthYearReportParamWork.TtlType = comboBox2.SelectedIndex;            //集計方法
            salesMonthYearReportParamWork.PrintType = comboBox3.SelectedIndex;          //印刷タイプ
            salesMonthYearReportParamWork.OutType = Int32.Parse(textBox9.Text);         //出力順
            salesMonthYearReportParamWork.CustomerCodeSt = Int32.Parse(textBox5.Text);  //開始得意先コード
            salesMonthYearReportParamWork.CustomerCodeEd = Int32.Parse(textBox6.Text);  //終了得意先コード
            salesMonthYearReportParamWork.SrchCodeSt = textBox7.Text;                   //開始検索コード
            salesMonthYearReportParamWork.SrchCodeEd = textBox8.Text;                   //終了検索コード

            ArrayList al = new ArrayList();
            al.Add(salesMonthYearReportParamWork);
            dataGridView2.DataSource = al;

            Search();
        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = salesMonthYearReportResultDB.Search(out objResult, objParam);
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
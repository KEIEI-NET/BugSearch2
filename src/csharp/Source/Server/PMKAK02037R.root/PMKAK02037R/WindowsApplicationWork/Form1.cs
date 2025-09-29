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
        IStockRetPlnTableDB stockRetPlnTableDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockRetPlnTableDB = MediationStockRetPlnTableDB.GetStockRetPlnTableDB();
            comboBox1.Items.Add("全て印刷");
            comboBox1.Items.Add("入荷計上");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("入荷");
            comboBox2.Items.Add("返品");
            comboBox2.Items.Add("入荷＋返品");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("仕入先→入荷日→伝票番号");
            comboBox3.Items.Add("入荷日→仕入先→伝票番号");
            comboBox3.Items.Add("担当者→仕入先→入荷日→伝票番号");
            comboBox3.Items.Add("入荷日→伝票番号");
            comboBox3.Items.Add("伝票番号");
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Add("黒伝");
            comboBox4.Items.Add("赤伝");
            comboBox4.Items.Add("元黒");
            comboBox4.Items.Add("全て");
            comboBox4.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockRetPlnParamWork stockRetPlnParamWork = null;

            stockRetPlnParamWork = new StockRetPlnParamWork();

            // 企業コード
            stockRetPlnParamWork.EnterpriseCode = textBox1.Text;

            // 拠点コード
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();

            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);

            string[] sectionCode = wrkSecCdList.ToArray();

            stockRetPlnParamWork.SectionCodes = sectionCode;

            //開始得意先コード
            stockRetPlnParamWork.SupplierCdSt = textBox5.Text=="" ? 0 : Convert.ToInt32(textBox5.Text);
            //終了得意先コード
            stockRetPlnParamWork.SupplierCdEd = textBox6.Text=="" ? 0 : Convert.ToInt32(textBox6.Text);
            //開始仕入日
            stockRetPlnParamWork.StockDateSt = 0;
            //終了仕入日
            stockRetPlnParamWork.StockDateEd = 0;
            //発行タイプ
            stockRetPlnParamWork.MakeShowDiv = comboBox1.SelectedIndex;
            //出力指定
            stockRetPlnParamWork.SlipDiv = comboBox2.SelectedIndex;
            //日付指定
            stockRetPlnParamWork.PrintDailyFooter = comboBox4.SelectedIndex;

            ArrayList al = new ArrayList();
            al.Add(stockRetPlnParamWork);
            dataGridView2.DataSource = al;

            Search();

        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = stockRetPlnTableDB.Search(out objResult, objParam);
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
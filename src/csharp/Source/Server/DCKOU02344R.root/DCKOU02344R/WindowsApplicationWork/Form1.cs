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
        IArrivalListDB arrivalListDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            arrivalListDB = MediationArrivalListDB.GetArrivalListDB();
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
            ArrivalListParamWork arrivalListParamWork = null;

            arrivalListParamWork = new ArrivalListParamWork();

            // 企業コード
            arrivalListParamWork.EnterpriseCode = textBox1.Text;

            // 拠点コード
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();

            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);

            string[] sectionCode = wrkSecCdList.ToArray();

            arrivalListParamWork.SectionCodes = sectionCode;

            //開始得意先コード
            arrivalListParamWork.SupplierCdSt = textBox5.Text=="" ? 0 : Convert.ToInt32(textBox5.Text);
            //終了得意先コード
            arrivalListParamWork.SupplierCdEd = textBox6.Text=="" ? 0 : Convert.ToInt32(textBox6.Text);
            //開始仕入担当者コード
            arrivalListParamWork.StockAgentCodeSt = textBox7.Text;
            //終了仕入担当者コード
            arrivalListParamWork.StockAgentCodeEd = textBox8.Text;
            //開始仕入入力者コード
            //arrivalListParamWork.StockInputCodeSt = textBox9.Text;
            //終了仕入入力者コード
            //arrivalListParamWork.StockInputCodeEd = textBox10.Text;
            //開始仕入伝票番号
            arrivalListParamWork.SupplierSlipNoSt = textBox11.Text=="" ? 0 : Convert.ToInt32(textBox11.Text);
            //終了仕入伝票番号
            arrivalListParamWork.SupplierSlipNoEd = textBox12.Text=="" ? 0 : Convert.ToInt32(textBox12.Text);
            //開始仕入日
            arrivalListParamWork.StockDateSt = 0;
            //終了仕入日
            arrivalListParamWork.StockDateEd = 0;
            //開始入荷日
            arrivalListParamWork.ArrivalGoodsDaySt = textBox13.Text == "" ? 0 : Convert.ToInt32(textBox13.Text.Substring(0, 4)) * 10000 + Convert.ToInt32(textBox13.Text.Substring(4, 2)) * 100 + Convert.ToInt32(textBox13.Text.Substring(6, 2));
            //終了入荷日
            arrivalListParamWork.ArrivalGoodsDayEd = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text.Substring(0, 4)) * 10000 + Convert.ToInt32(textBox14.Text.Substring(4, 2)) * 100 + Convert.ToInt32(textBox14.Text.Substring(6, 2));
            //発行タイプ
            arrivalListParamWork.MakeShowDiv = comboBox1.SelectedIndex;
            //伝票区分
            arrivalListParamWork.SlipDiv = comboBox2.SelectedIndex;
            //出力順
            arrivalListParamWork.SortOrder = comboBox3.SelectedIndex;
            //赤伝区分
            arrivalListParamWork.DebitNoteDiv = comboBox4.SelectedIndex;

            ArrayList al = new ArrayList();
            al.Add(arrivalListParamWork);
            dataGridView2.DataSource = al;

            Search();

        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = arrivalListDB.Search(out objResult, objParam);
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
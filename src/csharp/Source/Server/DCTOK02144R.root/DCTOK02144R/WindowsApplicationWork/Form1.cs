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

namespace WindowsApplicationWork
{
    public partial class Form1 : Form
    {
        ISalesTransListResultDB salesTransListResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //集計単位
            //0:商品別 1:得意先別 2:担当者別 3:倉庫別
            comboBox1.Items.Add("0:商品別");
            comboBox1.Items.Add("1:得意先別");
            comboBox1.Items.Add("2:担当者別");
            comboBox1.Items.Add("3:倉庫別");
            comboBox1.SelectedIndex = 0;

            //集計方法
            comboBox2.Items.Add("0:全社");
            comboBox2.Items.Add("1:拠点別");
            comboBox2.SelectedIndex = 0;

            //在庫取寄せ区分
            //0:合計 1:在庫, 2:取寄せ
            comboBox3.Items.Add("0:合計");
            comboBox3.Items.Add("1:在庫");
            comboBox3.Items.Add("2:取寄せ");
            comboBox3.SelectedIndex = 0;

            //メーカー別印刷
            //0:しない 1:する
            comboBox4.Items.Add("0:しない");
            comboBox4.Items.Add("1:する");
            comboBox4.SelectedIndex = 0;

            //明細単位
            comboBox5.Items.Add("0：品番");
            comboBox5.Items.Add("1：BLコード");
            comboBox5.Items.Add("2：グループコード");
            comboBox5.Items.Add("3：商品中分類");
            comboBox5.Items.Add("4：商品大分類");
            comboBox5.Items.Add("5：メーカー");
            comboBox5.Items.Add("6：拠点・得意先・担当者");
            comboBox5.Items.Add("7：拠点");
            comboBox5.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesTransListResultDB = MediationSalesTransListResultDB.GetSalesTransListResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesTransListCndtnWork paramWork = null;

            paramWork = new SalesTransListCndtnWork();

            //企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            //拠点コード
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCodes = SectionCodes;

            //集計単位
            paramWork.TotalType = comboBox1.SelectedIndex;

            //集計方法
            paramWork.TtlType = comboBox2.SelectedIndex;

            //在庫取寄せ区分
            paramWork.RsltTtlDivCd = comboBox3.SelectedIndex;

            //メーカー別印刷
            paramWork.MakerPrintDiv = comboBox4.SelectedIndex;

            //明細単位
            paramWork.Detail = comboBox5.SelectedIndex;

            //対象年月(当月)
            paramWork.AddUpYearMonthSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            paramWork.AddUpYearMonthEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);

            //印刷範囲指定
            paramWork.PrintRangeSt = Int32.Parse(textBox5.Text);
            paramWork.PrintRangeEd = Int32.Parse(textBox6.Text);

            //得意先コード
            paramWork.CustomerCodeSt = Int32.Parse(textBox7.Text);
            paramWork.CustomerCodeEd = Int32.Parse(textBox8.Text);

            //従業員コード
            paramWork.EmployeeCodeSt = textBox9.Text;
            paramWork.EmployeeCodeEd = textBox10.Text;

            //商品メーカーコード
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox11.Text);
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox12.Text);

            //商品大分類コード
            paramWork.GoodsLGroupSt = Int32.Parse(textBox13.Text);
            paramWork.GoodsLGroupEd = Int32.Parse(textBox14.Text);

            //商品中分類コード
            paramWork.GoodsMGroupSt = Int32.Parse(textBox15.Text);
            paramWork.GoodsMGroupEd = Int32.Parse(textBox16.Text);

            //BLグループコード
            paramWork.BLGroupCodeSt = Int32.Parse(textBox17.Text);
            paramWork.BLGroupCodeEd = Int32.Parse(textBox18.Text);

            //BL商品コード
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox19.Text);
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox20.Text);

            //商品番号
            paramWork.GoodsNoSt = textBox21.Text;
            paramWork.GoodsNoEd = textBox22.Text;



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
                int status = salesTransListResultDB.Search(out objResult, objParam);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
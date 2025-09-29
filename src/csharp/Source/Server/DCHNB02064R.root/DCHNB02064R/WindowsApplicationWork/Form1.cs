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
        IShipmGoodsOdrReportResultDB shipmGoodsOdrReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //集計単位
            //0:商品別 1:BLコード別 2:得意先別 3:担当者別
            comboBox1.Items.Add("0:商品別");
            comboBox1.Items.Add("1:BLコード別");
            comboBox1.Items.Add("2:得意先別");
            comboBox1.Items.Add("3:担当者別");
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

            //明細単位
            comboBox4.Items.Add("0");
            comboBox4.Items.Add("1");
            comboBox4.Items.Add("2");
            comboBox4.Items.Add("3");
            comboBox4.Items.Add("4");
            comboBox4.Items.Add("5");
            comboBox4.Items.Add("6");
            comboBox4.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            shipmGoodsOdrReportResultDB = MediationShipmGoodsOdrReportResultDB.GetShipmGoodsOdrReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmGoodsOdrReportParamWork paramWork = null;

            paramWork = new ShipmGoodsOdrReportParamWork();

            // 企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            // 拠点コード
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
            //明細単位
            paramWork.Detail = comboBox4.SelectedIndex;

            //対象年月
            paramWork.SalesDateSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            paramWork.SalesDateEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);
            //印刷範囲指定
            paramWork.PrintRangeSt = Int32.Parse(textBox5.Text);
            paramWork.PrintRangeEd = Int32.Parse(textBox6.Text);
            //仕入先コード
            paramWork.SupplierCdSt = Int32.Parse(textBox7.Text);
            paramWork.SupplierCdEd = Int32.Parse(textBox8.Text);
            //得意先コード
            paramWork.CustomerCodeSt = Int32.Parse(textBox9.Text);
            paramWork.CustomerCodeEd = Int32.Parse(textBox10.Text);
            //従業員コード
            paramWork.EmployeeCodeSt = textBox11.Text;
            paramWork.EmployeeCodeEd = textBox12.Text;
            //商品メーカーコード
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox13.Text);
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox14.Text);
            //商品大分類コード
            paramWork.GoodsLGroupSt = Int32.Parse(textBox15.Text);
            paramWork.GoodsLGroupEd = Int32.Parse(textBox16.Text);
            //商品中分類コード
            paramWork.GoodsMGroupSt = Int32.Parse(textBox17.Text);
            paramWork.GoodsMGroupEd = Int32.Parse(textBox18.Text);
            //BLグループコード
            paramWork.BLGroupCodeSt = Int32.Parse(textBox19.Text);
            paramWork.BLGroupCodeEd = Int32.Parse(textBox20.Text);
            
            paramWork.BLGroupCodeAry = null;
            //BL商品コード
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox21.Text);
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox22.Text);
            //商品番号
            paramWork.GoodsNoSt = textBox23.Text;
            paramWork.GoodsNoEd = textBox24.Text;

            //順位設定
            paramWork.Order = Int32.Parse(textBox25.Text);

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
                int status = shipmGoodsOdrReportResultDB.Search(out objResult, objParam);
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
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
        ISalesRsltListResultDB salesRsltListResultDB = null;
        
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

            //出荷指定区分
            //0:当月 1:当期
            comboBox3.Items.Add("0:当月");
            comboBox3.Items.Add("1:当期");
            comboBox3.SelectedIndex = 0;

            //在庫取寄せ区分
            //0:合計 1:在庫, 2:取寄せ
            comboBox4.Items.Add("0:合計");
            comboBox4.Items.Add("1:在庫");
            comboBox4.Items.Add("2:取寄せ");
            comboBox4.SelectedIndex = 0;

            //当期印刷
            //0:しない 1:する
            comboBox5.Items.Add("0:しない");
            comboBox5.Items.Add("1:する");
            comboBox5.SelectedIndex = 0;

            //メーカー別印刷
            //0:しない 1:する
            comboBox6.Items.Add("0:しない");
            comboBox6.Items.Add("1:する");
            comboBox6.SelectedIndex = 0;

            //明細単位
            comboBox7.Items.Add("0：品番");
            comboBox7.Items.Add("1：BLコード");
            comboBox7.Items.Add("2：グループコード");
            comboBox7.Items.Add("3：商品中分類");
            comboBox7.Items.Add("4：商品大分類");
            comboBox7.Items.Add("5：メーカー");
            comboBox7.Items.Add("6：拠点");
            comboBox7.SelectedIndex = 0;

            //発行タイプ
            //0:拠点別倉庫別 1:倉庫別得意先別 2:倉庫別拠点別
            comboBox8.Items.Add("0:拠点別倉庫別");
            comboBox8.Items.Add("1:倉庫別得意先別");
            comboBox8.Items.Add("2:倉庫別拠点別");
            comboBox8.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesRsltListResultDB = MediationSalesRsltListResultDB.GetSalesRsltListResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesRsltListCndtnWork paramWork = null;

            paramWork = new SalesRsltListCndtnWork();

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

            //出荷指定区分
            paramWork.PrintRangeDiv = comboBox3.SelectedIndex;

            //在庫取寄せ区分
            paramWork.RsltTtlDivCd = comboBox4.SelectedIndex;

            //当期印刷
            paramWork.AnnualPrintDiv = comboBox5.SelectedIndex;

            //メーカー別印刷
            paramWork.MakerPrintDiv = comboBox6.SelectedIndex;

            //明細単位
            paramWork.Detail = comboBox7.SelectedIndex;

            //発行タイプ
            paramWork.PrintType = comboBox8.SelectedIndex;

            //対象年月(当月)
            paramWork.AddUpYearMonthSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            paramWork.AddUpYearMonthEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);

            //対象年月(当期)
            paramWork.AnnualAddUpYearMonthSt = DateTime.ParseExact(textBox5.Text, "yyyyMM", null);
            paramWork.AnnualAddUpYaerMonthEd = DateTime.ParseExact(textBox6.Text, "yyyyMM", null);

            //対象期間(期間)
            paramWork.SalesDateSt = DateTime.ParseExact(textBox7.Text, "yyyyMMdd", null);
            paramWork.SalesDateEd = DateTime.ParseExact(textBox8.Text, "yyyyMMdd", null);

            //対象期間(当期)
            paramWork.AnnualSalesDateSt = DateTime.ParseExact(textBox9.Text, "yyyyMMdd", null);
            paramWork.AnnualSalesDateEd = DateTime.ParseExact(textBox10.Text, "yyyyMMdd", null);

            //印刷範囲指定
            paramWork.PrintRangeSt = Int32.Parse(textBox11.Text);
            paramWork.PrintRangeEd = Int32.Parse(textBox12.Text);

            //得意先コード
            paramWork.CustomerCodeSt = Int32.Parse(textBox13.Text);
            paramWork.CustomerCodeEd = Int32.Parse(textBox14.Text);

            //従業員コード
            paramWork.EmployeeCodeSt = textBox15.Text;
            paramWork.EmployeeCodeEd = textBox16.Text;

            //倉庫コード
            paramWork.WarehouseCodeSt = textBox17.Text;
            paramWork.WarehouseCodeEd = textBox18.Text;

            //商品メーカーコード
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox19.Text);
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox20.Text);

            //商品大分類コード
            paramWork.GoodsLGroupSt = Int32.Parse(textBox21.Text);
            paramWork.GoodsLGroupEd = Int32.Parse(textBox22.Text);

            //商品中分類コード
            paramWork.GoodsMGroupSt = Int32.Parse(textBox23.Text);
            paramWork.GoodsMGroupEd = Int32.Parse(textBox24.Text);

            //BLグループコード
            paramWork.BLGroupCodeSt = Int32.Parse(textBox25.Text);
            paramWork.BLGroupCodeEd = Int32.Parse(textBox26.Text);

            //BL商品コード
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox27.Text);
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox28.Text);

            //商品番号
            paramWork.GoodsNoSt = textBox29.Text;
            paramWork.GoodsNoEd = textBox30.Text;

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
                int status = salesRsltListResultDB.Search(out objResult, objParam);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();

            switch (comboBox1.SelectedIndex)
            {
                case 0:  //商品別
                default:
                    //0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：拠点
                    comboBox7.Items.Add("0：品番");
                    comboBox7.Items.Add("1：BLコード");
                    comboBox7.Items.Add("2：グループコード");
                    comboBox7.Items.Add("3：商品中分類");
                    comboBox7.Items.Add("4：商品大分類");
                    comboBox7.Items.Add("5：メーカー");
                    comboBox7.Items.Add("6：拠点");
                    comboBox7.SelectedIndex = 0;
                    break;
                case 1:  //得意先別
                    //0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：得意先　7：拠点
                    comboBox7.Items.Add("0：品番");
                    comboBox7.Items.Add("1：BLコード");
                    comboBox7.Items.Add("2：グループコード");
                    comboBox7.Items.Add("3：商品中分類");
                    comboBox7.Items.Add("4：商品大分類");
                    comboBox7.Items.Add("5：メーカー");
                    comboBox7.Items.Add("6：得意先");
                    comboBox7.Items.Add("7：拠点");
                    comboBox7.SelectedIndex = 0;
                    break;
                case 2:  //担当者別
                    //0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：担当者　7：拠点
                    comboBox7.Items.Add("0：品番");
                    comboBox7.Items.Add("1：BLコード");
                    comboBox7.Items.Add("2：グループコード");
                    comboBox7.Items.Add("3：商品中分類");
                    comboBox7.Items.Add("4：商品大分類");
                    comboBox7.Items.Add("5：メーカー");
                    comboBox7.Items.Add("6：担当者");
                    comboBox7.Items.Add("7：拠点");
                    comboBox7.SelectedIndex = 0;
                    break;
                case 3:  //倉庫別
                    //0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：拠点　7：倉庫
                    //0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：得意先　7：倉庫
                    //0：品番　1：BLコード　2：グループコード　3：商品中分類　4：商品大分類　5：メーカー　6：倉庫　7：拠点
                    comboBox7.Items.Add("0：品番");
                    comboBox7.Items.Add("1：BLコード");
                    comboBox7.Items.Add("2：グループコード");
                    comboBox7.Items.Add("3：商品中分類");
                    comboBox7.Items.Add("4：商品大分類");
                    comboBox7.Items.Add("5：メーカー");
                    comboBox7.Items.Add("6:");
                    comboBox7.Items.Add("7:");
                    comboBox7.SelectedIndex = 0;
                    break;
            }
        }

    }
}
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
        ICustSalesTargetDB custSalesTargetDB = null;
        CustSalesTargetWork custSalesTargetWork = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
            textBox2.Text = "000001";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            custSalesTargetDB = MediationCustSalesTargetDB.GetCustSalesTargetDB();

        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            ShipmGoodsOdrReportParamWork paramWork = null;

            paramWork = new ShipmGoodsOdrReportParamWork();

            // 企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            //拠点別集計区分
            //0:全社集計／1:拠点別集計
            paramWork.TtlType = comboBox2.SelectedIndex;
            
            // 拠点コード
            string[] SectionCodes = new string[4];
            SectionCodes[0] = textBox2.Text;
            SectionCodes[1] = "000002";
            paramWork.SectionCodes = SectionCodes;

            //部署管理区分
            //paramWork.SectionDiv = 2;

            //開始年月
            paramWork.SalesDateSt = Convert.ToDateTime(textBox11.Text);

            //終了年月
            paramWork.SalesDateEd = Convert.ToDateTime(textBox12.Text);

            //開始期年月
            //paramWork.AnnualAddUpYearMonthSt = Convert.ToDateTime(textBox8.Text);

            //終了期年月
            //paramWork.AnnualAddUpYaerMonthEd = Convert.ToDateTime(textBox9.Text);

            //担当従業員コード
            paramWork.SalesEmployeeCdSt = "";
            paramWork.SalesEmployeeCdEd = "";

            //得意先コード
            paramWork.CustomerCodeSt = 0;
            paramWork.CustomerCodeEd = 0;

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
        */

        /*
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
        */

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            custSalesTargetWork = new CustSalesTargetWork();
            custSalesTargetWork.EnterpriseCode = textBox1.Text;
            custSalesTargetWork.SectionCode = textBox2.Text;
            custSalesTargetWork.BusinessTypeCode = Convert.ToInt32(textBox3.Text);
            custSalesTargetWork.SalesAreaCode = Convert.ToInt32(textBox4.Text);
            custSalesTargetWork.CustomerCode = Convert.ToInt32(textBox5.Text);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(custSalesTargetWork);

            int status = custSalesTargetDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                custSalesTargetWork = (CustSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSalesTargetWork));

                Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(custSalesTargetWork);
                dataGridView2.DataSource = al;
            }		
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            ArrayList al = new ArrayList();
            SearchCustSalesTargetParaWork work = new SearchCustSalesTargetParaWork();
            work.EnterpriseCode = textBox1.Text;
            al.Add(work);
            dataGridView1.DataSource = al;

        }

        /// <summary>
        /// AddRow, 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CustSalesTargetWork _custSalesTargetWork = new  CustSalesTargetWork();
            _custSalesTargetWork.EnterpriseCode = textBox1.Text;
            _custSalesTargetWork.SectionCode = textBox2.Text;
            _custSalesTargetWork.BusinessTypeCode = Convert.ToInt32(textBox3.Text);
            _custSalesTargetWork.SalesAreaCode = Convert.ToInt32(textBox4.Text);
            _custSalesTargetWork.CustomerCode = Convert.ToInt32(textBox5.Text);

            ArrayList al = dataGridView2.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(_custSalesTargetWork);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = al;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            object parabyte = dataGridView1.DataSource;
            object objCustSalesTarget;

            int status = custSalesTargetDB.Search(out objCustSalesTarget, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objCustSalesTarget).Count.ToString() + "件";

                dataGridView2.DataSource = objCustSalesTarget;
            }

        }

        /// <summary>
        /// WriteGrid, 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            int status = custSalesTargetDB.Write(ref objCustSalesTargetWork);
            if (status != 0)
            {
                Text = "更新失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "更新成功";
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objCustSalesTargetWork;
            }		

        }

        /// <summary>
        /// LogDelGrid, 論理削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            int status = custSalesTargetDB.LogicalDelete(ref objCustSalesTargetWork);
            if (status != 0)
            {
                Text = "論理削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "論理削除成功";
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objCustSalesTargetWork;
            }
        }

        /// <summary>
        /// RevGrid, 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            int status = custSalesTargetDB.RevivalLogicalDelete(ref objCustSalesTargetWork);
            if (status != 0)
            {
                Text = "復活失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "復活成功";
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objCustSalesTargetWork;
            }
        }

        /// <summary>
        /// DelGrid, 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            CustSalesTargetWork[] trarray = (CustSalesTargetWork[])((ArrayList)dataGridView2.DataSource).ToArray(typeof(CustSalesTargetWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = custSalesTargetDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再削除してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
                dataGridView2.DataSource = null;
            }
        }

    }
}
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
        ISalesOrderRemainClearDB salesOrderRemainClearDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesOrderRemainClearDB = MediationSalesOrderRemainClearDB.GetSalesOrderRemainClearDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtrInfo_SalesOrderRemainClearWork extrInfo_SalesOrderRemainClearWork = null;

            extrInfo_SalesOrderRemainClearWork = new ExtrInfo_SalesOrderRemainClearWork();

            // 企業コード
            extrInfo_SalesOrderRemainClearWork.EnterpriseCode = textBox1.Text;

            extrInfo_SalesOrderRemainClearWork.St_WarehouseCode = textBox2.Text;
            extrInfo_SalesOrderRemainClearWork.Ed_WarehouseCode = textBox3.Text;

            if (textBox6.Text.Trim() != string.Empty)
            {
                extrInfo_SalesOrderRemainClearWork.St_SupplierCd = Convert.ToInt32(textBox6.Text);
            }
            if (textBox7.Text.Trim() != string.Empty)
            {
                extrInfo_SalesOrderRemainClearWork.Ed_SupplierCd = Convert.ToInt32(textBox7.Text);
            }

            if (textBox10.Text.Trim() != string.Empty)
            {
                extrInfo_SalesOrderRemainClearWork.St_GoodsMakerCd = Convert.ToInt32(textBox10.Text);
            }
            if (textBox13.Text.Trim() != string.Empty)
            {
                extrInfo_SalesOrderRemainClearWork.Ed_GoodsMakerCd = Convert.ToInt32(textBox13.Text);
            }
            if (textBox14.Text.Trim() != string.Empty)
            {
                extrInfo_SalesOrderRemainClearWork.St_BLGoodsCode = Convert.ToInt32(textBox14.Text);
            }
            if (textBox15.Text.Trim() != string.Empty)
            {
                extrInfo_SalesOrderRemainClearWork.Ed_BLGoodsCode = Convert.ToInt32(textBox15.Text);
            }

            ArrayList al = new ArrayList();
            al.Add(extrInfo_SalesOrderRemainClearWork);
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

                int status = salesOrderRemainClearDB.SearchUpdate(objParam);
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
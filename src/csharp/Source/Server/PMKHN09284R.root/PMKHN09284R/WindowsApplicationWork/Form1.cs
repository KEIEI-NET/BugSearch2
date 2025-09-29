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
        IStockMasterTblDB stockMasterTblDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockMasterTblDB = MediationStockMasterTblDB.GetStockMasterTblDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtrInfo_StockMasterTblWork extrInfo_StockMasterTblWork = null;

            extrInfo_StockMasterTblWork = new ExtrInfo_StockMasterTblWork();

            // 企業コード
            extrInfo_StockMasterTblWork.EnterpriseCode = textBox1.Text;

            extrInfo_StockMasterTblWork.St_WarehouseCode = textBox2.Text;
            extrInfo_StockMasterTblWork.Ed_WarehouseCode = textBox3.Text;

            extrInfo_StockMasterTblWork.St_WarehouseShelfNo = textBox4.Text;
            extrInfo_StockMasterTblWork.Ed_WarehouseShelfNo = textBox5.Text;

            if (textBox6.Text.Trim() != string.Empty)
            {
                extrInfo_StockMasterTblWork.St_SupplierCd = Convert.ToInt32(textBox6.Text);
            }
            if (textBox7.Text.Trim() != string.Empty)
            {
                extrInfo_StockMasterTblWork.Ed_SupplierCd = Convert.ToInt32(textBox7.Text);
            }

            if (textBox10.Text.Trim() != string.Empty)
            {
                extrInfo_StockMasterTblWork.St_GoodsMakerCd = Convert.ToInt32(textBox10.Text);
            }
            if (textBox13.Text.Trim() != string.Empty)
            {
                extrInfo_StockMasterTblWork.Ed_GoodsMakerCd = Convert.ToInt32(textBox13.Text);
            }
            if (textBox14.Text.Trim() != string.Empty)
            {
                extrInfo_StockMasterTblWork.St_BLGoodsCode = Convert.ToInt32(textBox14.Text);
            }
            if (textBox15.Text.Trim() != string.Empty)
            {
                extrInfo_StockMasterTblWork.Ed_BLGoodsCode = Convert.ToInt32(textBox15.Text);
            }
            extrInfo_StockMasterTblWork.St_GoodsNo = textBox11.Text;
            extrInfo_StockMasterTblWork.Ed_GoodsNo = textBox12.Text;

            extrInfo_StockMasterTblWork.St_GoodsLGroup = 0;
            extrInfo_StockMasterTblWork.Ed_GoodsLGroup = 1;
            extrInfo_StockMasterTblWork.St_GoodsMGroup = 0;
            extrInfo_StockMasterTblWork.Ed_GoodsMGroup = 1;
            extrInfo_StockMasterTblWork.St_BLGroupCode = 0;
            extrInfo_StockMasterTblWork.Ed_BLGroupCode = 1;

            ArrayList al = new ArrayList();
            al.Add(extrInfo_StockMasterTblWork);
            dataGridView2.DataSource = al;

            Search();


        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;

            object objResult = null;

            RsltInfo_StockMasterTblWork rsltInfo_StockMasterTblWork = new RsltInfo_StockMasterTblWork();

            objResult = (object)rsltInfo_StockMasterTblWork;
            try
            {
                dataGridView1.DataSource = null;

                int status = stockMasterTblDB.Search(out objResult, objParam);
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
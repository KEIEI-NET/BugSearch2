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
        IInventoryDtDspDB inventoryDtDspDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
            MKCD.Text = "1";
            WH01.Text = "0001";
            WH02.Text = "0002";
            WH03.Text = "0003";
            WH04.Text = "0004";
            WH05.Text = "0005";
            WH06.Text = "0006";
            WH07.Text = "0007";
            WH08.Text = "0008";
            WH09.Text = "0009";
            WH10.Text = "0010";

            //倉庫区分
            comboBox1.Items.Add("0:範囲");
            comboBox1.Items.Add("1:単独");
            comboBox1.SelectedIndex = 0;

            // 表示区分
            comboBox2.Items.Add("0:全て");
            comboBox2.Items.Add("1:自社在庫");
            comboBox2.Items.Add("2:受託在庫");
            comboBox2.SelectedIndex = 0;

            // 表示タイプ
            comboBox3.Items.Add("0:通常");
            comboBox3.Items.Add("1:ｱｲﾃﾑ数=0はｶｳﾝﾄしない");
            comboBox3.Items.Add("2:最大");
            comboBox3.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            inventoryDtDspDB = MediationInventoryDtDspDB.GetInventoryDtDspDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InventoryDataDspParamWork inventoryDataDspParamWork = null;

            inventoryDataDspParamWork = new InventoryDataDspParamWork();
            // 企業コード
            inventoryDataDspParamWork.EnterpriseCode = textBox1.Text;
            // 商品メーカーコード
            inventoryDataDspParamWork.GoodsMakerCd = Convert.ToInt32(MKCD.Text);
            //倉庫指定区分 0:範囲,1:単独
            inventoryDataDspParamWork.WarehouseDiv = comboBox1.SelectedIndex;
            //開始倉庫コード
            inventoryDataDspParamWork.StWarehouseCode = STWH.Text;
            //終了倉庫コード
            inventoryDataDspParamWork.EdWarehouseCode = EDWH.Text;
            //倉庫コード01
            inventoryDataDspParamWork.WarehouseCd01 = WH01.Text;
            //倉庫コード02
            inventoryDataDspParamWork.WarehouseCd02 = WH02.Text;
            //倉庫コード03
            inventoryDataDspParamWork.WarehouseCd03 = WH03.Text;
            //倉庫コード04
            inventoryDataDspParamWork.WarehouseCd04 = WH04.Text;
            //倉庫コード05
            inventoryDataDspParamWork.WarehouseCd05 = WH05.Text;
            //倉庫コード06
            inventoryDataDspParamWork.WarehouseCd06 = WH06.Text;
            //倉庫コード07
            inventoryDataDspParamWork.WarehouseCd07 = WH07.Text;
            //倉庫コード08
            inventoryDataDspParamWork.WarehouseCd08 = WH08.Text;
            //倉庫コード09
            inventoryDataDspParamWork.WarehouseCd09 = WH09.Text;
            //倉庫コード10
            inventoryDataDspParamWork.WarehouseCd10 = WH10.Text;
            //表示区分
            inventoryDataDspParamWork.ListDiv = comboBox2.SelectedIndex;
            //表示タイプ
            inventoryDataDspParamWork.ListTypeDiv = comboBox3.SelectedIndex;
            ArrayList al = new ArrayList();
            al.Add(inventoryDataDspParamWork);
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

                int status = inventoryDtDspDB.Search(out objResult, objParam);

                if (status != 0)
                {
                    Text = "該当データ無し ST=" + Convert.ToString(status);
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                STWH.Enabled = true;
                EDWH.Enabled = true;
                WH01.Enabled = false;
                WH02.Enabled = false;
                WH03.Enabled = false;
                WH04.Enabled = false;
                WH05.Enabled = false;
                WH06.Enabled = false;
                WH07.Enabled = false;
                WH08.Enabled = false;
                WH09.Enabled = false;
                WH10.Enabled = false;
                WH01.Text = "";
                WH02.Text = "";
                WH03.Text = "";
                WH04.Text = "";
                WH05.Text = "";
                WH06.Text = "";
                WH07.Text = "";
                WH08.Text = "";
                WH09.Text = "";
                WH10.Text = "";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                STWH.Enabled = false;
                EDWH.Enabled = false;
                WH01.Enabled = true;
                WH02.Enabled = true;
                WH03.Enabled = true;
                WH04.Enabled = true;
                WH05.Enabled = true;
                WH06.Enabled = true;
                WH07.Enabled = true;
                WH08.Enabled = true;
                WH09.Enabled = true;
                WH10.Enabled = true;
                WH01.Text = "0001";
                WH02.Text = "0002";
                WH03.Text = "0003";
                WH04.Text = "0004";
                WH05.Text = "0005";
                WH06.Text = "0006";
                WH07.Text = "0007";
                WH08.Text = "0008";
                WH09.Text = "0009";
                WH10.Text = "0010";

            }
        }
    }
}
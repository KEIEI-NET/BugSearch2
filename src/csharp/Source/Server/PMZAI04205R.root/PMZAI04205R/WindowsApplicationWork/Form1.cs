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

            //�q�ɋ敪
            comboBox1.Items.Add("0:�͈�");
            comboBox1.Items.Add("1:�P��");
            comboBox1.SelectedIndex = 0;

            // �\���敪
            comboBox2.Items.Add("0:�S��");
            comboBox2.Items.Add("1:���Ѝ݌�");
            comboBox2.Items.Add("2:����݌�");
            comboBox2.SelectedIndex = 0;

            // �\���^�C�v
            comboBox3.Items.Add("0:�ʏ�");
            comboBox3.Items.Add("1:���ѐ�=0�Ͷ��Ă��Ȃ�");
            comboBox3.Items.Add("2:�ő�");
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
            // ��ƃR�[�h
            inventoryDataDspParamWork.EnterpriseCode = textBox1.Text;
            // ���i���[�J�[�R�[�h
            inventoryDataDspParamWork.GoodsMakerCd = Convert.ToInt32(MKCD.Text);
            //�q�Ɏw��敪 0:�͈�,1:�P��
            inventoryDataDspParamWork.WarehouseDiv = comboBox1.SelectedIndex;
            //�J�n�q�ɃR�[�h
            inventoryDataDspParamWork.StWarehouseCode = STWH.Text;
            //�I���q�ɃR�[�h
            inventoryDataDspParamWork.EdWarehouseCode = EDWH.Text;
            //�q�ɃR�[�h01
            inventoryDataDspParamWork.WarehouseCd01 = WH01.Text;
            //�q�ɃR�[�h02
            inventoryDataDspParamWork.WarehouseCd02 = WH02.Text;
            //�q�ɃR�[�h03
            inventoryDataDspParamWork.WarehouseCd03 = WH03.Text;
            //�q�ɃR�[�h04
            inventoryDataDspParamWork.WarehouseCd04 = WH04.Text;
            //�q�ɃR�[�h05
            inventoryDataDspParamWork.WarehouseCd05 = WH05.Text;
            //�q�ɃR�[�h06
            inventoryDataDspParamWork.WarehouseCd06 = WH06.Text;
            //�q�ɃR�[�h07
            inventoryDataDspParamWork.WarehouseCd07 = WH07.Text;
            //�q�ɃR�[�h08
            inventoryDataDspParamWork.WarehouseCd08 = WH08.Text;
            //�q�ɃR�[�h09
            inventoryDataDspParamWork.WarehouseCd09 = WH09.Text;
            //�q�ɃR�[�h10
            inventoryDataDspParamWork.WarehouseCd10 = WH10.Text;
            //�\���敪
            inventoryDataDspParamWork.ListDiv = comboBox2.SelectedIndex;
            //�\���^�C�v
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
                    Text = "�Y���f�[�^���� ST=" + Convert.ToString(status);
                }
                else
                {
                    // XML�̓ǂݍ���
                    Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)objResult).Count.ToString() + "��";

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
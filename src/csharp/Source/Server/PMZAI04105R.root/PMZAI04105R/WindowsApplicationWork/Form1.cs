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
        IStockHisDspDB stockHisDspDB = null;

        public Form1()
        {
            InitializeComponent();
            //textBox1.Text = "0101150800511000";
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            //textBox3.Text = "04437-52310";
            textBox3.Text = "TEST-001";
            textBox4.Text = "1";
            textBox5.Text = "0001";
            textBox6.Text = "200709";
            textBox7.Text = "200810";
            textBox9.Text = "20081101";
            textBox8.Text = "20081128";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockHisDspDB = MediationStockHisDspDB.GetStockHisDspDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockHistoryDspSearchParamWork stockHistoryDspSearchParamWork = null;

            stockHistoryDspSearchParamWork = new StockHistoryDspSearchParamWork();

            //��ƃR�[�h
            stockHistoryDspSearchParamWork.EnterpriseCode = textBox1.Text;

            //�i��
            stockHistoryDspSearchParamWork.GoodsNo = textBox3.Text;

            //���[�J�[
            stockHistoryDspSearchParamWork.GoodsMakerCd = Convert.ToInt32(textBox4.Text);

            //�q��
            stockHistoryDspSearchParamWork.WarehouseCode = textBox5.Text;

            //�J�n�N��
            stockHistoryDspSearchParamWork.StAddUpYearMonth = Convert.ToInt32(textBox6.Text);

            //�I���N��
            stockHistoryDspSearchParamWork.EdAddUpYearMonth = Convert.ToInt32(textBox7.Text);

            // �J�n�N����
            stockHistoryDspSearchParamWork.StAddUpADate = Convert.ToInt32(textBox9.Text);

            // �I���N����
            stockHistoryDspSearchParamWork.EdAddUpADate = Convert.ToInt32(textBox8.Text);

            ArrayList al = new ArrayList();

            al.Add(stockHistoryDspSearchParamWork);

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

                int status = stockHisDspDB.Search(out objResult, objParam);
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

    }
}
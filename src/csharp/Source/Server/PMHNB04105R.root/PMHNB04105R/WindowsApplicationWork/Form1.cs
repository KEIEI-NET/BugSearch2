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
        ISPartsDspDB sPartsDspDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text  = "0101150842020000";
            textBox2.Text  = "01";
            textBox11.Text = "200801";
            textBox12.Text = "200812";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            sPartsDspDB = MediationSPartsDspDB.GetSPartsDspDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmentPartsDspParamWork shipmentPartsDspParamWork = null;

            shipmentPartsDspParamWork = new ShipmentPartsDspParamWork();

            // ��ƃR�[�h
            shipmentPartsDspParamWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            shipmentPartsDspParamWork.SectionCode = textBox2.Text;

            // �J�n�N��
            shipmentPartsDspParamWork.StAddUpYearMonth = Convert.ToInt32(textBox11.Text);

            // �I���N��
            shipmentPartsDspParamWork.EdAddUpYearMonth = Convert.ToInt32(textBox12.Text);

            ArrayList al = new ArrayList();
            al.Add(shipmentPartsDspParamWork);
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
                int status = sPartsDspDB.Search(out objResult, objParam);
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
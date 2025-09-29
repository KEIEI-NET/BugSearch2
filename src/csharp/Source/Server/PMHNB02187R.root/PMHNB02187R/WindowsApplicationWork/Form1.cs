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
        ICustSalesDistributionReportResultDB custSalesDistributionReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //�W�v�P��
            //0:���Ӑ� 1:�S���� 2:�n��
            comboBox1.Items.Add("0:���Ӑ�");
            comboBox1.Items.Add("1:�S����");
            comboBox1.Items.Add("2:�n��");
            comboBox1.SelectedIndex = 0;

            //�W�v���@
            comboBox2.Items.Add("0:����");
            comboBox2.Items.Add("1:���Ȃ�");
            comboBox2.SelectedIndex = 0;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            custSalesDistributionReportResultDB = MediationCustSalesDistributionReportResultDB.GetCustSalesDistributionReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustSalesDistributionReportParamWork paramWork = null;

            paramWork = new CustSalesDistributionReportParamWork();

            //��ƃR�[�h
            paramWork.EnterpriseCode = textBox1.Text;

            //���_�R�[�h
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCode = SectionCodes;

            //���s�^�C�v
            paramWork.PrintDiv = comboBox1.SelectedIndex;

            //���яW�v�敪
            paramWork.SearchDiv = comboBox2.SelectedIndex;

            //�Ώۓ��t
            paramWork.StSalesDate = Int32.Parse(textBox3.Text);
            paramWork.EdSalesDate = Int32.Parse(textBox4.Text);


            //���Ӑ�R�[�h
            paramWork.StCustomerCode = Int32.Parse(textBox7.Text);
            paramWork.EdCustomerCode = Int32.Parse(textBox8.Text);

            //�]�ƈ��R�[�h
            paramWork.StSalesEmployeeCd = textBox9.Text;
            paramWork.EdSalesEmployeeCd = textBox10.Text;

            //�n��R�[�h
            paramWork.StSalesAreaCode = Int32.Parse(textBox11.Text);
            paramWork.EdSalesAreaCode = Int32.Parse(textBox12.Text);


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
                int status = custSalesDistributionReportResultDB.Search(out objResult, objParam);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
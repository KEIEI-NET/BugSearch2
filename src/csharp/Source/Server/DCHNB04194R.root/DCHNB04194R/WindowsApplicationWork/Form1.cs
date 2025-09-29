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
using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;

namespace WindowsApplicationWork
{
    public partial class Form1 : Form
    {
        ISalesAnnualDataSelectResultDB salesAnnualDataSelectResultDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            textBox3.Text = "1";
            textBox8.Text = "200801";
            textBox9.Text = "200812";
            textBox7.Text = "20080821";
            textBox10.Text = "20080920";
            textBox11.Text = "20080820";
            textBox12.Text = "20080820";
            textBox13.Text = "200809";
            
            //0:���_,1:���Ӑ�,2:�S����,3:�󒍎�,4:���s��,5:�n��,6:�Ǝ�
            comboBox1.Items.Add("0:���_");
            comboBox1.Items.Add("1:���Ӑ�");
            comboBox1.Items.Add("2:�S����");
            comboBox1.Items.Add("3:�n��");
            comboBox1.Items.Add("4:�Ǝ�");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("0:�N�x����");
            comboBox2.Items.Add("1:�c���Ɖ�(�����E����)");
            comboBox2.Items.Add("2:�c���Ɖ�(������������)");
            comboBox2.SelectedIndex = 0;

            comboBox3.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesAnnualDataSelectResultDB = MediationSalesAnnualDataSelectResultDB.GetSalesAnnualDataSelectResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = null;

            salesAnnualDataSelectParamWork = new SalesAnnualDataSelectParamWork();

            // ��ƃR�[�h
            salesAnnualDataSelectParamWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            salesAnnualDataSelectParamWork.SectionCode = textBox2.Text;

            //���Ӑ�R�[�h
            salesAnnualDataSelectParamWork.CustomerCode = textBox3.Text == "" ? 0 : Convert.ToInt32(textBox3.Text);
            
            //�]�ƈ��R�[�h
            salesAnnualDataSelectParamWork.EmployeeCode = textBox4.Text;

            //�̔��G���A�R�[�h
            salesAnnualDataSelectParamWork.SalesAreaCode = textBox5.Text=="" ? 0 : Convert.ToInt32(textBox5.Text);

            //�Ǝ�R�[�h
            salesAnnualDataSelectParamWork.BusinessTypeCode = textBox6.Text=="" ? 0 : Convert.ToInt32(textBox6.Text);

            //�J�n�N��
            salesAnnualDataSelectParamWork.YearMonthSt = textBox8.Text == "" ? 200801 : Convert.ToInt32(textBox8.Text);

            //�I���N��
            salesAnnualDataSelectParamWork.YearMonthEd = textBox9.Text == "" ? 200812 : Convert.ToInt32(textBox9.Text);

            //�W�v�敪
            salesAnnualDataSelectParamWork.TotalDiv = comboBox1.SelectedIndex;

            //�����敪
            salesAnnualDataSelectParamWork.SearchDiv = comboBox2.SelectedIndex;

            // �]�ƈ��敪
            int EmployeeDiv = 10;
            if (comboBox3.SelectedIndex == 0)
            {
                EmployeeDiv = 10;
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                EmployeeDiv = 20;

            }
            else
            {
                EmployeeDiv = 30;
            }

            salesAnnualDataSelectParamWork.EmployeeDivCd = EmployeeDiv;
            

            // �v��N����           
            salesAnnualDataSelectParamWork.StAddUpDate = Convert.ToInt32(textBox7.Text);
            salesAnnualDataSelectParamWork.EdAddUpDate = Convert.ToInt32(textBox10.Text);

            ArrayList al = new ArrayList();
            al.Add(salesAnnualDataSelectParamWork);
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
                int status = salesAnnualDataSelectResultDB.Search(out objResult, objParam);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SalesAnnualDataSelectParamWork salesAnnualDataSelectParamWork = null;

            salesAnnualDataSelectParamWork = new SalesAnnualDataSelectParamWork();

            // ��ƃR�[�h
            salesAnnualDataSelectParamWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            salesAnnualDataSelectParamWork.SectionCode = textBox2.Text;

            //���Ӑ�R�[�h
            salesAnnualDataSelectParamWork.CustomerCode = textBox3.Text == "" ? 0 : Convert.ToInt32(textBox3.Text);

            //�]�ƈ��R�[�h
            salesAnnualDataSelectParamWork.EmployeeCode = textBox4.Text;

            //�̔��G���A�R�[�h
            salesAnnualDataSelectParamWork.SalesAreaCode = textBox5.Text == "" ? 0 : Convert.ToInt32(textBox5.Text);

            //�Ǝ�R�[�h
            salesAnnualDataSelectParamWork.BusinessTypeCode = textBox6.Text == "" ? 0 : Convert.ToInt32(textBox6.Text);

            //�J�n�N��
            salesAnnualDataSelectParamWork.YearMonthSt = textBox8.Text == "" ? 200801 : Convert.ToInt32(textBox8.Text);

            //�I���N��
            salesAnnualDataSelectParamWork.YearMonthEd = textBox9.Text == "" ? 200812 : Convert.ToInt32(textBox9.Text);

            //�W�v�敪
            salesAnnualDataSelectParamWork.TotalDiv = comboBox1.SelectedIndex;

            //�����敪
            salesAnnualDataSelectParamWork.SearchDiv = comboBox2.SelectedIndex;

            // �]�ƈ��敪
            int EmployeeDiv = 10;
            if (comboBox3.SelectedIndex == 0)
            {
                EmployeeDiv = 10;
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                EmployeeDiv = 20;

            }
            else
            {
                EmployeeDiv = 30;
            }

            salesAnnualDataSelectParamWork.EmployeeDivCd = EmployeeDiv;



            // �W�v�N����           
            salesAnnualDataSelectParamWork.StAddUpDate = Convert.ToInt32(textBox7.Text);
            salesAnnualDataSelectParamWork.EdAddUpDate = Convert.ToInt32(textBox10.Text);

            //���Ӑ����
            salesAnnualDataSelectParamWork.CustTotalDay = Convert.ToInt32(textBox11.Text);
            //���В���
            salesAnnualDataSelectParamWork.SecTotalDay = Convert.ToInt32(textBox12.Text);
            //�v��N��
            salesAnnualDataSelectParamWork.AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM",Convert.ToInt32(textBox13.Text));


            ArrayList al = new ArrayList();
            al.Add(salesAnnualDataSelectParamWork);
            dataGridView2.DataSource = al;

            CustSearch();

        }

        private void CustSearch()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                dataGridView1.DataSource = null;
                int status = salesAnnualDataSelectResultDB.CustSearch(out objResult, objParam);
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
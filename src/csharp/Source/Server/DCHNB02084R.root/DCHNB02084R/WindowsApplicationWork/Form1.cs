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
        ISalesMonthYearReportResultDB salesMonthYearReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //�W�v�P��
            //0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:���s�ҕ� 4:�n��� 5:�Ǝ�� 6:�̔��敪��
            comboBox1.Items.Add("0:���Ӑ��");
            comboBox1.Items.Add("1:�S���ҕ�");
            comboBox1.Items.Add("2:�󒍎ҕ�");
            comboBox1.Items.Add("3:���s�ҕ�");
            comboBox1.Items.Add("4:�n���");
            comboBox1.Items.Add("5:�Ǝ��");
            comboBox1.Items.Add("6:�̔��敪��");
            comboBox1.SelectedIndex = 0;

            //�W�v���@
            //0:�S�� 1:���_��
            comboBox2.Items.Add("0:�S��");
            comboBox2.Items.Add("1:���_��");
            comboBox2.SelectedIndex = 0;

            //����^�C�v
            //0:���� 1:���� 2:����������
            comboBox3.Items.Add("0:����");
            comboBox3.Items.Add("1:����");
            comboBox3.Items.Add("2:����������");
            comboBox3.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesMonthYearReportResultDB = MediationSalesMonthYearReportResultDB.GetSalesMonthYearReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesMonthYearReportParamWork salesMonthYearReportParamWork = null;

            salesMonthYearReportParamWork = new SalesMonthYearReportParamWork();

            #region [Old]
            /*
            // ��ƃR�[�h
            salesMonthYearReportParamWork.EnterpriseCode = textBox1.Text;

            //���_�ʏW�v�敪
            //0:�S�ЏW�v�^1:���_�ʏW�v
            salesMonthYearReportParamWork.TtlType = comboBox2.SelectedIndex;
            
            // ���_�R�[�h
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            SectionCodes[1] = "";
            salesMonthYearReportParamWork.SectionCodes = SectionCodes;

            //�����Ǘ��敪
            salesMonthYearReportParamWork.SectionDiv = 2;

            //�J�n�N��
            salesMonthYearReportParamWork.AddUpYearMonthSt = Convert.ToDateTime(textBox11.Text);

            //�I���N��
            salesMonthYearReportParamWork.AddUpYearMonthEd = Convert.ToDateTime(textBox12.Text);

            //�J�n���N��
            salesMonthYearReportParamWork.AnnualAddUpYearMonthSt = Convert.ToDateTime(textBox8.Text);

            //�I�����N��
            salesMonthYearReportParamWork.AnnualAddUpYaerMonthEd = Convert.ToDateTime(textBox9.Text);

            //�S���]�ƈ��R�[�h
            salesMonthYearReportParamWork.SalesEmployeeCdSt = "";
            salesMonthYearReportParamWork.SalesEmployeeCdEd = "";

            //���Ӑ�R�[�h
            salesMonthYearReportParamWork.CustomerCodeSt = 0;
            salesMonthYearReportParamWork.CustomerCodeEd = 0;

            //���i���[�J�[�R�[�h
            salesMonthYearReportParamWork.GoodsMakerCdSt = 0;
            salesMonthYearReportParamWork.GoodsMakerCdEd = 0;


            //�W�v�敪
            salesMonthYearReportParamWork.TotalType = comboBox1.SelectedIndex;
             */
            #endregion

            //��ƃR�[�h
            salesMonthYearReportParamWork.EnterpriseCode = textBox1.Text;
            
            //���_�R�[�h
            string[] SectionCodes = new string[2];
            if (textBox2.Text != "")
            {
                SectionCodes[0] = textBox2.Text;
            }
            else
            {
                SectionCodes = null;
            }
            salesMonthYearReportParamWork.SectionCodes = SectionCodes;
            
            //�J�n�Ώ۔N��(����)
            salesMonthYearReportParamWork.AddUpYearMonthSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            //�I���Ώ۔N��(����)
            salesMonthYearReportParamWork.AddUpYearMonthEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);

            //�J�n�Ώ۔N��(����)
            salesMonthYearReportParamWork.AnnualAddUpYearMonthSt = DateTime.ParseExact(textBox10.Text, "yyyyMM", null);
            //�I���Ώ۔N��(����)
            salesMonthYearReportParamWork.AnnualAddUpYaerMonthEd = DateTime.ParseExact(textBox11.Text, "yyyyMM", null);


            salesMonthYearReportParamWork.TotalType = comboBox1.SelectedIndex;          //�W�v�P��
            salesMonthYearReportParamWork.TtlType = comboBox2.SelectedIndex;            //�W�v���@
            salesMonthYearReportParamWork.PrintType = comboBox3.SelectedIndex;          //����^�C�v
            salesMonthYearReportParamWork.OutType = Int32.Parse(textBox9.Text);         //�o�͏�
            salesMonthYearReportParamWork.CustomerCodeSt = Int32.Parse(textBox5.Text);  //�J�n���Ӑ�R�[�h
            salesMonthYearReportParamWork.CustomerCodeEd = Int32.Parse(textBox6.Text);  //�I�����Ӑ�R�[�h
            salesMonthYearReportParamWork.SrchCodeSt = textBox7.Text;                   //�J�n�����R�[�h
            salesMonthYearReportParamWork.SrchCodeEd = textBox8.Text;                   //�I�������R�[�h

            ArrayList al = new ArrayList();
            al.Add(salesMonthYearReportParamWork);
            dataGridView2.DataSource = al;

            Search();
        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = salesMonthYearReportResultDB.Search(out objResult, objParam);
                if (status != 0)
                {
                    Text = "�Y���f�[�^����";
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
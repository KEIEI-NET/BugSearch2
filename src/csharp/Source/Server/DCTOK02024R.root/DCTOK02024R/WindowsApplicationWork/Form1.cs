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
        ISalesDayMonthReportResultDB salesDayMonthReportResultDB = null;
        
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesDayMonthReportResultDB = MediationSalesDayMonthReportResultDB.GetSalesDayMonthReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region [old]
            /*
            SalesDayMonthReportParamWork salesDayMonthReportParamWork = null;

            salesDayMonthReportParamWork = new SalesDayMonthReportParamWork();

            // ��ƃR�[�h
            salesDayMonthReportParamWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            salesDayMonthReportParamWork.SectionCodes = SectionCodes;

            //�W�v���@
            salesDayMonthReportParamWork.TtlType = comboBox2.SelectedIndex;

            //�S���]�ƈ��R�[�h
            salesDayMonthReportParamWork.SalesEmployeeCdSt = "";
            salesDayMonthReportParamWork.SalesEmployeeCdEd = "";

            //�󒍏]�ƈ��R�[�h
            salesDayMonthReportParamWork.FrontEmployeeCdSt = "";
            salesDayMonthReportParamWork.FrontEmployeeCdEd = "";

            //���s�]�ƈ��R�[�h
            salesDayMonthReportParamWork.SalesInputCodeSt = "";
            salesDayMonthReportParamWork.SalesInputCodeEd = "";

            //�̔��G���A�R�[�h
            salesDayMonthReportParamWork.SalesAreaCodeSt = 0;
            salesDayMonthReportParamWork.SalesAreaCodeEd = 0;

            //�Ǝ�R�[�h
            salesDayMonthReportParamWork.BusinessTypeCodeSt = 0;
            salesDayMonthReportParamWork.BusinessTypeCodeEd = 0;

            //�J�n�N����
            salesDayMonthReportParamWork.SalesDateSt = Convert.ToDateTime(textBox11.Text);

            //�I���N����
            salesDayMonthReportParamWork.SalesDateEd = Convert.ToDateTime(textBox12.Text);

            //�J�n�N��
            salesDayMonthReportParamWork.MonthReportDateSt = Convert.ToDateTime(textBox8.Text);

            //�I���N��
            salesDayMonthReportParamWork.MonthReportDateEd = Convert.ToDateTime(textBox9.Text);

            //���ԖڕW��
            salesDayMonthReportParamWork.TargetMonth = Convert.ToDateTime(textBox7.Text.Substring(0, 7));

            //�W�v�敪
            salesDayMonthReportParamWork.TotalType = comboBox1.SelectedIndex;
            */
            #endregion

            SalesDayMonthReportParamWork salesDayMonthReportParamWork = null;

            salesDayMonthReportParamWork = new SalesDayMonthReportParamWork();

            //��ƃR�[�h
            salesDayMonthReportParamWork.EnterpriseCode = textBox1.Text;

            //���_�R�[�h
            string[] SectionCodes = new string[2];
            if (textBox2.Text == "")
            {
                SectionCodes = null;
            }
            else
            {
                SectionCodes[0] = textBox2.Text;
            }
            salesDayMonthReportParamWork.SectionCodes = SectionCodes;

            //�J�n�Ώۓ��t(����)
            salesDayMonthReportParamWork.SalesDateSt = DateTime.ParseExact(textBox3.Text, "yyyyMMdd", null);
            //�I���Ώۓ��t(����)
            salesDayMonthReportParamWork.SalesDateEd = DateTime.ParseExact(textBox4.Text, "yyyyMMdd", null);
            //�J�n�Ώۓ��t(����)
            salesDayMonthReportParamWork.MonthReportDateSt = DateTime.ParseExact(textBox5.Text, "yyyyMMdd", null);
            //�I���Ώۓ��t(����)
            salesDayMonthReportParamWork.MonthReportDateEd = DateTime.ParseExact(textBox6.Text, "yyyyMMdd", null);

            salesDayMonthReportParamWork.TotalType = comboBox1.SelectedIndex;          //�W�v�P��
            salesDayMonthReportParamWork.TtlType = comboBox2.SelectedIndex;            //�W�v���@
            salesDayMonthReportParamWork.OutType = Int32.Parse(textBox11.Text);        //�o�͏�

            salesDayMonthReportParamWork.CustomerCodeSt = Int32.Parse(textBox7.Text);  //�J�n���Ӑ�R�[�h
            salesDayMonthReportParamWork.CustomerCodeEd = Int32.Parse(textBox8.Text);  //�I�����Ӑ�R�[�h
            salesDayMonthReportParamWork.SrchCodeSt = textBox9.Text;                   //�J�n�����R�[�h
            salesDayMonthReportParamWork.SrchCodeEd = textBox10.Text;                  //�I�������R�[�h

            ArrayList al = new ArrayList();
            al.Add(salesDayMonthReportParamWork);
            dataGridView2.DataSource = al;

            Search();
        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = salesDayMonthReportResultDB.Search(out objResult, objParam);
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
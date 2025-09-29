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
        IStockMonthYearReportResultDB stockMonthYearReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
            textBox2.Text = "000001";
            //textBox7.Text = "0";
            textBox8.Text = "2007/01";
            textBox9.Text = "2007/12";
            //textBox10.Text = "1";
            textBox11.Text = "2007/01";
            textBox12.Text = "2007/01";
            comboBox1.Items.Add("0:���_��");
            comboBox1.Items.Add("1:�d�����");
            comboBox1.Items.Add("2:�S���ҕ�");
            comboBox1.Items.Add("3:������");
            comboBox1.Items.Add("4:���[�J�[��");
            comboBox1.Items.Add("5:�d����ʃ��[�J�[��");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("0: �S��");
            comboBox2.Items.Add("1: ���_��");
            comboBox2.SelectedIndex = 1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockMonthYearReportResultDB = MediationStockMonthYearReportResultDB.GetStockMonthYearReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockMonthYearReportParamWork paramWork = null;

            paramWork = new StockMonthYearReportParamWork();

            // ��ƃR�[�h
            paramWork.EnterpriseCode = textBox1.Text;

            //���_�ʏW�v�敪
            //0:�S�ЏW�v�^1:���_�ʏW�v
            paramWork.TtlType = comboBox2.SelectedIndex;
            
            // ���_�R�[�h
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            SectionCodes[1] = "000002";
            paramWork.SectionCodes = SectionCodes;

            //�����Ǘ��敪
            paramWork.SectionDiv = 2;

            //�J�n�N��
            paramWork.StockDateYmSt = Convert.ToDateTime(textBox11.Text);

            //�I���N��
            paramWork.StockDateYmEd = Convert.ToDateTime(textBox12.Text);

            //�J�n���N��
            paramWork.AnnualStockDateYmSt = Convert.ToDateTime(textBox8.Text);

            //�I�����N��
            paramWork.AnnualStockDateYmEd = Convert.ToDateTime(textBox9.Text);

            //�S���]�ƈ��R�[�h
            paramWork.EmployeeCodeSt = "";
            paramWork.EmployeeCodeEd = "";

            //�d����R�[�h
            paramWork.SupplierCdSt = 0;
            paramWork.SupplierCdEd = 0;

            //���i���[�J�[�R�[�h
            paramWork.GoodsMakerCdSt = 0;
            paramWork.GoodsMakerCdEd = 0;


            //�W�v�敪
            paramWork.TotalType = comboBox1.SelectedIndex;


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
                int status = stockMonthYearReportResultDB.Search(out objResult, objParam);
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
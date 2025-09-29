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
        ISalesTransListResultDB salesTransListResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //�W�v�P��
            //0:���i�� 1:���Ӑ�� 2:�S���ҕ� 3:�q�ɕ�
            comboBox1.Items.Add("0:���i��");
            comboBox1.Items.Add("1:���Ӑ��");
            comboBox1.Items.Add("2:�S���ҕ�");
            comboBox1.Items.Add("3:�q�ɕ�");
            comboBox1.SelectedIndex = 0;

            //�W�v���@
            comboBox2.Items.Add("0:�S��");
            comboBox2.Items.Add("1:���_��");
            comboBox2.SelectedIndex = 0;

            //�݌Ɏ�񂹋敪
            //0:���v 1:�݌�, 2:���
            comboBox3.Items.Add("0:���v");
            comboBox3.Items.Add("1:�݌�");
            comboBox3.Items.Add("2:���");
            comboBox3.SelectedIndex = 0;

            //���[�J�[�ʈ��
            //0:���Ȃ� 1:����
            comboBox4.Items.Add("0:���Ȃ�");
            comboBox4.Items.Add("1:����");
            comboBox4.SelectedIndex = 0;

            //���גP��
            comboBox5.Items.Add("0�F�i��");
            comboBox5.Items.Add("1�FBL�R�[�h");
            comboBox5.Items.Add("2�F�O���[�v�R�[�h");
            comboBox5.Items.Add("3�F���i������");
            comboBox5.Items.Add("4�F���i�啪��");
            comboBox5.Items.Add("5�F���[�J�[");
            comboBox5.Items.Add("6�F���_�E���Ӑ�E�S����");
            comboBox5.Items.Add("7�F���_");
            comboBox5.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesTransListResultDB = MediationSalesTransListResultDB.GetSalesTransListResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesTransListCndtnWork paramWork = null;

            paramWork = new SalesTransListCndtnWork();

            //��ƃR�[�h
            paramWork.EnterpriseCode = textBox1.Text;

            //���_�R�[�h
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCodes = SectionCodes;

            //�W�v�P��
            paramWork.TotalType = comboBox1.SelectedIndex;

            //�W�v���@
            paramWork.TtlType = comboBox2.SelectedIndex;

            //�݌Ɏ�񂹋敪
            paramWork.RsltTtlDivCd = comboBox3.SelectedIndex;

            //���[�J�[�ʈ��
            paramWork.MakerPrintDiv = comboBox4.SelectedIndex;

            //���גP��
            paramWork.Detail = comboBox5.SelectedIndex;

            //�Ώ۔N��(����)
            paramWork.AddUpYearMonthSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            paramWork.AddUpYearMonthEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);

            //����͈͎w��
            paramWork.PrintRangeSt = Int32.Parse(textBox5.Text);
            paramWork.PrintRangeEd = Int32.Parse(textBox6.Text);

            //���Ӑ�R�[�h
            paramWork.CustomerCodeSt = Int32.Parse(textBox7.Text);
            paramWork.CustomerCodeEd = Int32.Parse(textBox8.Text);

            //�]�ƈ��R�[�h
            paramWork.EmployeeCodeSt = textBox9.Text;
            paramWork.EmployeeCodeEd = textBox10.Text;

            //���i���[�J�[�R�[�h
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox11.Text);
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox12.Text);

            //���i�啪�ރR�[�h
            paramWork.GoodsLGroupSt = Int32.Parse(textBox13.Text);
            paramWork.GoodsLGroupEd = Int32.Parse(textBox14.Text);

            //���i�����ރR�[�h
            paramWork.GoodsMGroupSt = Int32.Parse(textBox15.Text);
            paramWork.GoodsMGroupEd = Int32.Parse(textBox16.Text);

            //BL�O���[�v�R�[�h
            paramWork.BLGroupCodeSt = Int32.Parse(textBox17.Text);
            paramWork.BLGroupCodeEd = Int32.Parse(textBox18.Text);

            //BL���i�R�[�h
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox19.Text);
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox20.Text);

            //���i�ԍ�
            paramWork.GoodsNoSt = textBox21.Text;
            paramWork.GoodsNoEd = textBox22.Text;



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
                int status = salesTransListResultDB.Search(out objResult, objParam);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

    }
}
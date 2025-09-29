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
        ISalesRsltListResultDB salesRsltListResultDB = null;
        
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

            //�o�׎w��敪
            //0:���� 1:����
            comboBox3.Items.Add("0:����");
            comboBox3.Items.Add("1:����");
            comboBox3.SelectedIndex = 0;

            //�݌Ɏ�񂹋敪
            //0:���v 1:�݌�, 2:���
            comboBox4.Items.Add("0:���v");
            comboBox4.Items.Add("1:�݌�");
            comboBox4.Items.Add("2:���");
            comboBox4.SelectedIndex = 0;

            //�������
            //0:���Ȃ� 1:����
            comboBox5.Items.Add("0:���Ȃ�");
            comboBox5.Items.Add("1:����");
            comboBox5.SelectedIndex = 0;

            //���[�J�[�ʈ��
            //0:���Ȃ� 1:����
            comboBox6.Items.Add("0:���Ȃ�");
            comboBox6.Items.Add("1:����");
            comboBox6.SelectedIndex = 0;

            //���גP��
            comboBox7.Items.Add("0�F�i��");
            comboBox7.Items.Add("1�FBL�R�[�h");
            comboBox7.Items.Add("2�F�O���[�v�R�[�h");
            comboBox7.Items.Add("3�F���i������");
            comboBox7.Items.Add("4�F���i�啪��");
            comboBox7.Items.Add("5�F���[�J�[");
            comboBox7.Items.Add("6�F���_");
            comboBox7.SelectedIndex = 0;

            //���s�^�C�v
            //0:���_�ʑq�ɕ� 1:�q�ɕʓ��Ӑ�� 2:�q�ɕʋ��_��
            comboBox8.Items.Add("0:���_�ʑq�ɕ�");
            comboBox8.Items.Add("1:�q�ɕʓ��Ӑ��");
            comboBox8.Items.Add("2:�q�ɕʋ��_��");
            comboBox8.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salesRsltListResultDB = MediationSalesRsltListResultDB.GetSalesRsltListResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesRsltListCndtnWork paramWork = null;

            paramWork = new SalesRsltListCndtnWork();

            // ��ƃR�[�h
            paramWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCodes = SectionCodes;

            //�W�v�P��
            paramWork.TotalType = comboBox1.SelectedIndex;

            //�W�v���@
            paramWork.TtlType = comboBox2.SelectedIndex;

            //�o�׎w��敪
            paramWork.PrintRangeDiv = comboBox3.SelectedIndex;

            //�݌Ɏ�񂹋敪
            paramWork.RsltTtlDivCd = comboBox4.SelectedIndex;

            //�������
            paramWork.AnnualPrintDiv = comboBox5.SelectedIndex;

            //���[�J�[�ʈ��
            paramWork.MakerPrintDiv = comboBox6.SelectedIndex;

            //���גP��
            paramWork.Detail = comboBox7.SelectedIndex;

            //���s�^�C�v
            paramWork.PrintType = comboBox8.SelectedIndex;

            //�Ώ۔N��(����)
            paramWork.AddUpYearMonthSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            paramWork.AddUpYearMonthEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);

            //�Ώ۔N��(����)
            paramWork.AnnualAddUpYearMonthSt = DateTime.ParseExact(textBox5.Text, "yyyyMM", null);
            paramWork.AnnualAddUpYaerMonthEd = DateTime.ParseExact(textBox6.Text, "yyyyMM", null);

            //�Ώۊ���(����)
            paramWork.SalesDateSt = DateTime.ParseExact(textBox7.Text, "yyyyMMdd", null);
            paramWork.SalesDateEd = DateTime.ParseExact(textBox8.Text, "yyyyMMdd", null);

            //�Ώۊ���(����)
            paramWork.AnnualSalesDateSt = DateTime.ParseExact(textBox9.Text, "yyyyMMdd", null);
            paramWork.AnnualSalesDateEd = DateTime.ParseExact(textBox10.Text, "yyyyMMdd", null);

            //����͈͎w��
            paramWork.PrintRangeSt = Int32.Parse(textBox11.Text);
            paramWork.PrintRangeEd = Int32.Parse(textBox12.Text);

            //���Ӑ�R�[�h
            paramWork.CustomerCodeSt = Int32.Parse(textBox13.Text);
            paramWork.CustomerCodeEd = Int32.Parse(textBox14.Text);

            //�]�ƈ��R�[�h
            paramWork.EmployeeCodeSt = textBox15.Text;
            paramWork.EmployeeCodeEd = textBox16.Text;

            //�q�ɃR�[�h
            paramWork.WarehouseCodeSt = textBox17.Text;
            paramWork.WarehouseCodeEd = textBox18.Text;

            //���i���[�J�[�R�[�h
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox19.Text);
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox20.Text);

            //���i�啪�ރR�[�h
            paramWork.GoodsLGroupSt = Int32.Parse(textBox21.Text);
            paramWork.GoodsLGroupEd = Int32.Parse(textBox22.Text);

            //���i�����ރR�[�h
            paramWork.GoodsMGroupSt = Int32.Parse(textBox23.Text);
            paramWork.GoodsMGroupEd = Int32.Parse(textBox24.Text);

            //BL�O���[�v�R�[�h
            paramWork.BLGroupCodeSt = Int32.Parse(textBox25.Text);
            paramWork.BLGroupCodeEd = Int32.Parse(textBox26.Text);

            //BL���i�R�[�h
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox27.Text);
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox28.Text);

            //���i�ԍ�
            paramWork.GoodsNoSt = textBox29.Text;
            paramWork.GoodsNoEd = textBox30.Text;

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
                int status = salesRsltListResultDB.Search(out objResult, objParam);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();

            switch (comboBox1.SelectedIndex)
            {
                case 0:  //���i��
                default:
                    //0�F�i�ԁ@1�FBL�R�[�h�@2�F�O���[�v�R�[�h�@3�F���i�����ށ@4�F���i�啪�ށ@5�F���[�J�[�@6�F���_
                    comboBox7.Items.Add("0�F�i��");
                    comboBox7.Items.Add("1�FBL�R�[�h");
                    comboBox7.Items.Add("2�F�O���[�v�R�[�h");
                    comboBox7.Items.Add("3�F���i������");
                    comboBox7.Items.Add("4�F���i�啪��");
                    comboBox7.Items.Add("5�F���[�J�[");
                    comboBox7.Items.Add("6�F���_");
                    comboBox7.SelectedIndex = 0;
                    break;
                case 1:  //���Ӑ��
                    //0�F�i�ԁ@1�FBL�R�[�h�@2�F�O���[�v�R�[�h�@3�F���i�����ށ@4�F���i�啪�ށ@5�F���[�J�[�@6�F���Ӑ�@7�F���_
                    comboBox7.Items.Add("0�F�i��");
                    comboBox7.Items.Add("1�FBL�R�[�h");
                    comboBox7.Items.Add("2�F�O���[�v�R�[�h");
                    comboBox7.Items.Add("3�F���i������");
                    comboBox7.Items.Add("4�F���i�啪��");
                    comboBox7.Items.Add("5�F���[�J�[");
                    comboBox7.Items.Add("6�F���Ӑ�");
                    comboBox7.Items.Add("7�F���_");
                    comboBox7.SelectedIndex = 0;
                    break;
                case 2:  //�S���ҕ�
                    //0�F�i�ԁ@1�FBL�R�[�h�@2�F�O���[�v�R�[�h�@3�F���i�����ށ@4�F���i�啪�ށ@5�F���[�J�[�@6�F�S���ҁ@7�F���_
                    comboBox7.Items.Add("0�F�i��");
                    comboBox7.Items.Add("1�FBL�R�[�h");
                    comboBox7.Items.Add("2�F�O���[�v�R�[�h");
                    comboBox7.Items.Add("3�F���i������");
                    comboBox7.Items.Add("4�F���i�啪��");
                    comboBox7.Items.Add("5�F���[�J�[");
                    comboBox7.Items.Add("6�F�S����");
                    comboBox7.Items.Add("7�F���_");
                    comboBox7.SelectedIndex = 0;
                    break;
                case 3:  //�q�ɕ�
                    //0�F�i�ԁ@1�FBL�R�[�h�@2�F�O���[�v�R�[�h�@3�F���i�����ށ@4�F���i�啪�ށ@5�F���[�J�[�@6�F���_�@7�F�q��
                    //0�F�i�ԁ@1�FBL�R�[�h�@2�F�O���[�v�R�[�h�@3�F���i�����ށ@4�F���i�啪�ށ@5�F���[�J�[�@6�F���Ӑ�@7�F�q��
                    //0�F�i�ԁ@1�FBL�R�[�h�@2�F�O���[�v�R�[�h�@3�F���i�����ށ@4�F���i�啪�ށ@5�F���[�J�[�@6�F�q�Ɂ@7�F���_
                    comboBox7.Items.Add("0�F�i��");
                    comboBox7.Items.Add("1�FBL�R�[�h");
                    comboBox7.Items.Add("2�F�O���[�v�R�[�h");
                    comboBox7.Items.Add("3�F���i������");
                    comboBox7.Items.Add("4�F���i�啪��");
                    comboBox7.Items.Add("5�F���[�J�[");
                    comboBox7.Items.Add("6:");
                    comboBox7.Items.Add("7:");
                    comboBox7.SelectedIndex = 0;
                    break;
            }
        }

    }
}
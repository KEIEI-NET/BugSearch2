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
        IShipmGoodsOdrReportResultDB shipmGoodsOdrReportResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //�W�v�P��
            //0:���i�� 1:BL�R�[�h�� 2:���Ӑ�� 3:�S���ҕ�
            comboBox1.Items.Add("0:���i��");
            comboBox1.Items.Add("1:BL�R�[�h��");
            comboBox1.Items.Add("2:���Ӑ��");
            comboBox1.Items.Add("3:�S���ҕ�");
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

            //���גP��
            comboBox4.Items.Add("0");
            comboBox4.Items.Add("1");
            comboBox4.Items.Add("2");
            comboBox4.Items.Add("3");
            comboBox4.Items.Add("4");
            comboBox4.Items.Add("5");
            comboBox4.Items.Add("6");
            comboBox4.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            shipmGoodsOdrReportResultDB = MediationShipmGoodsOdrReportResultDB.GetShipmGoodsOdrReportResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmGoodsOdrReportParamWork paramWork = null;

            paramWork = new ShipmGoodsOdrReportParamWork();

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
            //�݌Ɏ�񂹋敪
            paramWork.RsltTtlDivCd = comboBox3.SelectedIndex;
            //���גP��
            paramWork.Detail = comboBox4.SelectedIndex;

            //�Ώ۔N��
            paramWork.SalesDateSt = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            paramWork.SalesDateEd = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);
            //����͈͎w��
            paramWork.PrintRangeSt = Int32.Parse(textBox5.Text);
            paramWork.PrintRangeEd = Int32.Parse(textBox6.Text);
            //�d����R�[�h
            paramWork.SupplierCdSt = Int32.Parse(textBox7.Text);
            paramWork.SupplierCdEd = Int32.Parse(textBox8.Text);
            //���Ӑ�R�[�h
            paramWork.CustomerCodeSt = Int32.Parse(textBox9.Text);
            paramWork.CustomerCodeEd = Int32.Parse(textBox10.Text);
            //�]�ƈ��R�[�h
            paramWork.EmployeeCodeSt = textBox11.Text;
            paramWork.EmployeeCodeEd = textBox12.Text;
            //���i���[�J�[�R�[�h
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox13.Text);
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox14.Text);
            //���i�啪�ރR�[�h
            paramWork.GoodsLGroupSt = Int32.Parse(textBox15.Text);
            paramWork.GoodsLGroupEd = Int32.Parse(textBox16.Text);
            //���i�����ރR�[�h
            paramWork.GoodsMGroupSt = Int32.Parse(textBox17.Text);
            paramWork.GoodsMGroupEd = Int32.Parse(textBox18.Text);
            //BL�O���[�v�R�[�h
            paramWork.BLGroupCodeSt = Int32.Parse(textBox19.Text);
            paramWork.BLGroupCodeEd = Int32.Parse(textBox20.Text);
            
            paramWork.BLGroupCodeAry = null;
            //BL���i�R�[�h
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox21.Text);
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox22.Text);
            //���i�ԍ�
            paramWork.GoodsNoSt = textBox23.Text;
            paramWork.GoodsNoEd = textBox24.Text;

            //���ʐݒ�
            paramWork.Order = Int32.Parse(textBox25.Text);

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
                int status = shipmGoodsOdrReportResultDB.Search(out objResult, objParam);
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
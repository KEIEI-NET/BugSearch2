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
        IStockRetPlnTableDB stockRetPlnTableDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockRetPlnTableDB = MediationStockRetPlnTableDB.GetStockRetPlnTableDB();
            comboBox1.Items.Add("�S�Ĉ��");
            comboBox1.Items.Add("���׌v��");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("����");
            comboBox2.Items.Add("�ԕi");
            comboBox2.Items.Add("���ׁ{�ԕi");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("�d���恨���ד����`�[�ԍ�");
            comboBox3.Items.Add("���ד����d���恨�`�[�ԍ�");
            comboBox3.Items.Add("�S���ҁ��d���恨���ד����`�[�ԍ�");
            comboBox3.Items.Add("���ד����`�[�ԍ�");
            comboBox3.Items.Add("�`�[�ԍ�");
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Add("���`");
            comboBox4.Items.Add("�ԓ`");
            comboBox4.Items.Add("����");
            comboBox4.Items.Add("�S��");
            comboBox4.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockRetPlnParamWork stockRetPlnParamWork = null;

            stockRetPlnParamWork = new StockRetPlnParamWork();

            // ��ƃR�[�h
            stockRetPlnParamWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();

            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);

            string[] sectionCode = wrkSecCdList.ToArray();

            stockRetPlnParamWork.SectionCodes = sectionCode;

            //�J�n���Ӑ�R�[�h
            stockRetPlnParamWork.SupplierCdSt = textBox5.Text=="" ? 0 : Convert.ToInt32(textBox5.Text);
            //�I�����Ӑ�R�[�h
            stockRetPlnParamWork.SupplierCdEd = textBox6.Text=="" ? 0 : Convert.ToInt32(textBox6.Text);
            //�J�n�d����
            stockRetPlnParamWork.StockDateSt = 0;
            //�I���d����
            stockRetPlnParamWork.StockDateEd = 0;
            //���s�^�C�v
            stockRetPlnParamWork.MakeShowDiv = comboBox1.SelectedIndex;
            //�o�͎w��
            stockRetPlnParamWork.SlipDiv = comboBox2.SelectedIndex;
            //���t�w��
            stockRetPlnParamWork.PrintDailyFooter = comboBox4.SelectedIndex;

            ArrayList al = new ArrayList();
            al.Add(stockRetPlnParamWork);
            dataGridView2.DataSource = al;

            Search();

        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = stockRetPlnTableDB.Search(out objResult, objParam);
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
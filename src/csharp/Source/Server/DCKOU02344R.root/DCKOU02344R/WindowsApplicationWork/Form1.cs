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
        IArrivalListDB arrivalListDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            arrivalListDB = MediationArrivalListDB.GetArrivalListDB();
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
            ArrivalListParamWork arrivalListParamWork = null;

            arrivalListParamWork = new ArrivalListParamWork();

            // ��ƃR�[�h
            arrivalListParamWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();

            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);

            string[] sectionCode = wrkSecCdList.ToArray();

            arrivalListParamWork.SectionCodes = sectionCode;

            //�J�n���Ӑ�R�[�h
            arrivalListParamWork.SupplierCdSt = textBox5.Text=="" ? 0 : Convert.ToInt32(textBox5.Text);
            //�I�����Ӑ�R�[�h
            arrivalListParamWork.SupplierCdEd = textBox6.Text=="" ? 0 : Convert.ToInt32(textBox6.Text);
            //�J�n�d���S���҃R�[�h
            arrivalListParamWork.StockAgentCodeSt = textBox7.Text;
            //�I���d���S���҃R�[�h
            arrivalListParamWork.StockAgentCodeEd = textBox8.Text;
            //�J�n�d�����͎҃R�[�h
            //arrivalListParamWork.StockInputCodeSt = textBox9.Text;
            //�I���d�����͎҃R�[�h
            //arrivalListParamWork.StockInputCodeEd = textBox10.Text;
            //�J�n�d���`�[�ԍ�
            arrivalListParamWork.SupplierSlipNoSt = textBox11.Text=="" ? 0 : Convert.ToInt32(textBox11.Text);
            //�I���d���`�[�ԍ�
            arrivalListParamWork.SupplierSlipNoEd = textBox12.Text=="" ? 0 : Convert.ToInt32(textBox12.Text);
            //�J�n�d����
            arrivalListParamWork.StockDateSt = 0;
            //�I���d����
            arrivalListParamWork.StockDateEd = 0;
            //�J�n���ד�
            arrivalListParamWork.ArrivalGoodsDaySt = textBox13.Text == "" ? 0 : Convert.ToInt32(textBox13.Text.Substring(0, 4)) * 10000 + Convert.ToInt32(textBox13.Text.Substring(4, 2)) * 100 + Convert.ToInt32(textBox13.Text.Substring(6, 2));
            //�I�����ד�
            arrivalListParamWork.ArrivalGoodsDayEd = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text.Substring(0, 4)) * 10000 + Convert.ToInt32(textBox14.Text.Substring(4, 2)) * 100 + Convert.ToInt32(textBox14.Text.Substring(6, 2));
            //���s�^�C�v
            arrivalListParamWork.MakeShowDiv = comboBox1.SelectedIndex;
            //�`�[�敪
            arrivalListParamWork.SlipDiv = comboBox2.SelectedIndex;
            //�o�͏�
            arrivalListParamWork.SortOrder = comboBox3.SelectedIndex;
            //�ԓ`�敪
            arrivalListParamWork.DebitNoteDiv = comboBox4.SelectedIndex;

            ArrayList al = new ArrayList();
            al.Add(arrivalListParamWork);
            dataGridView2.DataSource = al;

            Search();

        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = arrivalListDB.Search(out objResult, objParam);
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
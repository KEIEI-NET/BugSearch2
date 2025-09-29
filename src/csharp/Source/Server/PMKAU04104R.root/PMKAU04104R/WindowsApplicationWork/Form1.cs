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
        IUpdHisDspDB updHisDspDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            textBox8.Text = "20080101";
            textBox9.Text = "20081231";

            textBox11.Text = "20080101";
            textBox12.Text = "20081231";

            //�\���敪
            comboBox2.Items.Add("0:����");
            comboBox2.Items.Add("1:�x��");
            comboBox2.Items.Add("2:���㌎��");
            comboBox2.Items.Add("3:�d������");
            comboBox2.SelectedIndex = 0;

            // �������
            comboBox1.Items.Add("-1:�S��");
            comboBox1.Items.Add("0:�X�V����");
            comboBox1.Items.Add("1:��������");
            comboBox1.SelectedIndex = 0;

            // ���ʎ��
            comboBox3.Items.Add("-1:�S��");
            comboBox3.Items.Add("0:����");
            comboBox3.Items.Add("1:�ُ�");
            comboBox3.SelectedIndex = 0;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            updHisDspDB = MediationUpdHisDspDB.GetUpdHisDspDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtrInfo_UpdHisDspWork extrInfo_UpdHisDspWork = null;

            extrInfo_UpdHisDspWork = new ExtrInfo_UpdHisDspWork();

            // ��ƃR�[�h
            extrInfo_UpdHisDspWork.EnterpriseCode = textBox1.Text;

            // ���_�R�[�h
            string[] SectionCodeList = new string[2];
            if (checkBox1.Checked)
            {
                SectionCodeList[0] = "";
            }
            else
            {
                SectionCodeList[0] = textBox2.Text;
                SectionCodeList[1] = textBox3.Text;
            }
            extrInfo_UpdHisDspWork.AddupSecCodeList = SectionCodeList;


            //�J�n�N����
            extrInfo_UpdHisDspWork.St_CAddUpUpdDate = textBox11.Text == "" ? 20071001 : Convert.ToInt32(textBox11.Text);

            //�I���N����
            extrInfo_UpdHisDspWork.Ed_CAddUpUpdDate = textBox12.Text == "" ? 20071031 : Convert.ToInt32(textBox12.Text);

            //�J�n�N����
            extrInfo_UpdHisDspWork.St_CAddUpUpdExecDate = textBox8.Text == "" ? 20071001 : Convert.ToInt32(textBox8.Text);

            //�I���N����
            extrInfo_UpdHisDspWork.Ed_CAddUpUpdExecDate = textBox9.Text == "" ? 20071031 : Convert.ToInt32(textBox9.Text);

            //�\���敪
            extrInfo_UpdHisDspWork.DispDiv = comboBox2.SelectedIndex;

            //�������
            extrInfo_UpdHisDspWork.ProcKnd = comboBox1.SelectedIndex;

            //���ʎ��
            extrInfo_UpdHisDspWork.RsltKnd = comboBox3.SelectedIndex;


            ArrayList al = new ArrayList();
            al.Add(extrInfo_UpdHisDspWork);
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

                int status = updHisDspDB.Search(out objResult, objParam);
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
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
        IPartsSubstDspDB partsSubstDspDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            textBox3.Text = "1";
            textBox4.Text = "TEST-001";
            textBox5.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            partsSubstDspDB = MediationPartsSubstDspDB.GetPartsSubstDspDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PartsSubstUSearchParamWork PartsSubstUSearchParamWork = null;

            PartsSubstUSearchParamWork = new PartsSubstUSearchParamWork();

            // ��ƃR�[�h
            PartsSubstUSearchParamWork.EnterpriseCode = textBox1.Text;
            // �����敪
            PartsSubstUSearchParamWork.SearchDiv = Convert.ToInt32(textBox5.Text);
            // ���_�R�[�h
            PartsSubstUSearchParamWork.SectionCode = textBox2.Text;
            // ���[�J�[�R�[�h
            PartsSubstUSearchParamWork.ChgSrcMakerCd = Convert.ToInt32(textBox3.Text);
            // �i��
            PartsSubstUSearchParamWork.ChgSrcGoodsNo = textBox4.Text;
            

            ArrayList al = new ArrayList();
            al.Add(PartsSubstUSearchParamWork);
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

                int status = partsSubstDspDB.Search(out objResult, objParam);
                if (status != 0)
                {
                    Text = "�Y���f�[�^���� ST="+ Convert.ToString(status);
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
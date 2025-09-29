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
        ICustSalesTargetDB custSalesTargetDB = null;
        CustSalesTargetWork custSalesTargetWork = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
            textBox2.Text = "000001";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            custSalesTargetDB = MediationCustSalesTargetDB.GetCustSalesTargetDB();

        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            ShipmGoodsOdrReportParamWork paramWork = null;

            paramWork = new ShipmGoodsOdrReportParamWork();

            // ��ƃR�[�h
            paramWork.EnterpriseCode = textBox1.Text;

            //���_�ʏW�v�敪
            //0:�S�ЏW�v�^1:���_�ʏW�v
            paramWork.TtlType = comboBox2.SelectedIndex;
            
            // ���_�R�[�h
            string[] SectionCodes = new string[4];
            SectionCodes[0] = textBox2.Text;
            SectionCodes[1] = "000002";
            paramWork.SectionCodes = SectionCodes;

            //�����Ǘ��敪
            //paramWork.SectionDiv = 2;

            //�J�n�N��
            paramWork.SalesDateSt = Convert.ToDateTime(textBox11.Text);

            //�I���N��
            paramWork.SalesDateEd = Convert.ToDateTime(textBox12.Text);

            //�J�n���N��
            //paramWork.AnnualAddUpYearMonthSt = Convert.ToDateTime(textBox8.Text);

            //�I�����N��
            //paramWork.AnnualAddUpYaerMonthEd = Convert.ToDateTime(textBox9.Text);

            //�S���]�ƈ��R�[�h
            paramWork.SalesEmployeeCdSt = "";
            paramWork.SalesEmployeeCdEd = "";

            //���Ӑ�R�[�h
            paramWork.CustomerCodeSt = 0;
            paramWork.CustomerCodeEd = 0;

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
        */

        /*
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
        */

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            custSalesTargetWork = new CustSalesTargetWork();
            custSalesTargetWork.EnterpriseCode = textBox1.Text;
            custSalesTargetWork.SectionCode = textBox2.Text;
            custSalesTargetWork.BusinessTypeCode = Convert.ToInt32(textBox3.Text);
            custSalesTargetWork.SalesAreaCode = Convert.ToInt32(textBox4.Text);
            custSalesTargetWork.CustomerCode = Convert.ToInt32(textBox5.Text);

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(custSalesTargetWork);

            int status = custSalesTargetDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {
                // XML�̓ǂݍ���
                custSalesTargetWork = (CustSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSalesTargetWork));

                Text = "�Y���f�[�^�L��";
                ArrayList al = new ArrayList();
                al.Add(custSalesTargetWork);
                dataGridView2.DataSource = al;
            }		
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            ArrayList al = new ArrayList();
            SearchCustSalesTargetParaWork work = new SearchCustSalesTargetParaWork();
            work.EnterpriseCode = textBox1.Text;
            al.Add(work);
            dataGridView1.DataSource = al;

        }

        /// <summary>
        /// AddRow, �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CustSalesTargetWork _custSalesTargetWork = new  CustSalesTargetWork();
            _custSalesTargetWork.EnterpriseCode = textBox1.Text;
            _custSalesTargetWork.SectionCode = textBox2.Text;
            _custSalesTargetWork.BusinessTypeCode = Convert.ToInt32(textBox3.Text);
            _custSalesTargetWork.SalesAreaCode = Convert.ToInt32(textBox4.Text);
            _custSalesTargetWork.CustomerCode = Convert.ToInt32(textBox5.Text);

            ArrayList al = dataGridView2.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(_custSalesTargetWork);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = al;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            object parabyte = dataGridView1.DataSource;
            object objCustSalesTarget;

            int status = custSalesTargetDB.Search(out objCustSalesTarget, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {

                Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)objCustSalesTarget).Count.ToString() + "��";

                dataGridView2.DataSource = objCustSalesTarget;
            }

        }

        /// <summary>
        /// WriteGrid, �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            int status = custSalesTargetDB.Write(ref objCustSalesTargetWork);
            if (status != 0)
            {
                Text = "�X�V���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�X�V����";
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objCustSalesTargetWork;
            }		

        }

        /// <summary>
        /// LogDelGrid, �_���폜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            int status = custSalesTargetDB.LogicalDelete(ref objCustSalesTargetWork);
            if (status != 0)
            {
                Text = "�_���폜���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�_���폜����";
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objCustSalesTargetWork;
            }
        }

        /// <summary>
        /// RevGrid, ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            int status = custSalesTargetDB.RevivalLogicalDelete(ref objCustSalesTargetWork);
            if (status != 0)
            {
                Text = "�������s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
                }
            }
            else
            {
                Text = "��������";
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objCustSalesTargetWork;
            }
        }

        /// <summary>
        /// DelGrid, 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            object objCustSalesTargetWork = dataGridView2.DataSource;

            CustSalesTargetWork[] trarray = (CustSalesTargetWork[])((ArrayList)dataGridView2.DataSource).ToArray(typeof(CustSalesTargetWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = custSalesTargetDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "�폜���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���č폜���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�폜�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�폜����";
                dataGridView2.DataSource = null;
            }
        }

    }
}
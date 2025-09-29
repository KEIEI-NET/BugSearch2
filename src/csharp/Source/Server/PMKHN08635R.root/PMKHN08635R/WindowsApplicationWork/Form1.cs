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
        ISalTrgtPrintResultDB salTrgtPrintResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //�W�v�P��
            //10:���_,20:���_+����,22:���_+�]�ƈ�,
            //30:���_+���Ӑ�,31:���_+�Ǝ�,32:���_+�̔��ر,
            //33:���_+�̔��ر+���Ӑ�,34:���_�̔��敪40:���_+Ұ��,
            //41:���_+Ұ��+���i,42:���_+��ٰ��,43:���_+BL���i����,
            //44:���_+�̔��敪,45,���Е���(���i�敪)
            comboBox1.Items.Add("10:���_");
            comboBox1.Items.Add("20:���_+����");
            comboBox1.Items.Add("22:���_+�]�ƈ�");
            comboBox1.Items.Add("30:���_+���Ӑ�");
            comboBox1.Items.Add("31:���_+�Ǝ�");
            comboBox1.Items.Add("32:���_+�̔��ر");
            //comboBox1.Items.Add("33:���_+�̔��ر+���Ӑ�");
            //comboBox1.Items.Add("40:���_+Ұ��");
            //comboBox1.Items.Add("41:���_+Ұ��+���i");
            //comboBox1.Items.Add("42:���_+��ٰ��");
            //comboBox1.Items.Add("43:���_+BL���i����");
            comboBox1.Items.Add("44:���_+�̔��敪");
            comboBox1.Items.Add("45:���Е���(���i�敪)");
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salTrgtPrintResultDB = MediationSalTrgtPrintResultDB.GetSalTrgtPrintResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalTrgtPrintParamWork paramWork = null;

            paramWork = new SalTrgtPrintParamWork();

            //��ƃR�[�h
            paramWork.EnterpriseCode = textBox1.Text;

            //���_�R�[�h
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCodes = SectionCodes;

            //����敪
            String[] PrintTypelist = comboBox1.Text.Split((new Char[] { ':' }));
            paramWork.PrintType = Convert.ToInt32(PrintTypelist[0]);

            //�N��
            paramWork.TargetDivideCodeSt = Convert.ToInt32(textBox3.Text);
            paramWork.TargetDivideCodeEd = Convert.ToInt32(textBox4.Text);

            // �]�ƈ���
            if ((paramWork.PrintType == 10) ||
                (paramWork.PrintType == 20) ||
                (paramWork.PrintType == 22))
            {
                // ����
                paramWork.SubSectionCodeSt = Convert.ToInt32(textBox5.Text);
                paramWork.SubSectionCodeEd = Convert.ToInt32(textBox6.Text);
                // �]�ƈ��R�[�h
                paramWork.EmployeeCodeSt = textBox9.Text;
                paramWork.EmployeeCodeEd = textBox10.Text;

            }
            // ���Ӑ��
            else if ((paramWork.PrintType == 30) ||
                     (paramWork.PrintType == 31) ||
                     (paramWork.PrintType == 32) ||
                     (paramWork.PrintType == 33) ||
                     (paramWork.PrintType == 34))
            {
                // ���Ӑ�
                paramWork.CustomerCodeSt = Convert.ToInt32(textBox7.Text);
                paramWork.CustomerCodeEd = Convert.ToInt32(textBox8.Text);
                // �Ǝ�
                paramWork.BusinessTypeCodeSt = Convert.ToInt32(textBox15.Text);
                paramWork.BusinessTypeCodeEd = Convert.ToInt32(textBox16.Text);
                // �̔��G���A
                paramWork.SalesAreaCodeSt = Convert.ToInt32(textBox17.Text);
                paramWork.SalesAreaCodeEd = Convert.ToInt32(textBox18.Text);
            }
            // ���i��
            else if ((paramWork.PrintType == 40) ||
                (paramWork.PrintType == 41) ||
                (paramWork.PrintType == 42) ||
                (paramWork.PrintType == 43) ||
                (paramWork.PrintType == 44) ||
                (paramWork.PrintType == 45))
            {
                // �̔��敪
                paramWork.SalesCodeSt = Convert.ToInt32(textBox11.Text);
                paramWork.SalesCodeEd = Convert.ToInt32(textBox12.Text);
                // ���i�敪
                paramWork.EnterpriseGanreCodeSt = Convert.ToInt32(textBox13.Text);
                paramWork.EnterpriseGanreCodeEd = Convert.ToInt32(textBox14.Text);
            }  

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
                int status = salTrgtPrintResultDB.Search(out objResult, objParam,0);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //����敪
            String[] PrintTypelist = comboBox1.Text.Split((new Char[] { ':' }));
            int iPrintType = Convert.ToInt32(PrintTypelist[0]);
            // �]�ƈ���
            if ((iPrintType == 10) ||
                (iPrintType == 20) ||
                (iPrintType == 22))
            {
                // ����
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                // �]�ƈ��R�[�h
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                //------------------------
                // ���Ӑ�
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                // �Ǝ�
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                // �̔��G���A
                textBox17.Enabled = false;
                textBox18.Enabled = false;
                // �̔��敪
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                // ���i�敪
                textBox13.Enabled = false;
                textBox14.Enabled = false;

            }
            // ���Ӑ��
            else if ((iPrintType == 30) ||
                     (iPrintType == 31) ||
                     (iPrintType == 32) ||
                     (iPrintType == 33) ||
                     (iPrintType == 34))
            {
                // ���Ӑ�
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                // �Ǝ�
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                // �̔��G���A
                textBox17.Enabled = true;
                textBox18.Enabled = true;
                //----------------------------
                // ����
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                // �]�ƈ��R�[�h
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                // �̔��敪
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                // ���i�敪
                textBox13.Enabled = false;
                textBox14.Enabled = false;

            }
            // ���i��
            else if ((iPrintType == 40) ||
                    (iPrintType == 41) ||
                    (iPrintType == 42) ||
                    (iPrintType == 43) ||
                    (iPrintType == 44) ||
                    (iPrintType == 45))
            {
                // �̔��敪
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                // ���i�敪
                textBox13.Enabled = true;
                textBox14.Enabled = true;
                //---------------------------
                // ����
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                // �]�ƈ��R�[�h
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                // ���Ӑ�
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                // �Ǝ�
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                // �̔��G���A
                textBox17.Enabled = false;
                textBox18.Enabled = false;

            }  



        }

    }
}
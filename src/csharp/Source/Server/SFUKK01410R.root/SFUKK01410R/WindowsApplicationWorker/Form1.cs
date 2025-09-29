using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using System.Reflection;
using System.IO;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 �̊T�v�̐����ł��B
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        #region Windows
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.DataGrid dataGrid3;
        #endregion

        private IDepBillMonSecDB IdepbillmonsecDB = null;

        private static string[] _parameter;
        private Button button8;
        private static System.Windows.Forms.Form _form = null;


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0140150842030050";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 19);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(368, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 19);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(504, 48);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(72, 19);
            this.textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(639, 48);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(72, 19);
            this.textBox5.TabIndex = 5;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(176, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "�����ݒ�";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(312, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "�����ݒ�Ǘ�����";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(448, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "�����S��";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(584, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "�����S�̐ݒ�Ǘ�����";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(728, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(142, 19);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "0140150842030050";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(728, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(16, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(352, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 166);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(944, 178);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(506, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "SearchGrid";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(226, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Write";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(330, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "LogicalDelete";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(466, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "�_���폜�敪";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(136, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "1";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(808, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 24);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Search����Serialize����";
            // 
            // listBox2
            // 
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(374, 72);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(337, 88);
            this.listBox2.TabIndex = 25;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(852, 74);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 25);
            this.button5.TabIndex = 26;
            this.button5.Text = "�����w��Search";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(790, 78);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 19);
            this.numericUpDown1.TabIndex = 27;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(726, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "NextData?";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(418, 16);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(48, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(274, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(56, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Revival";
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 350);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(944, 178);
            this.dataGrid2.TabIndex = 37;
            // 
            // dataGrid3
            // 
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(16, 534);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(944, 178);
            this.dataGrid3.TabIndex = 38;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(584, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(92, 23);
            this.button8.TabIndex = 40;
            this.button8.Text = "CustomSearchGrid";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(977, 721);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(String[] args) 
        {
            try
            {
                string msg = "";
                _parameter = args;
                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",msg,0,MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"WindowsApplicationWorker",ex.Message,0,MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }

        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();
            //�]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",e.ToString(),0,MessageBoxButtons.OK);
            else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",e.ToString(),0,MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }




        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);		
            IdepbillmonsecDB = MediationDepBillMonSecDB.GetDepBillMonSecDB();
        }



        //Search Grid
        private void button3_Click(object sender, System.EventArgs e)
        {
            ArrayList al = new ArrayList();

            int retTotalCnt;

            string priseCd = "TBS1";


            DepositStWork depositStWork   = new DepositStWork();
            byte[] depositStWorkList;
            BillAllStWork billAllStWork   = new BillAllStWork();
            byte[] billAllStWorkList;
            MoneyKindWork moneyKindWork   = new MoneyKindWork();
            byte[] moneyKindWorkList;
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            byte[] secInfoSetWorkList;


            int status = IdepbillmonsecDB.Search(out retTotalCnt, 0, priseCd, out depositStWorkList, out billAllStWorkList, out moneyKindWorkList);
  

            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "�Y���f�[�^����";
            }
            else
            {
                // XML�̓ǂݍ���
//                DepositStWork[] ew1 = (DepositStWork[])XmlByteSerializer.Deserialize(depositStWorkList,typeof(DepositStWork[]));
//                dataGrid1.DataSource = ew1;
                depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(depositStWorkList,typeof(DepositStWork));
                textBox2.Text = "�Y������";
                textBox3.Text = depositStWork.DepositStMngCd.ToString();


//                BillAllStWork[] ew2 = (BillAllStWork[])XmlByteSerializer.Deserialize(billAllStWorkList,typeof(BillAllStWork[]));
//                dataGrid2.DataSource = ew2;
                billAllStWork = (BillAllStWork)XmlByteSerializer.Deserialize(billAllStWorkList,typeof(BillAllStWork));
                textBox4.Text = "�Y������";
                //textBox5.Text = billAllStWork.BillAllStCd.ToString();


                MoneyKindWork[] ew3 = (MoneyKindWork[])XmlByteSerializer.Deserialize(moneyKindWorkList,typeof(MoneyKindWork[]));
                dataGrid3.DataSource = ew3;

       //         SecInfoSetWork[] ew4 = (SecInfoSetWork[])XmlByteSerializer.Deserialize(secInfoSetWorkList,typeof(SecInfoSetWork[]));
       //         dataGrid4.DataSource = ew4;

//                Text = "�Y���f�[�^�L��  �����ݒ�=" + ew1.Length.ToString() + "  �����S��=" + ew2.Length.ToString() + "  ���z���=" + ew3.Length.ToString() + "  ���_���=" + ew4.Length.ToString() ;
            }		
        }


        //CustomSearchGrid
        private void button8_Click(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();

            int retTotalCnt;

            string priseCd = textBox1.Text;


            DepositStWork depositStWork   = new DepositStWork();
            byte[] depositStWorkList;
            BillAllStWork billAllStWork   = new BillAllStWork();
            byte[] billAllStWorkList;
        //    MoneyKindWork moneyKindWork   = new MoneyKindWork();
            object moneyKindWorkList = null;


            int status = IdepbillmonsecDB.Search(out retTotalCnt, 0, priseCd, out depositStWorkList, out billAllStWorkList, out moneyKindWorkList);
  

            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "�Y���f�[�^����  st="+status;
            }
            else
            {
                Text = "�Y���f�[�^����";

                // XML�̓ǂݍ���
//                DepositStWork[] ew1 = (DepositStWork[])XmlByteSerializer.Deserialize(depositStWorkList,typeof(DepositStWork[]));
//                dataGrid1.DataSource = ew1;
                depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(depositStWorkList,typeof(DepositStWork));
                textBox2.Text = "�Y������";
                textBox3.Text = depositStWork.DepositStMngCd.ToString();


//                BillAllStWork[] ew2 = (BillAllStWork[])XmlByteSerializer.Deserialize(billAllStWorkList,typeof(BillAllStWork[]));
//                dataGrid2.DataSource = ew2;
                billAllStWork = (BillAllStWork)XmlByteSerializer.Deserialize(billAllStWorkList,typeof(BillAllStWork));
                textBox4.Text = "�Y������";
                //textBox5.Text = billAllStWork.BillAllStCd.ToString();


                dataGrid3.DataSource = moneyKindWorkList;

            }		

        }



        //Clear
        private void button9_Click(object sender, System.EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";	
            textBox7.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            button5.Enabled = true;
            label6.Text = "���f�[�^�H";
        }




        //Read
        private void button1_Click(object sender, System.EventArgs e)
        {
            //            _companyInfWork = new CompanyInfWork();
            //            _companyInfWork.EnterpriseCode = textBox1.Text;
            //            _companyInfWork.AcceptAnOrderNo = Convert.ToInt32(textBox2.Text);
            //
            //            // XML�֕ϊ����A������̃o�C�i����
            //            byte[] parabyte = XmlByteSerializer.Serialize(_companyInfWork);			
            //
            //            int status = IcompanyinfDB.Read(ref parabyte,0);
            //            if (status != 0)
            //            {
            //                Text = "�Y���f�[�^����";
            //            }
            //            else
            //            {
            //                // XML�̓ǂݍ���
            //                _companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
            //
            //                Text = "�Y���f�[�^�L��";
            //                textBox1.Text = _companyInfWork.EnterpriseCode.ToString();
            //      //          textBox2.Text = _companyInfWork.AcceptAnOrderNo.ToString();
            //      //          textBox3.Text = "";    //_companyInfWork.LandTransBranchCd.ToString();
            //      //          textBox4.Text = "";    //_companyInfWork.LandTransOfficeCd.ToString();
            //      //          textBox5.Text = "";    //_companyInfWork.LandTransBranchNm;
            //      //          textBox9.Text = "";    //_companyInfWork.LogicalDeleteCode.ToString();
            //            }		
        }


        //Search
        private void button2_Click(object sender, System.EventArgs e)
        {
//            CompanyInfWork companyInfInsWork = new CompanyInfWork();
//            companyInfInsWork.EnterpriseCode = textBox1.Text;
//
//            ArrayList al = new ArrayList();
//
//            // XML�֕ϊ����A������̃o�C�i����
//            byte[] parabyte = XmlByteSerializer.Serialize(companyInfInsWork);		
//            byte[] retbyte;
//            int retTotalCnt;
//
//            DateTime DT1 = new DateTime(2005,5,22);            // (1982,4,1);
////            DateTime DT2 = new DateTime(2005,5,22);
//
//            string[] ar = new string[1];
//            ar[0] = "1";
//
//            short addUpCd = 1;
//            string priseCd = "TBS1";
//
//            int[] inp = new int[1];
//            inp[0] = 0;
//
//            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
//            byte[] secInfoSetWorkList;
//            OutputSetWork outputSetWork = new OutputSetWork();
//            byte[] outputSetWorkList;
//
//            int status = IcompanyinfDB.Search(out retbyte, out retTotalCnt, parabyte, 0, DT1, inp , ar , addUpCd, priseCd, out secInfoSetWorkList, out outputSetWorkList );
//
//            listBox1.Items.Clear();
//            if (status != 0)
//            {
//                Text = "�Y���f�[�^����";
//            }
//            else
//            {
//                // XML�̓ǂݍ���
//                CompanyInfWork[] ew = (CompanyInfWork[])XmlByteSerializer.Deserialize(retbyte,typeof(CompanyInfWork[]));
//                Text = "�Y���f�[�^�L��  HIT "+ew.Length.ToString()+"��";
//                for(int i = 0;i<ew.Length;i++)
//                {
//                    companyInfInsWork = (CompanyInfWork)ew[i];
//                    listBox1.Items.Add(companyInfInsWork.ToString());
//                    listBox1.Update();
//                }
//                if (checkBox1.Checked) XmlByteSerializer.Serialize(ew,"c:\\testList.xml");	
//            }
        }

/*
        private void button4_Click(object sender, System.EventArgs e)
        {
            if (_companyInfWork == null) _companyInfWork = new CompanyInfWork();

            _companyInfWork.EnterpriseCode = textBox1.Text;
            _companyInfWork.AcceptAnOrderNo = textBox2.Text;
            _companyInfWork.LandTransBranchCd = Convert.ToInt32(textBox3.Text);
            _companyInfWork.LandTransOfficeCd = Convert.ToInt32(textBox4.Text);
            _companyInfWork.LandTransBranchNm = textBox5.Text;

            _companyInfWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

            byte[] parabyte = XmlByteSerializer.Serialize(_companyInfWork);
            int status = IcompanyinfDB.Write(ref parabyte);
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
                // XML�̓ǂݍ���
                _companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));

            }		

        }


        private void button6_Click(object sender, System.EventArgs e)
        {
            byte[] parabyte = XmlByteSerializer.Serialize(_companyInfWork);
            int status = IcompanyinfDB.LogicalDelete(ref parabyte);
            if (status != 0)
            {
                Text = "�폜���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�폜�o���܂���ł����B");
                }
                else
                {
                    MessageBox.Show("���ł��폜�s�@status="+status.ToString());
                }
            }
            else
            {
                Text = "�폜����";
                // XML�̓ǂݍ���
                _companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
                textBox7.Text = _companyInfWork.LogicalDeleteCode.ToString();

            }				
        }
*/


        //�����w��Search
        private void button5_Click(object sender, System.EventArgs e)
        {
//            listBox2.Items.Clear();
//
//            CompanyInfWork companyInfWork = new CompanyInfWork();
//            byte[] parabyte;
//            if (_prevCompanyInfWork == null)
//            {
//                companyInfWork.EnterpriseCode = textBox6.Text;
//                parabyte = XmlByteSerializer.Serialize(companyInfWork);
//            }
//            else
//            {
//                parabyte = XmlByteSerializer.Serialize(_prevCompanyInfWork);	
//            }
//
//            byte[] retbyte;
//            int retTotalCnt;
//            bool nextData;
//
//            int status = IcompanyinfDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);
//
//            if (status != 0)
//            {
//                Text = "�Y���f�[�^����";
//            }
//            else
//            {
//                // XML�̓ǂݍ���
//                CompanyInfWork[] ew = (CompanyInfWork[])XmlByteSerializer.Deserialize(retbyte,typeof(CompanyInfWork[]));
//
//                Text = "�Y���f�[�^�L��  HIT "+ew.Length.ToString()+"��";
//
//                //����̂݌����擾
//                if (_prevCompanyInfWork == null) 
//                {
//                    label7.Text = "�������F "+retTotalCnt.ToString()+" ��";
//                }
//				
//                for(int i = 0;i<ew.Length;i++)
//                {
//                    companyInfWork = (CompanyInfWork)ew[i];
//                    listBox2.Items.Add(companyInfWork.ToString());
//                    listBox2.Update();
//                    if (i == ew.Length - 1) _prevCompanyInfWork = (CompanyInfWork)ew[i];
//                }
//                if (nextData)		label6.Text = "���f�[�^�L��";
//                else
//                {
//                    numericUpDown1.Focus();
//                    button5.Enabled = false;
//                    label6.Text = "���f�[�^����";
//                }
//            }				
//					
        }


/*
        private void button12_Click(object sender, System.EventArgs e)
        {

            byte[] parabyte = XmlByteSerializer.Serialize(_companyInfWork);
            int status = IcompanyinfDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "�폜���s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�폜�o���܂���ł����B");
                }
            }
            else
            {
                Text = "�폜����";
            }						
        }


        private void button7_Click(object sender, System.EventArgs e)
        {
            byte[] parabyte = XmlByteSerializer.Serialize(_companyInfWork);
            int status = IcompanyinfDB.RevivalLogicalDelete(ref parabyte);
            if (status != 0)
            {
                Text = "�������s";
                if (status == 800)
                {
                    MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
                }
                else if (status == 801)
                {
                    MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�폜�o���܂���ł����B");
                }
                else
                {
                    MessageBox.Show("���ł������s�@status="+status.ToString());
                }
            }
            else
            {
                Text = "��������";
                // XML�̓ǂݍ���
                _companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
                textBox7.Text = _companyInfWork.LogicalDeleteCode.ToString();
            }				
		
        }
*/


        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {
		
        }



    }

}



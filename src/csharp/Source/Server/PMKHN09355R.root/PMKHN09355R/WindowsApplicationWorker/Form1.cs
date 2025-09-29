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
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
    /// ����From�̓����[�g�e�X�g�ׂ̈�����From�ł�
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private ICustomerCustomerChangeDB IcustomerCustomerChangeDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private Label label7;
        private TextBox textBox14;
        private Label label8;
        private TextBox textBox15;
        private Label label9;
		private static System.Windows.Forms.Form _form = null;

		public Form1()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 284);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 252);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(17, 139);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(179, 139);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(339, 139);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(273, 139);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(495, 139);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(573, 139);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(417, 139);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 168);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 19);
            this.textBox1.TabIndex = 43;
            this.textBox1.Text = "0101150842020000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "��ƃR�[�h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 46;
            this.label2.Text = "���_�R�[�h";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 19);
            this.textBox2.TabIndex = 45;
            this.textBox2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "���Ӑ�";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(273, 57);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 19);
            this.textBox3.TabIndex = 47;
            this.textBox3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 12);
            this.label4.TabIndex = 50;
            this.label4.Text = "�J�i";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(116, 78);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(138, 19);
            this.textBox4.TabIndex = 49;
            this.textBox4.Text = "90000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "�S����";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(273, 77);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(138, 19);
            this.textBox5.TabIndex = 51;
            this.textBox5.Text = "90000000";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "�n��";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(116, 98);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(138, 19);
            this.textBox6.TabIndex = 53;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(273, 98);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(138, 19);
            this.textBox7.TabIndex = 58;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(116, 118);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(138, 19);
            this.textBox8.TabIndex = 59;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(273, 118);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(138, 19);
            this.textBox9.TabIndex = 60;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(517, 39);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(138, 19);
            this.textBox10.TabIndex = 61;
            this.textBox10.Text = "0";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(713, 40);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(138, 19);
            this.textBox11.TabIndex = 62;
            this.textBox11.Text = "0";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(517, 59);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(138, 19);
            this.textBox12.TabIndex = 63;
            this.textBox12.Text = "0";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(713, 60);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(138, 19);
            this.textBox13.TabIndex = 64;
            this.textBox13.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 65;
            this.label7.Text = "�Ǝ�";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(517, 98);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(138, 19);
            this.textBox14.TabIndex = 66;
            this.textBox14.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 67;
            this.label8.Text = "�����敪";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(116, 39);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(138, 19);
            this.textBox15.TabIndex = 68;
            this.textBox15.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 12);
            this.label9.TabIndex = 69;
            this.label9.Text = "���Ӑ�(READ�p)";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
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
				int status =  ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();
					System.Windows.Forms.Application.Run(_form);
				}
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"SFCMN09000U",ex.Message,0,MessageBoxButtons.OK);
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
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}

        /// <summary>
        /// �v���C�}���L�[�l��ݒ�
        /// </summary>
        /// <param name="customerCustomerChangeWork"></param>
        private void SetKey(ref CustomerCustomerChangeParamWork customerCustomerChangeParamWork)
        {
            customerCustomerChangeParamWork.EnterpriseCode = textBox1.Text;
            //���ȉ��Ɋ�ƃR�[�h�ȊO�̃L�[���ڂ��Z�b�g����R�[�h���L�q
            customerCustomerChangeParamWork.StMngSectionCode = textBox2.Text.Trim();
            customerCustomerChangeParamWork.EdMngSectionCode = textBox3.Text.Trim();
            customerCustomerChangeParamWork.StCustomerCode = Int32.Parse(textBox4.Text);
            customerCustomerChangeParamWork.EdCustomerCode = Int32.Parse(textBox5.Text);
            customerCustomerChangeParamWork.StKana = textBox6.Text;
            customerCustomerChangeParamWork.EdKana = textBox7.Text;
            customerCustomerChangeParamWork.StCustomerAgentCd = textBox8.Text;
            customerCustomerChangeParamWork.EdCustomerAgentCd = textBox9.Text;
            customerCustomerChangeParamWork.StSalesAreaCode = Int32.Parse( textBox10.Text);
            customerCustomerChangeParamWork.EdSalesAreaCode = Int32.Parse(textBox11.Text);
            customerCustomerChangeParamWork.StBusinessTypeCode = Int32.Parse(textBox12.Text);
            customerCustomerChangeParamWork.EdBusinessTypeCode = Int32.Parse(textBox13.Text);
            customerCustomerChangeParamWork.SearchDiv = Int32.Parse(textBox14.Text);
        }

        /// <summary>
        /// 1���ǂݍ��ݏ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            object parabyte = new CustomerCustomerChangeResultWork();
            CustomerCustomerChangeResultWork customerCustomerChangeResultWork = parabyte as CustomerCustomerChangeResultWork;

            //this.SetKey(ref customerCustomerChangeWork);
            customerCustomerChangeResultWork.EnterpriseCode = textBox1.Text;
            customerCustomerChangeResultWork.CustomerCode = Int32.Parse( textBox15.Text );

            //ArrayList paramAl = new ArrayList();
            //paramAl.Add(customerCustomerChangeResultWork);
            //parabyte = paramAl;


            parabyte = customerCustomerChangeResultWork;

			int status = IcustomerCustomerChangeDB.Read(ref parabyte, 0);

			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				Text = "�Y���f�[�^�L��";

                CustomSerializeArrayList al = new CustomSerializeArrayList();
                al.Add(parabyte);
                dataGrid1.DataSource = al;
			}
		}

        /// <summary>
        /// FromLoad���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
			IcustomerCustomerChangeDB = MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
			//textBox1.Text = LoginInfoAcquisition.EnterpriseCode;
		}

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button9_Click(object sender, System.EventArgs e)
		{
            if (dataGrid1.DataSource != null)
            {
                dataGrid2.DataSource = null;
                dataGrid2.DataSource = dataGrid1.DataSource;
                dataGrid1.DataSource = null;
            }
            //CustomSerializeArrayList al = new CustomSerializeArrayList();
            //CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
            //this.SetKey(ref customerCustomerChangeParamWork);
            //al.Add(customerCustomerChangeParamWork);
            //dataGrid2.DataSource = al;
		}

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button8_Click(object sender, System.EventArgs e)
		{
            object parabyte = new CustomerCustomerChangeParamWork();

            CustomerCustomerChangeParamWork customerCustomerChangeParamWork = parabyte as CustomerCustomerChangeParamWork;

            this.SetKey(ref customerCustomerChangeParamWork);

			object objcustomerCustomerChangeResult = null;

            //ArrayList paramAl = new ArrayList();
            //paramAl.Add(customerCustomerChangeParamWork);
            //parabyte = paramAl;
            parabyte = customerCustomerChangeParamWork;

            int status = IcustomerCustomerChangeDB.Search(ref objcustomerCustomerChangeResult, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{

				Text = "�Y���f�[�^�L��";

                dataGrid1.DataSource = objcustomerCustomerChangeResult;
			}
		}

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
            //object objcustomerCustomerChangeResultList = dataGrid2.DataSource;

            //int status = IcustomerCustomerChangeDB.Write(ref objcustomerCustomerChangeResultList);
            //if (status != 0)
            //{
            //    Text = "�X�V���s";
            //    if (status == 800)
            //    {
            //        MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
            //    }
            //    else if (status == 801)
            //    {
            //        MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
            //    }
            //}
            //else
            //{
            //    Text = "�X�V����";
            //    dataGrid1.DataSource = null;
            //    dataGrid1.DataSource = objcustomerCustomerChangeResultList;
            //}
		}

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
            //CustomerCustomerChangeWork customerCustomerChangeWork = new CustomerCustomerChangeWork();
            //this.SetKey(ref customerCustomerChangeWork);
            //CustomSerializeArrayList al = dataGrid1.DataSource as CustomSerializeArrayList;
            //if (al == null) al = new CustomSerializeArrayList();
            //al.Add(customerCustomerChangeWork);
            //dataGrid1.DataSource = null;
            //dataGrid1.DataSource = al;
		}

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button13_Click(object sender, System.EventArgs e)
		{
            
            //object objcustomerCustomerChangeList = dataGrid1.DataSource;
            //int status = IcustomerCustomerChangeDB.LogicalDelete(ref objcustomerCustomerChangeList);
            //if (status != 0)
            //{
            //    Text = "�_���폜���s";
            //    if (status == 800)
            //    {
            //        MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
            //    }
            //    else if (status == 801)
            //    {
            //        MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
            //    }
            //}
            //else
            //{
            //    Text = "�_���폜����";
            //    dataGrid1.DataSource = null;
            //    dataGrid1.DataSource = objcustomerCustomerChangeList;
            //}
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            //object objcustomerCustomerChangeList = dataGrid1.DataSource;

            //int status = IcustomerCustomerChangeDB.Delete(objcustomerCustomerChangeList);
            //if (status != 0)
            //{
            //    Text = "�폜���s";
            //    if (status == 800)
            //    {
            //        MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���č폜���Ă��������B");
            //    }
            //    else if (status == 801)
            //    {
            //        MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�폜�o���܂���ł����B");
            //    }
            //}
            //else
            //{
            //    Text = "�폜����";
            //    dataGrid1.DataSource = null;
            //    //dataGrid1.DataSource = objcustomerCustomerChangeList;
            //}
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
        //    object objcustomerCustomerChangeList = dataGrid1.DataSource;

        //    int status = IcustomerCustomerChangeDB.RevivalLogicalDelete(ref objcustomerCustomerChangeList);
        //    if (status != 0)
        //    {
        //        Text = "�������s";
        //        if (status == 800)
        //        {
        //            MessageBox.Show("���[���ōX�V����Ă��܂��B�ēx�f�[�^��ǂݍ���ł���ēo�^���Ă��������B");
        //        }
        //        else if (status == 801)
        //        {
        //            MessageBox.Show("���[���Ńf�[�^���폜����Ă��܂��B�o�^�o���܂���ł����B");
        //        }
        //    }
        //    else
        //    {
        //        Text = "��������";
        //        dataGrid1.DataSource = null;
        //        dataGrid1.DataSource = objcustomerCustomerChangeList;
        //    }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
	}
}

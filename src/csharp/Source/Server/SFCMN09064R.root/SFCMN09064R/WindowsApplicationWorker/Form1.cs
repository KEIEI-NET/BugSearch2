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

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
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
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button12;

		//private UserGdBdUWork _volInsurGdWork = null;
		private UserGdBdUWork _userGdBdUWork = null;

		//private UserGdBdUWork _prevUserGdBdUWork = null;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.Button button11;

		private IUserGdBdUDB IusergdbduDB = null;

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
			this.label7 = new System.Windows.Forms.Label();
			this.button12 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button8 = new System.Windows.Forms.Button();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.button10 = new System.Windows.Forms.Button();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.button11 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(312, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Read";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(288, 19);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "TBS1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(264, 80);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(248, 19);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "1";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(264, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(248, 19);
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "1";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(264, 128);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(248, 19);
			this.textBox4.TabIndex = 4;
			this.textBox4.Text = "";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(264, 152);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(248, 19);
			this.textBox5.TabIndex = 5;
			this.textBox5.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(144, 80);
			this.label1.Name = "label1";
			this.label1.TabIndex = 6;
			this.label1.Text = "�K�C�h�敪";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "�K�C�h�R�[�h";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(144, 128);
			this.label3.Name = "label3";
			this.label3.TabIndex = 8;
			this.label3.Text = "�K�C�h����";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(144, 152);
			this.label4.Name = "label4";
			this.label4.TabIndex = 9;
			this.label4.Text = "�K�C�h�^�C�v";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(16, 200);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(288, 19);
			this.textBox6.TabIndex = 10;
			this.textBox6.Text = "TBS1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(72, 224);
			this.button2.Name = "button2";
			this.button2.TabIndex = 11;
			this.button2.Text = "Search";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(16, 272);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(304, 88);
			this.listBox1.TabIndex = 12;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(648, 392);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(328, 144);
			this.dataGrid1.TabIndex = 13;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(856, 368);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "SearchUser";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(392, 16);
			this.button4.Name = "button4";
			this.button4.TabIndex = 15;
			this.button4.Text = "Write";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(472, 33);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(88, 23);
			this.button6.TabIndex = 17;
			this.button6.Text = "LogicalDelete";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(16, 40);
			this.button9.Name = "button9";
			this.button9.TabIndex = 20;
			this.button9.Text = "Clear";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(144, 48);
			this.label5.Name = "label5";
			this.label5.TabIndex = 22;
			this.label5.Text = "�_���폜�敪";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(264, 48);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(24, 19);
			this.textBox7.TabIndex = 23;
			this.textBox7.Text = "0";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(72, 248);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(168, 24);
			this.checkBox1.TabIndex = 24;
			this.checkBox1.Text = "Search����Serialize����";
			// 
			// listBox2
			// 
			this.listBox2.ItemHeight = 12;
			this.listBox2.Location = new System.Drawing.Point(336, 272);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(240, 88);
			this.listBox2.TabIndex = 25;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(360, 232);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(112, 23);
			this.button5.TabIndex = 26;
			this.button5.Text = "�����w��Search";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(496, 232);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   20000,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(56, 19);
			this.numericUpDown1.TabIndex = 27;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 1000,
																		 0,
																		 0,
																		 0});
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(472, 208);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 28;
			this.label6.Text = "NextData?";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(320, 208);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(136, 16);
			this.label7.TabIndex = 29;
			this.label7.Text = "�������F";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(472, 57);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(88, 23);
			this.button12.TabIndex = 31;
			this.button12.Text = "Delete";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(472, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(88, 23);
			this.button7.TabIndex = 32;
			this.button7.Text = "Revival";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(264, 176);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(248, 19);
			this.textBox8.TabIndex = 33;
			this.textBox8.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(144, 176);
			this.label8.Name = "label8";
			this.label8.TabIndex = 34;
			this.label8.Text = "���[�U�[����";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Location = new System.Drawing.Point(16, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(96, 96);
			this.groupBox1.TabIndex = 35;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(16, 64);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(64, 24);
			this.radioButton3.TabIndex = 37;
			this.radioButton3.Text = "header";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(48, 24);
			this.radioButton1.TabIndex = 36;
			this.radioButton1.Text = "user";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(16, 40);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(48, 24);
			this.radioButton2.TabIndex = 36;
			this.radioButton2.Text = "offer";
			// 
			// dataGrid2
			// 
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(600, 40);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(376, 320);
			this.dataGrid2.TabIndex = 36;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(872, 16);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 23);
			this.button8.TabIndex = 37;
			this.button8.Text = "SearchHader";
			this.button8.Click += new System.EventHandler(this.button8_Click_1);
			// 
			// dataGrid3
			// 
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(648, 568);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(328, 144);
			this.dataGrid3.TabIndex = 38;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(856, 544);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(120, 23);
			this.button10.TabIndex = 39;
			this.button10.Text = "SearchOffer";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// dataGrid4
			// 
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(16, 392);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(608, 320);
			this.dataGrid4.TabIndex = 40;
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(504, 368);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(120, 23);
			this.button11.TabIndex = 41;
			this.button11.Text = "SearchUser+Offer";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(992, 726);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.dataGrid4);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.dataGrid3);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.dataGrid2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.label7);
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
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//if (_volInsurGdWork == null) _volInsurGdWork = new UserGdBdUWork();
			_userGdBdUWork = new UserGdBdUWork();
			_userGdBdUWork.EnterpriseCode = textBox1.Text;
			_userGdBdUWork.UserGuideDivCd = Convert.ToInt32(textBox2.Text);
			_userGdBdUWork.GuideCode = Convert.ToInt32(textBox3.Text);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_userGdBdUWork);			

			//int status = IusergdbduDB.ReadUserGdBdU(ref parabyte,0);
			int status = IusergdbduDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

				Text = "�Y���f�[�^�L��";
				textBox1.Text = _userGdBdUWork.EnterpriseCode;
				textBox2.Text = _userGdBdUWork.UserGuideDivCd.ToString();
				textBox3.Text = _userGdBdUWork.GuideCode.ToString();
				textBox4.Text = _userGdBdUWork.GuideName.ToString();
				textBox5.Text = _userGdBdUWork.GuideType.ToString();
				textBox7.Text = _userGdBdUWork.LogicalDeleteCode.ToString();
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);		
			IusergdbduDB = MediationUserGdBdUDB.GetUserGdBdUDB();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			UserGdBdUWork volInsurGdWork = new UserGdBdUWork();
			volInsurGdWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			object parabyte = XmlByteSerializer.Serialize(volInsurGdWork);		
			object retbyte;

			//int status = IusergdbduDB.SearchUserGdBdU(out retbyte, parabyte, 0, 0);
			int status = IusergdbduDB.Search(out retbyte, parabyte, 0, 0);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				ArrayList ew = retbyte as ArrayList;

				Text = "�Y���f�[�^�L��  HIT ";
				
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			_userGdBdUWork = new UserGdBdUWork();
			_userGdBdUWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			object parabyte = _userGdBdUWork;
			object retbyte;

			//int status = IusergdbduDB.SearchUserGdBdU(out retbyte, parabyte, 0, 0);
			int status = IusergdbduDB.Search(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				ArrayList ew = retbyte as ArrayList;

				Text = "�Y���f�[�^�L��  HIT ";
				
				dataGrid1.DataSource = ew;
			}		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if(_userGdBdUWork == null) _userGdBdUWork = new UserGdBdUWork();
			_userGdBdUWork.EnterpriseCode = textBox1.Text;
			_userGdBdUWork.UserGuideDivCd = Convert.ToInt32(textBox2.Text);
			_userGdBdUWork.GuideCode = Convert.ToInt32(textBox3.Text);
			_userGdBdUWork.GuideName = textBox4.Text;
			_userGdBdUWork.GuideType = Convert.ToInt32(textBox5.Text);

			_userGdBdUWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(_userGdBdUWork);

			//int status = IusergdbduDB.WriteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.Write(ref parabyte);
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
				_userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));

			}		

		}


		private void button6_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_userGdBdUWork);

			//int status = IusergdbduDB.LogicalDeleteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.LogicalDelete(ref parabyte);
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
				_userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));
				textBox7.Text = _userGdBdUWork.LogicalDeleteCode.ToString();

			}				
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";	
			textBox7.Text = "";
			listBox1.Items.Clear();
			//_prevUserGdBdUWork = null;
			listBox2.Items.Clear();
			button5.Enabled = true;
			label6.Text = "���f�[�^�H";
		}

		/// <summary>
		/// �����w�胊�[�h
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, System.EventArgs e)
		{
//			listBox2.Items.Clear();
//
//			UserGdBdUWork volInsurGdWork = new UserGdBdUWork();
//			byte[] parabyte;
//			if (_prevUserGdBdUWork == null)
//			{
//				volInsurGdWork.EnterpriseCode = textBox6.Text;
//				parabyte = XmlByteSerializer.Serialize(volInsurGdWork);
//			}
//			else
//			{
//				parabyte = XmlByteSerializer.Serialize(_prevUserGdBdUWork);	
//			}
//
//			byte[] retbyte;
//			int retTotalCnt;
//			bool nextData;
//
//			int status = IusergdbduDB.SearchSpecificationUserGdBdU(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);
//
//			if (status != 0)
//			{
//				Text = "�Y���f�[�^����";
//			}
//			else
//			{
//				// XML�̓ǂݍ���
//				UserGdBdUWork[] ew = (UserGdBdUWork[])XmlByteSerializer.Deserialize(retbyte,typeof(UserGdBdUWork[]));
//
//				Text = "�Y���f�[�^�L��  HIT "+ew.Length.ToString()+"��";
//
//				//����̂݌����擾
//				if (_prevUserGdBdUWork == null) 
//				{
//					label7.Text = "�������F "+retTotalCnt.ToString()+" ��";
//				}
//				
//				for(int i = 0;i<ew.Length;i++)
//				{
//					volInsurGdWork = (UserGdBdUWork)ew[i];
//					listBox2.Items.Add(volInsurGdWork.ToString());
//					listBox2.Update();
//					if (i == ew.Length - 1) _prevUserGdBdUWork = (UserGdBdUWork)ew[i];
//				}
//				if (nextData)		label6.Text = "���f�[�^�L��";
//				else
//				{
//					numericUpDown1.Focus();
//					button5.Enabled = false;
//					label6.Text = "���f�[�^����";
//				}
//			}				
//					
		}

		private void button12_Click(object sender, System.EventArgs e)
		{

			byte[] parabyte = XmlByteSerializer.Serialize(_userGdBdUWork);

			//int status = IusergdbduDB.DeleteUserGdBdU(parabyte);
			int status = IusergdbduDB.Delete(parabyte);
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
			byte[] parabyte = XmlByteSerializer.Serialize(_userGdBdUWork);

			//int status = IusergdbduDB.RevivalLogicalDeleteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.RevivalLogicalDelete(ref parabyte);
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
				_userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdUWork));
				textBox7.Text = _userGdBdUWork.LogicalDeleteCode.ToString();
			}				
		
		}

		private void button8_Click(object sender, System.EventArgs e)
		{

		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButton1.Checked)
			{

			}																																	
		}

		private void button8_Click_1(object sender, System.EventArgs e)
		{
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			_userGdBdUWork = new UserGdBdUWork();
			_userGdBdUWork.EnterpriseCode = textBox1.Text;
			_userGdBdUWork.UserGuideDivCd = Convert.ToInt32(textBox2.Text);

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			object parabyte = _userGdBdUWork;
			object retbyte;

			//int status = IusergdbduDB.SearchGuidBody(out retbyte, parabyte, 0, 0);
			int status = IusergdbduDB.SearchGuideDivCode(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				ArrayList ew = retbyte as ArrayList;

				Text = "�Y���f�[�^�L��  HIT ";
				
				dataGrid4.DataSource = ew;
			}			
		}
	}
}

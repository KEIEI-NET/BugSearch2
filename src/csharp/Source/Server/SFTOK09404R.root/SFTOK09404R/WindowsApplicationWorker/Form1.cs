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
		private NoteGuidBdWork _noteGuidBdWork = null;

		private NoteGuidHdWork _noteGuidHdWork = null;

		//private UserGdBdUWork _prevUserGdBdUWork = null;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.Button button11;

		private INoteGuidBdDB IusergdbduDB = null;

		private static string[] _parameter;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
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
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.button11 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(688, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 23);
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
			this.button2.Location = new System.Drawing.Point(768, 344);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "SearchGuideDivCode";
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
			this.dataGrid1.Location = new System.Drawing.Point(488, 392);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(408, 320);
			this.dataGrid1.TabIndex = 13;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(768, 368);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "SearchBody";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(688, 80);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 23);
			this.button4.TabIndex = 15;
			this.button4.Text = "Write";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(688, 128);
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
			this.button12.Location = new System.Drawing.Point(688, 152);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(88, 23);
			this.button12.TabIndex = 31;
			this.button12.Text = "Delete";
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(688, 104);
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
			// dataGrid4
			// 
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(16, 392);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(464, 320);
			this.dataGrid4.TabIndex = 40;
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(352, 368);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(120, 23);
			this.button11.TabIndex = 41;
			this.button11.Text = "SearchHeader";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(592, 104);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(88, 23);
			this.button8.TabIndex = 46;
			this.button8.Text = "Revival";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(592, 152);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(88, 23);
			this.button10.TabIndex = 45;
			this.button10.Text = "Delete";
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(592, 128);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(88, 23);
			this.button13.TabIndex = 44;
			this.button13.Text = "LogicalDelete";
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(592, 80);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(88, 23);
			this.button14.TabIndex = 43;
			this.button14.Text = "Write";
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(592, 56);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(88, 23);
			this.button15.TabIndex = 42;
			this.button15.Text = "Read";
			this.button15.Click += new System.EventHandler(this.button15_Click);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(624, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 23);
			this.label9.TabIndex = 47;
			this.label9.Text = "Header";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(728, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 23);
			this.label10.TabIndex = 48;
			this.label10.Text = "Body";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(912, 726);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.button15);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.dataGrid4);
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
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.ResumeLayout(false);

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
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"Form1",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"Form1",ex.Message,0,MessageBoxButtons.OK);
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
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"Form1",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"Form1",e.ToString(),0,MessageBoxButtons.OK);
			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//if (_volInsurGdWork == null) _volInsurGdWork = new UserGdBdUWork();
			_noteGuidBdWork = new NoteGuidBdWork();
			_noteGuidBdWork.EnterpriseCode = textBox1.Text;
			_noteGuidBdWork.NoteGuideDivCode = Convert.ToInt32(textBox2.Text);
			_noteGuidBdWork.NoteGuideCode = Convert.ToInt32(textBox3.Text);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidBdWork);			

			//int status = IusergdbduDB.ReadUserGdBdU(ref parabyte,0);
			int status = IusergdbduDB.ReadBody(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

				Text = "�Y���f�[�^�L��";
				textBox1.Text = _noteGuidBdWork.EnterpriseCode;
				textBox2.Text = _noteGuidBdWork.NoteGuideDivCode.ToString();
				textBox3.Text = _noteGuidBdWork.NoteGuideCode.ToString();
				textBox4.Text = _noteGuidBdWork.NoteGuideName;
				textBox7.Text = _noteGuidBdWork.LogicalDeleteCode.ToString();
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);		
			IusergdbduDB = MediationNoteGuidBdDB.GetNoteGuidBdDB();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			_noteGuidBdWork = new NoteGuidBdWork();
			_noteGuidBdWork.EnterpriseCode = textBox1.Text;
			_noteGuidBdWork.NoteGuideDivCode = Convert.ToInt32(textBox2.Text);

			ArrayList al = new ArrayList();
			al.Add(_noteGuidBdWork);
			// XML�֕ϊ����A������̃o�C�i����
			object parabyte = al;			
			object retbyte;

			//int status = IusergdbduDB.SearchUserGdBdU(out retbyte, parabyte, 0, 0);
			int status = IusergdbduDB.SearchGuideDivCode(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)retbyte).Count.ToString()+"��";
				
				dataGrid1.DataSource = retbyte;
			}		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			_noteGuidBdWork = new NoteGuidBdWork();
			_noteGuidBdWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			object parabyte = _noteGuidBdWork;			
			object retbyte;

			//int status = IusergdbduDB.SearchUserGdBdU(out retbyte, parabyte, 0, 0);
			int status = IusergdbduDB.SearchBody(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)retbyte).Count.ToString()+"��";
				
				dataGrid1.DataSource = retbyte;
			}		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if(_noteGuidBdWork == null) _noteGuidBdWork = new NoteGuidBdWork();
			_noteGuidBdWork.EnterpriseCode = textBox1.Text;
			_noteGuidBdWork.NoteGuideDivCode = Convert.ToInt32(textBox2.Text);
			_noteGuidBdWork.NoteGuideCode = Convert.ToInt32(textBox3.Text);
			_noteGuidBdWork.NoteGuideName = textBox4.Text;
			
			_noteGuidBdWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidBdWork);

			//int status = IusergdbduDB.WriteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.WriteBody(ref parabyte);
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
				_noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));

			}		

		}


		private void button6_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidBdWork);

			//int status = IusergdbduDB.LogicalDeleteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.LogicalDeleteBody(ref parabyte);
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
				_noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));
				textBox7.Text = _noteGuidBdWork.LogicalDeleteCode.ToString();

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
			//_prevNoteGuidBdWork = null;
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

			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidBdWork);

			//int status = IusergdbduDB.DeleteUserGdBdU(parabyte);
			int status = IusergdbduDB.DeleteBody(parabyte);
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
			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidBdWork);

			//int status = IusergdbduDB.RevivalLogicalDeleteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.RevivalLogicalDeleteBody(ref parabyte);
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
				_noteGuidBdWork = (NoteGuidBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidBdWork));
				textBox7.Text = _noteGuidBdWork.LogicalDeleteCode.ToString();
			}				
		
		}

		private void button15_Click(object sender, System.EventArgs e)
		{
			//if (_volInsurGdWork == null) _volInsurGdWork = new UserGdBdUWork();
			_noteGuidHdWork = new NoteGuidHdWork();
			_noteGuidHdWork.EnterpriseCode = textBox1.Text;
			_noteGuidHdWork.NoteGuideDivCode = Convert.ToInt32(textBox2.Text);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidHdWork);			

			//int status = IusergdbduDB.ReadUserGdBdU(ref parabyte,0);
			int status = IusergdbduDB.ReadHeader(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

				Text = "�Y���f�[�^�L��";
				textBox1.Text = _noteGuidHdWork.EnterpriseCode;
				textBox2.Text = _noteGuidHdWork.NoteGuideDivCode.ToString();
				textBox4.Text = _noteGuidHdWork.NoteGuideDivName;
				textBox7.Text = _noteGuidHdWork.LogicalDeleteCode.ToString();
			}		
		
		}

		private void button14_Click(object sender, System.EventArgs e)
		{
			if(_noteGuidHdWork == null) _noteGuidHdWork = new NoteGuidHdWork();
			_noteGuidHdWork.EnterpriseCode = textBox1.Text;
			_noteGuidHdWork.NoteGuideDivCode = Convert.ToInt32(textBox2.Text);
			_noteGuidHdWork.NoteGuideDivName = textBox4.Text;
			
			_noteGuidHdWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidHdWork);

			//int status = IusergdbduDB.WriteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.WriteHeader(ref parabyte);
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
				_noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));

			}		
                     		
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidHdWork);

			//int status = IusergdbduDB.RevivalLogicalDeleteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.RevivalLogicalDeleteHeader(ref parabyte);
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
				_noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));
				textBox7.Text = _noteGuidHdWork.LogicalDeleteCode.ToString();
			}				
		
		}

		private void button13_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidHdWork);

			//int status = IusergdbduDB.LogicalDeleteUserGdBdU(ref parabyte);
			int status = IusergdbduDB.LogicalDeleteHeader(ref parabyte);
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
				_noteGuidHdWork = (NoteGuidHdWork)XmlByteSerializer.Deserialize(parabyte,typeof(NoteGuidHdWork));
				textBox7.Text = _noteGuidHdWork.LogicalDeleteCode.ToString();

			}				
		
		}

		private void button10_Click(object sender, System.EventArgs e)
		{

			byte[] parabyte = XmlByteSerializer.Serialize(_noteGuidHdWork);

			//int status = IusergdbduDB.DeleteUserGdBdU(parabyte);
			int status = IusergdbduDB.DeleteHeader(parabyte);
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

		private void button11_Click(object sender, System.EventArgs e)
		{
			_noteGuidHdWork = new NoteGuidHdWork();
			_noteGuidHdWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			object parabyte = _noteGuidHdWork;			
			object retbyte;

			//int status = IusergdbduDB.SearchUserGdBdU(out retbyte, parabyte, 0, 0);
			int status = IusergdbduDB.SearchHeader(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)retbyte).Count.ToString()+"��";
				
				dataGrid4.DataSource = retbyte;
			}		
		
		}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
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

		private PriceChgProcStWork _varCostWork = null;
		
		private PriceChgProcStWork _prevPriceChgProcStWork = null;
		private System.Windows.Forms.Button button7;

		private IPriceChgProcStDB IlctngtaxstDB = null;

		public Form1()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
            textBox1.Text = "YOKO";
            textBox7.Text = "0";
            textBox2.Text = "1";
            textBox6.Text = textBox1.Text;
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
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
			this.textBox2.Text = "2";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(264, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(248, 19);
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "";
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
			this.label1.Text = "�ŗ�����";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 104);
			this.label2.Name = "label2";
			this.label2.TabIndex = 7;
			this.label2.Text = "�ŗ��ŗL����";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(144, 136);
			this.label3.Name = "label3";
			this.label3.TabIndex = 8;
			this.label3.Text = "�ŗ�����";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(144, 160);
			this.label4.Name = "label4";
			this.label4.TabIndex = 9;
			this.label4.Text = "����œ]�ŕ���";
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
			this.dataGrid1.Location = new System.Drawing.Point(24, 392);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(488, 144);
			this.dataGrid1.TabIndex = 13;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(336, 368);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "SearchGrid";
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
			this.textBox7.Text = "1";
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
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(592, 550);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
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
			this.ResumeLayout(false);

		}
		#endregion

        /*
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
        */

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

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
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }


        // Read button
		private void button1_Click(object sender, System.EventArgs e)
		{
			_varCostWork = new PriceChgProcStWork();
			_varCostWork.EnterpriseCode = textBox1.Text;

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_varCostWork);			

			int status = IlctngtaxstDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_varCostWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte,typeof(PriceChgProcStWork));

				Text = "�Y���f�[�^�L��";
				textBox1.Text = _varCostWork.EnterpriseCode.ToString();

				textBox7.Text = _varCostWork.LogicalDeleteCode.ToString();
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);		
			//IlctngtaxstDB = MediationTaxRateSetDB.GetTaxRateSetDB();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			PriceChgProcStWork TaxRateSetInsWork = new PriceChgProcStWork();
			TaxRateSetInsWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(TaxRateSetInsWork);		
			byte[] retbyte;

			int status = IlctngtaxstDB.Search(out retbyte, parabyte, 5, 0);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				PriceChgProcStWork[] ew = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(retbyte,typeof(PriceChgProcStWork[]));

				Text = "�Y���f�[�^�L��  HIT "+ew.Length.ToString()+"��";
				
				for(int i = 0;i<ew.Length;i++)
				{
					TaxRateSetInsWork = (PriceChgProcStWork)ew[i];
					listBox1.Items.Add(TaxRateSetInsWork.ToString());
					listBox1.Update();
				}
				if (checkBox1.Checked) XmlByteSerializer.Serialize(ew,"c:\\testList.xml");	
			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			_varCostWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_varCostWork);			
			byte[] retbyte;

			int status = IlctngtaxstDB.Search(out retbyte, parabyte, 0, ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				PriceChgProcStWork[] ew = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(retbyte,typeof(PriceChgProcStWork[]));

				Text = "�Y���f�[�^�L��  HIT "+ew.Length.ToString()+"��";
				
				dataGrid1.DataSource = ew;
			}		
		}

        // Write button
		private void button4_Click(object sender, System.EventArgs e)
		{
			if (_varCostWork == null) _varCostWork = new PriceChgProcStWork();
//			_varCostWork = new PriceChgProcStWork();

			_varCostWork.EnterpriseCode = textBox1.Text;
			
			_varCostWork.LogicalDeleteCode = System.Convert.ToInt32(textBox7.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(_varCostWork);

			int status = IlctngtaxstDB.Write(ref parabyte);
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
				_varCostWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte,typeof(PriceChgProcStWork));

			}		

		}

        // LogicalDelete button
		private void button6_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_varCostWork);
			int status = IlctngtaxstDB.LogicalDelete(ref parabyte);
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
				_varCostWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte,typeof(PriceChgProcStWork));
				textBox7.Text = _varCostWork.LogicalDeleteCode.ToString();

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
			_prevPriceChgProcStWork = null;
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
			listBox2.Items.Clear();

			PriceChgProcStWork lcTngTaxStWork = new PriceChgProcStWork();
			byte[] parabyte;
			if (_prevPriceChgProcStWork == null)
			{
				lcTngTaxStWork.EnterpriseCode = textBox6.Text;
				parabyte = XmlByteSerializer.Serialize(lcTngTaxStWork);
			}
			else
			{
				parabyte = XmlByteSerializer.Serialize(_prevPriceChgProcStWork);	
			}

			byte[] retbyte;
			int retTotalCnt;
			bool nextData;

			int status = IlctngtaxstDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);

			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				PriceChgProcStWork[] ew = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(retbyte,typeof(PriceChgProcStWork[]));

				Text = "�Y���f�[�^�L��  HIT "+ew.Length.ToString()+"��";

				//����̂݌����擾
				if (_prevPriceChgProcStWork == null) 
				{
					label7.Text = "�������F "+retTotalCnt.ToString()+" ��";
				}
				
				for(int i = 0;i<ew.Length;i++)
				{
					lcTngTaxStWork = (PriceChgProcStWork)ew[i];
					listBox2.Items.Add(lcTngTaxStWork.ToString());
					listBox2.Update();
					if (i == ew.Length - 1) _prevPriceChgProcStWork = (PriceChgProcStWork)ew[i];
				}
				if (nextData)		label6.Text = "���f�[�^�L��";
				else
				{
					numericUpDown1.Focus();
					button5.Enabled = false;
					label6.Text = "���f�[�^����";
				}
			}				
					
		}

        // Delete button
		private void button12_Click(object sender, System.EventArgs e)
		{

			byte[] parabyte = XmlByteSerializer.Serialize(_varCostWork);
			int status = IlctngtaxstDB.Delete(parabyte);
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
			byte[] parabyte = XmlByteSerializer.Serialize(_varCostWork);
			int status = IlctngtaxstDB.RevivalLogicalDelete(ref parabyte);
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
				_varCostWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte,typeof(PriceChgProcStWork));
				textBox7.Text = _varCostWork.LogicalDeleteCode.ToString();
			}				
		
		}
	}
}

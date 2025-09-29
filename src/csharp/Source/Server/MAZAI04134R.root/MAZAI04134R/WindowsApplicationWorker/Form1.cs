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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		private StockWork _stockWork = null;

		//private StockWork _prevStockWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private IStockDB IstockDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button2;
        private DataGrid dataGrid3;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Button button3;
        private DataGrid dataGrid4;
        private Button button4;
        private DataGrid dataGrid5;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox5;
        private Label label10;
        private TextBox textBox6;
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid5 = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "TBS1";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 185);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 116);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 40);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(260, 156);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(354, 156);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(16, 156);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(426, 156);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(498, 156);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(570, 156);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 69);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "AddRow";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(16, 336);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(909, 116);
            this.dataGrid3.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "EnterpriseCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "SectionCode";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(378, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 19);
            this.textBox2.TabIndex = 43;
            this.textBox2.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "MakerCode";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(543, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(78, 19);
            this.textBox3.TabIndex = 45;
            this.textBox3.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(639, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "GoodsCode";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(714, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 19);
            this.textBox4.TabIndex = 47;
            this.textBox4.Text = "SH903i";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 459);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 50;
            this.button3.Text = "AddRow";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGrid4
            // 
            this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid4.DataMember = "";
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(16, 488);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.Size = new System.Drawing.Size(909, 116);
            this.dataGrid4.TabIndex = 49;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 611);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 23);
            this.button4.TabIndex = 52;
            this.button4.Text = "AddRow";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGrid5
            // 
            this.dataGrid5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid5.DataMember = "";
            this.dataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid5.Location = new System.Drawing.Point(16, 640);
            this.dataGrid5.Name = "dataGrid5";
            this.dataGrid5.Size = new System.Drawing.Size(909, 116);
            this.dataGrid5.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "�݌Ƀ}�X�^";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "���ԍ݌Ƀ}�X�^";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "�݌Ɏ󕥗����}�X�^";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 616);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 12);
            this.label8.TabIndex = 56;
            this.label8.Text = "�݌Ɏ󕥗����}�X�^";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 58;
            this.label9.Text = "AcPaySlipCd";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(378, 45);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(78, 19);
            this.textBox5.TabIndex = 57;
            this.textBox5.Text = "10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(468, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 12);
            this.label10.TabIndex = 60;
            this.label10.Text = "AcPaySlipNum";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(554, 45);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(78, 19);
            this.textBox6.TabIndex = 59;
            this.textBox6.Text = "10001";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 784);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).EndInit();
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
        /// 1���ǂݍ��ݏ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
//			if (_stockWork == null) _stockWork = new StockWork();
			_stockWork = new StockWork();
			_stockWork.EnterpriseCode = textBox1.Text;
            //_stockWork.SectionCode = textBox2.Text;
            //_stockWork.RecordReadKey = Convert.ToInt32(textBox3.Text);
            //_stockWork.NewOrModifiRatioCd = Convert.ToInt32(textBox4.Text);
            //_stockWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_stockWork);			

			int status = IstockDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_stockWork = (StockWork)XmlByteSerializer.Deserialize(parabyte,typeof(StockWork));

				Text = "�Y���f�[�^�L��";
                ArrayList al = new ArrayList();
                al.Add(_stockWork);
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
			IstockDB = MediationStockDB.GetStockDB();
		}

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button9_Click(object sender, System.EventArgs e)
		{
            dataGrid1.DataSource = null;
            dataGrid3.DataSource = null;
			dataGrid2.DataSource = null;
            ArrayList al = new ArrayList();
            StockWork work = new StockWork();
            work.EnterpriseCode = textBox1.Text;
            al.Add(work);
            dataGrid2.DataSource = al;
		}

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button8_Click(object sender, System.EventArgs e)
		{
			object parabyte = dataGrid2.DataSource;
			object objstock;

			int status = IstockDB.Search(out objstock, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{

				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)objstock).Count.ToString()+"��";
				
				dataGrid1.DataSource = objstock;
			}
		}

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
			object objstockWork = dataGrid1.DataSource;
			int status = IstockDB.Write(ref objstockWork);
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
                dataGrid1.DataSource = objstockWork as ArrayList;
			}		
		}

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
			StockWork stockWork = new StockWork();
            stockWork.EnterpriseCode = textBox1.Text;
            stockWork.SectionCode = textBox2.Text;
            stockWork.GoodsMakerCd = Convert.ToInt32(textBox3.Text);
            stockWork.GoodsNo = textBox4.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(stockWork);
			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
		}

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button13_Click(object sender, System.EventArgs e)
		{
            object objstockWork = dataGrid1.DataSource;

            int status = IstockDB.LogicalDelete(ref objstockWork);
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
                dataGrid1.DataSource = objstockWork as ArrayList;
            }
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            object objstockWork = dataGrid1.DataSource;

            StockWork[] trarray = (StockWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(StockWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IstockDB.Delete(parabyte);
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
                dataGrid1.DataSource = null;
                //dataGrid1.DataSource = objstockWork;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            object objstockWork = dataGrid1.DataSource;

            int status = IstockDB.RevivalLogicalDelete(ref objstockWork);
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
                dataGrid1.DataSource = objstockWork as ArrayList;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void setretlist(object retlist)
        {
            CustomSerializeArrayList paraList = retlist as CustomSerializeArrayList;

            //���X�g����K�v�ȏ����擾
            for (int i = 0; i < paraList.Count; i++)
            {
                ArrayList wkal = paraList[i] as ArrayList;
                if (wkal != null)
                {
                    if (wkal.Count > 0)
                    {
                        //�݌Ƀ}�X�^�Ń��X�g��NULL�̏ꍇ
                        if (wkal[0] is StockWork)
                        {
                            dataGrid1.DataSource = null; 
                            dataGrid1.DataSource = wkal;
                        }
                        //�݌Ɏ󕥗����}�X�^�̏ꍇ
                        if (wkal[0] is StockAcPayHistWork)
                        {
                            dataGrid5.DataSource = null;
                            dataGrid5.DataSource = wkal;
                        }
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
            stockAcPayHistWork.EnterpriseCode = textBox1.Text;
            stockAcPayHistWork.SectionCode = textBox2.Text;
            stockAcPayHistWork.GoodsMakerCd = Convert.ToInt32(textBox3.Text);
            stockAcPayHistWork.GoodsNo = textBox4.Text;
            stockAcPayHistWork.AcPaySlipCd = Convert.ToInt32(textBox5.Text);
            stockAcPayHistWork.AcPaySlipNum = textBox6.Text;
            ArrayList al = dataGrid4.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(stockAcPayHistWork);
            dataGrid4.DataSource = null;
            dataGrid4.DataSource = al;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StockAcPayHistWork stockAcPayHistWork = new StockAcPayHistWork();
            stockAcPayHistWork.EnterpriseCode = textBox1.Text;
            stockAcPayHistWork.SectionCode = textBox2.Text;
            stockAcPayHistWork.GoodsMakerCd = Convert.ToInt32(textBox3.Text);
            stockAcPayHistWork.GoodsNo = textBox4.Text;
            stockAcPayHistWork.AcPaySlipCd = Convert.ToInt32(textBox5.Text);
            stockAcPayHistWork.AcPaySlipNum = textBox6.Text;
            ArrayList al = dataGrid5.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(stockAcPayHistWork);
            dataGrid5.DataSource = null;
            dataGrid5.DataSource = al;
        }

	}
}

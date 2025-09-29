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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;

        private PMakerNmWork _pMakerNmWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox LogicalDeletetextBox;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;

		private IPMakerNmDB IpmakernmDB = null;

        private static string[] _parameter;
        private Label label14;
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LogicalDeletetextBox = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "TBS1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(184, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "���i���[�J�[�R�[�h";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 164);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(888, 332);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(560, 135);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(520, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "�_���폜�敪";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogicalDeletetextBox
            // 
            this.LogicalDeletetextBox.Location = new System.Drawing.Point(664, 96);
            this.LogicalDeletetextBox.Name = "LogicalDeletetextBox";
            this.LogicalDeletetextBox.Size = new System.Drawing.Size(24, 19);
            this.LogicalDeletetextBox.TabIndex = 23;
            this.LogicalDeletetextBox.Text = "0";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(744, 135);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "CstomSearchGrid";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(24, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 23);
            this.label10.TabIndex = 36;
            this.label10.Text = "��ƃR�[�h";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(24, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(512, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "�v���C�}���L�[";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(184, 89);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(288, 19);
            this.textBox3.TabIndex = 58;
            this.textBox3.Text = "10";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(24, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 16);
            this.label14.TabIndex = 57;
            this.label14.Text = "���i���[�J�[����";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(904, 502);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.LogicalDeletetextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			_pMakerNmWork = new PMakerNmWork();
            _pMakerNmWork.PartsMakerCode = int.Parse(textBox2.Text);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_pMakerNmWork);			

			int status = IpmakernmDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_pMakerNmWork = (PMakerNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(PMakerNmWork));

				Text = "�Y���f�[�^�L��";
                textBox2.Text = _pMakerNmWork.PartsMakerCode.ToString();
                textBox3.Text = _pMakerNmWork.PartsMakerFullName.ToString();

			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile , false);		
			IpmakernmDB = MediationPMakerNmDB.GetPMakerNmDB();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
		}


		private void button6_Click(object sender, System.EventArgs e)
		{
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			_pMakerNmWork = null;
			dataGrid1.DataSource = null;
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			PMakerNmWork pMakerNmWork = new PMakerNmWork();

			object paraobj = pMakerNmWork;
			object retobj = null;
			int status = IpmakernmDB.Search(out retobj, 0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)retobj).Count.ToString()+"��";
				
				dataGrid1.DataSource = retobj;
			}		
		}

	}
}

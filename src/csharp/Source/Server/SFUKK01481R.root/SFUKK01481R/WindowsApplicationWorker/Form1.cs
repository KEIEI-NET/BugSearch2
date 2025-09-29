using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;


using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label3;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit3;
		private System.Windows.Forms.Button button5;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Button button6;
        private IControlDepsitAlwDB IcontrolDepsitAlwDB = null;

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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.button1 = new System.Windows.Forms.Button();
            this.tNedit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tNedit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tNedit3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tNedit1
            // 
            this.tNedit1.ActiveAppearance = appearance4;
            this.tNedit1.AutoSelect = true;
            this.tNedit1.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.tNedit1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit1.DataText = "tNedit1";
            this.tNedit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit1.Location = new System.Drawing.Point(136, 44);
            this.tNedit1.MaxLength = 12;
            this.tNedit1.Name = "tNedit1";
            this.tNedit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit1.Size = new System.Drawing.Size(97, 21);
            this.tNedit1.TabIndex = 1;
            this.tNedit1.Text = "tNedit1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "�󒍔ԍ�";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "���Ӑ�R�[�h";
            // 
            // tNedit2
            // 
            this.tNedit2.ActiveAppearance = appearance5;
            this.tNedit2.AutoSelect = true;
            this.tNedit2.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.tNedit2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit2.DataText = "tNedit2";
            this.tNedit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit2.Location = new System.Drawing.Point(136, 12);
            this.tNedit2.MaxLength = 12;
            this.tNedit2.Name = "tNedit2";
            this.tNedit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit2.Size = new System.Drawing.Size(97, 21);
            this.tNedit2.TabIndex = 3;
            this.tNedit2.Text = "tNedit2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "�����폜";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(272, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(232, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "�������`�F�b�N";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(228, 24);
            this.button4.TabIndex = 7;
            this.button4.Text = "�������`�F�b�N(�ԁE���E�ςݍ����O)";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "�Ԏ󒍔ԍ�";
            // 
            // tNedit3
            // 
            this.tNedit3.ActiveAppearance = appearance6;
            this.tNedit3.AutoSelect = true;
            this.tNedit3.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.tNedit3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit3.DataText = "tNedit3";
            this.tNedit3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit3.Location = new System.Drawing.Point(136, 80);
            this.tNedit3.MaxLength = 12;
            this.tNedit3.Name = "tNedit3";
            this.tNedit3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit3.Size = new System.Drawing.Size(97, 21);
            this.tNedit3.TabIndex = 8;
            this.tNedit3.Text = "tNedit3";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(368, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(132, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "�Ԉ����쐬";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(36, 148);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "ReadDB_Test";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(572, 278);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tNedit3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tNedit2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tNedit1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private static string[] _parameter;
		private static System.Windows.Forms.Form _form = null;

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main(String[] args) 
		{
			//			Application.Run(new Form1());
			try
			{
				string msg = "";
				_parameter = args;
				//�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B
			�@�@//�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, 
�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();
					System.Windows.Forms.Application.Run(_form);
				}
				if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"Sample",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"Sample",ex.Message,0,MessageBoxButtons.OK);
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
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"Sample",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"Sample",e.ToString(),0,MessageBoxButtons.OK);
			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);	
            IcontrolDepsitAlwDB = MediationControlDepsitAlwDB.GetControlDepsitAlwDB();

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DepositAlwWork[]  depositAlwWorkList;
			string errmsg;

			ControlDepsitAlwAcs controlDepsitAlwAcs = new ControlDepsitAlwAcs();
			int status = controlDepsitAlwAcs.ReadDB("0140150842030000", tNedit2.GetInt(), tNedit1.GetInt(), out depositAlwWorkList, out errmsg);
			if (status == 0)
				MessageBox.Show("status=" + status.ToString() + " count=" + depositAlwWorkList.Length.ToString());
			else
				MessageBox.Show("status=" + status.ToString() );	
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string errmsg;

			ControlDepsitAlwAcs controlDepsitAlwAcs = new ControlDepsitAlwAcs();
			int status = controlDepsitAlwAcs.DeleteDB("0140150842030000", tNedit2.GetInt(), tNedit1.GetInt(), out errmsg);

			MessageBox.Show("status=" + status.ToString() );	
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string errmsg;
			int count;

			ControlDepsitAlwAcs controlDepsitAlwAcs = new ControlDepsitAlwAcs();
			int status = controlDepsitAlwAcs.GetCountDB(0, "0140150842030000", tNedit2.GetInt(), tNedit1.GetInt(), out count, out errmsg);

			MessageBox.Show("status=" + status.ToString() + " Count=" +  count.ToString());		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			string errmsg;
			int count;

			ControlDepsitAlwAcs controlDepsitAlwAcs = new ControlDepsitAlwAcs();
			int status = controlDepsitAlwAcs.GetCountDB(1, "0140150842030000", tNedit2.GetInt(), tNedit1.GetInt(), out count, out errmsg);

			MessageBox.Show("status=" + status.ToString() + " Count=" +  count.ToString());		
		
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			//string errmsg;

			ControlDepsitAlwAcs controlDepsitAlwAcs = new ControlDepsitAlwAcs();
			//int status = controlDepsitAlwAcs.CreateRedDepositAllowance("0140150842030000", tNedit2.GetInt(), tNedit1.GetInt(), tNedit3.GetInt(), out errmsg);

			//MessageBox.Show("status=" + status.ToString() );		
		}

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] depositAlwWorkListByte = null;
            int status = IcontrolDepsitAlwDB.ReadDB("0113180842031000", 1100, 30, "000100497", out depositAlwWorkListByte);
        }

	}
}

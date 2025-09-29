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
    /// 
    /// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        #region Windows

        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.TextBox tb08;
        #endregion

        private ITtlDayCalcDB iTtlDayCalcDB = null;

        private static string[] _parameter;
        private Button button3;
        private TextBox tb15;
        private Label label4;
		private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// 
        /// </summary>
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
            this.button3 = new System.Windows.Forms.Button();
            this.tb15 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point( 122, 72 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 99, 24 );
            this.button3.TabIndex = 228;
            this.button3.TabStop = false;
            this.button3.Text = "��������";
            this.button3.Click += new System.EventHandler( this.button3_Click );
            // 
            // tb15
            // 
            this.tb15.Location = new System.Drawing.Point( 122, 28 );
            this.tb15.Name = "tb15";
            this.tb15.Size = new System.Drawing.Size( 72, 19 );
            this.tb15.TabIndex = 238;
            this.tb15.TabStop = false;
            this.tb15.Text = "-1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font( "MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.label4.Location = new System.Drawing.Point( 12, 28 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 104, 19 );
            this.label4.TabIndex = 241;
            this.label4.Text = "���_�R�[�h";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 12 );
            this.ClientSize = new System.Drawing.Size( 259, 129 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.tb15 );
            this.Controls.Add( this.button3 );
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler( this.Form1_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }
		#endregion


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


		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            iTtlDayCalcDB = MediationTtlDayCalcDB.GetTtlDayCalcDB();
		}

        private void button3_Click(object sender, EventArgs e)
        {
            //..

            TtlDayCalcParaWork para = new TtlDayCalcParaWork();
            para.EnterpriseCode = "0101150842020000";
            para.SectionCode = "";
            para.ProcDiv = 0;
            para.WithMasterDiv = 1;

            object retObj;
            //iTtlDayCalcDB.SearchHisMonthly( out retObj, para );   // ��������
            //iTtlDayCalcDB.SearchHisDmdC( out retObj, para );    // ���𐿋�
            //iTtlDayCalcDB.SearchHisPayment( out retObj, para );    // �����x��
            //iTtlDayCalcDB.SearchPrcMonthlyAccRec( out retObj, para );   // ���z�������|
            //iTtlDayCalcDB.SearchPrcMonthlyAccPay( out retObj, para );   // ���z�������|
            //iTtlDayCalcDB.SearchPrcDmdC( out retObj, para );   // ���z����
            //iTtlDayCalcDB.SearchPrcPayment( out retObj, para );   // ���z�x��

            iTtlDayCalcDB.SearchHisMonthly( out retObj, para );   // ��������

            if ( retObj != null )
            {
                if ( retObj is CustomSerializeArrayList )
                {
                    //(retObj as CustomSerializeArrayList)[0] 
                }
                else
                {
                    MessageBox.Show( "! retObj is CustomSerializeArrayList" );
                }
            }
            else
            {
                MessageBox.Show( "retObj == null" );
            }
        }

	}
}

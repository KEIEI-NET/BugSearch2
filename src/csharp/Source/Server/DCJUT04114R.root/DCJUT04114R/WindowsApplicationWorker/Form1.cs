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
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		//private AcptAnOdrRemainRefWork _prevAcptAnOdrRemainRefWork = null;
        private System.Windows.Forms.Button button8;

		private IAcptAnOdrRemainRefDB IacptanodrremainrefDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 189);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(869, 382);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(230, 9);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(131, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "���������N���A";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.Location = new System.Drawing.Point(12, 160);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "����";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(12, 38);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(869, 116);
            this.dataGrid2.TabIndex = 39;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 16);
            this.radioButton1.TabIndex = 43;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "����f�[�^����";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(122, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 16);
            this.radioButton2.TabIndex = 44;
            this.radioButton2.Text = "�d���f�[�^����";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(901, 585);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
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
        /// FromLoad���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);		
			IacptanodrremainrefDB = MediationAcptAnOdrRemainRefDB.GetAcptAnOdrRemainRefDB();
		}

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button9_Click(object sender, System.EventArgs e)
		{
			dataGrid1.DataSource = null;
			dataGrid2.DataSource = null;

            CustomSerializeArrayList al = new CustomSerializeArrayList();
            
            object work = null;
            
            if (radioButton1.Checked)
            {
                // ����f�[�^����
                work = new AcptAnOdrRemainRefCndtnWork();

                (work as AcptAnOdrRemainRefCndtnWork).EnterpriseCode = "0101150842020000";
                (work as AcptAnOdrRemainRefCndtnWork).SectionCode = "01";
                (work as AcptAnOdrRemainRefCndtnWork).CustomerCode = 1;
                (work as AcptAnOdrRemainRefCndtnWork).ClaimCode = 1;
                (work as AcptAnOdrRemainRefCndtnWork).AcpOdrStateDiv = 1;
                (work as AcptAnOdrRemainRefCndtnWork).FullModel = "A";
                (work as AcptAnOdrRemainRefCndtnWork).St_SearchSlipDate = new DateTime(2008,07,01);
                (work as AcptAnOdrRemainRefCndtnWork).Ed_SearchSlipDate = new DateTime(2008,07,01);
                (work as AcptAnOdrRemainRefCndtnWork).St_SalesDate = new DateTime(2008,07,01);
                (work as AcptAnOdrRemainRefCndtnWork).Ed_SalesDate = new DateTime(2008,07,01);
                (work as AcptAnOdrRemainRefCndtnWork).St_SalesSlipNum = "1";
                (work as AcptAnOdrRemainRefCndtnWork).Ed_SalesSlipNum = "1";
                (work as AcptAnOdrRemainRefCndtnWork).SalesInputCode = "1";
                (work as AcptAnOdrRemainRefCndtnWork).FrontEmployeeCd = "1";
                (work as AcptAnOdrRemainRefCndtnWork).SalesEmployeeCd = "1";
                (work as AcptAnOdrRemainRefCndtnWork).GoodsMakerCd = 1;
                (work as AcptAnOdrRemainRefCndtnWork).GoodsNo = "A";
                (work as AcptAnOdrRemainRefCndtnWork).GoodsName = "a";
                (work as AcptAnOdrRemainRefCndtnWork).GoodsNameSrchTyp = 0;
            }
            else
            {
                // �d���f�[�^����
                work = null;
            }
            
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
			object parabyte = (dataGrid2.DataSource as ArrayList)[0];
            object objacptanodrremainRef = null;

            int status = 0;

			if (radioButton1.Checked)
            {
                status = IacptanodrremainrefDB.Search(out objacptanodrremainRef, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
            }
            else
            {

            }
            
			if (status != 0)
			{
                Text = string.Format("�Y���f�[�^���� (st = {0})", status);
			}
			else
			{
				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)objacptanodrremainRef).Count.ToString()+"��";
				dataGrid1.DataSource = objacptanodrremainRef;
			}
        }
	}
}

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

		private GoodsWork _goodsWork = null;

		//private GoodsWork _prevGoodsWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private IGoodsDB IgoodsDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
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
((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
this.SuspendLayout();
// 
// button1
// 
this.button1.Location = new System.Drawing.Point(312, 16);
this.button1.Name = "button1";
this.button1.Size = new System.Drawing.Size(75, 23);
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
// dataGrid1
// 
this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.dataGrid1.DataMember = "";
this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
this.dataGrid1.Location = new System.Drawing.Point(16, 185);
this.dataGrid1.Name = "dataGrid1";
this.dataGrid1.Size = new System.Drawing.Size(909, 351);
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
this.button8.Location = new System.Drawing.Point(82, 156);
this.button8.Name = "button8";
this.button8.Size = new System.Drawing.Size(88, 23);
this.button8.TabIndex = 33;
this.button8.Text = "Search";
this.button8.Click += new System.EventHandler(this.button8_Click);
// 
// button10
// 
this.button10.Location = new System.Drawing.Point(288, 156);
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
this.button13.Location = new System.Drawing.Point(360, 156);
this.button13.Name = "button13";
this.button13.Size = new System.Drawing.Size(72, 23);
this.button13.TabIndex = 36;
this.button13.Text = "LogDelGrid";
this.button13.Click += new System.EventHandler(this.button13_Click);
// 
// button14
// 
this.button14.Location = new System.Drawing.Point(432, 156);
this.button14.Name = "button14";
this.button14.Size = new System.Drawing.Size(72, 23);
this.button14.TabIndex = 37;
this.button14.Text = "RevGrid";
this.button14.Click += new System.EventHandler(this.button14_Click);
// 
// button15
// 
this.button15.Location = new System.Drawing.Point(504, 156);
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
this.dataGrid2.Location = new System.Drawing.Point(16, 69);
this.dataGrid2.Name = "dataGrid2";
this.dataGrid2.Size = new System.Drawing.Size(909, 81);
this.dataGrid2.TabIndex = 39;
// 
// Form1
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
this.ClientSize = new System.Drawing.Size(941, 550);
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
//			if (_goodsWork == null) _goodsWork = new GoodsWork();
			_goodsWork = new GoodsWork();
			//_goodsWork.EnterpriseCode = textBox1.Text;
            //_goodsWork.SectionCode = textBox2.Text;
            //_goodsWork.RecordReadKey = Convert.ToInt32(textBox3.Text);
            //_goodsWork.NewOrModifiRatioCd = Convert.ToInt32(textBox4.Text);
            //_goodsWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

      _goodsWork.GoodsMakerCd = 4;
      _goodsWork.GoodsNo = "6";
      // XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_goodsWork);			

			int status = IgoodsDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_goodsWork = (GoodsWork)XmlByteSerializer.Deserialize(parabyte,typeof(GoodsWork));

				Text = "�Y���f�[�^�L��";
                ArrayList al = new ArrayList();
                al.Add(_goodsWork);
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
			IgoodsDB = MediationGoodsDB.GetGoodsDB();
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
            ArrayList al = new ArrayList();
            GoodsWork work = new GoodsWork();
            //work.EnterpriseCode = textBox1.Text;
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
      _goodsWork = new GoodsWork();
      //_goodsWork.GoodsMakerCd = 4;
      //_goodsWork.GoodsNo = "5";
      object parabyte = _goodsWork;
			
			object objgoods;

			int status = IgoodsDB.Search(out objgoods, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{

				Text = "�Y���f�[�^�L��  HIT "+((ArrayList)objgoods).Count.ToString()+"��";
				
				dataGrid1.DataSource = objgoods;
			}
		}

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
			object objgoodsWork = dataGrid1.DataSource;

            int status = 0;// IgoodsDB.Write(ref objgoodsWork);
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
				dataGrid1.DataSource = null;
				dataGrid1.DataSource = objgoodsWork;
			}		
		}

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
			GoodsWork goodsWork = new GoodsWork();
			//goodsWork.EnterpriseCode = textBox1.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(goodsWork);
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
            object objgoodsWork = dataGrid1.DataSource;

            int status = 0;// IgoodsDB.LogicalDelete(ref objgoodsWork);
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
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objgoodsWork;
            }
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            object objgoodsWork = dataGrid1.DataSource;

            GoodsWork[] trarray = (GoodsWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(GoodsWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = 0;// IgoodsDB.Delete(parabyte);
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
                //dataGrid1.DataSource = objgoodsWork;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            object objgoodsWork = dataGrid1.DataSource;

            int status = 0;// IgoodsDB.RevivalLogicalDelete(ref objgoodsWork);
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
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objgoodsWork;
            }
        }
	}
}

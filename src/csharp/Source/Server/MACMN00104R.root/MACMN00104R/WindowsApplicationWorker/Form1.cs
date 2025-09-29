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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

        private GoodsCndtnWork _goodsRelationDataWork = null;

		//private GoodsCndtnWork _prevGoodsCndtnWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private IGoodsURelationDataDB IgoodsurelationdataDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private ComboBox comboBox1;
        private Button button2;
        private DataGrid dataGrid3;
        private Button button3;
        private DataGrid dataGrid4;
        private Button button4;
        private DataGrid dataGrid5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button5;
        private DataGrid dataGrid6;
        private Label label5;
        private Label label6;
        private Button button1;
        private Label label7;
        private TextBox textBox2;
        private Label label8;
        private TextBox textBox3;
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid5 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGrid6 = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0113180842031000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 185);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1051, 115);
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
            this.button8.Location = new System.Drawing.Point(179, 156);
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
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 69);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(1051, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(793, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 20);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "AddRow";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(16, 338);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(1051, 115);
            this.dataGrid3.TabIndex = 41;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 461);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "AddRow";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGrid4
            // 
            this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid4.DataMember = "";
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(16, 490);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.Size = new System.Drawing.Size(1051, 115);
            this.dataGrid4.TabIndex = 43;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 615);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 23);
            this.button4.TabIndex = 46;
            this.button4.Text = "AddRow";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGrid5
            // 
            this.dataGrid5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid5.DataMember = "";
            this.dataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid5.Location = new System.Drawing.Point(16, 644);
            this.dataGrid5.Name = "dataGrid5";
            this.dataGrid5.Size = new System.Drawing.Size(1051, 115);
            this.dataGrid5.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "���i�}�X�^";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "�@�폤�i�}�X�^";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 620);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "�t���i�}�X�^";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 772);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "�Ǘ����}�X�^";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 767);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 23);
            this.button5.TabIndex = 51;
            this.button5.Text = "AddRow";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGrid6
            // 
            this.dataGrid6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid6.DataMember = "";
            this.dataGrid6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid6.Location = new System.Drawing.Point(16, 796);
            this.dataGrid6.Name = "dataGrid6";
            this.dataGrid6.Size = new System.Drawing.Size(1051, 115);
            this.dataGrid6.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "���i�A���f�[�^";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "EnterpriseCode";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(594, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(470, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "GoodsCode";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(539, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 19);
            this.textBox2.TabIndex = 55;
            this.textBox2.Text = "100";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "MakerCode";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(386, 13);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(57, 19);
            this.textBox3.TabIndex = 57;
            this.textBox3.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1083, 954);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGrid6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.comboBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).EndInit();
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
//			if (_goodsRelationDataWork == null) _goodsRelationDataWork = new GoodsURelationDataWork();
			_goodsRelationDataWork = new GoodsCndtnWork();
			_goodsRelationDataWork.EnterpriseCode = textBox1.Text;
            //_goodsRelationDataWork.SectionCode = textBox2.Text;
            //_goodsRelationDataWork.RecordReadKey = Convert.ToInt32(textBox3.Text);
            //_goodsRelationDataWork.NewOrModifiRatioCd = Convert.ToInt32(textBox4.Text);
            //_goodsRelationDataWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(_goodsRelationDataWork);

            int status = 0;// IgoodsurelationdataDB.Read(ref parabyte, 0);
			if (status != 0)
			{
				Text = "�Y���f�[�^����";
			}
			else
			{
				// XML�̓ǂݍ���
				_goodsRelationDataWork = (GoodsCndtnWork)XmlByteSerializer.Deserialize(parabyte,typeof(GoodsCndtnWork));

				Text = "�Y���f�[�^�L��";
                ArrayList al = new ArrayList();
                al.Add(_goodsRelationDataWork);
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
			IgoodsurelationdataDB = MediationGoodsURelationDataDB.GetGoodsURelationDataDB();
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
            GoodsCndtnWork work = new GoodsCndtnWork();
            work.EnterpriseCode = textBox1.Text;
            //work.GoodsValiditySrchCode = new int[] { 0, 1, 2 };
            //work.GoodsValiditySrchCode = new int[] { 0, 1, 2 };
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
            //ArrayList al = new ArrayList();

            //al.Add(_goodsRelationDataWork);
			object paraobj = dataGrid2.DataSource;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            //retList.Add(new CarrierWork());
            retList.Add(new GoodsUnitDataWork());
            retList.Add(new GoodsMngWork());
            object retobj = retList;

            int status = IgoodsurelationdataDB.Search(ref retobj,paraobj,0,0);

            if (status != 0)
			{
				Text = "�Y���f�[�^���� ST = "+status.ToString();
			}
			else
			{

                //Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)objoodRelationData).Count.ToString() + "��";
                Text = "�Y���f�[�^�L��  HIT " + ((CustomSerializeArrayList)retobj).Count.ToString() + "��";

                comboBox1.DataSource = retobj;
                //comboBox1.DisplayMember = 
                dataGrid1.DataSource = ((CustomSerializeArrayList)retobj)[0];
			}
		}

        /// <summary>
        /// �X�V����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
            CustomSerializeArrayList SCAList = new CustomSerializeArrayList();
            if (dataGrid1.DataSource != null) SCAList.Add(dataGrid1.DataSource);

			object objgoodsRelationDataWork = SCAList;

            int status = IgoodsurelationdataDB.WriteRelation(ref objgoodsRelationDataWork);
			if (status != 0)
			{
				Text = "�X�V���s ST="+status.ToString();
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
                dataGrid1.DataSource = ((CustomSerializeArrayList)objgoodsRelationDataWork)[0];
			}		
		}

        /// <summary>
        /// �s�ǉ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
      GoodsUnitDataWork goodsRelationDataWork = new GoodsUnitDataWork();
			goodsRelationDataWork.EnterpriseCode = textBox1.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(goodsRelationDataWork);
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
            CustomSerializeArrayList SCAList = new CustomSerializeArrayList();
            if (dataGrid1.DataSource != null) SCAList.Add(dataGrid1.DataSource);

            object objgoodsRelationDataWork = SCAList;

            int status = IgoodsurelationdataDB.LogicalDeleteRelation(ref objgoodsRelationDataWork);
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
                dataGrid1.DataSource = ((CustomSerializeArrayList)objgoodsRelationDataWork)[0];
            }
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            object objgoodsRelationDataWork = dataGrid1.DataSource;

            GoodsCndtnWork[] trarray = (GoodsCndtnWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(GoodsUnitDataWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IgoodsurelationdataDB.DeleteRelation(parabyte);
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
                //dataGrid1.DataSource = objgoodsRelationDataWork;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            CustomSerializeArrayList SCAList = new CustomSerializeArrayList();
            if (dataGrid1.DataSource != null) SCAList.Add(dataGrid1.DataSource);

            object objgoodsRelationDataWork = SCAList;
            int status = IgoodsurelationdataDB.RevivalLogicalDeleteRelation(ref objgoodsRelationDataWork);
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
                dataGrid1.DataSource = ((CustomSerializeArrayList)objgoodsRelationDataWork)[0];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid1.DataSource = comboBox1.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoodsUWork goodsUWork = new GoodsUWork();
            goodsUWork.EnterpriseCode = textBox1.Text;
            goodsUWork.GoodsNo = textBox2.Text;
            goodsUWork.GoodsMakerCd = Convert.ToInt32(textBox3.Text);
            ArrayList al = dataGrid3.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(goodsUWork);
            dataGrid3.DataSource = null;
            dataGrid3.DataSource = al;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CellphoneUWork cellphoneUWork = new CellphoneUWork();
            //cellphoneUWork.EnterpriseCode = textBox1.Text;
            //cellphoneUWork.GoodsCode = textBox2.Text;
            //cellphoneUWork.MakerCode = Convert.ToInt32(textBox3.Text);
            //ArrayList al = dataGrid4.DataSource as ArrayList;
            //if (al == null) al = new ArrayList();
            //al.Add(cellphoneUWork);
            //dataGrid4.DataSource = null;
            //dataGrid4.DataSource = al;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //AccessoriesUWork accessoriesUWork = new AccessoriesUWork();
            //accessoriesUWork.EnterpriseCode = textBox1.Text;
            //accessoriesUWork.GoodsCode = textBox2.Text;
            //accessoriesUWork.MakerCode = Convert.ToInt32(textBox3.Text);
            //ArrayList al = dataGrid5.DataSource as ArrayList;
            //if (al == null) al = new ArrayList();
            //al.Add(accessoriesUWork);
            //dataGrid5.DataSource = null;
            //dataGrid5.DataSource = al;
        }

        private void button5_Click(object sender, EventArgs e)
        {
          /*
            GoodsMngWork goodsMngWork = new GoodsMngWork();
            goodsMngWork.EnterpriseCode = textBox1.Text;
            goodsMngWork.GoodsCode = textBox2.Text;
            goodsMngWork.MakerCode = Convert.ToInt32(textBox3.Text);
            ArrayList al = dataGrid6.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(goodsMngWork);
            dataGrid6.DataSource = null;
            dataGrid6.DataSource = al;
           */ 
        }
	}
}

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
	/// Form1 の概要の説明です。
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
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;

		//private UserGdBdWork _volInsurGdWork = null;
		private UserGdBdWork _userGdBdWork = null;

		private UserGdHdWork _userGdHdWork = null;
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

		private IUserGdBdDB IusergdbdDB = null;

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

		public Form1()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
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
			this.button9 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.button5 = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
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
			this.label1.Text = "ガイド区分";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "ガイドコード";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(144, 128);
			this.label3.Name = "label3";
			this.label3.TabIndex = 8;
			this.label3.Text = "ガイド名称";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(144, 152);
			this.label4.Name = "label4";
			this.label4.TabIndex = 9;
			this.label4.Text = "ガイドタイプ";
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
			this.label5.Text = "論理削除区分";
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
			this.checkBox1.Text = "Search時にSerializeする";
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
			this.button5.Text = "件数指定Search";
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
			this.label7.Text = "総件数：";
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
			this.label8.Text = "ユーザー名称";
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
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button9);
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
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
        static void Main(String[] args) 
		{
            try
            {
                string msg = "";
                _parameter = args;
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
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

			//Application.Run(new Form1());
		}

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

		private void button1_Click(object sender, System.EventArgs e)
		{
			//if (_volInsurGdWork == null) _volInsurGdWork = new UserGdBdWork();
			_userGdBdWork = new UserGdBdWork();
			_userGdBdWork.UserGuideDivCd = Convert.ToInt32(textBox2.Text);
			_userGdBdWork.GuideCode = Convert.ToInt32(textBox3.Text);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_userGdBdWork);			

			//int status = IusergdbdDB.ReadUserGdBd(ref parabyte,0);
			int status = IusergdbdDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_userGdBdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(parabyte,typeof(UserGdBdWork));

				Text = "該当データ有り";
				textBox2.Text = _userGdBdWork.UserGuideDivCd.ToString();
				textBox3.Text = _userGdBdWork.GuideCode.ToString();
				textBox4.Text = _userGdBdWork.GuideName.ToString();
				textBox5.Text = _userGdBdWork.GuideType.ToString();
				textBox7.Text = _userGdBdWork.LogicalDeleteCode.ToString();
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);		
			IusergdbdDB = MediationUserGdBdDB.GetUserGdBdDB();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";	
			textBox7.Text = "";
			listBox1.Items.Clear();
			//_prevUserGdBdWork = null;
			listBox2.Items.Clear();
			button5.Enabled = true;
			label6.Text = "次データ？";
		}

		/// <summary>
		/// 件数指定リード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, System.EventArgs e)
		{
//			listBox2.Items.Clear();
//
//			UserGdBdWork volInsurGdWork = new UserGdBdWork();
//			byte[] parabyte;
//			if (_prevUserGdBdWork == null)
//			{
//				volInsurGdWork.EnterpriseCode = textBox6.Text;
//				parabyte = XmlByteSerializer.Serialize(volInsurGdWork);
//			}
//			else
//			{
//				parabyte = XmlByteSerializer.Serialize(_prevUserGdBdWork);	
//			}
//
//			byte[] retbyte;
//			int retTotalCnt;
//			bool nextData;
//
//			int status = IusergdbdDB.SearchSpecificationUserGdBd(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);
//
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				UserGdBdWork[] ew = (UserGdBdWork[])XmlByteSerializer.Deserialize(retbyte,typeof(UserGdBdWork[]));
//
//				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
//
//				//初回のみ件数取得
//				if (_prevUserGdBdWork == null) 
//				{
//					label7.Text = "総件数： "+retTotalCnt.ToString()+" 件";
//				}
//				
//				for(int i = 0;i<ew.Length;i++)
//				{
//					volInsurGdWork = (UserGdBdWork)ew[i];
//					listBox2.Items.Add(volInsurGdWork.ToString());
//					listBox2.Update();
//					if (i == ew.Length - 1) _prevUserGdBdWork = (UserGdBdWork)ew[i];
//				}
//				if (nextData)		label6.Text = "次データ有り";
//				else
//				{
//					numericUpDown1.Focus();
//					button5.Enabled = false;
//					label6.Text = "次データ無し";
//				}
//			}				
//					
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
			_userGdHdWork = new UserGdHdWork();
			
			ArrayList al = new ArrayList();

			// XMLへ変換し、文字列のバイナリ化
			object parabyte = _userGdHdWork;			
			object retbyte;

			//int status = IusergdbdDB.SearchGuideHeader(out retbyte, parabyte, 0, 0);
            int status = IusergdbdDB.SearchHeader(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				ArrayList ew = retbyte as ArrayList;

				Text = "該当データ有り  HIT";
				
				dataGrid2.DataSource = ew;
			}		
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			_userGdBdWork = new UserGdBdWork();

			ArrayList al = new ArrayList();

			// XMLへ変換し、文字列のバイナリ化
			object parabyte = _userGdBdWork;
			object retbyte;

			//int status = IusergdbdDB.SearchUserGdBd(out retbyte, parabyte, 0, 0);
            int status = IusergdbdDB.SearchBody(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				ArrayList ew = retbyte as ArrayList;

				Text = "該当データ有り  HIT";
				
				dataGrid3.DataSource = ew;
			}		
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			_userGdBdWork = new UserGdBdWork();
			_userGdBdWork.UserGuideDivCd = Convert.ToInt32(textBox2.Text);

			ArrayList al = new ArrayList();

			// XMLへ変換し、文字列のバイナリ化
			object parabyte = _userGdBdWork;
			object retbyte;

			//int status = IusergdbdDB.SearchGuidBody(out retbyte, parabyte, 0, 0);
            int status = IusergdbdDB.SearchGuideDivCode(out retbyte, parabyte, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData01);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				ArrayList ew = retbyte as ArrayList;

				Text = "該当データ有り  HIT";
				
				dataGrid4.DataSource = ew;
			}			
		}
	}
}

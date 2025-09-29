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
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button4;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button12;

		private CompanyNmWork _companyNmWork = null;

		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox EnterprisetextBox;
		private System.Windows.Forms.TextBox LogicalDeletetextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox CompanyNameCdtextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox CompanyPrtextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox CompanyName1textBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox CompanyName2textBox;
		private System.Windows.Forms.TextBox PostNotextBox;
		private System.Windows.Forms.TextBox Address1textBox;
		private System.Windows.Forms.TextBox Address2textBox;
		private System.Windows.Forms.TextBox Address3textBox;

		private ICompanyNmDB IcompanynmDB = null;

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
            this.EnterprisetextBox = new System.Windows.Forms.TextBox();
            this.CompanyNameCdtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LogicalDeletetextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyPrtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CompanyName1textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CompanyName2textBox = new System.Windows.Forms.TextBox();
            this.PostNotextBox = new System.Windows.Forms.TextBox();
            this.Address1textBox = new System.Windows.Forms.TextBox();
            this.Address2textBox = new System.Windows.Forms.TextBox();
            this.Address3textBox = new System.Windows.Forms.TextBox();
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
            // EnterprisetextBox
            // 
            this.EnterprisetextBox.Location = new System.Drawing.Point(184, 40);
            this.EnterprisetextBox.Name = "EnterprisetextBox";
            this.EnterprisetextBox.Size = new System.Drawing.Size(288, 19);
            this.EnterprisetextBox.TabIndex = 1;
            this.EnterprisetextBox.Text = "TBS1";
            // 
            // CompanyNameCdtextBox
            // 
            this.CompanyNameCdtextBox.Location = new System.Drawing.Point(184, 72);
            this.CompanyNameCdtextBox.Name = "CompanyNameCdtextBox";
            this.CompanyNameCdtextBox.Size = new System.Drawing.Size(288, 19);
            this.CompanyNameCdtextBox.TabIndex = 2;
            this.CompanyNameCdtextBox.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "自社名称コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(552, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(552, 224);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(336, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 352);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(888, 144);
            this.dataGrid1.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(672, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(776, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "LogicalDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(552, 320);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogicalDeletetextBox
            // 
            this.LogicalDeletetextBox.Location = new System.Drawing.Point(184, 136);
            this.LogicalDeletetextBox.Name = "LogicalDeletetextBox";
            this.LogicalDeletetextBox.Size = new System.Drawing.Size(24, 19);
            this.LogicalDeletetextBox.TabIndex = 23;
            this.LogicalDeletetextBox.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(720, 192);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 24);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Search時にSerializeする";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(776, 88);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(88, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(776, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Revival";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(768, 320);
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
            this.label10.Text = "企業コード";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(24, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(512, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "プライマリキー";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(24, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(512, 16);
            this.label13.TabIndex = 40;
            this.label13.Text = "その他項目";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "自社PR文";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompanyPrtextBox
            // 
            this.CompanyPrtextBox.Location = new System.Drawing.Point(184, 168);
            this.CompanyPrtextBox.Name = "CompanyPrtextBox";
            this.CompanyPrtextBox.Size = new System.Drawing.Size(288, 19);
            this.CompanyPrtextBox.TabIndex = 42;
            this.CompanyPrtextBox.Text = "車の事ならお任せ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "自社名称１";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompanyName1textBox
            // 
            this.CompanyName1textBox.Location = new System.Drawing.Point(184, 192);
            this.CompanyName1textBox.Name = "CompanyName1textBox";
            this.CompanyName1textBox.Size = new System.Drawing.Size(288, 19);
            this.CompanyName1textBox.TabIndex = 44;
            this.CompanyName1textBox.Text = "翼ｼｽﾃﾑ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "自社名称２";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "郵便番号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(32, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 47;
            this.label7.Text = "住所１";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(167, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 16);
            this.label8.TabIndex = 48;
            this.label8.Text = "住所２";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(24, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 16);
            this.label9.TabIndex = 49;
            this.label9.Text = "住所３";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompanyName2textBox
            // 
            this.CompanyName2textBox.Location = new System.Drawing.Point(184, 216);
            this.CompanyName2textBox.Name = "CompanyName2textBox";
            this.CompanyName2textBox.Size = new System.Drawing.Size(288, 19);
            this.CompanyName2textBox.TabIndex = 50;
            this.CompanyName2textBox.Text = "翼太郎";
            // 
            // PostNotextBox
            // 
            this.PostNotextBox.Location = new System.Drawing.Point(184, 240);
            this.PostNotextBox.Name = "PostNotextBox";
            this.PostNotextBox.Size = new System.Drawing.Size(288, 19);
            this.PostNotextBox.TabIndex = 51;
            this.PostNotextBox.Text = "989-5301";
            // 
            // Address1textBox
            // 
            this.Address1textBox.Location = new System.Drawing.Point(184, 264);
            this.Address1textBox.Name = "Address1textBox";
            this.Address1textBox.Size = new System.Drawing.Size(288, 19);
            this.Address1textBox.TabIndex = 52;
            this.Address1textBox.Text = "福岡県福岡市博多区博多駅南";
            // 
            // Address2textBox
            // 
            this.Address2textBox.Location = new System.Drawing.Point(184, 288);
            this.Address2textBox.Name = "Address2textBox";
            this.Address2textBox.Size = new System.Drawing.Size(13, 19);
            this.Address2textBox.TabIndex = 53;
            this.Address2textBox.Text = "2";
            // 
            // Address3textBox
            // 
            this.Address3textBox.Location = new System.Drawing.Point(184, 312);
            this.Address3textBox.Name = "Address3textBox";
            this.Address3textBox.Size = new System.Drawing.Size(288, 19);
            this.Address3textBox.TabIndex = 54;
            this.Address3textBox.Text = "8-3";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(904, 502);
            this.Controls.Add(this.Address3textBox);
            this.Controls.Add(this.Address2textBox);
            this.Controls.Add(this.Address1textBox);
            this.Controls.Add(this.PostNotextBox);
            this.Controls.Add(this.CompanyName2textBox);
            this.Controls.Add(this.CompanyName1textBox);
            this.Controls.Add(this.CompanyPrtextBox);
            this.Controls.Add(this.LogicalDeletetextBox);
            this.Controls.Add(this.CompanyNameCdtextBox);
            this.Controls.Add(this.EnterprisetextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
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
		/// アプリケーション終了イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">メッセージ</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//メッセージを出す前に全て開放
			ApplicationStartControl.EndApplication();
			//従業員ログオフのメッセージを表示
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			_companyNmWork = new CompanyNmWork();
			_companyNmWork.EnterpriseCode = EnterprisetextBox.Text;
			_companyNmWork.CompanyNameCd = Convert.ToInt32( CompanyNameCdtextBox.Text );

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_companyNmWork);			

			int status = IcompanynmDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_companyNmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));

				Text = "該当データ有り";
				EnterprisetextBox.Text = _companyNmWork.EnterpriseCode.ToString();
				CompanyNameCdtextBox.Text = _companyNmWork.CompanyNameCd.ToString();
				LogicalDeletetextBox.Text = _companyNmWork.LogicalDeleteCode.ToString();
				CompanyPrtextBox.Text = _companyNmWork.CompanyPr.ToString();
				CompanyName1textBox.Text = _companyNmWork.CompanyName1.ToString();
				CompanyName2textBox.Text = _companyNmWork.CompanyName2.ToString();
				PostNotextBox.Text = _companyNmWork.PostNo.ToString();
				Address1textBox.Text = _companyNmWork.Address1.ToString();
				//Address2textBox.Text = _companyNmWork.Address2.ToString();
				Address3textBox.Text = _companyNmWork.Address3.ToString();
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);		
			IcompanynmDB = MediationCompanyNmDB.GetCompanyNmDB();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			CompanyNmWork companyNmWork = new CompanyNmWork();
			companyNmWork.EnterpriseCode = EnterprisetextBox.Text;

			object paraobj = companyNmWork;
			object retobj = null;
			int status = IcompanynmDB.Search(out retobj, paraobj, 0, 0);

			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り  HIT "+((ArrayList)retobj).Count.ToString()+"件";
				
				for(int i = 0;i< ((ArrayList)retobj).Count;i++)
				{
					listBox1.Items.Add(((CompanyNmWork)((ArrayList)retobj)[i]).ToString());
					listBox1.Update();
				}
				if (checkBox1.Checked)
				{
					CompanyNmWork[] CompanyNmWorks = (CompanyNmWork[])((ArrayList)retobj).ToArray(typeof(CompanyNmWork));
					XmlByteSerializer.Serialize(CompanyNmWorks,"c:\\testList.xml");
				}
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if (_companyNmWork == null) _companyNmWork = new CompanyNmWork();

			_companyNmWork.EnterpriseCode = EnterprisetextBox.Text;
			_companyNmWork.CompanyNameCd = Convert.ToInt32( CompanyNameCdtextBox.Text );

			_companyNmWork.LogicalDeleteCode = System.Convert.ToInt32(LogicalDeletetextBox.Text);

			_companyNmWork.CompanyPr = CompanyPrtextBox.Text;
			_companyNmWork.CompanyName1 = CompanyName1textBox.Text;
			_companyNmWork.CompanyName2 = CompanyName2textBox.Text;
			_companyNmWork.PostNo = PostNotextBox.Text;
			_companyNmWork.Address1 = Address1textBox.Text;
			//_companyNmWork.Address2 = Convert.ToInt32(Address2textBox.Text);
			_companyNmWork.Address3 = Address3textBox.Text;

//			ArrayList al = new ArrayList();
//			al.Add(_vlPntAdNmUWork);
//			object paraobj = al;
			byte[] parabyte = XmlByteSerializer.Serialize(_companyNmWork);

			int status = IcompanynmDB.Write(ref parabyte);

			if (status != 0)
			{
				Text = "更新失敗";
				if (status == 800)
				{
					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
				}
				else if (status == 801)
				{
					MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
				}
			}
			else
			{
				Text = "更新成功";
			}		

		}


		private void button6_Click(object sender, System.EventArgs e)
		{
//			ArrayList list = new ArrayList();
//			list.Add(_vlPntAdNmUWork);
//			object paraobj = list;

			byte[] parabyte = XmlByteSerializer.Serialize(_companyNmWork);
			int status = IcompanynmDB.LogicalDelete(ref parabyte);
			if (status != 0)
			{
				Text = "削除失敗";
				if (status == 800)
				{
					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
				}
				else if (status == 801)
				{
					MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
				}
				else
				{
					MessageBox.Show("何でか削除不可　status="+status.ToString());
				}
			}
			else
			{
				Text = "削除成功";

				_companyNmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));
				LogicalDeletetextBox.Text = _companyNmWork.LogicalDeleteCode.ToString();				
//				LogicalDeletetextBox.Text = ((CompanyNmWork)((ArrayList)paraobj)[0]).LogicalDeleteCode.ToString();

			}				
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear();
			_companyNmWork = null;
			dataGrid1.DataSource = null;
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
//			CompanyNmWork[] list = new CompanyNmWork[1]{_vlPntAdNmUWork};
//			byte[] parabyte = XmlByteSerializer.Serialize(list);
			byte[] parabyte = XmlByteSerializer.Serialize(_companyNmWork);
			int status = IcompanynmDB.Delete(parabyte);
			if (status != 0)
			{
				Text = "削除失敗";
				if (status == 800)
				{
					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
				}
				else if (status == 801)
				{
					MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
				}
			}
			else
			{
				Text = "削除成功";
			}						
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
//			ArrayList list = new ArrayList();
//			list.Add(_vlPntAdNmUWork);
//			object paraobj = list;

			byte[] parabyte = XmlByteSerializer.Serialize(_companyNmWork);
			int status = IcompanynmDB.RevivalLogicalDelete(ref parabyte);
			if (status != 0)
			{
				Text = "復活失敗";
				if (status == 800)
				{
					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
				}
				else if (status == 801)
				{
					MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
				}
				else
				{
					MessageBox.Show("何でか復活不可　status="+status.ToString());
				}
			}
			else
			{
				Text = "復活成功";
				_companyNmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyNmWork));
				LogicalDeletetextBox.Text = _companyNmWork.LogicalDeleteCode.ToString();				
//
//				LogicalDeletetextBox.Text = ((CompanyNmWork)((ArrayList)paraobj)[0]).LogicalDeleteCode.ToString();
			}						
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			CompanyNmWork companyNmWork = new CompanyNmWork();
			companyNmWork.EnterpriseCode = EnterprisetextBox.Text;

			object paraobj = companyNmWork;
			object retobj = null;
			int status = IcompanynmDB.Search(out retobj, paraobj, 0, 0);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り  HIT "+((ArrayList)retobj).Count.ToString()+"件";
				
				dataGrid1.DataSource = retobj;
			}		
		}

		private void label28_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label32_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label29_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label31_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label27_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label30_Click(object sender, System.EventArgs e)
		{
		
		}

	}
}

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

using System.Reflection;
using System.IO;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        #region Windows
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.TextBox tb3;
		private System.Windows.Forms.TextBox tb4;
		private System.Windows.Forms.TextBox tb5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
        private TextBox tb8;
        private TextBox tb7;
        private TextBox tb6;
        private Label label6;
        private Label label7;
        private Label label10;
        private Label label11;
        private TextBox tb11;
        private TextBox tb10;
        private TextBox tb9;
        private Label label13;
        private Label label14;
        private Label label15;
        private Button button2;
        private Button button5;
        private Button button10;
        private Button button11;
        #endregion


        private AlItmDspNmWork _alItmDspNmWork = null;
		private AlItmDspNmWork _prevAlItmDspNmWork = null;
		private IAlItmDspNmDB IalitmdspnmDB = null;


        private static string[] _parameter;
		private static System.Windows.Forms.Form _form = null;



		public Form1()
		{
			InitializeComponent();
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
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb8 = new System.Windows.Forms.TextBox();
            this.tb7 = new System.Windows.Forms.TextBox();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0140150842030050";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(134, 81);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(105, 19);
            this.tb2.TabIndex = 3;
            this.tb2.Text = "0";
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(134, 105);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(105, 19);
            this.tb3.TabIndex = 4;
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(134, 129);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(105, 19);
            this.tb4.TabIndex = 5;
            // 
            // tb5
            // 
            this.tb5.Location = new System.Drawing.Point(134, 153);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(105, 19);
            this.tb5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "表示名称管理№";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "自宅TEL表示名称";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "勤務先TEL表示名称";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "携帯TEL表示名称";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 233);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(725, 173);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(540, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Search";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(266, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(322, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 23;
            this.button6.Text = "LogicalDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(155, 16);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(49, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(134, 49);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 2;
            this.textBox7.Text = "1";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(476, 16);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(58, 23);
            this.button12.TabIndex = 25;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(416, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "Revival";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(596, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 23);
            this.button8.TabIndex = 27;
            this.button8.Text = "CstomSearch";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(502, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(542, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 35;
            // 
            // tb8
            // 
            this.tb8.Location = new System.Drawing.Point(382, 105);
            this.tb8.Name = "tb8";
            this.tb8.Size = new System.Drawing.Size(105, 19);
            this.tb8.TabIndex = 9;
            // 
            // tb7
            // 
            this.tb7.Location = new System.Drawing.Point(382, 81);
            this.tb7.Name = "tb7";
            this.tb7.Size = new System.Drawing.Size(105, 19);
            this.tb7.TabIndex = 8;
            // 
            // tb6
            // 
            this.tb6.Location = new System.Drawing.Point(134, 178);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(105, 19);
            this.tb6.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(262, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(262, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "勤務先FAX表示名称";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(262, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "自宅FAX表示名称";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 40;
            this.label11.Text = "その他TEL表示名称";
            // 
            // tb11
            // 
            this.tb11.Location = new System.Drawing.Point(382, 178);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(105, 19);
            this.tb11.TabIndex = 12;
            // 
            // tb10
            // 
            this.tb10.Location = new System.Drawing.Point(382, 154);
            this.tb10.Name = "tb10";
            this.tb10.Size = new System.Drawing.Size(105, 19);
            this.tb10.TabIndex = 11;
            // 
            // tb9
            // 
            this.tb9.Location = new System.Drawing.Point(382, 130);
            this.tb9.Name = "tb9";
            this.tb9.Size = new System.Drawing.Size(105, 19);
            this.tb9.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(262, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 50;
            this.label13.Text = "追加情報３表示名称";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(262, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 49;
            this.label14.Text = "追加情報２表示名称";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(262, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 48;
            this.label15.Text = "追加情報１表示名称";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 51;
            this.button2.Text = "Read2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(78, 204);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 23);
            this.button5.TabIndex = 52;
            this.button5.Text = "Read2(Custom)";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(247, 203);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(90, 23);
            this.button10.TabIndex = 54;
            this.button10.Text = "CstomSearch2";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(179, 203);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 53;
            this.button11.Text = "Search2";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(749, 418);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb11);
            this.Controls.Add(this.tb10);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.tb7);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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



		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);		
			IalitmdspnmDB = MediationAlItmDspNmDB.GetAlItmDspNmDB();
		}




        //Read
		private void button1_Click(object sender, System.EventArgs e)
		{
//			if (_alItmDspNmWork == null) _alItmDspNmWork = new AlItmDspNmWork();
			_alItmDspNmWork = new AlItmDspNmWork();
			_alItmDspNmWork.EnterpriseCode = textBox1.Text;

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_alItmDspNmWork);			

			int status = IalitmdspnmDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "該当データ無し  st="+status;
			}
			else
			{
				// XMLの読み込み
				_alItmDspNmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

				Text = "該当データ有り";
				textBox1.Text = _alItmDspNmWork.EnterpriseCode.ToString();
				//tb2.Text  = _alItmDspNmWork.DspNameManageNo.ToString();    // 2008.05.26 del
				tb3.Text  = _alItmDspNmWork.HomeTelNoDspName.ToString();
				tb4.Text  = _alItmDspNmWork.OfficeTelNoDspName.ToString();
				tb5.Text  = _alItmDspNmWork.MobileTelNoDspName.ToString();
				tb6.Text  = _alItmDspNmWork.OtherTelNoDspName.ToString();
				tb7.Text  = _alItmDspNmWork.HomeFaxNoDspName.ToString();
				tb8.Text  = _alItmDspNmWork.OfficeFaxNoDspName.ToString();
				tb9.Text  = _alItmDspNmWork.AddInfo1DspName.ToString();
				tb10.Text = _alItmDspNmWork.AddInfo2DspName.ToString();
				tb11.Text = _alItmDspNmWork.AddInfo3DspName.ToString();

                textBox7.Text = _alItmDspNmWork.LogicalDeleteCode.ToString();
			}		
		}


        //Search
		private void button3_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;
			
			AlItmDspNmWork alItmDspNmWork = new AlItmDspNmWork();
			alItmDspNmWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(alItmDspNmWork);			
			byte[] retbyte;

			int status = IalitmdspnmDB.Search(out retbyte, parabyte, 0, 0);

            if (status != 0)
			{
				Text = "該当データ無し  st="+status;
			}
			else
			{
				// XMLの読み込み
				AlItmDspNmWork[] ew = (AlItmDspNmWork[])XmlByteSerializer.Deserialize(retbyte,typeof(AlItmDspNmWork[]));

				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
				
				dataGrid1.DataSource = ew;
			}		
			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}


        //CustomSearch
		private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

			AlItmDspNmWork alItmDspNmWork = new AlItmDspNmWork();
			alItmDspNmWork.EnterpriseCode = textBox1.Text;

			object paraobj = alItmDspNmWork;
			object retobj = null;

            int status = IalitmdspnmDB.Search(out retobj, paraobj, 0, 0);

            if (status != 0)
			{
				Text = "該当データ無し  st="+status;
			}
			else
			{
				Text = "該当データ有り  HIT "+((ArrayList)retobj).Count.ToString()+"件";
				
				dataGrid1.DataSource = retobj;
			}		

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}


        //Write
		private void button4_Click(object sender, System.EventArgs e)
		{
			if (_alItmDspNmWork == null) _alItmDspNmWork = new AlItmDspNmWork();

			_alItmDspNmWork.EnterpriseCode     = textBox1.Text; 
			//_alItmDspNmWork.DspNameManageNo    = Convert.ToInt32(tb2.Text);   // 2008.05.26 frl 
			_alItmDspNmWork.HomeTelNoDspName   = tb3.Text;
			_alItmDspNmWork.OfficeTelNoDspName = tb4.Text;
			_alItmDspNmWork.MobileTelNoDspName = tb5.Text;
			_alItmDspNmWork.OtherTelNoDspName  = tb6.Text; 
			_alItmDspNmWork.HomeFaxNoDspName   = tb7.Text; 
			_alItmDspNmWork.OfficeFaxNoDspName = tb8.Text; 
			_alItmDspNmWork.AddInfo1DspName    = tb9.Text;
			_alItmDspNmWork.AddInfo2DspName    = tb10.Text; 
			_alItmDspNmWork.AddInfo3DspName    = tb11.Text; 

			_alItmDspNmWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(_alItmDspNmWork);

			int status = IalitmdspnmDB.Write(ref parabyte);
			if (status != 0)
			{
				Text = "更新失敗  st="+status;
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
				// XMLの読み込み
				_alItmDspNmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

			}		

		}


        //Delete
		private void button12_Click(object sender, System.EventArgs e)
		{

			byte[] parabyte = XmlByteSerializer.Serialize(_alItmDspNmWork);
			int status = IalitmdspnmDB.Delete(parabyte);
			if (status != 0)
			{
				Text = "削除失敗  st="+status;
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


        //LogicalDelete
		private void button6_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_alItmDspNmWork);
			int status = IalitmdspnmDB.LogicalDelete(ref parabyte);
			if (status != 0)
			{
				Text = "削除失敗  st="+status;
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
				// XMLの読み込み
				_alItmDspNmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));
				textBox7.Text = _alItmDspNmWork.LogicalDeleteCode.ToString();

			}				
		}


        //Revival
		private void button7_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_alItmDspNmWork);
			int status = IalitmdspnmDB.RevivalLogicalDelete(ref parabyte);
			if (status != 0)
			{
				Text = "復活失敗  st="+status;
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
				// XMLの読み込み
				_alItmDspNmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));
				textBox7.Text = _alItmDspNmWork.LogicalDeleteCode.ToString();
			}				
		
		}

    
        //Clear
		private void button9_Click(object sender, System.EventArgs e)
		{
	//		tb2.Text  = "";
			tb3.Text  = "";
			tb4.Text  = "";
			tb5.Text  = "";	
			tb6.Text  = "";
			tb7.Text  = "";
			tb8.Text  = "";	
			tb9.Text  = "";
			tb10.Text = "";
			tb11.Text = "";	
			_prevAlItmDspNmWork = null;
		}




        //Read2
        private void button2_Click(object sender, EventArgs e)
        {

			SqlConnection sqlConnection = null;

    		SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
//			if (connectionText == null || connectionText == "") return status;
//    		string connectionText = "workstation id=Kouguchi2 ; packet size=4096 ; User id=sfuser ; Pwd=sfuser001 ; data source=10.20.150.155 ; persist security info=False ; initial catalog=SF_NET_USR_DB";

			sqlConnection = new SqlConnection(connectionText);
			sqlConnection.Open();				



//			if (_alItmDspNmWork == null) _alItmDspNmWork = new AlItmDspNmWork();
			_alItmDspNmWork = new AlItmDspNmWork();
			_alItmDspNmWork.EnterpriseCode = textBox1.Text;

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_alItmDspNmWork);			

			int status = IalitmdspnmDB.Read(ref parabyte,0, ref sqlConnection);
			if (status != 0)
			{
				Text = "該当データ無し  st="+status;
			}
			else
			{
				// XMLの読み込み
				_alItmDspNmWork = (AlItmDspNmWork)XmlByteSerializer.Deserialize(parabyte,typeof(AlItmDspNmWork));

				Text = "該当データ有り";
				textBox1.Text = _alItmDspNmWork.EnterpriseCode.ToString();
				//tb2.Text  = _alItmDspNmWork.DspNameManageNo.ToString();    // 2008.05.26 del
				tb3.Text  = _alItmDspNmWork.HomeTelNoDspName.ToString();
				tb4.Text  = _alItmDspNmWork.OfficeTelNoDspName.ToString();
				tb5.Text  = _alItmDspNmWork.MobileTelNoDspName.ToString();
				tb6.Text  = _alItmDspNmWork.OtherTelNoDspName.ToString();
				tb7.Text  = _alItmDspNmWork.HomeFaxNoDspName.ToString();
				tb8.Text  = _alItmDspNmWork.OfficeFaxNoDspName.ToString();
				tb9.Text  = _alItmDspNmWork.AddInfo1DspName.ToString();
				tb10.Text = _alItmDspNmWork.AddInfo2DspName.ToString();
				tb11.Text = _alItmDspNmWork.AddInfo3DspName.ToString();

                textBox7.Text = _alItmDspNmWork.LogicalDeleteCode.ToString();
			}		

			sqlConnection.Close();

        }


        //Read2(Custom)
        private void button5_Click(object sender, EventArgs e)
        {
        }

        //Search2
        private void button11_Click(object sender, EventArgs e)
        {
        }


        //Customsearch2
        private void button10_Click(object sender, EventArgs e)
        {
        }


    }

}

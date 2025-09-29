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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections.Generic;

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
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button12;
		private System.Windows.Forms.ListBox listBox3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;

//        private FreePprGrpWork     _prevFreePprGrpWork = null;
        private FreePprGrpWork     _freePprGrpWork = null;
        private FrePprGrTrWork   _frePprGrTrWork = null;
        private FrePprGrTrWork[] _frePprGrTrWorkRet = null;
        private IFreePprGrpDB IFreePprGrpDB = null;
            
		private static string[] _parameter;
		private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button22;
		private System.Windows.Forms.Button button23;
        private TextBox textBox4;
        private Label label3;
		private static System.Windows.Forms.Form _form = null;
        public List<FrePprGrTrWork> paraobj = new List<FrePprGrTrWork>();

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.textBox1.Text = "0140150842030050";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(159, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(159, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(160, 19);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "test";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "自由帳票ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "自由帳票グループ名称";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(16, 148);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(288, 19);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "0140150842030050";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(4, 207);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(512, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(24, 392);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(488, 144);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(336, 368);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Search→Grid";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(392, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(56, 183);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 24);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Search時にSerializeする";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(472, 16);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(88, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // listBox3
            // 
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(592, 56);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(224, 208);
            this.listBox3.TabIndex = 40;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(592, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "GrCd,表示順位,出力FNm,帳票ID,振替Cd";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(704, 376);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(104, 19);
            this.textBox8.TabIndex = 45;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(704, 352);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(104, 19);
            this.textBox12.TabIndex = 44;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(704, 328);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(104, 19);
            this.textBox13.TabIndex = 43;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(704, 304);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(104, 19);
            this.textBox14.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(600, 379);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 49;
            this.label12.Text = "ユーザー帳票ID";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(598, 355);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 48;
            this.label13.Text = "出力ファイル名";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(600, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 47;
            this.label14.Text = "表示順位";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(600, 307);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 46;
            this.label15.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(600, 272);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 23);
            this.button8.TabIndex = 50;
            this.button8.Text = "List Add";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(712, 272);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(96, 23);
            this.button10.TabIndex = 51;
            this.button10.Text = "List Delete";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(600, 438);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(112, 23);
            this.button11.TabIndex = 52;
            this.button11.Text = "一括取得";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(720, 438);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(112, 23);
            this.button13.TabIndex = 53;
            this.button13.Text = "一件登録";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(600, 470);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(112, 23);
            this.button14.TabIndex = 54;
            this.button14.Text = "一括登録";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(528, 504);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(264, 32);
            this.label16.TabIndex = 55;
            this.label16.Text = "label16";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(688, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 24);
            this.label17.TabIndex = 57;
            this.label17.Text = "label17";
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(447, 544);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(80, 23);
            this.button18.TabIndex = 60;
            this.button18.Text = "明細Search";
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Enabled = false;
            this.button19.Location = new System.Drawing.Point(530, 544);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(104, 23);
            this.button19.TabIndex = 61;
            this.button19.Text = "明細DeleteInsert";
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(366, 544);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(75, 23);
            this.button22.TabIndex = 64;
            this.button22.Text = "明細削除";
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(393, 146);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(75, 23);
            this.button23.TabIndex = 65;
            this.button23.Text = "DtlSearch";
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(704, 401);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 19);
            this.textBox4.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(598, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 67;
            this.label3.Text = "振替コード";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(848, 574);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
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
				if (status != 0)TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",msg,0,MessageBoxButtons.OK);
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

        //グループリード
		private void button1_Click(object sender, System.EventArgs e)
		{
			_freePprGrpWork = new FreePprGrpWork();
			_freePprGrpWork.EnterpriseCode = textBox1.Text;
			_freePprGrpWork.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列


			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_freePprGrpWork);

            int status = IFreePprGrpDB.ReadFreePprGrp(ref parabyte, 0, out msgDiv, out errMsg);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte,typeof(FreePprGrpWork));

				Text = "該当データ有り";
				textBox1.Text = _freePprGrpWork.EnterpriseCode.ToString();
				textBox2.Text = _freePprGrpWork.FreePrtPprGroupCd.ToString();
				textBox14.Text = _freePprGrpWork.FreePrtPprGroupCd.ToString();
				textBox3.Text = _freePprGrpWork.FreePrtPprGroupNm;		
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile , false);		
			IFreePprGrpDB = MediationFreePprGrpDB.GetFreePprGrpDB();
		}

        //グループサーチ
		private void button2_Click(object sender, System.EventArgs e)
		{
			FreePprGrpWork mainWorkInsWork = new FreePprGrpWork();
			mainWorkInsWork.EnterpriseCode = textBox1.Text;
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

			ArrayList al = new ArrayList();

            //// XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(mainWorkInsWork);		
            //byte[] retbyte;
            object paraObj = (object)mainWorkInsWork;
            object retObj = null;

            int status = IFreePprGrpDB.SearchFreePprGrp(out retObj, paraObj, 5, 0, out msgDiv, out errMsg);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
                //// XMLの読み込み
                //FreePprGrpWork[] ew = (FreePprGrpWork[])XmlByteSerializer.Deserialize(retbyte,typeof(FreePprGrpWork[]));

				Text = "該当データ有り  HIT "+ ((ArrayList)retObj).Count.ToString() +"件";
				
				foreach( FreePprGrpWork item in (ArrayList)retObj )
				{
					listBox1.Items.Add(item.ToString());
					listBox1.Update();
				}
                if (checkBox1.Checked) XmlByteSerializer.Serialize( retObj ,"c:\\testList.xml");	
			}
		}

        //グループサーチ
		private void button3_Click(object sender, System.EventArgs e)
		{
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

            if (_freePprGrpWork == null) _freePprGrpWork = new FreePprGrpWork();
			_freePprGrpWork.EnterpriseCode = textBox1.Text;

			ArrayList al = new ArrayList();

            object paraObj = _freePprGrpWork;
            object retObj = null;

            int status = IFreePprGrpDB.SearchFreePprGrp(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01, out msgDiv, out errMsg);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り  HIT "+ ((ArrayList)retObj).ToString()+"件";

                dataGrid1.DataSource = (ArrayList)retObj;
			}		
		}

        //グループライト
		private void button4_Click(object sender, System.EventArgs e)
		{
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

			if (_freePprGrpWork == null) _freePprGrpWork = new FreePprGrpWork();

			_freePprGrpWork.EnterpriseCode = textBox1.Text;
			_freePprGrpWork.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);;
			_freePprGrpWork.FreePrtPprGroupNm = textBox3.Text;
			byte[] parabyte = XmlByteSerializer.Serialize(_freePprGrpWork);

            int status = IFreePprGrpDB.WriteFreePprGrp(ref parabyte, out msgDiv, out errMsg);
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
				// XMLの読み込み
				_freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte,typeof(FreePprGrpWork));
			}
        }

        //グループ情報クリア
        private void button9_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = "";
			textBox3.Text = "";
			listBox1.Items.Clear();
//			_prevFreePprGrpWork = null;
//			listBox2.Items.Clear();
        }

        //グループ削除
		private void button12_Click(object sender, System.EventArgs e)
		{
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

			byte[] parabyte1 = XmlByteSerializer.Serialize(_freePprGrpWork);
			byte[] parabyte2 = null;

			if (_frePprGrTrWorkRet != null)
			{
				parabyte2 = XmlByteSerializer.Serialize(_frePprGrTrWorkRet);
			}

            int status = IFreePprGrpDB.DeleteFreePprGrpAll(ref parabyte1, ref parabyte2, out msgDiv, out errMsg);
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

        //リストに追加
        private void button8_Click(object sender, System.EventArgs e)
		{
			string a, b, c, d, g, f;

			a = textBox14.Text;
			b = textBox13.Text;
			c = textBox12.Text;
			d = textBox8.Text;
            g = textBox4.Text;

			f = a + "," + b + "," + c + "," + d + "," +g;
			listBox3.Items.Add(f);

			textBox13.Text = "";
			textBox12.Text = "";
			textBox8.Text = "";
		}

        //リストから削除
		private void button10_Click(object sender, System.EventArgs e)
		{
			int idx = listBox3.SelectedIndex;
			listBox3.Items.RemoveAt(idx);
		}


        // 振替Write
		private void button13_Click(object sender, System.EventArgs e)
		{

			string lin = listBox3.Text;
			string[] itm = lin.Split(new char[] {','});
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列


			if (_frePprGrTrWork == null) _frePprGrTrWork = new FrePprGrTrWork();

			_frePprGrTrWork.EnterpriseCode = textBox1.Text;

			_frePprGrTrWork.FreePrtPprGroupCd = Convert.ToInt32(itm[0]);
			_frePprGrTrWork.DisplayOrder = Convert.ToInt32(itm[1]);

			// テスト用
			byte[] parabyte = XmlByteSerializer.Serialize(_frePprGrTrWork);
            int status = IFreePprGrpDB.ReadFrePprGrTr(ref parabyte, 0, out msgDiv, out errMsg);
			_frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));

            _frePprGrTrWork.OutputFormFileName = itm[2];
			_frePprGrTrWork.UserPrtPprIdDerivNo = Convert.ToInt32(itm[3]);
            _frePprGrTrWork.TransferCode = Convert.ToInt32(itm[4]);

			//parabyte = XmlByteSerializer.Serialize(_frePprGrTrWork);
            paraobj.Add(_frePprGrTrWork);
            object obj = new object();
            obj = paraobj;
            status = IFreePprGrpDB.WriteFrePprGrTr(ref obj, out msgDiv, out errMsg);
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
				// XMLの読み込み
			//	_frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));

			}		
		}

		//明細一括取得
        private void button11_Click(object sender, System.EventArgs e)
        {
            FrePprGrTrWork mainWrkDtlInsWork = new FrePprGrTrWork();
            mainWrkDtlInsWork.EnterpriseCode = textBox1.Text;
            mainWrkDtlInsWork.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列


            ArrayList al = new ArrayList();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte;
            byte[] retbyte;
            FrePprGrTrWork frePprGrTrWk = new FrePprGrTrWork();

            frePprGrTrWk.EnterpriseCode = textBox1.Text;
            frePprGrTrWk.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);
            parabyte = XmlByteSerializer.Serialize(frePprGrTrWk);

            int status = IFreePprGrpDB.SearchFrePprGrTr(out retbyte, parabyte, 5, ConstantManagement.LogicalMode.GetDataAll, out msgDiv, out errMsg);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                FrePprGrTrWork[] ew = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(retbyte, typeof(FrePprGrTrWork[]));
                _frePprGrTrWorkRet = ew;
                _frePprGrTrWork = ew[0];

                Text = "該当データ有り  HIT " + ew.Length.ToString() + "件";

                string lst;

                listBox3.Items.Clear();
                for (int i = 0; i < ew.Length; i++)
                {
                    mainWrkDtlInsWork = (FrePprGrTrWork)ew[i];
                    lst = mainWrkDtlInsWork.FreePrtPprGroupCd.ToString() + "," + mainWrkDtlInsWork.DisplayOrder.ToString() + "," + mainWrkDtlInsWork.OutputFormFileName + "," + mainWrkDtlInsWork.UserPrtPprIdDerivNo.ToString() + "," + mainWrkDtlInsWork.UpdateDateTime.ToString() + "," + mainWrkDtlInsWork.LogicalDeleteCode.ToString();
                    listBox3.Items.Add(lst);
                    listBox3.Update();
                }
                if (checkBox1.Checked) XmlByteSerializer.Serialize(ew, "c:\\testList.xml");
            }
        }

		private void listBox3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string lin = listBox3.Text;
			string[] itm = lin.Split(new char[] {','});

			if (lin == "")
			{
				textBox13.Text = "";
				textBox12.Text = "";
				textBox8.Text = "";
			}
			else
			{
				textBox14.Text = itm[0];
				textBox13.Text = itm[1];
				textBox12.Text = itm[2];
				textBox8.Text = itm[3];
                textBox4.Text = itm[4];
			}
		}

        //明細一括登録
//        private void button14_Click(object sender, System.EventArgs e)
//        {
//            string lin;
//            string[] itm;
//            ArrayList al = new ArrayList();
//            bool msgDiv;       //メッセージ有無区分
//            string errMsg;     //エラーメッセージ文字列


//            if (_freePprGrpWork == null) _freePprGrpWork = new FreePprGrpWork();

//            _freePprGrpWork.EnterpriseCode = textBox1.Text;

//            _freePprGrpWork.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);;
//            _freePprGrpWork.FreePrtPprGroupNm = textBox3.Text;

//            byte[] parabyte1 = XmlByteSerializer.Serialize(_freePprGrpWork);

//            int status;
//            for (int n=0; n<listBox3.Items.Count; n++)
//            {
//                FrePprGrTrWork wkFrePprGrTrWork = new FrePprGrTrWork();

//                if (_frePprGrTrWorkRet != null)
//                {
//                    if (_frePprGrTrWorkRet.Length > n)
//                    {
//                        wkFrePprGrTrWork = _frePprGrTrWorkRet[n];
//                    }
//                }

//                listBox3.SelectedIndex=n;
//                lin = listBox3.Text;
//                itm = lin.Split(new char[] {','});

//                wkFrePprGrTrWork.EnterpriseCode = textBox1.Text;
//                wkFrePprGrTrWork.FreePrtPprGroupCd = Convert.ToInt32(itm[0]);
//                wkFrePprGrTrWork.DisplayOrder = Convert.ToInt32(itm[1]);
///*
//                // テスト用
//                byte[] parabyte = XmlByteSerializer.Serialize(wkFrePprGrTrWork);
//                status = IFreePprGrpDB.ReadFrePprGrTr(ref parabyte,0);
//                wkFrePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));
//*/				
//                wkFrePprGrTrWork.OutputFormFileName = itm[2];
//                wkFrePprGrTrWork.UserPrtPprIdDerivNo = Convert.ToInt32(itm[3]);
//                _frePprGrTrWork.TransferCode = Convert.ToInt32(itm[4]);
				
//                al.Add(wkFrePprGrTrWork);

//            }
//            FrePprGrTrWork[] FrePprGrTrWorks = (FrePprGrTrWork[])al.ToArray(typeof(FrePprGrTrWork));
//            byte[] parabyte2 = XmlByteSerializer.Serialize(FrePprGrTrWorks);

//            status = IFreePprGrpDB.WriteFreePprGrpAndDtl(ref parabyte1, ref parabyte2, out msgDiv, out errMsg);
//            if (status != 0)
//            {
//                Text = "更新失敗";
//                if (status == 800)
//                {
//                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
//                }
//                else if (status == 801)
//                {
//                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
//                }
//            }
//            else
//            {
//                Text = "更新成功";
//                // XMLの読み込み
//                _freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte1,typeof(FreePprGrpWork));
//                _frePprGrTrWorkRet = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(parabyte2,typeof(FrePprGrTrWork[]));
///*
//                label16.Text = "配列[0]:" + _frePprGrTrWorkRet[0].DisplayOrder.ToString() + " 配列[1]:" + _frePprGrTrWorkRet[1].DisplayOrder.ToString()
//                            + " 配列[2]:" + _frePprGrTrWorkRet[2].DisplayOrder.ToString() + " 配列[3]:" + _frePprGrTrWorkRet[3].DisplayOrder.ToString();
//*/

//            }		
//        }

        ////振替サーチ
        private void button18_Click(object sender, System.EventArgs e)
        {
            _frePprGrTrWork = new FrePprGrTrWork();
            _frePprGrTrWork.EnterpriseCode = textBox1.Text;
            _frePprGrTrWork.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text); ;
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

            ArrayList al = new ArrayList();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_frePprGrTrWork);
            byte[] retbyte;
            FrePprGrTrWork frePprGrTrWk = new FrePprGrTrWork();

            frePprGrTrWk.EnterpriseCode = textBox1.Text;
            frePprGrTrWk.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);
            parabyte = XmlByteSerializer.Serialize(frePprGrTrWk);

            int status = IFreePprGrpDB.SearchFrePprGrTr(out retbyte, parabyte, 0, ConstantManagement.LogicalMode.GetData01, out msgDiv, out errMsg);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                FrePprGrTrWork[] ew = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(retbyte, typeof(FrePprGrTrWork[]));

                Text = "該当データ有り  HIT " + ew.Length.ToString() + "件";

                dataGrid1.DataSource = ew;
            }
        }

        #region DEL
        //明細DleteAndInsert
        //private void button19_Click(object sender, System.EventArgs e)
        //{
        //    FrePprGrTrWork[] list = (FrePprGrTrWork[])dataGrid1.DataSource;
        //    // XMLへ変換し、文字列のバイナリ化
        //    byte[] parabyte1 = XmlByteSerializer.Serialize(list.Clone());
        //    byte[] parabyte2 = XmlByteSerializer.Serialize(list.Clone());

        //    int status = IFreePprGrpDB.DtlDeleteAndWrite(ref parabyte1 , ref parabyte2);
        //    if (status != 0)
        //    {
        //        Text = "更新失敗";
        //        if (status == 800)
        //        {
        //            MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
        //        }
        //        else if (status == 801)
        //        {
        //            MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
        //        }
        //    }
        //    else
        //    {
        //        Text = "更新成功";
        //        dataGrid1.DataSource = null;
        //        list = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(parabyte2,typeof(FrePprGrTrWork[]));
        //        dataGrid1.DataSource = list;

        //    }										
        //}
        #endregion

        //明細削除
		private void button22_Click(object sender, System.EventArgs e)
		{
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

			if (_frePprGrTrWork == null) _frePprGrTrWork = new FrePprGrTrWork();

			FrePprGrTrWork[] list = (FrePprGrTrWork[])dataGrid1.DataSource;
			_frePprGrTrWork = list[0];


			// テスト用
			byte[] parabyte = XmlByteSerializer.Serialize(_frePprGrTrWork);
            int status = IFreePprGrpDB.DtlDelete(parabyte, out msgDiv, out errMsg);
			if (status != 0)
			{
				Text = "削除失敗";
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
				Text = "削除成功";
			}				

		}

        //振替サーチ
        private void button23_Click(object sender, System.EventArgs e)
        {
            _frePprGrTrWork = new FrePprGrTrWork();
            _frePprGrTrWork.EnterpriseCode = textBox1.Text;
            bool msgDiv;       //メッセージ有無区分
            string errMsg;     //エラーメッセージ文字列

            ArrayList al = new ArrayList();


            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_frePprGrTrWork);
            byte[] retbyte;
            FrePprGrTrWork frePprGrTrWk = new FrePprGrTrWork();

            frePprGrTrWk.EnterpriseCode = textBox1.Text;
            frePprGrTrWk.FreePrtPprGroupCd = Convert.ToInt32(textBox2.Text);
            parabyte = XmlByteSerializer.Serialize(frePprGrTrWk);

            int status = IFreePprGrpDB.SearchFrePprGrTr(out retbyte, parabyte, 0, ConstantManagement.LogicalMode.GetData01, out msgDiv, out errMsg);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                FrePprGrTrWork[] ew = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(retbyte, typeof(FrePprGrTrWork[]));
                Text = "該当データ有り  HIT " + ew.Length.ToString() + "件";
                dataGrid1.DataSource = ew;
            }
        }
	}
}

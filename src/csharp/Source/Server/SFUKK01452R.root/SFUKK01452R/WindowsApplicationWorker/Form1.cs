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
		private System.Windows.Forms.Button button4;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        #endregion

        //private DepsitMainWork _depsitMainWork;
        //private DepsitMainWork _prevDepsitMainWork;
        //private DepositAlwWork _depositAlwWork;
        //private DepositAlwWork _prevDepositAlwWork;
        private IDepositReadDB  IdepositreadDB     = null;


        private static string[] _parameter;
        private TextBox textBox9;
        private Label label11;
        private TextBox textBox10;
        private Label label12;
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
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "YMD";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(104, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(104, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 19);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(104, 152);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 19);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "0";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(104, 128);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 19);
            this.textBox5.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "入金伝票番号";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "得意先コード";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "引当済入金伝票呼出区分";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "計上拠点コード";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(544, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(224, 19);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "0140150842030000";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(552, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(408, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(368, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 248);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(768, 192);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "SearchGrid";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(312, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(360, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "LogicalDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(448, 40);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(56, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(104, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(616, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 24);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Search時にSerializeする";
            // 
            // listBox2
            // 
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(408, 176);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(368, 52);
            this.listBox2.TabIndex = 25;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(280, 184);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "件数指定Search";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(216, 184);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 19);
            this.numericUpDown1.TabIndex = 27;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(144, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "NextData?";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "総件数：";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(448, 16);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(56, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(360, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Revival";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(192, 216);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "CstomSearchGrid";
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(56, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 35;
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 448);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(768, 192);
            this.dataGrid2.TabIndex = 36;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(304, 80);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(80, 19);
            this.textBox8.TabIndex = 37;
            this.textBox8.Text = "30";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(216, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 23);
            this.label10.TabIndex = 38;
            this.label10.Text = "受注ステータス";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(304, 104);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(80, 19);
            this.textBox9.TabIndex = 39;
            this.textBox9.Text = "1";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(216, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 23);
            this.label11.TabIndex = 40;
            this.label11.Text = "売上伝票番号";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(304, 128);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(80, 19);
            this.textBox10.TabIndex = 41;
            this.textBox10.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(216, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 23);
            this.label12.TabIndex = 42;
            this.label12.Text = "請求先コード";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(784, 646);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion


		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
        [STAThread]
            //		static void Main() 
        static void Main(String[] args) 
        {
            //			Application.Run(new Form1());
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
                if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",msg,0,MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"WindowsApplicationWorker",ex.Message,0,MessageBoxButtons.OK);
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
            if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",e.ToString(),0,MessageBoxButtons.OK);
            else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"WindowsApplicationWorker",e.ToString(),0,MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);		
            IdepositreadDB = MediationDepositReadDB.GetDepositReadDB();
            textBox1.Text = LoginInfoAcquisition.EnterpriseCode;

#if DEBUG
            this.Text = "入金/引当読込 - Debug";
#else
            this.Text = "入金/引当読込 - Release";
#endif
        }




		private void button1_Click(object sender, System.EventArgs e)
		{
////			if (_ocrDefSetWork == null) _ocrDefSetWork = new OcrDefSetWork();
//			_ocrDefSetWork = new OcrDefSetWork();
//			_ocrDefSetWork.EnterpriseCode = textBox1.Text;
//			_ocrDefSetWork.SectionCode = textBox2.Text;
//
//			// XMLへ変換し、文字列のバイナリ化
//			byte[] parabyte = XmlByteSerializer.Serialize(_ocrDefSetWork);			
//
//			int status = IocrdefsetDB.Read(ref parabyte,0);
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				_ocrDefSetWork = (OcrDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(OcrDefSetWork));
//
//				Text = "該当データ有り";
//				textBox1.Text = _ocrDefSetWork.EnterpriseCode.ToString();
//				textBox2.Text = _ocrDefSetWork.SectionCode.ToString();
//				textBox3.Text = _ocrDefSetWork.OcrNo.ToString();
//				textBox4.Text = _ocrDefSetWork.OcrEx5NoteTitle.ToString();
//				textBox5.Text = _ocrDefSetWork.OcrFrameNoEditCd.ToString();
//				textBox7.Text = _ocrDefSetWork.LogicalDeleteCode.ToString();
//			}		
		}


		private void button2_Click(object sender, System.EventArgs e)
		{
//			OcrDefSetWork ocrDefSetInsWork = new OcrDefSetWork();
//			ocrDefSetInsWork.EnterpriseCode = textBox1.Text;
//
//			ArrayList al = new ArrayList();
//
//			// XMLへ変換し、文字列のバイナリ化
//			byte[] parabyte = XmlByteSerializer.Serialize(ocrDefSetInsWork);		
//			byte[] retbyte;
//
//			int status = IocrdefsetDB.Search(out retbyte, parabyte, 0, 0);
//			listBox1.Items.Clear();
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				OcrDefSetWork[] ew = (OcrDefSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(OcrDefSetWork[]));
//
//				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
//				
//				for(int i = 0;i<ew.Length;i++)
//				{
//					ocrDefSetInsWork = (OcrDefSetWork)ew[i];
//					listBox1.Items.Add(ocrDefSetInsWork.ToString());
//					listBox1.Update();
//				}
//				if (checkBox1.Checked) XmlByteSerializer.Serialize(ew,"c:\\testList.xml");	
//			}
		}


        //Search
		private void button3_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;
			
			DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepositAlwWork depositAlwWork = new DepositAlwWork();

            byte[] parabyte1;
            byte[] parabyte2;


            DateTime DT1 = new DateTime(1,1,1); 
            DateTime DT2 = new DateTime(9999,12,31);  

            SearchParaDepositRead SPTA = new SearchParaDepositRead();
            SPTA.EnterpriseCode          = textBox1.Text;                     //"TBS1";
            SPTA.AddUpSecCode            = textBox5.Text;                     //"000001";
            SPTA.CustomerCode            = Convert.ToInt32(textBox3.Text);    //112211;
            SPTA.DepositSlipNo           = Convert.ToInt32(textBox2.Text);    //1000;
            //SPTA.DepositCallMonthsStart  = DT1;
            //SPTA.DepositCallMonthsEnd    = DT2;
            SPTA.AlwcDepositCall         = Convert.ToInt32(textBox4.Text);    //0;
            SPTA.AcptAnOdrStatus         = Convert.ToInt32(textBox8.Text);
            SPTA.SalesSlipNum            = textBox9.Text;
            SPTA.ClaimCode               = Convert.ToInt32(textBox10.Text);  

            //if (Convert.ToInt32(textBox8.Text)>0)
            //{
            //    SPTA.AcceptAnOrderNo         = Convert.ToInt32(textBox8.Text);
            //}

//			int status = IDepositReadDB.Search(out retbyte, parabyte, 0, 0);
            int status = IdepositreadDB.Search(out parabyte1 , out parabyte2 , SPTA , 0 , 0);

			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し  status=" + status;
			}
			else
			{
				// XMLの読み込み
				DepsitMainWork[] ew  = (DepsitMainWork[])XmlByteSerializer.Deserialize(parabyte1,typeof(DepsitMainWork[]));
                DepositAlwWork[] ew2 = (DepositAlwWork[])XmlByteSerializer.Deserialize(parabyte2,typeof(DepositAlwWork[]));

				Text = "該当データ有り  入金マスタ=" + ew.Length.ToString() + "件" + "  引当マスタ=" + ew2.Length.ToString() + "件";
				
				dataGrid1.DataSource = ew;
                dataGrid2.DataSource = ew2;
            }		
			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}


        //Search(Custom)
        private void button8_Click_1(object sender, System.EventArgs e)
        {
            DateTime start,end;
            start = DateTime.Now;

            DepsitMainWork depsitMainWork = new DepsitMainWork();
            DepositAlwWork depositAlwWork = new DepositAlwWork();

            object parabyte1 = null;
            object parabyte2 = null;


            DateTime DT1 = new DateTime(1,1,1); 
            DateTime DT2 = new DateTime(9999,12,31);  

            SearchParaDepositRead SPTA = new SearchParaDepositRead();
            SPTA.EnterpriseCode          = textBox1.Text;                     //"TBS1";
            SPTA.AddUpSecCode            = textBox5.Text;                     //"000001";
            SPTA.CustomerCode            = Convert.ToInt32(textBox3.Text);    //112211;
            SPTA.DepositSlipNo           = Convert.ToInt32(textBox2.Text);    //1000;
            //SPTA.DepositCallMonthsStart  = DT1;
            //SPTA.DepositCallMonthsEnd    = DT2;
            SPTA.AlwcDepositCall         = Convert.ToInt32(textBox4.Text);    //0;

            //if (Convert.ToInt32(textBox8.Text)>0)
            //{
            //    SPTA.AcceptAnOrderNo         = Convert.ToInt32(textBox8.Text);
            //}


            //            int status = IdepsitmainDB.Search(out retobj, paraobj, 0, 0);
            int status = IdepositreadDB.Search(out parabyte1 , out parabyte2 , SPTA , 0 , 0);

            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し  status=" + status;
            }
            else
            {
                //                Text = "該当データ有り  入金マスタ=" + ew.Length.ToString() + "件" + "  引当マスタ=" + ew2.Length.ToString() + "件";
                Text = "該当データ有り";
				
                dataGrid1.DataSource = parabyte1;
                dataGrid2.DataSource = parabyte2;
            }		

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);
        
        }



		private void button4_Click(object sender, System.EventArgs e)
		{
//			if (_ocrDefSetWork == null) _ocrDefSetWork = new OcrDefSetWork();
//
//			_ocrDefSetWork.EnterpriseCode = textBox1.Text;
//			_ocrDefSetWork.SectionCode = textBox2.Text;
//			_ocrDefSetWork.OcrNo = Convert.ToInt32(textBox3.Text);
//			_ocrDefSetWork.OcrEx5NoteTitle = textBox4.Text;
//			_ocrDefSetWork.OcrFrameNoEditCd = Convert.ToInt32(textBox5.Text);
//
//			_ocrDefSetWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);
//
//			byte[] parabyte = XmlByteSerializer.Serialize(_ocrDefSetWork);
//
//			int status = IocrdefsetDB.Write(ref parabyte);
//			if (status != 0)
//			{
//				Text = "更新失敗";
//				if (status == 800)
//				{
//					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
//				}
//				else if (status == 801)
//				{
//					MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
//				}
//			}
//			else
//			{
//				Text = "更新成功";
//				// XMLの読み込み
//				_ocrDefSetWork = (OcrDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(OcrDefSetWork));
//
//			}		
//
		}


		private void button6_Click(object sender, System.EventArgs e)
		{
//			byte[] parabyte = XmlByteSerializer.Serialize(_ocrDefSetWork);
//			int status = IocrdefsetDB.LogicalDelete(ref parabyte);
//			if (status != 0)
//			{
//				Text = "削除失敗";
//				if (status == 800)
//				{
//					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
//				}
//				else if (status == 801)
//				{
//					MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
//				}
//				else
//				{
//					MessageBox.Show("何でか削除不可　status="+status.ToString());
//				}
//			}
//			else
//			{
//				Text = "削除成功";
//				// XMLの読み込み
//				_ocrDefSetWork = (OcrDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(OcrDefSetWork));
//				textBox7.Text = _ocrDefSetWork.LogicalDeleteCode.ToString();
//
//			}				
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";	
			textBox7.Text = "";
			listBox1.Items.Clear();
			//_prevDepsitMainWork = null;
            //_prevDepositAlwWork = null;
            listBox2.Items.Clear();
			button5.Enabled = true;
			label6.Text = "次データ？";
		}


		private void button5_Click(object sender, System.EventArgs e)
		{
//			listBox2.Items.Clear();
//
//			OcrDefSetWork ocrDefSetWork = new OcrDefSetWork();
//			byte[] parabyte;
//			if (_prevOcrDefSetWork == null)
//			{
//				ocrDefSetWork.EnterpriseCode = textBox6.Text;
//				parabyte = XmlByteSerializer.Serialize(ocrDefSetWork);
//			}
//			else
//			{
//				parabyte = XmlByteSerializer.Serialize(_prevOcrDefSetWork);	
//			}
//
//			byte[] retbyte;
//			int retTotalCnt;
//			bool nextData;
//
//			int status = IocrdefsetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);
//
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				OcrDefSetWork[] ew = (OcrDefSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(OcrDefSetWork[]));
//
//				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
//
//				//初回のみ件数取得
//				if (_prevOcrDefSetWork == null) 
//				{
//					label7.Text = "総件数： "+retTotalCnt.ToString()+" 件";
//				}
//				
//				for(int i = 0;i<ew.Length;i++)
//				{
//					ocrDefSetWork = (OcrDefSetWork)ew[i];
//					listBox2.Items.Add(ocrDefSetWork.ToString());
//					listBox2.Update();
//					if (i == ew.Length - 1) _prevOcrDefSetWork = (OcrDefSetWork)ew[i];
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


		private void button12_Click(object sender, System.EventArgs e)
		{
//
//			byte[] parabyte = XmlByteSerializer.Serialize(_ocrDefSetWork);
//			int status = IocrdefsetDB.Delete(parabyte);
//			if (status != 0)
//			{
//				Text = "削除失敗";
//				if (status == 800)
//				{
//					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
//				}
//				else if (status == 801)
//				{
//					MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
//				}
//			}
//			else
//			{
//				Text = "削除成功";
//			}						
		}


		private void button7_Click(object sender, System.EventArgs e)
		{
//			byte[] parabyte = XmlByteSerializer.Serialize(_ocrDefSetWork);
//			int status = IocrdefsetDB.RevivalLogicalDelete(ref parabyte);
//			if (status != 0)
//			{
//				Text = "復活失敗";
//				if (status == 800)
//				{
//					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
//				}
//				else if (status == 801)
//				{
//					MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
//				}
//				else
//				{
//					MessageBox.Show("何でか復活不可　status="+status.ToString());
//				}
//			}
//			else
//			{
//				Text = "復活成功";
//				// XMLの読み込み
//				_ocrDefSetWork = (OcrDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(OcrDefSetWork));
//				textBox7.Text = _ocrDefSetWork.LogicalDeleteCode.ToString();
//			}				
//		
		}


	}


}


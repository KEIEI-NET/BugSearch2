using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

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
        private System.Windows.Forms.Button button3;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;

		private EmployeeWork _pmemployeeWork = null;
		private EmployeeWork _pmemployeeWork2 = null;


		private IPMEmployeeDB _ipmemployeeDB = null;
		private static string[] _parameter;
		private TextBox textBox8;
		private Label label8;
		private TextBox textBox9;
		private Label label9;
		private TextBox textBox10;
		private TextBox textBox11;
		private TextBox textBox12;
		private TextBox textBox13;
		private TextBox textBox14;
		private TextBox textBox15;
		private TextBox textBox16;
		private Button button8;
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
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0140150842030050";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(109, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "test";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(114, 138);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(109, 19);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "テスト";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(114, 162);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(109, 19);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "テスト";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(114, 186);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(109, 19);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "test";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "従業員コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "従業員名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "カナ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "ログインID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(442, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 46;
            this.button3.Text = "Write";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 32);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(39, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(114, 69);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "0";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(114, 92);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(109, 19);
            this.textBox8.TabIndex = 33;
            this.textBox8.Text = "1";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(22, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "表示順位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(114, 209);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(109, 19);
            this.textBox9.TabIndex = 35;
            this.textBox9.Text = "Test";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(22, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "パスワード";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(255, 209);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(109, 19);
            this.textBox10.TabIndex = 43;
            this.textBox10.Text = "Test";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(255, 92);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(109, 19);
            this.textBox11.TabIndex = 42;
            this.textBox11.Text = "1";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(255, 69);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(24, 19);
            this.textBox12.TabIndex = 41;
            this.textBox12.Text = "0";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(255, 186);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(109, 19);
            this.textBox13.TabIndex = 40;
            this.textBox13.Text = "test";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(255, 162);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(109, 19);
            this.textBox14.TabIndex = 39;
            this.textBox14.Text = "テスト";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(255, 138);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(109, 19);
            this.textBox15.TabIndex = 38;
            this.textBox15.Text = "テスト";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(255, 114);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(109, 19);
            this.textBox16.TabIndex = 37;
            this.textBox16.Text = "test";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(442, 41);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 44;
            this.button8.Text = "Read2";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(538, 340);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            //PM従業員ログオフのメッセージを表示
            if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
		}

		// Read1
		private void button1_Click(object sender, System.EventArgs e)
		{
			_pmemployeeWork = new EmployeeWork();
			_pmemployeeWork.EnterpriseCode = textBox1.Text;
			_pmemployeeWork.EmployeeCode = textBox2.Text;

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_pmemployeeWork);

			int status = _ipmemployeeDB.Read(ref parabyte, 0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_pmemployeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));

				Text = "該当データ有り";
				textBox1.Text = _pmemployeeWork.EnterpriseCode.ToString();
				textBox2.Text = _pmemployeeWork.EmployeeCode.ToString();
				textBox3.Text = _pmemployeeWork.Name.ToString();
				textBox4.Text = _pmemployeeWork.Kana.ToString();
				textBox5.Text = _pmemployeeWork.LoginId.ToString();
				textBox7.Text = _pmemployeeWork.LogicalDeleteCode.ToString();
				textBox8.Text = _pmemployeeWork.DisplayOrder.ToString();
				textBox9.Text = _pmemployeeWork.LoginPassword.ToString();
			}
		}

		// Read2
		private void button8_Click( object sender, EventArgs e )
		{
			_pmemployeeWork2 = new EmployeeWork();
			_pmemployeeWork2.EnterpriseCode = textBox1.Text;
			_pmemployeeWork2.EmployeeCode = textBox16.Text;

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_pmemployeeWork2);			

			int status = _ipmemployeeDB.Read(ref parabyte, 0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_pmemployeeWork2 = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));

				Text = "該当データ有り";
				textBox1.Text = _pmemployeeWork2.EnterpriseCode.ToString();
				textBox16.Text = _pmemployeeWork2.EmployeeCode.ToString();
				textBox15.Text = _pmemployeeWork2.Name.ToString();
				textBox14.Text = _pmemployeeWork2.Kana.ToString();
				textBox13.Text = _pmemployeeWork2.LoginId.ToString();
				textBox12.Text = _pmemployeeWork2.LogicalDeleteCode.ToString();
				textBox11.Text = _pmemployeeWork2.DisplayOrder.ToString();
				textBox10.Text = _pmemployeeWork2.LoginPassword.ToString();
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            _ipmemployeeDB = Broadleaf.Application.Remoting.Adapter.MediationGetPMEmployeeDB.GetPMEmployeeDB();
		}

		// DisplayClear
		private void button9_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";	
			textBox7.Text = "";
			textBox8.Text = "";
			textBox9.Text = "";
			textBox16.Text = "";
			textBox15.Text = "";
			textBox14.Text = "";
			textBox13.Text = "";
			textBox12.Text = "";
			textBox11.Text = "";
		}

        private void button3_Click(object sender, EventArgs e)
        {
            PMEmployeeWork pmemployeeWork = null;

            if (pmemployeeWork == null) pmemployeeWork = new PMEmployeeWork();

            ArrayList al = new ArrayList();
            pmemployeeWork.EnterpriseCode = textBox1.Text;
            pmemployeeWork.EmployeeCode = textBox2.Text;
            pmemployeeWork.Name = textBox3.Text;
            pmemployeeWork.Kana = textBox4.Text;
            pmemployeeWork.LoginId = textBox5.Text;
            pmemployeeWork.DisplayOrder = Convert.ToInt32(textBox8.Text);
            pmemployeeWork.LoginPassword = textBox9.Text;
            pmemployeeWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);
            al.Add(pmemployeeWork);

            object paraobj = al;

            int status = _ipmemployeeDB.Write(ref paraobj);
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
                pmemployeeWork = (PMEmployeeWork)((ArrayList)paraobj)[0];
            }		
        }
	}
}
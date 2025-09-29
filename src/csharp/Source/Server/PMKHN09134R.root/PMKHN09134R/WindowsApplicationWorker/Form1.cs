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
    /// このFromはリモートテストの為だけのFromです
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		//private ICustSlipNoSetDB ICustSlipNoSetDB = null;
        private OperationStWork _operationStWork = null;
        private IOperationStDB _OperationStDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox8;
        private Label label8;
        private TextBox textBox9;
        private Label label9;
        private TextBox textBox10;
        private Label label10;
        private TextBox textBox11;
        private Label label11;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 284);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 252);
            this.dataGrid1.TabIndex = 13;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 255);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(289, 255);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 255);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(361, 255);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(433, 255);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(505, 255);
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
            this.dataGrid2.Location = new System.Drawing.Point(16, 168);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "企業コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 41;
            this.textBox1.Text = "0101150842020000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 43;
            this.textBox2.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "オペレーション設定区分";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(134, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 45;
            this.textBox3.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "カテゴリコード";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(134, 70);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 47;
            this.textBox4.Text = "PMKHN09134R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "プログラムID";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(134, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 19);
            this.textBox5.TabIndex = 49;
            this.textBox5.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "オペレーションコード";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(134, 110);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 19);
            this.textBox6.TabIndex = 51;
            this.textBox6.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "権限レベル1";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(362, 10);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 19);
            this.textBox7.TabIndex = 53;
            this.textBox7.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "権限レベル2";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(362, 30);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 19);
            this.textBox8.TabIndex = 55;
            this.textBox8.Text = "0001";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "従業員コード";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(362, 50);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 19);
            this.textBox9.TabIndex = 57;
            this.textBox9.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 56;
            this.label9.Text = "制限区分";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(362, 70);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 19);
            this.textBox10.TabIndex = 59;
            this.textBox10.Text = "20080701";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "適用開始日";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(362, 90);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 19);
            this.textBox11.TabIndex = 61;
            this.textBox11.Text = "20081231";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(246, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 60;
            this.label11.Text = "適用終了日";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 62;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(177, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 63;
            this.button3.Text = "Write";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(258, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 64;
            this.button4.Text = "Delete";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(339, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 65;
            this.button5.Text = "LDelete";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(420, 139);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 66;
            this.button6.Text = "RDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
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

        #region [SetKey]
        /*
        /// <summary>
        /// プライマリキー値を設定
        /// </summary>
        /// <param name="CustSlipNoSetWork"></param>
        private void SetKey(ref CustSlipNoSetWork CustSlipNoSetWork)
        {
            CustSlipNoSetWork.EnterpriseCode = textBox1.Text;
            //↓以下に企業コード以外のキー項目をセットするコードを記述

        }
        */
        #endregion

        /// <summary>
        /// READボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            //READ
            #region [パラメータセット]
            _operationStWork = new OperationStWork();
            _operationStWork.EnterpriseCode = textBox1.Text;
            _operationStWork.OperationStDiv = Int32.Parse(textBox2.Text);
            _operationStWork.CategoryCode = Int32.Parse(textBox3.Text);
            _operationStWork.PgId = textBox4.Text;
            _operationStWork.OperationCode = Int32.Parse(textBox5.Text);
            _operationStWork.AuthorityLevel1 = Int32.Parse(textBox6.Text);
            _operationStWork.AuthorityLevel2 = Int32.Parse(textBox7.Text);
            _operationStWork.EmployeeCode = textBox8.Text;
            _operationStWork.LimitDiv = Int32.Parse(textBox9.Text);
            _operationStWork.ApplyStartDate = Int32.Parse(textBox10.Text);
            _operationStWork.ApplyEndDate = Int32.Parse(textBox11.Text);

            object paraobj = _operationStWork;
            #endregion

            int status = _OperationStDB.Read(ref paraobj, 0);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り";

                CustomSerializeArrayList al = new CustomSerializeArrayList();
                al.Add(paraobj);
                dataGrid1.DataSource = al;
			}
		}

        /// <summary>
        /// SEARCHボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //SEARCH
            #region [パラメータセット]
            _operationStWork = new OperationStWork();
            _operationStWork.EnterpriseCode = textBox1.Text;
            _operationStWork.OperationStDiv = Int32.Parse(textBox2.Text);
            _operationStWork.CategoryCode = Int32.Parse(textBox3.Text);
            _operationStWork.PgId = textBox4.Text;
            _operationStWork.OperationCode = Int32.Parse(textBox5.Text);
            _operationStWork.AuthorityLevel1 = Int32.Parse(textBox6.Text);
            _operationStWork.AuthorityLevel2 = Int32.Parse(textBox7.Text);
            _operationStWork.EmployeeCode = textBox8.Text;
            _operationStWork.LimitDiv = Int32.Parse(textBox9.Text);
            _operationStWork.ApplyStartDate = Int32.Parse(textBox10.Text);
            _operationStWork.ApplyEndDate = Int32.Parse(textBox11.Text);

            object paraobj = _operationStWork;

            OperationStWork _retoperationStWork = null;
            _retoperationStWork = new OperationStWork();
            object retobj = _retoperationStWork;

            #endregion

            //SEARCH実行
            int status = _OperationStDB.Search(ref retobj, paraobj, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り";
                ArrayList al = retobj as ArrayList;
                dataGrid1.DataSource = al;
            } 
        }

        /// <summary>
        /// WRITEボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //WRITE
            #region [パラメータセット]
            _operationStWork = new OperationStWork();
            _operationStWork.EnterpriseCode = textBox1.Text;
            _operationStWork.OperationStDiv = Int32.Parse(textBox2.Text);
            _operationStWork.CategoryCode = Int32.Parse(textBox3.Text);
            _operationStWork.PgId = textBox4.Text;
            _operationStWork.OperationCode = Int32.Parse(textBox5.Text);
            _operationStWork.AuthorityLevel1 = Int32.Parse(textBox6.Text);
            _operationStWork.AuthorityLevel2 = Int32.Parse(textBox7.Text);
            _operationStWork.EmployeeCode = textBox8.Text;
            _operationStWork.LimitDiv = Int32.Parse(textBox9.Text);
            _operationStWork.ApplyStartDate = Int32.Parse(textBox10.Text);
            _operationStWork.ApplyEndDate = Int32.Parse(textBox11.Text);

            object paraobj = _operationStWork;
            #endregion

            //WRITE実行
            int status = _OperationStDB.Write(ref paraobj);

            if (status != 0)
            {
                Text = "Write失敗";
            }
            else
            {
                Text = "Write成功";
            } 
        }

        /// <summary>
        /// DELETEボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //DELETE
            #region [パラメータセット]
            _operationStWork = new OperationStWork();
            _operationStWork.EnterpriseCode = textBox1.Text;
            _operationStWork.OperationStDiv = Int32.Parse(textBox2.Text);
            _operationStWork.CategoryCode = Int32.Parse(textBox3.Text);
            _operationStWork.PgId = textBox4.Text;
            _operationStWork.OperationCode = Int32.Parse(textBox5.Text);
            _operationStWork.AuthorityLevel1 = Int32.Parse(textBox6.Text);
            _operationStWork.AuthorityLevel2 = Int32.Parse(textBox7.Text);
            _operationStWork.EmployeeCode = textBox8.Text;
            _operationStWork.LimitDiv = Int32.Parse(textBox9.Text);
            _operationStWork.ApplyStartDate = Int32.Parse(textBox10.Text);
            _operationStWork.ApplyEndDate = Int32.Parse(textBox11.Text);

            object paraobj = _operationStWork;
            #endregion

            //DELETE実行
            int status = _OperationStDB.Delete(paraobj);

            if (status != 0)
            {
                Text = "Delete失敗";
            }
            else
            {
                Text = "Delete成功";
            } 
        }

        /// <summary>
        /// LDELETEボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //LDELETE
            #region [パラメータセット]
            _operationStWork = new OperationStWork();
            _operationStWork.EnterpriseCode = textBox1.Text;
            _operationStWork.OperationStDiv = Int32.Parse(textBox2.Text);
            _operationStWork.CategoryCode = Int32.Parse(textBox3.Text);
            _operationStWork.PgId = textBox4.Text;
            _operationStWork.OperationCode = Int32.Parse(textBox5.Text);
            _operationStWork.AuthorityLevel1 = Int32.Parse(textBox6.Text);
            _operationStWork.AuthorityLevel2 = Int32.Parse(textBox7.Text);
            _operationStWork.EmployeeCode = textBox8.Text;
            _operationStWork.LimitDiv = Int32.Parse(textBox9.Text);
            _operationStWork.ApplyStartDate = Int32.Parse(textBox10.Text);
            _operationStWork.ApplyEndDate = Int32.Parse(textBox11.Text);

            object paraobj = _operationStWork;
            #endregion

            //DELETE実行
            int status = _OperationStDB.LogicalDelete(ref paraobj);

            if (status != 0)
            {
                Text = "LDelete失敗";
            }
            else
            {
                Text = "LDelete成功";
            } 
        }

        /// <summary>
        /// RDARETEボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //RDARETE
            #region [パラメータセット]
            _operationStWork = new OperationStWork();
            _operationStWork.EnterpriseCode = textBox1.Text;
            _operationStWork.OperationStDiv = Int32.Parse(textBox2.Text);
            _operationStWork.CategoryCode = Int32.Parse(textBox3.Text);
            _operationStWork.PgId = textBox4.Text;
            _operationStWork.OperationCode = Int32.Parse(textBox5.Text);
            _operationStWork.AuthorityLevel1 = Int32.Parse(textBox6.Text);
            _operationStWork.AuthorityLevel2 = Int32.Parse(textBox7.Text);
            _operationStWork.EmployeeCode = textBox8.Text;
            _operationStWork.LimitDiv = Int32.Parse(textBox9.Text);
            _operationStWork.ApplyStartDate = Int32.Parse(textBox10.Text);
            _operationStWork.ApplyEndDate = Int32.Parse(textBox11.Text);

            object paraobj = _operationStWork;
            #endregion

            //DELETE実行
            int status = _OperationStDB.RevivalLogicalDelete(ref paraobj);

            if (status != 0)
            {
                Text = "RDelete失敗";
            }
            else
            {
                Text = "RDelete成功";
            } 
        }

        /// <summary>
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
			//ICustSlipNoSetDB = MediationCustSlipNoSetDB.GetCustSlipNoSetDB();
            _OperationStDB = MediationOperationStDB.GetOperationStDB();
			textBox1.Text = LoginInfoAcquisition.EnterpriseCode;
#if DEBUG
            this.Text = "CustSlipNoSet - Debug";
#else
            this.Text = "CustSlipNoSet - Release";
#endif
        }

        #region
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button9_Click(object sender, System.EventArgs e)
		{
            /*
			dataGrid1.DataSource = null;
			dataGrid2.DataSource = null;
            CustomSerializeArrayList al = new CustomSerializeArrayList();
            CustSlipNoSetWork CustSlipNoSetWork = new CustSlipNoSetWork();
            this.SetKey(ref CustSlipNoSetWork);
            al.Add(CustSlipNoSetWork);
            dataGrid2.DataSource = al;
             */
		}

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button8_Click(object sender, System.EventArgs e)
		{
            /*
            object parabyte = (dataGrid2.DataSource as CustomSerializeArrayList)[0];
			object objCustSlipNoSet = new CustomSerializeArrayList();

			int status = ICustSlipNoSetDB.Search(ref objCustSlipNoSet, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{

				Text = "該当データ有り  HIT "+((CustomSerializeArrayList)objCustSlipNoSet).Count.ToString()+"件";

				dataGrid1.DataSource = objCustSlipNoSet;
			}
             */
		}

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
            /*
			object objCustSlipNoSetList = dataGrid1.DataSource;

			int status = ICustSlipNoSetDB.Write(ref objCustSlipNoSetList);
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
				dataGrid1.DataSource = null;
				dataGrid1.DataSource = objCustSlipNoSetList;
			}
             */
		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
            /*
			CustSlipNoSetWork CustSlipNoSetWork = new CustSlipNoSetWork();
            this.SetKey(ref CustSlipNoSetWork);
			CustomSerializeArrayList al = dataGrid1.DataSource as CustomSerializeArrayList;
			if(al == null)al = new CustomSerializeArrayList();
			al.Add(CustSlipNoSetWork);
			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
             */
		}

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button13_Click(object sender, System.EventArgs e)
		{
            /*
            object objCustSlipNoSetList = dataGrid1.DataSource;

            int status = ICustSlipNoSetDB.LogicalDelete(ref objCustSlipNoSetList);
            if (status != 0)
            {
                Text = "論理削除失敗";
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
                Text = "論理削除成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objCustSlipNoSetList;
            }
             */
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            /*
            object objCustSlipNoSetList = dataGrid1.DataSource;

            int status = ICustSlipNoSetDB.Delete(objCustSlipNoSetList);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再削除してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
                dataGrid1.DataSource = null;
                //dataGrid1.DataSource = objCustSlipNoSetList;
            }
             */
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            /*
            object objCustSlipNoSetList = dataGrid1.DataSource;

            int status = ICustSlipNoSetDB.RevivalLogicalDelete(ref objCustSlipNoSetList);
            if (status != 0)
            {
                Text = "復活失敗";
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
                Text = "復活成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objCustSlipNoSetList;
            }
             */
        }
        #endregion
    }
}

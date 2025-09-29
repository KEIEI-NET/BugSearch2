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
		private System.Windows.Forms.Button button9;

		private OprtnHisLogWork _oprtnHisLogWork = null;
        private OprtnHisLogSrchWork _oprtnHisLogSrchWork = null;
        private OprationLogOrderWork _oprationLogOrderWork = null;

		//private OprtnHisLogWork _prevOprtnHisLogWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private IOprtnHisLogDB IoprtnhislogDB = null;

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
        private TextBox textBox12;
        private Label label12;
        private TextBox textBox13;
        private Label label13;
        private TextBox textBox14;
        private Label label14;
        private TextBox textBox15;
        private Label label15;
        private TextBox textBox16;
        private Label label16;
        private TextBox textBox17;
        private Label label17;
        private TextBox textBox18;
        private Label label18;
        private TextBox textBox19;
        private Label label19;
        private TextBox textBox20;
        private Label label20;
        private TextBox textBox21;
        private Label label21;
        private TextBox textBox22;
        private Label label22;
        private TextBox textBox23;
        private Label label23;
        private TextBox textBox24;
        private Label label24;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
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
            this.button9 = new System.Windows.Forms.Button();
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
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 170);
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
            this.dataGrid1.Location = new System.Drawing.Point(16, 315);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 221);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 170);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(82, 286);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(288, 286);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(16, 286);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(360, 286);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(432, 286);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(504, 286);
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
            this.dataGrid2.Location = new System.Drawing.Point(16, 199);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "企業コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 41;
            this.textBox1.Text = "0101150842020000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 43;
            this.textBox2.Text = "20080725";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "ログデータ作成日時";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(115, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "ログデータGUID";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(115, 67);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "ログイン拠点コード";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(115, 86);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 19);
            this.textBox5.TabIndex = 49;
            this.textBox5.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "種別区分コード";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(115, 105);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 19);
            this.textBox6.TabIndex = 51;
            this.textBox6.Text = "23012A1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "端末名";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(115, 124);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 19);
            this.textBox7.TabIndex = 53;
            this.textBox7.Text = "0001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "担当者コード";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(115, 143);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 19);
            this.textBox8.TabIndex = 55;
            this.textBox8.Text = "MACMN00114R";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "起動ﾌﾟﾛｸﾞﾗﾑ名称";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(332, 10);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 19);
            this.textBox9.TabIndex = 57;
            this.textBox9.Text = "MACMN00114R";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 12);
            this.label9.TabIndex = 56;
            this.label9.Text = "アセンブリID";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(332, 29);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 19);
            this.textBox10.TabIndex = 59;
            this.textBox10.Text = "操作履歴ログデータリモート";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(233, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "アセンブリ名称";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(332, 48);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 19);
            this.textBox11.TabIndex = 61;
            this.textBox11.Text = "Test";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 60;
            this.label11.Text = "クラスID";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(332, 67);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 19);
            this.textBox12.TabIndex = 63;
            this.textBox12.Text = "Read";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 62;
            this.label12.Text = "処理名";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(332, 86);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 19);
            this.textBox13.TabIndex = 65;
            this.textBox13.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 12);
            this.label13.TabIndex = 64;
            this.label13.Text = "オペレーションコード";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(332, 105);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 19);
            this.textBox14.TabIndex = 67;
            this.textBox14.Text = "10";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(233, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 12);
            this.label14.TabIndex = 66;
            this.label14.Text = "データ処理レベル";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(332, 124);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 19);
            this.textBox15.TabIndex = 69;
            this.textBox15.Text = "10";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(233, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 12);
            this.label15.TabIndex = 68;
            this.label15.Text = "機能処理レベル";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(332, 143);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 19);
            this.textBox16.TabIndex = 71;
            this.textBox16.Text = "9.9.9999";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(233, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 12);
            this.label16.TabIndex = 70;
            this.label16.Text = "システムバージョン";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(555, 10);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 19);
            this.textBox17.TabIndex = 73;
            this.textBox17.Text = "1000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(456, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 12);
            this.label17.TabIndex = 72;
            this.label17.Text = "オペレーションステータス";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(555, 29);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 19);
            this.textBox18.TabIndex = 75;
            this.textBox18.Text = "エラーです";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(456, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 12);
            this.label18.TabIndex = 74;
            this.label18.Text = "データメッセージ";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(555, 48);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 19);
            this.textBox19.TabIndex = 77;
            this.textBox19.Text = "処理に失敗";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(456, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 12);
            this.label19.TabIndex = 76;
            this.label19.Text = "オペレーションデータ";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(555, 67);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(100, 19);
            this.textBox20.TabIndex = 79;
            this.textBox20.Text = "morimoto";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(456, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 78;
            this.label20.Text = "担当者名";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(555, 86);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(100, 19);
            this.textBox21.TabIndex = 81;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(456, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 80;
            this.label21.Text = "label21";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(555, 105);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 19);
            this.textBox22.TabIndex = 83;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(456, 108);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 82;
            this.label22.Text = "label22";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(555, 124);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(100, 19);
            this.textBox23.TabIndex = 85;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(456, 127);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 84;
            this.label23.Text = "label23";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(555, 143);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(100, 19);
            this.textBox24.TabIndex = 87;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(456, 146);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 86;
            this.label24.Text = "label24";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 88;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 89;
            this.button3.Text = "Write";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(340, 170);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 90;
            this.button4.Text = "Delete";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(421, 170);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 91;
            this.button5.Text = "LDelete";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(502, 170);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 92;
            this.button6.Text = "RDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(832, 170);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 93;
            this.button7.Text = "Write×3";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label12);
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
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
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

        /// <summary>
        /// READボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            //READ
            #region [パラメータセット]
            _oprtnHisLogWork = new OprtnHisLogWork();
            _oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            _oprtnHisLogWork.LogDataCreateDateTime = DateTime.ParseExact(textBox2.Text, "yyyyMMddHHmmss", null);
            //_oprtnHisLogWork.LogDataGuid = textBox3.Text;
            //Guid guidValue = Guid.NewGuid();
            //_oprtnHisLogWork.LogDataGuid = guidValue;
            _oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            _oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            _oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            _oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            _oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            _oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            _oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            _oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            _oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            _oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            _oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            _oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            _oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            _oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            _oprtnHisLogWork.LogDataMassage = textBox18.Text;
            _oprtnHisLogWork.LogOperationData = textBox19.Text;

            object paraobj = _oprtnHisLogWork;
            #endregion

            int status = IoprtnhislogDB.Read(ref paraobj, 0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(paraobj);
                dataGrid1.DataSource = al;
			}		
		}

        /// <summary>
        /// SHEACH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //SHEACH
            #region [パラメータセット]
            //_oprtnHisLogSrchWork = new OprtnHisLogSrchWork();
            //_oprtnHisLogSrchWork.EnterpriseCode = textBox1.Text;
            //_oprtnHisLogSrchWork.St_LogDataCreateDateTime = DateTime.ParseExact("20080101000000", "yyyyMMddHHmmss", null);
            //_oprtnHisLogSrchWork.Ed_LogDataCreateDateTime = DateTime.ParseExact("20081231235959", "yyyyMMddHHmmss", null);
            ////_oprtnHisLogSrchWork.LoginSectionCd = "0001";
            //_oprtnHisLogSrchWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            //_oprtnHisLogSrchWork.LogDataMachineName = textBox6.Text;
            //_oprtnHisLogSrchWork.LogDataAgentCd = textBox7.Text;
            //_oprtnHisLogSrchWork.LogDataObjAssemblyID = textBox9.Text;
            //_oprtnHisLogSrchWork.LogDataOperationCd = Int32.Parse(textBox13.Text);

            //object paraobj = _oprtnHisLogSrchWork;

            //OprtnHisLogSrchWork _retoprtnHisLogSrchWork = null;
            //_retoprtnHisLogSrchWork = new OprtnHisLogSrchWork();
            //object retobj = _retoprtnHisLogSrchWork;
            #endregion

            _oprationLogOrderWork = new OprationLogOrderWork();
            _oprationLogOrderWork.EnterpriseCode = textBox1.Text;
            //_oprationLogOrderWork.St_LogDataCreateDateTime = DateTime.ParseExact("20080101000000", "yyyyMMddHHmmss", null);
            //_oprationLogOrderWork.Ed_LogDataCreateDateTime = DateTime.ParseExact("20081231235959", "yyyyMMddHHmmss", null);
            //_oprtnHisLogSrchWork.LoginSectionCd = "0001";
            _oprationLogOrderWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprationLogOrderWork.LogDataMachineName = textBox6.Text;
            _oprationLogOrderWork.LogDataObjClassID = textBox7.Text;

            object paraobj = _oprationLogOrderWork;

            OprtnHisLogWork _retoprtnHisLogSrchWork = null;
            _retoprtnHisLogSrchWork = new OprtnHisLogWork();
            object retobj = _retoprtnHisLogSrchWork;


            //SEARCH実行
            int status = IoprtnhislogDB.SearchUOE(ref retobj, paraobj, 0, 0);

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
        /// WRITE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //WRITE
            #region [パラメータセット]
            _oprtnHisLogWork = new OprtnHisLogWork();
            _oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            _oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
            //_oprtnHisLogWork.LogDataCreateDateTime = DateTime.ParseExact(textBox2.Text, "yyyyMMddHHmmss", null);
            //_oprtnHisLogWork.LogDataGuid = textBox3.Text;
            //Guid guidValue = Guid.NewGuid();
            //_oprtnHisLogWork.LogDataGuid = guidValue;
            _oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            _oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            _oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            _oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            _oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            _oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            _oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            _oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            _oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            _oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            _oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            _oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            _oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            _oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            _oprtnHisLogWork.LogDataMassage = textBox18.Text;
            _oprtnHisLogWork.LogOperationData = textBox19.Text;

            object paraobj = _oprtnHisLogWork;
            #endregion

            int status = IoprtnhislogDB.Write(ref paraobj);
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
        /// DELETE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //DELETE
            #region [パラメータセット]
            _oprtnHisLogWork = new OprtnHisLogWork();
            _oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            //_oprtnHisLogWork.LogDataCreateDateTime = DateTime.ParseExact(textBox2.Text, "yyyyMMddHHmmss", null);
            //_oprtnHisLogWork.LogDataGuid = textBox3.Text;
            //Guid guidValue = Guid.NewGuid();
            //_oprtnHisLogWork.LogDataGuid = guidValue;
            _oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            _oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            _oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            _oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            _oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            _oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            _oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            _oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            _oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            _oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            _oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            _oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            _oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            _oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            _oprtnHisLogWork.LogDataMassage = textBox18.Text;
            _oprtnHisLogWork.LogOperationData = textBox19.Text;

            _oprationLogOrderWork = new OprationLogOrderWork();
            _oprationLogOrderWork.EnterpriseCode = textBox1.Text;
            _oprationLogOrderWork.St_LogDataCreateDateTime = DateTime.ParseExact("20080101000000", "yyyyMMddHHmmss", null);
            _oprationLogOrderWork.Ed_LogDataCreateDateTime = DateTime.ParseExact("20081231235959", "yyyyMMddHHmmss", null);
            //_oprtnHisLogSrchWork.LoginSectionCd = "0001";
            _oprationLogOrderWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprationLogOrderWork.LogDataMachineName = textBox6.Text;
            _oprationLogOrderWork.LogDataObjClassID = textBox7.Text;

            string[] str = new string[1];

            //for (int i = 0; i < 2; i++)
            //{
                str[0] = "22";
                //str[1] = "03";
            //}
            if (str.Length != 0)
            {
                _oprationLogOrderWork.SectionCodes = str;
            }


            object paraobj = _oprationLogOrderWork;

            OprtnHisLogWork _retoprtnHisLogSrchWork = null;
            _retoprtnHisLogSrchWork = new OprtnHisLogWork();
            object retobj = _retoprtnHisLogSrchWork;

            object p = _oprtnHisLogWork;
            #endregion

            int status = IoprtnhislogDB.DeleteUOE(paraobj);
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
        /// LDETETE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //LDETETE
            #region [パラメータセット]
            _oprtnHisLogWork = new OprtnHisLogWork();
            _oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            _oprtnHisLogWork.LogDataCreateDateTime = DateTime.ParseExact(textBox2.Text, "yyyyMMddHHmmss", null);
            //_oprtnHisLogWork.LogDataGuid = textBox3.Text;
            //Guid guidValue = Guid.NewGuid();
            //_oprtnHisLogWork.LogDataGuid = guidValue;
            _oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            _oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            _oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            _oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            _oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            _oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            _oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            _oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            _oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            _oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            _oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            _oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            _oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            _oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            _oprtnHisLogWork.LogDataMassage = textBox18.Text;
            _oprtnHisLogWork.LogOperationData = textBox19.Text;

            object paraobj = _oprtnHisLogWork;
            #endregion

            int status = IoprtnhislogDB.LogicalDelete(ref paraobj);
            if (status != 0)
            {
                Text = "LogicalDelete失敗";
            }
            else
            {
                Text = "LogicalDelete成功";
            }
        }

        /// <summary>
        /// RDELETE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //RDELETE
            #region [パラメータセット]
            _oprtnHisLogWork = new OprtnHisLogWork();
            _oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            _oprtnHisLogWork.LogDataCreateDateTime = DateTime.ParseExact(textBox2.Text, "yyyyMMddHHmmss", null);
            //_oprtnHisLogWork.LogDataGuid = textBox3.Text;
            //Guid guidValue = Guid.NewGuid();
            //_oprtnHisLogWork.LogDataGuid = guidValue;
            _oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            _oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            _oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            _oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            _oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            _oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            _oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            _oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            _oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            _oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            _oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            _oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            _oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            _oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            _oprtnHisLogWork.LogDataMassage = textBox18.Text;
            _oprtnHisLogWork.LogOperationData = textBox19.Text;

            object paraobj = _oprtnHisLogWork;
            #endregion

            int status = IoprtnhislogDB.RevivalLogicalDelete(ref paraobj);
            if (status != 0)
            {
                Text = "RevivalLogicalDelete失敗";
            }
            else
            {
                Text = "RevivalLogicalDelete成功";
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
			IoprtnhislogDB = MediationOprtnHisLogDB.GetOprtnHisLogDB();
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
            ArrayList al = new ArrayList();
            OprtnHisLogWork work = new OprtnHisLogWork();
            work.EnterpriseCode = textBox1.Text;
            al.Add(work);
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
			object parabyte = dataGrid2.DataSource;
			object objoprtnHisLog;

			int status = IoprtnhislogDB.Search(out objoprtnHisLog, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{

				Text = "該当データ有り  HIT "+((ArrayList)objoprtnHisLog).Count.ToString()+"件";
				
				dataGrid1.DataSource = objoprtnHisLog;
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
			object objoprtnHisLogWork = dataGrid1.DataSource;
	
			int status = IoprtnhislogDB.Write(ref objoprtnHisLogWork);
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
				dataGrid1.DataSource = objoprtnHisLogWork;
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
			OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();
			oprtnHisLogWork.EnterpriseCode = textBox1.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(oprtnHisLogWork);
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
            object objoprtnHisLogWork = dataGrid1.DataSource;

            int status = IoprtnhislogDB.LogicalDelete(ref objoprtnHisLogWork);
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
                dataGrid1.DataSource = objoprtnHisLogWork;
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
            object objoprtnHisLogWork = dataGrid1.DataSource;

            OprtnHisLogWork[] trarray = (OprtnHisLogWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(OprtnHisLogWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IoprtnhislogDB.Delete(parabyte);
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
                //dataGrid1.DataSource = objoprtnHisLogWork;
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
            object objoprtnHisLogWork = dataGrid1.DataSource;

            int status = IoprtnhislogDB.RevivalLogicalDelete(ref objoprtnHisLogWork);
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
                dataGrid1.DataSource = objoprtnHisLogWork;
            }
             */
        }
        #endregion
        /// <summary>
        /// WRITE×3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            //WRITE×3
            #region [パラメータセット]
            _oprtnHisLogWork = new OprtnHisLogWork();
            _oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            //_oprtnHisLogWork.LogDataCreateDateTime = DateTime.Now;
            //_oprtnHisLogWork.LogDataCreateDateTime = DateTime.ParseExact(textBox2.Text, "yyyyMMddHHmmss", null);
            _oprtnHisLogWork.LogDataCreateDateTime = new DateTime(2008, 10, 23 ,11,13,50);
            //_oprtnHisLogWork.LogDataGuid = textBox3.Text;
            //Guid guidValue = Guid.NewGuid();
            //_oprtnHisLogWork.LogDataGuid = guidValue;
            _oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            _oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            _oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            _oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            _oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            _oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            _oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            _oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            _oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            _oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            _oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            _oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            _oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            _oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            _oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            _oprtnHisLogWork.LogDataMassage = textBox18.Text;
            _oprtnHisLogWork.LogOperationData = textBox19.Text;

            object paraobj = _oprtnHisLogWork;
            #endregion

            paraobj = CreateObj();
            int status = IoprtnhislogDB.Write(ref paraobj);
            if (status != 0)
            {
                Text = "Write1失敗 ST=" + Convert.ToString(status);
            }
            else
            {
                Text = "Write1成功 ";
            }
            paraobj = CreateObj();
            status = IoprtnhislogDB.Write(ref paraobj);
            
            if (status != 0)
            {
                Text += "Write2失敗 ST=" + Convert.ToString(status);
            }
            else
            {
                Text += "Write2成功 ";
            }
            paraobj = CreateObj();
            status = IoprtnhislogDB.Write(ref paraobj);
            if (status != 0)
            {
                Text += "Write3失敗 ST=" + Convert.ToString(status);
            }
            else
            {
                Text += "Write3成功 ";
            }


        }

        private object CreateObj()
        {
            OprtnHisLogWork oprtnHisLogWork;

            oprtnHisLogWork = new OprtnHisLogWork();
            oprtnHisLogWork.EnterpriseCode = textBox1.Text;
            oprtnHisLogWork.LogDataCreateDateTime = new DateTime(2008, 10, 23,11, 13, 50);

            oprtnHisLogWork.LoginSectionCd = textBox4.Text;
            oprtnHisLogWork.LogDataKindCd = Int32.Parse(textBox5.Text);
            oprtnHisLogWork.LogDataMachineName = textBox6.Text;
            oprtnHisLogWork.LogDataAgentCd = textBox7.Text;
            oprtnHisLogWork.LogDataAgentNm = textBox20.Text;
            oprtnHisLogWork.LogDataObjBootProgramNm = textBox8.Text;
            oprtnHisLogWork.LogDataObjAssemblyID = textBox9.Text;
            oprtnHisLogWork.LogDataObjAssemblyNm = textBox10.Text;
            oprtnHisLogWork.LogDataObjClassID = textBox11.Text;
            oprtnHisLogWork.LogDataObjProcNm = textBox12.Text;
            oprtnHisLogWork.LogDataOperationCd = Int32.Parse(textBox13.Text);
            oprtnHisLogWork.LogOperaterDtProcLvl = textBox14.Text;
            oprtnHisLogWork.LogOperaterFuncLvl = textBox15.Text;
            oprtnHisLogWork.LogDataSystemVersion = textBox16.Text;
            oprtnHisLogWork.LogOperationStatus = Int32.Parse(textBox17.Text);
            oprtnHisLogWork.LogDataMassage = textBox18.Text;
            oprtnHisLogWork.LogOperationData = textBox19.Text;


            return oprtnHisLogWork;
        }

    }
}

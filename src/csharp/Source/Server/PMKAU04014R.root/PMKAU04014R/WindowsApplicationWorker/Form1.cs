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
	public class Form1 : System.Windows.Forms.Form
	{
        #region Windows

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.Container components = null;
        //private System.Windows.Forms.TextBox tb08;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb01;
        #endregion

        //private IStockMonthYearReportDataWorkDB IstockMonthYearReportDataWorkDB = null;
        private ICustPrtPprWorkDB IcustPrtPprWorkDB = null;
        //private StockMoveListResultWork stockMoveListResultWork = new StockMoveListResultWork();
        private static string[] _parameter;
        private Label label9;
        private Button button1;
        private TextBox tb50;
        private ListBox listBox1;
        private Label label6;
        private Button button3;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label4;
        private TextBox textBox7;
        private Label label5;
        private TextBox textBox8;
        private Label label7;
        private TextBox textBox9;
        private Label label10;
        private TextBox textBox10;
        private Label label11;
        private TextBox textBox11;
        private Label label12;
        private TextBox textBox12;
        private Label label13;
        private TextBox textBox13;
        private Label label14;
        private TextBox textBox14;
        private Label label15;
        private TextBox textBox15;
        private Label label16;
        private TextBox textBox16;
        private Label label17;
        private TextBox textBox17;
        private Label label18;
        private TextBox textBox18;
        private Label label19;
        private TextBox textBox19;
        private Label label20;
        private TextBox textBox21;
        private Label label21;
        private TextBox textBox20;
        private Label label22;
        private TextBox textBox23;
        private Label label23;
        private TextBox textBox22;
        private Label label24;
        private TextBox textBox25;
        private Label label25;
        private TextBox textBox24;
        private Label label26;
        private TextBox textBox28;
        private Label label27;
        private TextBox textBox27;
        private Label label28;
        private TextBox textBox26;
        private Label label29;
        private TextBox textBox31;
        private Label label30;
        private TextBox textBox30;
        private Label label31;
        private TextBox textBox29;
        private Label label32;
        private TextBox textBox32;
        private Label label33;
        private TextBox textBox35;
        private Label label34;
        private TextBox textBox34;
        private Label label35;
        private TextBox textBox33;
        private Label label36;
        private TextBox textBox38;
        private Label label37;
        private TextBox textBox37;
        private Label label38;
        private DataGrid dataGrid2;
        private TextBox textBox36;
        private Label label39;
        private Button button4;
        private Button button5;
        private TextBox textBox40;
        private Label label40;
        private TextBox textBox39;
        private Label label41;
        private TextBox MaxCnt;
        private Label label42;
        private TextBox textBox41;
        private TextBox textBox42;
        private Label label43;
        private TextBox textBox43;
        private Label label44;
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
            this.tb01 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.MaxCnt = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // tb01
            // 
            this.tb01.Location = new System.Drawing.Point(10, 3);
            this.tb01.Name = "tb01";
            this.tb01.Size = new System.Drawing.Size(144, 19);
            this.tb01.TabIndex = 1;
            this.tb01.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(10, 320);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(919, 120);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TabStop = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(80, 179);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 24);
            this.button8.TabIndex = 50;
            this.button8.Text = "SearchA";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(444, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 19);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(557, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 19);
            this.label9.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 232;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb50
            // 
            this.tb50.Location = new System.Drawing.Point(10, 53);
            this.tb50.Name = "tb50";
            this.tb50.Size = new System.Drawing.Size(144, 19);
            this.tb50.TabIndex = 231;
            this.tb50.TabStop = false;
            this.tb50.Text = "000000";
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(10, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 88);
            this.listBox1.TabIndex = 230;
            this.listBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 229;
            this.label6.Text = "■拠点コード";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 228;
            this.button3.TabStop = false;
            this.button3.Text = "Add";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 248;
            this.button2.Text = "SearchB";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 249;
            this.label1.Text = "得意先コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(265, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 250;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(265, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 252;
            this.textBox2.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 251;
            this.label2.Text = "請求先コード";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(265, 67);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 254;
            this.textBox3.Text = "20080101";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 253;
            this.label3.Text = "売上日付";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(369, 67);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 255;
            this.textBox4.Text = "20081231";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(369, 86);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 19);
            this.textBox6.TabIndex = 258;
            this.textBox6.Text = "20081231";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(265, 86);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 19);
            this.textBox5.TabIndex = 257;
            this.textBox5.Text = "20080101";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 256;
            this.label4.Text = "入力日付";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(265, 105);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 19);
            this.textBox7.TabIndex = 260;
            this.textBox7.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 259;
            this.label5.Text = "伝票区分";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(265, 124);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 19);
            this.textBox8.TabIndex = 262;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 261;
            this.label7.Text = "伝票番号";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(265, 143);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 19);
            this.textBox9.TabIndex = 264;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 263;
            this.label10.Text = "担当者";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(265, 162);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 19);
            this.textBox10.TabIndex = 266;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(163, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 265;
            this.label11.Text = "受注者";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(265, 181);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 19);
            this.textBox11.TabIndex = 268;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(163, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 267;
            this.label12.Text = "発行者";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(265, 200);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 19);
            this.textBox12.TabIndex = 270;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(163, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 269;
            this.label13.Text = "管理番号";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(265, 219);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 19);
            this.textBox13.TabIndex = 272;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(163, 222);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 271;
            this.label14.Text = "車種名称";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(265, 238);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 19);
            this.textBox14.TabIndex = 274;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(163, 241);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 273;
            this.label15.Text = "型式";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(265, 257);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 19);
            this.textBox15.TabIndex = 276;
            this.textBox15.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(163, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 275;
            this.label16.Text = "車台№";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(265, 276);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 19);
            this.textBox16.TabIndex = 278;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(163, 279);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 277;
            this.label17.Text = "指示書№";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(265, 295);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 19);
            this.textBox17.TabIndex = 280;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(163, 298);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 12);
            this.label18.TabIndex = 279;
            this.label18.Text = "カラー名称";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(585, 29);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 19);
            this.textBox18.TabIndex = 282;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(483, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 12);
            this.label19.TabIndex = 281;
            this.label19.Text = "トリム名称";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(585, 48);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 19);
            this.textBox19.TabIndex = 284;
            this.textBox19.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(483, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 12);
            this.label20.TabIndex = 283;
            this.label20.Text = "UOE送信";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(585, 86);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(100, 19);
            this.textBox21.TabIndex = 288;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(483, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 12);
            this.label21.TabIndex = 287;
            this.label21.Text = "備考２";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(585, 67);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(100, 19);
            this.textBox20.TabIndex = 286;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(483, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 12);
            this.label22.TabIndex = 285;
            this.label22.Text = "備考１";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(585, 124);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(100, 19);
            this.textBox23.TabIndex = 292;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(483, 127);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(61, 12);
            this.label23.TabIndex = 291;
            this.label23.Text = "UOEﾘﾏｰｸ1";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(585, 105);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 19);
            this.textBox22.TabIndex = 290;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(483, 108);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 12);
            this.label24.TabIndex = 289;
            this.label24.Text = "備考３";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(585, 162);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(100, 19);
            this.textBox25.TabIndex = 296;
            this.textBox25.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(483, 165);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 12);
            this.label25.TabIndex = 295;
            this.label25.Text = "BLグループ";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(585, 143);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(100, 19);
            this.textBox24.TabIndex = 294;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(483, 146);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(61, 12);
            this.label26.TabIndex = 293;
            this.label26.Text = "UOEﾘﾏｰｸ2";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(585, 219);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(100, 19);
            this.textBox28.TabIndex = 302;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(483, 222);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 12);
            this.label27.TabIndex = 301;
            this.label27.Text = "品番";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(585, 200);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(100, 19);
            this.textBox27.TabIndex = 300;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(483, 203);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 299;
            this.label28.Text = "品名";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(585, 181);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(100, 19);
            this.textBox26.TabIndex = 298;
            this.textBox26.Text = "0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(483, 184);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(46, 12);
            this.label29.TabIndex = 297;
            this.label29.Text = "BLコード";
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(585, 276);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(100, 19);
            this.textBox31.TabIndex = 308;
            this.textBox31.Text = "0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(483, 279);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 307;
            this.label30.Text = "自社分類";
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(585, 257);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(100, 19);
            this.textBox30.TabIndex = 306;
            this.textBox30.Text = "0";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(483, 260);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 305;
            this.label31.Text = "販売区分";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(585, 238);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(100, 19);
            this.textBox29.TabIndex = 304;
            this.textBox29.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(483, 241);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 12);
            this.label32.TabIndex = 303;
            this.label32.Text = "メーカー";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(585, 295);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(100, 19);
            this.textBox32.TabIndex = 310;
            this.textBox32.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(483, 298);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 12);
            this.label33.TabIndex = 309;
            this.label33.Text = "在庫取寄区分";
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(808, 67);
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(100, 19);
            this.textBox35.TabIndex = 316;
            this.textBox35.Text = "0";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(706, 70);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 12);
            this.label34.TabIndex = 315;
            this.label34.Text = "仕入先";
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(808, 48);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(100, 19);
            this.textBox34.TabIndex = 314;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(706, 51);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 12);
            this.label35.TabIndex = 313;
            this.label35.Text = "仕入伝票番号";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(808, 29);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(100, 19);
            this.textBox33.TabIndex = 312;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(706, 32);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 12);
            this.label36.TabIndex = 311;
            this.label36.Text = "倉庫";
            // 
            // textBox38
            // 
            this.textBox38.Location = new System.Drawing.Point(808, 124);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(100, 19);
            this.textBox38.TabIndex = 322;
            this.textBox38.Text = "0";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(706, 127);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(77, 12);
            this.label37.TabIndex = 321;
            this.label37.Text = "削除指定区分";
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(808, 105);
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(100, 19);
            this.textBox37.TabIndex = 320;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(706, 108);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.TabIndex = 319;
            this.label38.Text = "明細備考";
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(10, 446);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(919, 195);
            this.dataGrid2.TabIndex = 325;
            this.dataGrid2.TabStop = false;
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(808, 86);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(100, 19);
            this.textBox36.TabIndex = 318;
            this.textBox36.Text = "0";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(706, 89);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(41, 12);
            this.label39.TabIndex = 317;
            this.label39.Text = "発注先";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 23);
            this.button4.TabIndex = 326;
            this.button4.Text = "残高・明細検索";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 23);
            this.button5.TabIndex = 327;
            this.button5.Text = "残高一覧検索";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(808, 257);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(100, 19);
            this.textBox40.TabIndex = 331;
            this.textBox40.Text = "200812";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(706, 219);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(111, 12);
            this.label40.TabIndex = 330;
            this.label40.Text = "残高一覧表示の条件";
            // 
            // textBox39
            // 
            this.textBox39.Location = new System.Drawing.Point(808, 238);
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(100, 19);
            this.textBox39.TabIndex = 329;
            this.textBox39.Text = "200801";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(706, 241);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(53, 12);
            this.label41.TabIndex = 328;
            this.label41.Text = "対象年月";
            // 
            // MaxCnt
            // 
            this.MaxCnt.Location = new System.Drawing.Point(265, 4);
            this.MaxCnt.Name = "MaxCnt";
            this.MaxCnt.Size = new System.Drawing.Size(100, 19);
            this.MaxCnt.TabIndex = 333;
            this.MaxCnt.Text = "51";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(163, 7);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(65, 12);
            this.label42.TabIndex = 332;
            this.label42.Text = "検索上限数";
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(369, 105);
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(100, 19);
            this.textBox41.TabIndex = 334;
            this.textBox41.Text = "0";
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(808, 276);
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(100, 19);
            this.textBox42.TabIndex = 336;
            this.textBox42.Text = "0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(706, 279);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 12);
            this.label43.TabIndex = 335;
            this.label43.Text = "検索種別";
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(808, 143);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(100, 19);
            this.textBox43.TabIndex = 338;
            this.textBox43.Text = "0";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(706, 146);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(77, 12);
            this.label44.TabIndex = 337;
            this.label44.Text = "伝票検索区分";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 653);
            this.Controls.Add(this.textBox43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.textBox42);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.textBox41);
            this.Controls.Add(this.MaxCnt);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.textBox40);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.textBox39);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.textBox38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.textBox37);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.textBox36);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.textBox35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.textBox34);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.textBox33);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.textBox32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.textBox31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.textBox30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb50);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb01);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion


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
            //IstockMonthYearReportDataWorkDB = MediationStockMonthYearReportDataWorkDB.GetStockMonthYearReportDataWorkDB();
            IcustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
		}

        //Search
		private void button8_Click(object sender, System.EventArgs e)
		{
            /*
			DateTime start,end;
			start = DateTime.Now;

            StockMonthYearReportWork stockMonthYearReportWork = new StockMonthYearReportWork();

            #region 値セット
            //企業コード
            stockMonthYearReportWork.EnterpriseCode = tb01.Text;

            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                stockMonthYearReportWork.SectionCodes = str;
            }

            stockMonthYearReportWork.St_AddUpYearMonth =  DateTime.ParseExact(tb04.Text, "yyyyMM", null);
            stockMonthYearReportWork.Ed_AddUpYearMonth =  DateTime.ParseExact(tb05.Text, "yyyyMM", null);
            stockMonthYearReportWork.PartsManagementDivide1 = null;
            stockMonthYearReportWork.PartsManagementDivide2 = null;
            stockMonthYearReportWork.St_WarehouseCode = tb8.Text;
            stockMonthYearReportWork.Ed_WarehouseCode = tb9.Text;
            stockMonthYearReportWork.St_SupplierCd = Int32.Parse(tb10.Text);
            stockMonthYearReportWork.Ed_SupplierCd = Int32.Parse(tb11.Text);
            stockMonthYearReportWork.St_GoodsMakerCd = Int32.Parse(tb12.Text);
            stockMonthYearReportWork.Ed_GoodsMakerCd = Int32.Parse(tb13.Text);
            stockMonthYearReportWork.St_GoodsNo = tb14.Text;
            stockMonthYearReportWork.Ed_GoodsNo = tb15.Text;



            #endregion

            object paraobj = stockMonthYearReportWork;      //条件パラメータ
			object retobj = null;                           //DM抽出結果
            int status= 0;
            try
            {
                status = IstockMonthYearReportDataWorkDB.Search(out retobj, paraobj, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
			{
                Text = "該当データ無し  status=" + status;
            }
			else
			{
				Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";
				
				dataGrid1.DataSource = retobj;
			}		

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
             */
		}

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            DateTime start, end;
            start = DateTime.Now;

            StockMonthYearReportWork stockMonthYearReportWork = new StockMonthYearReportWork();

            #region 値セット
            //企業コード
            stockMonthYearReportWork.EnterpriseCode = tb01.Text;

            #endregion

            object paraobj = stockMonthYearReportWork;      //条件パラメータ
            object retobj = null;                           //DM抽出結果

            int status = IstockMonthYearReportDataWorkDB.Search(out retobj, paraobj, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し  status=" + status;
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";

                dataGrid1.DataSource = retobj;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);
             */

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(tb50.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        //残高・明細検索
        private void button4_Click(object sender, EventArgs e)
        {
            //
            DateTime start, end;
            start = DateTime.Now;

            CustPrtPprWork custPrtPprWork = new CustPrtPprWork();

            #region 値セット
            //企業コード
            custPrtPprWork.EnterpriseCode = tb01.Text;

            //拠点コード
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                custPrtPprWork.SectionCode = str;
            }

            custPrtPprWork.SearchCnt = Int64.Parse(MaxCnt.Text);
            custPrtPprWork.CustomerCode = Int32.Parse(textBox1.Text);
            custPrtPprWork.ClaimCode = Int32.Parse(textBox2.Text);
            custPrtPprWork.St_SalesDate = DateTime.ParseExact(textBox3.Text, "yyyyMMdd", null);
            custPrtPprWork.Ed_SalesDate = DateTime.ParseExact(textBox4.Text, "yyyyMMdd", null);
            custPrtPprWork.St_AddUpADate = DateTime.ParseExact(textBox5.Text, "yyyyMMdd", null);
            custPrtPprWork.Ed_AddUpADate = DateTime.ParseExact(textBox6.Text, "yyyyMMdd", null);
            
            //custPrtPprWork.AcptAnOdrStatus = Int32.Parse(textBox7.Text);
            //custPrtPprWork.SalesSlipCd = Int32.Parse(textBox41.Text);
            custPrtPprWork.AcptAnOdrStatus = null;
            custPrtPprWork.SalesSlipCd = null;
            //Int32[] iAcptAnOdrStatus = { 30 };
            //Int32[] iSalesSlipCd = { 0, 1, 2, 3, 4, 5, 6 };
            //custPrtPprWork.AcptAnOdrStatus = iAcptAnOdrStatus;
            //custPrtPprWork.SalesSlipCd = iSalesSlipCd;

            custPrtPprWork.SalesSlipNum = textBox8.Text;
            custPrtPprWork.SalesEmployeeCd = textBox9.Text;
            custPrtPprWork.FrontEmployeeCd = textBox10.Text;
            custPrtPprWork.SalesInputCode = textBox11.Text;
            custPrtPprWork.CarMngCode = textBox12.Text;
            custPrtPprWork.ModelFullName = textBox13.Text;
            custPrtPprWork.FullModel = textBox14.Text;
            custPrtPprWork.SearchFrameNo = Int32.Parse(textBox15.Text);
            custPrtPprWork.PartySaleSlipNum = textBox16.Text;
            custPrtPprWork.ColorName1 = textBox17.Text;
            custPrtPprWork.TrimName = textBox18.Text;
            custPrtPprWork.DataSendCode = Int32.Parse(textBox19.Text);
            custPrtPprWork.SlipNote = textBox20.Text;
            custPrtPprWork.SlipNote2 = textBox21.Text;
            custPrtPprWork.SlipNote3 = textBox22.Text;
            custPrtPprWork.UoeRemark1 = textBox23.Text;
            custPrtPprWork.UoeRemark2 = textBox24.Text;
            custPrtPprWork.BLGroupCode = Int32.Parse(textBox25.Text);
            custPrtPprWork.BLGoodsCode = Int32.Parse(textBox26.Text);
            custPrtPprWork.GoodsName = textBox27.Text;
            custPrtPprWork.GoodsNo = textBox28.Text;
            custPrtPprWork.GoodsMakerCd = Int32.Parse(textBox29.Text);
            custPrtPprWork.SalesCode = Int32.Parse(textBox30.Text);
            custPrtPprWork.EnterpriseGanreCode = Int32.Parse(textBox31.Text);
            custPrtPprWork.SalesOrderDivCd = Int32.Parse(textBox32.Text);
            custPrtPprWork.WarehouseCode = textBox33.Text;
            custPrtPprWork.SupplierSlipNo = textBox34.Text;
            custPrtPprWork.SupplierCd = Int32.Parse(textBox35.Text);
            custPrtPprWork.UOESupplierCd = Int32.Parse(textBox36.Text);
            custPrtPprWork.DtlNote = textBox37.Text;
            custPrtPprWork.SearchType = Int32.Parse(textBox43.Text);
            #endregion

            object paraobj = custPrtPprWork;       //条件パラメータ
           
            object retobj1 = null;

            object retobj2 = null;


            int status = 0;
            Int64 iDataCnt = 0;

            try
            {
                status = IcustPrtPprWorkDB.SearchRef(ref retobj1, ref retobj2, paraobj, out iDataCnt, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "該当データ無し  status=" + status + " iDataCnt=" + iDataCnt;
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj2).Count.ToString() + "件";

                dataGrid1.DataSource = retobj1;
                dataGrid2.DataSource = retobj2;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);
        }

        //残高一覧検索
        private void button5_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            CustPrtPprBlnceWork custPrtPprBlnceWork = new CustPrtPprBlnceWork();

            #region 値セット
            //企業コード
            custPrtPprBlnceWork.EnterpriseCode = tb01.Text;

            //拠点コード
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                custPrtPprBlnceWork.SectionCode = str;
            }
            custPrtPprBlnceWork.CustomerCode = Int32.Parse(textBox1.Text);
            custPrtPprBlnceWork.ClaimCode = Int32.Parse(textBox2.Text);
            custPrtPprBlnceWork.St_AddUpYearMonth = DateTime.ParseExact(textBox39.Text, "yyyyMM", null);
            custPrtPprBlnceWork.Ed_AddUpYearMonth = DateTime.ParseExact(textBox40.Text, "yyyyMM", null);

            #endregion

            object paraobj = custPrtPprBlnceWork;       //条件パラメータ

            object retobj1 = null;

            int status = 0;
            int iDiv = Int32.Parse(textBox42.Text);
            try
            {
                status = IcustPrtPprWorkDB.SearchBlTbl(ref retobj1, paraobj, iDiv, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "該当データ無し  status=" + status;
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj1).Count.ToString() + "件";

                dataGrid1.DataSource = retobj1;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
	}
}

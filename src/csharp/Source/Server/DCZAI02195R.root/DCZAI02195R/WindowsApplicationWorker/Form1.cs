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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb03;
        private System.Windows.Forms.TextBox tb01;
        private System.Windows.Forms.TextBox tb04;
        private System.Windows.Forms.TextBox tb06;
        private System.Windows.Forms.TextBox tb05;
        private System.Windows.Forms.TextBox tb02;
        private TextBox tb07;
        private Label label10;
        #endregion

        private IStockOverListWorkDB IstockOverListWorkDB = null;

        private static string[] _parameter;
        private Label label9;
        private Button button1;
        private TextBox tb50;
        private ListBox listBox1;
        private Label label6;
        private Button button3;
        private TextBox tb8;
        private TextBox tb9;
        private TextBox tb11;
        private TextBox tb10;
        private TextBox tb12;
        private TextBox tb15;
        private TextBox tb13;
        private Label label4;
        private Label label7;
        private Label label11;
        private Label label12;
        private TextBox tb14;
        private TextBox tb04b;
        private TextBox tb16;
        private Label label2;
        private TextBox tb17;
        private TextBox tb18;
        private Label label5;
        private TextBox tb19;
        private TextBox tb20;
        private Label label13;
        private TextBox tb21;
        private TextBox tb22;
        private Label label14;
        private TextBox tb23;
        private TextBox tb24;
        private Label label15;
        private TextBox tb25;
        private TextBox tb26;
        private Label label16;
        private TextBox tb27;
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
            this.tb04 = new System.Windows.Forms.TextBox();
            this.tb03 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tb8 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tb06 = new System.Windows.Forms.TextBox();
            this.tb05 = new System.Windows.Forms.TextBox();
            this.tb02 = new System.Windows.Forms.TextBox();
            this.tb07 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.tb15 = new System.Windows.Forms.TextBox();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb14 = new System.Windows.Forms.TextBox();
            this.tb04b = new System.Windows.Forms.TextBox();
            this.tb16 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb17 = new System.Windows.Forms.TextBox();
            this.tb18 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb19 = new System.Windows.Forms.TextBox();
            this.tb20 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb21 = new System.Windows.Forms.TextBox();
            this.tb22 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tb23 = new System.Windows.Forms.TextBox();
            this.tb24 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tb25 = new System.Windows.Forms.TextBox();
            this.tb26 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tb27 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            // tb04
            // 
            this.tb04.BackColor = System.Drawing.Color.White;
            this.tb04.Location = new System.Drawing.Point(288, 28);
            this.tb04.Name = "tb04";
            this.tb04.Size = new System.Drawing.Size(72, 19);
            this.tb04.TabIndex = 6;
            this.tb04.Text = "200805";
            // 
            // tb03
            // 
            this.tb03.Location = new System.Drawing.Point(366, 3);
            this.tb03.Name = "tb03";
            this.tb03.Size = new System.Drawing.Size(72, 19);
            this.tb03.TabIndex = 3;
            this.tb03.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(160, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "倉庫コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(160, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "管理区分1,2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(10, 318);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(428, 175);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TabStop = false;
            // 
            // tb8
            // 
            this.tb8.Location = new System.Drawing.Point(288, 72);
            this.tb8.Name = "tb8";
            this.tb8.Size = new System.Drawing.Size(72, 19);
            this.tb8.TabIndex = 100;
            this.tb8.TabStop = false;
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
            this.label8.Location = new System.Drawing.Point(7, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 19);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb06
            // 
            this.tb06.Location = new System.Drawing.Point(288, 50);
            this.tb06.Name = "tb06";
            this.tb06.Size = new System.Drawing.Size(72, 19);
            this.tb06.TabIndex = 4;
            // 
            // tb05
            // 
            this.tb05.BackColor = System.Drawing.Color.White;
            this.tb05.Location = new System.Drawing.Point(366, 28);
            this.tb05.Name = "tb05";
            this.tb05.Size = new System.Drawing.Size(72, 19);
            this.tb05.TabIndex = 8;
            this.tb05.Text = "200805";
            // 
            // tb02
            // 
            this.tb02.Location = new System.Drawing.Point(288, 3);
            this.tb02.Name = "tb02";
            this.tb02.Size = new System.Drawing.Size(72, 19);
            this.tb02.TabIndex = 2;
            this.tb02.Text = "20081201";
            // 
            // tb07
            // 
            this.tb07.Location = new System.Drawing.Point(366, 50);
            this.tb07.Name = "tb07";
            this.tb07.Size = new System.Drawing.Size(72, 19);
            this.tb07.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(160, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 19);
            this.label10.TabIndex = 184;
            this.label10.Text = "棚番";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(135, 296);
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
            // tb9
            // 
            this.tb9.Location = new System.Drawing.Point(366, 72);
            this.tb9.Name = "tb9";
            this.tb9.Size = new System.Drawing.Size(72, 19);
            this.tb9.TabIndex = 233;
            this.tb9.TabStop = false;
            // 
            // tb11
            // 
            this.tb11.Location = new System.Drawing.Point(366, 95);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(72, 19);
            this.tb11.TabIndex = 234;
            this.tb11.TabStop = false;
            // 
            // tb10
            // 
            this.tb10.Location = new System.Drawing.Point(288, 95);
            this.tb10.Name = "tb10";
            this.tb10.Size = new System.Drawing.Size(72, 19);
            this.tb10.TabIndex = 235;
            this.tb10.TabStop = false;
            // 
            // tb12
            // 
            this.tb12.Location = new System.Drawing.Point(288, 117);
            this.tb12.Name = "tb12";
            this.tb12.Size = new System.Drawing.Size(72, 19);
            this.tb12.TabIndex = 236;
            this.tb12.TabStop = false;
            this.tb12.Text = "0";
            // 
            // tb15
            // 
            this.tb15.Location = new System.Drawing.Point(366, 139);
            this.tb15.Name = "tb15";
            this.tb15.Size = new System.Drawing.Size(72, 19);
            this.tb15.TabIndex = 238;
            this.tb15.TabStop = false;
            this.tb15.Text = "9999";
            // 
            // tb13
            // 
            this.tb13.Location = new System.Drawing.Point(366, 117);
            this.tb13.Name = "tb13";
            this.tb13.Size = new System.Drawing.Size(72, 19);
            this.tb13.TabIndex = 240;
            this.tb13.TabStop = false;
            this.tb13.Text = "999999";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(160, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 241;
            this.label4.Text = "在庫登録日";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(160, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 19);
            this.label7.TabIndex = 242;
            this.label7.Text = "メーカーコード";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(160, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 19);
            this.label11.TabIndex = 243;
            this.label11.Text = "仕入先コード";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(160, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 19);
            this.label12.TabIndex = 246;
            this.label12.Text = "未出荷経過月";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb14
            // 
            this.tb14.Location = new System.Drawing.Point(288, 139);
            this.tb14.Name = "tb14";
            this.tb14.Size = new System.Drawing.Size(72, 19);
            this.tb14.TabIndex = 250;
            this.tb14.TabStop = false;
            this.tb14.Text = "0";
            // 
            // tb04b
            // 
            this.tb04b.BackColor = System.Drawing.Color.White;
            this.tb04b.Location = new System.Drawing.Point(263, 27);
            this.tb04b.Name = "tb04b";
            this.tb04b.Size = new System.Drawing.Size(19, 19);
            this.tb04b.TabIndex = 251;
            this.tb04b.Text = "0";
            // 
            // tb16
            // 
            this.tb16.Location = new System.Drawing.Point(288, 161);
            this.tb16.Name = "tb16";
            this.tb16.Size = new System.Drawing.Size(72, 19);
            this.tb16.TabIndex = 254;
            this.tb16.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(160, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 253;
            this.label2.Text = "品番";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb17
            // 
            this.tb17.Location = new System.Drawing.Point(366, 161);
            this.tb17.Name = "tb17";
            this.tb17.Size = new System.Drawing.Size(72, 19);
            this.tb17.TabIndex = 252;
            this.tb17.TabStop = false;
            // 
            // tb18
            // 
            this.tb18.Location = new System.Drawing.Point(288, 183);
            this.tb18.Name = "tb18";
            this.tb18.Size = new System.Drawing.Size(72, 19);
            this.tb18.TabIndex = 257;
            this.tb18.TabStop = false;
            this.tb18.Text = "0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(160, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 256;
            this.label5.Text = "BLコード";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb19
            // 
            this.tb19.Location = new System.Drawing.Point(366, 183);
            this.tb19.Name = "tb19";
            this.tb19.Size = new System.Drawing.Size(72, 19);
            this.tb19.TabIndex = 255;
            this.tb19.TabStop = false;
            this.tb19.Text = "99999";
            // 
            // tb20
            // 
            this.tb20.Location = new System.Drawing.Point(288, 205);
            this.tb20.Name = "tb20";
            this.tb20.Size = new System.Drawing.Size(72, 19);
            this.tb20.TabIndex = 260;
            this.tb20.TabStop = false;
            this.tb20.Text = "0";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(160, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 19);
            this.label13.TabIndex = 259;
            this.label13.Text = "商品大分類";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb21
            // 
            this.tb21.Location = new System.Drawing.Point(366, 205);
            this.tb21.Name = "tb21";
            this.tb21.Size = new System.Drawing.Size(72, 19);
            this.tb21.TabIndex = 258;
            this.tb21.TabStop = false;
            this.tb21.Text = "9999";
            // 
            // tb22
            // 
            this.tb22.Location = new System.Drawing.Point(288, 228);
            this.tb22.Name = "tb22";
            this.tb22.Size = new System.Drawing.Size(72, 19);
            this.tb22.TabIndex = 263;
            this.tb22.TabStop = false;
            this.tb22.Text = "0";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(160, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 19);
            this.label14.TabIndex = 262;
            this.label14.Text = "商品中分類";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb23
            // 
            this.tb23.Location = new System.Drawing.Point(366, 228);
            this.tb23.Name = "tb23";
            this.tb23.Size = new System.Drawing.Size(72, 19);
            this.tb23.TabIndex = 261;
            this.tb23.TabStop = false;
            this.tb23.Text = "9999";
            // 
            // tb24
            // 
            this.tb24.Location = new System.Drawing.Point(288, 250);
            this.tb24.Name = "tb24";
            this.tb24.Size = new System.Drawing.Size(72, 19);
            this.tb24.TabIndex = 266;
            this.tb24.TabStop = false;
            this.tb24.Text = "0";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(160, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 19);
            this.label15.TabIndex = 265;
            this.label15.Text = "グループコード";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb25
            // 
            this.tb25.Location = new System.Drawing.Point(366, 250);
            this.tb25.Name = "tb25";
            this.tb25.Size = new System.Drawing.Size(72, 19);
            this.tb25.TabIndex = 264;
            this.tb25.TabStop = false;
            this.tb25.Text = "99999";
            // 
            // tb26
            // 
            this.tb26.Location = new System.Drawing.Point(288, 272);
            this.tb26.Name = "tb26";
            this.tb26.Size = new System.Drawing.Size(72, 19);
            this.tb26.TabIndex = 269;
            this.tb26.TabStop = false;
            this.tb26.Text = "0";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(160, 271);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 19);
            this.label16.TabIndex = 268;
            this.label16.Text = "商品区分";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb27
            // 
            this.tb27.Location = new System.Drawing.Point(366, 272);
            this.tb27.Name = "tb27";
            this.tb27.Size = new System.Drawing.Size(72, 19);
            this.tb27.TabIndex = 267;
            this.tb27.TabStop = false;
            this.tb27.Text = "9999";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(457, 505);
            this.Controls.Add(this.tb26);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tb27);
            this.Controls.Add(this.tb24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tb25);
            this.Controls.Add(this.tb22);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tb23);
            this.Controls.Add(this.tb20);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb21);
            this.Controls.Add(this.tb18);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb19);
            this.Controls.Add(this.tb16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb17);
            this.Controls.Add(this.tb04b);
            this.Controls.Add(this.tb14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb13);
            this.Controls.Add(this.tb15);
            this.Controls.Add(this.tb12);
            this.Controls.Add(this.tb10);
            this.Controls.Add(this.tb11);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb50);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb07);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb02);
            this.Controls.Add(this.tb06);
            this.Controls.Add(this.tb05);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.tb03);
            this.Controls.Add(this.tb04);
            this.Controls.Add(this.tb01);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
            IstockOverListWorkDB = MediationStockOverListWorkDB.GetStockOverListWorkDB();
		}

        //Search
		private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

            StockOverListCndtnWork stockOverListCndtnWork = new StockOverListCndtnWork();

            #region 値セット
            
            stockOverListCndtnWork.EnterpriseCode = tb01.Text;  //企業コード
            //拠点コード
            /*
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                stockOverListCndtnWork.SectionCodes = str;
            }
            */
            stockOverListCndtnWork.SectionCodes = null;
            stockOverListCndtnWork.StockCreateDate = DateTime.ParseExact(tb02.Text, "yyyyMMdd", null);  //在庫登録日
            stockOverListCndtnWork.StockCreateDateDiv = Int32.Parse(tb03.Text);                         //在庫登録日指定区分
            stockOverListCndtnWork.St_AddUpYearMonth = DateTime.ParseExact(tb04.Text, "yyyyMM", null);  //開始未出荷経過月
            stockOverListCndtnWork.Ed_AddUpYearMonth = DateTime.ParseExact(tb05.Text, "yyyyMM", null);  //終了未出荷経過月
            stockOverListCndtnWork.NoShipmentDiv = Int32.Parse(tb04b.Text);                             //未出荷指定区分
            stockOverListCndtnWork.PartsManagementDivide1 = null;//tb06.Text;                                  //部品管理区分１
            stockOverListCndtnWork.PartsManagementDivide2 = null;//tb07.Text;                                  //部品管理区分２
            stockOverListCndtnWork.St_WarehouseCode = tb8.Text;                                         //開始倉庫コード
            stockOverListCndtnWork.Ed_WarehouseCode = tb9.Text;                                         //終了倉庫コード
            stockOverListCndtnWork.St_WarehouseShelfNo = tb10.Text;                                     //開始棚番
            stockOverListCndtnWork.Ed_WarehouseShelfNo = tb11.Text;                                     //終了棚番
            stockOverListCndtnWork.St_SupplierCd = Int32.Parse(tb12.Text);                              //開始仕入先コード
            stockOverListCndtnWork.Ed_SupplierCd = Int32.Parse(tb13.Text);                              //終了仕入先コード
            stockOverListCndtnWork.St_GoodsMakerCd = Int32.Parse(tb14.Text);                            //開始商品メーカーコード
            stockOverListCndtnWork.Ed_GoodsMakerCd = Int32.Parse(tb15.Text);                            //終了商品メーカーコード
            stockOverListCndtnWork.St_GoodsNo = tb16.Text;                                              //開始商品番号
            stockOverListCndtnWork.Ed_GoodsNo = tb17.Text;                                              //終了商品番号
            stockOverListCndtnWork.St_BLGoodsCode = Int32.Parse(tb18.Text);                             //開始BL商品コード
            stockOverListCndtnWork.Ed_BLGoodsCode = Int32.Parse(tb19.Text);                             //終了BL商品コード
            /*
            stockOverListCndtnWork.St_LargeGoodsGanreCode = Int32.Parse(tb20.Text);                     //開始商品大分類
            stockOverListCndtnWork.Ed_LargeGoodsGanreCode = Int32.Parse(tb21.Text);                     //終了商品大分類
            stockOverListCndtnWork.St_MediumGoodsGanreCode = Int32.Parse(tb22.Text);                    //開始商品中分類
            stockOverListCndtnWork.Ed_MediumGoodsGanreCode = Int32.Parse(tb23.Text);                    //終了商品中分類
            stockOverListCndtnWork.St_DetailGoodsGanreCode = Int32.Parse(tb24.Text);                    //開始グループコード
            stockOverListCndtnWork.Ed_DetailGoodsGanreCode = Int32.Parse(tb25.Text);                    //終了グループコード
             */
            stockOverListCndtnWork.St_EnterpriseGanreCode = Int32.Parse(tb26.Text);                     //開始商品区分
            stockOverListCndtnWork.Ed_EnterpriseGanreCode = Int32.Parse(tb27.Text);                     //終了商品区分

            listBox1.Items.Add("000001");

            #endregion

            object paraobj = stockOverListCndtnWork;      //条件パラメータ
			object retobj = null;                               //DM抽出結果

            int status = IstockOverListWorkDB.Search(out retobj, paraobj, 0, 0);

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
		}

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(tb50.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
	}
}

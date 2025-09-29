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
using Broadleaf.Library.Globarization;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        #region Windows

        private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.TextBox tb17;
		private System.Windows.Forms.TextBox tb18;
		private System.Windows.Forms.TextBox tb19;
		private System.Windows.Forms.TextBox tb20;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button4;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
        private TextBox tb3;
        private Label label6;
        private TextBox tb5;
        private Label label7;
        private TextBox tb4;
        private Label label10;
        private TextBox StSCd;
        private TextBox tb6;
        private Label label12;
        private TextBox StGCD;
        private TextBox EdSCd;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private TextBox EdGCD;
        private Label label19;
        private TextBox tb1;
        private Label label20;
        private Label label21;
        private Button button11;
        #endregion

        private IInventoryExtDB  IinventoryExtDB = null;

        private static string[] _parameter;
        private Label label26;
        private Label label27;
        private Button button1;
        private Label label5;
        private Label label28;
        private TextBox tb25;
        private TextBox tb24;
        private TextBox tb23;
        private TextBox tb22;
        private TextBox tb21;
        private TextBox W01;
        private TextBox W09;
        private TextBox W05;
        private TextBox W06;
        private TextBox W10;
        private TextBox W02;
        private TextBox W07;
        private TextBox W08;
        private TextBox W03;
        private TextBox W04;
        private Label label30;
        private Label label31;
        private TextBox EdTana;
        private TextBox StTana;
        private Label label32;
        private Label label11;
        private Label label13;
        private TextBox IPDAY;
        private TextBox IPTIM;
        private Label label14;
        private Label label22;
        private TextBox UPDAY;
        private TextBox UPTIM;
        private Button button2;
		private static System.Windows.Forms.Form _form = null;

		public Form1()
		{
			InitializeComponent();
            tb1.Text = "0101150842020000";
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
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb17 = new System.Windows.Forms.TextBox();
            this.tb18 = new System.Windows.Forms.TextBox();
            this.tb19 = new System.Windows.Forms.TextBox();
            this.tb20 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button4 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.StSCd = new System.Windows.Forms.TextBox();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.StGCD = new System.Windows.Forms.TextBox();
            this.EdSCd = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.EdGCD = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tb25 = new System.Windows.Forms.TextBox();
            this.tb24 = new System.Windows.Forms.TextBox();
            this.tb23 = new System.Windows.Forms.TextBox();
            this.tb22 = new System.Windows.Forms.TextBox();
            this.tb21 = new System.Windows.Forms.TextBox();
            this.W01 = new System.Windows.Forms.TextBox();
            this.W09 = new System.Windows.Forms.TextBox();
            this.W05 = new System.Windows.Forms.TextBox();
            this.W06 = new System.Windows.Forms.TextBox();
            this.W10 = new System.Windows.Forms.TextBox();
            this.W02 = new System.Windows.Forms.TextBox();
            this.W07 = new System.Windows.Forms.TextBox();
            this.W08 = new System.Windows.Forms.TextBox();
            this.W03 = new System.Windows.Forms.TextBox();
            this.W04 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.EdTana = new System.Windows.Forms.TextBox();
            this.StTana = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.IPDAY = new System.Windows.Forms.TextBox();
            this.IPTIM = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.UPDAY = new System.Windows.Forms.TextBox();
            this.UPTIM = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(428, 3);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(131, 19);
            this.tb2.TabIndex = 1;
            this.tb2.Text = "01";
            // 
            // tb17
            // 
            this.tb17.Location = new System.Drawing.Point(565, 47);
            this.tb17.Name = "tb17";
            this.tb17.Size = new System.Drawing.Size(47, 19);
            this.tb17.TabIndex = 3;
            this.tb17.Text = "0";
            this.tb17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb18
            // 
            this.tb18.Location = new System.Drawing.Point(565, 72);
            this.tb18.Name = "tb18";
            this.tb18.Size = new System.Drawing.Size(47, 19);
            this.tb18.TabIndex = 4;
            this.tb18.Text = "0";
            this.tb18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb19
            // 
            this.tb19.Location = new System.Drawing.Point(565, 97);
            this.tb19.Name = "tb19";
            this.tb19.Size = new System.Drawing.Size(47, 19);
            this.tb19.TabIndex = 5;
            this.tb19.Text = "0";
            this.tb19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb20
            // 
            this.tb20.Location = new System.Drawing.Point(565, 122);
            this.tb20.Name = "tb20";
            this.tb20.Size = new System.Drawing.Size(47, 19);
            this.tb20.TabIndex = 6;
            this.tb20.Text = "0";
            this.tb20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(375, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "棚卸処理区分";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(375, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "商品種別（一般）抽出区分";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(375, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "商品種別（携帯電話）抽出区分";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(375, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "商品種別（付属品）抽出区分";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(17, 399);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(594, 298);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(117, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 23);
            this.button4.TabIndex = 32;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(118, 341);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(93, 23);
            this.button12.TabIndex = 35;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(18, 312);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(93, 23);
            this.button8.TabIndex = 36;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(380, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(461, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 35;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(126, 51);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(86, 19);
            this.tb3.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(17, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "倉庫コード";
            // 
            // tb5
            // 
            this.tb5.Location = new System.Drawing.Point(126, 192);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(86, 19);
            this.tb5.TabIndex = 16;
            this.tb5.Text = "0";
            this.tb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "仕入先コード";
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(242, 51);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(87, 19);
            this.tb4.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(17, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 19);
            this.label10.TabIndex = 40;
            this.label10.Text = "メーカーコード";
            // 
            // StSCd
            // 
            this.StSCd.Location = new System.Drawing.Point(126, 217);
            this.StSCd.Name = "StSCd";
            this.StSCd.Size = new System.Drawing.Size(86, 19);
            this.StSCd.TabIndex = 18;
            this.StSCd.Text = "0";
            this.StSCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb6
            // 
            this.tb6.Location = new System.Drawing.Point(242, 192);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(87, 19);
            this.tb6.TabIndex = 17;
            this.tb6.Text = "999999";
            this.tb6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(17, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 19);
            this.label12.TabIndex = 44;
            this.label12.Text = "グループコード";
            // 
            // StGCD
            // 
            this.StGCD.Location = new System.Drawing.Point(126, 242);
            this.StGCD.Name = "StGCD";
            this.StGCD.Size = new System.Drawing.Size(86, 19);
            this.StGCD.TabIndex = 20;
            this.StGCD.Text = "0";
            this.StGCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EdSCd
            // 
            this.EdSCd.Location = new System.Drawing.Point(242, 217);
            this.EdSCd.Name = "EdSCd";
            this.EdSCd.Size = new System.Drawing.Size(87, 19);
            this.EdSCd.TabIndex = 19;
            this.EdSCd.Text = "999999999";
            this.EdSCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(375, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 23);
            this.label15.TabIndex = 60;
            this.label15.Text = "在庫評価方法";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(375, 225);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(164, 21);
            this.label16.TabIndex = 58;
            this.label16.Text = "委託（受託）在庫抽出区分";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(375, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(164, 23);
            this.label17.TabIndex = 56;
            this.label17.Text = "委託（自社）在庫抽出区分";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(375, 174);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(164, 21);
            this.label18.TabIndex = 54;
            this.label18.Text = "受託在庫抽出区分";
            // 
            // EdGCD
            // 
            this.EdGCD.Location = new System.Drawing.Point(242, 242);
            this.EdGCD.Name = "EdGCD";
            this.EdGCD.Size = new System.Drawing.Size(87, 19);
            this.EdGCD.TabIndex = 21;
            this.EdGCD.Text = "99999";
            this.EdGCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(375, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(164, 23);
            this.label19.TabIndex = 52;
            this.label19.Text = "自社在庫抽出区分";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(102, 3);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(109, 19);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "0101150842020000";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(218, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 19);
            this.label20.TabIndex = 63;
            this.label20.Text = "～";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(218, 195);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 19);
            this.label21.TabIndex = 66;
            this.label21.Text = "～";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(19, 341);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(93, 23);
            this.button11.TabIndex = 67;
            this.button11.Text = "SearchWrite";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(218, 245);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(18, 19);
            this.label26.TabIndex = 76;
            this.label26.Text = "～";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(218, 220);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 19);
            this.label27.TabIndex = 77;
            this.label27.Text = "～";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 78;
            this.button1.Text = "DeleteInvent";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(362, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 79;
            this.label5.Text = "拠点コード";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(15, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 19);
            this.label28.TabIndex = 80;
            this.label28.Text = "企業コード";
            // 
            // tb25
            // 
            this.tb25.Location = new System.Drawing.Point(565, 247);
            this.tb25.Name = "tb25";
            this.tb25.Size = new System.Drawing.Size(47, 19);
            this.tb25.TabIndex = 81;
            this.tb25.Text = "0";
            this.tb25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb24
            // 
            this.tb24.Location = new System.Drawing.Point(565, 222);
            this.tb24.Name = "tb24";
            this.tb24.Size = new System.Drawing.Size(47, 19);
            this.tb24.TabIndex = 82;
            this.tb24.Text = "0";
            this.tb24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb23
            // 
            this.tb23.Location = new System.Drawing.Point(565, 197);
            this.tb23.Name = "tb23";
            this.tb23.Size = new System.Drawing.Size(47, 19);
            this.tb23.TabIndex = 83;
            this.tb23.Text = "0";
            this.tb23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb22
            // 
            this.tb22.Location = new System.Drawing.Point(565, 172);
            this.tb22.Name = "tb22";
            this.tb22.Size = new System.Drawing.Size(47, 19);
            this.tb22.TabIndex = 84;
            this.tb22.Text = "0";
            this.tb22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb21
            // 
            this.tb21.Location = new System.Drawing.Point(565, 147);
            this.tb21.Name = "tb21";
            this.tb21.Size = new System.Drawing.Size(47, 19);
            this.tb21.TabIndex = 85;
            this.tb21.Text = "0";
            this.tb21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // W01
            // 
            this.W01.Location = new System.Drawing.Point(126, 81);
            this.W01.Name = "W01";
            this.W01.Size = new System.Drawing.Size(54, 19);
            this.W01.TabIndex = 6;
            // 
            // W09
            // 
            this.W09.Location = new System.Drawing.Point(126, 138);
            this.W09.Name = "W09";
            this.W09.Size = new System.Drawing.Size(55, 19);
            this.W09.TabIndex = 14;
            // 
            // W05
            // 
            this.W05.Location = new System.Drawing.Point(126, 109);
            this.W05.Name = "W05";
            this.W05.Size = new System.Drawing.Size(54, 19);
            this.W05.TabIndex = 10;
            // 
            // W06
            // 
            this.W06.Location = new System.Drawing.Point(186, 109);
            this.W06.Name = "W06";
            this.W06.Size = new System.Drawing.Size(54, 19);
            this.W06.TabIndex = 11;
            // 
            // W10
            // 
            this.W10.Location = new System.Drawing.Point(186, 137);
            this.W10.Name = "W10";
            this.W10.Size = new System.Drawing.Size(55, 19);
            this.W10.TabIndex = 15;
            // 
            // W02
            // 
            this.W02.Location = new System.Drawing.Point(186, 81);
            this.W02.Name = "W02";
            this.W02.Size = new System.Drawing.Size(54, 19);
            this.W02.TabIndex = 7;
            // 
            // W07
            // 
            this.W07.Location = new System.Drawing.Point(246, 109);
            this.W07.Name = "W07";
            this.W07.Size = new System.Drawing.Size(54, 19);
            this.W07.TabIndex = 12;
            // 
            // W08
            // 
            this.W08.Location = new System.Drawing.Point(306, 108);
            this.W08.Name = "W08";
            this.W08.Size = new System.Drawing.Size(55, 19);
            this.W08.TabIndex = 13;
            // 
            // W03
            // 
            this.W03.Location = new System.Drawing.Point(246, 81);
            this.W03.Name = "W03";
            this.W03.Size = new System.Drawing.Size(54, 19);
            this.W03.TabIndex = 8;
            // 
            // W04
            // 
            this.W04.Location = new System.Drawing.Point(306, 81);
            this.W04.Name = "W04";
            this.W04.Size = new System.Drawing.Size(54, 19);
            this.W04.TabIndex = 9;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(17, 81);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(95, 12);
            this.label30.TabIndex = 89;
            this.label30.Text = "倉庫コード 単独";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(218, 169);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(18, 19);
            this.label31.TabIndex = 93;
            this.label31.Text = "～";
            // 
            // EdTana
            // 
            this.EdTana.Location = new System.Drawing.Point(242, 166);
            this.EdTana.Name = "EdTana";
            this.EdTana.Size = new System.Drawing.Size(87, 19);
            this.EdTana.TabIndex = 91;
            this.EdTana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StTana
            // 
            this.StTana.Location = new System.Drawing.Point(126, 166);
            this.StTana.Name = "StTana";
            this.StTana.Size = new System.Drawing.Size(86, 19);
            this.StTana.TabIndex = 90;
            this.StTana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(17, 169);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(164, 17);
            this.label32.TabIndex = 92;
            this.label32.Text = "棚番";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(362, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 94;
            this.label11.Text = "準備処理日";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(362, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 95;
            this.label13.Text = "準備処理時間";
            // 
            // IPDAY
            // 
            this.IPDAY.Location = new System.Drawing.Point(463, 296);
            this.IPDAY.Name = "IPDAY";
            this.IPDAY.Size = new System.Drawing.Size(96, 19);
            this.IPDAY.TabIndex = 96;
            // 
            // IPTIM
            // 
            this.IPTIM.Location = new System.Drawing.Point(463, 319);
            this.IPTIM.Name = "IPTIM";
            this.IPTIM.Size = new System.Drawing.Size(96, 19);
            this.IPTIM.TabIndex = 97;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(362, 342);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 98;
            this.label14.Text = "更新日";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(362, 365);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 23);
            this.label22.TabIndex = 99;
            this.label22.Text = "更新時間";
            // 
            // UPDAY
            // 
            this.UPDAY.Location = new System.Drawing.Point(463, 344);
            this.UPDAY.Name = "UPDAY";
            this.UPDAY.Size = new System.Drawing.Size(96, 19);
            this.UPDAY.TabIndex = 100;
            // 
            // UPTIM
            // 
            this.UPTIM.Location = new System.Drawing.Point(463, 368);
            this.UPTIM.Name = "UPTIM";
            this.UPTIM.Size = new System.Drawing.Size(96, 19);
            this.UPTIM.TabIndex = 101;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 102;
            this.button2.Text = "SearchInventoryDate";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(629, 719);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.UPTIM);
            this.Controls.Add(this.UPDAY);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.IPTIM);
            this.Controls.Add(this.IPDAY);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.EdTana);
            this.Controls.Add(this.StTana);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.W04);
            this.Controls.Add(this.W07);
            this.Controls.Add(this.W08);
            this.Controls.Add(this.W03);
            this.Controls.Add(this.W06);
            this.Controls.Add(this.W10);
            this.Controls.Add(this.W02);
            this.Controls.Add(this.W05);
            this.Controls.Add(this.W09);
            this.Controls.Add(this.W01);
            this.Controls.Add(this.tb21);
            this.Controls.Add(this.tb22);
            this.Controls.Add(this.tb23);
            this.Controls.Add(this.tb24);
            this.Controls.Add(this.tb25);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.EdGCD);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.StGCD);
            this.Controls.Add(this.EdSCd);
            this.Controls.Add(this.StSCd);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.tb20);
            this.Controls.Add(this.tb19);
            this.Controls.Add(this.tb18);
            this.Controls.Add(this.tb17);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					_form = new Form1();
					System.Windows.Forms.Application.Run(_form);
				}
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"Form1",msg,0,MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,"Form1",ex.Message,0,MessageBoxButtons.OK);
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
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"Form1",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"Form1",e.ToString(),0,MessageBoxButtons.OK);
			//アプリケーション終了
			System.Windows.Forms.Application.Exit();
		}
		

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IinventoryExtDB = MediationInventoryExtDB.GetInventoryExtDB();
        }

        #region SearchWrite
        private void button11_Click(object sender, EventArgs e)
        {
			DateTime start,end;
			start = DateTime.Now;

			InventoryExtCndtnWork wkInventoryExtCndtnWork = new InventoryExtCndtnWork();

            #region 検索パラメータセット
			wkInventoryExtCndtnWork.EnterpriseCode      = tb1.Text;                         // 企業コード
            wkInventoryExtCndtnWork.SectionCode         = tb2.Text;                         // 拠点コード
            wkInventoryExtCndtnWork.InventoryProcDiv    = Convert.ToInt32(tb17.Text);       // 棚卸処理区分
            wkInventoryExtCndtnWork.StWarehouseCd       = tb3.Text;                         // 倉庫コード開始
            wkInventoryExtCndtnWork.EdWarehouseCd       = tb4.Text;                         // 倉庫コード終了
            wkInventoryExtCndtnWork.WarehouseCd01       = W01.Text;                         // 単独倉庫1
            wkInventoryExtCndtnWork.WarehouseCd02       = W02.Text;                         // 単独倉庫2
            wkInventoryExtCndtnWork.WarehouseCd03       = W03.Text;                         // 単独倉庫3
            wkInventoryExtCndtnWork.WarehouseCd04       = W04.Text;                         // 単独倉庫4
            wkInventoryExtCndtnWork.WarehouseCd05       = W05.Text;                         // 単独倉庫5
            wkInventoryExtCndtnWork.WarehouseCd06       = W06.Text;                         // 単独倉庫6
            wkInventoryExtCndtnWork.WarehouseCd07       = W07.Text;                         // 単独倉庫7
            wkInventoryExtCndtnWork.WarehouseCd08       = W08.Text;                         // 単独倉庫8
            wkInventoryExtCndtnWork.WarehouseCd09       = W09.Text;                         // 単独倉庫9
            wkInventoryExtCndtnWork.WarehouseCd10       = W10.Text;                         // 単独倉庫10
            wkInventoryExtCndtnWork.StWarehouseShelfNo  = StTana.Text;                      // 棚番開始
            wkInventoryExtCndtnWork.EdWarehouseShelfNo  = EdTana.Text;                      // 棚番終了
            wkInventoryExtCndtnWork.StMakerCd           = Convert.ToInt32(tb5.Text);        // メーカーコード開始
            wkInventoryExtCndtnWork.EdMakerCd           = Convert.ToInt32(tb6.Text);        // メーカーコード終了
            wkInventoryExtCndtnWork.StBLGoodsCd         = Convert.ToInt32(tb17.Text);       // BLコード開始
            wkInventoryExtCndtnWork.EdBLGoodsCd         = Convert.ToInt32(tb18.Text);       // BLコード終了
            wkInventoryExtCndtnWork.StBLGroupCode       = Convert.ToInt32(StGCD.Text);      // グループコード開始
            wkInventoryExtCndtnWork.EdBLGroupCode       = Convert.ToInt32(EdGCD.Text);      // グループコード終了
            wkInventoryExtCndtnWork.StCustomerCd        = Convert.ToInt32(StSCd.Text);      // 仕入先コード開始
            wkInventoryExtCndtnWork.EdCustomerCd        = Convert.ToInt32(EdSCd.Text);      // 仕入先コード終了
            wkInventoryExtCndtnWork.StockPointWay       = Convert.ToInt32(tb25.Text);       // 在庫評価方法
            wkInventoryExtCndtnWork.InventoryDate       = Convert.ToDateTime("2008/09/17"); // 棚卸日
            #endregion

			object paraobj = wkInventoryExtCndtnWork;
            object retobj = null;

            string statusMSG = "";

			int status = IinventoryExtDB.SearchWrite( out retobj, paraobj, 0, 0, out statusMSG);

            if (status != 0)
			{
				Text = "該当ﾃﾞｰﾀ無し  st=" + status + "  stﾒｯｾｰｼﾞ=" + statusMSG;

				dataGrid1.DataSource = retobj;
            }
			else
			{
				Text = "該当ﾃﾞｰﾀ有り  棚卸準備履歴ﾏｽﾀ="+((ArrayList)retobj).Count.ToString()+"件" + "  stﾒｯｾｰｼﾞ=" + statusMSG;
				
				dataGrid1.DataSource = retobj;
			}		

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);

        }
        #endregion

        #region Search
        private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

			InventoryExtCndtnWork wkInventoryExtCndtnWork = new InventoryExtCndtnWork();

			wkInventoryExtCndtnWork.EnterpriseCode = tb1.Text;
            wkInventoryExtCndtnWork.SectionCode    = tb2.Text;      // 拠点コード
            //wkInventoryExtCndtnWork.StSectionCode  = StSecCD.Text;  // 拠点コード開始
            //wkInventoryExtCndtnWork.EdSectionCode  = EdSecCD.Text;  // 拠点コード終了   

			object paraobj = wkInventoryExtCndtnWork;
			object retobj = null;

			int status = IinventoryExtDB.Search(out retobj, paraobj, 0, 0);

            if (status != 0)
			{
				Text = "該当データ無し  st=" + status;
			}
			else
			{
				Text = "該当データ有り  HIT "+((ArrayList)retobj).Count.ToString()+"件";
				
				dataGrid1.DataSource = retobj;
            }		

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
        }
        #endregion

        #region Write
        private void button4_Click(object sender, System.EventArgs e)
		{
            DateTime start, end;
            start = DateTime.Now;

            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));
            InventDataPreWork wkInventDataPreWork = new InventDataPreWork();

            #region 検索パラメータセット
            wkInventDataPreWork.EnterpriseCode     = tb1.Text;                      // 企業コード    
            wkInventDataPreWork.SectionCode        = tb2.Text;                      // 拠点コード
            wkInventDataPreWork.InventoryPreprDay  = TDateTime.LongDateToDateTime("YYYYMMDD", SysDate); // 棚卸準簿処理日
            wkInventDataPreWork.InventoryPreprTim  = SysTime;                                           // 棚卸準備処理時間    
            wkInventDataPreWork.InventoryProcDiv   = Convert.ToInt32(tb17.Text);    // 棚卸処理区分
            wkInventDataPreWork.WarehouseCodeSt      = tb3.Text;                    // 倉庫コード開始
            wkInventDataPreWork.WarehouseCodeEd      = tb4.Text;                    // 倉庫コード終了
            wkInventDataPreWork.ShelfNoSt = StTana.Text;                            // 棚番開始
            wkInventDataPreWork.ShelfNoEd = EdTana.Text;                            // 棚番終了
            wkInventDataPreWork.StartSupplierCode = Convert.ToInt32(StSCd.Text);    // 仕入先コード開始
            wkInventDataPreWork.EndSupplierCode = Convert.ToInt32(EdSCd.Text);      // 仕入先コード終了
            wkInventDataPreWork.BLGoodsCodeSt = Convert.ToInt32(tb17.Text);         // BLコード開始
            wkInventDataPreWork.BLGoodsCodeEd = Convert.ToInt32(tb18.Text);         // BLコード終了 
            wkInventDataPreWork.GoodsMakerCdSt = Convert.ToInt32(tb5.Text);         // メーカーコード開始
            wkInventDataPreWork.GoodsMakerCdEd       = Convert.ToInt32(tb6.Text);   // メーカーコード終了
            wkInventDataPreWork.BLGroupCodeSt = Convert.ToInt32(StGCD.Text);        // グループコード開始
            wkInventDataPreWork.BLGroupCodeEd = Convert.ToInt32(EdGCD.Text);        // グループコード終了
            wkInventDataPreWork.TrtStkExtraDiv     = Convert.ToInt32(tb22.Text);    // 受託在庫抽出区分    
            wkInventDataPreWork.EntCmpStkExtraDiv  = Convert.ToInt32(tb23.Text);    // 委託(自社)在庫抽出区分
            wkInventDataPreWork.SelWarehouseCode1 = W01.Text;                       // 倉庫01
            wkInventDataPreWork.SelWarehouseCode2 = W02.Text;                       // 倉庫02
            wkInventDataPreWork.SelWarehouseCode3 = W03.Text;                       // 倉庫03
            wkInventDataPreWork.SelWarehouseCode4 = W04.Text;                       // 倉庫04
            wkInventDataPreWork.SelWarehouseCode5 = W05.Text;                       // 倉庫05
            wkInventDataPreWork.SelWarehouseCode6 = W06.Text;                       // 倉庫06
            wkInventDataPreWork.SelWarehouseCode7 = W07.Text;                       // 倉庫07
            wkInventDataPreWork.SelWarehouseCode8 = W08.Text;                       // 倉庫08
            wkInventDataPreWork.SelWarehouseCode9 = W09.Text;                       // 倉庫09
            wkInventDataPreWork.SelWarehouseCode10 = W10.Text;                      // 倉庫10        
            #endregion

            byte[] parabyte = XmlByteSerializer.Serialize(wkInventDataPreWork);

            int status = IinventoryExtDB.Write(ref parabyte);

            if (status != 0)
            {
                Text = "更新失敗 st=" + status;

                dataGrid1.DataSource = parabyte;
            }
            else
            {
                Text = "更新成功";
                InventDataPreWork inventDataPreWork = (InventDataPreWork)XmlByteSerializer.Deserialize(parabyte, typeof(InventDataPreWork));
                ArrayList retArray = new ArrayList();
                retArray.Add(inventDataPreWork);
                dataGrid1.DataSource = retArray;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);

        }
        #endregion

        #region Delete
        private void button12_Click(object sender, System.EventArgs e)
		{
            int SysDate = (Convert.ToInt32(DateTime.Now.Year * 10000)) + (Convert.ToInt32(DateTime.Now.Month * 100)) + (Convert.ToInt32(DateTime.Now.Day));
            int SysTime = (Convert.ToInt32(DateTime.Now.Hour * 10000)) + (Convert.ToInt32(DateTime.Now.Minute * 100)) + (Convert.ToInt32(DateTime.Now.Second));
            InventDataPreWork wkInventDataPreWork = new InventDataPreWork();

            wkInventDataPreWork.EnterpriseCode    = tb1.Text;
            wkInventDataPreWork.SectionCode       = tb2.Text;
            wkInventDataPreWork.InventoryPreprDay = TDateTime.LongDateToDateTime("YYYYMMDD", SysDate);
            wkInventDataPreWork.InventoryPreprTim = SysTime;
            wkInventDataPreWork.InventoryPreprDay = TDateTime.LongDateToDateTime("YYYYMMDD", Convert.ToInt32(IPDAY.Text));
            wkInventDataPreWork.InventoryPreprTim = Convert.ToInt32(IPTIM.Text);
            DateTime Dt = new DateTime( 2008,09,18,14,56,33,203 );
            wkInventDataPreWork.UpdateDateTime = Dt;

            byte[] parabyte = XmlByteSerializer.Serialize(wkInventDataPreWork);

            int status = IinventoryExtDB.Delete(parabyte);

            if (status != 0)
            {
                Text = "削除失敗  st=" + status;

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
        #endregion

        #region DeleteInvent
        private void button1_Click(object sender, System.EventArgs e)
        {
            InventoryDataWork wkInventoryDataWork = new InventoryDataWork();

            wkInventoryDataWork.EnterpriseCode = tb1.Text;
            wkInventoryDataWork.SectionCode = tb2.Text;

            byte[] parabyte = XmlByteSerializer.Serialize(wkInventoryDataWork);
            byte[] retbyte = null;

            int status = IinventoryExtDB.DeleteInvent(parabyte, out retbyte);

            if (status != 0)
            {
                Text = "削除失敗  st=" + status;

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
                InventDataPreWork inventDataPreWork = (InventDataPreWork)XmlByteSerializer.Deserialize(retbyte, typeof(InventDataPreWork));
                ArrayList retArray = new ArrayList();
                retArray.Add(inventDataPreWork);
                dataGrid1.DataSource = retArray;
            }

        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            InventoryExtCndtnWork wkInventoryExtCndtnWork = new InventoryExtCndtnWork();

            #region 検索パラメータセット
            wkInventoryExtCndtnWork.EnterpriseCode = tb1.Text;                         // 企業コード
            wkInventoryExtCndtnWork.SectionCode = tb2.Text;                         // 拠点コード
            wkInventoryExtCndtnWork.InventoryProcDiv = Convert.ToInt32(tb17.Text);       // 棚卸処理区分
            wkInventoryExtCndtnWork.StWarehouseCd = tb3.Text;                         // 倉庫コード開始
            wkInventoryExtCndtnWork.EdWarehouseCd = tb4.Text;                         // 倉庫コード終了
            wkInventoryExtCndtnWork.WarehouseCd01 = W01.Text;                         // 単独倉庫1
            wkInventoryExtCndtnWork.WarehouseCd02 = W02.Text;                         // 単独倉庫2
            wkInventoryExtCndtnWork.WarehouseCd03 = W03.Text;                         // 単独倉庫3
            wkInventoryExtCndtnWork.WarehouseCd04 = W04.Text;                         // 単独倉庫4
            wkInventoryExtCndtnWork.WarehouseCd05 = W05.Text;                         // 単独倉庫5
            wkInventoryExtCndtnWork.WarehouseCd06 = W06.Text;                         // 単独倉庫6
            wkInventoryExtCndtnWork.WarehouseCd07 = W07.Text;                         // 単独倉庫7
            wkInventoryExtCndtnWork.WarehouseCd08 = W08.Text;                         // 単独倉庫8
            wkInventoryExtCndtnWork.WarehouseCd09 = W09.Text;                         // 単独倉庫9
            wkInventoryExtCndtnWork.WarehouseCd10 = W10.Text;                         // 単独倉庫10
            wkInventoryExtCndtnWork.StWarehouseShelfNo = StTana.Text;                      // 棚番開始
            wkInventoryExtCndtnWork.EdWarehouseShelfNo = EdTana.Text;                      // 棚番終了
            wkInventoryExtCndtnWork.StMakerCd = Convert.ToInt32(tb5.Text);        // メーカーコード開始
            wkInventoryExtCndtnWork.EdMakerCd = Convert.ToInt32(tb6.Text);        // メーカーコード終了
            wkInventoryExtCndtnWork.StBLGoodsCd = Convert.ToInt32(tb17.Text);       // BLコード開始
            wkInventoryExtCndtnWork.EdBLGoodsCd = Convert.ToInt32(tb18.Text);       // BLコード終了
            wkInventoryExtCndtnWork.StBLGroupCode = Convert.ToInt32(StGCD.Text);      // グループコード開始
            wkInventoryExtCndtnWork.EdBLGroupCode = Convert.ToInt32(EdGCD.Text);      // グループコード終了
            wkInventoryExtCndtnWork.StCustomerCd = Convert.ToInt32(StSCd.Text);      // 仕入先コード開始
            wkInventoryExtCndtnWork.EdCustomerCd = Convert.ToInt32(EdSCd.Text);      // 仕入先コード終了
            wkInventoryExtCndtnWork.StockPointWay = Convert.ToInt32(tb25.Text);       // 在庫評価方法
            wkInventoryExtCndtnWork.InventoryDate = Convert.ToDateTime("2008/09/17"); // 棚卸日
            #endregion

            object paraobj = wkInventoryExtCndtnWork;
            object retobj = null;

            string statusMSG = "";

            int status = IinventoryExtDB.SearchInventoryDate(out retobj, paraobj, 0,  out statusMSG);

            if (status != 0)
            {
                Text = "該当ﾃﾞｰﾀ無し  st=" + status + "  stﾒｯｾｰｼﾞ=" + statusMSG;

                dataGrid1.DataSource = retobj;
            }
            else
            {
                Text = "該当ﾃﾞｰﾀ有り  棚卸準備履歴ﾏｽﾀ=" + ((ArrayList)retobj).Count.ToString() + "件" + "  stﾒｯｾｰｼﾞ=" + statusMSG;

                dataGrid1.DataSource = retobj;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);

        }
    }
}

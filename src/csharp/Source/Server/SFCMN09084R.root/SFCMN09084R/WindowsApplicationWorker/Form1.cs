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
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox EraNameDispCd1;
		private System.Windows.Forms.TextBox EraNameDispCd2;
		private System.Windows.Forms.TextBox EraNameDispCd3;
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
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
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

        private AllDefSetWork _allDefSetWork = null;
//        private AllDefSetWork _prevAllDefSetWork = null;
        private IAllDefSetDB  IalldefsetDB = null;

		private static string[] _parameter;
        private TextBox SecMngDiv;
        private Label label10;
        private TextBox GoodsNoInpDiv;
        private Label label11;
        private TextBox JanCodeInpDiv;
        private Label label12;
        private TextBox cutomer;
        private TextBox CnsTaxAutoCorrDiv;
        private Label label14;
        private TextBox RemainCntMngDiv;
        private Label label15;
        private TextBox MemoMoveDiv;
        private Label label16;
        private TextBox RemCntAutoDspDiv;
        private Label label17;
        private TextBox TtlAmntDspRateDivCd;
        private Label label18;
        private Label label13;
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
            this.EraNameDispCd1 = new System.Windows.Forms.TextBox();
            this.EraNameDispCd2 = new System.Windows.Forms.TextBox();
            this.EraNameDispCd3 = new System.Windows.Forms.TextBox();
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
            this.SecMngDiv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GoodsNoInpDiv = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.JanCodeInpDiv = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cutomer = new System.Windows.Forms.TextBox();
            this.CnsTaxAutoCorrDiv = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.RemainCntMngDiv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.MemoMoveDiv = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.RemCntAutoDspDiv = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TtlAmntDspRateDivCd = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.textBox1.Text = "0113180842031000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(264, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "2";
            // 
            // EraNameDispCd1
            // 
            this.EraNameDispCd1.Location = new System.Drawing.Point(264, 104);
            this.EraNameDispCd1.Name = "EraNameDispCd1";
            this.EraNameDispCd1.Size = new System.Drawing.Size(248, 19);
            this.EraNameDispCd1.TabIndex = 3;
            this.EraNameDispCd1.Text = "0";
            // 
            // EraNameDispCd2
            // 
            this.EraNameDispCd2.Location = new System.Drawing.Point(264, 128);
            this.EraNameDispCd2.Name = "EraNameDispCd2";
            this.EraNameDispCd2.Size = new System.Drawing.Size(248, 19);
            this.EraNameDispCd2.TabIndex = 4;
            this.EraNameDispCd2.Text = "0";
            // 
            // EraNameDispCd3
            // 
            this.EraNameDispCd3.Location = new System.Drawing.Point(264, 152);
            this.EraNameDispCd3.Name = "EraNameDispCd3";
            this.EraNameDispCd3.Size = new System.Drawing.Size(248, 19);
            this.EraNameDispCd3.TabIndex = 5;
            this.EraNameDispCd3.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(104, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "拠点コード";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(104, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "元号表示区分１";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(104, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "元号表示区分２";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(104, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "元号表示区分３";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(16, 200);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(288, 19);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "0113180842031000";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(16, 272);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(304, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 392);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(560, 144);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(456, 368);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "SearchGrid";
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(472, 33);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "LogicalDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(104, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(264, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "1";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(72, 248);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 24);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Search時にSerializeする";
            // 
            // listBox2
            // 
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(336, 272);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(240, 88);
            this.listBox2.TabIndex = 25;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(360, 232);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "件数指定Search";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(496, 232);
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
            this.label6.Location = new System.Drawing.Point(472, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "NextData?";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(320, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "総件数：";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(472, 57);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(88, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(472, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Revival";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(328, 368);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "CstomSearchGrid";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(56, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 35;
            // 
            // SecMngDiv
            // 
            this.SecMngDiv.Location = new System.Drawing.Point(757, 77);
            this.SecMngDiv.Name = "SecMngDiv";
            this.SecMngDiv.Size = new System.Drawing.Size(60, 19);
            this.SecMngDiv.TabIndex = 36;
            this.SecMngDiv.Text = "0";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(611, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 23);
            this.label10.TabIndex = 37;
            this.label10.Text = "部署管理区分";
            // 
            // GoodsNoInpDiv
            // 
            this.GoodsNoInpDiv.Location = new System.Drawing.Point(757, 101);
            this.GoodsNoInpDiv.Name = "GoodsNoInpDiv";
            this.GoodsNoInpDiv.Size = new System.Drawing.Size(60, 19);
            this.GoodsNoInpDiv.TabIndex = 38;
            this.GoodsNoInpDiv.Text = "0";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(611, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 23);
            this.label11.TabIndex = 39;
            this.label11.Text = "商品番号入力区分";
            // 
            // JanCodeInpDiv
            // 
            this.JanCodeInpDiv.Location = new System.Drawing.Point(757, 124);
            this.JanCodeInpDiv.Name = "JanCodeInpDiv";
            this.JanCodeInpDiv.Size = new System.Drawing.Size(60, 19);
            this.JanCodeInpDiv.TabIndex = 40;
            this.JanCodeInpDiv.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(611, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 23);
            this.label12.TabIndex = 41;
            this.label12.Text = "ＪＡＮコード入力区分";
            // 
            // cutomer
            // 
            this.cutomer.Location = new System.Drawing.Point(757, 147);
            this.cutomer.Name = "cutomer";
            this.cutomer.Size = new System.Drawing.Size(60, 19);
            this.cutomer.TabIndex = 42;
            this.cutomer.Text = "0";
            // 
            // CnsTaxAutoCorrDiv
            // 
            this.CnsTaxAutoCorrDiv.Location = new System.Drawing.Point(757, 170);
            this.CnsTaxAutoCorrDiv.Name = "CnsTaxAutoCorrDiv";
            this.CnsTaxAutoCorrDiv.Size = new System.Drawing.Size(60, 19);
            this.CnsTaxAutoCorrDiv.TabIndex = 44;
            this.CnsTaxAutoCorrDiv.Text = "0";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(611, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(140, 23);
            this.label14.TabIndex = 45;
            this.label14.Text = "消費税自動補正区分";
            // 
            // RemainCntMngDiv
            // 
            this.RemainCntMngDiv.Location = new System.Drawing.Point(757, 193);
            this.RemainCntMngDiv.Name = "RemainCntMngDiv";
            this.RemainCntMngDiv.Size = new System.Drawing.Size(60, 19);
            this.RemainCntMngDiv.TabIndex = 46;
            this.RemainCntMngDiv.Text = "0";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(611, 196);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 23);
            this.label15.TabIndex = 47;
            this.label15.Text = "残数管理区分";
            // 
            // MemoMoveDiv
            // 
            this.MemoMoveDiv.Location = new System.Drawing.Point(757, 216);
            this.MemoMoveDiv.Name = "MemoMoveDiv";
            this.MemoMoveDiv.Size = new System.Drawing.Size(60, 19);
            this.MemoMoveDiv.TabIndex = 48;
            this.MemoMoveDiv.Text = "0";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(611, 219);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 23);
            this.label16.TabIndex = 49;
            this.label16.Text = "メモ複写区分";
            // 
            // RemCntAutoDspDiv
            // 
            this.RemCntAutoDspDiv.Location = new System.Drawing.Point(757, 239);
            this.RemCntAutoDspDiv.Name = "RemCntAutoDspDiv";
            this.RemCntAutoDspDiv.Size = new System.Drawing.Size(60, 19);
            this.RemCntAutoDspDiv.TabIndex = 50;
            this.RemCntAutoDspDiv.Text = "0";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(611, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(140, 23);
            this.label17.TabIndex = 51;
            this.label17.Text = "残数自動表示区分";
            // 
            // TtlAmntDspRateDivCd
            // 
            this.TtlAmntDspRateDivCd.Location = new System.Drawing.Point(757, 262);
            this.TtlAmntDspRateDivCd.Name = "TtlAmntDspRateDivCd";
            this.TtlAmntDspRateDivCd.Size = new System.Drawing.Size(60, 19);
            this.TtlAmntDspRateDivCd.TabIndex = 52;
            this.TtlAmntDspRateDivCd.Text = "0";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(611, 265);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(140, 23);
            this.label18.TabIndex = 53;
            this.label18.Text = "総額表示掛率適用区分";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(611, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 23);
            this.label13.TabIndex = 43;
            this.label13.Text = "得意先";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(963, 550);
            this.Controls.Add(this.TtlAmntDspRateDivCd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.RemCntAutoDspDiv);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.MemoMoveDiv);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.RemainCntMngDiv);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CnsTaxAutoCorrDiv);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cutomer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.JanCodeInpDiv);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.GoodsNoInpDiv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SecMngDiv);
            this.Controls.Add(this.label10);
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
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.EraNameDispCd3);
            this.Controls.Add(this.EraNameDispCd2);
            this.Controls.Add(this.EraNameDispCd1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
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
		
		private void button1_Click(object sender, System.EventArgs e)
		{
//			if (_allDefSetWork == null) _allDefSetWork = new AllDefSetWork();
			_allDefSetWork = new AllDefSetWork();
			_allDefSetWork.EnterpriseCode = textBox1.Text;
			_allDefSetWork.SectionCode = textBox2.Text;
            // ↓ 2007.08.16 980081 a
            _allDefSetWork.EraNameDispCd1 = int.Parse(EraNameDispCd1.Text);
            _allDefSetWork.EraNameDispCd2 = int.Parse(EraNameDispCd2.Text);
            _allDefSetWork.EraNameDispCd3 = int.Parse(EraNameDispCd3.Text);
            // ↑ 2007.08.16 980081 a
            //_allDefSetWork.SecMngDiv = int.Parse(SecMngDiv.Text);
            _allDefSetWork.GoodsNoInpDiv = int.Parse(GoodsNoInpDiv.Text);
            _allDefSetWork.CnsTaxAutoCorrDiv = int.Parse(CnsTaxAutoCorrDiv.Text);
            _allDefSetWork.RemainCntMngDiv = int.Parse(RemainCntMngDiv.Text);
            _allDefSetWork.MemoMoveDiv = int.Parse(MemoMoveDiv.Text);
            _allDefSetWork.RemCntAutoDspDiv = int.Parse(RemCntAutoDspDiv.Text);
            _allDefSetWork.TtlAmntDspRateDivCd = int.Parse(TtlAmntDspRateDivCd.Text);


			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_allDefSetWork);			

			int status = IalldefsetDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

				Text = "該当データ有り";
//				textBox1.Text = _allDefSetWork.EnterpriseCode.ToString();
//				textBox2.Text = _allDefSetWork.SectionCode.ToString();
                // ↓ 2007.08.16 980081 a
                EraNameDispCd1.Text = _allDefSetWork.EraNameDispCd1.ToString();
                EraNameDispCd2.Text = _allDefSetWork.EraNameDispCd2.ToString();
                EraNameDispCd3.Text = _allDefSetWork.EraNameDispCd3.ToString();
                // ↑ 2007.08.16 980081 a
                //SecMngDiv.Text = _allDefSetWork.SecMngDiv.ToString();
                GoodsNoInpDiv.Text = _allDefSetWork.GoodsNoInpDiv.ToString();
                CnsTaxAutoCorrDiv.Text = _allDefSetWork.CnsTaxAutoCorrDiv.ToString();
                RemainCntMngDiv.Text = _allDefSetWork.RemainCntMngDiv.ToString();
                MemoMoveDiv.Text = _allDefSetWork.MemoMoveDiv.ToString();
                RemCntAutoDspDiv.Text = _allDefSetWork.RemCntAutoDspDiv.ToString();
                TtlAmntDspRateDivCd.Text = _allDefSetWork.TtlAmntDspRateDivCd.ToString();

//				textBox7.Text = _allDefSetWork.LogicalDeleteCode.ToString();
			}		
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);		
			IalldefsetDB = MediationAllDefSetDB.GetAllDefSetDB();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
//			AllDefSetWork allDefSetInsWork = new AllDefSetWork();
//			allDefSetInsWork.EnterpriseCode = textBox1.Text;
//
//			ArrayList al = new ArrayList();
//
//			// XMLへ変換し、文字列のバイナリ化
//			byte[] parabyte = XmlByteSerializer.Serialize(allDefSetInsWork);		
//			byte[] retbyte;
//
//			int status = IalldefsetDB.Search(out retbyte, parabyte, 0, 0);
//			listBox1.Items.Clear();
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				AllDefSetWork[] ew = (AllDefSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(AllDefSetWork[]));
//
//				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
//				
//				for(int i = 0;i<ew.Length;i++)
//				{
//					allDefSetInsWork = (AllDefSetWork)ew[i];
//					listBox1.Items.Add(allDefSetInsWork.ToString());
//					listBox1.Update();
//				}
//				if (checkBox1.Checked) XmlByteSerializer.Serialize(ew,"c:\\testList.xml");	
//			}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
//			DateTime start,end;
//			start = DateTime.Now;
//			
//			AllDefSetWork allDefSetWork = new AllDefSetWork();
//			allDefSetWork.EnterpriseCode = textBox1.Text;
//
//			ArrayList al = new ArrayList();
//
//			// XMLへ変換し、文字列のバイナリ化
//			byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);			
//			byte[] retbyte;
//
//			int status = IalldefsetDB.Search(out retbyte, parabyte, 0, 0);
//			listBox1.Items.Clear();
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				AllDefSetWork[] ew = (AllDefSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(AllDefSetWork[]));
//
//				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
//				
//				dataGrid1.DataSource = ew;
//			}		
//			end = DateTime.Now;
//			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if (_allDefSetWork == null) _allDefSetWork = new AllDefSetWork();

			_allDefSetWork.EnterpriseCode       = textBox1.Text;
			_allDefSetWork.SectionCode          = textBox2.Text;
            // ↓ 2007.08.16 980081 a
            _allDefSetWork.EraNameDispCd1 = int.Parse(EraNameDispCd1.Text);
            _allDefSetWork.EraNameDispCd2 = int.Parse(EraNameDispCd2.Text);
            _allDefSetWork.EraNameDispCd3 = int.Parse(EraNameDispCd3.Text);
            // ↑ 2007.08.16 980081 a
            //_allDefSetWork.SecMngDiv = int.Parse(SecMngDiv.Text);
            _allDefSetWork.GoodsNoInpDiv = int.Parse(GoodsNoInpDiv.Text);
            _allDefSetWork.CnsTaxAutoCorrDiv = int.Parse(CnsTaxAutoCorrDiv.Text);
            _allDefSetWork.RemainCntMngDiv = int.Parse(RemainCntMngDiv.Text);
            _allDefSetWork.MemoMoveDiv = int.Parse(MemoMoveDiv.Text);
            _allDefSetWork.RemCntAutoDspDiv = int.Parse(RemCntAutoDspDiv.Text);
            _allDefSetWork.TtlAmntDspRateDivCd = int.Parse(TtlAmntDspRateDivCd.Text);

			_allDefSetWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(_allDefSetWork);

			int status = IalldefsetDB.Write(ref parabyte);
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
				_allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

			}		

		}


		private void button6_Click(object sender, System.EventArgs e)
		{
			byte[] parabyte = XmlByteSerializer.Serialize(_allDefSetWork);
			int status = IalldefsetDB.LogicalDelete(ref parabyte);
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
				// XMLの読み込み
				_allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));
				textBox7.Text = _allDefSetWork.LogicalDeleteCode.ToString();

			}				
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			textBox2.Text = "";
			EraNameDispCd1.Text = "";
			EraNameDispCd2.Text = "";
			EraNameDispCd3.Text = "";	
			textBox7.Text = "";
			listBox1.Items.Clear();
//			_prevAllDefSetWork = null;
			listBox2.Items.Clear();
			button5.Enabled = true;
			label6.Text = "次データ？";
		}

		/// <summary>
		/// 件数指定リード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button5_Click(object sender, System.EventArgs e)
		{
//			listBox2.Items.Clear();
//
//			AllDefSetWork allDefSetWork = new AllDefSetWork();
//			byte[] parabyte;
//			if (_prevAllDefSetWork == null)
//			{
//				allDefSetWork.EnterpriseCode = textBox6.Text;
//				parabyte = XmlByteSerializer.Serialize(allDefSetWork);
//			}
//			else
//			{
//				parabyte = XmlByteSerializer.Serialize(_prevAllDefSetWork);	
//			}
//
//			byte[] retbyte;
//			int retTotalCnt;
//			bool nextData;
//
//			int status = IalldefsetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);
//
//			if (status != 0)
//			{
//				Text = "該当データ無し";
//			}
//			else
//			{
//				// XMLの読み込み
//				AllDefSetWork[] ew = (AllDefSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(AllDefSetWork[]));
//
//				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
//
//				//初回のみ件数取得
//				if (_prevAllDefSetWork == null) 
//				{
//					label7.Text = "総件数： "+retTotalCnt.ToString()+" 件";
//				}
//				
//				for(int i = 0;i<ew.Length;i++)
//				{
//					allDefSetWork = (AllDefSetWork)ew[i];
//					listBox2.Items.Add(allDefSetWork.ToString());
//					listBox2.Update();
//					if (i == ew.Length - 1) _prevAllDefSetWork = (AllDefSetWork)ew[i];
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

			byte[] parabyte = XmlByteSerializer.Serialize(_allDefSetWork);
			int status = IalldefsetDB.Delete(parabyte);
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
			byte[] parabyte = XmlByteSerializer.Serialize(_allDefSetWork);
			int status = IalldefsetDB.RevivalLogicalDelete(ref parabyte);
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
				// XMLの読み込み
				_allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));
				textBox7.Text = _allDefSetWork.LogicalDeleteCode.ToString();
			}				
		
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

			AllDefSetWork allDefSetWork = new AllDefSetWork();
			allDefSetWork.EnterpriseCode = textBox1.Text;
            // ↓ 2007.08.16 980081 a
            allDefSetWork.EraNameDispCd1 = int.Parse(EraNameDispCd1.Text);
            allDefSetWork.EraNameDispCd2 = int.Parse(EraNameDispCd2.Text);
            allDefSetWork.EraNameDispCd3 = int.Parse(EraNameDispCd3.Text);
            // ↑ 2007.08.16 980081 a
            //allDefSetWork.SecMngDiv = int.Parse(SecMngDiv.Text);
            allDefSetWork.GoodsNoInpDiv = int.Parse(GoodsNoInpDiv.Text);
            allDefSetWork.CnsTaxAutoCorrDiv = int.Parse(CnsTaxAutoCorrDiv.Text);
            allDefSetWork.RemainCntMngDiv = int.Parse(RemainCntMngDiv.Text);
            allDefSetWork.MemoMoveDiv = int.Parse(MemoMoveDiv.Text);
            allDefSetWork.RemCntAutoDspDiv = int.Parse(RemCntAutoDspDiv.Text);
            allDefSetWork.TtlAmntDspRateDivCd = int.Parse(TtlAmntDspRateDivCd.Text);

			object paraobj = allDefSetWork;
			object retobj = null;
			int status = IalldefsetDB.Search(out retobj, paraobj, 0, 0);
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

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}
	}
}

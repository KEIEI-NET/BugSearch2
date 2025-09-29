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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;

        //private StockConfShWork _salesOrderWork = null;

        //private StockConfShWork _prevStockConfShWork = null;
        private System.Windows.Forms.Button button8;

        private IStockConfDB IstockconfDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label5;
        private Label label6;
        private Label label4;
        private Label label7;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label18;
        private Label label19;
        private TextBox textBox22;
        private TextBox textBox23;
        private Label label20;
        private Label label21;
        private TextBox textBox24;
        private TextBox textBox25;
        private Label label23;
        private Label label24;
        private TextBox textBox26;
        private TextBox textBox27;
        private Label label25;
        private TextBox textBox28;
        private Label label26;
        private TextBox textBox29;
        private Label label3;
        private Label label8;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label9;
        private TextBox textBox7;
        private Button button1;
        private Label label13;
        private TextBox textBox16;
        private Label label11;
        private Label label12;
        private TextBox textBox14;
        private TextBox textBox15;
        private Label label10;
        private TextBox textBox13;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 339);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 197);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(854, 183);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(16, 310);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(115, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "仕入確認(明細)";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(12, 224);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 80);
            this.dataGrid2.TabIndex = 39;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(150, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 19);
            this.textBox2.TabIndex = 40;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(150, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 19);
            this.textBox3.TabIndex = 41;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(150, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 19);
            this.textBox4.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "企業コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "拠点コード";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 119);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "全選択";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(216, 119);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 46;
            this.checkBox2.Text = "全拠点選択";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(311, 44);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(146, 19);
            this.textBox8.TabIndex = 52;
            this.textBox8.Text = "20010101";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(483, 44);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(146, 19);
            this.textBox9.TabIndex = 53;
            this.textBox9.Text = "20091231";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 55;
            this.label5.Text = "仕入日";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 60;
            this.label4.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "入荷日";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(311, 94);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(146, 19);
            this.textBox10.TabIndex = 58;
            this.textBox10.Text = "20010101";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(483, 97);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(146, 19);
            this.textBox11.TabIndex = 57;
            this.textBox11.Text = "20091231";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(370, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 85;
            this.label18.Text = "～";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(325, 158);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 12);
            this.label19.TabIndex = 84;
            this.label19.Text = "担当者コード";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(324, 183);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(41, 19);
            this.textBox22.TabIndex = 83;
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(393, 183);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(41, 19);
            this.textBox23.TabIndex = 82;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(514, 183);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 89;
            this.label20.Text = "～";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(469, 158);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 88;
            this.label21.Text = "伝票番号";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(468, 183);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(41, 19);
            this.textBox24.TabIndex = 87;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(537, 183);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(41, 19);
            this.textBox25.TabIndex = 86;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(759, 94);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 97;
            this.label23.Text = "～";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(658, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 12);
            this.label24.TabIndex = 96;
            this.label24.Text = "仕入先(得意先)コード";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(657, 94);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(89, 19);
            this.textBox26.TabIndex = 95;
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(800, 91);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(92, 19);
            this.textBox27.TabIndex = 94;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(243, 158);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 99;
            this.label25.Text = "赤伝区分";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(242, 183);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(41, 19);
            this.textBox28.TabIndex = 98;
            this.textBox28.Text = "-1";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(148, 158);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 12);
            this.label26.TabIndex = 101;
            this.label26.Text = "仕入伝票区分";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(147, 183);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(41, 19);
            this.textBox29.TabIndex = 100;
            this.textBox29.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 105;
            this.label3.Text = "～";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(602, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 104;
            this.label8.Text = "相手先伝票番号";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(601, 183);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(41, 19);
            this.textBox5.TabIndex = 103;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(670, 183);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(41, 19);
            this.textBox6.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(658, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 12);
            this.label9.TabIndex = 107;
            this.label9.Text = "発行タイプ";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(719, 40);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(41, 19);
            this.textBox7.TabIndex = 108;
            this.textBox7.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 109;
            this.button1.Text = "仕入確認(伝票)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(781, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 126;
            this.label13.Text = "出力指定";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(783, 183);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(41, 19);
            this.textBox16.TabIndex = 125;
            this.textBox16.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 124;
            this.label11.Text = "～";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 12);
            this.label12.TabIndex = 123;
            this.label12.Text = "販売エリア";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(16, 183);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(41, 19);
            this.textBox14.TabIndex = 122;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(85, 183);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(41, 19);
            this.textBox15.TabIndex = 121;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(722, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 120;
            this.label10.Text = "在取区分";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(724, 183);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(41, 19);
            this.textBox13.TabIndex = 119;
            this.textBox13.Text = "-1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox1);
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
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }


        /// <summary>
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.Text = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IstockconfDB = MediationStockConfDB.GetStockConfDB();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, System.EventArgs e)
        {
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;


            ArrayList al = new ArrayList();
            StockConfShWork work = new StockConfShWork();
            work.EnterpriseCode = textBox1.Text;

            // 拠点コード
            System.Collections.Generic.List<string> wrkSecCdList = new System.Collections.Generic.List<string>();

            if (textBox2.Text != "") wrkSecCdList.Add(textBox2.Text);
            if (textBox3.Text != "") wrkSecCdList.Add(textBox3.Text);
            if (textBox4.Text != "") wrkSecCdList.Add(textBox4.Text);

            string[] sectionCode = wrkSecCdList.ToArray();
            
            work.StockSectionCd = sectionCode;

            // 仕入日
            if (textBox8.Text != "") work.StockDateSt = Convert.ToInt32(textBox8.Text);
            if (textBox9.Text != "") work.StockDateEd = Convert.ToInt32(textBox9.Text);

            // 入荷日
            if (textBox10.Text != "") work.ArrivalGoodsDaySt = Convert.ToInt32(textBox10.Text);
            if (textBox11.Text != "") work.ArrivalGoodsDayEd = Convert.ToInt32(textBox11.Text);

            // 発行タイプ
            if (textBox7.Text != "") work.PrintType = Convert.ToInt32(textBox7.Text);

            // 仕入先(得意先)コード
            if (textBox26.Text != "") work.SupplierCdSt = Convert.ToInt32(textBox26.Text);
            if (textBox27.Text != "") work.SupplierCdEd = Convert.ToInt32(textBox27.Text);

            // 仕入伝票区分
            if (textBox29.Text != "") work.SupplierSlipCd = Convert.ToInt32(textBox29.Text);

            // 赤伝区分
            if (textBox28.Text != "") work.DebitNoteDiv = Convert.ToInt32(textBox28.Text);

            // 仕入担当者
            if (textBox22.Text != "") work.StockAgentCodeSt = textBox22.Text;
            if (textBox23.Text != "") work.StockAgentCodeEd = textBox23.Text;

            // 仕入伝票番号
            if (textBox24.Text != "") work.SupplierSlipNoSt = Convert.ToInt32(textBox24.Text);
            if (textBox25.Text != "") work.SupplierSlipNoEd = Convert.ToInt32(textBox25.Text);

            // 相手先伝番
            if (textBox5.Text != "") work.PartySaleSlipNumSt = textBox5.Text;
            if (textBox6.Text != "") work.PartySaleSlipNumEd = textBox6.Text;

            // 在取区分
            if (textBox13.Text != "") work.StockOrderDivCd = Convert.ToInt32(textBox13.Text);

            // 販売エリアコード（開始）
            if (textBox14.Text != "") work.SalesAreaCodeSt = Convert.ToInt32(textBox14.Text);

            // 販売エリアコード（終了）
            if (textBox15.Text != "") work.SalesAreaCodeEd = Convert.ToInt32(textBox15.Text);

            // 出力指定
            if (textBox16.Text != "") work.OutputDesignated = Convert.ToInt32(textBox16.Text);
                
            //work.IsSelectAllSection = checkBox1.Checked;
            //work.IsOutputAllSecRec = checkBox2.Checked;
            
            al.Add(work);
            dataGrid2.DataSource = al;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
            button9_Click(sender, e);

            object parabyte = dataGrid2.DataSource;
            object objsalesOrder;

            int status = IstockconfDB.Search(out objsalesOrder, parabyte);

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objsalesOrder).Count.ToString() + "件";

                dataGrid1.DataSource = objsalesOrder;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button9_Click(sender, e);

            object parabyte = dataGrid2.DataSource;
            object objsalesOrder;

            int status = IstockconfDB.SearchSlipTtl(out objsalesOrder, parabyte);

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)objsalesOrder).Count.ToString() + "件";

                dataGrid1.DataSource = objsalesOrder;
            }
        }



    }
}

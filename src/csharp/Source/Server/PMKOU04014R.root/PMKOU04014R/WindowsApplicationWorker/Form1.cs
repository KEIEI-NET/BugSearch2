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
		private System.Windows.Forms.TextBox tb08;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb01;
        #endregion

        private ISuppPrtPprWorkDB IsuppPrtPprWorkDB = null;
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
        private TextBox textBox9;
        private Label label7;
        private DataGrid dataGrid2;
        private Button button4;
        private Button button5;
        private TextBox textBox40;
        private Label label40;
        private TextBox textBox25;
        private Label label41;
        private TextBox MaxCnt;
        private Label label42;
        private TextBox textBox8;
        private TextBox textBox42;
        private Label label43;
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
		private static System.Windows.Forms.Form _form = null;


		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
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


		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
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
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.MaxCnt = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
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
            this.label6.Text = "�����_�R�[�h";
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
            this.label1.Text = "�d����R�[�h";
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
            this.label2.Text = "�x����R�[�h";
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
            this.label3.Text = "�d�����t";
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
            this.label4.Text = "���͓��t";
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
            this.label5.Text = "�`�[�敪";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(265, 124);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 19);
            this.textBox9.TabIndex = 262;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 261;
            this.label7.Text = "�`�[�ԍ�";
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 23);
            this.button4.TabIndex = 326;
            this.button4.Text = "�c���E���׌���";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(13, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 23);
            this.button5.TabIndex = 327;
            this.button5.Text = "�c���ꗗ����";
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
            this.label40.Text = "�c���ꗗ�\���̏���";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(808, 238);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(100, 19);
            this.textBox25.TabIndex = 329;
            this.textBox25.Text = "200801";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(706, 241);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(53, 12);
            this.label41.TabIndex = 328;
            this.label41.Text = "�Ώ۔N��";
            // 
            // MaxCnt
            // 
            this.MaxCnt.Location = new System.Drawing.Point(265, 4);
            this.MaxCnt.Name = "MaxCnt";
            this.MaxCnt.Size = new System.Drawing.Size(100, 19);
            this.MaxCnt.TabIndex = 333;
            this.MaxCnt.Text = "2001";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(163, 7);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(65, 12);
            this.label42.TabIndex = 332;
            this.label42.Text = "���������";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(369, 105);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 19);
            this.textBox8.TabIndex = 334;
            this.textBox8.Text = "0";
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
            this.label43.Text = "�������";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(265, 143);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 19);
            this.textBox10.TabIndex = 338;
            this.textBox10.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 12);
            this.label10.TabIndex = 337;
            this.label10.Text = "�d��SEQ/�x����";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(265, 162);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 19);
            this.textBox11.TabIndex = 340;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(163, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 339;
            this.label11.Text = "�S����";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(265, 181);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 19);
            this.textBox12.TabIndex = 342;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(163, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 341;
            this.label12.Text = "���s��";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(265, 200);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 19);
            this.textBox13.TabIndex = 344;
            this.textBox13.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(163, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 12);
            this.label13.TabIndex = 343;
            this.label13.Text = "UOE����";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(265, 219);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 19);
            this.textBox14.TabIndex = 346;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(163, 222);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 12);
            this.label14.TabIndex = 345;
            this.label14.Text = "���l�P";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(265, 238);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 19);
            this.textBox15.TabIndex = 348;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(163, 241);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 347;
            this.label15.Text = "���l�Q";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(265, 257);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 19);
            this.textBox16.TabIndex = 350;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(163, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 12);
            this.label16.TabIndex = 349;
            this.label16.Text = "UOE���}�[�N1";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(265, 276);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 19);
            this.textBox17.TabIndex = 352;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(163, 279);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 12);
            this.label17.TabIndex = 351;
            this.label17.Text = "UOE���}�[�N2";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(265, 294);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 19);
            this.textBox18.TabIndex = 354;
            this.textBox18.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(163, 297);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 12);
            this.label18.TabIndex = 353;
            this.label18.Text = "BL�O���[�v";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(590, 32);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 19);
            this.textBox19.TabIndex = 356;
            this.textBox19.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(488, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 12);
            this.label19.TabIndex = 355;
            this.label19.Text = "BL�R�[�h";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(590, 51);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(100, 19);
            this.textBox20.TabIndex = 358;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(488, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 357;
            this.label20.Text = "�i��";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(590, 70);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(100, 19);
            this.textBox21.TabIndex = 360;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(488, 73);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 359;
            this.label21.Text = "�i��";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(590, 89);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 19);
            this.textBox22.TabIndex = 362;
            this.textBox22.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(488, 92);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 12);
            this.label22.TabIndex = 361;
            this.label22.Text = "���[�J�[";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(590, 108);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(100, 19);
            this.textBox23.TabIndex = 364;
            this.textBox23.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(488, 111);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 12);
            this.label23.TabIndex = 363;
            this.label23.Text = "�݌Ɏ��敪";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(590, 127);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(100, 19);
            this.textBox24.TabIndex = 366;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(488, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 12);
            this.label24.TabIndex = 365;
            this.label24.Text = "�q�ɃR�[�h";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 653);
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
            this.Controls.Add(this.textBox42);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.MaxCnt);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.textBox40);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.textBox9);
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
				//�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
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
			//���b�Z�[�W���o���O�ɑS�ĊJ��
			ApplicationStartControl.EndApplication();
			//�]�ƈ����O�I�t�̃��b�Z�[�W��\��
			if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            IsuppPrtPprWorkDB = MediationSuppPrtPprWorkDB.GetSuppPrtPprWorkDB();
		}

        //Search
		private void button8_Click(object sender, System.EventArgs e)
		{
		}

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(tb50.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        //�c���E���׌���
        private void button4_Click(object sender, EventArgs e)
        {
            //
            DateTime start, end;
            start = DateTime.Now;

            SuppPrtPprWork suppPrtPprWork = new SuppPrtPprWork();

            #region �l�Z�b�g
            //��ƃR�[�h
            suppPrtPprWork.EnterpriseCode = tb01.Text;

            //���_�R�[�h
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                suppPrtPprWork.SectionCode = str;
            }

            suppPrtPprWork.SearchCnt = Int64.Parse(MaxCnt.Text);
            suppPrtPprWork.SupplierCd = Int32.Parse(textBox1.Text);
            suppPrtPprWork.PayeeCode = Int32.Parse(textBox2.Text);
            suppPrtPprWork.St_StockDate = DateTime.ParseExact(textBox3.Text, "yyyyMMdd", null);
            suppPrtPprWork.Ed_StockDate = DateTime.ParseExact(textBox4.Text, "yyyyMMdd", null);
            suppPrtPprWork.St_InputDay = DateTime.ParseExact(textBox5.Text, "yyyyMMdd", null);
            suppPrtPprWork.Ed_InputDay = DateTime.ParseExact(textBox6.Text, "yyyyMMdd", null);
            
            /*
            Int32[] iSupplierFormal = { 30 };
            Int32[] iSupplierSlipCd = { 0, 1, 2, 3, 4, 5, 6 };
            suppPrtPprWork.SupplierFormal = iSupplierFormal;
            suppPrtPprWork.SupplierSlipCd = iSupplierSlipCd;
            */
            suppPrtPprWork.SupplierFormal = null;
            suppPrtPprWork.SupplierSlipCd = null;

            suppPrtPprWork.PartySaleSlipNum = textBox9.Text;
            suppPrtPprWork.PaymentSlipNo = Int32.Parse(textBox10.Text);
            suppPrtPprWork.StockAgentCode = textBox11.Text;
            // suppPrtPprWork.StockInputCode = textBox12.Text; // DEL 2009/09/08
            suppPrtPprWork.WayToOrder = Int32.Parse(textBox13.Text);
            suppPrtPprWork.SupplierSlipNote1 = textBox14.Text;
            suppPrtPprWork.SupplierSlipNote2 = textBox15.Text;
            suppPrtPprWork.UoeRemark1 = textBox16.Text;
            suppPrtPprWork.UoeRemark2 = textBox17.Text;
            suppPrtPprWork.BLGroupCode = Int32.Parse(textBox18.Text);
            suppPrtPprWork.BLGoodsCode = Int32.Parse(textBox19.Text);
            suppPrtPprWork.GoodsName = textBox20.Text;
            suppPrtPprWork.GoodsNo = textBox21.Text;
            suppPrtPprWork.GoodsMakerCd = Int32.Parse(textBox22.Text);
            suppPrtPprWork.StockOrderDivCd = Int32.Parse(textBox23.Text);
            suppPrtPprWork.WarehouseCode = textBox24.Text;
            #endregion

            object paraobj = suppPrtPprWork;       //�����p�����[�^
           
            object retobj1 = null;

            object retobj2 = null;


            int status = 0;
            Int64 iDataCnt = 0;

            try
            {
                status = IsuppPrtPprWorkDB.SearchRef(ref retobj1, ref retobj2, paraobj, out iDataCnt, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "�Y���f�[�^����  status=" + status + " iDataCnt=" + iDataCnt;
            }
            else
            {
                Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)retobj2).Count.ToString() + "��";

                dataGrid1.DataSource = retobj1;
                dataGrid2.DataSource = retobj2;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);
        }

        //�c���ꗗ����
        private void button5_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            SuppPrtPprBlnceWork suppPrtPprBlnceWork = new SuppPrtPprBlnceWork();

            #region �l�Z�b�g
            //��ƃR�[�h
            suppPrtPprBlnceWork.EnterpriseCode = tb01.Text;

            //���_�R�[�h
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                suppPrtPprBlnceWork.SectionCode = str;
            }
            suppPrtPprBlnceWork.SupplierCd = Int32.Parse(textBox1.Text);
            suppPrtPprBlnceWork.PayeeCode = Int32.Parse(textBox2.Text);
            suppPrtPprBlnceWork.St_AddUpYearMonth = DateTime.ParseExact(textBox25.Text, "yyyyMM", null);
            suppPrtPprBlnceWork.Ed_AddUpYearMonth = DateTime.ParseExact(textBox40.Text, "yyyyMM", null);

            #endregion

            object paraobj = suppPrtPprBlnceWork;       //�����p�����[�^

            object retobj1 = null;

            int status = 0;
            int iDiv = Int32.Parse(textBox42.Text);
            try
            {
                status = IsuppPrtPprWorkDB.SearchBlTbl(ref retobj1, paraobj, iDiv, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "�Y���f�[�^����  status=" + status;
            }
            else
            {
                Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)retobj1).Count.ToString() + "��";

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

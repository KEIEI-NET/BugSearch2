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
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		//private SalesTransitDtParaWork _salesTransitDtWork = null;

		//private SalesTransitDtParaWork _prevSalesTransitDtParaWork = null;
        private System.Windows.Forms.Button button8;

        private IShipGoodsAnalyzeDB IshipGoodsAnalyzeDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label4;
        private TextBox textBox6;
        private Label label5;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label6;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label7;
        private TextBox textBox11;
        private TextBox textBox12;
        private Label label8;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label9;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label10;
        private TextBox textBox17;
        private TextBox textBox18;
        private Label label11;
        private TextBox textBox19;
        private ComboBox comboBox1;
        private Label label12;
        private ComboBox comboBox2;
        private Label label13;
        private ComboBox comboBox3;
        private Label label14;
		private static System.Windows.Forms.Form _form = null;

		public Form1()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

            //集計方法 0:全社 1:拠点毎
            comboBox1.Items.Add("0:全社");
            comboBox1.Items.Add("1:拠点毎");
            comboBox1.SelectedIndex = 0;

            //在庫登録日検索区分 0:以前 1:以後
            comboBox2.Items.Add("0:以前");
            comboBox2.Items.Add("1:以後");
            comboBox2.SelectedIndex = 0;

            //在庫取寄せ区分 0:合計 1:在庫, 2:取寄
            comboBox3.Items.Add("0:合計");
            comboBox3.Items.Add("1:在庫");
            comboBox3.Items.Add("2:取寄");
            comboBox3.SelectedIndex = 0;

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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 337);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 277);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(787, 308);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 308);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(107, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "出荷商品分析表";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 222);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 80);
            this.dataGrid2.TabIndex = 39;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 308);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "企業コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 19);
            this.textBox1.TabIndex = 71;
            this.textBox1.Text = "0101150842020000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 19);
            this.textBox2.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 72;
            this.label2.Text = "拠点コード";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 44);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(115, 19);
            this.textBox3.TabIndex = 75;
            this.textBox3.Text = "200801";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "対象年月";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(229, 44);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(115, 19);
            this.textBox4.TabIndex = 77;
            this.textBox4.Text = "200808";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(108, 63);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(115, 19);
            this.textBox5.TabIndex = 79;
            this.textBox5.Text = "20080831";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 78;
            this.label4.Text = "在庫登録日";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(108, 82);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(115, 19);
            this.textBox6.TabIndex = 81;
            this.textBox6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "仕入先コード";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(229, 82);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(115, 19);
            this.textBox7.TabIndex = 82;
            this.textBox7.Text = "999999999";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(108, 101);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(115, 19);
            this.textBox8.TabIndex = 84;
            this.textBox8.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 12);
            this.label6.TabIndex = 83;
            this.label6.Text = "商品メーカーコード";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(229, 101);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(115, 19);
            this.textBox9.TabIndex = 85;
            this.textBox9.Text = "999999";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(108, 120);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(115, 19);
            this.textBox10.TabIndex = 87;
            this.textBox10.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 12);
            this.label7.TabIndex = 86;
            this.label7.Text = "商品大分類コード";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(229, 120);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(115, 19);
            this.textBox11.TabIndex = 88;
            this.textBox11.Text = "9999";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(108, 139);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(115, 19);
            this.textBox12.TabIndex = 90;
            this.textBox12.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 12);
            this.label8.TabIndex = 89;
            this.label8.Text = "商品中分類コード";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(229, 139);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(115, 19);
            this.textBox13.TabIndex = 91;
            this.textBox13.Text = "9999";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(108, 158);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(115, 19);
            this.textBox14.TabIndex = 93;
            this.textBox14.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 12);
            this.label9.TabIndex = 92;
            this.label9.Text = "BLグループコード";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(229, 158);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(115, 19);
            this.textBox15.TabIndex = 94;
            this.textBox15.Text = "99999";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(108, 177);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(115, 19);
            this.textBox16.TabIndex = 96;
            this.textBox16.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 12);
            this.label10.TabIndex = 95;
            this.label10.Text = "BL商品コード";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(229, 177);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(115, 19);
            this.textBox17.TabIndex = 97;
            this.textBox17.Text = "99999999";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(108, 196);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(115, 19);
            this.textBox18.TabIndex = 99;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 98;
            this.label11.Text = "商品番号";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(229, 196);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(115, 19);
            this.textBox19.TabIndex = 100;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(479, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 102;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(363, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 101;
            this.label12.Text = "集計方法";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(479, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 104;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(363, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 12);
            this.label13.TabIndex = 103;
            this.label13.Text = "在庫登録日検索区分";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(479, 46);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 106;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(363, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 12);
            this.label14.TabIndex = 105;
            this.label14.Text = "在庫取寄せ区分";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button11);
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
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            IshipGoodsAnalyzeDB = MediationShipGoodsAnalyzeDB.GetShipGoodsAnalyzeDB();
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
            ExtrInfo_ShipGoodsAnalyzeWork extrInfo_ShipGoodsAnalyzeWork = new ExtrInfo_ShipGoodsAnalyzeWork();

            extrInfo_ShipGoodsAnalyzeWork.EnterpriseCode = textBox1.Text;
            
            string[] SectionCodes = new string[3];
            if (textBox2.Text != "")
            {
                SectionCodes[0] = textBox2.Text;
            }
            else
            {
                SectionCodes = null;
            }
            extrInfo_ShipGoodsAnalyzeWork.SectionCodes = SectionCodes;


            extrInfo_ShipGoodsAnalyzeWork.TtlType = comboBox1.SelectedIndex;
            extrInfo_ShipGoodsAnalyzeWork.BeforeAfter = comboBox2.SelectedIndex;
            extrInfo_ShipGoodsAnalyzeWork.RsltTtlDivCd = comboBox3.SelectedIndex;

            extrInfo_ShipGoodsAnalyzeWork.St_AddUpYearMonth = DateTime.ParseExact(textBox3.Text, "yyyyMM", null);
            extrInfo_ShipGoodsAnalyzeWork.Ed_AddUpYearMonth = DateTime.ParseExact(textBox4.Text, "yyyyMM", null);
            extrInfo_ShipGoodsAnalyzeWork.Ex_StockCreateDate = DateTime.ParseExact(textBox5.Text, "yyyyMMdd", null);

            extrInfo_ShipGoodsAnalyzeWork.SupplierCdSt = Int32.Parse(textBox6.Text);
            extrInfo_ShipGoodsAnalyzeWork.SupplierCdEd = Int32.Parse(textBox7.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdSt = Int32.Parse(textBox8.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsMakerCdEd = Int32.Parse(textBox9.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupSt = Int32.Parse(textBox10.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsLGroupEd = Int32.Parse(textBox11.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupSt = Int32.Parse(textBox12.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsMGroupEd = Int32.Parse(textBox13.Text);
            extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeSt = Int32.Parse(textBox14.Text);
            extrInfo_ShipGoodsAnalyzeWork.BLGroupCodeEd = Int32.Parse(textBox15.Text);
            extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeSt = Int32.Parse(textBox16.Text);
            extrInfo_ShipGoodsAnalyzeWork.BLGoodsCodeEd = Int32.Parse(textBox17.Text);
            extrInfo_ShipGoodsAnalyzeWork.GoodsNoSt = textBox18.Text;
            extrInfo_ShipGoodsAnalyzeWork.GoodsNoEd = textBox19.Text;


            al.Add(extrInfo_ShipGoodsAnalyzeWork);
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

			object paraObj = dataGrid2.DataSource;
			object retObj = null;
            //ExtrInfo_ShipGoodsAnalyzeWork work = new ExtrInfo_ShipGoodsAnalyzeWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            try
            {
                int status = IshipGoodsAnalyzeDB.SearchShipGoodsAnalyze(out retObj, workObj, 0);
                if (status != 0)
                {
                    Text = "該当データ無し:status = " + status.ToString();
                }
                else
                {

                    Text = "該当データ有り";

                    dataGrid1.DataSource = retObj;
                }
            }
            catch (Exception ex)
            {
                Text = "例外発生 = " + ex.Message;

            }

		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
            ExtrInfo_ShipGoodsAnalyzeWork extrInfo_DemandTotalWork = new ExtrInfo_ShipGoodsAnalyzeWork();
			extrInfo_DemandTotalWork.EnterpriseCode = textBox1.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(extrInfo_DemandTotalWork);
			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
		}

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Ed_SalesAreaCode_TextChanged(object sender, EventArgs e)
        {

        }


	}
}

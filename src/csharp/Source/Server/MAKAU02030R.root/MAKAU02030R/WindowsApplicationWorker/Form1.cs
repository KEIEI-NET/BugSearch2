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
		private System.Windows.Forms.TextBox EnterpriseCode;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		//private SalesTransitDtParaWork _salesTransitDtWork = null;

		//private SalesTransitDtParaWork _prevSalesTransitDtParaWork = null;
        private System.Windows.Forms.Button button8;

        private IBillTableDB IbillTableDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label1;
        private Label label2;
        private Button button11;
        private TextBox Section1;
        private TextBox Section2;
        private TextBox Section3;
        private Label label3;
        private TextBox AddUpDate;
        private Label label4;
        private TextBox CustomerCodeSt;
        private TextBox CustomerCodeEd;
        private Label label5;
        private Label label6;
        private TextBox KanaSt;
        private TextBox KanaEd;
        private Label label7;
        private CheckBox IsSelectAllSection;
        private CheckBox IsOutputAllSecRec;
        private Label label9;
        private Label label10;
        private TextBox BillCollecterCdSt;
        private TextBox BillCollecterCdEd;
        private Label label11;
        private TextBox CustomerAgentCdSt;
        private TextBox CustomerAgentCdEd;
        private Label label12;
        private CheckBox IsBillOutputOnly;
        private TextBox DmdItems;
        private Label label25;
        private CheckBox IsLastDay;
        private TextBox TotalDay;
        private Label label8;
        private TextBox textBox1;
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
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.Section1 = new System.Windows.Forms.TextBox();
            this.Section2 = new System.Windows.Forms.TextBox();
            this.Section3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddUpDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomerCodeSt = new System.Windows.Forms.TextBox();
            this.CustomerCodeEd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.KanaSt = new System.Windows.Forms.TextBox();
            this.KanaEd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IsSelectAllSection = new System.Windows.Forms.CheckBox();
            this.IsOutputAllSecRec = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BillCollecterCdSt = new System.Windows.Forms.TextBox();
            this.BillCollecterCdEd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CustomerAgentCdSt = new System.Windows.Forms.TextBox();
            this.CustomerAgentCdEd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.IsBillOutputOnly = new System.Windows.Forms.CheckBox();
            this.DmdItems = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.IsLastDay = new System.Windows.Forms.CheckBox();
            this.TotalDay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(93, 19);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 1;
            this.EnterpriseCode.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 370);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 244);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(787, 341);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 341);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(107, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "請求一覧表";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 243);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 89);
            this.dataGrid2.TabIndex = 39;
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
            this.label2.Location = new System.Drawing.Point(15, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "拠点コード";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 341);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Section1
            // 
            this.Section1.Location = new System.Drawing.Point(94, 78);
            this.Section1.Name = "Section1";
            this.Section1.Size = new System.Drawing.Size(114, 19);
            this.Section1.TabIndex = 59;
            this.Section1.Text = "99";
            // 
            // Section2
            // 
            this.Section2.Location = new System.Drawing.Point(214, 78);
            this.Section2.Name = "Section2";
            this.Section2.Size = new System.Drawing.Size(114, 19);
            this.Section2.TabIndex = 60;
            // 
            // Section3
            // 
            this.Section3.Location = new System.Drawing.Point(334, 78);
            this.Section3.Name = "Section3";
            this.Section3.Size = new System.Drawing.Size(114, 19);
            this.Section3.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "計上年月日";
            // 
            // AddUpDate
            // 
            this.AddUpDate.Location = new System.Drawing.Point(93, 44);
            this.AddUpDate.Name = "AddUpDate";
            this.AddUpDate.Size = new System.Drawing.Size(115, 19);
            this.AddUpDate.TabIndex = 63;
            this.AddUpDate.Text = "20081020";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 64;
            this.label4.Text = "得意先コード";
            // 
            // CustomerCodeSt
            // 
            this.CustomerCodeSt.Location = new System.Drawing.Point(94, 104);
            this.CustomerCodeSt.Name = "CustomerCodeSt";
            this.CustomerCodeSt.Size = new System.Drawing.Size(100, 19);
            this.CustomerCodeSt.TabIndex = 63;
            // 
            // CustomerCodeEd
            // 
            this.CustomerCodeEd.Location = new System.Drawing.Point(223, 104);
            this.CustomerCodeEd.Name = "CustomerCodeEd";
            this.CustomerCodeEd.Size = new System.Drawing.Size(100, 19);
            this.CustomerCodeEd.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "～";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 12);
            this.label6.TabIndex = 64;
            this.label6.Text = "得意先カナ";
            // 
            // KanaSt
            // 
            this.KanaSt.Location = new System.Drawing.Point(93, 134);
            this.KanaSt.Name = "KanaSt";
            this.KanaSt.Size = new System.Drawing.Size(100, 19);
            this.KanaSt.TabIndex = 63;
            // 
            // KanaEd
            // 
            this.KanaEd.Location = new System.Drawing.Point(223, 134);
            this.KanaEd.Name = "KanaEd";
            this.KanaEd.Size = new System.Drawing.Size(100, 19);
            this.KanaEd.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 64;
            this.label7.Text = "～";
            // 
            // IsSelectAllSection
            // 
            this.IsSelectAllSection.AutoSize = true;
            this.IsSelectAllSection.Checked = true;
            this.IsSelectAllSection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsSelectAllSection.Location = new System.Drawing.Point(357, 159);
            this.IsSelectAllSection.Name = "IsSelectAllSection";
            this.IsSelectAllSection.Size = new System.Drawing.Size(241, 16);
            this.IsSelectAllSection.TabIndex = 65;
            this.IsSelectAllSection.Text = "全社選択(true:全社選択 false:各拠点選択)";
            this.IsSelectAllSection.UseVisualStyleBackColor = true;
            // 
            // IsOutputAllSecRec
            // 
            this.IsOutputAllSecRec.AutoSize = true;
            this.IsOutputAllSecRec.Checked = true;
            this.IsOutputAllSecRec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsOutputAllSecRec.Location = new System.Drawing.Point(357, 181);
            this.IsOutputAllSecRec.Name = "IsOutputAllSecRec";
            this.IsOutputAllSecRec.Size = new System.Drawing.Size(443, 16);
            this.IsOutputAllSecRec.TabIndex = 65;
            this.IsOutputAllSecRec.Text = "全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)";
            this.IsOutputAllSecRec.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 64;
            this.label9.Text = "集金担当";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 64;
            this.label10.Text = "顧客担当";
            // 
            // BillCollecterCdSt
            // 
            this.BillCollecterCdSt.Location = new System.Drawing.Point(93, 159);
            this.BillCollecterCdSt.Name = "BillCollecterCdSt";
            this.BillCollecterCdSt.Size = new System.Drawing.Size(51, 19);
            this.BillCollecterCdSt.TabIndex = 63;
            // 
            // BillCollecterCdEd
            // 
            this.BillCollecterCdEd.Location = new System.Drawing.Point(223, 159);
            this.BillCollecterCdEd.Name = "BillCollecterCdEd";
            this.BillCollecterCdEd.Size = new System.Drawing.Size(51, 19);
            this.BillCollecterCdEd.TabIndex = 63;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(200, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 64;
            this.label11.Text = "～";
            // 
            // CustomerAgentCdSt
            // 
            this.CustomerAgentCdSt.Location = new System.Drawing.Point(93, 184);
            this.CustomerAgentCdSt.Name = "CustomerAgentCdSt";
            this.CustomerAgentCdSt.Size = new System.Drawing.Size(51, 19);
            this.CustomerAgentCdSt.TabIndex = 63;
            // 
            // CustomerAgentCdEd
            // 
            this.CustomerAgentCdEd.Location = new System.Drawing.Point(223, 184);
            this.CustomerAgentCdEd.Name = "CustomerAgentCdEd";
            this.CustomerAgentCdEd.Size = new System.Drawing.Size(51, 19);
            this.CustomerAgentCdEd.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(200, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "～";
            // 
            // IsBillOutputOnly
            // 
            this.IsBillOutputOnly.AutoSize = true;
            this.IsBillOutputOnly.Checked = true;
            this.IsBillOutputOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsBillOutputOnly.Location = new System.Drawing.Point(357, 137);
            this.IsBillOutputOnly.Name = "IsBillOutputOnly";
            this.IsBillOutputOnly.Size = new System.Drawing.Size(151, 16);
            this.IsBillOutputOnly.TabIndex = 65;
            this.IsBillOutputOnly.Text = "「請求書発行する」得意先";
            this.IsBillOutputOnly.UseVisualStyleBackColor = true;
            // 
            // DmdItems
            // 
            this.DmdItems.Location = new System.Drawing.Point(93, 210);
            this.DmdItems.Name = "DmdItems";
            this.DmdItems.Size = new System.Drawing.Size(100, 19);
            this.DmdItems.TabIndex = 68;
            this.DmdItems.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(15, 213);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 67;
            this.label25.Text = "請求内訳";
            // 
            // IsLastDay
            // 
            this.IsLastDay.AutoSize = true;
            this.IsLastDay.Checked = true;
            this.IsLastDay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsLastDay.Location = new System.Drawing.Point(357, 115);
            this.IsLastDay.Name = "IsLastDay";
            this.IsLastDay.Size = new System.Drawing.Size(351, 16);
            this.IsLastDay.TabIndex = 69;
            this.IsLastDay.Text = "得意先締末尾指定プロパティ(true:28～31全て false:指定締日のみ)";
            this.IsLastDay.UseVisualStyleBackColor = true;
            // 
            // TotalDay
            // 
            this.TotalDay.Location = new System.Drawing.Point(256, 44);
            this.TotalDay.Name = "TotalDay";
            this.TotalDay.Size = new System.Drawing.Size(28, 19);
            this.TotalDay.TabIndex = 71;
            this.TotalDay.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 70;
            this.label8.Text = "締日";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(357, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 19);
            this.textBox1.TabIndex = 72;
            this.textBox1.Text = "50";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(391, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(307, 12);
            this.label13.TabIndex = 73;
            this.label13.Text = "50:合計請求書,60:明細請求書,70:伝票合計請求書,80:領収書";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TotalDay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.IsLastDay);
            this.Controls.Add(this.DmdItems);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.IsBillOutputOnly);
            this.Controls.Add(this.IsOutputAllSecRec);
            this.Controls.Add(this.IsSelectAllSection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CustomerCodeEd);
            this.Controls.Add(this.KanaEd);
            this.Controls.Add(this.KanaSt);
            this.Controls.Add(this.CustomerCodeSt);
            this.Controls.Add(this.CustomerAgentCdEd);
            this.Controls.Add(this.BillCollecterCdEd);
            this.Controls.Add(this.CustomerAgentCdSt);
            this.Controls.Add(this.BillCollecterCdSt);
            this.Controls.Add(this.AddUpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Section3);
            this.Controls.Add(this.Section2);
            this.Controls.Add(this.Section1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.EnterpriseCode);
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
            IbillTableDB = MediationBillTableDB.GetBillTableDB();
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
            
            
            int[] salesFormal = new int[3];
            //int[] salesFormal = new int[1];
            ArrayList al = new ArrayList();
            ExtrInfo_DemandTotalWork work = new ExtrInfo_DemandTotalWork();
            work.EnterpriseCode = EnterpriseCode.Text;
            //拠点コード
            string[] sectionCode = new string[3];
            sectionCode[0] = Section1.Text;
            sectionCode[1] = Section2.Text;
            sectionCode[2] = Section3.Text;
            work.ResultsAddUpSecList = sectionCode;
            work.SlipPrtKind = Convert.ToInt32(textBox1.Text);

            //請求書発行
            work.IsBillOutputOnly = IsBillOutputOnly.Checked;
            //work.IsSelectAllSection = IsSelectAllSection.Checked;
            //work.IsOutputAllSecRec = IsOutputAllSecRec.Checked;
            //work.IsLastDay = IsLastDay.Checked;

            //得意先コード
            if (CustomerCodeSt.Text != "") work.CustomerCodeSt = Convert.ToInt32(CustomerCodeSt.Text);
            if (CustomerCodeEd.Text != "") work.CustomerCodeEd = Convert.ToInt32(CustomerCodeEd.Text);
            ////得意先カナ
            //if (KanaSt.Text != "") work.KanaSt = KanaSt.Text;
            //if (KanaEd.Text != "") work.KanaEd = KanaEd.Text;
            //集金担当
            if (BillCollecterCdSt.Text != "") work.BillCollecterCdSt = BillCollecterCdSt.Text;
            if (BillCollecterCdEd.Text != "") work.BillCollecterCdEd = BillCollecterCdEd.Text;
            //顧客担当
            if (CustomerAgentCdSt.Text != "") work.CustomerAgentCdSt = CustomerAgentCdSt.Text;
            if (CustomerAgentCdEd.Text != "") work.CustomerAgentCdEd = CustomerAgentCdEd.Text;

            Int32 dateTemp;
            dateTemp = Convert.ToInt32("0" + AddUpDate.Text);
            work.AddUpDate = DateTime.Parse(Convert.ToString(dateTemp / 10000) + "/" + Convert.ToString(dateTemp % 10000 / 100) + "/" + Convert.ToString(dateTemp % 100));
            work.DmdItems = Convert.ToInt32(DmdItems.Text);
            //work.TotalDay = Convert.ToInt32(TotalDay.Text);

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

			object paraObj = dataGrid2.DataSource;
			object retObj;
            //ExtrInfo_DemandTotalWork work = new ExtrInfo_DemandTotalWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            int status = IbillTableDB.SearchBillTable(out retObj, workObj);

			if (status != 0)
			{
                Text = "該当データ無し:status = " + status.ToString();
			}
			else
			{

				Text = "該当データ有り  HIT "+((ArrayList)retObj).Count.ToString()+"件";
				
				dataGrid1.DataSource = retObj;
			}
		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
            ExtrInfo_DemandTotalWork extrInfo_DemandTotalWork = new ExtrInfo_DemandTotalWork();
			extrInfo_DemandTotalWork.EnterpriseCode = EnterpriseCode.Text;
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


	}
}

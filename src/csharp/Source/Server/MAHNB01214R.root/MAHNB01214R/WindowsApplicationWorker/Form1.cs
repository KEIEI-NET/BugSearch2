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

        private IClaimSalesReadDB IclaimSalesReadDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private Label label1;
        private TextBox EnterpriseCode;
        private Label label9;
        private TextBox ClaimCode;
        private Label label2;
        private TextBox DemandAddUpSecCd;
        private Label label3;
        private TextBox AcptAnOdrStatus;
        private Label label4;
        private TextBox SalesSlipNum;
        private Label label5;
        private TextBox CustomerCode;
        private Label label6;
        private TextBox AddUpADateStart;
        private TextBox AddUpADateEnd;
        private TextBox SearchSlipDateEnd;
        private Label label8;
        private TextBox SearchSlipDateStart;
        private Label label10;
        private TextBox ResultsAddUpSecCd;
        private Label label11;
        private TextBox AlwcSalesSlipCall;
        private Label label12;
        private TextBox ServiceSlipCd;
        private Label label13;
        private TextBox AccRecDivCd;
        private Label label14;
        private TextBox AutoDepositCd;
        private Label label15;
        private TextBox SalesEmployeeCd;
        private Button button1;
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ClaimCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DemandAddUpSecCd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AcptAnOdrStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SalesSlipNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CustomerCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AddUpADateStart = new System.Windows.Forms.TextBox();
            this.AddUpADateEnd = new System.Windows.Forms.TextBox();
            this.SearchSlipDateEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SearchSlipDateStart = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ResultsAddUpSecCd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AlwcSalesSlipCall = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ServiceSlipCd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AccRecDivCd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.AutoDepositCd = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SalesEmployeeCd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.button8.Text = "Search";
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
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(95, 6);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 69;
            this.EnterpriseCode.Text = "0113180842031000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 12);
            this.label9.TabIndex = 98;
            this.label9.Text = "請求先コード";
            // 
            // ClaimCode
            // 
            this.ClaimCode.Location = new System.Drawing.Point(95, 112);
            this.ClaimCode.Name = "ClaimCode";
            this.ClaimCode.Size = new System.Drawing.Size(115, 19);
            this.ClaimCode.TabIndex = 96;
            this.ClaimCode.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 100;
            this.label2.Text = "請求計上拠点";
            // 
            // DemandAddUpSecCd
            // 
            this.DemandAddUpSecCd.Location = new System.Drawing.Point(95, 141);
            this.DemandAddUpSecCd.Name = "DemandAddUpSecCd";
            this.DemandAddUpSecCd.Size = new System.Drawing.Size(115, 19);
            this.DemandAddUpSecCd.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 12);
            this.label3.TabIndex = 102;
            this.label3.Text = "受注ステータス";
            // 
            // AcptAnOdrStatus
            // 
            this.AcptAnOdrStatus.Location = new System.Drawing.Point(95, 32);
            this.AcptAnOdrStatus.Name = "AcptAnOdrStatus";
            this.AcptAnOdrStatus.Size = new System.Drawing.Size(115, 19);
            this.AcptAnOdrStatus.TabIndex = 101;
            this.AcptAnOdrStatus.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 104;
            this.label4.Text = "売上伝票番号";
            // 
            // SalesSlipNum
            // 
            this.SalesSlipNum.Location = new System.Drawing.Point(95, 58);
            this.SalesSlipNum.Name = "SalesSlipNum";
            this.SalesSlipNum.Size = new System.Drawing.Size(115, 19);
            this.SalesSlipNum.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 106;
            this.label5.Text = "得意先コード";
            // 
            // CustomerCode
            // 
            this.CustomerCode.Location = new System.Drawing.Point(95, 84);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(115, 19);
            this.CustomerCode.TabIndex = 105;
            this.CustomerCode.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 108;
            this.label6.Text = "計上日付";
            // 
            // AddUpADateStart
            // 
            this.AddUpADateStart.Location = new System.Drawing.Point(333, 6);
            this.AddUpADateStart.Name = "AddUpADateStart";
            this.AddUpADateStart.Size = new System.Drawing.Size(61, 19);
            this.AddUpADateStart.TabIndex = 107;
            this.AddUpADateStart.Text = "20070101";
            // 
            // AddUpADateEnd
            // 
            this.AddUpADateEnd.Location = new System.Drawing.Point(400, 6);
            this.AddUpADateEnd.Name = "AddUpADateEnd";
            this.AddUpADateEnd.Size = new System.Drawing.Size(61, 19);
            this.AddUpADateEnd.TabIndex = 109;
            this.AddUpADateEnd.Text = "20081231";
            // 
            // SearchSlipDateEnd
            // 
            this.SearchSlipDateEnd.Location = new System.Drawing.Point(400, 32);
            this.SearchSlipDateEnd.Name = "SearchSlipDateEnd";
            this.SearchSlipDateEnd.Size = new System.Drawing.Size(61, 19);
            this.SearchSlipDateEnd.TabIndex = 115;
            this.SearchSlipDateEnd.Text = "20081231";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 114;
            this.label8.Text = "更新日付";
            // 
            // SearchSlipDateStart
            // 
            this.SearchSlipDateStart.Location = new System.Drawing.Point(333, 32);
            this.SearchSlipDateStart.Name = "SearchSlipDateStart";
            this.SearchSlipDateStart.Size = new System.Drawing.Size(61, 19);
            this.SearchSlipDateStart.TabIndex = 113;
            this.SearchSlipDateStart.Text = "20070101";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 117;
            this.label10.Text = "実績計上拠点";
            // 
            // ResultsAddUpSecCd
            // 
            this.ResultsAddUpSecCd.Location = new System.Drawing.Point(95, 169);
            this.ResultsAddUpSecCd.Name = "ResultsAddUpSecCd";
            this.ResultsAddUpSecCd.Size = new System.Drawing.Size(115, 19);
            this.ResultsAddUpSecCd.TabIndex = 116;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(253, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 12);
            this.label11.TabIndex = 119;
            this.label11.Text = "引当済売上伝票呼出区分";
            // 
            // AlwcSalesSlipCall
            // 
            this.AlwcSalesSlipCall.Location = new System.Drawing.Point(400, 57);
            this.AlwcSalesSlipCall.Name = "AlwcSalesSlipCall";
            this.AlwcSalesSlipCall.Size = new System.Drawing.Size(61, 19);
            this.AlwcSalesSlipCall.TabIndex = 118;
            this.AlwcSalesSlipCall.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(253, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 12);
            this.label12.TabIndex = 121;
            this.label12.Text = "サービス伝票区分";
            // 
            // ServiceSlipCd
            // 
            this.ServiceSlipCd.Location = new System.Drawing.Point(400, 85);
            this.ServiceSlipCd.Name = "ServiceSlipCd";
            this.ServiceSlipCd.Size = new System.Drawing.Size(61, 19);
            this.ServiceSlipCd.TabIndex = 120;
            this.ServiceSlipCd.Text = "-1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 123;
            this.label13.Text = "売掛区分";
            // 
            // AccRecDivCd
            // 
            this.AccRecDivCd.Location = new System.Drawing.Point(400, 114);
            this.AccRecDivCd.Name = "AccRecDivCd";
            this.AccRecDivCd.Size = new System.Drawing.Size(61, 19);
            this.AccRecDivCd.TabIndex = 122;
            this.AccRecDivCd.Text = "-1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(253, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 125;
            this.label14.Text = "自動入金区分";
            // 
            // AutoDepositCd
            // 
            this.AutoDepositCd.Location = new System.Drawing.Point(400, 142);
            this.AutoDepositCd.Name = "AutoDepositCd";
            this.AutoDepositCd.Size = new System.Drawing.Size(61, 19);
            this.AutoDepositCd.TabIndex = 124;
            this.AutoDepositCd.Text = "-1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(253, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 127;
            this.label15.Text = "販売従業員";
            // 
            // SalesEmployeeCd
            // 
            this.SalesEmployeeCd.Location = new System.Drawing.Point(400, 168);
            this.SalesEmployeeCd.Name = "SalesEmployeeCd";
            this.SalesEmployeeCd.Size = new System.Drawing.Size(61, 19);
            this.SalesEmployeeCd.TabIndex = 126;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 128;
            this.button1.Text = "Search";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.SalesEmployeeCd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.AutoDepositCd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.AccRecDivCd);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ServiceSlipCd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AlwcSalesSlipCall);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ResultsAddUpSecCd);
            this.Controls.Add(this.SearchSlipDateEnd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SearchSlipDateStart);
            this.Controls.Add(this.AddUpADateEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddUpADateStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SalesSlipNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AcptAnOdrStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DemandAddUpSecCd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ClaimCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterpriseCode);
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
            IclaimSalesReadDB = MediationClaimSalesReadDB.GetClaimSalesReadDB();
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
            SearchClaimSalesWork searchClaimSalesWork = new SearchClaimSalesWork();
            SearchParaClaimSalesRead searchParaClaimSalesRead = new SearchParaClaimSalesRead();
            object parabyte = null;

            searchParaClaimSalesRead.EnterpriseCode = EnterpriseCode.Text;

            int[] acptAnOdrStatus = new int[1];
            acptAnOdrStatus[0] = Convert.ToInt32(AcptAnOdrStatus.Text);
            searchParaClaimSalesRead.AcptAnOdrStatus = acptAnOdrStatus;

            searchParaClaimSalesRead.SalesSlipNum = SalesSlipNum.Text;
            searchParaClaimSalesRead.CustomerCode = Convert.ToInt32(CustomerCode.Text);
            searchParaClaimSalesRead.ClaimCode = Convert.ToInt32(ClaimCode.Text);
            searchParaClaimSalesRead.DemandAddUpSecCd = DemandAddUpSecCd.Text;
            searchParaClaimSalesRead.ResultsAddUpSecCd = ResultsAddUpSecCd.Text;
            searchParaClaimSalesRead.AddUpADateStart = Convert.ToInt32(AddUpADateStart.Text);
            searchParaClaimSalesRead.AddUpADateEnd = Convert.ToInt32(AddUpADateEnd.Text);
            searchParaClaimSalesRead.SearchSlipDateStart = Convert.ToInt32(SearchSlipDateStart.Text);
            searchParaClaimSalesRead.SearchSlipDateEnd = Convert.ToInt32(SearchSlipDateEnd.Text);

            searchParaClaimSalesRead.AlwcSalesSlipCall = Convert.ToInt32(AlwcSalesSlipCall.Text);
            //searchParaClaimSalesRead.ServiceSlipCd = Convert.ToInt32(ServiceSlipCd.Text);
            searchParaClaimSalesRead.AccRecDivCd = Convert.ToInt32(AccRecDivCd.Text);
            searchParaClaimSalesRead.AutoDepositCd = Convert.ToInt32(AutoDepositCd.Text);
            searchParaClaimSalesRead.SalesEmployeeCd = SalesEmployeeCd.Text;

            try
            {
                int status = IclaimSalesReadDB.Search(out parabyte, searchParaClaimSalesRead, 0, 0);
                if (status != 0)
                {
                    Text = "該当データ無し:status = " + status.ToString();
                }
                else
                {
                    Text = "該当データ有り  HIT " + ((ArrayList)parabyte).Count.ToString() + "件";
                    dataGrid1.DataSource = parabyte;
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
            //ExtrInfo_OrderPursuitInquiryDtlWork extrInfo_DemandTotalWork = new ExtrInfo_OrderPursuitInquiryDtlWork();
			//extrInfo_DemandTotalWork.EnterpriseCode = EnterpriseCode.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			//al.Add(extrInfo_DemandTotalWork);
			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
		}

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button9_Click(sender, e);

            object paraObj = dataGrid2.DataSource;
            SearchClaimSalesWork searchClaimSalesWork = new SearchClaimSalesWork();
            SearchParaClaimSalesRead searchParaClaimSalesRead = new SearchParaClaimSalesRead();
            object parabyte = null;

            searchParaClaimSalesRead.EnterpriseCode = EnterpriseCode.Text;

            int[] acptAnOdrStatus = new int[1];
            acptAnOdrStatus[0] = Convert.ToInt32(AcptAnOdrStatus.Text);
            searchParaClaimSalesRead.AcptAnOdrStatus = acptAnOdrStatus;

            searchParaClaimSalesRead.SalesSlipNum = SalesSlipNum.Text;
            searchParaClaimSalesRead.CustomerCode = Convert.ToInt32(CustomerCode.Text);
            searchParaClaimSalesRead.ClaimCode = Convert.ToInt32(ClaimCode.Text);
            searchParaClaimSalesRead.DemandAddUpSecCd = DemandAddUpSecCd.Text;
            searchParaClaimSalesRead.ResultsAddUpSecCd = ResultsAddUpSecCd.Text;
            searchParaClaimSalesRead.AddUpADateStart = Convert.ToInt32(AddUpADateStart.Text);
            searchParaClaimSalesRead.AddUpADateEnd = Convert.ToInt32(AddUpADateEnd.Text);
            searchParaClaimSalesRead.SearchSlipDateStart = Convert.ToInt32(SearchSlipDateStart.Text);
            searchParaClaimSalesRead.SearchSlipDateEnd = Convert.ToInt32(SearchSlipDateEnd.Text);

            searchParaClaimSalesRead.AlwcSalesSlipCall = Convert.ToInt32(AlwcSalesSlipCall.Text);
            //searchParaClaimSalesRead.ServiceSlipCd = Convert.ToInt32(ServiceSlipCd.Text);
            searchParaClaimSalesRead.AccRecDivCd = Convert.ToInt32(AccRecDivCd.Text);
            searchParaClaimSalesRead.AutoDepositCd = Convert.ToInt32(AutoDepositCd.Text);
            searchParaClaimSalesRead.SalesEmployeeCd = SalesEmployeeCd.Text;

            try
            {
                int status = IclaimSalesReadDB.SearchCus(out parabyte, searchParaClaimSalesRead, 0, 0);
                if (status != 0)
                {
                    Text = "該当データ無し:status = " + status.ToString();
                }
                else
                {
                    Text = "該当データ有り  HIT " + ((ArrayList)parabyte).Count.ToString() + "件";
                    dataGrid1.DataSource = parabyte;
                }
            }
            catch (Exception ex)
            {
                Text = "例外発生 = " + ex.Message;

            }

        }

	}
}

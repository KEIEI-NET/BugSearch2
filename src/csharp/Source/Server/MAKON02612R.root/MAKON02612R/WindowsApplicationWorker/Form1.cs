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
		private System.Windows.Forms.DataGrid dataGridCustDmd;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;

		//private SalesTransitDtParaWork _salesTransitDtWork = null;

		//private SalesTransitDtParaWork _prevSalesTransitDtParaWork = null;
        private System.Windows.Forms.Button bReadProc;

        private ISuplAccInfGetDB IsuplAccInfGetDB = null;

		private static string[] _parameter;
        private DataGrid dataGridParam;
        private Label label1;
        private Label label2;
        private TextBox SectionCode1;
        private TextBox SectionCode2;
        private TextBox SectionCode3;
        private Label label3;
        private TextBox StartAddUpYearMonth;
        private Label label4;
        private TextBox CustomerCode;
        private Label label5;
        private TextBox EndAddUpYearMonth;
        private TextBox AddUpDate;
        private Label label6;
        private Button bSearchSlip;
        private Button bSearchDetail;
        private DataGrid dataGridLedgerSalesSlip;
        private DataGrid dataGridLedgerSalesDetail;
        private DataGrid dataGridLedgerDepsitMain;
        private Label label7;
        private TextBox StartCustomerCode;
        private TextBox EndCustomerCode;
        private Label label8;
        private Label label9;
        private TextBox OutMoneyDiv;
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
            this.dataGridCustDmd = new System.Windows.Forms.DataGrid();
            this.bReadProc = new System.Windows.Forms.Button();
            this.dataGridParam = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SectionCode1 = new System.Windows.Forms.TextBox();
            this.SectionCode2 = new System.Windows.Forms.TextBox();
            this.SectionCode3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartAddUpYearMonth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomerCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EndAddUpYearMonth = new System.Windows.Forms.TextBox();
            this.AddUpDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bSearchSlip = new System.Windows.Forms.Button();
            this.bSearchDetail = new System.Windows.Forms.Button();
            this.dataGridLedgerSalesSlip = new System.Windows.Forms.DataGrid();
            this.dataGridLedgerSalesDetail = new System.Windows.Forms.DataGrid();
            this.dataGridLedgerDepsitMain = new System.Windows.Forms.DataGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.StartCustomerCode = new System.Windows.Forms.TextBox();
            this.EndCustomerCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OutMoneyDiv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedgerSalesSlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedgerSalesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedgerDepsitMain)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(74, 6);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 1;
            this.EnterpriseCode.Text = "0113180842031000";
            // 
            // dataGridCustDmd
            // 
            this.dataGridCustDmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCustDmd.CaptionFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataGridCustDmd.CaptionText = "買掛情報";
            this.dataGridCustDmd.DataMember = "";
            this.dataGridCustDmd.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridCustDmd.Location = new System.Drawing.Point(16, 117);
            this.dataGridCustDmd.Name = "dataGridCustDmd";
            this.dataGridCustDmd.Size = new System.Drawing.Size(919, 119);
            this.dataGridCustDmd.TabIndex = 13;
            // 
            // bReadProc
            // 
            this.bReadProc.Location = new System.Drawing.Point(601, 30);
            this.bReadProc.Name = "bReadProc";
            this.bReadProc.Size = new System.Drawing.Size(107, 19);
            this.bReadProc.TabIndex = 33;
            this.bReadProc.Text = "Read";
            this.bReadProc.Click += new System.EventHandler(this.bReadProc_Click);
            // 
            // dataGridParam
            // 
            this.dataGridParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridParam.DataMember = "";
            this.dataGridParam.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridParam.Location = new System.Drawing.Point(16, 55);
            this.dataGridParam.Name = "dataGridParam";
            this.dataGridParam.Size = new System.Drawing.Size(918, 56);
            this.dataGridParam.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "企業コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "拠点コード";
            // 
            // SectionCode1
            // 
            this.SectionCode1.Location = new System.Drawing.Point(75, 30);
            this.SectionCode1.Name = "SectionCode1";
            this.SectionCode1.Size = new System.Drawing.Size(114, 19);
            this.SectionCode1.TabIndex = 59;
            this.SectionCode1.Text = "000010";
            // 
            // SectionCode2
            // 
            this.SectionCode2.Location = new System.Drawing.Point(195, 30);
            this.SectionCode2.Name = "SectionCode2";
            this.SectionCode2.Size = new System.Drawing.Size(114, 19);
            this.SectionCode2.TabIndex = 60;
            // 
            // SectionCode3
            // 
            this.SectionCode3.Location = new System.Drawing.Point(315, 30);
            this.SectionCode3.Name = "SectionCode3";
            this.SectionCode3.Size = new System.Drawing.Size(114, 19);
            this.SectionCode3.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "計上年月";
            // 
            // StartAddUpYearMonth
            // 
            this.StartAddUpYearMonth.Location = new System.Drawing.Point(658, 6);
            this.StartAddUpYearMonth.Name = "StartAddUpYearMonth";
            this.StartAddUpYearMonth.Size = new System.Drawing.Size(51, 19);
            this.StartAddUpYearMonth.TabIndex = 63;
            this.StartAddUpYearMonth.Text = "200802";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 64;
            this.label4.Text = "得意先コード";
            // 
            // CustomerCode
            // 
            this.CustomerCode.Location = new System.Drawing.Point(269, 6);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(60, 19);
            this.CustomerCode.TabIndex = 63;
            this.CustomerCode.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(715, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 65;
            this.label5.Text = "～";
            // 
            // EndAddUpYearMonth
            // 
            this.EndAddUpYearMonth.Location = new System.Drawing.Point(738, 6);
            this.EndAddUpYearMonth.Name = "EndAddUpYearMonth";
            this.EndAddUpYearMonth.Size = new System.Drawing.Size(51, 19);
            this.EndAddUpYearMonth.TabIndex = 66;
            this.EndAddUpYearMonth.Text = "200802";
            // 
            // AddUpDate
            // 
            this.AddUpDate.Location = new System.Drawing.Point(870, 6);
            this.AddUpDate.Name = "AddUpDate";
            this.AddUpDate.Size = new System.Drawing.Size(65, 19);
            this.AddUpDate.TabIndex = 67;
            this.AddUpDate.Text = "20071031";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(799, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "計上年月日";
            // 
            // bSearchSlip
            // 
            this.bSearchSlip.Location = new System.Drawing.Point(714, 30);
            this.bSearchSlip.Name = "bSearchSlip";
            this.bSearchSlip.Size = new System.Drawing.Size(107, 19);
            this.bSearchSlip.TabIndex = 69;
            this.bSearchSlip.Text = "SearchSlip";
            this.bSearchSlip.Click += new System.EventHandler(this.bSearchSlip_Click);
            // 
            // bSearchDetail
            // 
            this.bSearchDetail.Location = new System.Drawing.Point(827, 30);
            this.bSearchDetail.Name = "bSearchDetail";
            this.bSearchDetail.Size = new System.Drawing.Size(107, 19);
            this.bSearchDetail.TabIndex = 70;
            this.bSearchDetail.Text = "SearchDetail";
            this.bSearchDetail.Click += new System.EventHandler(this.bSearchDetail_Click);
            // 
            // dataGridLedgerSalesSlip
            // 
            this.dataGridLedgerSalesSlip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridLedgerSalesSlip.CaptionFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataGridLedgerSalesSlip.CaptionText = "仕入(ヘッダ)情報";
            this.dataGridLedgerSalesSlip.DataMember = "";
            this.dataGridLedgerSalesSlip.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridLedgerSalesSlip.Location = new System.Drawing.Point(16, 242);
            this.dataGridLedgerSalesSlip.Name = "dataGridLedgerSalesSlip";
            this.dataGridLedgerSalesSlip.Size = new System.Drawing.Size(919, 119);
            this.dataGridLedgerSalesSlip.TabIndex = 71;
            // 
            // dataGridLedgerSalesDetail
            // 
            this.dataGridLedgerSalesDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridLedgerSalesDetail.CaptionFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataGridLedgerSalesDetail.CaptionText = "仕入(明細)情報";
            this.dataGridLedgerSalesDetail.DataMember = "";
            this.dataGridLedgerSalesDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridLedgerSalesDetail.Location = new System.Drawing.Point(15, 367);
            this.dataGridLedgerSalesDetail.Name = "dataGridLedgerSalesDetail";
            this.dataGridLedgerSalesDetail.Size = new System.Drawing.Size(919, 119);
            this.dataGridLedgerSalesDetail.TabIndex = 72;
            // 
            // dataGridLedgerDepsitMain
            // 
            this.dataGridLedgerDepsitMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridLedgerDepsitMain.CaptionFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataGridLedgerDepsitMain.CaptionText = "支払伝票情報";
            this.dataGridLedgerDepsitMain.DataMember = "";
            this.dataGridLedgerDepsitMain.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridLedgerDepsitMain.Location = new System.Drawing.Point(15, 492);
            this.dataGridLedgerDepsitMain.Name = "dataGridLedgerDepsitMain";
            this.dataGridLedgerDepsitMain.Size = new System.Drawing.Size(919, 119);
            this.dataGridLedgerDepsitMain.TabIndex = 73;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 12);
            this.label7.TabIndex = 75;
            this.label7.Text = "得意先コード(範囲)";
            // 
            // StartCustomerCode
            // 
            this.StartCustomerCode.Location = new System.Drawing.Point(441, 6);
            this.StartCustomerCode.Name = "StartCustomerCode";
            this.StartCustomerCode.Size = new System.Drawing.Size(60, 19);
            this.StartCustomerCode.TabIndex = 74;
            this.StartCustomerCode.Text = "0";
            // 
            // EndCustomerCode
            // 
            this.EndCustomerCode.Location = new System.Drawing.Point(533, 6);
            this.EndCustomerCode.Name = "EndCustomerCode";
            this.EndCustomerCode.Size = new System.Drawing.Size(60, 19);
            this.EndCustomerCode.TabIndex = 76;
            this.EndCustomerCode.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 77;
            this.label8.Text = "～";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 79;
            this.label9.Text = "金額区分";
            // 
            // OutMoneyDiv
            // 
            this.OutMoneyDiv.Location = new System.Drawing.Point(494, 30);
            this.OutMoneyDiv.Name = "OutMoneyDiv";
            this.OutMoneyDiv.Size = new System.Drawing.Size(30, 19);
            this.OutMoneyDiv.TabIndex = 78;
            this.OutMoneyDiv.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(951, 633);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.OutMoneyDiv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EndCustomerCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StartCustomerCode);
            this.Controls.Add(this.dataGridLedgerDepsitMain);
            this.Controls.Add(this.dataGridLedgerSalesDetail);
            this.Controls.Add(this.dataGridLedgerSalesSlip);
            this.Controls.Add(this.bSearchDetail);
            this.Controls.Add(this.bSearchSlip);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AddUpDate);
            this.Controls.Add(this.EndAddUpYearMonth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.StartAddUpYearMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SectionCode3);
            this.Controls.Add(this.SectionCode2);
            this.Controls.Add(this.SectionCode1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridParam);
            this.Controls.Add(this.bReadProc);
            this.Controls.Add(this.EnterpriseCode);
            this.Controls.Add(this.dataGridCustDmd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedgerSalesSlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedgerSalesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLedgerDepsitMain)).EndInit();
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
            IsuplAccInfGetDB = MediationSuplAccInfGetDB.GetSuplAccInfGetDB();
		}

        private void bSearchSlip_Click(object sender, EventArgs e)
        {
            dataGridParam.DataSource = null;
            dataGridCustDmd.DataSource = null;
            dataGridLedgerSalesSlip.DataSource = null;
            dataGridLedgerSalesDetail.DataSource = null;
            dataGridLedgerDepsitMain.DataSource = null;

            ArrayList al = new ArrayList();
            SuplAccInfGetParameter work = new SuplAccInfGetParameter();
            
            work.EnterpriseCode = EnterpriseCode.Text;
            //拠点コード
            ArrayList sectionCode = new ArrayList();
            sectionCode.Add(SectionCode1.Text);
            //sectionCode.Add(SectionCode2.Text);
            //sectionCode.Add(SectionCode3.Text);
            work.AddUpSecCodeList = sectionCode;

            //得意先コード
            work.SupplierCd = Convert.ToInt32(CustomerCode.Text);
            work.StartSupplierCd = Convert.ToInt32(StartCustomerCode.Text);
            work.EndSupplierCd = Convert.ToInt32(EndCustomerCode.Text);

            //計上年月
            //work.StartAddUpYearMonth = Convert.ToInt32(StartAddUpYearMonth.Text);
            //work.EndAddUpYearMonth = Convert.ToInt32(EndAddUpYearMonth.Text);


            al.Add(work);
            dataGridParam.DataSource = al;

            //以下、リモート呼出処理
            object objCustDmdPrcInfGetWorkList = null;
            object objLedgerSalesSlipWorkList = null;
            object objLedgerDepsitMainWorkList = null;
            int status = 0;
            //status = IsuplAccInfGetDB.Search(out objCustDmdPrcInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, work);

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objCustDmdPrcInfGetWorkList).Count.ToString() + "件";

                dataGridCustDmd.DataSource = objCustDmdPrcInfGetWorkList;
                dataGridLedgerSalesSlip.DataSource = objLedgerSalesSlipWorkList;
                dataGridLedgerDepsitMain.DataSource = objLedgerDepsitMainWorkList;
            }

        }

        private void bSearchDetail_Click(object sender, EventArgs e)
        {
            dataGridParam.DataSource = null;
            dataGridCustDmd.DataSource = null;
            dataGridLedgerSalesSlip.DataSource = null;
            dataGridLedgerSalesDetail.DataSource = null;
            dataGridLedgerDepsitMain.DataSource = null;

            ArrayList al = new ArrayList();
            SuplAccInfGetParameter work = new SuplAccInfGetParameter();

            work.EnterpriseCode = EnterpriseCode.Text;
            //拠点コード
            ArrayList sectionCode = new ArrayList();
            sectionCode.Add(SectionCode1.Text);
            //sectionCode.Add(SectionCode2.Text);
            //sectionCode.Add(SectionCode3.Text);
            work.AddUpSecCodeList = sectionCode;

            //得意先コード
            work.SupplierCd = Convert.ToInt32(CustomerCode.Text);
            work.StartSupplierCd = Convert.ToInt32(StartCustomerCode.Text);
            work.EndSupplierCd = Convert.ToInt32(EndCustomerCode.Text);

            //計上年月
            //work.StartAddUpYearMonth = Convert.ToInt32(StartAddUpYearMonth.Text);
            //work.EndAddUpYearMonth = Convert.ToInt32(EndAddUpYearMonth.Text);

            al.Add(work);
            dataGridParam.DataSource = al;

            //以下、リモート呼出処理
            object objCustDmdPrcInfGetWorkList = null;
            object objLedgerSalesSlipWorkList = null;
            object objLedgerSalesDetailWorkList = null;
            object objLedgerDepsitMainWorkList = null;

            int status = 0;
            //status = IsuplAccInfGetDB.Search(out objCustDmdPrcInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerSalesDetailWorkList, out objLedgerDepsitMainWorkList, work);

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objCustDmdPrcInfGetWorkList).Count.ToString() + "件";

                dataGridCustDmd.DataSource = objCustDmdPrcInfGetWorkList;
                dataGridLedgerSalesSlip.DataSource = objLedgerSalesSlipWorkList;
                dataGridLedgerSalesDetail.DataSource = objLedgerSalesDetailWorkList;
                dataGridLedgerDepsitMain.DataSource = objLedgerDepsitMainWorkList;
            }

        }

        private void bReadProc_Click(object sender, EventArgs e)
        {/*
            dataGridParam.DataSource = null;
            dataGridCustDmd.DataSource = null;
            dataGridLedgerSalesSlip.DataSource = null;
            dataGridLedgerSalesDetail.DataSource = null;
            dataGridLedgerDepsitMain.DataSource = null;

            ArrayList al = new ArrayList();
            SuplAccInfReadParameter work = new SuplAccInfReadParameter();

            work.EnterpriseCode = EnterpriseCode.Text;
            //拠点コード
            work.AddUpSecCode = SectionCode1.Text;

            //得意先コード
            work.SupplierCd = Convert.ToInt32(CustomerCode.Text);

            //計上年月日
            work.AddUpDate = Convert.ToInt32(AddUpDate.Text);

            al.Add(work);
            dataGridParam.DataSource = al;

            //以下、リモート呼出処理
            object objCustDmdPrcInfGetWorkList = null;

            int status = IsuplAccInfGetDB.Read(out objCustDmdPrcInfGetWorkList, work);

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り";
                ArrayList al2 = new ArrayList();
                al2.Add(objCustDmdPrcInfGetWorkList);
                dataGridCustDmd.DataSource = al2;
            }
            */
        }


	}
}

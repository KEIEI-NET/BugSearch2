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

        private IPaymentBalanceLedgerDB IpaymentBalanceLedgerDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private TextBox outMoneyDiv;
        private Label label15;
        private Label label12;
        private Label label5;
        private Label label10;
        private Label label4;
        private TextBox ed_PayeeCode;
        private TextBox st_PayeeCode;
        private TextBox ed_AddUpYearMonth;
        private TextBox st_AddUpYearMonth;
        private TextBox paymentAddupSecCode2;
        private TextBox paymentAddupSecCode1;
        private TextBox paymentAddupSecCode0;
        private Label label2;
        private Label label1;
        private TextBox enterpriseCode;
        private Label label3;
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
            this.outMoneyDiv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ed_PayeeCode = new System.Windows.Forms.TextBox();
            this.st_PayeeCode = new System.Windows.Forms.TextBox();
            this.ed_AddUpYearMonth = new System.Windows.Forms.TextBox();
            this.st_AddUpYearMonth = new System.Windows.Forms.TextBox();
            this.paymentAddupSecCode2 = new System.Windows.Forms.TextBox();
            this.paymentAddupSecCode1 = new System.Windows.Forms.TextBox();
            this.paymentAddupSecCode0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.enterpriseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.button8.Text = "支払残高元帳";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 243);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 89);
            this.dataGrid2.TabIndex = 39;
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
            // outMoneyDiv
            // 
            this.outMoneyDiv.Location = new System.Drawing.Point(293, 31);
            this.outMoneyDiv.Name = "outMoneyDiv";
            this.outMoneyDiv.Size = new System.Drawing.Size(75, 19);
            this.outMoneyDiv.TabIndex = 84;
            this.outMoneyDiv.Text = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(217, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 83;
            this.label15.Text = "出力金額区分";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(350, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 80;
            this.label12.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 79;
            this.label5.Text = "～";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "対象年月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "支払先コード";
            // 
            // ed_PayeeCode
            // 
            this.ed_PayeeCode.Location = new System.Drawing.Point(422, 81);
            this.ed_PayeeCode.Name = "ed_PayeeCode";
            this.ed_PayeeCode.Size = new System.Drawing.Size(100, 19);
            this.ed_PayeeCode.TabIndex = 77;
            this.ed_PayeeCode.Text = "0";
            // 
            // st_PayeeCode
            // 
            this.st_PayeeCode.Location = new System.Drawing.Point(293, 81);
            this.st_PayeeCode.Name = "st_PayeeCode";
            this.st_PayeeCode.Size = new System.Drawing.Size(100, 19);
            this.st_PayeeCode.TabIndex = 78;
            this.st_PayeeCode.Text = "0";
            // 
            // ed_AddUpYearMonth
            // 
            this.ed_AddUpYearMonth.Location = new System.Drawing.Point(373, 130);
            this.ed_AddUpYearMonth.Name = "ed_AddUpYearMonth";
            this.ed_AddUpYearMonth.Size = new System.Drawing.Size(51, 19);
            this.ed_AddUpYearMonth.TabIndex = 75;
            // 
            // st_AddUpYearMonth
            // 
            this.st_AddUpYearMonth.Location = new System.Drawing.Point(293, 130);
            this.st_AddUpYearMonth.Name = "st_AddUpYearMonth";
            this.st_AddUpYearMonth.Size = new System.Drawing.Size(51, 19);
            this.st_AddUpYearMonth.TabIndex = 76;
            // 
            // paymentAddupSecCode2
            // 
            this.paymentAddupSecCode2.Location = new System.Drawing.Point(17, 142);
            this.paymentAddupSecCode2.Name = "paymentAddupSecCode2";
            this.paymentAddupSecCode2.Size = new System.Drawing.Size(114, 19);
            this.paymentAddupSecCode2.TabIndex = 74;
            // 
            // paymentAddupSecCode1
            // 
            this.paymentAddupSecCode1.Location = new System.Drawing.Point(17, 117);
            this.paymentAddupSecCode1.Name = "paymentAddupSecCode1";
            this.paymentAddupSecCode1.Size = new System.Drawing.Size(114, 19);
            this.paymentAddupSecCode1.TabIndex = 73;
            // 
            // paymentAddupSecCode0
            // 
            this.paymentAddupSecCode0.Location = new System.Drawing.Point(17, 92);
            this.paymentAddupSecCode0.Name = "paymentAddupSecCode0";
            this.paymentAddupSecCode0.Size = new System.Drawing.Size(114, 19);
            this.paymentAddupSecCode0.TabIndex = 72;
            this.paymentAddupSecCode0.Text = "01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "拠点コード";
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
            // enterpriseCode
            // 
            this.enterpriseCode.Location = new System.Drawing.Point(16, 31);
            this.enterpriseCode.Name = "enterpriseCode";
            this.enterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.enterpriseCode.TabIndex = 69;
            this.enterpriseCode.Text = "0101150842020000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 12);
            this.label3.TabIndex = 85;
            this.label3.Text = "0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:ﾌﾟﾗｽとﾏｲﾅｽ 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outMoneyDiv);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ed_PayeeCode);
            this.Controls.Add(this.st_PayeeCode);
            this.Controls.Add(this.ed_AddUpYearMonth);
            this.Controls.Add(this.st_AddUpYearMonth);
            this.Controls.Add(this.paymentAddupSecCode2);
            this.Controls.Add(this.paymentAddupSecCode1);
            this.Controls.Add(this.paymentAddupSecCode0);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterpriseCode);
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
            IpaymentBalanceLedgerDB = MediationPaymentBalanceLedgerDB.GetPaymentBalanceLedgerDB();
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
            ExtrInfo_PaymentBalanceWork work = new ExtrInfo_PaymentBalanceWork();

            work.EnterpriseCode = enterpriseCode.Text;

            //拠点コード
            string[] sectionCode = new string[3];
            sectionCode[0] = paymentAddupSecCode0.Text;
            sectionCode[1] = paymentAddupSecCode1.Text;
            sectionCode[2] = paymentAddupSecCode2.Text;
            work.PaymentAddupSecCodeList = sectionCode;

            //支払先コード
            if (st_PayeeCode.Text != "") work.St_PayeeCode = Convert.ToInt32(st_PayeeCode.Text);
            if (ed_PayeeCode.Text != "") work.Ed_PayeeCode = Convert.ToInt32(ed_PayeeCode.Text);

            //対象年月
            if (st_AddUpYearMonth.Text != "") work.St_AddUpYearMonth = Convert.ToInt32(st_AddUpYearMonth.Text);
            if (ed_AddUpYearMonth.Text != "") work.Ed_AddUpYearMonth = Convert.ToInt32(ed_AddUpYearMonth.Text);

            ////出力金額区分
            //if (outMoneyDiv.Text != "") work.OutMoneyDiv = Convert.ToInt32(outMoneyDiv.Text);
            

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
			object retObj = null;
            //ExtrInfo_PaymentBalanceWork work = new ExtrInfo_PaymentBalanceWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            try
            {
                int status = IpaymentBalanceLedgerDB.SearchPaymentBalanceLedger(out retObj, workObj);
                if (status != 0)
                {
                    Text = "該当データ無し:status = " + status.ToString();
                }
                else
                {

                    Text = "該当データ有り  HIT " + ((ArrayList)retObj).Count.ToString() + "件";

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
            ExtrInfo_PaymentBalanceWork extrInfo_DemandTotalWork = new ExtrInfo_PaymentBalanceWork();
			extrInfo_DemandTotalWork.EnterpriseCode = enterpriseCode.Text;
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

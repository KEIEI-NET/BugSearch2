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
		private System.Windows.Forms.TextBox enterpriseCode;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		//private SalesTransitDtParaWork _salesTransitDtWork = null;

		//private SalesTransitDtParaWork _prevSalesTransitDtParaWork = null;
        private System.Windows.Forms.Button button8;

        private ICollectProgramDB ICollectProgramDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label1;
        private Label label2;
        private Button button11;
        private TextBox paymentAddupSecCode0;
        private TextBox paymentAddupSecCode1;
        private TextBox paymentAddupSecCode2;
        private Label label3;
        private TextBox cAddUpUpdExecDate;
        private Label label4;
        private TextBox st_ClaimCode;
        private TextBox ed_ClaimCode;
        private Label label5;
        private Label label6;
        private TextBox paymentSchedule;
        private TextBox paymentCond0;
        private Label label9;
        private Label label10;
        private TextBox employeeKindDiv;
        private TextBox st_EmployeeCode;
        private TextBox ed_EmployeeCode;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox addUpDate;
        private TextBox sortOrderDiv;
        private TextBox paymentCond1;
        private TextBox paymentCond2;
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
            this.enterpriseCode = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.paymentAddupSecCode0 = new System.Windows.Forms.TextBox();
            this.paymentAddupSecCode1 = new System.Windows.Forms.TextBox();
            this.paymentAddupSecCode2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cAddUpUpdExecDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.st_ClaimCode = new System.Windows.Forms.TextBox();
            this.ed_ClaimCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.paymentSchedule = new System.Windows.Forms.TextBox();
            this.paymentCond0 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.employeeKindDiv = new System.Windows.Forms.TextBox();
            this.st_EmployeeCode = new System.Windows.Forms.TextBox();
            this.ed_EmployeeCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.addUpDate = new System.Windows.Forms.TextBox();
            this.sortOrderDiv = new System.Windows.Forms.TextBox();
            this.paymentCond1 = new System.Windows.Forms.TextBox();
            this.paymentCond2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // enterpriseCode
            // 
            this.enterpriseCode.Location = new System.Drawing.Point(16, 44);
            this.enterpriseCode.Name = "enterpriseCode";
            this.enterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.enterpriseCode.TabIndex = 1;
            this.enterpriseCode.Text = "0101150842020000";
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
            this.button8.Text = "回収予定表";
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
            this.label2.Location = new System.Drawing.Point(15, 85);
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
            // paymentAddupSecCode0
            // 
            this.paymentAddupSecCode0.Location = new System.Drawing.Point(17, 105);
            this.paymentAddupSecCode0.Name = "paymentAddupSecCode0";
            this.paymentAddupSecCode0.Size = new System.Drawing.Size(114, 19);
            this.paymentAddupSecCode0.TabIndex = 59;
            this.paymentAddupSecCode0.Text = "01";
            // 
            // paymentAddupSecCode1
            // 
            this.paymentAddupSecCode1.Location = new System.Drawing.Point(17, 130);
            this.paymentAddupSecCode1.Name = "paymentAddupSecCode1";
            this.paymentAddupSecCode1.Size = new System.Drawing.Size(114, 19);
            this.paymentAddupSecCode1.TabIndex = 60;
            // 
            // paymentAddupSecCode2
            // 
            this.paymentAddupSecCode2.Location = new System.Drawing.Point(17, 155);
            this.paymentAddupSecCode2.Name = "paymentAddupSecCode2";
            this.paymentAddupSecCode2.Size = new System.Drawing.Size(114, 19);
            this.paymentAddupSecCode2.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "得意先締日";
            // 
            // cAddUpUpdExecDate
            // 
            this.cAddUpUpdExecDate.Location = new System.Drawing.Point(518, 69);
            this.cAddUpUpdExecDate.Name = "cAddUpUpdExecDate";
            this.cAddUpUpdExecDate.Size = new System.Drawing.Size(100, 19);
            this.cAddUpUpdExecDate.TabIndex = 63;
            this.cAddUpUpdExecDate.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 64;
            this.label4.Text = "請求先コード";
            // 
            // st_ClaimCode
            // 
            this.st_ClaimCode.Location = new System.Drawing.Point(518, 94);
            this.st_ClaimCode.Name = "st_ClaimCode";
            this.st_ClaimCode.Size = new System.Drawing.Size(100, 19);
            this.st_ClaimCode.TabIndex = 63;
            this.st_ClaimCode.Text = "0";
            // 
            // ed_ClaimCode
            // 
            this.ed_ClaimCode.Location = new System.Drawing.Point(647, 94);
            this.ed_ClaimCode.Name = "ed_ClaimCode";
            this.ed_ClaimCode.Size = new System.Drawing.Size(100, 19);
            this.ed_ClaimCode.TabIndex = 63;
            this.ed_ClaimCode.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(624, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "～";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 64;
            this.label6.Text = "支払条件";
            // 
            // paymentSchedule
            // 
            this.paymentSchedule.Location = new System.Drawing.Point(518, 168);
            this.paymentSchedule.Name = "paymentSchedule";
            this.paymentSchedule.Size = new System.Drawing.Size(100, 19);
            this.paymentSchedule.TabIndex = 63;
            this.paymentSchedule.Text = "0";
            // 
            // paymentCond0
            // 
            this.paymentCond0.Location = new System.Drawing.Point(175, 105);
            this.paymentCond0.Name = "paymentCond0";
            this.paymentCond0.Size = new System.Drawing.Size(100, 19);
            this.paymentCond0.TabIndex = 63;
            this.paymentCond0.Text = "20";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(442, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 64;
            this.label9.Text = "担当者区分";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(442, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 64;
            this.label10.Text = "担当者";
            // 
            // employeeKindDiv
            // 
            this.employeeKindDiv.Location = new System.Drawing.Point(518, 121);
            this.employeeKindDiv.Name = "employeeKindDiv";
            this.employeeKindDiv.Size = new System.Drawing.Size(51, 19);
            this.employeeKindDiv.TabIndex = 63;
            this.employeeKindDiv.Text = "0";
            // 
            // st_EmployeeCode
            // 
            this.st_EmployeeCode.Location = new System.Drawing.Point(518, 143);
            this.st_EmployeeCode.Name = "st_EmployeeCode";
            this.st_EmployeeCode.Size = new System.Drawing.Size(51, 19);
            this.st_EmployeeCode.TabIndex = 63;
            // 
            // ed_EmployeeCode
            // 
            this.ed_EmployeeCode.Location = new System.Drawing.Point(598, 143);
            this.ed_EmployeeCode.Name = "ed_EmployeeCode";
            this.ed_EmployeeCode.Size = new System.Drawing.Size(51, 19);
            this.ed_EmployeeCode.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(575, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 64;
            this.label12.Text = "～";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(442, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 66;
            this.label14.Text = "処理日";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(442, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 66;
            this.label15.Text = "出力順";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(442, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 66;
            this.label16.Text = "支払予定日";
            // 
            // addUpDate
            // 
            this.addUpDate.Location = new System.Drawing.Point(518, 22);
            this.addUpDate.Name = "addUpDate";
            this.addUpDate.Size = new System.Drawing.Size(75, 19);
            this.addUpDate.TabIndex = 67;
            this.addUpDate.Text = "2007/10/31";
            // 
            // sortOrderDiv
            // 
            this.sortOrderDiv.Location = new System.Drawing.Point(518, 44);
            this.sortOrderDiv.Name = "sortOrderDiv";
            this.sortOrderDiv.Size = new System.Drawing.Size(75, 19);
            this.sortOrderDiv.TabIndex = 68;
            this.sortOrderDiv.Text = "1";
            // 
            // paymentCond1
            // 
            this.paymentCond1.Location = new System.Drawing.Point(175, 130);
            this.paymentCond1.Name = "paymentCond1";
            this.paymentCond1.Size = new System.Drawing.Size(100, 19);
            this.paymentCond1.TabIndex = 69;
            this.paymentCond1.Text = "0";
            // 
            // paymentCond2
            // 
            this.paymentCond2.Location = new System.Drawing.Point(175, 155);
            this.paymentCond2.Name = "paymentCond2";
            this.paymentCond2.Size = new System.Drawing.Size(100, 19);
            this.paymentCond2.TabIndex = 70;
            this.paymentCond2.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.paymentCond2);
            this.Controls.Add(this.paymentCond1);
            this.Controls.Add(this.sortOrderDiv);
            this.Controls.Add(this.addUpDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ed_ClaimCode);
            this.Controls.Add(this.paymentCond0);
            this.Controls.Add(this.paymentSchedule);
            this.Controls.Add(this.st_ClaimCode);
            this.Controls.Add(this.ed_EmployeeCode);
            this.Controls.Add(this.st_EmployeeCode);
            this.Controls.Add(this.employeeKindDiv);
            this.Controls.Add(this.cAddUpUpdExecDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.paymentAddupSecCode2);
            this.Controls.Add(this.paymentAddupSecCode1);
            this.Controls.Add(this.paymentAddupSecCode0);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.enterpriseCode);
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
            ICollectProgramDB = MediationCollectProgramDB.GetCollectProgramDB();
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
            ArrayList al = new ArrayList();
            ExtrInfo_CollectPlanWork work = new ExtrInfo_CollectPlanWork();

            //企業コード
            work.EnterpriseCode = enterpriseCode.Text;
            
            //拠点コード
            string[] sectionCode = new string[3];
            sectionCode[0] = paymentAddupSecCode0.Text;
            sectionCode[1] = paymentAddupSecCode1.Text;
            sectionCode[2] = paymentAddupSecCode2.Text;
            work.CollectAddupSecCodeList = sectionCode;

            //金種
            Int32[] paymentCond = new Int32[3];
            paymentCond[0] = Convert.ToInt32(paymentCond0.Text);
            paymentCond[1] = Convert.ToInt32(paymentCond1.Text);
            paymentCond[2] = Convert.ToInt32(paymentCond2.Text);
            work.CollectCond = paymentCond;

            if (addUpDate.Text != "") work.AddUpDate = Convert.ToDateTime(addUpDate.Text);
            work.SortOrderDiv = Convert.ToInt32(sortOrderDiv.Text);
            work.TotalDay = Convert.ToInt32(cAddUpUpdExecDate.Text);
            work.St_ClaimCode = Convert.ToInt32(st_ClaimCode.Text);
            work.Ed_ClaimCode = Convert.ToInt32(ed_ClaimCode.Text);
            work.EmployeeKindDiv = Convert.ToInt32(employeeKindDiv.Text);
            work.St_EmployeeCode = st_EmployeeCode.Text;
            work.Ed_EmployeeCode = ed_EmployeeCode.Text;
            work.CollectSchedule = Convert.ToInt32(paymentSchedule.Text);

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
            //ExtrInfo_CollectPlanWork work = new ExtrInfo_CollectPlanWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            try
            {
                int status = ICollectProgramDB.SearchCollectProgram(out retObj, workObj);
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
            ExtrInfo_CollectPlanWork extrInfo_CollectTotalWork = new ExtrInfo_CollectPlanWork();
			extrInfo_CollectTotalWork.EnterpriseCode = enterpriseCode.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(extrInfo_CollectTotalWork);
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

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
    /// class Form1
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
	{
        #region Windows
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button BtSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Ed_PayeeCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox EnterpriceCode;
        private System.Windows.Forms.TextBox St_PayeeKana;
        private System.Windows.Forms.TextBox EmployeeKindDiv;
        private System.Windows.Forms.TextBox Ed_PayeeKana;
        private System.Windows.Forms.TextBox St_PayeeCode;
        private TextBox St_EmployeeCode;
        #endregion

        private IPaymentListWorkDB iPaymentListWorkDB = null;

        private static string[] _parameter;
        private Label label2;
        private Label label9;
        private Button button1;
        private TextBox tb24;
        private ListBox PaymentAddupSecCodeList;
        private Label label6;
        private Button button3;
        private TextBox Ed_EmployeeCode;
        private TextBox St_PaymentSlipNo;
        private TextBox Ed_PaymentSlipNo;
        private CheckBox IsOptSection;
        private TextBox St_AddUpADate;
        private TextBox Ed_AddUpADate;
        private Label label15;
        private Label label17;
        private TextBox St_InputDate;
        private TextBox Ed_InputDate;
        private TextBox textBox5;
        private ListBox PaymentKind;
        private TextBox PrintDiv;
        private Label label18;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private static System.Windows.Forms.Form _form = null;


        /// <summary>
        /// Form1()
        /// </summary>
        public Form1()
		{
			InitializeComponent();
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
            this.EnterpriceCode = new System.Windows.Forms.TextBox();
            this.St_PayeeKana = new System.Windows.Forms.TextBox();
            this.Ed_PayeeCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.Ed_EmployeeCode = new System.Windows.Forms.TextBox();
            this.BtSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.EmployeeKindDiv = new System.Windows.Forms.TextBox();
            this.Ed_PayeeKana = new System.Windows.Forms.TextBox();
            this.St_PayeeCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.St_EmployeeCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb24 = new System.Windows.Forms.TextBox();
            this.PaymentAddupSecCodeList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.St_PaymentSlipNo = new System.Windows.Forms.TextBox();
            this.Ed_PaymentSlipNo = new System.Windows.Forms.TextBox();
            this.IsOptSection = new System.Windows.Forms.CheckBox();
            this.St_AddUpADate = new System.Windows.Forms.TextBox();
            this.Ed_AddUpADate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.St_InputDate = new System.Windows.Forms.TextBox();
            this.Ed_InputDate = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.PaymentKind = new System.Windows.Forms.ListBox();
            this.PrintDiv = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterpriceCode
            // 
            this.EnterpriceCode.Location = new System.Drawing.Point(10, 3);
            this.EnterpriceCode.Name = "EnterpriceCode";
            this.EnterpriceCode.Size = new System.Drawing.Size(144, 19);
            this.EnterpriceCode.TabIndex = 1;
            this.EnterpriceCode.Text = "0101150842020000";
            // 
            // St_PayeeKana
            // 
            this.St_PayeeKana.BackColor = System.Drawing.Color.White;
            this.St_PayeeKana.Location = new System.Drawing.Point(288, 28);
            this.St_PayeeKana.Name = "St_PayeeKana";
            this.St_PayeeKana.Size = new System.Drawing.Size(72, 19);
            this.St_PayeeKana.TabIndex = 6;
            // 
            // Ed_PayeeCode
            // 
            this.Ed_PayeeCode.Location = new System.Drawing.Point(366, 3);
            this.Ed_PayeeCode.Name = "Ed_PayeeCode";
            this.Ed_PayeeCode.Size = new System.Drawing.Size(72, 19);
            this.Ed_PayeeCode.TabIndex = 3;
            this.Ed_PayeeCode.Text = "999999999";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(160, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "担当者コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(160, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "担当者区分";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 330);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(664, 254);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(160, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "支払先コード";
            // 
            // Ed_EmployeeCode
            // 
            this.Ed_EmployeeCode.Location = new System.Drawing.Point(366, 78);
            this.Ed_EmployeeCode.Name = "Ed_EmployeeCode";
            this.Ed_EmployeeCode.Size = new System.Drawing.Size(72, 19);
            this.Ed_EmployeeCode.TabIndex = 100;
            this.Ed_EmployeeCode.TabStop = false;
            this.Ed_EmployeeCode.Text = "999999999";
            // 
            // BtSearch
            // 
            this.BtSearch.Location = new System.Drawing.Point(298, 300);
            this.BtSearch.Name = "BtSearch";
            this.BtSearch.Size = new System.Drawing.Size(64, 24);
            this.BtSearch.TabIndex = 50;
            this.BtSearch.Text = "Search";
            this.BtSearch.Click += new System.EventHandler(this.BtSearch_Click);
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
            // EmployeeKindDiv
            // 
            this.EmployeeKindDiv.Location = new System.Drawing.Point(288, 53);
            this.EmployeeKindDiv.Name = "EmployeeKindDiv";
            this.EmployeeKindDiv.Size = new System.Drawing.Size(72, 19);
            this.EmployeeKindDiv.TabIndex = 4;
            this.EmployeeKindDiv.Text = "1";
            // 
            // Ed_PayeeKana
            // 
            this.Ed_PayeeKana.BackColor = System.Drawing.Color.White;
            this.Ed_PayeeKana.Location = new System.Drawing.Point(366, 28);
            this.Ed_PayeeKana.Name = "Ed_PayeeKana";
            this.Ed_PayeeKana.Size = new System.Drawing.Size(72, 19);
            this.Ed_PayeeKana.TabIndex = 8;
            // 
            // St_PayeeCode
            // 
            this.St_PayeeCode.Location = new System.Drawing.Point(288, 3);
            this.St_PayeeCode.Name = "St_PayeeCode";
            this.St_PayeeCode.Size = new System.Drawing.Size(72, 19);
            this.St_PayeeCode.TabIndex = 2;
            this.St_PayeeCode.Text = "0";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(160, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 19);
            this.label16.TabIndex = 115;
            this.label16.Text = "支払先カナ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label66.Location = new System.Drawing.Point(160, 168);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(104, 19);
            this.label66.TabIndex = 165;
            this.label66.Text = "支払番号";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // St_EmployeeCode
            // 
            this.St_EmployeeCode.Location = new System.Drawing.Point(288, 78);
            this.St_EmployeeCode.Name = "St_EmployeeCode";
            this.St_EmployeeCode.Size = new System.Drawing.Size(72, 19);
            this.St_EmployeeCode.TabIndex = 5;
            this.St_EmployeeCode.Text = "0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(7, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 185;
            this.label2.Text = "■入金金種";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.button1.Location = new System.Drawing.Point(228, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 232;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb24
            // 
            this.tb24.Location = new System.Drawing.Point(10, 53);
            this.tb24.Name = "tb24";
            this.tb24.Size = new System.Drawing.Size(144, 19);
            this.tb24.TabIndex = 231;
            this.tb24.TabStop = false;
            this.tb24.Text = "000000";
            // 
            // PaymentAddupSecCodeList
            // 
            this.PaymentAddupSecCodeList.ItemHeight = 12;
            this.PaymentAddupSecCodeList.Location = new System.Drawing.Point(10, 78);
            this.PaymentAddupSecCodeList.Name = "PaymentAddupSecCodeList";
            this.PaymentAddupSecCodeList.Size = new System.Drawing.Size(144, 88);
            this.PaymentAddupSecCodeList.TabIndex = 230;
            this.PaymentAddupSecCodeList.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 229;
            this.label6.Text = "■拠点コード";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(158, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 228;
            this.button3.TabStop = false;
            this.button3.Text = "Add";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // St_PaymentSlipNo
            // 
            this.St_PaymentSlipNo.Location = new System.Drawing.Point(288, 168);
            this.St_PaymentSlipNo.Name = "St_PaymentSlipNo";
            this.St_PaymentSlipNo.Size = new System.Drawing.Size(72, 19);
            this.St_PaymentSlipNo.TabIndex = 234;
            this.St_PaymentSlipNo.TabStop = false;
            this.St_PaymentSlipNo.Text = "0";
            // 
            // Ed_PaymentSlipNo
            // 
            this.Ed_PaymentSlipNo.Location = new System.Drawing.Point(366, 168);
            this.Ed_PaymentSlipNo.Name = "Ed_PaymentSlipNo";
            this.Ed_PaymentSlipNo.Size = new System.Drawing.Size(72, 19);
            this.Ed_PaymentSlipNo.TabIndex = 236;
            this.Ed_PaymentSlipNo.TabStop = false;
            this.Ed_PaymentSlipNo.Text = "999999999";
            // 
            // IsOptSection
            // 
            this.IsOptSection.AutoSize = true;
            this.IsOptSection.Location = new System.Drawing.Point(163, 249);
            this.IsOptSection.Name = "IsOptSection";
            this.IsOptSection.Size = new System.Drawing.Size(260, 16);
            this.IsOptSection.TabIndex = 253;
            this.IsOptSection.Text = "拠点オプション導入区分(true:全社 false:各拠点)";
            this.IsOptSection.UseVisualStyleBackColor = true;
            // 
            // St_AddUpADate
            // 
            this.St_AddUpADate.Location = new System.Drawing.Point(288, 108);
            this.St_AddUpADate.Name = "St_AddUpADate";
            this.St_AddUpADate.Size = new System.Drawing.Size(72, 19);
            this.St_AddUpADate.TabIndex = 254;
            this.St_AddUpADate.Text = "2007/01/01";
            // 
            // Ed_AddUpADate
            // 
            this.Ed_AddUpADate.Location = new System.Drawing.Point(366, 107);
            this.Ed_AddUpADate.Name = "Ed_AddUpADate";
            this.Ed_AddUpADate.Size = new System.Drawing.Size(72, 19);
            this.Ed_AddUpADate.TabIndex = 255;
            this.Ed_AddUpADate.Text = "2008/12/31";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(160, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 256;
            this.label15.Text = "計上日";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(160, 135);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 19);
            this.label17.TabIndex = 259;
            this.label17.Text = "支払日";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // St_InputDate
            // 
            this.St_InputDate.Location = new System.Drawing.Point(288, 136);
            this.St_InputDate.Name = "St_InputDate";
            this.St_InputDate.Size = new System.Drawing.Size(72, 19);
            this.St_InputDate.TabIndex = 257;
            this.St_InputDate.Text = "2007/01/01";
            // 
            // Ed_InputDate
            // 
            this.Ed_InputDate.Location = new System.Drawing.Point(366, 135);
            this.Ed_InputDate.Name = "Ed_InputDate";
            this.Ed_InputDate.Size = new System.Drawing.Size(72, 19);
            this.Ed_InputDate.TabIndex = 258;
            this.Ed_InputDate.Text = "2008/12/31";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(10, 193);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(144, 19);
            this.textBox5.TabIndex = 261;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "000000";
            // 
            // PaymentKind
            // 
            this.PaymentKind.ItemHeight = 12;
            this.PaymentKind.Location = new System.Drawing.Point(10, 218);
            this.PaymentKind.Name = "PaymentKind";
            this.PaymentKind.Size = new System.Drawing.Size(144, 88);
            this.PaymentKind.TabIndex = 260;
            this.PaymentKind.TabStop = false;
            // 
            // PrintDiv
            // 
            this.PrintDiv.Location = new System.Drawing.Point(288, 224);
            this.PrintDiv.Name = "PrintDiv";
            this.PrintDiv.Size = new System.Drawing.Size(72, 19);
            this.PrintDiv.TabIndex = 263;
            this.PrintDiv.TabStop = false;
            this.PrintDiv.Text = "2";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(160, 224);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(122, 19);
            this.label18.TabIndex = 262;
            this.label18.Text = "帳票タイプ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(366, 224);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(185, 23);
            this.ultraLabel1.TabIndex = 264;
            this.ultraLabel1.Text = "1:総合計、2:簡易、3:金種別";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(676, 595);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PrintDiv);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.PaymentKind);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.St_InputDate);
            this.Controls.Add(this.Ed_InputDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.St_AddUpADate);
            this.Controls.Add(this.Ed_AddUpADate);
            this.Controls.Add(this.IsOptSection);
            this.Controls.Add(this.Ed_PaymentSlipNo);
            this.Controls.Add(this.St_PaymentSlipNo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb24);
            this.Controls.Add(this.PaymentAddupSecCodeList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.St_EmployeeCode);
            this.Controls.Add(this.St_PayeeCode);
            this.Controls.Add(this.EmployeeKindDiv);
            this.Controls.Add(this.Ed_PayeeKana);
            this.Controls.Add(this.Ed_EmployeeCode);
            this.Controls.Add(this.Ed_PayeeCode);
            this.Controls.Add(this.St_PayeeKana);
            this.Controls.Add(this.EnterpriceCode);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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


		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            iPaymentListWorkDB = MediationPaymentListWorkDB.GetPaymentListWorkDB();
		}


        private void button3_Click(object sender, EventArgs e)
        {
            if (tb24.Text != "")
            {
                PaymentAddupSecCodeList.Items.Add(tb24.Text);
            }
            if (textBox5.Text != "")
            {
                PaymentKind.Items.Add(textBox5.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentAddupSecCodeList.Items.Clear();
            PaymentKind.Items.Clear();
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;
            ArrayList al1 = new ArrayList();
            ArrayList al2 = new ArrayList();

            PaymentSlpCndtnWork paymentSlpCndtnWork = new PaymentSlpCndtnWork();

            #region 値セット
            //企業コード
            paymentSlpCndtnWork.EnterpriseCode = EnterpriceCode.Text;
            paymentSlpCndtnWork.IsOptSection = IsOptSection.Checked;

            //選択支払計上拠点コード
            string[] str = new string[PaymentAddupSecCodeList.Items.Count];
            for (int i = 0; i < PaymentAddupSecCodeList.Items.Count; i++)
            {
                str[i] = PaymentAddupSecCodeList.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                paymentSlpCndtnWork.PaymentAddupSecCodeList = str;
            }

            //支払金種
            ArrayList alist = new ArrayList();
            for (int i = 0; i < PaymentKind.Items.Count; i++)
            {
                alist.Add(PaymentKind.Items[i].ToString());
            }
            paymentSlpCndtnWork.PaymentKind = alist;

            //計上日
            paymentSlpCndtnWork.St_AddUpADate = Convert.ToDateTime(St_AddUpADate.Text);
            paymentSlpCndtnWork.Ed_AddUpADate = Convert.ToDateTime(Ed_AddUpADate.Text);

            //支払日
            paymentSlpCndtnWork.St_InputDate = Convert.ToDateTime(St_InputDate.Text);
            paymentSlpCndtnWork.Ed_InputDate = Convert.ToDateTime(Ed_InputDate.Text);

            //帳票タイプ区分
            paymentSlpCndtnWork.PrintDiv = Convert.ToInt32(PrintDiv.Text);

            //支払先コード
            paymentSlpCndtnWork.St_PayeeCode = Convert.ToInt32(St_PayeeCode.Text);
            paymentSlpCndtnWork.Ed_PayeeCode = Convert.ToInt32(Ed_PayeeCode.Text);

            //支払先カナ
            paymentSlpCndtnWork.St_PayeeKana = St_PayeeKana.Text;
            paymentSlpCndtnWork.Ed_PayeeKana = Ed_PayeeKana.Text;

            //担当者区分
            paymentSlpCndtnWork.EmployeeKindDiv = Convert.ToInt32(EmployeeKindDiv.Text);

            //支払担当者・入力担当者
            paymentSlpCndtnWork.St_EmployeeCode = St_EmployeeCode.Text;
            paymentSlpCndtnWork.Ed_EmployeeCode = Ed_EmployeeCode.Text;

            //支払番号
            paymentSlpCndtnWork.St_PaymentSlipNo = Convert.ToInt32(St_PaymentSlipNo.Text);
            paymentSlpCndtnWork.Ed_PaymentSlipNo = Convert.ToInt32(Ed_PaymentSlipNo.Text);
            #endregion

            object paraobj = paymentSlpCndtnWork;      //条件パラメータ
            object retobj = null;                               //DM抽出結果

            int status = 0;
            switch (paymentSlpCndtnWork.PrintDiv)
            {
                case 1:
                    {
                        MessageBox.Show("総合計タイプは2008/7/8のPM.NSレビューで無くしました。");
                        //status = iPaymentListWorkDB.SearchAllTotal(out retobj, paraobj, 0, 0,0);
                        break;
                    }
                case 2:
                //case 3:
                    {
                        status = iPaymentListWorkDB.SearchDepsitOnly(out retobj, paraobj, 0, 0);
                        break;
                    }
                case 3:
                //case 4:
                    {
                        status = iPaymentListWorkDB.SearchDepsitKind(out retobj, paraobj, 0, 0);
                        break;
                    }
            }

            
            if (status != 0)
            {
                Text = "該当データ無し  status=" + status;
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";

                dataGrid1.DataSource = retobj;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);

        }
	}
}

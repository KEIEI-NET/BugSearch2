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

        private IPrevYearComparisonDB IprevYearComparisonDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private TextBox ListType;
        private Label label15;
        private Label label12;
        private Label label5;
        private Label label10;
        private Label label4;
        private TextBox Ed_AddUpSecCode;
        private TextBox St_AddUpSecCode;
        private TextBox Ed_AddUpYearMonth;
        private TextBox St_AddUpYearMonth;
        private TextBox SecCode2;
        private TextBox SecCode1;
        private TextBox SecCode0;
        private Label label2;
        private Label label1;
        private TextBox EnterpriseCode;
        private Label label3;
        private TextBox St_SubSectionCode;
        private TextBox St_MinSectionCode;
        private TextBox Ed_MinSectionCode;
        private TextBox Ed_SubSectionCode;
        private Label label6;
        private Label label7;
        private TextBox Ed_EmployeeCode;
        private TextBox St_EmployeeCode;
        private Label label8;
        private Label label9;
        private TextBox Ed_CustomerCode;
        private TextBox St_CustomerCode;
        private Label label11;
        private Label label13;
        private TextBox Ed_BusinessTypeCode;
        private TextBox St_BusinessTypeCode;
        private Label label14;
        private Label label16;
        private TextBox Ed_SalesAreaCode;
        private TextBox St_SalesAreaCode;
        private Label label17;
        private Label label18;
        private TextBox Ed_MonthSalesRatio;
        private TextBox St_MonthSalesRatio;
        private Label label19;
        private Label label20;
        private TextBox Ed_YearGrossRatio;
        private TextBox St_YearGrossRatio;
        private Label label21;
        private Label label22;
        private TextBox Ed_MonthGrossRatio;
        private TextBox St_MonthGrossRatio;
        private Label label23;
        private Label label24;
        private TextBox Ed_YearSalesRatio;
        private TextBox St_YearSalesRatio;
        private Label label25;
        private TextBox MoneyUnit;
        private Label label26;
        private Label label27;
        private TextBox PrintType;
        private TextBox TotalWay;
        private Label label28;
        private Label label29;
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
            this.ListType = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Ed_AddUpSecCode = new System.Windows.Forms.TextBox();
            this.St_AddUpSecCode = new System.Windows.Forms.TextBox();
            this.Ed_AddUpYearMonth = new System.Windows.Forms.TextBox();
            this.St_AddUpYearMonth = new System.Windows.Forms.TextBox();
            this.SecCode2 = new System.Windows.Forms.TextBox();
            this.SecCode1 = new System.Windows.Forms.TextBox();
            this.SecCode0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.St_SubSectionCode = new System.Windows.Forms.TextBox();
            this.St_MinSectionCode = new System.Windows.Forms.TextBox();
            this.Ed_MinSectionCode = new System.Windows.Forms.TextBox();
            this.Ed_SubSectionCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Ed_EmployeeCode = new System.Windows.Forms.TextBox();
            this.St_EmployeeCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Ed_CustomerCode = new System.Windows.Forms.TextBox();
            this.St_CustomerCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Ed_BusinessTypeCode = new System.Windows.Forms.TextBox();
            this.St_BusinessTypeCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Ed_SalesAreaCode = new System.Windows.Forms.TextBox();
            this.St_SalesAreaCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Ed_MonthSalesRatio = new System.Windows.Forms.TextBox();
            this.St_MonthSalesRatio = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Ed_YearGrossRatio = new System.Windows.Forms.TextBox();
            this.St_YearGrossRatio = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.Ed_MonthGrossRatio = new System.Windows.Forms.TextBox();
            this.St_MonthGrossRatio = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.Ed_YearSalesRatio = new System.Windows.Forms.TextBox();
            this.St_YearSalesRatio = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.MoneyUnit = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.PrintType = new System.Windows.Forms.TextBox();
            this.TotalWay = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
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
            this.button8.Text = "前年対比表";
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
            // ListType
            // 
            this.ListType.Location = new System.Drawing.Point(293, 29);
            this.ListType.Name = "ListType";
            this.ListType.Size = new System.Drawing.Size(75, 19);
            this.ListType.TabIndex = 84;
            this.ListType.Text = "3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(217, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 12);
            this.label15.TabIndex = 83;
            this.label15.Text = "帳票タイプ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(350, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 80;
            this.label12.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(613, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 79;
            this.label5.Text = "～";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "対象年月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "拠点コード等";
            // 
            // Ed_AddUpSecCode
            // 
            this.Ed_AddUpSecCode.Location = new System.Drawing.Point(636, 98);
            this.Ed_AddUpSecCode.Name = "Ed_AddUpSecCode";
            this.Ed_AddUpSecCode.Size = new System.Drawing.Size(51, 19);
            this.Ed_AddUpSecCode.TabIndex = 77;
            this.Ed_AddUpSecCode.Text = "000001";
            // 
            // St_AddUpSecCode
            // 
            this.St_AddUpSecCode.Location = new System.Drawing.Point(507, 98);
            this.St_AddUpSecCode.Name = "St_AddUpSecCode";
            this.St_AddUpSecCode.Size = new System.Drawing.Size(51, 19);
            this.St_AddUpSecCode.TabIndex = 78;
            this.St_AddUpSecCode.Text = "000001";
            // 
            // Ed_AddUpYearMonth
            // 
            this.Ed_AddUpYearMonth.Location = new System.Drawing.Point(373, 97);
            this.Ed_AddUpYearMonth.Name = "Ed_AddUpYearMonth";
            this.Ed_AddUpYearMonth.Size = new System.Drawing.Size(51, 19);
            this.Ed_AddUpYearMonth.TabIndex = 75;
            this.Ed_AddUpYearMonth.Text = "200712";
            // 
            // St_AddUpYearMonth
            // 
            this.St_AddUpYearMonth.Location = new System.Drawing.Point(293, 97);
            this.St_AddUpYearMonth.Name = "St_AddUpYearMonth";
            this.St_AddUpYearMonth.Size = new System.Drawing.Size(51, 19);
            this.St_AddUpYearMonth.TabIndex = 76;
            this.St_AddUpYearMonth.Text = "200701";
            // 
            // SecCode2
            // 
            this.SecCode2.Location = new System.Drawing.Point(17, 142);
            this.SecCode2.Name = "SecCode2";
            this.SecCode2.Size = new System.Drawing.Size(114, 19);
            this.SecCode2.TabIndex = 74;
            // 
            // SecCode1
            // 
            this.SecCode1.Location = new System.Drawing.Point(17, 117);
            this.SecCode1.Name = "SecCode1";
            this.SecCode1.Size = new System.Drawing.Size(114, 19);
            this.SecCode1.TabIndex = 73;
            // 
            // SecCode0
            // 
            this.SecCode0.Location = new System.Drawing.Point(17, 92);
            this.SecCode0.Name = "SecCode0";
            this.SecCode0.Size = new System.Drawing.Size(114, 19);
            this.SecCode0.TabIndex = 72;
            this.SecCode0.Text = "000001";
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
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(16, 31);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 69;
            this.EnterpriseCode.Text = "0113180842031000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(419, 12);
            this.label3.TabIndex = 85;
            this.label3.Text = "0:得意先別,1:担当者別,2:受注者別,3:地区別,4:業種別,5:グループコード別,6:BLコード別";
            // 
            // St_SubSectionCode
            // 
            this.St_SubSectionCode.Location = new System.Drawing.Point(557, 98);
            this.St_SubSectionCode.Name = "St_SubSectionCode";
            this.St_SubSectionCode.Size = new System.Drawing.Size(25, 19);
            this.St_SubSectionCode.TabIndex = 87;
            this.St_SubSectionCode.Text = "00";
            // 
            // St_MinSectionCode
            // 
            this.St_MinSectionCode.Location = new System.Drawing.Point(582, 98);
            this.St_MinSectionCode.Name = "St_MinSectionCode";
            this.St_MinSectionCode.Size = new System.Drawing.Size(25, 19);
            this.St_MinSectionCode.TabIndex = 88;
            this.St_MinSectionCode.Text = "00";
            // 
            // Ed_MinSectionCode
            // 
            this.Ed_MinSectionCode.Location = new System.Drawing.Point(711, 98);
            this.Ed_MinSectionCode.Name = "Ed_MinSectionCode";
            this.Ed_MinSectionCode.Size = new System.Drawing.Size(25, 19);
            this.Ed_MinSectionCode.TabIndex = 90;
            this.Ed_MinSectionCode.Text = "00";
            // 
            // Ed_SubSectionCode
            // 
            this.Ed_SubSectionCode.Location = new System.Drawing.Point(686, 98);
            this.Ed_SubSectionCode.Name = "Ed_SubSectionCode";
            this.Ed_SubSectionCode.Size = new System.Drawing.Size(25, 19);
            this.Ed_SubSectionCode.TabIndex = 89;
            this.Ed_SubSectionCode.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 93;
            this.label6.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 94;
            this.label7.Text = "従業員コード";
            // 
            // Ed_EmployeeCode
            // 
            this.Ed_EmployeeCode.Location = new System.Drawing.Point(422, 122);
            this.Ed_EmployeeCode.Name = "Ed_EmployeeCode";
            this.Ed_EmployeeCode.Size = new System.Drawing.Size(51, 19);
            this.Ed_EmployeeCode.TabIndex = 91;
            // 
            // St_EmployeeCode
            // 
            this.St_EmployeeCode.Location = new System.Drawing.Point(293, 122);
            this.St_EmployeeCode.Name = "St_EmployeeCode";
            this.St_EmployeeCode.Size = new System.Drawing.Size(51, 19);
            this.St_EmployeeCode.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(399, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 97;
            this.label8.Text = "～";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 12);
            this.label9.TabIndex = 98;
            this.label9.Text = "得意先コード";
            // 
            // Ed_CustomerCode
            // 
            this.Ed_CustomerCode.Location = new System.Drawing.Point(422, 147);
            this.Ed_CustomerCode.Name = "Ed_CustomerCode";
            this.Ed_CustomerCode.Size = new System.Drawing.Size(51, 19);
            this.Ed_CustomerCode.TabIndex = 95;
            this.Ed_CustomerCode.Text = "0";
            // 
            // St_CustomerCode
            // 
            this.St_CustomerCode.Location = new System.Drawing.Point(293, 147);
            this.St_CustomerCode.Name = "St_CustomerCode";
            this.St_CustomerCode.Size = new System.Drawing.Size(51, 19);
            this.St_CustomerCode.TabIndex = 96;
            this.St_CustomerCode.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(399, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 101;
            this.label11.Text = "～";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(217, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 12);
            this.label13.TabIndex = 102;
            this.label13.Text = "業種コード";
            // 
            // Ed_BusinessTypeCode
            // 
            this.Ed_BusinessTypeCode.Location = new System.Drawing.Point(422, 197);
            this.Ed_BusinessTypeCode.Name = "Ed_BusinessTypeCode";
            this.Ed_BusinessTypeCode.Size = new System.Drawing.Size(51, 19);
            this.Ed_BusinessTypeCode.TabIndex = 99;
            this.Ed_BusinessTypeCode.Text = "0";
            // 
            // St_BusinessTypeCode
            // 
            this.St_BusinessTypeCode.Location = new System.Drawing.Point(293, 197);
            this.St_BusinessTypeCode.Name = "St_BusinessTypeCode";
            this.St_BusinessTypeCode.Size = new System.Drawing.Size(51, 19);
            this.St_BusinessTypeCode.TabIndex = 100;
            this.St_BusinessTypeCode.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(399, 175);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 105;
            this.label14.Text = "～";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(217, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 12);
            this.label16.TabIndex = 106;
            this.label16.Text = "エリアコード";
            // 
            // Ed_SalesAreaCode
            // 
            this.Ed_SalesAreaCode.Location = new System.Drawing.Point(422, 172);
            this.Ed_SalesAreaCode.Name = "Ed_SalesAreaCode";
            this.Ed_SalesAreaCode.Size = new System.Drawing.Size(51, 19);
            this.Ed_SalesAreaCode.TabIndex = 103;
            this.Ed_SalesAreaCode.Text = "0";
            // 
            // St_SalesAreaCode
            // 
            this.St_SalesAreaCode.Location = new System.Drawing.Point(293, 172);
            this.St_SalesAreaCode.Name = "St_SalesAreaCode";
            this.St_SalesAreaCode.Size = new System.Drawing.Size(51, 19);
            this.St_SalesAreaCode.TabIndex = 104;
            this.St_SalesAreaCode.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(643, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 109;
            this.label17.Text = "～";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(495, 125);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 12);
            this.label18.TabIndex = 110;
            this.label18.Text = "前年比(月売上)";
            // 
            // Ed_MonthSalesRatio
            // 
            this.Ed_MonthSalesRatio.Location = new System.Drawing.Point(666, 122);
            this.Ed_MonthSalesRatio.Name = "Ed_MonthSalesRatio";
            this.Ed_MonthSalesRatio.Size = new System.Drawing.Size(51, 19);
            this.Ed_MonthSalesRatio.TabIndex = 107;
            this.Ed_MonthSalesRatio.Text = "0";
            // 
            // St_MonthSalesRatio
            // 
            this.St_MonthSalesRatio.Location = new System.Drawing.Point(586, 122);
            this.St_MonthSalesRatio.Name = "St_MonthSalesRatio";
            this.St_MonthSalesRatio.Size = new System.Drawing.Size(51, 19);
            this.St_MonthSalesRatio.TabIndex = 108;
            this.St_MonthSalesRatio.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(643, 200);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 113;
            this.label19.Text = "～";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(495, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 12);
            this.label20.TabIndex = 114;
            this.label20.Text = "前年比(年粗利)";
            // 
            // Ed_YearGrossRatio
            // 
            this.Ed_YearGrossRatio.Location = new System.Drawing.Point(666, 197);
            this.Ed_YearGrossRatio.Name = "Ed_YearGrossRatio";
            this.Ed_YearGrossRatio.Size = new System.Drawing.Size(51, 19);
            this.Ed_YearGrossRatio.TabIndex = 111;
            this.Ed_YearGrossRatio.Text = "0";
            // 
            // St_YearGrossRatio
            // 
            this.St_YearGrossRatio.Location = new System.Drawing.Point(586, 197);
            this.St_YearGrossRatio.Name = "St_YearGrossRatio";
            this.St_YearGrossRatio.Size = new System.Drawing.Size(51, 19);
            this.St_YearGrossRatio.TabIndex = 112;
            this.St_YearGrossRatio.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(643, 175);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 12);
            this.label21.TabIndex = 117;
            this.label21.Text = "～";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(495, 175);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 12);
            this.label22.TabIndex = 118;
            this.label22.Text = "前年比(月粗利)";
            // 
            // Ed_MonthGrossRatio
            // 
            this.Ed_MonthGrossRatio.Location = new System.Drawing.Point(666, 172);
            this.Ed_MonthGrossRatio.Name = "Ed_MonthGrossRatio";
            this.Ed_MonthGrossRatio.Size = new System.Drawing.Size(51, 19);
            this.Ed_MonthGrossRatio.TabIndex = 115;
            this.Ed_MonthGrossRatio.Text = "0";
            // 
            // St_MonthGrossRatio
            // 
            this.St_MonthGrossRatio.Location = new System.Drawing.Point(586, 172);
            this.St_MonthGrossRatio.Name = "St_MonthGrossRatio";
            this.St_MonthGrossRatio.Size = new System.Drawing.Size(51, 19);
            this.St_MonthGrossRatio.TabIndex = 116;
            this.St_MonthGrossRatio.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(643, 150);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 121;
            this.label23.Text = "～";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(495, 150);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 12);
            this.label24.TabIndex = 122;
            this.label24.Text = "前年比(年売上)";
            // 
            // Ed_YearSalesRatio
            // 
            this.Ed_YearSalesRatio.Location = new System.Drawing.Point(666, 147);
            this.Ed_YearSalesRatio.Name = "Ed_YearSalesRatio";
            this.Ed_YearSalesRatio.Size = new System.Drawing.Size(51, 19);
            this.Ed_YearSalesRatio.TabIndex = 119;
            this.Ed_YearSalesRatio.Text = "0";
            // 
            // St_YearSalesRatio
            // 
            this.St_YearSalesRatio.Location = new System.Drawing.Point(586, 147);
            this.St_YearSalesRatio.Name = "St_YearSalesRatio";
            this.St_YearSalesRatio.Size = new System.Drawing.Size(51, 19);
            this.St_YearSalesRatio.TabIndex = 120;
            this.St_YearSalesRatio.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(374, 54);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 12);
            this.label25.TabIndex = 125;
            this.label25.Text = "0：一円単位 1:千円単位";
            // 
            // MoneyUnit
            // 
            this.MoneyUnit.Location = new System.Drawing.Point(293, 51);
            this.MoneyUnit.Name = "MoneyUnit";
            this.MoneyUnit.Size = new System.Drawing.Size(75, 19);
            this.MoneyUnit.TabIndex = 124;
            this.MoneyUnit.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(217, 54);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 123;
            this.label26.Text = "金額単位";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(218, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 12);
            this.label27.TabIndex = 126;
            this.label27.Text = "発行タイプ";
            // 
            // PrintType
            // 
            this.PrintType.Location = new System.Drawing.Point(293, 73);
            this.PrintType.Name = "PrintType";
            this.PrintType.Size = new System.Drawing.Size(75, 19);
            this.PrintType.TabIndex = 127;
            this.PrintType.Text = "0";
            // 
            // TotalWay
            // 
            this.TotalWay.Location = new System.Drawing.Point(293, 6);
            this.TotalWay.Name = "TotalWay";
            this.TotalWay.Size = new System.Drawing.Size(75, 19);
            this.TotalWay.TabIndex = 129;
            this.TotalWay.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(218, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 12);
            this.label28.TabIndex = 128;
            this.label28.Text = "集計方法";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(374, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 12);
            this.label29.TabIndex = 130;
            this.label29.Text = "0：全社 1:拠点毎";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.TotalWay);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.PrintType);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.MoneyUnit);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.Ed_YearSalesRatio);
            this.Controls.Add(this.St_YearSalesRatio);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.Ed_MonthGrossRatio);
            this.Controls.Add(this.St_MonthGrossRatio);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.Ed_YearGrossRatio);
            this.Controls.Add(this.St_YearGrossRatio);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Ed_MonthSalesRatio);
            this.Controls.Add(this.St_MonthSalesRatio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Ed_SalesAreaCode);
            this.Controls.Add(this.St_SalesAreaCode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Ed_BusinessTypeCode);
            this.Controls.Add(this.St_BusinessTypeCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Ed_CustomerCode);
            this.Controls.Add(this.St_CustomerCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Ed_EmployeeCode);
            this.Controls.Add(this.St_EmployeeCode);
            this.Controls.Add(this.Ed_MinSectionCode);
            this.Controls.Add(this.Ed_SubSectionCode);
            this.Controls.Add(this.St_MinSectionCode);
            this.Controls.Add(this.St_SubSectionCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ListType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Ed_AddUpSecCode);
            this.Controls.Add(this.St_AddUpSecCode);
            this.Controls.Add(this.Ed_AddUpYearMonth);
            this.Controls.Add(this.St_AddUpYearMonth);
            this.Controls.Add(this.SecCode2);
            this.Controls.Add(this.SecCode1);
            this.Controls.Add(this.SecCode0);
            this.Controls.Add(this.label2);
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
            IprevYearComparisonDB = MediationPrevYearComparisonDB.GetPrevYearComparisonDB();
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
            ExtrInfo_PrevYearComparisonWork work = new ExtrInfo_PrevYearComparisonWork();

            work.EnterpriseCode = "0101150842020000";
            work.secCodeList = new string[] { "82" };
            //集計方法
            work.TotalWay = Int32.Parse(TotalWay.Text);

            //帳票タイプ
            work.ListType = Int32.Parse(ListType.Text);

            //金額単位
            work.MoneyUnit = Int32.Parse(MoneyUnit.Text);
            
            //発行タイプ
            work.printType = Int32.Parse(PrintType.Text);

            work.St_AddUpYearMonth = 200712;
            work.Ed_AddUpYearMonth = 200712;

            work.St_MonthSalesRatio = 0.0;
            work.Ed_MonthSalesRatio = 20.0;
            work.St_MonthGrossRatio = 0.0;
            work.Ed_MonthGrossRatio = 20.0;

            work.St_CustomerCode = 0;
            work.Ed_CustomerCode = 0;
            work.St_EmployeeCode = "";
            work.Ed_EmployeeCode = "";
            work.St_BLGoodsCode = 0;
            work.Ed_BLGoodsCode = 0;
            work.St_GoodsLGroup = 0;
            work.Ed_GoodsLGroup = 0;
            work.St_GoodsMGroup = 0;
            work.Ed_GoodsMGroup = 0;
            work.St_BLGroupCode = 0;
            work.Ed_BLGroupCode = 0;
            work.St_SalesAreaCode = 0;
            work.Ed_SalesAreaCode = 0;
            work.St_BusinessTypeCode = 0;
            work.Ed_BusinessTypeCode = 0;

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
            //ExtrInfo_PrevYearComparisonWork work = new ExtrInfo_PrevYearComparisonWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            try
            {
                int status = IprevYearComparisonDB.SearchPrevYearComparison(out retObj, workObj);
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
            ExtrInfo_PrevYearComparisonWork extrInfo_DemandTotalWork = new ExtrInfo_PrevYearComparisonWork();
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

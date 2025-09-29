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
using Broadleaf.Library.Resources;

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

        private ISalHisRefDB IsalHisRefDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private TextBox SectionCode;
        private Label label2;
        private Label label1;
        private TextBox EnterpriseCode;
        private TextBox CustomerCode;
        private Label label3;
        private TextBox SalesDateSt;
        private Label label4;
        private TextBox SalesDateEd;
        private Label label5;
        private TextBox GoodsNo;
        private Label label6;
        private TextBox GoodsMakerCd;
        private Label label7;
        private TextBox SalesSlipNumSt;
        private Label label8;
        private TextBox ClaimCode;
        private Label label9;
        private TextBox OrderNumber;
        private Label label10;
        private Label label11;
        private TextBox GoodsName;
        private Label label12;
        private TextBox FrontEmployeeCd;
        private Label label13;
        private TextBox SalesEmployeeCd;
        private Label label14;
        private TextBox SalesInputCode;
        private Label label15;
        private CheckBox GoodsNmVagueSrch;
        private Button button1;
        private TextBox searchCount;
        private Label label16;
        private TextBox LogicalMode;
        private Label label17;
        private TextBox SalesSlipNumEd;
        private TextBox SubSectionCode;
        private TextBox MinSectionCode;
        private TextBox SearchSlipDateEd;
        private Label label18;
        private TextBox SearchSlipDateSt;
        private Label label19;
        private Label label20;
        private TextBox AccRecDivCd;
        private TextBox SalesSlipCd;
        private Label label21;
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
            this.SectionCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.CustomerCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SalesDateSt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SalesDateEd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GoodsNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GoodsMakerCd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SalesSlipNumSt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ClaimCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.OrderNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.GoodsName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FrontEmployeeCd = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SalesEmployeeCd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SalesInputCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.GoodsNmVagueSrch = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.searchCount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.LogicalMode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SalesSlipNumEd = new System.Windows.Forms.TextBox();
            this.SubSectionCode = new System.Windows.Forms.TextBox();
            this.MinSectionCode = new System.Windows.Forms.TextBox();
            this.SearchSlipDateEd = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.SearchSlipDateSt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.AccRecDivCd = new System.Windows.Forms.TextBox();
            this.SalesSlipCd = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
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
            this.button8.Text = "Search";
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
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 341);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // SectionCode
            // 
            this.SectionCode.Location = new System.Drawing.Point(117, 31);
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.Size = new System.Drawing.Size(115, 19);
            this.SectionCode.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 34);
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
            this.EnterpriseCode.Location = new System.Drawing.Point(117, 6);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 69;
            this.EnterpriseCode.Text = "0101150842020000";
            // 
            // CustomerCode
            // 
            this.CustomerCode.Location = new System.Drawing.Point(117, 54);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(115, 19);
            this.CustomerCode.TabIndex = 74;
            this.CustomerCode.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 73;
            this.label3.Text = "得意先コード";
            // 
            // SalesDateSt
            // 
            this.SalesDateSt.Location = new System.Drawing.Point(117, 78);
            this.SalesDateSt.Name = "SalesDateSt";
            this.SalesDateSt.Size = new System.Drawing.Size(115, 19);
            this.SalesDateSt.TabIndex = 76;
            this.SalesDateSt.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 75;
            this.label4.Text = "売上日";
            // 
            // SalesDateEd
            // 
            this.SalesDateEd.Location = new System.Drawing.Point(252, 78);
            this.SalesDateEd.Name = "SalesDateEd";
            this.SalesDateEd.Size = new System.Drawing.Size(115, 19);
            this.SalesDateEd.TabIndex = 78;
            this.SalesDateEd.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 77;
            this.label5.Text = "～";
            // 
            // GoodsNo
            // 
            this.GoodsNo.Location = new System.Drawing.Point(117, 102);
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.Size = new System.Drawing.Size(115, 19);
            this.GoodsNo.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 79;
            this.label6.Text = "商品番号";
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Location = new System.Drawing.Point(117, 127);
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.Size = new System.Drawing.Size(115, 19);
            this.GoodsMakerCd.TabIndex = 82;
            this.GoodsMakerCd.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 81;
            this.label7.Text = "商品メーカーコード";
            // 
            // SalesSlipNumSt
            // 
            this.SalesSlipNumSt.Location = new System.Drawing.Point(117, 152);
            this.SalesSlipNumSt.Name = "SalesSlipNumSt";
            this.SalesSlipNumSt.Size = new System.Drawing.Size(115, 19);
            this.SalesSlipNumSt.TabIndex = 84;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 83;
            this.label8.Text = "売上伝票番号";
            // 
            // ClaimCode
            // 
            this.ClaimCode.Location = new System.Drawing.Point(117, 177);
            this.ClaimCode.Name = "ClaimCode";
            this.ClaimCode.Size = new System.Drawing.Size(115, 19);
            this.ClaimCode.TabIndex = 86;
            this.ClaimCode.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 12);
            this.label9.TabIndex = 85;
            this.label9.Text = "請求先コード";
            // 
            // OrderNumber
            // 
            this.OrderNumber.Location = new System.Drawing.Point(546, 6);
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Size = new System.Drawing.Size(115, 19);
            this.OrderNumber.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(409, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 87;
            this.label10.Text = "相手先注文番号";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 12);
            this.label11.TabIndex = 89;
            this.label11.Text = "商品名称曖昧検索フラグ";
            // 
            // GoodsName
            // 
            this.GoodsName.Location = new System.Drawing.Point(546, 54);
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Size = new System.Drawing.Size(115, 19);
            this.GoodsName.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(409, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 91;
            this.label12.Text = "商品名称";
            // 
            // FrontEmployeeCd
            // 
            this.FrontEmployeeCd.Location = new System.Drawing.Point(546, 77);
            this.FrontEmployeeCd.Name = "FrontEmployeeCd";
            this.FrontEmployeeCd.Size = new System.Drawing.Size(115, 19);
            this.FrontEmployeeCd.TabIndex = 94;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(409, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 12);
            this.label13.TabIndex = 93;
            this.label13.Text = "受付従業員コード";
            // 
            // SalesEmployeeCd
            // 
            this.SalesEmployeeCd.Location = new System.Drawing.Point(546, 102);
            this.SalesEmployeeCd.Name = "SalesEmployeeCd";
            this.SalesEmployeeCd.Size = new System.Drawing.Size(115, 19);
            this.SalesEmployeeCd.TabIndex = 96;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(409, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 12);
            this.label14.TabIndex = 95;
            this.label14.Text = "販売従業員コード";
            // 
            // SalesInputCode
            // 
            this.SalesInputCode.Location = new System.Drawing.Point(546, 127);
            this.SalesInputCode.Name = "SalesInputCode";
            this.SalesInputCode.Size = new System.Drawing.Size(115, 19);
            this.SalesInputCode.TabIndex = 98;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(409, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 12);
            this.label15.TabIndex = 97;
            this.label15.Text = "入力担当者コード";
            // 
            // GoodsNmVagueSrch
            // 
            this.GoodsNmVagueSrch.AutoSize = true;
            this.GoodsNmVagueSrch.Location = new System.Drawing.Point(546, 33);
            this.GoodsNmVagueSrch.Name = "GoodsNmVagueSrch";
            this.GoodsNmVagueSrch.Size = new System.Drawing.Size(140, 16);
            this.GoodsNmVagueSrch.TabIndex = 99;
            this.GoodsNmVagueSrch.Text = "チェック有りだと曖昧検索";
            this.GoodsNmVagueSrch.UseVisualStyleBackColor = true;
            this.GoodsNmVagueSrch.CheckedChanged += new System.EventHandler(this.goodsNmVagueSrch_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "TopSearch";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // searchCount
            // 
            this.searchCount.Location = new System.Drawing.Point(373, 343);
            this.searchCount.Name = "searchCount";
            this.searchCount.Size = new System.Drawing.Size(44, 19);
            this.searchCount.TabIndex = 101;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 312;
            this.label16.Text = "論理削除区分";
            // 
            // LogicalMode
            // 
            this.LogicalMode.Location = new System.Drawing.Point(117, 202);
            this.LogicalMode.Name = "LogicalMode";
            this.LogicalMode.Size = new System.Drawing.Size(115, 19);
            this.LogicalMode.TabIndex = 311;
            this.LogicalMode.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(233, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 313;
            this.label17.Text = "～";
            // 
            // SalesSlipNumEd
            // 
            this.SalesSlipNumEd.Location = new System.Drawing.Point(252, 152);
            this.SalesSlipNumEd.Name = "SalesSlipNumEd";
            this.SalesSlipNumEd.Size = new System.Drawing.Size(115, 19);
            this.SalesSlipNumEd.TabIndex = 314;
            this.SalesSlipNumEd.TextChanged += new System.EventHandler(this.salesSlipNumEd_TextChanged);
            // 
            // SubSectionCode
            // 
            this.SubSectionCode.Location = new System.Drawing.Point(235, 31);
            this.SubSectionCode.Name = "SubSectionCode";
            this.SubSectionCode.Size = new System.Drawing.Size(59, 19);
            this.SubSectionCode.TabIndex = 315;
            this.SubSectionCode.Text = "0";
            // 
            // MinSectionCode
            // 
            this.MinSectionCode.Location = new System.Drawing.Point(300, 30);
            this.MinSectionCode.Name = "MinSectionCode";
            this.MinSectionCode.Size = new System.Drawing.Size(59, 19);
            this.MinSectionCode.TabIndex = 316;
            this.MinSectionCode.Text = "0";
            // 
            // SearchSlipDateEd
            // 
            this.SearchSlipDateEd.Location = new System.Drawing.Point(681, 152);
            this.SearchSlipDateEd.Name = "SearchSlipDateEd";
            this.SearchSlipDateEd.Size = new System.Drawing.Size(115, 19);
            this.SearchSlipDateEd.TabIndex = 320;
            this.SearchSlipDateEd.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(662, 155);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 319;
            this.label18.Text = "～";
            // 
            // SearchSlipDateSt
            // 
            this.SearchSlipDateSt.Location = new System.Drawing.Point(546, 152);
            this.SearchSlipDateSt.Name = "SearchSlipDateSt";
            this.SearchSlipDateSt.Size = new System.Drawing.Size(115, 19);
            this.SearchSlipDateSt.TabIndex = 318;
            this.SearchSlipDateSt.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(409, 155);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 317;
            this.label19.Text = "入力日";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(409, 205);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 324;
            this.label20.Text = "売掛区分";
            // 
            // AccRecDivCd
            // 
            this.AccRecDivCd.Location = new System.Drawing.Point(546, 202);
            this.AccRecDivCd.Name = "AccRecDivCd";
            this.AccRecDivCd.Size = new System.Drawing.Size(115, 19);
            this.AccRecDivCd.TabIndex = 323;
            this.AccRecDivCd.Text = "0";
            // 
            // SalesSlipCd
            // 
            this.SalesSlipCd.Location = new System.Drawing.Point(546, 177);
            this.SalesSlipCd.Name = "SalesSlipCd";
            this.SalesSlipCd.Size = new System.Drawing.Size(115, 19);
            this.SalesSlipCd.TabIndex = 322;
            this.SalesSlipCd.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(409, 180);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 321;
            this.label21.Text = "売上伝票区分";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.AccRecDivCd);
            this.Controls.Add(this.SalesSlipCd);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.SearchSlipDateEd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.SearchSlipDateSt);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.MinSectionCode);
            this.Controls.Add(this.SubSectionCode);
            this.Controls.Add(this.SalesSlipNumEd);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.LogicalMode);
            this.Controls.Add(this.searchCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GoodsNmVagueSrch);
            this.Controls.Add(this.SalesInputCode);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.SalesEmployeeCd);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.FrontEmployeeCd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.GoodsName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.OrderNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ClaimCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SalesSlipNumSt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GoodsMakerCd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GoodsNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SalesDateEd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SalesDateSt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SectionCode);
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
            IsalHisRefDB = MediationSalHisRefDB.GetSalHisRefDB();
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
            SalHisRefExtraParamWork work = new SalHisRefExtraParamWork();

            work.EnterpriseCode = EnterpriseCode.Text;
            work.SectionCode = SectionCode.Text;
            work.SubSectionCode = Convert.ToInt32(SubSectionCode.Text);
            //work.MinSectionCode = Convert.ToInt32(MinSectionCode.Text);
            work.CustomerCode = Convert.ToInt32(CustomerCode.Text);
            work.SalesDateSt = Convert.ToInt32(SalesDateSt.Text);
            work.SalesDateEd = Convert.ToInt32(SalesDateEd.Text);
            work.GoodsNo = GoodsNo.Text;
            work.GoodsMakerCd = Convert.ToInt32(GoodsMakerCd.Text);
            work.SalesSlipNumSt = SalesSlipNumSt.Text;
            work.SalesSlipNumEd = SalesSlipNumEd.Text;
            work.ClaimCode = Convert.ToInt32(ClaimCode.Text);
            //work.OrderNumber = OrderNumber.Text;
            //work.GoodsNmVagueSrch = GoodsNmVagueSrch.Checked;
            work.GoodsName = GoodsName.Text;
            work.FrontEmployeeCd = FrontEmployeeCd.Text;
            work.SalesEmployeeCd = SalesEmployeeCd.Text;
            work.SalesInputCode = SalesInputCode.Text;
            work.SearchSlipDateSt = Convert.ToInt32(SearchSlipDateSt.Text);
            work.SearchSlipDateEd = Convert.ToInt32(SearchSlipDateEd.Text);
            work.SalesSlipCd = Convert.ToInt32(SalesSlipCd.Text);
            work.AccRecDivCd = Convert.ToInt32(AccRecDivCd.Text);

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

            ArrayList al = new ArrayList();
            al = (ArrayList)dataGrid2.DataSource;

			object paraObj = al[0];
			object retObj = null;
            //SalHisRefExtraParamWork work = new SalHisRefExtraParamWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            try
            {
                int status = IsalHisRefDB.Search(out retObj, workObj, 0, (ConstantManagement.LogicalMode)Convert.ToInt32(LogicalMode.Text));
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
            SalHisRefExtraParamWork extrInfo_DemandTotalWork = new SalHisRefExtraParamWork();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            button9_Click(sender, e);

            ArrayList al = new ArrayList();
            al = (ArrayList)dataGrid2.DataSource;

            object paraObj = al[0];
            object retObj = null;
            //SalHisRefExtraParamWork work = new SalHisRefExtraParamWork();
            //object workObj = (object)work;
            object workObj = paraObj;

            try
            {
                Int32 totalCnt = 0;
                bool nextData = false;
                int status = 0;
                //status = IsalHisRefDB.TopSearch(out retObj, workObj, out totalCnt, out nextData, Convert.ToInt32(searchCount.Text), 0, (ConstantManagement.LogicalMode)Convert.ToInt32(LogicalMode.Text));
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

        private void salesSlipNumEd_TextChanged(object sender, EventArgs e)
        {

        }

        private void goodsNmVagueSrch_CheckedChanged(object sender, EventArgs e)
        {

        }


	}
}

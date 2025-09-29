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

        //private OrderConfShWork _salesOrderWork = null;

        //private OrderConfShWork _prevSalesConfShWork = null;
        private System.Windows.Forms.Button button8;

        private IOrderConfDB IOrderConfDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox SectionCode1;
        private TextBox SectionCode2;
        private TextBox SectionCode3;
        private Label label1;
        private Label label2;
        private CheckBox IsOutputAllSecRec;
        private CheckBox IsSelectAllSection;
        private TextBox SalesDateSt;
        private TextBox SalesDateEd;
        private Label label5;
        private Label label6;
        private Label label4;
        private Label label7;
        private TextBox ShipmentDaySt;
        private TextBox ShipmentDayEd;
        private Label label18;
        private Label label19;
        private TextBox SalesEmployeeCdSt;
        private TextBox SalesEmployeeCdEd;
        private Label label20;
        private Label label21;
        private TextBox SalesSlipNumSt;
        private TextBox SalesSlipNumEd;
        private Label label23;
        private Label label24;
        private TextBox CustomerCodeSt;
        private TextBox CustomerCodeEd;
        private Label label25;
        private TextBox DebitNoteDiv;
        private Label label26;
        private TextBox SalesSlipCd;
        private Label label3;
        private TextBox LogicalDeleteCode;
        private Label label8;
        private Label label9;
        private TextBox SearchSlipDateSt;
        private TextBox SearchSlipDateEd;
        private Label label10;
        private Label label11;
        private TextBox FrontEmployeeCdSt;
        private TextBox FrontEmployeeCdEd;
        private Label label12;
        private Label label13;
        private TextBox SalesInputCodeSt;
        private TextBox SalesInputCodeEd;
        private Label label14;
        private TextBox GrsProfitCheckLower;
        private TextBox GrsProfitCheckBest;
        private TextBox GrsProfitCheckUpper;
        private TextBox GrossMargin1Mark;
        private TextBox GrossMargin2Mark;
        private TextBox GrossMargin3Mark;
        private TextBox GrossMargin4Mark;
        private Label label15;
        private TextBox PrintMode;
        private Label label16;
        private TextBox AcptAnOdrStatus;
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
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
            this.SectionCode1 = new System.Windows.Forms.TextBox();
            this.SectionCode2 = new System.Windows.Forms.TextBox();
            this.SectionCode3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IsOutputAllSecRec = new System.Windows.Forms.CheckBox();
            this.IsSelectAllSection = new System.Windows.Forms.CheckBox();
            this.SalesDateSt = new System.Windows.Forms.TextBox();
            this.SalesDateEd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ShipmentDaySt = new System.Windows.Forms.TextBox();
            this.ShipmentDayEd = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SalesEmployeeCdSt = new System.Windows.Forms.TextBox();
            this.SalesEmployeeCdEd = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SalesSlipNumSt = new System.Windows.Forms.TextBox();
            this.SalesSlipNumEd = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.CustomerCodeSt = new System.Windows.Forms.TextBox();
            this.CustomerCodeEd = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.DebitNoteDiv = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.SalesSlipCd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LogicalDeleteCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SearchSlipDateSt = new System.Windows.Forms.TextBox();
            this.SearchSlipDateEd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.FrontEmployeeCdSt = new System.Windows.Forms.TextBox();
            this.FrontEmployeeCdEd = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SalesInputCodeSt = new System.Windows.Forms.TextBox();
            this.SalesInputCodeEd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.GrsProfitCheckLower = new System.Windows.Forms.TextBox();
            this.GrsProfitCheckBest = new System.Windows.Forms.TextBox();
            this.GrsProfitCheckUpper = new System.Windows.Forms.TextBox();
            this.GrossMargin1Mark = new System.Windows.Forms.TextBox();
            this.GrossMargin2Mark = new System.Windows.Forms.TextBox();
            this.GrossMargin3Mark = new System.Windows.Forms.TextBox();
            this.GrossMargin4Mark = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PrintMode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.AcptAnOdrStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(88, 19);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 1;
            this.EnterpriseCode.Text = "0113180842031000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 395);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 141);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(800, 366);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 357);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "売上確認表";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 280);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 71);
            this.dataGrid2.TabIndex = 39;
            // 
            // SectionCode1
            // 
            this.SectionCode1.Location = new System.Drawing.Point(88, 44);
            this.SectionCode1.Name = "SectionCode1";
            this.SectionCode1.Size = new System.Drawing.Size(146, 19);
            this.SectionCode1.TabIndex = 40;
            // 
            // SectionCode2
            // 
            this.SectionCode2.Location = new System.Drawing.Point(240, 44);
            this.SectionCode2.Name = "SectionCode2";
            this.SectionCode2.Size = new System.Drawing.Size(146, 19);
            this.SectionCode2.TabIndex = 41;
            // 
            // SectionCode3
            // 
            this.SectionCode3.Location = new System.Drawing.Point(392, 44);
            this.SectionCode3.Name = "SectionCode3";
            this.SectionCode3.Size = new System.Drawing.Size(146, 19);
            this.SectionCode3.TabIndex = 42;
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
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "拠点コード";
            // 
            // IsOutputAllSecRec
            // 
            this.IsOutputAllSecRec.AutoSize = true;
            this.IsOutputAllSecRec.Location = new System.Drawing.Point(209, 21);
            this.IsOutputAllSecRec.Name = "IsOutputAllSecRec";
            this.IsOutputAllSecRec.Size = new System.Drawing.Size(72, 16);
            this.IsOutputAllSecRec.TabIndex = 45;
            this.IsOutputAllSecRec.Text = "全社選択";
            this.IsOutputAllSecRec.UseVisualStyleBackColor = true;
            // 
            // IsSelectAllSection
            // 
            this.IsSelectAllSection.AutoSize = true;
            this.IsSelectAllSection.Location = new System.Drawing.Point(286, 21);
            this.IsSelectAllSection.Name = "IsSelectAllSection";
            this.IsSelectAllSection.Size = new System.Drawing.Size(120, 16);
            this.IsSelectAllSection.TabIndex = 46;
            this.IsSelectAllSection.Text = "全拠点レコード出力";
            this.IsSelectAllSection.UseVisualStyleBackColor = true;
            // 
            // SalesDateSt
            // 
            this.SalesDateSt.Location = new System.Drawing.Point(88, 69);
            this.SalesDateSt.Name = "SalesDateSt";
            this.SalesDateSt.Size = new System.Drawing.Size(146, 19);
            this.SalesDateSt.TabIndex = 52;
            this.SalesDateSt.Text = "20010101";
            // 
            // SalesDateEd
            // 
            this.SalesDateEd.Location = new System.Drawing.Point(263, 69);
            this.SalesDateEd.Name = "SalesDateEd";
            this.SalesDateEd.Size = new System.Drawing.Size(146, 19);
            this.SalesDateEd.TabIndex = 53;
            this.SalesDateEd.Text = "20091231";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 55;
            this.label5.Text = "売上日付";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 60;
            this.label4.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 59;
            this.label7.Text = "出荷日付";
            // 
            // ShipmentDaySt
            // 
            this.ShipmentDaySt.Location = new System.Drawing.Point(88, 94);
            this.ShipmentDaySt.Name = "ShipmentDaySt";
            this.ShipmentDaySt.Size = new System.Drawing.Size(146, 19);
            this.ShipmentDaySt.TabIndex = 58;
            this.ShipmentDaySt.Text = "20010101";
            // 
            // ShipmentDayEd
            // 
            this.ShipmentDayEd.Location = new System.Drawing.Point(263, 94);
            this.ShipmentDayEd.Name = "ShipmentDayEd";
            this.ShipmentDayEd.Size = new System.Drawing.Size(146, 19);
            this.ShipmentDayEd.TabIndex = 57;
            this.ShipmentDayEd.Text = "20091231";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(240, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 85;
            this.label18.Text = "～";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 196);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 84;
            this.label19.Text = "販売従業員";
            // 
            // SalesEmployeeCdSt
            // 
            this.SalesEmployeeCdSt.Location = new System.Drawing.Point(88, 193);
            this.SalesEmployeeCdSt.Name = "SalesEmployeeCdSt";
            this.SalesEmployeeCdSt.Size = new System.Drawing.Size(146, 19);
            this.SalesEmployeeCdSt.TabIndex = 83;
            // 
            // SalesEmployeeCdEd
            // 
            this.SalesEmployeeCdEd.Location = new System.Drawing.Point(263, 193);
            this.SalesEmployeeCdEd.Name = "SalesEmployeeCdEd";
            this.SalesEmployeeCdEd.Size = new System.Drawing.Size(146, 19);
            this.SalesEmployeeCdEd.TabIndex = 82;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(240, 171);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 89;
            this.label20.Text = "～";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 171);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 88;
            this.label21.Text = "伝票番号";
            // 
            // SalesSlipNumSt
            // 
            this.SalesSlipNumSt.Location = new System.Drawing.Point(88, 168);
            this.SalesSlipNumSt.Name = "SalesSlipNumSt";
            this.SalesSlipNumSt.Size = new System.Drawing.Size(146, 19);
            this.SalesSlipNumSt.TabIndex = 87;
            // 
            // SalesSlipNumEd
            // 
            this.SalesSlipNumEd.Location = new System.Drawing.Point(263, 168);
            this.SalesSlipNumEd.Name = "SalesSlipNumEd";
            this.SalesSlipNumEd.Size = new System.Drawing.Size(146, 19);
            this.SalesSlipNumEd.TabIndex = 86;
            this.SalesSlipNumEd.TextChanged += new System.EventHandler(this.textBox25_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(240, 147);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 97;
            this.label23.Text = "～";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 148);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 96;
            this.label24.Text = "得意先";
            // 
            // CustomerCodeSt
            // 
            this.CustomerCodeSt.Location = new System.Drawing.Point(88, 144);
            this.CustomerCodeSt.Name = "CustomerCodeSt";
            this.CustomerCodeSt.Size = new System.Drawing.Size(146, 19);
            this.CustomerCodeSt.TabIndex = 95;
            // 
            // CustomerCodeEd
            // 
            this.CustomerCodeEd.Location = new System.Drawing.Point(263, 144);
            this.CustomerCodeEd.Name = "CustomerCodeEd";
            this.CustomerCodeEd.Size = new System.Drawing.Size(146, 19);
            this.CustomerCodeEd.TabIndex = 94;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(425, 97);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 99;
            this.label25.Text = "赤伝区分";
            // 
            // DebitNoteDiv
            // 
            this.DebitNoteDiv.Location = new System.Drawing.Point(508, 94);
            this.DebitNoteDiv.Name = "DebitNoteDiv";
            this.DebitNoteDiv.Size = new System.Drawing.Size(41, 19);
            this.DebitNoteDiv.TabIndex = 98;
            this.DebitNoteDiv.Text = "-1";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(425, 122);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 12);
            this.label26.TabIndex = 101;
            this.label26.Text = "売上伝票区分";
            // 
            // SalesSlipCd
            // 
            this.SalesSlipCd.Location = new System.Drawing.Point(508, 119);
            this.SalesSlipCd.Name = "SalesSlipCd";
            this.SalesSlipCd.Size = new System.Drawing.Size(41, 19);
            this.SalesSlipCd.TabIndex = 100;
            this.SalesSlipCd.Text = "-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 103;
            this.label3.Text = "論理削除区分";
            // 
            // LogicalDeleteCode
            // 
            this.LogicalDeleteCode.Location = new System.Drawing.Point(508, 69);
            this.LogicalDeleteCode.Name = "LogicalDeleteCode";
            this.LogicalDeleteCode.Size = new System.Drawing.Size(41, 19);
            this.LogicalDeleteCode.TabIndex = 102;
            this.LogicalDeleteCode.Text = "-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 107;
            this.label8.Text = "～";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 106;
            this.label9.Text = "入力日付";
            // 
            // SearchSlipDateSt
            // 
            this.SearchSlipDateSt.Location = new System.Drawing.Point(88, 119);
            this.SearchSlipDateSt.Name = "SearchSlipDateSt";
            this.SearchSlipDateSt.Size = new System.Drawing.Size(146, 19);
            this.SearchSlipDateSt.TabIndex = 105;
            this.SearchSlipDateSt.Text = "20010101";
            // 
            // SearchSlipDateEd
            // 
            this.SearchSlipDateEd.Location = new System.Drawing.Point(263, 119);
            this.SearchSlipDateEd.Name = "SearchSlipDateEd";
            this.SearchSlipDateEd.Size = new System.Drawing.Size(146, 19);
            this.SearchSlipDateEd.TabIndex = 104;
            this.SearchSlipDateEd.Text = "20091231";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 111;
            this.label10.Text = "～";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 110;
            this.label11.Text = "受付従業員";
            // 
            // FrontEmployeeCdSt
            // 
            this.FrontEmployeeCdSt.Location = new System.Drawing.Point(88, 218);
            this.FrontEmployeeCdSt.Name = "FrontEmployeeCdSt";
            this.FrontEmployeeCdSt.Size = new System.Drawing.Size(146, 19);
            this.FrontEmployeeCdSt.TabIndex = 109;
            // 
            // FrontEmployeeCdEd
            // 
            this.FrontEmployeeCdEd.Location = new System.Drawing.Point(263, 218);
            this.FrontEmployeeCdEd.Name = "FrontEmployeeCdEd";
            this.FrontEmployeeCdEd.Size = new System.Drawing.Size(146, 19);
            this.FrontEmployeeCdEd.TabIndex = 108;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 115;
            this.label12.Text = "～";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 246);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 114;
            this.label13.Text = "入力担当者";
            // 
            // SalesInputCodeSt
            // 
            this.SalesInputCodeSt.Location = new System.Drawing.Point(88, 243);
            this.SalesInputCodeSt.Name = "SalesInputCodeSt";
            this.SalesInputCodeSt.Size = new System.Drawing.Size(146, 19);
            this.SalesInputCodeSt.TabIndex = 113;
            // 
            // SalesInputCodeEd
            // 
            this.SalesInputCodeEd.Location = new System.Drawing.Point(263, 243);
            this.SalesInputCodeEd.Name = "SalesInputCodeEd";
            this.SalesInputCodeEd.Size = new System.Drawing.Size(146, 19);
            this.SalesInputCodeEd.TabIndex = 112;
            this.SalesInputCodeEd.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(425, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 12);
            this.label14.TabIndex = 116;
            this.label14.Text = "粗利チェック";
            // 
            // GrsProfitCheckLower
            // 
            this.GrsProfitCheckLower.Location = new System.Drawing.Point(508, 168);
            this.GrsProfitCheckLower.Name = "GrsProfitCheckLower";
            this.GrsProfitCheckLower.Size = new System.Drawing.Size(41, 19);
            this.GrsProfitCheckLower.TabIndex = 117;
            this.GrsProfitCheckLower.Text = "10";
            // 
            // GrsProfitCheckBest
            // 
            this.GrsProfitCheckBest.Location = new System.Drawing.Point(508, 193);
            this.GrsProfitCheckBest.Name = "GrsProfitCheckBest";
            this.GrsProfitCheckBest.Size = new System.Drawing.Size(41, 19);
            this.GrsProfitCheckBest.TabIndex = 118;
            this.GrsProfitCheckBest.Text = "15";
            // 
            // GrsProfitCheckUpper
            // 
            this.GrsProfitCheckUpper.Location = new System.Drawing.Point(508, 218);
            this.GrsProfitCheckUpper.Name = "GrsProfitCheckUpper";
            this.GrsProfitCheckUpper.Size = new System.Drawing.Size(41, 19);
            this.GrsProfitCheckUpper.TabIndex = 119;
            this.GrsProfitCheckUpper.Text = "30";
            // 
            // GrossMargin1Mark
            // 
            this.GrossMargin1Mark.Location = new System.Drawing.Point(564, 168);
            this.GrossMargin1Mark.Name = "GrossMargin1Mark";
            this.GrossMargin1Mark.Size = new System.Drawing.Size(41, 19);
            this.GrossMargin1Mark.TabIndex = 120;
            this.GrossMargin1Mark.Text = "無";
            // 
            // GrossMargin2Mark
            // 
            this.GrossMargin2Mark.Location = new System.Drawing.Point(564, 193);
            this.GrossMargin2Mark.Name = "GrossMargin2Mark";
            this.GrossMargin2Mark.Size = new System.Drawing.Size(41, 19);
            this.GrossMargin2Mark.TabIndex = 121;
            this.GrossMargin2Mark.Text = "低";
            // 
            // GrossMargin3Mark
            // 
            this.GrossMargin3Mark.Location = new System.Drawing.Point(564, 218);
            this.GrossMargin3Mark.Name = "GrossMargin3Mark";
            this.GrossMargin3Mark.Size = new System.Drawing.Size(41, 19);
            this.GrossMargin3Mark.TabIndex = 122;
            this.GrossMargin3Mark.Text = "中";
            // 
            // GrossMargin4Mark
            // 
            this.GrossMargin4Mark.Location = new System.Drawing.Point(564, 243);
            this.GrossMargin4Mark.Name = "GrossMargin4Mark";
            this.GrossMargin4Mark.Size = new System.Drawing.Size(41, 19);
            this.GrossMargin4Mark.TabIndex = 123;
            this.GrossMargin4Mark.Text = "高";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(636, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 12);
            this.label15.TabIndex = 125;
            this.label15.Text = "帳票タイプ";
            // 
            // PrintMode
            // 
            this.PrintMode.Location = new System.Drawing.Point(719, 69);
            this.PrintMode.Name = "PrintMode";
            this.PrintMode.Size = new System.Drawing.Size(41, 19);
            this.PrintMode.TabIndex = 124;
            this.PrintMode.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(636, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 12);
            this.label16.TabIndex = 127;
            this.label16.Text = "受注Status";
            // 
            // AcptAnOdrStatus
            // 
            this.AcptAnOdrStatus.Location = new System.Drawing.Point(719, 44);
            this.AcptAnOdrStatus.Name = "AcptAnOdrStatus";
            this.AcptAnOdrStatus.Size = new System.Drawing.Size(41, 19);
            this.AcptAnOdrStatus.TabIndex = 126;
            this.AcptAnOdrStatus.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.AcptAnOdrStatus);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.PrintMode);
            this.Controls.Add(this.GrossMargin4Mark);
            this.Controls.Add(this.GrossMargin3Mark);
            this.Controls.Add(this.GrossMargin2Mark);
            this.Controls.Add(this.GrossMargin1Mark);
            this.Controls.Add(this.GrsProfitCheckUpper);
            this.Controls.Add(this.GrsProfitCheckBest);
            this.Controls.Add(this.GrsProfitCheckLower);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SalesInputCodeSt);
            this.Controls.Add(this.SalesInputCodeEd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FrontEmployeeCdSt);
            this.Controls.Add(this.FrontEmployeeCdEd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SearchSlipDateSt);
            this.Controls.Add(this.SearchSlipDateEd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LogicalDeleteCode);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.SalesSlipCd);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.DebitNoteDiv);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.CustomerCodeSt);
            this.Controls.Add(this.CustomerCodeEd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.SalesSlipNumSt);
            this.Controls.Add(this.SalesSlipNumEd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.SalesEmployeeCdSt);
            this.Controls.Add(this.SalesEmployeeCdEd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ShipmentDaySt);
            this.Controls.Add(this.ShipmentDayEd);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SalesDateEd);
            this.Controls.Add(this.SalesDateSt);
            this.Controls.Add(this.IsSelectAllSection);
            this.Controls.Add(this.IsOutputAllSecRec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SectionCode3);
            this.Controls.Add(this.SectionCode2);
            this.Controls.Add(this.SectionCode1);
            this.Controls.Add(this.dataGrid2);
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
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
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
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IOrderConfDB = MediationOrderConfDB.GetOrderConfDB();
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
            string[] sectionCode = new string[3];

            ArrayList al = new ArrayList();
            OrderConfShWork work = new OrderConfShWork();
            
            work.EnterpriseCode = EnterpriseCode.Text;
            work.AcptAnOdrStatus = Convert.ToInt32(AcptAnOdrStatus.Text);

            sectionCode[0] = SectionCode1.Text;
            sectionCode[1] = SectionCode2.Text;
            sectionCode[2] = SectionCode3.Text;
            work.ResultsAddUpSecList = sectionCode;

            if (SalesDateSt.Text != "") work.SalesDateSt = Convert.ToInt32(SalesDateSt.Text);
            if (SalesDateEd.Text != "") work.SalesDateEd = Convert.ToInt32(SalesDateEd.Text);

            if (ShipmentDaySt.Text != "") work.ShipmentDaySt = Convert.ToInt32(ShipmentDaySt.Text);
            if (ShipmentDayEd.Text != "") work.ShipmentDayEd = Convert.ToInt32(ShipmentDayEd.Text);

            if (SearchSlipDateSt.Text != "") work.SearchSlipDateSt = Convert.ToInt32(SearchSlipDateSt.Text);
            if (SearchSlipDateEd.Text != "") work.SearchSlipDateEd = Convert.ToInt32(SearchSlipDateEd.Text);

            if (CustomerCodeSt.Text != "") work.CustomerCodeSt = Convert.ToInt32(CustomerCodeSt.Text);
            if (CustomerCodeEd.Text != "") work.CustomerCodeEd = Convert.ToInt32(CustomerCodeEd.Text);

            if (SalesSlipNumSt.Text != "") work.SalesSlipNumSt = SalesSlipNumSt.Text;
            if (SalesSlipNumEd.Text != "") work.SalesSlipNumEd = SalesSlipNumEd.Text;

            if (SalesEmployeeCdSt.Text != "") work.SalesEmployeeCdSt = SalesEmployeeCdSt.Text;
            if (SalesEmployeeCdEd.Text != "") work.SalesEmployeeCdEd = SalesEmployeeCdEd.Text;

            if (FrontEmployeeCdSt.Text != "") work.FrontEmployeeCdSt = FrontEmployeeCdSt.Text;
            if (FrontEmployeeCdEd.Text != "") work.FrontEmployeeCdEd = FrontEmployeeCdEd.Text;

            if (SalesInputCodeSt.Text != "") work.SalesInputCodeSt = SalesInputCodeSt.Text;
            if (SalesInputCodeEd.Text != "") work.SalesInputCodeEd = SalesInputCodeEd.Text;

            if (DebitNoteDiv.Text != "") work.DebitNoteDiv = Convert.ToInt32(DebitNoteDiv.Text);
            if (SalesSlipCd.Text != "") work.SalesSlipCd = Convert.ToInt32(SalesSlipCd.Text);
            
            //work.IsSelectAllSection = IsOutputAllSecRec.Checked;
            //work.IsOutputAllSecRec = IsSelectAllSection.Checked;

            work.GrossMargin1Mark = GrossMargin1Mark.Text;
            work.GrossMargin2Mark = GrossMargin2Mark.Text;
            work.GrossMargin3Mark = GrossMargin3Mark.Text;
            work.GrossMargin4Mark = GrossMargin4Mark.Text;
            work.GrsProfitCheckLower = Convert.ToInt32(GrsProfitCheckLower.Text);
            work.GrsProfitCheckBest = Convert.ToInt32(GrsProfitCheckBest.Text);
            work.GrsProfitCheckUpper = Convert.ToInt32(GrsProfitCheckUpper.Text);

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

            object parabyte = dataGrid2.DataSource;
            object objOrder = null;

            Int32 status = -1;
            if (PrintMode.Text == "0")
            {
                status = IOrderConfDB.SearchSlip(out objOrder, parabyte);
            }
            else if (PrintMode.Text == "1")
            {
                status = IOrderConfDB.SearchDetail(out objOrder, parabyte);
            }

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objOrder).Count.ToString() + "件";

                dataGrid1.DataSource = objOrder;
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



    }
}

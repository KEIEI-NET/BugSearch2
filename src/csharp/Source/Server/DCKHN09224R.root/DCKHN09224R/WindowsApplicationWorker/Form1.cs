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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;

        private SalesTtlStWork _salesTtlStWork = null;
        //private SearchSalesTtlStParaWork _searchSalesTtlStParaWork = null;

        //private SalesTtlStWork _prevSalesTtlStWork = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;

        private ISalesTtlStDB IsalesTtlStDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label2;
        private Label label1;
        private TextBox SalesSlipPrtDiv;
        private TextBox EnterpriseCode;
        private Label label3;
        private TextBox ShipmSlipPrtDiv;
        private Label label4;
        private TextBox ZeroPrtDiv;
        private Label label5;
        private TextBox SlipChngDivLPrice;
        private Label label6;
        private TextBox ShipmSlipUnPrcPrtDiv;
        private Label label7;
        private TextBox StockDetailConf;
        private Label label8;
        private TextBox SalesFormalIn;
        private Label label9;
        private TextBox IoGoodsCntDiv;
        private Label label10;
        private TextBox GrsProfitChkLowSign;
        private Label label11;
        private TextBox GrsProfitCheckUpper;
        private Label label12;
        private TextBox GrsProfitCheckBest;
        private Label label13;
        private TextBox GrsProfitCheckLower;
        private Label label14;
        private TextBox ListPriceSelectDiv;
        private Label label15;
        private TextBox RetGoodsStockEtyDiv;
        private Label label16;
        private TextBox ShipmAddUpRemDiv;
        private Label label17;
        private TextBox AcpOdrrAddUpRemDiv;
        private Label label18;
        private TextBox UnPrcNonSettingDiv;
        private Label label19;
        private TextBox DtlNoteDispDiv;
        private Label label20;
        private TextBox BrSlipNote2DispDiv;
        private Label label21;
        private TextBox AcpOdrAgentDispDiv;
        private Label label22;
        private TextBox SalesAgentChngDiv;
        private Label label23;
        private TextBox GrsProfitChkMaxSign;
        private Label label24;
        private TextBox GrsProfitChkUprSign;
        private Label label25;
        private TextBox GrsProfitChkBestSign;
        private Label label30;
        private TextBox SlipChngDivUnPrc;
        private Label label31;
        private TextBox SlipChngDivCost;
        private Label label32;
        private TextBox SlipChngDivDate;
        private Label label33;
        private TextBox CustGuideDispDiv;
        private Label label34;
        private TextBox SupplierSlipDelDiv;
        private Label label35;
        private TextBox SupplierInpDiv;
        private Label label36;
        private TextBox BLGoodsCdInpDiv;
        private Label label37;
        private TextBox MakerInpDiv;
        private Label label26;
        private TextBox AutoDepoKindName;
        private Label label27;
        private TextBox AutoDepoKindCode;
        private Label label28;
        private TextBox AutoDepoKindDivCd;
        private Label label29;
        private TextBox IoGoodsCntDiv2;
        private Label label38;
        private TextBox DiscountName;
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SalesSlipPrtDiv = new System.Windows.Forms.TextBox();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShipmSlipPrtDiv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ZeroPrtDiv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SlipChngDivLPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ShipmSlipUnPrcPrtDiv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StockDetailConf = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SalesFormalIn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IoGoodsCntDiv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GrsProfitChkLowSign = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GrsProfitCheckUpper = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.GrsProfitCheckBest = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.GrsProfitCheckLower = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ListPriceSelectDiv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.RetGoodsStockEtyDiv = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ShipmAddUpRemDiv = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.AcpOdrrAddUpRemDiv = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.UnPrcNonSettingDiv = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.DtlNoteDispDiv = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.BrSlipNote2DispDiv = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.AcpOdrAgentDispDiv = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.SalesAgentChngDiv = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.GrsProfitChkMaxSign = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.GrsProfitChkUprSign = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.GrsProfitChkBestSign = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.SlipChngDivUnPrc = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.SlipChngDivCost = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.SlipChngDivDate = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.CustGuideDispDiv = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.SupplierSlipDelDiv = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.SupplierInpDiv = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.BLGoodsCdInpDiv = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.MakerInpDiv = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.AutoDepoKindName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.AutoDepoKindCode = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.AutoDepoKindDivCd = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.IoGoodsCntDiv2 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.DiscountName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 425);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 111);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(96, 280);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 396);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(289, 396);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 396);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(361, 396);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(433, 396);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(505, 396);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 309);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "売上伝票発行区分";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "企業コード";
            // 
            // SalesSlipPrtDiv
            // 
            this.SalesSlipPrtDiv.Location = new System.Drawing.Point(147, 26);
            this.SalesSlipPrtDiv.Name = "SalesSlipPrtDiv";
            this.SalesSlipPrtDiv.Size = new System.Drawing.Size(115, 19);
            this.SalesSlipPrtDiv.TabIndex = 46;
            this.SalesSlipPrtDiv.Text = "10";
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(147, 6);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 45;
            this.EnterpriseCode.Text = "0101150842020000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "出荷伝票発行区分";
            // 
            // ShipmSlipPrtDiv
            // 
            this.ShipmSlipPrtDiv.Location = new System.Drawing.Point(147, 46);
            this.ShipmSlipPrtDiv.Name = "ShipmSlipPrtDiv";
            this.ShipmSlipPrtDiv.Size = new System.Drawing.Size(115, 19);
            this.ShipmSlipPrtDiv.TabIndex = 49;
            this.ShipmSlipPrtDiv.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "ゼロ円印刷区分";
            // 
            // ZeroPrtDiv
            // 
            this.ZeroPrtDiv.Location = new System.Drawing.Point(147, 66);
            this.ZeroPrtDiv.Name = "ZeroPrtDiv";
            this.ZeroPrtDiv.Size = new System.Drawing.Size(115, 19);
            this.ZeroPrtDiv.TabIndex = 51;
            this.ZeroPrtDiv.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "伝票修正区分（定価）";
            // 
            // SlipChngDivLPrice
            // 
            this.SlipChngDivLPrice.Location = new System.Drawing.Point(703, 206);
            this.SlipChngDivLPrice.Name = "SlipChngDivLPrice";
            this.SlipChngDivLPrice.Size = new System.Drawing.Size(115, 19);
            this.SlipChngDivLPrice.TabIndex = 53;
            this.SlipChngDivLPrice.Text = "250";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "出荷伝票単価印刷区分";
            // 
            // ShipmSlipUnPrcPrtDiv
            // 
            this.ShipmSlipUnPrcPrtDiv.Location = new System.Drawing.Point(147, 86);
            this.ShipmSlipUnPrcPrtDiv.Name = "ShipmSlipUnPrcPrtDiv";
            this.ShipmSlipUnPrcPrtDiv.Size = new System.Drawing.Size(115, 19);
            this.ShipmSlipUnPrcPrtDiv.TabIndex = 55;
            this.ShipmSlipUnPrcPrtDiv.Text = "40";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 62;
            this.label7.Text = "仕入明細確認";
            // 
            // StockDetailConf
            // 
            this.StockDetailConf.Location = new System.Drawing.Point(147, 146);
            this.StockDetailConf.Name = "StockDetailConf";
            this.StockDetailConf.Size = new System.Drawing.Size(115, 19);
            this.StockDetailConf.TabIndex = 61;
            this.StockDetailConf.Text = "70";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 60;
            this.label8.Text = "売上形式初期値";
            // 
            // SalesFormalIn
            // 
            this.SalesFormalIn.Location = new System.Drawing.Point(147, 126);
            this.SalesFormalIn.Name = "SalesFormalIn";
            this.SalesFormalIn.Size = new System.Drawing.Size(115, 19);
            this.SalesFormalIn.TabIndex = 59;
            this.SalesFormalIn.Text = "60";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 58;
            this.label9.Text = "入出荷数区分";
            // 
            // IoGoodsCntDiv
            // 
            this.IoGoodsCntDiv.Location = new System.Drawing.Point(147, 106);
            this.IoGoodsCntDiv.Name = "IoGoodsCntDiv";
            this.IoGoodsCntDiv.Size = new System.Drawing.Size(115, 19);
            this.IoGoodsCntDiv.TabIndex = 57;
            this.IoGoodsCntDiv.Text = "50";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 12);
            this.label10.TabIndex = 70;
            this.label10.Text = "粗利チェック下限記号";
            // 
            // GrsProfitChkLowSign
            // 
            this.GrsProfitChkLowSign.Location = new System.Drawing.Point(147, 226);
            this.GrsProfitChkLowSign.Name = "GrsProfitChkLowSign";
            this.GrsProfitChkLowSign.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitChkLowSign.TabIndex = 69;
            this.GrsProfitChkLowSign.Text = "無";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 12);
            this.label11.TabIndex = 68;
            this.label11.Text = "粗利チェック上限";
            // 
            // GrsProfitCheckUpper
            // 
            this.GrsProfitCheckUpper.Location = new System.Drawing.Point(147, 206);
            this.GrsProfitCheckUpper.Name = "GrsProfitCheckUpper";
            this.GrsProfitCheckUpper.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitCheckUpper.TabIndex = 67;
            this.GrsProfitCheckUpper.Text = "30.5";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 12);
            this.label12.TabIndex = 66;
            this.label12.Text = "粗利チェック適正";
            // 
            // GrsProfitCheckBest
            // 
            this.GrsProfitCheckBest.Location = new System.Drawing.Point(147, 186);
            this.GrsProfitCheckBest.Name = "GrsProfitCheckBest";
            this.GrsProfitCheckBest.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitCheckBest.TabIndex = 65;
            this.GrsProfitCheckBest.Text = "20.5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 12);
            this.label13.TabIndex = 64;
            this.label13.Text = "粗利チェック下限";
            // 
            // GrsProfitCheckLower
            // 
            this.GrsProfitCheckLower.Location = new System.Drawing.Point(147, 166);
            this.GrsProfitCheckLower.Name = "GrsProfitCheckLower";
            this.GrsProfitCheckLower.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitCheckLower.TabIndex = 63;
            this.GrsProfitCheckLower.Text = "10.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(561, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 94;
            this.label14.Text = "定価選択区分";
            // 
            // ListPriceSelectDiv
            // 
            this.ListPriceSelectDiv.Location = new System.Drawing.Point(703, 26);
            this.ListPriceSelectDiv.Name = "ListPriceSelectDiv";
            this.ListPriceSelectDiv.Size = new System.Drawing.Size(115, 19);
            this.ListPriceSelectDiv.TabIndex = 93;
            this.ListPriceSelectDiv.Text = "160";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(287, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 92;
            this.label15.Text = "返品時在庫登録区分";
            // 
            // RetGoodsStockEtyDiv
            // 
            this.RetGoodsStockEtyDiv.Location = new System.Drawing.Point(419, 226);
            this.RetGoodsStockEtyDiv.Name = "RetGoodsStockEtyDiv";
            this.RetGoodsStockEtyDiv.Size = new System.Drawing.Size(115, 19);
            this.RetGoodsStockEtyDiv.TabIndex = 91;
            this.RetGoodsStockEtyDiv.Text = "150";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(287, 209);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 12);
            this.label16.TabIndex = 90;
            this.label16.Text = "出荷データ計上残区分";
            // 
            // ShipmAddUpRemDiv
            // 
            this.ShipmAddUpRemDiv.Location = new System.Drawing.Point(419, 206);
            this.ShipmAddUpRemDiv.Name = "ShipmAddUpRemDiv";
            this.ShipmAddUpRemDiv.Size = new System.Drawing.Size(115, 19);
            this.ShipmAddUpRemDiv.TabIndex = 89;
            this.ShipmAddUpRemDiv.Text = "140";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(287, 189);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 12);
            this.label17.TabIndex = 88;
            this.label17.Text = "受注データ計上残区分";
            // 
            // AcpOdrrAddUpRemDiv
            // 
            this.AcpOdrrAddUpRemDiv.Location = new System.Drawing.Point(419, 186);
            this.AcpOdrrAddUpRemDiv.Name = "AcpOdrrAddUpRemDiv";
            this.AcpOdrrAddUpRemDiv.Size = new System.Drawing.Size(115, 19);
            this.AcpOdrrAddUpRemDiv.TabIndex = 87;
            this.AcpOdrrAddUpRemDiv.Text = "130";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(287, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 12);
            this.label18.TabIndex = 86;
            this.label18.Text = "売価未設定時区分";
            // 
            // UnPrcNonSettingDiv
            // 
            this.UnPrcNonSettingDiv.Location = new System.Drawing.Point(419, 166);
            this.UnPrcNonSettingDiv.Name = "UnPrcNonSettingDiv";
            this.UnPrcNonSettingDiv.Size = new System.Drawing.Size(115, 19);
            this.UnPrcNonSettingDiv.TabIndex = 85;
            this.UnPrcNonSettingDiv.Text = "120";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(287, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 12);
            this.label19.TabIndex = 84;
            this.label19.Text = "明細備考表示区分";
            // 
            // DtlNoteDispDiv
            // 
            this.DtlNoteDispDiv.Location = new System.Drawing.Point(419, 146);
            this.DtlNoteDispDiv.Name = "DtlNoteDispDiv";
            this.DtlNoteDispDiv.Size = new System.Drawing.Size(115, 19);
            this.DtlNoteDispDiv.TabIndex = 83;
            this.DtlNoteDispDiv.Text = "110";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(287, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 12);
            this.label20.TabIndex = 82;
            this.label20.Text = "伝票備考２表示区分";
            // 
            // BrSlipNote2DispDiv
            // 
            this.BrSlipNote2DispDiv.Location = new System.Drawing.Point(419, 126);
            this.BrSlipNote2DispDiv.Name = "BrSlipNote2DispDiv";
            this.BrSlipNote2DispDiv.Size = new System.Drawing.Size(115, 19);
            this.BrSlipNote2DispDiv.TabIndex = 81;
            this.BrSlipNote2DispDiv.Text = "100";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(287, 109);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 12);
            this.label21.TabIndex = 80;
            this.label21.Text = "受注者表示区分";
            // 
            // AcpOdrAgentDispDiv
            // 
            this.AcpOdrAgentDispDiv.Location = new System.Drawing.Point(419, 106);
            this.AcpOdrAgentDispDiv.Name = "AcpOdrAgentDispDiv";
            this.AcpOdrAgentDispDiv.Size = new System.Drawing.Size(115, 19);
            this.AcpOdrAgentDispDiv.TabIndex = 79;
            this.AcpOdrAgentDispDiv.Text = "90";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(287, 89);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 12);
            this.label22.TabIndex = 78;
            this.label22.Text = "売上担当変更区分";
            // 
            // SalesAgentChngDiv
            // 
            this.SalesAgentChngDiv.Location = new System.Drawing.Point(419, 86);
            this.SalesAgentChngDiv.Name = "SalesAgentChngDiv";
            this.SalesAgentChngDiv.Size = new System.Drawing.Size(115, 19);
            this.SalesAgentChngDiv.TabIndex = 77;
            this.SalesAgentChngDiv.Text = "80";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(287, 69);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 12);
            this.label23.TabIndex = 76;
            this.label23.Text = "粗利チェック最大記号";
            // 
            // GrsProfitChkMaxSign
            // 
            this.GrsProfitChkMaxSign.Location = new System.Drawing.Point(419, 66);
            this.GrsProfitChkMaxSign.Name = "GrsProfitChkMaxSign";
            this.GrsProfitChkMaxSign.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitChkMaxSign.TabIndex = 75;
            this.GrsProfitChkMaxSign.Text = "大";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(287, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(108, 12);
            this.label24.TabIndex = 74;
            this.label24.Text = "粗利チェック上限記号";
            // 
            // GrsProfitChkUprSign
            // 
            this.GrsProfitChkUprSign.Location = new System.Drawing.Point(419, 46);
            this.GrsProfitChkUprSign.Name = "GrsProfitChkUprSign";
            this.GrsProfitChkUprSign.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitChkUprSign.TabIndex = 73;
            this.GrsProfitChkUprSign.Text = "中";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(287, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 12);
            this.label25.TabIndex = 72;
            this.label25.Text = "粗利チェック適正記号";
            // 
            // GrsProfitChkBestSign
            // 
            this.GrsProfitChkBestSign.Location = new System.Drawing.Point(419, 26);
            this.GrsProfitChkBestSign.Name = "GrsProfitChkBestSign";
            this.GrsProfitChkBestSign.Size = new System.Drawing.Size(115, 19);
            this.GrsProfitChkBestSign.TabIndex = 71;
            this.GrsProfitChkBestSign.Text = "低";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(561, 189);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(113, 12);
            this.label30.TabIndex = 110;
            this.label30.Text = "伝票修正区分（売価）";
            // 
            // SlipChngDivUnPrc
            // 
            this.SlipChngDivUnPrc.Location = new System.Drawing.Point(703, 186);
            this.SlipChngDivUnPrc.Name = "SlipChngDivUnPrc";
            this.SlipChngDivUnPrc.Size = new System.Drawing.Size(115, 19);
            this.SlipChngDivUnPrc.TabIndex = 109;
            this.SlipChngDivUnPrc.Text = "240";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(561, 169);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(113, 12);
            this.label31.TabIndex = 108;
            this.label31.Text = "伝票修正区分（原価）";
            // 
            // SlipChngDivCost
            // 
            this.SlipChngDivCost.Location = new System.Drawing.Point(703, 166);
            this.SlipChngDivCost.Name = "SlipChngDivCost";
            this.SlipChngDivCost.Size = new System.Drawing.Size(115, 19);
            this.SlipChngDivCost.TabIndex = 107;
            this.SlipChngDivCost.Text = "230";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(561, 149);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 12);
            this.label32.TabIndex = 106;
            this.label32.Text = "伝票修正区分（日付）";
            // 
            // SlipChngDivDate
            // 
            this.SlipChngDivDate.Location = new System.Drawing.Point(703, 146);
            this.SlipChngDivDate.Name = "SlipChngDivDate";
            this.SlipChngDivDate.Size = new System.Drawing.Size(115, 19);
            this.SlipChngDivDate.TabIndex = 105;
            this.SlipChngDivDate.Text = "220";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(561, 129);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(141, 12);
            this.label33.TabIndex = 104;
            this.label33.Text = "得意先ガイド初期表示区分";
            // 
            // CustGuideDispDiv
            // 
            this.CustGuideDispDiv.Location = new System.Drawing.Point(703, 126);
            this.CustGuideDispDiv.Name = "CustGuideDispDiv";
            this.CustGuideDispDiv.Size = new System.Drawing.Size(115, 19);
            this.CustGuideDispDiv.TabIndex = 103;
            this.CustGuideDispDiv.Text = "210";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(561, 109);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(101, 12);
            this.label34.TabIndex = 102;
            this.label34.Text = "仕入伝票削除区分";
            // 
            // SupplierSlipDelDiv
            // 
            this.SupplierSlipDelDiv.Location = new System.Drawing.Point(703, 106);
            this.SupplierSlipDelDiv.Name = "SupplierSlipDelDiv";
            this.SupplierSlipDelDiv.Size = new System.Drawing.Size(115, 19);
            this.SupplierSlipDelDiv.TabIndex = 101;
            this.SupplierSlipDelDiv.Text = "200";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(561, 89);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(89, 12);
            this.label35.TabIndex = 100;
            this.label35.Text = "仕入先入力区分";
            // 
            // SupplierInpDiv
            // 
            this.SupplierInpDiv.Location = new System.Drawing.Point(703, 86);
            this.SupplierInpDiv.Name = "SupplierInpDiv";
            this.SupplierInpDiv.Size = new System.Drawing.Size(115, 19);
            this.SupplierInpDiv.TabIndex = 99;
            this.SupplierInpDiv.Text = "190";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(561, 69);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(118, 12);
            this.label36.TabIndex = 98;
            this.label36.Text = "BL商品コード入力区分";
            // 
            // BLGoodsCdInpDiv
            // 
            this.BLGoodsCdInpDiv.Location = new System.Drawing.Point(703, 66);
            this.BLGoodsCdInpDiv.Name = "BLGoodsCdInpDiv";
            this.BLGoodsCdInpDiv.Size = new System.Drawing.Size(115, 19);
            this.BLGoodsCdInpDiv.TabIndex = 97;
            this.BLGoodsCdInpDiv.Text = "180";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(561, 49);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(90, 12);
            this.label37.TabIndex = 96;
            this.label37.Text = "メーカー入力区分";
            // 
            // MakerInpDiv
            // 
            this.MakerInpDiv.Location = new System.Drawing.Point(703, 46);
            this.MakerInpDiv.Name = "MakerInpDiv";
            this.MakerInpDiv.Size = new System.Drawing.Size(115, 19);
            this.MakerInpDiv.TabIndex = 95;
            this.MakerInpDiv.Text = "170";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(561, 249);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 12);
            this.label26.TabIndex = 116;
            this.label26.Text = "自動入金金種名称";
            // 
            // AutoDepoKindName
            // 
            this.AutoDepoKindName.Location = new System.Drawing.Point(703, 246);
            this.AutoDepoKindName.Name = "AutoDepoKindName";
            this.AutoDepoKindName.Size = new System.Drawing.Size(115, 19);
            this.AutoDepoKindName.TabIndex = 115;
            this.AutoDepoKindName.Text = "270";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(561, 229);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 12);
            this.label27.TabIndex = 114;
            this.label27.Text = "自動入金金種コード";
            // 
            // AutoDepoKindCode
            // 
            this.AutoDepoKindCode.Location = new System.Drawing.Point(703, 226);
            this.AutoDepoKindCode.Name = "AutoDepoKindCode";
            this.AutoDepoKindCode.Size = new System.Drawing.Size(115, 19);
            this.AutoDepoKindCode.TabIndex = 113;
            this.AutoDepoKindCode.Text = "260";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(561, 269);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 12);
            this.label28.TabIndex = 112;
            this.label28.Text = "自動入金金種区分";
            // 
            // AutoDepoKindDivCd
            // 
            this.AutoDepoKindDivCd.Location = new System.Drawing.Point(703, 266);
            this.AutoDepoKindDivCd.Name = "AutoDepoKindDivCd";
            this.AutoDepoKindDivCd.Size = new System.Drawing.Size(115, 19);
            this.AutoDepoKindDivCd.TabIndex = 111;
            this.AutoDepoKindDivCd.Text = "280";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(287, 249);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 12);
            this.label29.TabIndex = 118;
            this.label29.Text = "入出荷数区分2";
            // 
            // IoGoodsCntDiv2
            // 
            this.IoGoodsCntDiv2.Location = new System.Drawing.Point(419, 246);
            this.IoGoodsCntDiv2.Name = "IoGoodsCntDiv2";
            this.IoGoodsCntDiv2.Size = new System.Drawing.Size(115, 19);
            this.IoGoodsCntDiv2.TabIndex = 117;
            this.IoGoodsCntDiv2.Text = "50";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(287, 269);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.TabIndex = 120;
            this.label38.Text = "値引名称";
            // 
            // DiscountName
            // 
            this.DiscountName.Location = new System.Drawing.Point(419, 266);
            this.DiscountName.Name = "DiscountName";
            this.DiscountName.Size = new System.Drawing.Size(115, 19);
            this.DiscountName.TabIndex = 119;
            this.DiscountName.Text = "270";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.DiscountName);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.IoGoodsCntDiv2);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.AutoDepoKindName);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.AutoDepoKindCode);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.AutoDepoKindDivCd);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.SlipChngDivUnPrc);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.SlipChngDivCost);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.SlipChngDivDate);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.CustGuideDispDiv);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.SupplierSlipDelDiv);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.SupplierInpDiv);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.BLGoodsCdInpDiv);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.MakerInpDiv);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ListPriceSelectDiv);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.RetGoodsStockEtyDiv);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ShipmAddUpRemDiv);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.AcpOdrrAddUpRemDiv);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.UnPrcNonSettingDiv);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.DtlNoteDispDiv);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.BrSlipNote2DispDiv);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.AcpOdrAgentDispDiv);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.SalesAgentChngDiv);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.GrsProfitChkMaxSign);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.GrsProfitChkUprSign);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.GrsProfitChkBestSign);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.GrsProfitChkLowSign);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GrsProfitCheckUpper);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.GrsProfitCheckBest);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.GrsProfitCheckLower);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StockDetailConf);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SalesFormalIn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.IoGoodsCntDiv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ShipmSlipUnPrcPrtDiv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SlipChngDivLPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ZeroPrtDiv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ShipmSlipPrtDiv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SalesSlipPrtDiv);
            this.Controls.Add(this.EnterpriseCode);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button1);
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
                if (status != 0)    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",msg,0,MessageBoxButtons.OK);
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
            if (_form != null)    TMsgDisp.Show(_form.Owner,    emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            else                TMsgDisp.Show(                emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 1件読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
//            if (_salesTtlStWork == null) _salesTtlStWork = new SalesTtlStWork();
            _salesTtlStWork = new SalesTtlStWork();
            _salesTtlStWork.EnterpriseCode = EnterpriseCode.Text;
            _salesTtlStWork.SalesSlipPrtDiv = Convert.ToInt32(SalesSlipPrtDiv.Text);
            _salesTtlStWork.ShipmSlipPrtDiv = Convert.ToInt32(ShipmSlipPrtDiv.Text);
            //_salesTtlStWork.ZeroPrtDiv = Convert.ToInt32(ZeroPrtDiv.Text);
            _salesTtlStWork.ShipmSlipUnPrcPrtDiv = Convert.ToInt32(ShipmSlipUnPrcPrtDiv.Text);
            //_salesTtlStWork.IoGoodsCntDiv = Convert.ToInt32(IoGoodsCntDiv.Text);
            //_salesTtlStWork.SalesFormalIn = Convert.ToInt32(SalesFormalIn.Text);
            //_salesTtlStWork.StockDetailConf = Convert.ToInt32(StockDetailConf.Text);
            _salesTtlStWork.GrsProfitCheckLower = Convert.ToDouble(GrsProfitCheckLower.Text);
            _salesTtlStWork.GrsProfitCheckBest = Convert.ToDouble(GrsProfitCheckBest.Text);
            _salesTtlStWork.GrsProfitCheckUpper = Convert.ToDouble(GrsProfitCheckUpper.Text);
            _salesTtlStWork.GrsProfitChkLowSign = GrsProfitChkLowSign.Text;
            _salesTtlStWork.GrsProfitChkBestSign = GrsProfitChkBestSign.Text;
            _salesTtlStWork.GrsProfitChkUprSign = GrsProfitChkUprSign.Text;
            _salesTtlStWork.GrsProfitChkMaxSign = GrsProfitChkMaxSign.Text;
            _salesTtlStWork.SalesAgentChngDiv = Convert.ToInt32(SalesAgentChngDiv.Text);
            _salesTtlStWork.AcpOdrAgentDispDiv = Convert.ToInt32(AcpOdrAgentDispDiv.Text);
            _salesTtlStWork.BrSlipNote2DispDiv = Convert.ToInt32(BrSlipNote2DispDiv.Text);
            _salesTtlStWork.DtlNoteDispDiv = Convert.ToInt32(DtlNoteDispDiv.Text);
            _salesTtlStWork.UnPrcNonSettingDiv = Convert.ToInt32(UnPrcNonSettingDiv.Text);
            _salesTtlStWork.AcpOdrrAddUpRemDiv = Convert.ToInt32(AcpOdrrAddUpRemDiv.Text);
            _salesTtlStWork.ShipmAddUpRemDiv = Convert.ToInt32(ShipmAddUpRemDiv.Text);
            _salesTtlStWork.RetGoodsStockEtyDiv = Convert.ToInt32(RetGoodsStockEtyDiv.Text);
            _salesTtlStWork.ListPriceSelectDiv = Convert.ToInt32(ListPriceSelectDiv.Text);
            _salesTtlStWork.MakerInpDiv = Convert.ToInt32(MakerInpDiv.Text);
            _salesTtlStWork.BLGoodsCdInpDiv = Convert.ToInt32(BLGoodsCdInpDiv.Text);
            _salesTtlStWork.SupplierInpDiv = Convert.ToInt32(SupplierInpDiv.Text);
            _salesTtlStWork.SupplierSlipDelDiv = Convert.ToInt32(SupplierSlipDelDiv.Text);
            _salesTtlStWork.CustGuideDispDiv = Convert.ToInt32(CustGuideDispDiv.Text);
            _salesTtlStWork.SlipChngDivDate = Convert.ToInt32(SlipChngDivDate.Text);
            _salesTtlStWork.SlipChngDivCost = Convert.ToInt32(SlipChngDivCost.Text);
            _salesTtlStWork.SlipChngDivUnPrc = Convert.ToInt32(SlipChngDivUnPrc.Text);
            _salesTtlStWork.SlipChngDivLPrice = Convert.ToInt32(SlipChngDivLPrice.Text);
            _salesTtlStWork.AutoDepoKindCode = Convert.ToInt32(AutoDepoKindCode.Text);
            _salesTtlStWork.AutoDepoKindName = AutoDepoKindName.Text;
            _salesTtlStWork.AutoDepoKindDivCd = Convert.ToInt32(AutoDepoKindDivCd.Text);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_salesTtlStWork);            

            int status = IsalesTtlStDB.Read(ref parabyte,0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                _salesTtlStWork = (SalesTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(SalesTtlStWork));

                Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(_salesTtlStWork);
                dataGrid1.DataSource = al;
            }        
        }

        /// <summary>
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);        
            IsalesTtlStDB = MediationSalesTtlStDB.GetSalesTtlStDB();
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
            SalesTtlStWork work = new SalesTtlStWork();
            work.EnterpriseCode = EnterpriseCode.Text;
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
            ArrayList al = new ArrayList();
            SalesTtlStWork work = new SalesTtlStWork();
            work.EnterpriseCode = EnterpriseCode.Text;
            al.Add(work);
            dataGrid2.DataSource = al;
            object parabyte = dataGrid2.DataSource;
            object objsalesTtlSt = new SalesTtlStWork();

            int status = IsalesTtlStDB.Search(out objsalesTtlSt, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT "+((ArrayList)objsalesTtlSt).Count.ToString()+"件";
                
                dataGrid1.DataSource = objsalesTtlSt;
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, System.EventArgs e)
        {
            object objsalesTtlStWork = new SalesTtlStWork();
            objsalesTtlStWork = dataGrid1.DataSource;
    
            int status = IsalesTtlStDB.Write(ref objsalesTtlStWork);
            if (status != 0)
            {
                Text = "更新失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "更新成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objsalesTtlStWork;
            }        
        }

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, System.EventArgs e)
        {
            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = EnterpriseCode.Text;
            salesTtlStWork.SalesSlipPrtDiv = Convert.ToInt32(SalesSlipPrtDiv.Text);
            salesTtlStWork.ShipmSlipPrtDiv = Convert.ToInt32(ShipmSlipPrtDiv.Text);
            //salesTtlStWork.ZeroPrtDiv = Convert.ToInt32(ZeroPrtDiv.Text);
            salesTtlStWork.ShipmSlipUnPrcPrtDiv = Convert.ToInt32(ShipmSlipUnPrcPrtDiv.Text);
            //salesTtlStWork.IoGoodsCntDiv = Convert.ToInt32(IoGoodsCntDiv.Text);
            //salesTtlStWork.SalesFormalIn = Convert.ToInt32(SalesFormalIn.Text);
            //salesTtlStWork.StockDetailConf = Convert.ToInt32(StockDetailConf.Text);
            salesTtlStWork.GrsProfitCheckLower = Convert.ToDouble(GrsProfitCheckLower.Text);
            salesTtlStWork.GrsProfitCheckBest = Convert.ToDouble(GrsProfitCheckBest.Text);
            salesTtlStWork.GrsProfitCheckUpper = Convert.ToDouble(GrsProfitCheckUpper.Text);
            salesTtlStWork.GrsProfitChkLowSign = GrsProfitChkLowSign.Text;
            salesTtlStWork.GrsProfitChkBestSign = GrsProfitChkBestSign.Text;
            salesTtlStWork.GrsProfitChkUprSign = GrsProfitChkUprSign.Text;
            salesTtlStWork.GrsProfitChkMaxSign = GrsProfitChkMaxSign.Text;
            salesTtlStWork.SalesAgentChngDiv = Convert.ToInt32(SalesAgentChngDiv.Text);
            salesTtlStWork.AcpOdrAgentDispDiv = Convert.ToInt32(AcpOdrAgentDispDiv.Text);
            salesTtlStWork.BrSlipNote2DispDiv = Convert.ToInt32(BrSlipNote2DispDiv.Text);
            salesTtlStWork.DtlNoteDispDiv = Convert.ToInt32(DtlNoteDispDiv.Text);
            salesTtlStWork.UnPrcNonSettingDiv = Convert.ToInt32(UnPrcNonSettingDiv.Text);
            salesTtlStWork.AcpOdrrAddUpRemDiv = Convert.ToInt32(AcpOdrrAddUpRemDiv.Text);
            salesTtlStWork.ShipmAddUpRemDiv = Convert.ToInt32(ShipmAddUpRemDiv.Text);
            salesTtlStWork.RetGoodsStockEtyDiv = Convert.ToInt32(RetGoodsStockEtyDiv.Text);
            salesTtlStWork.ListPriceSelectDiv = Convert.ToInt32(ListPriceSelectDiv.Text);
            salesTtlStWork.MakerInpDiv = Convert.ToInt32(MakerInpDiv.Text);
            salesTtlStWork.BLGoodsCdInpDiv = Convert.ToInt32(BLGoodsCdInpDiv.Text);
            salesTtlStWork.SupplierInpDiv = Convert.ToInt32(SupplierInpDiv.Text);
            salesTtlStWork.SupplierSlipDelDiv = Convert.ToInt32(SupplierSlipDelDiv.Text);
            salesTtlStWork.CustGuideDispDiv = Convert.ToInt32(CustGuideDispDiv.Text);
            salesTtlStWork.SlipChngDivDate = Convert.ToInt32(SlipChngDivDate.Text);
            salesTtlStWork.SlipChngDivCost = Convert.ToInt32(SlipChngDivCost.Text);
            salesTtlStWork.SlipChngDivUnPrc = Convert.ToInt32(SlipChngDivUnPrc.Text);
            salesTtlStWork.SlipChngDivLPrice = Convert.ToInt32(SlipChngDivLPrice.Text);
            salesTtlStWork.AutoDepoKindCode = Convert.ToInt32(AutoDepoKindCode.Text);
            salesTtlStWork.AutoDepoKindName = AutoDepoKindName.Text;
            salesTtlStWork.AutoDepoKindDivCd = Convert.ToInt32(AutoDepoKindDivCd.Text);
            //salesTtlStWork.IoGoodsCntDiv2 = Convert.ToInt32(IoGoodsCntDiv2.Text);
            salesTtlStWork.DiscountName = DiscountName.Text;
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(salesTtlStWork);
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, System.EventArgs e)
        {
            object objsalesTtlStWork = dataGrid1.DataSource;

            int status = IsalesTtlStDB.LogicalDelete(ref objsalesTtlStWork);
            if (status != 0)
            {
                Text = "論理削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "論理削除成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objsalesTtlStWork;
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, System.EventArgs e)
        {
            object objsalesTtlStWork = dataGrid1.DataSource;

            SalesTtlStWork[] trarray = (SalesTtlStWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(SalesTtlStWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IsalesTtlStDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再削除してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
                dataGrid1.DataSource = null;
                //dataGrid1.DataSource = objsalesTtlStWork;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            object objsalesTtlStWork = dataGrid1.DataSource;

            int status = IsalesTtlStDB.RevivalLogicalDelete(ref objsalesTtlStWork);
            if (status != 0)
            {
                Text = "復活失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                }
            }
            else
            {
                Text = "復活成功";
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = objsalesTtlStWork;
            }
        }
    }
}

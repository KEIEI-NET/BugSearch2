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
using Broadleaf.Library.Collections;

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

        private IStockAcPayHisSearchDB IstockAcPayHisSearchDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private Label label12;
        private Label label10;
        private TextBox St_IoGoodsDay;
        private TextBox SecCode2;
        private TextBox SecCode1;
        private TextBox SecCode0;
        private Label label2;
        private Label label1;
        private TextBox EnterpriseCode;
        private Label label6;
        private Label label7;
        private TextBox Ed_WarehouseCode;
        private TextBox St_WarehouseCode;
        private Label label4;
        private TextBox AcPaySlipCd;
        private Label label17;
        private Label label3;
        private Label label5;
        private TextBox Ed_IoGoodsDay;
        private TextBox St_AddUpADate;
        private TextBox Ed_AddUpADate;
        private Label label28;
        private TextBox ValidDivCd;
        private Label label27;
        private Label label8;
        private Label label9;
        private TextBox Ed_GoodsMakerCd;
        private TextBox St_GoodsMakerCd;
        private Label label11;
        private Label label13;
        private TextBox Ed_GoodsNo;
        private TextBox St_GoodsNo;
        private Label label14;
        private Label label15;
        private TextBox Ed_AcPaySlipNum;
        private TextBox St_AcPaySlipNum;
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
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.St_IoGoodsDay = new System.Windows.Forms.TextBox();
            this.SecCode2 = new System.Windows.Forms.TextBox();
            this.SecCode1 = new System.Windows.Forms.TextBox();
            this.SecCode0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Ed_WarehouseCode = new System.Windows.Forms.TextBox();
            this.St_WarehouseCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AcPaySlipCd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ed_IoGoodsDay = new System.Windows.Forms.TextBox();
            this.St_AddUpADate = new System.Windows.Forms.TextBox();
            this.Ed_AddUpADate = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.ValidDivCd = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Ed_GoodsMakerCd = new System.Windows.Forms.TextBox();
            this.St_GoodsMakerCd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Ed_GoodsNo = new System.Windows.Forms.TextBox();
            this.St_GoodsNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Ed_AcPaySlipNum = new System.Windows.Forms.TextBox();
            this.St_AcPaySlipNum = new System.Windows.Forms.TextBox();
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
            this.button8.Text = "売上仕入対比表";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(309, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 80;
            this.label12.Text = "～";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(147, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "入出荷日";
            // 
            // St_IoGoodsDay
            // 
            this.St_IoGoodsDay.Location = new System.Drawing.Point(244, 51);
            this.St_IoGoodsDay.Name = "St_IoGoodsDay";
            this.St_IoGoodsDay.Size = new System.Drawing.Size(59, 19);
            this.St_IoGoodsDay.TabIndex = 76;
            this.St_IoGoodsDay.Text = "0";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 93;
            this.label6.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 94;
            this.label7.Text = "倉庫コード";
            // 
            // Ed_WarehouseCode
            // 
            this.Ed_WarehouseCode.Location = new System.Drawing.Point(332, 103);
            this.Ed_WarehouseCode.Name = "Ed_WarehouseCode";
            this.Ed_WarehouseCode.Size = new System.Drawing.Size(59, 19);
            this.Ed_WarehouseCode.TabIndex = 91;
            // 
            // St_WarehouseCode
            // 
            this.St_WarehouseCode.Location = new System.Drawing.Point(244, 103);
            this.St_WarehouseCode.Name = "St_WarehouseCode";
            this.St_WarehouseCode.Size = new System.Drawing.Size(59, 19);
            this.St_WarehouseCode.TabIndex = 92;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(592, 12);
            this.label4.TabIndex = 130;
            this.label4.Text = "-1:全て,10:仕入,11:入荷,12:受計上,20:売上,21:売計上,22:出荷,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:" +
                "棚卸";
            // 
            // AcPaySlipCd
            // 
            this.AcPaySlipCd.Location = new System.Drawing.Point(244, 28);
            this.AcPaySlipCd.Name = "AcPaySlipCd";
            this.AcPaySlipCd.Size = new System.Drawing.Size(59, 19);
            this.AcPaySlipCd.TabIndex = 129;
            this.AcPaySlipCd.Text = "-1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(147, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 128;
            this.label17.Text = "受払元伝票区分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 133;
            this.label3.Text = "～";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 134;
            this.label5.Text = "計上日";
            // 
            // Ed_IoGoodsDay
            // 
            this.Ed_IoGoodsDay.Location = new System.Drawing.Point(332, 51);
            this.Ed_IoGoodsDay.Name = "Ed_IoGoodsDay";
            this.Ed_IoGoodsDay.Size = new System.Drawing.Size(59, 19);
            this.Ed_IoGoodsDay.TabIndex = 136;
            this.Ed_IoGoodsDay.Text = "0";
            // 
            // St_AddUpADate
            // 
            this.St_AddUpADate.Location = new System.Drawing.Point(244, 77);
            this.St_AddUpADate.Name = "St_AddUpADate";
            this.St_AddUpADate.Size = new System.Drawing.Size(59, 19);
            this.St_AddUpADate.TabIndex = 138;
            this.St_AddUpADate.Text = "0";
            // 
            // Ed_AddUpADate
            // 
            this.Ed_AddUpADate.Location = new System.Drawing.Point(332, 77);
            this.Ed_AddUpADate.Name = "Ed_AddUpADate";
            this.Ed_AddUpADate.Size = new System.Drawing.Size(59, 19);
            this.Ed_AddUpADate.TabIndex = 140;
            this.Ed_AddUpADate.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(312, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(167, 12);
            this.label28.TabIndex = 125;
            this.label28.Text = "0:有効 1:無効（修正前又は削除）";
            // 
            // ValidDivCd
            // 
            this.ValidDivCd.Location = new System.Drawing.Point(244, 6);
            this.ValidDivCd.Name = "ValidDivCd";
            this.ValidDivCd.Size = new System.Drawing.Size(24, 19);
            this.ValidDivCd.TabIndex = 126;
            this.ValidDivCd.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(147, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 127;
            this.label27.Text = "有効区分";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 143;
            this.label8.Text = "～";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 12);
            this.label9.TabIndex = 144;
            this.label9.Text = "メーカーコード";
            // 
            // Ed_GoodsMakerCd
            // 
            this.Ed_GoodsMakerCd.Location = new System.Drawing.Point(332, 129);
            this.Ed_GoodsMakerCd.Name = "Ed_GoodsMakerCd";
            this.Ed_GoodsMakerCd.Size = new System.Drawing.Size(59, 19);
            this.Ed_GoodsMakerCd.TabIndex = 141;
            this.Ed_GoodsMakerCd.Text = "0";
            // 
            // St_GoodsMakerCd
            // 
            this.St_GoodsMakerCd.Location = new System.Drawing.Point(244, 129);
            this.St_GoodsMakerCd.Name = "St_GoodsMakerCd";
            this.St_GoodsMakerCd.Size = new System.Drawing.Size(59, 19);
            this.St_GoodsMakerCd.TabIndex = 142;
            this.St_GoodsMakerCd.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 147;
            this.label11.Text = "～";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(147, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 148;
            this.label13.Text = "商品番号";
            // 
            // Ed_GoodsNo
            // 
            this.Ed_GoodsNo.Location = new System.Drawing.Point(332, 155);
            this.Ed_GoodsNo.Name = "Ed_GoodsNo";
            this.Ed_GoodsNo.Size = new System.Drawing.Size(59, 19);
            this.Ed_GoodsNo.TabIndex = 145;
            // 
            // St_GoodsNo
            // 
            this.St_GoodsNo.Location = new System.Drawing.Point(244, 155);
            this.St_GoodsNo.Name = "St_GoodsNo";
            this.St_GoodsNo.Size = new System.Drawing.Size(59, 19);
            this.St_GoodsNo.TabIndex = 146;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(309, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 151;
            this.label14.Text = "～";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(147, 181);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 152;
            this.label15.Text = "伝票番号";
            // 
            // Ed_AcPaySlipNum
            // 
            this.Ed_AcPaySlipNum.Location = new System.Drawing.Point(332, 178);
            this.Ed_AcPaySlipNum.Name = "Ed_AcPaySlipNum";
            this.Ed_AcPaySlipNum.Size = new System.Drawing.Size(59, 19);
            this.Ed_AcPaySlipNum.TabIndex = 149;
            // 
            // St_AcPaySlipNum
            // 
            this.St_AcPaySlipNum.Location = new System.Drawing.Point(244, 178);
            this.St_AcPaySlipNum.Name = "St_AcPaySlipNum";
            this.St_AcPaySlipNum.Size = new System.Drawing.Size(59, 19);
            this.St_AcPaySlipNum.TabIndex = 150;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Ed_AcPaySlipNum);
            this.Controls.Add(this.St_AcPaySlipNum);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Ed_GoodsNo);
            this.Controls.Add(this.St_GoodsNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Ed_GoodsMakerCd);
            this.Controls.Add(this.St_GoodsMakerCd);
            this.Controls.Add(this.Ed_AddUpADate);
            this.Controls.Add(this.St_AddUpADate);
            this.Controls.Add(this.Ed_IoGoodsDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AcPaySlipCd);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.ValidDivCd);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Ed_WarehouseCode);
            this.Controls.Add(this.St_WarehouseCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.St_IoGoodsDay);
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
            IstockAcPayHisSearchDB = MediationStockAcPayHisSearchDB.GetStockAcPayHisSearchDB();
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
            StockAcPayHisSearchParaWork work = new StockAcPayHisSearchParaWork();

            work.EnterpriseCode = EnterpriseCode.Text;

            //拠点コード
            string[] sectionCode = new string[2];
            sectionCode[0] = SecCode0.Text;
            sectionCode[1] = SecCode1.Text;
            //sectionCode[2] = SecCode2.Text;
            work.SectionCodes = sectionCode;

            //work.TotalWay = TotalWay.Checked;

            //if (ValidDivCd.Text != "") work.ValidDivCd = Convert.ToInt32(ValidDivCd.Text);
            if (AcPaySlipCd.Text != "") work.AcPaySlipCd = Convert.ToInt32(AcPaySlipCd.Text);

            if (St_IoGoodsDay.Text != "") work.St_IoGoodsDay = Convert.ToInt32(St_IoGoodsDay.Text);
            if (Ed_IoGoodsDay.Text != "") work.Ed_IoGoodsDay = Convert.ToInt32(Ed_IoGoodsDay.Text);
            if (St_AddUpADate.Text != "") work.St_AddUpADate = Convert.ToInt32(St_AddUpADate.Text);
            if (Ed_AddUpADate.Text != "") work.Ed_AddUpADate = Convert.ToInt32(Ed_AddUpADate.Text);
            if (St_GoodsMakerCd.Text != "") work.St_GoodsMakerCd = Convert.ToInt32(St_GoodsMakerCd.Text);
            if (Ed_GoodsMakerCd.Text != "") work.Ed_GoodsMakerCd = Convert.ToInt32(Ed_GoodsMakerCd.Text);

            if (St_WarehouseCode.Text != "") work.St_WarehouseCode = St_WarehouseCode.Text;
            if (Ed_WarehouseCode.Text != "") work.Ed_WarehouseCode = Ed_WarehouseCode.Text;
            if (St_GoodsNo.Text != "") work.St_GoodsNo = St_GoodsNo.Text;
            if (Ed_GoodsNo.Text != "") work.Ed_GoodsNo = Ed_GoodsNo.Text;
            if (St_AcPaySlipNum.Text != "") work.St_AcPaySlipNum = St_AcPaySlipNum.Text;
            if (Ed_AcPaySlipNum.Text != "") work.Ed_AcPaySlipNum = Ed_AcPaySlipNum.Text;


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

			//object paraObj = dataGrid2.DataSource;
			object retObj = null;
            //object workObj = paraObj;
            object workObj = ((ArrayList)dataGrid2.DataSource)[0];
            try
            {
                int status = IstockAcPayHisSearchDB.Search(out retObj, workObj, 0, 0);
                if (status != 0)
                {
                    Text = "該当データ無し:status = " + status.ToString();
                }
                else
                {

                    Text = "該当データ有り  HIT " + ((ArrayList)retObj).Count.ToString() + "件";

                    CustomSerializeArrayList CSAList = retObj as CustomSerializeArrayList;
                    if (CSAList.Count > 0)
                        dataGrid1.DataSource = CSAList[0];
                    //dataGrid1.DataSource = retObj;
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
            StockAcPayHisSearchParaWork extrInfo_DemandTotalWork = new StockAcPayHisSearchParaWork();
			extrInfo_DemandTotalWork.EnterpriseCode = EnterpriseCode.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(extrInfo_DemandTotalWork);
			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
		}



	}
}

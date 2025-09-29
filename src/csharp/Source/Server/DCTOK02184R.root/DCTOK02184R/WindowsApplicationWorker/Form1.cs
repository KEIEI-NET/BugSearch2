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

        private IPastYearStatisticsDB IpastYearStatisticsDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button11;
        private Label label12;
        private Label label10;
        private TextBox St_AddUpYear;
        private TextBox SecCode2;
        private TextBox SecCode1;
        private TextBox SecCode0;
        private Label label2;
        private Label label1;
        private TextBox EnterpriseCode;
        private Label label6;
        private Label label7;
        private TextBox Ed_CustomerCode;
        private TextBox St_CustomerCode;
        private Label label27;
        private TextBox ListType;
        private Label label28;
        private Label label4;
        private TextBox MoneyUnit;
        private Label label17;
        private TextBox Ed_AddUpYear;
        private CheckBox TotalWay;
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
            this.St_AddUpYear = new System.Windows.Forms.TextBox();
            this.SecCode2 = new System.Windows.Forms.TextBox();
            this.SecCode1 = new System.Windows.Forms.TextBox();
            this.SecCode0 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Ed_CustomerCode = new System.Windows.Forms.TextBox();
            this.St_CustomerCode = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.ListType = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MoneyUnit = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Ed_AddUpYear = new System.Windows.Forms.TextBox();
            this.TotalWay = new System.Windows.Forms.CheckBox();
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
            this.button8.Text = "過年度統計表";
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
            this.label12.Location = new System.Drawing.Point(350, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 80;
            this.label12.Text = "～";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(196, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "対象年度";
            // 
            // St_AddUpYear
            // 
            this.St_AddUpYear.Location = new System.Drawing.Point(293, 27);
            this.St_AddUpYear.Name = "St_AddUpYear";
            this.St_AddUpYear.Size = new System.Drawing.Size(32, 19);
            this.St_AddUpYear.TabIndex = 76;
            this.St_AddUpYear.Text = "2007";
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
            this.label6.Location = new System.Drawing.Point(350, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 93;
            this.label6.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 94;
            this.label7.Text = "得意先コード";
            // 
            // Ed_CustomerCode
            // 
            this.Ed_CustomerCode.Location = new System.Drawing.Point(373, 51);
            this.Ed_CustomerCode.Name = "Ed_CustomerCode";
            this.Ed_CustomerCode.Size = new System.Drawing.Size(51, 19);
            this.Ed_CustomerCode.TabIndex = 91;
            this.Ed_CustomerCode.Text = "0";
            // 
            // St_CustomerCode
            // 
            this.St_CustomerCode.Location = new System.Drawing.Point(293, 51);
            this.St_CustomerCode.Name = "St_CustomerCode";
            this.St_CustomerCode.Size = new System.Drawing.Size(51, 19);
            this.St_CustomerCode.TabIndex = 92;
            this.St_CustomerCode.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(196, 106);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 127;
            this.label27.Text = "帳票種別";
            // 
            // ListType
            // 
            this.ListType.Location = new System.Drawing.Point(293, 103);
            this.ListType.Name = "ListType";
            this.ListType.Size = new System.Drawing.Size(24, 19);
            this.ListType.TabIndex = 126;
            this.ListType.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(353, 106);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(129, 12);
            this.label28.TabIndex = 125;
            this.label28.Text = "0：営業所別 1：仕入先別";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 12);
            this.label4.TabIndex = 130;
            this.label4.Text = "0：一円単位 1：千円単位";
            // 
            // MoneyUnit
            // 
            this.MoneyUnit.Location = new System.Drawing.Point(293, 76);
            this.MoneyUnit.Name = "MoneyUnit";
            this.MoneyUnit.Size = new System.Drawing.Size(51, 19);
            this.MoneyUnit.TabIndex = 129;
            this.MoneyUnit.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(196, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 128;
            this.label17.Text = "金額単位";
            // 
            // Ed_AddUpYear
            // 
            this.Ed_AddUpYear.Location = new System.Drawing.Point(373, 27);
            this.Ed_AddUpYear.Name = "Ed_AddUpYear";
            this.Ed_AddUpYear.Size = new System.Drawing.Size(32, 19);
            this.Ed_AddUpYear.TabIndex = 136;
            this.Ed_AddUpYear.Text = "2007";
            // 
            // TotalWay
            // 
            this.TotalWay.AutoSize = true;
            this.TotalWay.Location = new System.Drawing.Point(17, 167);
            this.TotalWay.Name = "TotalWay";
            this.TotalWay.Size = new System.Drawing.Size(84, 16);
            this.TotalWay.TabIndex = 142;
            this.TotalWay.Text = "全拠点集計";
            this.TotalWay.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 628);
            this.Controls.Add(this.TotalWay);
            this.Controls.Add(this.Ed_AddUpYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MoneyUnit);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.ListType);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Ed_CustomerCode);
            this.Controls.Add(this.St_CustomerCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.St_AddUpYear);
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
            IpastYearStatisticsDB = MediationPastYearStatisticsDB.GetPastYearStatisticsDB();
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
            ExtrInfo_PastYearStatisticsWork work = new ExtrInfo_PastYearStatisticsWork();

            work.EnterpriseCode = EnterpriseCode.Text;

            //拠点コード
            string[] sectionCode = new string[2];
            sectionCode[0] = SecCode0.Text;
            sectionCode[1] = SecCode1.Text;
            //sectionCode[2] = SecCode2.Text;
            work.SecCodeList = sectionCode;
            work.TotalWay = TotalWay.Checked;

            //対象年月
            if (St_AddUpYear.Text != "") work.St_AddUpYear = Convert.ToInt32(St_AddUpYear.Text);
            if (Ed_AddUpYear.Text != "") work.Ed_AddUpYear = Convert.ToInt32(Ed_AddUpYear.Text);
            if (St_CustomerCode.Text != "") work.St_CustomerCode = Convert.ToInt32(St_CustomerCode.Text);
            if (Ed_CustomerCode.Text != "") work.Ed_CustomerCode = Convert.ToInt32(Ed_CustomerCode.Text);

            if (ListType.Text != "") work.ListType = Convert.ToInt32(ListType.Text);
            if (MoneyUnit.Text != "") work.MoneyUnit = Convert.ToInt32(MoneyUnit.Text);
            
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
            object workObj = paraObj;

            try
            {
                int status = IpastYearStatisticsDB.SearchPastYearStatistics(out retObj, workObj);
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
            ExtrInfo_PastYearStatisticsWork extrInfo_DemandTotalWork = new ExtrInfo_PastYearStatisticsWork();
			extrInfo_DemandTotalWork.EnterpriseCode = EnterpriseCode.Text;
			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(extrInfo_DemandTotalWork);
			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
		}


	}
}

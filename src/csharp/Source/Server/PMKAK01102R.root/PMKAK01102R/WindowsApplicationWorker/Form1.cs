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
using Broadleaf.Library.Resources;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
    /// このFromはリモートテストの為だけのFromです
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;

		private IStockSlipRetPlnDB IStockSlipRetPlnDB = null;

        private static string[] _parameter;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
		private static System.Windows.Forms.Form _form = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEnterpriseCode;
        private TextBox txtSectionCode;
        private TextBox txtWareHouseCode;
        private ComboBox cmbType;
        private Panel panel1;
        private Button button4;
        private Label label5;
        private Label label6;
        private TextBox txtRetry;
        private TextBox txtTimeOut;
        private Label label7;
        private TextBox txtInterval;

        private ShareCheckKeyList ShareCheckKeyList = new ShareCheckKeyList();

		public Form1()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//

            cmbType.Items.AddRange(Enum.GetNames(typeof(ShareCheckType)));
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnterpriseCode = new System.Windows.Forms.TextBox();
            this.txtSectionCode = new System.Windows.Forms.TextBox();
            this.txtWareHouseCode = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.txtRetry = new System.Windows.Forms.TextBox();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "TBS1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 19);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(17, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(288, 19);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(17, 91);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(288, 19);
            this.textBox4.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "ロックキーの追加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Location = new System.Drawing.Point(11, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(688, 124);
            this.dataGridView1.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(445, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "ロック→待機→リリース";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "企業コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "拠点コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "倉庫コード";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "ロックタイプ";
            // 
            // txtEnterpriseCode
            // 
            this.txtEnterpriseCode.Location = new System.Drawing.Point(68, 14);
            this.txtEnterpriseCode.MaxLength = 16;
            this.txtEnterpriseCode.Name = "txtEnterpriseCode";
            this.txtEnterpriseCode.Size = new System.Drawing.Size(108, 19);
            this.txtEnterpriseCode.TabIndex = 1;
            // 
            // txtSectionCode
            // 
            this.txtSectionCode.Location = new System.Drawing.Point(430, 14);
            this.txtSectionCode.MaxLength = 6;
            this.txtSectionCode.Name = "txtSectionCode";
            this.txtSectionCode.Size = new System.Drawing.Size(48, 19);
            this.txtSectionCode.TabIndex = 5;
            // 
            // txtWareHouseCode
            // 
            this.txtWareHouseCode.Location = new System.Drawing.Point(546, 14);
            this.txtWareHouseCode.MaxLength = 6;
            this.txtWareHouseCode.Name = "txtWareHouseCode";
            this.txtWareHouseCode.Size = new System.Drawing.Size(48, 19);
            this.txtWareHouseCode.TabIndex = 7;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(241, 14);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 20);
            this.cmbType.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtInterval);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtRetry);
            this.panel1.Controls.Add(this.txtTimeOut);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtWareHouseCode);
            this.panel1.Controls.Add(this.txtEnterpriseCode);
            this.panel1.Controls.Add(this.txtSectionCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(17, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 208);
            this.panel1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(600, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "ロックキーのクリア";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtRetry
            // 
            this.txtRetry.Location = new System.Drawing.Point(80, 176);
            this.txtRetry.MaxLength = 6;
            this.txtRetry.Name = "txtRetry";
            this.txtRetry.Size = new System.Drawing.Size(34, 19);
            this.txtRetry.TabIndex = 12;
            this.txtRetry.Text = "3";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(240, 176);
            this.txtTimeOut.MaxLength = 6;
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(48, 19);
            this.txtTimeOut.TabIndex = 14;
            this.txtTimeOut.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "ロックタイムアウト(㍉秒）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "再試行回数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "待機時間(㍉秒）";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(385, 176);
            this.txtInterval.MaxLength = 6;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(48, 19);
            this.txtInterval.TabIndex = 17;
            this.txtInterval.Text = "10000";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(747, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
                    Application.EnableVisualStyles();
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
			IStockSlipRetPlnDB = MediationStockSlipRetPlnDB.GetStockSlipRetPlnDB();
            textBox1.Text = LoginInfoAcquisition.EnterpriseCode;
            txtEnterpriseCode.Text = LoginInfoAcquisition.EnterpriseCode;

# if DEBUG
            dataGridView1.DataSource = ShareCheckKeyList;

            Text = this.GetHashCode().ToString();
# endif
		}

        private string Test(ArrayList param)
        {
            string ret = "";

#if false
            foreach(object item in param)
            {
                if (item is ArrayList)
                {
                    ret += (string.IsNullOrEmpty(ret) ? "" : "\n") + this.Test(item as ArrayList);
                }
                else
                {
                    if (item is StockDetailWork)
                    {
                        StockDetailWork sdtl = item as StockDetailWork;

                        ret += (string.IsNullOrEmpty(ret) ? "" : "\n") + string.Format("SupplierFormal = {0}  StockSlipDtlNum = {1}  SupplierFormalSrc = {2}  StockSlipDtlNumSrc = {3}  AcptAnOdrStatusSync = {4}  SalesSlipDtlNumSync = {5}",
                            sdtl.SupplierFormal,
                            sdtl.StockSlipDtlNum,
                            sdtl.SupplierFormalSrc,
                            sdtl.StockSlipDtlNumSrc,
                            sdtl.AcptAnOdrStatusSync,
                            sdtl.SalesSlipDtlNumSync);
                    }
                    else if (item is SalesDetailWork)
                    {
                        SalesDetailWork sdtl = item as SalesDetailWork;

                        ret += (string.IsNullOrEmpty(ret) ? "" : "\n") + string.Format("AcptAnOdrStatus = {0}  SalesSlipDtlNum = {1}  AcptAnOdrStatusSrc = {2}  SalesSlipDtlNumSrc = {3}  SupplierFormalSync = {4}  StockSlipDtlNumSync = {5}",
                            sdtl.AcptAnOdrStatus,
                            sdtl.SalesSlipDtlNum,
                            sdtl.AcptAnOdrStatusSrc,
                            sdtl.SalesSlipDtlNumSrc,
                            sdtl.SupplierFormalSync,
                            sdtl.StockSlipDtlNumSync);
                    }
                }
            }
#endif
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
#if false 
            object paraList = new CustomSerializeArrayList();
            
            string retMsg;
            string retItemInfo;

            IOWriteCtrlOptWork opt = new IOWriteCtrlOptWork();

            Guid dtlrelationguid = Guid.NewGuid();

            for (int i = 0; i < 8; i++)
            {
                CustomSerializeArrayList slips = new CustomSerializeArrayList();

                switch (i)
                {
                    case 0:  // 見積
                    case 1:  // 受注
                    case 2:  // 売上
                    case 3:  // 出荷
                        {
                            slips.Add(new SalesSlipWork());

                            (slips[0] as SalesSlipWork).EnterpriseCode = "0113180842031000";
                            (slips[0] as SalesSlipWork).SectionCode = "000025";
                            (slips[0] as SalesSlipWork).AcptAnOdrStatus = 10 + i * 10;
    
                            slips.Add(new ArrayList());
                            (slips[1] as ArrayList).Add(new SalesDetailWork());

                            ((slips[1] as ArrayList)[0] as SalesDetailWork).EnterpriseCode = "0113180842031000"; 
                            ((slips[1] as ArrayList)[0] as SalesDetailWork).SectionCode = "000025";
                            ((slips[1] as ArrayList)[0] as SalesDetailWork).AcptAnOdrStatus = 10 + i * 10;

                            switch (i)
                            {
                                case 0:  // 見積
                                    {

                                        break;
                                    }
                                case 1:  // 受注
                                    {
                                        ((slips[1] as ArrayList)[0] as SalesDetailWork).AcptAnOdrStatusSrc = 10; // 見積
                                        ((slips[1] as ArrayList)[0] as SalesDetailWork).SupplierFormalSync = 2;  // 発注
                                        break;
                                    }
                                case 2:  // 売上
                                    {
                                        ((slips[1] as ArrayList)[0] as SalesDetailWork).AcptAnOdrStatusSrc = 40; // 出荷
                                        ((slips[1] as ArrayList)[0] as SalesDetailWork).SupplierFormalSync = 0;  // 仕入
                                        break;
                                    }
                                case 3:  // 出荷
                                    {
                                        ((slips[1] as ArrayList)[0] as SalesDetailWork).AcptAnOdrStatusSrc = 20; // 受注
                                        ((slips[1] as ArrayList)[0] as SalesDetailWork).SupplierFormalSync = 1;  // 入荷
                                        break;
                                    }
                            }
                            
                            ((slips[1] as ArrayList)[0] as SalesDetailWork).DtlRelationGuid = dtlrelationguid;
                            break;
                        }
                    case 4:  // 仕入
                    case 5:  // 入荷
                    case 6:  // 発注
                        {
                            slips.Add(new StockSlipWork());

                            (slips[0] as StockSlipWork).EnterpriseCode = "0113180842031000";
                            (slips[0] as StockSlipWork).SectionCode = "000025";
                            (slips[0] as StockSlipWork).SupplierFormal = i - 4;

                            slips.Add(new ArrayList());
                            (slips[1] as ArrayList).Add(new StockDetailWork());
                            ((slips[1] as ArrayList)[0] as StockDetailWork).EnterpriseCode = "0113180842031000"; 
                            ((slips[1] as ArrayList)[0] as StockDetailWork).SectionCode = "000025";
                            ((slips[1] as ArrayList)[0] as StockDetailWork).SupplierFormal = i - 4;

                            switch (i)
                            {
                                case 4:  // 仕入
                                    {
                                        ((slips[1] as ArrayList)[0] as StockDetailWork).SupplierFormalSrc = 1;     // 入荷
                                        ((slips[1] as ArrayList)[0] as StockDetailWork).AcptAnOdrStatusSync = 30;  // 売上
                                        break;
                                    }
                                case 5:  // 入荷
                                    {
                                        ((slips[1] as ArrayList)[0] as StockDetailWork).SupplierFormalSrc = 0;     // 発注
                                        ((slips[1] as ArrayList)[0] as StockDetailWork).AcptAnOdrStatusSync = 40;  // 出荷
                                        break;
                                    }
                                case 6:  // 発注
                                    {
                                        ((slips[1] as ArrayList)[0] as StockDetailWork).SupplierFormalSrc = -1;    // なし
                                        ((slips[1] as ArrayList)[0] as StockDetailWork).AcptAnOdrStatusSync = 20;  // 受注
                                        break;
                                    }
                            }


                            ((slips[1] as ArrayList)[0] as StockDetailWork).DtlRelationGuid = dtlrelationguid;

                            if (i == 6)
                            {
                                slips.RemoveAt(0);
                            }
                            break;
                        }
                    case 7:
                        {
                            slips.Add(new SalesTempWork());
                            (slips[0] as SalesTempWork).DtlRelationGuid = Guid.NewGuid();

                            break;
                        }
                }
                
                (paraList as CustomSerializeArrayList).Add(slips);
            }

            opt.CtrlStartingPoint = 0;
            (paraList as CustomSerializeArrayList).Add(opt);

            int status = this.IStockSlipRetPlnDB.Write(ref paraList, out retMsg, out retItemInfo);


            MessageBox.Show("status = " + status.ToString() + "\n" + Test(paraList as ArrayList));

#endif
        }

        private void button2_Click(object sender, EventArgs e)
        {
# if false
            ShareCheckType scType = ShareCheckType.None;
            try
            {
                scType = (ShareCheckType)Enum.Parse(typeof(ShareCheckType), cmbType.Text);
            }
            catch
            {

            }
            
            ShareCheckKeyList.Add(txtEnterpriseCode.Text, scType, txtSectionCode.Text, txtWareHouseCode.Text);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ShareCheckKeyList;
# endif
        }

        private void button3_Click(object sender, EventArgs e)
        {
#if false
# if !DEBUG
            object obj = new ArrayList(ShareCheckKeyList);
            int st = this.IStockSlipRetPlnDB.ShLock(ref obj, Convert.ToInt32(txtTimeOut.Text), Convert.ToInt32(txtRetry.Text), Convert.ToInt32(txtInterval.Text));

            ShareCheckKeyList.Clear();
            ShareCheckKeyList.AddRange((ShareCheckKey[])(obj as ArrayList).ToArray(typeof(ShareCheckKey)));

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ShareCheckKeyList;

            string stStr = string.Format("ST={0}({1})\r\n\r\n", Enum.GetName(typeof(ConstantManagement.DB_Status), st), st);

            foreach (ShareCheckKey key in ShareCheckKeyList)
            {
                stStr += string.Format("TYPE={0}  ENT={1}  SEC={2}  WAR={3} - RET={4}\r\n", Enum.GetName(typeof(ShareCheckType), key.Type),
                    key.EnterpriseCode, key.SectionCode, key.WarehouseCode, Enum.GetName(typeof(ShareCheckResult), key.Result));
            }

            MessageBox.Show(stStr, this.GetHashCode().ToString());
# endif
#endif
        }

        private void button4_Click(object sender, EventArgs e)
        {
# if DEBUG
            dataGridView1.DataSource = null;
            ShareCheckKeyList.Clear();
            dataGridView1.DataSource = ShareCheckKeyList;
# endif
        }

	}


}

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
//using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
    /// このFromはリモートテストの為だけのFromです
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		//private SalesTransitDtParaWork _salesTransitDtWork = null;

		//private SalesTransitDtParaWork _prevSalesTransitDtParaWork = null;
        private System.Windows.Forms.Button button8;

        private IBillDetailTableDB IbillDetailTableDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label1;
        private Label label2;
        private Button button11;
        private TextBox textBox2;
        private TextBox textBox5;
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private TextBox DetailsUnit;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DetailsUnit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0101150842020000";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(792, 235);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(83, 235);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "請求明細書発行";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 140);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(909, 89);
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
            this.button11.Location = new System.Drawing.Point(17, 235);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(17, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 19);
            this.textBox2.TabIndex = 59;
            this.textBox2.Text = "01";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(172, 44);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 19);
            this.textBox5.TabIndex = 63;
            this.textBox5.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "請求先コード";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(909, 231);
            this.dataGridView1.TabIndex = 64;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(16, 501);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(909, 190);
            this.dataGridView2.TabIndex = 65;
            // 
            // DetailsUnit
            // 
            this.DetailsUnit.Location = new System.Drawing.Point(172, 105);
            this.DetailsUnit.Name = "DetailsUnit";
            this.DetailsUnit.Size = new System.Drawing.Size(100, 19);
            this.DetailsUnit.TabIndex = 66;
            this.DetailsUnit.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(942, 703);
            this.Controls.Add(this.DetailsUnit);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
            IbillDetailTableDB = MediationBillDetailTableDB.GetBillDetailTableDB();
		}

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button9_Click(object sender, System.EventArgs e)
		{
			dataGridView1.DataSource = null;
			dataGridView2.DataSource = null;
            
            ArrayList al = new ArrayList();
            ExtrInfo_DemandDetailWork work = new ExtrInfo_DemandDetailWork();
            //企業コード
            work.EnterpriseCode = textBox1.Text;
            //計上拠点コード
            work.AddUpSecCode = textBox2.Text;
            //請求先コード
            work.ClaimCode = Convert.ToInt32(textBox5.Text);
            //計上日付（開始）
            work.AddUpADateSt = new DateTime(2007, 06, 01);
            //計上日付（終了）
            work.AddUpADateEd = new DateTime(2008, 10, 31);
            //
            work.IsExtractDepo = true;

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

            ExtrInfo_DemandDetailWork work = new ExtrInfo_DemandDetailWork();
            //企業コード
            work.EnterpriseCode = textBox1.Text;
            //計上拠点コード
            work.AddUpSecCode = textBox2.Text;
            //請求先コード
            work.ClaimCode = Convert.ToInt32(textBox5.Text);
            //計上日付（開始）
            work.AddUpADateSt = new DateTime(2006, 06, 01);
            //計上日付（終了）
            work.AddUpADateEd = new DateTime(2008, 10, 31);
            //
            work.IsExtractDepo = true;
            //
            work.DetailsUnit = Convert.ToInt32(DetailsUnit.Text);

            ArrayList tempList = null;

            object paraObj = (object)work;
			object retObj = null;

            int status = IbillDetailTableDB.SearchBillDetailTable(out retObj, paraObj);

			if (status != 0)
			{
                Text = "該当データ無し:status = " + status.ToString();
			}
			else
			{
                tempList = retObj as ArrayList;

                dataGridView1.DataSource = tempList;
                Text = "HIT 件数：" + tempList.Count.ToString();
                
			}
		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
            ExtrInfo_DemandDetailWork extrInfo_DemandDetailWork = new ExtrInfo_DemandDetailWork();
			extrInfo_DemandDetailWork.EnterpriseCode = textBox1.Text;
            extrInfo_DemandDetailWork.AddUpSecCode = textBox2.Text;
            extrInfo_DemandDetailWork.ClaimCode = Convert.ToInt32(textBox5.Text);
            ArrayList al = dataGridView1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
			al.Add(extrInfo_DemandDetailWork);
			dataGridView1.DataSource= null;
			dataGridView2.DataSource = al;
		}

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }


	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Collections.Generic;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Remoting.ParamData;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
    /// このFromはリモートテストの為だけのFromです
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		private TbsPartsCodeWork _TbsPartsCodeWork = null;

        private TbsPartsCodeLcDB TbsPartsCodeLcDB;

        private System.Windows.Forms.Button button8;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
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
this.dataGrid1 = new System.Windows.Forms.DataGrid();
this.button9 = new System.Windows.Forms.Button();
this.button8 = new System.Windows.Forms.Button();
this.dataGrid2 = new System.Windows.Forms.DataGrid();
this.textBox2 = new System.Windows.Forms.TextBox();
this.textBox3 = new System.Windows.Forms.TextBox();
this.textBox4 = new System.Windows.Forms.TextBox();
this.button1 = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
this.SuspendLayout();
// 
// textBox1
// 
this.textBox1.Location = new System.Drawing.Point(16, 16);
this.textBox1.Name = "textBox1";
this.textBox1.Size = new System.Drawing.Size(288, 19);
this.textBox1.TabIndex = 1;
this.textBox1.Text = "0140150842030000";
// 
// dataGrid1
// 
this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.dataGrid1.DataMember = "";
this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
this.dataGrid1.Location = new System.Drawing.Point(16, 284);
this.dataGrid1.Name = "dataGrid1";
this.dataGrid1.Size = new System.Drawing.Size(909, 252);
this.dataGrid1.TabIndex = 13;
// 
// button9
// 
this.button9.Location = new System.Drawing.Point(17, 139);
this.button9.Name = "button9";
this.button9.Size = new System.Drawing.Size(75, 23);
this.button9.TabIndex = 20;
this.button9.Text = "Clear";
this.button9.Click += new System.EventHandler(this.button9_Click);
// 
// button8
// 
this.button8.Location = new System.Drawing.Point(106, 255);
this.button8.Name = "button8";
this.button8.Size = new System.Drawing.Size(88, 23);
this.button8.TabIndex = 33;
this.button8.Text = "Search";
this.button8.Click += new System.EventHandler(this.button8_Click);
// 
// dataGrid2
// 
this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
this.dataGrid2.DataMember = "";
this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
this.dataGrid2.Location = new System.Drawing.Point(16, 168);
this.dataGrid2.Name = "dataGrid2";
this.dataGrid2.Size = new System.Drawing.Size(909, 81);
this.dataGrid2.TabIndex = 39;
// 
// textBox2
// 
this.textBox2.Location = new System.Drawing.Point(16, 41);
this.textBox2.Name = "textBox2";
this.textBox2.Size = new System.Drawing.Size(288, 19);
this.textBox2.TabIndex = 40;
// 
// textBox3
// 
this.textBox3.Location = new System.Drawing.Point(17, 66);
this.textBox3.Name = "textBox3";
this.textBox3.Size = new System.Drawing.Size(288, 19);
this.textBox3.TabIndex = 41;
// 
// textBox4
// 
this.textBox4.Location = new System.Drawing.Point(17, 91);
this.textBox4.Name = "textBox4";
this.textBox4.Size = new System.Drawing.Size(288, 19);
this.textBox4.TabIndex = 42;
// 
// button1
// 
this.button1.Location = new System.Drawing.Point(12, 255);
this.button1.Name = "button1";
this.button1.Size = new System.Drawing.Size(88, 23);
this.button1.TabIndex = 43;
this.button1.Text = "Read";
this.button1.Click += new System.EventHandler(this.button1_Click);
// 
// Form1
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
this.ClientSize = new System.Drawing.Size(941, 550);
this.Controls.Add(this.button1);
this.Controls.Add(this.textBox4);
this.Controls.Add(this.textBox3);
this.Controls.Add(this.textBox2);
this.Controls.Add(this.dataGrid2);
this.Controls.Add(this.button8);
this.Controls.Add(this.textBox1);
this.Controls.Add(this.button9);
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
            TbsPartsCodeWork work = new TbsPartsCodeWork();
            //work.EnterpriseCode = textBox1.Text;
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
			ArrayList al = parabyte as ArrayList;
            TbsPartsCodeLcDB = new TbsPartsCodeLcDB();
            
            List<TbsPartsCodeWork> tbsPartsCodeWorkList = new List<TbsPartsCodeWork>();
            _TbsPartsCodeWork = al[0] as TbsPartsCodeWork;

            int status = TbsPartsCodeLcDB.Search(out tbsPartsCodeWorkList, _TbsPartsCodeWork, 0);

			if (status != 0)
			{
				Text = "該当データ無し : status = " + status;
			}
			else
			{

				Text = "該当データ有り  HIT "+((List<TbsPartsCodeWork>)tbsPartsCodeWorkList).Count.ToString()+"件";
				
				dataGrid1.DataSource = tbsPartsCodeWorkList;
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
            //button9_Click(sender, e);

			object parabyte = dataGrid2.DataSource;
			ArrayList al = parabyte as ArrayList;
            TbsPartsCodeLcDB = new TbsPartsCodeLcDB();
            
            TbsPartsCodeWork TbsPartsCodeWork = new TbsPartsCodeWork();
            _TbsPartsCodeWork = al[0] as TbsPartsCodeWork;

			int status = TbsPartsCodeLcDB.Read(ref _TbsPartsCodeWork, 0);

			if (status != 0)
			{
				Text = "該当データ無し : status = " + status;
			}
			else
			{

				Text = "該当データ有り  HIT 1件";
                ArrayList readdata = new ArrayList();
                readdata.Add(_TbsPartsCodeWork);

                dataGrid1.DataSource = readdata;

			}
        
        }

	}
}

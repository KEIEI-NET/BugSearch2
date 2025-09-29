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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button9;

		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private ICustSlipNoSetDB ICustSlipNoSetDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
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
this.textBox1 = new System.Windows.Forms.TextBox();
this.dataGrid1 = new System.Windows.Forms.DataGrid();
this.button9 = new System.Windows.Forms.Button();
this.button8 = new System.Windows.Forms.Button();
this.button10 = new System.Windows.Forms.Button();
this.button11 = new System.Windows.Forms.Button();
this.button13 = new System.Windows.Forms.Button();
this.button14 = new System.Windows.Forms.Button();
this.button15 = new System.Windows.Forms.Button();
this.dataGrid2 = new System.Windows.Forms.DataGrid();
this.textBox2 = new System.Windows.Forms.TextBox();
this.textBox3 = new System.Windows.Forms.TextBox();
this.textBox4 = new System.Windows.Forms.TextBox();
((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
this.SuspendLayout();
//
// button1
//
this.button1.Location = new System.Drawing.Point(312, 16);
this.button1.Name = "button1";
this.button1.Size = new System.Drawing.Size(75, 23);
this.button1.TabIndex = 0;
this.button1.Text = "Read";
this.button1.Click += new System.EventHandler(this.button1_Click);
//
// textBox1
//
this.textBox1.Location = new System.Drawing.Point(16, 16);
this.textBox1.Name = "textBox1";
this.textBox1.Size = new System.Drawing.Size(288, 19);
this.textBox1.TabIndex = 1;
this.textBox1.Text = "TBS1";
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
this.button8.Location = new System.Drawing.Point(83, 255);
this.button8.Name = "button8";
this.button8.Size = new System.Drawing.Size(88, 23);
this.button8.TabIndex = 33;
this.button8.Text = "Search";
this.button8.Click += new System.EventHandler(this.button8_Click);
//
// button10
//
this.button10.Location = new System.Drawing.Point(289, 255);
this.button10.Name = "button10";
this.button10.Size = new System.Drawing.Size(72, 23);
this.button10.TabIndex = 34;
this.button10.Text = "WriteGrid";
this.button10.Click += new System.EventHandler(this.button10_Click);
//
// button11
//
this.button11.Location = new System.Drawing.Point(17, 255);
this.button11.Name = "button11";
this.button11.Size = new System.Drawing.Size(60, 23);
this.button11.TabIndex = 35;
this.button11.Text = "AddRow";
this.button11.Click += new System.EventHandler(this.button11_Click);
//
// button13
//
this.button13.Location = new System.Drawing.Point(361, 255);
this.button13.Name = "button13";
this.button13.Size = new System.Drawing.Size(72, 23);
this.button13.TabIndex = 36;
this.button13.Text = "LogDelGrid";
this.button13.Click += new System.EventHandler(this.button13_Click);
//
// button14
//
this.button14.Location = new System.Drawing.Point(433, 255);
this.button14.Name = "button14";
this.button14.Size = new System.Drawing.Size(72, 23);
this.button14.TabIndex = 37;
this.button14.Text = "RevGrid";
this.button14.Click += new System.EventHandler(this.button14_Click);
//
// button15
//
this.button15.Location = new System.Drawing.Point(505, 255);
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
// Form1
//
this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
this.ClientSize = new System.Drawing.Size(941, 550);
this.Controls.Add(this.textBox4);
this.Controls.Add(this.textBox3);
this.Controls.Add(this.textBox2);
this.Controls.Add(this.dataGrid2);
this.Controls.Add(this.button15);
this.Controls.Add(this.button14);
this.Controls.Add(this.button13);
this.Controls.Add(this.button11);
this.Controls.Add(this.button10);
this.Controls.Add(this.button8);
this.Controls.Add(this.textBox1);
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
        /// プライマリキー値を設定
        /// </summary>
        /// <param name="CustSlipNoSetWork"></param>
        private void SetKey(ref CustSlipNoSetWork CustSlipNoSetWork)
        {
            CustSlipNoSetWork.EnterpriseCode = textBox1.Text;
            //↓以下に企業コード以外のキー項目をセットするコードを記述

        }

        /// <summary>
        /// 1件読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            object parabyte = new CustSlipNoSetWork();
			CustSlipNoSetWork CustSlipNoSetWork = parabyte as CustSlipNoSetWork;

            this.SetKey(ref CustSlipNoSetWork);

			int status = ICustSlipNoSetDB.Read(ref parabyte, 0);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り";

                CustomSerializeArrayList al = new CustomSerializeArrayList();
                al.Add(parabyte);
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
			ICustSlipNoSetDB = MediationCustSlipNoSetDB.GetCustSlipNoSetDB();
			textBox1.Text = LoginInfoAcquisition.EnterpriseCode;
#if DEBUG
            this.Text = "CustSlipNoSet - Debug";
#else
            this.Text = "CustSlipNoSet - Release";
#endif
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
            CustomSerializeArrayList al = new CustomSerializeArrayList();
            CustSlipNoSetWork CustSlipNoSetWork = new CustSlipNoSetWork();
            this.SetKey(ref CustSlipNoSetWork);
            al.Add(CustSlipNoSetWork);
            dataGrid2.DataSource = al;
		}

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button8_Click(object sender, System.EventArgs e)
		{
            object parabyte = (dataGrid2.DataSource as CustomSerializeArrayList)[0];
			object objCustSlipNoSet = new CustomSerializeArrayList();

			int status = ICustSlipNoSetDB.Search(ref objCustSlipNoSet, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{

				Text = "該当データ有り  HIT "+((CustomSerializeArrayList)objCustSlipNoSet).Count.ToString()+"件";

				dataGrid1.DataSource = objCustSlipNoSet;
			}
		}

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
			object objCustSlipNoSetList = dataGrid1.DataSource;

			int status = ICustSlipNoSetDB.Write(ref objCustSlipNoSetList);
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
				dataGrid1.DataSource = objCustSlipNoSetList;
			}
		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
			CustSlipNoSetWork CustSlipNoSetWork = new CustSlipNoSetWork();
            this.SetKey(ref CustSlipNoSetWork);
			CustomSerializeArrayList al = dataGrid1.DataSource as CustomSerializeArrayList;
			if(al == null)al = new CustomSerializeArrayList();
			al.Add(CustSlipNoSetWork);
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
            object objCustSlipNoSetList = dataGrid1.DataSource;

            int status = ICustSlipNoSetDB.LogicalDelete(ref objCustSlipNoSetList);
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
                dataGrid1.DataSource = objCustSlipNoSetList;
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            object objCustSlipNoSetList = dataGrid1.DataSource;

            int status = ICustSlipNoSetDB.Delete(objCustSlipNoSetList);
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
                //dataGrid1.DataSource = objCustSlipNoSetList;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            object objCustSlipNoSetList = dataGrid1.DataSource;

            int status = ICustSlipNoSetDB.RevivalLogicalDelete(ref objCustSlipNoSetList);
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
                dataGrid1.DataSource = objCustSlipNoSetList;
            }
        }
	}
}

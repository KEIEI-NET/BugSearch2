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
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Write_Button;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button Delete_Button;
		private System.Windows.Forms.Button Search_Button;
		private System.Windows.Forms.TextBox tb1;
		private System.Windows.Forms.TextBox LogicalDeletetextBox;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb2;

        private DmdPrtPtnSetWork dmdPrtPtnSetWork = null;
        private IDmdPrtPtnSetDB IdmdPrtPtnSetDB = null;

        private static string[] _parameter;
        private Label label14;
        private Label label3;
        private Label label4;
        private TextBox tb3;
        private TextBox tb4;
        private TextBox tb5;
        private Button Read_Button;
        private Button LogicalDelete_Button;
        private Button Revival_Button;
        private DataGrid dataGrid1;
        private Label label7;
        private TextBox tb6;
        private TextBox tb7;
        private Label label2;
        private Label label6;
        private Label label8;
        private Label label9;
        private TextBox tb9;
        private TextBox tb8;
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Write_Button = new System.Windows.Forms.Button();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LogicalDeletetextBox = new System.Windows.Forms.TextBox();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Search_Button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.Read_Button = new System.Windows.Forms.Button();
            this.LogicalDelete_Button = new System.Windows.Forms.Button();
            this.Revival_Button = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.tb6 = new System.Windows.Forms.TextBox();
            this.tb7 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb9 = new System.Windows.Forms.TextBox();
            this.tb8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(184, 33);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(288, 19);
            this.tb1.TabIndex = 5;
            this.tb1.Text = "0113180842030000";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(184, 58);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(288, 19);
            this.tb2.TabIndex = 6;
            this.tb2.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "拠点コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Write_Button
            // 
            this.Write_Button.Location = new System.Drawing.Point(478, 56);
            this.Write_Button.Name = "Write_Button";
            this.Write_Button.Size = new System.Drawing.Size(85, 23);
            this.Write_Button.TabIndex = 1;
            this.Write_Button.Text = "Write";
            this.Write_Button.Click += new System.EventHandler(this.Write_Button_Click);
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(476, 178);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(85, 23);
            this.Clear_Button.TabIndex = 4;
            this.Clear_Button.Text = "Clear";
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "論理削除区分";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogicalDeletetextBox
            // 
            this.LogicalDeletetextBox.Location = new System.Drawing.Point(184, 184);
            this.LogicalDeletetextBox.Name = "LogicalDeletetextBox";
            this.LogicalDeletetextBox.Size = new System.Drawing.Size(24, 19);
            this.LogicalDeletetextBox.TabIndex = 12;
            this.LogicalDeletetextBox.Text = "01";
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(478, 131);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(85, 23);
            this.Delete_Button.TabIndex = 2;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(478, 31);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(85, 23);
            this.Search_Button.TabIndex = 0;
            this.Search_Button.Text = "SearchA";
            this.Search_Button.Click += new System.EventHandler(this.SearchA_Button_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(24, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 15);
            this.label10.TabIndex = 51;
            this.label10.Text = "企業コード";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(24, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(448, 22);
            this.label11.TabIndex = 50;
            this.label11.Text = "その他の設定項目";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(24, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 15);
            this.label14.TabIndex = 54;
            this.label14.Text = "得意先コード";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 55;
            this.label3.Text = "請求書パターン番号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(30, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 15);
            this.label4.TabIndex = 56;
            this.label4.Text = "請求書明細パターン番号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(184, 83);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(288, 19);
            this.tb3.TabIndex = 8;
            this.tb3.Text = "1";
            // 
            // tb4
            // 
            this.tb4.Location = new System.Drawing.Point(184, 135);
            this.tb4.Name = "tb4";
            this.tb4.Size = new System.Drawing.Size(288, 19);
            this.tb4.TabIndex = 9;
            this.tb4.Text = "1";
            // 
            // tb5
            // 
            this.tb5.Location = new System.Drawing.Point(184, 159);
            this.tb5.Name = "tb5";
            this.tb5.Size = new System.Drawing.Size(288, 19);
            this.tb5.TabIndex = 10;
            this.tb5.Text = "1";
            // 
            // Read_Button
            // 
            this.Read_Button.Location = new System.Drawing.Point(478, 8);
            this.Read_Button.Name = "Read_Button";
            this.Read_Button.Size = new System.Drawing.Size(85, 23);
            this.Read_Button.TabIndex = 59;
            this.Read_Button.Text = "Read";
            this.Read_Button.Click += new System.EventHandler(this.Read_Button_Click);
            // 
            // LogicalDelete_Button
            // 
            this.LogicalDelete_Button.Location = new System.Drawing.Point(478, 81);
            this.LogicalDelete_Button.Name = "LogicalDelete_Button";
            this.LogicalDelete_Button.Size = new System.Drawing.Size(85, 23);
            this.LogicalDelete_Button.TabIndex = 60;
            this.LogicalDelete_Button.Text = "LogicalDelete";
            this.LogicalDelete_Button.Click += new System.EventHandler(this.LogicalDelete_Button_Click);
            // 
            // Revival_Button
            // 
            this.Revival_Button.Location = new System.Drawing.Point(478, 106);
            this.Revival_Button.Name = "Revival_Button";
            this.Revival_Button.Size = new System.Drawing.Size(85, 23);
            this.Revival_Button.TabIndex = 61;
            this.Revival_Button.Text = "Revival";
            this.Revival_Button.Click += new System.EventHandler(this.Revival_Button_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 313);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(551, 188);
            this.dataGrid1.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(24, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(448, 22);
            this.label7.TabIndex = 63;
            this.label7.Text = "キー項目";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb6
            // 
            this.tb6.Location = new System.Drawing.Point(184, 209);
            this.tb6.Name = "tb6";
            this.tb6.Size = new System.Drawing.Size(288, 19);
            this.tb6.TabIndex = 64;
            this.tb6.Text = "1";
            // 
            // tb7
            // 
            this.tb7.Location = new System.Drawing.Point(184, 234);
            this.tb7.Name = "tb7";
            this.tb7.Size = new System.Drawing.Size(288, 19);
            this.tb7.TabIndex = 65;
            this.tb7.Text = "1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "請求書パターン名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(30, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 15);
            this.label6.TabIndex = 67;
            this.label6.Text = "請求書明細パターン名称";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(30, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 15);
            this.label8.TabIndex = 71;
            this.label8.Text = "得意先名称２";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(30, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 15);
            this.label9.TabIndex = 70;
            this.label9.Text = "得意先名称１";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb9
            // 
            this.tb9.Location = new System.Drawing.Point(184, 288);
            this.tb9.Name = "tb9";
            this.tb9.Size = new System.Drawing.Size(288, 19);
            this.tb9.TabIndex = 69;
            this.tb9.Text = "1";
            // 
            // tb8
            // 
            this.tb8.Location = new System.Drawing.Point(184, 263);
            this.tb8.Name = "tb8";
            this.tb8.Size = new System.Drawing.Size(288, 19);
            this.tb8.TabIndex = 68;
            this.tb8.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(573, 513);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb9);
            this.Controls.Add(this.tb8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb7);
            this.Controls.Add(this.tb6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.Revival_Button);
            this.Controls.Add(this.LogicalDelete_Button);
            this.Controls.Add(this.Read_Button);
            this.Controls.Add(this.tb5);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.LogicalDeletetextBox);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.Write_Button);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile , false);
            IdmdPrtPtnSetDB = MediationDmdPrtPtnSetDB.GetDmdPrtPtnSetDB();
		}

        private void Read_Button_Click(object sender, EventArgs e)
        {
            dmdPrtPtnSetWork = new DmdPrtPtnSetWork();

            dmdPrtPtnSetWork.EnterpriseCode = tb1.Text;
            dmdPrtPtnSetWork.SectionCode = tb2.Text;
            dmdPrtPtnSetWork.CustomerCode = Convert.ToInt32(tb3.Text);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
            int status = IdmdPrtPtnSetDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));

                Text = "該当データ有り";
                tb1.Text = dmdPrtPtnSetWork.EnterpriseCode;
                tb2.Text = dmdPrtPtnSetWork.SectionCode;
                tb3.Text = dmdPrtPtnSetWork.CustomerCode.ToString();
                tb4.Text = dmdPrtPtnSetWork.DemandPtnNo.ToString();
                tb5.Text = dmdPrtPtnSetWork.DmdDtlPtnNo.ToString();
                tb6.Text = dmdPrtPtnSetWork.DemandPtnNoNm;
                tb7.Text = dmdPrtPtnSetWork.DmdDtlPtnNoNm;
                tb8.Text = dmdPrtPtnSetWork.Name;
                tb9.Text = dmdPrtPtnSetWork.Name2;

                LogicalDeletetextBox.Text = dmdPrtPtnSetWork.LogicalDeleteCode.ToString();
            }
        }

        private void SearchA_Button_Click(object sender, System.EventArgs e)
        {
            ArrayList paraarray = new ArrayList();

            DmdPrtPtnSetWork　bsmkstdstuWork = new DmdPrtPtnSetWork();
            bsmkstdstuWork.EnterpriseCode = tb1.Text;
            bsmkstdstuWork.SectionCode = tb2.Text;

            object paraobj = bsmkstdstuWork;
            object retobj = null;

            int status = IdmdPrtPtnSetDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";

                dataGrid1.DataSource = retobj;
            }
        }

        private void Write_Button_Click(object sender, System.EventArgs e)
		{
            if (dmdPrtPtnSetWork == null) dmdPrtPtnSetWork = new DmdPrtPtnSetWork();
            dmdPrtPtnSetWork.EnterpriseCode = tb1.Text;
            dmdPrtPtnSetWork.LogicalDeleteCode = System.Convert.ToInt32(LogicalDeletetextBox.Text);
            dmdPrtPtnSetWork.SectionCode = tb2.Text;
            dmdPrtPtnSetWork.CustomerCode = Convert.ToInt32(tb3.Text);
            dmdPrtPtnSetWork.DemandPtnNo = Convert.ToInt32(tb4.Text);
            dmdPrtPtnSetWork.DmdDtlPtnNo = Convert.ToInt32(tb5.Text);

			byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
			int status = IdmdPrtPtnSetDB.Write(ref parabyte);
            
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
                else
                {
                    MessageBox.Show("更新失敗：status=" + status.ToString());
                }
			}
			else
			{
				Text = "更新成功";
                dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));
			}
		}

        private void LogicalDelete_Button_Click(object sender, EventArgs e)
        {
            if (dmdPrtPtnSetWork != null)
            {
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
                int status = IdmdPrtPtnSetDB.LogicalDelete(ref parabyte);
                if (status != 0)
                {
                    Text = "削除失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                    }
                    else
                    {
                        MessageBox.Show("削除失敗：status=" + status.ToString());
                    }
                }
                else
                {
                    Text = "削除成功";
                    dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));
                    LogicalDeletetextBox.Text = dmdPrtPtnSetWork.LogicalDeleteCode.ToString();
                }
            }
            else
            {
                MessageBox.Show("LogicalDelete対象データが読み込まれていません");
            }
        }

        private void Revival_Button_Click(object sender, EventArgs e)
        {
            if (dmdPrtPtnSetWork != null)
            {
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
                int status = IdmdPrtPtnSetDB.Revival(ref parabyte);
                if (status != 0)
                {
                    Text = "復活失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                    }
                    else
                    {
                        MessageBox.Show("復活失敗　status=" + status.ToString());
                    }
                }
                else
                {
                    Text = "復活成功";
                    dmdPrtPtnSetWork = (DmdPrtPtnSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnSetWork));
                    LogicalDeletetextBox.Text = dmdPrtPtnSetWork.LogicalDeleteCode.ToString();
                }
            }
            else
            {
                MessageBox.Show("Revival対象データが読み込まれていません");
            }
        }

        private void Delete_Button_Click(object sender, System.EventArgs e)
        {
            if (dmdPrtPtnSetWork != null)
            {
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnSetWork);
                int status = IdmdPrtPtnSetDB.Delete(parabyte);
                if (status != 0)
                {
                    Text = "削除失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                    }
                    else
                    {
                        MessageBox.Show("削除失敗：status=" + status.ToString());
                    }
                }
                else
                {
                    Text = "削除成功";
                }
            }
            else
            {
                MessageBox.Show("Delete対象データが読み込まれていません");
            }
        }

        private void Clear_Button_Click(object sender, System.EventArgs e)
		{
			dmdPrtPtnSetWork = null;
			dataGrid1.DataSource = null;
		}
	}
}

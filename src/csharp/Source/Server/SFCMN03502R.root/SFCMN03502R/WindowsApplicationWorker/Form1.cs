using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Collections.Generic;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox Enterprise_textBox;
		private System.Windows.Forms.TextBox EmployeeCd_textBox1;
        private System.Windows.Forms.TextBox FeliCaMngKind_textBox1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private IContainer components;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LogicalDelete_textBox1;
		private System.Windows.Forms.Button button12;
		private FeliCaMngWork _felicaMngWork = new FeliCaMngWork();
		private FeliCaMngWork _felicaMngWork2 = new FeliCaMngWork();
		private System.Windows.Forms.Button button7;
		private IFeliCaMngDB IfelicaMngDB = null;
		private static string[] _parameter;
		private TextBox FeliCaIDm_textBox1;
        private Label label8;
		private TextBox FeliCaIDm_textBox2;
        private TextBox LogicalDelete_textBox2;
		private TextBox FeliCaMngKind_textBox2;
        private TextBox EmployeeCd_textBox2;
		private Button button8;
        private TextBox Updatetime_textBox2;
        private TextBox Updatetime_textBox1;
        private Label label3;
        private TArrowKeyControl tArrowKeyControl1;
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.Enterprise_textBox = new System.Windows.Forms.TextBox();
            this.EmployeeCd_textBox1 = new System.Windows.Forms.TextBox();
            this.FeliCaMngKind_textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LogicalDelete_textBox1 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.FeliCaIDm_textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.FeliCaIDm_textBox2 = new System.Windows.Forms.TextBox();
            this.LogicalDelete_textBox2 = new System.Windows.Forms.TextBox();
            this.FeliCaMngKind_textBox2 = new System.Windows.Forms.TextBox();
            this.EmployeeCd_textBox2 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.Updatetime_textBox2 = new System.Windows.Forms.TextBox();
            this.Updatetime_textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Enterprise_textBox
            // 
            this.Enterprise_textBox.Location = new System.Drawing.Point(16, 6);
            this.Enterprise_textBox.Name = "Enterprise_textBox";
            this.Enterprise_textBox.Size = new System.Drawing.Size(288, 19);
            this.Enterprise_textBox.TabIndex = 1;
            this.Enterprise_textBox.Text = "0140150842030050";
            // 
            // EmployeeCd_textBox1
            // 
            this.EmployeeCd_textBox1.Location = new System.Drawing.Point(114, 141);
            this.EmployeeCd_textBox1.Name = "EmployeeCd_textBox1";
            this.EmployeeCd_textBox1.Size = new System.Drawing.Size(164, 19);
            this.EmployeeCd_textBox1.TabIndex = 2;
            this.EmployeeCd_textBox1.Text = "test";
            // 
            // FeliCaMngKind_textBox1
            // 
            this.FeliCaMngKind_textBox1.Location = new System.Drawing.Point(114, 116);
            this.FeliCaMngKind_textBox1.Name = "FeliCaMngKind_textBox1";
            this.FeliCaMngKind_textBox1.Size = new System.Drawing.Size(164, 19);
            this.FeliCaMngKind_textBox1.TabIndex = 3;
            this.FeliCaMngKind_textBox1.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "従業員コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "フェリカ管理種別";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(613, 90);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(304, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(12, 219);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1028, 413);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(490, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "SearchGrid";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(401, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(592, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "LogicalDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 32);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogicalDelete_textBox1
            // 
            this.LogicalDelete_textBox1.Location = new System.Drawing.Point(114, 69);
            this.LogicalDelete_textBox1.Name = "LogicalDelete_textBox1";
            this.LogicalDelete_textBox1.Size = new System.Drawing.Size(24, 19);
            this.LogicalDelete_textBox1.TabIndex = 23;
            this.LogicalDelete_textBox1.Text = "0";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(694, 6);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(88, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(490, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Revival";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // FeliCaIDm_textBox1
            // 
            this.FeliCaIDm_textBox1.Location = new System.Drawing.Point(114, 92);
            this.FeliCaIDm_textBox1.Name = "FeliCaIDm_textBox1";
            this.FeliCaIDm_textBox1.Size = new System.Drawing.Size(164, 19);
            this.FeliCaIDm_textBox1.TabIndex = 33;
            this.FeliCaIDm_textBox1.Text = "1";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(14, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "FeliCaIDm";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FeliCaIDm_textBox2
            // 
            this.FeliCaIDm_textBox2.Location = new System.Drawing.Point(312, 92);
            this.FeliCaIDm_textBox2.Name = "FeliCaIDm_textBox2";
            this.FeliCaIDm_textBox2.Size = new System.Drawing.Size(164, 19);
            this.FeliCaIDm_textBox2.TabIndex = 42;
            this.FeliCaIDm_textBox2.Text = "2";
            // 
            // LogicalDelete_textBox2
            // 
            this.LogicalDelete_textBox2.Location = new System.Drawing.Point(312, 69);
            this.LogicalDelete_textBox2.Name = "LogicalDelete_textBox2";
            this.LogicalDelete_textBox2.Size = new System.Drawing.Size(24, 19);
            this.LogicalDelete_textBox2.TabIndex = 41;
            this.LogicalDelete_textBox2.Text = "0";
            // 
            // FeliCaMngKind_textBox2
            // 
            this.FeliCaMngKind_textBox2.Location = new System.Drawing.Point(312, 116);
            this.FeliCaMngKind_textBox2.Name = "FeliCaMngKind_textBox2";
            this.FeliCaMngKind_textBox2.Size = new System.Drawing.Size(164, 19);
            this.FeliCaMngKind_textBox2.TabIndex = 38;
            this.FeliCaMngKind_textBox2.Text = "1";
            // 
            // EmployeeCd_textBox2
            // 
            this.EmployeeCd_textBox2.Location = new System.Drawing.Point(312, 141);
            this.EmployeeCd_textBox2.Name = "EmployeeCd_textBox2";
            this.EmployeeCd_textBox2.Size = new System.Drawing.Size(164, 19);
            this.EmployeeCd_textBox2.TabIndex = 37;
            this.EmployeeCd_textBox2.Text = "test";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(312, 35);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 44;
            this.button8.Text = "Read2";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Updatetime_textBox2
            // 
            this.Updatetime_textBox2.Location = new System.Drawing.Point(312, 166);
            this.Updatetime_textBox2.Name = "Updatetime_textBox2";
            this.Updatetime_textBox2.Size = new System.Drawing.Size(164, 19);
            this.Updatetime_textBox2.TabIndex = 47;
            // 
            // Updatetime_textBox1
            // 
            this.Updatetime_textBox1.Location = new System.Drawing.Point(114, 166);
            this.Updatetime_textBox1.Name = "Updatetime_textBox1";
            this.Updatetime_textBox1.Size = new System.Drawing.Size(164, 19);
            this.Updatetime_textBox1.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 46;
            this.label3.Text = "更新日時";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1052, 644);
            this.Controls.Add(this.Updatetime_textBox2);
            this.Controls.Add(this.Updatetime_textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.FeliCaIDm_textBox2);
            this.Controls.Add(this.LogicalDelete_textBox2);
            this.Controls.Add(this.FeliCaMngKind_textBox2);
            this.Controls.Add(this.EmployeeCd_textBox2);
            this.Controls.Add(this.FeliCaIDm_textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.LogicalDelete_textBox1);
            this.Controls.Add(this.FeliCaMngKind_textBox1);
            this.Controls.Add(this.EmployeeCd_textBox1);
            this.Controls.Add(this.Enterprise_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IfelicaMngDB = MediationFeliCaMngDB.GetFeliCaMngDB();
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
            //FeliCa管理ログオフのメッセージを表示
            if (_form != null)	TMsgDisp.Show(_form.Owner,	emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            else				TMsgDisp.Show(				emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
		}

		// Read
		private void button1_Click(object sender, System.EventArgs e)
		{
			FeliCaMngWork felicaMngWork = new FeliCaMngWork();
            felicaMngWork.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWork.FeliCaIDm = FeliCaIDm_textBox1.Text;
            felicaMngWork.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text, 0);

            object paraObj = (object)felicaMngWork;

            int status = IfelicaMngDB.Read(ref paraObj);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り";
                _felicaMngWork = (FeliCaMngWork)paraObj;
				Enterprise_textBox.Text = _felicaMngWork.EnterpriseCode.ToString();
                LogicalDelete_textBox1.Text = _felicaMngWork.LogicalDeleteCode.ToString();
                FeliCaMngKind_textBox1.Text = _felicaMngWork.FeliCaMngKind.ToString();
                FeliCaIDm_textBox1.Text = _felicaMngWork.FeliCaIDm;
                EmployeeCd_textBox1.Text = _felicaMngWork.EmployeeCode;
                Updatetime_textBox1.Text = _felicaMngWork.UpdateDateTime.Ticks.ToString();
			}
		}

		// Read2
		private void button8_Click( object sender, EventArgs e )
		{
            FeliCaMngWork felicaMngWork = new FeliCaMngWork();
            felicaMngWork.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWork.FeliCaIDm = FeliCaIDm_textBox2.Text;
            felicaMngWork.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox2.Text, 0);

            object paraObj = (object)felicaMngWork;

            int status = IfelicaMngDB.Read(ref paraObj);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り";
                _felicaMngWork = (FeliCaMngWork)paraObj;
                Enterprise_textBox.Text = _felicaMngWork.EnterpriseCode.ToString();
                LogicalDelete_textBox2.Text = _felicaMngWork.LogicalDeleteCode.ToString();
                FeliCaMngKind_textBox2.Text = _felicaMngWork.FeliCaMngKind.ToString();
                FeliCaIDm_textBox2.Text = _felicaMngWork.FeliCaIDm;
                EmployeeCd_textBox2.Text = _felicaMngWork.EmployeeCode;
                Updatetime_textBox2.Text = _felicaMngWork.UpdateDateTime.Ticks.ToString();
            }
		}

        // Search Grid
		private void button2_Click(object sender, System.EventArgs e)
		{
			FeliCaMngWork felicaMngWork = new FeliCaMngWork();
			felicaMngWork.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWork.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text, 0);
			ArrayList al = new ArrayList();

			object paraobj = (object)felicaMngWork;
			object retobj = null;

			int status = IfelicaMngDB.Search(out retobj, paraobj, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetDataAll);
			listBox1.Items.Clear();
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				Text = "該当データ有り  HIT "+ ((ArrayList)retobj).Count.ToString()+"件";

                foreach (FeliCaMngWork ret in (ArrayList)retobj)
                {
                    listBox1.Items.Add(ret.ToString());
					listBox1.Update();
				}
			}
		}

		// Search
		private void button3_Click(object sender, System.EventArgs e)
		{
            FeliCaMngWork felicaMngWork = new FeliCaMngWork();
            felicaMngWork.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWork.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text, 0);
            ArrayList al = new ArrayList();

            object paraobj = (object)felicaMngWork;
            object retobj = null;

            int status = IfelicaMngDB.Search(out retobj, paraobj, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetDataAll);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";
                dataGrid1.DataSource = (ArrayList)retobj;
            }
		}

		// Write
		private void button4_Click(object sender, System.EventArgs e)
		{
			_felicaMngWork = new FeliCaMngWork();
            _felicaMngWork2 = new FeliCaMngWork();

            List<FeliCaMngWork> al = new List<FeliCaMngWork>();
			_felicaMngWork.EnterpriseCode = Enterprise_textBox.Text;
			_felicaMngWork.EmployeeCode = EmployeeCd_textBox1.Text;
			_felicaMngWork.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text, 0);
			_felicaMngWork.FeliCaIDm = FeliCaIDm_textBox1.Text;
			_felicaMngWork.LogicalDeleteCode = TStrConv.StrToIntDef(LogicalDelete_textBox1.Text, 0);
            if(Updatetime_textBox1.Text != string.Empty)
                _felicaMngWork.UpdateDateTime = new DateTime(Convert.ToInt64(Updatetime_textBox1.Text));
            al.Add( _felicaMngWork );

            _felicaMngWork2.EnterpriseCode = Enterprise_textBox.Text;
            _felicaMngWork2.EmployeeCode = EmployeeCd_textBox2.Text;
            _felicaMngWork2.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox2.Text, 0);
            _felicaMngWork2.FeliCaIDm = FeliCaIDm_textBox2.Text;
            _felicaMngWork2.LogicalDeleteCode = TStrConv.StrToIntDef(LogicalDelete_textBox2.Text, 0);
            if (Updatetime_textBox2.Text != string.Empty)
                _felicaMngWork.UpdateDateTime = new DateTime(Convert.ToInt64(Updatetime_textBox2.Text));
            al.Add(_felicaMngWork2);
			object paraobj = al;

			int status = IfelicaMngDB.Write( ref paraobj );
			if (status != 0)
			{
                Text = "更新失敗 ST=" + status.ToString();
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
				_felicaMngWork = ( ( List<FeliCaMngWork> )paraobj )[ 0 ];
                _felicaMngWork2 = ((List<FeliCaMngWork>)paraobj)[1];
                Updatetime_textBox1.Text = _felicaMngWork.UpdateDateTime.Ticks.ToString();
                Updatetime_textBox2.Text = _felicaMngWork2.UpdateDateTime.Ticks.ToString();
			}
		}

        // Logical Delete
		private void button6_Click(object sender, System.EventArgs e)
		{
            FeliCaMngWork felicaMngWk = new FeliCaMngWork();
            felicaMngWk.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWk.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text,0);
            felicaMngWk.FeliCaIDm = FeliCaIDm_textBox1.Text;
            if (Updatetime_textBox1.Text != string.Empty)
                felicaMngWk.UpdateDateTime = new DateTime(Convert.ToInt64(Updatetime_textBox1.Text), DateTimeKind.Local);
                
            object paraobj = (object)felicaMngWk;
            int status = IfelicaMngDB.LogicalDelete(ref paraobj);
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
					MessageBox.Show("何でか削除不可　status="+status.ToString());
				}
			}
			else
			{
				Text = "削除成功";
				_felicaMngWork = (FeliCaMngWork)paraobj;
				LogicalDelete_textBox1.Text = _felicaMngWork.LogicalDeleteCode.ToString();
                Updatetime_textBox1.Text = _felicaMngWork.UpdateDateTime.Ticks.ToString();
			}
		}

		// DisplayClear
		private void button9_Click(object sender, System.EventArgs e)
		{
			EmployeeCd_textBox1.Text = "";
            EmployeeCd_textBox2.Text = "";
            LogicalDelete_textBox1.Text = "";
            LogicalDelete_textBox2.Text = "";
            FeliCaIDm_textBox1.Text = "";
			FeliCaIDm_textBox2.Text = "";
            FeliCaMngKind_textBox1.Text = "";
            FeliCaMngKind_textBox2.Text = "";
			listBox1.Items.Clear();
		}

        // Delete
		private void button12_Click(object sender, System.EventArgs e)
		{
            FeliCaMngWork felicaMngWk = new FeliCaMngWork();
            felicaMngWk.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWk.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text, 0);
            felicaMngWk.FeliCaIDm = FeliCaIDm_textBox1.Text;
            if (Updatetime_textBox1.Text != string.Empty)
                felicaMngWk.UpdateDateTime = new DateTime(Convert.ToInt64(Updatetime_textBox1.Text), DateTimeKind.Local);

            object paraobj = (object)felicaMngWk;

            int status = IfelicaMngDB.Delete(paraobj);
			if (status != 0)
			{
				Text = "削除失敗 ST=" + status.ToString();
				if (status == 800)
				{
					MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
				}
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
			}
			else
			{
				Text = "削除成功";
			}						
		}

        // Revival
		private void button7_Click(object sender, System.EventArgs e)
		{
            FeliCaMngWork felicaMngWk = new FeliCaMngWork();
            felicaMngWk.EnterpriseCode = Enterprise_textBox.Text;
            felicaMngWk.FeliCaMngKind = TStrConv.StrToIntDef(FeliCaMngKind_textBox1.Text, 0);
            felicaMngWk.FeliCaIDm = FeliCaIDm_textBox1.Text;
            if (Updatetime_textBox1.Text != string.Empty)
                felicaMngWk.UpdateDateTime = new DateTime(Convert.ToInt64(Updatetime_textBox1.Text), DateTimeKind.Local);
            
            object paraobj = (object)felicaMngWk;

			int status = IfelicaMngDB.RevivalLogicalDelete(ref paraobj);
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
					MessageBox.Show("何でか復活不可　status="+status.ToString());
				}
			}
			else
			{
				Text = "復活成功";
		        _felicaMngWork = (FeliCaMngWork)paraobj;
                LogicalDelete_textBox1.Text = _felicaMngWork.LogicalDeleteCode.ToString();
                Updatetime_textBox1.Text = _felicaMngWork.UpdateDateTime.Ticks.ToString();
			}				
		}
	}
}

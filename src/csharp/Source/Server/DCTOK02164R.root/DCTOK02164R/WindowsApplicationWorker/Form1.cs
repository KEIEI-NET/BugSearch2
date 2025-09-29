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
	public class Form1 : System.Windows.Forms.Form
	{
        #region Windows

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox tb01;
        #endregion

        private ISalesSlipYearContrastResultWorkDB IsalesSlipYearContrastResultWorkDB = null;
        //private StockMoveListResultWork stockMoveListResultWork = new StockMoveListResultWork();
        private static string[] _parameter;
        private Label label2;
        private Label label9;
        private Button button1;
        private TextBox tb50;
        private ListBox listBox1;
        private Label label6;
        private Button button3;
        private TextBox tb11;
        private TextBox tb10;
        private TextBox tb12;
        private TextBox tb13;
        private TextBox tb29;
        private TextBox tb28;
        private Label label1;
		private static System.Windows.Forms.Form _form = null;


		public Form1()
		{
			InitializeComponent();
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
            this.tb01 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.tb29 = new System.Windows.Forms.TextBox();
            this.tb28 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb01
            // 
            this.tb01.Location = new System.Drawing.Point(10, 3);
            this.tb01.Name = "tb01";
            this.tb01.Size = new System.Drawing.Size(144, 19);
            this.tb01.TabIndex = 1;
            this.tb01.Text = "0101150842020000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(10, 250);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(752, 203);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TabStop = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(80, 179);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 24);
            this.button8.TabIndex = 50;
            this.button8.Text = "SearchA";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(444, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 19);
            this.label8.TabIndex = 34;
            this.label8.Text = "Time:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label66.Location = new System.Drawing.Point(160, 50);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(111, 19);
            this.label66.TabIndex = 165;
            this.label66.Text = "対象日付";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(160, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 185;
            this.label2.Text = "対象日付(累計)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(557, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 19);
            this.label9.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 232;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb50
            // 
            this.tb50.Location = new System.Drawing.Point(10, 53);
            this.tb50.Name = "tb50";
            this.tb50.Size = new System.Drawing.Size(144, 19);
            this.tb50.TabIndex = 231;
            this.tb50.TabStop = false;
            this.tb50.Text = "000000";
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(10, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 88);
            this.listBox1.TabIndex = 230;
            this.listBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 229;
            this.label6.Text = "■拠点コード";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 228;
            this.button3.TabStop = false;
            this.button3.Text = "Add";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tb11
            // 
            this.tb11.Location = new System.Drawing.Point(403, 51);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(72, 19);
            this.tb11.TabIndex = 234;
            this.tb11.TabStop = false;
            this.tb11.Text = "200811";
            // 
            // tb10
            // 
            this.tb10.Location = new System.Drawing.Point(325, 51);
            this.tb10.Name = "tb10";
            this.tb10.Size = new System.Drawing.Size(72, 19);
            this.tb10.TabIndex = 235;
            this.tb10.TabStop = false;
            this.tb10.Text = "200811";
            // 
            // tb12
            // 
            this.tb12.Location = new System.Drawing.Point(325, 78);
            this.tb12.Name = "tb12";
            this.tb12.Size = new System.Drawing.Size(72, 19);
            this.tb12.TabIndex = 236;
            this.tb12.TabStop = false;
            this.tb12.Text = "200804";
            // 
            // tb13
            // 
            this.tb13.Location = new System.Drawing.Point(403, 78);
            this.tb13.Name = "tb13";
            this.tb13.Size = new System.Drawing.Size(72, 19);
            this.tb13.TabIndex = 240;
            this.tb13.TabStop = false;
            this.tb13.Text = "200811";
            // 
            // tb29
            // 
            this.tb29.Location = new System.Drawing.Point(403, 106);
            this.tb29.Name = "tb29";
            this.tb29.Size = new System.Drawing.Size(72, 19);
            this.tb29.TabIndex = 263;
            this.tb29.TabStop = false;
            this.tb29.Text = "999999";
            // 
            // tb28
            // 
            this.tb28.Location = new System.Drawing.Point(325, 106);
            this.tb28.Name = "tb28";
            this.tb28.Size = new System.Drawing.Size(72, 19);
            this.tb28.TabIndex = 259;
            this.tb28.TabStop = false;
            this.tb28.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(160, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 19);
            this.label1.TabIndex = 277;
            this.label1.Text = "仕入先";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(777, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb29);
            this.Controls.Add(this.tb28);
            this.Controls.Add(this.tb13);
            this.Controls.Add(this.tb12);
            this.Controls.Add(this.tb10);
            this.Controls.Add(this.tb11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb50);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb01);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion


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
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            IsalesSlipYearContrastResultWorkDB = MediationSalesSlipYearContrastResultWorkDB.GetSalesSlipYearContrastResultWorkDB();
		}

        //Search
		private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

            SalesSlipYearContrastParamWork salesSlipYearContrastParamWork = new SalesSlipYearContrastParamWork();
            salesSlipYearContrastParamWork.EnterpriseCode = tb01.Text;

            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                salesSlipYearContrastParamWork.SectionCodes = str;
            }
            salesSlipYearContrastParamWork.StAddUpYearMonth = Int32.Parse(tb10.Text);
            salesSlipYearContrastParamWork.EdAddUpYearMonth = Int32.Parse(tb11.Text);
            salesSlipYearContrastParamWork.StAnnualAddUpYearMonth = Int32.Parse(tb12.Text);
            salesSlipYearContrastParamWork.EdAnnualAddUpYearMonth = Int32.Parse(tb13.Text);
            salesSlipYearContrastParamWork.StSupplierCd = Int32.Parse(tb28.Text);
            salesSlipYearContrastParamWork.EdSupplierCd = Int32.Parse(tb29.Text);



            object paraobj = salesSlipYearContrastParamWork;      //条件パラメータ
			object retobj = null;                               //DM抽出結果
            int status= 0;
            try
            {
                status = IsalesSlipYearContrastResultWorkDB.Search(out retobj, paraobj, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
			{
                Text = "該当データ無し  status=" + status;
            }
			else
			{
				Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";
				
				dataGrid1.DataSource = retobj;
			}		

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            SalesSlipYearContrastParamWork salesSlipYearContrastParamWork = new SalesSlipYearContrastParamWork();

            #region 値セット
            //企業コード
            salesSlipYearContrastParamWork.EnterpriseCode = tb01.Text;

            #endregion

            object paraobj = salesSlipYearContrastParamWork;      //条件パラメータ
            object retobj = null;                               //DM抽出結果

            int status = IsalesSlipYearContrastResultWorkDB.Search(out retobj, paraobj, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し  status=" + status;
            }
            else
            {
                Text = "該当データ有り  HIT " + ((ArrayList)retobj).Count.ToString() + "件";

                dataGrid1.DataSource = retobj;
            }

            end = DateTime.Now;
            label9.Text = Convert.ToString((end - start).TotalSeconds);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(tb50.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
	}
}

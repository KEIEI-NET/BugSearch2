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
		private System.Windows.Forms.TextBox tb08;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb01;
        #endregion

        private IAccPaymentListWorkDB IaccPaymentListWorkDB = null;
        //private StockMoveListResultWork stockMoveListResultWork = new StockMoveListResultWork();
        private static string[] _parameter;
        private Label label9;
        private Button button1;
        private TextBox tb50;
        private ListBox listBox1;
        private Label label6;
        private Button button3;
        private Button button2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label1;
        private ComboBox comboBox2;
        private Label label4;
        private ComboBox comboBox1;
        private Label label11;
        private Button button4;
		private static System.Windows.Forms.Form _form = null;


		public Form1()
		{
			InitializeComponent();

            //出力金額区分
            //0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ
            comboBox1.Items.Add("0:全て");
            comboBox1.Items.Add("1:0とﾌﾟﾗｽ");
            comboBox1.Items.Add("2:ﾌﾟﾗｽのみ");
            comboBox1.Items.Add("3:0のみ");
            comboBox1.Items.Add("4:0以外");
            comboBox1.Items.Add("5:0とﾏｲﾅｽ");
            comboBox1.Items.Add("6:ﾏｲﾅｽのみ");
            comboBox1.SelectedIndex = 0;

            //出力順
            //0:印字する 1:印字しない
            comboBox2.Items.Add("0:印字する");
            comboBox2.Items.Add("1:印字しない");
            comboBox2.SelectedIndex = 0;
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
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
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
            this.dataGrid1.Location = new System.Drawing.Point(10, 278);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(752, 175);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 248;
            this.button2.Text = "SearchB";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(389, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 19);
            this.textBox2.TabIndex = 251;
            this.textBox2.Text = "20080730";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 19);
            this.textBox1.TabIndex = 250;
            this.textBox1.Text = "200807";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 249;
            this.label3.Text = "対象年月";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(389, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(115, 19);
            this.textBox4.TabIndex = 254;
            this.textBox4.Text = "999999999";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(268, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(115, 19);
            this.textBox3.TabIndex = 253;
            this.textBox3.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 252;
            this.label1.Text = "支払先コード";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(268, 89);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 258;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 257;
            this.label4.Text = "支払内訳区分";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(268, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 256;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(174, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 255;
            this.label11.Text = "出力金額区分";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(176, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 23);
            this.button4.TabIndex = 259;
            this.button4.Text = "買掛残高一覧表";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(777, 465);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb50);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb01);
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
            IaccPaymentListWorkDB = MediationAccPaymentListWorkDB.GetAccPaymentListWorkDB();
		}

        //Search
		private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

            AccPaymentListCndtnWork accPaymentListCndtnWork = new AccPaymentListCndtnWork();
            //            estimateListCndtnWork = (EstimateListCndtnWork)XmlByteSerializer.Deserialize(@"C:\DC.NS\TEMP\OrderListCndtnWork.xml", typeof(EstimateListCndtnWork));

            #region 値セット
            //企業コード
            accPaymentListCndtnWork.EnterpriseCode = tb01.Text;
            accPaymentListCndtnWork.SectionCodes = new string[] {"00001"};
                
            #endregion

            object paraobj = accPaymentListCndtnWork;      //条件パラメータ
			object retobj = null;                               //DM抽出結果
            int status= 0;
            try
            {
                status = IaccPaymentListWorkDB.Search(out retobj, paraobj, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
			{
                Text = "該当データ無し  status=" + status;
                return;
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

            AccPaymentListCndtnWork accPaymentListCndtnWork = new AccPaymentListCndtnWork();

            #region 値セット
            //企業コード
            accPaymentListCndtnWork.EnterpriseCode = tb01.Text;

            /*
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                stockMoveListCndtnWork.BfAfSectionCd = str;
            }

            stockMoveListCndtnWork.St_MainBfAfEnterWarehCd = tb04.Text;
            stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd = tb05.Text;
            stockMoveListCndtnWork.ShipmentArrivalDiv = Convert.ToInt32(tb02.Text);
            //stockMoveListCndtnWork.SummaryPrintDiv = Convert.ToInt32(tb03.Text);
            stockMoveListCndtnWork.StockMoveFormalDiv = 2;
            stockMoveListCndtnWork.St_ShipArrivalSectionCd = tb06.Text;
            stockMoveListCndtnWork.Ed_ShipArrivalSectionCd = tb07.Text;
            stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd = tb8.Text;
            stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd = tb9.Text;
            stockMoveListCndtnWork.St_StockMoveSlipNo = Convert.ToInt32(tb10.Text);
            stockMoveListCndtnWork.Ed_StockMoveSlipNo = Convert.ToInt32(tb11.Text);
            stockMoveListCndtnWork.St_GoodsMakerCd = Convert.ToInt32(tb12.Text);
            stockMoveListCndtnWork.Ed_GoodsMakerCd = Convert.ToInt32(tb13.Text);
            stockMoveListCndtnWork.St_GoodsNo = tb14.Text;
            stockMoveListCndtnWork.Ed_GoodsNo = tb15.Text;
            stockMoveListCndtnWork.St_UpdateSecCd = tb16.Text;
            stockMoveListCndtnWork.Ed_UpdateSecCd = tb17.Text;
            stockMoveListCndtnWork.St_StockMvEmpCode = tb18.Text;
            stockMoveListCndtnWork.Ed_StockMvEmpCode = tb19.Text;
            stockMoveListCndtnWork.St_ShipAgentCd = tb20.Text;
            stockMoveListCndtnWork.Ed_ShipAgentCd = tb21.Text;
            stockMoveListCndtnWork.St_ReceiveAgentCd = tb22.Text;
            stockMoveListCndtnWork.Ed_ReceiveAgentCd = tb23.Text;
            stockMoveListCndtnWork.StockDiv = Convert.ToInt32(tb24.Text);
            //stockMoveListCndtnWork.St_CarrierEpCd = Convert.ToInt32(tb26.Text);
            //stockMoveListCndtnWork.Ed_CarrierEpCd = Convert.ToInt32(tb27.Text);
            stockMoveListCndtnWork.St_CustomerCode = Convert.ToInt32(tb28.Text);
            stockMoveListCndtnWork.Ed_CustomerCode = Convert.ToInt32(tb29.Text);
            */ 
            #endregion

            object paraobj = accPaymentListCndtnWork;      //条件パラメータ
            object retobj = null;                               //DM抽出結果

            int status = IaccPaymentListWorkDB.Search(out retobj, paraobj, 0, 0);

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

        private void button4_Click(object sender, EventArgs e)
        {
            AccPaymentListCndtnWork paramWork = null;

            paramWork = new AccPaymentListCndtnWork();

            // 企業コード
            paramWork.EnterpriseCode = tb01.Text;

            // 拠点コード
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                paramWork.SectionCodes = str;
            }
            else
            {
                paramWork.SectionCodes = null;
            }

            //出力金額区分
            paramWork.OutMoneyDiv = comboBox1.SelectedIndex;
            //支払内訳区分
            paramWork.PayDtlDiv = comboBox2.SelectedIndex;

            //対象年月
            paramWork.AddUpYearMonth = DateTime.ParseExact(textBox1.Text, "yyyyMM", null);
            //対象年月日
            paramWork.AddUpDate = DateTime.ParseExact(textBox2.Text, "yyyyMMdd", null);

            //請求先コード
            paramWork.St_PayeeCode = Int32.Parse(textBox3.Text);
            paramWork.Ed_PayeeCode = Int32.Parse(textBox4.Text);

            ArrayList al = new ArrayList();
            al.Add(paramWork);
            DataGridView dataGridView2 = new DataGridView();
            dataGridView2.DataSource = al;

            object workObj = dataGridView2.DataSource;

            object retObj = null;

            try
            {
                int status = IaccPaymentListWorkDB.Search(out retObj, workObj, 0, 0);
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
	}
}

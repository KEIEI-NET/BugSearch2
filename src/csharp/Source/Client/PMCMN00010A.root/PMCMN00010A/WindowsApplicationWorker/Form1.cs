using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller;

namespace WindowsApplicationWorker
{
	public class Form1 : System.Windows.Forms.Form
	{
        #region Windows

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb01;
        #endregion

        private IVersionChkWorkDB IversionChkWorkDB = null;
        //private StockMoveListResultWork stockMoveListResultWork = new StockMoveListResultWork();
        private static string[] _parameter;
        private Label label9;
        private Button button1;
        private TextBox tb50;
        private ListBox listBox1;
        private Label label6;
        private Button button3;
        private Button button2;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button7;
        private TextBox textBox6;
        private Label label7;
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
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb01
            // 
            this.tb01.Location = new System.Drawing.Point(10, 3);
            this.tb01.Name = "tb01";
            this.tb01.Size = new System.Drawing.Size(144, 19);
            this.tb01.TabIndex = 1;
            this.tb01.Text = "0113180842031000";
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
            this.button8.Location = new System.Drawing.Point(80, 178);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(78, 24);
            this.button8.TabIndex = 50;
            this.button8.Text = "USER_AP";
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
            this.button2.Location = new System.Drawing.Point(248, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 24);
            this.button2.TabIndex = 248;
            this.button2.Text = "Merge.Chk";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(80, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 23);
            this.button4.TabIndex = 249;
            this.button4.Text = "USER_DB";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(164, 178);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 23);
            this.button5.TabIndex = 250;
            this.button5.Text = "OFFER_AP";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(164, 207);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 23);
            this.button6.TabIndex = 251;
            this.button6.Text = "OFFER_DB";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(590, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 19);
            this.textBox1.TabIndex = 252;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(590, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 19);
            this.textBox2.TabIndex = 253;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(590, 128);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 19);
            this.textBox3.TabIndex = 254;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(590, 153);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(175, 19);
            this.textBox4.TabIndex = 255;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(590, 178);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(175, 19);
            this.textBox5.TabIndex = 256;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 257;
            this.label1.Text = "Currentver";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 258;
            this.label2.Text = "Tergetver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 259;
            this.label3.Text = "ErrorCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 260;
            this.label4.Text = "ErrorMessage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 12);
            this.label5.TabIndex = 261;
            this.label5.Text = "Mergecheck";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(403, 145);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(79, 23);
            this.button7.TabIndex = 262;
            this.button7.Text = "UpDateVer";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(274, 147);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(123, 19);
            this.textBox6.TabIndex = 263;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 12);
            this.label7.TabIndex = 264;
            this.label7.Text = "UpDate用version";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(777, 465);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
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
            IversionChkWorkDB = MediationVersionChkWorkDB.GetVersionChkWorkDB();
		}

        //Search
		private void button8_Click(object sender, System.EventArgs e)
		{
			DateTime start,end;
			start = DateTime.Now;

            //sendBeforOrderCndtnWork.St_UOESupplierCd = 100;

            //sendBeforOrderCndtnWork.Ed_UOESupplierCd = 9999;
            //orderListCndtnWork = (SendBeforOrderCndtnWork)XmlByteSerializer.Deserialize(@"C:\DC.NS\TEMP\OrderListCndtnWork.xml", typeof(OrderListCndtnWork));

            //string ServiceCode = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //string IndexCode = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            //string ProductCode = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ProductCode);


//            orderListCndtnWork.St_OrderDataCreateDate = DateTime.MinValue;
//            orderListCndtnWork.Ed_OrderDataCreateDate = DateTime.MinValue;
//            orderListCndtnWork.St_OrderFormPrintDate = DateTime.MinValue;
//            orderListCndtnWork.Ed_OrderFormPrintDate = DateTime.MinValue;
//            orderListCndtnWork.St_ExpectDeliveryDate = DateTime.MinValue;
//            orderListCndtnWork.Ed_ExpectDeliveryDate = DateTime.MinValue;
            #region 値セット
            //企業コード
//            orderListCndtnWork.EnterpriseCode          = tb01.Text;

            /*
            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            if (str.Length != 0)
            {
                stockAnalysisOrderListCndtnWork.BfAfSectionCd = str;
            }

            stockAnalysisOrderListCndtnWork.St_WarehouseCode = tb04.Text;
            stockAnalysisOrderListCndtnWork.Ed_WarehouseCode = tb05.Text;
            stockAnalysisOrderListCndtnWork.ShipmentArrivalDiv = Convert.ToInt32(tb02.Text);
            //stockMoveListCndtnWork.SummaryPrintDiv = Convert.ToInt32(tb03.Text);
            stockAnalysisOrderListCndtnWork.StockMoveFormalDiv = 1;
            stockAnalysisOrderListCndtnWork.St_ShipArrivalSectionCd = tb06.Text;
            stockAnalysisOrderListCndtnWork.Ed_ShipArrivalSectionCd = tb07.Text;
            stockAnalysisOrderListCndtnWork.St_ShipArrivalEnterWarehCd = tb8.Text;
            stockAnalysisOrderListCndtnWork.Ed_ShipArrivalEnterWarehCd = tb9.Text;
            stockAnalysisOrderListCndtnWork.St_StockMoveSlipNo = Convert.ToInt32(tb10.Text);
            stockAnalysisOrderListCndtnWork.Ed_StockMoveSlipNo = Convert.ToInt32(tb11.Text);
            stockAnalysisOrderListCndtnWork.St_GoodsMakerCd = Convert.ToInt32(tb12.Text);
            stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd = Convert.ToInt32(tb13.Text);
            stockAnalysisOrderListCndtnWork.St_GoodsNo = tb14.Text;
            stockAnalysisOrderListCndtnWork.Ed_GoodsNo = tb15.Text;
            stockAnalysisOrderListCndtnWork.St_UpdateSecCd = tb16.Text;
            stockAnalysisOrderListCndtnWork.Ed_UpdateSecCd = tb17.Text;
            stockAnalysisOrderListCndtnWork.St_StockMvEmpCode = tb18.Text;
            stockAnalysisOrderListCndtnWork.Ed_StockMvEmpCode = tb19.Text;
            stockAnalysisOrderListCndtnWork.St_ShipAgentCd = tb20.Text;
            stockAnalysisOrderListCndtnWork.Ed_ShipAgentCd = tb21.Text;
            stockAnalysisOrderListCndtnWork.St_ReceiveAgentCd = tb22.Text;
            stockAnalysisOrderListCndtnWork.Ed_ReceiveAgentCd = tb23.Text;
            stockAnalysisOrderListCndtnWork.StockDiv = Convert.ToInt32(tb24.Text);
            //stockMoveListCndtnWork.St_CarrierEpCd = Convert.ToInt32(tb26.Text);
            //stockMoveListCndtnWork.Ed_CarrierEpCd = Convert.ToInt32(tb27.Text);
            stockAnalysisOrderListCndtnWork.St_CustomerCode = Convert.ToInt32(tb28.Text);
            stockAnalysisOrderListCndtnWork.Ed_CustomerCode = Convert.ToInt32(tb29.Text);
            */ 
            #endregion
            string CurrrentVersion = string.Empty;
            string TargetVersion = string.Empty;
            string ErrorMessage = string.Empty;
            Int32 ErrorCode = 0;
            
            VersionCheckAcs versionCheckAcs= new VersionCheckAcs();
            int status= 0;
            try
            {
                status = versionCheckAcs.UsrVersionCheckAP(out CurrrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
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
                Text = "該当データ有り";

                textBox1.Text = CurrrentVersion;
                textBox2.Text = TargetVersion;
                textBox3.Text = ErrorCode.ToString();
                textBox4.Text = ErrorMessage;
			}		

			end = DateTime.Now;
			label9.Text = Convert.ToString((end - start).TotalSeconds);
		}

        private void button2_Click(object sender, EventArgs e)
        {
            string CurrrentVersion = string.Empty;
            //string TargetVersion = string.Empty;
            //string ErrorMessage = string.Empty;
            //string ErrorCode = string.Empty; ;
            int MergeCheckResult = 0;
            int status = 0;
            VersionCheckAcs versionCheckAcs = new VersionCheckAcs();
            try
            {
                status = versionCheckAcs.MergeCheck(out MergeCheckResult,out CurrrentVersion);
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
                Text = "該当データ有り";

                textBox5.Text = MergeCheckResult.ToString();
            }


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
            string CurrrentVersion = string.Empty;
            string TargetVersion = string.Empty;
            string ErrorMessage = string.Empty;
            Int32 ErrorCode = 0;

            VersionCheckAcs versionCheckAcs = new VersionCheckAcs();
            int status = 0;
            try
            {
                status = versionCheckAcs.UsrVersionCheckDB(out CurrrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
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
                Text = "該当データ有り";

                textBox1.Text = CurrrentVersion;
                textBox2.Text = TargetVersion;
                textBox3.Text = ErrorCode.ToString();
                textBox4.Text = ErrorMessage;

            }		
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string CurrrentVersion = string.Empty;
            string TargetVersion = string.Empty;
            string ErrorMessage = string.Empty;
            Int32 ErrorCode = 0;

            VersionCheckAcs versionCheckAcs = new VersionCheckAcs();
            int status = 0;
            try
            {
                status = versionCheckAcs.TkdVersionCheckAP(out CurrrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
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
                Text = "該当データ有り";

                textBox1.Text = CurrrentVersion;
                textBox2.Text = TargetVersion;
                textBox3.Text = ErrorCode.ToString();
                textBox4.Text = ErrorMessage;
            }	
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string CurrrentVersion = string.Empty;
            string TargetVersion = string.Empty;
            string ErrorMessage = string.Empty;
            Int32 ErrorCode = 0;

            VersionCheckAcs versionCheckAcs = new VersionCheckAcs();
            int status = 0;
            try
            {
                status = versionCheckAcs.TkdVersionCheckDB(out CurrrentVersion, out TargetVersion, out ErrorCode, out ErrorMessage);
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
                Text = "該当データ有り";

                textBox1.Text = CurrrentVersion;
                textBox2.Text = TargetVersion;
                textBox3.Text = ErrorCode.ToString();
                textBox4.Text = ErrorMessage;
            }	
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string CurrentVersion = string.Empty;

            CurrentVersion = textBox6.Text;
            VersionCheckAcs versionCheckAcs = new VersionCheckAcs();
            int status = 0;
            try
            {
                status = versionCheckAcs.UpdateVersion(ref CurrentVersion);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "更新失敗 status=" + status;
            }
            else
            {
                Text = "更新成功";

            }	



        }
	}
}

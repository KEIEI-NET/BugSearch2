using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
//using Broadleaf.Application.Remoting;
//using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

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

		//private StockDayTotalDataWork _stockdaytotalDataWork = null;

		//private StockDayTotalDataWork _prevStockDayTotalDataWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		//private IStockDayTotalDataDB IstockdaytotaldataDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox1;
		private static System.Windows.Forms.Form _form = null;
        private Button button2;
        private Button button3;

        UoeSndRcvCtlAcs _uoeSndRcvCtlAcs = null;

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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.button1.Text = "手入力";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0113180842031000";
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0:担当者別",
            "1:担当者・仕入先別"});
            this.comboBox1.Location = new System.Drawing.Point(177, 258);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 20);
            this.comboBox1.TabIndex = 43;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "PM連動";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(312, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "伝票引当";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
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
        /// 1件読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button1_Click(object sender, System.EventArgs e)
		{
            int status;
            string message;
            ArrayList dtlList = new ArrayList();
            
            //注文一覧(手入力)
            OrderLstInputDtl orderLstInputDtl = new OrderLstInputDtl(); //手入力
            orderLstInputDtl.UserName = "";
            orderLstInputDtl.UserCode = "";

            orderLstInputDtl.ItemCode = "99999";
            orderLstInputDtl.OrderDate = DateTime.Today;
            orderLstInputDtl.OrderTime = 103030;
            orderLstInputDtl.SlipNoHead = "654321";
            orderLstInputDtl.Memo = "";

            orderLstInputDtl.OrderGoodsNo = "9091530001";
            orderLstInputDtl.ShipmGoodsNo = "90915-30001";
            orderLstInputDtl.GoodsName = "エレメント特";
            orderLstInputDtl.ShipmentCnt = 7;
            orderLstInputDtl.OrderRemCnt = 0;
            orderLstInputDtl.AnswerListPrice = 2000;
            orderLstInputDtl.SourceShipment = "ＳＳＬ開発部";
            orderLstInputDtl.SlipNoDtl = "654321";
            orderLstInputDtl.AnswerSalesUnitCost = 700;

            dtlList.Add(orderLstInputDtl);

            //注文一覧(ヘッダー部)
            OrderLsthead orderLsthead = new OrderLsthead();
            orderLsthead.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            orderLsthead.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            orderLsthead.UOESupplierCd = 500;

            orderLsthead.CsvKnd = 1;
            orderLsthead.LstDtl = dtlList;
            orderLsthead.UpdRsl = 9;

            List<OrderLsthead> list = new List<OrderLsthead>();
            list.Add(orderLsthead);

            // ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御
            status = _uoeSndRcvCtlAcs.EpartsUoeWebOrderCtl(ref list, out message);
		}

        private void button2_Click(object sender, EventArgs e)
        {
            int status;
            string message;
            ArrayList dtlList = new ArrayList();

            //PM連動
            OrderLstPmDtl orderLstPmDtl = new OrderLstPmDtl();
            orderLstPmDtl.UserName = "";
            orderLstPmDtl.UserCode = "";

            orderLstPmDtl.OrderDate = DateTime.Today;
            orderLstPmDtl.OrderTime = 103030;
            orderLstPmDtl.ItemCode = "99999";
            orderLstPmDtl.Msg = "";

            orderLstPmDtl.LinkNo = Int32.Parse(textBox2.Text);
            orderLstPmDtl.SlipNoHead = "654321";
            orderLstPmDtl.OrderGoodsNo = "9091530001";
            orderLstPmDtl.ShipmGoodsNo = "90915-30001";
            orderLstPmDtl.GoodsName = "エレメント特";
            orderLstPmDtl.ShipmentCnt = 2;
            orderLstPmDtl.OrderRemCnt = 0;
            orderLstPmDtl.AnswerListPrice = 2000;
            orderLstPmDtl.SourceShipment = "ＳＳＬ開発部";
            orderLstPmDtl.PlanDate = DateTime.Today;

            orderLstPmDtl.SlipNoDtl = "654321";
            orderLstPmDtl.AnswerSalesUnitCost = 700;
            orderLstPmDtl.Memo = "";

            dtlList.Add(orderLstPmDtl);

            //注文一覧(ヘッダー部)
            OrderLsthead orderLsthead = new OrderLsthead();
            orderLsthead.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            orderLsthead.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            orderLsthead.UOESupplierCd = 500;

            orderLsthead.CsvKnd = 0;
            orderLsthead.LstDtl = dtlList;
            orderLsthead.UpdRsl = 9;

            List<OrderLsthead> list = new List<OrderLsthead>();
            list.Add(orderLsthead);

            // ホンダＵＯＥ ＷＥＢ e-Parts回答更新制御
            status = _uoeSndRcvCtlAcs.EpartsUoeWebOrderCtl(ref list, out message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int status;
            string message;
            ArrayList dtlList = new ArrayList();

            BuyOutLstDtl buyOutLstDtl = new BuyOutLstDtl();

            buyOutLstDtl.No = 1;

            buyOutLstDtl.OrderDate = DateTime.Today;
            buyOutLstDtl.BuyOutDate = DateTime.Today.AddDays(1);
            buyOutLstDtl.GoodsNo = "90915-30001";;
            buyOutLstDtl.GoodsName = "エレメント特";
            buyOutLstDtl.ShipmentCnt = 7;
            buyOutLstDtl.AnswerListPrice = 0;

            buyOutLstDtl.BuyOutCost = 750;
            buyOutLstDtl.BuyOutSlipNo = "6543210001";
            buyOutLstDtl.OrderSlipNo = "654321";

            buyOutLstDtl.Comment = "";
            buyOutLstDtl.OrderCost = 0;

            buyOutLstDtl.UpdRsl = 0;

            dtlList.Add(buyOutLstDtl);


            //買上一覧(ヘッダー部)
            BuyOutLsthead buyOutLsthead = new BuyOutLsthead();

            buyOutLsthead.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            buyOutLsthead.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            buyOutLsthead.UOESupplierCd = 500;

            buyOutLsthead.CsvKnd = 0;
            buyOutLsthead.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            buyOutLsthead.StockAgentName = LoginInfoAcquisition.Employee.Name;
            buyOutLsthead.CostUpdtDiv = 1;
            buyOutLsthead.StcCreDiv = 1;

            buyOutLsthead.LstDtl = dtlList;
            buyOutLsthead.UpdRsl = 9;

            List<BuyOutLsthead> list = new List<BuyOutLsthead>();
            list.Add(buyOutLsthead);

            // ホンダＵＯＥ ＷＥＢ e-Parts引当制御処理
            status = _uoeSndRcvCtlAcs.EpartsUoeWebBuyCtl(ref list, out message);
        }

        /// <summary>
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);		
			//IstockdaytotaldataDB = MediationStockDayTotalDataDB.GetStockDayTotalDataDB();

            _uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
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
            //StockDayTotalExtractWork work = new StockDayTotalExtractWork();
            //work.EnterpriseCode = textBox1.Text;
            //al.Add(work);
            dataGrid2.DataSource = al;
            comboBox1.SelectedIndex = 0;
		}

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button8_Click(object sender, System.EventArgs e)
		{
#if False
            object parabyte = dataGrid2.DataSource;
			object objstockdaytotalData = null;

            int status = IstockdaytotaldataDB.Search(out objstockdaytotalData, parabyte, comboBox1.SelectedIndex);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{

				Text = "該当データ有り  HIT "+((ArrayList)objstockdaytotalData).Count.ToString()+"件";
				
				dataGrid1.DataSource = objstockdaytotalData;
			}
#endif
		}

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
			/*
            object objstockdaytotalDataWork = dataGrid1.DataSource;
	
			int status = IstockdaytotaldataDB.Write(ref objstockdaytotalDataWork);
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
				dataGrid1.DataSource = objstockdaytotalDataWork;
			}		
            */
		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
#if False
            StockDayTotalDataWork DataWork = new StockDayTotalDataWork();
            DataWork.EnterpriseCode = textBox1.Text;

			ArrayList al = dataGrid1.DataSource as ArrayList;
			if(al == null)al = new ArrayList();
            al.Add(DataWork);
#endif
			dataGrid1.DataSource = null;
#if False
			dataGrid1.DataSource = al;
#endif
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button13_Click(object sender, System.EventArgs e)
		{
            /*
            object objstockdaytotalDataWork = dataGrid1.DataSource;

            int status = IstockdaytotaldataDB.LogicalDelete(ref objstockdaytotalDataWork);
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
                dataGrid1.DataSource = objstockdaytotalDataWork;
            }
            */ 
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            /*
            object objstockdaytotalDataWork = dataGrid1.DataSource;

            StockDayTotalDataWork[] trarray = (StockDayTotalDataWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(StockDayTotalDataWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IstockdaytotaldataDB.Delete(parabyte);
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
                //dataGrid1.DataSource = objstockdaytotalDataWork;
            }
            */ 
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            /*
            object objstockdaytotalDataWork = dataGrid1.DataSource;

            int status = IstockdaytotaldataDB.RevivalLogicalDelete(ref objstockdaytotalDataWork);
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
                dataGrid1.DataSource = objstockdaytotalDataWork;
            }
            */
        }


	}
}

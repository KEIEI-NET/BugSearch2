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

		private StockMoveWork _stockMoveWork = null;

		//private StockMoveWork _prevStockMoveWork = null;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;

		private IStockMoveDB IstockmoveDB = null;

		private static string[] _parameter;
        private DataGrid dataGrid2;
        private Button button2;
        private DataGrid dataGrid3;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
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
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0113180842031000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(20, 234);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1032, 241);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(20, 89);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(86, 205);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(292, 205);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(20, 205);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(60, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(364, 205);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(436, 205);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(508, 205);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(20, 118);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(1032, 81);
            this.dataGrid2.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "AddRow";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(20, 507);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(1032, 241);
            this.dataGrid3.TabIndex = 41;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(803, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 20);
            this.comboBox1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "EnterpriseCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "MakerCode";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(325, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 19);
            this.textBox2.TabIndex = 44;
            this.textBox2.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "GoodsCode";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(394, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 19);
            this.textBox3.TabIndex = 46;
            this.textBox3.Text = "D903IS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "SectionCode";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(227, 26);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(91, 19);
            this.textBox4.TabIndex = 48;
            this.textBox4.Text = "KYOTEN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 12);
            this.label5.TabIndex = 51;
            this.label5.Text = "StockMoveFormal";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(492, 26);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(90, 19);
            this.textBox5.TabIndex = 50;
            this.textBox5.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "BfSectionCode";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(227, 76);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(91, 19);
            this.textBox6.TabIndex = 52;
            this.textBox6.Text = "KYOTEN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "AfSectionCode";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(324, 76);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(91, 19);
            this.textBox7.TabIndex = 54;
            this.textBox7.Text = "KYOTEN";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1064, 770);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.button2);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
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
//			if (_stockMoveWork == null) _stockMoveWork = new StockMoveWork();
			_stockMoveWork = new StockMoveWork();
			_stockMoveWork.EnterpriseCode = textBox1.Text;
            //_stockMoveWork.SectionCode = textBox2.Text;
            //_stockMoveWork.RecordReadKey = Convert.ToInt32(textBox3.Text);
            //_stockMoveWork.NewOrModifiRatioCd = Convert.ToInt32(textBox4.Text);
            //_stockMoveWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(_stockMoveWork);			

			int status = IstockmoveDB.Read(ref parabyte,0);
			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{
				// XMLの読み込み
				_stockMoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(parabyte,typeof(StockMoveWork));

				Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(_stockMoveWork);
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
			IstockmoveDB = MediationStockMoveDB.GetStockMoveDB();
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
            StockMoveSlipSearchCondWork stockMoveWork = new StockMoveSlipSearchCondWork();
            stockMoveWork.EnterpriseCode = textBox1.Text;
            //更新拠点コード
            //stockMoveWork.SectionCode = "000001";

            //在庫移動伝票番号
            //stockMoveWork.StockMoveSlipNo = 10;

            //在庫移動入力従業員コード
            //stockMoveWork.StockMvEmpCode = "777";

            //出荷担当従業員コード
            //stockMoveWork.ShipAgentCd = "777";

            //引取担当従業員コード
            //stockMoveWork.ReceiveAgentCd = "777";

            //出荷予定開始日
            //stockMoveWork.ShipmentScdlStDay = new DateTime(2007, 09, 21);

            //出荷予定終了日
            //stockMoveWork.ShipmentScdlEdDay = new DateTime(2007, 09, 21);

            //出荷確定開始日
            stockMoveWork.ShipmentFixStDay = new DateTime(2007, 09, 21);

            //出荷確定終了日
            stockMoveWork.ShipmentFixEdDay = new DateTime(2007, 09, 21);

            //入荷開始日
            //stockMoveWork.ArrivalGoodsStDay = new DateTime(2007, 09, 21);

            //入荷終了日
            //stockMoveWork.ArrivalGoodsEdDay = new DateTime(2007, 09, 21);

            //移動元拠点コード
            stockMoveWork.BfSectionCode = "000001";

            //移動元倉庫コード
            //stockMoveWork.BfEnterWarehCode = "a1";

            //移動先拠点コード
            //stockMoveWork.AfSectionCode = "000001";

            //移動先倉庫コード
            //stockMoveWork.AfEnterWarehCode = "a2";

            //移動状態
            //stockMoveWork.MoveStatus[0] = '9';


            al.Add(stockMoveWork);
            dataGrid2.DataSource = al;
		}

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button8_Click(object sender, System.EventArgs e)
		{
			object parabyte = ((ArrayList)dataGrid2.DataSource)[0];
			object objstockMove;

			int status = IstockmoveDB.Search(out objstockMove, parabyte, 0, 0);

			if (status != 0)
			{
				Text = "該当データ無し";
			}
			else
			{

                Text = "該当データ有り  HIT ";// +((ArrayList)objstockMove).Count.ToString() + "件";

                //SetGrid(objstockMove);
                dataGrid1.DataSource = null;
                dataGrid1.DataSource = ((CustomSerializeArrayList)objstockMove)[0];
            }
		}

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button10_Click(object sender, System.EventArgs e)
		{
            CustomSerializeArrayList scalist = new CustomSerializeArrayList();
            scalist.Add(dataGrid1.DataSource);
            //scalist.Add(dataGrid3.DataSource);

			object objstockMoveWork = scalist;
            string retMsg = "";
			int status = IstockmoveDB.Write(ref objstockMoveWork,out retMsg);
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
                dataGrid1.DataSource = ((CustomSerializeArrayList)objstockMoveWork)[0];
			}		
		}

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button11_Click(object sender, System.EventArgs e)
		{
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();

            //StockMoveWork stockMoveWork = new StockMoveWork();
            //stockMoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(@"C:\DC.NS\TEMP\stockMoveWork.xml", typeof(StockMoveWork));
            
            //StockMoveWork stockMoveWork = new StockMoveWork();
            //stockMoveWork = (StockMoveWork)XmlByteSerializer.Deserialize(@"C:\DC.NS\TEMP\stockMoveWork-Arrival.xml", typeof(StockMoveWork));
            
            //al.Add(stockMoveWork);

            StockMoveWork[] stockMoveWork;
            stockMoveWork = (StockMoveWork[])XmlByteSerializer.Deserialize(@"C:\DC.NS\TEMP\stockMoveWorkList.xml", typeof(StockMoveWork[]));

            al.Add(stockMoveWork[0]);
            al.Add(stockMoveWork[1]);

            /*
            stockMoveWork.EnterpriseCode = textBox1.Text;
            stockMoveWork.UpdateSecCd = textBox4.Text;
            stockMoveWork.GoodsMakerCd = Convert.ToInt32(textBox2.Text);
            stockMoveWork.GoodsNo = textBox3.Text;
            stockMoveWork.StockMoveFormal = Convert.ToInt32(textBox5.Text);
            stockMoveWork.BfSectionCode = textBox6.Text;
            stockMoveWork.AfSectionCode = textBox7.Text;
            */ 
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
            CustomSerializeArrayList scalist = new CustomSerializeArrayList();
            scalist.Add(dataGrid1.DataSource);
            object objstockMoveWork = scalist;

            int status = IstockmoveDB.LogicalDelete(ref objstockMoveWork);
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
                dataGrid1.DataSource = ((CustomSerializeArrayList)objstockMoveWork)[0];
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button15_Click(object sender, System.EventArgs e)
		{
            CustomSerializeArrayList scalist = new CustomSerializeArrayList();
            scalist.Add(dataGrid1.DataSource);
            object objstockMoveWork = scalist;

            //StockMoveWork[] trarray = (StockMoveWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(StockMoveWork));
            //byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IstockmoveDB.Delete(ref objstockMoveWork);
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
                //dataGrid1.DataSource = objstockMoveWork;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            CustomSerializeArrayList scalist = new CustomSerializeArrayList();
            scalist.Add(dataGrid1.DataSource);
            object objstockMoveWork = scalist;

            int status = IstockmoveDB.RevivalLogicalDelete(ref objstockMoveWork);
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
                dataGrid1.DataSource = ((CustomSerializeArrayList)objstockMoveWork)[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockMoveWork stockMoveExpWork = new StockMoveWork();
            stockMoveExpWork.EnterpriseCode = textBox1.Text;
            stockMoveExpWork.UpdateSecCd = textBox4.Text;
            //stockMoveExpWork.AfSectionCode = textBox4.Text;
            stockMoveExpWork.GoodsMakerCd = Convert.ToInt32(textBox2.Text);
            stockMoveExpWork.GoodsNo = textBox3.Text;
            stockMoveExpWork.StockMoveFormal = Convert.ToInt32(textBox5.Text);
            stockMoveExpWork.BfSectionCode = textBox6.Text;
            stockMoveExpWork.AfSectionCode = textBox7.Text;
            ArrayList al = dataGrid3.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(stockMoveExpWork);
            dataGrid3.DataSource = null;
            dataGrid3.DataSource = al;
        }

        private void SetGrid(object retobj)
        {
            CustomSerializeArrayList retList = retobj as CustomSerializeArrayList;
            dataGrid1.DataSource = null;
            dataGrid3.DataSource = null;
            //リストから必要な情報を取得
            for (int i = 0; i < retList.Count; i++)
            {
                ArrayList wkal = retList[i] as ArrayList;
                if (wkal != null)
                {
                    if (wkal.Count > 0)
                    {
                        //在庫マスタでリストがNULLの場合
                        if (wkal[0] is StockMoveWork)
                        {
                            dataGrid1.DataSource = wkal;
                        }
                    }
                }
            }

        }
	}
}

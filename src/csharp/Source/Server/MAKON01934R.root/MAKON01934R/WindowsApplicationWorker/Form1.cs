using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Serialization.Formatters.Soap;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using Broadleaf.Library.Resources;

namespace WindowsApplication1
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private SearchRetStockSlip _searchRetStockSlip = null;
        private SearchParaStockSlip _searchParaStockSlip = null;
        //private int _totalCount;
        //private int _remainCount;
        private SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

        //private SearchRetStockSlip _prevSearchRetStockSlip = null;

        //private object _retObj = null;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button4;
        private Button button5;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox4;
        private Label label7;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 261);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(960, 88);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 395);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(960, 295);
            this.dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "検索結果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "検索条件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "企業コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 19);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "0113180842031000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "全件：SearchEnterprise";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "件数指定：SearchSpecificationEnterprise";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(256, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "件数：SearchCntEnterprise";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(274, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(274, 105);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(664, 221);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "NewRow";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(756, 220);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(216, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Searｃｈ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(662, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Time　：　";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(664, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "テスト用";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(514, 35);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(94, 19);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(455, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "仕入伝番";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(984, 702);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
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
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "WindowsApplication1", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "WindowsApplication1", ex.Message, 0, MessageBoxButtons.OK);
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFCMN09000U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
        }

        /// <summary>
        /// 指定された企業コードの仕入データLISTを全て戻します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            dataGridView2.DataSource = null;
            ArrayList al = new ArrayList();

            //_searchParaStockSlip = new SearchParaStockSlip();

            CustomSerializeArrayList retCsal = new CustomSerializeArrayList();

            string enterpriseCode;
            enterpriseCode = System.Convert.ToString(textBox1.Text);

            //al.Add(_searchParaStockSlip);
            //al = dataGrid2.DataSource as ArrayList;

            object retobj = (object)retCsal;

            ISearchStockSlipDB iSearchStockSlipDB = MediationSearchStockSlipDB.GetSearchStockSlipDB();

            int status = iSearchStockSlipDB.SearchEnterprise(enterpriseCode, out retobj);
            if (status != 0)
            {
                Text = "該当データなし";
            }
            else
            {
                retCsal = retobj as CustomSerializeArrayList;

                Text = "該当データあり  HIT " + retCsal.Count.ToString() + "件";

                dataGridView2.DataSource = retCsal as ArrayList;
            }

            end = DateTime.Now;
            label5.Text = Convert.ToString((end - start).TotalSeconds);
        }

        /// <summary>
        /// 指定された企業コードの指定件数分の仕入データLISTを戻します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            dataGridView2.DataSource = null;
            ArrayList al = new ArrayList();

            CustomSerializeArrayList retCsal = new CustomSerializeArrayList();

            //_searchParaStockSlip = new SearchParaStockSlip();

            string enterpriseCode;
            enterpriseCode = System.Convert.ToString(textBox1.Text);

            //al.Add(_searchParaStockSlip);
            //al = dataGrid2.DataSource as ArrayList;

            object retobj = (object)retCsal;
            int retTotalCnt = 0;
            bool nextData;
            int readCnt = System.Convert.ToInt32(textBox2.Text);

            ISearchStockSlipDB iSearchStockSlipDB = MediationSearchStockSlipDB.GetSearchStockSlipDB();

            int status = iSearchStockSlipDB.SearchSpecificationEnterprise(enterpriseCode, out retobj, out retTotalCnt, out nextData, readCnt);
            if (status != 0)
            {
                Text = "該当データなし";
            }
            else
            {
                retCsal = retobj as CustomSerializeArrayList;

                Text = "該当データあり  HIT " + retCsal.Count.ToString() + "件";

                dataGridView2.DataSource = retCsal as ArrayList;
            }

            end = DateTime.Now;
            label5.Text = Convert.ToString((end - start).TotalSeconds);
        }

        /// <summary>
        /// 指定された企業コードの仕入データLIST件数を戻します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            dataGridView2.DataSource = null;
            ArrayList al = new ArrayList();



            string enterpriseCode;
            enterpriseCode = System.Convert.ToString(textBox1.Text);

            int retCnt = 0;

            ISearchStockSlipDB iSearchStockSlipDB = MediationSearchStockSlipDB.GetSearchStockSlipDB();

            int status = iSearchStockSlipDB.SearchCntEnterprise(enterpriseCode, out retCnt);
            if (status != 0)
            {
                Text = "該当データなし";
            }
            else
            {
                textBox3.Text = System.Convert.ToString(retCnt);

                Text = "該当データあり  HIT " + retCnt.ToString() + "件";
            }

            end = DateTime.Now;
            label5.Text = Convert.ToString((end - start).TotalSeconds);
        }

        /// <summary>
        /// NewRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click_1(object sender, EventArgs e)
        {
            SearchParaStockSlip searchpara = new SearchParaStockSlip();
            searchpara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
         
            ArrayList al = new ArrayList();
            al.Add(searchpara);

            dataGridView1.DataSource = al;
            dataGridView1.Update();
        }

        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての仕入データLISTを戻します
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            DateTime start, end;
            start = DateTime.Now;

            dataGridView2.DataSource = null;

            CustomSerializeArrayList csal = new CustomSerializeArrayList();
            CustomSerializeArrayList retCsal = null;

            //ArrayList al = new ArrayList();

            _searchParaStockSlip = new SearchParaStockSlip();
            _searchRetStockSlip = new SearchRetStockSlip();
            
            /*
            if (dataGridView1.DataSource != null)
            {
                //_searchParaStockSlip = dataGridView1.DataSource as SearchParaStockSlip;
                csal.Add(dataGridView1.DataSource);
            }
            
            _searchParaStockSlip.EnterpriseCode = System.Convert.ToString(textBox1.Text);
            _searchParaStockSlip.SupplierSlipNo = System.Convert.ToInt32(textBox4.Text);
            _searchParaStockSlip.SupplierSlipCd = 10;
            _searchParaStockSlip.AccPayDivCd = 1;
            _searchParaStockSlip.DebitNoteDiv = 0;
               */

            _searchParaStockSlip = (dataGridView1.DataSource as ArrayList)[0] as SearchParaStockSlip;
            csal.Add(_searchParaStockSlip);
            
            object param = (object)csal;
            object retobj = (object)retCsal;

            ISearchStockSlipDB iSearchStockSlipDB = MediationSearchStockSlipDB.GetSearchStockSlipDB();

            int status = iSearchStockSlipDB.Search(ref param, out retobj);

            if (status != 0)
            {
                Text = "該当データなし(" + status.ToString() + ")";
            }
            else
            {
                csal = param as CustomSerializeArrayList;
                retCsal = retobj as CustomSerializeArrayList;
                //al = retobj as ArrayList;

                Text = "該当データあり  HIT " + retCsal.Count.ToString() + "件";

                dataGridView2.DataSource = retCsal as ArrayList;
            }

            end = DateTime.Now;
            label5.Text = Convert.ToString((end - start).TotalSeconds);
        }

    }
}

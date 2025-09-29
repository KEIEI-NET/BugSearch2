using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using System.Runtime.Remoting;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Text;

namespace WindowsApplicationWorker
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button10;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button2;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Panel panel2;
        private TextBox txtSystemDivCd;
        private TextBox txtPrintPaperDivCd;
        private TextBox txtSlipOrPrtPprDivCd;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;

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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSystemDivCd = new System.Windows.Forms.TextBox();
            this.txtPrintPaperDivCd = new System.Windows.Forms.TextBox();
            this.txtSlipOrPrtPprDivCd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(201, 136);
            this.listBox1.TabIndex = 21;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(232, 12);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(124, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "Search";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(393, 19);
            this.textBox1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "出力ファイル名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "ユーザー帳票ID枝番";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 19);
            this.textBox2.TabIndex = 27;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(468, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 19);
            this.textBox3.TabIndex = 31;
            this.textBox3.Text = "0140150842030050";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Delete";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(737, 489);
            this.panel1.TabIndex = 32;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(737, 427);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSystemDivCd);
            this.panel2.Controls.Add(this.txtPrintPaperDivCd);
            this.panel2.Controls.Add(this.txtSlipOrPrtPprDivCd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(737, 62);
            this.panel2.TabIndex = 2;
            // 
            // txtSystemDivCd
            // 
            this.txtSystemDivCd.Location = new System.Drawing.Point(494, 6);
            this.txtSystemDivCd.Name = "txtSystemDivCd";
            this.txtSystemDivCd.Size = new System.Drawing.Size(100, 19);
            this.txtSystemDivCd.TabIndex = 3;
            // 
            // txtPrintPaperDivCd
            // 
            this.txtPrintPaperDivCd.Location = new System.Drawing.Point(307, 6);
            this.txtPrintPaperDivCd.Name = "txtPrintPaperDivCd";
            this.txtPrintPaperDivCd.Size = new System.Drawing.Size(100, 19);
            this.txtPrintPaperDivCd.TabIndex = 2;
            // 
            // txtSlipOrPrtPprDivCd
            // 
            this.txtSlipOrPrtPprDivCd.Location = new System.Drawing.Point(107, 6);
            this.txtSlipOrPrtPprDivCd.Name = "txtSlipOrPrtPprDivCd";
            this.txtSlipOrPrtPprDivCd.Size = new System.Drawing.Size(100, 19);
            this.txtSlipOrPrtPprDivCd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(416, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "SystemDivCd";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(214, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "PrintPaperDivCd";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "SlipOrPrtPprDivCd";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(761, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button10);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;
        private static SFANL08230AE sfanl08230ae = new SFANL08230AE();

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
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。
                //出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode,
                                    new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", msg, 0, MessageBoxButtons.OK);
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


        //サーチ
        private void button10_Click(object sender, System.EventArgs e)
        {
            FrePrtPSetWork[] frePrtPSetWorkList;
            string errmsg;

            int status = sfanl08230ae.Search(textBox3.Text,"", out frePrtPSetWorkList, 0, ConstantManagement.LogicalMode.GetData0, out errmsg);
            if (status == 0)
            {
                foreach (FrePrtPSetWork frePrtPSetWork in frePrtPSetWorkList)
                {
                    listBox1.Items.Add(frePrtPSetWork.DisplayName);

                }
            }

            MessageBox.Show("STATUS=" + status.ToString() + errmsg);
        }

        //デリート
        private void button2_Click(object sender, EventArgs e)
        {
            FrePrtPSetWork frePrtPSetWork = new FrePrtPSetWork();
            string errmsg;
            bool msgDiv;

            //キーセット
            frePrtPSetWork.OutputFormFileName = textBox1.Text;
            if (textBox2.Text != "")
            {
                frePrtPSetWork.UserPrtPprIdDerivNo = Convert.ToInt32(textBox2.Text);
            }
            frePrtPSetWork.EnterpriseCode = textBox3.Text;

            int status = sfanl08230ae.Delete(frePrtPSetWork,out msgDiv, out errmsg);

            if (status == 0)
            {
                listBox1.Items.Add(frePrtPSetWork.DisplayName);
            }
            MessageBox.Show("STATUS=" + status.ToString() + errmsg);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IFrePrtPSetDLDB _iFrePrtPSetSearchDB = MediationFrePrtPSetDLDB.GetFrePrtPSetDLDB();
                int slipOrPrtPprDivCd = TStrConv.StrToIntDef(this.txtSlipOrPrtPprDivCd.Text, 0);
                int printPaperDivCd = TStrConv.StrToIntDef(this.txtPrintPaperDivCd.Text, 0);
                int systemDivCd = TStrConv.StrToIntDef(this.txtSystemDivCd.Text, 0);
                int[] systemDivCdArray = new int[1] { systemDivCd };
                byte[] frePrtPSetWorkListkByte;

                FrePrtPSetWork[] frePrtPSetWorkList = null;
                bool msgDiv;
                string errMsg;
                int status = _iFrePrtPSetSearchDB.Search(textBox3.Text, slipOrPrtPprDivCd, printPaperDivCd, systemDivCdArray, out frePrtPSetWorkListkByte, out msgDiv, out errMsg);
                if (status == 0)
                {
                    // XMLバイト列からクラス配列へ展開
                    frePrtPSetWorkList = (FrePrtPSetWork[])XmlByteSerializer.Deserialize(frePrtPSetWorkListkByte, typeof(FrePrtPSetWork[]));
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            this.dataGridView1.DataSource = frePrtPSetWorkList;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Status:" + status.ToString().PadRight(3));
                            this.dataGridView1.DataSource = null;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}

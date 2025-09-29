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

using System.IO;
using Broadleaf.Library.Collections;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using Broadleaf.Library.Resources;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// このFormはリモートテストの為だけのFromです
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EnterpriseCode;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private MonthlyAddUpWork _monthlyAddUpWork = null;
        private MonthlyAddUpStatusWork _monthlyAddUpStatusWork = null;
        //private MonthlyAddUpHisWork _monthlyAddUpHisWork = null;

        private System.Windows.Forms.Button button10;

        private IMonthlyAddUpDB ImonthlyAddUpDB = null;

        private static string[] _parameter;
        private TextBox ProcCntntsFlag;
        private Label label1;
        private Label label4;
        private Label label6;
        private TextBox AddUpSecCode;
        private Label label7;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private Label label2;
        private TextBox CompanyTotalDay;
        private Label label3;
        private TextBox AddUpDate;
        private Label label5;
        private TextBox CustomerCode;
        private Button button4;
        private Label label8;
        private TextBox textBox1;
        private Label label9;
        private TextBox textBox2;
        private Label label10;
        private TextBox textBox3;
        private Label label11;
        private TextBox textBox4;
        private Label label12;
        private TextBox textBox5;
        private Label label13;
        private TextBox textBox6;
        private Button button5;
        private Label label14;
        private TextBox textBox7;
        private Label label15;
        private TextBox textBox8;
        private Label label16;
        private TextBox textBox9;
        private Label label17;
        private TextBox textBox10;
        private Label label18;
        private TextBox textBox11;
        private Label label19;
        private TextBox textBox12;
        private Button button6;
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
            this.button1 = new System.Windows.Forms.Button();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.ProcCntntsFlag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddUpSecCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyTotalDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddUpDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CustomerCode = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "更新";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(118, 11);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 1;
            this.EnterpriseCode.Text = "0101150842020000";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(102, 112);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "締取消";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // ProcCntntsFlag
            // 
            this.ProcCntntsFlag.Location = new System.Drawing.Point(118, 30);
            this.ProcCntntsFlag.Name = "ProcCntntsFlag";
            this.ProcCntntsFlag.Size = new System.Drawing.Size(72, 19);
            this.ProcCntntsFlag.TabIndex = 41;
            this.ProcCntntsFlag.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "企業コード";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "更新内容";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "1：月次準備　2：月次更新";
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Location = new System.Drawing.Point(118, 66);
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.Size = new System.Drawing.Size(100, 19);
            this.AddUpSecCode.TabIndex = 55;
            this.AddUpSecCode.Text = "01";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "計上拠点コード";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "売掛Read";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(138, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 57;
            this.button3.Text = "買掛Read";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(848, 215);
            this.dataGridView1.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "締日(2桁)";
            // 
            // CompanyTotalDay
            // 
            this.CompanyTotalDay.Location = new System.Drawing.Point(332, 11);
            this.CompanyTotalDay.Name = "CompanyTotalDay";
            this.CompanyTotalDay.Size = new System.Drawing.Size(22, 19);
            this.CompanyTotalDay.TabIndex = 59;
            this.CompanyTotalDay.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 62;
            this.label3.Text = "計上年月日";
            // 
            // AddUpDate
            // 
            this.AddUpDate.Location = new System.Drawing.Point(332, 30);
            this.AddUpDate.Name = "AddUpDate";
            this.AddUpDate.Size = new System.Drawing.Size(59, 19);
            this.AddUpDate.TabIndex = 61;
            this.AddUpDate.Text = "20080320";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "得意先";
            // 
            // CustomerCode
            // 
            this.CustomerCode.Location = new System.Drawing.Point(332, 49);
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Size = new System.Drawing.Size(59, 19);
            this.CustomerCode.TabIndex = 63;
            this.CustomerCode.Text = "1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(231, 112);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 65;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(421, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 67;
            this.label8.Text = "企業コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(507, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 19);
            this.textBox1.TabIndex = 66;
            this.textBox1.Text = "0101150842020000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 69;
            this.label9.Text = "拠点コード";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(507, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 19);
            this.textBox2.TabIndex = 68;
            this.textBox2.Text = "01";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(421, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 71;
            this.label10.Text = "計上年月日";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(507, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(78, 19);
            this.textBox3.TabIndex = 70;
            this.textBox3.Text = "20080730";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(421, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 73;
            this.label11.Text = "計上年月";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(507, 68);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(78, 19);
            this.textBox4.TabIndex = 72;
            this.textBox4.Text = "20080701";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(421, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 12);
            this.label12.TabIndex = 75;
            this.label12.Text = "得意先コード";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(507, 87);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(78, 19);
            this.textBox5.TabIndex = 74;
            this.textBox5.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(421, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 12);
            this.label13.TabIndex = 77;
            this.label13.Text = "請求先コード";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(507, 106);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(78, 19);
            this.textBox6.TabIndex = 76;
            this.textBox6.Text = "1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(423, 127);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 23);
            this.button5.TabIndex = 78;
            this.button5.Text = "ReadCustAccRec";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(604, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 12);
            this.label14.TabIndex = 80;
            this.label14.Text = "企業コード";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(690, 11);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(78, 19);
            this.textBox7.TabIndex = 79;
            this.textBox7.Text = "0101150842020000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(604, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 12);
            this.label15.TabIndex = 82;
            this.label15.Text = "拠点コード";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(690, 30);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(78, 19);
            this.textBox8.TabIndex = 81;
            this.textBox8.Text = "01";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(604, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 84;
            this.label16.Text = "計上年月日";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(690, 49);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(78, 19);
            this.textBox9.TabIndex = 83;
            this.textBox9.Text = "20080730";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(604, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 86;
            this.label17.Text = "計上年月";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(690, 68);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(78, 19);
            this.textBox10.TabIndex = 85;
            this.textBox10.Text = "20080701";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(604, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 12);
            this.label18.TabIndex = 88;
            this.label18.Text = "仕入先コード";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(690, 87);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(78, 19);
            this.textBox11.TabIndex = 87;
            this.textBox11.Text = "1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(604, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 12);
            this.label19.TabIndex = 90;
            this.label19.Text = "支払先コード";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(690, 106);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(78, 19);
            this.textBox12.TabIndex = 89;
            this.textBox12.Text = "1";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(606, 127);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 23);
            this.button6.TabIndex = 91;
            this.button6.Text = "ReadSuplAccPay";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(871, 397);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CustomerCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddUpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompanyTotalDay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddUpSecCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcCntntsFlag);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.EnterpriseCode);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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

        /// <summary>
        /// FormLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            ImonthlyAddUpDB = MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();
        }

        /// <summary>
        /// 月次更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            _monthlyAddUpWork = new MonthlyAddUpWork();
            _monthlyAddUpWork.EnterpriseCode = EnterpriseCode.Text;//企業コード
            _monthlyAddUpWork.AddUpSecCode = AddUpSecCode.Text;//計上拠点コード
            _monthlyAddUpWork.ProcCntntsFlag = Convert.ToInt32(ProcCntntsFlag.Text);//更新内容フラグ
            _monthlyAddUpWork.CompanyTotalDay = Convert.ToInt32(CompanyTotalDay.Text);//締日
            Int32 date = Convert.ToInt32(AddUpDate.Text);
            _monthlyAddUpWork.AddUpDate = new DateTime(date /10000,(date / 100) % 100,date % 100);//計上年月日
            _monthlyAddUpWork.AddUpYearMonth = new DateTime(date / 10000, (date / 100) % 100, 01);
            _monthlyAddUpWork.StockUpdDiv = 1;

            object paraObj = null;
            paraObj = (object)_monthlyAddUpWork;

            object retParam = null;
            string retMsg = null;
            bool msgDiv = false;

            int status = ImonthlyAddUpDB.Write(ref paraObj, out retParam, out msgDiv, out retMsg, 1);
            if (status != 0)
            {
                Text = "更新失敗 : " + retMsg;
            }
            else
            {
                ArrayList retList = retParam as ArrayList;

                for (int i = 0; i < retList.Count; i++)
                {
                    _monthlyAddUpStatusWork = retList[i] as MonthlyAddUpStatusWork;
                }

                Text = "更新成功";
            }
        }

        /// <summary>
        /// 月次締取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, System.EventArgs e)
        {
            _monthlyAddUpWork = new MonthlyAddUpWork();
            _monthlyAddUpWork.EnterpriseCode = EnterpriseCode.Text;//企業コード
            _monthlyAddUpWork.AddUpSecCode = AddUpSecCode.Text;//計上拠点コード
            _monthlyAddUpWork.ProcCntntsFlag = Convert.ToInt32(ProcCntntsFlag.Text);//更新内容フラグ
            _monthlyAddUpWork.CompanyTotalDay = Convert.ToInt32(CompanyTotalDay.Text);//得意先締日
            Int32 date = Convert.ToInt32(AddUpDate.Text);
            _monthlyAddUpWork.AddUpDate = new DateTime(date / 10000, (date / 100) % 100, date % 100);//計上年月日
            _monthlyAddUpWork.AddUpYearMonth = new DateTime(date / 10000, (date / 100) % 100, 01);

            object paraObj = null;
            paraObj = (object)_monthlyAddUpWork;

            object retParam = null;
            string retMsg = null;
            bool msgDiv = false;

            paraObj = (object)_monthlyAddUpWork;

            //int status = ImonthlyAddUpDB.Delete(ref paraObj, out retParam, out msgDiv, out retMsg, 0);
            int status = ImonthlyAddUpDB.Delete(ref paraObj, out retParam, out msgDiv, out retMsg, 1);
            if (status != 0)
            {
                Text = "削除失敗 : " + retMsg;
            }
            else
            {
                Text = "削除成功";
            }
        }

        /// <summary>
        /// 売掛読込
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            CustAccRecWork custAccRecWork = new CustAccRecWork();
            custAccRecWork.EnterpriseCode = EnterpriseCode.Text;
            custAccRecWork.CustomerCode = Convert.ToInt32(CustomerCode.Text);
            custAccRecWork.AddUpSecCode = AddUpSecCode.Text;
            Int32 date = Convert.ToInt32(AddUpDate.Text);
            custAccRecWork.AddUpDate = new DateTime(date / 10000, (date / 100) % 100, date % 100);

            object paraObj = (object)custAccRecWork;

            string retMsg = null;

            int status = ImonthlyAddUpDB.ReadCustAccRec(ref paraObj, out retMsg);

            if (status != 0)
            {
                Text = "読取失敗 : ";
            }
            else
            {
                Text = "読取成功";
                ArrayList al = new ArrayList();
                al.Add((CustAccRecWork)paraObj);
                dataGridView1.DataSource = al;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
            suplAccPayWork.EnterpriseCode = EnterpriseCode.Text;
            suplAccPayWork.SupplierCd = Convert.ToInt32(CustomerCode.Text);
            suplAccPayWork.AddUpSecCode = AddUpSecCode.Text;
            Int32 date = Convert.ToInt32(AddUpDate.Text);
            suplAccPayWork.AddUpDate = new DateTime(date / 10000, (date / 100) % 100, date % 100);

            object paraObj = (object)suplAccPayWork;

            string retMsg = null;

            int status = ImonthlyAddUpDB.ReadSuplAccPay(ref paraObj, out retMsg);

            if (status != 0)
            {
                Text = "読取失敗 : ";
            }
            else
            {
                Text = "読取成功";
                ArrayList al = new ArrayList();
                al.Add((SuplAccPayWork)paraObj);
                dataGridView1.DataSource = al;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //
            DateGetAcs dateGetAcs = null;
            dateGetAcs = DateGetAcs.GetInstance();
            DateTime yearMonth;
            int year;
            DateTime startMonthDate;
            DateTime endMonthDate;
            dateGetAcs.GetYearMonth(DateTime.Parse("2008/03/27"), out yearMonth, out year, out startMonthDate, out endMonthDate);

            //startMonthDate = startMonthDate;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustAccRecWork custAccRecWork = new CustAccRecWork();

            //企業コード
            custAccRecWork.EnterpriseCode = textBox1.Text;
            //拠点コード
            custAccRecWork.AddUpSecCode = textBox2.Text;
            //計上年月日
            custAccRecWork.AddUpDate = DateTime.ParseExact(textBox3.Text, "yyyyMMdd", null);
            //計上年月
            custAccRecWork.AddUpYearMonth = DateTime.ParseExact(textBox4.Text, "yyyyMMdd", null);
            //得意先コード
            custAccRecWork.CustomerCode = Int32.Parse(textBox5.Text);
            //請求先コード
            custAccRecWork.ClaimCode = Int32.Parse(textBox6.Text);

            object paraObj = (object)custAccRecWork;

            string retMsg = null;

            int status = ImonthlyAddUpDB.ReadCustAccRec(ref paraObj, out retMsg);

            if (status != 0)
            {
                Text = "読取失敗 : ";
            }
            else
            {
                Text = "読取成功";
                ArrayList al = new ArrayList();
                al.Add((CustAccRecWork)paraObj);
                dataGridView1.DataSource = al;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

            //企業コード
            suplAccPayWork.EnterpriseCode = textBox7.Text;
            //拠点コード
            suplAccPayWork.AddUpSecCode = textBox8.Text;
            //計上年月日
            suplAccPayWork.AddUpDate = DateTime.ParseExact(textBox9.Text, "yyyyMMdd", null);
            //計上年月
            suplAccPayWork.AddUpYearMonth = DateTime.ParseExact(textBox10.Text, "yyyyMMdd", null);
            //仕入先コード
            suplAccPayWork.SupplierCd = Int32.Parse(textBox11.Text);
            //請求先コード
            suplAccPayWork.PayeeCode = Int32.Parse(textBox12.Text);

            object paraObj = (object)suplAccPayWork;

            string retMsg = null;

            int status = ImonthlyAddUpDB.ReadSuplAccPay(ref paraObj, out retMsg);

            if (status != 0)
            {
                Text = "読取失敗 : ";
            }
            else
            {
                Text = "読取成功";
                ArrayList al = new ArrayList();
                al.Add((SuplAccPayWork)paraObj);
                dataGridView1.DataSource = al;
            }
        }

    }
}

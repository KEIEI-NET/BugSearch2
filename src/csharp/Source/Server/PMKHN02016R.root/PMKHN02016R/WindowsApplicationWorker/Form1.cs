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
    /// <summary>
    /// Form1 の概要の説明です。
    /// このFromはリモートテストの為だけのFromです
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button button8;

        private IRatePrtDB IratePrtDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label4;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label5;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label6;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label7;
        private TextBox textBox12;
        private TextBox textBox13;
        private Label label8;
        private TextBox textBox14;
        private TextBox textBox15;
        private Label label9;
        private TextBox textBox16;
        private TextBox textBox17;
        private Label label10;
        private TextBox textBox18;
        private TextBox textBox19;
        private Label label11;
        private TextBox textBox20;
        private TextBox textBox21;
        private Label label12;
        private TextBox textBox22;
        private Label label13;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label14;
        private static System.Windows.Forms.Form _form = null;

        public Form1()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //単価種類
            //1:売価設定,2:原価設定,3:価格設定,4:作業原価,5:作業売価
            comboBox1.Items.Add("1:売価設定");
            comboBox1.Items.Add("2:原価設定");
            comboBox1.Items.Add("3:価格設定");
            comboBox1.Items.Add("4:作業原価");
            comboBox1.Items.Add("5:作業売価");
            comboBox1.SelectedIndex = 0;

            //設定方法
            //0:グループ設定 1:単品設定
            comboBox2.Items.Add("0:グループ設定");
            comboBox2.Items.Add("1:単品設定");
            comboBox2.SelectedIndex = 0;

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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 395);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 141);
            this.dataGrid1.TabIndex = 13;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(370, 246);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Search";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 280);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 71);
            this.dataGrid2.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "企業コード";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 19);
            this.textBox1.TabIndex = 126;
            this.textBox1.Text = "0101150842020000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(149, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(90, 19);
            this.textBox2.TabIndex = 128;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 127;
            this.label2.Text = "拠点コード";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(149, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 19);
            this.textBox3.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 129;
            this.label3.Text = "掛率設定区分";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(245, 77);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(90, 19);
            this.textBox4.TabIndex = 131;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(149, 96);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(90, 19);
            this.textBox5.TabIndex = 133;
            this.textBox5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 132;
            this.label4.Text = "得意先コード";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(245, 96);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(90, 19);
            this.textBox6.TabIndex = 134;
            this.textBox6.Text = "99999999";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(149, 115);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(90, 19);
            this.textBox7.TabIndex = 136;
            this.textBox7.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 12);
            this.label5.TabIndex = 135;
            this.label5.Text = "得意先掛率グループコード";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(245, 115);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(90, 19);
            this.textBox8.TabIndex = 137;
            this.textBox8.Text = "9999";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(149, 134);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(90, 19);
            this.textBox9.TabIndex = 139;
            this.textBox9.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 138;
            this.label6.Text = "仕入先コード";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(245, 134);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(90, 19);
            this.textBox10.TabIndex = 140;
            this.textBox10.Text = "999999";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(149, 153);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(90, 19);
            this.textBox11.TabIndex = 142;
            this.textBox11.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 141;
            this.label7.Text = "商品メーカーコード";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(245, 153);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(90, 19);
            this.textBox12.TabIndex = 143;
            this.textBox12.Text = "9999";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(149, 172);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(90, 19);
            this.textBox13.TabIndex = 145;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 12);
            this.label8.TabIndex = 144;
            this.label8.Text = "商品掛率ランク";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(245, 172);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(90, 19);
            this.textBox14.TabIndex = 146;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(149, 191);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(90, 19);
            this.textBox15.TabIndex = 148;
            this.textBox15.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 12);
            this.label9.TabIndex = 147;
            this.label9.Text = "商品掛率グループコード";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(245, 191);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(90, 19);
            this.textBox16.TabIndex = 149;
            this.textBox16.Text = "9999";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(149, 210);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(90, 19);
            this.textBox17.TabIndex = 151;
            this.textBox17.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 12);
            this.label10.TabIndex = 150;
            this.label10.Text = "BLグループコード";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(245, 210);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(90, 19);
            this.textBox18.TabIndex = 152;
            this.textBox18.Text = "99999";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(149, 229);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(90, 19);
            this.textBox19.TabIndex = 154;
            this.textBox19.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 12);
            this.label11.TabIndex = 153;
            this.label11.Text = "BL商品コード";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(245, 229);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(90, 19);
            this.textBox20.TabIndex = 155;
            this.textBox20.Text = "99999";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(149, 248);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(90, 19);
            this.textBox21.TabIndex = 157;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 251);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 156;
            this.label12.Text = "商品番号";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(245, 248);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(90, 19);
            this.textBox22.TabIndex = 158;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 12);
            this.label13.TabIndex = 159;
            this.label13.Text = "拠点コード";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 160;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(427, 57);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 162;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(346, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 161;
            this.label14.Text = "設定方法";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGrid1);
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
        /// FromLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IratePrtDB = MediationRatePrtDB.GetRatePrtDB();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
            RatePrtReqWork paramWork = null;
            paramWork = new RatePrtReqWork();

            //企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            //拠点コード
            string[] SectionCodes = new string[1];
            if (textBox2.Text != "")
            {
                SectionCodes[0] = textBox2.Text;
                paramWork.SectionCode = SectionCodes;
            }
            else
            {
                paramWork.SectionCode = null;
            }

            paramWork.UnitPriceKind = comboBox1.SelectedIndex;           //単価種類
            paramWork.RateMngGoodsCdKind = comboBox2.SelectedIndex;      //設定方法
            paramWork.RateSettingDivideSt = textBox3.Text;               //開始掛率設定区分
            paramWork.RateSettingDivideEd = textBox4.Text;               //終了掛率設定区分
            paramWork.CustomerCodeSt = Int32.Parse(textBox5.Text);       //開始得意先コード
            paramWork.CustomerCodeEd = Int32.Parse(textBox6.Text);       //終了得意先コード
            paramWork.CustRateGrpCodeSt = Int32.Parse(textBox7.Text);    //開始得意先掛率グループコード
            paramWork.CustRateGrpCodeEd = Int32.Parse(textBox8.Text);    //終了得意先掛率グループコード
            paramWork.SupplierCdSt = Int32.Parse(textBox9.Text);         //開始仕入先コード
            paramWork.SupplierCdEd = Int32.Parse(textBox10.Text);        //終了仕入先コード
            paramWork.GoodsMakerCdSt = Int32.Parse(textBox11.Text);      //開始商品メーカーコード
            paramWork.GoodsMakerCdEd = Int32.Parse(textBox12.Text);      //終了商品メーカーコード
            paramWork.GoodsRateRankSt = textBox13.Text;                  //開始商品掛率ランク
            paramWork.GoodsRateRankEd = textBox14.Text;                  //終了商品掛率ランク
            paramWork.GoodsRateGrpCodeSt = Int32.Parse(textBox15.Text);  //開始商品掛率グループコード
            paramWork.GoodsRateGrpCodeEd = Int32.Parse(textBox16.Text);  //終了商品掛率グループコード
            paramWork.BLGroupCodeSt = Int32.Parse(textBox17.Text);       //開始BLグループコード
            paramWork.BLGroupCodeEd = Int32.Parse(textBox18.Text);       //終了BLグループコード
            paramWork.BLGoodsCodeSt = Int32.Parse(textBox19.Text);       //開始BL商品コード
            paramWork.BLGoodsCodeEd = Int32.Parse(textBox20.Text);       //終了BL商品コード
            paramWork.GoodsNoSt = textBox21.Text;                        //開始商品番号
            paramWork.GoodsNoEd = textBox22.Text;                        //終了商品番号

            ArrayList al = new ArrayList();
            al.Add(paramWork);
            object objParam = al;
            object objResult = null;

            int status = IratePrtDB.Search(out objResult, objParam, 0);
            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り";

                dataGrid1.DataSource = objResult;
            }
        }
    }
}

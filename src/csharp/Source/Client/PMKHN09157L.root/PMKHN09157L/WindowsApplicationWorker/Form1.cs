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
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections.Generic;
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
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;

        //private ModelNameUWork _blGoodsCdUWork = null;
        private Operation _operationWork = null;

        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;

        //private ModelNameULcDB _ModelNameULcDB = null;
        private OperationLcDB _OperationLcDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label2;
        private Label label1;
        private TextBox DataInputSystem;
        private TextBox EnterpriseCode;
        private Label label7;
        private TextBox Syncmode;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox4;
        private Label label8;
        private TextBox textBox5;
        private Label label9;
        private TextBox textBox6;
        private Label label10;
        private TextBox textBox7;
        private Label label11;
        private TextBox textBox8;
        private Label label12;
        private TextBox textBox9;
        private Label label13;
        private TextBox textBox10;
        private Button button2;
        private Button button3;
        private Button button4;
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataInputSystem = new System.Windows.Forms.TextBox();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Syncmode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.button10.Location = new System.Drawing.Point(177, 255);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "Sync";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "車種コード";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "企業コード";
            // 
            // DataInputSystem
            // 
            this.DataInputSystem.Location = new System.Drawing.Point(147, 26);
            this.DataInputSystem.Name = "DataInputSystem";
            this.DataInputSystem.Size = new System.Drawing.Size(115, 19);
            this.DataInputSystem.TabIndex = 46;
            this.DataInputSystem.Text = "000001";
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(147, 6);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 45;
            this.EnterpriseCode.Text = "0101150842020000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 58;
            this.label7.Text = "Syncmode";
            // 
            // Syncmode
            // 
            this.Syncmode.Location = new System.Drawing.Point(361, 6);
            this.Syncmode.Name = "Syncmode";
            this.Syncmode.Size = new System.Drawing.Size(19, 19);
            this.Syncmode.TabIndex = 57;
            this.Syncmode.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 12);
            this.label3.TabIndex = 60;
            this.label3.Text = "提供日付(YYYYMMDD)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 19);
            this.textBox1.TabIndex = 59;
            this.textBox1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "カテゴリコード";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(147, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 19);
            this.textBox2.TabIndex = 61;
            this.textBox2.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "カテゴリ名称";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(147, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(115, 19);
            this.textBox3.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 12);
            this.label6.TabIndex = 66;
            this.label6.Text = "カテゴリ表示順位";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(427, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(115, 19);
            this.textBox4.TabIndex = 65;
            this.textBox4.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 12);
            this.label8.TabIndex = 68;
            this.label8.Text = "プログラムID";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(427, 77);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(115, 19);
            this.textBox5.TabIndex = 67;
            this.textBox5.Text = "ZAIKOENTRY";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 12);
            this.label9.TabIndex = 70;
            this.label9.Text = "プログラム名称";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(427, 99);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(115, 19);
            this.textBox6.TabIndex = 69;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 12);
            this.label10.TabIndex = 72;
            this.label10.Text = "プログラム表示順位";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(427, 121);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(115, 19);
            this.textBox7.TabIndex = 71;
            this.textBox7.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(579, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 12);
            this.label11.TabIndex = 74;
            this.label11.Text = "オペレーションコード";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(711, 55);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(115, 19);
            this.textBox8.TabIndex = 73;
            this.textBox8.Text = "1000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(579, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 12);
            this.label12.TabIndex = 76;
            this.label12.Text = "オペレーション名称";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(711, 77);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(115, 19);
            this.textBox9.TabIndex = 75;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(579, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 12);
            this.label13.TabIndex = 78;
            this.label13.Text = "オペレーション表示順位";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(711, 99);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(115, 19);
            this.textBox10.TabIndex = 77;
            this.textBox10.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 79;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(260, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 80;
            this.button3.Text = "Write";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(341, 139);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 81;
            this.button4.Text = "Delete";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Syncmode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataInputSystem);
            this.Controls.Add(this.EnterpriseCode);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
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
                if (status != 0)    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",msg,0,MessageBoxButtons.OK);
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
            if (_form != null)    TMsgDisp.Show(_form.Owner,    emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            else                TMsgDisp.Show(                emErrorLevel.ERR_LEVEL_INFO,"SFCMN09000U",e.ToString(),0,MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// READボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            //READ
            #region [パラメータセット]
            _operationWork = new Operation();
            _operationWork.OfferDate = Int32.Parse(textBox1.Text);
            _operationWork.CategoryCode = Int32.Parse(textBox2.Text);
            _operationWork.CategoryName = textBox3.Text;
            _operationWork.CategoryDspOdr = Int32.Parse(textBox4.Text);
            _operationWork.PgId = textBox5.Text;
            _operationWork.PgName = textBox6.Text;
            _operationWork.PgDspOdr = Int32.Parse(textBox7.Text);
            _operationWork.OperationCode = Int32.Parse(textBox8.Text);
            _operationWork.OperationName = textBox9.Text;
            _operationWork.OperationDspOdr = Int32.Parse(textBox10.Text);

            _OperationLcDB = new OperationLcDB();
            object paraobj = _operationWork;
            #endregion

            //READ実行
            int status = _OperationLcDB.Read(ref paraobj, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(paraobj);
                dataGrid1.DataSource = al;
            }        
        }

        /// <summary>
        /// SEARCHボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //SEARCH
            #region [パラメータセット]
            _operationWork = new Operation();
            _operationWork.OfferDate = Int32.Parse(textBox1.Text);
            _operationWork.CategoryCode = Int32.Parse(textBox2.Text);
            _operationWork.CategoryName = textBox3.Text;
            _operationWork.CategoryDspOdr = Int32.Parse(textBox4.Text);
            _operationWork.PgId = textBox5.Text;
            _operationWork.PgName = textBox6.Text;
            _operationWork.PgDspOdr = Int32.Parse(textBox7.Text);
            _operationWork.OperationCode = Int32.Parse(textBox8.Text);
            _operationWork.OperationName = textBox9.Text;
            _operationWork.OperationDspOdr = Int32.Parse(textBox10.Text);

            _OperationLcDB = new OperationLcDB();
            object paraobj = _operationWork;

            Operation _retoperationWork = null;
            _retoperationWork = new Operation();
            object retobj = _retoperationWork;
            #endregion

            //SEARCH実行
            int status = 99;
            try
            {
                status = _OperationLcDB.Search(ref retobj, paraobj, 0, 0);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                Text = "該当データ有り";
                ArrayList al = retobj as ArrayList;
                dataGrid1.DataSource = al;
            }        

        }

        /// <summary>
        /// WRITEボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //WRITE
            #region [パラメータセット]
            _operationWork = new Operation();
            _operationWork.OfferDate = Int32.Parse(textBox1.Text);
            _operationWork.CategoryCode = Int32.Parse(textBox2.Text);
            _operationWork.CategoryName = textBox3.Text;
            _operationWork.CategoryDspOdr = Int32.Parse(textBox4.Text);
            _operationWork.PgId = textBox5.Text;
            _operationWork.PgName = textBox6.Text;
            _operationWork.PgDspOdr = Int32.Parse(textBox7.Text);
            _operationWork.OperationCode = Int32.Parse(textBox8.Text);
            _operationWork.OperationName = textBox9.Text;
            _operationWork.OperationDspOdr = Int32.Parse(textBox10.Text);

            _OperationLcDB = new OperationLcDB();
            object paraobj = _operationWork;
            #endregion

            //WRITE実行
            int status = 99;
            try
            {
                status = _OperationLcDB.Write(ref paraobj);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "Write失敗";
            }
            else
            {
                Text = "Write成功";
            }      
        }

        /// <summary>
        /// DELETEボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //DELETE
            #region [パラメータセット]
            _operationWork = new Operation();
            _operationWork.OfferDate = Int32.Parse(textBox1.Text);
            _operationWork.CategoryCode = Int32.Parse(textBox2.Text);
            _operationWork.CategoryName = textBox3.Text;
            _operationWork.CategoryDspOdr = Int32.Parse(textBox4.Text);
            _operationWork.PgId = textBox5.Text;
            _operationWork.PgName = textBox6.Text;
            _operationWork.PgDspOdr = Int32.Parse(textBox7.Text);
            _operationWork.OperationCode = Int32.Parse(textBox8.Text);
            _operationWork.OperationName = textBox9.Text;
            _operationWork.OperationDspOdr = Int32.Parse(textBox10.Text);

            _OperationLcDB = new OperationLcDB();
            object paraobj = _operationWork;
            #endregion

            //DELETE実行
            int status = 99;
            try
            {
                status = _OperationLcDB.Delete(paraobj);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFCMN09000U", ex.Message, 0, MessageBoxButtons.OK);
            }

            if (status != 0)
            {
                Text = "Delete失敗";
            }
            else
            {
                Text = "Delete成功";
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
            //IcustSlipMngDB = MediationCustSlipMngDB.GetCustSlipMngDB();
        }

        #region [未処理ボタン]
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, System.EventArgs e)
        {
            /*
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;
            ArrayList al = new ArrayList();
            ModelNameUWork work = new ModelNameUWork();
            work.EnterpriseCode = EnterpriseCode.Text;
            work.ModelUniqueCode = Convert.ToInt32(DataInputSystem.Text);
            al.Add(work);
            dataGrid2.DataSource = al;
             */
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
            /*
            ArrayList al = new ArrayList();
            ModelNameUWork work = new ModelNameUWork();
            work.EnterpriseCode = EnterpriseCode.Text;
            work.ModelUniqueCode = Convert.ToInt32(DataInputSystem.Text);
            al.Add(work);
            dataGrid2.DataSource = al;
            object parabyte = dataGrid2.DataSource;

            List<ModelNameUWork> blGoodsCdUWork = new List<ModelNameUWork>();
            
            _ModelNameULcDB = new ModelNameULcDB();
            int status = _ModelNameULcDB.Search(out blGoodsCdUWork,work, 0,0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT " + ((List<ModelNameUWork>)blGoodsCdUWork).Count.ToString() + "件";

                dataGrid1.DataSource = blGoodsCdUWork;
            }
             */
        }

        /// <summary>
        /// Sync処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, System.EventArgs e)
        {
            /*
            object parabyte = dataGrid1.DataSource;

            List<ModelNameUWork> list = parabyte as List<ModelNameUWork>;
            ArrayList al = new ArrayList();
            foreach (ModelNameUWork work in list) al.Add(work);
            _ModelNameULcDB = new ModelNameULcDB();

            _blGoodsCdUWork = al[0] as ModelNameUWork;

            SyncServiceWork syncServiceWork = new SyncServiceWork();
            syncServiceWork.EnterpriseCode = EnterpriseCode.Text;
            syncServiceWork.ManagementTableName = "CUSTSLIPMNGRF";
            if (!String.IsNullOrEmpty(Syncmode.Text)) syncServiceWork.Syncmode = Convert.ToInt32(Syncmode.Text);
            syncServiceWork.SyncExecDate = _blGoodsCdUWork.CreateDateTime;
            syncServiceWork.SyncDateTimeSt = _blGoodsCdUWork.CreateDateTime;
            syncServiceWork.SyncDateTimeEd = _blGoodsCdUWork.CreateDateTime;


            ArrayList pal = new ArrayList();
            pal.Add(al);
            int status = _ModelNameULcDB.WriteSyncLocalData(syncServiceWork, pal, 0);

            if (status != 0)
            {
                Text = "該当データ無し : status = " + status;
            }
            else
            {

                Text = "該当データ有り  HIT 1件";
                ArrayList readdata = new ArrayList();
                readdata.Add(_blGoodsCdUWork);

                dataGrid2.DataSource = readdata;

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
            /*
            ModelNameUWork blGoodsCdUWork = new ModelNameUWork();
            blGoodsCdUWork.EnterpriseCode = EnterpriseCode.Text;
            blGoodsCdUWork.ModelUniqueCode = Convert.ToInt32(DataInputSystem.Text);
            List<ModelNameUWork> al = dataGrid1.DataSource as List<ModelNameUWork>;
            if (al == null) al = new List<ModelNameUWork>();
            al.Add(blGoodsCdUWork);
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
             */
        }
        #endregion

    }
}

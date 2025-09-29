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
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button12;

        private WarehouseWork _warehouseWork = null;

        //private CarrierWork _prevCarrierWork = null;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;

        private IWarehouseDB IwarehouseDB = null;

        private static string[] _parameter;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "TBS1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(264, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(264, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(248, 19);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(264, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(248, 19);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(264, 152);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(248, 19);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "拠点コード";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "倉庫コード";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(144, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "倉庫名称";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(144, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "塗装種類コード";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(16, 200);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(288, 19);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "TBS1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Search";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(16, 272);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(304, 88);
            this.listBox1.TabIndex = 12;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 392);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(560, 144);
            this.dataGrid1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(152, 368);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "SearchGrid";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(392, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Write";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(472, 33);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "LogicalDelete";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 40);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(144, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(264, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "1";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(72, 248);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 24);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Search時にSerializeする";
            // 
            // listBox2
            // 
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(336, 272);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(240, 88);
            this.listBox2.TabIndex = 25;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(360, 232);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "件数指定Search";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(496, 232);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 19);
            this.numericUpDown1.TabIndex = 27;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(472, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "NextData?";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(320, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "総件数：";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(472, 57);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(88, 23);
            this.button12.TabIndex = 31;
            this.button12.Text = "Delete";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(472, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Revival";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(64, 368);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(88, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "CustomSearch";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(288, 368);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(16, 368);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(48, 23);
            this.button11.TabIndex = 35;
            this.button11.Text = "AddRow";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(360, 368);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(432, 368);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(504, 368);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(16, 112);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(112, 23);
            this.button16.TabIndex = 39;
            this.button16.Text = "SearchFeaderCode";
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(592, 550);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IwarehouseDB = MediationWarehouseDB.GetWarehouseDB();
            textBox1.Text = "YOKO";
            textBox2.Text = "01";
            textBox3.Text = "01";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = textBox1.Text;
            textBox7.Text = "0";
            label4.Text = "";
        }

        // Read button
        private void button1_Click(object sender, System.EventArgs e)
        {
            _warehouseWork = new WarehouseWork();
            _warehouseWork.EnterpriseCode = textBox1.Text;
            _warehouseWork.SectionCode = textBox2.Text;
            _warehouseWork.WarehouseCode = textBox3.Text;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_warehouseWork);

            //object retList = null;
            object paraObj = _warehouseWork;

            int status = IwarehouseDB.Read(ref parabyte, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                
                // XMLの読み込み
                _warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));

                Text = "該当データ有り";
                textBox1.Text = _warehouseWork.EnterpriseCode.ToString();
                textBox2.Text = _warehouseWork.SectionCode.ToString();
                textBox3.Text = _warehouseWork.WarehouseCode.ToString();
                textBox4.Text = _warehouseWork.WarehouseName.ToString();
                //textBox5.Text = _warehouseWork.BodyPaintKindCd.ToString();
                textBox7.Text = _warehouseWork.LogicalDeleteCode.ToString();
                

                Text = "該当データ有り";
                _warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));
            }
        }

        // Search button
        private void button2_Click(object sender, System.EventArgs e)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = textBox1.Text;

            ArrayList al = new ArrayList();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(warehouseWork);
            byte[] retbyte;

            object paraObj = warehouseWork;
            object retList = null;

            int status = 0;  // IwarehouseDB.Search(out retbyte, parabyte, 0, 0);
            status = IwarehouseDB.Search(out retList, paraObj, 0, 0);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                //EjibaiRtDtWork[] ew = (EjibaiRtDtWork[])XmlByteSerializer.Deserialize(retbyte,typeof(EjibaiRtDtWork[]));

                //Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";

                //for(int i = 0;i<ew.Length;i++)
                //{
                //    ejibaiRtDtInsWork = (EjibaiRtDtWork)ew[i];
                //    listBox1.Items.Add(ejibaiRtDtInsWork.ToString());
                //    listBox1.Update();
                //}
                //if (checkBox1.Checked) XmlByteSerializer.Serialize(ew,"c:\\testList.xml");	

            }
        }

        // SearchGrid button
        private void button3_Click(object sender, System.EventArgs e)
        {
            _warehouseWork.EnterpriseCode = textBox1.Text;

            ArrayList al = new ArrayList();

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_warehouseWork);
            byte[] retbyte;

            int status = 0;// IejibairtdtDB.Search(out retbyte, parabyte, 0, 0);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                //// XMLの読み込み
                //EjibaiRtDtWork[] ew = (EjibaiRtDtWork[])XmlByteSerializer.Deserialize(retbyte,typeof(EjibaiRtDtWork[]));

                //Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";

                //dataGrid1.DataSource = ew;
            }
        }

        // Write button
        private void button4_Click(object sender, System.EventArgs e)
        {
            if (_warehouseWork == null) _warehouseWork = new WarehouseWork();

            _warehouseWork.EnterpriseCode = textBox1.Text;
            _warehouseWork.SectionCode = textBox2.Text;
            _warehouseWork.WarehouseCode = textBox3.Text;
            _warehouseWork.WarehouseName = textBox4.Text;
            //_ejibaiRtDtWork.BodyPaintKindCd = Convert.ToInt32(textBox5.Text);

            _warehouseWork.LogicalDeleteCode = System.Convert.ToInt16(textBox7.Text);

            ArrayList al = new ArrayList();
            al.Add(_warehouseWork);
            //byte[] parabyte = XmlByteSerializer.Serialize(_ejibaiRtDtWork);

            object obj = al;

            int status = IwarehouseDB.Write(ref obj);
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
                //_ejibaiRtDtWork = (EjibaiRtDtWork)XmlByteSerializer.Deserialize(parabyte,typeof(EjibaiRtDtWork));
                dataGrid1.DataSource = obj;
            }
        }

        // LogicalDelete button
        private void button6_Click(object sender, System.EventArgs e)
        {
            if (_warehouseWork == null) _warehouseWork = new WarehouseWork();

            _warehouseWork.EnterpriseCode = textBox1.Text;
            _warehouseWork.SectionCode = textBox2.Text;
            _warehouseWork.WarehouseCode = textBox3.Text;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_warehouseWork);

            object paraObj = _warehouseWork;
            
            //int status = 0;// IejibairtdtDB.LogicalDelete(ref parabyte);
            int status = IwarehouseDB.LogicalDelete(ref paraObj);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
                else
                {
                    MessageBox.Show("何でか削除不可　status=" + status.ToString());
                }
            }
            else
            {
                Text = "削除成功";
                // XMLの読み込み
                _warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));
                textBox7.Text = _warehouseWork.LogicalDeleteCode.ToString();

            }
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            listBox1.Items.Clear();
            //			_prevEjibaiRtDtWork = null;
            listBox2.Items.Clear();
            button5.Enabled = true;
            label6.Text = "次データ？";
            dataGrid1.DataSource = null;
        }

        /// <summary>
        /// 件数指定リード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, System.EventArgs e)
        {
            //			listBox2.Items.Clear();
            //
            //			EjibaiRtDtWork ejibaiRtDtWork = new EjibaiRtDtWork();
            //			byte[] parabyte;
            //			if (_prevEjibaiRtDtWork == null)
            //			{
            //				ejibaiRtDtWork.EnterpriseCode = textBox6.Text;
            //				parabyte = XmlByteSerializer.Serialize(ejibaiRtDtWork);
            //			}
            //			else
            //			{
            //				parabyte = XmlByteSerializer.Serialize(_prevEjibaiRtDtWork);	
            //			}
            //
            //			byte[] retbyte;
            //			int retTotalCnt;
            //			bool nextData;
            //
            //			int status = 0;
            //			//int status = IejibairtdtDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte, 0,0,(int)numericUpDown1.Value);
            //
            //			if (status != 0)
            //			{
            //				Text = "該当データ無し";
            //			}
            //			else
            //			{
            //				// XMLの読み込み
            //				EjibaiRtDtWork[] ew = (EjibaiRtDtWork[])XmlByteSerializer.Deserialize(retbyte,typeof(EjibaiRtDtWork[]));
            //
            //				Text = "該当データ有り  HIT "+ew.Length.ToString()+"件";
            //
            //				//初回のみ件数取得
            //				if (_prevEjibaiRtDtWork == null) 
            //				{
            //					label7.Text = "総件数： "+retTotalCnt.ToString()+" 件";
            //				}
            //				
            //				for(int i = 0;i<ew.Length;i++)
            //				{
            //					ejibaiRtDtWork = (EjibaiRtDtWork)ew[i];
            //					listBox2.Items.Add(ejibaiRtDtWork.ToString());
            //					listBox2.Update();
            //					if (i == ew.Length - 1) _prevEjibaiRtDtWork = (EjibaiRtDtWork)ew[i];
            //				}
            //				if (nextData)		label6.Text = "次データ有り";
            //				else
            //				{
            //					numericUpDown1.Focus();
            //					button5.Enabled = false;
            //					label6.Text = "次データ無し";
            //				}
            //			}				
            //					
        }

        private void button12_Click(object sender, System.EventArgs e)
        {
            //_ejibaiRtDtWork = new EjibaiRtDtWork();
            _warehouseWork.EnterpriseCode = textBox1.Text;
            //_ejibaiRtDtWork.SectionCode = textBox2.Text;
            //_ejibaiRtDtWork.RecordReadKey = Convert.ToInt32(textBox3.Text);

            WarehouseWork[] paraarray = new WarehouseWork[] { _warehouseWork };

            byte[] parabyte = XmlByteSerializer.Serialize(paraarray);
            int status = IwarehouseDB.Delete(parabyte);
            if (status != 0)
            {
                Text = "削除失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
            }
            else
            {
                Text = "削除成功";
            }
        }

        // Revival button
        private void button7_Click(object sender, System.EventArgs e)
        {
            if (_warehouseWork == null) _warehouseWork = new WarehouseWork();

            _warehouseWork.EnterpriseCode = textBox1.Text;
            _warehouseWork.SectionCode = textBox2.Text;
            _warehouseWork.WarehouseCode = textBox3.Text;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_warehouseWork);

            object paraObj = _warehouseWork;

            int status = IwarehouseDB.RevivalLogicalDelete(ref paraObj);

            if (status != 0)
            {
                Text = "復活失敗";
                if (status == 800)
                {
                    MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                }
                else if (status == 801)
                {
                    MessageBox.Show("他端末でデータが削除されています。削除出来ませんでした。");
                }
                else
                {
                    MessageBox.Show("何でか復活不可　status=" + status.ToString());
                }
            }
            else
            {
                Text = "復活成功";
                // XMLの読み込み
                _warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));
                textBox7.Text = _warehouseWork.LogicalDeleteCode.ToString();
            }

        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            _warehouseWork = new WarehouseWork();
            _warehouseWork.EnterpriseCode = textBox1.Text;

            ArrayList al = new ArrayList();

            al.Add(_warehouseWork);
            object parabyte = al;
            object objwarehouse;

            int status = IwarehouseDB.Search(out objwarehouse, parabyte, 0, 0);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objwarehouse).Count.ToString() + "件";

                dataGrid1.DataSource = objwarehouse;
            }
        }

        private void button10_Click(object sender, System.EventArgs e)
        {
            object objwarehouseWork = dataGrid1.DataSource;

            int status = IwarehouseDB.Write(ref objwarehouseWork);
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
                dataGrid1.DataSource = objwarehouseWork;
            }
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = textBox1.Text;
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(warehouseWork);
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        private void button13_Click(object sender, System.EventArgs e)
        {
            object objwarehouseWork = dataGrid1.DataSource;

            int status = IwarehouseDB.LogicalDelete(ref objwarehouseWork);
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
                dataGrid1.DataSource = objwarehouseWork;
            }
        }

        private void button15_Click(object sender, System.EventArgs e)
        {
            object objwarehouseWork = dataGrid1.DataSource;

            WarehouseWork[] trarray = (WarehouseWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(WarehouseWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IwarehouseDB.Delete(parabyte);
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
                //dataGrid1.DataSource = objejibaiRtDtWork;
            }
        }

        private void button16_Click(object sender, System.EventArgs e)
        {
            _warehouseWork = new WarehouseWork();
            _warehouseWork.EnterpriseCode = textBox1.Text;
            //_ejibaiRtDtWork.SectionCode = Convert.ToInt32( textBox2.Text );

            ArrayList al = new ArrayList();

            al.Add(_warehouseWork);
            object parabyte = al;
            object objwarehouse;

            int status = 0;// IejibairtdtDB.SearchHeaderCode(out objejibaiRtDt, parabyte, 0, 0);
            listBox1.Items.Clear();
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                //Text = "該当データ有り  HIT "+((ArrayList)objejibaiRtDt).Count.ToString()+"件";

                //dataGrid1.DataSource = objejibaiRtDt;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            object objwarehouseWork = dataGrid1.DataSource;

            int status = IwarehouseDB.RevivalLogicalDelete(ref objwarehouseWork);
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
                dataGrid1.DataSource = objwarehouseWork;
            }
        }
    }
}

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
    /// このFromはリモートテストの為だけのFromです
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private CustDmdPrcUpdateWork _custDmdPrcUpdateWork = null;
        private CustDmdPrcUpdStatusWork _custDmdPrcUpdStatusWork = null;
        private CustDmdPrcWork _custDmdPrcWork = null;

        //private SumGrpDivWork _prevSumGrpDivWork = null;
        private System.Windows.Forms.Button button10;

        private ICustDmdPrcDB IcustDmdPrcDB = null;

        private static string[] _parameter;
        private TextBox textBox2;
        private TextBox UpdObjectFlag;
        private TextBox AddUpDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox CustomerCode1;
        private TextBox CustomerCode2;
        private TextBox CustomerCode3;
        private Label label5;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private Label label6;
        private TextBox textBox14;
        private Label label7;
        private Button button2;
        private Label label8;
        private TextBox ProcCntntsFlag;
        private Label label9;
        private TextBox CustomerCode4;
        private TextBox CustomerCode5;
        private TextBox CustomerCode10;
        private TextBox CustomerCode9;
        private TextBox CustomerCode8;
        private TextBox CustomerCode7;
        private TextBox CustomerCode6;
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
            this.button10 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.UpdObjectFlag = new System.Windows.Forms.TextBox();
            this.AddUpDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomerCode1 = new System.Windows.Forms.TextBox();
            this.CustomerCode2 = new System.Windows.Forms.TextBox();
            this.CustomerCode3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ProcCntntsFlag = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CustomerCode4 = new System.Windows.Forms.TextBox();
            this.CustomerCode5 = new System.Windows.Forms.TextBox();
            this.CustomerCode10 = new System.Windows.Forms.TextBox();
            this.CustomerCode9 = new System.Windows.Forms.TextBox();
            this.CustomerCode8 = new System.Windows.Forms.TextBox();
            this.CustomerCode7 = new System.Windows.Forms.TextBox();
            this.CustomerCode6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "更新";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0101150842020000";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(17, 350);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "締取消";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 19);
            this.textBox2.TabIndex = 40;
            this.textBox2.Text = "20";
            // 
            // UpdObjectFlag
            // 
            this.UpdObjectFlag.Enabled = false;
            this.UpdObjectFlag.Location = new System.Drawing.Point(146, 91);
            this.UpdObjectFlag.Name = "UpdObjectFlag";
            this.UpdObjectFlag.Size = new System.Drawing.Size(72, 19);
            this.UpdObjectFlag.TabIndex = 41;
            this.UpdObjectFlag.Text = "1";
            // 
            // AddUpDate
            // 
            this.AddUpDate.Location = new System.Drawing.Point(146, 143);
            this.AddUpDate.Name = "AddUpDate";
            this.AddUpDate.Size = new System.Drawing.Size(72, 19);
            this.AddUpDate.TabIndex = 42;
            this.AddUpDate.Text = "20080229";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "得意先締日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "検索対象";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "締次 更新/取消 年月日";
            // 
            // CustomerCode1
            // 
            this.CustomerCode1.Enabled = false;
            this.CustomerCode1.Location = new System.Drawing.Point(144, 167);
            this.CustomerCode1.Name = "CustomerCode1";
            this.CustomerCode1.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode1.TabIndex = 49;
            // 
            // CustomerCode2
            // 
            this.CustomerCode2.Enabled = false;
            this.CustomerCode2.Location = new System.Drawing.Point(250, 167);
            this.CustomerCode2.Name = "CustomerCode2";
            this.CustomerCode2.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode2.TabIndex = 50;
            // 
            // CustomerCode3
            // 
            this.CustomerCode3.Enabled = false;
            this.CustomerCode3.Location = new System.Drawing.Point(356, 167);
            this.CustomerCode3.Name = "CustomerCode3";
            this.CustomerCode3.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode3.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(15, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "得意先コード指定";
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(235, 62);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(74, 19);
            this.textBox10.TabIndex = 53;
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(330, 62);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(74, 19);
            this.textBox11.TabIndex = 53;
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(420, 62);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(74, 19);
            this.textBox12.TabIndex = 53;
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.Location = new System.Drawing.Point(512, 62);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(74, 19);
            this.textBox13.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "1:全て 2:個別選択 3:個別除外　※1固定";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(146, 36);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 19);
            this.textBox14.TabIndex = 55;
            this.textBox14.Text = "01";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 52;
            this.label7.Text = "計上拠点コード";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "請求処理1件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "検索対象";
            // 
            // ProcCntntsFlag
            // 
            this.ProcCntntsFlag.Location = new System.Drawing.Point(146, 115);
            this.ProcCntntsFlag.Name = "ProcCntntsFlag";
            this.ProcCntntsFlag.Size = new System.Drawing.Size(72, 19);
            this.ProcCntntsFlag.TabIndex = 57;
            this.ProcCntntsFlag.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 12);
            this.label9.TabIndex = 59;
            this.label9.Text = "1:締次更新 2:締次取消";
            // 
            // CustomerCode4
            // 
            this.CustomerCode4.Enabled = false;
            this.CustomerCode4.Location = new System.Drawing.Point(462, 167);
            this.CustomerCode4.Name = "CustomerCode4";
            this.CustomerCode4.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode4.TabIndex = 60;
            // 
            // CustomerCode5
            // 
            this.CustomerCode5.Enabled = false;
            this.CustomerCode5.Location = new System.Drawing.Point(568, 167);
            this.CustomerCode5.Name = "CustomerCode5";
            this.CustomerCode5.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode5.TabIndex = 61;
            // 
            // CustomerCode10
            // 
            this.CustomerCode10.Enabled = false;
            this.CustomerCode10.Location = new System.Drawing.Point(568, 192);
            this.CustomerCode10.Name = "CustomerCode10";
            this.CustomerCode10.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode10.TabIndex = 66;
            // 
            // CustomerCode9
            // 
            this.CustomerCode9.Enabled = false;
            this.CustomerCode9.Location = new System.Drawing.Point(462, 192);
            this.CustomerCode9.Name = "CustomerCode9";
            this.CustomerCode9.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode9.TabIndex = 65;
            // 
            // CustomerCode8
            // 
            this.CustomerCode8.Enabled = false;
            this.CustomerCode8.Location = new System.Drawing.Point(356, 192);
            this.CustomerCode8.Name = "CustomerCode8";
            this.CustomerCode8.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode8.TabIndex = 64;
            // 
            // CustomerCode7
            // 
            this.CustomerCode7.Enabled = false;
            this.CustomerCode7.Location = new System.Drawing.Point(250, 192);
            this.CustomerCode7.Name = "CustomerCode7";
            this.CustomerCode7.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode7.TabIndex = 63;
            // 
            // CustomerCode6
            // 
            this.CustomerCode6.Enabled = false;
            this.CustomerCode6.Location = new System.Drawing.Point(144, 192);
            this.CustomerCode6.Name = "CustomerCode6";
            this.CustomerCode6.Size = new System.Drawing.Size(100, 19);
            this.CustomerCode6.TabIndex = 62;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(725, 440);
            this.Controls.Add(this.CustomerCode10);
            this.Controls.Add(this.CustomerCode9);
            this.Controls.Add(this.CustomerCode8);
            this.Controls.Add(this.CustomerCode7);
            this.Controls.Add(this.CustomerCode6);
            this.Controls.Add(this.CustomerCode5);
            this.Controls.Add(this.CustomerCode4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ProcCntntsFlag);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CustomerCode3);
            this.Controls.Add(this.CustomerCode2);
            this.Controls.Add(this.CustomerCode1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddUpDate);
            this.Controls.Add(this.UpdObjectFlag);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            DateTime appDate;
            appDate = System.DateTime.Now;

            _custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();

            _custDmdPrcUpdateWork.EnterpriseCode = textBox1.Text;                       //企業コード
            _custDmdPrcUpdateWork.AddUpSecCode = textBox14.Text;                        //計上拠点コード
            _custDmdPrcUpdateWork.UpdObjectFlag = Convert.ToInt32(UpdObjectFlag.Text);  //1:全て 2:個別選択 3:個別除外
            _custDmdPrcUpdateWork.ProcCntntsFlag = Convert.ToInt32(ProcCntntsFlag.Text);//1:締次更新 2:締取消
            _custDmdPrcUpdateWork.CustomerTotalDay = Convert.ToInt32(textBox2.Text);    //得意先締日            
            Int32 addUpDateY = Convert.ToInt32(AddUpDate.Text) / 10000;
            Int32 addUpDateM = (Convert.ToInt32(AddUpDate.Text) % 10000) /100;
            Int32 addUpDateD = Convert.ToInt32(AddUpDate.Text) % 100;
            _custDmdPrcUpdateWork.AddUpDate = new DateTime(addUpDateY, addUpDateM, addUpDateD);//計上年月日
            _custDmdPrcUpdateWork.AddUpYearMonth = new DateTime(addUpDateY, addUpDateM, 01);

            // XMLへ変換し、文字列のバイナリ化
            //byte[] parabyte = XmlByteSerializer.Serialize(_custDmdPrcUpdateWork);
            object paraObj = null;
            paraObj = (object)_custDmdPrcUpdateWork;

            object retParam = null;
            string retMsg = null;

            int status = IcustDmdPrcDB.Write(ref paraObj, out retParam, out retMsg);
            if (status != 0)
            {
                Text = "STATUS = " + status + " 更新失敗 : " + retMsg;
            }
            else
            {
                // XMLの読み込み
                //_custDmdPrcUpdateWork = (CustDmdPrcUpdateWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustDmdPrcUpdateWork));
                ArrayList retList = retParam as ArrayList;

                for (int i = 0; i < retList.Count; i++)
                {
                    _custDmdPrcUpdStatusWork = retList[i] as CustDmdPrcUpdStatusWork;
                }

                Text = "更新成功";
            }
        }

        /// <summary>
        /// FormLoad時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            IcustDmdPrcDB = MediationCustDmdPrcDB.GetCustDmdPrcDB();
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 締取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, System.EventArgs e)
        {
            DateTime appDate;
            appDate = System.DateTime.Now;

            _custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            _custDmdPrcUpdateWork.EnterpriseCode = textBox1.Text;//企業コード
            _custDmdPrcUpdateWork.AddUpSecCode = textBox14.Text;//計上拠点コード
            _custDmdPrcUpdateWork.ProcCntntsFlag = Int32.Parse(ProcCntntsFlag.Text);//処理内容フラグ
            _custDmdPrcUpdateWork.UpdObjectFlag = Convert.ToInt32(UpdObjectFlag.Text);
            _custDmdPrcUpdateWork.CustomerTotalDay = Convert.ToInt32(textBox2.Text);//得意先締日
            Int32 addUpDateY = Convert.ToInt32(AddUpDate.Text) / 10000;
            Int32 addUpDateM = (Convert.ToInt32(AddUpDate.Text) % 10000) / 100;
            Int32 addUpDateD = Convert.ToInt32(AddUpDate.Text) % 100;
            _custDmdPrcUpdateWork.AddUpDate = new DateTime(addUpDateY, addUpDateM, addUpDateD);//計上年月日

            object paraObj = null;
            string retMsg = null;
            paraObj = (object)_custDmdPrcUpdateWork;

            int status = IcustDmdPrcDB.Delete(ref paraObj, out retMsg);
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
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _custDmdPrcWork = new CustDmdPrcWork();
            _custDmdPrcWork.EnterpriseCode = textBox1.Text;//企業コード
            _custDmdPrcWork.AddUpSecCode = textBox14.Text;//計上拠点コード
            _custDmdPrcWork.CustomerCode = 2000;//得意先締日
            _custDmdPrcWork.AddUpDate = new DateTime(2007, 04, 20);

            object paraObj = null;
            string retMsg = null;
            paraObj = (object)_custDmdPrcWork;

            int status = IcustDmdPrcDB.ReadCustDmdPrc(ref paraObj, out retMsg);
            if (status != 0)
            {
                Text = "読取失敗 : " + retMsg;
            }
            else
            {
                Text = "読取成功";
            }
        }
    }
}

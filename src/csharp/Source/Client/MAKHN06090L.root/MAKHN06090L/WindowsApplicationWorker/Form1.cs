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
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;

        //private SecInfoAcs _SecInfoAcs = null;
        //private SecInfoSetWork _SecInfoSetWork = null;

        //private SecInfoSetWork _prevSecInfoSetWork = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGrid dataGrid3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGrid dataGrid4;
        private System.Windows.Forms.Button button6;

        private SectionInfoLcDB sectionInfoLcDB = null;
        private static System.Windows.Forms.Form _form = null;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox4;
        private Button button13;
        private Button button14;
        private Button button15;
        private static string[] _parameter;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "TBS1";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 120);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(880, 96);
            this.dataGrid1.TabIndex = 13;
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
            this.label5.Location = new System.Drawing.Point(144, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "論理削除区分";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(264, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(24, 19);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "1";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(432, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 24);
            this.button8.TabIndex = 33;
            this.button8.Text = "CustomSearch";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 248);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(1032, 136);
            this.dataGrid2.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "■拠点情報条件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "■予約入庫分類別目標抽出検索結果";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(832, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 37;
            this.button1.Text = "New";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(576, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(624, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 19);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(984, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 43;
            this.button2.Text = "Add";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(904, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "■拠点コード";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(904, 152);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 64);
            this.listBox1.TabIndex = 45;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(904, 128);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(144, 19);
            this.textBox3.TabIndex = 46;
            this.textBox3.Text = "000001";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(984, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 24);
            this.button3.TabIndex = 47;
            this.button3.Text = "Clear";
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(432, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 24);
            this.button4.TabIndex = 48;
            this.button4.Text = "SearchACS";
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // dataGrid3
            // 
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(16, 408);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(1032, 136);
            this.dataGrid3.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 23);
            this.label4.TabIndex = 50;
            this.label4.Text = "■拠点情報結果";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(768, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 24);
            this.button5.TabIndex = 51;
            this.button5.Text = "NewACS";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 544);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 23);
            this.label7.TabIndex = 53;
            this.label7.Text = "■拠点情報結果";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid4
            // 
            this.dataGrid4.DataMember = "";
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(16, 568);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.Size = new System.Drawing.Size(1032, 136);
            this.dataGrid4.TabIndex = 52;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(552, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 24);
            this.button6.TabIndex = 54;
            this.button6.Text = "GetSecInfoACS";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(320, 64);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 24);
            this.button7.TabIndex = 55;
            this.button7.Text = "NewACS";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(818, 64);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(144, 24);
            this.button10.TabIndex = 56;
            this.button10.Text = "GetSecInfoACS";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(818, 34);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(144, 24);
            this.button11.TabIndex = 57;
            this.button11.Text = "GetSecInfoACSCtr";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(552, 88);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(144, 24);
            this.button12.TabIndex = 58;
            this.button12.Text = "WriteOfflineData";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(712, 56);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 59;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(320, 16);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(96, 24);
            this.button13.TabIndex = 60;
            this.button13.Text = "SetSecInfo";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(818, 4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(144, 24);
            this.button14.TabIndex = 61;
            this.button14.Text = "GetSecInfoACSCtrList";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(432, 90);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(96, 24);
            this.button15.TabIndex = 62;
            this.button15.Text = "ReSetACS";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1056, 734);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGrid4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
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
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "Form1", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
            //Application.Run(new Form1());
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
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            sectionInfoLcDB = new SectionInfoLcDB();

            //textBox1.Text = LoginInfoAcquisition.EnterpriseCode;

            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            secInfoSetWork.EnterpriseCode = textBox1.Text;
            ArrayList al = new ArrayList();
            al.Add(secInfoSetWork);

            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }


        private void button9_Click(object sender, System.EventArgs e)
        {
            textBox7.Text = "";
            //			_prevSecInfoSetWork = null;
            dataGrid1.DataSource = null;
            dataGrid2.DataSource = null;
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            ArrayList al = dataGrid1.DataSource as ArrayList;
            SecInfoSetWork parabyte = al[0] as SecInfoSetWork;
            dataGrid2.DataSource = null;
            dataGrid3.DataSource = null;

            //ArrayList tglist = null;
            //ArrayList timelist = null;
            //CustomSerializeArrayList csal = null;

            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            parabyte.SectionCode = textBox3.Text;

            object objret;
            int errorLevel;
            string errorCode = "";
            string errorMessage = "";

            DateTime start, end;
            start = DateTime.Now;
            int status = sectionInfoLcDB.Search(out objret, parabyte, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
            end = DateTime.Now;
            textBox2.Text = Convert.ToString((end - start).TotalSeconds);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                ArrayList CSAList = objret as ArrayList;
                //				foreach(object obj in CSAList)
                //				{
                //					ArrayList wkal = obj as ArrayList;
                //					if(obj != null)
                //					{
                //						if(wkal[0] is SecInfoSetWork)tglist = wkal;
                //						else if(wkal[0] is ArrayList)timelist = wkal;
                //						//else if(wkal[0] is SearchRetResvdCETgTimeWork)timelist = wkal;
                //					}
                //
                //				}

                //Text = "該当データ有り  HIT "+tglist.Count.ToString()+"件";
                dataGrid2.DataSource = CSAList[0];
                dataGrid3.DataSource = CSAList[1];
                dataGrid4.DataSource = CSAList[2];
            }
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            secInfoSetWork.EnterpriseCode = textBox1.Text;
            ArrayList al = new ArrayList();
            al.Add(secInfoSetWork);

            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        private void button2_Click_1(object sender, System.EventArgs e)
        {
            listBox1.Items.Add(textBox3.Text);
        }

        private void button3_Click_1(object sender, System.EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click_1(object sender, System.EventArgs e)
        {
            //SecInfoSet wkSecInfoSet = null;
            //_SecInfoAcs.ResetSectionInfo();// GetSecInfo(' (out wkSecInfoSet);
            //			//SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            //			//secInfoSetWork.EnterpriseCode = textBox1.Text;
            //
            //			SecInfoSetWork secInfoSetWork = ((ArrayList)dataGrid1.DataSource)[0] as SecInfoSetWork;
            //
            //			string[] str = new string[listBox1.Items.Count];
            //			for(int i=0;i<listBox1.Items.Count;i++)
            //			{
            //				str[i] = listBox1.Items[i].ToString();
            //			}
            //			secInfoSetWork.SelectSecCd = str;
            //
            //
            //			SecInfoSetWorkAcs acs = new SecInfoSetWorkAcs();
            //			DataSet ds1 = null;
            //			DataSet ds2 = null;
            //
            //			int errorLevel;
            //			string errorCode,errorMessage = "";
            //			
            //			DateTime start,end;
            //			start = DateTime.Now;
            //			acs.Search(ref ds1,ref ds2,ConstantManagement.LogicalMode.GetData0,secInfoSetWork,out errorLevel,out errorCode,out errorMessage);
            //			end = DateTime.Now;
            //			textBox2.Text = Convert.ToString((end - start).TotalSeconds);
            //		
            //			dataGrid2.DataSource = ds1.Tables["RSRVCENTTGRF"];
            //			dataGrid3.DataSource = ds2;

        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
            secInfoSetWork.EnterpriseCode = textBox1.Text;
            ArrayList al = new ArrayList();
            al.Add(secInfoSetWork);

            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            //SecInfoSet wkSecInfoSet = null;
            //ArrayList _SecCtrlSetList;
            ////ArrayList _CompanyNmList;

            //_SecInfoAcs.GetSecInfo(textBox3.Text, out wkSecInfoSet, out _SecCtrlSetList);


        }

        private void button7_Click(object sender, System.EventArgs e)
        {

            //_SecInfoAcs = new SecInfoAcs();

            //dataGrid2.DataSource = _SecInfoAcs.SecInfoSetList;
            //dataGrid3.DataSource = _SecInfoAcs.SecCtrlSetList;
            //dataGrid4.DataSource = _SecInfoAcs.CompanyNmList;
        }

        private void button10_Click(object sender, System.EventArgs e)
        {

            //SecInfoSet wkSecInfoSet = null;
            //CompanyNm wkCompanyNm = null;

            //SecInfoSet secInfoSet = null;
            //ArrayList secCtrlSetList = null;
            //string sectionCode = textBox4.Text.Trim();
            //if (sectionCode != "")
            //    _SecInfoAcs.GetSecInfo(sectionCode, out secInfoSet, out secCtrlSetList);
            //else
            //    _SecInfoAcs.GetSecInfo(out secInfoSet, out secCtrlSetList);

            //dataGrid3.DataSource = secCtrlSetList;
            //_SecInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd2, out wkSecInfoSet,out wkCompanyNm);


            /*
                        //---拠点情報部品アクセスクラスのインスタンス化---//
                        //ここでログイン企業コードから全ての拠点情報をサーバーから取得します
                        SecInfoAcs _SecInfoAcs = new SecInfoAcs();

                        //---各プロパティ値の取得---//
                        //インスタンス化が行われた段階で各プロパティには値が設定されています
                        dataGrid2.DataSource = _SecInfoAcs.SecInfoSetList;	//拠点情報設定リスト
                        dataGrid3.DataSource = _SecInfoAcs.SecCtrlSetList;	//拠点制御設定リスト
                        dataGrid4.DataSource = _SecInfoAcs.CompanyNmList;	//自社名称リスト

                        //---プロパティ値の再設定---//
                        _SecInfoAcs.ResetSectionInfo();				//拠点指定なし
                        _SecInfoAcs.ResetSectionInfo(sectionCode);	//指定された拠点コードを自拠点としてプロパティを設定します

                        //---自拠点の拠点情報の取得---//
                        _SecInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet, out companyNm);
                        //---自拠点の制御拠点情報の取得---//
                        _SecInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet, out companyNm);
                        //---拠点コードを指定しての拠点情報の取得---//
                        _SecInfoAcs.GetSecInfo(sectionCode, SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet, out companyNm);

            */
        }

        private void button11_Click(object sender, System.EventArgs e)
        {

            //SecInfoSet wkSecInfoSet = null;
            //CompanyNm wkCompanyNm = null;

            //_SecInfoAcs.GetSecInfo(SecInfoAcs.CtrlFuncCode.BillSettingSecCd, SecInfoAcs.CompanyNameCd.CompanyNameCd2, out wkSecInfoSet, out wkCompanyNm);
        }

        private void button12_Click(object sender, System.EventArgs e)
        {
            //_SecInfoAcs.WriteOfflineData(this);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ArrayList al = dataGrid1.DataSource as ArrayList;
            SecInfoSetWork parabyte = al[0] as SecInfoSetWork;
            dataGrid2.DataSource = null;
            dataGrid3.DataSource = null;

            //ArrayList tglist = null;
            //ArrayList timelist = null;
            //CustomSerializeArrayList csal = null;

            string[] str = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                str[i] = listBox1.Items[i].ToString();
            }
            parabyte.SectionCode = textBox3.Text;

            object objret;
            int errorLevel;
            string errorCode = "";
            string errorMessage = "";

            DateTime start, end;
            start = DateTime.Now;
            int status = sectionInfoLcDB.Search(out objret, parabyte, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
            end = DateTime.Now;
            textBox2.Text = Convert.ToString((end - start).TotalSeconds);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                //CustomSerializeArrayList CSAList = objret as CustomSerializeArrayList;
                //				foreach(object obj in CSAList)
                //				{
                //					ArrayList wkal = obj as ArrayList;
                //					if(obj != null)
                //					{
                //						if(wkal[0] is SecInfoSetWork)tglist = wkal;
                //						else if(wkal[0] is ArrayList)timelist = wkal;
                //						//else if(wkal[0] is SearchRetResvdCETgTimeWork)timelist = wkal;
                //					}
                //
                //				}

                //Text = "該当データ有り  HIT "+tglist.Count.ToString()+"件";
                //dataGrid2.DataSource = CSAList[0];
                //dataGrid3.DataSource = CSAList[1];
                //dataGrid4.DataSource = CSAList[2];

                //SecInfoAcs.SetSecInfo((ArrayList)CSAList[0], (ArrayList)CSAList[1], (ArrayList)CSAList[2]);
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //SecInfoSet wkSecInfoSet = null;
            //CompanyNm wkCompanyNm = null;
            //ArrayList secctrllist = null;
            //_SecInfoAcs.GetSecInfo(out wkSecInfoSet, out secctrllist);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //_SecInfoAcs.ResetSectionInfo();
        }
    }
}

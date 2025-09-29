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
        private System.Windows.Forms.TextBox EnterpriseCode;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        //private ExtrInfo_AccRecConsTaxDiffWork _salesOrderWork = null;

        //private ExtrInfo_AccRecConsTaxDiffWork _prevSalesConfShWork = null;
        private System.Windows.Forms.Button button8;

        private IAccRecConsTaxDiffDB IAccRecConsTaxDiffDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private TextBox SectionCode1;
        private TextBox SectionCode2;
        private TextBox SectionCode3;
        private Label label1;
        private Label label2;
        private TextBox St_SalesDate;
        private TextBox Ed_SalesDate;
        private Label label5;
        private Label label6;
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
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.SectionCode1 = new System.Windows.Forms.TextBox();
            this.SectionCode2 = new System.Windows.Forms.TextBox();
            this.SectionCode3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.St_SalesDate = new System.Windows.Forms.TextBox();
            this.Ed_SalesDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(88, 19);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 1;
            this.EnterpriseCode.Text = "0113180842031000";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 305);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(909, 231);
            this.dataGrid1.TabIndex = 13;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 276);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "実行";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 199);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(908, 71);
            this.dataGrid2.TabIndex = 39;
            // 
            // SectionCode1
            // 
            this.SectionCode1.Location = new System.Drawing.Point(88, 44);
            this.SectionCode1.Name = "SectionCode1";
            this.SectionCode1.Size = new System.Drawing.Size(146, 19);
            this.SectionCode1.TabIndex = 40;
            // 
            // SectionCode2
            // 
            this.SectionCode2.Location = new System.Drawing.Point(240, 44);
            this.SectionCode2.Name = "SectionCode2";
            this.SectionCode2.Size = new System.Drawing.Size(146, 19);
            this.SectionCode2.TabIndex = 41;
            // 
            // SectionCode3
            // 
            this.SectionCode3.Location = new System.Drawing.Point(392, 44);
            this.SectionCode3.Name = "SectionCode3";
            this.SectionCode3.Size = new System.Drawing.Size(146, 19);
            this.SectionCode3.TabIndex = 42;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "拠点コード";
            // 
            // St_SalesDate
            // 
            this.St_SalesDate.Location = new System.Drawing.Point(88, 69);
            this.St_SalesDate.Name = "St_SalesDate";
            this.St_SalesDate.Size = new System.Drawing.Size(146, 19);
            this.St_SalesDate.TabIndex = 52;
            this.St_SalesDate.Text = "20010101";
            // 
            // Ed_SalesDate
            // 
            this.Ed_SalesDate.Location = new System.Drawing.Point(263, 69);
            this.Ed_SalesDate.Name = "Ed_SalesDate";
            this.Ed_SalesDate.Size = new System.Drawing.Size(146, 19);
            this.Ed_SalesDate.TabIndex = 53;
            this.Ed_SalesDate.Text = "20091231";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 55;
            this.label5.Text = "売上日付";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(240, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "～";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Ed_SalesDate);
            this.Controls.Add(this.St_SalesDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SectionCode3);
            this.Controls.Add(this.SectionCode2);
            this.Controls.Add(this.SectionCode1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.EnterpriseCode);
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
            IAccRecConsTaxDiffDB = MediationAccRecConsTaxDiffDB.GetAccRecConsTaxDiffDB();
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
            string[] sectionCode = new string[3];

            ArrayList al = new ArrayList();
            ExtrInfo_AccRecConsTaxDiffWork work = new ExtrInfo_AccRecConsTaxDiffWork();

            work.EnterpriseCode = "0101150842020000";
            
            //sectionCode[0] = SectionCode1.Text;
            //sectionCode[1] = SectionCode2.Text;
            //sectionCode[2] = SectionCode3.Text;
            //work.SecCodeList = sectionCode;

            //if (St_SalesDate.Text != "") work.St_SalesDate = Convert.ToInt32(St_SalesDate.Text);
            //if (Ed_SalesDate.Text != "") work.Ed_SalesDate = Convert.ToInt32(Ed_SalesDate.Text);


            al.Add(work);
            dataGrid2.DataSource = al;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
            button9_Click(sender, e);

            object parabyte = dataGrid2.DataSource;
            object objOrder = null;

            Int32 status = -1;
            status = IAccRecConsTaxDiffDB.SearchAccRecConsTaxDiffProc(out objOrder, parabyte);

            if (status != 0)
            {
                Text = "該当データ無し:status = " + status.ToString();
            }
            else
            {

                Text = "該当データ有り  HIT " + ((ArrayList)objOrder).Count.ToString() + "件";

                dataGrid1.DataSource = objOrder;
            }
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



    }
}

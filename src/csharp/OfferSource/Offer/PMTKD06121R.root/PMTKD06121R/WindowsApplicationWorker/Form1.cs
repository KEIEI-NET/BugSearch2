using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtMakerCode;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        //private CTICustomerSearchRetWork _cTICustomerSearchRetWork = null;

        //private CTICustomerSearchRetWork _prevCTICustomerSearchRetWork = null;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;

        //private ICategoryEquipmentDB iCategoryEquipmentDB = null;
        //    private PrimePartsInfDB primepartsinfDB = null;

        //private ICTICustomerSearchDB IcarowneruDB = null;
        //private CTICustomerSearchAcs cTICustomerSearchAcs = null;

        private static System.Windows.Forms.Form _form = null;
        private Label label5;
        private TextBox txtModelCode;
        private Label label1;
        private TextBox txtModelSubCode;
        private Label label2;
        private TextBox txtProduceTypeofYearCd;
        private Label label4;
        private TextBox txtSystematicCode;
        private Label label6;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private TextBox txtFullModelFixedNo;
        private Label label7;
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
            this.txtMakerCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModelCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelSubCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProduceTypeofYearCd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSystematicCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.txtFullModelFixedNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMakerCode
            // 
            this.txtMakerCode.Location = new System.Drawing.Point(146, 14);
            this.txtMakerCode.Name = "txtMakerCode";
            this.txtMakerCode.Size = new System.Drawing.Size(145, 19);
            this.txtMakerCode.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(825, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 33;
            this.btnSearch.Text = "結合検索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(628, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(676, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 19);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "MakerCode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModelCode
            // 
            this.txtModelCode.Location = new System.Drawing.Point(146, 37);
            this.txtModelCode.Name = "txtModelCode";
            this.txtModelCode.Size = new System.Drawing.Size(145, 19);
            this.txtModelCode.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "ModelCode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModelSubCode
            // 
            this.txtModelSubCode.Location = new System.Drawing.Point(146, 60);
            this.txtModelSubCode.Name = "txtModelSubCode";
            this.txtModelSubCode.Size = new System.Drawing.Size(145, 19);
            this.txtModelSubCode.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 43;
            this.label2.Text = "ModelSubCode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProduceTypeofYearCd
            // 
            this.txtProduceTypeofYearCd.Location = new System.Drawing.Point(455, 12);
            this.txtProduceTypeofYearCd.Name = "txtProduceTypeofYearCd";
            this.txtProduceTypeofYearCd.Size = new System.Drawing.Size(145, 19);
            this.txtProduceTypeofYearCd.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(326, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 23);
            this.label4.TabIndex = 45;
            this.label4.Text = "ProduceTypeOfYearCd";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSystematicCode
            // 
            this.txtSystematicCode.Location = new System.Drawing.Point(455, 37);
            this.txtSystematicCode.Name = "txtSystematicCode";
            this.txtSystematicCode.Size = new System.Drawing.Size(145, 19);
            this.txtSystematicCode.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(326, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 47;
            this.label6.Text = "SystematicCode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(919, 200);
            this.dataGridView1.TabIndex = 48;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 301);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(919, 200);
            this.dataGridView2.TabIndex = 49;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(12, 505);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 21;
            this.dataGridView3.Size = new System.Drawing.Size(919, 200);
            this.dataGridView3.TabIndex = 50;
            // 
            // txtFullModelFixedNo
            // 
            this.txtFullModelFixedNo.Location = new System.Drawing.Point(455, 60);
            this.txtFullModelFixedNo.Name = "txtFullModelFixedNo";
            this.txtFullModelFixedNo.Size = new System.Drawing.Size(145, 19);
            this.txtFullModelFixedNo.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(326, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 52;
            this.label7.Text = "FullModelFixedNo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(943, 715);
            this.Controls.Add(this.txtFullModelFixedNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSystematicCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProduceTypeofYearCd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtModelSubCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModelCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtMakerCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
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
            /*
            _form = new Form1();
            System.Windows.Forms.Application.Run(_form);
            */
            //*
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
            //*/
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

        private IColTrmEquInfDB _IColTrmEquInfDB;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            _IColTrmEquInfDB = MediationColTrmEquInfDB.GetRemoteObject();
        }


        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            int makerCd;
            int modelCd;
            int modelSubCd;
            int produceYearCd;
            int SystemCd;
            int fullModelFixedNo;
            object colorCdRetWork;
            object trimCdRetWork;
            object cEqpDefDspRetWork;

            object paraColTrmEquSearchCondWork;

            ColTrmEquSearchCondWork colTrmEquSearchCondWork = new ColTrmEquSearchCondWork();

            if (int.TryParse(txtMakerCode.Text, out makerCd))
                colTrmEquSearchCondWork.MakerCode = makerCd;

            if (int.TryParse(txtModelCode.Text, out modelCd))
                colTrmEquSearchCondWork.ModelCode = modelCd;

            if (int.TryParse(txtModelSubCode.Text, out modelSubCd))
                colTrmEquSearchCondWork.ModelSubCode = modelSubCd;

            if (int.TryParse(txtProduceTypeofYearCd.Text, out produceYearCd))
                colTrmEquSearchCondWork.ProduceTypeOfYearCd = new int[] { produceYearCd };

            if (int.TryParse(txtSystematicCode.Text, out SystemCd))
                colTrmEquSearchCondWork.SystematicCode = new int[] { SystemCd };
            if (int.TryParse(txtFullModelFixedNo.Text, out fullModelFixedNo))
                colTrmEquSearchCondWork.FullModelFixedNo = new int[] { fullModelFixedNo };

            paraColTrmEquSearchCondWork = colTrmEquSearchCondWork;

            _IColTrmEquInfDB.SearchColTrmEquInf(out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, ref paraColTrmEquSearchCondWork);
            dataGridView1.DataSource = colorCdRetWork;
            dataGridView2.DataSource = trimCdRetWork;
            dataGridView3.DataSource = cEqpDefDspRetWork;
        }

    }
}

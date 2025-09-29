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
        private System.Windows.Forms.TextBox txtBLCode;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGrid dataGrid2;

        private IOfferPrimeBlSearchDB iOfferPrimeBlSearchDB = null;

        private static System.Windows.Forms.Form _form = null;
        private Label label1;
        private Label label2;
        private TextBox txtMaker;
        private TextBox txtModel;
        private TextBox txtModelSub;
        private Label label4;
        private TextBox txtSeries;
        private Label label5;
        private TextBox txtBody;
        private Label label6;
        private TextBox txtDoor;
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
            this.txtBLCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtModelSub = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDoor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBLCode
            // 
            this.txtBLCode.Location = new System.Drawing.Point(87, 12);
            this.txtBLCode.Name = "txtBLCode";
            this.txtBLCode.Size = new System.Drawing.Size(105, 19);
            this.txtBLCode.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(779, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "検索";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(17, 62);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1031, 306);
            this.dataGrid1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(892, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(940, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 19);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(17, 375);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(1031, 306);
            this.dataGrid2.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 54;
            this.label1.Text = "BL コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(215, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 56;
            this.label2.Text = "コード";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(285, 14);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(69, 19);
            this.txtMaker.TabIndex = 55;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(360, 14);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(69, 19);
            this.txtModel.TabIndex = 57;
            // 
            // txtModelSub
            // 
            this.txtModelSub.Location = new System.Drawing.Point(435, 14);
            this.txtModelSub.Name = "txtModelSub";
            this.txtModelSub.Size = new System.Drawing.Size(69, 19);
            this.txtModelSub.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(525, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 60;
            this.label4.Text = "シリーズモデル";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSeries
            // 
            this.txtSeries.Location = new System.Drawing.Point(606, 14);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(69, 19);
            this.txtSeries.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 62;
            this.label5.Text = "ボディー";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(87, 37);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(69, 19);
            this.txtBody.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(215, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 64;
            this.label6.Text = "ドア";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDoor
            // 
            this.txtDoor.Location = new System.Drawing.Point(285, 39);
            this.txtDoor.Name = "txtDoor";
            this.txtDoor.Size = new System.Drawing.Size(69, 19);
            this.txtDoor.TabIndex = 63;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1064, 694);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDoor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.txtModelSub);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtBLCode);
            this.Controls.Add(this.label3);
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


        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            iOfferPrimeBlSearchDB = MediationOfferPrimeBlSearchDB.GetOfferPrimeBlSearchDB();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            // 初期化
            ArrayList RetParts1 = new ArrayList();
            ArrayList RetParts2 = new ArrayList();
            ArrayList RetParts3 = new ArrayList();
            ArrayList RetParts4 = new ArrayList();

            OfferPrimeBlSearchCondWork offerPrimeBlSearchCondWork = new OfferPrimeBlSearchCondWork();

            int blCode;
            int doorCount;
            int makerCd, modelCd, modelSubCd;

            int.TryParse(txtBLCode.Text, out blCode);
            int.TryParse(txtDoor.Text, out doorCount);
            int.TryParse(txtMaker.Text, out makerCd);
            int.TryParse(txtModel.Text, out modelCd);
            int.TryParse(txtModelSub.Text, out modelSubCd);

            offerPrimeBlSearchCondWork.TbsPartsCode = blCode;
            //offerPrimeBlSearchCondWork.BodyName = txtBody.Text;
            //offerPrimeBlSearchCondWork.DoorCount = doorCount;
            offerPrimeBlSearchCondWork.MakerCode = makerCd;
            offerPrimeBlSearchCondWork.ModelCode = modelCd;
            offerPrimeBlSearchCondWork.ModelSubCode = modelSubCd;
            //offerPrimeBlSearchCondWork.SeriesModel = txtSeries.Text;            
            
            DateTime start, end;
            start = DateTime.Now;

            int status = iOfferPrimeBlSearchDB.Search(offerPrimeBlSearchCondWork, out RetParts1, out RetParts2, out RetParts3, out RetParts4);

            //            textBox7.Text = ((ArrayList)data).Count.ToString();
            end = DateTime.Now;
            textBox2.Text = Convert.ToString((end - start).TotalSeconds);

            dataGrid1.DataSource = RetParts1;
            dataGrid2.DataSource = RetParts2;

        }

    }
}

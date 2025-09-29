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
//using Broadleaf.Application.Controller;
//using Broadleaf.Application.UIData;
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
        private IContainer components;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;

        private static System.Windows.Forms.Form _form = null;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor2;
        private Label label1;
        private Button button1;
        private static string[] _parameter;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        private DataGrid dataGrid2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor3;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TextBox textBox3;
        private Label label2;
        private Label label4;
        private Button button5;
        private TextBox textBox4;
        private MergeDataGetDB _mergeDataGetDB = new MergeDataGetDB();

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
            this.components = new System.ComponentModel.Container();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraTextEditor2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.ultraTextEditor3 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(784, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "シンクデータ取得";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(487, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(541, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ultraTextEditor1
            // 
            this.ultraTextEditor1.Location = new System.Drawing.Point(84, 14);
            this.ultraTextEditor1.Name = "ultraTextEditor1";
            this.ultraTextEditor1.Size = new System.Drawing.Size(141, 21);
            this.ultraTextEditor1.TabIndex = 39;
            // 
            // ultraTextEditor2
            // 
            this.ultraTextEditor2.Location = new System.Drawing.Point(12, 333);
            this.ultraTextEditor2.Multiline = true;
            this.ultraTextEditor2.Name = "ultraTextEditor2";
            this.ultraTextEditor2.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.ultraTextEditor2.Size = new System.Drawing.Size(870, 261);
            this.ultraTextEditor2.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "データサイズ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "日付取得";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(12, 85);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(868, 242);
            this.dataGrid2.TabIndex = 43;
            // 
            // ultraTextEditor3
            // 
            this.ultraTextEditor3.Location = new System.Drawing.Point(243, 13);
            this.ultraTextEditor3.Name = "ultraTextEditor3";
            this.ultraTextEditor3.Size = new System.Drawing.Size(113, 21);
            this.ultraTextEditor3.TabIndex = 44;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "ﾏｰｼﾞﾃﾞｰﾀ取得";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(443, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 46;
            this.button3.Text = "価格取得";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(524, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 47;
            this.button4.Text = "メーカー取得";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 19);
            this.textBox1.TabIndex = 48;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(243, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 19);
            this.textBox3.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 50;
            this.label2.Text = "メーカー";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(193, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 23);
            this.label4.TabIndex = 51;
            this.label4.Text = "品番";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(620, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 23);
            this.button5.TabIndex = 52;
            this.button5.Text = "インストール日付取得";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(717, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 53;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(894, 606);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ultraTextEditor3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ultraTextEditor2);
            this.Controls.Add(this.ultraTextEditor1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor3)).EndInit();
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

        private IMergeDataGet _ISyncProcess;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            _ISyncProcess = MediationMergeDataGetDB.GetRemoteObject();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            //int date = 0;
            //byte[] syncData;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //_ISyncProcess.GetSyncData("en", "1", ref date, out syncData);
            sw.Stop();
            textBox2.Text = string.Format("Elapsed Time [{0}]", sw.Elapsed);
            //ultraTextEditor1.Text = syncData.Length.ToString("N");
            //string data = System.Text.Encoding.Default.GetString(syncData);
            //ultraTextEditor2.Text = data;
            //System.Diagnostics.Debug.WriteLine(syncData.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    int offerDate = 20081001;


            int blDate = 20081221;//20081001;
            int groupDate = 20081212;//20081001;
            int goodsMDate = 20090305;//20081001;
            int modelNmDate = 20081201;//20081001;
            int makerDate = 20090103;//20081001;
            int partsPosDate = 20080828;//20081001;
            int priceDate = 20081130;//20081001;
            int prmSetDate = 20081130;//20081001;
            int prmSetChgDate = 20081130;//20081001;
            int primPartsDate = 20081130;//20081091;
            int searchPartsType=20;
            int bigCarOfferDiv=1;

            //offerDate = Int32.Parse(ultraTextEditor3.Text.Trim());
            object offerDateList = null;
            _mergeDataGetDB.GetOfferDate(blDate, groupDate, goodsMDate, modelNmDate, makerDate, partsPosDate, priceDate, primPartsDate, prmSetDate, prmSetChgDate, searchPartsType, bigCarOfferDiv, out offerDateList);
            //Text = "該当データ有り  HIT " + ((CustomSerializeArrayList)objUOEGuideName).Count.ToString() + "件";

            dataGrid2.DataSource = offerDateList;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int offerDate = 0;
            offerDate = Int32.Parse(ultraTextEditor3.Text.Trim());
            object offerDateList = new object();
            MergeInfoGetCond cond = new MergeInfoGetCond();

            cond.BLFlg = 1;
            cond.BLGroupFlg = 1;
            cond.GoodsMGroupFlg = 1;
            cond.ModelNameFlg = 1;
            cond.PrmSetChgFlg = 1;
            cond.PrmSetFlg = 1;
            cond.PartsPosFlg = 1;
            cond.PMakerFlg = 1;


            _mergeDataGetDB.GetMergeData(offerDate, cond, out offerDateList,20,1 );
            //Text = "該当データ有り  HIT " + ((CustomSerializeArrayList)objUOEGuideName).Count.ToString() + "件";

            dataGrid2.DataSource = offerDateList;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int offerDate = 0;
            int makerCd = 0;

            string GoodsNo = "";
            string GoodsPriceNo = "";

            makerCd = Int32.Parse(textBox1.Text.Trim());
            GoodsNo = textBox3.Text.Trim();
            GoodsPriceNo = textBox3.Text.Trim();
            offerDate = Int32.Parse(ultraTextEditor3.Text.Trim());
            object obj = null;
            ArrayList resultlist = new ArrayList();
            _mergeDataGetDB.GetGoodsInfo(offerDate, makerCd, GoodsNo, GoodsPriceNo, out obj);
            ArrayList objlst = obj as ArrayList;
            foreach (ArrayList al in objlst)
            {

                resultlist.Add(al);
            }
            dataGrid2.DataSource = resultlist;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int offerDate = 0;
            offerDate = Int32.Parse(ultraTextEditor3.Text.Trim());
            object resultlist = null;
            _mergeDataGetDB.GetMakerInfo(offerDate, out resultlist);

            dataGrid2.DataSource = resultlist;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime installofferDate = DateTime.MinValue;
            //_mergeDataGetDB.GetInstalDate(ref installofferDate);

            textBox4.Text = installofferDate.ToString();
        }


    }
}

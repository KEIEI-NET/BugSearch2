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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;

        private AcptAnOdrTtlStWork _acptAnOdrTtlStWork = null;
        //private SearchAcptAnOdrTtlStParaWork _searchAcptAnOdrTtlStParaWork = null;

        //private AcptAnOdrTtlStWork _prevAcptAnOdrTtlStWork = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;

        private IAcptAnOdrTtlStDB IacptAnOdrTtlStDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label2;
        private Label label1;
        private TextBox OrderNumberCompo;
        private TextBox EnterpriseCode;
        private Label label3;
        private TextBox OrderFormRealPrtDiv;
        private Label label4;
        private TextBox EstmCountReflectDiv;
        private Label label5;
        private TextBox AcpOdrrSlipPrtDiv;
        private Label label6;
        private TextBox OrderScrDisp;
        private Label label7;
        private TextBox AodrOrderAddUpDiv;
        private Label label8;
        private TextBox DotKulOrderDiv;
        private Label label9;
        private TextBox FaxOrderDiv;
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
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderNumberCompo = new System.Windows.Forms.TextBox();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OrderFormRealPrtDiv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EstmCountReflectDiv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AcpOdrrSlipPrtDiv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OrderScrDisp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AodrOrderAddUpDiv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DotKulOrderDiv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.FaxOrderDiv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 139);
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
            this.button9.Location = new System.Drawing.Point(96, 139);
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
            this.button10.Location = new System.Drawing.Point(289, 255);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 23);
            this.button10.TabIndex = 34;
            this.button10.Text = "WriteGrid";
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
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(361, 255);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(72, 23);
            this.button13.TabIndex = 36;
            this.button13.Text = "LogDelGrid";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(433, 255);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "RevGrid";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(505, 255);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 23);
            this.button15.TabIndex = 38;
            this.button15.Text = "DelGrid";
            this.button15.Click += new System.EventHandler(this.button15_Click);
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
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "発注番号構成";
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
            // OrderNumberCompo
            // 
            this.OrderNumberCompo.Location = new System.Drawing.Point(147, 26);
            this.OrderNumberCompo.Name = "OrderNumberCompo";
            this.OrderNumberCompo.Size = new System.Drawing.Size(115, 19);
            this.OrderNumberCompo.TabIndex = 46;
            this.OrderNumberCompo.Text = "10";
            // 
            // EnterpriseCode
            // 
            this.EnterpriseCode.Location = new System.Drawing.Point(147, 6);
            this.EnterpriseCode.Name = "EnterpriseCode";
            this.EnterpriseCode.Size = new System.Drawing.Size(115, 19);
            this.EnterpriseCode.TabIndex = 45;
            this.EnterpriseCode.Text = "0113180842031000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "発注書即時発行区分";
            // 
            // OrderFormRealPrtDiv
            // 
            this.OrderFormRealPrtDiv.Location = new System.Drawing.Point(147, 46);
            this.OrderFormRealPrtDiv.Name = "OrderFormRealPrtDiv";
            this.OrderFormRealPrtDiv.Size = new System.Drawing.Size(115, 19);
            this.OrderFormRealPrtDiv.TabIndex = 49;
            this.OrderFormRealPrtDiv.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "見積数反映区分";
            // 
            // EstmCountReflectDiv
            // 
            this.EstmCountReflectDiv.Location = new System.Drawing.Point(147, 66);
            this.EstmCountReflectDiv.Name = "EstmCountReflectDiv";
            this.EstmCountReflectDiv.Size = new System.Drawing.Size(115, 19);
            this.EstmCountReflectDiv.TabIndex = 51;
            this.EstmCountReflectDiv.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "受注伝票発行区分";
            // 
            // AcpOdrrSlipPrtDiv
            // 
            this.AcpOdrrSlipPrtDiv.Location = new System.Drawing.Point(147, 86);
            this.AcpOdrrSlipPrtDiv.Name = "AcpOdrrSlipPrtDiv";
            this.AcpOdrrSlipPrtDiv.Size = new System.Drawing.Size(115, 19);
            this.AcpOdrrSlipPrtDiv.TabIndex = 53;
            this.AcpOdrrSlipPrtDiv.Text = "40";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "発注画面表示";
            // 
            // OrderScrDisp
            // 
            this.OrderScrDisp.Location = new System.Drawing.Point(147, 106);
            this.OrderScrDisp.Name = "OrderScrDisp";
            this.OrderScrDisp.Size = new System.Drawing.Size(115, 19);
            this.OrderScrDisp.TabIndex = 55;
            this.OrderScrDisp.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 62;
            this.label7.Text = "受発注計上時相手区分";
            // 
            // AodrOrderAddUpDiv
            // 
            this.AodrOrderAddUpDiv.Location = new System.Drawing.Point(428, 66);
            this.AodrOrderAddUpDiv.Name = "AodrOrderAddUpDiv";
            this.AodrOrderAddUpDiv.Size = new System.Drawing.Size(115, 19);
            this.AodrOrderAddUpDiv.TabIndex = 61;
            this.AodrOrderAddUpDiv.Text = "80";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 60;
            this.label8.Text = "ドットクル発注区分";
            // 
            // DotKulOrderDiv
            // 
            this.DotKulOrderDiv.Location = new System.Drawing.Point(428, 46);
            this.DotKulOrderDiv.Name = "DotKulOrderDiv";
            this.DotKulOrderDiv.Size = new System.Drawing.Size(115, 19);
            this.DotKulOrderDiv.TabIndex = 59;
            this.DotKulOrderDiv.Text = "70";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(296, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 12);
            this.label9.TabIndex = 58;
            this.label9.Text = "ＦＡＸ発注区分";
            // 
            // FaxOrderDiv
            // 
            this.FaxOrderDiv.Location = new System.Drawing.Point(428, 26);
            this.FaxOrderDiv.Name = "FaxOrderDiv";
            this.FaxOrderDiv.Size = new System.Drawing.Size(115, 19);
            this.FaxOrderDiv.TabIndex = 57;
            this.FaxOrderDiv.Text = "60";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AodrOrderAddUpDiv);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DotKulOrderDiv);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.FaxOrderDiv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OrderScrDisp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EstmCountReflectDiv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OrderFormRealPrtDiv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrderNumberCompo);
            this.Controls.Add(this.EnterpriseCode);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
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
        /// 1件読み込み処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
//            if (_acptAnOdrTtlStWork == null) _acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            _acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            _acptAnOdrTtlStWork.EnterpriseCode = EnterpriseCode.Text;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_acptAnOdrTtlStWork);            

            int status = IacptAnOdrTtlStDB.Read(ref parabyte,0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                _acptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(AcptAnOdrTtlStWork));

                Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(_acptAnOdrTtlStWork);
                dataGrid1.DataSource = al;
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
            IacptAnOdrTtlStDB = MediationAcptAnOdrTtlStDB.GetAcptAnOdrTtlStDB();
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
            ArrayList al = new ArrayList();
            SearchAcptAnOdrTtlStParaWork work = new SearchAcptAnOdrTtlStParaWork();
            work.EnterpriseCode = EnterpriseCode.Text;
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
            ArrayList al = new ArrayList();
            SearchAcptAnOdrTtlStParaWork work = new SearchAcptAnOdrTtlStParaWork();
            work.EnterpriseCode = "0101150842020000";
            work.SectionCode = "00";
            al.Add(work);
            dataGrid2.DataSource = al;
            object parabyte = dataGrid2.DataSource;
            object objacptAnOdrTtlSt = new AcptAnOdrTtlStWork();

            int status = IacptAnOdrTtlStDB.Search(out objacptAnOdrTtlSt, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT "+((ArrayList)objacptAnOdrTtlSt).Count.ToString()+"件";
                
                dataGrid1.DataSource = objacptAnOdrTtlSt;
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, System.EventArgs e)
        {
            object objacptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            objacptAnOdrTtlStWork = dataGrid1.DataSource;
    
            int status = IacptAnOdrTtlStDB.Write(ref objacptAnOdrTtlStWork);
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
                dataGrid1.DataSource = objacptAnOdrTtlStWork;
            }        
        }

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, System.EventArgs e)
        {
            AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            acptAnOdrTtlStWork.EnterpriseCode = EnterpriseCode.Text;
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if (al == null) al = new ArrayList();
            al.Add(acptAnOdrTtlStWork);
            dataGrid1.DataSource = null;
            dataGrid1.DataSource = al;
        }

        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, System.EventArgs e)
        {
            object objacptAnOdrTtlStWork = dataGrid1.DataSource;

            int status = IacptAnOdrTtlStDB.LogicalDelete(ref objacptAnOdrTtlStWork);
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
                dataGrid1.DataSource = objacptAnOdrTtlStWork;
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, System.EventArgs e)
        {
            object objacptAnOdrTtlStWork = dataGrid1.DataSource;

            AcptAnOdrTtlStWork[] trarray = (AcptAnOdrTtlStWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(AcptAnOdrTtlStWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IacptAnOdrTtlStDB.Delete(parabyte);
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
                //dataGrid1.DataSource = objacptAnOdrTtlStWork;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            object objacptAnOdrTtlStWork = dataGrid1.DataSource;

            int status = IacptAnOdrTtlStDB.RevivalLogicalDelete(ref objacptAnOdrTtlStWork);
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
                dataGrid1.DataSource = objacptAnOdrTtlStWork;
            }
        }
    }
}

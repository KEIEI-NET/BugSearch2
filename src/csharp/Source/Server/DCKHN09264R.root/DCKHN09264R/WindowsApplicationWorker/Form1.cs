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

        private SlipOutputSetWork _slipOutputSetWork = null;
        //private SearchSlipOutputSetParaWork _searchSlipOutputSetParaWork = null;

        //private SlipOutputSetWork _prevSlipOutputSetWork = null;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;

        private ISlipOutputSetDB IslipOutputSetDB = null;

        private static string[] _parameter;
        private DataGrid dataGrid2;
        private Label label2;
        private Label label1;
        private TextBox SectionCode;
        private TextBox EnterpriseCode;
        private Label label3;
        private TextBox CashRegisterNo;
        private Label label4;
        private TextBox SlipPrtKind;
        private Label label5;
        private TextBox SlipPrtSetPaperId;
        private Label label6;
        private TextBox DataInputSystem;
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
            this.SectionCode = new System.Windows.Forms.TextBox();
            this.EnterpriseCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CashRegisterNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SlipPrtKind = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SlipPrtSetPaperId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DataInputSystem = new System.Windows.Forms.TextBox();
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
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "拠点コード";
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
            // SectionCode
            // 
            this.SectionCode.Location = new System.Drawing.Point(147, 26);
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.Size = new System.Drawing.Size(115, 19);
            this.SectionCode.TabIndex = 46;
            this.SectionCode.Text = "000001";
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
            this.label3.Size = new System.Drawing.Size(48, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "レジ番号";
            // 
            // CashRegisterNo
            // 
            this.CashRegisterNo.Location = new System.Drawing.Point(147, 46);
            this.CashRegisterNo.Name = "CashRegisterNo";
            this.CashRegisterNo.Size = new System.Drawing.Size(115, 19);
            this.CashRegisterNo.TabIndex = 49;
            this.CashRegisterNo.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "伝票印刷種別";
            // 
            // SlipPrtKind
            // 
            this.SlipPrtKind.Location = new System.Drawing.Point(147, 87);
            this.SlipPrtKind.Name = "SlipPrtKind";
            this.SlipPrtKind.Size = new System.Drawing.Size(115, 19);
            this.SlipPrtKind.TabIndex = 51;
            this.SlipPrtKind.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "伝票印刷設定用帳票ID";
            // 
            // SlipPrtSetPaperId
            // 
            this.SlipPrtSetPaperId.Location = new System.Drawing.Point(147, 107);
            this.SlipPrtSetPaperId.Name = "SlipPrtSetPaperId";
            this.SlipPrtSetPaperId.Size = new System.Drawing.Size(115, 19);
            this.SlipPrtSetPaperId.TabIndex = 53;
            this.SlipPrtSetPaperId.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "データ入力システム";
            // 
            // DataInputSystem
            // 
            this.DataInputSystem.Location = new System.Drawing.Point(147, 67);
            this.DataInputSystem.Name = "DataInputSystem";
            this.DataInputSystem.Size = new System.Drawing.Size(115, 19);
            this.DataInputSystem.TabIndex = 55;
            this.DataInputSystem.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(941, 550);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DataInputSystem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SlipPrtSetPaperId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SlipPrtKind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CashRegisterNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SectionCode);
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
//            if (_slipOutputSetWork == null) _slipOutputSetWork = new SlipOutputSetWork();
            _slipOutputSetWork = new SlipOutputSetWork();
            _slipOutputSetWork.EnterpriseCode = EnterpriseCode.Text;
            //_slipOutputSetWork.SectionCode = SectionCode.Text;
            _slipOutputSetWork.CashRegisterNo = Convert.ToInt32(CashRegisterNo.Text);
            _slipOutputSetWork.DataInputSystem = Convert.ToInt32(DataInputSystem.Text);
            _slipOutputSetWork.SlipPrtKind = Convert.ToInt32(SlipPrtKind.Text);
            _slipOutputSetWork.SlipPrtSetPaperId = SlipPrtSetPaperId.Text;
            //_slipOutputSetWork.PrinterMngNo = Convert.ToInt32(PrinterMngNo.Text);

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(_slipOutputSetWork);            

            int status = IslipOutputSetDB.Read(ref parabyte,0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                _slipOutputSetWork = (SlipOutputSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipOutputSetWork));

                Text = "該当データ有り";
                ArrayList al = new ArrayList();
                al.Add(_slipOutputSetWork);
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
            IslipOutputSetDB = MediationSlipOutputSetDB.GetSlipOutputSetDB();
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
            SearchSlipOutputSetParaWork work = new SearchSlipOutputSetParaWork();
            work.EnterpriseCode = EnterpriseCode.Text;
            string[] sectionCode = new string[1];
            sectionCode[0] = SectionCode.Text; 
            work.SelectSectCd =  sectionCode;
            work.CashRegisterNo = Convert.ToInt32(CashRegisterNo.Text);
            work.DataInputSystem = Convert.ToInt32(DataInputSystem.Text);
            work.SlipPrtKind = Convert.ToInt32(SlipPrtKind.Text);
            work.SlipPrtSetPaperId = SlipPrtSetPaperId.Text;
            //work.PrinterMngNo = Convert.ToInt32(PrinterMngNo.Text);
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
            SearchSlipOutputSetParaWork work = new SearchSlipOutputSetParaWork();
            work.EnterpriseCode = EnterpriseCode.Text;
            string[] sectionCode = new string[1];
            sectionCode[0] = SectionCode.Text;
            work.SelectSectCd = sectionCode;
            work.CashRegisterNo = Convert.ToInt32(CashRegisterNo.Text);
            work.DataInputSystem = Convert.ToInt32(DataInputSystem.Text);
            work.SlipPrtKind = Convert.ToInt32(SlipPrtKind.Text);
            work.SlipPrtSetPaperId = SlipPrtSetPaperId.Text;
            //work.PrinterMngNo = Convert.ToInt32(PrinterMngNo.Text);
            al.Add(work);
            dataGrid2.DataSource = al;
            object parabyte = dataGrid2.DataSource;
            object objslipOutputSet;

            int status = IslipOutputSetDB.Search(out objslipOutputSet, parabyte, 0, 0);

            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {

                Text = "該当データ有り  HIT "+((ArrayList)objslipOutputSet).Count.ToString()+"件";
                
                dataGrid1.DataSource = objslipOutputSet;
            }
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, System.EventArgs e)
        {
            object objslipOutputSetWork = dataGrid1.DataSource;
    
            int status = IslipOutputSetDB.Write(ref objslipOutputSetWork);
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
                dataGrid1.DataSource = objslipOutputSetWork;
            }        
        }

        /// <summary>
        /// 行追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, System.EventArgs e)
        {
            SlipOutputSetWork slipOutputSetWork = new SlipOutputSetWork();
            slipOutputSetWork.EnterpriseCode = EnterpriseCode.Text;
            //slipOutputSetWork.SectionCode = SectionCode.Text;
            slipOutputSetWork.CashRegisterNo = Convert.ToInt32(CashRegisterNo.Text);
            slipOutputSetWork.DataInputSystem = Convert.ToInt32(DataInputSystem.Text);
            slipOutputSetWork.SlipPrtKind = Convert.ToInt32(SlipPrtKind.Text);
            slipOutputSetWork.SlipPrtSetPaperId = SlipPrtSetPaperId.Text;
            //slipOutputSetWork.PrinterMngNo = Convert.ToInt32(PrinterMngNo.Text);
            ArrayList al = dataGrid1.DataSource as ArrayList;
            if(al == null)al = new ArrayList();
            al.Add(slipOutputSetWork);
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
            object objslipOutputSetWork = dataGrid1.DataSource;

            int status = IslipOutputSetDB.LogicalDelete(ref objslipOutputSetWork);
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
                dataGrid1.DataSource = objslipOutputSetWork;
            }
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, System.EventArgs e)
        {
            object objslipOutputSetWork = dataGrid1.DataSource;

            SlipOutputSetWork[] trarray = (SlipOutputSetWork[])((ArrayList)dataGrid1.DataSource).ToArray(typeof(SlipOutputSetWork));
            byte[] parabyte = XmlByteSerializer.Serialize(trarray);

            int status = IslipOutputSetDB.Delete(parabyte);
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
                //dataGrid1.DataSource = objslipOutputSetWork;
            }
        }

        /// <summary>
        /// 復活処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            object objslipOutputSetWork = dataGrid1.DataSource;

            int status = IslipOutputSetDB.RevivalLogicalDelete(ref objslipOutputSetWork);
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
                dataGrid1.DataSource = objslipOutputSetWork;
            }
        }
    }
}

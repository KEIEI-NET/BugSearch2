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
//using Broadleaf.Application.Controller;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections.Generic;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBoxEnterpriseCode;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Button button3;

        private static System.Windows.Forms.Form _form = null;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimePickerPriceDate;
        private NumericUpDown numericUpDownBlUtyPtSbCdRF;
        private Label label7;
        private ListBox listBoxAutoAnswerDivSCM;
        private TextBox textBoxBlUtyPtThCdRF;
        private TextBox textBoxBLCode;
        private Label label8;
        private TextBox textBoxStatus;
        private Label label9;
        private TextBox textBoxFullModelFixedNo;
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
            this.dateTimePickerPriceDate.Value = DateTime.Now.Date;

            this.textBoxEnterpriseCode.Text = "0101150842020000";
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
            this.textBoxEnterpriseCode = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerPriceDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownBlUtyPtSbCdRF = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxAutoAnswerDivSCM = new System.Windows.Forms.ListBox();
            this.textBoxBlUtyPtThCdRF = new System.Windows.Forms.TextBox();
            this.textBoxBLCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxFullModelFixedNo = new System.Windows.Forms.TextBox();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGrid2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDownBlUtyPtSbCdRF ) ).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEnterpriseCode
            // 
            this.textBoxEnterpriseCode.Location = new System.Drawing.Point( 74, 5 );
            this.textBoxEnterpriseCode.Name = "textBoxEnterpriseCode";
            this.textBoxEnterpriseCode.Size = new System.Drawing.Size( 288, 19 );
            this.textBoxEnterpriseCode.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point( 681, 168 );
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size( 96, 24 );
            this.buttonSearch.TabIndex = 33;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler( this.buttonSearch_Click );
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point( 0, 198 );
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size( 891, 420 );
            this.dataGrid2.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point( 723, 8 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 48, 23 );
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point( 771, 8 );
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size( 112, 19 );
            this.textBoxTime.TabIndex = 39;
            this.textBoxTime.Text = "0";
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point( 783, 168 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 96, 24 );
            this.button3.TabIndex = 58;
            this.button3.Text = "Dummy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 8 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 56, 12 );
            this.label1.TabIndex = 59;
            this.label1.Text = "企業コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 44 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 77, 12 );
            this.label2.TabIndex = 60;
            this.label2.Text = "価格適用日付";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 12, 67 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 58, 12 );
            this.label4.TabIndex = 61;
            this.label4.Text = "旧BLコード";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 12, 114 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 58, 12 );
            this.label5.TabIndex = 62;
            this.label5.Text = "新BLコード";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 12, 138 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 77, 12 );
            this.label6.TabIndex = 63;
            this.label6.Text = "新BLサブコード";
            // 
            // dateTimePickerPriceDate
            // 
            this.dateTimePickerPriceDate.Location = new System.Drawing.Point( 127, 39 );
            this.dateTimePickerPriceDate.Name = "dateTimePickerPriceDate";
            this.dateTimePickerPriceDate.Size = new System.Drawing.Size( 127, 19 );
            this.dateTimePickerPriceDate.TabIndex = 64;
            // 
            // numericUpDownBlUtyPtSbCdRF
            // 
            this.numericUpDownBlUtyPtSbCdRF.Location = new System.Drawing.Point( 127, 136 );
            this.numericUpDownBlUtyPtSbCdRF.Maximum = new decimal( new int[] {
            99999999,
            0,
            0,
            0} );
            this.numericUpDownBlUtyPtSbCdRF.Name = "numericUpDownBlUtyPtSbCdRF";
            this.numericUpDownBlUtyPtSbCdRF.Size = new System.Drawing.Size( 120, 19 );
            this.numericUpDownBlUtyPtSbCdRF.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 12, 93 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 109, 12 );
            this.label7.TabIndex = 66;
            this.label7.Text = "自動回答区分(SCM)";
            // 
            // listBoxAutoAnswerDivSCM
            // 
            this.listBoxAutoAnswerDivSCM.FormattingEnabled = true;
            this.listBoxAutoAnswerDivSCM.ItemHeight = 12;
            this.listBoxAutoAnswerDivSCM.Items.AddRange( new object[] {
            "0:通常(PCC連携なし)",
            "1:手動回答",
            "2:自動回答"} );
            this.listBoxAutoAnswerDivSCM.Location = new System.Drawing.Point( 127, 89 );
            this.listBoxAutoAnswerDivSCM.Name = "listBoxAutoAnswerDivSCM";
            this.listBoxAutoAnswerDivSCM.Size = new System.Drawing.Size( 120, 16 );
            this.listBoxAutoAnswerDivSCM.TabIndex = 67;
            this.listBoxAutoAnswerDivSCM.SelectedIndexChanged += new System.EventHandler( this.listBoxAutoAnswerDivSCM_SelectedIndexChanged );
            // 
            // textBoxBlUtyPtThCdRF
            // 
            this.textBoxBlUtyPtThCdRF.Location = new System.Drawing.Point( 127, 111 );
            this.textBoxBlUtyPtThCdRF.MaxLength = 9;
            this.textBoxBlUtyPtThCdRF.Name = "textBoxBlUtyPtThCdRF";
            this.textBoxBlUtyPtThCdRF.Size = new System.Drawing.Size( 178, 19 );
            this.textBoxBlUtyPtThCdRF.TabIndex = 68;
            // 
            // textBoxBLCode
            // 
            this.textBoxBLCode.Location = new System.Drawing.Point( 127, 64 );
            this.textBoxBLCode.Name = "textBoxBLCode";
            this.textBoxBLCode.Size = new System.Drawing.Size( 100, 19 );
            this.textBoxBLCode.TabIndex = 69;
            this.textBoxBLCode.Validated += new System.EventHandler( this.textBoxBLCode_Validated );
            this.textBoxBLCode.Validating += new System.ComponentModel.CancelEventHandler( this.textBoxBLCode_Validating );
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 723, 39 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 38, 12 );
            this.label8.TabIndex = 70;
            this.label8.Text = "Status";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point( 771, 33 );
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size( 112, 19 );
            this.textBoxStatus.TabIndex = 71;
            this.textBoxStatus.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point( 323, 44 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 95, 12 );
            this.label9.TabIndex = 72;
            this.label9.Text = "フル型式固定番号";
            // 
            // textBoxFullModelFixedNo
            // 
            this.textBoxFullModelFixedNo.Location = new System.Drawing.Point( 424, 41 );
            this.textBoxFullModelFixedNo.Multiline = true;
            this.textBoxFullModelFixedNo.Name = "textBoxFullModelFixedNo";
            this.textBoxFullModelFixedNo.Size = new System.Drawing.Size( 122, 89 );
            this.textBoxFullModelFixedNo.TabIndex = 73;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 5, 12 );
            this.ClientSize = new System.Drawing.Size( 891, 618 );
            this.Controls.Add( this.textBoxFullModelFixedNo );
            this.Controls.Add( this.label9 );
            this.Controls.Add( this.textBoxStatus );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.textBoxBLCode );
            this.Controls.Add( this.textBoxBlUtyPtThCdRF );
            this.Controls.Add( this.listBoxAutoAnswerDivSCM );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.numericUpDownBlUtyPtSbCdRF );
            this.Controls.Add( this.dateTimePickerPriceDate );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.textBoxTime );
            this.Controls.Add( this.textBoxEnterpriseCode );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.dataGrid2 );
            this.Controls.Add( this.buttonSearch );
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler( this.Form1_Load );
            ( (System.ComponentModel.ISupportInitialize)( this.dataGrid2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.numericUpDownBlUtyPtSbCdRF ) ).EndInit();
            this.ResumeLayout( false );
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


        }

        private void listBoxAutoAnswerDivSCM_SelectedIndexChanged( object sender, EventArgs e )
        {
            switch (this.listBoxAutoAnswerDivSCM.SelectedIndex)
            {
                case 1:
                case 2:
                    this.textBoxBlUtyPtThCdRF.Text = string.Empty;
                    this.textBoxBlUtyPtThCdRF.Enabled = true;
                    this.numericUpDownBlUtyPtSbCdRF.Value = 0;
                    this.numericUpDownBlUtyPtSbCdRF.Enabled = true;
                    break;
                default:
                    this.textBoxBlUtyPtThCdRF.Text = string.Empty;
                    this.textBoxBlUtyPtThCdRF.Enabled = false;
                    this.numericUpDownBlUtyPtSbCdRF.Value = 0;
                    this.numericUpDownBlUtyPtSbCdRF.Enabled = false;
                    break;
            }
        }

        private void buttonSearch_Click( object sender, EventArgs e )
        {
            this.textBoxTime.Text = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", 0, 0, 0, 0);
            this.textBoxStatus.Text = "0";
            this.Refresh();

            DateTime stTime = DateTime.Now;

            GetPartsInfPara inPara = this.createInPara();
            if (inPara == null)
            {
                this.textBoxStatus.Text = string.Format( "[0]", -1 );
                this.Refresh();
                return;
            }
            IOfferPartsInfo iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

            List<PartsModelLnkWork> partsModelLnkWork = null;
            long retCnt = 0;

            object retInf = null;
            object colorWork = null;
            object trimWork = null;
            object equipWork = null;
            object prtSubstWork = null;

            int status = iOfferPartsInfo.GetPartsInf(
                inPara, ref retInf, ref colorWork, ref trimWork, ref equipWork, ref prtSubstWork, out partsModelLnkWork, out retCnt );

            if ( status == 0 && retCnt > 0 )
            {
                this.dataGrid2.DataSource = (CustomSerializeArrayList)retInf;
            }
            else
            {
                this.dataGrid2.DataSource = null;
            }

            DateTime edTime = DateTime.Now;
            DateTime durationTime = new DateTime( edTime.Ticks - stTime.Ticks );
            this.textBoxTime.Text = string.Format( "{0:00}:{1:00}:{2:00}.{3:000}", durationTime.Hour, durationTime.Minute, durationTime.Second, durationTime.Millisecond );
            this.textBoxStatus.Text = status.ToString();
            this.Refresh();
        }

        private GetPartsInfPara createInPara()
        {
            GetPartsInfPara inPara = new GetPartsInfPara();
            inPara.EnterpriseCode = this.textBoxEnterpriseCode.Text;
            inPara.PriceDate = this.dateTimePickerPriceDate.Value.Date;
            inPara.TbsPartsCode = int.Parse( this.textBoxBLCode.Text );
            if ( !string.IsNullOrEmpty(this.textBoxFullModelFixedNo.Text) && this.textBoxFullModelFixedNo.Lines.Length > 0 )
            {
                List<int> fullModelFixedNoList = new List<int>();
                for ( int i = 0 ; i < this.textBoxFullModelFixedNo.Lines.Length ; i++ )
                {
                    string str = this.textBoxFullModelFixedNo.Lines[i];
                    try
                    {
                        fullModelFixedNoList.Add(int.Parse(str));
                    }
                    catch(Exception ex)
                    {
                        TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOP, "PMTKD06161R", ex.Message, -1, MessageBoxButtons.OK );
                        return null;
                    }
                }
                inPara.FullModelFixedNo = fullModelFixedNoList.ToArray();
            }

            if (string.IsNullOrEmpty(this.textBoxBlUtyPtThCdRF.Text))
            {
                inPara.BlUtyPtThCd = string.Empty;
                inPara.BlUtyPtSbCd = 0;
            }
            else
            {
                inPara.BlUtyPtThCd = this.textBoxBlUtyPtThCdRF.Text;
                inPara.BlUtyPtSbCd = Convert.ToInt32(this.numericUpDownBlUtyPtSbCdRF.Value);
            }

            return inPara;
        }

        private void textBoxBLCode_Validating( object sender, CancelEventArgs e )
        {
            if ( string.IsNullOrEmpty(this.textBoxBLCode.Text) || this.textBoxBLCode.Text.Trim().Length <= 0 )
            {
                // なにもしない
                return;
            }
            else
            {
                try
                {
                    int resultCode = 0;
                    bool resultFlag = int.TryParse(this.textBoxBLCode.Text, out resultCode);
                    e.Cancel = !resultFlag;
                }
                catch(Exception ex)
                {
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOP, "PMTKD06161R", ex.Message, -1, MessageBoxButtons.OK );
                    e.Cancel = true;
                }
            }
        }

        private void textBoxBLCode_Validated( object sender, EventArgs e )
        {
            if (string.IsNullOrEmpty( this.textBoxBLCode.Text ) || this.textBoxBLCode.Text.Trim().Length <= 0)
            {
                // なにもしない
                return;
            }
            else
            {
                try
                {
                    int resultCode = 0;
                    bool resultFlag = int.TryParse( this.textBoxBLCode.Text, out resultCode );
                    if (resultFlag)
                    {
                        this.textBoxBLCode.Text = string.Format( "{0:000000}", resultCode );
                    }
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOP, "PMTKD06161R", ex.Message, -1, MessageBoxButtons.OK );
                }
            }
        }

    }
}

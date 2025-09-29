using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <br>Update Note : 2010/01/05　21024 佐々木 健</br>
    /// <br>              メニューや起動ダイアログの残像が残ることがある件の対応(MANTIS[0014851])</br>
    /// <br>              ※backgroundWorkerを画面から削除</br>
    /// <br>Update Note: 2011/02/18 21024 佐々木 健</br>
    /// <br>             SCM対応</br>
    /// <br>              1)キャンセル区分の対応</br>
    /// </remarks>
    public partial class MAHNB01000UA : Form
    {
        #region ●プライベート変数
        private MAHNB01010UA _salesSlipInput;
        private int _index;
        //FloatingWindow _fw = new FloatingWindow();        // 2010/01/05 Del
        //>>>2010/02/26
        string _parameter;
        long _scmInquiryNumber;    // 問合せ番号(SCM用)
        int _scmAcptAnOdrStatus;   // 受注ステータス(SCM用)
        string _scmSalesSlipNum;   // 売上伝票番号(SCM用)
        string _inqOriginalEpCd;
        string _inqOriginalSecCd;
        int _inqOrdDivCd;
        int _customerCode;
        //<<<2010/02/26
        // 2011/02/18 >>>
        //int _answerDivCd; // 2010/03/30
        short _cancelDiv;
        // 2011/02/18 <<<
        #endregion

        //>>>2010/02/26
        ///// <summary>
        ///// コンストラクタ
        ///// </summary>
        //public MAHNB01000UA(int index)
        //{
        //    // 2010/01/05 >>>
        //    //try
        //    //{
        //    //    InitializeComponent();
        //    //    //this._fw.Show(this); // スプラッシュ表示
        //    //    this.backgroundWorker1.RunWorkerAsync();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    this.backgroundWorker1.CancelAsync();
        //    //}

        //    InitializeComponent();
        //    this._index = index;
        //    // 2010/01/05 <<<


        //}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parameter"></param>
        public MAHNB01000UA(int index, string parameter)
        {
            InitializeComponent();
            this._index = index;
            this._parameter = parameter;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parameter"></param>
        /// <param name="customerCode"></param>
        public MAHNB01000UA(int index, string parameter, int customerCode)
        {
            InitializeComponent();
            this._index = index;
            this._parameter = parameter;
            this._customerCode = customerCode;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parameter"></param>
        /// <param name="inquiryNumber"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="inqOriginalEpCd"></param>
        /// <param name="inqOriginalSecCd"></param>
        /// <param name="inqOrdDivCd"></param>
        public MAHNB01000UA(int index, string parameter, long inquiryNumber, int acptAnOdrStatus, string salesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd)
        {
            InitializeComponent();

            this._index = index;

            this._parameter = parameter;
            this._scmInquiryNumber = inquiryNumber;
            this._scmAcptAnOdrStatus = acptAnOdrStatus;
            this._scmSalesSlipNum = salesSlipNum;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOrdDivCd = inqOrdDivCd;
        }
        //<<<2010/02/26

        //>>>2010/03/30
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="index"></param>
        /// <param name="parameter"></param>
        /// <param name="inquiryNumber"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="inqOriginalEpCd"></param>
        /// <param name="inqOriginalSecCd"></param>
        /// <param name="inqOrdDivCd"></param>
        /// <param name="answerDivCd"></param>
        // 2011/02/18 >>>
        //public MAHNB01000UA(int index, string parameter, long inquiryNumber, int acptAnOdrStatus, string salesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, int answerDivCd)
        public MAHNB01000UA(int index, string parameter, long inquiryNumber, int acptAnOdrStatus, string salesSlipNum, string inqOriginalEpCd, string inqOriginalSecCd, int inqOrdDivCd, short cancelDiv)
        // 2011/02/18 <<<
        {
            InitializeComponent();

            this._index = index;

            this._parameter = parameter;
            this._scmInquiryNumber = inquiryNumber;
            this._scmAcptAnOdrStatus = acptAnOdrStatus;
            this._scmSalesSlipNum = salesSlipNum;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOrdDivCd = inqOrdDivCd;
            // 2011/02/18 >>>
            //this._answerDivCd = answerDivCd;
            this._cancelDiv = cancelDiv;
            // 2011/02/18 <<<
        }
        //<<<2010/03/30

        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01000UA_Load(object sender, EventArgs e)
        {
            SalesSlipInputInitDataAcs salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            salesSlipInputInitDataAcs.CreateSecInfoAcs();

            //>>>2010/03/30
            ////>>>2010/02/26
            ////this._salesSlipInput = new MAHNB01010UA();
            //this._salesSlipInput = new MAHNB01010UA(this._parameter, this._scmInquiryNumber, this._scmAcptAnOdrStatus, this._scmSalesSlipNum, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOrdDivCd, this._customerCode);
            ////<<<2010/02/26
            // 2011/02/18 >>>
            //this._salesSlipInput = new MAHNB01010UA(this._parameter, this._scmInquiryNumber, this._scmAcptAnOdrStatus, this._scmSalesSlipNum, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOrdDivCd, this._customerCode, this._answerDivCd);
            this._salesSlipInput = new MAHNB01010UA(this._parameter, this._scmInquiryNumber, this._scmAcptAnOdrStatus, this._scmSalesSlipNum, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOrdDivCd, this._customerCode, this._cancelDiv);//@@@@20230303
            // 2011/02/18 <<<
            //<<<2010/03/30
            this._salesSlipInput.TopLevel = false;
            this._salesSlipInput.FormBorderStyle = FormBorderStyle.None;
            this._salesSlipInput.Show();
            this._salesSlipInput.Dock = DockStyle.Fill;
            this.Text = this._salesSlipInput.Text;
            if (_index > 0)
            {
                this._salesSlipInput.Text = string.Format("{0}[{1}]", this.Text, _index);
                this.Text = string.Format("{0}[{1}]", this.Text, _index);
            }
            //>>>2010/02/26
            this._salesSlipInput.InquiryNumber = this._scmInquiryNumber;
            this._salesSlipInput.AcptAnOdrStatus = this._scmAcptAnOdrStatus;
            this._salesSlipInput.SalesSlipNum = this._scmSalesSlipNum;
            //<<<2010/02/26
            this.Controls.Add(this._salesSlipInput);

            this._salesSlipInput.FormClosed += new FormClosedEventHandler(this.SalesSlipInput_FormClosed);
        }

        /// <summary>
        /// FormClosedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesSlipInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// MAHNB01000UA_Shownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01000UA_Shown(object sender, EventArgs e)
        {

            try
            {
                //this.backgroundWorker1.CancelAsync(); // 描画スレッド終了         // 2010/01/05 Del
                System.Windows.Forms.Application.DoEvents(); // 画面描画
                //if (this._fw != null) this._fw.Close(); // スプラッシュ非表示     // 2010/01/05 Del
                this.Opacity = 1; // 透明度100%
                System.Windows.Forms.Application.DoEvents(); // 画面描画
            }
            catch (Exception)
            {
            }
        }

        protected override void WndProc(ref Message m)
        {
            //const int WM_SYSCOMMAND = 0x112;
            //const int SC_CLOSE = 0xF060;

            //if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            //{
            //    this.WindowState = FormWindowState.Minimized;
            //    return;
            //}
            base.WndProc(ref m);
        }
        // 2010/01/05 Del >>>
        ///// <summary>
        ///// backgroundWorker1_DoWork
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    this.BackgroundOperation();
        //}

        ///// <summary>
        ///// BackgroundWorker処理
        ///// </summary>
        //private void BackgroundOperation()
        //{
        //    try
        //    {
        //        this._fw.Show(this); // スプラッシュ表示

        //        while (true)
        //        {
        //            System.Threading.Thread.Sleep(10);
        //            System.Windows.Forms.Application.DoEvents(); // 画面描画
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.backgroundWorker1.CancelAsync();
        //    }
        //}
        // 2010/01/05 Del <<<

        //>>>2010/02/26
        #region ●プロパティ
        /// <summary>起動パラメータ</summary>
        public string Parameter
        {
            set { this._parameter = value; }
            get { return this._parameter; }
        }
        /// <summary>問合せ番号(SCM用)</summary>
        public long SCMInquiryNumber
        {
            set { this._scmInquiryNumber = value; }
            get { return this._scmInquiryNumber; }
        }
        /// <summary>受注ステータス(SCM用)</summary>
        public int SCMAcptAnOdrStatus
        {
            set { this._scmAcptAnOdrStatus = value; }
            get { return this._scmAcptAnOdrStatus; }
        }
        /// <summary>売上伝票番号(SCM用)</summary>
        public string SCMSalesSlipNum
        {
            set { this._scmSalesSlipNum = value; }
            get { return this._scmSalesSlipNum; }
        }
        #endregion
        //<<<2010/02/26
    }
}
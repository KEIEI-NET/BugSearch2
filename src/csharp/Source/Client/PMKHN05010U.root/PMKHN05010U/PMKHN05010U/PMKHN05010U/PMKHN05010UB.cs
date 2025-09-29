using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信種別選択ガイドUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信種別の選択・登録の可否選択を行います</br>
    /// <br>Programmer : 30517 夏野 駿希</br>
    /// <br>Date       : 2011/01/17</br>
    /// <br></br>
    /// <br>UpDateNote : 2011/02/01　30517　夏野 駿希</br>
    /// <br>           : RetKeyControlを削除・送信種別から下キーでYESボタンへ移動する様に変更</br>
    /// <br></br>
    /// <br>UpDateNote : 2011/03/03　30517　夏野 駿希</br>
    /// <br>           : 画面の表示内容を変更</br>
    /// <br></br>
    /// <br>UpDateNote : 2011/05/17 20056 對馬 大輔</br>
    /// <br>           : SCM対応</br>
    /// <br>           : 1)指示書番号の追加</br>
    /// <br></br>
    /// <br>UpDateNote : 2011/09/16 鄧潘ハン</br>
    /// <br>           : Redmine 25219 PCCUOE PM側／売上伝票入力 UOE発注時の動作不具合の修正</br>
    /// <br></br>
    /// <br>UpDateNote : 2012/08/17 30744 湯上 千加子</br>
    /// <br>           : SCM障害№154対応 連結設定のチェックがない時送信しないようにする</br>
    /// <br></br>
    /// <br>UpDateNote : 2013/08/09 宮本 利明</br>
    /// <br>           : SCM障害№10557対応</br>
    /// <br></br>
    /// <br>UpDateNote : 2013/08/19 宮本 利明</br>
    /// <br>           : SCM障害№10557対応 ※2013/08/09対応分の修正</br>
    /// <br></br>
    /// <br>Update Note: 2020/02/24 譚洪</br>
    /// <br>管理番号   : 11570208-00</br>
    /// <br>           : PMKOBETSU-2912消費税税率機能追加対応</br>
    internal partial class PMKHN05010UB : Form
    {
        #region プライベートメンバ
        /// <summary>ダイアログリザルト</summary>
        private DialogResult _result = DialogResult.No;
        /// <summary>送信種別チェックボックスの状態</summary>
        private bool _optSendTargetChk = true;
        /// <summary>得意先略称</summary>
        private string _customerSnm = string.Empty;
        /// <summary>オンライン区分</summary>
        private int _optSendTargetDiv;
        /// <summary>送信固定フラグ</summary>
        private bool _mustSendFlg = false;
        //>>>2011/05/17
        /// <summary>指示書番号</summary>
        private string _partySalesSlipNum = string.Empty;
        //<<<2011/05/17
        // --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
        /// <summary>BLP送信区分</summary>
        private int _blpSendDiv = 1;
        // --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<

        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
        /// <summary>軽減税率区分</summary>
        private double _scmTaxRateInput = 0.0;
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
        #endregion

        #region 外部公開プロパティ（internal）
        /// <summary>ダイアログリザルト</summary>
        internal DialogResult Result
        {
            get { return _result; }
        }

        /// <summary>送信種別チェックボックスの状態</summary>
        internal bool OptSendTargetChk
        {
            get { return _optSendTargetChk; }
        }
        //>>>2011/05/17
        /// <summary>指示書番号</summary>
        internal string PartySalesSlipNum
        {
            get { return this._partySalesSlipNum; }
            set { this._partySalesSlipNum = value; }
        }
        //<<<2011/05/17

        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
        /// <summary>軽減税率区分</summary>
        internal double ScmTaxRateInput
        {
            get { return _scmTaxRateInput; }
            set { _scmTaxRateInput = value; }
        }
        // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="optSendTargetDiv">オンライン区分</param>
        /// <param name="mustSendFlg">送信固定フラグ</param>
        /// <param name="blpSendDiv">BLP送信区分</param>
        // --- UPD 2013/08/09 T.Miyamoto ------------------------------>>>>>
        //internal PMKHN05010UB(string customerSnm, int optSendTargetDiv, bool mustSendFlg)
        internal PMKHN05010UB(string customerSnm, int optSendTargetDiv, bool mustSendFlg, int blpSendDiv)
        // --- UPD 2013/08/09 T.Miyamoto ------------------------------<<<<<
        {
            InitializeComponent();
            _customerSnm = customerSnm;
            _optSendTargetDiv = optSendTargetDiv;
            _mustSendFlg = mustSendFlg;
            _blpSendDiv = blpSendDiv; //ADD 2013/08/09 T.Miyamoto
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// オンライン区分名称を取得します
        /// </summary>
        /// <returns></returns>
        private string getOnlineKindDivNm()
        {
            string onlineKindDivNm = string.Empty;

            #region 2011/03/03 del
            // 2011/03/03 Del >>>
            //switch (_optSendTargetDiv)
            //{
            //    case (int)PMKHN05010UA.OptSendTargetDiv.Scm:
            //        onlineKindDivNm = "SCM";
            //        break;
            //    case (int)PMKHN05010UA.OptSendTargetDiv.TspNs:
            //        onlineKindDivNm = "TSP.NS";
            //        break;
            //    case (int)PMKHN05010UA.OptSendTargetDiv.TspInline:
            //        onlineKindDivNm = "TSPインライン";
            //        break;
            //    case (int)PMKHN05010UA.OptSendTargetDiv.TspMail:
            //        onlineKindDivNm = "TSPメール";
            //        break;
            //    default:
            //        onlineKindDivNm = string.Empty;
            //        break;
            //}
            // 2011/03/03 Del <<<
            #endregion 2011/03/03 del

            // 2011/03/03 Add >>>
            switch (_optSendTargetDiv)
            {
                case (int)PMKHN05010UA.OptSendTargetDiv.Scm:
                    onlineKindDivNm = "回答送信";
                    break;
                case (int)PMKHN05010UA.OptSendTargetDiv.TspNs:
                    onlineKindDivNm = "TSP.NS送信";
                    break;
                case (int)PMKHN05010UA.OptSendTargetDiv.TspInline:
                    onlineKindDivNm = "TSPインライン送信";
                    break;
                case (int)PMKHN05010UA.OptSendTargetDiv.TspMail:
                    onlineKindDivNm = "TSPメール送信";
                    break;
                //---ADD 2011/09/16 --------->>>>>
                case (int)PMKHN05010UA.OptSendTargetDiv.ScmUOE:
                    onlineKindDivNm = "UOE送信時に回答送信";
                    break;
                //---ADD 2011/09/16 ---------<<<<<
                default:
                    onlineKindDivNm = string.Empty;
                    break;
            }
            // 2011/03/03 Add <<<
            return onlineKindDivNm;
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //uLabel_CustomerSNm.Text = _customerSnm; // 2011/03/03 Del
            uCheckEditor_OptSendTarget.Text = getOnlineKindDivNm();
            if (_mustSendFlg)
            {
                uCheckEditor_OptSendTarget.Enabled = false;
            }
            else
            {
                uCheckEditor_OptSendTarget.Enabled = true;
                // --- ADD 2013/08/19 T.Miyamoto ------------------------------>>>>>
                uCheckEditor_OptSendTarget.Checked = _blpSendDiv == 1;
                // --- ADD 2013/08/19 T.Miyamoto ------------------------------<<<<<
            }
            // --- DEL 2013/08/19 T.Miyamoto ------------------------------>>>>>
            //// --- ADD 2013/08/09 T.Miyamoto ------------------------------>>>>>
            //uCheckEditor_OptSendTarget.Checked = _blpSendDiv == 1;
            //// --- ADD 2013/08/09 T.Miyamoto ------------------------------<<<<<
            // --- DEL 2013/08/19 T.Miyamoto ------------------------------<<<<<

            // ADD 2012/08/17 SCM障害№154 --------------->>>>>
            // 送信しない時はチェックボックスを使用不可にする
            if (_optSendTargetDiv == (int)PMKHN05010UA.OptSendTargetDiv.ScmNoSend)
            {
                uCheckEditor_OptSendTarget.Checked = false;
                uCheckEditor_OptSendTarget.Enabled = false;
                uCheckEditor_OptSendTarget.Visible = false;
            }
            // ADD 2012/08/17 SCM障害№154 ---------------<<<<<

            Bitmap icon = new Bitmap(32, 32);
            Graphics graphics = Graphics.FromImage(icon);
            try
            {
                graphics.DrawIcon(SystemIcons.Information, 0, 0);
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
            pictureBox1.Image = icon;

            //>>>2011/05/17
            // 指示書番号表示設定
            switch (_optSendTargetDiv)
            {
                case (int)PMKHN05010UA.OptSendTargetDiv.Scm:
                    this.panel_PartySalesSlipNum.Visible = true;
                    break;
                //---ADD 2011/09/16------------------------>>>>>
                case (int)PMKHN05010UA.OptSendTargetDiv.ScmUOE:
                    this.panel_PartySalesSlipNum.Visible = true;
                    break;
                //---ADD 2011/09/16------------------------<<<<<
                case (int)PMKHN05010UA.OptSendTargetDiv.TspNs:
                case (int)PMKHN05010UA.OptSendTargetDiv.TspInline:
                case (int)PMKHN05010UA.OptSendTargetDiv.TspMail:
                    this.panel_PartySalesSlipNum.Visible = false;
                    break;
                default:
                    this.panel_PartySalesSlipNum.Visible = false;
                    break;
            }

            this.tEdit_PartySalesSlipNum.DataText = this._partySalesSlipNum;
            //<<<2011/05/17

            // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
            if (this._scmTaxRateInput != 0.0)
            {
                this.ultraLabel1.Visible = false;
                this.ultraLabel2.Visible = true;
                string msg = string.Format("税率({0}%)が設定されています。" + "\r\n" + "登録してもよろしいですか？", (this._scmTaxRateInput * 100).ToString("#0"));
                this.ultraLabel2.Text = msg;
            }
            // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
        }

        /// <summary>
        /// YESボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Yes_Click(object sender, EventArgs e)
        {
            _result = DialogResult.Yes;
            _optSendTargetChk = uCheckEditor_OptSendTarget.Checked;
            this.Close();
        }

        /// <summary>
        /// NOボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_No_Click(object sender, EventArgs e)
        {
            _result = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// KeyUpイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKHN05010UA_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Escキー⇒NOボタンクリックイベント
                case Keys.Escape:
                    uButton_No_Click(sender, e);
                    break;
                // Nキー⇒NOボタンクリックイベント
                case Keys.N:
                    uButton_No_Click(sender, e);
                    break;
                // Yキー⇒YESボタンクリックイベント
                case Keys.Y:
                    uButton_Yes_Click(sender, e);
                    break;
            }
        }

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }
            switch (prevCtrl.Name)
            {
                case "uButton_Yes":
                    if (!e.ShiftKey)
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                                // YESボタン上でエンターの場合はYESボタンクリックイベント
                                uButton_Yes_Click(sender, e);
                                break;
                        }
                    }
                    break;
                // 2011/02/01 Add >>>
                case "uCheckEditor_OptSendTarget":
                    switch (e.Key)
                    {
                        case Keys.Down:
                            // 下キー入力の場合はYESボタンへ移動
                            e.NextCtrl = uButton_Yes;
                            break;
                    }
                    break;
                // 2011/02/01 Add <<<

                //>>>2011/05/17
                case "tEdit_PartySalesSlipNum":
                    this._partySalesSlipNum = this.tEdit_PartySalesSlipNum.Text.Trim();
                    break;
                //<<<2011/05/17
            }
        }
        #endregion

        private void PMKHN05010UB_Shown(object sender, EventArgs e)
        {
            this.uButton_Yes.Focus();
        }
    }
}
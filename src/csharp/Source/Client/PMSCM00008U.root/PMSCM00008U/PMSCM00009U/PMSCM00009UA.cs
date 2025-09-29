//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せデータ受信確認画面 フォームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/20  修正内容 : IAAE版から製品版へ変更(不要ロジック削除)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
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
    /// 簡単問合せデータ受信確認画面 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成(IAAEから変更)</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/04/20</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM00009UA : Form
    {
        // ===================================================================================== //
        // 列挙型
        // ===================================================================================== //
        #region ■ 列挙型
        /// <summary>
        /// 問合せ・発注種別
        /// </summary>
        public enum InqOrdDivCd : int
        {
            Inquiry = 1,
            Order = 2
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member

        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト
        private int _customerCode = 0;
        private string _customerSnm = string.Empty;
        private InqOrdDivCd _inqOrdDiv = InqOrdDivCd.Inquiry;
        private long _inquiryNumber;

        // 2011/03/03 Add >>>
        private int _cancelRowNumber = 0;
        private string _cancelGoodsName = string.Empty;
        private int _cancelDiv = 0;

        private const int ctDefaultHeight = 260;
        private const int ctCancelHeight = 290;
        // 2011/03/03 Add <<<

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Property

        /// <summary>得意先略称</summary>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// <summary>得意先コード</summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>問合せ・発注種別</summary>
        public InqOrdDivCd InqOrdDiv
        {
            get { return _inqOrdDiv; }
            set { _inqOrdDiv = value; }
        }

        /// <summary>問合せ番号</summary>
        public long InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        // 2011/03/03 Add >>>
        /// <summary>
        /// 取り消した行番号
        /// </summary>
        public int CancelRowNumber
        {
            get { return _cancelRowNumber; }
            set { _cancelRowNumber = value; }
        }

        /// <summary>
        /// 取消した部品名称
        /// </summary>
        public string CancelGoodsName
        {
            get { return _cancelGoodsName; }
            set { _cancelGoodsName = value; }
        }

        /// <summary>
        /// キャンセル区分
        /// </summary>
        public int CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        // 2011/03/03 Add <<<
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■ Event

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Constructor

        public PMSCM00009UA()
        {
            InitializeComponent();
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method
        /// <summary>
        /// 画面セット
        /// </summary>
        private void SetDisplay()
        {
            this.ulabel_customerSNM.Text = _customerSnm.Trim();
            if (this.ulabel_customerSNM.Text.Length > 15) this.ulabel_customerSNM.Text = this.ulabel_customerSNM.Text.Substring(0, 15);
            // 2011/03/03 >>>
            //this.uLabel_Msg1.Text = string.Format("{0}情報を受信しました。", GetInfoMsg(_inqOrdDiv));
            //this.ulabel_InquiryNumber.Text = string.Format("{0:0000000000}", this._inquiryNumber);
            this.ulabel_InquiryNumber.Text = this._inquiryNumber.ToString();
            // 2011/03/03 <<<
            this.ulabel_inqOrdDiv.Text = GetInfoMsg(_inqOrdDiv);

            // 2011/03/03 Add >>>
            if (this._cancelRowNumber > 0)
            {
                this.Height = ctCancelHeight;
                this.uLabel_Msg1.Text = string.Format("{0}情報が取消されました。", GetInfoMsg(_inqOrdDiv));
                this.uLabel_GoodsName.Text = this._cancelGoodsName;
                this.uLabel_GoodsName.Visible = true;
                this.uLabel_GoodsNameTitle.Visible = true;
                this.button_ExecuteEntry.Visible = false;
            }
            else
            {
                this.Height = ctDefaultHeight;
                this.uLabel_Msg1.Text = string.Format("{0}情報を受信しました。", ( this._cancelDiv == 1 ) ? "返品" : GetInfoMsg(_inqOrdDiv));
                if (this._cancelDiv == 1)
                {
                    this.ulabel_inqOrdDiv.Text = "返品";
                }
                this.uLabel_GoodsName.Visible = false;
                this.uLabel_GoodsNameTitle.Visible = false;
                this.button_ExecuteEntry.Visible = true;
            }
            // 2011/03/03 Add <<<
        }

        #endregion

        // ===================================================================================== //
        // 各種コントロールイベント
        // ===================================================================================== //
        #region ■ Control Event
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this.SetDialogRes(DialogResult.Cancel);
            this.Close();
        }

        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerClaimConfirmation_Click(object sender, EventArgs e)
        {
            this.SetDialogRes(DialogResult.OK);
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UM_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;

        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UM_Load(object sender, EventArgs e)
        {
            this.SetDisplay();
        }

        #endregion


        #region ■ Private Static Method
        /// <summary>
        /// 情報のメッセージ取得
        /// </summary>
        /// <param name="inq"></param>
        /// <returns></returns>
        private static string GetInfoMsg(InqOrdDivCd inq)
        {
            string ret = string.Empty;

            switch (inq)
            {
                case InqOrdDivCd.Inquiry:
                    ret = "問合せ";
                    break;
                case InqOrdDivCd.Order:
                    ret = "発注";
                    break;
                default:
                    ret = "新着";
                    break;
            }
            return ret;
        }
        #endregion
    }
}
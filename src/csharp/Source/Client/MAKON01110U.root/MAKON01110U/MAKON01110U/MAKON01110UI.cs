using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 消費税率設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 消費税率設定フォームクラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2020/02/24</br>
    /// <br></br>
    /// </remarks>
    public partial class MAKON01110UI : Form
    {
        private double _taxRate = 0;
        private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
        string pgId = "MAKON01110UI";
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        public MAKON01110UI(double taxRate)
        {
            InitializeComponent();
            this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            double temp = taxRate * 100;
            int temInt = (int)temp;
            this.TaxRate_tNedit.Text = temInt.ToString();
        }
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Property
        /// <summary>
        /// 税率プロパティ
        /// </summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 確定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 確定ボタンクリック時に発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            if (TaxRate_tNedit.GetValue() == 0)
            {
                string message = "消費税率を入力してください。";
                // エラーメッセージがあれば表示
                TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            pgId,
                            message,
                            0,
                            MessageBoxButtons.OK);
                TaxRate_tNedit.Focus();
            }
            else
            {
                this._stockSlipInputInitDataAcs.TaxRateValue = TaxRate_tNedit.GetValue()/100;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンクリック時に発生します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2020/02/24</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (!e.ShiftKey && e.Key == Keys.Enter)
            {
                switch (e.PrevCtrl.Name)
                {
                    // 画面税率と確定ボタンにカーソルがある場合
                    case "TaxRate_tNedit":
                    case "uButton_Save":
                        {
                            uButton_Save.PerformClick();
                            e.NextCtrl = TaxRate_tNedit;
                            break;
                        }
                    // 閉じるボタンにカーソルがある場合
                    case "uButton_Close":
                        {
                            uButton_Close.PerformClick();

                            break;
                        }
                }
            }
        }
        #endregion
    }
}
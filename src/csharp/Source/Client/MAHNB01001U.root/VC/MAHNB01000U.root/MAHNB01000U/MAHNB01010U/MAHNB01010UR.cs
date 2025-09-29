using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 消費税率設定コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 税率の入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2020/02/24</br>
    /// </remarks>
    public partial class MAHNB01010UR : Form
    {
        DialogResult _result = DialogResult.Cancel;

        public MAHNB01010UR(double taxRate)
        {
            InitializeComponent();
            _taxRate = taxRate;
            this.TaxRate_tNedit.SetValue(taxRate * 100);
        }
        private double _taxRate;

        /// <summary>税率</summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// <summary>
        /// 確定ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 確定ボタンクリックイベントです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            if (this.TaxRate_tNedit.GetValue() == 0.0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "消費税率を入力してください。",
                    -1,
                    MessageBoxButtons.OK);

                this.TaxRate_tNedit.Focus();
            }
            else
            {
                _taxRate = this.TaxRate_tNedit.GetValue() / 100;
                DialogResult = DialogResult.OK;
                _result = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンクリックイベントです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// フォームクローズ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : フォームクローズ後発生イベントです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void MAKON01110UR_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = this._result;
        }

        /// <summary>
        /// 明細グリッドリーヴイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 明細グリッドリーヴイベントです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void TaxRate_tNedit_Leave(object sender, EventArgs e)
        {
            Double value = TaxRate_tNedit.GetValue();
            TaxRate_tNedit.Text = value.ToString("#0");	
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note       : 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
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
    }
}
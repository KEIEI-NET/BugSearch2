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
    /// 更新履歴表示メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 更新履歴表示UIクラスを表示します。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/09/29</br>
    /// </remarks>
    public partial class PMKAU04100UA : Form
    {
        private PMKAU04101UA _customerCarSearchForm;

        /// <summary>
        /// 更新履歴表示メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 更新履歴表示メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/09/29</br>
        /// </remarks>
        public PMKAU04100UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 更新履歴表示メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/09/29</br>
        /// </remarks>
        private void CustomerCarSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/09/29</br>
        /// </remarks>
        private void PMKAU04100UA_Load(object sender, EventArgs e)
        {
            this._customerCarSearchForm = new PMKAU04101UA();
            this._customerCarSearchForm.TopLevel = false;
            this._customerCarSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._customerCarSearchForm.Show();
            this.Controls.Add(this._customerCarSearchForm);
            this._customerCarSearchForm.Dock = DockStyle.Fill;

            this._customerCarSearchForm.FormClosed += new FormClosedEventHandler(CustomerCarSearchForm_FormClosed);
        }
    }
}
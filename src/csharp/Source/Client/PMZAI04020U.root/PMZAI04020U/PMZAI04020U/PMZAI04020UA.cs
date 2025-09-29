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
    /// 在庫組立・分解処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 在庫組立・分解処理UIクラスを表示します。</br>
    /// <br>Programmer	: 980035 金沢　貞義</br>
    /// <br>Date		: 2008/11/05</br>
    /// </remarks>
    public partial class PMZAI04020UA : Form
    {
        private PMZAI04021UA _customerCarSearchForm;

        /// <summary>
        /// 在庫組立・分解処理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 在庫組立・分解処理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 980035 金沢　貞義</br>
        /// <br>Date		: 2008/11/05</br>
        /// </remarks>
        public PMZAI04020UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 在庫組立・分解処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 980035 金沢　貞義</br>
        /// <br>Date		: 2008/11/05</br>
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
        /// <br>Programmer	: 980035 金沢　貞義</br>
        /// <br>Date		: 2008/11/05</br>
        /// </remarks>
        private void PMZAI04020UA_Load(object sender, EventArgs e)
        {
            this._customerCarSearchForm = new PMZAI04021UA();
            this._customerCarSearchForm.TopLevel = false;
            this._customerCarSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._customerCarSearchForm.Show();
            this.Controls.Add(this._customerCarSearchForm);
            this._customerCarSearchForm.Dock = DockStyle.Fill;

            this._customerCarSearchForm.FormClosed += new FormClosedEventHandler(CustomerCarSearchForm_FormClosed);
        }
    }
}
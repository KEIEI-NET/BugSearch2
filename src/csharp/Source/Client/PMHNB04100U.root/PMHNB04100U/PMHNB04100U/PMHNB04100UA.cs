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
    /// 出荷部品表示メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 出荷部品表示UIクラスを表示します。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/11/10</br>
    /// </remarks>
    public partial class PMHNB04100UA : Form
    {
        PMHNB04101UA _pmhnb04101UA;

        /// <summary>
        /// 出荷部品表示メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 出荷部品表示メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        public PMHNB04100UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMHNB04100UA_Load(object sender, EventArgs e)
        {
            this._pmhnb04101UA = new PMHNB04101UA();
            this._pmhnb04101UA.TopLevel = false;
            this._pmhnb04101UA.FormBorderStyle = FormBorderStyle.None;
            this._pmhnb04101UA.Show();
            this.Controls.Add(this._pmhnb04101UA);
            this._pmhnb04101UA.Dock = DockStyle.Fill;

            this._pmhnb04101UA.FormClosed += new FormClosedEventHandler(PMHNB04101UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 出荷部品表示メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMHNB04101UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
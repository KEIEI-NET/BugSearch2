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
    /// 在庫実績照会メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 在庫実績照会UIクラスを表示します。</br>
    /// <br>Programmer	: 30350 櫻井 亮太</br>
    /// <br>Date		: 2008/11/25</br>
    /// </remarks>
    public partial class PMZAI04100UA : Form
    {
        PMZAI04101UA _pmzai04101UA;

        /// <summary>
        /// 在庫実績照会メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 在庫実績照会メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/11/25</br>
        /// </remarks>
        public PMZAI04100UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/11/25</br>
        /// </remarks>
        private void PMZAI04100UA_Load(object sender, EventArgs e)
        {
            this._pmzai04101UA = new PMZAI04101UA();
            this._pmzai04101UA.TopLevel = false;
            this._pmzai04101UA.FormBorderStyle = FormBorderStyle.None;
            this._pmzai04101UA.Show();
            this.Controls.Add(this._pmzai04101UA);
            this._pmzai04101UA.Dock = DockStyle.Fill;

            this._pmzai04101UA.FormClosed += new FormClosedEventHandler(PMZAI04101UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 在庫実績照会メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/11/25</br>
        /// </remarks>
        private void PMZAI04101UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
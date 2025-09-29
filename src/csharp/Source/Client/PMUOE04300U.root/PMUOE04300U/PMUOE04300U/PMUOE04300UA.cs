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
    /// DSPログデータ照会メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: DSPデータログ照会UIクラスを表示します。</br>
    /// <br>Programmer	: 30350 櫻井 亮太</br>
    /// <br>Date		: 2008/12/02</br>
    /// </remarks>
    public partial class PMUOE04300UA : Form
    {
        PMUOE04301UA _pmuoe04301UA;

        /// <summary>
        /// DSPログデータ照会メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: DSPデータログ照会メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        public PMUOE04300UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太/br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        private void PMUOE04300UA_Load(object sender, EventArgs e)
        {
            this._pmuoe04301UA = new PMUOE04301UA();
            this._pmuoe04301UA.TopLevel = false;
            this._pmuoe04301UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe04301UA.Show();
            this.Controls.Add(this._pmuoe04301UA);
            this._pmuoe04301UA.Dock = DockStyle.Fill;

            this._pmuoe04301UA.FormClosed += new FormClosedEventHandler(PMUOE04300UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: DSPログデータ照会メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        private void PMUOE04300UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
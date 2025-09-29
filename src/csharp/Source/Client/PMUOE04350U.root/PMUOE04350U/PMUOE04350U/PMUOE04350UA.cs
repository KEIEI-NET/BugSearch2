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
    /// 通信ログデータ照会メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 通信ログデータ照会UIクラスを表示します。</br>
    /// <br>Programmer	: 30350 櫻井 亮太</br>
    /// <br>Date		: 2008/12/02</br>
    /// </remarks>
    public partial class PMUOE04350UA : Form
    {
        PMUOE04351UA _pmuoe04351UA;

        /// <summary>
        /// 通信ログデータ照会メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 通信ログデータ照会メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        public PMUOE04350UA()
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
        private void PMUOE04350UA_Load(object sender, EventArgs e)
        {
            this._pmuoe04351UA = new PMUOE04351UA();
            this._pmuoe04351UA.TopLevel = false;
            this._pmuoe04351UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe04351UA.Show();
            this.Controls.Add(this._pmuoe04351UA);
            this._pmuoe04351UA.Dock = DockStyle.Fill;

            this._pmuoe04351UA.FormClosed += new FormClosedEventHandler(PMUOE04350UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 通信ログデータ照会メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/12/02</br>
        /// </remarks>
        private void PMUOE04350UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
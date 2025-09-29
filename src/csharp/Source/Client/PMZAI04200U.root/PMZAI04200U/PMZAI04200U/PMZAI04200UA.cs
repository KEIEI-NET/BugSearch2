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
    /// 棚卸表示メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 棚卸表示UIクラスを表示します。</br>
    /// <br>Programmer	: 30350 櫻井 亮太</br>
    /// <br>Date		: 2008/11/17</br>
    /// <br>Update Note : 2014/03/05 田建委</br>
    /// <br>            : Redmine#42247 印刷機能を追加する為、ActiveReportsのライセンス情報を付加。(licenses.licx)</br>
    /// </remarks>
    public partial class PMZAI04200UA : Form
    {
        PMZAI04201UA _pmzai04201UA;

        /// <summary>
        /// 棚卸表示メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 棚卸表示メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/11/17</br>
        /// </remarks>
        public PMZAI04200UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太/br>
        /// <br>Date		: 2008/11/17</br>
        /// </remarks>
        private void PMZAI04200UA_Load(object sender, EventArgs e)
        {
            this._pmzai04201UA = new PMZAI04201UA();
            this._pmzai04201UA.TopLevel = false;
            this._pmzai04201UA.FormBorderStyle = FormBorderStyle.None;
            this._pmzai04201UA.Show();
            this.Controls.Add(this._pmzai04201UA);
            this._pmzai04201UA.Dock = DockStyle.Fill;

            this._pmzai04201UA.FormClosed += new FormClosedEventHandler(PMZAI04200UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 棚卸表示メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30350 櫻井 亮太</br>
        /// <br>Date		: 2008/11/17</br>
        /// </remarks>
        private void PMZAI04200UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
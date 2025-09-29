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
    /// 掛率マスタ一括修正・登録メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 掛率マスタ一括修正・登録UIクラスを表示します。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2009/01/19</br>
    /// </remarks>
    public partial class PMKHN09400UA : Form
    {
        PMKHN09401UA _pmkhn09401UA;

        /// <summary>
        /// 掛率マスタ一括修正・登録メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率マスタ一括修正・登録メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2009/01/19</br>
        /// </remarks>
        public PMKHN09400UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2009/01/19</br>
        /// </remarks>
        private void PMKHN09400UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09401UA = new PMKHN09401UA();
            this._pmkhn09401UA.TopLevel = false;
            this._pmkhn09401UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09401UA.Show();
            this.Controls.Add(this._pmkhn09401UA);
            this._pmkhn09401UA.Dock = DockStyle.Fill;

            this._pmkhn09401UA.FormClosed += new FormClosedEventHandler(PMKHN09401UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率マスタ一括修正・登録メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2009/01/19</br>
        /// </remarks>
        private void PMKHN09401UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられる時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void PMKHN09400UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09401UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09401UA.SaveStateXmlData();
        }
    }
}
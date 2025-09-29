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
    /// 得意先一括修正メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 出荷部品表示UIクラスを表示します。</br>
    /// <br>Programmer	: 30414 忍　幸史</br>
    /// <br>Date		: 2008/11/20</br>
    /// </remarks>
    public partial class PMKHN09350UA : Form
    {
        PMKHN09351UA _pmkhn09351UA;

        /// <summary>
        /// 得意先一括修正メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先一括修正メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        public PMKHN09350UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        private void PMKHN09350UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09351UA = new PMKHN09351UA();
            this._pmkhn09351UA.TopLevel = false;
            this._pmkhn09351UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09351UA.Show();
            this.Controls.Add(this._pmkhn09351UA);
            this._pmkhn09351UA.Dock = DockStyle.Fill;

            this._pmkhn09351UA.FormClosed += new FormClosedEventHandler(PMHNB04101UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先一括修正メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30414 忍　幸史</br>
        /// <br>Date		: 2008/11/20</br>
        /// </remarks>
        private void PMHNB04101UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void PMKHN09350UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09351UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09351UA.SaveStateXmlData();
        }
    }
}
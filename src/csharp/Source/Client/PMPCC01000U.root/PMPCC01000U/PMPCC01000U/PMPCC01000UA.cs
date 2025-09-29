//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先メッセージ設定処理
// プログラム概要   : 得意先メッセージ設定処理に対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/08/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
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
    /// 得意先メッセージ設定処理
    /// </summary>
    /// <remarks>
    /// Note       : 得意先メッセージ設定処理です。<br />
    /// Programmer : 黄海霞<br />
    /// Date       : 2011.08.08<br />
    /// </remarks>
    public partial class PMPCC01000UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// 得意先メッセージフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08 </br>
        /// </remarks>
        public PMPCC01000UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMPCC01001UA _updateCountForm;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PMPCC01000UA_Load(object sender, EventArgs e)
        {
            this._updateCountForm = new PMPCC01001UA();
            this._updateCountForm.TopLevel = false;
            this._updateCountForm.FormBorderStyle = FormBorderStyle.None;
            this._updateCountForm.Show();
            this._updateCountForm.Dock = DockStyle.Fill;
            this.Text = this._updateCountForm.Text;
            this.Controls.Add(this._updateCountForm);
            this._updateCountForm.FormClosed += new FormClosedEventHandler(this.PMPCC01000UA_FormClosed);
        }
        # endregion ■ フォームロード ■

        #region ■ Private Method ■
        /// <summary>
        /// 画面閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void PMPCC01000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■
    }
}
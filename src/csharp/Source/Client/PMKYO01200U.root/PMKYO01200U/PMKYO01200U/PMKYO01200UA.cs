//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/20  修正内容 : 新規作成
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

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// マスタ送受信処理
    /// </summary>
    /// <remarks>
    /// Note       : マスタ送受信処理処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.20<br />
    /// </remarks>
    public partial class PMKYO01200UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01200UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMKYO01201UA _updateCountForm;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void PMKYO01200UA_Load(object sender, EventArgs e)
        {
            this._updateCountForm = new PMKYO01201UA();
            this._updateCountForm.TopLevel = false;
            this._updateCountForm.FormBorderStyle = FormBorderStyle.None;
            this._updateCountForm.Show();
            this._updateCountForm.Dock = DockStyle.Fill;
            this.Text = this._updateCountForm.Text;
            this.Controls.Add(this._updateCountForm);
            this._updateCountForm.FormClosed += new FormClosedEventHandler(this.UpdateCountForm_FormClosed);
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
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void UpdateCountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■
    }
}
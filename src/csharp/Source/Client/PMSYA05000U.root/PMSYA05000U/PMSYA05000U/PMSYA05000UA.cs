//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日更新
// プログラム概要   : 車検期日更新フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 車検期日更新処理
    /// </summary>
    /// <remarks>
    /// Note       : 車検期日更新処理です。<br />
    /// Programmer : 王海立<br />
    /// Date       : 2010/04/21<br />
    /// </remarks>
    public partial class PMSYA05000UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMSYA05000UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMSYA05001UA _updateCountForm;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private void PMSYA05000UA_Load(object sender, EventArgs e)
        {
            this._updateCountForm = new PMSYA05001UA();
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
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private void UpdateCountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■
    }
}
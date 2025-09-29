//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 目標自動設定
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 目標自動設定
    /// </summary>
    /// <remarks>
    /// Note       : 目標自動設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.20<br />
    /// </remarks>
    public partial class PMKHN09450UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN09450UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMKHN09451UA _objAutoSetForm;

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
        /// <br>Date       : 2009.05.01</br>
        /// </remarks>
        private void PMKHN09450UA_Load(object sender, EventArgs e)
        {
            this._objAutoSetForm = new PMKHN09451UA();
            this._objAutoSetForm.TopLevel = false;
            this._objAutoSetForm.FormBorderStyle = FormBorderStyle.None;
            this._objAutoSetForm.Show();
            this._objAutoSetForm.Dock = DockStyle.Fill;
            this.Text = this._objAutoSetForm.Text;
            this.Controls.Add(this._objAutoSetForm);
            this._objAutoSetForm.FormClosed += new FormClosedEventHandler(this.ObjAutoSetForm_FormClosed);
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
        /// <br>Date       : 2009.05.01</br>
        /// </remarks>
        private void ObjAutoSetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■
    }
}
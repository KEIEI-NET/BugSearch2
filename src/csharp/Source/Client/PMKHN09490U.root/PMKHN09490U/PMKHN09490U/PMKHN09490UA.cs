//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ
// プログラム概要   : 在庫マスタに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/08/11  修正内容 : 新規作成
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫マスタ
    /// </summary>
    /// <remarks>
    /// Note       : 在庫マスタ設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2010/08/11<br />
    /// </remarks>
    public partial class PMKHN09490UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタのフォームクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public PMKHN09490UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMKHN09491UA _pmKHN09491UA;

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
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void PMKHN09490UA_Load(object sender, EventArgs e)
        {
            this._pmKHN09491UA = new PMKHN09491UA();
            this._pmKHN09491UA.TopLevel = false;
            this._pmKHN09491UA.FormBorderStyle = FormBorderStyle.None;
            this._pmKHN09491UA.Show();
            this._pmKHN09491UA.Dock = DockStyle.Fill;
            this.Text = this._pmKHN09491UA.Text;
            this.Controls.Add(this._pmKHN09491UA);
            this._pmKHN09491UA.FormClosed += new FormClosedEventHandler(this.PMKHN09490UA_FormClosed);
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
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        private void PMKHN09490UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■
    }
}
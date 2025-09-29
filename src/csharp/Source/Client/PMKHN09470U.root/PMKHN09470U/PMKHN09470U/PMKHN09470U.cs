//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタ（掛率優先管理パターン） 
// プログラム概要   : 掛率設定マスタ（掛率優先管理パターン）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/08/10  修正内容 : 新規作成
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
    /// 掛率設定マスタ（掛率優先管理パターン）
    /// </summary>
    /// <remarks>
    /// Note       : 掛率設定マスタ（掛率優先管理パターン）設定処理です。<br />
    /// Programmer : 呉元嘯<br />
    /// Date       : 2010/08/10<br />
    /// </remarks>
    public partial class PMKHN09470U : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKHN09470U()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMKHN09471UA _pMKHN09471UA;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09470UA_Load(object sender, EventArgs e)
        {
            this._pMKHN09471UA = new PMKHN09471UA();
            this._pMKHN09471UA.TopLevel = false;
            this._pMKHN09471UA.FormBorderStyle = FormBorderStyle.None;
            this._pMKHN09471UA.Show();
            this._pMKHN09471UA.Dock = DockStyle.Fill;
            this.Text = this._pMKHN09471UA.Text;
            this.Controls.Add(this._pMKHN09471UA);
            this._pMKHN09471UA.FormClosed += new FormClosedEventHandler(this.PMKHN09470UA_FormClosed);
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
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09470UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion ■ Private Method ■

    }
}
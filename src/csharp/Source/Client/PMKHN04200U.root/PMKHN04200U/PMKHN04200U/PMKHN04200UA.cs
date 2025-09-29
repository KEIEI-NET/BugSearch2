//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会
// プログラム概要   : SCM問合せログテーブルに対して検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
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
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKHN04200UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 他社部品検索履歴照会のフォームクラスです。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public PMKHN04200UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMKHN04201UA _pmKHN04201UA;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private void PMKHN04200UA_Load(object sender, EventArgs e)
        {
            this._pmKHN04201UA = new PMKHN04201UA();
            this._pmKHN04201UA.TopLevel = false;
            this._pmKHN04201UA.FormBorderStyle = FormBorderStyle.None;
            this._pmKHN04201UA.Show();
            this._pmKHN04201UA.Dock = DockStyle.Fill;
            this.Text = this._pmKHN04201UA.Text;
            this.Controls.Add(this._pmKHN04201UA);
            this._pmKHN04201UA.FormClosed += new FormClosedEventHandler(this.PMKHN04200UA_FormClosed);
            this._pmKHN04201UA.SetInitFocus(); // ADD 2010/11/19
        }
        # endregion ■ フォームロード ■

        #region ■ Private Method ■
        /// <summary>
        /// 画面閉閉じた処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private void PMKHN04200UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private void PMKHN04200UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._pmKHN04201UA.CallBeforeClosing();
        }
        #endregion ■ Private Method ■
    }
}
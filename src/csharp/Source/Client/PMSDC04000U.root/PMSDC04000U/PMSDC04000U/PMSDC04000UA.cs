//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 売上データ送信ログテーブルに対して検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2019/12/02  修正内容 : 新規作成
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
    public partial class PMSDC04000UA : Form
    {
        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信ログ表示のフォームクラスです。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public PMSDC04000UA()
        {
            InitializeComponent();
        }
        # endregion ■ コンストラクタ ■

        # region ■ private field ■

        private PMSDC04001UA _PMSDC04001UA;

        # endregion ■ private field ■

        # region ■ フォームロード ■
        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void PMSDC04000UA_Load(object sender, EventArgs e)
        {
            this._PMSDC04001UA = new PMSDC04001UA();
            this._PMSDC04001UA.TopLevel = false;
            this._PMSDC04001UA.FormBorderStyle = FormBorderStyle.None;
            this._PMSDC04001UA.Show();
            this._PMSDC04001UA.Dock = DockStyle.Fill;
            this.Text = this._PMSDC04001UA.Text;
            this.Controls.Add(this._PMSDC04001UA);
            this._PMSDC04001UA.FormClosed += new FormClosedEventHandler(this.PMSDC04000UA_FormClosed);
            this._PMSDC04001UA.SetInitFocus();
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void PMSDC04000UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private void PMSDC04000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._PMSDC04001UA.CallBeforeClosing();
        }
        #endregion ■ Private Method ■
    }
}
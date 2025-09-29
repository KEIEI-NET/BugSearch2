//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品照会
// プログラム概要   : テキスト出力の確認ダイアログ
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11470154-00 作成担当 : 陳艶丹
// 作 成 日  2018/10/16  修正内容 : 新規作成
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
    public partial class BeforeTextOutputDialog : Form
    {
        #region
        /// <summary>
        /// テキスト出力の確認ダイアログフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力の確認ダイアログフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        public BeforeTextOutputDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Event
        /// <summary>
        /// 初回表示時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 初回表示時イベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void BeforeTextOutputDialog_Shown(object sender, EventArgs e)
        {
            this.ubCancel.Focus();
        }

        #region ubOk_Click Event
        /// <summary>
        /// ubOk_Click Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 「はい」ボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void ubOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        #endregion

        #region ubCancel_Click Event
        /// <summary>
        /// ubCancel_Click Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 「いいえ」ボタンクリックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void ubCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        #endregion

        #endregion
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力の確認ダイアログ
// プログラム概要   : テキスト出力の確認ダイアログ表示処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570163-00  作成担当 : 田建委
// 作 成 日  K2019/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570217-00  作成担当 : 寺田義啓
// 作 成 日  2019/11/15   修正内容 : （修正内容一覧No.1）テキスト出力メッセージ改良
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
    /// 出力時アラートメッセージ表示処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : 出力時アラートメッセージ表示処理です。<br/>
    /// Programmer : 田建委<br/>
    /// Date       : K2019/08/12<br/>
    /// </remarks>
    public partial class BeforeTextOutputDialog : Form
    {
        #region
        /// <summary>
        /// テキスト出力の確認ダイアログフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力の確認ダイアログフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : K2019/08/12</br>
        /// </remarks>
        private void ubCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        #endregion

        #endregion
    }
}
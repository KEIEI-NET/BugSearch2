//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ユーザー価格・原価一括設定
// プログラム概要   : ユーザー価格・原価を複数件一括で修正・登録する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/08  修正内容 : 新規作成
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
    /// ユーザー価格・原価一括設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザー価格・原価一括設定のフォームクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.05.05</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.05.05 men 新規作成(DC.NSから流用)</br>
    /// </remarks>
    public partial class PMKHN09420UA : Form
    {
        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public PMKHN09420UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ユーザー価格・原価一括設定画面
        /// </summary>
        PMKHN09421UA _dataPrice;

        /// <summary>
        /// 画面を閉める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private void DataPrice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private void PMKHN09420UA_Load(object sender, EventArgs e)
        {
            this._dataPrice = new PMKHN09421UA();
            this._dataPrice.TopLevel = false;
            this._dataPrice.FormBorderStyle = FormBorderStyle.None;
            this._dataPrice.Show();
            this._dataPrice.Dock = DockStyle.Fill;
            this.Text = this._dataPrice.Text;
            this._dataPrice.FormClosed += new FormClosedEventHandler(this.DataPrice_FormClosed);
            this.Controls.Add(this._dataPrice);
        }
    }
}
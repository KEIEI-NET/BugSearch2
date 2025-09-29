//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動起動サービス処理
// プログラム概要   : 自動起動サービスのファイルを更新する
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/21  修正内容 : 新規作成
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
    /// 自動起動サービス処理
    /// </summary>
    public partial class PMKYO09300UA : Form
    {
        /// <summary>
        /// 画面初期化
        /// </summary>
        public PMKYO09300UA()
        {
            InitializeComponent();
        }

        PMKYO09301UA _serviceFiles;

        /// <summary>
        /// 画面を閉める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceFiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKYO02000UA_Load(object sender, EventArgs e)
        {
            this._serviceFiles = new PMKYO09301UA();
            this._serviceFiles.TopLevel = false;
            this._serviceFiles.FormBorderStyle = FormBorderStyle.None;
            this._serviceFiles.Show();
            this._serviceFiles.Dock = DockStyle.Fill;
            this.Text = this._serviceFiles.Text;
            this.Controls.Add(this._serviceFiles);
            this._serviceFiles.FormClosed += new FormClosedEventHandler(this.ServiceFiles_FormClosed);
        }
    }
}
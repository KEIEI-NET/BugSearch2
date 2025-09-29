//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 簡単問合せ接続情報 フレームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/25  修正内容 : 新規作成
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
    /// フレームクラス
    /// </summary>
    public partial class PMSCM00200UA : Form
    {
        /// <summary>
        /// 画面初期化
        /// </summary>
        public PMSCM00200UA()
        {
            InitializeComponent();
        }

        PMSCM00201UA _form;

        /// <summary>
        /// 画面を閉める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKYO02000UA_Load(object sender, EventArgs e)
        {
            this._form = new PMSCM00201UA();
            this._form.TopLevel = false;
            this._form.FormBorderStyle = FormBorderStyle.None;
            this._form.Show();
            this._form.Dock = DockStyle.Fill;
            this.Text = this._form.Text;
            this.Controls.Add(this._form);
            this._form.FormClosed += new FormClosedEventHandler(this.MDI_FormClosed);
        }
    }
}
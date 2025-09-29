//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
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
    public partial class PMKYO01100UA : Form
    {
        /// <summary>
        /// 画面初期化
        /// </summary>
        public PMKYO01100UA()
        {
            InitializeComponent();
        }

        PMKYO01101UA _dataReceive;

        /// <summary>
        /// 画面を閉める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKYO01100UA_Load(object sender, EventArgs e)
        {
            this._dataReceive = new PMKYO01101UA();
            this._dataReceive.TopLevel = false;
            this._dataReceive.FormBorderStyle = FormBorderStyle.None;
            this._dataReceive.Show();
            this._dataReceive.Dock = DockStyle.Fill;
            this.Text = this._dataReceive.Text;
            this._dataReceive.FormClosed += new FormClosedEventHandler(this.DataReceive_FormClosed);
            this.Controls.Add(this._dataReceive);
        }
    }
}
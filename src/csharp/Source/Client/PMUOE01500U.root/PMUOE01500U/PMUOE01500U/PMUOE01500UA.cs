//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注処理
// プログラム概要   : 発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/06/01  修正内容 : 新規作成
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
    /// 発注処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 発注処理UIクラスを表示します。</br>
    /// <br>Programmer	: 張凱</br>
    /// <br>Date		: 2009/06/01</br>
    /// </remarks>
    public partial class PMUOE01500UA : Form
    {
        PMUOE01501UA _pmuoe01501UA;

        /// <summary>
        ///発注処理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 発注処理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/06/01</br>
        /// </remarks>
        public PMUOE01500UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 発注処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/06/01</br>
        /// </remarks>
        private void PMUOE01500UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/06/01</br>
        /// </remarks>
        private void PMUOE01500U_Load(object sender, EventArgs e)
        {
            this._pmuoe01501UA = new PMUOE01501UA();
            this._pmuoe01501UA.TopLevel = false;
            this._pmuoe01501UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01501UA.Show();
            this._pmuoe01501UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01501UA);


            this._pmuoe01501UA.FormClosed += new FormClosedEventHandler(PMUOE01500UA_FormClosed);
        }
    }
}
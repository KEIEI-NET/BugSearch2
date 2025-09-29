//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : トヨタ発注処理
// プログラム概要   : トヨタ発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 譚洪
// 作 成 日  2009/12/31  修正内容 : 新規作成
//                                  トヨタ電子カタログとの連携用データとして、UOE発注データから発注送信データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/08/26  修正内容 : Redmine#13666対応
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
    /// トヨタ発注処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: トヨタ発注処理UIクラスを表示します。</br>
    /// <br>Programmer	: 譚洪</br>
    /// <br>Date		: 2009/12/31</br>
    /// <br>Update Note : 2010/08/26 呉元嘯</br>
    /// <br>              Redmine#13666対応</br>
    /// </remarks>
    public partial class PMUOE01510UA : Form
    {
        PMUOE01511UA _pmuoe01511UA;

        /// <summary>
        ///トヨタ発注処理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: トヨタ発注処理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/31</br>
        /// </remarks>
        public PMUOE01510UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: トヨタ発注処理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/31</br>
        /// </remarks>
        private void PMUOE01510UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009/12/31</br>
        /// </remarks>
        private void PMUOE01510U_Load(object sender, EventArgs e)
        {
            this._pmuoe01511UA = new PMUOE01511UA();
            this._pmuoe01511UA.TopLevel = false;
            this._pmuoe01511UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01511UA.Show();
            this._pmuoe01511UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01511UA);


            this._pmuoe01511UA.FormClosed += new FormClosedEventHandler(PMUOE01510UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: トヨタ発注処理画面を終了します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2010/08/26</br>
        /// </remarks>
        private void PMUOE01510UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._pmuoe01511UA.closeCheck)
            {
                e.Cancel = true;
            }
        }
    }
}
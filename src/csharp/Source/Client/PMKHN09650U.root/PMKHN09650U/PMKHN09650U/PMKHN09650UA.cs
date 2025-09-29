//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン目標設定マスタ
// プログラム概要   : キャンペーン目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// キャンペーン目標設定マスタ UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタUIフォームクラス</br>
    /// <br>Programmer : 徐佳</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    public partial class PMKHN09650UA : Form
    {
        /// <summary>
        ///キャンペーン目標設定マスタメインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン目標設定マスタメインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public PMKHN09650UA()
        {
            InitializeComponent();
        }

        private PMKHN09651UA _pmkhn09651UA;

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面がLoadされた時に発生します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void PMKHN09650UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09651UA = new PMKHN09651UA();
            this._pmkhn09651UA.TopLevel = false;
            this._pmkhn09651UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09651UA.Show();
            this._pmkhn09651UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmkhn09651UA);

            this._pmkhn09651UA.FormClosed += new FormClosedEventHandler(this.PMKHN09651UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン目標設定マスタメインフレーム画面を終了します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void PMKHN09651UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKHN09650UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
    }
}
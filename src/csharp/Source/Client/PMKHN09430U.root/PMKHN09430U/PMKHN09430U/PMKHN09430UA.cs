//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価一括修正
// プログラム概要   : 売価一括修正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/14  修正内容 : 新規作成
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
    /// 売価一括修正メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売価一括修正UIクラスを表示します。</br>
    /// <br>Programmer	: 張凱</br>
    /// <br>Date		: 2009/04/01</br>
    /// </remarks>
    public partial class PMKHN09430UA : Form
    {
        PMKHN09431UA _pmkhn09431UA;

        /// <summary>
        ///売価一括修正メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 売価一括修正メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        public PMKHN09430UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられる時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void PMKHN09430UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // XML保存
            this._pmkhn09431UA.SaveStateXmlData();
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 売価一括修正メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        private void PMKHN09431UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/04/01</br>
        /// </remarks>
        private void PMKHN09430UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09431UA = new PMKHN09431UA();
            this._pmkhn09431UA.TopLevel = false;
            this._pmkhn09431UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09431UA.Show();
            this.Controls.Add(this._pmkhn09431UA);
            this._pmkhn09431UA.Dock = DockStyle.Fill;

            this._pmkhn09431UA.FormClosed += new FormClosedEventHandler(PMKHN09431UA_FormClosed);
        }
    }
}
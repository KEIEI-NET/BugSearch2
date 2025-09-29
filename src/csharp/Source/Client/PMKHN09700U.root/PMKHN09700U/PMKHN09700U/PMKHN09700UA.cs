//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自動回答品目設定マスタメンテナンス
// プログラム概要   : 自動回答品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2012/10/25  修正内容 : 新規作成
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
    /// 自動回答品目設定メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UIクラスを表示します。</br>
    /// </remarks>
    public partial class PMKHN09700UA : Form
    {
        PMKHN09701UA _pmkhn09701UA;

        /// <summary>
        /// 掛率マスタ一括修正・登録メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: メインフレームクラスのインスタンスを生成します。</br>
        /// </remarks>
        public PMKHN09700UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// </remarks>
        private void PMKHN09700UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09701UA = new PMKHN09701UA();
            this._pmkhn09701UA.TopLevel = false;
            this._pmkhn09701UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09701UA.Show();
            this.Controls.Add(this._pmkhn09701UA);
            this._pmkhn09701UA.Dock = DockStyle.Fill;

            this._pmkhn09701UA.FormClosed += new FormClosedEventHandler(PMKHN09701UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// </remarks>
        private void PMKHN09701UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられる時に発生します。</br>
        /// </remarks>
        private void PMKHN09700UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09701UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09701UA.SaveStateXmlData();
        }
    }
}
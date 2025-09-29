//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/08/04  修正内容 : 新規作成
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
    /// 単品売価設定一括登録・修正メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 単品売価設定一括登録・修正UIクラスを表示します。</br>
    /// <br>Programmer	: 李占川</br>
    /// <br>Date		: 2010/08/04</br>
    /// </remarks>
    public partial class PMKHN09460UA : Form
    {
        PMKHN09461UA _pmkhn09461UA;

        /// <summary>
        /// 単品売価設定一括登録・修正メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 単品売価設定一括登録・修正メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        public PMKHN09460UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        private void PMKHN09460UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09461UA = new PMKHN09461UA();
            this._pmkhn09461UA.TopLevel = false;
            this._pmkhn09461UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09461UA.Show();
            this.Controls.Add(this._pmkhn09461UA);
            this._pmkhn09461UA.Dock = DockStyle.Fill;

            this._pmkhn09461UA.FormClosed += new FormClosedEventHandler(PMKHN09461UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 単品売価設定一括登録・修正メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        private void PMKHN09461UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void PMKHN09460UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09461UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09461UA.SaveStateXmlData();
        }
    }
}
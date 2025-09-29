//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 重点品目設定マスタ
// プログラム概要   : 重点品目設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/22  修正内容 : 新規作成
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
    /// 重点品目設定メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 重点品目設定UIクラスを表示します。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2009/05/22</br>
    /// </remarks>
    public partial class PMKHN09550UA : Form
    {
        PMKHN09551UA _pmkhn09551UA;

        /// <summary>
        /// 重点品目設定メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 重点品目設定メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/22</br>
        /// </remarks>
        public PMKHN09550UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/22</br>
        /// </remarks>
        private void PMKHN09550UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09551UA = new PMKHN09551UA();
            this._pmkhn09551UA.TopLevel = false;
            this._pmkhn09551UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09551UA.Show();
            this.Controls.Add(this._pmkhn09551UA);
            this._pmkhn09551UA.Dock = DockStyle.Fill;

            this._pmkhn09551UA.FormClosed += new FormClosedEventHandler(PMKHN09550UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 重点品目設定メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/22</br>
        /// </remarks>
        private void PMKHN09550UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/22</br>
        /// </remarks>
        private void PMKHN09550UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09551UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09551UA.SaveStateXmlData();
        }
    }
}
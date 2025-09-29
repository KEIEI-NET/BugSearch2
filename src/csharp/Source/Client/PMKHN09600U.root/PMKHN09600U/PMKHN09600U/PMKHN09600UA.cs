//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン管理マスタ
// プログラム概要   : キャンペーン管理の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/28  修正内容 : 新規作成
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
    /// キャンペーン管理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: キャンペーン管理UIクラスを表示します。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2009/05/28</br>
    /// </remarks>
    public partial class PMKHN09600UA : Form
    {
        PMKHN09601UA _pmkhn09601UA;

        /// <summary>
        /// キャンペーン管理メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン管理メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/28</br>
        /// </remarks>
        public PMKHN09600UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/28</br>
        /// </remarks>
        private void PMKHN09600UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09601UA = new PMKHN09601UA();
            this._pmkhn09601UA.TopLevel = false;
            this._pmkhn09601UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09601UA.Show();
            this.Controls.Add(this._pmkhn09601UA);
            this._pmkhn09601UA.Dock = DockStyle.Fill;

            this._pmkhn09601UA.FormClosed += new FormClosedEventHandler(PMKHN09600UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン管理メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009/05/28</br>
        /// </remarks>
        private void PMKHN09600UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void PMKHN09600UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09601UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09601UA.SaveStateXmlData();
        }
    }
}
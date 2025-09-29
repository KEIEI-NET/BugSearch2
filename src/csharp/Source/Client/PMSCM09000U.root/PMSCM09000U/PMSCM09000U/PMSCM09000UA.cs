//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCM品目設定マスタメンテナンス
// プログラム概要   : SCM品目設定マスタの操作を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2009/05/11  修正内容 : 新規作成
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
    /// <summary>
    /// SCM品目設定メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 掛率マスタ一括修正・登録UIクラスを表示します。</br>
    /// <br>Programmer	: 22018 鈴木 正臣</br>
    /// <br>Date		: 2009/05/21</br>
    /// </remarks>
    public partial class PMSCM09000UA : Form
    {
        PMSCM09001UA _pmkhn09401UA;

        /// <summary>
        /// 掛率マスタ一括修正・登録メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率マスタ一括修正・登録メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2009/05/21</br>
        /// </remarks>
        public PMSCM09000UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面がLoadされた時に発生します。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2009/05/21</br>
        /// </remarks>
        private void PMSCM09000UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09401UA = new PMSCM09001UA();
            this._pmkhn09401UA.TopLevel = false;
            this._pmkhn09401UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09401UA.Show();
            this.Controls.Add(this._pmkhn09401UA);
            this._pmkhn09401UA.Dock = DockStyle.Fill;

            this._pmkhn09401UA.FormClosed += new FormClosedEventHandler(PMSCM09001UA_FormClosed);
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率マスタ一括修正・登録メインフレーム画面を終了します。</br>
        /// <br>Programmer	: 22018 鈴木 正臣</br>
        /// <br>Date		: 2009/05/21</br>
        /// </remarks>
        private void PMSCM09001UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer  : 22018 鈴木 正臣</br>
        /// <br>Date        : 2009/05/21</br>
        /// </remarks>
        private void PMSCM09000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面情報比較
            bool bStatus = this._pmkhn09401UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML保存
            this._pmkhn09401UA.SaveStateXmlData();
        }
    }
}
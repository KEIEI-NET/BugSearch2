//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　伝票番号変換処理メインフレームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/04  修正内容 : 新規作成
//****************************************************************************//

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
    /// PM.NS統合ツール　伝票番号変換処理メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 伝票番号変換処理メインフレームクラスです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/05</br>
    /// </remarks>
    public partial class PMKHN05150UA : Form
    {
        #region -- Member --

        /// <summary>拠点コード変換UIクラス</summary>
        private PMKHN05151UA chldFrm;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　伝票番号変更メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、メインフレームクラスの初期処理を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05</br>
        /// </remarks>
        public PMKHN05150UA()
        {
            InitializeComponent();
        }

        #endregion

        #region -- Event --

        /// <summary>
        /// Loadイベント処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面起動時の初期化処理を行います。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/05<</br>
        /// </remarks>
        private void PMKHN05150UA_Load(object sender, EventArgs e)
        {
            // 拠点コード変換UIクラスをロードします。
            this.chldFrm = new PMKHN05151UA();
            this.chldFrm.TopLevel = false;
            this.chldFrm.FormBorderStyle = FormBorderStyle.None;
            this.chldFrm.Show();
            this.Controls.Add(this.chldFrm);
            this.chldFrm.Dock = DockStyle.Fill;

            // イベントの設定
            this.FormClosing += new FormClosingEventHandler(this.chldFrm.PMKHN05151UA_FormClosing);
        }

        #endregion
    }
}
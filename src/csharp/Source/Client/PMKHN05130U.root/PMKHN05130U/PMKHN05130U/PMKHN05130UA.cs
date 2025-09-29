//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換メインフレームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2017/12/15  修正内容 : 新規作成
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
    /// PM.NS統合ツール　拠点コード変換メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換メインフレームクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public partial class PMKHN05130UA : Form
    {
        #region -- Member --

        /// <summary>拠点コード変換UIクラス</summary>
        private PMKHN05131UA chldFrm;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　拠点コード変換メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、拠点コード変換メインフレームクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public PMKHN05130UA()
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
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15<</br>
        /// </remarks>
        private void PMKHN05130UA_Load(object sender, EventArgs e)
        {

            
            // 拠点コード変換UIクラスをロードします。
            this.chldFrm = new PMKHN05131UA();
            this.chldFrm.TopLevel = false;
            this.chldFrm.FormBorderStyle = FormBorderStyle.None;
            this.chldFrm.Show();
            this.Controls.Add(this.chldFrm);
            this.chldFrm.Dock = DockStyle.Fill;

            // イベントの設定
            this.FormClosing += new FormClosingEventHandler(this.chldFrm.PMKHN05131UA_FormClosing);
        }

        #endregion
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換メインフレームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/01  修正内容 : 新規作成
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
    /// PM.NS統合ツール　担当者マスタコード変換メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換メインフレームクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/01</br>
    /// </remarks>
    public partial class PMKHN05110UA : Form
    {

        #region -- Member --

        /// <summary>担当者マスタコード変換UIクラス</summary>
        private PMKHN05111UA chlFrm;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール　担当者マスタコード変換メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、担当者マスタコード変換メインフレームクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/01</br>
        /// </remarks>
        public PMKHN05110UA()
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
        /// <br>Date       : 2016/03/01<</br>
        /// </remarks>
        private void PMKHN05110UA_Load(object sender, EventArgs e)
        {
            // 担当者マスタコード変換UIクラスをロードします。
            this.chlFrm = new PMKHN05111UA();
            this.chlFrm.TopLevel = false;
            this.chlFrm.FormBorderStyle = FormBorderStyle.None;
            this.chlFrm.Show();
            this.Controls.Add(this.chlFrm);
            this.chlFrm.Dock = DockStyle.Fill;

            // イベントの設定
            // FormClosingイベントは子フォームのFormClosingイベントと連動させます。
            this.FormClosing += new FormClosingEventHandler(this.chlFrm.PMKHN05111UA_FormClosing);
        }

        #endregion
    }
}
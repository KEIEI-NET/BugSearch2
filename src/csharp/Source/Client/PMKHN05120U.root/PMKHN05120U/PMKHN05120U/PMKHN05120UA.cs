//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換メインフレームクラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
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
    /// PM.NS統合ツール　得意先マスタコード変換メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換メインフレームクラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public partial class PMKHN05120UA : Form
    {
        #region -- Member --

        /// <summary>得意先マスタコード変換UIクラス</summary>
        private PMKHN05121UA chldFrm = null;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS統合ツール得意先マスタコード変換メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS統合ツール、得意先マスタコード変換メインフレームクラスの初期処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public PMKHN05120UA()
        {
            InitializeComponent();
        }

        #endregion

        #region -- protected --

        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面起動時の初期化処理を行います。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23<</br>
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 得意先マスタコード変換UIクラスをロードします。
            this.chldFrm = new PMKHN05121UA();
            this.chldFrm.TopLevel = false;
            this.chldFrm.FormBorderStyle = FormBorderStyle.None;
            this.chldFrm.Show();
            this.Controls.Add(this.chldFrm);
            this.chldFrm.Dock = DockStyle.Fill;

            // イベントの設定
            // FormColsingイベントを子フォームのFormClosingイベントと連動させる            
            this.FormClosing += new FormClosingEventHandler(this.chldFrm.PMKHN05121UA_FormClosing);
        }

        #endregion
    }
}
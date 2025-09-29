//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括登録
// プログラム概要   : キャンペーン対象商品設定マスタ一括登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
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
    /// キャンペーン対象商品設定マスタ一括登録 UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括登録UIフォームクラス</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// </remarks>
    public partial class PMKHN09630UA : Form
    {
        /// <summary>
        ///キャンペーン対象商品設定マスタ一括登録メインフレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタ一括登録メインフレームクラスのインスタンスを生成します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public PMKHN09630UA()
        {
            InitializeComponent();
        }

        #region Private Members
        private PMKHN09631UA _pmkhn09631UA;

        #endregion


        /// <summary>
        /// Load イベント
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面がLoadされた時に発生します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void PMKHN09630UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09631UA = new PMKHN09631UA();

            this._pmkhn09631UA.TopLevel = false;
            this._pmkhn09631UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09631UA.Show();
            this._pmkhn09631UA.Dock = DockStyle.Fill;

            this.Text = this._pmkhn09631UA.Text;

            this.Controls.Add(this._pmkhn09631UA);
            this._pmkhn09631UA.FormClosed += new FormClosedEventHandler(this.PMKHN09630UA_FormClosed);

        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタ一括登録メインフレーム画面を終了します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void PMKHN09630UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタ一括登録メインフレーム画面を表示します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void PMKHN09630UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
    }
}
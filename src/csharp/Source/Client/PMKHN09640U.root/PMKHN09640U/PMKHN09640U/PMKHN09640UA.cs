//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
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
    /// キャンペーン対象商品設定マスタ一括削除フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括削除を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/04/26</br>
    /// </remarks>
    public partial class PMKHN09640UA : Form
    {

        #region Constroctors
        /// <summary>
        /// キャンペーン対象商品設定マスタ一括削除フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: キャンペーン対象商品設定マスタ一括削除フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2011/04/26</br>
        /// </remarks>
        public PMKHN09640UA()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Members
        private PMKHN09641UA _dispatchInputForm;

        #endregion


        #region Event
        /// <summary>
        /// キャンペーン対象商品設定マスタ一括削除フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09640U_Load(object sender, EventArgs e)
        {
            this._dispatchInputForm = new PMKHN09641UA();

            this._dispatchInputForm.TopLevel = false;
            this._dispatchInputForm.FormBorderStyle = FormBorderStyle.None;
            this._dispatchInputForm.Show();
            this._dispatchInputForm.Dock = DockStyle.Fill;

            this.Text = this._dispatchInputForm.Text;
           
            this.Controls.Add(this._dispatchInputForm);
            this._dispatchInputForm.FormClosed += new FormClosedEventHandler(this.dispatchInpu_FormClosed);
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ一括削除フォーム閉じるイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void dispatchInpu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// 画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : キャンペーン対象商品設定マスタ一括削除メインフレーム画面を表示します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void PMKHN09640UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
    }
}
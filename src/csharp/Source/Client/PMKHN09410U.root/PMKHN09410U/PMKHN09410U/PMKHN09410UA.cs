//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ引用登録
// プログラム概要   : 掛率マスタ引用登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/08  修正内容 : 新規作成
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
    /// 掛率マスタ引用登録フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ引用登録を行います。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2008.03.27</br>
    /// </remarks>
    public partial class PMKHN09410UA : Form
    {

        #region Constroctors
        /// <summary>
        /// 掛率マスタ引用登録フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 掛率マスタ引用登録フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 劉洋</br>
        /// <br>Date		: 2008.03.27</br>
        /// </remarks>
        public PMKHN09410UA()
        {
            InitializeComponent();
        }
        #endregion


        #region Private Members
        private PMKHN09411UA _dispatchInputForm;

        #endregion


        #region Event
        /// <summary>
        /// 掛率マスタ引用登録フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void PMKHN09410U_Load(object sender, EventArgs e)
        {
            this._dispatchInputForm = new PMKHN09411UA();

            this._dispatchInputForm.TopLevel = false;
            this._dispatchInputForm.FormBorderStyle = FormBorderStyle.None;
            this._dispatchInputForm.Show();
            this._dispatchInputForm.Dock = DockStyle.Fill;

            this.Text = this._dispatchInputForm.Text;
           
            this.Controls.Add(this._dispatchInputForm);
            this._dispatchInputForm.FormClosed += new FormClosedEventHandler(this.dispatchInpu_FormClosed);
        }

        /// <summary>
        /// 掛率マスタ引用登録フォーム閉じるイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.03.27</br>
        /// </remarks>
        private void dispatchInpu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
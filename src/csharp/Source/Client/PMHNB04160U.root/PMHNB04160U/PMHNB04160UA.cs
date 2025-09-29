//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 担当者別実績照会
// プログラム概要   : 担当者別実績照会一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/01  修正内容 : 新規作成
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
    /// 担当者別実績照会 フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 担当者別実績照会 フレームのフォームクラスです。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2008.12.01</br>
    /// </remarks>
    public partial class PMHNB04160UA : Form
    {
        /// <summary>PMHNB04161UAオブジェクト</summary>
        /// <remarks></remarks>
        PMHNB04161UA _employeeResultsForm;

        #region Constroctors
        /// <summary>
        /// PMHNB04160UAクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public PMHNB04160UA()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>フォームロード</summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している<see cref="EventArgs"/>。</param>
        /// <remarks>
        /// <br>Note: </br>
        /// <br>Programmer	: 汪千来</br>	
        /// <br>Date: 2008.12.01</br>
        /// </remarks>
        private void PMHNB04160UA_Load(object sender, EventArgs e)
        {
            this._employeeResultsForm = new PMHNB04161UA();
            this._employeeResultsForm.TopLevel = false;
            this._employeeResultsForm.FormBorderStyle = FormBorderStyle.None;
            this._employeeResultsForm.Show();
            this._employeeResultsForm.Dock = DockStyle.Fill;
            this.Text = this._employeeResultsForm.Text;
            this.Controls.Add(this._employeeResultsForm);

            this._employeeResultsForm.FormClosed += new FormClosedEventHandler(this.employeeResults_FormClosed);
        }

        /// <summary>画面閉じる処理</summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している<see cref="EventArgs"/>。</param>
        /// <remarks>
        /// <br>Note: </br>
        /// <br>Programmer	: 汪千来</br>	
        /// <br>Date: 2008.12.01</br>
        /// </remarks>
        private void employeeResults_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
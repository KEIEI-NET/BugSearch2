//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール送信履歴表示
// プログラム概要   : メール送信履歴表示一覧を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2010/05/25  修正内容 : 新規作成
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
    /// メール送信履歴表示 フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メール送信履歴表示 フレームのフォームクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public partial class PMKHN04150UA : Form
    {
        /// <summary>PMKHN04151UAオブジェクト</summary>
        /// <remarks></remarks>
        PMKHN04151UA _mailHistoryForm;

        #region Constroctors
        /// <summary>
        /// PMKHN04150UAクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期化を行いします。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04150UA()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>フォームロード</summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している<see cref="EventArgs"/>。</param>
        /// <remarks>
        /// <br>Note:         フォームロードを行いします。</br>
        /// <br>Programmer	: 呉元嘯</br>	
        /// <br>Date:         2010/05/25</br>
        /// </remarks>
        private void PMKHN04150UA_Load(object sender, EventArgs e)
        {
            this._mailHistoryForm = new PMKHN04151UA();
            this._mailHistoryForm.TopLevel = false;
            this._mailHistoryForm.FormBorderStyle = FormBorderStyle.None;
            this._mailHistoryForm.Show();
            this._mailHistoryForm.Dock = DockStyle.Fill;
            this.Text = this._mailHistoryForm.Text;
            this.Controls.Add(this._mailHistoryForm);

            this._mailHistoryForm.FormClosed += new FormClosedEventHandler(this.MailHistoryForm_FormClosed);
        }

        /// <summary>画面閉じる処理</summary>
        /// <param name="sender">イベントのソース</param>
        /// <param name="e">イベントデータを格納している<see cref="EventArgs"/>。</param>
        /// <remarks>
        /// <br>Note:         画面閉じる処理を行いします。</br>
        /// <br>Programmer	: 呉元嘯</br>	
        /// <br>Date:         2010/05/25</br>
        /// </remarks>
        private void MailHistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
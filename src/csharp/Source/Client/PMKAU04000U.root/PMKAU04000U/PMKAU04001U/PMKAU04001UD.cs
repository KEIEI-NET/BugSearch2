//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先電子元帳
// プログラム概要   : 得意先電子元帳 フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/10/27  修正内容 : 新規作成
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
    /// 得意先電子元帳原価印刷設定画面
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳原価印刷設定UIクラスです。</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/10/27</br>
    public partial class PMKAU04001UD : Form
    {
        #region プライベートメンバ
        private int _genKaDiv = 0;//原価表示フラグ
        private DialogResult _dialogResult = DialogResult.Cancel;
        #endregion // プライベートメンバ

        #region プロパティ

        // 原価表示フラグ０：表示１：表示しない
        public int GenKaDiv
        {
            get { return _genKaDiv; }
            set { _genKaDiv = value; }
        }

        // フォーム終了ステータス
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }
        #endregion

        #region コンストラクタ
        public PMKAU04001UD()
        {
            InitializeComponent();
            //画面初期化
            this.tComboEditor_GenKaDispDiv.Value = 0;
        }
        #endregion

        #region イベント
        /// <summary>
        /// OKボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : OKボタンをクリックする。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/10/27</br>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            this._genKaDiv = Convert.ToInt32(this.tComboEditor_GenKaDispDiv.Value);
            this._dialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 終了ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : 終了ボタンをクリックする。</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/10/27</br>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this._dialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion イベント

    }
}
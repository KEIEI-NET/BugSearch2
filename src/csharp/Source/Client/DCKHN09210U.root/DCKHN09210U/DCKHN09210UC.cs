//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 品名表示パターン設定(HELP)
// プログラム概要   : 品名表示パターン設定(HELP)
//----------------------------------------------------------------------------//
//                (c)Copyright 2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2010/12/03  修正内容 : 新規作成
//                                  品名表示区分へのＨＥＬＰを追加
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
    /// 品名表示パターン設定(HELP)
    /// </summary>
    /// <remarks>
    /// <br>Note		: 品名表示パターン設定(HELP)</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2010/12/03</br>
    /// </remarks>
    public partial class DCKHN09210UC : Form
    {
        /// <summary>
        /// 品名表示パターン設定(HELP)
        /// </summary>
        /// <remarks>
        /// <br>Note		: 品名表示パターン設定(HELP)</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2010/12/03</br>
        /// </remarks>
        public DCKHN09210UC()
        {
            InitializeComponent();
        }

        #region OK
        /// <summary>
        /// 画面を閉じる([OK]ボタンをクリックする。)
        /// </summary>
        /// <remarks>
        /// <br>Note		: 品名表示パターン設定(HELP)画面を閉じる。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2010/12/03</br>
        /// </remarks>
        private void ubtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion // OK

        #region Escキー
        /// <summary>
        /// 画面を閉じる(ＥＳＣキーをクリックする。)
        /// </summary>
        /// <remarks>
        /// <br>Note		: 品名表示パターン設定(HELP)画面を閉じる。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2010/12/03</br>
        /// </remarks>
        private void DCKHN09210UC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion 

        private void DCKHN09210UC_Load(object sender, EventArgs e)
        {
            this.ultraLabel1.Text = "　商品マスタ　　　・・\n（変更可）";
            this.ultraLabel2.Text = "　部品マスタ　　　・・\n（提供データ変更不可）";
            this.ultraLabel3.Text = "　検索品名マスタ　・・\n（提供データ変更不可）";
            this.ultraLabel4.Text = "　BLコードマスタ　・・\n（提供データ変更可）";
            this.ultraLabel5.Text = "任意設定している品名\n品番で意味合いを持たせて表示する場合に有効";
            this.ultraLabel6.Text = "品番毎にメーカーが設定している品名\n一般に流通している品名を表示する場合に有効";
            this.ultraLabel7.Text = "BLコード毎にメーカーが設定している品名\n一般に流通している品名を表示する場合に有効";
            this.ultraLabel8.Text = "BLコード毎にＰＭで設定している品名\nメーカーに依存せず、品名を表示する場合に有効";
        }
    }
}
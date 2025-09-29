//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品不可設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
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
    /// 返品不可設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品不可設定のフォームクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.05.01</br>
    /// </remarks>
    public partial class PMKHN09500UA : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 返品不可設定のフォームクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.01</br>
        /// </remarks>
        public PMKHN09500UA()
        {
            InitializeComponent();
        }

        private PMKHN09501UA _goodsNoReturnInput;

        /// <summary>
        /// 画面処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void PMKHN09500UA_Load(object sender, EventArgs e)
        {
            this._goodsNoReturnInput = new PMKHN09501UA();
            this._goodsNoReturnInput.TopLevel = false;
            this._goodsNoReturnInput.FormBorderStyle = FormBorderStyle.None;
            this._goodsNoReturnInput.Show();
            this._goodsNoReturnInput.Dock = DockStyle.Fill;
            this.Text = this._goodsNoReturnInput.Text;
            this.Controls.Add(this._goodsNoReturnInput);

            this._goodsNoReturnInput.FormClosed += new FormClosedEventHandler(this.GoodsNoReturnInput_FormClosed);
        }

        /// <summary>
        /// 画面閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void GoodsNoReturnInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
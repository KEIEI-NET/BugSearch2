//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル循環棚卸照会
// プログラム概要   : ハンディターミナル循環棚卸照会フレーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ハンディターミナル循環棚卸照会フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル循環棚卸照会を行います。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public partial class PMHND04400UA : Form
    {
        /// <summary>
        /// ハンディターミナル循環棚卸照会フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ハンディターミナル循環棚卸照会フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public PMHND04400UA()
        {
            InitializeComponent();
        }

        private PMHND04401UA InventInfoForm;

        /// <summary>
        /// Form.Load イベント (PMHND04400U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void PMHND04400UA_Load(object sender, EventArgs e)
        {
            this.InventInfoForm = new PMHND04401UA();
            this.InventInfoForm.TopLevel = false;
            this.InventInfoForm.FormBorderStyle = FormBorderStyle.None;
            this.InventInfoForm.Show();
            this.Controls.Add(this.InventInfoForm);
            this.InventInfoForm.Dock = DockStyle.Fill;

            this.InventInfoForm.FormClosed += new FormClosedEventHandler(this.InventInfoForm_FormClosed);

        }

        /// <summary>
        /// Form.Closed イベント (PMHND04400U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが閉じされるときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void InventInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
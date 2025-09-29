//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカーパターン検索履歴照会
// プログラム概要   : メーカーパターン検索履歴照会フレーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11570249-00 作成担当 : 陳艶丹
// 作 成 日  2020/03/09  修正内容 : 新規作成
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
    /// メーカーパターン検索履歴照会フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカーパターン検索履歴照会を行います。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
	public partial class PMKHN09783UA : Form
	{
        /// <summary>
        /// メーカーパターン検索履歴照会フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーパターン検索履歴照会フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
		public PMKHN09783UA()
		{
			InitializeComponent();
		}

        private PMKHN09783UB MakerGoodsPtrnHisForm;

        /// <summary>
        /// Form.Load イベント (PMKHN09783U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09783UA_Load(object sender, EventArgs e)
        {
            this.MakerGoodsPtrnHisForm = new PMKHN09783UB();
            this.MakerGoodsPtrnHisForm.TopLevel = false;
            this.MakerGoodsPtrnHisForm.FormBorderStyle = FormBorderStyle.None;
            this.MakerGoodsPtrnHisForm.Show();
            this.Controls.Add(this.MakerGoodsPtrnHisForm);
            this.MakerGoodsPtrnHisForm.Dock = DockStyle.Fill;

            this.MakerGoodsPtrnHisForm.FormClosed += new FormClosedEventHandler(this.MakerGoodsPtrnHisForm_FormClosed);

        }

        /// <summary>
        /// Form.Closed イベント (PMKHN09783U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが閉じされるときに発生します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void MakerGoodsPtrnHisForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}
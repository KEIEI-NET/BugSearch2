//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品照会
// プログラム概要   : 検品照会フレーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/07/20  修正内容 : 新規作成
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
    /// 検品照会フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品照会を行います。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/07/20</br>
    /// </remarks>
	public partial class PMHND04200UA : Form
	{
        /// <summary>
        /// 検品照会フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品照会フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
		public PMHND04200UA()
		{
			InitializeComponent();
		}

        private PMHND04201UA InspectInfoForm;

        /// <summary>
        /// Form.Load イベント (PMHND04200U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04200UA_Load(object sender, EventArgs e)
        {
            this.InspectInfoForm = new PMHND04201UA();
            this.InspectInfoForm.TopLevel = false;
            this.InspectInfoForm.FormBorderStyle = FormBorderStyle.None;
            this.InspectInfoForm.Show();
            this.Controls.Add(this.InspectInfoForm);
            this.InspectInfoForm.Dock = DockStyle.Fill;

            this.InspectInfoForm.FormClosed += new FormClosedEventHandler(this.InspectInfoForm_FormClosed);

        }

        /// <summary>
        /// Form.Closed イベント (PMHND04200U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが閉じされるときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void InspectInfoForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}
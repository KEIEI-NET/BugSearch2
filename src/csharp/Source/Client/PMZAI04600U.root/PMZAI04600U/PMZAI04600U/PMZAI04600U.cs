//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳 フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/04/06  修正内容 : 新規作成
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
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 在庫移動電子元帳 フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫移動電子元帳 フォームクラスです。</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
    /// </remarks>
	public partial class PMZAI04600U : Form
	{
        /// <summary>
        /// PMZAI04600U
        /// </summary>
        public PMZAI04600U()
		{
			InitializeComponent();
		}

        private PMZAI04601UA _customerElecNoteMainForm;

        /// <summary>
        /// ロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ロード処理です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04600U_Load(object sender, EventArgs e)
		{
            this._customerElecNoteMainForm = new PMZAI04601UA();
            this._customerElecNoteMainForm.TopLevel = false;
            this._customerElecNoteMainForm.FormBorderStyle = FormBorderStyle.None;
            this._customerElecNoteMainForm.Show();
            this.Controls.Add(this._customerElecNoteMainForm);
            this._customerElecNoteMainForm.Dock = DockStyle.Fill;

            this._customerElecNoteMainForm.FormClosed += new FormClosedEventHandler(this.CustomerElecNoteMainForm_FormClosed);
		}

        /// <summary>
        /// 子フォームクローズ後イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 子フォームクローズ後イベント処理です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void CustomerElecNoteMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // FormClose前の処理
            _customerElecNoteMainForm.BeforeFormClose();
            this.Close();
        }

        /// <summary>
        /// ウィンドウメッセージ制御処理
        /// </summary>
        /// <param name="m"></param>
        /// <remarks>
        /// <br>Note       : ウィンドウメッセージ制御処理です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        protected override void WndProc( ref Message m )
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if ( m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE )
            {
                // FormClose前の処理
                _customerElecNoteMainForm.BeforeFormClose();
            }
            base.WndProc( ref m );
        }
        /// <summary>
        /// 表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 表示イベント処理です。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2011/04/06</br>
        /// <br></br>
        /// </remarks>
        private void PMZAI04600U_Shown( object sender, EventArgs e )
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }

        private void PMZAI04600U_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;
        }
	}
}
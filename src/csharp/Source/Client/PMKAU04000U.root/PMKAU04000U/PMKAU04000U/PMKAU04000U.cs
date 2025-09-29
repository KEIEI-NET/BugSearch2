//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先電子元帳
// プログラム概要   : 得意先電子元帳 フレーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徳永 俊詞
// 作 成 日  2008/09/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 立谷 亮介 30182
// 修 正 日  2012/06/13  修正内容 : PM.NS 常駐待機高速起動対応
//----------------------------------------------------------------------------//
// 管理番号  11470152-00  作成担当 : 譚洪
// 作 成 日  2018/09/04   修正内容 : 履歴自動表示機能追加対応
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
	public partial class PMKAU04000U : Form
	{
        public PMKAU04000U()
		{
			InitializeComponent();
            this.ShowInTaskbar = false;// -- Add 2012/06/13 30182 R.Tachiya --
        }

        private PMKAU04001UA _customerElecNoteMainForm;

        // --- Add 2011/08/06 duzg for 赤伝発行時、データ送信対応 --->>>
        /// <summary>コマンドライン引数</summary>
        private string[] _commandLineArgs;

        /// <summary>コマンドライン引数</summary>
        public string[] CommandLineArgs
        {
            set { _commandLineArgs = value; }
            get { return this._commandLineArgs; }
        }
        // --- Add 2011/08/06 duzg for 赤伝発行時、データ送信対応 --->>>

        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
        /// <summary>コマンドライン引数</summary>
        private string[] _salesCommandArgs;

        /// <summary>コマンドライン引数</summary>
        public string[] SalesCommandArgs
        {
            set { _salesCommandArgs = value; }
            get { return this._salesCommandArgs; }
        }
        //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<

        /// <summary>Form.Load イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 履歴自動表示機能追加対応</br>
        /// </remarks>
        private void PMKAU04000U_Load(object sender, EventArgs e)
		{
            this.Hide();// -- Add 2012/06/13 30182 R.Tachiya --
            this._customerElecNoteMainForm = new PMKAU04001UA();
            this._customerElecNoteMainForm.CommandLineArgs = CommandLineArgs;// 2011.08.06 duzg for 赤伝発行時、データ送信対応
            this._customerElecNoteMainForm.SalesCommandArgs = SalesCommandArgs;// ADD　2018/09/04 譚洪　履歴自動表示の対応
            this._customerElecNoteMainForm.TopLevel = false;
            this._customerElecNoteMainForm.FormBorderStyle = FormBorderStyle.None;
            this._customerElecNoteMainForm.Show();
            this.Controls.Add(this._customerElecNoteMainForm);
            this._customerElecNoteMainForm.Dock = DockStyle.Fill;

            this._customerElecNoteMainForm.FormClosed += new FormClosedEventHandler(this.CustomerElecNoteMainForm_FormClosed);
            // -- Add St 2012/06/13 30182 R.Tachiya --
            int id = System.Diagnostics.Process.GetCurrentProcess().Id;
            ApplicationWaiter applicationWaiter = new ApplicationWaiter();
            applicationWaiter.SleepUpToFormReView(id);//常駐待機
            this.ShowInTaskbar = true;
            this.Show();
            applicationWaiter.ReViewForm(id);//再表示準備終了
            // -- Add Ed 2012/06/13 30182 R.Tachiya --
        }

        /// <summary>
        /// 子フォームクローズ後イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2018/09/04 譚洪</br>
        /// <br>管理番号   : 11470152-00</br>
        /// <br>           : 履歴自動表示機能追加対応</br>
        /// </remarks>
        private void PMKAU04000U_Shown( object sender, EventArgs e )
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
            //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
            if (this._customerElecNoteMainForm.SalesCommandArgs != null && this._customerElecNoteMainForm.SalesCommandArgs.Length == 2)
            {
                this._customerElecNoteMainForm.ShowCustPrtSlip();
            }
            //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
        }

        private void PMKAU04000U_FormClosing(object sender, FormClosingEventArgs e)
        {
            //-----ADD 2010/12/20----->>>>>
            System.Environment.CurrentDirectory = ConstantManagement_ClientDirectory.NSCurrentDirectory;
            //-----ADD 2010/12/20-----<<<<<
        }
	}
}
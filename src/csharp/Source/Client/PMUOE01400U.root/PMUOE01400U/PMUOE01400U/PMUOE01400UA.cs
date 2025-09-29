//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ復旧処理
// プログラム概要   : ＵＯＥ復旧処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

namespace Broadleaf.Windows.Forms
{
	public partial class PMUOE01400UA : Form
	{
		public PMUOE01400UA()
		{
			InitializeComponent();
		}

		PMUOE01401UA _stockInput;

		private void PMUOE01400UA_Load(object sender, EventArgs e)
		{
			this._stockInput = new PMUOE01401UA();
			this._stockInput.TopLevel = false;
			this._stockInput.FormBorderStyle = FormBorderStyle.None;            
			this._stockInput.Show();
			this._stockInput.Dock = DockStyle.Fill;
			this.Text = this._stockInput.Text;
			this.Controls.Add(this._stockInput);

			this._stockInput.FormClosed += new FormClosedEventHandler(this.StockInput_FormClosed);
		}

		private void StockInput_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}
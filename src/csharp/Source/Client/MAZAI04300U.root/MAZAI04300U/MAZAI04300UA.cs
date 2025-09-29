//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入出庫照会
// プログラム概要   : 在庫入出庫照会フレーム
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070263-00 作成担当 : 時シン
// 作 成 日  2015/03/27  修正内容 : Redmine#44209 在庫入出庫照会画面に「削除済マスタの検索」チェックボタンを追加対応
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
	public partial class MAZAI04300UA : Form
	{
		public MAZAI04300UA()
		{
			InitializeComponent();
		}

		private MAZAI04310UA _stockAcPayHisSearchForm;

        private void MAZAI04300UA_Load(object sender, EventArgs e)
        {
            this._stockAcPayHisSearchForm = new MAZAI04310UA();
            this._stockAcPayHisSearchForm.TopLevel = false;
            this._stockAcPayHisSearchForm.FormBorderStyle = FormBorderStyle.None;
            this._stockAcPayHisSearchForm.Show();
            this.Controls.Add(this._stockAcPayHisSearchForm);
            this._stockAcPayHisSearchForm.Dock = DockStyle.Fill;

            this._stockAcPayHisSearchForm.FormClosed += new FormClosedEventHandler(this.StockAcPayHisSearchForm_FormClosed);

        }

        private void StockAcPayHisSearchForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済マスタの検索」チェックボタンを追加対応------>>>>>
        /// <summary>
        /// Formのcloseイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remark>
        /// <br>Update Note: 2015/03/27 時シン</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           : 在庫入出庫照会画面に「削除済マスタの検索」チェックボタンを追加対応</br>
        /// </remark>
        private void MAZAI04300UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._stockAcPayHisSearchForm.BeforeClose();
        }
        //----- ADD 2015/03/27 時シン Redmine#44209 在庫入出庫照会画面に「削除済マスタの検索」チェックボタンを追加対応------<<<<<

	}
}
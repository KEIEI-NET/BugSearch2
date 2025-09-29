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

namespace Broadleaf.Windows.Forms
{
	public partial class PMKOU04000U : Form
	{
        public PMKOU04000U()
		{
			InitializeComponent();
		}

        private PMKOU04001UA _supplierElecNoteMainForm;

        private void PMKOU04000U_Load(object sender, EventArgs e)
		{
            this._supplierElecNoteMainForm = new PMKOU04001UA();
            this._supplierElecNoteMainForm.TopLevel = false;
            this._supplierElecNoteMainForm.FormBorderStyle = FormBorderStyle.None;
            this._supplierElecNoteMainForm.Show();
            this.Controls.Add(this._supplierElecNoteMainForm);
            this._supplierElecNoteMainForm.Dock = DockStyle.Fill;

            this._supplierElecNoteMainForm.FormClosed += new FormClosedEventHandler(this.SupplierElecNoteMainForm_FormClosed);
		}
        /// <summary>
        /// 子フォームクローズ後イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierElecNoteMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // FormClose前の処理
            _supplierElecNoteMainForm.BeforeFormClose();
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
                _supplierElecNoteMainForm.BeforeFormClose();
            }
            base.WndProc( ref m );
        }
        /// <summary>
        /// フォーム初回表示イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKOU04000U_Shown( object sender, EventArgs e )
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
	}
}
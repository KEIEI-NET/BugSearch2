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
	public partial class PMKOU01100UA : Form
	{
        public PMKOU01100UA()
		{
			InitializeComponent();
		}

        private PMKOU01101UA _supplierCheck;

        private void PMKOU01100UA_Load(object sender, EventArgs e)
        {
            this._supplierCheck = new PMKOU01101UA();
            this._supplierCheck.TopLevel = false;
            this._supplierCheck.FormBorderStyle = FormBorderStyle.None;
            this._supplierCheck.Show();
            this.Controls.Add(this._supplierCheck);
            this._supplierCheck.Dock = DockStyle.Fill;
            this._supplierCheck.FormClosed += new FormClosedEventHandler(this.SupplierCheck_FormClosed);
        }

        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
        /// <summary>
        /// ウィンドウメッセージ制御処理
        /// </summary>
        /// <param name="m">m</param>
        /// <remarks>
        /// <br>Note       : ウィンドウメッセージ制御処理を行います。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2012/08/30</br>
        /// <br>管理番号   : 10801804-00 2012/09/12配信分 Redmine#31879</br>
        /// <br>                           No.1159のグリッドの仕様変更の対応</br>
        /// <br></br>
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                // FormClose前の処理
                _supplierCheck.BeforeFormClose();
            }
            base.WndProc(ref m);
        }
        //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<

        private void SupplierCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879------->>>>>>>
            // FormClose前の処理
            _supplierCheck.BeforeFormClose();
            //------ADD BY 凌小青 on 2012/08/30 for Redmine#31879-------<<<<<<<
            this.Close();
        }
	}
}
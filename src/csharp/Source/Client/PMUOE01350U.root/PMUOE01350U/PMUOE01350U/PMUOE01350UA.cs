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
	public partial class PMUOE01350UA : Form
	{
        private PMUOE01351UA _form;
        
        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMUOE01350UA()
		{
			InitializeComponent();
        }
        #endregion

        #region ■イベント
        #region ▼PMUOE01350UA_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE01350UA_Load(object sender, EventArgs e)
        {
            this._form = new PMUOE01351UA();
            this._form.TopLevel = false;
            this._form.FormBorderStyle = FormBorderStyle.None;
            this._form.Show();
            this.Controls.Add(this._form);
            this._form.Dock = DockStyle.Fill;

            this._form.FormClosed += new FormClosedEventHandler(this.PMUOE01350UA_FormClosed);
        }
        #endregion

        #region ▼PMUOE01350UA_FormClosed
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void PMUOE01350UA_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
        }
        #endregion
        #endregion

    }
}
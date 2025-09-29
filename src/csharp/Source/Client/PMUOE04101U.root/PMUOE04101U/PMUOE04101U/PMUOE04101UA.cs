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
	public partial class PMUOE04101UA : Form
	{
        private PMUOE04102UA _form;
        
        #region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMUOE04101UA()
		{
			InitializeComponent();
        }
        #endregion

        #region ■イベント
        #region ▼PMUOE04101UA_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE04101UA_Load(object sender, EventArgs e)
        {
            this.Text = "UOE回答表示(単体)";        //ADD 2009/01/20 不具合対応[9833]

            this._form = new PMUOE04102UA();
            this._form.TopLevel = false;
            this._form.FormBorderStyle = FormBorderStyle.None;
            this._form.Show();
            this.Controls.Add(this._form);
            this._form.Dock = DockStyle.Fill;

            this._form.FormClosed += new FormClosedEventHandler(this.PMUOE04101UA_FormClosed);
        }
        #endregion

        #region ▼PMUOE04101UA_FormClosed
        /// <summary>
        /// フォームクローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void PMUOE04101UA_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
        }
        #endregion
        #endregion

    }
}
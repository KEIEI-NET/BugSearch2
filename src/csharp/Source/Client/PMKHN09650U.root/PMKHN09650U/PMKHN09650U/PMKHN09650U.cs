using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKHN09650U : Form
    {
        public PMKHN09650U()
        {
            InitializeComponent();
        }

        private PMKHN09621UA _pmkhn09621UA;

        private void PMKHN09650UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09621UA = new PMKHN09621UA();
            this._pmkhn09621UA.TopLevel = false;
            this._pmkhn09621UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09621UA.Show();
            this.Controls.Add(this._pmkhn09621UA);
            this._pmkhn09621UA.Dock = DockStyle.Fill;

            this._pmkhn09621UA.FormClosed += new FormClosedEventHandler(this.PMKHN09621UA_FormClosed);
        }

        private void PMKHN09621UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        //private void PMZAI09200UA_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!this._pmzai09201UA.FormCloseCheckFinish)
        //    {
        //        e.Cancel = true;

        //        // 終了処理前チェック
        //        this._pmzai09201UA.FormClosingCheck();
        //    }
        //    else
        //    {
        //        // XML保存
        //        this._pmzai09201UA.SaveStateXmlData();
        //    }
        //}
    }
}
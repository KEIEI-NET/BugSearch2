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
    public partial class PMZAI09200UA : Form
    {
        public PMZAI09200UA()
        {
            InitializeComponent();
        }

        private PMZAI09201UA _pmzai09201UA;

        private void PMZAI09200UA_Load(object sender, EventArgs e)
        {
            this._pmzai09201UA = new PMZAI09201UA();
            this._pmzai09201UA.TopLevel = false;
            this._pmzai09201UA.FormBorderStyle = FormBorderStyle.None;
            this._pmzai09201UA.Show();
            this.Controls.Add(this._pmzai09201UA);
            this._pmzai09201UA.Dock = DockStyle.Fill;

            this._pmzai09201UA.FormClosed += new FormClosedEventHandler(this.PMZAI09201UA_FormClosed);


        }

        private void PMZAI09201UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMZAI09200UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._pmzai09201UA.FormCloseCheckFinish)
            {
                e.Cancel = true;

                // 終了処理前チェック
                this._pmzai09201UA.FormClosingCheck();
            }
            else
            {
                // XML保存
                this._pmzai09201UA.SaveStateXmlData();
            }
        }
    }
}
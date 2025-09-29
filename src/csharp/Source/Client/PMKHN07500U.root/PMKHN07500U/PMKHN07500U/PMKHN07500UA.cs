using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	public partial class PMKHN07500UA : Form
	{
        public PMKHN07500UA(string parameter)
		{
            InitializeComponent();
            this._parameter = parameter;
		}

        private PMKHN07504UA _mailInputForm;
        private string _parameter;

		private void PMKHN07500UA_Load(object sender, EventArgs e)
		{
            this._mailInputForm = new PMKHN07504UA();
            this._mailInputForm.GetStartParameterEvent += new PMKHN07504UA.GetStartParameterEventHandler(this.GetStartParameter);
            this._mailInputForm.TopLevel = false;
			this._mailInputForm.FormBorderStyle = FormBorderStyle.None;
            this._mailInputForm.Show();
            this.Controls.Add(this._mailInputForm);
			this._mailInputForm.Dock = DockStyle.Fill;
            this.Text = this._mailInputForm.Text;

			this._mailInputForm.FormClosed += new FormClosedEventHandler(this.ResultinquiryForm_FormClosed);
		}

		private void ResultinquiryForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}

        /// <summary>
        /// 起動パラメータ取得処理(メイン画面でデリゲートで使用)
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameter(out string param)
        {
            param = this._parameter;
        }
    }
}
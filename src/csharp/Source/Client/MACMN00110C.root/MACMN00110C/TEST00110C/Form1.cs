using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this._logWriter = new OperationLogWriter();
		}

		private OperationLogWriter _logWriter;

		private void Start_btn_Click(object sender, EventArgs e)
		{
			// ���O�o��
			this._logWriter.WriteOperationLog(null, 0, "Start_btn_Click", OperationLogWriter.emOperation.OPE_UPDATE, 0, "�X�V�e�X�g�@���O�o�͂n�j", "���O�I�y���[�V�����f�[�^����������");
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// �I�y���[�V����۸ފJ�n
//			this._logWriter.StartOperationLog(this, "TEST00110C", "���엚�����O�e�X�g", "Form1");
			this._logWriter.StartOperationLog(null);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._logWriter.ExitOperationLog(this);
		}

        private void New_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void Upd_btn_Click(object sender, EventArgs e)
        {

        }

        private void LogDel_btn_Click(object sender, EventArgs e)
        {

        }

        private void Del_btn_Click(object sender, EventArgs e)
        {

        }

        private void Rev_btn_Click(object sender, EventArgs e)
        {

        }
	}
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�̃t�@�C�����X�V����
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����N���T�[�r�X����
    /// </summary>
    public partial class PMKYO09300UA : Form
    {
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        public PMKYO09300UA()
        {
            InitializeComponent();
        }

        PMKYO09301UA _serviceFiles;

        /// <summary>
        /// ��ʂ�߂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceFiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKYO02000UA_Load(object sender, EventArgs e)
        {
            this._serviceFiles = new PMKYO09301UA();
            this._serviceFiles.TopLevel = false;
            this._serviceFiles.FormBorderStyle = FormBorderStyle.None;
            this._serviceFiles.Show();
            this._serviceFiles.Dock = DockStyle.Fill;
            this.Text = this._serviceFiles.Text;
            this.Controls.Add(this._serviceFiles);
            this._serviceFiles.FormClosed += new FormClosedEventHandler(this.ServiceFiles_FormClosed);
        }
    }
}
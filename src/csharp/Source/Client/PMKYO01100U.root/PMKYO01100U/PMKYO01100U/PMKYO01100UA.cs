//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
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
    public partial class PMKYO01100UA : Form
    {
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        public PMKYO01100UA()
        {
            InitializeComponent();
        }

        PMKYO01101UA _dataReceive;

        /// <summary>
        /// ��ʂ�߂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKYO01100UA_Load(object sender, EventArgs e)
        {
            this._dataReceive = new PMKYO01101UA();
            this._dataReceive.TopLevel = false;
            this._dataReceive.FormBorderStyle = FormBorderStyle.None;
            this._dataReceive.Show();
            this._dataReceive.Dock = DockStyle.Fill;
            this.Text = this._dataReceive.Text;
            this._dataReceive.FormClosed += new FormClosedEventHandler(this.DataReceive_FormClosed);
            this.Controls.Add(this._dataReceive);
        }
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇���ڑ���� �t���[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �t���[���N���X
    /// </summary>
    public partial class PMSCM00200UA : Form
    {
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        public PMSCM00200UA()
        {
            InitializeComponent();
        }

        PMSCM00201UA _form;

        /// <summary>
        /// ��ʂ�߂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKYO02000UA_Load(object sender, EventArgs e)
        {
            this._form = new PMSCM00201UA();
            this._form.TopLevel = false;
            this._form.FormBorderStyle = FormBorderStyle.None;
            this._form.Show();
            this._form.Dock = DockStyle.Fill;
            this.Text = this._form.Text;
            this.Controls.Add(this._form);
            this._form.FormClosed += new FormClosedEventHandler(this.MDI_FormClosed);
        }
    }
}
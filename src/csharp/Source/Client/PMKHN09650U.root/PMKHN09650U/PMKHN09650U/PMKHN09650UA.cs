//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
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
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�}�X�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^UI�t�H�[���N���X</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    public partial class PMKHN09650UA : Form
    {
        /// <summary>
        ///�L�����y�[���ڕW�ݒ�}�X�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���ڕW�ݒ�}�X�^���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        public PMKHN09650UA()
        {
            InitializeComponent();
        }

        private PMKHN09651UA _pmkhn09651UA;

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void PMKHN09650UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09651UA = new PMKHN09651UA();
            this._pmkhn09651UA.TopLevel = false;
            this._pmkhn09651UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09651UA.Show();
            this._pmkhn09651UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmkhn09651UA);

            this._pmkhn09651UA.FormClosed += new FormClosedEventHandler(this.PMKHN09651UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���ڕW�ݒ�}�X�^���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void PMKHN09651UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void PMKHN09650UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
    }
}
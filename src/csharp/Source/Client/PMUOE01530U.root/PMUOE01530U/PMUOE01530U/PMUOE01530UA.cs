//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �O�H��������
// �v���O�����T�v   : �O�H�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : gaoyh
// �� �� ��  2010/04/20  �C�����e : �V�K�쐬
//                                  �O�HWeb-UOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^����O�HWeb-UOE�p�V�X�e���A�g�t�@�C���̍쐬���s��
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
    /// �O�H�����������C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �O�H��������UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: gaoyh</br>
    /// <br>Date		: 2010/04/20</br>
    /// </remarks>
    public partial class PMUOE01530UA : Form
    {
        PMUOE01531UA _pmuoe01531UA;

        /// <summary>
        ///�O�H�����������C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �O�H�����������C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        public PMUOE01530UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �O�H�����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        private void PMUOE01530UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        private void PMUOE01530U_Load(object sender, EventArgs e)
        {
            this._pmuoe01531UA = new PMUOE01531UA();
            this._pmuoe01531UA.TopLevel = false;
            this._pmuoe01531UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01531UA.Show();
            this._pmuoe01531UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01531UA);


            this._pmuoe01531UA.FormClosed += new FormClosedEventHandler(PMUOE01530UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �O�H�����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: gaoyh</br>
        /// <br>Date		: 2010/04/20</br>
        /// </remarks>
        private void PMUOE01530UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�@�C���i�X�g���[���j���N���[�Y
            this._pmuoe01531UA.CloseFileStreamU();

        }
    }
}
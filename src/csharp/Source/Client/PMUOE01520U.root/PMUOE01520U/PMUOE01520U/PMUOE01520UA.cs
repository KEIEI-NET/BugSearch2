//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Y��������
// �v���O�����T�v   : ���Y�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������
// �� �� ��  2010/03/08  �C�����e : �V�K�쐬
//                                  ���YWeb-UOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^������YWeb-UOE�p�V�X�e���A�g�t�@�C���̍쐬���s��
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
    /// ���Y�����������C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���Y��������UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: ������</br>
    /// <br>Date		: 2010/03/08</br>
    /// </remarks>
    public partial class PMUOE01520UA : Form
    {
        PMUOE01521UA _pmuoe01521UA;

        /// <summary>
        ///���Y�����������C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Y�����������C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        public PMUOE01520UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Y�����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        private void PMUOE01520UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        private void PMUOE01520U_Load(object sender, EventArgs e)
        {
            this._pmuoe01521UA = new PMUOE01521UA();
            this._pmuoe01521UA.TopLevel = false;
            this._pmuoe01521UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01521UA.Show();
            this._pmuoe01521UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01521UA);


            this._pmuoe01521UA.FormClosed += new FormClosedEventHandler(PMUOE01520UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Y�����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/03/08</br>
        /// </remarks>
        private void PMUOE01520UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�@�C���i�X�g���[���j���N���[�Y
            this._pmuoe01521UA.CloseFileStreamU();

        }
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �g���^��������
// �v���O�����T�v   : �g���^�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : 杍^
// �� �� ��  2009/12/31  �C�����e : �V�K�쐬
//                                  �g���^�d�q�J�^���O�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^���甭�����M�f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/08/26  �C�����e : Redmine#13666�Ή�
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
    /// �g���^�����������C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �g���^��������UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 杍^</br>
    /// <br>Date		: 2009/12/31</br>
    /// <br>Update Note : 2010/08/26 ������</br>
    /// <br>              Redmine#13666�Ή�</br>
    /// </remarks>
    public partial class PMUOE01510UA : Form
    {
        PMUOE01511UA _pmuoe01511UA;

        /// <summary>
        ///�g���^�����������C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �g���^�����������C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/31</br>
        /// </remarks>
        public PMUOE01510UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �g���^�����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/31</br>
        /// </remarks>
        private void PMUOE01510UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009/12/31</br>
        /// </remarks>
        private void PMUOE01510U_Load(object sender, EventArgs e)
        {
            this._pmuoe01511UA = new PMUOE01511UA();
            this._pmuoe01511UA.TopLevel = false;
            this._pmuoe01511UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01511UA.Show();
            this._pmuoe01511UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01511UA);


            this._pmuoe01511UA.FormClosed += new FormClosedEventHandler(PMUOE01510UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �g���^����������ʂ��I�����܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/08/26</br>
        /// </remarks>
        private void PMUOE01510UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._pmuoe01511UA.closeCheck)
            {
                e.Cancel = true;
            }
        }
    }
}
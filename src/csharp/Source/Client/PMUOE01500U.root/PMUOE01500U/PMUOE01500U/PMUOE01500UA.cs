//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��������
// �v���O�����T�v   : �����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/06/01  �C�����e : �V�K�쐬
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
    /// �����������C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ��������UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: ���M</br>
    /// <br>Date		: 2009/06/01</br>
    /// </remarks>
    public partial class PMUOE01500UA : Form
    {
        PMUOE01501UA _pmuoe01501UA;

        /// <summary>
        ///�����������C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �����������C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/06/01</br>
        /// </remarks>
        public PMUOE01500UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �����������C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/06/01</br>
        /// </remarks>
        private void PMUOE01500UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009/06/01</br>
        /// </remarks>
        private void PMUOE01500U_Load(object sender, EventArgs e)
        {
            this._pmuoe01501UA = new PMUOE01501UA();
            this._pmuoe01501UA.TopLevel = false;
            this._pmuoe01501UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01501UA.Show();
            this._pmuoe01501UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01501UA);


            this._pmuoe01501UA.FormClosed += new FormClosedEventHandler(PMUOE01500UA_FormClosed);
        }
    }
}
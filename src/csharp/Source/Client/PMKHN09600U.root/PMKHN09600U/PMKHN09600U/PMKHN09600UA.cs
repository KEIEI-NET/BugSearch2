//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���Ǘ��}�X�^
// �v���O�����T�v   : �L�����y�[���Ǘ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/28  �C�����e : �V�K�쐬
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
    /// �L�����y�[���Ǘ����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �L�����y�[���Ǘ�UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2009/05/28</br>
    /// </remarks>
    public partial class PMKHN09600UA : Form
    {
        PMKHN09601UA _pmkhn09601UA;

        /// <summary>
        /// �L�����y�[���Ǘ����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[���Ǘ����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009/05/28</br>
        /// </remarks>
        public PMKHN09600UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009/05/28</br>
        /// </remarks>
        private void PMKHN09600UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09601UA = new PMKHN09601UA();
            this._pmkhn09601UA.TopLevel = false;
            this._pmkhn09601UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09601UA.Show();
            this.Controls.Add(this._pmkhn09601UA);
            this._pmkhn09601UA.Dock = DockStyle.Fill;

            this._pmkhn09601UA.FormClosed += new FormClosedEventHandler(PMKHN09600UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �L�����y�[���Ǘ����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009/05/28</br>
        /// </remarks>
        private void PMKHN09600UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H�[���������鎞�ɔ������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private void PMKHN09600UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09601UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09601UA.SaveStateXmlData();
        }
    }
}
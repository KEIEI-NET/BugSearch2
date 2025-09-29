//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d�_�i�ڐݒ�}�X�^
// �v���O�����T�v   : �d�_�i�ڐݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
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
    /// �d�_�i�ڐݒ胁�C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �d�_�i�ڐݒ�UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2009/05/22</br>
    /// </remarks>
    public partial class PMKHN09550UA : Form
    {
        PMKHN09551UA _pmkhn09551UA;

        /// <summary>
        /// �d�_�i�ڐݒ胁�C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d�_�i�ڐݒ胁�C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009/05/22</br>
        /// </remarks>
        public PMKHN09550UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009/05/22</br>
        /// </remarks>
        private void PMKHN09550UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09551UA = new PMKHN09551UA();
            this._pmkhn09551UA.TopLevel = false;
            this._pmkhn09551UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09551UA.Show();
            this.Controls.Add(this._pmkhn09551UA);
            this._pmkhn09551UA.Dock = DockStyle.Fill;

            this._pmkhn09551UA.FormClosed += new FormClosedEventHandler(PMKHN09550UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d�_�i�ڐݒ胁�C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2009/05/22</br>
        /// </remarks>
        private void PMKHN09550UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Date        : 2009/05/22</br>
        /// </remarks>
        private void PMKHN09550UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09551UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09551UA.SaveStateXmlData();
        }
    }
}
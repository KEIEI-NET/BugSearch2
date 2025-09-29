//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �P�i�����ݒ�ꊇ�o�^�E�C��
// �v���O�����T�v   : �|���}�X�^�̒P�i�ݒ蕪��ΏۂɁA�������ꊇ�œo�^�E�C���A�ꊇ�폜�A���p�o�^���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/08/04  �C�����e : �V�K�쐬
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
    /// �P�i�����ݒ�ꊇ�o�^�E�C�����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �P�i�����ݒ�ꊇ�o�^�E�C��UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: �����</br>
    /// <br>Date		: 2010/08/04</br>
    /// </remarks>
    public partial class PMKHN09460UA : Form
    {
        PMKHN09461UA _pmkhn09461UA;

        /// <summary>
        /// �P�i�����ݒ�ꊇ�o�^�E�C�����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �P�i�����ݒ�ꊇ�o�^�E�C�����C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        public PMKHN09460UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        private void PMKHN09460UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09461UA = new PMKHN09461UA();
            this._pmkhn09461UA.TopLevel = false;
            this._pmkhn09461UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09461UA.Show();
            this.Controls.Add(this._pmkhn09461UA);
            this._pmkhn09461UA.Dock = DockStyle.Fill;

            this._pmkhn09461UA.FormClosed += new FormClosedEventHandler(PMKHN09461UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �P�i�����ݒ�ꊇ�o�^�E�C�����C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        private void PMKHN09461UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void PMKHN09460UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09461UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09461UA.SaveStateXmlData();
        }
    }
}
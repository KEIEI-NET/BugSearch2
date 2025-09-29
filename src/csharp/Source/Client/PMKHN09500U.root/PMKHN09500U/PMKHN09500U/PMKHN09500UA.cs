//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi�s�ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
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
    /// <summary>
    /// �ԕi�s�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi�s�ݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.05.01</br>
    /// </remarks>
    public partial class PMKHN09500UA : Form
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ԕi�s�ݒ�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.01</br>
        /// </remarks>
        public PMKHN09500UA()
        {
            InitializeComponent();
        }

        private PMKHN09501UA _goodsNoReturnInput;

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void PMKHN09500UA_Load(object sender, EventArgs e)
        {
            this._goodsNoReturnInput = new PMKHN09501UA();
            this._goodsNoReturnInput.TopLevel = false;
            this._goodsNoReturnInput.FormBorderStyle = FormBorderStyle.None;
            this._goodsNoReturnInput.Show();
            this._goodsNoReturnInput.Dock = DockStyle.Fill;
            this.Text = this._goodsNoReturnInput.Text;
            this.Controls.Add(this._goodsNoReturnInput);

            this._goodsNoReturnInput.FormClosed += new FormClosedEventHandler(this.GoodsNoReturnInput_FormClosed);
        }

        /// <summary>
        /// ��ʕ��鏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private void GoodsNoReturnInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
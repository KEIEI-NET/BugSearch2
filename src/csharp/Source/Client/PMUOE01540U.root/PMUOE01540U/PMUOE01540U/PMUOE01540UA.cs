//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_��������
// �v���O�����T�v   : �}�c�_�����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �����
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//                                  �}�c�_WebUOE�Ƃ̘A�g�p�f�[�^�Ƃ��āAUOE�����f�[�^����}�c�_�p�V�X�e���A�g�A�h���X�̍쐬���s��
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
    /// �}�c�_�����������C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �}�c�_��������UI�N���X��\�����܂��B</br>
    /// <br>Programmer	: �����</br>
    /// <br>Date		: 2011/05/18</br>
    /// </remarks>
    public partial class PMUOE01540UA : Form
    {
        PMUOE01541UA _pmuoe01541UA;

        /// <summary>
        ///�}�c�_�����������C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �}�c�_�����������C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2011/05/18</br>
        /// </remarks>
        public PMUOE01540UA()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �}�c�_���������t�H�[������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �}�c�_���������t�H�[������</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        private void _pmuoe01541UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2011/05/18</br>
        /// </remarks>
        private void PMUOE01540U_Load(object sender, EventArgs e)
        {
            this._pmuoe01541UA = new PMUOE01541UA();
            this._pmuoe01541UA.TopLevel = false;
            this._pmuoe01541UA.FormBorderStyle = FormBorderStyle.None;
            this._pmuoe01541UA.Show();
            this._pmuoe01541UA.Dock = DockStyle.Fill;
            this.Controls.Add(this._pmuoe01541UA);


            this._pmuoe01541UA.FormClosed += new FormClosedEventHandler(_pmuoe01541UA_FormClosed);
        }
    }
}
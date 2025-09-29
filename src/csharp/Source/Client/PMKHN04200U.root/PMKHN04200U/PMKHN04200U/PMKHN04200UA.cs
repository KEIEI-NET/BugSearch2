//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ�
// �v���O�����T�v   : SCM�⍇�����O�e�[�u���ɑ΂��Č����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
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
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    public partial class PMKHN04200UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Е��i���������Ɖ�̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public PMKHN04200UA()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMKHN04201UA _pmKHN04201UA;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private void PMKHN04200UA_Load(object sender, EventArgs e)
        {
            this._pmKHN04201UA = new PMKHN04201UA();
            this._pmKHN04201UA.TopLevel = false;
            this._pmKHN04201UA.FormBorderStyle = FormBorderStyle.None;
            this._pmKHN04201UA.Show();
            this._pmKHN04201UA.Dock = DockStyle.Fill;
            this.Text = this._pmKHN04201UA.Text;
            this.Controls.Add(this._pmKHN04201UA);
            this._pmKHN04201UA.FormClosed += new FormClosedEventHandler(this.PMKHN04200UA_FormClosed);
            this._pmKHN04201UA.SetInitFocus(); // ADD 2010/11/19
        }
        # endregion �� �t�H�[�����[�h ��

        #region �� Private Method ��
        /// <summary>
        /// ��ʕ�������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private void PMKHN04200UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ʕ��鏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private void PMKHN04200UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._pmKHN04201UA.CallBeforeClosing();
        }
        #endregion �� Private Method ��
    }
}
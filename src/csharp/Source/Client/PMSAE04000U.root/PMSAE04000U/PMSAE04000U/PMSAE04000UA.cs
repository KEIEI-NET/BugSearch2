//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\��
// �v���O�����T�v   : ����f�[�^���M���O�e�[�u���ɑ΂��Č����������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhaimm
// �� �� ��  2013/06/26  �C�����e : �V�K�쐬
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
    public partial class PMSAE04000UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���O�\���̃t�H�[���N���X�ł��B</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        public PMSAE04000UA()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMSAE04001UA _PMSAE04001UA;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void PMSAE04000UA_Load(object sender, EventArgs e)
        {
            this._PMSAE04001UA = new PMSAE04001UA();
            this._PMSAE04001UA.TopLevel = false;
            this._PMSAE04001UA.FormBorderStyle = FormBorderStyle.None;
            this._PMSAE04001UA.Show();
            this._PMSAE04001UA.Dock = DockStyle.Fill;
            this.Text = this._PMSAE04001UA.Text;
            this.Controls.Add(this._PMSAE04001UA);
            this._PMSAE04001UA.FormClosed += new FormClosedEventHandler(this.PMSAE04000UA_FormClosed);
            this._PMSAE04001UA.SetInitFocus();
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
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void PMSAE04000UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013/06/26</br>
        /// </remarks>
        private void PMSAE04000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._PMSAE04001UA.CallBeforeClosing();
        }
        #endregion �� Private Method ��
    }
}
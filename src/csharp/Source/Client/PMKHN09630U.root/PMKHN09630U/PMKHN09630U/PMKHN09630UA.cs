//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/05/20  �C�����e : �V�K�쐬
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
    /// �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^UI�t�H�[���N���X</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/05/20</br>
    /// </remarks>
    public partial class PMKHN09630UA : Form
    {
        /// <summary>
        ///�L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public PMKHN09630UA()
        {
            InitializeComponent();
        }

        #region Private Members
        private PMKHN09631UA _pmkhn09631UA;

        #endregion


        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void PMKHN09630UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09631UA = new PMKHN09631UA();

            this._pmkhn09631UA.TopLevel = false;
            this._pmkhn09631UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09631UA.Show();
            this._pmkhn09631UA.Dock = DockStyle.Fill;

            this.Text = this._pmkhn09631UA.Text;

            this.Controls.Add(this._pmkhn09631UA);
            this._pmkhn09631UA.FormClosed += new FormClosedEventHandler(this.PMKHN09630UA_FormClosed);

        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void PMKHN09630UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�o�^���C���t���[����ʂ�\�����܂��B</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private void PMKHN09630UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
    }
}
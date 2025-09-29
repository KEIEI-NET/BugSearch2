//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�|���ꊇ�o�^�E�C���U
// �v���O�����T�v   �F�|���}�X�^�̓o�^�E�C�������ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�����
// �C����    2013/02/17     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
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
    /// �|���ꊇ�o�^�E�C���U���C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �|���ꊇ�o�^�E�C���UUI�N���X��\�����܂��B</br>
    /// <br>Programmer	: �����</br>
    /// <br>Date		: 2013/02/17</br>
    /// </remarks>
    public partial class PMKHN09901UA : Form
    {
        PMKHN09902UA _pmkhn09902UA;

        /// <summary>
        /// �|���ꊇ�o�^�E�C���U���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �|���ꊇ�o�^�E�C���U���C���t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        public PMKHN09901UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        private void PMKHN09901UA_Load(object sender, EventArgs e)
        {
            this._pmkhn09902UA = new PMKHN09902UA();
            this._pmkhn09902UA.TopLevel = false;
            this._pmkhn09902UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn09902UA.Show();
            this.Controls.Add(this._pmkhn09902UA);
            this._pmkhn09902UA.Dock = DockStyle.Fill;

            this._pmkhn09902UA.FormClosed += new FormClosedEventHandler(PMKHN09902UA_FormClosed);
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param> 
        /// <remarks>
        /// <br>Note		: �|���ꊇ�o�^�E�C���U���C���t���[����ʂ��I�����܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        private void PMKHN09902UA_FormClosed(object sender, FormClosedEventArgs e)
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
        /// <br>Date        : 2013/02/17</br>
        /// </remarks>
        private void PMKHN09901UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��ʏ���r
            bool bStatus = this._pmkhn09902UA.CompareScreen();
            if (!bStatus)
            {
                e.Cancel = true;
            }

            // XML�ۑ�
            this._pmkhn09902UA.SaveStateXmlData();
        }

        /// <summary>
        /// ��ʃT�C�Y�ύX�㏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param> 
        /// <remarks>
        /// <br>Note		: ��ʃT�C�Y�ύX�㏈�����ɔ������܂��B</br>
        /// <br>Programmer	: gezh</br>
        /// <br>Date		: 2013/03/25</br>
        /// </remarks>
        private void PMKHN09901UA_SizeChanged(object sender, EventArgs e)
        {
            if (_pmkhn09902UA != null && this.WindowState != FormWindowState.Minimized)
            {
                // �O���b�h�ɃX�N���[���o�[���������x���̐���
                this._pmkhn09902UA.ScrollControl();
            }
        }

    }
}
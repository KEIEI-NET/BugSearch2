//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �i���\���p�^�[���ݒ�(HELP)
// �v���O�����T�v   : �i���\���p�^�[���ݒ�(HELP)
//----------------------------------------------------------------------------//
//                (c)Copyright 2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2010/12/03  �C�����e : �V�K�쐬
//                                  �i���\���敪�ւ̂g�d�k�o��ǉ�
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
    /// �i���\���p�^�[���ݒ�(HELP)
    /// </summary>
    /// <remarks>
    /// <br>Note		: �i���\���p�^�[���ݒ�(HELP)</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2010/12/03</br>
    /// </remarks>
    public partial class DCKHN09210UC : Form
    {
        /// <summary>
        /// �i���\���p�^�[���ݒ�(HELP)
        /// </summary>
        /// <remarks>
        /// <br>Note		: �i���\���p�^�[���ݒ�(HELP)</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2010/12/03</br>
        /// </remarks>
        public DCKHN09210UC()
        {
            InitializeComponent();
        }

        #region OK
        /// <summary>
        /// ��ʂ����([OK]�{�^�����N���b�N����B)
        /// </summary>
        /// <remarks>
        /// <br>Note		: �i���\���p�^�[���ݒ�(HELP)��ʂ����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2010/12/03</br>
        /// </remarks>
        private void ubtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion // OK

        #region Esc�L�[
        /// <summary>
        /// ��ʂ����(�d�r�b�L�[���N���b�N����B)
        /// </summary>
        /// <remarks>
        /// <br>Note		: �i���\���p�^�[���ݒ�(HELP)��ʂ����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2010/12/03</br>
        /// </remarks>
        private void DCKHN09210UC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion 

        private void DCKHN09210UC_Load(object sender, EventArgs e)
        {
            this.ultraLabel1.Text = "�@���i�}�X�^�@�@�@�E�E\n�i�ύX�j";
            this.ultraLabel2.Text = "�@���i�}�X�^�@�@�@�E�E\n�i�񋟃f�[�^�ύX�s�j";
            this.ultraLabel3.Text = "�@�����i���}�X�^�@�E�E\n�i�񋟃f�[�^�ύX�s�j";
            this.ultraLabel4.Text = "�@BL�R�[�h�}�X�^�@�E�E\n�i�񋟃f�[�^�ύX�j";
            this.ultraLabel5.Text = "�C�Ӑݒ肵�Ă���i��\n�i�ԂňӖ��������������ĕ\������ꍇ�ɗL��";
            this.ultraLabel6.Text = "�i�Ԗ��Ƀ��[�J�[���ݒ肵�Ă���i��\n��ʂɗ��ʂ��Ă���i����\������ꍇ�ɗL��";
            this.ultraLabel7.Text = "BL�R�[�h���Ƀ��[�J�[���ݒ肵�Ă���i��\n��ʂɗ��ʂ��Ă���i����\������ꍇ�ɗL��";
            this.ultraLabel8.Text = "BL�R�[�h���ɂo�l�Őݒ肵�Ă���i��\n���[�J�[�Ɉˑ������A�i����\������ꍇ�ɗL��";
        }
    }
}
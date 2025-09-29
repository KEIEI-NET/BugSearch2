//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����M����\��
// �v���O�����T�v   : ���[�����M����\���ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/05/25  �C�����e : �V�K�쐬
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
    /// ���[�����M����\�� �t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����M����\�� �t���[���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2010/05/25</br>
    /// </remarks>
    public partial class PMKHN04150UA : Form
    {
        /// <summary>PMKHN04151UA�I�u�W�F�N�g</summary>
        /// <remarks></remarks>
        PMKHN04151UA _mailHistoryForm;

        #region Constroctors
        /// <summary>
        /// PMKHN04150UA�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������s�����܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/05/25</br>
        /// </remarks>
        public PMKHN04150UA()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>�t�H�[�����[�h</summary>
        /// <param name="sender">�C�x���g�̃\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^���i�[���Ă���<see cref="EventArgs"/>�B</param>
        /// <remarks>
        /// <br>Note:         �t�H�[�����[�h���s�����܂��B</br>
        /// <br>Programmer	: ������</br>	
        /// <br>Date:         2010/05/25</br>
        /// </remarks>
        private void PMKHN04150UA_Load(object sender, EventArgs e)
        {
            this._mailHistoryForm = new PMKHN04151UA();
            this._mailHistoryForm.TopLevel = false;
            this._mailHistoryForm.FormBorderStyle = FormBorderStyle.None;
            this._mailHistoryForm.Show();
            this._mailHistoryForm.Dock = DockStyle.Fill;
            this.Text = this._mailHistoryForm.Text;
            this.Controls.Add(this._mailHistoryForm);

            this._mailHistoryForm.FormClosed += new FormClosedEventHandler(this.MailHistoryForm_FormClosed);
        }

        /// <summary>��ʕ��鏈��</summary>
        /// <param name="sender">�C�x���g�̃\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^���i�[���Ă���<see cref="EventArgs"/>�B</param>
        /// <remarks>
        /// <br>Note:         ��ʕ��鏈�����s�����܂��B</br>
        /// <br>Programmer	: ������</br>	
        /// <br>Date:         2010/05/25</br>
        /// </remarks>
        private void MailHistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�o�ו��i�\��
// �v���O�����T�v   : ���q�o�ו��i�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/09/10  �C�����e : �V�K�쐬
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
    /// ���q�o�ו��i�\��
    /// </summary>
    /// <remarks>
    /// Note       : ���q�o�ו��i�\���ݒ菈���ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.09.10<br />
    /// </remarks>
    public partial class PMSYA04000UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        public PMSYA04000UA()
        {
            InitializeComponent();
        }
        #endregion

        # region �� private field ��

        private PMSYA04001UA _pMSYA04001UA;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void PMSYA04000UA_Load(object sender, EventArgs e)
        {
            this._pMSYA04001UA = new PMSYA04001UA();
            this._pMSYA04001UA.TopLevel = false;
            this._pMSYA04001UA.FormBorderStyle = FormBorderStyle.None;
            this._pMSYA04001UA.Show();
            this._pMSYA04001UA.Dock = DockStyle.Fill;
            this.Text = this._pMSYA04001UA.Text;
            this.Controls.Add(this._pMSYA04001UA);
            this._pMSYA04001UA.FormClosed += new FormClosedEventHandler(this.PMSYA04001UA_FormClosed);
        }
        # endregion �� �t�H�[�����[�h ��

        #region �� Private Method ��
        /// <summary>
        /// ��ʕ��鏈��
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void PMSYA04001UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion �� Private Method ��
    }
}
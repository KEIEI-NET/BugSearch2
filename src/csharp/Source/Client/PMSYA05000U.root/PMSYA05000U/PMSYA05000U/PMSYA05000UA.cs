//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԍ������X�V
// �v���O�����T�v   : �Ԍ������X�V�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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

using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �Ԍ������X�V����
    /// </summary>
    /// <remarks>
    /// Note       : �Ԍ������X�V�����ł��B<br />
    /// Programmer : ���C��<br />
    /// Date       : 2010/04/21<br />
    /// </remarks>
    public partial class PMSYA05000UA : Form
    {
        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMSYA05000UA()
        {
            InitializeComponent();
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� private field ��

        private PMSYA05001UA _updateCountForm;

        # endregion �� private field ��

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// �t�H�[�����[�h�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private void PMSYA05000UA_Load(object sender, EventArgs e)
        {
            this._updateCountForm = new PMSYA05001UA();
            this._updateCountForm.TopLevel = false;
            this._updateCountForm.FormBorderStyle = FormBorderStyle.None;
            this._updateCountForm.Show();
            this._updateCountForm.Dock = DockStyle.Fill;
            this.Text = this._updateCountForm.Text;
            this.Controls.Add(this._updateCountForm);
            this._updateCountForm.FormClosed += new FormClosedEventHandler(this.UpdateCountForm_FormClosed);
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
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        private void UpdateCountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion �� Private Method ��
    }
}
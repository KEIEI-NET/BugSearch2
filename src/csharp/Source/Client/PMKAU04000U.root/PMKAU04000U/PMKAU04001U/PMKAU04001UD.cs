//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�d�q����
// �v���O�����T�v   : ���Ӑ�d�q���� �t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/10/27  �C�����e : �V�K�쐬
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
    /// ���Ӑ�d�q������������ݒ���
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q������������ݒ�UI�N���X�ł��B</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/10/27</br>
    public partial class PMKAU04001UD : Form
    {
        #region �v���C�x�[�g�����o
        private int _genKaDiv = 0;//�����\���t���O
        private DialogResult _dialogResult = DialogResult.Cancel;
        #endregion // �v���C�x�[�g�����o

        #region �v���p�e�B

        // �����\���t���O�O�F�\���P�F�\�����Ȃ�
        public int GenKaDiv
        {
            get { return _genKaDiv; }
            set { _genKaDiv = value; }
        }

        // �t�H�[���I���X�e�[�^�X
        public DialogResult DResult
        {
            get { return _dialogResult; }
            set { _dialogResult = value; }
        }
        #endregion

        #region �R���X�g���N�^
        public PMKAU04001UD()
        {
            InitializeComponent();
            //��ʏ�����
            this.tComboEditor_GenKaDispDiv.Value = 0;
        }
        #endregion

        #region �C�x���g
        /// <summary>
        /// OK�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : OK�{�^�����N���b�N����B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/10/27</br>
        private void uButton_OK_Click(object sender, EventArgs e)
        {
            this._genKaDiv = Convert.ToInt32(this.tComboEditor_GenKaDispDiv.Value);
            this._dialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// �I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note       : �I���{�^�����N���b�N����B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/10/27</br>
        private void uButton_Cancel_Click(object sender, EventArgs e)
        {
            this._dialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion �C�x���g

    }
}
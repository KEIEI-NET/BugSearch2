//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���_�E���Ӑ�I�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// </remarks>
    public partial class PMREC09021UD : Form
    {

        # region �ϐ���`

        # endregion

        #region [ �R���X�g���N�^ ]

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="secCusSetDataTable">�O���b�h�\���p �f�[�^�e�[�u��</param>
        public PMREC09021UD()
        {
            InitializeComponent();
            InitializeForm();

        }

        #endregion

        #region [ �������� ]
        private void InitializeForm()
        {
        }
        #endregion

        #region ColInfo�@�C���^�[�i��

        internal static class ColInfo
        {
        }
        #endregion

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void PMREC09021UD_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09021UD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
        }

        private void PMREC09021UD_Shown(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
        }
        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <returns>DialogResult</returns>
        internal new DialogResult ShowDialog()
        {
            DialogResult ret = base.ShowDialog();

            return ret;
        }

        #endregion

        private void ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {

        }

        private void uButton_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
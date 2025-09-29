//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i�a�k���ގw��j
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i�a�k���ގw��j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2010/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2010/09/26  �C�����e : Redmine#14492�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���ݒ�}�X�^������ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���ݒ�}�X�^������ʗp�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer	: ������</br>
    /// <br>Date		: 2010/08/12</br>
    /// <br>Update Note : 2010/09/26 ������ �d�l�A�� #14492�Ή�</br>
    /// </remarks>
    public partial class PMKHN09474UB : Form
    {
        #region �� Private Members
        private ImageList _imageList16 = null;
        private int _cellMove;
        private RateProtyMngBlCdConstructionAcs _rateProtyMngBlCdConstructionAcs;
        #endregion �� Private Members

        #region �� Constructor
        /// <summary>
        /// �|���ݒ�}�X�^������ʗp���[�U�[�ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^������ʗp���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09474UB()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;

            this._rateProtyMngBlCdConstructionAcs = new RateProtyMngBlCdConstructionAcs();
            this._cellMove = 0;
            // �R���{�{�b�N�X�ݒ�
            this.tComboEditor_CellMove.Items.Clear();
            this.tComboEditor_CellMove.Items.Add(0, "�E");
            this.tComboEditor_CellMove.Items.Add(1, "��");
            this.tComboEditor_CellMove.Value = 0;
        }
        #endregion �� Constructor

        #region �� Public Property

        /// <summary>
        /// �Z���ړ��v���p�e�B
        /// </summary>
        public int CellMove
        {
            get
            {
                return _cellMove;
            }
        }

        #endregion �� Public Property

        #region �� Private Methods
        /// <summary>
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <param name="defaultButton">�����\���{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note        : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         "PMKHN09474U",                     // �A�Z���u��ID
                                         message,                           // �\�����郁�b�Z�[�W
                                         status,                            // �X�e�[�^�X�l
                                         msgButton,                         // �\������{�^��
                                         defaultButton);                    // �����\���{�^��
            return dialogResult;
        }
        #endregion �� Private Methods

        #region �� Control Events
        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br>Update Note : 2010/09/26 ������ �d�l�A�� #14492�Ή�</br>
        /// </remarks>
        private void PMKHN09474UB_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.UNDO;

            this.tComboEditor_CellMove.Value = this._rateProtyMngBlCdConstructionAcs.CellMove;
            this._cellMove = this._rateProtyMngBlCdConstructionAcs.CellMove;// ADD 2010/09/26

        }
        /// <summary>
        /// Button_Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.tComboEditor_CellMove.Value != null)
            {
                this._rateProtyMngBlCdConstructionAcs.CellMove = (int)this.tComboEditor_CellMove.Value;
            }
            this._rateProtyMngBlCdConstructionAcs.Serialize();

            this._cellMove = (int)this.tComboEditor_CellMove.Value;

        }
        /// <summary>
        /// Button_Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ������</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        #endregion �� Control Events

    }
}
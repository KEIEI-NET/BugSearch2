//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�ꊇ�C��
// �v���O�����T�v   �F���Ӑ�̕ύX���ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/11/27     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�ꊇ�C����ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ꊇ�C����ʗp�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/11/20</br>
    /// </remarks>
    public partial class PMKHN09351UC : Form
    {
        #region �� Private Member

        private ImageList _imageList16 = null;
        private CustomerCustomerChangeConstructionAcs _customerCustomerChangeConstructionAcs;

        private int _cellMove;

        #endregion �� Private Member


        #region �� Constructor

        /// <summary>
        /// ���Ӑ�ꊇ�C����ʗp���[�U�[�ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C����ʗp���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09351UC()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._customerCustomerChangeConstructionAcs = new CustomerCustomerChangeConstructionAcs();

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
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // �e�E�B���h�E�t�H�[��
                                         errLevel,                          // �G���[���x��
                                         "PMKHN09351U",                     // �A�Z���u��ID
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
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void MAZAI04350UC_Load(object sender, EventArgs e)
        {
            this.Ok_Button.ImageList = this._imageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.ImageList = this._imageList16;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.UNDO;

            this.tComboEditor_CellMove.Value = this._customerCustomerChangeConstructionAcs.CellMove;
        }

        /// <summary>
        /// Button_Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.tComboEditor_CellMove.Value != null)
            {
                this._customerCustomerChangeConstructionAcs.CellMove = (int)this.tComboEditor_CellMove.Value;
            }
            this._customerCustomerChangeConstructionAcs.Serialize();

            this._cellMove = (int)this.tComboEditor_CellMove.Value;
        }

        /// <summary>
        /// Button_Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/11/20</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion �� Control Events
    }
}
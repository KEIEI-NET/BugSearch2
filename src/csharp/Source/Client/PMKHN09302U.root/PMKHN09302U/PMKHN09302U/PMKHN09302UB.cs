using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
    /// <br>Note       : �|���}�X�^��ʗp�̃��[�U�[�ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : caohh  �A��265</br>
    /// <br>Date       : 2011/08/05</br>
    /// </remarks>
    public partial class PMKHN09302UB : Form
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �|���}�X�^��ʗp���[�U�[�ݒ�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// <br></br>
        /// </remarks>
        public PMKHN09302UB()
        {
            InitializeComponent();
            // �ϐ�������
            _imageList16 = IconResourceManagement.ImageList16;
            _rateInputConstructionAcs = new RateInputConstructionAcs();

            this.tComboEditor1.SelectedIndex = this._rateInputConstructionAcs.SaveInfoDiv;

        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private ImageList _imageList16 = null;
        private RateInputConstructionAcs _rateInputConstructionAcs = null;
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/05</br>
        /// </remarks>
        private void PMKHN09302UB_Load(object sender, EventArgs e)
        {
            this.OK_Button.ImageList = this._imageList16;
            this.Cancel_Button.ImageList = this._imageList16;

            this.OK_Button.Appearance.Image = (int)Size16_Index.DECISION;
            this.Cancel_Button.Appearance.Image = (int)Size16_Index.BEFORE;

            this.tComboEditor1.SelectedIndex = this._rateInputConstructionAcs.SaveInfoDiv;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note�@�@�@  : �{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : caohh</br>
        /// <br>Date        : 2011/08/05</br>
        /// </remarks>
        private void OK_Button_Click(object sender, EventArgs e)
        {
            this._rateInputConstructionAcs.SaveInfoDiv = this.tComboEditor1.SelectedIndex;
            this._rateInputConstructionAcs.Serialize();
        }
        # endregion
    }
}
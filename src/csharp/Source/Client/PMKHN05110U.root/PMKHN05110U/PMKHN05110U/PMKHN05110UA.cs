//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ����C���t���[���N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/01  �C�����e : �V�K�쐬
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
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ����C���t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ����C���t���[���N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/01</br>
    /// </remarks>
    public partial class PMKHN05110UA : Form
    {

        #region -- Member --

        /// <summary>�S���҃}�X�^�R�[�h�ϊ�UI�N���X</summary>
        private PMKHN05111UA chlFrm;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ����C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�S���҃}�X�^�R�[�h�ϊ����C���t���[���N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/01</br>
        /// </remarks>
        public PMKHN05110UA()
        {
            InitializeComponent();
        }

        #endregion

        #region -- Event --

        /// <summary>
        /// Load�C�x���g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʋN�����̏������������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/01<</br>
        /// </remarks>
        private void PMKHN05110UA_Load(object sender, EventArgs e)
        {
            // �S���҃}�X�^�R�[�h�ϊ�UI�N���X�����[�h���܂��B
            this.chlFrm = new PMKHN05111UA();
            this.chlFrm.TopLevel = false;
            this.chlFrm.FormBorderStyle = FormBorderStyle.None;
            this.chlFrm.Show();
            this.Controls.Add(this.chlFrm);
            this.chlFrm.Dock = DockStyle.Fill;

            // �C�x���g�̐ݒ�
            // FormClosing�C�x���g�͎q�t�H�[����FormClosing�C�x���g�ƘA�������܂��B
            this.FormClosing += new FormClosingEventHandler(this.chlFrm.PMKHN05111UA_FormClosing);
        }

        #endregion
    }
}
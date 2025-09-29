//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���z�I���Ɖ�
// �v���O�����T�v   : �n���f�B�^�[�~�i���z�I���Ɖ�t���[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/08/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �n���f�B�^�[�~�i���z�I���Ɖ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���z�I���Ɖ���s���܂��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public partial class PMHND04400UA : Form
    {
        /// <summary>
        /// �n���f�B�^�[�~�i���z�I���Ɖ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���z�I���Ɖ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public PMHND04400UA()
        {
            InitializeComponent();
        }

        private PMHND04401UA InventInfoForm;

        /// <summary>
        /// Form.Load �C�x���g (PMHND04400U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����\�������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void PMHND04400UA_Load(object sender, EventArgs e)
        {
            this.InventInfoForm = new PMHND04401UA();
            this.InventInfoForm.TopLevel = false;
            this.InventInfoForm.FormBorderStyle = FormBorderStyle.None;
            this.InventInfoForm.Show();
            this.Controls.Add(this.InventInfoForm);
            this.InventInfoForm.Dock = DockStyle.Fill;

            this.InventInfoForm.FormClosed += new FormClosedEventHandler(this.InventInfoForm_FormClosed);

        }

        /// <summary>
        /// Form.Closed �C�x���g (PMHND04400U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void InventInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[���i�E�����ꊇ�ݒ�
// �v���O�����T�v   : ���[�U�[���i�E�����𕡐����ꊇ�ŏC���E�o�^����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// ���[�U�[���i�E�����ꊇ�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[���i�E�����ꊇ�ݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.05.05</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.05.05 men �V�K�쐬(DC.NS���痬�p)</br>
    /// </remarks>
    public partial class PMKHN09420UA : Form
    {
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public PMKHN09420UA()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���[�U�[���i�E�����ꊇ�ݒ���
        /// </summary>
        PMKHN09421UA _dataPrice;

        /// <summary>
        /// ��ʂ�߂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private void DataPrice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private void PMKHN09420UA_Load(object sender, EventArgs e)
        {
            this._dataPrice = new PMKHN09421UA();
            this._dataPrice.TopLevel = false;
            this._dataPrice.FormBorderStyle = FormBorderStyle.None;
            this._dataPrice.Show();
            this._dataPrice.Dock = DockStyle.Fill;
            this.Text = this._dataPrice.Text;
            this._dataPrice.FormClosed += new FormClosedEventHandler(this.DataPrice_FormClosed);
            this.Controls.Add(this._dataPrice);
        }
    }
}
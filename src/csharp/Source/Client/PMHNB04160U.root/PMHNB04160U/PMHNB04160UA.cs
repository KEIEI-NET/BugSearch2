//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
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
    /// �S���ҕʎ��яƉ� �t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ� �t���[���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2008.12.01</br>
    /// </remarks>
    public partial class PMHNB04160UA : Form
    {
        /// <summary>PMHNB04161UA�I�u�W�F�N�g</summary>
        /// <remarks></remarks>
        PMHNB04161UA _employeeResultsForm;

        #region Constroctors
        /// <summary>
        /// PMHNB04160UA�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public PMHNB04160UA()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>�t�H�[�����[�h</summary>
        /// <param name="sender">�C�x���g�̃\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^���i�[���Ă���<see cref="EventArgs"/>�B</param>
        /// <remarks>
        /// <br>Note: </br>
        /// <br>Programmer	: ���痈</br>	
        /// <br>Date: 2008.12.01</br>
        /// </remarks>
        private void PMHNB04160UA_Load(object sender, EventArgs e)
        {
            this._employeeResultsForm = new PMHNB04161UA();
            this._employeeResultsForm.TopLevel = false;
            this._employeeResultsForm.FormBorderStyle = FormBorderStyle.None;
            this._employeeResultsForm.Show();
            this._employeeResultsForm.Dock = DockStyle.Fill;
            this.Text = this._employeeResultsForm.Text;
            this.Controls.Add(this._employeeResultsForm);

            this._employeeResultsForm.FormClosed += new FormClosedEventHandler(this.employeeResults_FormClosed);
        }

        /// <summary>��ʕ��鏈��</summary>
        /// <param name="sender">�C�x���g�̃\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^���i�[���Ă���<see cref="EventArgs"/>�B</param>
        /// <remarks>
        /// <br>Note: </br>
        /// <br>Programmer	: ���痈</br>	
        /// <br>Date: 2008.12.01</br>
        /// </remarks>
        private void employeeResults_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/29  �C�����e : Redmine #8136 ���_�Ǘ��^��M�����̒��`�F�b�N�����ύX
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �G���[�\���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �G���[�\���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.07.28</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2011.07.28 �V�K�쐬</br>
    /// </remarks>
    public partial class PMKYO01101UD : Form
    {
        ArrayList _errList;
        public bool _continueFlg;  // ADD 2011/11/29

        /// <summary>
        /// �G���[����
        /// </summary>
        /// <param name="errList"></param>
        public PMKYO01101UD(ArrayList errList)
        {
            InitializeComponent();
            _errList = errList;
            _continueFlg = false;   // ADD 2011/11/29
            //ultraPictureBox_Warning.Image = ;
        }


        /// <summary>
        /// �G���[���ו\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                PMKYO01900UA form = new PMKYO01900UA(_errList);
                form.Show();
            }
            catch { }
        }
        /// <summary>
        /// �I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        // --- ADD 2011/11/29  ---- >>>>
        /// <summary>
        /// ���s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton_Continue_Click(object sender, EventArgs e)
        {
            this._continueFlg = true;

            try
            {
                this.Close();
            }
            catch { }
        }
        // --- ADD 2011/11/29  ---- <<<<
    }
}
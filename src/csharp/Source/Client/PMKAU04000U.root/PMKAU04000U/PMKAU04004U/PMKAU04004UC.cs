//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�d�q����
// �v���O�����T�v   : ���Ӑ�d�q���� �e�L�X�g�o�͗p�����v���O���X�o�[�i����
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�                �쐬�S�� : ������
// �C �� ��  2015/02/05    �C�����e : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �e�L�X�g�o�͗p�����v���O���X�o�[�i����
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�͗p�����v���O���X�o�[�i���󋵃N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2015/02/05</br>
    /// </remarks>
    public partial class PMKAU04004UC : Form
    {
        /// <summary>���o����</summary>
        private int _searchMax;

        /// <summary>
        /// ���o����
        /// </summary>
        public int SearchMax
        {
            get { return _searchMax; }
            set { _searchMax = value; }
        }

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�[�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public PMKAU04004UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// PMKAU04004UC_Load �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : PMKAU04004UC_Load �C�x���g�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void PMKAU04004UC_Load(object sender, EventArgs e)
        {
            this.Cancel_Button.Visible = true;
            this.Cancel_Button.Enabled = true;

            // ��ʐݒ�
            this.ScreenSetting(this._searchMax);
        }

        /// <summary>
        /// ��ʏ����ݒ�
        /// </summary>
        /// <param name="searchMax"></param>
        /// <remarks>
        /// <br>Note       : ��ʏ����ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void ScreenSetting(int searchMax)
        {
            // �ďo���̃X���b�h�𔻒�
            if (this.InvokeRequired == false)
            {
                this.InitialSetting(searchMax);
            }
        }

        /// <summary>
        /// ��ʏ����ݒ�
        /// </summary>
        /// <param name="max"></param>
        /// <remarks>
        /// <br>Note       : ��ʏ����ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void InitialSetting(int max)
        {
            if (max != 0)
            {
                this.Main_ProgressBar.Visible = true;
                this.Main_ProgressBar.Maximum = max;
                this.Main_ProgressBar.Minimum = 0;
            }
            else
            {
                this.Main_ProgressBar.Visible = false;
            }
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵐ݒ菈��
        /// </summary>
        /// <param name="seachCount"></param>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵐ݒ菈��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void ProgressBarUpEvent(int seachCount)
        {
            ProcessSetting(seachCount);
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵐ݒ菈��
        /// </summary>
        /// <param name="cnt"></param>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵐ݒ菈��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void ProcessSetting(int cnt)
        {
            if (this._searchMax != 0)
            {
                this.Main_ProgressBar.Value = cnt;
                this.Main_ProgressBar.Refresh();
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// �L�����Z���{�^���̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^���̃N���b�N�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                    "���o�����𒆒f���Ă�낵���ł����H", -1, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CancelButtonClick != null)
                {
                    CancelButtonClick(sender, e);
                }
            }
        }

        /// <summary>�L�����Z���{�^���̃N���b�N�C�x���g </summary>
        public event EventHandler CancelButtonClick;
    }
}
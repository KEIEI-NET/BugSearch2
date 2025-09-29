//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��������(����)�G���[���b�Z�[�W
// �v���O�����T�v   : ��������(����)�G���[���b�Z�[�W�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00 �쐬�S�� : 杍^
// �� �� ��  2013/08/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ��������(����)�G���[���b�Z�[�W
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��������(����)�G���[���b�Z�[�W</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2013/08/15</br>
    /// </remarks>
    public partial class PMCMN00900UA : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        private const string SELECTRESULT = "SELECTRESULT";
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";

        //private UoeSndRcvCtlAndAutoAcs uoeSndRcvCtlAndAutoAcs;
        private LocalDataStoreSlot selectResult = null;
        private LocalDataStoreSlot msgShowSolt = null;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        public PMCMN00900UA()
        {
            InitializeComponent();
            msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
            if (Thread.GetData(msgShowSolt) != null)
            {
                if ((int)Thread.GetData(msgShowSolt) == 3)
                {
                    this.Text = "�G���[���� �] ����M������";
                }
                else
                {
                    this.Text = "�G���[���� �] �����M������";
                }
            }
        }
        #endregion

        // ===================================================================================== //
        // �p�u�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region public Methods
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : 2013/08/15</br>
        /// </remarks>
        public void ErrorMsgShow(string msg)
        {
            this.ultraLabel1.Text = msg;
            this.ShowDialog();
            Close();
        }
        #endregion

        // ===================================================================================== //
        // ��ʑ��쏈�����N�^
        // ===================================================================================== //
        #region Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void contimueBtn_Click(object sender, EventArgs e)
        {
            Thread.FreeNamedDataSlot(SELECTRESULT);
            selectResult = Thread.AllocateNamedDataSlot(SELECTRESULT);
            Thread.SetData(selectResult, 1);
            Close();
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Thread.FreeNamedDataSlot(SELECTRESULT);
            selectResult = Thread.AllocateNamedDataSlot(SELECTRESULT);
            Thread.SetData(selectResult, 2);
            Close();
        }
        #endregion
    }
}
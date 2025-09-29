//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j
// �v���O�����T�v   : ����f�[�^�e�L�X�g�o�́i�s�l�x�j�@�t���[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : ���N�n��
// �� �� ��  2011/10/31  �C�����e : �V�K�쐬
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
    /// ����f�[�^�e�L�X�g�o�́i�s�l�x�j UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j UI�N���X</br>										
    /// <br>Programmer : ���N�n��</br>										
    /// <br>Date       : 2012/10/31</br>										
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// </remarks>
    public partial class PMKHN07700UA : Form
    {
        #region Public Members
        /// <summary>
        /// ����f�[�^�e�L�X�g�o�́i�s�l�x�j���C���t���[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j���C���t���[���N���X�R���X�g���N�^</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        public PMKHN07700UA()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Members
        private PMKHN07701UA _pmkhn07701UA;
        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�jLoad �C�x���g</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07700UA_Load(object sender, EventArgs e)
        {
            this._pmkhn07701UA = new PMKHN07701UA();

            this._pmkhn07701UA.TopLevel = false;
            this._pmkhn07701UA.FormBorderStyle = FormBorderStyle.None;
            this._pmkhn07701UA.Show();
            this._pmkhn07701UA.Dock = DockStyle.Fill;

            this.Text = this._pmkhn07701UA.Text;

            this.Controls.Add(this._pmkhn07701UA);
            this._pmkhn07701UA.FormClosed += new FormClosedEventHandler(this.PMKHN07700UA_FormClosed);

        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j��ʏI������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07700UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <param name="m">m</param>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j��ʏI������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
            {
                // FormClose�O�̏���
                this._pmkhn07701UA.Close();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����f�[�^�e�L�X�g�o�́i�s�l�x�j��ʕ\������</br>										
        /// <br>Programmer : ���N�n��</br>										
        /// <br>Date       : 2012/10/31</br>										
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// </remarks>
        private void PMKHN07700UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }

        #endregion 
    }
}
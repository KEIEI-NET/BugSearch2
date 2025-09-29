//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E���ח\��
// �v���O�����T�v   : �o�i�E���ח\�� �A�b�v���[�h���f�_�C�A���O
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : ���O
// �� �� �� : 2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using System.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �A�b�v���[�h���f�_�C�A���O�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �A�b�v���[�h���f�_�C�A���O�N���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public partial class PMMAX02000UG : Form
    {
        # region ��private
        /// <summary>�t�@�C��</summary>
        private string _fileName;
        /// <summary>���[�h</summary>
        private int _mode;

        /// <summary>�t�@�C��</summary>
        private string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>���[�h</summary>
        private int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        # endregion

        #region �� Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMMAX02000UG()
        {
            InitializeComponent();
        }

         /// <summary>
        /// �R���X�g���N�^�@Nunit�p
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �A�b�v���[�h���f�_�C�A���O�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UG(string param)
        {
            if (("NUnit").Equals(param))
            {
                // ������
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion

        #region �� Public Method

        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <param name="owner">�ΏۃI�u�W�F�N�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="fileName">�o�̓t�@�C��</param>
        /// <param name="mode">���[�h</param>
        /// <remarks>
        /// <br>Note       : ��� ShowDialog</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public DialogResult ShowDialog(IWin32Window owner, string message, int mode, string fileName)
        {
            this.lbl_Message.Text = message;
            this._mode = mode;
            this._fileName = fileName;
            return base.ShowDialog(owner);
        }

        #endregion

        #region ��Control Event
        /// <summary>
        /// ��� Load�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ��� Load�C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UG_Load(object sender, EventArgs e)
        {
            Bitmap iconBitmap = new Bitmap(288, 32);
            Graphics graphics = Graphics.FromImage(iconBitmap);
            try
            {
                graphics.DrawIcon(SystemIcons.Information, 0, 0);
            }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
            pictureBox_Icon.Image = iconBitmap;
        }

        /// <summary>
        /// ��� Shown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���Shown�C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UG_Shown(object sender, EventArgs e)
        {
            // �A�b�v���[�h���f�_�C�A���O
            if (this._mode == 0)
            {
                this.btn_Open.Focus();
                this.btn_ErrList.Visible = false;
                this.btn_OK.Visible = false;
            }
            // ���iMAX�󋵊Ď��_�C�A���O
            else
            {
                this.btn_ErrList.Focus();
                this.btn_Open.Visible = false;
                this.btn_Yes.Visible = false;
                this.btn_Cancel.Visible = false;
            }
        }

        /// <summary>
        /// �`�F�b�N���X�g���m�F����{�^��Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �`�F�b�N���X�g���m�F����{�^��Click �C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_Open_Click(object sender, EventArgs e)
        {
            Process.Start(_fileName);
            this.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// �`�F�b�N���X�g���m�F����{�^��Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �`�F�b�N���X�g���m�F����{�^��Click �C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_Yes_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// Cancel_Button_Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���~�{�^��Click �C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Abort;
        }

        /// <summary>
        /// �G���[���X�g���C������{�^��������Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �G���[���X�g���C������{�^���������C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_ErrList_Click(object sender, EventArgs e)
        {
            Process.Start(_fileName);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// OK�{�^��������Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : OK�{�^���������C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Yes;
            
        }

        /// <summary>
        /// �u�~�v�{�^��������Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �u�~�v�{�^���������C�x���g</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UG_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
        #endregion

       
    }
}
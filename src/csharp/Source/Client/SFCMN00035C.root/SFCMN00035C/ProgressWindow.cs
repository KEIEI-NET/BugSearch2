//**********************************************************************//
// System           :   �r�e�D�m�d�s                                    //
// Sub System       :                                                   //
// Program name     :   �A�Z���u���z�u����            �@�@�@�@�@�@�@�@�@//
//                  :   SFCMN00036C.DLL        �@�@�@�@�@�@�@�@�@�@�@�@ //
// Name Space       :   Broadleaf.Windows.Forms.                        //
// Programmer       :   ����@�K��                                    //
// Date             :   2006.07.15                                      //
//----------------------------------------------------------------------//
// Update Note      :             �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//
//----------------------------------------------------------------------//
//                 Copyright(c)2006 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Broadleaf.Library.Net.Mail
{

    /// <summary>
    /// �󋵕\���E�C���h�E�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󋵕\���E�C���h�E�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public partial class ProgressWindow : Form
    {
        //  �f���Q�[�g
        delegate void AddStatusDelegate(string Status, bool NoProgressMode);
        delegate void SetTitleDelegate(string Title);
        delegate void SetProgressDelegate(int NowPos, int MaxPos);
        delegate void SetLabelProgressDelegate(int NowPos, int MaxPos);
        delegate void SetButtonVisibleDelegate(bool visible);
        delegate void HideWindowDelegate();

        //  ���������p�̃C�x���g�Q
        private AddStatusDelegate AddStatusProc;
        private SetTitleDelegate SetTitleProc;
        private SetProgressDelegate SetProgressProc;
        private SetLabelProgressDelegate SetLabelProgressProc;
        private SetButtonVisibleDelegate SetButtonVisibleProc;
        private HideWindowDelegate HideWindowProc;

        /// <summary>
        /// ProgressWindow�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ProgressWindow�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public ProgressWindow()
        {
            InitializeComponent();
            AddStatusProc = new AddStatusDelegate(AddStatusProc2);
            SetTitleProc = new SetTitleDelegate(SetTitleProc2);
            SetProgressProc = new SetProgressDelegate(SetProgressProc2);
            SetLabelProgressProc = new SetLabelProgressDelegate(SetLabelProgressProc2);
            SetButtonVisibleProc = new SetButtonVisibleDelegate(SetButtonVisibleProc2);
            HideWindowProc = new HideWindowDelegate(HideWindowProc2);
        }


        /// <summary>
        /// �i���󋵐ݒ菈��
        /// </summary>
        /// <param name="Status">�i���󋵕�����</param>
        /// <param name="NoProgressMode">�����X�N���[����~�ݒ�(True:�X�N���[����~,false:�X�N���[��)</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void AddStatus(string Status, bool NoProgressMode)
        {
            try
            {
                Invoke(AddStatusProc, new object[] { Status, NoProgressMode });
            }
            catch
            {
            }
        }

        /// <summary>
        /// �i���󋵃v���O���X�o�[�ݒ菈��
        /// </summary>
        /// <param name="NowPos">���݃|�W�V����</param>
        /// <param name="MaxPos">�ő咷</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetProgress(int NowPos, int MaxPos)
        {
            try
            {
                Invoke(SetProgressProc, new object[] { NowPos, MaxPos });
            }
            catch
            {
            }
        }

        /// <summary>
        /// �E�C���h�E�^�C�g���ݒ菈��
        /// </summary>
        /// <param name="Title">�E�C���h�E�^�C�g��</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetTitle(string Title)
        {
            try
            {
                Invoke(SetTitleProc, new object[] { Title });
            }
            catch
            {
            }
        }

        /// <summary>
        /// �i���󋵃��x���ݒ菈��
        /// </summary>
        /// <param name="NowPos">���݈ʒu</param>
        /// <param name="MaxPos">�ő�ʒu</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetLabelProgress(int NowPos, int MaxPos)
        {
            try
            {
                Invoke(SetLabelProgressProc, new object[] { NowPos, MaxPos });
            }
            catch
            {
            }
        }

        /// <summary>
        /// ����{�^���\�����䏈��
        /// </summary>
        /// <param name="visible">�\������(True:�\��,false:��\��)</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetButtonVisible(bool visible)
        {
            try
            {
                Invoke(SetButtonVisibleProc, new object[] { visible });
            }
            catch
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// �E�C���h�E��\�����䏈��
        /// </summary>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void HideWindow()
        {
            try
            {
                Invoke(HideWindowProc, new object[] {  });
            }
            catch
            {
            }
        }

        /// <summary>
        /// �i���󋵐ݒ菈��(���������p)
        /// </summary>
        /// <param name="Status">�i���󋵕�����</param>
        /// <param name="NoProgressMode">�����X�N���[����~�ݒ�(True:�X�N���[����~,false:�X�N���[��)</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        private void AddStatusProc2(string Status, bool NoProgressMode)
        {
            try
            {
                lstStatus.Items.Add(Status);
                if (NoProgressMode != true)
                {
                    lstStatus.SelectedIndex = lstStatus.Items.Count - 1;
                }
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// �i���󋵃v���O���X�o�[�ݒ菈��(���������p)
        /// </summary>
        /// <param name="NowPos">���݃|�W�V����</param>
        /// <param name="MaxPos">�ő咷</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetProgressProc2(int NowPos, int MaxPos)
        {
            try
            {
                barProgress.Maximum = MaxPos;
                barProgress.Minimum = 0;
                barProgress.Value = NowPos;
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// �i���󋵃��x���ݒ菈��(���������p)
        /// </summary>
        /// <param name="NowPos">���݈ʒu</param>
        /// <param name="MaxPos">�ő�ʒu</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetLabelProgressProc2(int NowPos, int MaxPos)
        {
            try
            {
                lblProgress.Text = "(" + NowPos.ToString() + "/" + MaxPos.ToString() + ")";
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// �E�C���h�E�^�C�g���ݒ菈��(���������p)
        /// </summary>
        /// <param name="Title">�E�C���h�E�^�C�g��</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [MTAThread]
        public void SetTitleProc2(string Title)
        {
            try
            {
                this.Text = "�i���󋵁F" + Title;
            }
            finally
            {
                Application.DoEvents();
            }
        }

        /// <summary>
        /// ����{�^���\�����䏈��(���������p)
        /// </summary>
        /// <param name="visible">�\������(True:�\��,false:��\��)</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void SetButtonVisibleProc2(bool visible)
        {
            btnFunc.Visible = visible;
        }

        /// <summary>
        /// �E�C���h�E��\�����䏈��(���������p)
        /// </summary>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void HideWindowProc2()
        {
            Hide();
            Application.DoEvents();
        }

        /// <summary>
        /// ����{�^���������C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���������ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void btnFunc_Click(object sender, EventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// �E�C���h�E�T�C�Y�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �E�C���h�E�T�C�Y��ύX�������ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void ProgressWindow_Resize(object sender, EventArgs e)
        {
            //  �T�C�Y�ύX�ɍ��킹�ăR���g���[���̈ʒu�T�C�Y�𒲐����܂�
            barProgress.Width = (int)(pnlBar.ClientSize.Width * .9);
            barProgress.Left = (ClientSize.Width - barProgress.Width) / 2;
            lblProgress.Left = (ClientSize.Width - lblProgress.Width) / 2;
        }

        /// <summary>
        /// �E�C���h�E�\�����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �E�C���h�E��\���������ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void ProgressWindow_Shown(object sender, EventArgs e)
        {
            //  �T�C�Y�ύX�ɍ��킹�ăR���g���[���̈ʒu�T�C�Y�𒲐����܂�
            barProgress.Width = (int)(pnlBar.ClientSize.Width * .9);
            barProgress.Left = (ClientSize.Width - barProgress.Width) / 2;
            lblProgress.Left = (ClientSize.Width - lblProgress.Width) / 2;

        }


    }
}
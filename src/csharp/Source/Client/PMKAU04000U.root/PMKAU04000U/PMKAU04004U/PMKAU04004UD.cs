//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���Ӑ�d�q����
// �v���O�����T�v   : ���Ӑ�d�q���� �e�L�X�g�o�͗p�����v���O���X�o�[�i���󋵂̕\��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2015/02/05    �C�����e : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�d�q���� �e�L�X�g�o�͗p�����v���O���X�o�[�i���󋵂̕\��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�͗p�����v���O���X�o�[�i���󋵂̕\���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2015/02/05</br>
    /// </remarks>
    public class PMKAU04004UD : IDisposable
    {
        // Fields
        private volatile PMKAU04004UC _form;
        private volatile bool _isClosing;
        private bool _isShowing;
        private Form _ownerForm;
        private Thread _showingThread;
        private ManualResetEvent _startEvent;
        private EventHandler _cancelButtonClick;
        /// <summary>���o������</summary>
        private int _searchMax;
        /// <summary>���o����</summary>
        private int _seachCount;

        /// <summary>
        /// ���o����
        /// </summary>
        public int SearchMax
        {
            get { return _searchMax; }
            set { _searchMax = value; }
        }

        /// <summary>
        /// �L�����Z���C�x���g
        /// </summary>
        public event EventHandler CancelButtonClick
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this._cancelButtonClick = (EventHandler)Delegate.Combine(this._cancelButtonClick, value);
            }


            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this._cancelButtonClick = (EventHandler)Delegate.Remove(this._cancelButtonClick, value);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void Close()
        {
            this._isClosing = true;
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.Invoke(new MethodInvoker(this._form.Close));
            }
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void Dispose()
        {
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.Invoke(new MethodInvoker(this._form.Dispose));
            }
        }

        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�[�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public PMKAU04004UD()
        {
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵂̍X�V
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵂̍X�V�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        /// <param name="seachCount"></param>
        public void ProgressBarUpEvent(int seachCount)
        {
            this._seachCount = seachCount;
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.Invoke(new MethodInvoker(this.SetProgressBarUp));
            }
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵂̍X�V
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵂̍X�V�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void SetProgressBarUp()
        {
            if ((this._form != null) && !this._form.IsDisposed)
            {
                this._form.ProgressBarUpEvent(this._seachCount);
            }
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵉�ʂ̕���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵉�ʂ̕���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void _form_Closing(object sender, CancelEventArgs e)
        {
            if (!this._isClosing)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵉�ʂ�Activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵉�ʂ�Activated�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void _form_Activated(object sender, EventArgs e)
        {
            this._form.Activated -= new EventHandler(this._form_Activated);
            this._startEvent.Set();
        }

        /// <summary>
        /// ���C���t�H�[���̎擾
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���C���t�H�[���̎擾�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private Form GetMainForm()
        {
            Form activeForm = null;
            IntPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
            if (mainWindowHandle != IntPtr.Zero)
            {
                Control control = Control.FromHandle(mainWindowHandle);
                if ((control != null) && !control.IsDisposed)
                {
                    activeForm = (Form)control;
                }
            }
            if (activeForm == null)
            {
                activeForm = Form.ActiveForm;
                if (activeForm != null)
                {
                    return activeForm;
                }
                if (System.Windows.Forms.Application.OpenForms.Count > 0)
                {
                    activeForm = System.Windows.Forms.Application.OpenForms[0];
                }
                if (activeForm == null)
                {
                    System.Windows.Forms.Application.DoEvents();
                    activeForm = Form.ActiveForm;
                }
            }
            return activeForm;
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵂̕\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵂̕\���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public void Show()
        {
            this.Show(null);
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵂̕\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵂̕\���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        /// <param name="owner"></param>
        public void Show(Form owner)
        {
            if (!this._isShowing)
            {
                this._ownerForm = owner;
                this._isShowing = true;
                this._isClosing = false;
                this._startEvent = new ManualResetEvent(false);
                this._showingThread = new Thread(new ThreadStart(this.ShowThread));
                this._showingThread.SetApartmentState(ApartmentState.STA);
                this._showingThread.IsBackground = true;
                this._showingThread.Start();
                this._startEvent.WaitOne();
            }
        }

        /// <summary>
        /// �v���O���X�o�[�i���󋵂̕\��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���O���X�o�[�i���󋵂̕\���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        private void ShowThread()
        {
            try
            {
                this._form = new PMKAU04004UC();
                this._form.Closing += new CancelEventHandler(this._form_Closing);
                this._form.Activated += new EventHandler(this._form_Activated);
                this._form.SearchMax = this._searchMax;
                this._form.Height = 126;
                if (this._cancelButtonClick != null)
                {
                    this._form.CancelButtonClick += this._cancelButtonClick;
                }
                if ((this._ownerForm != null) && this._ownerForm.Visible)
                {
                    this._form.StartPosition = FormStartPosition.Manual;
                    this._form.Left = this._ownerForm.Left + ((this._ownerForm.Width - this._form.Width) / 2);
                    this._form.Top = this._ownerForm.Top + ((this._ownerForm.Height - this._form.Height) / 2);
                }
                else
                {
                    Form mainForm = this.GetMainForm();
                    if (mainForm != null)
                    {
                        this._form.StartPosition = FormStartPosition.Manual;
                        this._form.Left = mainForm.Left + ((mainForm.Width - this._form.Width) / 2);
                        this._form.Top = mainForm.Top + ((mainForm.Height - this._form.Height) / 2);
                    }
                    else
                    {
                        this._form.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
                this._form.ShowDialog();
            }
            finally
            {
                this._form.Dispose();
                this._form = null;
                this._isShowing = false;
            }
        }

    }
}

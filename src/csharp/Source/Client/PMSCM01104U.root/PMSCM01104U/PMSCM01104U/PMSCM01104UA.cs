using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    public class PMSCM01104UA : IDisposable
    {

        #region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMSCM01104UA()
        {
        }
        #endregion

        #region IDisposable �����o
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (CallMode == 1)
            {
                if (( this._form2 != null ) && !( this._form2.IsDisposed ))
                {
                    this._form2.Invoke(new MethodInvoker(this._form2.Dispose));
                }
            }
            else
            {
                if (( this._form != null ) && !( this._form.IsDisposed ))
                {
                    this._form.Invoke(new MethodInvoker(this._form.Dispose));
                }
            }
        }
        #endregion

        #region Private Member
        /// <summary>���ʏ�������ʎ���</summary>
        private volatile CommonProcessingFormEntity _form = null;
        private volatile PMSCM01104UC _form2 = null;

        /// <summary>�t�H�[�����\�������܂őҋ@���邽�߂̑ҋ@�n���h��</summary>
        private System.Threading.ManualResetEvent _startEvent;

        /// <summary>�X���b�h</summary>
        private Thread _showingThread = null;

        /// <summary>�^�C�g��</summary>
        private string _title = string.Empty;

        /// <summary>���b�Z�[�W</summary>
        private string _message = string.Empty;

        /// <summary>�L�����Z���{�^���\���L��</summary>
        private bool _dispCancelButton = false;

        /// <summary>�I�[�i�[�t�H�[��</summary>
        private Form _ownerForm = null;

        /// <summary>�\�����t���O</summary>
        private bool _isShowing = false;

        /// <summary>�t�H�[�����R�[�h�ŕ��Ă��邩�������t���O</summary>
        private volatile bool _isClosing = false;

        /// <summary>�L�����Z���{�^�����N���b�N���ꂽ���������t���O</summary>
        private volatile bool _isCanceled = false;

        private int CallMode = 0;// 0:���M�� 1:��M����

        #endregion

        #region Property
        /// <summary>��ʃ^�C�g���v���p�e�B</summary>
        public string Title
        {
            get { return this._title; }
            set
            {
                this._title = value;
                if (( this._form != null ) && !( this._form.IsDisposed ))
                {
                    this._form.Invoke(new MethodInvoker(SetTitle));
                }
            }
        }

        /// <summary>���b�Z�[�W�v���p�e�B</summary>
        /// <value>��ʂɕ\�����镶����</value>
        public string Message
        {
            get { return this._message; }
            set
            {
                this._message = value;
                if (( this._form != null ) && !( this._form.IsDisposed ))
                {
                    this._form.Invoke(new MethodInvoker(SetMessage));
                }
            }
        }

        /// <summary>�L�����Z���{�^���\���L���v���p�e�B</summary>
        /// <value>true:�L�����Z���{�^����\������i���f�@�\����j,false:�L�����Z���{�^����\�����Ȃ��i���f�@�\�Ȃ��j</value>
        public bool DispCancelButton
        {
            get { return this._dispCancelButton; }
            set { this._dispCancelButton = value; }
        }

        /// <summary>�L�����Z�����ꂽ���ǂ���</summary>
        /// <value>true:�L�����Z�����ꂽ,false:�L�����Z������Ă��Ȃ�</value>
        public bool IsCanceled
        {
            get { return this._isCanceled; }
        }
        #endregion

        #region Public Event
        /// <summary>�L�����Z���{�^���N���b�N�C�x���g</summary>
        public event EventHandler CancelButtonClick = null;
        #endregion

        #region Public Method

        public void Show2(Form owner)
        {
            CallMode = 1;

            if (this._isShowing) return;

            _ownerForm = owner;
            this._isShowing = true;
            this._isClosing = false;
            this._isCanceled = false;
            this._startEvent = new System.Threading.ManualResetEvent(false);

            this._showingThread = new Thread(new ThreadStart(ShowThread2));
            this._showingThread.SetApartmentState(ApartmentState.STA);
            this._showingThread.IsBackground = true;
            this._showingThread.Start();

            //�t�H�[�����\�������܂őҋ@����
            this._startEvent.WaitOne();
        }


        /// <summary>
        /// Show����
        /// </summary>
        public void Show(Form owner)
        {

            if (this._isShowing) return;

            _ownerForm = owner;
            this._isShowing = true;
            this._isClosing = false;
            this._isCanceled = false;
            this._startEvent = new System.Threading.ManualResetEvent(false);

            this._showingThread = new Thread(new ThreadStart(ShowThread));
            this._showingThread.SetApartmentState(ApartmentState.STA);
            this._showingThread.IsBackground = true;
            this._showingThread.Start();

            //�t�H�[�����\�������܂őҋ@����
            this._startEvent.WaitOne();
        }

        public int CallDlg()
        {
            return 0;
        }

        /// <summary>
        /// Show����
        /// </summary>
        public void Show()
        {
            //2008.03.17 23011 noguchi
            //�e�t�H�[�����w��̏ꍇ�ɂ͐e�����͂ŒT���悤�ɕύX
            Form activeForm = GetActiveForm();

            Show(activeForm);
        }

        /// <summary>
        /// �N���[�Y����
        /// </summary>
        public void Close()
        {
            // 2008.02.29 ���c Add ������S�� try �` catch �ň͂�

            try
            {
                if (_ownerForm != null)
                {
                    _ownerForm.Activate();
                }

                this._isClosing = true;
                if (( _form != null ) && !( this._form.IsDisposed ))
                {
                    this._form.Invoke(new MethodInvoker(this._form.Close));
                }
                if (_ownerForm != null)
                {
                    _ownerForm.Activate();
                }
            }
            catch { }

            Application.DoEvents();
        }

        /// <summary>
        /// �N���[�Y����
        /// </summary>
        public void Close2()
        {

            try
            {
                if (_ownerForm != null)
                {
                    _ownerForm.Activate();
                }

                this._isClosing = true;
                if (( _form2 != null ) && !( this._form2.IsDisposed ))
                {
                    this._form2.Invoke(new MethodInvoker(this._form2.Close));
                }
                if (_ownerForm != null)
                {
                    _ownerForm.Activate();
                }
            }
            catch { }

            Application.DoEvents();
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Show�X���b�h
        /// </summary>
        private void ShowThread2()
        {
            try
            {
                this._form2 = new PMSCM01104UC();

                //this._form2.Closing += new System.ComponentModel.CancelEventHandler(_form_Closing);
                this._form2.Activated += new EventHandler(_form2_Activated);


                // �I�[�i�[�t�H�[�����ݒ聕�\������Ă���ꍇ
                if (( _ownerForm != null ) && ( _ownerForm.Visible ))
                {
                    // �I�[�i�[�t�H�[���̒����ɉ�ʂ�\��
                    this._form2.StartPosition = FormStartPosition.Manual;
                    this._form2.Left = _ownerForm.Left + ( _ownerForm.Width - this._form2.Width ) / 2;
                    this._form2.Top = _ownerForm.Top + ( _ownerForm.Height - this._form2.Height ) / 2;
                }
                else
                {
                    // 2006.10.24 ADD START ����@����
                    // ���C���t�H�[���擾
                    Form mainForm = this.GetMainForm();
                    if (mainForm != null)
                    {
                        this._form2.StartPosition = FormStartPosition.Manual;
                        this._form2.Left = mainForm.Left + ( mainForm.Width - this._form2.Width ) / 2;
                        this._form2.Top = mainForm.Top + ( mainForm.Height - this._form2.Height ) / 2;
                    }
                    else
                    {
                        this._form2.StartPosition = FormStartPosition.CenterScreen;
                    }
                    // 2006.10.24 ADD END ����@����
                }

                // Thread �̃A�^�b�`
                int fore_thread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
                int this_thread = AppDomain.GetCurrentThreadId();
                AttachThreadInput(this_thread, fore_thread, true);

                // ��ʂ̋N�����@��ύX
                Application.Run(_form2);					// 2007.11.30 ���c Add

                // Thread �̃f�^�b�`
                AttachThreadInput(this_thread, fore_thread, false);
            }
            finally
            {
                this._form2.Dispose();
                this._form2 = null;
                this._isShowing = false;
            }
        }

        /// <summary>
        /// Show�X���b�h
        /// </summary>
        private void ShowThread()
        {
            try
            {
                this._form = new CommonProcessingFormEntity();

                this._form.Text = this._title;
                this._form.statusInfo_ultraLabel.Text = this._message;
                this._form.cancel_ultraButton.Visible = this._dispCancelButton;
                this._form.cancel_ultraButton.Click += new EventHandler(cancel_ultraButton_Click);
                this._form.Closing += new System.ComponentModel.CancelEventHandler(_form_Closing);
                this._form.Activated += new EventHandler(_form_Activated);

                // �L�����Z���{�^���N���b�N�C�x���g���ݒ肳��Ă���ꍇ
                if (CancelButtonClick != null)
                {
                    this._form.cancel_ultraButton.Click += CancelButtonClick;
                }

                // �I�[�i�[�t�H�[�����ݒ聕�\������Ă���ꍇ
                if (( _ownerForm != null ) && ( _ownerForm.Visible ))
                {
                    // �I�[�i�[�t�H�[���̒����ɉ�ʂ�\��
                    this._form.StartPosition = FormStartPosition.Manual;
                    this._form.Left = _ownerForm.Left + ( _ownerForm.Width - this._form.Width ) / 2;
                    this._form.Top = _ownerForm.Top + ( _ownerForm.Height - this._form.Height ) / 2;
                }
                else
                {
                    // 2006.10.24 ADD START ����@����
                    // ���C���t�H�[���擾
                    Form mainForm = this.GetMainForm();
                    if (mainForm != null)
                    {
                        this._form.StartPosition = FormStartPosition.Manual;
                        this._form.Left = mainForm.Left + ( mainForm.Width - this._form.Width ) / 2;
                        this._form.Top = mainForm.Top + ( mainForm.Height - this._form.Height ) / 2;
                    }
                    else
                    {
                        this._form.StartPosition = FormStartPosition.CenterScreen;
                    }
                    // 2006.10.24 ADD END ����@����
                }

                // Thread �̃A�^�b�`
                int fore_thread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
                int this_thread = AppDomain.GetCurrentThreadId();
                AttachThreadInput(this_thread, fore_thread, true);

                // ��ʂ̋N�����@��ύX
                Application.Run(_form);					// 2007.11.30 ���c Add

                // Thread �̃f�^�b�`
                AttachThreadInput(this_thread, fore_thread, false);
            }
            finally
            {
                this._form.Dispose();
                this._form = null;
                this._isShowing = false;
            }
        }

        [DllImport("user32.dll")]
        extern static int GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        extern static IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        extern static bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);

        /// <summary>
        /// ���C���t�H�[���擾����
        /// </summary>
        /// <remarks>
        /// <br>Note		:</br>
        /// <br>Programmer	: 99033 iwamoto</br>
        /// <br>Date		: 2006.10.24</br>
        /// <br></br>
        /// </remarks>
        private Form GetMainForm()
        {
            Form mainForm = null;

            IntPtr hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (hWnd != IntPtr.Zero)
            {
                Control control = Form.FromHandle(hWnd);
                if (( control != null ) && ( !control.IsDisposed ))
                {
                    mainForm = (Form)control;
                }
            }

            if (mainForm == null)
            {
                mainForm = Form.ActiveForm;
                if (mainForm == null)
                {
                    if (System.Windows.Forms.Application.OpenForms.Count > 0)
                    {
                        mainForm = System.Windows.Forms.Application.OpenForms[0];
                    }

                    // ���b�Z�[�W�����ׂď�������ActiveForm�擾
                    if (mainForm == null)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        mainForm = Form.ActiveForm;
                    }
                }
            }

            return mainForm;
        }

        /// <summary>
        /// �A�N�e�B�u�t�H�[�����擾���܂��B
        /// ��Q�Ή��ō쐬
        /// �p�N������SFCMN00001U��TMsgDsp
        /// </summary>
        /// <remarks>
        /// 2008.03.17 23011 noguchi
        /// </remarks>
        /// <returns></returns>
        private Form GetActiveForm()
        {
            Form activeForm = Form.ActiveForm;

            //** MainWindowHandle **//
            if (activeForm == null)
            {
                IntPtr hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    Control ctrl = Form.FromHandle(hWnd);

                    if (( ctrl != null ) && ( !ctrl.IsDisposed ) && ctrl is Form)
                    {
                        activeForm = ctrl as Form;
                    }
                }

                //** OpenForms **//
                if (activeForm == null)
                {
                    if (System.Windows.Forms.Application.OpenForms.Count > 0)
                    {
                        activeForm = System.Windows.Forms.Application.OpenForms[0];
                    }

                    //** ���b�Z�[�W�����ׂď�������ActiveForm **//
                    if (activeForm == null)
                    {
                        System.Windows.Forms.Application.DoEvents();
                        activeForm = Form.ActiveForm;
                    }
                }
            }

            return activeForm;
        }

        /// <summary>
        /// �t�H�[���A�N�e�B�u
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_Activated(object sender, EventArgs e)
        {
            this._form.Activated -= new EventHandler(_form_Activated);
            this._startEvent.Set();
        }

        /// <summary>
        /// �t�H�[���A�N�e�B�u
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form2_Activated(object sender, EventArgs e)
        {
            this._form2.Activated -= new EventHandler(_form2_Activated);
            this._startEvent.Set();
        }

        /// <summary>
        /// �t�H�[���N���[�W���O
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this._isClosing)
            {
                e.Cancel = true;
                this._isCanceled = true;
            }
        }

        /// <summary>
        /// �L�����Z���{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_ultraButton_Click(object sender, EventArgs e)
        {
            this._isCanceled = true;
        }

        /// <summary>
        /// �^�C�g���ݒ菈��
        /// </summary>
        private void SetTitle()
        {
            if (( this._form != null ) && !( this._form.IsDisposed ))
            {
                this._form.Text = this._title;
            }
        }

        /// <summary>
        /// ���b�Z�[�W�ݒ菈��
        /// </summary>
        private void SetMessage()
        {
            if (( this._form != null ) && !( this._form.IsDisposed ))
            {
                this._form.statusInfo_ultraLabel.Text = this._message;
            }
        }
        #endregion
    }
}

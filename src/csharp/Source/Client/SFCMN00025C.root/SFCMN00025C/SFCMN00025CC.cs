using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �X�v���b�V���E�B���h�E�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �X�v���b�V���E�B���h�E��\������N���X�ł��i���C���t�H�[����Shown�C�x���g�Ŏ����I�ɏ����܂��j</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/01/05</br>
    /// </remarks>
    public class SplashWindow
    {
        #region �� Private Member
        //Splash�t�H�[��
        private static FloatingWindowF _form = null;
        //���C���t�H�[��
        private static System.Windows.Forms.Form _mainForm = null;
        //Splash��\������X���b�h
        private static System.Threading.Thread _thread = null;
        //lock�p�̃I�u�W�F�N�g
        private static readonly object syncObject = new object();
        #endregion

        #region �� Public Method
        /// <summary>
        /// Splash�t�H�[����\������
        /// </summary>
        /// <param name="mainForm">���C���t�H�[��</param>
        public static void ShowSplash(System.Windows.Forms.Form mainForm)
        {
            if (_form != null || _thread != null)
                return;

            _mainForm = mainForm;
            //���C���t�H�[����Activated�C�x���g��Splash�t�H�[��������
            if (_mainForm != null)
            {
                _mainForm.Shown += new EventHandler(MainForm_Shown);
            }

            //�X���b�h�̍쐬
            _thread = new System.Threading.Thread(
                new System.Threading.ThreadStart(StartThread));
            _thread.Name = "SplashForm";
            _thread.IsBackground = true;
            _thread.ApartmentState = System.Threading.ApartmentState.STA;
            //�X���b�h�̊J�n
            _thread.Start();
        }

        /// <summary>
        /// Splash�t�H�[����\������
        /// </summary>
        public static void ShowSplash()
        {
            ShowSplash(null);
        }

        /// <summary>
        /// Splash�t�H�[��������
        /// </summary>
        public static void CloseSplash()
        {
            lock (syncObject)
            {
                if (_form != null && _form.IsDisposed == false)
                {
                    //Splash�t�H�[�������
                    //Invoke���K�v�����ׂ�
                    if (_form.InvokeRequired)
                        _form.Invoke(new System.Windows.Forms.MethodInvoker(_form.Close));
                    else
                        _form.Close();
                }

                if (_mainForm != null)
                {
                    _mainForm.Activated -= new EventHandler(MainForm_Shown);
                    //���C���t�H�[�����A�N�e�B�u�ɂ���
                    _mainForm.Activate();
                }

                _form = null;
                _thread = null;
                _mainForm = null;
            }
        }
        #endregion

        #region �� Private Method
        /// <summary>
        /// �X���b�h�ŊJ�n���郁�\�b�h
        /// </summary>
        private static void StartThread()
        {
            //Splash�t�H�[�����쐬
            _form = new FloatingWindowF();
            //Splash�t�H�[����\������
            System.Windows.Forms.Application.Run(_form);
        }

        /// <summary>
        /// ���C���t�H�[����Shown���ꂽ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MainForm_Shown(object sender, EventArgs e)
        {
            //Splash�t�H�[�������
            CloseSplash();
        }
        #endregion

    }
}

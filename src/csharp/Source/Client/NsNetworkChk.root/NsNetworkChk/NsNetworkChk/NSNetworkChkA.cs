using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

using Broadleaf.NSNetworkChk.UI;

namespace Broadleaf.NSNetworkChk.UI
{
    /// <summary>
    /// AWS�ʐM�e�X�g���C��EXE
    /// </summary>
    /// <remarks>
    /// <br>Note       : AWS�ʐM�e�X�g�̃��C���ƂȂ�EXE�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2019.01.02</br>
    /// </remarks>
    public partial class NSNetworkChkA : ApplicationContext
    {
        //=========================================================================================
        // �R���X�g���N�^
        //=========================================================================================
        #region Constructors
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public NSNetworkChkA()
        {
            nSNetworkTest_Form = new NSNetworkChk_Form();
            nSNetworkTest_Form.Opacity = 0;
            nSNetworkTest_Form.TopMost = false;
            nSNetworkTest_Form.FormClosing += new FormClosingEventHandler(OnFormClosed);
            System.Windows.Forms.Application.DoEvents();
            nSNetworkTest_Form.AutoNSNetworkTest(1);
            nSNetworkTest_Form.Opacity = 0;
            nSNetworkTest_Form.ShowInTaskbar = false;
            nSNetworkTest_Form.ShowIcon = false;
        }

        #endregion

        //=========================================================================================
        // ���������o
        //=========================================================================================
        #region Private Members
        /// <summary>AWS�ʐM�e�X�g���C���t���[��</summary>
        private NSNetworkChk_Form nSNetworkTest_Form = null;
        #endregion

        /// <summary>
        /// �N���t�H�[���̃N���[�Y�C�x���g�n���h���ł��B
        /// </summary>
        private void OnFormClosed(object sender, EventArgs e)
        {
            // �X���b�h�̃��b�Z�[�W���[�v�I���̌ďo
            ExitThread();
        }

        /// <summary>
        /// �X���b�h�̏I���ł��B
        /// </summary>
        protected override void ExitThreadCore()
        {
            // Application�I�u�W�F�N�g�ɂăX���b�h�I��
            base.ExitThreadCore();
        }
    }
}
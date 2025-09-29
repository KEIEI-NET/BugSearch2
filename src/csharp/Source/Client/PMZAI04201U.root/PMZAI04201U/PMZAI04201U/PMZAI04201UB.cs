//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I���\��UI�@PDF�\���p
// �v���O�����T�v   : �I���\��UI�@PDF�\���p
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : �c����
// �� �� ��  2014/03/05   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PDF�\�����UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : PDF�\�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
    /// <br>Programmer  : �c����</br>
    /// <br>Date        : 2014/03/05</br>
    /// </remarks>
    public partial class PMZAI04201UB : Form, IDisposable
    {
        [DllImport("ole32.dll")]
        extern static void CoFreeUnusedLibraries();

        private Form _ownerForm;
        private DCCMN04000UB _pdfViewer = new DCCMN04000UB();
        private string _pdfName;
        private bool _pdfResult;

        /// <summary>
        /// PDF�\�����UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : PDF�\�����UI�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        /// <param name="ownerForm"></param>
        public PMZAI04201UB(Form ownerForm)
        {
            InitializeComponent();
            _ownerForm = ownerForm;
        }

        /// <summary>
        /// PDF�\����ʂ�Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : PDF�\����ʂ�Load�B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void PMZAI04201UB_Load(object sender, EventArgs e)
        {
            this._pdfViewer = new DCCMN04000UB();
            this.Controls.Add(this._pdfViewer);
            this._pdfViewer.Dock = DockStyle.Fill;

            this.Width = _ownerForm.Width;
            this.Height = _ownerForm.Height;
            this.Left = _ownerForm.Left;
            this.Top = _ownerForm.Top;
        }

        /// <summary>
        /// PDF�\��
        /// </summary>
        /// <param name="pdfName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : PDF�\�����s���B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        public bool PDFShow(string pdfName)
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }

        /// <summary>
        /// PDF�\����ʂ�Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : PDF�\����ʂ�Shown�B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void PMZAI04201UB_Shown(object sender, EventArgs e)
        {
            _pdfResult = this._pdfViewer.PDFShow(_pdfName);
        }

        /// <summary>
        /// PDF�\����ʕ���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : DF�\����ʕ���C�x���g�B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2014/03/05</br>
        /// </remarks>
        private void PMZAI04201UB_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // �u���E�U�R���g���[���𖾊m�ɔj������
                _pdfViewer.Dispose();
                // �j���ׂ̈̎��Ԃ��V�X�e���ɗ^����
                System.Windows.Forms.Application.DoEvents();
            }
            finally
            {
                //  �g�pDLL�����S���
                CoFreeUnusedLibraries();
            }
        }
    }
}
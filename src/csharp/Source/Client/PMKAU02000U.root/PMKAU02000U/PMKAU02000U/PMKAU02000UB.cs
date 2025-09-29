//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������ꗗ�\
// �v���O�����T�v   : �������ꗗ�\���𒊏o���A����EPDF�o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2010/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2010/11/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
// --- ADD m.suzuki 2010/11/02 ---------->>>>>
using System.Runtime.InteropServices;
// --- ADD m.suzuki 2010/11/02 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������ꗗ�\ PDF�\���t�H�[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ꗗ�\PDF�\�����s���t�H�[���ł��B</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2010/07/01</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// </remarks>
	public partial class PMKAU02000UB : Form, IDisposable
	{
        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
        [DllImport( "ole32.dll" )]
        extern static void CoFreeUnusedLibraries();
        // --- ADD m.suzuki 2010/11/02 ----------<<<<<

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="ownerForm"></param>
        public PMKAU02000UB( Form ownerForm )
        {
            InitializeComponent();
            _ownerForm = ownerForm;
        }

        private Form _ownerForm;
        private DCCMN04000UB _pdfViewer = new DCCMN04000UB();
        private string _pdfName;
        private bool _pdfResult;

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_Load(object sender, EventArgs e)
		{
            this._pdfViewer = new DCCMN04000UB();
            this.Controls.Add( this._pdfViewer );
            this._pdfViewer.Dock = DockStyle.Fill;

            if ( _ownerForm != null )
            {
                this.Width = _ownerForm.Width;
                this.Height = _ownerForm.Height;
                this.Left = _ownerForm.Left;
                this.Top = _ownerForm.Top;
            }
		}
        /// <summary>
        /// PDFShow
        /// </summary>
        /// <param name="pdfName"></param>
        /// <returns></returns>
        public bool PDFShow( string pdfName )
        {
            _pdfName = pdfName;
            _pdfResult = false;
            this.ShowDialog();

            return _pdfResult;
        }
        /// <summary>
        /// Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_Shown( object sender, EventArgs e )
        {
            _pdfResult = this._pdfViewer.PDFShow( _pdfName );
        }
        /// <summary>
        /// FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_FormClosing( object sender, FormClosingEventArgs e )
        {
        }
        /// <summary>
        /// FormClosed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKAU02000UB_FormClosed( object sender, FormClosedEventArgs e )
        {
            // --- ADD m.suzuki 2010/11/02 ---------->>>>>
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
            // --- ADD m.suzuki 2010/11/02 ----------<<<<<
        }
        /// <summary>
        /// Dispose
        /// </summary>
        void IDisposable.Dispose()
        {
            // --- DEL m.suzuki 2010/11/02 ---------->>>>>
            //if ( this._pdfViewer != null )
            //{
            //    this.Controls.Remove( this._pdfViewer );
            //    this._pdfViewer.Dispose();
            //}
            // --- DEL m.suzuki 2010/11/02 ----------<<<<<
        }
    }
}